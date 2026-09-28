---
title: Tillämpa eller ändra bildlayouter i Python via Java
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/python-java/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- sidfotssynlighet
- titelsida
- titel och innehåll
- avsnittsrubrik
- två innehåll
- jämförelse
- endast titel
- tom layout
- innehåll med bildtext
- bild med bildtext
- titel och vertikal text
- vertikal titel och text
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Tillämpa, skapa och modifiera bildlayouter i Aspose.Slides för Python via Java, lägg till platshållare, ta bort oanvända layouter och kontrollera sidfotssynlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen av platshållare såsom titlar, text, bilder, diagram och tabeller. Att använda en layout ger bilder en konsekvent struktur samtidigt som varje bild kan innehålla sitt eget innehåll.

De vanligaste layouterna är:

- **Title Slide**: Innehåller platshållare för titel och undertitel.
- **Title and Content**: Innehåller en titelplatshållare och en allmän innehållsplatshållare.
- **Blank**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå layoutarv**

En presentation har tre relaterade nivåer:

1. En [master slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/) definierar temat, delad formatering, bakgrunder och gemensamma objekt.
1. En [layout slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/) tillhör en master och definierar en särskild placering av platshållare.
1. En [normal slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/) använder en layout och lagrar det innehåll som matats in för den bilden.

En normal bild ärver tema och formatering från sin layout, och layouten ärver från sin master. Ett värde som sätts direkt på en normal bild åsidosätter det ärvda värdet på den nivån. När en normal bild skapas genereras dess platshållarformer från den valda layouten, medan innehållet som matas in i dessa platshållare tillhör den normala bilden.

Lägg till nödvändiga platshållare i en layout innan du skapar bilder från den. Att lägga till en ny platshållare i en layout senare lägger inte automatiskt till motsvarande platshållarform i befintliga normala bilder.

Detta förhållande har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri i en layout kan uppdatera alla bilder som är beroende av den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela först dess beroende bilder till en annan layout, eller ta bara bort oanvända layouter.

För mer information om den översta nivån i denna hierarki, se [Slide Master](/slides/sv/python-java/slide-master/).

För att dölja ärvda logotyper eller dekorativa masterformer på en bild eller via en delad layout, se [Control the Visibility of Master Graphics](/slides/sv/python-java/slide-master/). Exemplet jämför två bilder som använder samma master.

## **Välj och tillämpa en bildlayout**

Använd en layouttyp när presentationen följer standarddefinitioner för PowerPoint‑layouter. Layoutnamn kan redigeras av användaren och kan lokalanpassas, så namnbaserad urval är mindre pålitligt om du inte kontrollerar källmallarna.

Det följande exemplet söker efter **Title and Content** på den första masteren. Om den layouten saknas faller det avsiktligt tillbaka till **Blank**. Den andra kontrollen för `None` är nödvändig eftersom en presentation kan innehålla enbart anpassade layouter. Den valda layouten tillämpas sedan på den första normala bilden via metoden [Slide.setLayoutSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Att ändra en bilds layout tar inte bort vanliga former som lagts till direkt på bilden. Dock kan platshållarpositioner, ärvd formatering och sambandet mellan befintliga platshållare och den nya layouten ändras, så inspektera utdata när du byter mellan väsentligt olika layouter.

## **Lägg till en layoutbild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; det skapar ingen. För att skapa en layout, anropa metoden [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterlayoutslidecollection/#add) på mål‑masterns layoutsamling.

Det följande exemplet lägger alltid till en ny **Title and Content**‑layout med namnet `Report Title and Content`, och lägger sedan till en normal bild baserad på den. Layoutnamn måste vara unika inom samlingen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lägg bara till en layout när mallen verkligen behöver en ytterligare återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den i stället för att skapa en dubblett.

## **Lägg till platshållare i en layoutbild**

Metoden [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#getPlaceholderManager) tillhandahåller en [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/) för att lägga till platshållarformer i en layout.

| PowerPoint‑platshållare               | [LayoutPlaceholderManager] metod |
| ------------------------------------- | --------------------------------- |
| ![Innehåll](content.png)              | [addContentPlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Innehåll (Vertikal)](contentV.png)  | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                     | [addTextPlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertikal)](textV.png)         | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Bild](picture.png)                  | [addPicturePlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png)                 | [addChartPlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabell](table.png)                  | [addTablePlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)             | [addSmartArtPlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                   | [addMediaPlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Onlinebild](onlineImage.png)        | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Det följande exemplet verifierar att **Blank**‑layouten finns, lägger till fyra platshållare i den och skapar sedan en normal bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den normala bilden skapas, så att Aspose.Slides kan generera motsvarande platshållarformer på den bilden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

{{% alert color="warning" title="Varning" %}}
Att ändra ärvd formatering eller geometrin för befintliga layout‑platshållare kan påverka beroende bilder. En nylagd layout‑platshållare fylls inte retroaktivt i befintliga normala bilder. Testa layout‑ändringar på en kopia av presentationen och inspektera varje beroende bild.
{{% /alert %}}

## **Ta bort oanvända layoutbilder**

Använd metoden [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att ta bort layouter som ingen normal bild refererar till. Metoden lämnar intakta de layouter som fortfarande används.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

För att ta bort en specifik layout, använd först dess [hasDependingSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#hasDependingSlides)‑ eller [getDependingSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#getDependingSlides)‑metod. Tilldela eventuella beroende bilder innan du anropar [LayoutSlide.remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#remove). Försök att ta bort en layout som används resulterar i ett [PptxEditException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxeditexception/).

## **Styr sidfotssynlighet på en layoutbild**

En layout har egna sidfot‑, bild‑nummer‑ och datum‑tid‑platshållare. Använd metoden [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) för att kontrollera dessa platshållare för en layout. Detta är användbart när t.ex. innehållslayouter ska visa sidfot men titellayouter inte ska göra det.

Det följande exemplet väljer säkert en layout och gör dess sidfots‑element synliga:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Styr sidfotssynlighet på en master och dess underliggande layouter**

För att tillämpa enhetliga sidfot‑inställningar över en master‑hierarki, använd metoden [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Spridningsmetoderna för [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslideheaderfootermanager/) verkar på master‑objektet samt dess beroende layout‑ och normala bilder; de riktar sig inte enbart mot en enskild normal bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Vad är skillnaden mellan en Master Slide och en Layout Slide?**

En master‑slide definierar presentationens tema och delade formateringar. En layout‑slide tillhör en master och definierar en återanvändbar placering av platshållare. Normala bilder använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en Layout Slide från en presentation till en annan?**

Ja. Lägg till en kopia i destinationssamlingen med metoden [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/globallayoutslidecollection/#addClone). När du kopierar mellan presentationer bör du även verifiera typsnitt, teman, bilder och andra resurser som layouten använder.

**Vad händer när jag ändrar en layout som redan är i bruk?**

Beroende bilder ärver layout‑ändringarna om de inte har överskuggat den berörda formateringen eller objekten lokalt. Platshållargeometri och ärvd stil kan därför ändras på många bilder samtidigt. Använd [getDependingSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#getDependingSlides) för att identifiera de påverkade bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande är i bruk?**

Aspose.Slides kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxeditexception/). Tilldela först de beroende bilderna, eller använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att bara ta bort orefererade layouter.