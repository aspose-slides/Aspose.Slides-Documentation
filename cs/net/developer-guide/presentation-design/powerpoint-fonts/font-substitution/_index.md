---
title: Konfigurace náhrady písem v prezentacích v .NET
linktitle: Náhrada písem
type: docs
weight: 70
url: /cs/net/font-substitution/
keywords:
- písmo
- náhradní písmo
- náhrada písma
- nahrazení písma
- náhrada písma
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Konfigurujte pravidla náhrady písem a kontrolujte nahrazená písma v Aspose.Slides pro .NET při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada písma (font substitution) umožňuje Aspose.Slides použít dostupné písmo místo písma, ke kterému nelze přistupovat při vykreslování nebo konverzi prezentace. Náhrada ovlivňuje pouze vykreslený výstup; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete si prohlédnout náhrady, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní napříč prostředími s různými nainstalovanými písmy.

## **Získání náhrad písem**

Použijte metodu [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/), abyste zjistili, která písma budou nahrazena při vykreslení prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstitutioninfo/), které identifikují původní i náhradní názvy písma.

Následující ukázka v C# vypisuje všechny náhrady písem pro prezentaci:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Získání náhrad písem pro vybrané snímky**

Použijte přetížení [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/) s argumentem `int[] slides`, abyste prozkoumali jen náhrady potřebné k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, kontrolujete velkou prezentaci postupně, hledáte snímky závislé na nedostupných písmenech, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednopodlažní indexy snímků: `1` označuje první snímek. Naproti tomu indexér kolekce [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) je nulový, takže stejný snímek se přistupuje jako `presentation.Slides[0]`. Tuto rozdílnost mějte na paměti při sestavování pole, abyste se vyhnuli chybám „o jeden“.

Volání přetížení proveďte přes vlastnost [Presentation.FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/fontsmanager/). Vrátí pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstitutioninfo/), který obsahuje původní i náhradní název písma. Výsledek odráží aktuální fontové prostředí a [externě načtená písma](/slides/cs/net/custom-font/). Náhradní pravidla uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsubstrulecollection/) mění vykreslený výstup, ale nejsou v výsledku uvedena.

Stejná náhrada může být vyžadována více než jedním vybraným snímkem. Výsledek deduplikujte, když vytváříte inventář písem nebo preflight zprávu. Následující příklad vypisuje každou vrácenou náhradu a poté vytvoří seřazený seznam unikátních mapování písem:

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

Rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte si to podle rozsahu vykreslovací operace:

| Přetížení | Použijte, když |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/) bez argumentů | Potřebujete náhrady pro celou prezentaci. |
| [GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/) s `int[] slides` | Potřebujete náhrady pro vybraný rozsah, postupnou kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady písem**

Chcete-li určit písmo, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.  
2. Vytvořte definice písem pro zdrojové a náhradní písmo.  
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstcondition/).  
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstrulecollection/).  
5. Přiřaďte kolekci k vlastnosti [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. Vykreslete nebo konvertujte prezentaci.

Následující ukázka v C# nahrazuje `Arial` za `SomeRareFont`, pokud je `SomeRareFont` nedostupné, a poté vykreslí první snímek pro ověření výsledku. Náhradní písmo musí být pro Aspose.Slides dostupné.

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
Pro nepodmíněnou změnu písem použitých v celé prezentaci viz [Náhrada písem](/slides/cs/net/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písma používaného během vykreslování a konverze. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo tím, které je určeno pravidlem.

Matematické rovnice Office Math mají navíc požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě toto písmo k výpočtu a vykreslení rozložení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může i nadále uvádět, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby bylo **Cambria Math** dostupné pro Aspose.Slides. Nainstalujte jej v operačním systému nebo načtěte jako [externí písmo](/slides/cs/net/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Pravidla náhrady popsaná výše stále platí pro běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradou písem a náhradou (font replacement) písem?**  
[Font replacement](/slides/cs/net/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písem (font substitution) vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla náhrady aplikují?**  
Pravidla se podílejí na [sekvenci výběru písma](/slides/cs/net/font-selection-sequence/) během vykreslování a konverze. S `WhenInaccessible` se pravidlo použije pouze tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nastaveno žádné pravidlo náhrady?**  
Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písma. Výsledek závisí na písmenech dostupných v běhovém prostředí.

**Mohu načíst externí písma, abych se vyhnul náhradě?**  
Ano. Můžete [načíst externí písma](/slides/cs/net/custom-font/), aby je Aspose.Slides mohl používat během vykreslování a konverze.

**Distribuuje Aspose písma s knihovnou?**  
Ne. Za poskytování písem a dodržování jejich licencí jste zodpovědní vy.

**Mohou se výsledky náhrady lišit mezi Windows, Linux a macOS?**  
Ano. Nainstalovaná písma a umístění vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může na jiném vyžadovat náhradu.

**Jak zajistit konzistentní výběr písem při hromadných konverzích?**  
Používejte stejné soubory písem a jejich verze na každém počítači nebo v každém kontejneru, [načtěte požadovaná externí písma](/slides/cs/net/custom-font/), a [vložte písma](/slides/cs/net/embedded-font/), pokud to licence dovoluje. Můžete také před exportem zavolat [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/), abyste identifikovali neočekávané náhrady.