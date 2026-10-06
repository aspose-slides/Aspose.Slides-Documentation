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
description: "Pas presentatienotities aan met Aspose.Slides voor C++. Werk moeiteloos met PowerPoint- en OpenDocument-notities om uw productiviteit te verhogen."
---
## **Overzicht**

Aspose.Slides ondersteunt het verwijderen van notitieslides uit een presentatie. In dit onderwerp introduceren we deze functionaliteit, inclusief hoe notities te verwijderen en hoe een stijl toe te passen op notitieslides in een presentatie. Aspose.Slides stelt u in staat notities van elke slide te verwijderen en ook styling toe te passen op bestaande notities. Ontwikkelaars kunnen notities op de volgende manieren verwijderen:

- Verwijder notities van een specifieke slide in een presentatie.
- Verwijder notities van alle slides in een presentatie.

Om de afmetingen van de notitiepagina te lezen of te wijzigen, de oriëntatie te wisselen en het exportgedrag te controleren, zie [Grootte van notitiepagina](/slides/nl/cpp/notes-size/).

## **Verwijder notities van een specifieke slide**
Notities van een specifieke slide kunnen worden verwijderd zoals getoond in het voorbeeld hieronder:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Verwijder notities van alle slides**
Notities van alle slides in een presentatie kunnen worden verwijderd zoals getoond in het voorbeeld hieronder:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Een notitiestijl toevoegen**
De NotesStyle‑eigenschap is toegevoegd aan de IMasterNotesSlide‑interface en de MasterNotesSlide‑klasse. Deze eigenschap specificeert de stijl van notitietekst. De implementatie wordt gedemonstreerd in het voorbeeld hieronder.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### Welke API‑entiteit biedt toegang tot de notities van een specifieke slide?

Notities worden benaderd via de slide‑notities‑manager: de slide heeft een [NotesSlideManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/notesslidemanager/) en een [methode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/notesslidemanager/get_notesslide/) die het notitiesobject retourneert, of `null` als er geen notities zijn.

### Zijn er verschillen in de ondersteuning van notities tussen de PowerPoint‑versies waarmee de bibliotheek werkt?

De bibliotheek richt zich op een breed scala aan Microsoft PowerPoint‑formaten (97‑nieuwer) en ODP; notities worden ondersteund binnen deze formaten zonder afhankelijk te zijn van een geïnstalleerde kopie van PowerPoint.