using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using MuhasebeTakip.Models;
using MuhasebeTakip.Managers;

namespace MuhasebeTakip.Forms
{
    public partial class AnaForm : Form
    {
        private IslemYoneticisi _islemYoneticisi;
        private KategoriYoneticisi _kategoriYoneticisi;

        // Form kontrolleri
        private TextBox aciklamaTextBox;
        private TextBox tutarTextBox;
        private ComboBox turComboBox;
        private ComboBox kategoriComboBox;
        private Button ekleButton;
        private Button silButton;
        private DataGridView islemDataGrid;
        private Label grafikBaslikLabel;
        private ListBox grafikListBox;
        private Label toplamGelirLabel;
        private Label toplamGiderLabel;
        private Label netKarLabel;
        private Label islemSayisiLabel;
        private Chart grafik;

        public AnaForm()
        {
            _islemYoneticisi = new IslemYoneticisi();
            _kategoriYoneticisi = new KategoriYoneticisi();

            KontrolleriOlustur();
            FormTasariminiHazirla();
        }

        private void KontrolleriOlustur()
        {
            aciklamaTextBox = new TextBox();
            tutarTextBox = new TextBox();
            turComboBox = new ComboBox();
            kategoriComboBox = new ComboBox();
            ekleButton = new Button();
            silButton = new Button();
            islemDataGrid = new DataGridView();
            grafikBaslikLabel = new Label();
            grafikListBox = new ListBox();
            toplamGelirLabel = new Label();
            toplamGiderLabel = new Label();
            netKarLabel = new Label();
            islemSayisiLabel = new Label();
            grafik = new Chart();
        }

