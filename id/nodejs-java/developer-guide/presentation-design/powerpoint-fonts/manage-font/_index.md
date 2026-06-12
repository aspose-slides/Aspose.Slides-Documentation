---
title: Kelola Font di Presentasi Menggunakan JavaScript
linktitle: Kelola Font
type: docs
weight: 10
url: /id/nodejs-java/manage-fonts/
keywords:
- kelola font
- properti font
- paragraf
- pemformatan teks
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kontrol font dengan Aspose.Slides untuk Node.js via Java: sematkan, ganti, dan muat font khusus agar presentasi PPT, PPTX, dan ODP tetap jelas dan konsisten."
---
## **Pendahuluan**

Presentasi biasanya berisi teks dan gambar. Teks dapat diformat dalam berbagai cara, baik untuk menyoroti bagian dan kata tertentu maupun untuk menyesuaikan dengan gaya perusahaan. Pemformatan teks membantu pengguna mengubah tampilan konten presentasi. Artikel ini menunjukkan cara menggunakan Aspose.Slides for Node.js via Java untuk mengonfigurasi properti font pada paragraf teks di slide.

## **Kelola Properti Terkait Font**

Untuk mengelola properti font sebuah paragraf menggunakan Aspose.Slides for Node.js via Java:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Akses bentuk [Placeholder](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/placeholder/) pada slide dan cast ke [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).
1. Dapatkan [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) dari [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) yang disediakan oleh [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).
1. Ratakan paragraf.
1. Akses [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) teks pada sebuah [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/).
1. Tentukan font menggunakan [FontData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontdata/) dan setel **Font** pada [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) secara bersamaan.
   1. Setel font menjadi tebal.
   1. Setel font menjadi miring.
1. Setel warna font menggunakan [FillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/) yang disediakan oleh objek [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/).
1. Simpan presentasi yang telah dimodifikasi ke file PPTX.

Implementasi langkah‑langkah di atas diberikan di bawah. Contoh ini mengambil presentasi standar dan memformat font pada salah satu slide. Cuplikan layar berikut menunjukkan file input dan bagaimana potongan kode mengubahnya. Kode mengubah font, warna, dan gaya font.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Gambar: Teks dalam file input**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Gambar: Teks yang sama dengan pemformatan yang diperbarui**|

```javascript
// Membuat objek Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Mengakses slide menggunakan posisi slide-nya
    var slide = pres.getSlides().get_Item(0);
    // Mengakses placeholder pertama dan kedua dalam slide dan mengubah tipenya menjadi AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Mengakses Paragraph pertama
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Menjustifikasi paragraf
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Mengakses portion pertama
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Mendefinisikan font baru
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Menetapkan font baru ke portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Menetapkan font menjadi Bold
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Menetapkan font menjadi Italic
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Menetapkan warna font
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Menyimpan PPTX ke disk
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Properti Font Teks**
{{% alert color="primary" %}} 

Seperti yang disebutkan dalam **Mengelola Properti terkait Font**, sebuah [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) digunakan untuk menampung teks dengan gaya pemformatan serupa dalam sebuah paragraf. Artikel ini menunjukkan cara menggunakan Aspose.Slides for Node.js via Java untuk membuat kotak teks dengan beberapa teks dan kemudian menentukan font tertentu, serta berbagai properti lain dari kategori keluarga font.

{{% /alert %}} 

Untuk membuat kotak teks dan mengatur properti font pada teks di dalamnya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Dapatkan referensi sebuah slide dengan menggunakan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) dengan tipe **Rectangle** ke slide.
1. Hapus gaya isi yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).
1. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) dari [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).
1. Tambahkan beberapa teks ke [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/).
1. Akses objek [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) yang terkait dengan [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/).
1. Tentukan font yang akan digunakan untuk [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/).
1. Setel properti font lainnya seperti tebal, miring, garis bawah, warna, dan tinggi menggunakan properti yang relevan yang tersedia pada objek [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/).
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Implementasi langkah‑langkah di atas diberikan di bawah.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Gambar: Teks dengan beberapa properti font yang diatur oleh Aspose.Slides for Node.js via Java**|

```javascript
// Membuat objek Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan AutoShape dengan tipe Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Hapus semua gaya isi yang terkait dengan AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Akses TextFrame yang terkait dengan AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Akses Portion yang terkait dengan TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Atur Font untuk Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Atur properti Bold pada Font
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Atur properti Italic pada Font
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Atur properti Underline pada Font
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Atur Tinggi Font
    port.getPortionFormat().setFontHeight(25);
    // Atur warna Font
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Simpan presentasi ke disk
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```