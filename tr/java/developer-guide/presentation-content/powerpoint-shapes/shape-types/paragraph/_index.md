---
title: Java'da Sunumlardan Paragraf Sınırlarını Alın
linktitle: Paragraf
type: docs
weight: 60
url: /tr/java/paragraph/
keywords:
- paragraf sınırları
- metin bölümü sınırları
- paragraf koordinatı
- bölüm koordinatı
- paragraf boyutu
- metin bölümü boyutu
- metin çerçevesi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da paragraf ve metin bölümü sınırlarını nasıl alacağınızı öğrenerek PowerPoint sunumlarındaki metin konumlandırmasını optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta paragrafların ve metin bölümlerinin sınırlarını, boyutlarını ve koordinatlarını nasıl alacağını açıklar. `getRect()` kullanarak bir `TextFrame` içinde bir paragrafın dikdörtgenini nasıl alacağınızı, bir tablo hücresi metin çerçevesindeki paragraf ve bölüm koordinatlarını nasıl elde edebileceğinizi gösterir ve ölçüm birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli detayları vurgular.

## **TextFrame içinde Paragraf ve Bölüm Koordinatlarını Almak**
Aspose.Slides for Java kullanarak, geliştiriciler artık TextFrame'in paragraf koleksiyonu içinde bir Paragrafın dikdörtgen koordinatlarını alabilirler. Ayrıca bir paragraftaki bölüm koleksiyonunun içindeki [bölümün koordinatlarını](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPortion#getCoordinates--) almanıza olanak tanır. Bu konuda, bir paragrafın dikdörtgen koordinatlarını ve paragraf içindeki bölümün konumunu nasıl alacağınızı bir örnekle göstereceğiz.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Bir Paragrafın Dikdörtgen Koordinatlarını Almak**
[**getRect()**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IParagraph#getRect--) yöntemini kullanarak geliştiriciler paragraf sınırları dikdörtgenini alabilirler.

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

## **Bir Tablo Hücresi TextFrame içinde Paragraf ve Bölüm Boyutunu Almak**
Bir tablo hücresi text çerçevesinde [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Portion) veya [Paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Paragraph) boyut ve koordinatlarını almak için, [IPortion.getRect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPortion#getRect--) ve [IParagraph.getRect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IParagraph#getRect--) yöntemlerini kullanabilirsiniz.

Bu örnek kod, açıklanan işlemi gösterir:

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

## **SSS**

**Paragraf ve metin bölümleri için koordinatlar hangi birimlerde döndürülür?**

Puan (point) biriminde döner; 1 inç = 72 puandır. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. Eğer [wrapping](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframeformat/#setWrapText-byte-) [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) içinde etkinleştirilmişse, metin alan genişliğine uyacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları dışa aktarılan görüntüde piksellere güvenilir bir şekilde eşlenebilir mi?**

Evet. Puanları pikselere şu şekilde dönüştürün: pixels = points × (DPI / 72). Sonuç, render/dışa aktarma için seçilen DPI'ye bağlıdır.

**Stil mirasını dikkate alarak "etkili" paragraf biçimlendirme parametrelerini nasıl alabilirim?**

[effective paragraph formatting data structure](/slides/tr/java/shape-effective-properties/) kullanın; bu, girintiler, boşluklar, kaydırma, RTL ve daha fazlası için son birleştirilmiş değerleri döndürür.