        private void FormTasariminiHazirla()
        {
            // Ana form ayarları
            Text = "Muhasebe Takip Sistemi - OOP";
            Size = new Size(1400, 900); // Form boyutu büyütüldü
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.LightGray;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // Ekleme paneli
            Panel eklemePanel = new Panel();
            eklemePanel.Location = new Point(20, 20);
            eklemePanel.Size = new Size(350, 200);
            eklemePanel.BackColor = Color.White;
            eklemePanel.BorderStyle = BorderStyle.FixedSingle;

            Label baslikLabel = new Label();
            baslikLabel.Text = "Yeni İşlem Ekle";
            baslikLabel.Location = new Point(10, 10);
            baslikLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            baslikLabel.Size = new Size(150, 25);

            Label aciklamaLabel = new Label();
            aciklamaLabel.Text = "Açıklama:";
            aciklamaLabel.Location = new Point(10, 45);
            aciklamaLabel.Size = new Size(80, 20);

            aciklamaTextBox.Location = new Point(100, 43);
            aciklamaTextBox.Size = new Size(200, 20);

            Label tutarLabel = new Label();
            tutarLabel.Text = "Tutar (₺):";
            tutarLabel.Location = new Point(10, 75);
            tutarLabel.Size = new Size(80, 20);

            tutarTextBox.Location = new Point(100, 73);
            tutarTextBox.Size = new Size(100, 20);

            Label turLabel = new Label();
            turLabel.Text = "Tür:";
            turLabel.Location = new Point(10, 105);
            turLabel.Size = new Size(80, 20);

            turComboBox.Location = new Point(100, 103);
            turComboBox.Size = new Size(100, 20);
            turComboBox.Items.AddRange(new string[] { "Gelir", "Gider" });
            turComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            Label kategoriLabel = new Label();
            kategoriLabel.Text = "Kategori:";
            kategoriLabel.Location = new Point(10, 135);
            kategoriLabel.Size = new Size(80, 20);

            kategoriComboBox.Location = new Point(100, 133);
            kategoriComboBox.Size = new Size(150, 20);
            kategoriComboBox.DataSource = _kategoriYoneticisi.TumKategorileriGetir();
            kategoriComboBox.DisplayMember = "Ad";
            kategoriComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            ekleButton.Text = "İşlem Ekle";
            ekleButton.Location = new Point(100, 165);
            ekleButton.Size = new Size(80, 25);
            ekleButton.BackColor = Color.Green;
            ekleButton.ForeColor = Color.White;
            ekleButton.Click += EkleButton_Click;

            silButton.Text = "Seçili Sil";
            silButton.Location = new Point(190, 165);
            silButton.Size = new Size(80, 25);
            silButton.BackColor = Color.Red;
            silButton.ForeColor = Color.White;
            silButton.Click += SilButton_Click;

            eklemePanel.Controls.AddRange(new Control[] {
                baslikLabel, aciklamaLabel, aciklamaTextBox, tutarLabel, tutarTextBox,
                turLabel, turComboBox, kategoriLabel, kategoriComboBox, ekleButton, silButton
            });

            // DataGridView
            islemDataGrid.Location = new Point(20, 240);
            islemDataGrid.Size = new Size(700, 300);
            islemDataGrid.BackgroundColor = Color.White;
            islemDataGrid.AllowUserToAddRows = false;
            islemDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            islemDataGrid.MultiSelect = false;

            // Grafik paneli
            Panel grafikPanel = new Panel();
            grafikPanel.Location = new Point(750, 20);
            grafikPanel.Size = new Size(600, 520); // Panel boyutu büyütüldü
            grafikPanel.BackColor = Color.White;
            grafikPanel.BorderStyle = BorderStyle.FixedSingle;

            grafikBaslikLabel.Text = "Kategorilere Göre Dağılım";
            grafikBaslikLabel.Location = new Point(10, 10);
            grafikBaslikLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            grafikBaslikLabel.Size = new Size(300, 25);

            // Chart kontrolü
            grafik.Location = new Point(10, 40);
            grafik.Size = new Size(580, 300);
            grafik.BackColor = Color.White;
            grafik.BorderlineColor = Color.Black;
            grafik.BorderlineWidth = 1;
            grafik.BorderlineDashStyle = ChartDashStyle.Solid;

            // ListBox (detaylı bilgiler için)
            grafikListBox.Location = new Point(10, 350);
            grafikListBox.Size = new Size(580, 160);
            grafikListBox.Font = new Font("Arial", 10);

            grafikPanel.Controls.Add(grafikBaslikLabel);
            grafikPanel.Controls.Add(grafik);
            grafikPanel.Controls.Add(grafikListBox);

            // Özet paneli
            Panel ozetPanel = new Panel();
            ozetPanel.Location = new Point(750, 560);
            ozetPanel.Size = new Size(600, 150);
            ozetPanel.BackColor = Color.White;
            ozetPanel.BorderStyle = BorderStyle.FixedSingle;

            toplamGelirLabel.Text = "Toplam Gelir: 0 ₺";
            toplamGelirLabel.Location = new Point(20, 20);
            toplamGelirLabel.Size = new Size(200, 25);
            toplamGelirLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            toplamGelirLabel.ForeColor = Color.Green;

            toplamGiderLabel.Text = "Toplam Gider: 0 ₺";
            toplamGiderLabel.Location = new Point(20, 50);
            toplamGiderLabel.Size = new Size(200, 25);
            toplamGiderLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            toplamGiderLabel.ForeColor = Color.Red;

            netKarLabel.Text = "Net Kar/Zarar: 0 ₺";
            netKarLabel.Location = new Point(20, 80);
            netKarLabel.Size = new Size(200, 25);
            netKarLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            netKarLabel.ForeColor = Color.Blue;

            islemSayisiLabel.Text = "Toplam İşlem: 0";
            islemSayisiLabel.Location = new Point(20, 110);
            islemSayisiLabel.Size = new Size(200, 25);
            islemSayisiLabel.Font = new Font("Arial", 10);

            // Gelir/Gider karşılaştırma ek bilgileri
            Label gelirGiderKarsilastirmaLabel = new Label();
            gelirGiderKarsilastirmaLabel.Text = "Gelir/Gider Oranı: -";
            gelirGiderKarsilastirmaLabel.Location = new Point(300, 20);
            gelirGiderKarsilastirmaLabel.Size = new Size(250, 25);
            gelirGiderKarsilastirmaLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            gelirGiderKarsilastirmaLabel.Name = "gelirGiderOranLabel";

            ozetPanel.Controls.AddRange(new Control[] {
                toplamGelirLabel, toplamGiderLabel, netKarLabel, islemSayisiLabel, gelirGiderKarsilastirmaLabel
            });

            Controls.AddRange(new Control[] {
                eklemePanel, islemDataGrid, grafikPanel, ozetPanel
            });

            DataGridKolonlariniOlustur();
            GrafikOlustur();
            GrafikListesiniGuncelle();
        }

        private void GrafikOlustur()
        {
            grafik.Series.Clear();
            grafik.ChartAreas.Clear();
            grafik.Legends.Clear();

            // ChartArea oluştur
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.White;
            chartArea.BorderColor = Color.LightGray;
            chartArea.BorderWidth = 1;
            grafik.ChartAreas.Add(chartArea);

            // Legend oluştur
            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Arial", 9);
            grafik.Legends.Add(legend);

            // Series oluştur
            Series series = new Series("KategoriDagilimi");
            series.Legend = "MainLegend";
            series.ChartType = SeriesChartType.Pie;
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";
            series.Font = new Font("Arial", 8);

            grafik.Series.Add(series);
        }

