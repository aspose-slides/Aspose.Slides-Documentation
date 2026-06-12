---
title: "Dia's toevoegen aan presentaties in .NET"
linktitle: "Dia toevoegen"
type: docs
weight: 10
url: /nl/net/add-slide-to-presentation/
keywords:
- "dia toevoegen"
- "dia maken"
- "lege dia"
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Voeg eenvoudig dia's toe aan uw PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET - naadloze, efficiënte dia-invoeging in enkele seconden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia’s toe te voegen aan PowerPoint‑presentaties via code. Een presentatie bevat master‑/layoutdia’s en gewone dia’s, en de gewone dia’s worden gerangschikt volgens een nul‑gebaseerde index. Elke dia heeft een unieke ID, en presentaties zonder dia’s worden niet ondersteund.

Dit artikel legt uit hoe u een `Presentation`‑object maakt, toegang krijgt tot de dia‑collectie, een lege dia toevoegt, werkt met de nieuw toegevoegde dia en de bijgewerkte presentatie opslaat. Het behandelt ook gerelateerde punten zoals het invoegen van dia’s op een specifieke positie, het gebruik van lay‑outs en het begrijpen van de lege dia die aanwezig is in een nieuw aangemaakte presentatie.

## **Een dia toevoegen aan een presentatie**
Voordat we ingaan op het toevoegen van dia’s aan presentatiebestanden, laten we enkele feiten over dia’s bespreken. Elk PowerPoint‑presentatiebestand bevat een master‑/layoutdia en andere normale dia’s. Dat betekent dat een presentatiebestand ten minste één of meer dia’s bevat. Het is belangrijk te weten dat presentaties zonder dia’s niet worden ondersteund door Aspose.Slides for .NET. Elke dia heeft een unieke Id en alle normale dia’s worden gerangschikt volgens een nul‑gebaseerde index. Aspose.Slides for .NET stelt ontwikkelaars in staat lege dia’s aan hun presentatie toe te voegen. Volg de onderstaande stappen om een lege dia toe te voegen aan de presentatie:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse aan.
- Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) klasse door een verwijzing naar de Slides‑eigenschap (verzameling van inhoudsdia‑objecten) in te stellen die wordt blootgesteld door het Presentation‑object.
- Voeg een lege dia toe aan de presentatie aan het einde van de collectie inhoudsdia’s door de AddEmptySlide‑methoden aan te roepen die door het ISlideCollection‑object worden aangeboden.
- Voer enige bewerkingen uit met de nieuw toegevoegde lege dia.
- Schrijf tenslotte het presentatie‑bestand weg met het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) object.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **Veelgestelde vragen**

**Kan ik een nieuwe dia op een specifieke positie invoegen, en niet alleen aan het einde?**

Ja. De bibliotheek ondersteunt dia‑collecties en de bewerkingen [insert](https://reference.aspose.com/slides/nl/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nl/net/aspose.slides/slidecollection/insertclone/) , zodat u een dia kunt toevoegen op de vereiste index in plaats van alleen aan het einde.

**Worden de thema’s/stijlen behouden bij het toevoegen van een dia op basis van een lay‑out?**

Ja. Een lay‑out erft de opmaak van zijn master, en de nieuwe dia erft van de geselecteerde lay‑out en de bijbehorende master.

**Welke dia zit er in een nieuwe "lege" presentatie voordat er dia’s worden toegevoegd?**

Een nieuw aangemaakte presentatie bevat al één lege dia met index nul. Dit is belangrijk om in overweging te nemen bij het berekenen van de invoeg‑indexen.

**Hoe kies ik de juiste lay‑out voor een nieuwe dia wanneer de master veel opties heeft?**

Kies doorgaans de [LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutslide/) die overeenkomt met de vereiste structuur (Titel en inhoud, Twee inhoud, enz.). Als zo’n lay‑out ontbreekt, kunt u deze aan de master [add it to the master](/slides/nl/net/slide-layout/) toevoegen en vervolgens gebruiken.