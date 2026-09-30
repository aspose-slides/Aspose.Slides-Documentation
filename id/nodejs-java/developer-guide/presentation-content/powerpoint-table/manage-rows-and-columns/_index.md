---
title: Kelola Baris dan Kolom dalam Tabel PowerPoint Menggunakan JavaScript
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/nodejs-java/manage-rows-and-columns/
keywords:
- baris tabel
- kolom tabel
- baris pertama
- header tabel
- salin baris
- salin kolom
- menyalin baris
- menyalin kolom
- hapus baris
- hapus kolom
- pemformatan teks baris
- pemformatan teks kolom
- gaya tabel
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola baris dan kolom tabel dalam PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js via Java serta percepat penyuntingan presentasi dan pembaruan data."
---
## **Pengantar**

Aspose.Slides untuk Node.js via Java memungkinkan Anda mengelola struktur tabel dan pemformatan dalam presentasi PowerPoint melalui kelas [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Anda dapat menentukan baris header, menyalin atau menghapus baris dan kolom, serta menerapkan pemformatan teks pada seluruh baris atau kolom.

Artikel ini menjelaskan operasi‑operasi tersebut dengan contoh JavaScript. Artikel ini juga menunjukkan cara mengambil preset gaya tabel sehingga Anda dapat menggunakannya kembali. Indeks baris dan kolom tabel dimulai dari nol.

## **Mengontrol Tinggi Baris**

Gunakan [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) untuk menetapkan tinggi minimum baris dalam poin. Itu merupakan batas bawah, bukan tinggi tetap. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) mengembalikan tinggi sebenarnya. Akses baris melalui [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

Contoh memuat [row-height-input.pptx](row-height-input.pptx), yang memiliki tabel sebagai bentuk pertama pada slide pertama. Baris pertama dimulai pada 70 poin. Sel‑sel menggunakan teks Arial 18‑poin, pembungkus, dan margin atas serta bawah 6‑poin; teks yang lebih panjang pada kolom kedua membungkus menjadi beberapa baris. Contoh meningkatkan minimum menjadi 100 poin, kemudian menurunkannya menjadi 20 poin, mencetak tinggi sebenarnya setelah setiap perubahan, dan menyimpan kedua hasilnya.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dengan presentasi yang disediakan, meningkatkan minimum menambah ruang pada baris. Menguranginya menghapus ruang ekstra tersebut, tetapi tinggi sebenarnya tetap lebih besar dari 20 poin karena teks dan margin sel membutuhkan lebih banyak ruang. Mengurangi minimum saja tidak dapat memaksa baris berada di bawah ruang yang diperlukan oleh isinya.

Beberapa faktor memengaruhi tinggi sebenarnya:

- **Teks dan ukuran huruf:** teks yang lebih panjang, jeda baris eksplisit, atau ukuran huruf yang lebih besar dapat memerlukan lebih banyak ruang vertikal.
- **Pembungkus dan lebar kolom:** dengan pembungkus diaktifkan, mengurangi lebar kolom dengan [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) dapat menghasilkan lebih banyak baris. Kolom yang lebih lebar dapat mengurangi ruang yang diperlukan secara vertikal.
- **Margin sel:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) dan [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) menambah ruang vertikal. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) dan [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) mengurangi lebar yang tersedia untuk teks dan dapat menyebabkan pembungkus tambahan.

Untuk tabel ini tanpa sel yang digabung, sel yang membutuhkan ruang vertikal paling banyak menentukan batas bawah yang ditentukan konten untuk seluruh baris. Untuk memendekkan baris, Anda mungkin juga perlu memendekkan teks, mengurangi ukuran huruf atau margin, atau memperlebar kolom.

Gambar di bawah menunjukkan tabel yang sama pada skala yang sama. Pada hasil yang diilustrasikan, tinggi sebenarnya adalah 70, 100, dan 55,2 poin: baris akhir tetap lebih tinggi daripada minimum 20 poin. Pengukuran teks yang tepat dapat bervariasi tergantung pada huruf yang tersedia di lingkungan Anda. Unduh hasil yang disimpan: [increased minimum](row-height-increased.pptx) dan [decreased minimum](row-height-decreased.pptx).

| Asli: minimum 70 pt, aktual 70 pt | Ditambah: minimum 100 pt, aktual 100 pt | Dikurangi: minimum 20 pt, aktual 55.2 pt |
| --- | --- | --- |
| ![Tabel asli dengan baris pertama 70 poin.](row-height-before.png) | ![Tabel setelah meningkatkan minimum baris pertama menjadi 100 poin.](row-height-increased.png) | ![Tabel setelah mengurangi minimum baris pertama menjadi 20 poin; teks yang dibungkus membuat baris tetap lebih tinggi daripada minimum.](row-height-decreased.png) |

