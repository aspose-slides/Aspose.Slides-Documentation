---
title: Python üzerinden Java ile Yedek Yazı Tipleriyle Sunumları Render Et
linktitle: Sunumları Render Et
type: docs
weight: 30
url: /tr/python-java/render-presentation-with-fallback-font/
keywords:
- yedek yazı tipi
- PowerPoint render et
- sunumu render et
- slaytı render et
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java içinde yedek yazı tipleriyle sunumları render edin – PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım Python kod örnekleriyle."
---
## **Genel Bakış**

Aspose.Slides, yedek yazı tipi kurallarını kullanarak sunumları render etmenizi sağlar. Bu makale, bir yedek yazı tipi kural koleksiyonu oluşturmayı, kuralları yedek yazı tiplerini kaldırarak ya da ekleyerek değiştirmeyi ve koleksiyonu [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) yöntemiyle atamayı gösterir.

Yedek yazı tipi kural koleksiyonu sunumun [FontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/) nesnesine atandığında, kurallar sunumu kaydetme, render etme ve dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük görseli oluştururken ve JPEG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Yedek Yazı Tipi Kurallarını Kullanarak Slaytı Görüntüleme**

Aşağıdaki örnek aşağıdaki adımları içerir:

1. [Yedek yazı tipi kural koleksiyonu oluştur](/slides/tr/python-java/create-fallback-fonts-collection/).
1. [Kaldır](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrule/#remove) bir kuraldan yedek yazı tipini ve [yedek yazı tipleri ekle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) başka bir kurala.
1. [setFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) yöntemini, [getFontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getFontsManager) tarafından döndürülen font yöneticisi üzerinde kullanarak kural koleksiyonunu atayın.
1. [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemini kullanarak sunumu aynı formatta ya da başka bir formatta kaydedin. Yedek yazı tipi kural koleksiyonu [FontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/) nesnesine atandıktan sonra, bu kurallar sunum üzerinde yapılan işlemler sırasında uygulanır: kaydetme, render etme, dönüştürme vb.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Yeni bir kural koleksiyonu oluştur.
fallback_rules = FontFallBackRulesCollection()

# Birden fazla kural oluştur.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Yedek yazı tipi "Tahoma"yı kurallardan kaldırmayı deneyin.
    fallback_rule.remove("Tahoma")

    # Belirtilen aralık için kuralları güncelle.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Mevcut bir kuralı kaldır, renderleme için en az bir kural bırak.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Hazırlanan kural koleksiyonunu ata.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Yapılandırılmış kural koleksiyonunu kullanarak bir küçük görsel render et.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Görüntüyü JPEG formatında diske kaydet.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Python üzerinden Java ile PPT ve PPTX'i JPG'ye dönüştürme hakkında daha fazla bilgi edinin.
{{% /alert %}}