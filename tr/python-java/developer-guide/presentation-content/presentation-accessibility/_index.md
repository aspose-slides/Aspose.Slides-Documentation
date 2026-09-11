---
title: Python üzerinden Java ile Sunum Erişilebilirliğini Yönet
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/python-java/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'in PPT, PPTX ve ODP dosyalarında sunum erişilebilirlik kontrollerini otomatikleştirmeye nasıl yardımcı olduğunu keşfedin—ekran okuyucu deneyimini geliştirin ve uyumluluğu artırın."
---
## **Introduction**

Sunum erişilebilirliği, ekran okuyucular, braille ekranları veya yalnızca klavye navigasyonu gibi yardımcı teknolojileri kullanan kişilerin slaytlarınızı görme engelli, fare kullanan izleyiciler kadar etkili bir şekilde anlayıp gezinebilmelerini sağlar. İyi uygulama, net bir okuma sırasına, bilgilendirici görseller için anlamlı alternatif metne, yeterli renk kontrastına, okunabilir tipografiye, açıklayıcı bağlantı metnine ve anlamı yalnızca renk ya da konumla iletmeyi önlemeye odaklanır. Erişilebilirlik baştan planlandığında, sonuç daha temiz bir yapı, daha tutarlı görseller ve her izleyiciye ek çözümler gerektirmeden ulaşan içerik olur.

## **Mark as Decorative**

Dekoratif olarak işaretle, yalnızca süs amaçlı görselleri işaretleyerek ekran okuyucuların bunları atlamasını sağlar, gürültüyü azaltır ve anlamlı içeriğe odaklanmayı sürdürür. Bu işaretlemeyi arka planlar, süslemeler ve doldurucular için kullanın—hiçbir zaman bilgi ileten grafikler, simgeler veya resimler için kullanmayın. Aspose.Slides, bu işareti tespit ve doğrulama için sunar, otomatik erişilebilirlik kontrolleri ve temizlik yapılmasını mümkün kılar.

![Mark as Decorative](mark_as_decorative.png)

Aşağıdaki kod örneği, bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl belirleyeceğinizi gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```