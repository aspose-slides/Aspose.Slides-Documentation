---
title: Dia-layouts toepassen of wijzigen in Python via Java
linktitle: Dia-layout
type: docs
weight: 60
url: /nl/python-java/slide-layout/
keywords:
- dia-layout
- inhoudslayout
- placeholder
- presentatie-ontwerp
- dia-ontwerp
- ongebruikte lay-out
- voettekst-zichtbaarheid
- titeldia
- titel en inhoud
- sectiekop
- twee inhoud
- vergelijking
- alleen titel
- lege layout
- inhoud met bijschrift
- afbeelding met bijschrift
- titel en verticale tekst
- verticale titel en tekst
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Dia-layouts toepassen, maken en wijzigen in Aspose.Slides voor Python via Java, placeholders toevoegen, ongebruikte lay-outs verwijderen en de voettekst-zichtbaarheid beheren."
---
## **Overzicht**

Een dia‑lay‑out definieert de posities en opmaak van placeholders zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een lay‑out geeft dia's een consistente structuur terwijl elke dia zijn eigen inhoud kan bevatten.

- **Titel­dia**: Bevat placeholder voor titel en ondertitel.
- **Titel en inhoud**: Bevat een titel‑placeholder en een algemene inhouds‑placeholder.
- **Leeg**: Bevat geen inhouds‑placeholders en is handig wanneer elke vorm handmatig wordt geplaatst.

## **Begrijp layout‑overerving**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [masterdia](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
1. Een [lay-outdia](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/) behoort tot een master en definieert een specifieke rangschikking van placeholders.
1. Een [normale dia](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/) gebruikt één lay‑out en slaat de inhoud op die voor die dia is ingevoerd.

Een normale dia erft thema en opmaak van zijn lay‑out, en de lay‑out erft van de master. Een waarde die rechtstreeks op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de placeholder‑vormen gegenereerd vanuit de geselecteerde lay‑out, terwijl de inhoud die in die placeholders wordt ingevoerd tot de normale dia behoort.

Voeg vereiste placeholders toe aan een lay‑out voordat je er dia's vanuit maakt. Later een extra placeholder aan een lay‑out toevoegen resulteert niet automatisch in een overeenkomstige placeholder‑vorm op bestaande normale dia's.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of bestaande placeholder‑geometrie op een lay‑out kan elke dia die ervan afhankelijk is bijwerken. Controleer vóór het bewerken van een al in gebruik zijnde lay‑out de afhankelijke dia's en controleer de resulterende presentatie.
- Een lay‑out die nog door een dia wordt gebruikt, kan niet worden verwijderd. Ken eerst de afhankelijke dia's aan een andere lay‑out toe, of verwijder alleen ongebruikte lay‑outs.

Voor meer informatie over het hoogste niveau van deze hiërarchie, zie [Slide Master](/slides/nl/python-java/slide-master/).

## **Selecteer en pas een dia‑lay‑out toe**

Gebruik een lay‑outtype wanneer de presentatie de standaard PowerPoint‑lay‑outdefinities volgt. Lay‑outnamen zijn door de gebruiker bewerkbaar en kunnen worden gelokaliseerd, waardoor selectie op basis van naam minder betrouwbaar is tenzij je de bron‑template beheert.

