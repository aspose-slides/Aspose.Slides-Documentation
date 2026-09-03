---
title: C++'da Sunumlarda Yazı Tiplerini Gömme
linktitle: Gömülü Yazı Tipleri
type: docs
weight: 40
url: /tr/cpp/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi gömme
- font gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint'te gömülü yazı tiplerini yönetin. Yazı tiplerini ekleyin, alın, kaldırın ve sıkıştırın; metin görünümünü koruyun ve dosya boyutunu küçültün."
---
## **Giriş**

Gömülü yazı tipleri, font verilerini bir PowerPoint sunumunun içine kaydeder. Görüntüleyici gömülü yazı tiplerini desteklediğinde, bu yazı tipleri hedef sistemde yüklü olmasa bile metni bu fontlarla gösterebilir. Bu, satır sonları, metin aralığı ve slayt düzeninin korunmasına yardımcı olur.

Aspose.Slides for C++ , bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesinin [Presentation::get_FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/) yöntemi aracılığıyla gömülü yazı tiplerini almanıza, eklemenize ve kaldırmanıza olanak tanır. Ayrıca, sunumun kullanılmayan karakterleri kaldırarak gömülü font verisinin boyutunu azaltabilirsiniz.

Aşağıdaki örnekler PPTX dosyalarıyla çalışır. Bir yazı tipini gömmeden önce, font verisinin Aspose.Slides tarafından erişilebilir olduğundan ve lisansınızın gömme izni verdiğinden emin olun.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

Sunumda depolanan yazı tiplerini listelemek için [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) kullanın. Birini kaldırmak için listeden bir yazı tipini [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/removeembeddedfont/) yöntemine gönderin ve ardından sunumu kaydedin.

Aşağıdaki örnek, `EmbeddedFonts.pptx` dosyasındaki gömülü yazı tiplerini listeler ve Calibri mevcutsa kaldırır:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Bir gömülü yazı tipini kaldırmak, saklanan font verisini siler; metne atanan yazı tipini değiştirmez. Yazı tipi hedef sistemde yüklüyse, metin hâlâ bu fontu kullanabilir. Aksi takdirde, [font substitution](/slides/tr/cpp/font-substitution/) gerekebilir ve bu durum düzeni etkileyebilir.

## **Yazı Tipi Verisini ve Gömme İzinlerini İncele**

Yazı tiplerini gömmeden önce incelemek için [IFontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/) arayüzünü kullanın. Sunumda kullanılan yazı tiplerini almak için [IFontsManager::GetFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getfonts/) çağırın. Her bir yazı tipi için bir [IFontData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontdata/) nesnesi ve gerekli [FontStyleType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontstyletype/) değeri ile [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getfontbytes/) yöntemini çağırın. Bu yöntem, ilgili font stilinin ikili verisini döndürür; istenen font ya da stil bulunamazsa `nullptr` döner. `nullptr` sonucunu [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/) yöntemine göndermeyin, çünkü bu yöntem bir bayt dizisi bekler.

[EmbeddingLevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides/embeddinglevel/) bir bayrak (flags) tanımıdır ve fontta saklanan gömme kısıtlamalarını raporlar:

- `Installable` başka bir sistemde kalıcı olarak kurulmasına ve gömülmesine izin verir; bu, font lisansına tabidir.
- `Restricted` yalnızca tek kullanım izni bayrağı olduğunda, fontun yasal sahibinden izin alınmadıkça gömülmesini yasaklar.
- `PreviewPrint` geçici olarak görüntüleme ve yazdırma için kullanılmasına izin verir; fontu içeren belge yalnızca okuma‑yazma korumalı olmalıdır.
- `Editable` geçici kullanım ve belgenin düzenlenip kaydedilmesine izin verir.
- `NoSubsetting` yalnızca bir alt küme karakterin gömülmesini yasaklayan ek bir kısıtlamadır. Bu bayrak varsa tüm karakterler gömülmelidir.
- `BitmapOnly` yalnızca bitmap vuruşlarının gömülmesine izin veren, kontür (outline) verisinin gömülmesini engelleyen bir ek kısıtlamadır. Fontta bitmap vuruşları yoksa gömülemez.

