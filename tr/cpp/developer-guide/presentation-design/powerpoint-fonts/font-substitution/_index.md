---
title: C++ Sunumlarında Yazı Tipi İkamesini Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/cpp/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipini değiştirme
- yazı tipi değiştirme
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını render ederken veya dönüştürürken, C++ için Aspose.Slides içinde yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'ın bir sunum render edilip dönüştürülürken erişilemeyen bir yazı tipinin yerine mevcut bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi kullanılamadığında hangi yazı tipinin kullanılacağını tanımlayabilir ve Aspose.Slides'ın render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlarda çıktının tutarlı kalmasına yardımcı olur.

Bir yazı tipi mevcut ancak özel bir kalın (bold) yüzeye sahip değilse, [Özel Kalın Yazı Tipi Olmayan Yazı Tiplerini Ele Al](/slides/tr/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) bölümüne bakın. Bu bölüm, PDF dışa aktarımı sırasında etkilenen metnin rasterleştirilmesi ve metin seçimi, arama ve ölçeklendirme üzerindeki sonuçlarını açıklar.

## **Yazı Tipi İkame Listesini Al**

[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) yöntemi, sunum render edildiğinde hangi yazı tiplerinin ikame edileceğini belirlemenizi sağlar. Yöntem, orijinal ve ikame yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki C++ örneği, bir sunum için tüm yazı tipi ikamelerini listeler:

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

## **Seçili Slaytlar İçin Yazı Tipi İkame Listesini Al**

[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) metodunu `System::ArrayPtr<int32_t> slides` bağımsız değişkeniyle birlikte kullanarak yalnızca belirli slaytların render edilmesi için gereken ikameleri inceleyebilirsiniz. Bu, bir sunumun yalnızca bir bölümünü render ya da dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, kullanılamayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu ya da konteyner için minimal bir yazı tipi paketi hazırlarken ya da ilgisiz slaytları işlemeye gerek kalmadan render farklılıklarını teşhis ederken faydalıdır.

`slides` dizisi, bir‑bazlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) yöntemi sıfır‑bazlı bir indeks kullanır; aynı slayt `presentation->get_Slide(0)` ile erişilir. Dizi oluştururken bu farkı akılda tutarak bir‑off‑by‑one hatasından kaçının.

Bu aşırı yüklemeyi, [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) yöntemi üzerinden çağırın. Yöntem, yalnızca seçili slaytlar render edilirken belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, mevcut yazı tipi ortamını, yapılandırılmış yedekleme kurallarını, bir [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/) içinde depolanan ikame kurallarını ve [harici yüklenen yazı tiplerini](/slides/tr/cpp/custom-font/) yansıtır.

Aynı ikame birden fazla seçili slayt tarafından istenebilir. Bir yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, döndürülen her ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

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

[IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) arabirimi her iki aşırı yüklemeyi de sağlar. Render işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Ne zaman kullanılır |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) bağımsız değişken olmadan | Tüm sunum için ikameler gerekirken. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) `System::ArrayPtr<int32_t> slides` ile | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım gerektiğinde. |

## **Yazı Tipi İkame Kurallarını Ayarla**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides'ın hangi yazı tipini kullanacağını belirtmek için:

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için tanımlar oluşturun.
3. [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/) içine ekleyin.
5. Koleksiyonu, [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) yöntemiyle atayın.
6. Sunumu render edin veya dönüştürün.

Aşağıdaki C++ örneği, `SomeRareFont` kullanılamadığında `Arial` yazı tipini ikame eder ve ardından sonucu doğrulamak için ilk slaytı render eder. İkame yazı tipi Aspose.Slides tarafından erişilebilir olmalıdır.

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
Sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için [Yazı Tipi Değiştirme](/slides/tr/cpp/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Aspose.Slides bir erişilemeyen yazı tipini kuralda belirtilen mevcut bir yazı tipiyle değiştirebildiğinde normal metin için çalışırlar.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides bu denklemin yerleşimini hesaplamak ve render etmek için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipine ikame eden bir kural, bu amaç için **Cambria Math**'i değiştiremez ve render hâlâ **Cambria Math**'in gerekli olduğunu bildirebilir.

Böyle bir sunumu render ya da dönüştürmek için **Cambria Math**'i Aspose.Slides'a erişilebilir hâle getirin. İşletim sistemine kurun veya bir [harici yazı tipi](/slides/tr/cpp/custom-font/) olarak yükleyin.

Bu sınırlama sadece denklem yerleşimini kapsar. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değiştirme ile ikame arasındaki fark nedir?**

[Font replacement](/slides/tr/cpp/font-replacement/) sunum boyunca bir yazı tipini diğerine kasıtlı olarak değiştirir. Yazı tipi ikamesi, yapılandırılan koşul sağlandığında (örneğin, orijinal yazı tipi kullanılamadığında) render edilen çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, render ve dönüşüm sırasında [font selection sequence](/slides/tr/cpp/font-selection-sequence/) içinde yer alır. `WhenInaccessible` ile bir kural, Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve ikame kuralı yapılandırılmadığında ne olur?**

Aspose.Slides, font seçme sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zaman ortamında mevcut olan yazı tiplerine bağlıdır.

**İkameyi önlemek için harici yazı tipleri yükleyebilir miyim?**

Evet. Aspose.Slides'ın render ve dönüşüm sırasında kullanabilmesi için [harici yazı tipleri yükleyebilirsiniz](/slides/tr/cpp/custom-font/).

**Aspose kütüphane ile birlikte yazı tipleri dağıtıyor mu?**

Hayır. Yazı tiplerini siz temin etmek ve lisans şartlarına uymakla sorumlusunuz.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir yazı tipi başka bir makinede ikame gerektirebilir.

**Toplu dönüşümlerde font seçimini nasıl tutarlı hâle getirebilirim?**

Her makine ya da konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli harici yazı tiplerini yükleyin](/slides/tr/cpp/custom-font/) ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/cpp/embedded-font/). Ayrıca dışa aktarmadan önce beklenmeyen ikameleri belirlemek için [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) çağırabilirsiniz.