---
title: Integrasi Data Excel ke Presentasi PowerPoint
linktitle: Integrasi Excel
type: docs
weight: 330
url: /id/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- buku kerja
- baca Excel
- integrasikan Excel
- sumber data
- mail merge
- impor tabel
- Excel ke PowerPoint
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Baca data dari workbook Excel di Aspose.Slides menggunakan API ExcelDataWorkbook. Muat lembar dan sel serta gunakan nilai untuk menghasilkan presentasi PowerPoint berbasis data."
---
## **Pendahuluan**

Presentasi PowerPoint adalah cara yang kuat untuk menampilkan dan menyampaikan informasi. Mereka sering digunakan bersama workbook Excel, di mana Excel berfungsi sebagai sumber data terstruktur yang sangat baik dan PowerPoint unggul dalam memvisualisasikan data tersebut bagi audiens.

Ada banyak skenario praktis di mana menggabungkan Excel dan PowerPoint sangat penting: mail merge, mengisi tabel data, menghasilkan satu slide per catatan data (pembuatan slide batch), membuat materi pelatihan, dan mengkonsolidasikan banyak laporan Excel menjadi satu presentasi, antara lain.

Sampai saat ini, mengimplementasikan fitur tersebut dengan API Aspose.Slides memerlukan ketergantungan pada solusi pihak ketiga seperti Aspose.Cells. Meskipun alat-alat ini kuat, mereka dapat menjadi terlalu kompleks dan mahal bagi pengguna yang hanya membutuhkan fungsi integrasi data dasar.

## **Cara Kerja**

Untuk mempermudah dan memperlancar kerja dengan data Excel, Aspose.Slides telah memperkenalkan kelas baru untuk membaca data dari workbook Excel dan mengimpor konten ke dalam presentasi. Fitur ini membuka kemungkinan baru yang kuat bagi pengguna API yang ingin memanfaatkan Excel sebagai sumber data dalam alur kerja presentasi mereka.

Fungsi baru ini dirancang untuk akses data tujuan umum dan tidak terintegrasi ke dalam Presentation Document Object Model (DOM). Itu berarti *tidak memungkinkan pengeditan atau penyimpanan file Excel* — tujuan tunggalnya adalah membuka workbook dan menavigasi kontennya untuk mengambil data sel.

