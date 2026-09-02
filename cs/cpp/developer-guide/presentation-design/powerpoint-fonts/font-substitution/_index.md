---
title: Konfigurace náhrady fontů v prezentacích v C++
linktitle: Náhrada fontů
type: docs
weight: 70
url: /cs/cpp/font-substitution/
keywords:
- font
- náhradní font
- náhrada fontu
- nahrazení fontu
- nahrazení fontu
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Konfigurujte pravidla náhrady fontů a prohlédněte si nahrazené fonty v Aspose.Slides pro C++, při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada fontů umožňuje Aspose.Slides použít dostupný font místo fontu, který nelze získat při vykreslování nebo konverzi prezentace. Náhrada ovlivňuje vykreslený výstup; nemění font přiřazený k obsahu prezentace.

Můžete definovat font, který se použije, když je konkrétní font nedostupný, a můžete si prohlédnout náhrady, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní v různých prostředích s různými nainstalovanými fonty.

## **Získat náhrady fontů**

Použijte metodu [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getsubstitutions/) k určení, které fonty budou při vykreslování prezentace nahrazeny. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsubstitutioninfo/), které identifikují původní a nahrazené názvy fontů.

Následující příklad v C++ vypisuje všechny náhrady fontů pro prezentaci:

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

## **Získat náhrady fontů pro vybrané snímky**

Použijte přetížení [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getsubstitutions/) s argumentem `System::ArrayPtr<int32_t> slides` k prohlédnutí pouze náhrad potřebných pro vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, kontrolujete velkou prezentaci postupně, vyhledáváte snímky, které závisí na nedostupných fontech, připravujete minimální balíček fontů pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednorozměrné indexy snímků začínající od jedné: `1` označuje první snímek. Naopak metoda [Presentation::get_Slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slide/) používá indexování od nuly, takže stejný snímek je přístupný jako `presentation->get_Slide(0)`. Mějte tento rozdíl na paměti při vytváření pole, abyste se vyhnuli chybám o jeden.

Volání přetížení přes metodu [Presentation::get_FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/) vrátí pouze náhrady určené při vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsubstitutioninfo/) obsahující původní a nahrazené názvy fontů. Výsledek odráží aktuální prostředí fontů, nakonfigurovaná pravidla náhrad, pravidla náhrad uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsubstrulecollection/) a [externě načtené fonty](/slides/cs/cpp/custom-font/).

Stejná náhrada může být vyžadována více než jedním vybraným snímkem. Při vytváření inventáře fontů nebo preflight reportu odstraňte duplicitní výsledky. Následující příklad hlásí každou vrácenou náhradu a poté vytváří seřazený seznam jedinečných mapování fontů:

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

Rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte to, které odpovídá rozsahu vykreslovací operace:

| Přetížení | Kdy použít |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getsubstitutions/) bez argumentů | Potřebujete náhrady pro celou prezentaci. |
| [GetSubstitutions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getsubstitutions/) s `System::ArrayPtr<int32_t> slides` | Potřebujete náhrady pro vybraný rozsah, postupnou kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady fontů**

1. Načtěte prezentaci.  
2. Vytvořte definice fontů pro zdrojový a náhradní font.  
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsubstcondition/).  
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsubstrulecollection/).  
5. Přiřaďte kolekci pomocí metody [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).  
6. Vykreslete nebo konvertujte prezentaci.

Následující příklad v C++ nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupný, a poté vykreslí první snímek pro ověření výsledku. Náhradní font musí být dostupný pro Aspose.Slides.

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

{{% alert color="info" title="Poznámka" %}}
Pro neomezenou změnu fontů používaných v celé prezentaci viz [Náhrada fontů](/slides/cs/cpp/font-replacement/).
{{% /alert %}}

## **Omezení pro fonty matematických rovnic**

Pravidla náhrady fontů jsou součástí standardního procesu výběru fontů používaného během vykreslování a konverze. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupný font dostupným fontem určeným pravidlem.

Rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě tento font pro výpočet a vykreslení rozvržení rovnice. Pravidlo, které nahrazuje jiný matematický font, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále uvádět, že **Cambria Math** je vyžadován.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby **Cambria Math** byl dostupný pro Aspose.Slides. Nainstalujte jej v operačním systému nebo jej načtěte jako [externí font](/slides/cs/cpp/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Popsaná pravidla náhrady stále platí pro běžný text v prezentaci.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením fontu a substitucí fontu?**

[Náhrada fontů](/slides/cs/cpp/font-replacement/) záměrně mění jeden font na jiný v celé prezentaci. Substituce fontu vybere font pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní font nedostupný.

**Kdy se pravidla substituce aplikují?**

Pravidla se podílejí na [sekvenci výběru fontu](/slides/cs/cpp/font-selection-sequence/) během vykreslování a konverze. S podmínkou `WhenInaccessible` se pravidlo použije jen tehdy, když Aspose.Slides nemůže získat zdrojový font.

**Co se stane, když font chybí a není nakonfigurováno žádné pravidlo náhrady?**

Aspose.Slides vybere nejbližší dostupný font podle svého procesu výběru fontu. Výsledek závisí na fontech dostupných v běhovém prostředí.

**Mohu načíst externí fonty, abych se vyhnul/a náhradě?**

Ano. Můžete [načíst externí fonty](/slides/cs/cpp/custom-font/), aby je Aspose.Slides mohl používat během vykreslování a konverze.

**Distribuuje Aspose fonty spolu s knihovnou?**

Ne. Vy jste zodpovědní za poskytování fontů a dodržování jejich licencí.

**Mohou se výsledky náhrady lišit mezi Windows, Linux a macOS?**

Ano. Instalované fonty a umístění vyhledávání fontů se liší podle operačního systému, takže font dostupný na jednom počítači může vyžadovat náhradu na jiném.

**Jak mohu zajistit konzistentní výběr fontů při hromadných konverzích?**

Používejte stejné soubory fontů a jejich verze na každém stroji nebo kontejneru, [načtěte požadované externí fonty](/slides/cs/cpp/custom-font/) a [vložte fonty](/slides/cs/cpp/embedded-font/) pokud licence to povoluje. Můžete také zavolat [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontsmanager/getsubstitutions/) před exportem, abyste identifikovali nečekané náhrady.