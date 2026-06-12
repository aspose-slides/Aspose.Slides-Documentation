---
title: Integrasikan Data Excel ke dalam Presentasi PowerPoint
linktitle: Integrasi Excel
type: docs
weight: 330
url: /id/nodejs-java/excel-integration/
keywords:
- Excel
- buku kerja
- baca Excel
- integrasikan Excel
- sumber data
- gabungan surat
- impor tabel
- Excel ke PowerPoint
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Baca data dari buku kerja Excel dalam JavaScript dengan Aspose.Slides. Muat lembar dan sel serta gunakan nilainya untuk menghasilkan presentasi PowerPoint berbasis data."
---
## **Pendahuluan**

Presentasi PowerPoint merupakan cara yang kuat untuk menampilkan dan menyampaikan informasi. Sering kali mereka digunakan bersama buku kerja Excel, di mana Excel berfungsi sebagai sumber data terstruktur yang sangat baik dan PowerPoint unggul dalam memvisualisasikan data tersebut untuk audiens.

Ada banyak skenario praktis di mana penggabungan Excel dan PowerPoint sangat penting: mail merge, mengisi tabel data, menghasilkan satu slide per catatan data (pembuatan slide batch), membuat materi pelatihan, dan mengkonsolidasikan beberapa laporan Excel menjadi satu presentasi, antara lain.

Sampai sekarang, mengimplementasikan fitur tersebut dengan API Aspose.Slides memerlukan ketergantungan pada solusi pihak ketiga seperti Aspose.Cells. Meskipun alat ini kuat, mereka dapat menjadi terlalu kompleks dan mahal bagi pengguna yang hanya membutuhkan fungsi integrasi data dasar.

## **Cara Kerja**

Untuk mempermudah dan menyederhanakan pekerjaan dengan data Excel, Aspose.Slides telah memperkenalkan kelas baru untuk membaca data dari buku kerja Excel dan mengimpor konten ke dalam presentasi. Fitur ini membuka peluang baru yang kuat bagi pengguna API yang ingin memanfaatkan Excel sebagai sumber data dalam alur kerja presentasi mereka.

Fungsionalitas baru ini dirancang untuk akses data umum dan tidak terintegrasi ke dalam Presentation Document Object Model (DOM). Itu berarti *tidak memungkinkan pengeditan atau penyimpanan file Excel* — tujuan utamanya adalah membuka buku kerja dan menavigasi isinya untuk mengambil data sel.

