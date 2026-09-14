---
title: Beheer presentatiekoppen en voetteksten in Python via Java
linktitle: Kop en voettekst
type: docs
weight: 140
url: /nl/python-java/presentation-header-and-footer/
keywords:
- kop
- koptekst
- voettekst
- voettekst tekst
- kop instellen
- voettekst instellen
- handout
- notities
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Learn hoe u voettekst-, datum-tijd-, dia-nummer- en kop-placeholders op dia's, notitie-pagina's en handouts kunt beheren met Aspose.Slides voor Python via Java."
---
## **Overzicht**

PowerPoint gebruikt verschillende kop‑ en voettekstplaceholders afhankelijk van het paginatype. Aspose.Slides for Python via Java stelt u in staat de tekst en zichtbaarheid van deze placeholders te beheren via header/footer‑managerklassen.

De beschikbare placeholders zijn afhankelijk van de scope:

| Scope | Kop | Voettekst | Datum/tijd | Dia/paginanummer |
|---|---|---|---|---|
| Reguliere dia | Nee | Ja | Ja | Ja |
| Notitie‑master | Ja | Ja | Ja | Ja |
| Notitiedia | Ja | Ja | Ja | Ja |
| Handout‑master | Ja | Ja | Ja | Ja |

Een regulier presentatiedia heeft geen kop‑placeholder. Koppen zijn beschikbaar op notitie‑pagina’s en handouts. Voor reguliere dia’s gebruikt u de voettekst‑, datum/tijd‑ en dia‑nummer‑placeholders.

De scope van een wijziging hangt af van de manager die u gebruikt. De [SlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideheaderfootermanager/)‑klasse beheert één reguliere dia. De [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notesslideheaderfootermanager/)‑klasse beheert één notitiedia. Master‑ en layout‑managers kunnen instellingen ook doorvoeren naar afhankelijke dia’s, terwijl de [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterhandoutslideheaderfootermanager/)‑klasse de handout‑master beheert.

## **Voettekst, datum/tijd en dia‑nummers instellen op reguliere dia’s**

Voor reguliere dia’s is de basisstroom om de header/footer‑manager van elke dia op te vragen, de voettekst‑ en datum/tijd‑tekst in te stellen, de benodigde placeholders in te schakelen en de presentatie op te slaan. Dia‑nummers worden door de presentatie gegenereerd, dus u hoeft alleen de zichtbaarheid te regelen.

Gebruik [setFooterText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) en [setDateTimeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) om tekst te zetten, en gebruik [setFooterVisibility](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) en [setSlideNumberVisibility](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) om de overeenkomstige placeholders zichtbaar te maken.

Het volgende end‑to‑end‑voorbeeld past dezelfde voettekst, datum/tijd‑tekst en zichtbaarheid van dia‑nummers toe op alle reguliere dia’s:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Als u slechts één dia wilt bijwerken, kun u die dia rechtstreeks benaderen via de [getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides)‑methode in plaats van de volledige collectie te doorlopen.

## **Koppen en voetteksten instellen op de notitie‑master**

De notitie‑master definieert gemeenschappelijke opmaak en placeholder‑gedrag voor notitiepagina’s. Gebruik de [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/)‑klasse wanneer u alleen de notitie‑master zelf wilt wijzigen.

Het volgende voorbeeld zet kop, voettekst en datum/tijd‑tekst op de notitie‑master en maakt alle ondersteunde placeholders zichtbaar op die master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De methode `getMasterNotesSlide` retourneert `None` wanneer de presentatie geen notitie‑master bevat.

## **Notitie‑masterinstellingen toepassen op onderliggende notitiedia’s**

Een notitie‑master kan kop‑ en voettekstinstellingen doorvoeren naar zichzelf en naar alle afhankelijke notitiedia’s. Gebruik de speciale propagatiemethoden op de [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/) wanneer dezelfde instellingen door de gehele notitie‑hiërarchie moeten worden toegepast.

