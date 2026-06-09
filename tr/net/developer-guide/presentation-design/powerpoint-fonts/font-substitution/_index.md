---
title: .NET'te Sunumlarda Yazı Tipi Değiştirmeyi Yapılandırma
linktitle: Yazı Tipi Değiştirme
type: docs
weight: 70
url: /tr/net/font-substitution/
keywords:
- yazı tipi
- yazı tipi değiştirme
- yazı tipi değişimi
- yazı tipi değiştirme
- yazı tipi yerine koyma
- değiştirme kuralı
- yerine koyma kuralı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını diğer dosya formatlarına dönüştürürken Aspose.Slides for .NET içinde optimal yazı tipi değişimini etkinleştirin."
---
## **Genel Bakış**

Yazı tipi değiştirme, Aspose.Slides'in, özgün sunum yazı tipi oluşturma veya dönüştürme sırasında mevcut olmadığında başka bir yazı tipini kullanmasını sağlar. Hangi yazı tiplerinin değiştirildiğini, `IFontsManager` arayüzündeki `GetSubstitutions` yöntemiyle kontrol edebilirsiniz.

Aspose.Slides ayrıca yazı tipi değiştirme kurallarını tanımlamanıza olanak verir. Örneğin, erişilemeyen bir yazı tipinin başka bir mevcut yazı tipiyle değiştirilmesini belirtebilir ve ardından bu kuralları sunumun yazı tipi yöneticisi aracılığıyla uygulayabilirsiniz.

## **Yazı Tipi Değiştirmeleri Al**

Sunum oluşturma sürecinde değiştirilen sunum yazı tiplerini öğrenebilmeniz için, Aspose.Slides [GetSubstitution](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getsubstitutions/) yöntemini [IFontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontsmanager/) arayüzünden sağlar.

C# kodu, bir sunum render edildiğinde gerçekleştirilen tüm yazı tipi değiştirilmelerini nasıl alacağınızı gösterir:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Yazı Tipi Değiştirme Kurallarını Ayarla**

Aspose.Slides, belirli koşullarda (örneğin bir yazı tipine erişilemediğinde) ne yapılması gerektiğini belirleyen yazı tipleri için kurallar ayarlamanıza şu şekilde izin verir:

1. İlgili sunumu yükleyin.
2. Değiştirilecek yazı tipini yükleyin.
3. Yeni yazı tipini yükleyin.
4. Değiştirme için bir kural ekleyin.
5. Kuralı sunum yazı tipi değiştirme kuralı koleksiyonuna ekleyin.
6. Etkiyi gözlemlemek için slayt resmini oluşturun.

Bu C# kodu, yazı tipi değiştirme sürecini gösterir:
```c#
// Sunumu yükler
Presentation presentation = new Presentation("Fonts.pptx");

// Değiştirilecek kaynak yazı tipini yükler
IFontData sourceFont = new FontData("SomeRareFont");

// Yeni yazı tipini yükler
IFontData destFont = new FontData("Arial");

// Yazı tipi değiştirme için bir kural ekler
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Kuralı yazı tipi değiştirme kuralları koleksiyonuna ekler
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Yazı tipi kural koleksiyonunu kural listesine ekler
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Görüntüyü JPEG formatında diske kaydeder
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOT"  color="warning"   %}} 
[**Yazı Tipi Değiştirme**](/slides/tr/net/font-replacement/) 
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi değiştirme kuralları, render ve dönüştürme sırasında kullanılan standart yazı tipi seçim sürecine katılır. Aspose.Slides'in, yapılandırılmış kurala göre erişilemeyen bir yazı tipini başka bir mevcut yazı tipiyle değiştirebildiği normal metin senaryoları için uygundur.

Bununla birlikte, Office matematik denklemlerinin önemli bir sınırlaması vardır. Bir denklem **Cambria Math** ile oluşturulmuşsa, Aspose.Slides denklemin düzenini doğru şekilde hesaplamak ve render etmek için hâlâ özgün **Cambria Math** yazı tipine ihtiyaç duyabilir. Bu nedenle, **Cambria Math**'ı **STIX Two Math** gibi başka bir matematik yazı tipiyle değiştirmek, denklem render'ı için desteklenmez ve hâlâ **Cambria Math**'ın gerekli olduğunu belirten bir istisna ile sonuçlanabilir.

Bu tür sunumları başarılı bir şekilde dönüştürmek için, **Cambria Math**'ın çalışma zamanında Aspose.Slides tarafından erişilebilir olduğundan emin olun. Yazı tipini işletim sistemine kurabilir veya [harici yazı tipi](/slides/tr/net/custom-font/) olarak sağlayabilirsiniz, böylece render ve dönüştürme sırasında normal yazı tipi seçim sürecine katılabilir.

Bu sınırlama yalnızca denklem render'ı için özeldir. Yukarıda açıklanan standart yazı tipi değiştirme kuralları, özgün yazı tipi erişilemez olduğunda normal sunum metnine hâlâ uygulanır.

## **SSS**

**Yazı tipi değiştirme ile yazı tipi substitüsyonu arasındaki fark nedir?**

[Değiştirme](/slides/tr/net/font-replacement/) tüm sunum boyunca bir yazı tipinin başka bir yazı tipine zorunlu olarak geçersiz kılınmasıdır. Substitisyon ise belirli bir koşulda (örneğin özgün yazı tipi mevcut olmadığında) tetiklenen ve belirlenmiş bir yedek yazı tipinin kullanıldığı bir kuruldur.

**Substitisyon kuralları tam olarak ne zaman uygulanır?**

Kurallar, yükleme, render ve dönüştürme sırasında değerlendirilen standart [yazı tipi seçimi](/slides/tr/net/font-selection-sequence/) dizisine katılır; seçilen yazı tipi mevcut değilse, değiştirme veya substitisyon uygulanır.

**Ne değiştirme ne de substitisyon yapılandırılmamış ve sistemde yazı tipi eksikse varsayılan davranış nedir?**

Kütüphane, PowerPoint'in davranışına benzer şekilde, en yakın mevcut sistem yazı tipini seçmeye çalışır.

**Runtime'da özelleştirilmiş harici yazı tipleri ekleyerek substitisyonu önleyebilir miyim?**

Evet. Çalışma zamanında [harici yazı tiplerini ekleyin](/slides/tr/net/custom-font/) ve kütüphane bunları seçim ve render için, sonraki dönüşümler dahil, değerlendirebilir.

**Aspose kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Aspose ücretli veya ücretsiz yazı tipleri dağıtmaz; yazı tiplerini kendi takdirinize ve sorumluluğunuza göre eklersiniz ve kullanırsınız.

**Windows, Linux ve macOS'ta substitisyon davranışında farklılıklar var mı?**

Evet. Yazı tipi keşfi, işletim sisteminin yazı tipi dizinlerinden başlar. Varsayılan mevcut yazı tipleri kümesi ve arama yolları platformlar arasında farklılık gösterir; bu da kullanılabilirliği ve substitisyon ihtiyacını etkiler.

**Toplu dönüşümler sırasında beklenmeyen substitisyonu en aza indirmek için ortamı nasıl hazırlamalıyım?**

Makine veya konteynerler arasında yazı tipi setini senkronize edin, çıktı belgeleri için gerekli [harici yazı tiplerini ekleyin](/slides/tr/net/custom-font/) ve mümkün olduğunda sunumlara [yazı tiplerini gömmek](/slides/tr/net/embedded-font/) sağlayın; böylece seçilen yazı tipleri render sırasında mevcut olur.