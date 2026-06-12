---
title: Integrasikan Data Excel ke dalam Presentasi PowerPoint
linktitle: Integrasi Excel
type: docs
weight: 330
url: /id/cpp/excel-integration/
keywords:
- Excel
- buku kerja
- membaca Excel
- mengintegrasikan Excel
- sumber data
- mail merge
- mengimpor tabel
- Excel ke PowerPoint
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Baca data dari workbook Excel dalam Aspose.Slides menggunakan API ExcelDataWorkbook. Muat lembar dan sel, lalu gunakan nilai-nilai tersebut untuk menghasilkan presentasi PowerPoint berbasis data."
---
## **Pendahuluan**

Presentasi PowerPoint adalah cara yang kuat untuk menampilkan dan menyampaikan informasi. Mereka sering digunakan bersama dengan workbook Excel, di mana Excel berfungsi sebagai sumber data terstruktur yang sangat baik dan PowerPoint unggul dalam memvisualisasikan data tersebut untuk audiens.

Ada banyak skenario praktis di mana menggabungkan Excel dan PowerPoint menjadi penting: mail merge, mengisi tabel data, menghasilkan satu slide per catatan data (pembuatan slide batch), membuat materi pelatihan, dan mengkonsolidasikan beberapa laporan Excel menjadi satu presentasi, antara lain.

Sampai saat ini, mengimplementasikan fitur semacam itu dengan API Aspose.Slides memerlukan ketergantungan pada solusi pihak ketiga seperti Aspose.Cells. Meskipun alat‑alat tersebut kuat, mereka dapat menjadi terlalu kompleks dan mahal bagi pengguna yang hanya membutuhkan fungsi integrasi data dasar.

## **Cara Kerja**

Untuk mempermudah kerja dengan data Excel dan menjadikannya lebih terintegrasi, Aspose.Slides telah memperkenalkan kelas baru untuk membaca data dari workbook Excel dan mengimpor konten ke dalam presentasi. Fitur ini membuka peluang baru yang kuat bagi pengguna API yang ingin memanfaatkan Excel sebagai sumber data dalam alur kerja presentasi mereka.

Fungsi baru ini dirancang untuk akses data umum dan tidak terintegrasi ke dalam Presentation Document Object Model (DOM). Artinya *tidak memungkinkan penyuntingan atau penyimpanan file Excel* — tujuan tunggalnya adalah membuka workbook dan menelusuri isinya untuk mengambil data sel.

