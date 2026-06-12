---
title: Mengintegrasikan Data Excel ke dalam Presentasi PowerPoint
linktitle: Integrasi Excel
type: docs
weight: 330
url: /id/php-java/excel-integration/
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
- PHP
- Aspose.Slides
description: "Baca data dari buku kerja Excel menggunakan Aspose.Slides untuk PHP melalui Java. Muat lembar dan sel serta gunakan nilai-nilai untuk menghasilkan presentasi PowerPoint berbasis data."
---
## **Pendahuluan**

Presentasi PowerPoint adalah cara yang kuat untuk menampilkan dan mengkomunikasikan informasi. Mereka sering digunakan bersama buku kerja Excel, di mana Excel berfungsi sebagai sumber data terstruktur yang sangat baik dan PowerPoint unggul dalam memvisualisasikan data tersebut bagi audiens.

Ada banyak skenario praktis di mana menggabungkan Excel dan PowerPoint menjadi penting: mail merge, mengisi tabel data, menghasilkan satu slide per catatan data (pembuatan slide batch), membuat materi pelatihan, dan mengkonsolidasikan beberapa laporan Excel menjadi satu presentasi, antara lain.

Sampai saat ini, mengimplementasikan fitur tersebut dengan API Aspose.Slides memerlukan ketergantungan pada solusi pihak ketiga seperti Aspose.Cells. Meskipun alat tersebut kuat, mereka dapat menjadi terlalu kompleks dan mahal bagi pengguna yang hanya membutuhkan fungsi integrasi data dasar.

## **Bagaimana Cara Kerjanya**

Untuk mempermudah dan memperlancar kerja dengan data Excel, Aspose.Slides telah memperkenalkan kelas baru untuk membaca data dari buku kerja Excel dan mengimpor konten ke dalam presentasi. Fitur ini membuka kemungkinan baru yang kuat bagi pengguna API yang ingin memanfaatkan Excel sebagai sumber data dalam alur kerja presentasi mereka.

Fungsionalitas baru ini dirancang untuk akses data tujuan umum dan tidak terintegrasi ke dalam Presentation Document Object Model (DOM). Itu berarti *tidak memungkinkan pengeditan atau penyimpanan file Excel* — satu-satunya tujuan fitur ini adalah membuka buku kerja dan menavigasi isinya untuk mengambil data sel.