İlk dört değer kullanım iznini tanımlarken, `NoSubsetting` ve `BitmapOnly` bunlarla birleştirilebilir. Bit düzeyinde işlemlerle değiştiricileri kontrol edin. `Installable` değeri sıfır olduğu için, kullanım‑izin bitlerini maskeleyip sonucu `Installable` ile karşılaştırın. Güncel fontlar en fazla bir kullanım‑izin biti ayarlamalıdır. Daha eski fontların birden çok izin biti ayarladığı durumlar için aşağıdaki yardımcı yöntem en az kısıtlayıcı izni seçer: `Editable`, ardından `PreviewPrint`, ardından `Restricted`.

Aşağıdaki örnek, `GetFonts` tarafından döndürülen her font için normal, kalın, italik ve kalın‑italik verilerini denetler. Kullanılamayan stilleri, kısıtlı fontları, yalnızca bitmap olanları, yalnızca ön izleme‑yazdırma izni olanları (çünkü çıktı hâlâ düzenlenebilir) ve zaten gömülü olanları atlar. Herhangi bir kullanılabilir stil `NoSubsetting` içeriyorsa, o font ailesi için tüm karakterler gömülür:

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bu inceleme, her font dosyasına kodlanmış kısıtlamaları raporlar. Bir lisans sağlamaz, fontun yasal olarak elde edildiğini kanıtlamaz veya gömülü bir kopyayı dağıtmadan önce font lisans anlaşmasını kontrol etmenizi yerine geçmez.

## **Gömülü Yazı Tipi Ekle**

Bir fontu gömmek için [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/addembeddedfont/) yöntemini kullanın. Aşırı yüklemeleri, bir [IFontData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontdata/) nesnesi ya da font verisini içeren bir bayt dizisi kabul eder. [EmbedFontCharacters](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/embedfontcharacters/) enum’u, hangi karakterlerin dahil edileceğini belirler:

- [All](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/embedfontcharacters/) fonttaki tüm karakterleri gömer. Alıcıların sunumu düzenlemesi ve yeni metin eklemesi gerektiğinde bu seçeneği kullanın.
- [OnlyUsed](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/embedfontcharacters/) yalnızca sunumda kullanılan karakterleri gömer ve dosya boyutunu küçültür. Bitmiş ve öncelikli olarak görüntülenmesi amaçlanan bir sunum için bu seçeneği tercih edin.

Aşağıdaki örnek, `Fonts.pptx` dosyasında kullanılan fontları almak için [IFontsManager::GetFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getfonts/) yöntemini kullanır ve hâlâ gömülmemiş olanları gömer. Eklenecek fontların kodun çalıştığı makinede bulunması gerekir. Mevcut gömülü fontlar karakter setlerini korur:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gömülü Yazı Tiplerini Sıkıştır**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) yöntemi, kullanılmayan karakterleri kaldırarak gömülü font verisinin boyutunu azaltır. Bu yöntem zaten gömülü fontlar üzerinde çalışır; dolayısıyla boyut azalması, sunumda ne kadar kullanılmayan font verisi olduğuna bağlıdır.

Aşağıdaki örnek, `EmbeddedFonts.pptx` içindeki fontları sıkıştırır ve sonucu ayrı bir dosya olarak kaydeder:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Alıcıların daha sonra metin eklemesi ihtimaline karşı orijinal dosyayı saklayın. Sıkıştırma sırasında kaldırılan karakterler, gömülü fonttan artık elde edilemez, hatta başlangıçta tüm karakterler gömülmüş olsa bile.

## **SSS**

**Bir gömülü fontun render sırasında hâlâ değiştirileceğini nasıl kontrol edebilirim?**

Sunumu render ettiğiniz ortamda [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontsmanager/getsubstitutions/) yöntemini çağırarak Aspose.Slides’ın hangi fontları değiştireceğini görebilirsiniz. Ayrıca [font substitution](/slides/tr/cpp/font-substitution/) ayarlarını ve [font fallback](/slides/tr/cpp/fallback-font/) kurallarını kontrol edin. Fallback, eksik karakterleri ele alır; dolayısıyla bir fontu gömmek, fontun kendisinde bulunmayan karakterleri çözmez.