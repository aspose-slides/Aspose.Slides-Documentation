---
title: "Konfigurace náhrady písma v prezentacích v .NET"
linktitle: "Náhrada písma"
type: docs
weight: 70
url: /cs/net/font-substitution/
keywords:
- písmo
- náhradní písmo
- náhrada písma
- nahrazení písma
- nahrazení písma
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Konfigurujte pravidla náhrady písma a kontrolujte nahrazená písma v Aspose.Slides pro .NET při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít dostupné písmo místo písma, které nelze při vykreslování nebo konverzi prezentace získat. Náhrada ovlivňuje výstup vykreslení; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se má použít, když je konkrétní písmo nedostupné, a můžete zkontrolovat náhrady, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní v různých prostředích s různě nainstalovanými písmy.

## **Získání náhrad písma**

Použijte metodu [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/), abyste zjistili, která písma budou nahrazena při vykreslení prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstitutioninfo/), které identifikují originální a nahrazené názvy písem.

Následující příklad v C# vypisuje všechny náhrady písem pro prezentaci:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Získání náhrad písma pro vybrané snímky**

Použijte přetížení [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/) s argumentem `int[] slides`, abyste zkontrolovali pouze náhrady potřebné k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, kontrolujete velkou prezentaci postupně, hledáte snímky, které závisí na nedostupných písmách, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednosměrné (jedno‑základní) indexy snímků: `1` označuje první snímek. Naproti tomu indexer kolekce [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) je nulový, takže stejný snímek je přístupný jako `presentation.Slides[0]`. Při vytváření polete si tuto odlišnost zapamatujte, abyste se vyhnuli chybám o jeden.

Zavolejte přetížení přes vlastnost [Presentation.FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/fontsmanager/). Vrací pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstitutioninfo/) obsahující originální a nahrazené názvy písem. Výsledek odráží aktuální prostředí písem, nakonfigurovaná pravidla záložního řešení, pravidla náhrad uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsubstrulecollection/), a [externě načtená písma](/slides/cs/net/custom-font/).

Stejná náhrada může být vyžadována více než jedním vybraným snímkem. Při tvorbě inventáře písem nebo preflight reportu výsledky deduplikujte. Následující příklad uvádí každou vrácenou náhradu a následně vytváří seřazený seznam unikátních mapování písem:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

Rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu vykreslovací operace:

| Přetížení | Použijte, když |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/) without arguments | Potřebujete náhrady pro celou prezentaci. |
| [GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Potřebujete náhrady pro vybraný rozsah, postupnou kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady písma**

Chcete-li určit, jaké písmo má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.
2. Vytvořte definice písem pro zdrojové a náhradní písmo.
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstcondition/).
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstrulecollection/).
5. Přiřaďte kolekci k vlastnosti [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Vykreslete nebo konvertujte prezentaci.

Následující příklad v C# nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykreslí první snímek pro ověření výsledku. Náhradní písmo musí být pro Aspose.Slides dostupné.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Pro bezpodmínečnou změnu písem použitých v celé prezentaci viz [Font Replacement](/slides/cs/net/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písem používaného během vykreslování a konverze. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat přesně toto písmo pro výpočet a vykreslení rozvržení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslení může stále hlásit, že **Cambria Math** je vyžadováno.

Aby bylo možné takovou prezentaci vykreslit nebo konvertovat, zajistěte, aby bylo **Cambria Math** dostupné pro Aspose.Slides. Nainstalujte jej v operačním systému nebo načtěte jako [externí písmo](/slides/cs/net/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Výše popsaná pravidla náhrady se i nadále vztahují na běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a náhradou písma?**

[Font replacement](/slides/cs/net/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písma vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je originální písmo nedostupné.

**Kdy se pravidla náhrady použijí?**

Pravidla se podílejí na [sekvenci výběru písma](/slides/cs/net/font-selection-sequence/) během vykreslování a konverze. S `WhenInaccessible` se pravidlo použije pouze tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo náhrady?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písem. Výsledek závisí na písmenech dostupných v běhovém prostředí.

**Mohu načíst externí písma, aby se zabránilo náhradám?**

Ano. Můžete [načíst externí písma](/slides/cs/net/custom-font/), aby je Aspose.Slides mohlo použít během vykreslování a konverze.

**Rozděluje Aspose písma s knihovnou?**

Ne. Vy jste zodpovědní za poskytování písem a dodržování jejich licencí.

**Mohou se výsledky náhrad lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a umístění vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může vyžadovat náhradu na jiném.

**Jak mohu zajistit konzistentní výběr písem při hromadných konverzích?**

Používejte stejné soubory a verze písem na každém počítači nebo kontejneru, [načtěte požadovaná externí písma](/slides/cs/net/custom-font/) a [vložte písma](/slides/cs/net/embedded-font/), pokud licence umožňuje. Můžete také před exportem zavolat [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/), abyste identifikovali nečekané náhrady.