        private void GrafikGuncelle()
        {
            var dagilim = _islemYoneticisi.KategoriDagilimi();

            if (grafik.Series.Count > 0)
            {
                grafik.Series[0].Points.Clear();

                if (dagilim.Any())
                {
                    // Renk paleti
                    Color[] renkler = {
                        Color.FromArgb(255, 99, 132),   // Kırmızı
                        Color.FromArgb(54, 162, 235),   // Mavi
                        Color.FromArgb(255, 205, 86),   // Sarı
                        Color.FromArgb(75, 192, 192),   // Turkuaz
                        Color.FromArgb(153, 102, 255),  // Mor
                        Color.FromArgb(255, 159, 64),   // Turuncu
                        Color.FromArgb(201, 203, 207),  // Gri
                        Color.FromArgb(255, 99, 255),   // Pembe
                        Color.FromArgb(99, 255, 132),   // Yeşil
                        Color.FromArgb(132, 99, 255)    // Lacivert
                    };

                    int renkIndex = 0;
                    decimal genelToplam = dagilim.Values.Sum();

                    foreach (var kategori in dagilim.OrderByDescending(x => x.Value))
                    {
                        decimal yuzde = genelToplam > 0 ? kategori.Value / genelToplam * 100 : 0;

                        DataPoint point = new DataPoint();
                        point.SetValueXY(kategori.Key, kategori.Value);
                        point.Label = $"%{yuzde:F1}";
                        point.LegendText = $"{kategori.Key} ({kategori.Value:N0} ₺)";
                        point.Color = renkler[renkIndex % renkler.Length];
                        grafik.Series[0].Points.Add(point);

                        renkIndex++;
                    }

                    grafik.Titles.Clear();
                    grafik.Titles.Add("Kategorilere Göre Harcama Dağılımı");
                    grafik.Titles[0].Font = new Font("Arial", 11, FontStyle.Bold);
                    grafik.Titles[0].ForeColor = Color.DarkBlue;
                }
                else
                {
                    grafik.Titles.Clear();
                    grafik.Titles.Add("Henüz veri bulunmuyor");
                    grafik.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);
                    grafik.Titles[0].ForeColor = Color.Gray;
                }
            }
        }

        private void DataGridKolonlariniOlustur()
        {
            islemDataGrid.Columns.Add("Id", "ID");
            islemDataGrid.Columns.Add("Tarih", "Tarih");
            islemDataGrid.Columns.Add("Aciklama", "Açıklama");
            islemDataGrid.Columns.Add("Tutar", "Tutar");
            islemDataGrid.Columns.Add("Tur", "Tür");
            islemDataGrid.Columns.Add("Kategori", "Kategori");

            islemDataGrid.Columns["Id"].Width = 50;
            islemDataGrid.Columns["Tarih"].Width = 100;
            islemDataGrid.Columns["Aciklama"].Width = 200;
            islemDataGrid.Columns["Tutar"].Width = 100;
            islemDataGrid.Columns["Tur"].Width = 80;
            islemDataGrid.Columns["Kategori"].Width = 120;
        }

