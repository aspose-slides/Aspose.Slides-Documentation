---
title: C++'ta Yedek Yazı Tipi Koleksiyonlarını Yapılandırma
linktitle: Yedek Yazı Tipi Koleksiyonu
type: docs
weight: 20
url: /tr/cpp/create-fallback-fonts-collection/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi koleksiyonu
- yazı tipini yapılandır
- yazı tipini kur
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalması için C++ için Aspose.Slides'ta bir yedek yazı tipi koleksiyonu kurun."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için yedek yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her yedek kural, `FontFallBackRule` sınıfı tarafından temsil edilir ve `IFontFallBackRulesCollection` arabirimini uygulayan bir `FontFallBackRulesCollection` içine eklenebilir.

Koleksiyonu oluşturduktan sonra, sunumun `FontsManager` sınıfının `set_FontFallBackRulesCollection` yöntemiyle atayabilirsiniz. `FontsManager`, sunum boyunca yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager`, yedek yazı tipi koleksiyonu ile başlatıldığında, belirtilen yedek yazı tipleri sunum oluşturulurken uygulanır.

## **Yedek Kuralları Uygula**

[FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) sınıfının örnekleri, [IFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrulescollection/) arayüzünü uygulayan [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrulescollection/) içine düzenlenebilir. Koleksiyondan kurallar eklemek veya kaldırmak mümkündür.

Ardından bu koleksiyon, [FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/) sınıfının [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) yöntemine geçirilebilir. FontsManager, sunum boyunca yazı tiplerini kontrol eder.

Her [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) öğesinin, FontsManager sınıfının kendi örneğiyle bir [get_FontsManager()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/) yöntemi vardır.

Belirli bir sunumun FontsManager'ına yedek yazı tipi kurallar koleksiyonunu oluşturup atamanın bir örneği aşağıdadır:

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager, yedek yazı tipleri koleksiyonu ile başlatıldıktan sonra, yedek yazı tipleri sunum oluşturulurken uygulanır.

{{% alert color="primary" %}} 
[Yedek Yazı Tipi ile Sunumu Render Etme](/slides/tr/cpp/render-presentation-with-fallback-font/) hakkında daha fazla bilgi edinin.
{{% /alert %}}

## **SSS**

**Yedek kurallarım PPTX dosyasına gömülür ve kaydetmeden sonra PowerPoint'te görünür mü?**

Hayır. Yedek kurallar, çalışma zamanında kullanılan render ayarlarıdır; PPTX dosyasına serileştirilmezler ve PowerPoint arayüzünde görünmezler.

**Yedekleme, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?**

Evet. Bu nesnelerdeki herhangi bir metin için aynı glif değiştirme mekanizması kullanılır.

**Aspose kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Yazı tiplerini kendi tarafınızdan eklersiniz ve sorumluluğu siz üstlenirsiniz.

**Eksik yazı tipleri için değiştirme/yerine koyma ve eksik glifler için yedekleme birlikte kullanılabilir mi?**

Evet. Bunlar aynı yazı tipi çözümleme boru hattının bağımsız aşamalarıdır: önce motor, yazı tipi kullanılabilirliğini ([replacement](/slides/tr/cpp/font-replacement/)/[substitution](/slides/tr/cpp/font-substitution/)) çözer, ardından yedekleme, mevcut yazı tiplerindeki eksik glifleri doldurur.