---
title: Integrasi Data Excel ke Presentasi PowerPoint
linktitle: Integrasi Excel
type: docs
weight: 330
url: /id/androidjava/excel-integration/
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
- Android
- Java
- Aspose.Slides
description: "Baca data dari buku kerja Excel di Aspose.Slides menggunakan API ExcelDataWorkbook. Muat lembar dan sel serta gunakan nilai-nilai untuk menghasilkan presentasi PowerPoint berbasis data."
---
## **Pendahuluan**

Presentasi PowerPoint adalah cara yang kuat untuk menampilkan dan menyampaikan informasi. Mereka sering digunakan bersama dengan buku kerja Excel, di mana Excel berfungsi sebagai sumber data terstruktur yang sangat baik dan PowerPoint unggul dalam memvisualisasikan data tersebut untuk audiens.

Berbagai skenario praktis memerlukan penggabungan Excel dan PowerPoint: mail merge, mengisi tabel data, menghasilkan satu slide per catatan data (pembuatan slide batch), membuat materi pelatihan, dan mengkonsolidasikan beberapa laporan Excel menjadi satu presentasi, antara lain.

Sampai saat ini, mengimplementasikan fitur tersebut dengan API Aspose.Slides memerlukan ketergantungan pada solusi pihak ketiga seperti Aspose.Cells. Meskipun alat-alat ini kuat, mereka dapat menjadi terlalu kompleks dan mahal bagi pengguna yang hanya membutuhkan fungsionalitas integrasi data dasar.

## **Cara Kerja**

Untuk mempermudah dan menyederhanakan kerja dengan data Excel, Aspose.Slides telah memperkenalkan kelas baru untuk membaca data dari buku kerja Excel dan mengimpor konten ke dalam presentasi. Fitur ini membuka kemungkinan baru yang kuat bagi pengguna API yang ingin memanfaatkan Excel sebagai sumber data dalam alur kerja presentasi mereka.

Fungsionalitas baru ini dirancang untuk akses data tujuan umum dan tidak terintegrasi ke dalam Presentation Document Object Model (DOM). Itu berarti *tidak memungkinkan pengeditan atau penyimpanan file Excel* — tujuan tunggalnya adalah membuka buku kerja dan menavigasi kontennya untuk mengambil data sel.

Pada inti fitur ini adalah kelas baru [ExcelDataWorkbook](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/exceldataworkbook/). Kelas ini memungkinkan Anda memuat buku kerja Excel dari file lokal atau aliran. Setelah dimuat, ia menyediakan beberapa overload dari metode [getCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) yang dapat Anda gunakan untuk mengambil sel tertentu berdasarkan posisinya (misalnya indeks baris dan kolom atau rentang bernama).

Setiap pemanggilan [getCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) mengembalikan instance dari kelas [ExcelDataCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/exceldatacell/). Objek ini mewakili satu sel dalam buku kerja Excel dan memberi Anda akses ke nilainya dengan cara yang sederhana dan intuitif.

#### **Impor Diagram Excel**

Langkah berikutnya untuk memperluas fungsionalitas adalah kelas [ExcelWorkbookImporter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/excelworkbookimporter/). Kelas utilitas ini menyediakan fungsi untuk mengimpor konten dari buku kerja Excel ke dalam presentasi. Ia berisi beberapa overload dari metode [addChartFromWorkbook](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) yang membantu Anda mengambil diagram yang dipilih dari buku kerja Excel yang ditentukan dan menambahkannya ke akhir koleksi shape yang diberikan pada koordinat yang ditentukan.

Singkatnya, ini adalah API yang ringan dan sederhana untuk membaca data Excel — tepat apa yang dibutuhkan banyak pengembang tanpa beban tambahan dari perpustakaan pemrosesan spreadsheet yang lengkap.

## **Mari Kita Kode**

### **Contoh Skenario Mail Merge**

Dalam contoh berikut, kami akan mengimplementasikan skenario Mail Merge sederhana dengan menghasilkan beberapa presentasi berdasarkan data yang disimpan dalam buku kerja Excel.

