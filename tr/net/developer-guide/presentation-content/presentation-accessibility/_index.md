---
title: .NET'te Sunum Erişilebilirliğini Yönetin
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/net/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PPT, PPTX ve ODP dosyalarında sunum erişilebilirliği kontrollerini otomatikleştirin—ekran okuyucu deneyimini iyileştirin ve uyumluluğu artırın."
---
## **Giriş**

Sunum erişilebilirliği, ekran okuyucular, braille ekranlar veya sadece klavye ile gezinme gibi yardımcı teknolojileri kullanan kişilerin slaytlarınızı görme yetisi olan, fare kullanan izleyiciler kadar etkili bir şekilde anlamasını ve gezinmesini sağlar. İyi uygulamalar, net okuma sırası, bilgilendirici görseller için anlamlı alternatif metin, yeterli renk kontrastı, okunabilir tipografi, açıklayıcı bağlantı metni ve anlamı yalnızca renk ya da konumla iletmeyi önlemeye odaklanır. Erişilebilirlik baştan planlandığında, daha temiz bir yapı, tutarlı görseller ve her izleyiciye ekstra çaba gerektirmeden ulaşan içerik elde edilir.

## **Dekoratif Olarak İşaretle**

Dekoratif işaretle, sadece süs amaçlı görselleri işaretleyerek ekran okuyucuların bu öğeleri atlamasını sağlar, gürültüyü azaltır ve anlamlı içeriğe odaklanmayı sürdürür. Arka planlar, süslemeler ve boşluklar için uygulayın—bilgi taşıyan grafikler, simgeler veya resimler için asla kullanmayın. Aspose.Slides, bu işareti tespit ve doğrulama için sunar, otomatik erişilebilirlik kontrolleri ve temizlik imkanı verir.

![Dekoratif Olarak İşaretle](mark_as_decorative.png)

Aşağıdaki kod örneği, bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl belirleyeceğinizi gösterir.

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```