---
title: Dapatkan Batas Paragraf dari Presentasi di Java
linktitle: Paragraf
type: docs
weight: 60
url: /id/java/paragraph/
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
- Java
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf dan bagian teks di Aspose.Slides untuk Java untuk mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf serta bagian teks di Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dalam `TextFrame` dengan menggunakan `getRect()`, cara mendapatkan koordinat paragraf dan bagian di dalam text frame sel tabel, serta menyoroti detail penting seperti satuan pengukuran, efek pembungkus teks pada batas, konversi piksel, dan nilai format paragraf yang efektif.

## **Dapatkan Koordinat Paragraf dan Bagian dalam TextFrame**
Dengan Aspose.Slides untuk Java, pengembang kini dapat memperoleh koordinat persegi panjang untuk Paragraph di dalam koleksi paragraf TextFrame. Ini juga memungkinkan Anda mendapatkan [koordinat bagian](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPortion#getCoordinates--) di dalam koleksi bagian dari sebuah paragraf. Pada topik ini, kami akan mendemonstrasikan dengan contoh cara mendapatkan koordinat persegi panjang untuk paragraf beserta posisi bagian di dalam paragraf.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Dapatkan Koordinat Persegi Panjang Sebuah Paragraf**
Dengan metode [**getRect()**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IParagraph#getRect--) pengembang dapat memperoleh persegi panjang batas paragraf.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dapatkan Ukuran Paragraf dan Bagian di Dalam TextFrame Sel Tabel**

Untuk mendapatkan ukuran dan koordinat [Portion](https://reference.aspose.com/slides/id/java/com.aspose.slides/Portion) atau [Paragraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/Paragraph) di dalam text frame sel tabel, Anda dapat menggunakan metode [IPortion.getRect](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPortion#getRect--) dan [IParagraph.getRect](https://reference.aspose.com/slides/id/java/com.aspose.slides/IParagraph#getRect--).

This sample code demonstrates the described operation:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Dalam satuan apa koordinat yang dikembalikan untuk paragraf dan bagian teks diukur?**

Dalam poin, di mana 1 inci = 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [pembungkus](https://reference.aspose.com/slides/id/java/com.aspose.slides/textframeformat/#setWrapText-byte-) diaktifkan dalam [TextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/textframe/), teks akan dipisahkan agar sesuai dengan lebar area, yang mengubah batas sebenarnya dari paragraf.

**Apakah koordinat paragraf dapat dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversikan poin ke piksel dengan: pixels = points × (DPI / 72). Hasilnya bergantung pada DPI yang dipilih untuk rendering/ekspor.

**Bagaimana saya mendapatkan parameter format paragraf "efektif", dengan mempertimbangkan pewarisan gaya?**

Gunakan [effective paragraph formatting data structure](/slides/id/java/shape-effective-properties/); itu mengembalikan nilai akhir yang dikonsolidasikan untuk indentasi, spasi, pembungkus, RTL, dan lainnya.