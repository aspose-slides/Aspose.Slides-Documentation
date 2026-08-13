---
title: "Java'da Yedek Yazı Tipi Koleksiyonlarını Yapılandırma"
linktitle: "Yedek Yazı Tipi Koleksiyonu"
type: docs
weight: 20
url: /tr/java/create-fallback-fonts-collection/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi koleksiyonu
- yazı tipi yapılandırması
- yazı tipi kurulumu
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da yedek yazı tipleri koleksiyonu kurarak PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için yedek yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her yedek kural, `FontFallBackRule` sınıfı ile temsil edilir ve `FontFallBackRulesCollection` koleksiyonuna eklenebilir; bu koleksiyon `IFontFallBackRulesCollection` arayüzünü uygular.

Koleksiyonu oluşturduktan sonra, sunumun `FontsManager` nesnesinin `FontFallBackRulesCollection` özelliğine atayabilirsiniz. `FontsManager`, sunum boyunca yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager` nesnesi vardır.

`FontsManager` yedek yazı tipi koleksiyonu ile başlatıldığında, belirtilen yedek yazı tipleri sunumun işlenmesi sırasında uygulanır.

## **Yedek Kuralları Uygula**

[FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) sınıfının örnekleri, [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRulesCollection) içinde düzenlenebilir; bu koleksiyon, [IFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IFontFallBackRulesCollection) arayüzünü uygular. Koleksiyondan kurallar eklemek veya çıkarmak mümkündür.

Ardından bu koleksiyon, [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRulesCollection) yöntemi aracılığıyla [FontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsManager) sınıfına atanabilir. FontsManager, sunum boyunca yazı tiplerini kontrol eder.

Her [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesinin, kendi [FontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsManager) örneğiyle birlikte bir [getFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getFontsManager--) yöntemi bulunur.

Aşağıda, belirli bir sunumun [FontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getFontsManager--) nesnesine yedek yazı tipi kurallarının koleksiyonunu nasıl oluşturup atayacağınıza dair bir örnek verilmiştir:  

```java
import com.aspose.slides.*;

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

FontsManager yedek yazı tipi koleksiyonu ile başlatıldıktan sonra, yedek yazı tipleri sunumun işlenmesi sırasında uygulanır.

{{% alert color="info" %}} 
Daha fazla bilgi için [Render Presentation with Fallback Font](/slides/tr/java/render-presentation-with-fallback-font/) sayfasına bakabilirsiniz.
{{% /alert %}}

## **SSS**

### Yedek kurallarım PPTX dosyasına gömülür ve kaydedildikten sonra PowerPoint içinde görünür mü?

Hayır. Yedek kurallar, çalışma zamanı işleme ayarlarıdır; PPTX dosyasına serileştirilmez ve PowerPoint kullanıcı arabiriminde görünmez.

### Yedekleme, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?

Evet. Aynı glif değiştirme mekanizması bu nesnelerdeki tüm metinler için kullanılır.

### Aspose, kitaplıkla birlikte herhangi bir yazı tipi dağıtıyor mu?

Hayır. Yazı tiplerini kendi tarafınızdan ekler ve sorumluluğu siz üstlenirsiniz.

### Eksik yazı tipleri için değiştirme/ikame ve eksik glifler için yedekleme birlikte kullanılabilir mi?

Evet. Bunlar aynı yazı tipi çözümleme hattının bağımsız aşamalarıdır: önce motor, yazı tipi bulunabilirliğini (değiştirme](/slides/tr/java/font-replacement/)/[ikame](/slides/tr/java/font-substitution/)) çözer, ardından yedekleme mevcut yazı tiplerinde eksik glifleri doldurur.