Untuk memulai, kami memerlukan dua hal:
1. Buku kerja Excel yang berisi data

![Excel data example](example1_image0.png)

2. Template presentasi PowerPoint

![PowerPoint template example](example1_image1.png)

```java
// Muat buku kerja Excel dengan data karyawan.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Muat templat presentasi.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iterasi baris Excel (kecuali header pada baris 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Buat presentasi baru untuk setiap catatan karyawan.
        Presentation employeePresentation = new Presentation();

        try {
            // Hapus slide kosong default.
            employeePresentation.getSlides().removeAt(0);

            // Klon slide templat ke dalam presentasi baru.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Dapatkan paragraf dari shape target (asumsi indeks shape 1 digunakan).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Ganti placeholder dengan data dari Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Simpan presentasi yang dipersonalisasi ke file terpisah.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Hasil](example1_image2.png)

### **Contoh Tabel Excel**

Pada contoh kedua, kami cukup menyalin data dari tabel Excel dan menampilkannya pada slide PowerPoint dengan format yang lebih menarik secara visual.

Dalam contoh ini, kami menggunakan kembali buku kerja Excel yang sama dari contoh pertama, yang berisi tabel karyawan sederhana.

```java
// Muat buku kerja Excel yang berisi data karyawan.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Buat presentasi PowerPoint baru.
Presentation presentation = new Presentation();

try {
    // Tambahkan bentuk tabel ke slide pertama.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Isi tabel PowerPoint dengan data dari buku kerja Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Simpan presentasi yang dihasilkan ke file.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hasil](example2_image0.png)

### **Contoh Mengimpor Diagram Excel**

Dalam contoh ini, kami mengimpor diagram dari lembar kerja pertama buku kerja Excel yang digunakan pada contoh sebelumnya. Diagram tersebut akan ditautkan ke buku kerja eksternal dalam presentasi yang dihasilkan.

Pertama, kami menambahkan diagram Pai ke buku kerja Excel berdasarkan tabel karyawan.

![Contoh Diagram Excel](example3_image0.png)

```java
// Buat presentasi PowerPoint baru.
Presentation presentation = new Presentation();
try {
    // Dapatkan koleksi shape dari slide pertama.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Impor diagram bernama "Chart 1" dari lembar pertama workbook dan tambahkan ke koleksi shape.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Simpan presentasi yang dihasilkan ke file.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hasil](example3_image1.png)

### **Contoh Mengimpor Semua Diagram Excel**

Bayangkan Anda memiliki buku kerja Excel yang penuh dengan diagram dan Anda perlu mengimpor semuanya ke dalam satu presentasi. Setiap diagram harus ditempatkan pada slide baru.

Kode berikut mengiterasi semua lembar kerja dalam file Excel sumber, mengekstrak diagram dari setiap lembar kerja, dan menambahkan setiap diagram ke slide terpisah menggunakan tata letak slide kosong. Dalam presentasi yang dihasilkan, hanya data diagram yang akan disematkan, bukan seluruh buku kerja.

```java
// Muat buku kerja Excel yang berisi data karyawan.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Buat presentasi PowerPoint baru.
Presentation presentation = new Presentation();
try {
    // Ambil tata letak slide kosong.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Dapatkan nama semua lembar kerja yang terdapat dalam buku kerja Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Ambil peta yang memetakan indeks diagram ke nama diagram untuk lembar kerja.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Tambahkan slide baru menggunakan tata letak kosong.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Impor diagram yang ditentukan dari buku kerja Excel ke dalam koleksi shape slide.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Simpan presentasi yang dihasilkan ke file.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ringkasan**

Mekanisme ini, tersedia langsung di Aspose.Slides, menggabungkan pekerjaan dengan data Excel dan presentasi dalam satu tempat. Ini memungkinkan Anda membuat slide dengan diagram visual dan data yang disajikan sebagai tabel Excel — tanpa perpustakaan tambahan atau integrasi yang kompleks.