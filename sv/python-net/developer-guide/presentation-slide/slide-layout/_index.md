---
title: Applicera eller ändra bildlayouter i Python
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/python-net/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- sidfotssynlighet
- titelbild
- titel och innehåll
- sektionrubrik
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
- Aspose.Slides
description: "Applicera, skapa och modifiera bildlayouter i Aspose.Slides för Python via .NET, lägg till platshållare, ta bort oanvända layouter och kontrollera sidfotssynlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen av platshållare såsom titlar, text, bilder, diagram och tabeller. Att tillämpa en layout ger bilder en konsekvent struktur samtidigt som varje bild kan innehålla sitt eget innehåll.

De vanligaste layouterna är:

- **Titelbild**: Innehåller platshållare för titel och undertitel.
- **Titel och innehåll**: Innehåller en platshållare för titel och en allmän innehållsplatshållare.
- **Tom**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå layout‑arv**

En presentation har tre relaterade nivåer:

1. En [master‑bild](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslide/) definierar temat, gemensam formatering, bakgrunder och vanliga objekt.
2. En [layout‑bild](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/) tillhör en master och definierar en specifik placering av platshållare.
3. En [normal bild](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/) använder en layout och lagrar det innehåll som matats in för den bilden.

En normal bild ärver tema och formatering från sin layout, och layouten ärver från sin master. Ett värde som sätts direkt på en normal bild åsidosätter det ärvda värdet på den nivån. När en normal bild skapas genereras dess platshållarformer från den valda layouten, medan innehållet som matas in i dessa platshållare tillhör den normala bilden.

Lägg till nödvändiga platshållare i en layout innan du skapar bilder från den. Att senare lägga till en annan platshållare i en layout lägger inte automatiskt till en motsvarande platshållarform i befintliga normala bilder.

Detta förhållande har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri i en layout kan uppdatera alla bilder som är beroende av den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela först dess beroende bilder till en annan layout, eller ta bara bort oanvända layouter.

För mer information om den översta nivån i denna hierarki, se [Slide‑master](/slides/sv/python-net/slide-master/).

## **Välj och tillämpa en bildlayout**

Använd en layouttyp när presentationen följer standarddefinitionerna för PowerPoint‑layouter. Layoutnamn kan redigeras av användaren och kan lokaleras, så namn‑baserad urval är mindre pålitligt om du inte kontrollerar källmallen.

Det följande exemplet söker efter **Titel och innehåll** på den första master‑bilden. Om den layouten inte finns, faller det avsiktligt tillbaka till **Tom**. Den andra null‑kontrollen är nödvändig eftersom en presentation kan innehålla endast anpassade layouter. Den valda layouten appliceras sedan på den första normala bilden via [Slide.layout_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/layout_slide/)-egenskapen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Att ändra en bilds layout tar inte bort vanliga former som lagts till direkt på bilden. Däremot kan platshållarpositioner, ärvd formatering och motsvarande mellan befintliga platshållare och den nya layouten förändras, så inspektera resultatet när du byter mellan väsentligt olika layouter.

## **Lägg till en layout‑bild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; det skapar inte en ny. För att skapa en layout, anropa [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterlayoutslidecollection/add/)-metoden på mål‑masterens layout‑samling.

Det följande exemplet lägger alltid till en ny **Titel och innehåll**‑layout med namnet `Report Title and Content`, och lägger därefter till en normal bild baserad på den. Layoutnamn måste vara unika inom samlingen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Lägg till en layout endast när mallen verkligen behöver en ytterligare återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den istället för att skapa en dubblett.

## **Lägg till platshållare i en layout‑bild**

[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/placeholder_manager/)-egenskapen tillhandahåller en [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/)-instans för att lägga till platshållarformer i en layout.

| PowerPoint‑platshållare            | `LayoutPlaceholderManager`‑metod |
| ---------------------------------- | --------------------------------- |
| ![Innehåll](content.png)           | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Innehåll (Vertikal)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png)                  | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertikal)](textV.png)      | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Bild](picture.png)               | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Diagram](chart.png)              | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabell](table.png)               | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)          | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)                | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online‑bild](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Det följande exemplet verifierar att **Tom**‑layouten finns, lägger till fyra platshållare i den och skapar sedan en normal bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den normala bilden skapas, så att Aspose.Slides kan generera motsvarande platshållarformer på den bilden.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Platshållarna på layout‑bilden](add_placeholders.png)

{{% alert color="warning" title="Varning" %}}
Att ändra ärvd formatering eller geometrin för befintliga layout‑platshållare kan påverka beroende bilder. En nylagd layout‑platshållare fylls inte i retroaktivt i befintliga normala bilder. Testa layout‑ändringar på en kopia av presentationen och inspektera varje beroende bild.
{{% /alert %}}

## **Ta bort oanvända layout‑bilder**

Använd [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/)-metoden för att ta bort layouter som ingen normal bild refererar till. Metoden lämnar intakta de layouter som fortfarande är i bruk.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

För att ta bort en specifik layout, använd först dess [has_depending_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/has_depending_slides/)-egenskap eller [get_depending_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/get_depending_slides/)-metod. Tilldela eventuella beroende bilder innan du anropar [LayoutSlide.remove](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/remove/). Att försöka ta bort en layout som används resulterar i ett [PptxEditException](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pptxeditexception/).

## **Styr synlighet för sidfot på en layout‑bild**

En layout har sina egna sidfot‑, bildnummer‑ och datum‑tid‑platshållare. Använd [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/header_footer_manager/)-egenskapen för att styra dessa platshållare för en specifik layout. Detta är användbart när t.ex. innehållslayouter ska visa sidfot men titel‑layouter inte ska.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Styr synlighet för sidfot på ett master‑blad och dess underordnade layouter**

För att applicera enhetliga sidfot‑inställningar över en master‑hierarki, använd [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslide/header_footer_manager/)-egenskapen. Spridnings‑metoderna i [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslideheaderfootermanager/) verkar på master‑bladet samt dess beroende layout‑bilder och normala bilder; de riktar sig inte endast mot en enskild normal bild.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Vad är skillnaden mellan en master‑bild och en layout‑bild?**

En master‑bild definierar presentationens tema och gemensam formatering. En layout‑bild tillhör en master och definierar ett återanvändbart arrangemang av platshållare. Normala bilder använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en layout‑bild från en presentation till en annan?**

Ja. Lägg till en kopia i mål‑samlingen med [add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/globallayoutslidecollection/add_clone/)-metoden. Vid kopiering mellan presentationer bör du också verifiera teckensnitt, teman, bilder och andra resurser som layouten använder.

**Vad händer när jag ändrar en layout som redan används?**

Beroende bilder ärver layout‑ändringarna såvida de inte har överskrivit den berörda formateringen eller objekten lokalt. Platshållargeometri och ärvd styling kan därför förändras på många bilder samtidigt. Använd [get_depending_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/get_depending_slides/) för att identifiera de påverkade bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande används?**

Aspose.Slides kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pptxeditexception/). Tilldela först de beroende bilderna till en annan layout, eller använd [remove_unused_layout_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) för att bara ta bort orefererade layouter.