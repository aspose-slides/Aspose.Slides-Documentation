---
title: Android'de Sunumlardan Metin Bölüm Sınırlarını Alın
linktitle: Bölüm Sınırları
type: docs
weight: 47
url: /tr/androidjava/portion-bounds/
keywords:
- metin bölüm sınırları
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Java aracılığıyla Android için Aspose.Slides kullanarak PowerPoint sunumlarında metin bölüm sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bir metin bölümü, bir paragraf içindeki belirli bir metin parçasını temsil eder ve bu parçayı çevreleyen içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides'te, bölümler metin parçasının sınırlamalarını almanız, bir paragrafın yalnızca bir kısmına biçimlendirme uygulamanız veya metin davranışını daha ayrıntılı bir seviyede kontrol etmeniz gerektiğinde kullanılabilir.

Bu makale, bir bölümün sınırlayan dikdörtgenini [IPortion.getRect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPortion#getRect--) kullanarak nasıl alacağınızı gösterir. Ayrıca, bir bölümün başlangıç koordinatlarını [IPortion.getCoordinates](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPortion#getCoordinates--) kullanarak nasıl alacağınızı gösterir. Ek olarak, tek bir metin parçasına hiperlink uygulama, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı üzerinden nasıl çözüldüğünü anlama ve belirtilen bir yazı tipinin bulunmadığı durumları ele alma gibi yaygın bölümle ilgili senaryoları vurgular.

## **Bir Metin Bölümünün Sınırlarını Almak**

Bir metin bölümünün sınırlayan dikdörtgenini almak için [IPortion.getRect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPortion#getRect--) kullanın:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Bir Metin Bölümünün Koordinatlarını Almak**

Bir metin bölümünün başlangıç koordinatlarını almak için [IPortion.getCoordinates](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPortion#getCoordinates--) kullanın:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir paragraf içindeki metnin yalnızca bir kısmına hiperlink uygulayabilir miyim?**

Evet, tek bir bölüme [hyperlink atayabilirsiniz](/slides/tr/androidjava/manage-hyperlinks/); yalnızca o parça tıklanabilir, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir bölüm neyi geçersiz kılar ve neyi paragraftan veya metin çerçevesinden alır?**

Bölüm düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [IPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/) üzerinde ayarlanmamışsa, Aspose.Slides bunu [IParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/) üzerinden alır. Orada da ayarlanmamışsa, Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) veya [tema](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/theme/) stilini kullanır.

**Bir bölüm için belirtilen yazı tipi hedef makine veya sunucuda bulunmazsa ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/androidjava/font-selection-sequence/) uygulanır. Metin yeniden akabilir: ölçümler, tireleme ve genişlik değişebilir, bu da kesin konumlandırma için önemlidir.

**Paragrafın geri kalanından bağımsız olarak bölüme özgü metin doldurma şeffaflığı veya degrade ayarlayabilir miyim?**

Evet, [IPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/) düzeyindeki metin rengi, dolgu ve şeffaflık komşu parçalardan farklı olabilir.