---
title: Dapatkan Properti Efektif Bentuk dari Presentasi dalam JavaScript
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/nodejs-java/shape-effective-properties/
keywords:
- properti bentuk
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isian
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: Pelajari cara menggunakan Aspose.Slides untuk Node.js via Java untuk membedakan pemformatan bentuk lokal, diwariskan, dan efektif dalam presentasi PowerPoint.
---
## **Pahami Properti Lokal, Warisan, dan Efektif**

Pemformatan PowerPoint dapat berasal dari beberapa tempat. Nilai yang disimpan langsung pada sebuah objek adalah **nilai lokal**. Jika nilai tersebut tidak diatur, PowerPoint mencari sumber pemformatan induk, seperti default paragraf, gaya teks, tata letak atau slide master, tema, atau default tingkat presentasi. Nilai-nilai tersebut adalah **nilai yang diwariskan**. Nilai yang tersisa setelah seluruh hierarki diselesaikan adalah **nilai efektif**—nilai yang digunakan untuk merender objek.

Sebagai contoh, sebuah bagian teks mungkin tidak mendefinisikan tinggi font‑nya sendiri. Nilai lokal [getFontHeight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/#getFontHeight)‑nya kemudian `NaN`, yang berarti "tidak diatur di sini." Bagian tersebut dapat mewarisi tinggi dari paragrafnya, gaya teks default presentasi, atau sumber lain yang relevan. Memanggil [getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/#getEffective) pada format bagian mengembalikan tinggi yang telah diselesaikan akhir.

Gunakan dua jenis data pemformatan untuk tujuan yang berbeda:

- Baca atau ubah objek format lokal, seperti [PortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/), ketika Anda perlu mengontrol di mana nilai didefinisikan.
- Baca [data efektif yang dikembalikan oleh PortionFormat.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/#getEffective) ketika Anda membutuhkan hasil akhir yang dirender. Data efektif bersifat read‑only.

Sebelum menjalankan contoh, [install Aspose.Slides for Node.js via Java](/slides/id/nodejs-java/installation/).

## **Bandingkan Nilai Lokal, Warisan, dan Efektif**

Contoh lengkap berikut membuat sebuah bentuk dan menerapkan tinggi font pada tingkat presentasi, paragraf, dan bagian. Setiap langkah mencetak nilai yang didefinisikan pada tingkat tersebut dan nilai efektif yang dihasilkan untuk bagian teks yang sama. Ini juga memperlihatkan mengapa data efektif harus dibaca kembali setelah perubahan pemformatan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Baca data efektif setelah perubahan sebelumnya.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Tentukan nilai yang diwariskan pada dua level berbeda.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Nilai lokal pada bagian mengesampingkan kedua nilai yang diwariskan.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Mengubah nilai yang diwariskan tidak mengesampingkan nilai lokal yang ada.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Hapus nilai lokal. Bagian kini kembali mewarisi dari paragraf.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Hapus nilai paragraf. Default presentasi kini menyediakan hasilnya.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Prioritas dalam contoh ini adalah pemformatan lokal bagian, kemudian pemformatan paragraf, kemudian default presentasi. Objek lain dapat memiliki rantai warisan yang berbeda, tetapi prinsipnya sama: nilai eksplisit yang lebih spesifik menang, dan [getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/#getEffective) mengembalikan hasil akhir.

## **Dapatkan Properti Teks Efektif**

Pemformatan teks dibagi ke beberapa objek:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#getEffective) menyelesaikan properti bingkai teks seperti margin, penempatan, autofit, dan arah teks vertikal.
- [TextStyle.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textstyle/#getEffective) menyelesaikan pemformatan paragraf untuk setiap tingkat gaya teks.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#getEffective) menyelesaikan properti paragraf seperti perataan, inden, dan bullet.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/#getEffective) menyelesaikan properti karakter seperti tinggi font, jenis huruf, warna, tebal, dan miring.

Untuk contoh berikut, `text-formatting.pptx` harus berisi setidaknya satu slide dan satu [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) dengan bingkai teks yang tidak kosong. AutoShape dapat muncul di posisi apapun dalam koleksi bentuk; kode mencari objek yang cocok dan memvalidasinya sebelum digunakan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti 3D Efektif**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getEffective) mengembalikan satu objek data efektif yang mengelompokkan semua pengaturan 3D yang telah diselesaikan. Metode [getCamera](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getBevelTop), dan [getBevelBottom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/#getBevelBottom) menampilkan data efektif yang bersesuaian. Membaca pengaturan terkait ini secara bersama‑sama memudahkan pemahaman tampilan 3D akhir sebuah bentuk.

Untuk contoh ini, `shape-3d.pptx` harus berisi setidaknya satu bentuk pada slide pertamanya. Terapkan kamera 3D, pencahayaan, atau pengaturan bevel pada bentuk tersebut jika Anda menginginkan output berisi nilai selain default.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Dapatkan Pemformatan Tabel Efektif**

Pemformatan tabel dapat berasal dari gaya tabel dan dari format yang diterapkan pada seluruh tabel, kolom, baris, atau sel individual. Untuk konflik di antara isian yang didefinisikan secara eksplisit, prioritasnya adalah sel, baris, kolom, dan kemudian seluruh tabel. Format efektif sebuah sel adalah format akhir yang digunakan untuk menggambar sel tersebut.

Untuk contoh ini, `table-formatting.pptx` harus berisi setidaknya satu tabel pada slide pertamanya. Tabel tersebut harus memiliki setidaknya satu baris dan satu kolom. Kode mencari sebuah [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/table/) alih‑alih mengasumsikan bahwa `getShapes().get_Item(0)` adalah sebuah tabel.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Jika Anda memerlukan warna daripada hanya jenis isian, pertama periksa [getFillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/#getFillType) yang efektif, lalu baca metode yang berlaku untuk tipe tersebut—misalnya, [getSolidFillColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) untuk isian padat.

## **Baca Ulang Data Efektif Setelah Perubahan**

Data efektif menggambarkan hierarki pemformatan pada saat diselesaikan. Panggil `getEffective` lagi setelah mengubah apa pun yang dapat berpartisipasi dalam hierarki tersebut, termasuk:

- pemformatan lokal objek;
- default paragraf atau bingkai teks;
- gaya tabel, tabel, kolom, baris, atau format sel;
- pemformatan tata letak atau slide master;
- data tema atau default tingkat presentasi;
- tata letak atau master yang ditetapkan pada slide.

Jangan menyimpan objek data efektif sebagai snapshot permanen. Aspose.Slides dapat menyimpan beberapa data efektif secara internal, dan panggilan `getEffective` berikutnya dapat memperbarui data tersebut. Jika Anda perlu membandingkan nilai sebelum dan sesudah perubahan, salin nilai skalar yang diperlukan—seperti tinggi font, warna, perataan, atau lebar bevel—ke dalam variabel Anda sendiri sebelum melakukan perubahan.

Untuk mengubah sebuah nilai, perbarui objek format lokal yang sesuai lalu panggil `getEffective` untuk memverifikasi hasilnya. Objek data efektif itu sendiri bersifat read‑only.

## **FAQ**

**Bagaimana saya dapat mengetahui level mana yang menyediakan nilai efektif?**

Data efektif berisi nilai akhir, bukan sumbernya. Periksa objek lokal yang berlaku mulai dari level paling spesifik ke luar. Untuk teks, ini dapat mencakup bagian, paragraf, bingkai teks, tata letak, master, tema, dan default presentasi. Nilai yang tidak terdefinisi seperti `NaN` atau `null` menunjukkan bahwa pencarian berlanjut ke level lain.

**Apa yang terjadi ketika tidak ada level yang mendefinisikan properti?**

Aspose.Slides menyelesaikan default PowerPoint atau perpustakaan yang sesuai. Nilai yang telah diselesaikan tersebut muncul dalam data efektif meskipun tidak ada objek lokal yang secara eksplisit mendefinisikannya.

**Mengapa nilai efektif kadang‑kadang sama dengan nilai lokal?**

Nilai lokal memenangkan perhitungan warisan. Hal ini diharapkan ketika properti secara eksplisit diatur pada objek dan tidak ada aturan yang lebih spesifik yang menimpanya.

**Kapan saya harus menggunakan data lokal daripada data efektif?**

Gunakan data lokal untuk memeriksa atau mengedit level pemformatan tertentu. Gunakan data efektif ketika Anda membutuhkan tampilan akhir setelah warisan, aturan tema, dan gaya yang berlaku telah diselesaikan. [contoh perbandingan lengkap](#compare-local-inherited-and-effective-values) memperlihatkan keduanya dalam alur kerja yang sama.