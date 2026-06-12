---
title: Kelola Hyperlink Presentasi dalam JavaScript
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/nodejs-java/manage-hyperlinks/
keywords:
- menambahkan URL
- menambahkan hyperlink
- membuat hyperlink
- memformat hyperlink
- menghapus hyperlink
- memperbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola hyperlink dengan mudah dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js—tingkatkan interaktivitas dan alur kerja dalam hitungan menit."
---
## **Pendahuluan**

Hyperlink adalah referensi ke sebuah objek, data, atau tempat dalam sesuatu. Berikut adalah hyperlink umum dalam Presentasi PowerPoint:

* Tautan ke situs web di dalam teks, bentuk, atau media
* Tautan ke slide

Aspose.Slides for Node.js via Java memungkinkan Anda melakukan banyak tugas yang melibatkan hyperlink dalam presentasi.

{{% alert color="primary" %}} 
Anda mungkin ingin mencoba Aspose sederhana, [editor PowerPoint online gratis.](https://products.aspose.app/slides/id/editor)
{{% /alert %}} 

## **Menambahkan Hyperlink URL**

### **Menambahkan Hyperlink URL ke Teks**

Kode JavaScript ini menunjukkan cara menambahkan hyperlink situs web ke sebuah teks:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Menambahkan Hyperlink URL ke Bentuk atau Bingkai**

Contoh kode ini dalam JavaScript menunjukkan cara menambahkan hyperlink situs web ke sebuah bentuk:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Menambahkan Hyperlink URL ke Media**

Aspose.Slides memungkinkan Anda menambahkan hyperlink ke file gambar, audio, dan video.

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **gambar**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan gambar ke presentasi
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Membuat bingkai gambar pada slide 1 berdasarkan gambar yang telah ditambahkan sebelumnya
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **file audio**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **video**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
Anda mungkin ingin melihat *[Kelola OLE](/slides/id/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **Menggunakan Hyperlink untuk Membuat Daftar Isi**

Karena hyperlink memungkinkan Anda menambahkan referensi ke objek atau tempat, Anda dapat menggunakannya untuk membuat daftar isi.

Contoh kode ini menunjukkan cara membuat daftar isi dengan hyperlink:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Pemformatan Hyperlink**

### **Warna**

Dengan metode [setColorSource](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) dalam kelas [Hyperlink](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink), Anda dapat mengatur warna untuk hyperlink dan juga mendapatkan informasi warna dari hyperlink. Fitur ini pertama kali diperkenalkan di PowerPoint 2019, sehingga perubahan yang melibatkan properti ini tidak berlaku untuk versi PowerPoint yang lebih lama.

Contoh kode ini mendemonstrasikan operasi di mana hyperlink dengan warna berbeda ditambahkan ke slide yang sama:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghapus Hyperlink dalam Presentasi**

### **Menghapus Hyperlink dari Teks**

Kode JavaScript ini menunjukkan cara menghapus hyperlink dari teks dalam slide presentasi:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Memeriksa apakah shape mendukung text frame (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Melakukan iterasi paragraf dalam text frame
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Melakukan iterasi setiap portion dalam paragraf
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Mengubah teks
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Mengubah format
                    }
                }
            }
        }
    }
    // Menyimpan presentasi yang telah dimodifikasi
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Menghapus Hyperlink dari Bentuk atau Bingkai**

Kode JavaScript ini menunjukkan cara menghapus hyperlink dari bentuk dalam slide presentasi:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hyperlink yang Dapat Diubah**

Kelas [Hyperlink](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink) bersifat mutable. Dengan kelas ini, Anda dapat mengubah nilai properti berikut:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Potongan kode ini menunjukkan cara menambahkan hyperlink ke sebuah slide dan mengedit tooltip-nya nanti:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Properti yang Didukung dalam IHyperlinkQueries**

Anda dapat mengakses [HyperlinkQueries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries) dari sebuah presentasi, slide, atau teks yang memiliki hyperlink yang didefinisikan.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

Kelas [HyperlinkQueries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries) mendukung metode dan properti berikut:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Bagaimana saya dapat membuat navigasi internal bukan hanya ke slide, tetapi ke "section" atau slide pertama dari sebuah section?**

Section di PowerPoint adalah pengelompokan slide; navigasi secara teknis menargetkan slide tertentu. Untuk "menavigasi ke sebuah section", Anda biasanya menautkan ke slide pertamanya.

**Bisakah saya menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan layout mendukung hyperlink. Tautan tersebut muncul pada slide turunan dan dapat diklik selama presentasi.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Di [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/), ya—tautan biasanya dipertahankan. Saat mengekspor ke [images](/slides/id/nodejs-java/convert-powerpoint-to-png/) dan [video](/slides/id/nodejs-java/convert-powerpoint-to-video/), kemampuan diklik tidak akan terbawa karena sifat format tersebut (frame raster/video tidak mendukung hyperlink).