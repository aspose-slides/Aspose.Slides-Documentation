---
title: Konfigurace náhrady písem v prezentacích v C++
linktitle: Náhrada písem
type: docs
weight: 70
url: /cs/cpp/font-substitution/
keywords:
- písmo
- náhradní písmo
- náhrada písma
- nahrazení písma
- nahrazení písma
- pravidlo náhrady
- pravidlo výměny
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Konfigurujte pravidla náhrady písem a prohlédněte si nahrazená písma v Aspose.Slides pro C++ při vykreslování nebo převodu prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít dostupné písmo místo písma, ke kterému nelze získat přístup při vykreslování nebo převodu prezentace. Náhrada ovlivňuje vykreslený výstup; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se má použít, když je konkrétní písmo nedostupné, a můžete prohlédnout náhrady, které Aspose.Slides provede během vykreslování. To pomáhá udržet výstup konzistentní napříč prostředími s různými nainstalovanými písmy.

Pokud je písmo dostupné, ale nemá dedikovaný tučný řez, viz [Zpracování písem bez dedikovaného tučného řezu](/slides/cs/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Tato sekce vysvětluje, jak během exportu do PDF převést dotčený text na rastrový a jaké jsou důsledky pro výběr textu, vyhledávání a škálování.

## **Získat náhrady písem**

Použijte metodu [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) k určení, která písma budou nahrazena při vykreslení prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/), které identifikují původní a nahrazené názvy písem.

Následující příklad v C++ vypisuje všechny náhrady písem pro prezentaci:

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

## **Získat náhrady písem pro vybrané snímky**

Použijte přetížení [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) s argumentem `System::ArrayPtr<int32_t> slides` k prohlédnutí pouze náhrad potřebných pro vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, kontrolujete velkou prezentaci postupně, hledáte snímky, které závisí na nedostupných písmech, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednorozměrné indexy snímků počínaje jednou: `1` označuje první snímek. Naopak metoda [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) používá nulový index, takže stejný snímek se získá jako `presentation->get_Slide(0)`. Při vytváření pole mějte tento rozdíl na paměti, abyste předešli chybám o jeden.

Zavolejte přetížení pomocí metody [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). Vrátí pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/), který obsahuje původní a nahrazené názvy písem. Výsledek odráží aktuální prostředí písem, nakonfigurovaná pravidla pro záložní písma, pravidla náhrady uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/) a [externě načtená písma](/slides/cs/cpp/custom-font/).

Stejná náhrada může být vyžadována více než jedním vybraným snímkem. Při vytváření inventáře písem nebo předletového reportu deduplikujte výsledky. Následující příklad vypisuje každou vrácenou náhradu a poté vytváří seřazený seznam unikátních mapování písem:

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

Rozhraní [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte jedno podle rozsahu vykreslovací operace:

| Přetížení | Použít, když |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Potřebujete náhrady pro celou prezentaci. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | Potřebujete náhrady pro vybraný rozsah, postupnou kontrolu nebo částečný export. |

## **Nastavit pravidla náhrady písem**

Pro určení písma, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.
2. Vytvořte definice písem pro zdrojové a náhradní písmo.
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/).
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).
5. Přiřaďte kolekci pomocí metody [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Vykreslete nebo převeďte prezentaci.

Následující příklad v C++ nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykresluje první snímek k ověření výsledku. Náhradní písmo musí být pro Aspose.Slides dostupné.

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
Pro neomezenou změnu písem použitých v celé prezentaci viz [Nahrazení písma](/slides/cs/cpp/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písma používaného při vykreslování a převodu. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě toto písmo k výpočtu a vykreslení rozvržení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále hlásit, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo převod takové prezentace zajistěte, aby bylo **Cambria Math** dostupné pro Aspose.Slides. Nainstalujte jej v operačním systému nebo jej načtěte jako [externí písmo](/slides/cs/cpp/custom-font/).

Toto omezení platí pro rozvržení rovnic. Výše popsaná pravidla náhrady stále platí pro běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a náhradou písma?**

[Nahrazení písma](/slides/cs/cpp/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písma vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla náhrady používají?**

Pravidla se podílejí na [sekvence výběru písma](/slides/cs/cpp/font-selection-sequence/) během vykreslování a převodu. S `WhenInaccessible` se pravidlo použije pouze tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když chybí písmo a není nakonfigurováno žádné pravidlo náhrady?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písma. Výsledek závisí na písmenech dostupných v runtime prostředí.

**Mohu načíst externí písma, aby se předešlo náhradě?**

Ano. Můžete [načíst externí písma](/slides/cs/cpp/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a převodu.

**Distribuuje Aspose písma spolu s knihovnou?**

Ne. Vy jste zodpovědní za poskytování písem a dodržování jejich licencí.

**Mohou se výsledky náhrady lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a umístění pro vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může vyžadovat náhradu na jiném.

**Jak zajistit konzistentní výběr písem při dávkových převodech?**

Používejte stejné soubory písem a jejich verze na každém stroji nebo kontejneru, [načtěte požadovaná externí písma](/slides/cs/cpp/custom-font/) a [vložit písma](/slides/cs/cpp/embedded-font/) pokud licence dovolí. Můžete také před exportem zavolat [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) pro identifikaci neočekávaných náhrad.