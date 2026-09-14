---
title: Správa témat prezentací v Pythonu prostřednictvím Java
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/python-java/presentation-theme/
keywords:
- téma PowerPoint
- téma prezentace
- téma snímku
- nastavit téma
- změnit téma
- spravovat téma
- externí téma
- THMX
- barva tématu
- další paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Mistrovská témata prezentací v Aspose.Slides pro Python prostřednictvím Java pro vytváření, přizpůsobení a konverzi souborů PowerPoint s konzistentním brandováním."
---
## **Úvod**

Prezentace téma definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou téma‑vědomé, se odkazuje na tyto sdílené definice místo uložení každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je téma na úrovni prezentace dostupné přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasterTheme). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterthememanager/#getOverrideTheme), zatímco rozvržení nebo jednotlivý snímek může přepsat zděděné téma pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). V praxi je účinné téma snímku vyřešeno touto řetězovou dědičností: téma prezentace, přepsání masteru, přepsání rozvržení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější workflow s tématy: prohlédnutí tématu, změna barev a písem, kopírování nebo aplikace tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepsání.

## **Prohlédnutí tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mastertheme/) poskytuje schéma barev tématu, schéma písem a schéma formátů prostřednictvím [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mastertheme/#getFontScheme) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/mastertheme/#getFormatScheme). Prohlédnutí těchto kolekcí před jejich změnou je obzvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad čte hlavní vlastnosti tématu a udává, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prohlédněte master přiřazený ke snímku a používejte workflow efektivního tématu ukázané dále v tomto článku, pokud mohou být přítomna přepsání rozvržení nebo snímku.

## **Změna barev tématu**

Téma‑vědomé výplně, čáry a text mohou odkazovat na logickou barvu ze výčtu [SchemeColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/colorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyhodnoceny proti nové hodnotě. Objektům, které používají přímou RGB barvu, změna barvy tématu neproběhne.

Následující end‑to‑end příklad vytvoří tvar používající `Accent4`, změní barvu tématu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vypíše efektivní barvu výplně:

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

Protože obdélník zůstává propojený s `Accent4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `Accent4` už tento výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje prostřednictvím výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy vygenerované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich aplikuje transformace jasu a uloží výsledek:

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

Tyto varianty zůstávají založeny na barvě tématu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `ColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/colorscheme/) vystavuje stejné sloty tématu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy stejných slotů tématu; nejedná se o hodnoty dynamicky převáděné z jedné podoby do druhé.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontscheme/#getMajor) a [FontScheme.getMinor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontscheme/#getMinor) tyto sady vystavují.

Identifikátory písem kompatibilní s PowerPoint lze použít při formátování textu:

* `+mn-lt` – Tělo písma Latin (Minor Latin Font)
* `+mj-lt` – Nadpisové písmo Latin (Major Latin Font)
* `+mn-ea` – Tělo písma Východní Asie (Minor East Asian Font)
* `+mj-ea` – Nadpisové písmo Východní Asie (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo tématu a jeden řádek těla používající vedlejší latinské písmo. Poté změní písma tématu a uloží výsledek:

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

Nadpis používá hlavní písmo a tělo textu používá vedlejší písmo. Text, který má explicitně nastavený název písma místo identifikátoru tématu, se automaticky nepřepne při změně schématu písem tématu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlížení, přidávání, nahrazování nebo odstraňování těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
Pro více informací o písmenech prezentace, viz [PowerPoint Fonts](/slides/cs/python-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití tématu**

Níže uvedená workflow řeší různé problémy související s tématy.

### **Aplikovat externí téma na snímky závislé na masteru**

Použijte [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides), pokud máte soubor tématu PowerPoint (`.thmx`) a chcete přestylizovat každý snímek, který závisí na konkrétním masteru. Vyberte master z kolekce [Presentation.getMasters](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasters), reprezentované třídou [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/), a předávejte cestu k souboru tématu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master‑snímek založený na vybraném masteru.  
1. Aplikuje externí téma na nový master.  
1. Přiřadí nový master všem snímkům, které předtím závisely na vybraném masteru.  
1. Vrátí nově vytvořený [MasterSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/).

Následující příklad aplikuje externí téma na snímky, které závisí na prvním masteru, a uloží prezentaci:

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

Neplatné, poškozené nebo nepodporované téma může vyvolat [PptxReadException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxreadexception/). Ověřujte cesty zadávané uživateli, ošetřete selhání přístupu k souborovému systému a prezentaci ukládejte až po úspěšné aplikaci tématu.

Přesunuty jsou jen snímky, které závisely na vybraném masteru. Snímecky přiřazené k jiným masterům zachovají své původní mastery a témata. Téma‑vědomé barvy, písma, výplně, čáry, pozadí a efekty jsou vyřešeny proti externímu tématu. Přímě přiřazené barvy, písma, výplně a další explicitní formátování mohou zůstat nezměněny. Přepsání na úrovni rozvržení i snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Téma může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytněte je prostřednictvím [custom font sources](/slides/cs/python-java/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/python-java/font-substitution/).

Jedná se o přímé workflow na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání na úrovni snímku nebo rozvržení.

### **Použít různá externí témata v prezentaci s více mastery**

Když není předem známý relevantní master, získejte jej z reprezentativního snímku pomocí [Slide.getLayoutSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getLayoutSlide) a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getMasterSlide). Uložte původní odkazy na mastery před aplikací jakýchkoli témat, protože každé volání vytvoří další master v prezentaci.

Následující příklad používá snímky ze dvou sekcí k určení jejich masterů a aplikuje odlišné externí téma na každou skupinu:

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

První volání ovlivní jen snímky, které závisí na `first_group_master`, a druhé volání jen snímky, které závisí na `second_group_master`. Snímecky patřící k jakémukoli jinému masteru nebudou přestylizovány.

### **Zachovat zdrojové téma při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, naklonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/#addClone), poté naklonujte snímek pomocí [SlideCollection.addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone) a klonovaného masteru. Tím se přenesou master, jeho rozvržení a související téma.

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

Toto je preferované workflow, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Aplikovat hodnoty tématu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním masteru a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) zkopírují tři hlavní komponenty tématu do přepsání.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/overridetheme/#clear).

