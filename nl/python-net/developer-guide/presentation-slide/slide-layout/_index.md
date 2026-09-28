---
title: Dia-indelingen toepassen of wijzigen in Python
linktitle: Dia-indeling
type: docs
weight: 60
url: /nl/python-net/slide-layout/
keywords:
- dia-indeling
- inhoudsindeling
- plaatsaanduiding
- presentatieontwerp
- dia-ontwerp
- ongebruikte indeling
- zichtbaarheid van voettekst
- titeldia
- titel en inhoud
- sectiekop
- twee inhoud
- vergelijking
- alleen titel
- lege indeling
- inhoud met bijschrift
- afbeelding met bijschrift
- titel en verticale tekst
- verticale titel en tekst
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Dia-indelingen toepassen, maken en wijzigen in Aspose.Slides voor Python via .NET, plaatsaanduidingen toevoegen, ongebruikte indelingen verwijderen en de zichtbaarheid van de voettekst regelen."
---
## **Overzicht**

Een dia‑indeling definieert de posities en opmaak van tijdelijke aanduidingen zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een indeling geeft dia's een consistente structuur terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende indelingen omvatten:

- **Titel dia**: Bevat tijdelijke aanduidingen voor titel en ondertitel.
- **Titel en inhoud**: Bevat een tijdelijke aanduiding voor titel en een algemene inhoudstijdelijke aanduiding.
- **Leeg**: Bevat geen inhoudstijdelijke aanduidingen en is nuttig wanneer elke vorm handmatig wordt geplaatst.

## **Begrijp de overerving van indelingen**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [masterdia](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
1. Een [indelingsdia](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/) behoort tot een master en definieert een specifieke ordening van tijdelijke aanduidingen.
1. Een [normale dia](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/) gebruikt één indeling en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn indeling, en de indeling erft van de master. Een rechtstreeks op een normale dia ingestelde waarde overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de tijdelijke aanduidingsvormen gegenereerd op basis van de geselecteerde indeling, terwijl de ingevoerde inhoud in die tijdelijke aanduidingen tot de normale dia behoort.

Voeg de vereiste tijdelijke aanduidingen toe aan een indeling voordat u er dia's vanuit maakt. Het later toevoegen van een extra tijdelijke aanduiding aan een indeling voegt niet automatisch een overeenkomstige vorm toe aan bestaande normale dia's.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of bestaande tijdelijke aanduidingsgeometrie op een indeling kan elke afhankelijke dia bijwerken. Voordat u een al in gebruik zijnde indeling bewerkt, inspecteert u de afhankelijke dia's en bekijkt u de resulterende presentatie.
- Een indeling die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst de afhankelijke dia's opnieuw toe aan een andere indeling, of verwijder alleen ongebruikte indelingen.

Voor meer informatie over het bovenste niveau van deze hiërarchie, zie [Slide Master](/slides/nl/python-net/slide-master/).

Om geërfde logo's of decoratieve master‑vormen op één dia of via een gedeelde indeling te verbergen, zie [Control the Visibility of Master Graphics](/slides/nl/python-net/slide-master/). Het voorbeeld vergelijkt twee dia's die dezelfde master gebruiken.

## **Selecteer en pas een dia‑indeling toe**

Gebruik een indelingstype wanneer de presentatie de standaard PowerPoint‑indelingsdefinities volgt. Indelingsnamen zijn door de gebruiker bewerkbaar en kunnen worden gelokaliseerd, dus selectie op naam is minder betrouwbaar tenzij u de bron‑template beheert.

Het volgende voorbeeld zoekt **Titel en inhoud** op de eerste master. Als die indeling niet beschikbaar is, valt het doelbewust terug op **Leeg**. De tweede null‑controle is noodzakelijk omdat een presentatie alleen aangepaste indelingen kan bevatten. De geselecteerde indeling wordt vervolgens toegepast op de eerste normale dia via de [Slide.layout_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/layout_slide/)‑eigenschap.

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

Het wijzigen van de indeling van een dia verwijdert geen gewone vormen die rechtstreeks aan de dia zijn toegevoegd. De positie van tijdelijke aanduidingen, geërfde opmaak en de correspondentie tussen bestaande tijdelijke aanduidingen en de nieuwe indeling kunnen echter veranderen, dus inspecteer de output wanneer u tussen wezenlijk verschillende indelingen schakelt.

## **Voeg een indelingsdia toe**

