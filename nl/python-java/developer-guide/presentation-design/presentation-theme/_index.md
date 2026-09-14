---
title: Beheer presentatiethema's in Python via Java
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/python-java/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- diathema
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
description: "Beheer presentatiethema's in Aspose.Slides voor Python via Java om PowerPoint-bestanden te maken, aanpassen en converteren met consistente huisstijl."
---
## **Introductie**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het presentatieniveau‑thema beschikbaar via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasterTheme). Een presentatie kan ook themabepalingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterthememanager/#getOverrideTheme), terwijl een lay‑out of een individuele dia zijn geërfde thema kan overschrijven via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). In de praktijk wordt het effectieve thema voor een dia vastgesteld via deze overervingsketen: presentatiethema, master‑override, lay‑out‑override en dia‑override.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende themaworkflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overrides zijn verwerkt.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mastertheme/)‑object biedt toegang tot het kleurenpalet, lettertypepalet en opmaakschema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mastertheme/#getFontScheme) en [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/mastertheme/#getFormatScheme). Het inspecteren van deze collecties vóór wijziging is vooral handig wanneer een presentatie afkomstig is van een externe bron, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste themagegevens en meldt hoeveel achtergrond‑, vulling‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overrides aanwezig kunnen zijn.

## **Thema‑kleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/schemecolor/)‑enumeratie. Wanneer u de overeenkomstige vermelding in de [ColorScheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/colorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, bijgewerkt naar de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een update van een themakleur.

Het volgende end‑to‑end voorbeeld maakt een vorm die `Accent4` gebruikt, wijzigt de thema‑`Accent4`‑kleur naar rood, slaat de presentatie op, opent deze opnieuw en print de effectieve vulkleur:

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

Omdat het rechthoekige object nog gekoppeld is aan `Accent4`, wordt de zichtbare kleur rood na de themawijziging. Als u de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `Accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint genereert lichtere en donkerdere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides stelt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/colortransformoperation/)‑enumeratie.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten die van de hoofdkleuren zijn afgeleid.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `Accent4`, past luminantietransformaties toe op vijf ervan en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `Accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend vanaf de nieuwe `Accent4`‑waarde.

### **`SchemeColor`‑waarden koppelen aan `ColorScheme`‑posities**

De [SchemeColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/schemecolor/)‑enumeratie gebruikt `Text1`, `Background1`, `Text2` en `Background2`, terwijl de [ColorScheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/colorscheme/) dezelfde themaposities exposeert als `Dark1`, `Light1`, `Dark2` en `Light2`. De koppeling is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dit zijn alternatieve namen voor dezelfde themaposities; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertypepalet bevat een hoofdlettertype voor koppen en een secundair lettertype voor de hoofdtekst. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontscheme/#getMajor) en [FontScheme.getMinor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontscheme/#getMinor) exposen die sets.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themalettertype gebruikt en één regel lichaamstexte die het secundaire Latin‑themalettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofdlettertype en de hoofdtekst het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier zal niet automatisch omschakelen wanneer het themalettertype‑palet verandert.

