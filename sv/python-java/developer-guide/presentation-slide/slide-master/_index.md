---
title: Hantera presentations-slide-masters i Python via Java
linktitle: Bildbakgrund
type: docs
weight: 70
url: /sv/python-java/slide-master/
keywords:
- bildbakgrund
- masterbild
- PPT-masterbild
- flera master-bilder
- jämför master-bilder
- bakgrund
- platshållare
- klona master-bild
- kopiera master-bild
- duplicera master-bild
- oanvänd master-bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera slide-masters i Aspose.Slides för Python via Java: åtkomst, redigering, kloning, jämförelse och borttagning av master-bilder i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

En **slide master** definierar gemensamma designinställningar för en grupp bildspel. Den kan innehålla vanliga former, logotyper, bakgrunder, textstilar, temainställningar och sidfotinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation enhetlig utan att upprepa samma formatering på varje bild.

Aspose.Slides för Python via Java stöder samma modell. En presentation kan innehålla en eller flera master‑bilder, och varje master‑bild kan innehålla flera layout‑bilder. Vanliga bilder hänvisar normalt inte direkt till en master‑bild. Istället använder en vanlig bild en layout‑bild, och den layout‑bilden tillhör en master‑bild.

Hierarkin är:

1. **Slide master** – definierar den gemensamma designen och temat.  
1. **Layout slide** – definierar en specifik arrangemang av platshållare och layout‑nivåformatering.  
1. **Normal slide** – innehåller det faktiska presentationsinnehållet och använder en layout‑bild.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av klassen [MasterSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/). Alla master‑bilder i en presentation är tillgängliga via samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasters), som representeras av [MasterSlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
När samma egenskap definieras på mer än en nivå har den mer specifika nivån företräde. Till exempel, om en master‑bild och en layout‑bild båda definierar en bakgrund, använder bilder baserade på den layouten layout‑bakgrunden. För mer information om layout‑bilder, se [Apply or Change Slide Layouts](/slides/sv/python-java/slide-layout/).
{{% /alert %}}

## **Åtkomst till Slide Masters**

I PowerPoint kan du öppna Slide Master‑vyn via **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

I Aspose.Slides använder du samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasters) för att komma åt master‑bilder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Du kan också hämta master‑bilden som används av en normal bild via dess layout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Vad en Slide Master Innehåller**

En master‑bild är ett bild‑likt objekt. Den ärver från [BaseSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/), så den exponerar många av samma bildegenskaper som används av normala och layout‑bilder. Master‑specifika medlemmar listas på API‑sidan för [MasterSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/).

Vanligt använda master‑bildmedlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getBackground) | Anger bakgrunden på master‑nivå. |
| [getShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getShapes) | Lagrar former som placerats på mastern, såsom logotyper, bildramar och delad text. |
| [getLayoutSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getLayoutSlides) | Lagrar layout‑bilderna som tillhör mastern. |
| [getThemeManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getThemeManager) | Ger åtkomst till master‑temats API:er. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Styr sidhuvud, sidfot, datum och bildnummer för mastern och dess underliggande layouter. |
| [getDependingSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getDependingSlides) | Returnerar normala bilder som är beroende av mastern via deras layouter. |

## **Lägg till en Bild på en Slide Master**

När du lägger till en bild på en master‑bild visas den på bilder som använder layouter från den mastern. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första master‑bilden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

För mer information om bildramar, se [Picture Frame](/slides/sv/python-java/picture-frame/).

## **Styr Synligheten för Master‑Grafik**