Selectie en creatie zijn aparte bewerkingen. Het vorige voorbeeld selecteert een bestaande indeling; het maakt er geen nieuwe. Om een indeling te maken, roept u de [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterlayoutslidecollection/add/)‑methode aan op de indelingscollectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud**‑indeling met de naam `Report Title and Content` toe, en voegt vervolgens een normale dia toe die daarop is gebaseerd. Indelingsnamen moeten uniek zijn binnen de collectie.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Voeg een indeling alleen toe wanneer de template echt behoefte heeft aan een extra herbruikbare structuur. Als er al een geschikte indeling bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg tijdelijke aanduidingen toe aan een indelingsdia**

De [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/placeholder_manager/)‑eigenschap biedt een [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/) voor het toevoegen van tijdelijke aanduidingsvormen aan een indeling.

| PowerPoint-tijdelijke aanduiding | `LayoutPlaceholderManager`-methode |
| -------------------------------- | ----------------------------------- |
| ![Inhoud](content.png)           | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Inhoud (Verticaal)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Tekst](text.png)               | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Tekst (Verticaal)](textV.png)  | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Afbeelding](picture.png)       | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Diagram](chart.png)            | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabel](table.png)              | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)        | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)              | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online afbeelding](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Het volgende voorbeeld controleert of de **Leeg**‑indeling bestaat, voegt vier tijdelijke aanduidingen toe en maakt vervolgens een normale dia die de gewijzigde indeling gebruikt. De volgorde is opzettelijk: de tijdelijke aanduidingen worden toegevoegd voordat de normale dia wordt aangemaakt, zodat Aspose.Slides de overeenkomstige vormen op die dia kan genereren.

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

Het resultaat:

![De tijdelijke aanduidingen op de indelingsdia](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande indelings‑tijdelijke aanduidingen kan afhankelijke dia's beïnvloeden. Een recent toegevoegde indelings‑tijdelijke aanduiding wordt niet achteraf toegevoegd aan bestaande normale dia's. Test indelingswijzigingen op een kopie van de presentatie en inspecteer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte indelingsdia's**

Gebruik de [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/)‑methode om indelingen te verwijderen die door geen enkele normale dia worden gerefereerd. De methode laat indelingen die nog in gebruik zijn intact.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Om één specifieke indeling te verwijderen, gebruik eerst de [has_depending_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/has_depending_slides/)‑eigenschap of de [get_depending_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/get_depending_slides/)‑methode. Wijs eventuele afhankelijke dia's opnieuw toe voordat u [LayoutSlide.remove](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/remove/) aanroept. Het proberen te verwijderen van een gebruikte indeling veroorzaakt een [PptxEditException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxeditexception/).

## **Regel de zichtbaarheid van voettekst op een indelingsdia**

Een indeling heeft zijn eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑tijdelijke aanduidingen. Gebruik de [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/header_footer_manager/)‑eigenschap om die tijdelijke aanduidingen voor één indeling te regelen. Dit is handig wanneer bijvoorbeeld inhoud‑indelingen voetteksten moeten tonen, maar titel‑indelingen niet.

Het volgende voorbeeld selecteert veilig een indeling en maakt de voettekstelementen zichtbaar:

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

## **Regel de zichtbaarheid van voettekst op een master en diens onderliggende indelingen**

Om consistente voettekstinstellingen toe te passen over een master‑hiërarchie, gebruik de [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslide/header_footer_manager/)‑eigenschap. De propagatiemethoden van [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslideheaderfootermanager/) werken op de master en zijn afhankelijke indelings‑ en normale dia's; ze richten zich niet alleen op één enkele normale dia.

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

## **FAQ**

**Wat is het verschil tussen een masterdia en een indelingsdia?**

Een masterdia definieert het thema van de presentatie en gedeelde opmaak. Een indelingsdia behoort tot een master en definieert één herbruikbare ordening van tijdelijke aanduidingen. Normale dia's gebruiken die indelingen en slaan diasppecifieke inhoud op.

**Kan ik een indelingsdia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de bestemmingscollectie met de [add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/globallayoutslidecollection/add_clone/)‑methode. Bij het kopiëren tussen presentaties controleert u ook lettertypen, thema's, afbeeldingen en andere bronnen die door de bron‑indeling worden gebruikt.

**Wat gebeurt er wanneer ik een indeling wijzig die al in gebruik is?**

Afhankelijke dia's erven de indelingswijzigingen tenzij ze de getroffen opmaak of objecten lokaal overschrijven. De geometrie van tijdelijke aanduidingen en geërfde stijlen kunnen daardoor op veel dia's tegelijk veranderen. Gebruik [get_depending_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/get_depending_slides/) om de getroffen dia's te identificeren voordat u de indeling bewerkt.

**Wat gebeurt er als ik een indeling verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxeditexception/). Wijs eerst de afhankelijke dia's opnieuw toe, of gebruik [remove_unused_layout_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) om alleen niet‑gerefereerde indelingen te verwijderen.