De hoofd‑ en secundaire lettertypecollecties kunnen ook lettertypetoewijzingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
Voor meer informatie over presentatiellettertypen, zie [PowerPoint Fonts](/slides/nl/python-java/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande workflows lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die van een master afhangen**

Gebruik [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) wanneer u een PowerPoint‑themabestand (`.thmx`) heeft en elke dia wilt herontwerpen die afhankelijk is van een bepaalde master. Selecteer de master uit de [Presentation.getMasters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasters)‑collectie, weergegeven door [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/), en geef het themabestandspad door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Wijs de nieuwe master toe aan alle dia’s die vóórheen afhankelijk waren van de geselecteerde master.
1. Retourneert de nieuw aangemaakte [MasterSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/).

Het volgende voorbeeld past een extern thema toe op de dia’s die afhankelijk zijn van de eerste master en slaat de presentatie op:

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

Een ongeldig, corrupt of niet‑ondersteund thema kan een [PptxReadException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxreadexception/) veroorzaken. Valideer paden die door gebruikers worden opgegeven, verwerk fouten bij bestands‑systeemtoegang, en sla de presentatie alleen op nadat het thema succesvol is toegepast.

Alleen de dia’s die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia’s die bij andere masters horen behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden afgehandeld volgens het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen onveranderd blijven. Overrides op lay‑out‑ of dia‑niveau kunnen ook voorrang krijgen op waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen verwijzen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, bied ze aan via [custom font sources](/slides/nl/python-java/custom-font/), of configureer [font substitution](/slides/nl/python-java/font-substitution/).

Dit is een directe master‑niveau workflow: de methode accepteert een bestands­pad naar een `.thmx`‑bestand en vereist geen handmatig aanmaken van dia‑ of lay‑out‑thema‑overrides.

### **Verschillende externe thema’s toepassen in een presentatie met meerdere masters**

Wanneer de relevante master vooraf niet bekend is, haal deze dan op via een representatieve dia met [Slide.getLayoutSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getLayoutSlide) en [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getMasterSlide). Sla de originele master‑referenties op vóór het toepassen van thema’s, omdat elke aanroep een nieuwe master in de presentatie creëert.

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

De eerste aanroep heeft alleen invloed op dia’s die afhankelijk waren van `first_group_master`, en de tweede aanroep alleen op dia’s die afhankelijk waren van `second_group_master`. Dia’s die bij een andere master horen worden niet herontworpen.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wilt u een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelpresentatie met [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/#addClone), kloon vervolgens de dia met [SlideCollection.addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone) en de gekloonde master. Dit draagt de master, zijn lay‑outs en het bijbehorende thema mee.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming exact hetzelfde uit moet zien. Het simpelweg klonen van inhoud naar een niet‑gerelateerde doel‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseert u een dia‑niveau override vanuit het bron‑thema. De methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) en [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) kopiëren de drie hoofdthema‑componenten naar de override.

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

Dit wijzigt het thema dat die dia gebruikt zonder het thema dat door andere dia’s wordt geërfd aan te passen. Om de lokale override te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/overridetheme/#clear) aan.

### **Een thema‑override toepassen op een lay‑out**

Een lay‑out‑niveau override geldt voor dia’s die die lay‑out gebruiken, tenzij een bepaalde dia een eigen override heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslidethememanager/):

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

Gebruik een master‑ of presentatiethema wanneer veel lay‑outs en dia’s hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑outfamilie een andere styling nodig heeft, en een dia‑override alleen voor echte uitzonderingen. Overmatige dia‑niveau overrides maken latere globale themawijzigingen moeilijker voorspelbaar.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nl/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint kan in de UI meer achtergrondkeuzes tonen dan het aantal vullingsdefinities dat fysiek in deze collectie is opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteer de opgeslagen collectie en de huidige [Background.getStyleIndex](https://reference.aspose.com/slides/nl/python-java/aspose.slides/background/#getStyleIndex). Een stijl‑index van `0` betekent geen themavulling; positieve waarden zijn verwijzingen naar thema‑achtergrondstijlen. Dit verschilt van het indexeren van de collectie zelf, waarbij `get_Item(0)` het eerste opgeslagen item betekent. Ga niet ervan uit dat elke presentatie evenveel achtergrondvullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themaverwijzing die door de master wordt gebruikt en van eventuele achtergrond‑overrides op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond heeft, kan het wijzigen van alleen de master‑achtergrond die dia niet beïnvloeden. Gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/background/#getEffective) wanneer u de definitieve achtergrond na overerving moet weten.

{{% alert color="warning" title="Warning" %}}
Beschouw de stijl‑index niet als een nul‑gebaseerde collecti­index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en veronderstel dat het dezelfde weergave heeft in een ander bestand; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/python-java/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑formaatschema bevat aparte collecties voor vulling‑, lijn‑ en effectstijlen, beschikbaar via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nl/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nl/python-java/aspose.slides/formatscheme/#getLineStyles) en [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nl/python-java/aspose.slides/formatscheme/#getEffectStyles). Veel Office‑thema’s bevatten vaak drie hoofdstijl‑items die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van uitgaan van een vast aantal.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Wanneer u deze collecties in Python via Java benadert, is de collectie‑index nul‑gebaseerd: `get_Item(0)` is de eerste opgeslagen stijl en `get_Item(2)` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, beschikbaar via [ShapeStyle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak blijven mogelijk ongewijzigd.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vullingsstijl, schakelt een buiten­schaduw in bij de derde effectstijl en slaat het resultaat op:

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

Voor vormen die deze slots refereren, wordt de eerste themalijnstijl rood, de derde themavullingsstijl een ondoorzichtig bosgroen, en krijgt de derde effectstijl een buiten­schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijl‑slots elke vorm referereert en of directe opmaak de thema‑instelling overschrijft.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Bepalen of een effectieve effen vulkleur een themakleur gebruikt**

Een vulkleur kan direct op een object worden opgeslagen of geërfd van een alinea, lay‑out, master, themastijl of een ander opmaakniveau. Roep [FillFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/#getEffective) aan om die hiërarchie om te zetten in een onveranderlijk effectief vulgegevensobject. Controleer eerst `getFillType` op het effectieve data‑object. Alleen wanneer dit `FillType.Solid` is, moet u de eigenschappen van de effen vulkleur lezen.

Voor een effen vulkleur geeft `getSolidFillColor` de uiteindelijk gerenderde RGB‑waarde terug na overerving, themazakering en kleurtransformaties. `getSolidFillSchemeColor` geeft het bijbehorende logische [SchemeColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/schemecolor/)‑slot terug, zoals `Text1` of `Accent6`. Een waarde van `SchemeColor.NotDefined` betekent dat de effectieve effen vulkleur niet gebaseerd is op een schema‑kleur. In een workflow waar vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, duidt deze waarde op een directe RGB‑vulling.

Gebruik niet alleen de lokale waarde van [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/colorformat/#getSchemeColor) om een vulling te classificeren. Een tekstdeel kan bijvoorbeeld geen lokaal gedefinieerde schema‑kleur hebben, waardoor de lokale waarde `NotDefined` is, terwijl de effectieve vulling een themakleur erft en resolveert naar `Text1` of `Accent6`. Daarentegen vertelt `getSolidFillSchemeColor` u welk logisch themaslot de effectieve kleur heeft geproduceerd, maar niet van welk niveau (object, alinea, lay‑out, master, etc.) de slot afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vorm‑ als tekst‑deel‑vullingen, print elke uiteindelijke RGB‑waarde en bijbehorende schema‑kleur, en markeert effen vullingen die geen themakleur‑wijzigingen volgen:

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

De `NotDefined`‑tak levert een auditlijst van effen vullingen die niet reageren op wijzigingen in themakleurslots. Bekijk die objecten wanneer een presentatie moet voldoen aan een nieuw merkpalet. De gerapporteerde RGB‑waarde geeft nog steeds het huidige uiterlijk weer, terwijl de schema‑waarde uitlegt of dat uiterlijk gekoppeld is aan het thema.

Effectieve‑formaatobjecten zijn momentopnames. Na het wijzigen van het presentatiethema, een thema‑override, of enige geërfde opmaak, roep `getEffective` opnieuw aan en lees een nieuw effectief vulgegevensobject voordat u kleuren vergelijkt of rapporteert.

## **Effectieve thema‑waarden lezen**

Ruwe thema‑objecten vertellen u wat er op een bepaald niveau is gedefinieerd. Effectieve waarden laten zien wat een dia of vorm feitelijk gebruikt na overerving en lokale overrides. Voor een dia, roep [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) aan. Voor een achtergrond, gebruik [Background.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/background/#getEffective), en voor een vulling, gebruik [FillFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/#getEffective).

Het volgende voorbeeld leest het effectieve thema, de achtergrond, en de eerste vorm‑vulling van een dia:

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

Gebruik effectieve gegevens voor weergavediagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasterTheme) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑override missen die het uiteindelijke uiterlijk verandert.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) wijst alleen de dia’s opnieuw toe die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken behouden hun bestaande thema’s.

**Kan ik een thema op één enkele dia toepassen zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidethememanager/) van de dia en initialiseer zijn override‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s overerven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en de oorspronkelijke vormgeving wilt behouden, kloon dan de bron‑master naar de bestemming en kloon de dia met die master via [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslidecollection/#addClone) en [SlideCollection.addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addClone). Hiermee blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overrides?**

Gebruik [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑data‑methoden voor formatobjecten zoals [Background.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/background/#getEffective) en [FillFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/#getEffective). Deze API’s retourneren de opgeloste waarden na overerving en overrides.