---
title: Dapatkan Batas Paragraf dari Presentasi di Java
linktitle: Batas Paragraf
type: docs
weight: 43
url: /id/java/paragraph-bounds/
keywords:
- batas paragraf
- koordinat paragraf
- ukuran paragraf
- bingkai teks
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf di Aspose.Slides untuk Java guna mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf di Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dari sebuah [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/) dengan menggunakan [IParagraph.getRect](https://reference.aspose.com/slides/id/java/com.aspose.slides/IParagraph#getRect--), cara mendapatkan koordinat paragraf di dalam bingkai teks sel tabel, serta menyoroti detail penting seperti satuan pengukuran, pengaruh pembungkusan teks terhadap batas, konversi pixel, dan nilai format paragraf yang efektif.

## **Dapatkan Koordinat Persegi Panjang Paragraf**

Gunakan [IParagraph.getRect](https://reference.aspose.com/slides/id/java/com.aspose.slides/IParagraph#getRect--) untuk mendapatkan persegi panjang pembatas paragraf.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Dapatkan Ukuran Paragraf di Dalam Bingkai Teks Sel Tabel**

Untuk mendapatkan ukuran dan koordinat sebuah [IParagraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/iparagraph/) dalam bingkai teks sel tabel, gunakan [IParagraph.getRect](https://reference.aspose.com/slides/id/java/com.aspose.slides/IParagraph#getRect--). Persegi panjang yang dikembalikan bersifat relatif terhadap bingkai teks sel tabel, sehingga tambahkan posisi tabel dan offset sel ketika Anda memerlukan koordinat pada tingkat slide.

Contoh berikut mengambil batas paragraf di dalam sel tabel dan menggambar persegi panjang pada slide untuk memvisualisasikan batas tersebut:

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

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

Koordinat diukur dalam poin, di mana 1 inci sama dengan 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkusan kata memengaruhi batas paragraf?**

Ya. Jika [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) diaktifkan untuk [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/), teks akan dipotong agar sesuai dengan lebar area, yang akan mengubah batas aktual paragraf.

**Apakah koordinat paragraf dapat dipetakan secara andal ke pixel dalam gambar yang diekspor?**

Ya. Konversi poin ke pixel menggunakan rumus berikut: pixel = poin × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk rendering atau ekspor.

**Bagaimana cara mendapatkan parameter format paragraf “efektif”, dengan mempertimbangkan pewarisan gaya?**

Gunakan [effective paragraph formatting data structure](/slides/id/java/shape-effective-properties/); struktur ini mengembalikan nilai akhir yang telah digabungkan untuk indentasi, spasi, pembungkusan, RTL, dan lainnya.