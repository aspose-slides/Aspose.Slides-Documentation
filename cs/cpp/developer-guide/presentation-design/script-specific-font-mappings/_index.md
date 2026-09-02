---
title: Správa skriptově specifických písem tématu v C++
linktitle: Skriptem specifická písma tématu
type: docs
weight: 15
url: /cs/cpp/script-specific-font-mappings/
keywords:
- skriptově specifické písmo
- mapování tématických písem
- vícejazyčná prezentace
- psací systém
- cyrilické písmo
- arabské písmo
- japonské písmo
- gruzínské písmo
- thaana písmo
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Prohlédněte, přidejte, nahraďte a odstraňte skriptově specifická mapování písem v tématech PowerPointu pomocí Aspose.Slides pro C++."
---
## **Přehled**

Téma prezentace může vybrat různé rodiny písem pro různé psací systémy. To umožňuje vícejazyčný text, který stále používá písma tématu, aby sledoval jednotné schéma písem a zároveň používal vhodná písma pro cyriliku, arabštinu, japonštinu, georgštinu, thaana a další skripty.

Téma obsahuje hlavní kolekci písem, obvykle používanou pro nadpisy, a vedlejší kolekci písem, obvykle používanou pro tělo textu. Kromě jejich latinských a východoasijských vlastností poskytují obě kolekce mapování od značek psacích systémů k názvům rodin písem přes rozhraní [IFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifonts/).

Tento článek ukazuje, jak zkontrolovat a upravit tato mapování v hlavním tématu prezentace a ověřit, že změny přežijí cyklus uložení a načtení.

## **Pochopení značek skriptů**

Metody písma skriptu používají čtyřpísmenné podznačky BCP 47 k identifikaci psacích systémů. Běžné hodnoty zahrnují:

| Značka skriptu | Systém psaní |
|---|---|
| `Cyrl` | Cyrilice |
| `Arab` | Arabština |
| `Hans` | Zjednodušená čínština |
| `Jpan` | Japonština |
| `Geor` | Gruzínština |
| `Thaa` | Thaana |

## **Přístup a kontrola mapování písem skriptů**

Použijte [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_mastertheme/) k přístupu k tématu na úrovni prezentace. Metody [FontScheme::get_Major](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/fontscheme/get_major/) a [FontScheme::get_Minor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/fontscheme/get_minor/) vrací dvě kolekce [IFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifonts/).

Zavolejte [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fonts/getscriptfontmap/) pro získání všech mapování z kolekce. Pro vyhledání jednoho psacího systému zavolejte [Fonts::GetScriptFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fonts/getscriptfont/) s jeho značkou skriptu. `GetScriptFont` vrací nulový řetězec, pokud tato kolekce nedefinuje požadované mapování.

## **Upravit mapování a ověřit trvanlivost**

Použijte [Fonts::SetScriptFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fonts/setscriptfont/) pro vytvoření mapování nebo nahrazení aktuální rodiny písma. Použijte [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fonts/removescriptfont/) pro odstranění mapování.

Následující kompletní příklad načte všechna existující hlavní a vedlejší mapování, vyhledá hlavní japonské písmo, změní hlavní cyrilické písmo, odstraní vedlejší mapování Thaana, uloží prezentaci a znovu ji otevře k ověření obou změn. Aby byl krok odstraňování nezávislý na počátečním tématu, příklad nejprve vytvoří mapování Thaana pouze pokud ještě není definováno.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Ověření používá stejné chování vracení nulového řetězce jako běžné vyhledávání: po uložení odstranění `GetScriptFont(u"Thaa")` vrací nulový řetězec pro vedlejší kolekci.

## **Rozlišovat mapování tématu od ostatních nastavení písem**

Mapování tématu specifická pro skript se podílejí na výběru písma, ale řeší jiný problém než přímé formátování textu, substituce a náhradní písmo:

| Mechanismus | Účel | Dopad změny mapování tématu |
|---|---|---|
| Mapování tématu specifické pro skript | Vybere hlavní nebo vedlejší písmo tématu pro psací systém. | Text, který stále používá odpovídající písmo tématu, může být přesměrován na novou mapovanou rodinu. |
| Písmo přiřazené explicitně k části textu | Zafixuje požadovanou rodinu písma na této části místo spoléhaní se na téma. | Část může zůstat nezměněna, protože její přímé formátování přebije volbu tématu. |
| Substituce písma | Nahradí požadované písmo, když není dostupné nebo když platí pravidlo substituce. | Působí po požadavku na písmo; nepředefinuje mapování skriptu v tématu. |
| Náhradní písmo | Poskytuje glyfy, které vybrané písmo neobsahuje, často pro konkrétní rozsahy Unicode. | Doplní chybějící glyfy; nemění uložené mapování tématu. |

Pro více informací o posledních dvou mechanismech navštivte [Substituce písem](/slides/cs/cpp/font-substitution/) a [Náhradní písma](/slides/cs/cpp/fallback-font/).

Změna mapování v [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_mastertheme/) ovlivní pouze obsah, jehož efektivní formátování stále závisí na tomto tématu. Text může místo toho zdědit přepsání tématu z masteru, rozložení nebo snímku, nebo použít explicitně přiřazené písmo. Zkontrolujte tyto úrovně, když viditelný výsledek neodpovídá mapování na úrovni prezentace.

## **Zajistit dostupnost mapovaných písem a ověřit výsledek**

Mapování skriptu ukládá název rodiny písma; neinstaluje ani nenačítá odpovídající soubor písma. Pro konzistentní vykreslování a export musí být každé mapované písmo nainstalováno v prostředí nebo poskytnuto Aspose.Slides prostřednictvím vlastního zdroje, například [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfonts/) nebo [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Viz [Vlastní písma](/slides/cs/cpp/custom-font/) pro dostupné možnosti načítání.

Ověření uloženého mapování potvrzuje pouze, že definice tématu byla zachována. Neukazuje, že je písmo dostupné, obsahuje všechny požadované glyfy nebo vytváří zamýšlené rozložení. Vykreslete reprezentativní text pro každý požadovaný psací systém do obrázku nebo PDF a zkontrolujte výstup. Tím se zachytí chybějící písma, neúplné pokrytí glyfů, chování náhrady a změny rozložení před distribucí prezentace. Viz [Převod PowerPoint prezentací](/slides/cs/cpp/convert-powerpoint/) pro příklady vykreslování a exportu.

## **Často kladené otázky**

**Co vrací `GetScriptFont`, když skript není mapován?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fonts/getscriptfont/) vrací nulový řetězec, když požadované mapování skriptu není v této hlavní nebo vedlejší kolekci písem definováno.

**Přidá `SetScriptFont` druhé mapování, pokud skript již existuje?**

Ne. [Fonts::SetScriptFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fonts/setscriptfont/) vytvoří mapování, pokud chybí, a nahradí mapovanou rodinu písma, když je stejná značka skriptu již přítomna.

**Proč změna mapování tématu nezměnila některý text?**

Text může mít explicitně přiřazené písmo, zdědit jiné téma přes přepsání, nebo být ovlivněn substitucí či náhradou během vykreslování. Mapování skriptu na úrovni prezentace řídí pouze text, jehož efektivní formátování stále odkazuje na tuto kolekci písem tématu.

**Je uložení a opětovné otevření dostatečné k ověření vícejazyčného výstupu?**

Ne. Opětovné otevření ověřuje trvalost dat tématu. Také vykreslete reprezentativní text z každého požadovaného psacího systému, abyste potvrdili, že mapovaná písma jsou dostupná a obsahují potřebné glyfy.