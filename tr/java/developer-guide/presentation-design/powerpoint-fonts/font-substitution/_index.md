---
title: Java Kullanarak Sunumlarda Yazı Tipi Değiştirmeyi Yapılandırma
linktitle: Yazı Tipi Değiştirme
type: docs
weight: 70
url: /tr/java/font-substitution/
keywords:
- yazı tipi
- yazı tipi yerine koyma
- yazı tipi değiştirme
- yazı tipi yer değiştirme
- yazı tipi yer değiştirme
- değiştirme kuralı
- yerine koyma kuralı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını diğer dosya formatlarına dönüştürürken Aspose.Slides for Java’da optimal yazı tipi değişimini etkinleştirin."
---
## **Genel Bakış**

Yazı tipi değiştirme, Aspose.Slides'in orijinal sunumda kullanılan yazı tipi, renderlama veya dönüşüm sırasında mevcut olmadığında başka bir yazı tipi kullanmasını sağlar. `IFontsManager` arabiriminden `getSubstitutions` yöntemini kullanarak hangi yazı tiplerinin değiştirildiğini kontrol edebilirsiniz.

Aspose.Slides ayrıca yazı tipi değiştirme kurallarını tanımlamanıza izin verir. Örneğin, erişilemeyen bir yazı tipinin başka bir mevcut yazı tipiyle değiştirilmesini belirtebilir ve bu kuralları sunumun yazı tipi yöneticisi aracılığıyla uygulayabilirsiniz.

## **Yazı Tipi Değiştirme Kurallarını Ayarla**

Aspose.Slides, belirli koşullarda (örneğin bir yazı tipine erişilemediğinde) ne yapılacağını belirleyen kuralları şu şekilde ayarlamanıza olanak tanır:

1. İlgili sunumu yükleyin.
2. Değiştirilecek yazı tipini yükleyin.
3. Yeni yazı tipini yükleyin.
4. Değiştirme için bir kural ekleyin.
5. Kuralı sunumun yazı tipi değiştirme kural koleksiyonuna ekleyin.
6. Etkiyi gözlemlemek için slayt görseli oluşturun.

Bu Java kodu, yazı tipi değiştirme sürecini gösterir:

```java
// Bir sunumu yükler
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Değiştirilecek kaynak yazı tipini yükler
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Yeni yazı tipini yükler
    IFontData destFont = new FontData("Arial");
    
    // Yazı tipi değiştirme için bir kural ekler
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Kuralı yazı tipi değiştirme kuralları koleksiyonuna ekler
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Kural listesine bir yazı tipi kural koleksiyonu ekler
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // SomeRareFont erişilemez olduğunda Arial yazı tipi onun yerine kullanılacak
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

{{%  alert title="NOT"  color="warning"   %}} 

[**Yazı Tipi Değiştirme**](/slides/tr/java/font-replacement/) sayfasına göz atmak isteyebilirsiniz. 

{{% /alert %}}

## **Matematik Denklem Yazı Tipleri için Sınırlamalar**

Yazı tipi değiştirme kuralları, renderlama ve dönüşüm sırasında kullanılan standart yazı tipi seçim sürecine katılır. Bu kurallar, Aspose.Slides'in erişilemeyen bir yazı tipini yapılandırılmış kurala göre başka bir mevcut yazı tipiyle değiştirebileceği normal metin senaryoları için uygundur.

Bununla birlikte, Office matematik denklemlerinde önemli bir sınırlama vardır. Bir denklem **Cambria Math** ile oluşturulmuşsa, Aspose.Slides denklemin düzenini doğru bir şekilde hesaplamak ve renderlamak için hâlâ orijinal **Cambria Math** yazı tipine ihtiyaç duyabilir. Bu nedenle **Cambria Math**'i **STIX Two Math** gibi başka bir matematik yazı tipiyle değiştirmek, denklem renderlama için desteklenmez ve hâlâ **Cambria Math**'in gerekli olduğunu belirten bir istisna ortaya çıkabilir.

Bu tür sunumları başarıyla dönüştürmek için, çalışma zamanında **Cambria Math**'in Aspose.Slides tarafından erişilebilir olduğundan emin olun. Yazı tipini işletim sistemine kurabilir veya bir [harici yazı tipi](/slides/tr/java/custom-font/) sağlayarak renderlama ve dönüşüm sırasında normal yazı tipi seçim sürecine katılmasını sağlayabilirsiniz.

Bu sınırlama yalnızca denklem renderlamasına özeldir. Yukarıda açıklanan standart yazı tipi değiştirme kuralları, orijinal yazı tipi erişilemez olduğunda normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değiştirme ile yazı tipi yerine koyma arasındaki fark nedir?**

[Değiştirme](/slides/tr/java/font-replacement/) tüm sunum boyunca bir yazı tipinin zorunlu olarak başka bir yazı tipiyle değiştirilmesidir. Değiştirme, belirli bir koşul altında (örneğin orijinal yazı tipi mevcut değilse) tetiklenen ve ardından tanımlı bir geri dönüş yazı tipinin kullanıldığı bir kuraldır.

**Değiştirme kuralları tam olarak ne zaman uygulanır?**

Kurallar, yükleme, renderlama ve dönüşüm sırasında değerlendirilen standart [yazı tipi seçimi](/slides/tr/java/font-selection-sequence/) sürecine katılır; seçilen yazı tipi mevcut değilse, değiştirme veya yerine koyma uygulanır.

**Ne yazık ki hem değiştirme ne de yerine koyma yapılandırılmadı ve sistemde yazı tipi eksikse varsayılan davranış nedir?**

Kütüphane, PowerPoint'in davranışına benzer şekilde en yakın mevcut sistem yazı tipini seçmeye çalışır.

**Değiştirmeden kaçınmak için çalışma zamanında özel harici yazı tipleri ekleyebilir miyim?**

Evet. Çalışma zamanında [harici yazı tipleri ekleyebilir](/slides/tr/java/custom-font/) ve kütüphane bunları seçim ve renderlama için dikkate alır, sonraki dönüşümler için de geçerlidir.

**Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Aspose, ücretli ya da ücretsiz yazı tipleri dağıtmaz; yazı tiplerini kendi takdirinize ve sorumluluğunuza göre ekleyip kullanırsınız.

**Windows, Linux ve macOS'ta değiştirme davranışında farklılıklar var mı?**

Evet. Yazı tipi keşfi, işletim sisteminin yazı tipi dizinlerinden başlar. Varsayılan mevcut yazı tipleri ve arama yolları platformlar arasında farklılık gösterir; bu da erişilebilirliği ve değiştirme ihtiyacını etkiler.

**Toplu dönüşümler sırasında beklenmeyen değiştirmeleri en aza indirmek için ortamı nasıl hazırlamalıyım?**

Makineler veya konteynerler arasında yazı tipi setini senkronize edin, output belgeleri için gerekli [harici yazı tiplerini ekleyin](/slides/tr/java/custom-font/) ve mümkün olduğunda sunumlara [yazı tiplerini gömün](/slides/tr/java/embedded-font/) böylece seçilen yazı tipleri renderlama sırasında mevcut olur.