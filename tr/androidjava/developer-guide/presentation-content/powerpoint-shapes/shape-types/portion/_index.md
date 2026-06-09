---
title: Android'de Sunumlarda Metin Bölümlerini Yönetme
linktitle: Metin Bölümü
type: docs
weight: 70
url: /tr/androidjava/portion/
keywords:
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarında metin bölümlerini yönetmeyi öğrenin, performansı ve özelleştirmeyi artırın."
---
## **Giriş**

Bir metin bölümü, bir paragrafta belirli bir metin parçacığını temsil eder ve bu parçacıkla çevredeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides'te, bölümler bir metin parçacığının konumunu almak, yalnızca bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek istediğinizde kullanılabilir.

## **Bir Metin Bölümünün Koordinatlarını Al**
[**getCoordinates()**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPortion#getCoordinates--) yöntemi, [IPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportion/) ve [Portion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) sınıflarına eklenmiştir ve bölümün başlangıç koordinatlarını almanıza olanak tanır.

```java
// PPTX'i temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // Sunumun bağlamını yeniden şekillendir
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Tek bir paragraf içinde sadece metnin bir kısmına köprü uygulayabilir miyim?**

Evet, bir bölüme [köprü atayabilirsiniz](/slides/tr/androidjava/manage-hyperlinks/); sadece o parçacık tıklanabilir olur, bütün paragraf değil.

**Stil kalıtımı nasıl çalışır: bir Portion neyi geçersiz kılar ve neyi Paragraph/TextFrame'den alır?**

Portion seviyesindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) üzerinde ayarlanmamışsa, motor bunu [Paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/) üzerinden alır; eğer orada da ayarlanmamışsa, [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) veya [tema](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/theme/) stilinden alınır.

**Bir Portion için belirtilen yazı tipi hedef makinede/ sunucuda eksik olursa ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/androidjava/font-selection-sequence/) uygulanır. Metin yeniden akışa girebilir: metrikler, heceleme ve genişlik değişebilir, bu da hassas konumlandırma için önemlidir.

**Bir Portion'a özgü metin doldurma şeffaflığı veya degradeyi paragraftaki diğer bölümlerden bağımsız olarak ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) seviyesindeki metin rengi, dolgu ve şeffaflık komşu parçacıklardan farklı olabilir.