---
title: JavaScript'te Yedek Font Koleksiyonlarını Yapılandırma
linktitle: Yedek Font Koleksiyonu
type: docs
weight: 20
url: /tr/nodejs-java/create-fallback-fonts-collection/
keywords:
- yedek font
- yedek kural
- font koleksiyonu
- font yapılandırma
- font ayarlama
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js için Aspose.Slides ile JavaScript'te bir yedek font koleksiyonu kurarak PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için yedek font kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her yedek kural, `FontFallBackRule` sınıfı ile temsil edilir ve bir `FontFallBackRulesCollection` içine eklenebilir.

Koleksiyonu oluşturduktan sonra, sunumun `FontsManager`'ının `setFontFallBackRulesCollection` yöntemiyle atayabilirsiniz. `FontsManager`, sunum boyunca fontları kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager`, yedek font koleksiyonu ile başlatıldıktan sonra, belirtilen yedek fontlar sunum oluşturulması sırasında uygulanır.

## **Yedek Kuralları Uygulama**

[FontFallBackRule](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule) sınıfının örnekleri, [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRulesCollection) içine düzenlenebilir; bu, [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRulesCollection) sınıfını uygular. Koleksiyondan kurallar eklemek veya kaldırmak mümkündür.

Bu koleksiyon daha sonra, [FontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontsManager) sınıfının [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRulesCollection) yöntemine atanabilir. FontsManager, sunum boyunca fontları kontrol eder.

Her [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) nesnesinin, kendi [FontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontsManager) örneğiyle birlikte bir [getFontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getFontsManager--) yöntemi vardır.

Belirli bir sunumun [FontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getFontsManager--) içine yedek font kuralları koleksiyonunu nasıl oluşturup atayacağınıza dair bir örnek:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

FontsManager, yedek font koleksiyonu ile başlatıldıktan sonra, yedek fontlar sunum oluşturulması sırasında uygulanır.

{{% alert color="primary" %}} 
Yedek font ile sunumu nasıl oluşturacağınız hakkında daha fazla bilgi edinin: [Yedek Font ile Sunumu Oluşturma](/slides/tr/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **SSS**

**Yedek kurallarım PPTX dosyasına gömülür mü ve kaydettikten sonra PowerPoint'te görünür mü?**

Hayır. Yedek kurallar, çalışma zamanında uygulama ayarlarıdır; PPTX dosyasına serileştirilmezler ve PowerPoint arayüzünde görünmezler.

**Yedekleme, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?**

Evet. Bu nesnelerdeki tüm metinler aynı glyph-değiştirme mekanizmasıyla işlenir.

**Aspose, kütüphane ile birlikte herhangi bir font dağıtıyor mu?**

Hayır. Fontları kendi tarafınızda ekler ve kullanırsınız ve sorumluluk size aittir.

**Eksik fontlar için değiştirme/değiştirme ve eksik glyph'ler için yedekleme birlikte kullanılabilir mi?**

Evet. Bunlar aynı font-çözümleme hattının bağımsız aşamalarıdır: önce motor font kullanılabilirliğini çözümleyerek ([replacement](/slides/tr/nodejs-java/font-replacement/)/[substitution](/slides/tr/nodejs-java/font-substitution/)), ardından yedekleme mevcut fontlarda eksik glyph'ler için boşlukları doldurur.