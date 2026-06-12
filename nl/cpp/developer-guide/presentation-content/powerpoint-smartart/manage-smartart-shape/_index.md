---
title: Beheer SmartArt-afbeeldingen in presentaties met C++
linktitle: SmartArt-afbeeldingen
type: docs
weight: 20
url: /nl/cpp/manage-smartart-shape/
keywords:
- SmartArt-object
- SmartArt-grafiek
- SmartArt-stijl
- SmartArt-kleur
- SmartArt maken
- SmartArt toevoegen
- SmartArt bewerken
- SmartArt wijzigen
- SmartArt benaderen
- SmartArt-lay-outtype
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Automatiseer het creëren, bewerken en stylen van PowerPoint-SmartArt in C++ met Aspose.Slides, met beknopte code-voorbeelden en prestatiegerichte richtlijnen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om programmatiche SmartArt‑afbeeldingen te maken en te beheren in PowerPoint‑presentaties. Dit artikel legt uit hoe u een SmartArt‑vorm aan een dia toevoegt, bestaande SmartArt‑vormen benadert, SmartArt zoekt op een specifiek lay‑outtype, en het uiterlijk bijwerkt door de SmartArt‑stijl of kleurstijl te wijzigen.

De voorbeelden laten zien hoe u met SmartArt‑vormen werkt via de vormcollectie van de presentatiedia, controleert of een vorm SmartArt is en vervolgens de eigenschappen bewerkt of inspecteert.

## **SmartArt‑vorm maken**
Aspose.Slides voor C++ maakt nu het toevoegen van aangepaste SmartArt‑vormen in dia’s vanaf nul mogelijk. Aspose.Slides voor C++ biedt de eenvoudigste API om SmartArt‑vormen op de makkelijkste manier te creëren. Volg de onderstaande stappen om een SmartArt‑vorm in een dia te maken:

- Maak een instantie van [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
- Verkrijg de referentie van een dia via de Index.
- Voeg een SmartArt‑vorm toe door de LayoutType in te stellen.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **SmartArt‑vorm op een dia benaderen**
De volgende code wordt gebruikt om de SmartArt‑vormen die aan de presentatiedia zijn toegevoegd te benaderen. In de voorbeeldcode lopen we door iedere vorm in de dia en controleren of het een SmartArt‑vorm is. Als de vorm van het type SmartArt is, casten we deze naar een SmartArt‑instantie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **SmartArt‑vorm benaderen met een bepaald lay‑outtype**
De volgende voorbeeldcode helpt om de SmartArt‑vorm met een specifiek LayoutType te benaderen. Let op dat u het LayoutType van SmartArt niet kunt wijzigen; het is alleen-lezen en wordt ingesteld op het moment dat de SmartArt‑vorm wordt toegevoegd.

- Maak een instantie van `Presentation` klasse en laad de presentatie met SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia via de Index.
- Loop door iedere vorm in de eerste dia.
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dit het geval is.
- Zoek de SmartArt‑vorm met het opgegeven LayoutType en voer daarna de gewenste bewerkingen uit.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **SmartArt‑vormstijl wijzigen**
De volgende voorbeeldcode helpt om de SmartArt‑vorm met een bepaald LayoutType te benaderen.

- Maak een instantie van `Presentation` klasse en laad de presentatie met SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia via de Index.
- Loop door iedere vorm in de eerste dia.
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dit het geval is.
- Zoek de SmartArt‑vorm met de opgegeven Style.
- Stel de nieuwe Style in voor de SmartArt‑vorm.
- Sla de presentatie op.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **SmartArt‑vorm kleurstijl wijzigen**
In dit voorbeeld leren we de kleurstijl van een SmartArt‑vorm aanpassen. De onderstaande voorbeeldcode benadert de SmartArt‑vorm met een specifieke kleurstijl en wijzigt deze.

- Maak een instantie van `Presentation` klasse en laad de presentatie met SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia via de Index.
- Loop door iedere vorm in de eerste dia.
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dit het geval is.
- Zoek de SmartArt‑vorm met de opgegeven Color Style.
- Stel de nieuwe Color Style in voor de SmartArt‑vorm.
- Sla de presentatie op.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Kan ik SmartArt animeren als één enkel object?**

Ja. SmartArt is een vorm, dus u kunt via de animaties‑API [standaardanimaties](/slides/nl/cpp/powerpoint-animation/) toepassen (invoer, uitgang, nadruk, bewegingstrajecten) net als bij andere vormen.

**Hoe vind ik een specifieke SmartArt op een dia als ik de interne ID niet ken?**

Stel de Alternatieve Tekst (AltText) in en zoek de vorm op die waarde – dit is de aanbevolen manier om de doelvorm te lokaliseren.

**Kan ik SmartArt groeperen met andere vormen?**

Ja. U kunt SmartArt groeperen met andere vormen (afbeeldingen, tabellen, enz.) en daarna de [groep manipuleren](/slides/nl/cpp/group/).

**Hoe krijg ik een afbeelding van een specifieke SmartArt (bijvoorbeeld voor een preview of rapport)?**

Exporteer een miniatuur/afbeelding van de vorm; de bibliotheek kan [individuele vormen renderen](/slides/nl/cpp/create-shape-thumbnails/) naar rasterbestanden (PNG/JPG/TIFF).

**Wordt het uiterlijk van SmartArt behouden bij het converteren van de volledige presentatie naar PDF?**

Ja. De renderengine streeft naar hoge getrouwheid voor [PDF‑export](/slides/nl/cpp/convert-powerpoint-to-pdf/), met een reeks kwaliteits‑ en compatibiliteitsopties.