Inti dari fitur ini adalah kelas baru [ExcelDataWorkbook](https://reference.aspose.com/slides/id/cpp/aspose.slides.excel/exceldataworkbook/). Kelas ini memungkinkan Anda memuat workbook Excel dari file lokal atau aliran data. Setelah dimuat, ia menyediakan beberapa overload dari metode [GetCell](https://reference.aspose.com/slides/id/cpp/aspose.slides.excel/exceldataworkbook/getcell/), yang dapat Anda gunakan untuk mengambil sel tertentu berdasarkan posisinya (misalnya indeks baris dan kolom atau rentang bernama).

Setiap panggilan ke [GetCell](https://reference.aspose.com/slides/id/cpp/aspose.slides.excel/exceldataworkbook/getcell/) mengembalikan sebuah instance dari kelas [ExcelDataCell](https://reference.aspose.com/slides/id/cpp/aspose.slides.excel/exceldatacell/). Objek ini mewakili satu sel dalam workbook Excel dan memberi Anda akses ke nilai sel dengan cara yang sederhana dan intuitif.

#### **Impor Grafik Excel**

Langkah selanjutnya untuk memperluas fungsionalitas adalah kelas [ExcelWorkbookImporter](https://reference.aspose.com/slides/id/cpp/aspose.slides.import/excelworkbookimporter/). Kelas utilitas ini menyediakan fungsi untuk mengimpor konten dari workbook Excel ke dalam presentasi. Ia memiliki beberapa overload dari metode [AddChartFromWorkbook](https://reference.aspose.com/slides/id/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), yang membantu Anda mengambil grafik yang dipilih dari workbook Excel yang ditentukan dan menambahkannya ke akhir koleksi shape yang diberikan pada koordinat yang ditentukan.

Singkatnya, ini adalah API yang ringan dan sederhana untuk membaca data Excel — tepat apa yang banyak pengembang butuhkan tanpa beban tambahan dari perpustakaan pemrosesan spreadsheet lengkap.

## **Mari Kita Kode**

### **Contoh Skenario Mail Merge**

Dalam contoh berikut, kami akan mengimplementasikan skenario Mail Merge sederhana dengan menghasilkan beberapa presentasi berdasarkan data yang disimpan dalam workbook Excel.

Untuk memulai, kita memerlukan dua hal:
1. Workbook Excel yang berisi data

![Contoh data Excel](example1_image0.png)

2. Templat presentasi PowerPoint

![Contoh templat PowerPoint](example1_image1.png)

```cpp
// Muat workbook Excel dengan data karyawan.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Muat templat presentasi.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Loop melalui baris Excel (mengabaikan header pada baris 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Buat presentasi baru untuk setiap catatan karyawan.
    auto employeePresentation = MakeObject<Presentation>();

    // Hapus slide kosong default.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Klon slide templat ke dalam presentasi baru.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Dapatkan paragraf dari shape target (asumsikan indeks shape 1 digunakan).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Ganti placeholder dengan data dari Excel.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Simpan presentasi yang dipersonalisasi ke file terpisah.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Hasil](example1_image2.png)

### **Contoh Tabel Excel**

Pada contoh kedua, kami cukup menyalin data dari tabel Excel dan menampilkannya pada slide PowerPoint dengan format yang lebih menarik secara visual.

Dalam contoh ini, kami menggunakan kembali workbook Excel yang sama dari contoh pertama, yang berisi tabel karyawan sederhana.

```cpp
// Muat workbook Excel yang berisi data karyawan.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Buat presentasi PowerPoint baru.
auto presentation = MakeObject<Presentation>();

// Tambahkan shape tabel ke slide pertama.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Isi tabel PowerPoint dengan data dari workbook Excel.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Simpan presentasi hasil ke file.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Hasil](example2_image0.png)

### **Contoh Impor Grafik Excel**

Pada contoh ini, kami mengimpor sebuah grafik dari lembar kerja pertama workbook Excel yang digunakan pada contoh sebelumnya. Grafik tersebut akan terhubung ke workbook eksternal dalam presentasi yang dihasilkan.

Pertama, kami menambahkan grafik Pie ke workbook Excel berdasarkan tabel karyawan.

![Contoh Grafik Excel](example3_image0.png)

```cpp
// Buat presentasi PowerPoint baru.
auto presentation = MakeObject<Presentation>();

// Dapatkan koleksi shape dari slide pertama.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Impor grafik bernama "Chart 1" dari lembar pertama workbook dan tambahkan ke koleksi shape.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Simpan presentasi hasil ke file.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Hasil](example3_image1.png)

### **Contoh Impor Semua Grafik Excel**

Bayangkan Anda memiliki workbook Excel yang penuh dengan grafik dan Anda perlu mengimpor semuanya ke dalam sebuah presentasi. Setiap grafik harus ditempatkan pada slide baru.

Kode berikut mengiterasi semua lembar kerja dalam file Excel sumber, mengekstrak grafik dari masing‑masing lembar kerja, dan menambahkan setiap grafik ke slide terpisah menggunakan tata letak slide kosong. Dalam presentasi yang dihasilkan, hanya data grafik yang akan disematkan, bukan seluruh workbook.

```cpp
// Muat workbook Excel yang berisi data karyawan.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Buat presentasi PowerPoint baru.
auto presentation = MakeObject<Presentation>();

// Ambil tata letak slide kosong.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Dapatkan nama semua worksheet yang terdapat dalam workbook Excel.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Ambil kamus yang memetakan indeks grafik ke nama grafik untuk worksheet.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Tambahkan slide baru menggunakan tata letak kosong.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Impor grafik yang ditentukan dari workbook Excel ke dalam koleksi shape slide.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Simpan presentasi hasil ke file.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ringkasan**

Mekanisme ini, yang tersedia langsung dalam Aspose.Slides, menggabungkan kerja dengan data Excel dan presentasi dalam satu tempat. Ini memungkinkan Anda membuat slide dengan grafik visual dan data yang disajikan sebagai tabel Excel — tanpa perpustakaan tambahan atau integrasi yang rumit.