Inti dari fitur ini adalah kelas baru [ExcelDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/exceldataworkbook/) . Kelas ini memungkinkan Anda memuat buku kerja Excel dari file lokal atau aliran. Setelah dimuat, kelas ini menyediakan beberapa overload dari metode [getCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/exceldataworkbook/#getCell) , yang dapat Anda gunakan untuk mengambil sel tertentu berdasarkan posisinya (mis., indeks baris dan kolom atau rentang bernama) .

Setiap pemanggilan [getCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/exceldataworkbook/#getCell) mengembalikan instance dari kelas [ExcelDataCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/exceldatacell/) . Objek ini mewakili satu sel dalam buku kerja Excel dan memberikan Anda akses ke nilainya dengan cara yang sederhana dan intuitif.

#### **Impor Grafik Excel**

Langkah selanjutnya untuk memperluas fungsionalitas adalah kelas [ExcelWorkbookImporter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/excelworkbookimporter/) . Kelas utilitas ini menyediakan fungsionalitas untuk mengimpor konten dari buku kerja Excel ke dalam presentasi. Kelas ini berisi beberapa overload dari metode [addChartFromWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) , yang membantu Anda mengambil grafik terpilih dari buku kerja Excel yang ditentukan dan menambahkannya ke akhir koleksi shape yang diberikan pada koordinat yang ditentukan.

Singkatnya, ini adalah API yang ringan dan sederhana untuk membaca data Excel — tepat apa yang dibutuhkan banyak pengembang tanpa beban tambahan dari perpustakaan pemrosesan spreadsheet lengkap.

## **Mari Kita Kode**

### **Contoh Skenario Mail Merge**

Pada contoh berikut, kita akan mengimplementasikan skenario Mail Merge sederhana dengan menghasilkan beberapa presentasi berdasarkan data yang disimpan dalam buku kerja Excel.

Untuk memulai, kita membutuhkan dua hal:
1. Buku kerja Excel yang berisi data

![Contoh data Excel](example1_image0.png)

2.  Templete presentasi PowerPoint

![Contoh templat PowerPoint](example1_image1.png)

```js
// Muat buku kerja Excel dengan data karyawan.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Muat templat presentasi.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Iterasi baris Excel (kecuali header pada baris 0).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Buat presentasi baru untuk setiap catatan karyawan.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Hapus slide kosong default.
            employeePresentation.getSlides().removeAt(0);

            // Klon slide templat ke dalam presentasi baru.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Ambil paragraf dari shape target (diasumsikan indeks shape 1 digunakan).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Ganti placeholder dengan data dari Excel.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Simpan presentasi yang dipersonalisasi ke file terpisah.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
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

Pada contoh kedua, kami hanya menyalin data dari tabel Excel dan menampilkannya pada slide PowerPoint dalam format yang lebih menarik secara visual.

Dalam contoh ini, kami menggunakan kembali buku kerja Excel yang sama dari contoh pertama, yang berisi tabel karyawan sederhana.

```js
// Muat buku kerja Excel yang berisi data karyawan.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Buat presentasi PowerPoint baru.
let presentation = new aspose.slides.Presentation();

try {
    // Tambahkan shape tabel ke slide pertama.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Isi tabel PowerPoint dengan data dari buku kerja Excel.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Simpan presentasi hasil ke file.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hasil](example2_image0.png)

### **Contoh Mengimpor Grafik Excel**

Dalam contoh ini, kami mengimpor grafik dari lembar kerja pertama buku kerja Excel yang digunakan pada contoh sebelumnya. Grafik tersebut akan terhubung ke buku kerja eksternal dalam presentasi yang dihasilkan.

Pertama, kami menambahkan grafik Pie ke buku kerja Excel berdasarkan tabel karyawan.

![Contoh Grafik Excel](example3_image0.png)

```js
// Buat presentasi PowerPoint baru.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil koleksi shape dari slide pertama.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Impor grafik bernama "Chart 1" dari lembar pertama buku kerja dan tambahkan ke koleksi shape.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Simpan presentasi hasil ke file.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hasil](example3_image1.png)

### **Contoh Mengimpor Semua Grafik Excel**

Bayangkan Anda memiliki buku kerja Excel penuh dengan grafik dan Anda perlu mengimpor semuanya ke dalam sebuah presentasi. Setiap grafik harus ditempatkan pada slide baru.

Kode berikut mengiterasi semua lembar kerja dalam file Excel sumber, mengekstrak grafik dari setiap lembar kerja, dan menambahkan setiap grafik ke slide terpisah menggunakan tata letak slide kosong. Dalam presentasi yang dihasilkan, hanya data grafik yang akan disematkan, bukan seluruh buku kerja.

```js
// Muat buku kerja Excel yang berisi data karyawan.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Buat presentasi PowerPoint baru.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil tata letak slide kosong.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Dapatkan nama semua lembar kerja yang terdapat dalam buku kerja Excel.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Dapatkan peta yang memetakan indeks grafik ke nama grafik untuk lembar kerja.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Tambahkan slide baru menggunakan tata letak kosong.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Impor grafik yang ditentukan dari buku kerja Excel ke dalam koleksi shape slide.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Simpan presentasi hasil ke file.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ringkasan**

Mekanisme ini, tersedia langsung di Aspose.Slides, menggabungkan kerja dengan data Excel dan presentasi dalam satu tempat. Ini memungkinkan Anda membuat slide dengan grafik visual dan data yang disajikan sebagai tabel Excel — tanpa pustaka tambahan atau integrasi yang kompleks.