---
title: Beheer presentatiekoppen en -voetteksten met Python
linktitle: Kop en voettekst
type: docs
weight: 140
url: /nl/python-net/presentation-header-and-footer/
keywords:
- kop
- koptekst
- voettekst
- voetteksttekst
- kop instellen
- voettekst instellen
- handout
- notities
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u voettekst-, datum-tijd-, dia-nummer- en kop-plaatsaanduidingen op dia's, notitiepagina's en hand-outs kunt beheren met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

PowerPoint gebruikt verschillende kop- en voettekst‑plaatsaanduidingen afhankelijk van het type pagina. Aspose.Slides for Python via .NET stelt u in staat de tekst en zichtbaarheid van deze plaatsaanduidingen te beheren via header/footer‑managerklassen.

De beschikbare plaatsaanduidingen hangen af van de scope:

| Scope | Kop | Voettekst | Datum/tijd | Dia-/paginanummer |
|---|---|---|---|---|
| Reguliere dia | Nee | Ja | Ja | Ja |
| Notitie‑master | Ja | Ja | Ja | Ja |
| Notities‑dia | Ja | Ja | Ja | Ja |
| Hand‑out‑master | Ja | Ja | Ja | Ja |

Een reguliere presentatiedia heeft geen kop‑plaatsaanduiding. Koppen zijn beschikbaar op notitiepagina’s en hand‑outs. Voor reguliere dia’s gebruik je in plaats daarvan de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen.

De scope van een wijziging hangt af van de manager die u gebruikt. De [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slideheaderfootermanager/)‑klasse beheert één reguliere dia. De [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notesslideheaderfootermanager/)‑klasse beheert één notitiedia. Master‑ en layout‑managers kunnen de instellingen ook doorgeven aan afhankelijke dia’s, terwijl de [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterhandoutslideheaderfootermanager/)‑klasse de hand‑out‑master beheert.

## **Voettekst, datum/tijd en dia‑nummers instellen op reguliere dia’s**

Voor reguliere dia’s is de basisworkflow om de header/footer‑manager van elke dia te benaderen, de voettekst‑ en datum/tijd‑tekst in te stellen, de benodigde plaatsaanduidingen in te schakelen en de presentatie op te slaan. Dia‑nummers worden door de presentatie gegenereerd, dus u hoeft alleen hun zichtbaarheid te regelen.

Gebruik [`set_footer_text`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) en [`set_date_time_text`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) om tekst in te stellen, en gebruik [`set_footer_visibility`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/) en [`set_slide_number_visibility`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) om de overeenkomstige plaatsaanduidingen te tonen.

Het volgende end‑to‑end‑voorbeeld past dezelfde voettekst, datum/tijd‑tekst en dia‑nummer‑zichtbaarheid toe op alle reguliere dia’s:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Als u slechts één dia wilt bijwerken, benader die dia rechtstreeks via de [`slides`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slides/nl/)‑verzameling in plaats van door de volledige collectie te itereren.

## **Koppen en voetteksten instellen op de notitie‑master**

De notitie‑master definieert gemeenschappelijke opmaak en plaatsaanduidingsgedrag voor notitiepagina’s. Gebruik de [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/)‑klasse wanneer u alleen de notitie‑master zelf wilt wijzigen.

Het volgende voorbeeld stelt kop, voettekst en datum/tijd‑tekst in op de notitie‑master en maakt alle ondersteunde plaatsaanduidingen zichtbaar op die master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Een presentatie kan geen notitie‑master bevatten, controleer daarom de geretourneerde waarde op `None` voordat u deze wijzigt.

## **Instellingen van notitie‑master toepassen op onderliggende notitiedia’s**

Een notitie‑master kan kop‑ en voettekstinstellingen toepassen op zichzelf en op alle afhankelijke notitiedia’s. Gebruik de speciale propagatiemethoden op [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/) wanneer dezelfde instellingen door de notitie‑hiërarchie heen moeten worden toegepast.

Bijvoorbeeld, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) en [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) werken de notitie‑master‑kop en alle onderliggende koppen bij. Gelijke methoden zijn beschikbaar voor voetteksten, datum/tijd en dia‑nummers.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

