---
title: Dia's toevoegen aan presentaties in C++
linktitle: Dia toevoegen
type: docs
weight: 10
url: /nl/cpp/add-slide-to-presentation/
keywords:
- dia toevoegen
- dia maken
- lege dia
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Voeg eenvoudig dia's toe aan je PowerPoint- en OpenDocument-presentaties met Aspose.Slides for C++ — vloeiende, efficiënte dia-invoeging in enkele seconden."
---
## **Overzicht**

Aspose.Slides stelt je in staat om dia's toe te voegen aan PowerPoint‑presentaties via code. Een presentatie bevat master-/lay-outdia's en gewone dia's, en gewone dia's worden geordend op een nul‑gebaseerde index. Elke dia heeft een unieke ID, en presentaties zonder dia's worden niet ondersteund.

Dit artikel legt uit hoe je een `Presentation`‑object maakt, de dia‑collectie benadert, een lege dia toevoegt, werkt met de nieuw toegevoegde dia en de bijgewerkte presentatie opslaat. Het behandelt ook gerelateerde punten zoals het invoegen van dia's op een specifieke positie, het gebruik van lay-outs, en het begrijpen van de lege dia die bestaat in een nieuw aangemaakte presentatie.

## **Een dia toevoegen aan een presentatie**
Voordat we spreken over het toevoegen van dia's aan presentatie‑bestanden, bespreken we eerst enkele feiten over dia's. Elke PowerPoint‑presentatie‑file bevat een master‑/lay‑outdia en andere gewone dia's. Dat betekent dat een presentaties‑file ten minste één dia bevat. Het is belangrijk te weten dat presentaties zonder dia's niet ondersteund worden door Aspose.Slides for C++. Elke dia heeft een unieke Id en alle gewone dia's worden gerangschikt volgens een nul‑gebaseerde index. Aspose.Slides for C++ stelt ontwikkelaars in staat om lege dia's aan hun presentatie toe te voegen. Om een lege dia toe te voegen, volg je de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.  
- Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/)‑klasse door een referentie te zetten op de Slides‑eigenschap (collectie van inhoudsdia‑objecten) van het Presentation‑object.  
- Voeg een lege dia toe aan de presentatie aan het einde van de collectie inhoudsdia's door de AddEmptySlide‑methoden aan te roepen die door het ISlideCollection‑object worden blootgelegd.  
- Voer enige bewerkingen uit op de nieuw toegevoegde lege dia.  
- Schrijf ten slotte het presentatie‑bestand weg met het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑object.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **Veelgestelde vragen**

**Kan ik een nieuwe dia op een specifieke positie invoegen, niet alleen aan het einde?**

Ja. De bibliotheek ondersteunt dia‑collecties en [insert](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidecollection/insertclone/)‑operaties, zodat je een dia kunt toevoegen op de gewenste index in plaats van alleen aan het einde.

**Worden de thema's/stijlen behouden bij het toevoegen van een dia op basis van een lay-out?**

Ja. Een lay-out erft de opmaak van zijn master, en de nieuwe dia erft van de geselecteerde lay-out en de bijbehorende master.

**Welke dia staat er in een nieuwe “lege” presentatie vóór het toevoegen van dia's?**

Een nieuw aangemaakte presentatie bevat al één lege dia met index nul. Dit is belangrijk om rekening mee te houden bij het berekenen van invoeg‑indices.

**Hoe kies ik de “juiste” lay-out voor een nieuwe dia als de master veel opties heeft?**

Kies doorgaans de [LayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/layoutslide/) die overeenkomt met de gewenste structuur ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidelayouttype/)). Als zo’n lay‑out ontbreekt, kun je deze [add it to the master](/slides/nl/cpp/slide-layout/) en vervolgens gebruiken.