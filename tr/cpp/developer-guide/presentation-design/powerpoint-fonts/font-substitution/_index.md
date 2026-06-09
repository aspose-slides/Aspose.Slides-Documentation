---
title: Sunumlarda C++ Kullanarak Yazı Tipi İkamesini Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/cpp/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipini değiştir
- yazı tipi değişimi
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını diğer dosya formatlarına dönüştürürken Aspose.Slides için C++'ta optimum yazı tipi ikamesini etkinleştirin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in orijinal sunum yazı tipi renderleme veya dönüştürme sırasında mevcut olmadığında başka bir yazı tipi kullanmasını sağlar. `IFontsManager` arayüzündeki `GetSubstitutions` yöntemini kullanarak hangi yazı tiplerinin ikame edildiğini kontrol edebilirsiniz.

Aspose.Slides ayrıca yazı tipi ikame kuralları tanımlamanıza olanak tanır. Örneğin, erişilemeyen bir yazı tipinin başka bir mevcut yazı tipiyle değiştirilmesini belirtebilir ve bu kuralları sunumun yazı tipi yöneticisi aracılığıyla uygulayabilirsiniz.

## **Yazı Tipi İkame Kurallarını Ayarlama**

Aspose.Slides, belirli koşullarda (örneğin, bir yazı tipine erişilemediğinde) ne yapılması gerektiğini belirleyen yazı tipleri için kurallar ayarlamanıza izin verir:

1. İlgili sunumu yükleyin.
2. Değiştirilecek yazı tipini yükleyin.
3. Yeni yazı tipini yükleyin.
4. Değiştirme için bir kural ekleyin.
5. Kuralı sunumun yazı tipi değiştirme kuralı koleksiyonuna ekleyin.
6. Etkiyi gözlemlemek için slayt resmini oluşturun.

Bu C++ kodu, yazı tipi ikame sürecini göstermektedir:

```c++
// Belgeler dizini yolu.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Bir sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Değiştirilecek yazı tipini ve yeni yazı tipini tanımlar
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Yazı tipi değişimi için bir kural ekler
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Kuralı yazı tipi ikame kuralları koleksiyonuna ekler
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Yazı tipi kural koleksiyonunu kural listesine ekler
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// PPTX'i diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Şu sayfayı görmek isteyebilirsiniz [**Font Replacement**](/slides/tr/cpp/font-replacement/). 
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri için Sınırlamalar**

Yazı tipi ikame kuralları, renderleme ve dönüştürme sırasında kullanılan standart yazı tipi seçim sürecine katılır. Yapılandırılmış kurala göre Aspose.Slides'in erişilemeyen bir yazı tipini başka bir mevcut yazı tipiyle değiştirebildiği normal metin senaryoları için uygundur.

Bununla birlikte, Office matematik denklemlerinin önemli bir sınırlaması vardır. Bir denklem **Cambria Math** ile oluşturulmuşsa, Aspose.Slides doğru şekilde denklem yerleşimini hesaplamak ve renderlemek için hâlâ orijinal **Cambria Math** yazı tipine ihtiyaç duyabilir. Bu nedenle, **Cambria Math**'ı **STIX Two Math** gibi başka bir matematik yazı tipiyle ikame etmek, denklem renderlemesi için desteklenmez ve hâlâ **Cambria Math**'ın gerekli olduğunu belirten bir istisna ile sonuçlanabilir.

Bu tür sunumları başarılı bir şekilde dönüştürmek için, **Cambria Math**'ın çalışma zamanında Aspose.Slides tarafından erişilebilir olduğundan emin olun. Yazı tipini işletim sistemine kurabilir veya [external font](/slides/tr/cpp/custom-font/) olarak sağlayabilirsiniz; böylece renderleme ve dönüştürme sırasında normal yazı tipi seçim sürecine katılabilir.

Bu sınırlama özel olarak denklem renderlemesiyle ilgilidir. Yukarıda açıklanan standart yazı tipi ikame kuralları, orijinal yazı tipi erişilemez olduğunda normal sunum metnine hâlâ uygulanır.

## **FAQ**

**Yazı tipi değiştirme ile yazı tipi ikamesi arasındaki fark nedir?**

[Replacement](/slides/tr/cpp/font-replacement/) tüm sunum boyunca bir yazı tipinin başka bir yazı tipiyle zorunlu olarak değiştirilmesidir. İkame ise belirli bir koşulda (örneğin orijinal yazı tipi mevcut olmadığında) tetiklenen ve atanan bir yedek yazı tipinin kullanıldığı bir kuraldır.

**İkame kuralları tam olarak ne zaman uygulanır?**

Kurallar, yükleme, renderleme ve dönüştürme sırasında değerlendirilen standart [font selection](/slides/tr/cpp/font-selection-sequence/) sırasına katılır; seçilen yazı tipi mevcut değilse, değiştirme veya ikame uygulanır.

**Ne replacement ne de substitution yapılandırılmadığında ve sistemde yazı tipi eksik olduğunda varsayılan davranış nedir?**

Kütüphane, PowerPoint'in davranışına benzer şekilde en yakın mevcut sistem yazı tipini seçmeye çalışacaktır.

**İkameyi önlemek için çalışma zamanında özel dış yazı tipleri ekleyebilir miyim?**

Evet. Çalışma zamanında [add external fonts](/slides/tr/cpp/custom-font/) ekleyerek kütüphanenin seçim ve renderleme sırasında, sonraki dönüştürmeler için de dahil olmak üzere, bu yazı tiplerini göz önünde bulundurmasını sağlayabilirsiniz.

**Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Aspose, ücretli ya da ücretsiz yazı tipleri dağıtmaz; yazı tiplerini kendi takdirinize ve sorumluluğunuza göre eklersiniz ve kullanırsınız.

**Windows, Linux ve macOS'ta ikame davranışında farklılıklar var mı?**

Evet. Yazı tipi keşfi işletim sisteminin yazı tipi dizinlerinden başlar. Varsayılan mevcut yazı tiplerinin seti ve arama yolları platformlar arasında farklılık gösterir; bu da erişilebilirliği ve ikame ihtiyacını etkiler.

**Toplu dönüştürmeler sırasında beklenmeyen ikameleri en aza indirmek için ortamı nasıl hazırlamalıyım?**

Makine veya konteynerler arasında yazı tipi setini senkronize edin, çıktı belgeleri için gerekli olan [add the external fonts](/slides/tr/cpp/custom-font/) ekleyin ve mümkün olduğunda sunumlara [embed fonts](/slides/tr/cpp/embedded-font/) yerleştirerek seçilen yazı tiplerinin renderleme sırasında mevcut olmasını sağlayın.