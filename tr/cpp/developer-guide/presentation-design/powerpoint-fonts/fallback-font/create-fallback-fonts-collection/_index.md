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
description: "Aspose.Slides for C++'ta bir yedek yazı tipi koleksiyonu kurarak PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için yedek yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her yedek kural, `FontFallBackRule` sınıfı ile temsil edilir ve `FontFallBackRulesCollection`a eklenebilir; bu sınıf `IFontFallBackRulesCollection` arayüzünü uygular.

Koleksiyonu oluşturduktan sonra, sunumun `FontsManager` sınıfının `set_FontFallBackRulesCollection` yöntemi ile atayabilirsiniz. `FontsManager`, sunum genelindeki yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager` yedek yazı tipi koleksiyonuyla başlatıldıktan sonra, belirtilen yedek yazı tipleri sunum işlenirken uygulanır.

## **Yedek Kurallarını Uygulama**

`[FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/)` sınıfının örnekleri, `[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrulescollection/)` içine düzenlenebilir; bu sınıf `[IFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrulescollection/)` arayüzünü uygular. Koleksiyondan kurallar eklemek veya çıkarmak mümkündür.

Ardından bu koleksiyon, `[set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)` yöntemi aracılığıyla `[FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/)` sınıfına geçirilebilir. FontsManager, sunum genelindeki yazı tiplerini kontrol eder.

Her `[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/)` nesnesi, kendi FontsManager sınıfı örneğiyle birlikte bir `[get_FontsManager()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/)` yöntemine sahiptir.

Belirli bir sunumun FontsManager'ına yedek yazı tipi kuralları koleksiyonu nasıl oluşturulur ve atanır, aşağıda bir örnek verilmiştir:  

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager yedek yazı tipleri koleksiyonu ile başlatıldıktan sonra, yedek yazı tipleri sunum işlenirken uygulanır.

{{% alert color="info" %}} 
Daha fazla bilgi için [Yedek Yazı Tipi ile Sunumu İşleme](/slides/tr/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **SSS**

### Yedek kurallarım PPTX dosyasına yerleştirilecek ve kaydettikten sonra PowerPoint'te görünecek mi?

Hayır. Yedek kurallar, çalışma zamanı işleme ayarlarıdır; PPTX dosyasına serileştirilmezler ve PowerPoint kullanıcı arayüzünde görünmezler.

### Yedekleme, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?

Evet. Bu nesnelerdeki tüm metinler için aynı glif değiştirme mekanizması kullanılır.

### Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?

Hayır. Yazı tiplerini kendiniz ekler ve kullanırsınız; sorumluluk size aittir.

### Eksik yazı tipleri için değiştirme/yerine koyma ve eksik glifler için yedekleme birlikte kullanılabilir mi?

Evet. Bunlar aynı yazı tipi çözümleme boru hattının bağımsız aşamalarıdır: önce motor, yazı tipi kullanılabilirliğini ([replacement](/slides/tr/cpp/font-replacement/)/[substitution](/slides/tr/cpp/font-substitution/)) çözümleyip, ardından yedekleme, mevcut yazı tiplerindeki eksik glifleri doldurur.