---
title: Mengelola Kotak Teks dalam Presentasi Menggunakan JavaScript
linktitle: Mengelola Kotak Teks
type: docs
weight: 20
url: /id/nodejs-java/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- menambahkan teks
- memperbarui teks
- membuat kotak teks
- memeriksa kotak teks
- menambahkan kolom teks
- menambahkan tautan
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides untuk Node.js memudahkan pembuatan, penyuntingan, dan penggandaan kotak teks dalam file PowerPoint dan OpenDocument, meningkatkan otomatisasi presentasi Anda."
---
## **Pendahuluan**

Teks pada slide biasanya berada dalam kotak teks atau bentuk. Oleh karena itu, untuk menambahkan teks ke slide, Anda harus menambahkan kotak teks dan kemudian menaruh beberapa teks di dalam kotak teks tersebut. Aspose.Slides untuk Node.js via Java menyediakan kelas [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) yang memungkinkan Anda menambahkan bentuk yang berisi teks.

{{% alert title="Info" color="info" %}}

Aspose.Slides juga menyediakan kelas [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape) yang memungkinkan Anda menambahkan bentuk ke slide. Namun, tidak semua bentuk yang ditambahkan melalui kelas `Shape` dapat menampung teks. Namun, bentuk yang ditambahkan melalui kelas [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) dapat berisi teks.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Oleh karena itu, saat menangani sebuah bentuk yang ingin Anda tambahkan teks, Anda mungkin perlu memeriksa dan memastikan bahwa ia di‑cast melalui kelas `AutoShape`. Hanya dengan begitu Anda dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrame), yang merupakan properti di bawah `AutoShape`. Lihat bagian [Update Text](https://docs.aspose.com/slides/id/nodejs-java/manage-textbox/#update-text) pada halaman ini.

{{% /alert %}}

## **Buat Kotak Teks di Slide**

Untuk membuat kotak teks pada slide, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi untuk slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) dengan [ShapeType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) yang diatur ke `Rectangle` pada posisi tertentu di slide dan dapatkan referensi untuk objek `AutoShape` yang baru ditambahkan.
4. Tambahkan properti `TextFrame` ke objek `AutoShape` yang akan berisi teks. Pada contoh di bawah, kami menambahkan teks ini: *Aspose TextBox*
5. Terakhir, tulis file PPTX melalui objek `Presentation`. 

Kode JavaScript ini—implementasi dari langkah‑langkah di atas—menunjukkan cara menambahkan teks ke slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat instance Presentation
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama dalam presentasi
    var sld = pres.getSlides().get_Item(0);
    // Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Menambahkan TextFrame ke Rectangle
    ashp.addTextFrame(" ");
    // Mengakses text frame
    var txtFrame = ashp.getTextFrame();
    // Membuat objek Paragraph untuk text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Membuat objek Portion untuk paragraf
    var portion = para.getPortions().get_Item(0);
    // Menetapkan Teks
    portion.setText("Aspose TextBox");
    // Menyimpan presentasi ke disk
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Periksa Bentuk Kotak Teks**

Aspose.Slides menyediakan metode [isTextBox](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/#isTextBox) dari kelas [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) yang memungkinkan Anda memeriksa bentuk dan mengidentifikasi kotak teks.

![Text box and shape](istextbox.png)

Kode JavaScript ini menunjukkan cara memeriksa apakah sebuah bentuk dibuat sebagai kotak teks:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Perhatikan bahwa jika Anda hanya menambahkan sebuah autoshape menggunakan metode `addAutoShape` dari kelas [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/), metode `isTextBox` pada autoshape akan mengembalikan `false`. Namun, setelah Anda menambahkan teks ke autoshape menggunakan metode `addTextFrame` atau metode `setText`, properti `isTextBox` akan mengembalikan `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() mengembalikan false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() mengembalikan true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() mengembalikan false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() mengembalikan true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() mengembalikan false
shape3.addTextFrame("");
// shape3.isTextBox() mengembalikan false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() mengembalikan false
shape4.getTextFrame().setText("");
// shape4.isTextBox() mengembalikan false
```

## **Temukan Bentuk yang Memiliki Text Frame**

Dalam kode pengolahan teks umum, Anda mungkin menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) tanpa mengetahui objek presentasi mana yang memilikinya. Gunakan metode [TextFrame.getParentShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentShape--) untuk menavigasi kembali ke [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) pemiliknya.

