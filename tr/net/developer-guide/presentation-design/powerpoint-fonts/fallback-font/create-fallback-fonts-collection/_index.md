---
title: ".NET'te Geri Dönüş Yazı Tipi Koleksiyonlarını Yapılandırma"
linktitle: "Geri Dönüş Yazı Tipi Koleksiyonu"
type: docs
weight: 20
url: /tr/net/create-fallback-fonts-collection/
keywords:
- geri dönüş yazı tipi
- geri dönüş kuralı
- yazı tipi koleksiyonu
- yazı tipini yapılandırma
- yazı tipini kurma
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te bir geri dönüş yazı tipi koleksiyonu kurarak PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için geri dönüş yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak sağlar. Her geri dönüş kuralı `FontFallBackRule` sınıfı ile temsil edilir ve `IFontFallBackRulesCollection` arayüzünü uygulayan bir `FontFallBackRulesCollection` içine eklenebilir.

Koleksiyonu oluşturduktan sonra, onu sunumun `FontsManager`'ının `FontFallBackRulesCollection` özelliğine atayabilirsiniz. `FontsManager`, sunum boyunca yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager`, geri dönüş yazı tipi koleksiyonu ile başlatıldıktan sonra, belirtilen geri dönüş yazı tipleri sunum işlenirken uygulanır.

## **Geri Dönüş Kurallarını Uygula**

`[FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule)` sınıfının örnekleri, `[IFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontfallbackrulescollection)` arayüzünü uygulayan `[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrulescollection)` içine düzenlenebilir. Koleksiyondan kurallar eklemek veya kaldırmak mümkündür.

Ardından bu koleksiyon, `[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)` özelliğine `[FontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager)` sınıfının içinde atanabilir. FontsManager, sunum boyunca yazı tiplerini kontrol eder.

Her `[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation)` sınıfının, kendi `FontsManager` sınıfı örneğine sahip bir `[FontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/properties/fontsmanager)` özelliği vardır.

Belirli bir sunumun `FontsManager`'ına geri dönüş yazı tipi kuralları koleksiyonunu oluşturup atamanın bir örneği aşağıdadır:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

`FontsManager`, geri dönüş yazı tipi koleksiyonu ile başlatıldıktan sonra, geri dönüş yazı tipleri sunum işlenirken uygulanır.

{{% alert color="info" %}} 
[Geri Dönüş Yazı Tipi ile Sunumu İşleme](/slides/tr/net/render-presentation-with-fallback-font/)
{{% /alert %}}

## **SSS**

### Geri dönüş kurallarım PPTX dosyasına gömülür ve kaydettikten sonra PowerPoint'te görünür mü?

Hayır. Geri dönüş kuralları çalışma zamanında işleme ayarlarıdır; PPTX dosyasına serileştirilmezler ve PowerPoint kullanıcı arabiriminde görünmezler.

### Geri dönüş, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?

Evet. Bu nesnelerdeki tüm metinler için aynı glif değiştirme mekanizması kullanılır.

### Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?

Hayır. Yazı tiplerini kendi tarafınızda eklersiniz ve kullanırsınız; sorumluluk size aittir.

### Eksik yazı tipleri için değiştirme/yerine koyma ve eksik glifler için geri dönüş birlikte kullanılabilir mi?

Evet. Bunlar aynı yazı tipi çözümleme hattının bağımsız aşamalarıdır: önce motor, yazı tipi kullanılabilirliğini ([replacement](/slides/tr/net/font-replacement/)/[substitution](/slides/tr/net/font-substitution/)) çözer, ardından geri dönüş, mevcut yazı tiplerindeki eksik glif boşluklarını doldurur.