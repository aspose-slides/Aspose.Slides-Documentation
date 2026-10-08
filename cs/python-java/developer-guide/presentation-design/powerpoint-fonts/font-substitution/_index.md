---
title: Konfigurace náhrady písma v prezentacích pomocí Pythonu přes Java
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/python-java/font-substitution/
keywords:
- písmo
- náhrada písma
- substituce písma
- nahrazení písma
- nahrazení písma
- pravidlo substituce
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Nakonfigurujte pravidla náhrady písma a zkontrolujte nahrazená písma v Aspose.Slides pro Python přes Java při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít dostupné písmo místo písma, ke kterému nelze získat přístup při vykreslování nebo převodu prezentace. Náhrada ovlivňuje vykreslený výstup; nemění písmo přiřazené obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete zkontrolovat náhrady, které Aspose.Slides provede během vykreslování. To pomáhá udržet výstup konzistentní napříč prostředími s různými nainstalovanými fonty.

Pokud je písmo dostupné, ale nemá vyhrazený tučný řez, podívejte se na [Jak zacházet s fonty bez vyhrazeného tučného řezu](/slides/cs/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Toto oddílové vysvětluje, jak rasterizovat postižený text během exportu do PDF a jaké jsou důsledky pro výběr textu, vyhledávání a škálování.

## **Získat náhrady písma**

Použijte metodu [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) k určení, která písma budou nahrazena při vykreslení prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/), které identifikují původní a nahrazené názvy písem.

Následující příklad v Pythonu vypisuje všechny náhrady písem pro prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Získat náhrady písma pro vybrané snímky**

Použijte přetížení [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) s argumentem pole celých čísel Java, abyste zkontrolovali pouze náhrady potřebné k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, postupně kontrolujete velkou prezentaci, hledáte snímky závislé na nedostupných fontech, připravujete minimální balíček fontů pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednorozměrné indexy snímků počínaje jedničkou: `1` označuje první snímek. Naproti tomu přístup k kolekci pomocí [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) používá nulové indexování, takže stejný snímek je přístupný jako `presentation.getSlides().get_Item(0)`. Mějte tento rozdíl na paměti při vytváření pole, aby nedošlo k chybám o jednu.

Volání přetížení přes metodu [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Vrací pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) obsahující původní a nahrazené názvy písem. Výsledek odráží aktuální prostředí fontů, nakonfigurovaná pravidla záložních fontů, pravidla náhrady uložená v [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) a [externě načtené fonty](/slides/cs/python-java/custom-font/).

Stejná náhrada může být vyžadována více než jedním vybraným snímkem. Výsledky deduplikujte při tvorbě inventáře fontů nebo preflight reportu. Následující příklad hlásí každou vrácenou náhradu a poté vytváří seřazený seznam jedinečných mapování fontů:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

Třída [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu operace vykreslování:

| Přetížení | Použít, pokud |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | Potřebujete náhrady pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | Potřebujete náhrady pro vybraný rozsah, inkrementální kontrolu nebo částečný export. |

## **Nastavit pravidla náhrady písma**

Chcete-li určit písmo, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.
2. Vytvořte definice fontů pro zdrojové a náhradní písmo.
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).
5. Přiřaďte kolekci pomocí metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Vykreslete nebo převedte prezentaci.

Následující příklad v Pythonu nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupný, a poté vykresluje první snímek k ověření výsledku. Náhradní písmo musí být k dispozici pro Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Pro neomezenou změnu fontů používaných v celé prezentaci viz [Náhrada fontu](/slides/cs/python-java/font-replacement/).
{{% /alert %}}

## **Omezení pro fonty matematických rovnic**

Pravidla náhrady fontů jsou součástí standardního procesu výběru fontů používaného během vykreslování a konverze. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupný font dostupným fontem určeným pravidlem.

Rovnice Office Math mají dodatečný požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě tento font k výpočtu a vykreslení rozložení rovnice. Pravidlo, které nahrazuje jiný matematický font, např. **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále hlásit, že **Cambria Math** je vyžadován.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby byl **Cambria Math** dostupný pro Aspose.Slides. Nainstalujte jej v operačním systému nebo jej načtěte jako [externí font](/slides/cs/python-java/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Výše popsaná pravidla náhrady se i nadále vztahují na běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradou fontu a substitucí písma?**

[Náhrada fontu](/slides/cs/python-java/font-replacement/) úmyslně mění jeden font na jiný v celé prezentaci. Substituce písma vybírá font pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní font nedostupný.

**Kdy se pravidla substituce aplikují?**

Pravidla se podílejí na [sekvenci výběru fontu](/slides/cs/python-java/font-selection-sequence/) během vykreslování a konverze. S podmínkou `WhenInaccessible` je pravidlo použito jen tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému fontu.

**Co se stane, když chybí font a není nakonfigurováno žádné pravidlo substituce?**

Aspose.Slides vybere nejbližší dostupný font podle svého procesu výběru fontů. Výsledek závisí na fontech dostupných v runtime prostředí.

**Mohu načíst externí fonty, aby se předešlo substituci?**

Ano. Můžete [načíst externí fonty](/slides/cs/python-java/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a konverze.

**Distribuuje Aspose fonty s knihovnou?**

Ne. Vy jste zodpovědní za poskytování fontů a dodržování jejich licencí.

**Mohou se výsledky substituce lišit mezi Windows, Linux a macOS?**

Ano. Instalované fonty a umístění prohledávání fontů se liší podle operačního systému, takže font dostupný na jednom počítači může vyžadovat náhradu na jiném.

**Jak mohu zajistit konzistentní výběr fontů při dávkových konverzích?**

Používejte stejné soubory fontů a jejich verze na každém stroji nebo kontejneru, [načtěte požadované externí fonty](/slides/cs/python-java/custom-font/) a [vložené fonty](/slides/cs/python-java/embedded-font/) pokud licence umožňuje. Můžete také zavolat [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) před exportem, abyste identifikovali neočekávané náhrady.