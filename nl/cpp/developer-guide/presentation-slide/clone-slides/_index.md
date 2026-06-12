---
title: Dia's van een presentatie klonen in C++
linktitle: Dia's klonen
type: docs
weight: 40
url: /nl/cpp/clone-slides/
keywords:
  - dia klonen
  - dia kopiëren
  - dia opslaan
  - PowerPoint
  - OpenDocument
  - presentatie
  - C++
  - Aspose.Slides
description: "Dupliceer PowerPoint-dia's snel met Aspose.Slides for C++. Volg onze duidelijke codevoorbeelden om PPT‑creatie binnen enkele seconden te automatiseren en handmatig werk te elimineren."
---
## **Inleiding**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides for C++ maakt het ook mogelijk om een kopie of kloon van elke dia te maken en die gekloonde dia vervolgens in de huidige of een andere geopende presentatie in te voegen. Het proces van dia‑klonen creëert een nieuwe dia die door ontwikkelaars kan worden aangepast zonder de originele dia te wijzigen. Er zijn verschillende mogelijke manieren om een dia te klonen:

- Kloon aan het einde binnen een presentatie.
- Kloon naar een andere positie binnen een presentatie.
- Kloon aan het einde in een andere presentatie.
- Kloon naar een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides for C++ (een verzameling van [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/) objecten) die worden blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object, worden de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) en [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methoden geboden om de bovenstaande soorten dia‑klonen uit te voeren.

## **Kloon een dia aan het einde van een presentatie**
Als je een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand wilt gebruiken aan het einde van de bestaande dia's, gebruik dan de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) klasse door te verwijzen naar de Slides‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object.
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object en geef de dia die gekloond moet worden als parameter aan de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode.
1. Schrijf het gewijzigde presentatiebestand weg.

In het onderstaande voorbeeld hebben we een dia gekloond (die op de eerste positie – index nul – van de presentatie staat) naar het einde van de presentatie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Kloon een dia naar een andere positie binnen een presentatie**
Als je een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand wilt gebruiken, maar op een andere positie, gebruik dan de [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Instantieer de klasse door te verwijzen naar de **Slides** -collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object.
1. Roep de [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object en geef de te klonen dia samen met de index voor de nieuwe positie als parameter aan de [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia gekloond (die op index nul – positie 1 – van de presentatie staat) naar index 1 – positie 2 – van de presentatie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Kloon een dia aan het einde van een andere presentatie**
Als je een dia uit de ene presentatie wilt klonen en in een andere presentatie wilt gebruiken, aan het einde van de bestaande dia's:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse die de bestemmingspresentatie bevat waaraan de dia moet worden toegevoegd.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) klasse door te verwijzen naar de **Slides** -collectie die wordt blootgesteld door het Presentation‑object van de bestemmingspresentatie.
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object en geef de dia uit de bronpresentatie als parameter aan de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode.
1. Schrijf het gewijzigde bestemmingspresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia gekloond (van de eerste index van de bronpresentatie) naar het einde van de bestemmingspresentatie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Kloon een dia naar een andere positie in een andere presentatie**
Als je een dia uit de ene presentatie wilt klonen en in een andere presentatie wilt gebruiken, op een specifieke positie:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse die de presentatie bevat waaraan de dia moet worden toegevoegd.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) klasse door te verwijzen naar de Slides‑collectie die wordt blootgesteld door het Presentation‑object van de bestemmingspresentatie.
1. Roep de [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object en geef de dia uit de bronpresentatie samen met de gewenste positie als parameter aan de [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode.
1. Schrijf het gewijzigde bestemmingspresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia gekloond (van index nul van de bronpresentatie) naar index 1 (positie 2) van de bestemmingspresentatie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Kloon een dia op een specifieke positie in een andere presentatie**
Als je een dia met master‑dia uit de ene presentatie wilt klonen en in een andere presentatie wilt gebruiken, moet je eerst de gewenste master‑dia uit de bronpresentatie naar de bestemmingspresentatie klonen. Vervolgens gebruik je die master‑dia voor het klonen van de dia met master. De **AddClone(ISlide, IMasterSlide)** verwacht een master‑dia van de bestemmingspresentatie in plaats van van de bronpresentatie. Volg de onderstaande stappen om de dia met master te klonen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse die de bestemmingspresentatie bevat waarnaar de dia wordt gekloond.
1. Toegang krijgen tot de te klonen dia samen met de master‑dia.
1. Instantieer de [IMasterSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/) klasse door te verwijzen naar de Masters‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object van de bestemmingspresentatie.
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode aan die wordt blootgesteld door het [IMasterSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/) object en geef de master uit de bron‑PPTX die gekloond moet worden als parameter aan de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) klasse door de referentie naar de Slides‑collectie te zetten die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object van de bestemmingspresentatie.
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object en geef de dia uit de bronpresentatie die gekloond moet worden en de master‑dia als parameters aan de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode.
1. Schrijf het gewijzigde bestemmingspresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia met master (die op index nul van de bronpresentatie staat) naar het einde van de bestemmingspresentatie gekloond met behulp van de master van de bron‑dia.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Kloon een dia aan het einde van een gespecificeerde sectie**
Als je een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand wilt gebruiken, maar in een andere sectie, gebruik dan de [**AddClone()**](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode die wordt blootgesteld door de [**ISlideCollection**](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/)‑interface. Aspose.Slides for C++ maakt het mogelijk om een dia uit de eerste sectie te klonen en vervolgens die gekloonde dia in de tweede sectie van dezelfde presentatie in te voegen.

De volgende code‑fragment laat zien hoe je een dia kunt klonen en de gekloonde dia in een gespecificeerde sectie kunt invoegen.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**Worden notities voor sprekers en beoordelaars gekloond?**

Ja. De notitiepagina en beoordelings‑commentaren worden mee gekloond. Als je ze niet wilt, [verwijder ze](/slides/nl/cpp/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek gelinkt was aan een externe bron (bijv. een OLE‑ingesloten werkmap), blijft die koppeling behouden als een [OLE‑object](/slides/nl/cpp/manage-ole/). Na het verplaatsen tussen bestanden, controleer de beschikbaarheid van de gegevens en het vernieuwings‑gedrag.

**Kan ik de insertie‑positie en secties voor de kloon controleren?**

Ja. Je kunt de kloon op een specifieke dia‑index invoegen en plaatsen in een gekozen [sectie](/slides/nl/cpp/slide-section/). Als de doel‑sectie niet bestaat, maak deze eerst aan en verplaats de dia er vervolgens naartoe.