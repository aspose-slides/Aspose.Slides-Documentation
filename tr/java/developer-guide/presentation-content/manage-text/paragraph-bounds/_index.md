---
title: Java'da Sunumlardan Paragraf Sınırlarını Al
linktitle: Paragraf Sınırları
type: docs
weight: 43
url: /tr/java/paragraph-bounds/
keywords:
- paragraf sınırları
- paragraf koordinatı
- paragraf boyutu
- metin çerçevesi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "PowerPoint sunumlarında metin konumlandırmasını optimize etmek için Aspose.Slides for Java’da paragraf sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te paragrafların sınırlarını, boyutunu ve koordinatlarını nasıl alacağınızı açıklar. [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) üzerinden bir paragraf dikdörtgeni almayı [IParagraph.getRect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IParagraph#getRect--) kullanarak, tablo hücresi metin çerçevesi içindeki paragraf koordinatlarını elde etmeyi ve ölçüm birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli detayları vurgular.

## **Paragrafın Dikdörtgen Koordinatlarını Almak**

Bir paragrafın sınır dikdörtgenini almak için [IParagraph.getRect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IParagraph#getRect--) kullanın.

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

## **Tablo Hücresi Metin Çerçevesi İçindeki Bir Paragrafın Boyutunu Almak**

Bir tablo hücresi metin çerçevesindeki bir [IParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/) boyutunu ve koordinatlarını almak için [IParagraph.getRect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IParagraph#getRect--) kullanın. Döndürülen dikdörtgen tablo hücresi metin çerçevesine göre görelidir, bu nedenle slayt düzeyinde koordinatlara ihtiyaç duyduğunuzda tablo konumunu ve hücre ofsetini ekleyin.

Aşağıdaki örnek, bir tablo hücresi içindeki paragraf sınırlarını alır ve bu sınırları görselleştirmek için slayta dikdörtgenler çizer:

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

## **SSS**

**Paragraf koordinatları hangi birimlerde ölçülür?**

Puan (point) cinsinden ölçülür; 1 inç 72 puana eşittir. Bu, slayttaki tüm koordinat ve boyutlara uygulanır.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)[ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) için etkinleştirildiyse, metin alan genişliğine sığacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları, dışa aktarılan görüntüde güvenilir şekilde piksellere dönüştürülebilir mi?**

Evet. Puanları piksellere bu formülle dönüştürebilirsiniz: pikseller = puan x (DPI / 72). Sonuç, renderleme veya dışa aktarma için seçilen DPI'ye bağlıdır.

**Stil mirasını dikkate alarak "etkili" paragraf biçimlendirme parametrelerini nasıl alabilirim?**

[effective paragraph formatting data structure](/slides/tr/java/shape-effective-properties/) kullanın; girintiler, boşluklar, kaydırma, sağdan sola (RTL) ve diğerleri için nihai birleştirilmiş değerleri döndürür.