---
title: Groeppresentatievormen in C++
linktitle: Vormgroep
type: docs
weight: 40
url: /nl/cpp/group/
keywords:
- groepvorm
- vormgroep
- groep toevoegen
- alternatieve tekst
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je vormen kunt groeperen en degroeperen in PowerPoint‑presentaties met Aspose.Slides voor C++ — snelle, stap‑voor‑staphandleiding met gratis C++‑code."
---
## **Overzicht**

Dit artikel legt uit hoe je met groep‑vormen werkt in Aspose.Slides. Het toont hoe je een groep‑vorm aan een dia toevoegt, vormen erin plaatst en de bijgewerkte presentatie opslaat. Het laat ook zien hoe je vormen die zich binnen een groep bevinden kunt benaderen en hun `AlternativeText`‑waarden kunt uitlezen. Daarnaast behandelt het kort gerelateerde mogelijkheden van groep‑vormen, zoals geneste groepen, z‑volgorde en vergrendelingsopties.

## **Een groepvorm toevoegen**
Aspose.Slides ondersteunt het werken met groep‑vormen op dia's. Deze functie helpt ontwikkelaars rijkere presentaties te ondersteunen. Aspose.Slides for C++ ondersteunt het toevoegen of benaderen van groep‑vormen. Het is mogelijk om vormen aan een toegevoegde groepvorm toe te voegen om deze te vullen of om een eigenschap van de groepvorm te benaderen. Om een groepvorm aan een dia toe te voegen met Aspose.Slides for C++:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Verkrijg de referentie van een dia door diens Index te gebruiken
1. Voeg een groepvorm toe aan de dia.
1. Voeg de vormen toe aan de toegevoegde groepvorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het voorbeeld hieronder voegt een groepvorm toe aan een dia.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **De AltText‑eigenschap benaderen**
Dit onderwerp toont eenvoudige stappen, compleet met code‑voorbeelden, voor het toevoegen van een groepvorm en het benaderen van de AltText‑eigenschap van groep‑vormen op dia's. Om de AltText van een groepvorm in een dia te benaderen met Aspose.Slides for C++:

1. Instantieer de `Presentation` klasse die een PPTX‑bestand vertegenwoordigt.
1. Verkrijg de referentie van een dia door diens Index te gebruiken.
1. Benader de vormverzameling van de dia's.
1. Benader de groepvorm.
1. Benader de AltText‑eigenschap.

Het voorbeeld hieronder benadert de alternatieve tekst van de groepvorm.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Wordt geneste groepering (een groep binnen een groep) ondersteund?**

Ja. [GroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/groupshape/) heeft een [get_ParentGroup](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/get_parentgroup/)‑methode, die direct aangeeft dat hiërarchie wordt ondersteund (een groep kan een kind van een andere groep zijn).

**Hoe kan ik de z‑volgorde van de groep ten opzichte van andere objecten op de dia regelen?**

Gebruik de [GroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/groupshape/)‑[Z-Order‑positie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/get_zorderposition/) om de positie in de weergave‑stack te inspecteren.

**Kan ik verplaatsen/bewerken/ontgroeperen voorkomen?**

Ja. Het vergrendelingsgedeelte van de groep wordt blootgesteld via [get_GroupShapeLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/groupshape/get_groupshapelock/), waarmee je bewerkingen op het object kunt beperken.