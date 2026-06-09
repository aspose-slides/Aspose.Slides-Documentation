---
title: Android'de Yedek Yazı Tipi Koleksiyonlarını Yapılandır
linktitle: Yedek Yazı Tipi Koleksiyonu
type: docs
weight: 20
url: /tr/androidjava/create-fallback-fonts-collection/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi koleksiyonu
- yazı tipini yapılandır
- yazı tipini kur
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Java aracılığıyla Android için Aspose.Slides'te bir yedek yazı tipleri koleksiyonu kurarak, PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için yedek yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her yedek kural, `FontFallBackRule` sınıfı ile temsil edilir ve `IFontFallBackRulesCollection` arayüzünü uygulayan bir `FontFallBackRulesCollection`'a eklenebilir.

Koleksiyon oluşturulduktan sonra, bunu sunumun `FontsManager`'ının `FontFallBackRulesCollection` özelliğine atayabilirsiniz. `FontsManager`, sunum genelindeki yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager`, yedek yazı tipi koleksiyonu ile başlatıldıktan sonra, belirtilen yedek yazı tipleri sunum render edildiği sırada uygulanır.

## **Geri Dönüş Kurallarını Uygula**

[FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule) sınıfının örnekleri, [IFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IFontFallBackRulesCollection) arayüzünü uygulayan [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRulesCollection) içine düzenlenebilir. Koleksiyondan kurallar eklemek ya da kaldırmak mümkündür.

Ardından bu koleksiyon, [FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager) sınıfının [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRulesCollection) yöntemine atanabilir. FontsManager, sunum genelindeki yazı tiplerini kontrol eder.

Her [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) nesnesinin, kendi [FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager) sınıfı örneğiyle bir [getFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getFontsManager--) yöntemi vardır.

Belirli bir sunumun [FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getFontsManager--)'ına yedek yazı tipi kurallarının koleksiyonunu oluşturma ve atama örnekleri aşağıda verilmiştir:  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

FontsManager yedek yazı tipi koleksiyonu ile başlatıldıktan sonra, yedek yazı tipleri sunum render edildiği sırada uygulanır.

{{% alert color="primary" %}} 
Daha fazla bilgi için [Yedek Yazı Tipi ile Sunumu Render Et](/slides/tr/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **SSS**

**Kaydettiğimde yedek kurallarım PPTX dosyasına gömülür ve PowerPoint'te görünür mü?**

Hayır. Yedek kurallar, çalışma zamanı render ayarlarıdır; PPTX'e serileştirilmez ve PowerPoint'in UI'sinde görünmez.

**Yedekleme, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?**

Evet. Aynı glif değiştirme mekanizması bu nesnelerdeki metinler için de kullanılır.

**Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Yazı tiplerini kendi tarafınızdan eklersiniz ve sorumluluğu size aittir.

**Eksik yazı tipleri için değiştirme/substitution ve eksik glifler için yedekleme birlikte kullanılabilir mi?**

Evet. Bunlar aynı yazı tipi çözümleme hattının bağımsız aşamalarıdır: önce motor, yazı tipi bulunabilirliğini (değiştirme/substitution) çözer, ardından yedekleme mevcut yazı tiplerindeki eksik glifleri doldurur.