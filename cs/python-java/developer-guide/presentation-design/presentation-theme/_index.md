---
title: Spravovat motivy prezentací v Pythonu přes Java
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/python-java/presentation-theme/
keywords:
- Motiv PowerPoint
- Motiv prezentace
- Motiv snímku
- Nastavit motiv
- Změnit motiv
- Spravovat motiv
- Externí motiv
- THMX
- Barva motivu
- Dodatečná paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Mistrujte motivy prezentací v Aspose.Slides pro Python přes Java, abyste vytvářeli, upravovali a převáděli soubory PowerPoint s konzistentní značkou."
---
## **Úvod**

Prezentace motiv definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objektu vědomému motivu odkazují na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je motiv na úrovni prezentace k dispozici přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Hlavní snímek může přepsat motiv prezentace přes [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme), zatímco rozvržení nebo jednotlivý snímek může přepsat svůj zděděný motiv přes [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). V praxi je efektivní motiv pro snímek vyřešen přes tento řetězec dědičnosti: motiv prezentace, přepsání hlavního snímku, přepsání rozvržení a přepsání snímku.

![Součásti motivu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s motivem: prohlédnutí motivu, změna barev a písem, kopírování nebo aplikace motivu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepsání.

## **Prohlédnout motiv**

Objekt [MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) vystavuje schéma barev motivu, schéma písem a schéma formátů prostřednictvím [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti motivu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v motivu uloženo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()

    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

Pokud soubor používá více hlavních snímků, neberte jako samozřejmost, že každý snímek má stejný efektivní motiv. Prohlédněte hlavní snímek přiřazený ke snímku a použijte workflow efektivního motivu zobrazený později v tomto článku, když mohou být přítomna přepsání rozvržení nebo snímku.

## **Změnit barvy motivu**

Výplně, čáry a text vědomé motivu mohou odkazovat na logickou barvu ze výčtu [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou vyřešeny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se při aktualizaci barvy motivu nic nezmění.

Následující end‑to‑end příklad vytvoří tvar, který používá `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)

    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` už tento výplň neovlivní.

### **Použít barvy z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje přes výčet [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.

**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich aplikuje luminanční transformace a výsledek uloží:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tyto varianty zůstávají založeny na barvě motivu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapovat hodnoty `SchemeColor` na sloty `ColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) vystavuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejsou to hodnoty, které by se dynamicky převáděly z jedné formy do druhé.

## **Změnit písma motivu**

Schéma písem motivu obsahuje hlavní sadu písem pro nadpisy a menší sadu pro tělo textu. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) a [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) tato schémata vystavují.

Identifikátory písem kompatibilních s PowerPoint lze použít ve formátování textu:

* `+mn‑lt` – Tělo písmo latin (Minor Latin Font)
* `+mj‑lt` – Nadpis písmo latin (Major Latin Font)
* `+mn‑ea` – Tělo písmo východní Asie (Minor East Asian Font)
* `+mj‑ea` – Nadpis písmo východní Asie (Major East Asian Font)
* `+mn‑cs` – Tělo písmo komplexní skript (Minor Complex Script Font)
* `+mj‑cs` – Nadpis písmo komplexní skript (Major Complex Script Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinské písmo motivu, a jeden řádek těla, který používá menší latinské písmo motivu. Pak změní písma motivu a výsledek uloží:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nadpis následuje hlavní písmo a tělo textu následuje menší písmo. Text, který má explicitně uvedený název písma místo identifikátoru motivu, se automaticky nepřepne, když se změní schéma písem motivu.

Hlavní a menší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou Cyrilice, Arabština, Japonština, Gruzie a Thaana. Pro prohlédnutí, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
Pro více informací o písmu v prezentaci viz [Písma PowerPoint](/slides/cs/python-java/powerpoint-fonts/).
{{% /alert %}}

### **Vyřešit odkazy na písmo motivu**

Při prohlížení textu může [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) vrátit odkaz na motiv, například `+mn‑lt`, místo názvu rodiny písma. Zavolejte [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) s příslušnými efektivními daty motivu, aby se odkaz vyřešil. Předpony `+mj` a `+mn` volí hlavní a menší sadu písem; přípony `-lt`, `-ea` a `-cs` volí jejich latinská, východně asijská a komplexní skriptová písma.

Získejte efektivní motiv přes [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) na správci motivu objektu, jehož motiv se vztahuje k prohlíženému textu. Pro běžný text na snímku použijte správce motivu snímku, aby kontext zahrnoval zděděný motiv snímku a místní přepsání. Při prohlížení rozvržení nebo samotného hlavního snímku použijte jeho vlastní efektivní motiv. Nepředpokládejte, že motiv prvního hlavního snímku platí pro každý snímek.

Následující příklad vytvoří textový úsek, který explicitně odkazuje na menší latinské písmo. Inicializuje schéma písem snímku přes [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) a nastaví hlavní i menší latinské rodiny na `Arial` a `Calibri`, aby byl výsledek reprodukovatelný bez vstupního souboru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

Výstup je `+mn‑lt -> Calibri` následovaný `Verdana -> Verdana`. Uložený odkaz zůstává nezměněn, zatímco explicitní název rodiny je vrácen tak, jak je. Kdyby úsek použil `+mj‑lt`, vyřešil by se na `Arial` v tomto motivu.

Vyřešení odkazu motivu identifikuje rodinu písma určenou motivem. Nekontroluje dostupnost písma ani nezjišťuje, který soubor písma je nakonec použit po substituci nebo náhradě glyfů během vykreslování. Viz [Font Selection Sequence](/slides/cs/python-java/font-selection-sequence/) a [Font Substitution](/slides/cs/python-java/font-substitution/) pro tyto samostatné kroky.

## **Kopírovat nebo aplikovat motiv**

Níže uvedené pracovní postupy řeší různé problémy související s motivem.

### **Aplikovat externí motiv na snímky závislé na hlavním snímku**

Použijte [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides), když máte soubor motivu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním hlavním snímku. Vyberte hlavní snímek z kolekce [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters), reprezentované [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/), a předávejte cestu k souboru motivu metodě.

Metoda provádí následující operace:

1. Vytvoří nový hlavní snímek na základě vybraného hlavního snímku.
1. Aplikuje externí motiv na nový hlavní snímek.
1. Přiřadí nový hlavní snímek všem snímkům, které dříve závisely na vybraném hlavním snímku.
1. Vrátí nově vytvořený [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/).

Následující příklad aplikuje externí motiv na snímky, které závisí na prvním hlavním snímku, a uloží prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")
    print("Created master:", themed_master.getName())

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Neplatný, poškozený nebo nepodporovaný motiv může vyvolat [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/). Ověřujte cesty poskytnuté uživateli, řešte selhání přístupu k souborovému systému a uložte prezentaci až po úspěšném aplikování motivu.

Přesunou se jen snímky, které závisely na vybraném hlavním snímku. Snímky přiřazené k ostatním hlavním snímkům si zachovají své stávající hlavní snímky a motivy. Barvy, písma, výplně, čáry, pozadí a efekty vědomé motivu jsou řešeny vůči externímu motivu. Přímé přiřazení barev, písem, výplní a dalších explicitních formátování může zůstat nezměněno. Přepsání na úrovni rozvržení a snímku může také mít přednost před hodnotami zděděnými z nového hlavního snímku.

Motiv může odkazovat na písma, která nejsou v běhovém prostředí k dispozici. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytněte je přes [vlastní zdroje písem](/slides/cs/python-java/custom-font/), nebo nakonfigurujte [substituci písem](/slides/cs/python-java/font-substitution/).

Jedná se o přímý workflow na úrovni hlavního snímku: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání motivu na úrovni snímku nebo rozvržení.

### **Aplikovat různé externí motivy v prezentaci s více hlavními snímky**

Když není hlavní snímek znám předem, získejte jej z reprezentativního snímku přes [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide). Uložte původní odkazy na hlavní snímky před aplikací jakýchkoli motivů, protože každé volání vytvoří další hlavní snímek v prezentaci.

Následující příklad používá snímky ze dvou sekcí k nalezení jejich hlavních snímků a aplikuje jiný externí motiv na každou skupinu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

První volání ovlivní jen snímky, které závisely na `first_group_master`, a druhé volání ovlivní jen snímky, které závisely na `second_group_master`. Snímky patřící k jakémukoli jinému hlavnímu snímku nebudou přeformátovány.

### **Zachovat zdrojový motiv při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, klonujte zdrojový hlavní snímek do cílové prezentace pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone), poté klonujte snímek pomocí [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) a klonovaného hlavního snímku. Tím se přenese hlavní snímek, jeho rozvržení i související motiv.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)

        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Jedná se o preferovaný workflow, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový hlavní snímek může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Aplikovat hodnoty motivu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním hlavním snímku a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) kopírují tři hlavní komponenty motivu do přepsání.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Tím se změní motiv používaný tímto snímkem, aniž by se změnil motiv zděděný ostatními snímky. Pro odstranění místního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear).

### **Aplikovat přepsání motivu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky, které používají toto rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Použijte motiv na úrovni hlavního snímku nebo prezentace, když mnoho rozvržení a snímků má sdílet stejný základní design, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání pozdějších globálních změn motivu.

<!-- visual-explanation:presentation-theme:start -->
[![Rozšíření hlavního motivu na dva rozvržení; přepsání rozvržení ovlivňuje jeho snímky kromě snímku s ještě místnějším přepsáním.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Přepsání rozvržení se vztahuje na snímky používající toto rozvržení, pokud snímek neposkytne vlastní přepsání. Hodnoty založené na motivu následují jejich vyřešené schéma; explicitně formátované objekty mohou zachovat svůj místní vzhled. Udržujte přepsání úzká, jak má zamýšlená výjimka designu.*
<!-- visual-explanation:presentation-theme:end -->

## **Aktualizovat styly pozadí motivu**

Styly výplní pozadí motivu jsou uloženy v [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint může v uživatelském rozhraní nabízet více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex). Index stylu `0` znamená žádnou tematickou výplň; kladné hodnoty jsou odkazy na styl pozadí motivu. To se liší od indexování samotné kolekce, kde `get_Item(0)` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše dostupný počet výplní pozadí, přiřadí odkaz na tematické pozadí prvnímu hlavnímu snímku a uloží prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)

        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Viditelný výsledek závisí na položce motivu, na kterou odkazuje hlavní snímek, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze hlavního pozadí nemusí změnit tento snímek. Použijte [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte index stylu jako nulový index kolekce. Také se vyhněte hardcodování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/python-java/presentation-background/).
{{% /alert %}}

## **Aktualizovat efekty motivu**

Schéma formátů motivu obsahuje samostatné kolekce výplní, čar a efektů vystavené přes [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles) a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles). Typické motivy Office často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl prozkoumat každou kolekci místo předpokládání pevného počtu.

![Jemné, střední a intenzivní efekty motivu aplikované na stejný tvar](presentation-design_10.png)

Když přistupujete k těmto kolekcím v Pythonu přes Java, index kolekce je nulový: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazů stylu tvaru jsou samostatný koncept, vystavený přes [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/). Úprava stylu motivu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a výsledek uloží:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)

        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro tvary, které odkazují na tyto sloty, se první styl čáry motivu stane červeným, třetí styl výplně motivu se stane plně zeleným lesním odstínem a třetí efekt získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, na které sloty každý tvar odkazuje a zda přímé formátování nepřepíše motiv.

![Styly efektů motivu po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Vybrat výplň a čáru motivu pro tvar**

Tvar může nezávisle vybrat svou výplň a obrys přes [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) a [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex). Pro obě metody index `1` vybírá první položku v odpovídající kolekci motivu (`get_Item(0)`) a index `2` vybírá druhou (`get_Item(1)`).

Následující příklad nastaví dva styly výplně (zlatý a nebesky modrý) a dva styly čáry (tmavě modrá 6 pt a tmavě červená 12 pt) v výchozím motivu nové prezentace. Uloží snímek ve třech fázích, abyste mohli porovnat výsledky v PowerPointu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Počáteční styly | Změnit pravý obrys | Upravit první výplň motivu |
|:---:|:---:|:---:|
| ![Zlaté a nebesky modré obdélníky s odpovídajícími tenkými tmavě modrými obrysy](theme-style-initial.png) | ![Nebešky modrý obdélník má nyní silný tmavě červený obrys](theme-style-line-changed.png) | ![Levý obdélník je nyní zelený a oba obrysy zůstaly beze změny](theme-style-fill-changed.png) |

Výběr jiného stylu čáry změní jen obrys pravého obdélníku. Úprava první výplně motivu aktualizuje každý tvar, který ji používá. Zde se zeleně zbarví jen levý obdélník.

Na existujícím tvaru může lokální barva výplně, barva čáry nebo šířka čáry přepsat příslušnou část motivu. Pokud změna indexu stylu nemá viditelný efekt, zkontrolujte [přímé formátování](/slides/cs/python-java/shape-formatting/).

## **Zjistit, zda efektivní plná výplň používá barvu motivu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozvržení, hlavního snímku, stylu motivu nebo jiné úrovně formátování. Zavolejte [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective), abyste tuto hierarchii vyřešili do neměnných efektivních dat výplně. Nejprve zkontrolujte `getFillType` na objektu efektivních dat. Pouze pokud je `FillType.Solid`, měli byste číst vlastnosti plné výplně.

Pro plnou výplň `getSolidFillColor` vrací konečnou vykreslenou RGB hodnotu po aplikaci dědičnosti, vyhledání motivu a transformací barev. `getSolidFillSchemeColor` vrací odpovídající logické místo výčtu [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/), například `Text1` nebo `Accent6`. Hodnota `SchemeColor.NotDefined` znamená, že efektivní plná výplň není založena na výčtu schématu. V pracovním postupu, kde jsou výplně buď barvy motivu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Neproměňujte místní hodnotu [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) samotnou pro klasifikaci výplně. Například textový úsek může mít žádnou lokálně definovanou barvu schématu, takže jeho lokální hodnota je `NotDefined`, zatímco jeho efektivní výplň zdědí barvu motivu a vyřeší se na `Text1` nebo `Accent6`. Naopak `getSolidFillSchemeColor` vám říká, které logické místo motivu vytvořilo efektivní barvu, ale neřekne, zda toto místo přišlo z objektu, odstavce, rozvržení, hlavního snímku nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, prověří výplně tvarů i výplně textových úseků, vytiskne každou konečnou RGB hodnotu a související barvu schématu a označí plné výplně, které nebudou sledovat změny barvy motivu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

Větev `NotDefined` poskytuje seznam auditovaných plných výplní, které nebudou reagovat na změny v místech barvy motivu. Prohlédněte tyto objekty, když musí prezentace následovat novou firemní paletu. Uvedená RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled spojen s motivem.

Objekty s efektivním formátem jsou snímky. Po změně motivu prezentace, přepsání motivu nebo jakéhokoli zděděného formátování zavolejte `getEffective` znovu a načtěte nový objekt efektivních dat výplně před porovnáním nebo hlášením barev.

## **Číst efektivní hodnoty motivu**

Surové objekty motivu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a místních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective).

Následující příklad načte efektivní motiv, pozadí a první výplň tvaru ze snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme), můžete přehlédnout přepsání v hlavním snímku, rozvržení, snímku nebo tvaru, které mění konečný vzhled.

## **FAQ**

**Ovlivní aplikace externího motivu každý snímek v prezentaci?**

Ne. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) přiřadí jen snímky, které závisí na vybraném hlavním snímku. Snímky používající jiné hlavní snímky zachovají své existující motivy.

**Mohu aplikovat motiv na jediný snímek bez změny hlavního snímku?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále zdědí své existující motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový hlavní snímek do cíle a klonujte snímek s tímto hlavním snímkem pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) a [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone). Tím se zachová hlavní snímek, rozvržení i motiv společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) pro motiv snímku nebo rozvržení a odpovídající metody efektivních dat pro formátovací objekty, jako jsou [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) a [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepsání.