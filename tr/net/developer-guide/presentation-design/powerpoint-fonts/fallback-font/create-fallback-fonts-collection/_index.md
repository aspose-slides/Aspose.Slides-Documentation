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
- yazı tipini yapılandır
- yazı tipini kur
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalması için Aspose.Slides .NET için bir geri dönüş yazı tipi koleksiyonu kurun."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için geri dönüş yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her geri dönüş kuralı, `FontFallBackRule` sınıfı tarafından temsil edilir ve `IFontFallBackRulesCollection` arayüzünü uygulayan bir `FontFallBackRulesCollection` öğesine eklenebilir.

Koleksiyonu oluşturduktan sonra, onu sunumun `FontsManager` sınıfındaki `FontFallBackRulesCollection` özelliğine atayabilirsiniz. `FontsManager`, sunum boyunca yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı bulunur.

`FontsManager`, geri dönüş yazı tipi koleksiyonu ile başlatıldıktan sonra, belirtilen geri dönüş yazı tipleri sunum render edilirken uygulanır.

## **Geri Dönüş Kurallarını Uygula**

[FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule) sınıfının örnekleri, [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrulescollection) içinde düzenlenebilir, bu da [IFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontfallbackrulescollection) arayüzünü uygular. Koleksiyondan kurallar eklemek veya kaldırmak mümkündür.

Ardından bu koleksiyon, [FontFallBackRulesCollection ](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) özelliğine, [FontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager) sınıfının bir örneği olarak atanabilir. FontsManager, sunum boyunca yazı tiplerini kontrol eder.

Her [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) kendi [FontsManager ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/properties/fontsmanager) özelliğine sahiptir ve bu özellik FontsManager sınıfının kendi örneğini içerir.

Belirli bir sunumun FontsManager'ına geri dönüş yazı tipi kuralları koleksiyonunu oluşturma ve atama örneği aşağıdadır:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

FontsManager, geri dönüş yazı tipi koleksiyonu ile başlatıldıktan sonra, geri dönüş yazı tipleri sunum render edilirken uygulanır.

{{% alert color="primary" %}} 
Daha fazla bilgi için [Geri Dönüş Yazı Tipi ile Sunumu Render Etme](/slides/tr/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **SSS**

**Geri dönüş kurallarım PPTX dosyasına gömülüp kaydedildikten sonra PowerPoint'te görülebilir mi?**

Hayır. Geri dönüş kuralları çalışma zamanı render ayarlarıdır; PPTX dosyasına serileştirilmez ve PowerPoint arabiriminde görünmez.

**Geri dönüş, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?**

Evet. Bu nesnelerdeki tüm metinler için aynı glif değiştirme mekanizması kullanılır.

**Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Yazı tiplerini kendi tarafınızda ekler ve sorumluluğunuz altında kullanırsınız.

**Eksik yazı tipleri için değiştirme/ikame ve eksik glifler için geri dönüş birlikte kullanılabilir mi?**

Evet. Bunlar aynı yazı tipi çözümleme hattının bağımsız aşamalarıdır: öncelikle motor, yazı tipi kullanılabilirliğini ([replacement](/slides/tr/net/font-replacement/)/[substitution](/slides/tr/net/font-substitution/)) çözer, ardından geri dönüş, mevcut yazı tiplerindeki eksik glifleri doldurur.