Bijvoorbeeld, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) en [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) vernieuwen de kop van de notitie‑master en alle onderliggende koppen. Gelijkaardige methoden bestaan voor voetteksten, datum/tijd en dia‑nummers.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De hierboven gebruikte propagatiemethoden zijn [setFooterAndChildFootersText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) en [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Koppen en voetteksten instellen op een individuele notitiedia**

Een notitiedia behoort tot een specifieke reguliere dia. Gebruik de [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notesslideheaderfootermanager/)‑klasse wanneer u alleen die notitiepagina wilt aanpassen.

De [addNotesSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notesslidemanager/#addNotesSlide)‑methode retourneert de notitiedia voor de huidige dia en maakt er één aan indien deze nog niet bestaat. Het volgende voorbeeld configureert de notitiepagina die hoort bij de eerste presentatiedia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Als u eerst instellingen van de notitie‑master doorvoert en daarna een individuele notitiedia wijzigt, laten de latere per‑dia‑instellingen u toe die notitiepagina onafhankelijk aan te passen.

## **Koppen en voetteksten instellen op de handout‑master**

Handout‑pagina’s gebruiken de handout‑master voor hun kop‑, voettekst‑, datum/tijd‑ en paginanummer‑placeholders. In tegenstelling tot notitiepagina’s worden handout‑instellingen beheerd via de handout‑master en niet via individuele handout‑dia’s.

Gebruik de methode `getMasterHandoutSlide` om de handout‑master te benaderen. Als deze niet aanwezig is, roep dan `setDefaultMasterHandoutSlide` aan om de standaard handout‑master te creëren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Begrijpen van scope en overerving**

Kies de header/footer‑manager die overeenkomt met de scope die u wilt wijzigen:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideheaderfootermanager/) wijzigt voettekst-, datum/tijd- en dia‑nummervoorwaarden voor één reguliere dia.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslideheaderfootermanager/) beheert een layout‑dia en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslideheaderfootermanager/) beheert een reguliere master‑dia en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslideheaderfootermanager/) beheert de notitie‑master en kan instellingen doorvoeren naar alle afhankelijke notitiedia’s.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notesslideheaderfootermanager/) wijzigt één notitiedia en ondersteunt een kop‑placeholder naast voettekst, datum/tijd en dia‑nummer.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) wijzigt de handout‑master en ondersteunt alle vier de placeholder‑typen.

Gebruik propagatie vanuit een master‑ of layout‑manager wanneer dezelfde instelling door de gehele hiërarchie moet gelden. Gebruik een individuele dia‑ of notitiedia‑manager wanneer u een lokale instelling voor één pagina nodig heeft.

## **FAQ**

**Kan ik een koptekst toevoegen aan een regulier dia?**

Nee. PowerPoint definieert geen koptekst‑placeholder voor reguliere dia’s. Gebruik op reguliere dia’s de voettekst‑, datum/tijd‑ en dia‑nummer‑placeholders. Koptekst‑placeholders zijn beschikbaar op notitie‑pagina’s en handouts.

**Wat als een voettekst‑, datum/tijd‑ of dia‑nummer‑placeholder niet zichtbaar is?**

Gebruik de bijbehorende header/footer‑manager om de zichtbaarheid te controleren en in te schakelen wanneer nodig. Bijvoorbeeld, [isFooterVisible](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) geeft aan of een voettekst‑placeholder aanwezig is, en [setFooterVisibility](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) wijzigt de zichtbaarheid.

**Hoe start ik de dia‑nummering vanaf een andere waarde dan 1?**

Roep de [setFirstSlideNumber](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#setFirstSlideNumber)‑methode van de presentatie aan. De dia‑nummer‑placeholders gebruiken dan de bijgewerkte nummeringsreeks.

**Wat gebeurt er met kop‑ en voetteksten bij export naar PDF, afbeeldingen of HTML?**

Zichtbare kop‑ en voettekstelementen worden samen met de rest van de presentatiewijzigingen gerenderd in het uitvoerformaat. Hun uiterlijk hangt af van het paginatype dat wordt geëxporteerd en de bijbehorende placeholder‑zichtbaarheidsinstellingen.