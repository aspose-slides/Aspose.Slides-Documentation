---
title: C++ Kullanarak Sunumlarda Yazı Tipi İkamesini Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/cpp/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipi değiştirme
- yazı tipi değiştirme
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını diğer dosya formatlarına dönüştürürken C++ için Aspose.Slides'de optimal yazı tipi ikamesini etkinleştirin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in orijinal sunum yazı tipi renderleme veya dönüştürme sırasında bulunamadığında başka bir yazı tipi kullanmasını sağlar. `IFontsManager` arayüzündeki `GetSubstitutions` metodunu kullanarak hangi yazı tiplerinin ikame edildiğini kontrol edebilirsiniz.

Aspose.Slides ayrıca yazı tipi ikame kuralları tanımlamanıza izin verir. Örneğin, erişilemeyen bir yazı tipinin başka bir kullanılabilir yazı tipiyle değiştirilmesi gerektiğini belirtebilir ve bu kuralları sunumun yazı tipi yöneticisi aracılığıyla uygulayabilirsiniz.

## **Yazı Tipi İkame Kurallarını Belirleme**

Aspose.Slides, belirli koşullarda (örneğin bir yazı tipine erişilemediğinde) ne yapılması gerektiğini belirleyen kuralları şu şekilde ayarlamanıza olanak tanır:

1. İlgili sunumu yükleyin.
2. Değiştirilecek yazı tipini yükleyin.
3. Yeni yazı tipini yükleyin.
4. Değiştirme için bir kural ekleyin.
5. Kuralı sunumun yazı tipi değiştirme kural koleksiyonuna ekleyin.
6. Etkiyi gözlemlemek için slayt görüntüsü oluşturun.

Bu C++ kodu, yazı tipi ikame sürecini gösterir:

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Bir sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Değiştirilecek yazı tipini ve yeni yazı tipini tanımlar
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Yazı tipi değiştirme için bir kural ekler
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Kuralı yazı tipi ikame kuralları koleksiyonuna ekler
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Yazı tipi kural koleksiyonunu kural listesine ekler
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// PPTX dosyasını diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
İlgileniyorsanız [**Yazı Tipi Değiştirme**](/slides/tr/cpp/font-replacement/) sayfasına bakabilirsiniz. 
{{% /alert %}}

## **Matematik Denklemleri Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, renderleme ve dönüştürme sırasında kullanılan standart yazı tipi seçim sürecine katılır. Aspose.Slides'in yapılandırılmış kurala göre erişilemeyen bir yazı tipini başka bir kullanılabilir yazı tipine değiştirebildiği normal metin senaryoları için uygundur.

Ancak Office matematik denklemleri önemli bir sınırlamaya sahiptir. Bir denklem **Cambria Math** ile oluşturulmuşsa, Aspose.Slides denklemin yerleşimini doğru bir şekilde hesaplamak ve renderlemek için hâlâ orijinal **Cambria Math** yazı tipine ihtiyaç duyabilir. Bu nedenle **Cambria Math**'ı **STIX Two Math** gibi başka bir matematik yazı tipiyle ikame etmek, denklem renderlemesi için desteklenmez ve **Cambria Math** gerektirdiğine dair bir istisna ortaya çıkabilir.

Bu tür sunumları başarıyla dönüştürmek için, çalışma zamanında **Cambria Math**'ın Aspose.Slides tarafından erişilebilir olduğundan emin olun. Yazı tipini işletim sistemine kurabilir veya bir [harici yazı tipi](/slides/tr/cpp/custom-font/) olarak sağlayarak renderleme ve dönüştürme sırasında normal yazı tipi seçim sürecine katılmasını sağlayabilirsiniz.

Bu sınırlama yalnızca denklem renderlemesi için geçerlidir. Yukarıda açıklanan standart yazı tipi ikame kuralları, orijinal yazı tipi erişilemediğinde normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değiştirme ile ikame arasındaki fark nedir?**

[Değiştirme](/slides/tr/cpp/font-replacement/) tüm sunum boyunca bir yazı tipinin başka bir yazı tipiyle zorla değiştirilmesidir. İkame ise belirli bir koşul altında (örneğin orijinal yazı tipi mevcut olmadığında) devreye giren ve belirlenmiş bir yedek yazı tipinin kullanıldığı bir kuraldır.

**İkame kuralları tam olarak ne zaman uygulanır?**

Kurallar, yükleme, renderleme ve dönüştürme sırasında değerlendirilen standart [yazı tipi seçimi](/slides/tr/cpp/font-selection-sequence/) sürecine katılır; seçilen yazı tipi mevcut değilse değiştirme veya ikame uygulanır.

**Ne yazı tipi ne değiştirme ne de ikame yapılandırılmamış ve sistemde yazı tipi eksikse varsayılan davranış nedir?**

Kütüphane, PowerPoint'in davranışına benzer şekilde, en yakın mevcut sistem yazı tipini seçmeye çalışır.

**İkameyi önlemek için çalışma zamanında özel harici yazı tipleri ekleyebilir miyim?**

Evet. Çalışma zamanında [harici yazı tipleri ekleyebilir](/slides/tr/cpp/custom-font/) ve kütüphane bunları seçim ve renderleme için, sonraki dönüştürmeler dahil, dikkate alır.

**Aspose kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Aspose, ücretli veya ücretsiz yazı tipleri dağıtmaz; yazı tiplerini kendi takdiriniz ve sorumluluğunuz dahilinde ekler ve kullanırsınız.

**Windows, Linux ve macOS üzerinde ikame davranışında farklılıklar var mı?**

Evet. Yazı tipi keşfi, işletim sisteminin yazı tipi dizinlerinden başlar. Varsayılan olarak mevcut olan yazı tipleri ve arama yolları platformlar arasında farklılık gösterir; bu da kullanılabilirliği ve ikame ihtiyacını etkiler.

**Toplu dönüştürmeler sırasında beklenmedik ikameleri en aza indirmek için ortamı nasıl hazırlamalıyım?**

Makineler veya konteynerler arasında yazı tipi setini senkronize edin, çıkış belgeleri için gerekli [harici yazı tiplerini ekleyin](/slides/tr/cpp/custom-font/) ve mümkün olduğunda sunumlara [yazı tiplerini gömün](/slides/tr/cpp/embedded-font/) böylece renderleme sırasında seçilen yazı tipleri mevcut olur.