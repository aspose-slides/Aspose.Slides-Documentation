---
title: Python'da Sunum Erişilebilirliğini Yönetin
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/python-net/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python'ın PPT, PPTX ve ODP dosyalarında sunum erişilebilirliği kontrollerini otomatikleştirerek ekran okuyucu deneyimini geliştirdiğini ve uyumluluğu artırdığını keşfedin."
---
## **Giriş**

Sunum erişilebilirliği, ekran okuyucular, braille ekranlar veya yalnızca klavye ile gezinme gibi yardımcı teknolojileri kullanan kişilerin slaytlarınızı görsel engelli, fare kullanan izleyiciler kadar etkili bir şekilde anlamasını ve gezinmesini sağlar. İyi uygulama, net bir okuma sırası, bilgilendirici görseller için anlamlı alternatif metin, yeterli renk kontrastı, okunabilir tipografi, açıklayıcı bağlantı metni ve anlamı yalnızca renk veya konumla iletmekten kaçınmaya odaklanır. Erişilebilirlik baştan planlandığında, daha temiz bir yapı, daha tutarlı görseller ve her izleyiciye ek çözümler olmadan ulaşan içerik elde edilir.

## **Dekoratif Olarak İşaretle**

Dekoratif olarak işaretle, yalnızca süs amaçlı görselleri işaretleyerek ekran okuyucuların bu öğeleri atlamasını sağlar, gürültüyü azaltır ve anlamlı içeriğe odaklanmayı sürdürür. Arka planlar, süslemeler ve boşluk doldurucular için kullanın—bilgi veren grafikler, simgeler veya resimler için asla kullanmayın. Aspose.Slides, bu işareti algılama ve doğrulama için sunar, otomatik erişilebilirlik denetimlerini ve temizlemeyi mümkün kılar.

![Dekoratif Olarak İşaretle](mark_as_decorative.png)

Aşağıdaki kod örneği, bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl belirleyeceğinizi gösterir.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```