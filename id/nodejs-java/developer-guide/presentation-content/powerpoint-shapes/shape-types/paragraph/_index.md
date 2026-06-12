---
title: Dapatkan Batas Paragraf dari Presentasi di JavaScript
linktitle: Paragraf
type: docs
weight: 60
url: /id/nodejs-java/paragraph/
keywords:
- batas paragraf
- batas bagian teks
- koordinat paragraf
- koordinat bagian
- ukuran paragraf
- ukuran bagian teks
- bingkai teks
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf dan bagian teks di JavaScript dengan Aspose.Slides untuk Node.js guna mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf serta bagian teks di Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dalam `TextFrame` dengan menggunakan `getRect()`, cara mendapatkan koordinat paragraf dan bagian di dalam kerangka teks sel tabel, serta menyoroti detail penting seperti satuan pengukuran, pengaruh pembungkus teks pada batas, konversi piksel, dan nilai format paragraf yang efektif.

## **Dapatkan Koordinat Paragraf dan Bagian di TextFrame**
Using Aspose.Slides for Node.js via Java, developer sekarang dapat mendapatkan koordinat persegi panjang untuk Paragraph di dalam koleksi paragraf dari TextFrame. Ini juga memungkinkan Anda mendapatkan [koordinat bagian](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Portion#getCoordinates--) di dalam koleksi bagian dari sebuah paragraf. Pada topik ini, kami akan menunjukkan dengan contoh cara mendapatkan koordinat persegi panjang untuk paragraf beserta posisi bagian di dalam paragraf.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **Dapatkan Koordinat Persegi Panjang Paragraf**
Dengan menggunakan metode [**getRect()**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Paragraph#getRect--) , developer dapat memperoleh persegi panjang batas paragraf.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dapatkan ukuran paragraf dan bagian di dalam kerangka teks sel tabel**

Untuk mendapatkan ukuran dan koordinat [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Portion) atau [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Paragraph) dalam kerangka teks sel tabel, Anda dapat menggunakan metode [Portion.getRect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Portion#getRect--) dan [Paragraph.getRect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Paragraph#getRect--) .

Kode contoh ini menunjukkan operasi yang dijelaskan:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Dalam satuan apa koordinat yang dikembalikan untuk paragraf dan bagian teks diukur?**

Dalam poin, di mana 1 inci = 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [pembungkus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/setwraptext/) diaktifkan dalam [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/), teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas aktual paragraf.

**Apakah koordinat paragraf dapat dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversikan poin ke piksel menggunakan: pixels = points × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk rendering/ekspor.

**Bagaimana cara mendapatkan parameter format paragraf "efektif", dengan mempertimbangkan pewarisan gaya?**

Gunakan [struktur data format paragraf efektif](/slides/id/nodejs-java/shape-effective-properties/); itu mengembalikan nilai akhir yang dikonsolidasikan untuk indentasi, spasi, pembungkus, RTL, dan lainnya.