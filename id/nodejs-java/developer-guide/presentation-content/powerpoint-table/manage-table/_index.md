---
title: Kelola Tabel Presentasi dengan JavaScript
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/nodejs-java/manage-table/
keywords:
- menambahkan tabel
- membuat tabel
- mengakses tabel
- rasio aspek
- menyelaraskan teks
- pemformatan teks
- gaya tabel
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat & edit tabel dalam slide PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js. Temukan contoh kode sederhana untuk memperlancar alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint mengatur informasi ke dalam baris dan kolom, sehingga lebih mudah dibaca dan dibandingkan nilainya.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/), kelas [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam presentasi.

## **Membuat Tabel dari Awal**

Buat tabel dengan menentukan posisinya, lebar kolom, dan tinggi baris. Setelah menambahkannya ke slide, Anda dapat memformat batas sel, menggabungkan sel, dan menyisipkan teks.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Definisikan array lebar kolom dalam poin.
4. Definisikan array tinggi baris dalam poin.
5. Tambahkan objek [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) ke slide melalui metode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-).
6. Iterasi setiap [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) untuk menerapkan pemformatan pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel.
8. Akses sel yang digabung melalui metode [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) miliknya.
9. Tetapkan teks pada sel yang digabung.
10. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuat tabel dengan tiga kolom dan lima baris pada titik (100, 50). Ia menerapkan batas merah dengan lebar 5 poin, menggabungkan dua sel pertama pada baris pertama, dan menyimpan hasilnya sebagai `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, indeks sel dimulai dari nol dan menggunakan urutan (kolom, baris). Sel pertama memiliki indeks (0, 0).

Misalnya, sel‑sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor sebagai berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Contoh ini membuat tabel 4 × 4 yang digambarkan di atas, dengan lebar kolom dan tinggi baris masing‑masing 70 poin serta batas sel merah berukuran 5 poin. Koordinat menggambarkan indeks sel; contoh ini membiarkan sel kosong dan menyimpan tabel sebagai `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengakses Tabel yang Ada**

Tabel disimpan dalam koleksi shape slide. Iterasi shape untuk menemukan tabel, kemudian gunakan kelas [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) untuk membaca atau memperbarui sel‑nya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide yang berisi tabel berdasarkan indeksnya.
3. Iterasi objek [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) dan berhenti ketika menemukan tabel. Jika slide berisi beberapa tabel, gunakan [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) untuk mengidentifikasi tabel yang dibutuhkan.
4. Perbarui teks di sel target.
5. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah membuka `UpdateExistingTable.pptx` dan menemukan tabel pertama pada slide pertama. Ia menetapkan sel pada kolom 0, baris 1 menjadi `New` dan menyimpan hasilnya sebagai `table1_out.pptx`. Input harus berisi setidaknya satu slide, dan tabel pertama pada slide tersebut harus memiliki setidaknya satu kolom dan dua baris.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Untuk mengubah ukuran baris dalam tabel yang ada dan memahami mengapa tinggi sebenarnya dapat melebihi minimum yang diminta, lihat [Kontrol Tinggi Baris](/slides/id/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Temukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks umum menerima sebuah [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) dari tabel, gunakan metode [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) untuk mengambil [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) pemiliknya. Untuk text frame sel‑tabel, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) mengembalikan pemilik dan [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) mengembalikan `null`, meskipun tabel itu sendiri adalah sebuah shape.

Koordinat sel tersedia melalui properti hanya‑baca [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) dan [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) juga menyediakan navigasi hanya‑baca: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan `null` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel‑tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Cari dan Ganti Teks](/slides/id/nodejs-java/search-and-replace-text/).

## **Menyelaraskan Teks dalam Tabel**

Anda dapat mengontrol penambatan vertikal dan arah teks sel‑tabel individual. Contoh pada bagian ini menempatkan teks di tengah sel pertama dan memutarnya sebesar 270 derajat.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan objek [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) ke slide.
4. Akses objek [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) dari tabel.
5. Akses [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) pertama dan tetapkan teks serta warnanya.
6. Tetapkan penambatan vertikal sel dan arah teks menggunakan [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) dan [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Simpan presentasi yang telah dimodifikasi.

Contoh ini membuat tabel 4 × 4 dengan lebar kolom 120 poin dan tinggi baris 100 poin. Ia memformat teks di sel (0, 0), menambahkan nilai ke sel‑sel lain pada baris pertama, dan menyimpan hasilnya sebagai `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menetapkan Pemformatan Teks pada Tingkat Tabel**

Gunakan [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) untuk menerapkan pemformatan teks ke semua sel dalam sebuah tabel. Overload‑nya menerima pemformatan portion, paragraph, dan text frame, sehingga Anda dapat mengatur properti tersebut tanpa iterasi sel individual.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses objek [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) dari slide.
4. Tetapkan ukuran font menggunakan [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) untuk teks.
5. Tetapkan perataan paragraph dan margin kanan menggunakan [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) dan [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Tetapkan arah teks menggunakan [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah membuka `table.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia menetapkan ukuran font menjadi 25 poin, meratakan paragraph ke kanan dengan margin kanan 20 poin, dan membuat teks vertikal. Presentasi yang telah diformat disimpan sebagai `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mendapatkan Properti Gaya Tabel**

Gunakan [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) untuk membaca gaya preset tabel dan [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) untuk menentukannya. Contoh ini menerapkan [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) ke satu tabel, mencetak nilai preset, dan menetapkan preset yang sama ke tabel kedua. Kedua tabel disimpan dalam `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengunci Rasio Aspek Tabel**

Rasio aspek sebuah tabel adalah perbandingan antara lebar dan tingginya. Gunakan [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) untuk mengunci rasio ini pada tabel.

Contoh di bawah membuka `pres.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mencetak status kunci saat ini, mengaktifkan kunci rasio aspek, mencetak status yang diperbarui (`true`), dan menyimpan hasilnya sebagai `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan‑ke‑kiri (RTL) untuk seluruh tabel dan teks di dalam selnya?**

Ya. Tabel menyediakan metode [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-), dan paragraph memiliki [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Menggunakan keduanya memastikan urutan RTL yang tepat dan rendering yang benar di dalam sel.

**Bagaimana saya dapat mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) untuk menonaktifkan pemindahan, perubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah penyisipan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat menetapkan [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).