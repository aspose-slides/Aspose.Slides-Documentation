---
title: Dia-indelingen toepassen of wijzigen in Python via Java
linktitle: Dia-indeling
type: docs
weight: 60
url: /nl/python-java/slide-layout/
keywords:
- dia-indeling
- inhoudsindeling
- placeholder
- presentatie-ontwerp
- dia-ontwerp
- ongebruikte indeling
- voettekst-zichtbaarheid
- titel-dia
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
- Java
- Aspose.Slides
description: Pas dia-indelingen toe, maak ze aan en wijzig ze in Aspose.Slides voor Python via Java, voeg placeholders toe, verwijder ongebruikte indelingen en beheer de zichtbaarheid van de voettekst.
---
## **Overzicht**

Een dia‑indeling definieert de posities en opmaak van tijdelijke elementen zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een indeling geeft dia’s een consistente structuur, terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende indelingen zijn:

- **Titel‑dia**: Bevat titel‑ en subtitel‑placeholder‑elementen.
- **Titel en inhoud**: Bevat een titel‑placeholder en een algemene inhouds‑placeholder.
- **Leeg**: Bevat geen inhouds‑placeholder‑elementen en is handig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp overerving van indelingen**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [master‑dia](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/) definieert het thema, de gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
1. Een [indelings‑dia](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/) behoort tot een master en definieert een bepaalde rangschikking van placeholders.
1. Een [normale dia](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/) gebruikt één indeling en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn indeling, en de indeling erft van zijn master. Een waarde die rechtstreeks op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de placeholder‑vormen gegenereerd uit de geselecteerde indeling, terwijl de ingevoerde inhoud in die placeholders bij de normale dia hoort.

Voeg de benodigde placeholders toe aan een indeling voordat je er dia’s van maakt. Later een extra placeholder aan een indeling toevoegen, voegt niet automatisch een overeenkomstige placeholder‑vorm toe aan bestaande normale dia’s.

Deze relatie heeft twee belangrijke gevolgen:

- Het wijzigen van geërfde opmaak of bestaande placeholder‑geometrie op een indeling kan elke dia die ervan afhankelijk is bijwerken. Controleer vóór het bewerken van een al in gebruik zijnde indeling de afhankelijke dia’s en bekijk de resulterende presentatie.
- Een indeling die nog door een dia wordt gebruikt, kan niet worden verwijderd. Ken eerst de afhankelijke dia’s toe aan een andere indeling toe, of verwijder alleen ongebruikte indelingen.

Voor meer informatie over het hoogste niveau van deze hiërarchie, zie [Dia‑master](/slides/nl/python-java/slide-master/).

Om geërfde logo’s of decoratieve master‑vormen op één dia of via een gedeelde indeling te verbergen, zie [Stuur de zichtbaarheid van master‑graphics](/slides/nl/python-java/slide-master/). Het voorbeeld vergelijkt twee dia’s die dezelfde master gebruiken.

## **Selecteer en pas een dia‑indeling toe**

Gebruik een indelingstype wanneer de presentatie de standaard PowerPoint‑indelingsdefinities volgt. Indelingsnamen zijn door de gebruiker bewerkbaar en kunnen gelokaliseerd worden, waardoor selecteren op naam minder betrouwbaar is tenzij je de bron‑sjabloon beheert.

