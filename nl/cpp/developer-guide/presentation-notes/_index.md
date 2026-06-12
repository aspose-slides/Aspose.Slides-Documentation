---
title: Beheer presentatienotities in C++
linktitle: Presentatienotities
type: docs
weight: 110
url: /nl/cpp/presentation-notes/
keywords:
- notities
- notitieslide
- notities toevoegen
- notities verwijderen
- notitiestijl
- masternotities
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Pas presentatienotities aan met Aspose.Slides voor C++. Werk naadloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functie, inclusief hoe notities te verwijderen en hoe een stijl toe te passen op notitieslides in een presentatie. Aspose.Slides stelt u in staat notities van elke dia te verwijderen en ook opmaak toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Verwijder notities van een specifieke dia in een presentatie.
- Verwijder notities van alle dia's in een presentatie.

## **Notities van een specifieke dia verwijderen**
De notities van een bepaalde dia kunnen worden verwijderd zoals weergegeven in het voorbeeld hieronder:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Notities van alle dia's verwijderen**
De notities van alle dia's van een presentatie kunnen worden verwijderd zoals weergegeven in het voorbeeld hieronder:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Een notitiestijl toevoegen**
De NotesStyle‑eigenschap is toegevoegd aan de IMasterNotesSlide‑interface en de MasterNotesSlide‑klasse. Deze eigenschap specificeert de stijl van een notitietekst. De implementatie wordt gedemonstreerd in het voorbeeld hieronder.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**Welke API‑entiteit biedt toegang tot de notities van een specifieke dia?**

Notities worden benaderd via de notitiesbeheerder van de dia: de dia heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/notesslidemanager/) en een [method](https://reference.aspose.com/slides/nl/cpp/aspose.slides/notesslidemanager/get_notesslide/) die het notitieobject retourneert, of `null` als er geen notities zijn.

**Zijn er verschillen in notitie‑ondersteuning tussen de PowerPoint‑versies waarmee de bibliotheek werkt?**

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑en nieuwer) en ODP; notities worden ondersteund in deze formaten zonder dat er een geïnstalleerde kopie van PowerPoint nodig is.