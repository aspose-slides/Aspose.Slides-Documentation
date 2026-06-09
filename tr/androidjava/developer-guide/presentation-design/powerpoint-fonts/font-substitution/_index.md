---
title: Android'de Sunumlarda Font Değişimini Yapılandırma
linktitle: Font Değişimi
type: docs
weight: 70
url: /tr/androidjava/font-substitution/
keywords:
- yazı tipi
- yedek yazı tipi
- yazı tipi değişimi
- yazı tipi değiştirme
- yazı tipi ikamesi
- değişim kuralı
- ikame kuralı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını diğer dosya formatlarına dönüştürürken, Android için Aspose.Slides'ta Java aracılığıyla optimal font değişimini etkinleştirin."
---
## **Genel Bakış**

Font değişimi, Aspose.Slides'in orijinal sunum yazı tipi işleme veya dönüştürme sırasında mevcut olmadığında başka bir yazı tipini kullanmasını sağlar. `IFontsManager` arayüzündeki `getSubstitutions` yöntemini kullanarak hangi yazı tiplerinin değiştirildiğini kontrol edebilirsiniz.

Aspose.Slides ayrıca font değişim kurallarını tanımlamanıza izin verir. Örneğin, erişilemeyen bir fontun başka bir mevcut fontla değiştirilmesini belirtebilir ve ardından bu kuralları sunumun font yöneticisi aracılığıyla uygulayabilirsiniz.

## **Font Değişim Kurallarını Ayarlama**

Aspose.Slides, belirli koşullarda (örneğin bir fonta erişilemediğinde) ne yapılması gerektiğini belirleyen kuralları şu şekilde ayarlamanıza olanak tanır:

1. İlgili sunumu yükleyin.  
2. Değiştirilecek fontu yükleyin.  
3. Yeni fontu yükleyin.  
4. Değiştirme için bir kural ekleyin.  
5. Kuralı sunumun font değiştirme kural koleksiyonuna ekleyin.  
6. Etkisini gözlemlemek için slayt görüntüsü oluşturun.  

Bu Java kodu, font değişim sürecini gösterir:

```java
// Bir sunumu yükler
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Değiştirilecek kaynak fontu yükler
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Yeni fontu yükler
    IFontData destFont = new FontData("Arial");
    
    // Font değişimi için bir kural ekler
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Kuralı font değiştirme kuralları koleksiyonuna ekler
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Kural listesine bir font kural koleksiyonu ekler
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Arial fontu, SomeRareFont erişilemez olduğunda onun yerine kullanılacaktır
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Görüntüyü JPEG formatında diske kaydeder
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
İlgili sayfayı görmek isteyebilirsiniz [**Font Replacement**](/slides/tr/androidjava/font-replacement/).  
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri için Sınırlamalar**

Font değişim kuralları, işleme ve dönüştürme sırasında kullanılan standart font seçme sürecine katılır. Aspose.Slides'in, erişilemeyen bir fontu yapılandırılmış kurala göre başka bir mevcut fontla değiştirebildiği normal metin senaryoları için uygundur.

Ancak, Office matematik denklemlerinde önemli bir sınırlama vardır. Bir denklem **Cambria Math** ile oluşturulmuşsa, Aspose.Slides denklemin düzenini doğru şekilde hesaplamak ve işlemek için hâlâ orijinal **Cambria Math** yazı tipine ihtiyaç duyabilir. Bu nedenle **Cambria Math**'ın **STIX Two Math** gibi başka bir matematik yazı tipiyle değiştirilmesi, denklem işleme için desteklenmez ve hâlâ **Cambria Math** gerektiğini belirten bir istisna ile sonuçlanabilir.

Bu tür sunumları başarıyla dönüştürmek için, **Cambria Math**'ın çalışma zamanında Aspose.Slides tarafından erişilebilir olduğundan emin olun. Yazı tipini işletim sistemine kurabilir veya bir [external font](/slides/tr/androidjava/custom-font/) olarak sağlayarak işleme ve dönüştürme sırasında normal font seçme sürecine katılmasını sağlayabilirsiniz.

Bu sınırlama yalnızca denklem işleme için geçerlidir. Yukarıda açıklanan standart font değişim kuralları, orijinal font erişilemediğinde normal sunum metni için hâlâ uygulanır.

## **SSS**

**Font değiştirme ile font değişimi arasındaki fark nedir?**

[Replacement](/slides/tr/androidjava/font-replacement/) tüm sunum boyunca bir fontun zorla bir başka fontla üzerine yazılmasıdır. Değişim, belirli bir koşul altında (örneğin orijinal font mevcut olmadığında) tetiklenen ve tanımlı bir yedek fontun kullanıldığı bir kuraldır.

**Değişim kuralları tam olarak ne zaman uygulanır?**

Kurallar, yükleme, işleme ve dönüştürme sırasında değerlendirilmekte olan standart [font selection](/slides/tr/androidjava/font-selection-sequence/) sırasına katılır; seçilen font mevcut değilse değiştirme veya değişim uygulanır.

**Ne bir değiştirme ne de değişim yapılandırılmamış ve sistemde font eksikse varsayılan davranış nedir?**

Kütüphane, PowerPoint'in davranışına benzer şekilde en yakın mevcut sistem fontunu seçmeye çalışır.

**Değişimi önlemek için çalışma zamanında özel dış fontları ekleyebilir miyim?**

Evet. Çalışma zamanında [external fonts](/slides/tr/androidjava/custom-font/) ekleyebilir, böylece kütüphane seçim ve işleme sırasında bunları göz önünde bulundurur, sonraki dönüşümler için de geçerli olur.

**Aspose kütüphane ile birlikte herhangi bir font dağıtıyor mu?**

Hayır. Aspose ücretli veya ücretsiz fontlar dağıtmaz; fontları kendi takdiriniz ve sorumluluğunuzla ekleyip kullanırsınız.

**Windows, Linux ve macOS üzerinde değişim davranışında farklılıklar var mı?**

Evet. Font keşfi, işletim sisteminin font dizinlerinden başlar. Varsayılan mevcut fontların seti ve arama yolları platformlar arasında farklılık gösterir; bu da erişilebilirliği ve değişim ihtiyacını etkiler.

**Toplu dönüşümler sırasında beklenmeyen değişimleri en aza indirmek için ortamı nasıl hazırlamalıyım?**

Makine veya konteynerler arasında font setini senkronize edin, çıktı belgeleri için gereken [external fonts](/slides/tr/androidjava/custom-font/) ekleyin ve mümkün olduğunda sunumlara [embed fonts](/slides/tr/androidjava/embedded-font/) yerleştirerek seçilen fontların işleme sırasında mevcut olmasını sağlayın.