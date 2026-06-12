---
title: Beheer presentatie‑koppen en -voetteksten met Python
linktitle: Kop en voettekst
type: docs
weight: 140
url: /nl/python-net/presentation-header-and-footer/
keywords:
- kop
- koptekst
- voettekst
- voettekst
- kop instellen
- voettekst instellen
- hand-out
- notities
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Python via .NET om koppen en voetteksten toe te voegen en aan te passen in PowerPoint- en OpenDocument‑presentaties voor een professionele uitstraling."
---
## **Overzicht**

Aspose.Slides for Python stelt u in staat om de kop‑ en voettekst‑plaatsaanduidingen in een presentatie nauwkeurig te beheren. Voettekst, datum/tijd en slide‑nummers op dia’s worden beheerd vanuit het master‑niveau en kunnen globaal worden toegepast of per dia worden aangepast. Koppen worden ondersteund op notities en hand‑outs, waar u de zichtbaarheid kunt schakelen en de tekst voor kop, voettekst, datum/tijd en paginanummers kunt instellen via de speciale header & footer‑manager op de master‑notities‑dia of individuele notities‑dia’s. Dit artikel beschrijft de belangrijkste patronen voor het bijwerken van deze plaatsaanduidingen en het consistent doorvoeren van wijzigingen in uw deck.

## **Kop‑ en voettekst beheren**

In dit gedeelte leert u hoe u kop‑ en voettekstinhoud in een presentatie kunt beheren – de voettekst, datum en tijd, en dia‑nummers inschakelen of aanpassen. We geven een kort overzicht van de toepassingsgebieden voor deze instellingen (de volledige presentatie, individuele dia’s, en notities/hand‑outs) en tonen hoe u de Aspose.Slides‑API kunt gebruiken om ze snel en consistent bij te werken.

Het code‑voorbeeld hieronder opent een presentatie, schakelt de voettekst in en stelt de tekst in, werkt de koptekst bij op de master‑notities‑dia, en slaat het bestand op.

```py
import aspose.slides as slides

# Functie om de koptekst in te stellen.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Laad de presentatie.
with slides.Presentation("sample.pptx") as presentation:
    # Stel de voettekst in.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Toegang tot en bijwerken van de koptekst.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Sla de presentatie op.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Kop‑ en voettekst beheren op notities‑dia’s**

In dit gedeelte leert u hoe u koppen en voetteksten specifiek voor notities‑dia’s in Aspose.Slides kunt beheren. We behandelen het inschakelen van de betreffende plaatsaanduidingen, het instellen van tekst voor voetteksten, datum/tijd en paginanummers, en het consequent toepassen van deze wijzigingen op de notities‑master en individuele notities‑pagina’s.

Volg de onderstaande stappen:

1. Laad een presentatiebestand.  
2. Haal de master‑notities‑dia op en de bijbehorende [header & footer manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
3. Schakel op de master‑notities‑dia de zichtbaarheid van Header, Footer, Slide number en Date-time in voor de master en alle onderliggende notities‑dia’s.  
4. Stel op de master‑notities‑dia de tekst in voor Header, Footer en Date-time voor de master en alle onderliggende notities‑dia’s.  
5. Haal de notities‑dia op voor de eerste presentatiedia en de bijbehorende [header & footer manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/notesslideheaderfootermanager/).  
6. Zorg voor deze eerste notities‑dia ervoor dat Header, Footer, Slide number en Date-time zichtbaar zijn (schakel alle uitgeschakelde items in).  
7. Stel voor deze eerste notities‑dia de tekst in voor Header, Footer en Date-time.  
8. Sla de presentatie op in PPTX‑formaat.  

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Maak de master notities-dia en alle onderliggende header-, footer-, slide‑nummer- en datum/tijd‑plaatsaanduidingen zichtbaar.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Stel tekst in op de master notities-dia en alle onderliggende header-, footer- en datum/tijd‑plaatsaanduidingen.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Wijzig de header-, footer-, slide‑nummer- en datum/tijd‑instellingen alleen voor de eerste notities‑dia.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Zorg ervoor dat de header-, footer-, slide‑nummer- en datum/tijd‑plaatsaanduidingen zichtbaar zijn.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Stel tekst in op de header-, footer- en datum/tijd‑plaatsaanduidingen van de notities‑dia.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Sla de presentatie op.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik een "header" toevoegen aan gewone dia’s?**

In PowerPoint bestaat een "Header" alleen voor notities en hand‑outs; op gewone dia’s zijn de ondersteunde elementen de voettekst, datum/tijd en dia‑nummer. In Aspose.Slides geldt dezelfde beperking: header alleen voor Notes/Handout, en op dia’s — Footer/DateTime/SlideNumber.

**Wat als de lay-out geen voettekst‑gebied bevat—kan ik de zichtbaarheid "inschakelen"?**

Ja. Controleer de zichtbaarheid via de header/footer manager en schakel deze in indien nodig. Deze API‑indicatoren en methoden zijn ontworpen voor gevallen waarin de plaatsaanduiding ontbreekt of verborgen is.

**Hoe laat ik het dia‑nummer beginnen vanaf een andere waarde dan 1?**

Stel het [first slide number](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/first_slide_number/) van de presentatie in; daarna wordt alle nummering opnieuw berekend. U kunt bijvoorbeeld beginnen bij 0 of 10, en het nummer op de titel‑dia verbergen.

**Wat gebeurt er met kop‑ en voetteksten bij het exporteren naar PDF/afbeeldingen/HTML?**

Ze worden gerenderd als gewone textelementen van de presentatie. Met andere woorden, als de elementen zichtbaar zijn op dia’s/notities‑pagina’s, verschijnen ze ook in het geëxporteerde formaat naast de rest van de inhoud.