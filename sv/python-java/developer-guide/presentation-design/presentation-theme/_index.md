---
title: Hantera presentationsteman i Python via Java
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/python-java/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- ange tema
- ändra tema
- hantera tema
- externt tema
- THMX
- temafärg
- ytterligare palett
- temateckensnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Styr presentationsteman i Aspose.Slides för Python via Java för att skapa, anpassa och konvertera PowerPoint-filer med enhetlig varumärkesprofil."
---
## **Introduktion**

Ett presentations‑tema definierar en samordnad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Tema‑medvetna objekt refererar till dessa delade definitioner istället för att lagra varje visuellt attribut som ett fast värde, så ett temabyte kan uppdatera många objekt samtidigt.

I Aspose.Slides finns presentationsnivå‑temaet tillgängligt via [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasterTheme). En presentation kan också innehålla temautövrigganden på lägre nivåer. En master kan åsidosätta presentations‑temat via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterthememanager/#getOverrideTheme), medan en layout eller en enskild bild kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentations‑tema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Temakomponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa av effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

[MasterTheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/mastertheme/)‑objektet exponerar temats färgschema, teckensnittsschema och formatschema via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/mastertheme/#getFontScheme) och [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/mastertheme/#getFormatScheme). Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposter kan variera.

Följande exempel läser huvudtema‑egenskaperna och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effektstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är kopplad till bilden, och använd arbetsflödet för effektiva teman som visas senare i artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Tema‑medvetna fyllningar, linjer och text kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/schemecolor/). När du ändrar motsvarande post i [ColorScheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/colorscheme/), löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

