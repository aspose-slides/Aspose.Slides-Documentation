---
title: Android'de Yedek Yazı Tipi Koleksiyonlarını Yapılandırma
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
description: "Java aracılığıyla Android için Aspose.Slides'te bir yedek yazı tipi koleksiyonu kurarak PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides size bir sunum için yedek yazı tipi kurallarının bir koleksiyonunu yapılandırma imkanı verir. Her yedek kural, `FontFallBackRule` sınıfı ile temsil edilir ve `IFontFallBackRulesCollection` arayüzünü uygulayan bir `FontFallBackRulesCollection`'a eklenebilir.

Koleksiyonu oluşturduktan sonra, sunumun `FontsManager`'ının `FontFallBackRulesCollection` özelliğine atayabilirsiniz. `FontsManager` sunum boyunca yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager`, yedek yazı tipi koleksiyonu ile başlatıldığında, belirtilen yedek yazı tipleri sunum oluşturulurken uygulanır.

## **Yedek Kuralları Uygula**

`[FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule)` sınıfının örnekleri, `[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRulesCollection)` içerisinde düzenlenebilir; bu koleksiyon `[IFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IFontFallBackRulesCollection)` arayüzünü uygular. Koleksiyona kural eklemek veya kuralları kaldırmak mümkündür.

Ardından bu koleksiyon, `[FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager)` sınıfının `[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRulesCollection)` metoduna atanabilir. `FontsManager` sunum genelinde yazı tiplerini kontrol eder.

Her `[Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation)` nesnesinin kendi `[FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager)` örneğiyle kullanılabilen bir `[getFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getFontsManager--)` yöntemi vardır.

Aşağıda, belirli bir sunumun `[FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getFontsManager--)`'ine yedek yazı tipi kural koleksiyonunun nasıl oluşturulup atanacağına dair bir örnek verilmiştir:  

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

`FontsManager`, yedek yazı tipi koleksiyonu ile başlatıldıktan sonra, yedek yazı tipleri sunum oluşturulurken uygulanır.

{{% alert color="info" %}} 
Daha fazla bilgi için [Render Presentation with Fallback Font](/slides/tr/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **SSS**

### Yedek kurallarım PPTX dosyasına gömülür ve kaydedildikten sonra PowerPoint'te görünür mü?

Hayır. Yedek kurallar, çalışma zamanı render ayarlarıdır; PPTX dosyasına serileştirilmezler ve PowerPoint kullanıcı arayüzünde görünmezler.

### Yedekleme, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?

Evet. Bu nesnelerdeki metin için aynı glif değiştirme mekanizması kullanılır.

### Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?

Hayır. Yazı tiplerini kendi tarafınızda ekler ve sorumluluğu siz üstlenirsiniz.

### Eksik yazı tipleri için yerine koyma/değiştirme ve eksik glifler için yedekleme birlikte kullanılabilir mi?

Evet. Bunlar aynı yazı tipi çözümleme boru hattının bağımsız aşamalarıdır: önce motor, yazı tipi bulunabilirliğini ([replacement](/slides/tr/androidjava/font-replacement/)/[substitution](/slides/tr/androidjava/font-substitution/)) çözer, ardından yedekleme, mevcut yazı tiplerindeki eksik glifleri doldurur.