Het volgende voorbeeld zoekt naar **Titel en inhoud** op de eerste master. Als die lay‑out niet beschikbaar is, valt het expres terug op **Leeg**. De tweede controle op `None` is noodzakelijk omdat een presentatie uitsluitend aangepaste lay‑outs kan bevatten. De geselecteerde lay‑out wordt vervolgens toegepast op de eerste normale dia via de [Slide.setLayoutSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#setLayoutSlide) methode.

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

Het wijzigen van de lay‑out van een dia verwijdert niet de gewone vormen die rechtstreeks aan de dia zijn toegevoegd. Echter, placeholder‑posities, geërfde opmaak en de overeenkomst tussen bestaande placeholders en de nieuwe lay‑out kunnen veranderen, dus controleer de output bij het wisselen tussen wezenlijk verschillende lay‑outs.

## **Voeg een lay‑outdia toe**

Selectie en creatie zijn afzonderlijke handelingen. Het vorige voorbeeld selecteert een bestaande lay‑out; het maakt er geen aan. Om een lay‑out te maken, roep je de [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterlayoutslidecollection/#add) methode aan op de lay‑outcollectie van de beoogde master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud** lay‑out toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe op basis daarvan. Lay‑outnamen moeten uniek zijn binnen de collectie.

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

Voeg alleen een lay‑out toe wanneer de template daadwerkelijk een extra herbruikbare structuur nodig heeft. Als er al een geschikte lay‑out bestaat, selecteer en hergebruik deze in plaats van een duplicaat te maken.

## **Voeg placeholders toe aan een lay‑outdia**

De [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getPlaceholderManager) methode biedt een [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/) om placeholder‑vormen aan een lay‑out toe te voegen.

| PowerPoint‑placeholder | [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/) Method |
| ---------------------- | --------------------------------------------------------------------------------------------------------------------------------- |
| ![Inhoud](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhoud (verticaal)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (verticaal)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Afbeelding](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafiek](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabel](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online‑afbeelding](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Het volgende voorbeeld controleert of de **Leeg** lay‑out bestaat, voegt er vier placeholders aan toe, en maakt vervolgens een normale dia die de aangepaste lay‑out gebruikt. De volgorde is opzettelijk: de placeholders worden toegevoegd voordat de normale dia wordt aangemaakt, zodat Aspose.Slides de overeenkomstige placeholder‑vormen op die dia kan genereren.

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

Het resultaat:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande lay‑out‑placeholders kan invloed hebben op afhankelijke dia's. Een nieuw toegevoegde lay‑out‑placeholder wordt niet retroactief toegevoegd aan bestaande normale dia's. Test lay‑out‑wijzigingen op een kopie van de presentatie en controleer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte lay‑outdia's**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) methode om lay‑outs te verwijderen waar geen enkele normale dia naar verwijst. De methode laat lay‑outs die nog in gebruik zijn onaangeroerd.

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

Om één specifieke lay‑out te verwijderen, gebruik eerst de [hasDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#hasDependingSlides) of [getDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getDependingSlides) methode. Ken eventuele afhankelijke dia's opnieuw toe voordat je [LayoutSlide.remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#remove) aanroept. Een poging om een gebruikte lay‑out te verwijderen resulteert in een [PptxEditException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxeditexception/).

## **Bestuur de zichtbaarheid van de voettekst op een lay‑outdia**

Een lay‑out heeft zijn eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑placeholders. Gebruik de [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) methode om die placeholders voor één lay‑out te beheren. Dit is handig wanneer bijvoorbeeld inhoudslay‑outs voetteksten moeten tonen, maar titel‑lay‑outs niet.

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

## **Bestuur de zichtbaarheid van de voettekst op een master en diens onderliggende lay‑outs**

Om consistente voettekst‑instellingen toe te passen over een master‑hiërarchie, gebruik je de [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getHeaderFooterManager) methode. De propagatiemethoden van [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslideheaderfootermanager/) werken op de master en zijn afhankelijke lay‑outdia's en normale dia's; ze richten zich niet uitsluitend op één enkele normale dia.

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

**Wat is het verschil tussen een masterdia en een lay‑outdia?**

Een masterdia definieert het thema en de gedeelde opmaak van de presentatie. Een lay‑outdia behoort tot een master en definieert één herbruikbare rangschikking van placeholders. Normale dia's gebruiken die lay‑outs en slaan dia‑specifieke inhoud op.

**Kan ik een lay‑outdia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de bestemmingscollectie met de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/globallayoutslidecollection/#addClone) methode. Bij het kopiëren tussen presentaties moet je ook lettertypen, thema's, afbeeldingen en andere bronnen die door de bron‑lay‑out worden gebruikt verifiëren.

**Wat gebeurt er als ik een al gebruikte lay‑out wijzig?**

Afhankelijke dia's erven de lay‑out‑wijzigingen tenzij ze de betreffende opmaak of objecten lokaal overschrijven. Placeholder‑geometrie en geërfde styling kunnen daardoor op veel dia's tegelijk veranderen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getDependingSlides) om de getroffen dia's te identificeren vóór het bewerken van de lay‑out.

**Wat gebeurt er als ik een lay‑out verwijder die nog in gebruik is?**

Aspose.Slides geeft een [PptxEditException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxeditexception/) fout. Ken eerst de afhankelijke dia's opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) om alleen niet‑gerefereerde lay‑outs te verwijderen.