---
title: Beheer presentatiethema's in Python via Java
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/python-java/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- dia-thema
- thema instellen
- thema wijzigen
- thema beheren
- extern thema
- THMX
- themakleur
- aanvullend palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer masterpresentatiethema's in Aspose.Slides voor Python via Java om PowerPoint-bestanden te maken, aanpassen en converteren met een consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde verzameling kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme). Een presentatie kan ook thema‑overschrijvingen bevatten op lagere niveaus. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme), terwijl een indeling of een individuele dia haar geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). In de praktijk wordt het effectieve thema voor een dia bepaald via deze overervingsketen: presentatiethema, master‑overschrijving, indelings‑overschrijving en dia‑overschrijving.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑workflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overschrijvingen zijn verwerkt.

## **Een thema inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/)‑object maakt de kleuren‑schema, lettertype‑schema en opmaak‑schema van het thema beschikbaar via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme). Deze collecties inspecteren voordat je ze wijzigt is vooral nuttig wanneer een presentatie afkomstig is van een externe bron, omdat het aantal en de inhoud van stijl‑items kunnen variëren.

Het volgende voorbeeld leest de belangrijkste themagegevens en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer er indelings‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/)‑enumeratie. Wanneer je het overeenkomstige item in de [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, herberekend met de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet aangepast door een themakleur‑update.

Het volgende end‑to‑end‑voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de `Accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve vulkleur af:

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

Omdat het rechthoek nog gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de schema‑kleur vervangt door een directe kleur op de vorm, hebben latere wijzigingen aan `Accent4` geen invloed meer op die vulling.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint maakt lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides biedt deze transformaties via de [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/)‑enumeratie.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten die zijn afgeleid van de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantie‑transformaties toe op vijf ervan, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later wijzigt, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden toewijzen aan `ColorScheme`‑posities**

De [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) dezelfde themaposities exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De koppeling is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaposities; ze zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Themalettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een sublettertype‑set voor de hoofdtekst. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) en [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) exposeren die sets.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn‑lt` – Body Font Latin (Minor Latin Font)
* `+mj‑lt` – Heading Font Latin (Major Latin Font)
* `+mn‑ea` – Body Font East Asian (Minor East Asian Font)
* `+mj‑ea` – Heading Font East Asian (Major East Asian Font)
* `+mn‑cs` – Body Font Complex Script (Minor Complex Script Font)
* `+mj‑cs` – Heading Font Complex Script (Major Complex Script Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één tekstregel die het sub‑Latin‑themalettertype gebruikt. Vervolgens wijzigt het de themalettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de hoofdtekst volgt het sublettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch schakelen wanneer het thema‑lettertype‑schema verandert.

De hoofd‑ en sublettertype‑collecties kunnen ook lettertype‑mappingen bevatten voor individuele schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Voor inspectie, toevoegen, vervangen of verwijderen van deze mapping‑s, zie [Script‑Specific Theme Fonts](/slides/nl/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
Voor meer informatie over presentatietekstlettertypen, zie [PowerPoint Fonts](/slides/nl/python-java/powerpoint-fonts/).
{{% /alert %}}

### **Thema‑lettertypereferenties oplossen**

Bij het inspecteren van tekst kan [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) een themareferentie zoals `+mn‑lt` teruggeven in plaats van een lettertype‑familienaam. Roep [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) aan met de juiste effectieve themagegevens om die referentie op te lossen. De prefixes `+mj` en `+mn` selecteren respectievelijk de hoofd‑ en sublettertype‑sets; de suffixes `-lt`, `-ea` en `-cs` selecteren hun Latin, East Asian en Complex Script‑lettertypen.

Verkrijg het effectieve thema via [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) op de themamanager van het object waarvan het thema van toepassing is op de geïnspecteerde tekst. Voor gewone tekst op een dia, gebruik de themamanager van de dia zodat de context de geërfde thema‑ en lokale overschrijvingen van die dia omvat. Bij het inspecteren van een indeling of master zelf, gebruik dan diens eigen effectieve thema. Ga niet ervan uit dat het thema van de eerste master op elke dia van toepassing is.

Het volgende voorbeeld maakt een tekstgedeelte dat expliciet verwijst naar het sub‑Latin‑lettertype. Het initialiseert een dia‑lettertype‑schema via [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) en stelt de hoofd‑ en sub‑Latin‑families in op `Arial` en `Calibri`, waardoor het resultaat reproduceerbaar is zonder invoerbestand.

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

De output is `+mn‑lt -> Calibri` gevolgd door `Verdana -> Verdana`. De opgeslagen referentie blijft ongewijzigd, terwijl een expliciete familienaam onveranderd wordt geretourneerd. Als het gedeelte `+mj‑lt` zou gebruiken, zou het oplossen naar `Arial` in dit thema.

Het oplossen van een themareferentie identificeert de lettertypefamilie die door het thema is gespecificeerd. Het controleert niet de beschikbaarheid van het lettertype of bepaalt het uiteindelijke lettertypebestand dat na substitutie of glyph‑fallback tijdens het renderen wordt gebruikt. Zie [Font Selection Sequence](/slides/nl/python-java/font-selection-sequence/) en [Font Substitution](/slides/nl/python-java/font-substitution/) voor die afzonderlijke stappen.

## **Een thema kopiëren of toepassen**

De workflows hieronder lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia’s die van een master afhangen**

Gebruik [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) wanneer je een PowerPoint‑thema‑bestand (`.thmx`) hebt en elke dia die van een bepaalde master afhangt opnieuw wilt opmaken. Selecteer de master uit de collectie [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters), vertegenwoordigd door [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/), en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe mastersdia gebaseerd op de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Wijs de nieuwe master toe aan alle dia’s die voorheen van de geselecteerde master afhankelijk waren.
1. Retourneert de nieuw aangemaakte [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/).

Het volgende voorbeeld past een extern thema toe op de dia’s die van de eerste master afhangen en slaat de presentatie op:

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

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestands‑systeemtoegang, en sla de presentatie pas op nadat het thema met succes is toegepast.

Alleen de dia’s die van de geselecteerde master afhankelijk waren, worden opnieuw toegewezen. Dia’s die gekoppeld zijn aan andere masters behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden herberekend tegen het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overschrijvingen op indelings‑ of dia‑niveau kunnen ook voorrang krijgen boven waarden die van de nieuwe master zijn geërfd.

Het thema kan verwijzen naar lettertypen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, lever ze via [custom font sources](/slides/nl/python-java/custom-font/), of configureer [font substitution](/slides/nl/python-java/font-substitution/).

Dit is een directe master‑niveau‑workflow: de methode accepteert een pad naar een `.thmx`‑bestand en vereist geen handmatig aanmaken van dia‑ of indelings‑thema‑overschrijvingen.

### **Verschillende externe thema’s toepassen in een presentatie met meerdere masters**

Wanneer de relevante master niet van tevoren bekend is, verkrijg deze via een representatieve dia met [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) en [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide). Sla de oorspronkelijke master‑referenties op voordat je thema’s toepast, omdat elke oproep een extra master in de presentatie creëert.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te vinden en past een verschillend extern thema toe op elke groep:

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

De eerste oproep heeft alleen invloed op dia’s die afhankelijk waren van `first_group_master`, en de tweede oproep alleen op dia’s die afhankelijk waren van `second_group_master`. Dia’s die bij een andere master horen, worden niet opnieuw gestyled.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wil je een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master naar de doelpresentatie met [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone), en kloon vervolgens de dia met [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) en de gekloonde master. Hiermee worden de master, de indelingen en het bijbehorende thema meegevoerd.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Alleen de inhoud klonen naar een ongerelateerde doelmaster kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Moet de doel‑dia op haar huidige master en indeling blijven, initialiseert dan een dia‑niveau‑overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) kopiëren de drie belangrijkste themacomponenten naar de overschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat andere dia’s erven te wijzigen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear) aan.

### **Een thema‑overschrijving op een indeling toepassen**

Een indelings‑overschrijving is van toepassing op alle dia’s die die indeling gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethodes kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatieniveau‑thema wanneer veel indelingen en dia’s hetzelfde basisontwerp moeten delen, een indelings‑overschrijving wanneer één indelingsfamilie een andere opmaak nodig heeft, en een dia‑overschrijving uitsluitend voor echte uitzonderingen. Overmatig veel dia‑niveau‑overschrijvingen maken latere globale thema‑wijzigingen moeilijker te voorspellen.


<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Een indelings‑overschrijving is van toepassing op dia’s die die indeling gebruiken, tenzij een dia een meer lokale overschrijving heeft. Thema‑gebaseerde waarden volgen hun opgeloste schema; expliciet geformatteerde objecten kunnen hun lokale uiterlijk behouden. Houd overschrijvingen zo smal mogelijk, overeenkomstig de beoogde ontwerp‑uitzondering.* 
<!-- visual-explanation:presentation-theme:end -->

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint kan in de UI meer achtergrondkeuzes presenteren dan het aantal vuldefinities dat feitelijk in deze collectie is opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van het direct indexeren van de collectie, waar `get_Item(0)` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvul‑stijlen bevat.

Het volgende voorbeeld meldt het beschikbare aantal achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van het themaitem waarnaar de master verwijst en van eventuele achtergrond‑overschrijvingen op indelings‑ of dia‑niveau. Als een dia een eigen achtergrond heeft, kan het wijzigen van alleen de master‑achtergrond die dia niet beïnvloeden. Gebruik [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) wanneer je de uiteindelijke achtergrond na toepassing van overerving wilt weten.

{{% alert color="warning" title="Warning" %}}
Beschouw de stijl‑index niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en de veronderstelling dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/python-java/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑opmaakschema bevat aparte collecties voor vul‑, lijn‑ en effectstijlen, toegankelijk via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles) en [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlitems die visueel overeenkomen met subtiele, matige en intense opmaak, maar code moet elke collectie inspecteren in plaats van uit een vaste telling af te gaan.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Wanneer je deze collecties in Python via Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, blootgelegd via [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak blijven mogelijk ongewijzigd.

Het volgende voorbeeld controleert of de vereiste stijlitems bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buitenste schaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl wordt solide bosgroen, en de derde effectstijl krijgt een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑slots elke vorm referereert en of directe opmaak de thema‑instelling overschrijft.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Vul‑ en lijnstijlen voor een vorm selecteren**

Een vorm kan onafhankelijk haar vulling en omtrek kiezen via [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) en [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex). Voor beide methoden selecteert index `1` het eerste item in de overeenkomstige themacollectie (`get_Item(0)`), en index `2` het tweede (`get_Item(1)`).

Het volgende voorbeeld zet twee vulstijlen (goud en hemelsblauw) en twee lijnstijlen (donkerblauw op 6 pt en donkerrood op 12 pt) op in het standaardthema van een nieuwe presentatie. Het slaat de dia op drie momenten op zodat je de resultaten in PowerPoint kunt vergelijken.

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

| Initiele stijlen | Rechtermarge aanpassen | Eerste themavulling bewerken |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

Het selecteren van een andere lijnstijl wijzigt alleen de omtrek van het rechtere rechthoek. Het bewerken van de eerste themavulling werkt elke vorm bij die die stijl gebruikt. Hier wordt alleen het linkere rechthoek groen.

Op een bestaande vorm kan een lokale vulkleur, lijnkleur of lijndikte die themastijl‑onderdeel overschrijven. Als het wijzigen van een stijl‑index geen zichtbaar effect heeft, controleer dan de [directe opmaak](/slides/nl/python-java/shape-formatting/) van de vorm.

## **Bepalen of een effectieve effen vulling een themakleur gebruikt**

Een vulling kan direct op een object worden opgeslagen of geërfd zijn van een alinea, indeling, master, themastijl of een andere opmaak‑laag. Roep [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) aan om die hiërarchie te resolveren tot een ongewijzigde effectieve vulgegevens. Controleer eerst `getFillType` op het effectieve gegevensobject. Alleen wanneer dit `FillType.Solid` is, moet je de effen‑vullings‑eigenschappen lezen.

Voor een effen vulling geeft `getSolidFillColor` de definitieve gerenderde RGB‑waarde terug na overerving, themalook‑up en kleurtransformaties. `getSolidFillSchemeColor` geeft de overeenkomstige logische [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/)‑slot terug, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor.NotDefined` betekent dat de effectieve effen vulling niet is gebaseerd op een schema‑kleur. In een workflow waarbij vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vulling.

Gebruik niet alleen de lokale [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor)‑waarde om een vulling te classificeren. Bijvoorbeeld, een tekstgedeelte kan geen lokaal gedefinieerde schema‑kleur hebben, waardoor de lokale waarde `NotDefined` is, terwijl de effectieve vulling een themakleur erft en oplost naar `Text1` of `Accent6`. Omgekeerd vertelt `getSolidFillSchemeColor` je welke logische themaslot de effectieve kleur heeft geproduceerd, maar niet van welk niveau (object, alinea, indeling, master, enz.) die slot afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vormvullingen als tekstgedeelte‑vullingen, drukt elke uiteindelijke RGB‑waarde en bijbehorende schema‑kleur af, en markeert effen vullingen die geen themakleurwijzigingen zullen volgen:

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

De `NotDefined`‑tak levert een auditlijst van effen vullingen die niet reageren op wijzigingen in themakleurslots. Controleer die objecten wanneer een presentatie een nieuw merkkleurpalet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de schema‑waarde verklaart of dat uiterlijk verbonden is met het thema.

Effectieve‑formatobjecten zijn momentopnames. Nadat je het presentatiethema, een thema‑overschrijving of een andere geërfde opmaak hebt gewijzigd, roep je opnieuw `getEffective` aan en lees je een nieuw effectief vulgegevensobject voordat je kleuren vergelijkt of rapporteert.

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten vertellen je wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen je wat een dia of vorm daadwerkelijk gebruikt na overerving en lokale overschrijvingen. Voor een dia roep je [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) aan. Voor een achtergrond gebruik je [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective), en voor een vulling [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective).

Het volgende voorbeeld leest het effectieve thema, de achtergrond, en de eerste vormvulling van een dia:

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

Gebruik effectieve gegevens voor weergavediagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) inspecteert, kun je een master‑, indelings‑, dia‑ of vorm‑overschrijving missen die het uiteindelijke uiterlijk wijzigt.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) wijzigt alleen de dia’s die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken behouden hun bestaande thema’s.

**Kan ik een thema op één dia toepassen zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) van de dia en initialiseert de overschrijving van dat thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer je een dia verplaatst en diens bron‑uiterlijk wilt behouden, kloon dan de bron‑master naar de doelpresentatie en kloon de dia met die master via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) en [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone). Hiermee blijven de master, indelingen en het thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) voor een dia‑ of indelings‑thema en de overeenkomstige effectieve‑datamethoden voor format‑objecten zoals [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) en [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective). Deze API’s retourneren de opgeloste waarden na toepassing van overerving en overschrijvingen.