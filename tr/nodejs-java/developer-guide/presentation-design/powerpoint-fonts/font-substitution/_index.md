---
title: JavaScript Kullanarak Sunumlarda Font İkamesini Yapılandırma
linktitle: Font İkamesi
type: docs
weight: 70
url: /tr/nodejs-java/font-substitution/
keywords:
- font
- ikame font
- font ikamesi
- font değiştirme
- font yerine koyma
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te PowerPoint ve OpenDocument sunumlarını diğer dosya formatlarına dönüştürürken Node.js için Aspose.Slides'te optimal font ikamesini etkinleştirin."
---
## **Genel Bakış**

Font ikamesi, Aspose.Slides'in orijinal sunum fontu renderleme veya dönüştürme sırasında mevcut olmadığında başka bir font kullanmasını sağlar. `FontsManager` sınıfının `getSubstitutions` yöntemini kullanarak hangi fontların ikame edildiğini kontrol edebilirsiniz.

Aspose.Slides ayrıca font ikame kuralları tanımlamanıza olanak verir. Örneğin, erişilemeyen bir fontun başka bir mevcut fontla değiştirilmesi gerektiğini belirtebilir ve bu kuralları sunumun font yöneticisi aracılığıyla uygulayabilirsiniz.

## **Font İkame Kurallarını Ayarlama**

Aspose.Slides, belirli koşullarda (örneğin bir font erişilemez olduğunda) ne yapılacağını belirleyen kuralları şu şekilde ayarlamanıza izin verir:

1. İlgili sunumu yükleyin.
2. Değiştirilecek fontu yükleyin.
3. Yeni fontu yükleyin.
4. Değiştirme için bir kural ekleyin.
5. Kuralı sunumun font değiştirme kuralı koleksiyonuna ekleyin.
6. Etkiyi gözlemlemek için slayt görüntüsünü oluşturun.

Bu JavaScript kodu font ikame sürecini gösterir:

```javascript
// Bir sunumu yükler
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Değiştirilecek kaynak fontu yükler
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Yeni fontu yükler
    var destFont = new aspose.slides.FontData("Arial");
    // Font değiştirme için bir kural ekler
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Kuralı font ikame kuralları koleksiyonuna ekler
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Kural listesine bir font kural koleksiyonu ekler
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Arial fontu, SomeRareFont erişilemez olduğunda onun yerine kullanılacak
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Görüntüyü JPEG formatında diske kaydeder
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Şu bağlantıya göz atmak isteyebilirsiniz [**Font Replacement**](/slides/tr/nodejs-java/font-replacement/).
{{% /alert %}}

## **Matematik Denklemi Fontları İçin Sınırlamalar**

Font ikame kuralları, renderleme ve dönüştürme sırasında kullanılan standart font seçim sürecine katılır. Aspose.Slides'in yapılandırılmış kurala göre erişilemeyen bir fontu başka bir mevcut fontla değiştirebildiği normal metin senaryoları için uygundur.

Bununla birlikte, Office matematik denklemlerinde önemli bir sınırlama vardır. Bir denklem **Cambria Math** ile oluşturulduysa, Aspose.Slides denklemin düzenini doğru bir şekilde hesaplamak ve renderlemek için hâlâ orijinal **Cambria Math** fontuna ihtiyaç duyabilir. Bu nedenle **Cambria Math**'ı **STIX Two Math** gibi başka bir matematik fontu ile değiştirmek, denklem renderlemesi için desteklenmez ve **Cambria Math**'ın gerekli olduğunu belirten bir istisna ortaya çıkabilir.

Bu tür sunumları başarılı bir şekilde dönüştürmek için, **Cambria Math**'ın çalışma zamanında Aspose.Slides tarafından ulaşılabilir olduğundan emin olun. Fontu işletim sistemine kurabilir veya bir [external font](/slides/tr/nodejs-java/custom-font/) sağlayarak renderleme ve dönüştürme sırasında normal font seçim sürecine katılmasını sağlayabilirsiniz.

Bu sınırlama yalnızca denklem renderlemesiyle ilgilidir. Yukarıda açıklanan standart font ikame kuralları, orijinal font erişilemez olduğunda normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Font değiştirme ile font ikamesi arasındaki fark nedir?**

[Replacement](/slides/tr/nodejs-java/font-replacement/) tüm sunum boyunca bir fontun bir diğerine zorla geçersiz kılınmasıdır. İkame, belirli bir koşul altında (örneğin orijinal font bulunamadığında) devreye giren ve belirlenen bir yedek fontun kullanılmasını sağlayan bir kuraldır.

**İkame kuralları tam olarak ne zaman uygulanır?**

Kurallar, yükleme, renderleme ve dönüştürme sırasında değerlendirilen standart [font selection](/slides/tr/nodejs-java/font-selection-sequence/) sırasına katılır; seçilen font bulunamazsa değiştirme veya ikame uygulanır.

**Ne replacement ne de substitution yapılandırılmadığında ve sistemde font eksik olduğunda varsayılan davranış nedir?**

Kütüphane, PowerPoint'in davranışına benzer şekilde en yakın mevcut sistem fontunu seçmeye çalışır.

**Substituion önlemek için çalışma zamanında özel dış fontlar ekleyebilir miyim?**

Evet. Çalışma zamanında [add external fonts](/slides/tr/nodejs-java/custom-font/) ekleyerek kütüphanenin seçim ve renderleme sırasında bunları dikkate almasını sağlayabilirsiniz; bu, sonraki dönüştürmeler için de geçerlidir.

**Aspose kütüphaneyle birlikte herhangi bir font dağıtıyor mu?**

Hayır. Aspose ücretli veya ücretsiz fontları dağıtmaz; fontları kendi takdir ve sorumluluğunuzda ekler ve kullanırsınız.

**Windows, Linux ve macOS'ta ikame davranışında farklılıklar var mı?**

Evet. Font keşfi işletim sisteminin font dizinlerinden başlar. Varsayılan olarak mevcut olan fontların seti ve arama yolları platformlar arasında farklılık gösterir; bu da kullanılabilirliği ve ikame ihtiyacını etkiler.

**Toplu dönüştürmeler sırasında beklenmedik ikameleri en aza indirmek için ortamı nasıl hazırlamalıyım?**

Makine veya konteynerler arasında font setini senkronize edin, çıktı belgeleri için gerekli olan [external fonts](/slides/tr/nodejs-java/custom-font/) ekleyin ve mümkün olduğunda sunumlara [embed fonts](/slides/tr/nodejs-java/embedded-font/) ekleyerek renderleme sırasında seçilecek fontların mevcut olmasını sağlayın.