        private void EkleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GirisleriKontrolEt()) return;

                Islem yeniIslem;
                string secilenTur = turComboBox.SelectedItem.ToString();
                Kategori secilenKategori = (Kategori)kategoriComboBox.SelectedItem;

                // Polimorfizm - Tür kontrolü ile uygun nesne oluşturma
                if (secilenTur == "Gelir")
                {
                    yeniIslem = new Gelir();
                }
                else
                {
                    yeniIslem = new Gider();
                }

                // Kapsülleme - Property'ler üzerinden güvenli atama
                yeniIslem.Tarih = DateTime.Now;
                yeniIslem.Aciklama = aciklamaTextBox.Text.Trim();
                yeniIslem.Tutar = Convert.ToDecimal(tutarTextBox.Text);
                yeniIslem.Kategori = secilenKategori;

                _islemYoneticisi.IslemEkle(yeniIslem);

                DataGridiGuncelle();
                OzetBilgileriGuncelle();
                GrafikGuncelle();
                GrafikListesiniGuncelle();
                FormTemizle();

                MessageBox.Show($"İşlem başarıyla eklendi!\n{yeniIslem.GetDetayBilgi()}",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SilButton_Click(object sender, EventArgs e)
        {
            if (islemDataGrid.SelectedRows.Count > 0)
            {
                int seciliId = Convert.ToInt32(islemDataGrid.SelectedRows[0].Cells["Id"].Value);

                DialogResult sonuc = MessageBox.Show("Seçili işlemi silmek istediğinizden emin misiniz?",
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    if (_islemYoneticisi.IslemSil(seciliId))
                    {
                        DataGridiGuncelle();
                        OzetBilgileriGuncelle();
                        GrafikGuncelle();
                        GrafikListesiniGuncelle();
                        MessageBox.Show("İşlem silindi!", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek işlemi seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool GirisleriKontrolEt()
        {
            if (string.IsNullOrWhiteSpace(aciklamaTextBox.Text))
            {
                MessageBox.Show("Lütfen açıklama giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(tutarTextBox.Text, out decimal tutar) || tutar <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (turComboBox.SelectedItem == null)
            {
                MessageBox.Show("Lütfen işlem türünü seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (kategoriComboBox.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kategori seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void DataGridiGuncelle()
        {
            islemDataGrid.Rows.Clear();

            foreach (var islem in _islemYoneticisi.TumIslemleriGetir())
            {
                islemDataGrid.Rows.Add(
                    islem.Id,
                    islem.Tarih.ToString("dd/MM/yyyy HH:mm"),
                    islem.Aciklama,
                    islem.FormattedTutar,
                    islem.IslemTuru,
                    islem.Kategori.Ad
                );

                int sonSatir = islemDataGrid.Rows.Count - 1;
                islemDataGrid.Rows[sonSatir].DefaultCellStyle.ForeColor =
                    islem is Gelir ? Color.Green : Color.Red;
            }
        }

        private void OzetBilgileriGuncelle()
        {
            toplamGelirLabel.Text = $"Toplam Gelir: {_islemYoneticisi.ToplamGelir:N2} ₺";
            toplamGiderLabel.Text = $"Toplam Gider: {_islemYoneticisi.ToplamGider:N2} ₺";

            decimal netSonuc = _islemYoneticisi.NetKar;
            netKarLabel.Text = $"Net {(netSonuc >= 0 ? "Kar" : "Zarar")}: {Math.Abs(netSonuc):N2} ₺";
            netKarLabel.ForeColor = netSonuc >= 0 ? Color.Green : Color.Red;

            islemSayisiLabel.Text = $"Toplam İşlem: {_islemYoneticisi.ToplamIslemSayisi}";

            // Gelir/Gider oranı hesaplama
            Label gelirGiderOranLabel = Controls.Find("gelirGiderOranLabel", true).FirstOrDefault() as Label;
            if (gelirGiderOranLabel != null)
            {
                if (_islemYoneticisi.ToplamGider > 0)
                {
                    decimal oran = _islemYoneticisi.ToplamGelir / _islemYoneticisi.ToplamGider;
                    gelirGiderOranLabel.Text = $"Gelir/Gider Oranı: {oran:F2}";
                    gelirGiderOranLabel.ForeColor = oran >= 1 ? Color.Green : Color.Orange;
                }
                else
                {
                    gelirGiderOranLabel.Text = "Gelir/Gider Oranı: ∞";
                    gelirGiderOranLabel.ForeColor = Color.Green;
                }
            }
        }

        private void GrafikListesiniGuncelle()
        {
            grafikListBox.Items.Clear();

            var dagilim = _islemYoneticisi.KategoriDagilimi();

            if (dagilim.Any())
            {
                grafikBaslikLabel.Text = "Kategorilere Göre Dağılım";

                decimal genelToplam = dagilim.Values.Sum();

                grafikListBox.Items.Add("=== DETAYLI ANALİZ ===");
                grafikListBox.Items.Add("");

                foreach (var kategori in dagilim.OrderByDescending(x => x.Value))
                {
                    decimal yuzde = genelToplam > 0 ? kategori.Value / genelToplam * 100 : 0;
                    string satir = $"📊 {kategori.Key}: {kategori.Value:N2} ₺ (%{yuzde:F1})";
                    grafikListBox.Items.Add(satir);
                }

                grafikListBox.Items.Add("");
                grafikListBox.Items.Add("─────────────────────────");
                grafikListBox.Items.Add($"💰 GENEL TOPLAM: {genelToplam:N2} ₺");
                grafikListBox.Items.Add($"📈 EN YÜKSEK: {dagilim.OrderByDescending(x => x.Value).First().Key}");
                grafikListBox.Items.Add($"📉 EN DÜŞÜK: {dagilim.OrderBy(x => x.Value).First().Key}");
                grafikListBox.Items.Add($"🏷 TOPLAM KATEGORİ: {dagilim.Count}");
            }
            else
            {
                grafikBaslikLabel.Text = "Henüz veri bulunmuyor";
                grafikListBox.Items.Add("📊 Grafik göstermek için işlem ekleyin.");
                grafikListBox.Items.Add("");
                grafikListBox.Items.Add("💡 İpucu: Farklı kategorilerde işlemler");
                grafikListBox.Items.Add("   ekleyerek grafiği daha anlamlı hale");
                grafikListBox.Items.Add("   getirebilirsiniz.");
            }
        }

        private void FormTemizle()
        {
            aciklamaTextBox.Clear();
            tutarTextBox.Clear();
            turComboBox.SelectedIndex = -1;
            kategoriComboBox.SelectedIndex = -1;
            aciklamaTextBox.Focus();
        }

        private void InitializeComponent()
        {
            // Bu metod boş bırakılıyor - Form tasarımı FormTasariminiHazirla() metodunda yapılıyor
        }
    }
}