Untuk sebuah text frame yang milik sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) atau bentuk lain yang berisi teks, [TextFrame.getParentShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentShape--) mengembalikan pemiliknya dan [TextFrame.getParentCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentCell--) mengembalikan `null`. Kedua metode menyediakan navigasi read‑only, sehingga memanggilnya tidak mengubah kepemilikan. Selalu periksa nilai yang dikembalikan untuk `null` sebelum mengakses bentuk.

Untuk contoh lengkap yang mengidentifikasi pemilik bentuk dan sel tabel, termasuk bentuk yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/nodejs-java/search-and-replace-text/).

## **Tambahkan Kolom di Kotak Teks**

Aspose.Slides menyediakan metode [setColumnCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) dan [setColumnSpacing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat) yang memungkinkan Anda menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dalam kotak teks dan mengatur jarak antar kolom dalam satuan poin.

Kode ini dalam JavaScript menunjukkan operasi yang dijelaskan: 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama dalam presentasi
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Menambahkan TextFrame ke Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Mendapatkan format teks dari TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Menentukan jumlah kolom dalam TextFrame
    format.setColumnCount(3);
    // Menentukan jarak antar kolom
    format.setColumnSpacing(10);
    // Menyimpan presentasi
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tambahkan Kolom di Text Frame**

Aspose.Slides untuk Node.js via Java menyediakan metode [setColumnCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat) yang memungkinkan Anda menambahkan kolom di dalam text frame. Melalui properti ini, Anda dapat menentukan jumlah kolom yang diinginkan dalam sebuah text frame.

Kode JavaScript ini menunjukkan cara menambahkan kolom di dalam text frame:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Jarak kolom tidak pernah disetel, sehingga dilaporkan sebagai NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perbarui Teks**

Aspose.Slides memungkinkan Anda mengubah atau memperbarui teks yang terdapat dalam kotak teks atau semua teks yang terdapat dalam sebuah presentasi. 

Kode JavaScript ini menunjukkan operasi di mana semua teks dalam sebuah presentasi diperbarui atau diubah:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Memeriksa apakah bentuk mendukung text frame (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Iterasi melalui paragraf dalam text frame
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Iterasi melalui setiap portion dalam paragraf
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Mengubah teks
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Mengubah format
                    }
                }
            }
        }
    }
    // Menyimpan presentasi yang diubah
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tambahkan Kotak Teks dengan Tautan** 

Anda dapat menyisipkan tautan di dalam kotak teks. Ketika kotak teks diklik, pengguna akan diarahkan untuk membuka tautan tersebut. 

Untuk menambahkan kotak teks yang berisi tautan, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas `Presentation`. 
2. Dapatkan referensi untuk slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek `AutoShape` dengan `ShapeType` yang diatur ke `Rectangle` pada posisi tertentu di slide dan dapatkan referensi objek `AutoShape` yang baru ditambahkan.
4. Tambahkan `TextFrame` ke objek `AutoShape` dan atur teks pada bagian pertama. Pada contoh di bawah, kami menggunakan teks ini: *Aspose.Slides*
5. Dapatkan `HyperlinkManager` dari bagian tersebut melalui `PortionFormat`‑nya.
6. Panggil `setExternalHyperlinkClick` pada `HyperlinkManager` untuk menautkan tautan ke bagian tersebut.
7. Terakhir, tulis file PPTX melalui objek `Presentation`. 

Kode JavaScript ini—implementasi dari langkah‑langkah di atas—menunjukkan cara menambahkan kotak teks dengan tautan ke slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat instance kelas Presentation yang mewakili PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama dalam presentasi
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan objek AutoShape dengan tipe diatur sebagai Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Mengubah shape menjadi AutoShape
    var pptxAutoShape = shape;
    // Mengakses properti ITextFrame yang terkait dengan AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Menambahkan teks ke frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Mengatur Hyperlink untuk teks portion
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Menyimpan presentasi PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan master slide?**

Sebuah [placeholder](/slides/id/nodejs-java/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) dan dapat di‑override pada [layout](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/), sedangkan kotak teks biasa adalah objek independen pada slide tertentu dan tidak berubah ketika Anda beralih layout.

**Bagaimana cara melakukan penggantian teks massal di seluruh presentasi tanpa memengaruhi teks di dalam bagan, tabel, dan SmartArt?**

Batasi iterasi Anda pada auto‑shape yang memiliki text frame dan kecualikan objek terbenam seperti [chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/), [table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/table/), dan [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartart/) dengan menelusuri koleksi masing‑masing secara terpisah atau melewatkan tipe objek tersebut.