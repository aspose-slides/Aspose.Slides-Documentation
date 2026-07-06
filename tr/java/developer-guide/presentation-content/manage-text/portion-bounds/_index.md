---
title: Java'da Sunumlardan Metin Bölümünün Sınırlarını Alın
linktitle: Bölüm Sınırları
type: docs
weight: 47
url: /tr/java/portion-bounds/
keywords:
- metin bölüm sınırları
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint sunumlarında metin bölümü sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Metin bölümü, bir paragraftaki belirli bir metin parçasını temsil eder ve bu parçayı çevreleyen içerikten bağımsız olarak işlem yapmanıza olanak tanır. Aspose.Slides'te, bir metin parçasının sınırlarını almak, yalnızca bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek istediğinizde bölümler kullanılabilir.

Bu makale, bir bölümün sınırlayıcı dikdörtgenini [IPortion.getRect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPortion#getRect--) kullanarak nasıl alacağınızı gösterir. Ayrıca, bir bölümün başlangıç koordinatlarını [IPortion.getCoordinates](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPortion#getCoordinates--) kullanarak nasıl alacağınızı gösterir. Ek olarak, tek bir metin parçasına hiperlink ekleme, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı üzerinden nasıl çözüldüğünü anlama ve belirtilen bir yazı tipinin mevcut olmaması durumlarını ele alma gibi yaygın bölümle ilgili senaryoları vurgular.

## **Bir Metin Bölümünün Sınırlarını Alma**

Metin bölümünün sınırlayıcı dikdörtgenini almak için [IPortion.getRect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPortion#getRect--) kullanın:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Bir Metin Bölümünün Koordinatlarını Alma**

Metin bölümünün başlangıç koordinatlarını almak için [IPortion.getCoordinates](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPortion#getCoordinates--) kullanın:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Tek bir paragraf içinde metnin yalnızca bir kısmına hiperlink uygulayabilir miyim?**

Evet, tek bir bölüme [bir hiperlink atayabilirsiniz](/slides/tr/java/manage-hyperlinks/); yalnızca o parça tıklanabilir olacak, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir bölüm neyi geçersiz kılar ve neyi paragraftan ya da metin çerçevesinden alır?**

Bölüm düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [IPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/) üzerinde ayarlanmamışsa, Aspose.Slides onu [IParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/) üzerinden alır. Orada da ayarlanmamışsa, Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) veya [tema](https://reference.aspose.com/slides/tr/java/com.aspose.slides/theme/) stilini kullanır.

**Bir bölüm için belirtilen yazı tipi hedef makine veya sunucuda eksikse ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/java/font-selection-sequence/) uygulanır. Metin yeniden akışa girebilir: ölçümler, heceleme ve genişlik değişebilir, bu da kesin konumlandırma için önemlidir.

**Bir bölümün özel metin doldurma saydamlığını veya degradeyi paragrafın geri kalanından bağımsız olarak ayarlayabilir miyim?**

Evet, [IPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/) düzeyinde metin rengi, doldurma ve saydamlık komşu parçalardan farklı olabilir.