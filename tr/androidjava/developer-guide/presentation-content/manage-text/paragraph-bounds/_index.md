---
title: Android'de Sunumlardan Paragraf Sınırlarını Almak
linktitle: Paragraf Sınırları
type: docs
weight: 43
url: /tr/androidjava/paragraph-bounds/
keywords:
- paragraf sınırları
- paragraf koordinatı
- paragraf boyutu
- metin çerçevesi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de Java aracılığıyla paragraf sınırlarını nasıl alacağınızı öğrenerek PowerPoint sunumlarında metin konumlandırmayı optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların sınırlarını, boyutunu ve koordinatlarını nasıl alacağınızı açıklar. [IParagraph.getRect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraph#getRect--) kullanarak bir [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) içinden paragraf dikdörtgeni nasıl alınır, tablo hücresi metin çerçevesi içinde paragraf koordinatları nasıl elde edilir ve ölçüm birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli ayrıntılar vurgulanır.

## **Bir Paragrafın Dikdörtgen Koordinatlarını Almak**

Paragrafın sınırlayıcı dikdörtgenini almak için [IParagraph.getRect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraph#getRect--) kullanın.

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

## **Tablo Hücresi TextFrame'i İçindeki Bir Paragrafın Boyutunu Almak**

Bir tablo hücresi metin çerçevesindeki bir [IParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/) boyutunu ve koordinatlarını almak için [IParagraph.getRect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraph#getRect--) kullanın. Döndürülen dikdörtgen tablo hücresi metin çerçevesine göre görelative olduğundan, slayt düzeyinde koordinatlara ihtiyacınız olduğunda tablo konumunu ve hücre kaymasını ekleyin.

Aşağıdaki örnek, bir tablo hücresi içinde paragraf sınırlarını alır ve bu sınırları görselleştirmek için slayta dikdörtgenler çizer:

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

## **SSS**

**Paragraf koordinatları hangi birimlerde ölçülür?**

Koordinatlar nokta (point) biriminde ölçülür; 1 inç 72 noktaya eşittir. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma, bir paragrafın sınırlarını etkiler mi?**

Evet. [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) için [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) etkinleştirildiğinde, metin alan genişliğine sığdırmak için bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları, dışa aktarılan görüntüde piksel olarak güvenilir bir şekilde eşlenebilir mi?**

Evet. Noktaları piksele şu formülle dönüştürün: piksel = nokta × (DPI / 72). Sonuç, render veya dışa aktarma için seçilen DPI'ye bağlıdır.

**Stil kalıtımını dikkate alarak “etkili” paragraf biçimlendirme parametrelerini nasıl alabilirim?**

[etkili paragraf biçimlendirme veri yapısı](/slides/tr/androidjava/shape-effective-properties/) kullanın; bu, girintiler, boşluklar, kaydırma, RTL ve daha fazlası için nihai birleştirilmiş değerleri döndürür.