Het volgende voorbeeld zoekt **Titel en inhoud** op de eerste master. Als die indeling niet beschikbaar is, valt het opzettelijk terug op **Leeg**. De tweede controle op `None` is nodig omdat een presentatie alleen aangepaste indelingen kan bevatten. De geselecteerde indeling wordt vervolgens toegepast op de eerste normale dia via de [Slide.setLayoutSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#setLayoutSlide)‑methode.

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

Het wijzigen van de indeling van een dia verwijdert geen gewone vormen die direct aan de dia zijn toegevoegd. Echter, placeholder‑posities, geërfde opmaak en de overeenkomst tussen bestaande placeholders en de nieuwe indeling kunnen wijzigen, dus controleer de output bij het wisselen tussen wezenlijk verschillende indelingen.

## **Voeg een indelings‑dia toe**

Selectie en aanmaak zijn afzonderlijke handelingen. Het vorige voorbeeld selecteert een bestaande indeling; het maakt er geen nieuwe aan. Om een indeling aan te maken, roep je de [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterlayoutslidecollection/#add)‑methode aan op de indelingscollectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud**‑indeling toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe op basis daarvan. Indelingsnamen moeten uniek zijn binnen de collectie.

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

Voeg alleen een indeling toe wanneer het sjabloon echt een extra herbruikbare structuur nodig heeft. Als er al een geschikte indeling bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg placeholders toe aan een indelings‑dia**

De [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getPlaceholderManager)‑methode biedt een [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/) voor het toevoegen van placeholder‑vormen aan een indeling.

| PowerPoint‑placeholder | [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/) Methode |
| ---------------------- | --------------------------------------------------------------------------------------------------------------------------------- |
| ![Inhoud](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhoud (verticaal)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (verticaal)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Afbeelding](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabel](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online‑afbeelding](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Het volgende voorbeeld controleert of de **Leeg**‑indeling bestaat, voegt er vier placeholders aan toe en maakt vervolgens een normale dia die de aangepaste indeling gebruikt. De volgorde is opzettelijk: de placeholders worden toegevoegd vóórdat de normale dia wordt aangemaakt, zodat Aspose.Slides de overeenkomstige placeholder‑vormen op die dia kan genereren.

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

![De placeholders op de indelings‑dia](add_placeholders.png)

{{% alert color="warning" title="Waarschuwing" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande indelings‑placeholders kan afhankelijke dia’s beïnvloeden. Een nieuw toegevoegde indelings‑placeholder wordt niet automatisch aangevuld in bestaande normale dia’s. Test indelingswijzigingen op een kopie van de presentatie en controleer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte indelings‑dia's**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides)‑methode om indelingen die door geen normale dia worden gerefereerd te verwijderen. De methode laat indelingen die nog in gebruik zijn ongewijzigd.

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

Om één specifieke indeling te verwijderen, gebruik eerst de [hasDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#hasDependingSlides)‑ of [getDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getDependingSlides)‑methode. Ken alle afhankelijke dia’s opnieuw toe voordat je [LayoutSlide.remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#remove) aanroept. Pogingen om een gebruikte indeling te verwijderen geven een [PptxEditException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxeditexception/) terug.

## **Stuur de zichtbaarheid van de voettekst op een indelings‑dia**

Een indeling heeft eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑placeholders. Gebruik de [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getHeaderFooterManager)‑methode om die placeholders voor één indeling te beheersen. Handig wanneer bijvoorbeeld inhouds‑indelingen footers moeten tonen maar titel‑indelingen niet.

Het volgende voorbeeld selecteert veilig een indeling en maakt de voettekst‑elementen zichtbaar:

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

## **Stuur de zichtbaarheid van de voettekst op een master en de onderliggende indelingen**

Om consistente voettekst‑instellingen door een master‑hiërarchie heen toe te passen, gebruik je de [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getHeaderFooterManager)‑methode. De propagatiemethoden van [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslideheaderfootermanager/) werken op de master en op de afhankelijke indelings‑dia’s en normale dia’s; ze richten zich niet op één enkele normale dia.

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

**Wat is het verschil tussen een master‑dia en een indelings‑dia?**

Een master‑dia definieert het thema en de gedeelde opmaak van de presentatie. Een indelings‑dia behoort tot een master en definieert één herbruikbare rangschikking van placeholders. Normale dia’s gebruiken die indelingen en slaan dia‑specifieke inhoud op.

**Kan ik een indelings‑dia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de doel‑collectie met de [addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/globallayoutslidecollection/#addClone)‑methode. Bij het kopiëren tussen presentaties dien je ook lettertypen, thema’s, afbeeldingen en andere door de bron‑indeling gebruikte bronnen te controleren.

**Wat gebeurt er als ik een indeling wijzig die al in gebruik is?**

Afhankelijke dia’s erven de wijzigingen in de indeling, tenzij ze de getroffen opmaak of objecten lokaal hebben overschreven. Placeholder‑geometrie en geërfde styling kunnen daardoor in één keer op veel dia’s veranderen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getDependingSlides) om de getroffen dia’s te identificeren vóór je de indeling bewerkt.

**Wat gebeurt er als ik een indeling verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxeditexception/). Ken eerst de afhankelijke dia’s opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) om alleen niet‑gerefereerde indelingen te verwijderen.