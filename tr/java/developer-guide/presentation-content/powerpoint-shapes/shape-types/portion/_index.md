---
title: Java ile Sunumlarda Metin Bölümlerini Yönetme
linktitle: Metin Bölümü
type: docs
weight: 70
url: /tr/java/portion/
keywords:
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint sunumlarında metin bölümlerini yönetmeyi öğrenin, performansı ve özelleştirmeyi artırın."
---
## **Genel Bakış**

Bir metin bölümü, bir paragraftaki belirli bir metin kırıntısını temsil eder ve bu kırıntıyla çevredeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides içinde, bir metin kırıntısının konumunu almak, yalnızca bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek gerektiğinde bölümler kullanılabilir. Bu makale, `getCoordinates()` yöntemi kullanılarak bir bölümün başlangıç koordinatlarının nasıl alınacağını gösterir. Ayrıca bir tek metin kırıntısına köprü ekleme, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı üzerinden nasıl çözümlendiğini anlama ve belirtilen bir yazı tipinin bulunmadığı durumları ele alma gibi yaygın bölüm‑ile ilgili senaryoları vurgular. Ek olarak, aynı paragraftaki ayrı ayrı bölümler için metin doldurma, renk ve saydamlığın farklı ayarlanabileceği belirtilir.

## **Bir Metin Bölümünün Koordinatlarını Almak**
[**getCoordinates()**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPortion#getCoordinates--) yöntemi, bölümün başlangıç koordinatlarını almayı sağlayan [IPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iportion/) ve [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) sınıflarına eklenmiştir.

```java
// PPTX'yi temsil eden Presentation sınıfını örnekleyin
    // Sunumun bağlamını yeniden şekillendirme
Presentation pres = new Presentation();
try {
    // Reshaping the context of presentation
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

**Tek bir paragraftaki metnin yalnızca bir kısmına köprü uygulayabilir miyim?**

Evet, bir bölüme [köprü atayabilirsiniz](/slides/tr/java/manage-hyperlinks/); yalnızca o kırıntı tıklanabilir olur, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir Portion neyi geçersiz kılar ve neyi Paragraph/TextFrame'den alır?**

Bölüm‑seviyesindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) üzerinde ayarlanmamışsa, motor bunu [Paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraph/) üzerinden alır; orada da ayarlanmamışsa, [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) ya da [tema](https://reference.aspose.com/slides/tr/java/com.aspose.slides/theme/) stilinden alır.

**Bir Portion için belirtilen yazı tipi hedef makine/sunucuda bulunamazsa ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/java/font-selection-sequence/) uygulanır. Metin yeniden akışa girebilir: ölçüler, heceleme ve genişlik değişebilir, bu da doğru konumlandırma için önemlidir.

**Bir Portion'a özgü metin doldurma saydamlığını veya geçişi paragrafın geri kalanından bağımsız olarak ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) seviyesindeki metin rengi, doldurma ve saydamlık komşu kırıntılardan farklı olabilir.