Inti dari fitur ini adalah kelas baru [ExcelDataWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/exceldataworkbook/). Kelas ini memungkinkan Anda memuat buku kerja Excel dari file lokal atau aliran. Setelah dimuat, ia menyediakan beberapa overload dari metode [getCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/exceldataworkbook/#getCell), yang dapat Anda gunakan untuk mengambil sel tertentu berdasarkan posisinya (mis., indeks baris dan kolom atau rentang bernama).

Setiap pemanggilan [getCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/exceldataworkbook/#getCell) mengembalikan sebuah instance dari kelas [ExcelDataCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/exceldatacell/). Objek ini mewakili satu sel dalam buku kerja Excel dan memberi Anda akses ke nilainya dengan cara yang sederhana dan intuitif.

#### **Impor Diagram Excel**

Langkah selanjutnya untuk memperluas fungsionalitas adalah kelas [ExcelWorkbookImporter](https://reference.aspose.com/slides/id/php-java/aspose.slides/excelworkbookimporter/). Kelas utilitas ini menyediakan fungsi untuk mengimpor konten dari buku kerja Excel ke dalam presentasi. Ia berisi beberapa overload dari metode [addChartFromWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), yang membantu Anda mengambil diagram yang dipilih dari buku kerja Excel tertentu dan menambahkannya ke akhir koleksi shape yang diberikan pada koordinat yang ditentukan.

Singkatnya, ini adalah API yang ringan dan sederhana untuk membaca data Excel — tepat apa yang dibutuhkan banyak pengembang tanpa beban library pemrosesan spreadsheet lengkap.

## **Mari Kita Kode**

### **Contoh Skenario Mail Merge**

Dalam contoh berikut, kami akan mengimplementasikan skenario Mail Merge sederhana dengan menghasilkan beberapa presentasi berdasarkan data yang disimpan dalam buku kerja Excel.

Untuk memulai, kita membutuhkan dua hal:
1. Buku kerja Excel yang berisi data

![Contoh data Excel](example1_image0.png)

2. Template presentasi PowerPoint

![Contoh template PowerPoint](example1_image1.png)

```php
// Muat buku kerja Excel dengan data karyawan.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Muat templat presentasi.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iterasi baris Excel (kecuali header pada baris 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Buat presentasi baru untuk setiap catatan karyawan.
        $employeePresentation = new Presentation();

        try {
            // Hapus slide kosong default.
            $employeePresentation->getSlides()->removeAt(0);

            // Gandakan slide templat ke dalam presentasi baru.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Ambil paragraf dari shape target (diasumsikan indeks shape 1 digunakan).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Ganti placeholder dengan data dari Excel.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Simpan presentasi yang dipersonalisasi ke file terpisah.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Hasil](example1_image2.png)

### **Contoh Tabel Excel**

Pada contoh kedua, kami cukup menyalin data dari tabel Excel dan menampilkannya pada slide PowerPoint dalam format yang lebih menarik secara visual.

Dalam contoh ini, kami menggunakan kembali buku kerja Excel yang sama dari contoh pertama, yang berisi tabel karyawan sederhana.

```php
// Muat buku kerja Excel yang berisi data karyawan.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Buat presentasi PowerPoint baru.
$presentation = new Presentation();

try {
    // Tambahkan shape tabel ke slide pertama.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Isi tabel PowerPoint dengan data dari buku kerja Excel.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Simpan presentasi hasil ke file.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hasil](example2_image0.png)

### **Contoh Impor Diagram Excel**

Pada contoh ini, kami mengimpor diagram dari lembar kerja pertama buku kerja Excel yang digunakan pada contoh sebelumnya. Diagram tersebut akan tertaut ke buku kerja eksternal dalam presentasi yang dihasilkan.

Pertama, kami menambahkan diagram Pie ke buku kerja Excel berdasarkan tabel karyawan.

![Contoh Diagram Excel](example3_image0.png)

```php
// Buat presentasi PowerPoint baru.
$presentation = new Presentation();
try {
    // Dapatkan koleksi shape dari slide pertama.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Impor diagram bernama "Chart 1" dari lembar pertama workbook dan tambahkan ke koleksi shape.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Simpan presentasi hasil ke file.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hasil](example3_image1.png)

### **Contoh Impor Semua Diagram Excel**

Bayangkan Anda memiliki buku kerja Excel penuh dengan diagram dan Anda perlu mengimpornya semua ke dalam sebuah presentasi. Setiap diagram harus ditempatkan pada slide baru.

Kode berikut mengiterasi semua lembar kerja dalam file Excel sumber, mengekstrak diagram dari setiap lembar kerja, dan menambahkan setiap diagram ke slide terpisah menggunakan tata letak slide kosong. Dalam presentasi yang dihasilkan, hanya data diagram yang akan disematkan, bukan seluruh buku kerja.

```php
// Muat buku kerja Excel yang berisi data karyawan.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Buat presentasi PowerPoint baru.
$presentation = new Presentation();
try {
    // Ambil tata letak slide kosong.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Dapatkan nama semua lembar kerja yang terdapat dalam buku kerja Excel.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Ambil peta yang memetakan indeks diagram ke nama diagram untuk lembar kerja tersebut.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Tambahkan slide baru menggunakan tata letak kosong.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Impor diagram yang ditentukan dari buku kerja Excel ke dalam koleksi shape slide.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Simpan presentasi hasil ke file.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ringkasan**

Mekanisme ini, tersedia langsung di Aspose.Slides, menggabungkan kerja dengan data Excel dan presentasi dalam satu tempat. Ini memungkinkan Anda membuat slide dengan diagram visual dan data yang disajikan sebagai tabel Excel — tanpa library tambahan atau integrasi yang kompleks.