---
title: Hantera slide‑masters i presentationer i Python via Java
linktitle: Slide‑master
type: docs
weight: 70
url: /sv/python-java/slide-master/
keywords:
- slide‑master
- master‑slide
- PPT‑master‑slide
- flera master‑bilder
- jämför master‑bilder
- bakgrund
- platshållare
- klona master‑bild
- kopiera master‑bild
- duplicera master‑bild
- oanvänd master‑bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera slide‑masters i Aspose.Slides för Python via Java: åtkomst, redigering, kloning, jämförelse och borttagning av master‑bilder i PowerPoint- och OpenDocument‑presentationer."
---
## **Översikt**

En **slide‑master** definierar gemensamma designinställningar för en grupp bilder. Den kan innehålla vanliga former, logotyper, bakgrunder, textstilar, temainställningar och fotoinställningar. I PowerPoint är redigering av en slide‑master det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje bild.

Aspose.Slides för Python via Java stödjer samma modell. En presentation kan innehålla en eller flera masterbilder, och varje masterbild kan innehålla flera layoutbilder. Normala bilder refererar vanligtvis inte direkt till en masterbild. Istället använder en normal bild en layoutbild, och den layoutbilden tillhör en masterbild.

Hierarkin är:

1. **Slide master** – definierar den delade designen och temat.  
2. **Layout slide** – definierar en specifik placering av platshållare och layout‑nivåformatering.  
3. **Normal slide** – innehåller det faktiska presentationsinnehållet och använder en layoutbild.

![Hierarkin för masterbilder, layoutbilder och normala bilder](slide-master_2.jpg)

I Aspose.Slides representeras en slide‑master av klassen [MasterSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/). Alla masterbilder i en presentation är tillgängliga via samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasters), som representeras av [MasterSlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Arv" %}}

När samma egenskap definieras på mer än en nivå vinner den mer specifika nivån. Till exempel, om en masterbild och en layoutbild båda definierar en bakgrund, använder bilder baserade på den layouten layout‑bakgrunden. För mer information om layoutbilder, se [Apply or Change Slide Layouts](/slides/sv/python-java/slide-layout/).

{{% /alert %}}

## **Åtkomst till slide‑masters**

I PowerPoint kan du öppna slide‑master‑vyn via **Visa** > **Slide Master**.

![Slide Master‑kommandot på PowerPoint‑fliken Visa](slide-master_3.jpg)

I Aspose.Slides använder du samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasters) för att komma åt masterbilder:

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

Du kan också hämta masterbilden som en normal bild använder via dess layout:

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

## **Vad en slide‑master innehåller**

En masterbild är ett bild‑likt objekt. Den ärver från [BaseSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/), så den exponerar många av samma bildegenskaper som vanliga och layoutbilder använder. Master‑specifika medlemmar listas på API‑sidan för [MasterSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/).

Vanligt använda master‑medlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getBackground) | Ställer in master‑nivåns bakgrund för bilden. |
| [getShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getShapes) | Lagrar former placerade på masteren, såsom logotyper, bildramar och delad text. |
| [getLayoutSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getLayoutSlides) | Lagrar layoutbilderna som tillhör masteren. |
| [getThemeManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getThemeManager) | Ger åtkomst till master‑tema‑API:erna. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Styr rubriker, sidfötter, datum och bildnummer för masteren och dess underliggande layouter. |
| [getDependingSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getDependingSlides) | Returnerar normala bilder som är beroende av masteren via sina layouter. |

## **Lägg till en bild i en slide‑master**

När du lägger till en bild i en masterbild visas den på bilder som använder layouter från den masteren. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första masterbilden:

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

## **Arbeta med platshållare**

Platshållare definieras normalt på layoutbilder. Masterbilden tillhandahåller den gemensamma stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns platshållarkommandon i Slide Master‑vyn.

![Infoga platshållare‑kommandot i PowerPoint Slide Master‑vy](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides arbetar du med den layoutbild som tillhör masteren:

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

Du kan också formatera platshållarformer som redan finns på en masterbild. Följande exempel hittar titel‑platshållaren och tillämpar en linjär gradientfyllning:

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

![Formaterad titel‑platshållare ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/slides/sv/python-java/manage-placeholder/) och [Text Formatting](/slides/sv/python-java/text-formatting/).

## **Ändra bakgrund för en slide‑master**

En master‑bakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel ställer in en solid bakgrundsfärg för den första masterbilden:

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

## **Klona en slide‑master till en annan presentation**

Använd [MasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/#addClone) för att kopiera en masterbild till en annan presentation. Den kopierade masteren kan sedan användas av layouter och bilder i målpresentationen.

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

## **Lägg till flera slide‑masters**

En presentation kan innehålla flera masterbilder. Detta är användbart när olika avsnitt kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera masterbilder](slide-master_9.jpg)

Följande exempel klonar standard‑masteren, ger klonen en annan bakgrund, skapar en layout under den klonade masteren och lägger till en ny bild baserad på den layouten:

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

## **Jämför slide‑masters**

Masterbilder kan jämföras med metoden [equals](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#equals) som ärvs från [BaseSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, som bild‑ID:n, eller dynamiska platshållarvärden, som aktuellt datum.

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

## **Ställ in Slide Master‑vyn som standardvy**

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

## **Ta bort oanvända master‑bilder**

Presentationer kan ibland innehålla masterbilder som inte längre används av några normala bilder. Att ta bort oanvända masters kan minska filstorleken och förenkla underhållet av mallar.

Använd [removeUnused](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/#removeUnused) för att ta bort oanvända masters från samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getMasters):

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

Du kan också använda den låga‑kod‑metoden [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

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

**Vad är skillnaden mellan en slide‑master och en layout‑slide?**

En slide‑master definierar gemensamma designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layout‑slide tillhör en master‑slide och definierar en specifik placering av platshållare. En normal bild använder en layout‑slide, så den ärver både från layouten och masteren.

**Kan en presentation innehålla flera slide‑masters?**

Ja. En presentation kan innehålla flera slide‑masters. Använd flera masters när olika avsnitt behöver olika visuella system eller varumärkesprofil.

**Ska jag lägga till platshållare på en master‑slide eller en layout‑slide?**

I de flesta fall lägger du till platshållare på layout‑slides. Placera delade visuella element och gemensam formatering på master‑slide‑n, och lägg sedan innehålls‑platshållare på de layouter som normala bilder kommer att använda.

**Kan jag ta bort en master‑slide som fortfarande används?**

Nej. En master‑slide som har beroende bilder kan inte tas bort säkert direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en rengöringsmetod för oanvända masters som bara tar bort masters som inte används.