Inti dari fitur ini adalah kelas baru [ExcelDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.excel/exceldataworkbook/). Kelas ini memungkinkan Anda memuat workbook Excel dari file lokal atau aliran. Setelah dimuat, ia menyediakan beberapa overload dari metode [GetCell](https://reference.aspose.com/slides/id/net/aspose.slides.excel/exceldataworkbook/getcell/) yang dapat Anda gunakan untuk mengambil sel tertentu berdasarkan posisinya (mis., indeks baris dan kolom atau rentang bernama).

Setiap pemanggilan [GetCell](https://reference.aspose.com/slides/id/net/aspose.slides.excel/exceldataworkbook/getcell/) mengembalikan sebuah instance dari kelas [ExcelDataCell](https://reference.aspose.com/slides/id/net/aspose.slides.excel/exceldatacell/). Objek ini mewakili satu sel dalam workbook Excel dan memberi Anda akses ke nilainya dengan cara yang sederhana dan intuitif.

#### **Impor Grafik Excel**

Langkah selanjutnya untuk memperluas fungsionalitas adalah kelas [ExcelWorkbookImporter](https://reference.aspose.com/slides/id/net/aspose.slides.import/excelworkbookimporter/). Kelas utilitas ini menyediakan fungsi untuk mengimpor konten dari workbook Excel ke dalam presentasi. Ia berisi beberapa overload dari metode [AddChartFromWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) yang membantu Anda mengambil grafik yang dipilih dari workbook Excel yang ditentukan dan menambahkannya ke akhir koleksi shape yang diberikan pada koordinat yang ditentukan.

#### **Impor Tabel Excel**

Kelas [ExcelWorkbookImporter](https://reference.aspose.com/slides/id/net/aspose.slides.import/excelworkbookimporter/) juga berisi beberapa overload dari metode [AddTableFromWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Metode-metode ini memungkinkan Anda mengimpor rentang sel tertentu dari worksheet yang ditentukan dan menambahkannya sebagai tabel ke akhir koleksi shape yang diberikan pada koordinat yang ditentukan.

Singkatnya, ini adalah API yang ringan dan sederhana untuk membaca data Excel — tepat apa yang dibutuhkan banyak pengembang tanpa beban tambahan dari perpustakaan pemrosesan spreadsheet lengkap.

## **Mari Kita Kode**

### **Contoh Skenario Mail Merge**

Pada contoh berikut, kami akan mengimplementasikan skenario Mail Merge sederhana dengan menghasilkan beberapa presentasi berdasarkan data yang disimpan dalam workbook Excel.

Untuk memulai, kita membutuhkan dua hal:
1. Sebuah workbook Excel yang berisi data

![Contoh data Excel](example1_image0.png)

2. Template presentasi PowerPoint

![Contoh template PowerPoint](example1_image1.png)

```csharp
// Muat workbook Excel dengan data karyawan.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Muat templat presentasi.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Loop melalui baris Excel (kecuali header di baris 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Buat presentasi baru untuk setiap catatan karyawan.
    using Presentation employeePresentation = new Presentation();

    // Hapus slide kosong default.
    employeePresentation.Slides.RemoveAt(0);

    // Klon slide templat ke dalam presentasi baru.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Ambil paragraf dari shape target (diasumsikan indeks shape 1 digunakan).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Ganti placeholder dengan data dari Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Simpan presentasi yang dipersonalisasi ke file terpisah.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Hasil](example1_image2.png)

### **Contoh Tabel Excel**

Pada contoh kedua, kami cukup menyalin data dari tabel Excel dan menampilkannya pada slide PowerPoint dalam format yang lebih menarik secara visual.

Dalam contoh ini, kami menggunakan kembali workbook Excel yang sama dari contoh pertama, yang berisi tabel karyawan sederhana.

```csharp
// Muat workbook Excel yang berisi data karyawan.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Buat presentasi PowerPoint baru.
using Presentation presentation = new Presentation();

// Tambahkan shape tabel ke slide pertama.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Isi tabel PowerPoint dengan data dari workbook Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Simpan presentasi yang dihasilkan ke file.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Hasil](example2_image0.png)

### **Contoh Impor Grafik Excel**

Dalam contoh ini, kami mengimpor grafik dari worksheet pertama workbook Excel yang digunakan pada contoh sebelumnya. Grafik tersebut akan terhubung ke workbook eksternal dalam presentasi yang dihasilkan.

Pertama, kami menambahkan grafik Pie ke workbook Excel berdasarkan tabel karyawan.

![Contoh Grafik Excel](example3_image0.png)

```csharp
// Buat presentasi PowerPoint baru.
using Presentation presentation = new Presentation();

// Dapatkan koleksi shape slide pertama.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Impor chart bernama "Chart 1" dari sheet pertama workbook dan tambahkan ke koleksi shape.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Simpan presentasi yang dihasilkan ke file.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Hasil](example3_image1.png)

### **Contoh Impor Semua Grafik Excel**

Bayangkan Anda memiliki workbook Excel penuh dengan grafik dan Anda perlu mengimpor semuanya ke dalam sebuah presentasi. Setiap grafik harus ditempatkan pada slide baru.

Kode berikut mengiterasi semua worksheet dalam file Excel sumber, mengekstrak grafik dari setiap worksheet, dan menambahkan setiap grafik ke slide terpisah menggunakan layout slide kosong. Dalam presentasi yang dihasilkan, hanya data grafik yang akan disematkan, bukan seluruh workbook.

```csharp
// Muat workbook Excel yang berisi data karyawan.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Buat presentasi PowerPoint baru.
using Presentation presentation = new Presentation();

// Ambil layout slide kosong.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Dapatkan nama semua worksheet yang terdapat dalam workbook Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Ambil kamus yang memetakan indeks chart ke nama chart untuk worksheet.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Tambah slide baru menggunakan layout kosong.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Impor chart yang ditentukan dari workbook Excel ke dalam koleksi shape slide.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Simpan presentasi yang dihasilkan ke file.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Contoh Impor Tabel Excel**

Dalam contoh ini, kami mengimpor tabel yang diformat dari worksheet Excel secara langsung ke dalam presentasi PowerPoint.

Worksheet Excel sumber berisi tabel yang diformat dengan data karyawan:

![Contoh Tabel Excel](example4_image0.png)

```csharp
// Buat presentasi PowerPoint baru.
using Presentation presentation = new Presentation();

// Dapatkan koleksi shape slide pertama.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Impor tabel dari sheet pertama workbook dan tambahkan ke koleksi shape.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Simpan presentasi yang dihasilkan ke file.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![Hasil](example4_image1.png)

## **Ringkasan**

Mekanisme ini, yang tersedia langsung di Aspose.Slides, menggabungkan pengolahan data Excel dan presentasi dalam satu tempat. Hal ini memungkinkan Anda membuat slide dengan grafik visual dan data yang disajikan sebagai tabel Excel — tanpa pustaka tambahan atau integrasi yang rumit.