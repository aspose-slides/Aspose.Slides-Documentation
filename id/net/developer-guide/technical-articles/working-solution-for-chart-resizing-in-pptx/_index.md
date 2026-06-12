---
title: Solusi yang Berfungsi untuk Mengubah Ukuran Diagram di PPTX
type: docs
weight: 60
url: /id/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- perubahan ukuran diagram
- diagram Excel
- objek OLE
- menyematkan diagram
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Perbaiki perubahan ukuran diagram yang tidak terduga dalam PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk .NET. Pelajari dua metode dengan kode untuk menjaga ukuran tetap konsisten."
---
## **Latar Belakang**

Telah diamati bahwa diagram Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose diubah ukurannya ke skala yang tidak ditentukan setelah aktivasi pertama. Perilaku ini menyebabkan perbedaan visual yang jelas dalam presentasi antara keadaan diagram sebelum dan sesudah aktivasi. Tim Aspose telah menyelidiki masalah ini secara mendetail dan menemukan solusi. Artikel ini menjelaskan penyebab masalah dan perbaikan yang sesuai.

Dalam [artikel sebelumnya](/slides/id/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat diagram Excel dengan Aspose.Cells untuk .NET dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET. Untuk mengatasi [masalah pratinjau objek](/slides/id/net/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar diagram ke kerangka objek OLE diagram. Dalam presentasi hasil, ketika Anda mengklik ganda kerangka objek OLE yang menampilkan gambar diagram, diagram Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun yang diinginkan pada buku kerja Excel yang mendasarinya dan kemudian kembali ke slide yang bersangkutan dengan mengklik di luar buku kerja yang diaktifkan. Ukuran kerangka objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik kerangka objek OLE maupun buku kerja Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela sendiri, ia berusaha mempertahankan ukuran aslinya pada aktivasi pertama. Namun, kerangka objek OLE memiliki ukuran tersendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi mengenai ukuran dan mempertahankan proporsi yang benar sebagai bagian dari proses penyematan. Bergantung pada perbedaan antara ukuran jendela Excel dan ukuran atau posisi kerangka objek OLE, terjadi perubahan ukuran.

## **Solusi yang Berfungsi**

Ada dua skenario yang mungkin untuk membuat presentasi PowerPoint menggunakan Aspose.Slides untuk .NET.

**Scenario 1:** Membuat presentasi berdasarkan templat yang ada.

**Scenario 2:** Membuat presentasi dari awal.

Solusi yang kami berikan di sini berlaku untuk kedua skenario. Dasar semua pendekatan solusi adalah sama: **ukuran jendela objek OLE yang disematkan harus sesuai dengan kerangka objek OLE di slide PowerPoint**. Sekarang kami akan membahas dua pendekatan untuk solusi ini.

## **Pendekatan Pertama**

Dalam pendekatan ini, kami akan mempelajari cara mengatur ukuran jendela buku kerja Excel yang disematkan sehingga sesuai dengan ukuran kerangka objek OLE di slide PowerPoint.

**Scenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Asumsikan ada bentuk pada indeks 2 dalam templat di mana kami ingin menempatkan sebuah kerangka OLE yang berisi buku kerja Excel yang disematkan. Dalam skenario ini, ukuran kerangka objek OLE telah ditentukan sebelumnya—sesuai dengan ukuran bentuk pada indeks 2 dalam templat. Yang perlu kami lakukan hanyalah mengatur ukuran jendela buku kerja agar sama dengan ukuran bentuk tersebut. Potongan kode berikut melayani tujuan ini:

```cs
// Tentukan ukuran diagram dengan jendela. 
chart.SizeWithWindow = true;

// Atur lebar jendela buku kerja dalam inci (dibagi 72 karena PowerPoint menggunakan 72 piksel per inci).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Atur tinggi jendela buku kerja dalam inci.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Simpan buku kerja ke aliran memori.
MemoryStream workbookStream = workbook.SaveToStream();

// Buat kerangka objek OLE dengan data Excel yang disematkan.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

Misalkan kami ingin membuat presentasi dari awal dan menyertakan sebuah kerangka objek OLE dengan ukuran apa pun yang berisi buku kerja Excel yang disematkan. Pada potongan kode berikut, kami membuat kerangka objek OLE setinggi 4 inci dan lebar 9,5 inci pada x = 0,5 inci dan y = 1 inci di slide. Kami kemudian mengatur jendela buku kerja Excel ke ukuran yang sama—tinggi 4 inci dan lebar 9,5 inci.

```cs
// Tinggi yang diinginkan.
int desiredHeight = 288; // 4 inci (4 * 72)

// Lebar yang diinginkan.
int desiredWidth = 684;//9.5 inci (9.5 * 72)

// Tentukan ukuran diagram dengan jendela.
chart.SizeWithWindow = true;

// Atur lebar jendela buku kerja dalam inci.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Atur tinggi jendela buku kerja dalam inci.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Simpan buku kerja ke aliran memori.
MemoryStream workbookStream = workbook.SaveToStream();

// Buat kerangka objek OLE dengan data Excel yang disematkan.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Pendekatan Kedua**

Dalam pendekatan ini, kami akan mempelajari cara mengatur ukuran diagram dalam buku kerja Excel yang disematkan agar sesuai dengan ukuran kerangka objek OLE di slide PowerPoint. Pendekatan ini berguna ketika ukuran diagram sudah diketahui sebelumnya dan tidak akan berubah.

**Scenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Asumsikan ada bentuk pada indeks 2 dalam templat di mana kami berniat menempatkan sebuah kerangka OLE yang berisi buku kerja Excel yang disematkan. Dalam skenario ini, ukuran kerangka OLE telah ditentukan sebelumnya—sesuai dengan ukuran bentuk pada indeks 2 dalam templat. Yang perlu kami lakukan hanyalah mengatur ukuran diagram dalam buku kerja agar sama dengan ukuran bentuk tersebut. Potongan kode berikut melayani tujuan ini:

```cs
// Tentukan ukuran diagram tanpa jendela. 
chart.SizeWithWindow = false;

// Atur lebar diagram dalam piksel (kalikan dengan 96 karena Excel menggunakan 96 piksel per inci).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Atur tinggi diagram dalam piksel.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Tentukan ukuran cetak diagram.
chart.PrintSize = PrintSizeType.Custom;

// Simpan buku kerja ke aliran memori.
MemoryStream workbookStream = workbook.SaveToStream();

// Buat kerangka objek OLE dengan data Excel yang disematkan.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

Misalkan kami ingin membuat presentasi dari awal dan menyertakan sebuah kerangka objek OLE dengan ukuran apa pun yang berisi buku kerja Excel yang disematkan. Pada potongan kode berikut, kami membuat kerangka objek OLE dengan tinggi 4 inci dan lebar 9,5 inci di slide pada x = 0,5 inci dan y = 1 inci. Kami juga mengatur ukuran diagram yang bersesuaian ke dimensi yang sama: tinggi 4 inci dan lebar 9,5 inci.

```cs
 // Tinggi yang diinginkan.
int desiredHeight = 288; // 4 inci (4 * 576)

// Lebar yang diinginkan.
int desiredWidth = 684; // 9.5 inci (9.5 * 576)

// Tentukan ukuran diagram tanpa jendela. 
chart.SizeWithWindow = false;

// Atur lebar diagram dalam piksel.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Atur tinggi diagram dalam piksel.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Simpan buku kerja ke aliran memori.
MemoryStream workbookStream = workbook.SaveToStream();

// Buat kerangka objek OLE dengan data Excel yang disematkan.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Kesimpulan**

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran diagram. Pilihan pendekatan tergantung pada kebutuhan dan kasus penggunaan. Kedua pendekatan bekerja dengan cara yang sama baik presentasi dibuat dari templat maupun dibuat dari awal. Selain itu, tidak ada batasan ukuran kerangka objek OLE dalam solusi ini.

## **FAQ**

**Mengapa diagram Excel yang saya sematkan berubah ukuran setelah diaktifkan di PowerPoint?**  
Hal ini terjadi karena Excel berusaha mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sementara kerangka objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi mengenai ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah mungkin mencegah masalah perubahan ukuran ini sepenuhnya?**  
Ya. Dengan mencocokkan ukuran jendela buku kerja Excel atau ukuran diagram dengan ukuran kerangka objek OLE sebelum penyematan, Anda dapat menjaga konsistensi ukuran diagram.

**Pendekatan mana yang harus saya gunakan, mengatur ukuran jendela buku kerja atau mengatur ukuran diagram?**  
Gunakan **Pendekatan 1 (ukuran jendela)** jika Anda ingin mempertahankan rasio aspek buku kerja dan mungkin memungkinkan perubahan ukuran nanti.  
Gunakan **Pendekatan 2 (ukuran diagram)** jika dimensi diagram sudah tetap dan tidak akan berubah setelah disematkan.

**Apakah metode ini akan bekerja dengan presentasi berbasis templat dan presentasi baru?**  
Ya. Kedua pendekatan bekerja dengan cara yang sama untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran kerangka objek OLE?**  
Tidak. Anda dapat mengatur kerangka OLE ke ukuran apa pun selama skala tersebut sesuai dengan ukuran buku kerja atau diagram.

**Apakah saya dapat menggunakan metode ini dengan diagram yang dibuat di program spreadsheet lain?**  
Contoh-contoh dirancang untuk diagram Excel yang dibuat dengan Aspose.Cells, namun prinsip-prinsipnya berlaku untuk program spreadsheet lain yang kompatibel dengan OLE selama mereka mendukung opsi penyesuaian ukuran yang serupa.

## **Bagian Terkait**

- [Buat Diagram Excel dan Sematkan Sebagai Objek OLE dalam Presentasi](/slides/id/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Perbarui Objek OLE Secara Otomatis Menggunakan Add-In PowerPoint](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)