---
title: Android'de Sunum Erişilebilirliğini Yönet
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/androidjava/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'in Java aracılığıyla PPT, PPTX ve ODP dosyalarındaki sunum erişilebilirliği kontrollerini otomatikleştirmeye nasıl yardımcı olduğunu keşfedin—ekran okuyucu deneyimini iyileştirin ve uyumluluğu artırın."
---
## **Genel Bakış**

Sunum erişilebilirliği, ekran okuyucular, braille ekranları veya yalnızca klavye ile gezinme gibi yardımcı teknolojileri kullanan kişilerin slaytlarınızı görme engelli, fare kullanan izleyiciler kadar etkili bir şekilde anlayıp gezinebilmelerini sağlar. İyi uygulama, net bir okuma sırasına, bilgilendirici görseller için anlamlı alternatif metne, yeterli renk kontrastına, okunabilir tipografiye, açıklayıcı bağlantı metnine ve anlamı sadece renk ya da konumla iletmeyi önlemeye odaklanır. Erişilebilirlik en başından planlandığında, sonuç daha temiz bir yapı, daha tutarlı görseller ve her izleyiciye ek çözümler gerektirmeden ulaşan içerik olur.

## **Dekoratif Olarak İşaretle**

Dekoratif olarak işaretle, sadece süs amaçlı görselleri işaretleyerek ekran okuyucuların bunları atlamasını sağlar, gürültüyü azaltır ve anlamlı içeriğe odaklanmayı sürdürür. Bunu arka planlara, süslemelere ve boşluk dolduruculara uygulayın—hiçbir zaman bilgi veren grafiklere, simgelere veya görüntülere uygulamayın. Aspose.Slides bu bayrağı tespit ve doğrulama için sunar, otomatik erişilebilirlik kontrolleri ve temizlik yapılmasına olanak tanır.

![Dekoratif Olarak İşaretle](mark_as_decorative.png)

Aşağıdaki kod örneği, bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl belirleyeceğinizi gösterir.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```