Använd [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#setShowMasterShapes) för att dölja ärvd master‑grafik, såsom logotyper eller dekorativa former, utan att radera dem från mastern. Skicka `False` till [Slide.setShowMasterShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#setShowMasterShapes) på den bild som ska utesluta dessa grafiker och behåll `True` på bilder som ska visa dem.

Följande självständiga exempel skapar ett blått dekorativt band på en master och två bilder som använder samma tomma layout. Bandet är synligt på den första bilden och dolt på den andra. Ingen indata‑presentation eller bild krävs.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Exemplet använder layouten **Blank** som medföljer en ny presentation och tar bort den ursprungliga bildens egna platshållare.

### **Välj Omfattning för Inställningen**

En normal bild använder sin master via [Slide.getLayoutSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getLayoutSlide) och [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#getMasterSlide). Att sätta egenskapen på en enskild bild påverkar endast den bilden. Att skicka `False` till [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#setShowMasterShapes) döljer master‑grafik för bilder som använder den delade layouten, även om deras egna inställning är `True`. För att dölja grafik på bara en bild, ändra bildens egenskap och lämna den delade layouten oförändrad.

Inställningen stöds inte som en synlighetskontroll på själva master‑bilden. På en master returnerar [getShowMasterShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getShowMasterShapes) alltid `False`, och att skicka `True` till [setShowMasterShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#setShowMasterShapes) kastar ett undantag. Applicera den på en normal bild eller en layout istället.

### **Skilj på Grafik och Bakgrund**

| Åtgärd | Effekt |
| --- | --- |
| Dölj master‑grafik | Styr synligheten för ärvda master‑former utan att radera dem eller ändra bildens egna former. |
| Ändra bildens bakgrundsfyllning | Ändrar bakgrundens färg, gradient eller bild. Master‑grafik är separata former och kan förbli synliga över den bakgrunden. Se [Presentation Background](/slides/sv/python-java/presentation-background/). |
| Radera en form från master | Tar bort den delade källformen, så den inte längre är tillgänglig för någon bild som använder den mastern. |

## **Arbeta med Platshållare**

Platshållare definieras normalt på layout‑bilder. Master‑bilden tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns platshållarkommandon i Slide Master‑vyn.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides arbetar du med den layout‑bild som tillhör mastern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Du kan också formatera platshållarformer som redan finns på en master‑bild. Följande exempel hittar titel‑platshållaren och applicerar en linjär gradientfyllning:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/slides/sv/python-java/manage-placeholder/) och [Text Formatting](/slides/sv/python-java/text-formatting/).

## **Ändra Bakgrund för en Slide Master**

En master‑bakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första master‑bilden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

För relaterade ämnen, se [Presentation Background](/slides/sv/python-java/presentation-background/) och [Presentation Theme](/slides/sv/python-java/presentation-theme/).

## **Klona en Slide Master till en Annan Presentation**

Använd [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/#addClone) för att kopiera en master‑bild till en annan presentation. Den kopierade mastern kan sedan användas av layouter och bilder i destinationspresentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Om du behöver klona normala bilder tillsammans med deras master, se [Clone Slides](/slides/sv/python-java/clone-slides/).

## **Lägg till Flera Slide Masters**

En presentation kan innehålla flera master‑bilder. Detta är användbart när olika avsnitt kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Följande exempel klonar standard‑mastern, ger kopian en annan bakgrund, skapar en layout under den klonade mastern och lägger till en ny bild baserad på den layouten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Jämför Slide Masters**

Master‑bilder kan jämföras med metoden [equals](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#equals) som ärvd från [BaseSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

För mer information, se [Compare Presentation Slides](/slides/sv/python-java/compare-slides/).

## **Ställ in Slide Master‑vyn som Standardvy**

Använd metoden [setLastView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#setLastView) på [ViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för att styra vilken vy PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

För fler vyinställningar, se [Save Presentation](/slides/sv/python-java/save-presentation/).

## **Ta Bort Oanvända Master Slides**

Presentationer kan ibland innehålla master‑bilder som inte längre används av några normala bilder. Att ta bort oanvända master‑bilder kan minska filstorleken och förenkla underhållet av mallar.

Använd [removeUnused](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/#removeUnused) för att ta bort oanvända master‑bilder från samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Du kan också använda den lågkods‑metod [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Vad är skillnaden mellan en slide master och en layout‑bild?**

En slide master definierar gemensamma designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layout‑bild tillhör en master‑bild och definierar ett specifikt arrangemang av platshållare. En normal bild använder en layout‑bild, så den ärver både från layouten och mastern.

**Kan en presentation innehålla flera slide masters?**

Ja. En presentation kan innehålla flera slide masters. Använd flera master‑bilder när olika avsnitt behöver olika visuella system eller varumärkesprofil.

**Ska jag lägga till platshållare på en master‑bild eller en layout‑bild?**

I de flesta fall lägger du till platshållare på layout‑bilder. Placera delade visuella element och gemensam formatering på master‑bilden och innehållsplatshållare på layouterna som normala bilder kommer att använda.

**Kan jag radera en master‑bild som fortfarande används?**

Nej. En master‑bild som har beroende bilder kan inte säkert tas bort direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en rensningsmetod för oanvända master‑bilder som bara tar bort master‑bilder som inte är i bruk.