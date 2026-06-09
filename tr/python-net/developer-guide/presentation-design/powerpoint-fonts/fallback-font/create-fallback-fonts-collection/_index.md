---
title: Python’da Geri Dönüşüm Yazı Tipi Koleksiyonlarını Yapılandırma
linktitle: Geri Dönüşüm Yazı Tipi Koleksiyonu
type: docs
weight: 20
url: /tr/python-net/create-fallback-fonts-collection/
keywords:
- geri dönüşüm yazı tipi
- geri dönüşüm kuralı
- yazı tipi koleksiyonu
- yazı tipini yapılandırma
- yazı tipini kurma
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalması için Aspose.Slides for Python’da .NET aracılığıyla bir geri dönüşüm yazı tipi koleksiyonu kurun."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için geri dönüşüm yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her geri dönüşüm kuralı `FontFallBackRule` sınıfı ile temsil edilir ve bir `FontFallBackRulesCollection` içine eklenebilir.

Koleksiyonu oluşturduktan sonra, sunumun `fonts_manager` öğesinin `font_fall_back_rules_collection` özelliğine atayabilirsiniz. `fonts_manager`, sunum boyunca yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager`, geri dönüşüm yazı tipi koleksiyonu ile başlatıldıktan sonra, belirtilen geri dönüşüm yazı tipleri sunum render edildiğinde uygulanır.

## **Geri Dönüşüm Kurallarını Uygula**

`[FontFallBackRule](https://reference.aspose.com/slides/tr/python-net/aspose.slides/FontFallBackRule/)` sınıfının örnekleri, `[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontfallbackrulescollection/)` içine düzenlenebilir. Koleksiyondan kurallar eklemek veya kaldırmak mümkündür.

Ardından bu koleksiyon, `[font_fall_back_rules_collection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/)` özelliğine `[FontsManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/)` sınıfının içinde atanabilir. FontsManager, sunum boyunca yazı tiplerini kontrol eder.

Her `[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/)` bir `[fonts_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/fonts_manager/)` özelliğine sahiptir ve bu özellik kendi FontsManager sınıfı örneğini içerir.

Belirli bir sunumun FontsManager'ına geri dönüşüm yazı tipi kurallarının koleksiyonunu nasıl oluşturup atayacağını gösteren bir örnek:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

FontsManager, geri dönüşüm yazı tipi koleksiyonu ile başlatıldıktan sonra, geri dönüşüm yazı tipleri sunum render edildiğinde uygulanır.

{{% alert color="primary" %}} 
Daha fazla bilgi için [Geri Dönüşüm Yazı Tipi ile Sunumu Render Et](/slides/tr/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **SSS**

**Geri dönüşüm kurallarım PPTX dosyasına gömülür ve kaydettikten sonra PowerPoint'te görünür mü?**

Hayır. Geri dönüşüm kuralları çalışma zamanı render ayarlarıdır; PPTX dosyasına serileştirilmez ve PowerPoint kullanıcı arayüzünde görüntülenmez.

**Geri dönüşüm, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?**

Evet. Bu nesnelerdeki tüm metinler için aynı glif değiştirme mekanizması kullanılır.

**Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Yazı tiplerini kendi tarafınızdan ekler ve kullanırsınız ve sorumluluk size aittir.

**Eksik yazı tipleri için değişim/yerine koyma ve eksik glifler için geri dönüşüm birlikte kullanılabilir mi?**

Evet. Bunlar aynı yazı tipi çözümleme boru hattının bağımsız aşamalarıdır: önce motor, yazı tipi kullanılabilirliğini ([değişim](/slides/tr/python-net/font-replacement/)/[yerine koyma](/slides/tr/python-net/font-substitution/)) çözer, ardından geri dönüşüm, mevcut yazı tiplerindeki eksik glifleri doldurur.