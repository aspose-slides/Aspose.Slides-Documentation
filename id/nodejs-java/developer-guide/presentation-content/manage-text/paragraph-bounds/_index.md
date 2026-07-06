---
title: Dapatkan Batas Paragraf dari Presentasi dalam JavaScript
linktitle: Batas Paragraf
type: docs
weight: 43
url: /id/nodejs-java/paragraph-bounds/
keywords:
- batas paragraf
- koordinat paragraf
- ukuran paragraf
- frame teks
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf di Aspose.Slides untuk Node.js melalui Java untuk mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memperoleh batas, ukuran, dan koordinat paragraf dalam Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dari sebuah [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) dengan menggunakan [Paragraph.getRect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/getrect/), cara mendapatkan koordinat paragraf di dalam text frame sel tabel, serta menyoroti detail penting seperti satuan pengukuran, pengaruh pembungkus teks terhadap batas, konversi piksel, dan nilai format paragraf yang “effective”.

## **Dapatkan Koordinat Persegi Panjang dari Sebuah Paragraf**

Gunakan [Paragraph.getRect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/getrect/) untuk memperoleh persegi panjang pembatas sebuah paragraf.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Dapatkan Ukuran Paragraf di Dalam TextFrame Sel Tabel**

Untuk memperoleh ukuran dan koordinat sebuah [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) dalam text frame sel tabel, gunakan [Paragraph.getRect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/getrect/). Persegi panjang yang dikembalikan relatif terhadap text frame sel tabel, jadi tambahkan posisi tabel dan offset sel ketika Anda memerlukan koordinat tingkat slide.

Contoh berikut memperoleh batas paragraf di dalam sel tabel dan menggambar persegi panjang pada slide untuk memvisualisasikan batas tersebut:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tanya Jawab**

**Dalam satuan apa koordinat paragraf diukur?**

Koordinat diukur dalam poin, di mana 1 inci sama dengan 72 poin. Hal ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/setwraptext/) diaktifkan untuk [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/), teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas aktual paragraf.

**Dapatkah koordinat paragraf dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversi poin ke piksel menggunakan rumus berikut: pixels = points × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk proses rendering atau ekspor.

**Bagaimana cara mendapatkan parameter format paragraf "effective", dengan mempertimbangkan pewarisan gaya?**

Gunakan [struktur data format paragraf effective](/slides/id/nodejs-java/shape-effective-properties/); ia mengembalikan nilai akhir yang terkonsolidasi untuk indentasi, spasi, pembungkus, RTL, dan lainnya.