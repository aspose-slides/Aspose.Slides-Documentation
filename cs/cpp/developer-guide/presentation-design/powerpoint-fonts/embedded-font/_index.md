---
title: Vkládání písem do prezentací v C++
linktitle: Vložená písma
type: docs
weight: 40
url: /cs/cpp/embedded-font/
keywords:
- přidat písmo
- vložit písmo
- vkládání písem
- získat vložené písmo
- přidat vložené písmo
- odebrat vložené písmo
- komprimovat vložené písmo
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Spravujte vložená písma v PowerPointu pomocí Aspose.Slides pro C++. Přidávejte, načítejte, odebírejte a komprimujte písma, abyste zachovali vzhled textu a snížili velikost souboru."
---
## **Úvod**

Vkládání písem ukládá data písma uvnitř prezentace PowerPoint. Když prohlížeč podporuje vložená písma, může zobrazovat text s těmito písmy, i když nejsou nainstalována v cílovém systému. To pomáhá zachovat zalomení řádků, rozestupy textu a rozvržení snímků.

Aspose.Slides pro C++ umožňuje načíst, přidat a odebrat vložená písma pomocí [Presentation::get_FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/) metody třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Můžete také snížit velikost vložených dat písem odstraněním znaků, které prezentace nepoužívá.

Níže uvedené příklady pracují se soubory PPTX. Před vložením písma se ujistěte, že data písma jsou k dispozici pro Aspose.Slides a že licence umožňuje vkládání.

## **Získání a odebrání vložených písem**

Použijte [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) k výpisu písem uložených v prezentaci. Chcete‑li odebrat některé, předávejte písmo ze seznamu metodě [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), poté uložte prezentaci.

Následující příklad vypíše vložená písma v souboru `EmbeddedFonts.pptx` a odebere Calibri, pokud je přítomen:

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

Odebrání vloženého písma odstraní jeho uložená data; nezmění přiřazené písmo textu. Pokud je písmo nainstalováno v cílovém systému, text jej může i nadále používat. V opačném případě může být při vykreslování použita [náhrada písma](/slides/cs/cpp/font-substitution/), což může ovlivnit rozvržení.

## **Kontrola dat písma a oprávnění k vkládání**

Rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/) slouží ke kontrole písem před jejich vložením. Zavolejte [IFontsManager::GetFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getfonts/) a získáte písma použitá v prezentaci. Pro každé písmo předávejte objekt [IFontData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontdata/) a požadovanou hodnotu [FontStyleType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontstyletype/) metodě [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getfontbytes/). Metoda vrátí binární data pro daný styl písma nebo `nullptr`, pokud požadované písmo či styl není k dispozici. Výsledek `nullptr` nepředávejte metodě [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), protože tato metoda vyžaduje pole bajtů.

[EmbeddingLevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides/embeddinglevel/) je výčtová příznaková sada, která udává omezení vkládání uložená v písmu:

- `Installable` povoluje vkládání a trvalou instalaci na jiném systému, pokud to licence písma umožňuje.
- `Restricted` zakazuje vkládání, pokud není získáno povolení od právního vlastníka písma, a to v případě, že je to jediný příznak povolení používání.
- `PreviewPrint` povoluje dočasné použití pro prohlížení a tisk; dokument obsahující písmo musí být jen ke čtení.
- `Editable` povoluje dočasné použití a umožňuje dokument upravovat a ukládat.
- `NoSubsetting` je další omezení, které zakazuje vkládání jen podmnožiny glyfů. V takovém případě vložte všechny znaky.
- `BitmapOnly` je další omezení, které dovoluje vložit jen bitmapové údery, ne vektorová data. Pokud písmo nemá bitmapové údery, nelze jej vložit.

První čtyři hodnoty popisují oprávnění k používání, zatímco `NoSubsetting` a `BitmapOnly` lze kombinovat s nimi. Ověřte příznaky bitovými operacemi. Protože `Installable` má hodnotu nula, maskujte bity oprávnění k používání a porovnejte výsledek s `Installable`. Současná písma by měla nastavit nejvýše jeden bit oprávnění k používání. Pro kompatibilitu se staršími písmy, která nastavují více bitů, níže uvedený pomocník vybírá nejméně restriktivní oprávnění: `Editable`, poté `PreviewPrint`, poté `Restricted`.

Následující příklad audituje běžná, tučná, kurzívní a tučně‑kurzívní data dostupná pro každé písmo vrácené metodou `GetFonts`. Přeskakuje nedostupné styly, omezená písma, písma jen bitmapová, písma omezená na náhled a tisk, protože výstup zůstává editovatelný, a písma, která už jsou vložena. Pokud má kterýkoli dostupný styl příznak `NoSubsetting`, vloží všechny znaky pro danou rodinu písma.

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

Tato kontrola hlásí omezení zakódovaná v každém souboru písma. Neposkytuje licenci, neprokazuje, že jste písmo získali legálně, ani nenahrazuje kontrolu licenční smlouvy písma před distribuováním vložené kopie.

## **Přidání vložených písem**

Použijte [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/addembeddedfont/) k vložení písma. Jeho přetížení přijímají buď objekt [IFontData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontdata/), nebo pole bajtů obsahující data písma. Výčtová hodnota [EmbedFontCharacters](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/embedfontcharacters/) určuje, které znaky budou zahrnuty:

- [All](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/embedfontcharacters/) vloží všechny znaky písma. Použijte tuto možnost, když příjemci potřebují prezentaci upravovat a vkládat nový text.
- [OnlyUsed](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/embedfontcharacters/) vloží jen znaky použité v prezentaci, aby se snížila velikost souboru. Zvolte tuto možnost pro finální prezentaci, která je primárně určena ke sledování.

Následující příklad použije [IFontsManager::GetFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getfonts/) k získání písem použitých v souboru `Fonts.pptx` a vloží ta, která ještě nejsou vložena. Písma k přidání musí být k dispozici na počítači, na kterém běží kód. Existující vložená písma zachovají své aktuální sady znaků.

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

## **Komprese vložených písem**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) snižuje data vložených písem odstraněním nepoužitých znaků. Funguje na písmech, která jsou již vložena, takže míra úspory závisí na množství nevyužitých dat v prezentaci.

Následující příklad komprimuje písma v souboru `EmbeddedFonts.pptx` a výsledek uloží jako samostatný soubor:

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

Uchovejte původní soubor, pokud příjemci mohou později potřebovat přidávat text. Znaky odebrané během komprese už nebudou k dispozici z vloženého písma, i když jste původně vložili všechny znaky.

## **Často kladené otázky**

**Jak mohu zjistit, zda bude vložené písmo během vykreslování stále nahrazeno?**

Zavolejte [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getsubstitutions/) v prostředí, kde prezentaci vykreslujete, abyste viděli, která písma Aspose.Slides nahradí. Zkontrolujte také nastavení [náhrady písma](/slides/cs/cpp/font-substitution/) a pravidla [náhradního písma](/slides/cs/cpp/fallback-font/). Náhrada řeší chybějící znaky, takže vložení písma nevyřeší znaky, které samotné písmo neobsahuje.

**Mám vložit běžná písma jako Arial a Calibri?**

Rozhodnutí se odvíjí od cílového prostředí. Pokud jsou požadovaná písma k dispozici na každém počítači, který prezentaci otevírá nebo vykresluje, jejich vložení může jen zbytečně zvětšit velikost souboru. Pokud však příjemci nebo servery tato písma nemusí mít, vložení může pomoci zachovat zamýšlený vzhled, za předpokladu, že jejich licence to umožňuje.