---
title: Konfigurace náhrady písma v prezentacích v .NET
linktitle: Náhrada písma
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
description: "Konfigurujte pravidla náhrady písma a kontrolujte nahrazená písma v Aspose.Slides pro .NET při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít dostupné písmo místo písma, ke kterému nelze přistupovat při vykreslování nebo konverzi prezentace. Náhrada ovlivňuje výstupní renderovaný výsledek; nezmění písmo přiřazené obsahu prezentace.

Můžete definovat písmo, které se použije, pokud je konkrétní písmo nedostupné, a můžete si prohlédnout náhrady, které Aspose.Slides provede během vykreslování. To pomáhá udržet výstup konzistentní napříč prostředími s různými nainstalovanými písmy.

Pokud je písmo k dispozici, ale nemá samostatnou tučnou variantu, viz [Zpracování písem bez samostatného tučného řezu](/slides/cs/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Tato sekce vysvětluje, jak během exportu do PDF rasterizovat dotčený text a jaké jsou důsledky pro výběr textu, vyhledávání a škálování.

## **Získání náhrad písem**

Použijte metodu [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) k určení, která písma budou nahrazena při vykreslování prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/), které identifikují původní a nahrazené názvy písem.

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

## **Získání náhrad písem pro vybrané snímky**

Použijte přetížení [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) s argumentem `int[] slides` k prohlédnutí pouze náhrad potřebných k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, inkrementálně kontrolujete velkou prezentaci, hledáte snímky závislé na nedostupných písmech, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednorázové indexy snímků začínající od jedné: `1` označuje první snímek. Naopak indexer kolekce [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) je nulový, takže stejný snímek se přistupuje jako `presentation.Slides[0]`. Pamatujte na tento rozdíl při vytváření pole, aby nedošlo k chybě o jeden.

Volání přetížení prostřednictvím vlastnosti [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) vrátí pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) obsahující původní a náhradní názvy písem. Výsledek odráží aktuální prostředí písem a [externě načtená písma](/slides/cs/net/custom-font/). Pravidla náhrady uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) mění vykreslený výstup, ale nejsou v výsledku zobrazená.

Stejná náhrada může být požadována více než jedním vybraným snímkem. Při vytváření inventáře písem nebo přehledu předběžné kontroly výsledky deduplikujte. Následující příklad vypisuje každou vrácenou náhradu a poté vytváří seřazený seznam unikátních mapování písem:

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

Rozhraní [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu operace vykreslování:

| Přetížení | Použít, když |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) bez argumentů | Potřebujete náhrady pro celou prezentaci. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) s `int[] slides` | Potřebujete náhrady pro vybraný rozsah, inkrementální kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady písem**

Pro určení písma, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.
2. Vytvořte definice písem pro zdrojové a náhradní písmo.
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Přiřaďte kolekci k vlastnosti [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Vykreslete nebo konvertujte prezentaci.

Následující příklad v C# nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupný, a poté vykresluje první snímek pro ověření výsledku. Náhradní písmo musí být k dispozici pro Aspose.Slides.

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
Pro neomezenou změnu písem používaných v celé prezentaci viz [Náhrada písem](/slides/cs/net/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písem používaného při vykreslování a konverzi. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, může Aspose.Slides potřebovat právě toto písmo k výpočtu a vykreslení rozložení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále uvádět, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo konverzi takové prezentace zpřístupněte **Cambria Math** pro Aspose.Slides. Nainstalujte jej v operačním systému nebo načtěte jako [externí písmo](/slides/cs/net/custom-font/).

Toto omezení se vztahuje na rozložení rovnic. Výše popsaná pravidla náhrady se stále vztahují na běžný text prezentace.

## **FAQ**

**Jaký je rozdíl mezi nahrazením písma a náhradou písma?**

[Font replacement](/slides/cs/net/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písma vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla náhrady používají?**

Pravidla se podílejí na [sekvenci výběru písem](/slides/cs/net/font-selection-sequence/) během vykreslování a konverze. S `WhenInaccessible` se pravidlo použije pouze tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo náhrady?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písem. Výsledek závisí na písmenech dostupných v běhovém prostředí.

**Mohu načíst externí písma, aby se zabránilo náhradě?**

Ano. Můžete [načíst externí písma](/slides/cs/net/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a konverze.

**Distribuuje Aspose písma s knihovnou?**

Ne. Vy jste zodpovědní za poskytování písem a dodržování jejich licencí.

**Mohou se výsledky náhrady lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a umístění pro vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může vyžadovat náhradu na jiném.

**Jak mohu zajistit konzistentní výběr písem při dávkových konverzích?**

Používejte stejné soubory písem a verze na každém počítači nebo kontejneru, [načtěte požadovaná externí písma](/slides/cs/net/custom-font/) a [vložit písma](/slides/cs/net/embedded-font/) pokud to licence umožňuje. Můžete také zavolat [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) před exportem, abyste identifikovali neočekávané náhrady.