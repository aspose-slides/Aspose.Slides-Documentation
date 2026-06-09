---
title: Java'da Sunum Erişilebilirliğini Yönet
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/java/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'ın PPT, PPTX ve ODP dosyalarında sunum erişilebilirliği kontrollerini otomatikleştirmeye nasıl yardımcı olduğunu keşfedin—ekran okuyucu deneyimini iyileştirin ve uyumluluğu artırın."
---
## **Giriş**

Sunum erişilebilirliği, ekran okuyucular, braille ekranlar veya yalnızca klavye ile gezinme gibi yardımcı teknolojileri kullanan kişilerin slaytlarınızı gören ve fare kullanan izleyiciler kadar etkili bir şekilde anlayıp gezinebilmelerini sağlar. İyi uygulama, net bir okuma sırası, bilgilendirici görseller için anlamlı alternatif metin, yeterli renk kontrastı, okunabilir tipografi, açıklayıcı bağlantı metni ve anlamı yalnızca renk ya da konumla iletmekten kaçınmaya odaklanır. Erişilebilirlik baştan planlandığında, sonuç daha temiz bir yapı, daha tutarlı görseller ve her izleyiciye ek çözümler olmadan ulaşan içeriktir.

## **Mark as Decorative**

Dekoratif işareti, yalnızca süs amaçlı görselleri işaretleyerek ekran okuyucuların bunları atlamasını sağlar, gürültüyü azaltır ve anlamlı içeriğe odaklanmayı sürdürür. Bunu arka planlara, süslere ve boşluk dolduruculara uygulayın—asla bilgi taşıyan grafiklere, simgelere veya görsellere uygulamayın. Aspose.Slides bu işareti tespit ve doğrulama için sunar, otomatik erişilebilirlik kontrolleri ve temizlik yapılmasını sağlar.

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