---
title: C++ Sunumlarında Yazı Tipi İkamesi Yapılandırma
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
description: "PowerPoint ve OpenDocument sunumlarını işleme veya dönüştürme sırasında C++ için Aspose.Slides'te yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum işlenirken veya dönüştürülürken erişilemeyen bir yazı tipi yerine kullanılabilir bir yazı tipini kullanmasını sağlar. İkame, işlenen çıktıyı etkiler; sunum içeriğine atanmış olan yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında hangi yazı tipinin kullanılacağını tanımlayabilir ve Aspose.Slides’in işleme sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

## **Yazı Tipi İkame Listeleme**

Sunum işlenirken hangi yazı tiplerinin ikame edileceğini belirlemek için [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getsubstitutions/) yöntemini kullanın. Yöntem, özgün ve ikame edilen yazı tipi adlarını belirten [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki C++ örneği bir sunum için tüm yazı tipi ikamelerini listeler:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Seçili Slaytlar İçin Yazı Tipi İkame Listeleme**

Belirli slaytların işlenmesi için gereken ikameleri yalnızca incelemek istediğinizde, `System::ArrayPtr<int32_t> slides` parametresiyle [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getsubstitutions/) aşırı yüklemesini kullanın. Bu, bir sunumun yalnız bir bölümünü işlerken, büyük bir sunumu kademeli olarak kontrol ederken, erişilemeyen yazı tiplerine bağlı slaytları bulurken, bir sunucu ya da konteyner için minimal bir yazı tipi paketi hazırlarken veya ilgili olmayan slaytları işlemeden işleme farklılıklarını teşhis ederken kullanışlıdır.

`slides` dizisi bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation::get_Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slide/) yöntemi sıfır‑tabanlı bir indeks kullanır; aynı slayta `presentation->get_Slide(0)` ile ulaşılır. Dizi oluştururken bu farkı göz önünde bulundurarak bir‑off‑by‑one hatası yapmamaya dikkat edin.

Aşırı yüklemeyi, [Presentation::get_FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/) yöntemi üzerinden çağırın. Yalnızca seçili slaytların işlenmesi sırasında belirlenen ikameleri döndürür. Her sonuç, özgün ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, geçerli yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını, bir [IFontSubstRuleCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kurallarını ve [dışarıdan yüklenen yazı tiplerini](/slides/tr/cpp/custom-font/) yansıtır.

Aynı ikame birden fazla seçili slayt tarafından istenebilir. Bir yazı tipi envanteri ya da ön‑uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, döndürülen her ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

[IFontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/) arabirimi her iki aşırı yüklemeyi de sağlar. İşleme kapsamına göre birini seçin:

| Aşırı Yükleme | Ne zaman kullanılır |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getsubstitutions/) parametresiz | Tüm sunum için ikameler gerektiyse. |
| [GetSubstitutions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getsubstitutions/) `System::ArrayPtr<int32_t> slides` ile | Seçili bir aralık, kademeli kontrol ya da kısmi dışa aktarma gerektiğinde. |

## **Yazı Tipi İkame Kurallarını Belirleme**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides’in hangi yazı tipini kullanması gerektiğini belirtmek için:

1. Sunumu yükleyin.  
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.  
3. [WhenInaccessible](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsubstcondition/) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsubstrule/) oluşturun.  
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsubstrulecollection/) içine ekleyin.  
5. Koleksiyonu, [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) yöntemiyle atayın.  
6. Sunumu işleyin veya dönüştürün.

Aşağıdaki C++ örneği, `SomeRareFont` kullanılamadığında `Arial` ile ikame eder ve ardından ilk slaytı işleyerek sonucu doğrular. İkame edilen yazı tipinin Aspose.Slides tarafından erişilebilir olması gerekir.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Tüm sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik yapmak için [Yazı Tipi Değiştirme](/slides/tr/cpp/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemleri Yazı Tipleri İçin Kısıtlamalar**

Yazı tipi ikame kuralları, işleme ve dönüştürme sırasında kullanılan standart yazı tipi seçme sürecinin bir parçasıdır. Aspose.Slides, bir kuralda belirtilen kullanılabilir bir yazı tipiyle erişilemeyen bir yazı tipini değiştirirken normal metin için çalışır.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides, denklem düzenini hesaplamak ve işlemek için o tam yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipine ikame eden bir kural, **Cambria Math**'i bu amaçla değiştiremez ve işleme hâlâ **Cambria Math**'in gerekli olduğunu bildirebilir.

Böyle bir sunumu işlemek veya dönüştürmek için **Cambria Math**'i Aspose.Slides’e sunun. İşletim sistemine kurun ya da bir [dış yazı tipi](/slides/tr/cpp/custom-font/) olarak yükleyin.

Bu sınırlama yalnızca denklem düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları hâlâ normal sunum metni için uygulanır.

## **SSS**

**Yazı tipi değiştirme ile ikame arasındaki fark nedir?**  
[Font replacement](/slides/tr/cpp/font-replacement/) tüm sunum boyunca bir yazı tipini kasıtlı olarak diğerine değiştirir. Yazı tipi ikamesi, özgün yazı tipi kullanılamadığında gibi yapılandırılmış bir koşul gerçekleştiğinde işlenen çıktının kullandığı bir yazı tipini seçer.

**İkame kuralları ne zaman uygulanır?**  
Kurallar, işleme ve dönüştürme sırasında [font selection sequence](/slides/tr/cpp/font-selection-sequence/) içinde yer alır. `WhenInaccessible` ile bir kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve ikame kuralı yapılandırılmadığında ne olur?**  
Aspose.Slides, font seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zaman ortamında bulunan yazı tiplerine bağlıdır.

**İkameyi önlemek için dış yazı tipleri yükleyebilir miyim?**  
Evet. [Load external fonts](/slides/tr/cpp/custom-font/) sayesinde Aspose.Slides, işleme ve dönüştürme sırasında bunları kullanabilir.

**Aspose, kütüphane ile birlikte yazı tiplerini dağıtıyor mu?**  
Hayır. Yazı tiplerini sağlayan ve lisanslarına uyan sizsiniz.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**  
Evet. Yüklenen yazı tipleri ve arama konumları işletim sistemine göre değişir; bir makinede bulunan bir yazı tipi başka birinde ikame gerektirebilir.

**Toplu dönüştürmelerde yazı tipi seçiminde tutarlılığı nasıl sağlayabilirim?**  
Tüm makine veya konteynerlerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli dış yazı tiplerini](/slides/tr/cpp/custom-font/) yükleyin ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/cpp/embedded-font/). Ayrıca, dışa aktarmadan önce beklenmeyen ikameleri tespit etmek için [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getsubstitutions/) yöntemini çağırabilirsiniz.