## **Tetapkan Baris Pertama sebagai Header**

Gunakan metode [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) untuk menandai baris pertama agar diformat sebagai header. Penampilannya tergantung pada gaya tabel yang diterapkan pada tabel.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Akses slide pertama.
3. Akses tabel yang disimpan sebagai bentuk pertama pada slide.
4. Aktifkan pemformatan header untuk baris pertamanya.
5. Simpan presentasi yang telah dimodifikasi.

Contoh memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama. Contoh ini mengaktifkan pemformatan header untuk baris pertama dan menyimpan `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menyalin Baris atau Kolom Tabel**

Salin baris atau kolom untuk menggunakan kembali konten dan pemformatannya. Anda dapat menambahkan salinan ke akhir tabel atau menyisipkannya pada posisi tertentu.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Salin baris yang diperlukan.
6. Salin kolom yang diperlukan.
7. Simpan presentasi yang telah dimodifikasi.

Contoh memerlukan `Test.pptx` dengan setidaknya satu slide. Contoh ini membuat tabel dengan tiga kolom dan lima baris, dengan dimensi yang ditentukan dalam poin. Ia menambahkan salinan baris pertama dan kolom pertama, kemudian menyisipkan salinan baris kedua dan kolom kedua pada indeks 3 (posisi keempat). Tabel yang dihasilkan memiliki tujuh baris dan lima kolom. Argumen `false` menonaktifkan penyalinan ke baris atau kolom yang berdekatan yang digabung; tabel ini tidak memiliki sel yang digabung.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menghapus Baris atau Kolom dari Tabel**

Hapus baris atau kolom yang tidak lagi diperlukan dalam tabel. Menghapus suatu item menggeser indeks baris atau kolom yang mengikutinya.

1. Buat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Hapus baris kedua dan kolom kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh ini membuat tabel tiga‑by‑tiga dan menghapus baris serta kolom pada indeks 1, sehingga meninggalkan tabel dua‑by‑dua dalam `TestTable_out.pptx`. Dimensi berada dalam poin. Argumen `false` menonaktifkan penghapusan pada baris atau kolom yang berdekatan yang digabung; tabel ini tidak memiliki sel yang digabung.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menetapkan Pemformatan Teks pada Tingkat Baris Tabel**

Terapkan pemformatan teks pada seluruh baris agar sel‑selnya konsisten. Anda dapat menetapkan properti huruf, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Akses tabel pada slide pertama.
3. Gunakan [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) untuk baris pertama.
4. Gunakan [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) dan [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) untuk baris pertama.
5. Gunakan [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) untuk baris kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama dan setidaknya dua baris. Contoh ini menerapkan teks 25‑poin, perataan kanan, dan margin paragraf kanan 20‑poin pada baris pertama, kemudian menetapkan teks vertikal pada baris kedua.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menetapkan Pemformatan Teks pada Tingkat Kolom Tabel**

Terapkan pemformatan teks pada seluruh kolom agar sel‑selnya konsisten. Anda dapat menetapkan properti huruf, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Akses tabel pada slide pertama.
3. Gunakan [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) untuk kolom pertama.
4. Gunakan [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) dan [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) untuk kolom pertama.
5. Gunakan [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) untuk kolom kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama dan setidaknya dua kolom. Contoh ini menerapkan teks 25‑poin, perataan kanan, dan margin paragraf kanan 20‑poin pada kolom pertama, kemudian menetapkan teks vertikal pada kolom kedua.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mendapatkan Properti Gaya Tabel**

Gunakan metode [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) untuk mengambil preset yang diterapkan pada tabel dan menggunakannya kembali pada tabel lain. Metode ini mengidentifikasi preset alih‑alih menimpa format sel individual.

Contoh membuat tabel, menerapkan [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1), dan membaca kembali preset tersebut. Contoh mencetak nilai integer yang sesuai dengan `DarkStyle1` dan menyimpan tabel dalam `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/tata letak/master, dan Anda masih dapat menimpa isi, batas, dan warna teks di atas tema tersebut.

**Apakah saya dapat mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki fungsi penyortiran atau filter bawaan. Urutkan data di memori terlebih dahulu, kemudian isi kembali baris‑baris tabel sesuai urutan tersebut.

**Apakah saya dapat memiliki kolom bergaris (striped) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom bergaris, kemudian timpa sel‑sel tertentu dengan pemformatan lokal; pemformatan pada tingkat sel memiliki prioritas lebih tinggi dibandingkan gaya tabel.