---
title: "Mengelola Kotak Teks dalam Presentasi Menggunakan JavaScript"
linktitle: "Kelola Kotak Teks"
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
- menambahkan hyperlink
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides untuk Node.js memudahkan pembuatan, penyuntingan, dan penyalinan kotak teks dalam file PowerPoint dan OpenDocument, meningkatkan otomasi presentasi Anda."
---
## **Pendahuluan**

Teks pada slide biasanya berada dalam kotak teks atau bentuk. Oleh karena itu, untuk menambahkan teks ke slide, Anda harus menambahkan kotak teks terlebih dahulu dan kemudian menaruh teks di dalam kotak teks tersebut. Aspose.Slides for Node.js via Java menyediakan kelas [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) yang memungkinkan Anda menambahkan bentuk yang berisi teks.

{{% alert title="Info" color="info" %}}
Aspose.Slides juga menyediakan kelas [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape) yang memungkinkan Anda menambahkan bentuk ke slide. Namun, tidak semua bentuk yang ditambahkan melalui kelas `Shape` dapat memuat teks. Tetapi bentuk yang ditambahkan melalui kelas [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) dapat berisi teks.
{{% /alert %}}

{{% alert title="Catatan" color="warning" %}} 
Oleh karena itu, ketika berurusan dengan sebuah bentuk yang ingin Anda tambahkan teks, Anda sebaiknya memeriksa dan memastikan bahwa bentuk tersebut di‑cast melalui kelas `AutoShape`. Hanya setelah itu Anda dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrame), yang merupakan properti di bawah `AutoShape`. Lihat bagian [Update Text](https://docs.aspose.com/slides/id/nodejs-java/manage-textbox/#update-text) pada halaman ini.
{{% /alert %}}

## **Membuat Kotak Teks pada Slide**

Untuk membuat kotak teks pada slide, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi ke slide pertama pada presentasi yang baru dibuat. 
3. Tambahkan objek [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) dengan `ShapeType` yang disetel ke `Rectangle` pada posisi yang ditentukan di slide dan dapatkan referensi ke objek `AutoShape` yang baru ditambahkan.
4. Tambahkan properti `TextFrame` ke objek `AutoShape` yang akan berisi teks. Pada contoh di bawah, kami menambahkan teks berikut: *Aspose TextBox*
5. Akhirnya, tulis file PPTX melalui objek `Presentation`. 

Kode JavaScript—implementasi dari langkah‑langkah di atas—menunjukkan cara menambahkan teks ke slide:

```javascript
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
    // Membuat objek Portion untuk paragraph
    var portion = para.getPortions().get_Item(0);
    // Mengatur Teks
    portion.setText("Aspose TextBox");
    // Menyimpan presentasi ke disk
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Memeriksa Bentuk Kotak Teks**

Aspose.Slides menyediakan metode [isTextBox](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/#isTextBox) dari kelas [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) yang memungkinkan Anda memeriksa bentuk dan mengidentifikasi kotak teks.

![Kotak teks dan bentuk](istextbox.png)

Kode JavaScript ini menunjukkan cara memeriksa apakah sebuah bentuk dibuat sebagai kotak teks:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Perhatikan bahwa jika Anda hanya menambahkan sebuah autoshape menggunakan metode `addAutoShape` dari kelas [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/), metode `isTextBox` pada autoshape akan mengembalikan `false`. Namun, setelah Anda menambahkan teks ke autoshape menggunakan metode `addTextFrame` atau metode `setText`, properti `isTextBox` akan mengembalikan `true`.

```javascript
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

## **Menambahkan Kolom dalam Kotak Teks**

Aspose.Slides menyediakan metode [setColumnCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) dan [setColumnSpacing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat) yang memungkinkan Anda menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dalam kotak teks dan mengatur jarak antar kolom dalam poin.

Kode JavaScript berikut mendemonstrasikan operasi yang dijelaskan:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama dalam presentasi
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan AutoShape dengan tipe disetel sebagai Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Menambahkan TextFrame ke Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
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

## **Menambahkan Kolom dalam Text Frame**

Aspose.Slides for Node.js via Java menyediakan metode [setColumnCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrameFormat) yang memungkinkan Anda menambahkan kolom dalam text frame. Melalui properti ini, Anda dapat menentukan jumlah kolom yang diinginkan dalam sebuah text frame.

Kode JavaScript ini menunjukkan cara menambahkan kolom di dalam text frame:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

## **Memperbarui Teks**

Aspose.Slides memungkinkan Anda mengubah atau memperbarui teks yang ada di dalam kotak teks atau semua teks dalam sebuah presentasi. 

Kode JavaScript ini mendemonstrasikan operasi di mana semua teks dalam sebuah presentasi diperbarui atau diubah:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Memeriksa apakah shape mendukung text frame (IAutoShape).
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
    // Menyimpan presentasi yang dimodifikasi
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menambahkan Kotak Teks dengan Tautan Hiperteks** 

Anda dapat menyisipkan tautan di dalam kotak teks. Ketika kotak teks diklik, pengguna akan diarahkan ke tautan tersebut. 

Untuk menambahkan kotak teks yang berisi tautan, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas `Presentation`. 
2. Dapatkan referensi ke slide pertama pada presentasi yang baru dibuat. 
3. Tambahkan objek `AutoShape` dengan `ShapeType` disetel ke `Rectangle` pada posisi yang ditentukan di slide dan dapatkan referensi ke objek `AutoShape` yang baru ditambahkan.
4. Tambahkan `TextFrame` ke objek `AutoShape` yang berisi *Aspose TextBox* sebagai teks default. 
5. Buat instance dari kelas `HyperlinkManager`. 
6. Tetapkan objek `HyperlinkManager` ke properti [HyperlinkClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) yang terkait dengan bagian `TextFrame` yang Anda inginkan.
7. Akhirnya, tulis file PPTX melalui objek `Presentation`. 

Kode JavaScript—implementasi dari langkah‑langkah di atas—menunjukkan cara menambahkan kotak teks dengan tautan hiperteks ke slide:

```javascript
// Membuat instance kelas Presentation yang mewakili sebuah PPTX
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
    // Menambahkan beberapa teks ke frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Menetapkan Hyperlink untuk teks portion
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Menyimpan Presentasi PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan master slide?**

Sebuah [placeholder](/slides/id/nodejs-java/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) dan dapat ditimpa pada [layout](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/), sedangkan kotak teks biasa adalah objek independen pada slide tertentu dan tidak berubah ketika Anda beralih layout.

**Bagaimana cara melakukan penggantian teks secara massal di seluruh presentasi tanpa menyentuh teks di dalam diagram, tabel, dan SmartArt?**

Batasi iterasi Anda hanya pada auto‑shape yang memiliki text frame dan kecualikan objek tertanam ([chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/), [table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartart/)) dengan menelusuri koleksi mereka secara terpisah atau melewati tipe objek tersebut.