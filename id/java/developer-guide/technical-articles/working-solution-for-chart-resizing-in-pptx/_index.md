---
title: Solusi Berfungsi untuk Mengubah Ukuran Grafik di PPTX
type: docs
weight: 40
url: /id/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- mengubah ukuran grafik
- grafik Excel
- objek OLE
- menyematkan grafik
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Perbaiki perubahan ukuran grafik yang tidak terduga di PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides for Java. Pelajari dua metode dengan kode untuk menjaga ukuran tetap konsisten."
---
## **Latar Belakang**

Terjadi pengamatan bahwa grafik Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose mengalami perubahan ukuran ke skala yang tidak ditentukan setelah aktivasi pertama. Perilaku ini menyebabkan perbedaan visual yang jelas dalam presentasi antara keadaan grafik sebelum dan sesudah aktivasi. Tim Aspose telah menyelidiki masalah ini secara mendetail dan menemukan solusinya. Artikel ini menjelaskan penyebab masalah dan perbaikan yang bersangkutan.

Dalam [artikel sebelumnya](/slides/id/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat grafik Excel dengan Aspose.Cells for Java dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides for Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/java/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar grafik ke kerangka objek OLE grafik tersebut. Pada presentasi output, ketika Anda mengklik ganda kerangka objek OLE yang menampilkan gambar grafik, grafik Excel diaktifkan. Pengguna akhir dapat membuat perubahan apa pun yang diinginkan di buku kerja Excel yang mendasarinya, kemudian kembali ke slide terkait dengan mengklik di luar buku kerja yang diaktifkan. Ukuran kerangka objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik kerangka objek OLE maupun buku kerja Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela tersendiri, ia mencoba mempertahankan ukuran aslinya pada aktivasi pertama. Kerangka objek OLE, bagaimanapun, memiliki ukuran tersendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi mengenai ukuran dan mempertahankan proporsi yang tepat sebagai bagian dari proses penyematan. Bergantung pada perbedaan antara ukuran jendela Excel dan ukuran atau posisi kerangka objek OLE, terjadi perubahan ukuran.

## **Solusi yang Berfungsi**

Ada dua skenario kemungkinan untuk membuat presentasi PowerPoint menggunakan Aspose.Slides for Java.

**Skenario 1:** Membuat presentasi berdasarkan templat yang ada.

**Skenario 2:** Membuat presentasi dari awal.

Solusi yang kami berikan di sini berlaku untuk kedua skenario. Dasar semua pendekatan solusi adalah sama: **ukuran jendela objek OLE yang disematkan harus cocok dengan kerangka objek OLE di slide PowerPoint**. Kami akan membahas dua pendekatan untuk solusi ini.

## **Pendekatan Pertama**

Dalam pendekatan ini, kita akan belajar cara mengatur ukuran jendela buku kerja Excel yang disematkan sehingga cocok dengan ukuran kerangka objek OLE di slide PowerPoint.

**Skenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Anggap ada sebuah shape pada indeks 2 dalam templat di mana kami ingin menempatkan kerangka OLE yang berisi buku kerja Excel yang disematkan. Dalam skenario ini, ukuran kerangka objek OLE sudah ditentukan—ia cocok dengan ukuran shape pada indeks 2 dalam templat. Yang perlu kami lakukan hanyalah mengatur ukuran jendela buku kerja agar sama dengan ukuran shape tersebut. Potongan kode berikut melayani tujuan ini:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Atur lebar jendela buku kerja dalam inci (dibagi 72 karena PowerPoint menggunakan 72 poin per inci).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Atur tinggi jendela buku kerja dalam inci.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Simpan buku kerja ke aliran memori.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Buat kerangka objek OLE dengan data Excel yang disematkan.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Skenario 2**

Katakanlah kami ingin membuat presentasi dari awal dan menyertakan kerangka objek OLE dengan ukuran apa pun yang berisi buku kerja Excel yang disematkan. Pada potongan kode berikut, kami membuat kerangka objek OLE setinggi 4 inci dan lebar 9,5 inci pada x = 0,5 inci dan y = 1 inci di slide. Kemudian kami mengatur jendela buku kerja Excel ke ukuran yang sama—tinggi 4 inci dan lebar 9,5 inci.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Tinggi yang diinginkan.
int desiredHeight = 288; // 4 inch (4 * 72)
 
// Lebar yang diinginkan.
int desiredWidth = 684; // 9.5 inch (9.5 * 72)
 
// Tentukan ukuran grafik dengan jendela.
chart.setSizeWithWindow(true);
 
// Atur lebar jendela buku kerja dalam inci (dibagi 72 karena PowerPoint menggunakan 72 poin per inci).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Atur tinggi jendela buku kerja dalam inci.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Simpan buku kerja ke aliran memori.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Buat kerangka objek OLE dengan data Excel yang disematkan.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 inch (0.5 * 72)
    72,  // y = 1 inch (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Pendekatan Kedua**

Dalam pendekatan ini, kita akan belajar cara mengatur ukuran grafik di dalam buku kerja Excel yang disematkan agar cocok dengan ukuran kerangka objek OLE di slide PowerPoint. Pendekatan ini berguna ketika ukuran grafik sudah diketahui sebelumnya dan tidak akan berubah.

**Skenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Anggap ada sebuah shape pada indeks 2 dalam templat di mana kami berniat menempatkan kerangka OLE yang berisi buku kerja Excel yang disematkan. Dalam skenario ini, ukuran kerangka OLE sudah ditentukan—sesuai dengan ukuran shape pada indeks 2 dalam templat. Yang perlu kami lakukan hanyalah mengatur ukuran grafik di buku kerja agar sama dengan ukuran shape tersebut. Potongan kode berikut melayani tujuan ini:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Tentukan ukuran grafik tanpa jendela.
chart.setSizeWithWindow(false);
 
// Atur lebar grafik dalam piksel (kalikan dengan 96 karena Excel menggunakan 96 piksel per inci).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Atur tinggi grafik dalam piksel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Tentukan ukuran cetak grafik.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Simpan buku kerja ke aliran memori.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Buat kerangka objek OLE dengan data Excel yang disematkan.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Skenario 2**:

Misalkan kami ingin membuat presentasi dari awal dan menyertakan kerangka objek OLE dengan ukuran apa pun yang berisi buku kerja Excel yang disematkan. Pada potongan kode berikut, kami membuat kerangka objek OLE dengan tinggi 4 inci dan lebar 9,5 inci pada slide di x = 0,5 inci dan y = 1 inci. Kami juga mengatur ukuran grafik yang bersesuaian ke dimensi yang sama: tinggi 4 inci dan lebar 9,5 inci.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Tinggi yang diinginkan.
int desiredHeight = 288; // 4 inci (4 * 72)
 
// Lebar yang diinginkan.
int desiredWidth = 684; // 9,5 inci (9.5 * 72)
 
// Tentukan ukuran grafik tanpa jendela.
chart.setSizeWithWindow(false);
 
// Atur lebar grafik dalam piksel (dibagi 72 untuk mendapatkan inci, dikalikan 96 karena Excel menggunakan 96 piksel per inci).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Atur tinggi grafik dalam piksel.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Simpan buku kerja ke aliran memori.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Buat kerangka objek OLE dengan data Excel yang disematkan.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 inci (0.5 * 72)
    72,  // y = 1 inci (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Kesimpulan**

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran grafik. Pilihan pendekatan tergantung pada kebutuhan dan kasus penggunaan. Kedua pendekatan bekerja dengan cara yang sama baik presentasi dibuat dari templat maupun dibuat dari awal. Selain itu, tidak ada batasan ukuran kerangka objek OLE dalam solusi ini.

## **FAQ**

### Mengapa grafik Excel yang disematkan berubah ukuran setelah diaktifkan di PowerPoint?

Hal ini terjadi karena Excel mencoba mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sementara kerangka objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

### Apakah mungkin mencegah masalah perubahan ukuran ini sepenuhnya?

Ya. Dengan mencocokkan ukuran jendela buku kerja Excel atau ukuran grafik dengan ukuran kerangka objek OLE sebelum penyematan, Anda dapat menjaga konsistensi ukuran grafik.

### Pendekatan mana yang harus saya pilih, mengatur ukuran jendela buku kerja atau mengatur ukuran grafik?

Gunakan **Pendekatan 1 (ukuran jendela)** jika Anda ingin mempertahankan rasio aspek buku kerja dan memungkinkan perubahan ukuran di kemudian hari.
Gunakan **Pendekatan 2 (ukuran grafik)** jika dimensi grafik bersifat tetap dan tidak akan berubah setelah penyematan.

### Apakah metode ini bekerja untuk presentasi berbasis templat dan presentasi baru?

Ya. Kedua pendekatan bekerja sama untuk presentasi yang dibuat dari templat maupun dari awal.

### Apakah ada batasan ukuran kerangka objek OLE?

Tidak. Anda dapat mengatur kerangka OLE ke ukuran apa pun selama skala tersebut cocok dengan ukuran buku kerja atau grafik.

### Bisakah saya menggunakan metode ini dengan grafik yang dibuat di program spreadsheet lain?

Contoh-contoh dirancang untuk grafik Excel yang dibuat dengan Aspose.Cells, tetapi prinsipnya berlaku untuk program spreadsheet lain yang kompatibel dengan OLE selama mereka mendukung opsi pengukuran serupa.

## **Bagian Terkait**

- [Buat Grafik Excel dan Sematkan Sebagai Objek OLE dalam Presentasi](/slides/id/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)