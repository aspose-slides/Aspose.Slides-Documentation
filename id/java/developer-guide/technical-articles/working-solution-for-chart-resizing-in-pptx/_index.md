---
title: Solusi Praktis untuk Mengubah Ukuran Bagan di PPTX
type: docs
weight: 40
url: /id/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- perubahan ukuran bagan
- bagan Excel
- objek OLE
- menyisipkan bagan
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Perbaiki perubahan ukuran bagan yang tidak terduga di PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk Java. Pelajari dua metode dengan kode untuk menjaga ukuran tetap konsisten."
---
## **Latar Belakang**

Telah diamati bahwa bagan Excel yang disisipkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose mengalami perubahan ukuran ke skala yang tidak ditentukan setelah aktivasi pertama. Perilaku ini menyebabkan perbedaan visual yang jelas dalam presentasi antara keadaan sebelum dan sesudah aktivasi bagan. Tim Aspose telah menyelidiki masalah ini secara mendetail dan menemukan solusi. Artikel ini menjelaskan penyebab masalah dan perbaikan yang sesuai.

Dalam [artikel sebelumnya](/slides/id/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat bagan Excel dengan Aspose.Cells for Java dan menyisipkannya ke dalam presentasi PowerPoint menggunakan Aspose.Slides for Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/java/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar bagan ke frame objek OLE bagan. Pada presentasi hasil, ketika Anda mengklik dua kali frame objek OLE yang menampilkan gambar bagan, bagan Excel diaktifkan. Pengguna akhir dapat membuat perubahan apa pun yang diinginkan pada workbook Excel yang mendasarinya dan kemudian kembali ke slide yang bersangkutan dengan mengklik di luar workbook yang diaktifkan. Ukuran frame objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik frame objek OLE maupun workbook Excel yang disisipkan.

## **Penyebab Perubahan Ukuran**

Karena workbook Excel memiliki ukuran jendela tersendiri, ia berusaha mempertahankan ukuran aslinya pada aktivasi pertama. Frame objek OLE, bagaimanapun, memiliki ukuran sendiri. Menurut Microsoft, ketika workbook Excel diaktifkan, Excel dan PowerPoint menegosiasikan ukuran dan mempertahankan proporsi yang benar sebagai bagian dari proses penyisipan. Tergantung pada perbedaan antara ukuran jendela Excel dan ukuran atau posisi frame objek OLE, perubahan ukuran terjadi.

## **Solusi yang Berfungsi**

Ada dua skenario possible untuk membuat presentasi PowerPoint menggunakan Aspose.Slides for Java.

**Skenario 1:** Membuat presentasi berdasarkan templat yang ada.

**Skenario 2:** Membuat presentasi dari awal.

Solusi yang kami berikan di sini berlaku untuk kedua skenario. Dasar semua pendekatan solusi adalah sama: **ukuran jendela objek OLE yang disisipkan harus cocok dengan frame objek OLE di slide PowerPoint**. Kami akan membahas dua pendekatan untuk solusi ini.

## **Pendekatan Pertama**

Dalam pendekatan ini, kami akan mempelajari cara mengatur ukuran jendela workbook Excel yang disisipkan sehingga cocok dengan ukuran frame objek OLE di slide PowerPoint.

**Skenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Asumsikan ada bentuk pada indeks 2 dalam templat tempat kami ingin menempatkan frame OLE yang berisi workbook Excel yang disisipkan. Dalam skenario ini, ukuran frame objek OLE sudah ditentukan—ia cocok dengan ukuran bentuk pada indeks 2 dalam templat. Yang perlu kami lakukan hanyalah mengatur ukuran jendela workbook agar sama dengan ukuran bentuk tersebut. Potongan kode berikut melayani tujuan ini:

```java
// Atur lebar jendela workbook dalam inci (dibagi 576 karena PowerPoint menggunakan 576 piksel per inci).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Atur tinggi jendela workbook dalam inci.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Simpan workbook ke aliran memori.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Buat frame objek OLE dengan data Excel yang disisipkan.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Skenario 2**

Misalkan kami ingin membuat presentasi dari awal dan menyertakan frame objek OLE dengan ukuran apa pun serta workbook Excel yang disisipkan. Pada potongan kode berikut, kami membuat frame objek OLE dengan tinggi 4 inci dan lebar 9,5 inci pada x = 0,5 inci dan y = 1 inci di slide. Kami kemudian mengatur jendela workbook Excel ke ukuran yang sama—tinggi 4 inci dan lebar 9,5 inci.

```java
// Tinggi yang diinginkan.
int desiredHeight = 288; // 4 inci (4 * 72)
 
// Lebar yang diinginkan.
int desiredWidth = 684; // 9.5 inci (9.5 * 72)
 
// Tentukan ukuran bagan dengan jendela.
chart.setSizeWithWindow(true);
 
// Atur lebar jendela workbook dalam inci (dibagi 576 karena PowerPoint menggunakan 576 piksel per inci).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Atur tinggi jendela workbook dalam inci.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Simpan workbook ke aliran memori.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Buat frame objek OLE dengan data Excel yang disisipkan.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Pendekatan Kedua**

Dalam pendekatan ini, kami akan mempelajari cara mengatur ukuran bagan dalam workbook Excel yang disisipkan agar cocok dengan ukuran frame objek OLE di slide PowerPoint. Pendekatan ini berguna ketika ukuran bagan sudah diketahui sebelumnya dan tidak akan berubah.

**Skenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Asumsikan ada bentuk pada indeks 2 dalam templat tempat kami berencana menempatkan frame OLE yang berisi workbook Excel yang disisipkan. Dalam skenario ini, ukuran frame OLE sudah ditentukan—menyesuaikan ukuran bentuk pada indeks 2 dalam templat. Yang perlu kami lakukan hanyalah mengatur ukuran bagan dalam workbook agar sama dengan ukuran bentuk tersebut. Potongan kode berikut melayani tujuan ini:

```java
// Tentukan ukuran bagan tanpa jendela.
chart.setSizeWithWindow(false);
 
// Atur lebar bagan dalam piksel (kalikan dengan 96 karena Excel menggunakan 96 piksel per inci).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Atur tinggi bagan dalam piksel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Tentukan ukuran cetak bagan.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Simpan workbook ke aliran memori.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Buat frame objek OLE dengan data Excel yang disisipkan.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Skenario 2**:

Misalkan kami ingin membuat presentasi dari awal dan menyertakan frame objek OLE dengan ukuran apa pun serta workbook Excel yang disisipkan. Pada potongan kode berikut, kami membuat frame objek OLE dengan tinggi 4 inci dan lebar 9,5 inci di slide pada x = 0,5 inci dan y = 1 inci. Kami juga mengatur ukuran bagan yang bersesuaian ke dimensi yang sama: tinggi 4 inci dan lebar 9,5 inci.

```java
// Tinggi yang diinginkan.
int desiredHeight = 288; // 4 inci (4 * 72)
 
// Lebar yang diinginkan.
int desiredWidth = 684; // 9.5 inci (9.5 * 72)
 
// Tentukan ukuran bagan tanpa jendela.
chart.setSizeWithWindow(false);
 
// Atur lebar bagan dalam piksel (kalikan dengan 96 karena Excel menggunakan 96 piksel per inci).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Atur tinggi bagan dalam piksel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Simpan workbook ke aliran memori.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Buat frame objek OLE dengan data Excel yang disisipkan.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Kesimpulan**

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran bagan. Pilihan pendekatan tergantung pada kebutuhan dan kasus penggunaan. Kedua pendekatan bekerja dengan cara yang sama baik ketika presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan ukuran frame objek OLE dalam solusi ini.

## **FAQ**

**Mengapa bagan Excel yang saya sisipkan berubah ukuran setelah diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sedangkan frame objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel menegosiasikan ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah mungkin mencegah masalah perubahan ukuran ini sepenuhnya?**

Ya. Dengan mencocokkan ukuran jendela workbook Excel atau ukuran bagan dengan ukuran frame objek OLE sebelum penyisipan, Anda dapat menjaga konsistensi ukuran bagan.

**Pendekatan mana yang harus saya pilih, mengatur ukuran jendela workbook atau mengatur ukuran bagan?**

Gunakan **Pendekatan 1 (ukuran jendela)** jika Anda ingin mempertahankan rasio aspek workbook dan mungkin memungkinkan perubahan ukuran di kemudian hari.  
Gunakan **Pendekatan 2 (ukuran bagan)** jika dimensi bagan sudah tetap dan tidak akan berubah setelah penyisipan.

**Apakah metode ini akan bekerja pada presentasi berbasis templat dan presentasi baru?**

Ya. Kedua pendekatan bekerja sama untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran frame objek OLE?**

Tidak. Anda dapat mengatur frame OLE ke ukuran berapa pun selama skala tersebut cocok dengan ukuran workbook atau bagan.

**Dapatkah saya menggunakan metode ini dengan bagan yang dibuat di program spreadsheet lain?**

Contoh ini dirancang untuk bagan Excel yang dibuat dengan Aspose.Cells, tetapi prinsipnya berlaku untuk program spreadsheet lain yang kompatibel dengan OLE selama mereka mendukung opsi pengukuran serupa.

## **Bagian Terkait**

- [Membuat Bagan Excel dan Menyisipkannya sebagai Objek OLE dalam Presentasi](/slides/id/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Memperbarui Objek OLE Secara Otomatis Menggunakan Add-In PowerPoint](/slides/id/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)