### **Aplikovat přepsání tématu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky, které používají dané rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslidethememanager/):

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

Použijte téma na úrovni masteru nebo prezentace, když mnoho rozvržení a snímků má sdílet stejný základní design; použijte přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování; a použijte přepsání snímku jen pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje předvídání následných globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Výplně pozadí tématu jsou uloženy v [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint může v uživatelském rozhraní nabízet více možností pozadí, než je fyzicky uložených výplní v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální hodnotu [Background.getStyleIndex](https://reference.aspose.com/slides/cs/python-java/aspose.slides/background/#getStyleIndex). Index stylu `0` znamená žádnou tematickou výplň; kladné hodnoty jsou odkazy na styl pozadí tématu. Toto se liší od indexování samotné kolekce, kde `get_Item(0)` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad udává počet dostupných výplní pozadí, přiřadí tematický odkaz na pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na tématu, na které master odkazuje, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze masterového pozadí nemusí tento snímek ovlivnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/background/#getEffective), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nepojetí indexu stylu jako nulově‑založeného indexu kolekce. Také se vyhněte tvrdému kódování čísla stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro konkrétní prezentaci.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/python-java/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátů tématu obsahuje oddělené kolekce výplní, čar a efektových stylů, které jsou vystaveny přes [FormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/python-java/aspose.slides/formatscheme/#getLineStyles) a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/python-java/aspose.slides/formatscheme/#getEffectStyles). Typické Office témata často obsahují tři hlavní položky stylu, které vizuálně odpovídají subtilnímu, střednímu a intenzivnímu formátování, ale kód by měl prohlížet každou kolekci místo předpokládání pevného počtu.

![Subtilní, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Při přístupu k těmto kolekcím v Pythonu přes Java je index kolekce nulově založený: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazů stylů tvaru jsou samostatným konceptem, vystaveným přes [ShapeStyle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapestyle/). Úprava stylu tématu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylu existují, změní první styl čáry, třetí styl výplně a povolí vnější stín v třetím stylu efektu, a uloží výsledek:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí styl výplně tématu se změní na plnou lesní zelenou a třetí efektový styl získá vnější stín s odstupem 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každá forma odkazuje a zda přímé formátování nepřepíše téma.

![Styly efektů tématu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Zjištění, zda efektivní plná výplň používá barvu tématu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozvržení, masteru, stylu tématu nebo jiné úrovně formátování. Zavolejte [FillFormat.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#getEffective), aby se tato hierarchie vyřešila do neměnných efektivních dat výplně. Nejprve zkontrolujte `getFillType` na objektu efektivních dat. Pouze pokud je to `FillType.Solid`, byste měli číst vlastnosti plné výplně.

Pro plnou výplň `getSolidFillColor` vrací finální RGB hodnotu po dědičnosti, vyhledání v tématu a aplikaci transformací barev. `getSolidFillSchemeColor` vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/schemecolor/), například `Text1` nebo `Accent6`. Hodnota `SchemeColor.NotDefined` znamená, že efektivní plná výplň není založena na barvě schématu. Ve workflow, kde jsou výplně buď barvy tématu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Nepoužívejte lokální hodnotu [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/colorformat/#getSchemeColor) samotnou k třídění výplně. Například část textu může mít žádnou lokálně definovanou barvu schématu, takže její lokální hodnota je `NotDefined`, zatímco její efektivní výplň zdědí barvu tématu a vyřeší se na `Text1` nebo `Accent6`. Naopak `getSolidFillSchemeColor` vám řekne, který logický slot tématu vytvořil efektivní barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozvržení, masteru nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, auditoruje výplně tvarů i výplně částí textu, vypíše každou finální RGB hodnotu a související barvu schématu a označí plné výplně, které nebudou sledovat změny barvy tématu:

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

Větev `NotDefined` poskytuje seznam plných výplní, které nebudou reagovat na změny v slotech barvy tématu. Prohlédněte si tyto objekty, když musí prezentace následovat novou paletu značky. Udávaná RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled propojen s tématem.

Objekty efektivního formátu jsou snímky. Po změně tématu prezentace, přepsání tématu nebo jakéhokoli zděděného formátování znovu zavolejte `getEffective` a načtěte nový objekt efektivních dat výplně před porovnáním nebo hlášením barev.

## **Čtení efektivních hodnot tématu**

Syrové objekty tématu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/background/#getEffective) a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#getEffective).

Následující příklad načte efektivní téma, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasterTheme), můžete přehlédnout master, rozvržení, snímek nebo přepsání tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivní aplikace externího tématu všechny snímky v prezentaci?**

Ne. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) přepíše jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovají své stávající témata.

**Mohu aplikovat téma na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále zdědit své stávající témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu naklonujte zdrojový master do cíle a naklonujte snímek s tímto masterem pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/#addClone) a [SlideCollection.addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addClone). Tím se zachová master, rozvržení i téma společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) pro snímek nebo rozvržení a odpovídající metody efektivních dat pro formátovací objekty, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/background/#getEffective) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#getEffective). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepsání.