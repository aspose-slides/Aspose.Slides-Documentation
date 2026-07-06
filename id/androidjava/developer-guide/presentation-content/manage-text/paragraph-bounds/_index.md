---
title: Dapatkan Batas Paragraf dari Presentasi di Android
linktitle: Batas Paragraf
type: docs
weight: 43
url: /id/androidjava/paragraph-bounds/
keywords:
- batas paragraf
- koordinat paragraf
- ukuran paragraf
- bingkai teks
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf di Aspose.Slides untuk Android via Java untuk mengoptimalkan penempatan teks pada presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf di Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dari sebuah [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dengan menggunakan [IParagraph.getRect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraph#getRect--), cara mendapatkan koordinat paragraf di dalam bingkai teks sel tabel, serta menyoroti detail penting seperti satuan pengukuran, pengaruh pembungkus teks pada batas, konversi piksel, dan nilai pemformatan paragraf yang efektif.

## **Dapatkan Koordinat Persegi Panjang Sebuah Paragraf**

Gunakan [IParagraph.getRect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraph#getRect--) untuk mendapatkan persegi panjang pembatas sebuah paragraf.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Dapatkan Ukuran Paragraf Di Dalam TextFrame Sel Tabel**

Untuk mendapatkan ukuran dan koordinat sebuah [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) dalam bingkai teks sel tabel, gunakan [IParagraph.getRect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraph#getRect--). Persegi panjang yang dikembalikan relatif terhadap bingkai teks sel tabel, jadi tambahkan posisi tabel dan offset sel ketika Anda memerlukan koordinat pada tingkat slide.

Contoh berikut mendapatkan batas paragraf di dalam sel tabel dan menggambar persegi panjang pada slide untuk memvisualisasikan batas tersebut:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Dalam satuan apa koordinat paragraf diukur?**

Mereka diukur dalam poin, di mana 1 inci sama dengan 72 poin. Hal ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) diaktifkan untuk [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/), teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas sebenarnya dari paragraf.

**Apakah koordinat paragraf dapat dipetakan ke piksel secara andal dalam gambar yang diekspor?**

Ya. Konversikan poin ke piksel menggunakan rumus berikut: piksel = poin × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk rendering atau ekspor.

**Bagaimana cara mendapatkan parameter pemformatan paragraf "efektif", dengan mempertimbangkan pewarisan gaya?**

Gunakan [effective paragraph formatting data structure](/slides/id/androidjava/shape-effective-properties/); ia mengembalikan nilai akhir yang dikonsolidasikan untuk indentasi, jarak, pembungkus, RTL, dan lainnya.