Följande end‑to‑end‑exempel skapar en form som använder `Accent4`, ändrar temats `Accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den effektiva fyllningsfärgen:

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

Eftersom rektangeln förblir länkad till `Accent4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schemafärgen med en direkt färg på formen, kommer senare förändringar av `Accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att tillämpa färgtransformeringar. Aspose.Slides exponerar dessa transformeringar via uppräkningen [ColorTransformOperation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare samt mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** – Huvudtemafärger.

**2** – Ljusa och mörka varianter som produceras från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `Accent4`, tillämpar luminans‑transformeringar på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `Accent4` ändras senare beräknas de transformerade färgerna om från det nya `Accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `ColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/schemecolor/) använder `Text1`, `Background1`, `Text2` och `Background2`, medan [ColorScheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/colorscheme/) exponerar samma temaplatser som `Dark1`, `Light1`, `Dark2` och `Light2`. Mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som dynamiskt konverteras från en form till en annan.

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller en huvudteckensnittssats för rubriker och en mindre teckensnittssats för brödtext. Metoderna [FontScheme.getMajor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontscheme/#getMajor) och [FontScheme.getMinor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontscheme/#getMinor) exponerar dessa satser.

PowerPoint‑kompatibla temateckensnittsidenterare kan användas i textformatering:

* `+mn-lt` – Brödtext‑teckensnitt Latin (Minor Latin Font)
* `+mj-lt` – Rubrik‑teckensnitt Latin (Major Latin Font)
* `+mn-ea` – Brödtext‑teckensnitt Östasiatiskt (Minor East Asian Font)
* `+mj-ea` – Rubrik‑teckensnitt Östasiatiskt (Major East Asian Font)

Följande exempel skapar en rubrik som använder huvud‑Latin‑temateckensnittet och en brödtextlinje som använder det mindre Latin‑temateckensnittet. Därefter ändras temateckensnitten och resultatet sparas:

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

Rubriken följer huvudteckensnittet och brödtexten följer det mindre teckensnittet. Text som har ett explicit teckensnittnamn istället för en temaidentifierare byter inte automatiskt när temateckensnittsschemat ändras.

De stora och små teckensnittssamlingarna kan också innehålla teckensnittsmappningar för enskilda skriftsystem, såsom kyrilliska, arabiska, japanska, georgiska och thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script‑Specific Theme Fonts](/slides/sv/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
För mer information om presentations‑teckensnitt, se [PowerPoint Fonts](/slides/sv/python-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en masters beroende bilder**

Använd [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som beror på en viss master. Välj master från samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasters), representerad av [MasterSlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar en ny masterslides baserad på den valda master‑sliden.
1. Tillämpa det externa temat på den nya master‑sliden.
1. Tilldela den nya master‑sliden till alla bilder som tidigare berodde på den valda master‑sliden.
1. Returnerar den nyss skapade [MasterSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/).

Följande exempel tillämpar ett externt tema på de bilder som beror på den första master‑sliden och sparar presentationen:

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

Ett ogiltigt, korrupt eller ej stödt tema kan orsaka [PptxReadException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxreadexception/). Validera sökvägar som matas in av användare, hantera misslyckade filsystem‑åtkomster och spara presentationen först när temat har tillämpats utan fel.

Endast de bilder som berodde på den valda master‑sliden omfördelas. Bilder som är kopplade till andra masters behåller sina befintliga masters och teman. Tema‑medvetna färger, teckensnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, teckensnitt, fyllningar och annan explicit formatering kan förbli oförändrade. Åsidosättningar på layout‑ och bildnivå kan också ha företräde framför värden som ärvts från den nya master‑sliden.

Temat kan referera till teckensnitt som inte finns i körningsmiljön. För konsekvent rendering och export, installera de nödvändiga teckensnitten, tillhandahåll dem via [custom font sources](/slides/sv/python-java/custom-font/), eller konfigurera [font substitution](/slides/sv/python-java/font-substitution/).

Detta är ett direkt master‑nivå‑arbetsflöde: metoden accepterar en filsökväg till en `.thmx`‑fil och kräver inte att du manuellt skapar tema‑åsidosättningar på bild‑ eller layoutnivå.

### **Tillämpa olika externa teman i en multi‑master‑presentation**

När den relevanta master‑sliden inte är känd i förväg, hämta den från en representativ bild via [Slide.getLayoutSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getLayoutSlide) och [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#getMasterSlide). Spara de ursprungliga master‑referenserna innan du tillämpar några teman eftersom varje anrop skapar en ny master i presentationen.

Följande exempel använder bilder från två avsnitt för att lokalisera deras masters och tillämpar ett annat externt tema på varje grupp:

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

Det första anropet påverkar endast bilder som berodde på `first_group_master`, och det andra anropet påverkar endast bilder som berodde på `second_group_master`. Bilder som tillhör någon annan master omstylingas inte.

### **Bevara ett källtema när bilder flyttas**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑master‑sliden till mål‑presentationen med [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/#addClone), klona sedan bilden med [SlideCollection.addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone) och den klonade master‑sliden. Detta för med sig master‑sliden, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när käll‑bilden måste se likadan ut i destinationen. Att bara klona innehåll till en orelaterad mål‑master kan ändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål‑bilden måste behålla sin nuvarande master och layout, initiera en bild‑nivå‑åsidosättning från käll‑temat. Metoderna [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) och [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) kopierar de tre huvudtema‑komponenterna till åsidosättningen.

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

Detta ändrar temat som används av den bilden utan att ändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/overridetheme/#clear).

### **Tillämpa en tema‑åsidosättning på en layout**

En layout‑nivå‑åsidosättning gäller för bilder som använder den layouten, såvida en viss bild inte har sin egen åsidosättning. Samma initieringsmetoder kan användas via [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma basdesign, en layout‑åsidosättning när en layout‑familj behöver annan styling, och en bild‑åsidosättning endast för sanna undantag. Överdriven bild‑nivå‑åsidosättning gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera tema‑bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/sv/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint kan erbjuda fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som faktiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint bakgrundsstilsgalleri för ett presentations‑tema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och det aktuella [Background.getStyleIndex](https://reference.aspose.com/slides/sv/python-java/aspose.slides/background/#getStyleIndex). Ett stilindex på `0` betyder ingen temafyllning; positiva värden är referenser till temats bakgrundsstil. Detta är annorlunda än att indexera samlingen direkt, där `get_Item(0)` betyder den första lagrade posten. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temareferens för bakgrund till den första master‑sliden och sparar presentationen:

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

Det synliga resultatet beror på den temapost som refereras av master‑sliden och på eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund, kan en förändring av endast master‑bakgrunden ha ingen effekt på den bilden. Använd [Background.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/background/#getEffective) när du behöver veta den slutgiltiga bakgrunden efter att arv har verkställts.

{{% alert color="warning" title="Warning" %}}
Behandla inte stilindexet som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det ger samma utseende i en annan fil; temastildefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/python-java/presentation-background/).
{{% /alert %}}

## **Uppdatera tema‑effekter**

Ett tema‑formatschema innehåller separata samlingar för fyllning, linje och effektstil, exponerade via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/sv/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/sv/python-java/aspose.slides/formatscheme/#getLineStyles) och [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/sv/python-java/aspose.slides/formatscheme/#getEffectStyles). Vanliga Office‑teman innehåller ofta tre huvudsakliga stilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling i stället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter tillämpade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i Python via Java är samlingsindexet nollbaserat: `get_Item(0)` är den första lagrade stilen och `get_Item(2)` är den tredje. En formes stilreferensindex är ett separat koncept, exponerat via [ShapeStyle](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapestyle/). Att ändra en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de nödvändiga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar ett yttre skuggelement i den tredje effektstilen och sparar resultatet:

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skoggrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering överskrider temat.

![Tema‑effektstilar efter ändring av linje, fyllning och skugga](presentation-design_11.png)

## **Bestäm om en effektiv solid fyllning använder en temafärg**

En fyllning kan lagras direkt på ett objekt eller ärvas från ett stycke, en layout, en master, en temastil eller en annan formateringsnivå. Anropa [FillFormat.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/#getEffective) för att lösa den hierarkin till oföränderlig effektiv fyllningsdata. Kontrollera först `getFillType` på det effektiva dataobjektet. Endast när det är `FillType.Solid` bör du läsa solid‑fyllningsegenskaperna.

För en solid fyllning returnerar `getSolidFillColor` det slutgiltiga renderade RGB‑värdet efter arv, temauppslagning och färgtransformeringar. `getSolidFillSchemeColor` returnerar motsvarande logiska [SchemeColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/schemecolor/)‑plats, såsom `Text1` eller `Accent6`. Ett värde på `SchemeColor.NotDefined` betyder att den effektiva solida fyllningen inte är baserad på en schemafärg. I ett arbetsflöde där fyllningar antingen är temafärger eller direkta RGB‑färger identifierar detta värde en direkt RGB‑fyllning.

Använd inte endast det lokala [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/colorformat/#getSchemeColor)‑värdet för att klassificera en fyllning. Till exempel kan ett textsegment sakna lokalt definierad schemafärg, så dess lokala värde är `NotDefined`, medan dess effektiva fyllning ärver en temafärg och löser till `Text1` eller `Accent6`. Omvänt visar `getSolidFillSchemeColor` vilken logisk temaplatssiffra som producerade den effektiva färgen, men den anger inte om den platsen kom från objektet, stycket, layouten, mastern eller en annan nivå i formateringshierarkin.

Följande exempel laddar en presentation, granskar både form‑fyllningar och text‑segment‑fyllningar, skriver ut varje slutgiltigt RGB‑värde och tillhörande schemafärg, samt flaggar solida fyllningar som inte kommer att följa temafärgsändringar:

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

Grenen `NotDefined` ger en granskningslista över solida fyllningar som inte svarar på förändringar i temafärgsplatser. Granska dessa objekt när en presentation måste följa en ny varumärkespalett. Det rapporterade RGB‑värdet visar fortfarande det aktuella utseendet, medan schemavärdet förklarar om det utseendet är kopplat till temat.

Effektiva formatobjekt är ögonblicksbilder. Efter att temat i presentationen, en tema‑åsidosättning eller någon ärvd formatering har ändrats, anropa `getEffective` igen och läs ett nytt effektivt fyllningsdataobjekt innan du jämför eller rapporterar färger.

## **Läs effektiva temavärden**

Råa temaobjekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala åsidosättningar har lösts. För en bild anropa [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). För en bakgrund, använd [Background.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/background/#getEffective), och för en fyllning, använd [FillFormat.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/#getEffective).

Följande exempel läser det effektiva temat, bakgrunden och den första form‑fyllningen från en bild:

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du bara inspekterar [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasterTheme) kan du missa en master‑, layout‑, bild‑ eller form‑åsidosättning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) omfördelar endast de bilder som beror på den valda master‑sliden. Bilder som använder andra masters behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra mastern?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidethememanager/) och initiera dess åsidosättnings‑tema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och vill bevara dess käll‑utseende, klona käll‑master‑sliden till destinationen och klona bilden med den master‑sliden genom [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/#addClone) och [SlideCollection.addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone). Detta behåller master‑sliden, layouterna och temat tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsidosättningar?**

Använd [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) för en bild‑ eller layout‑tema och motsvarande effektiva‑data‑metoder för formatobjekt såsom [Background.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/background/#getEffective) och [FillFormat.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/#getEffective). Dessa API‑er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.