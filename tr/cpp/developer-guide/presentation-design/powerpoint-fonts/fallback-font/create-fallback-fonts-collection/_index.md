---
title: C++'ta Geri Dönüş Yazı Tipi Koleksiyonlarını Yapılandırma
linktitle: Geri Dönüş Yazı Tipi Koleksiyonu
type: docs
weight: 20
url: /tr/cpp/create-fallback-fonts-collection/
keywords:
- geri dönüş yazı tipi
- geri dönüş kuralı
- yazı tipi koleksiyonu
- yazı tipini yapılandırma
- yazı tipini ayarlama
- PowerPoint
- OpenDocument
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides içinde C++ için bir geri dönüş yazı tipi koleksiyonu kurarak, PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için geri dönüş yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her geri dönüş kuralı, `FontFallBackRule` sınıfıyla temsil edilir ve `IFontFallBackRulesCollection` arayüzünü uygulayan bir `FontFallBackRulesCollection` içine eklenebilir.

Koleksiyonu oluşturduktan sonra, sunumun `FontsManager` nesnesinin `set_FontFallBackRulesCollection` metodunu kullanarak atayabilirsiniz. `FontsManager`, sunum boyunca yazı tiplerini yönetir ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager` geri dönüş yazı tipi koleksiyonu ile başlatıldığında, belirtilen geri dönüş yazı tipleri sunum render edilirken uygulanır.

## **Geri Dönüş Kurallarını Uygula**

`FontFallBackRule` sınıfının örnekleri, `IFontFallBackRulesCollection` arayüzünü uygulayan bir [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrulescollection/) içinde düzenlenebilir. Koleksiyondan kurallar eklemek veya kaldırmak mümkündür.

Daha sonra bu koleksiyon, [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) metoduyla [FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/) sınıfına aktarılabilir. FontsManager, sunum boyunca yazı tiplerini kontrol eder.

Her [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının, kendi FontsManager örneğiyle birlikte bir [get_FontsManager()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/) metodu vardır.

Belirli bir sunumun FontsManager'ına geri dönüş yazı tipi kurallarının koleksiyonunu nasıl oluşturup atayabileceğinize dair bir örnek:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager geri dönüş yazı tipi koleksiyonuyla başlatıldıktan sonra, geri dönüş yazı tipleri sunum render edilirken uygulanır.

{{% alert color="primary" %}} 
Geri dönüş yazı tipi ile Sunumu Render Etme hakkında daha fazla bilgi edinin: [Render Presentation with Fallback Font](/slides/tr/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **SSS**

**Geri dönüş kurallarım PPTX dosyasına gömülüp kaydedildikten sonra PowerPoint'te görünecek mi?**

Hayır. Geri dönüş kuralları çalışma zamanı render ayarlarıdır; PPTX dosyasına serileştirilmez ve PowerPoint arayüzünde görünmez.

**Geri dönüş, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?**

Evet. Aynı glyph-değiştirme mekanizması bu nesnelerdeki tüm metinler için kullanılır.

**Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Yazı tiplerini kendi tarafınızda ekler ve kullanırsınız; sorumluluk tamamen size aittir.

**Eksik yazı tipleri için değiştirme/yerine koyma ve eksik glifler için geri dönüş birlikte kullanılabilir mi?**

Evet. Bunlar aynı font çözümleme hattının bağımsız aşamalarıdır: önce motor, font mevcutluğunu ([replacement](/slides/tr/cpp/font-replacement/)/[substitution](/slides/tr/cpp/font-substitution/)) çözer, ardından geri dönüş mevcut fontlardaki eksik glifleri doldurur.