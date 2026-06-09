---
title: Android'de Sunumlardan Paragraf Sınırlarını Alın
linktitle: Paragraf
type: docs
weight: 60
url: /tr/androidjava/paragraph/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da paragraf ve metin bölümü sınırlarını nasıl alacağınızı öğrenin ve PowerPoint sunumlarındaki metin konumlandırmasını optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların ve metin bölümlerinin sınırlamalarını, boyutlarını ve koordinatlarını nasıl alacağınızı açıklar. `getRect()` kullanarak bir `TextFrame` içinde bir paragrafın dikdörtgenini nasıl alacağınızı, bir tablo hücresi metin çerçevesi içindeki paragraf ve bölüm koordinatlarını nasıl alacağınızı gösterir ve ölçüm birimleri, metin kaydırmanın sınırlamalar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli ayrıntıları vurgular.

## **Metin Çerçevesinde Paragraf ve Bölüm Koordinatlarını Almak**
Aspose.Slides for Android via Java kullanarak, geliştiriciler artık TextFrame'in paragraf koleksiyonundaki bir Paragrafın dikdörtgen koordinatlarını alabilirler. Ayrıca bir paragraftaki bölüm koleksiyonu içinde [bölümün koordinatlarını](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPortion#getCoordinates--) almanıza olanak tanır. Bu konuda, bir paragrafın dikdörtgen koordinatlarını ve paragraf içindeki bölümün konumunu nasıl alacağınızı bir örnekle göstereceğiz.

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
Geliştiriciler, [**getRect()**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraph#getRect--) metodunu kullanarak paragraf sınırları dikdörtgenini alabilirler.

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

## **Tablo Hücresi Metin Çerçevesi İçindeki Paragraf ve Bölümün Boyutunu Almak**
Bir tablo hücresi metin çerçevesinde [Portion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Portion) veya [Paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Paragraph) boyutunu ve koordinatlarını elde etmek için [IPortion.getRect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPortion#getRect--) ve [IParagraph.getRect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IParagraph#getRect--) metodlarını kullanabilirsiniz.

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

**Paragraf ve metin bölümlerinin koordinatları hangi birimlerde döndürülür?**  
Puan (point) cinsindendir; 1 inç = 72 puan. Bu, slayttaki tüm koordinatlar ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**  
Evet. Eğer [wrapping](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)[TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) içinde etkinleştirilmişse, metin alan genişliğine sığacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları, dışa aktarılan görüntüde piksellere güvenilir bir şekilde eşlenebilir mi?**  
Evet. Puanları piksele şu formülle dönüştürün: pixels = points × (DPI / 72). Sonuç, renderleme/dışa aktarma için seçilen DPI'ye bağlıdır.

**Stil mirasını dikkate alarak “etkili” paragraf biçimlendirme parametrelerini nasıl alabilirim?**  
[effective paragraph formatting data structure](/slides/tr/androidjava/shape-effective-properties/) öğesini kullanın; girintiler, boşluklar, kaydırma, RTL ve daha fazlası için nihai birleştirilmiş değerleri döndürür.