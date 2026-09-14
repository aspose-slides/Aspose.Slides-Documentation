---
title: Konfigurace náhrady písma v prezentacích pomocí Pythonu přes Java
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/python-java/font-substitution/
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
- Python
- Java
- Aspose.Slides
description: "Konfigurujte pravidla náhrady písma a kontrolujte nahrazená písma v Aspose.Slides pro Python přes Java při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít dostupné písmo místo písma, které nelze při vykreslování nebo konverzi prezentace získat. Náhrada ovlivňuje vykreslený výstup; nemění písmo přiřazené obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete zkontrolovat náhrady, které Aspose.Slides provede během vykreslování. To pomáhá udržet výstup konzistentní napříč prostředími s různými nainstalovanými písmy.

## **Získání náhrad písma**

Použijte metodu [FontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getSubstitutions), abyste určili, která písma budou při vykreslování prezentace nahrazena. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsubstitutioninfo/), které identifikují původní a nahrazené názvy písem.

Následující příklad v jazyce Python vypisuje všechny náhrady písem pro prezentaci:

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

## **Získání náhrad písma pro vybrané snímky**

Použijte přetížení [FontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getSubstitutions) s argumentem pole celých čísel v jazyce Java, abyste zkontrolovali pouze náhrady potřebné k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, kontrolujete velkou prezentaci postupně, vyhledáváte snímky, které závisí na nedostupných písmech, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednorozměrné indexy snímků založené na čísle 1: `1` označuje první snímek. Naopak přístup k kolekci pomocí [Presentation.getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides) používá indexování od nuly, takže stejný snímek je přístupný jako `presentation.getSlides().get_Item(0)`. Tuto odlišnost mějte při vytváření pole na paměti, aby nedošlo k chybám o jeden.

Volání přetížení přes metodu [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getFontsManager). Vrací pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsubstitutioninfo/) obsahující původní a nahrazené názvy písem. Výsledek odráží aktuální prostředí písem, nakonfigurovaná záložní pravidla, pravidla náhrady uložená v [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsubstrulecollection/) a [externě načtená písma](/slides/cs/python-java/custom-font/).

Stejnou náhradu může vyžadovat více než jeden vybraný snímek. Výsledky deduplikujte, když vytváříte inventář písem nebo preflight zprávu. Následující příklad vypisuje každou vrácenou náhradu a poté vytváří seřazený seznam unikátních mapování písem:

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

Třída [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu vykreslovací operace:

| Přetížení | Použijte, pokud |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getSubstitutions) bez argumentů | Potřebujete náhrady pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getSubstitutions) s polem celých čísel Java | Potřebujete náhrady pro vybraný rozsah, postupnou kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady písma**

Pro určení písma, které by Aspose.Slides mělo použít, když je výchozí písmo nedostupné:

1. Načtěte prezentaci.
2. Vytvořte definice písem pro výchozí a náhradní písma.
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsubstrulecollection/).
5. Přiřaďte kolekci pomocí metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Vykreslete nebo konvertujte prezentaci.

Následující příklad v jazyce Python nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykresluje první snímek pro ověření výsledku. Náhradní písmo musí být dostupné pro Aspose.Slides.

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

{{% alert color="info" title="Poznámka" %}}
Pro neomezenou změnu písem používaných v celé prezentaci viz [Font Replacement](/slides/cs/python-java/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písma používaného při vykreslování a konverzi. Fungují pro běžný text, pokud Aspose.Slides může nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě toto písmo pro výpočet a vykreslení rozvržení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, např. **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále hlásit, že **Cambria Math** je požadováno.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby bylo **Cambria Math** dostupné pro Aspose.Slides. Nainstalujte jej v operačním systému nebo načtěte jako [external font](/slides/cs/python-java/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Výše popsaná pravidla náhrady se stále vztahují na běžný text v prezentaci.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a náhradou písma?**

[Font replacement](/slides/cs/python-java/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písma vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla náhrady aplikují?**

Pravidla se podílejí na [font selection sequence](/slides/cs/python-java/font-selection-sequence/) během vykreslování a konverze. S podmínkou `WhenInaccessible` se pravidlo použije pouze tehdy, když Aspose.Slides nemůže získat výchozí písmo.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo náhrady?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písma. Výsledek závisí na písmenech dostupných v runtime prostředí.

**Mohu načíst externí písma, aby se zabránilo náhradě?**

Ano. Můžete [load external fonts](/slides/cs/python-java/custom-font/), aby je Aspose.Slides mohl používat během vykreslování a konverze.

**Rozděluje Aspose písma spolu s knihovnou?**

Není. Vy jste zodpovědní za poskytování písem a dodržování jejich licencí.

**Mohou se výsledky náhrady lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a umístění hledání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může vyžadovat náhradu na jiném.

**Jak zajistit konzistentní výběr písem při dávkových konverzích?**

Používejte stejné soubory písem a jejich verze na každém počítači nebo kontejneru, [load required external fonts](/slides/cs/python-java/custom-font/) a [embed fonts](/slides/cs/python-java/embedded-font/), pokud licence umožňuje. Můžete také před exportem zavolat [FontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getSubstitutions), abyste identifikovali neočekávané náhrady.