De hierboven gebruikte propagatiemethoden zijn [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/) en [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Koppen en voetteksten instellen op een individuele notitiedia**

Een notitiedia behoort tot een specifieke reguliere dia. Gebruik de [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notesslideheaderfootermanager/)‑klasse wanneer u alleen die notitiepagina wilt aanpassen.

De [`add_notes_slide`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notesslidemanager/add_notes_slide/)‑methode retourneert de notitiedia voor de huidige dia en maakt er een aan indien deze nog niet bestaat. Het volgende voorbeeld configureert de notitiepagina die is gekoppeld aan de eerste presentatiedia:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Als u eerst de instellingen van de notitie‑master doorgeeft en daarna een individuele notitiedia wijzigt, laten de latere per‑dia‑instellingen u die notitiepagina onafhankelijk aanpassen.

## **Koppen en voetteksten instellen op de hand‑out‑master**

Hand‑out‑pagina’s gebruiken de hand‑out‑master voor hun kop‑, voettekst‑, datum/tijd‑ en paginanummer‑plaatsaanduidingen. In tegenstelling tot notitiepagina’s worden hand‑out‑instellingen beheerd via de hand‑out‑master in plaats van via individuele hand‑out‑dia’s.

Gebruik de eigenschap [`master_handout_slide`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) om de hand‑out‑master te benaderen. Indien deze niet aanwezig is, roep [`set_default_master_handout_slide`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) aan om de standaard hand‑out‑master te maken.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Scope en overerving begrijpen**

Kies de header/footer‑manager die overeenkomt met de scope die u wilt wijzigen:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slideheaderfootermanager/) wijzigt voettekst-, datum/tijd‑ en dia‑nummerinstellingen voor één reguliere dia.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslideheaderfootermanager/) beheert een layout‑dia en kan ondersteunde instellingen doorgeven aan afhankelijke dia’s.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslideheaderfootermanager/) beheert een reguliere diasmaster en kan ondersteunde instellingen doorgeven aan afhankelijke dia’s.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/) beheert de notitie‑master en kan instellingen doorgeven aan alle afhankelijke notitiedia’s.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notesslideheaderfootermanager/) wijzigt één notitiedia en ondersteunt een kop‑plaatsaanduiding naast voettekst, datum/tijd en dia‑nummer.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) wijzigt de hand‑out‑master en ondersteunt alle vier de plaatsaanduidingstypen.

Gebruik propagatie vanuit een master of layout wanneer dezelfde instelling door de volledige hiërarchie moet gelden. Gebruik een individuele dia‑ of notitiedia‑manager wanneer u een lokale instelling voor één pagina nodig heeft.

## **FAQ**

**Kan ik een kop toevoegen aan een reguliere dia?**

Nee. PowerPoint definieert geen kop‑plaatsaanduiding voor reguliere dia’s. Op reguliere dia’s gebruikt u de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen. Koppplaatsaanduidingen zijn beschikbaar op notitiepagina’s en hand‑outs.

**Wat als een voettekst-, datum/tijd- of dia‑nummer‑plaatsaanduiding niet zichtbaar is?**

Gebruik de overeenkomstige header/footer‑manager om de zichtbaarheid te controleren en deze indien nodig in te schakelen. Bijvoorbeeld, [`is_footer_visible`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) geeft aan of er een voettekst‑plaatsaanduiding aanwezig is, en [`set_footer_visibility`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) wijzigt de zichtbaarheid.

**Hoe start ik de dia‑nummering vanaf een andere waarde dan 1?**

Stel de eigenschap [`first_slide_number`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/first_slide_number/) van de presentatie in. De dia‑nummer‑plaatsaanduidingen gebruiken vervolgens de bijgewerkte nummeringsreeks.

**Wat gebeurt er met koppen en voetteksten bij het exporteren naar PDF, afbeeldingen of HTML?**

Zichtbare kop‑ en voettekstelementen worden samen met de rest van de presentatiewaarde gerenderd in het uitvoerformaat. Hun weergave hangt af van het geëxporteerde paginatype en de bijbehorende plaatsaanduidings‑zichtbaarheidsinstellingen.