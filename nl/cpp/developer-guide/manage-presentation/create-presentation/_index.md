---
title: Presentaties maken in C++
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/cpp/create-presentation/
keywords:
- presentatie maken
- nieuwe presentatie
- PPT maken
- nieuwe PPT
- PPTX maken
- nieuwe PPTX
- ODP maken
- nieuwe ODP
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Maak presentaties in C++ met Aspose.Slides—produceer PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning, en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe je een presentatie maakt met Aspose.Slides, eenvoudige inhoud aan een dia toevoegt en het resultaat opslaat als een bestand.

## **Maak een PowerPoint‑presentatie**
Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volg je de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse.
1. Verkrijg de referentie van een dia door gebruik te maken van de Index.
1. Voeg een AutoShape van het type Lijn toe met de AddAutoShape‑methode die beschikbaar is via het Shapes‑object.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**Naar welke formaten kan ik een nieuwe presentatie opslaan?**

Je kunt opslaan naar [PPTX, PPT en ODP](/slides/nl/cpp/save-presentation/), en exporteren naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/nl/cpp/convert-powerpoint-to-xps/), [HTML](/slides/nl/cpp/convert-powerpoint-to-html/), [SVG](/slides/nl/cpp/convert-powerpoint-to-png/), en [afbeeldingen](/slides/nl/cpp/convert-powerpoint-to-png/), onder andere.

**Kan ik starten vanaf een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?**

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en vergelijkbare formaten [worden ondersteund](/slides/nl/cpp/supported-file-formats/).

**Hoe kan ik de dia‑grootte/aspectverhouding regelen bij het maken van een presentatie?**

Stel de [dia‑grootte](/slides/nl/cpp/slide-size/) in (inclusief voorgedefinieerde formaten zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet schalen.

**In welke eenheden worden maten en coördinaten gemeten?**

In points: 1 inch is gelijk aan 72 eenheden.

**Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugenverbruik te verminderen?**

Gebruik [BLOB‑beheersstrategieën](/slides/nl/cpp/manage-blob/), beperk opslag in het geheugen door tijdelijke bestanden te gebruiken, en geef de voorkeur aan werkstromen op basis van bestanden boven louter in‑memory streams.

**Kan ik presentaties parallel maken/opslaan?**

Je kunt niet op dezelfde [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie werken vanuit [meerdere threads](/slides/nl/cpp/multithreading/). Gebruik aparte, geïsoleerde instanties per thread of proces.

**Hoe verwijder ik het proef‑watermerk en de beperkingen?**

[Pas een licentie toe](/slides/nl/cpp/licensing/) één keer per proces. De licentie‑XML moet ongewijzigd blijven, en de licentie‑instelling moet gesynchroniseerd worden als meerdere threads betrokken zijn.

**Kan ik de PPTX die ik maak digitaal ondertekenen?**

Ja. [Digitale handtekeningen](/slides/nl/cpp/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

**Worden macro's (VBA) ondersteund in aangemaakte presentaties?**

Ja. Je kunt [VBA‑projecten maken/bewerken](/slides/nl/cpp/presentation-via-vba/) en macro‑ingeschakelde bestanden zoals PPTM/PPSM opslaan.