---
title: Java’da Yedek Yazı Tipi Koleksiyonlarını Yapılandırma
linktitle: Yedek Yazı Tipi Koleksiyonu
type: docs
weight: 20
url: /tr/java/create-fallback-fonts-collection/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi koleksiyonu
- yazı tipini yapılandır
- yazı tipini kur
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java için Aspose.Slides içinde yedek yazı tipleri koleksiyonunu kurarak, PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net olmasını sağlayın."
---
## **Overview**

Aspose.Slides, bir sunum için yedek yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her yedek kural, `FontFallBackRule` sınıfı ile temsil edilir ve `IFontFallBackRulesCollection` arabirimini uygulayan bir `FontFallBackRulesCollection`a eklenebilir.

Koleksiyonu oluşturduktan sonra, bunu sunumun `FontsManager`'ının `FontFallBackRulesCollection` özelliğine atayabilirsiniz. `FontsManager`, sunum boyunca yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager`, yedek yazı tipi koleksiyonu ile başlatıldıktan sonra, belirtilen yedek yazı tipleri sunumun render edilmesi sırasında uygulanır.

## **Apply Fallback Rules**

[FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) sınıfının örnekleri, [IFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IFontFallBackRulesCollection) arabirimini uygulayan bir [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRulesCollection) içinde düzenlenebilir. Koleksiyondan kurallar eklemek veya kaldırmak mümkündür.

Ardından bu koleksiyon, [FontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsManager) sınıfının [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRulesCollection) metoduna atanabilir. FontsManager, sunum boyunca yazı tiplerini kontrol eder.

Her [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesinin, kendi [FontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsManager) sınıfı örneğiyle bir [getFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getFontsManager--) metodu vardır.

Aşağıda, bir sunumun [FontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getFontsManager--)'ına yedek yazı tipi kuralları koleksiyonu oluşturup atamanın bir örneği verilmiştir:
  
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

FontsManager, yedek yazı tipleri koleksiyonu ile başlatıldıktan sonra, yedek yazı tipleri sunumun render edilmesi sırasında uygulanır.

{{% alert color="primary" %}} 
Daha fazla bilgi için [Render Presentation with Fallback Font](/slides/tr/java/render-presentation-with-fallback-font/) konusuna bakın.
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

Hayır. Yedek kurallar, çalışma zamanı render ayarlarıdır; PPTX'e serileştirilmez ve PowerPoint arayüzünde görünmez.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

Evet. Aynı glif-değiştirme mekanizması bu nesnelerdeki tüm metinler için kullanılır.

**Does Aspose distribute any fonts with the library?**

Hayır. Yazı tiplerini kendi tarafınızdan ekler ve kullanırsınız, sorumluluk tamamen size aittir.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

Evet. Bunlar aynı yazı tipi çözümleme hattının bağımsız aşamalarıdır: önce motor, yazı tipi kullanılabilirliğini ([replacement](/slides/tr/java/font-replacement/)/[substitution](/slides/tr/java/font-substitution/)) çözer, ardından yedekleme, mevcut yazı tiplerindeki eksik glifleri doldurur.