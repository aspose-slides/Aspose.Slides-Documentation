---
title: Python aracılığıyla Java ile Yedek Yazı Tipi Koleksiyonlarını Yapılandırma
linktitle: Yedek Yazı Tipi Koleksiyonu
type: docs
weight: 20
url: /tr/python-java/create-fallback-fonts-collection/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi koleksiyonu
- yazı tipini yapılandır
- yazı tipini kur
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides için Python üzerinden Java ile bir yedek yazı tipi koleksiyonu kurarak, PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net olmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için yedek yazı tipi kuralları koleksiyonunu yapılandırmanıza olanak tanır. Her yedek kural, [FontFallBackRule](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrule/) sınıfı ile temsil edilir ve bir [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrulescollection/) içine eklenebilir.

Koleksiyon oluşturulduktan sonra, sunumun [FontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/) sınıfının [setFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) yöntemiyle atayabilirsiniz. [FontsManager], sunum boyunca yazı tiplerini kontrol eder ve her bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğinin kendi [FontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/)ı vardır.

[FontsManager] yedek yazı tipi koleksiyonu ile başlatıldıktan sonra, belirtilen yedek yazı tipleri sunum işlenmesi sırasında uygulanır.

## **Yedek Kuralları Uygula**

[FontFallBackRule] sınıfından örnekler bir [FontFallBackRulesCollection] içinde düzenlenebilir. Koleksiyondan kuralları ekleyebilir veya kaldırabilirsiniz.

Bu koleksiyon daha sonra, sunum boyunca yazı tiplerini kontrol eden [FontsManager] sınıfının [setFontFallBackRulesCollection] yöntemiyle atanabilir.

Her bir [Presentation] öğesinin, kendi [FontsManager] örneğini döndüren bir [getFontsManager] yöntemi vardır.

Aşağıdaki örnek, bir yedek yazı tipi kural koleksiyonu oluşturmayı ve bunu bir sunumun [FontsManager]ına atamayı göstermektedir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

[FontsManager] yedek yazı tipi koleksiyonu ile başlatıldıktan sonra, yedek yazı tipleri sunum işlenmesi sırasında uygulanır.

{{% alert color="info" title="Note" %}}
Daha fazla bilgi için [yedek bir yazı tipli bir sunumu nasıl render edeceğinizi](/slides/tr/python-java/render-presentation-with-fallback-font/) okuyabilirsiniz.
{{% /alert %}}

## **SSS**

**Yedek kurallarım PPTX dosyasına gömülüp kaydedildikten sonra PowerPoint'te görünür mü?**

Hayır. Yedek kurallar, çalışma zamanında uygulama ayarlarıdır; PPTX dosyasına serileştirilmezler ve PowerPoint arayüzünde görünmezler.

**Yedekleme, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?**

Evet. Bu nesnelerdeki tüm metinler aynı glif değiştirme mekanizmasıyla işlenir.

**Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Yazı tiplerini kendi tarafınızda ekler ve sorumluluğu siz üstlenirsiniz.

**Eksik yazı tipleri için değiştirme/ikame ve eksik glifler için yedekleme birlikte kullanılabilir mi?**

Evet. Bunlar aynı yazı tipi çözümleme hattının bağımsız aşamalarıdır: önce motor, yazı tipi kullanılabilirliğini ([değiştirme](/slides/tr/python-java/font-replacement/)/[ikame](/slides/tr/python-java/font-substitution/)) çözer, ardından yedekleme, mevcut yazı tiplerindeki eksik glifleri doldurur.