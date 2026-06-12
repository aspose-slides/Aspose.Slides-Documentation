---
title: Waarom niet Open XML SDK
type: docs
weight: 100
url: /nl/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- vergelijken
- presentatie-objectmodel
- hoogwaardige conversie
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek waarom Aspose.Slides een betere keuze is dan het gratis Open XML SDK: vergelijk functies, conversie zonder automatisering, en brede ondersteuning voor PPT, PPTX en ODP."
---
## **Overzicht**

Dit artikel legt uit wanneer ontwikkelaars mogelijk kiezen voor Open XML SDK of Aspose.Slides voor het werken met presentatiedocumenten. Het beschrijft Open XML SDK als een bibliotheek voor het manipuleren van OOXML‑pakketten en hun onderliggende XML‑elementen, terwijl Aspose.Slides wordt gepresenteerd als een presentatieverwerkingsbibliotheek met een high‑level objectmodel en ondersteuning voor tal van PowerPoint‑gerelateerde taken.

Het artikel vergelijkt beide opties op basis van ondersteunde formaten, programmeermodel, render‑ en afdrukmogelijkheden, platformondersteuning en veelvoorkomende gebruiksscenario’s. Het verduidelijkt ook dat Open XML SDK geschikt kan zijn voor eenvoudige PPTX‑bewerkingen of directe toegang tot OOXML‑elementen, terwijl Aspose.Slides beter past bij complexe presentatietaken zoals werken met meerdere PowerPoint‑formaten, vormen kopiëren of klonen, tekst vervangen, animaties toepassen en presentaties converteren naar PDF, TIFF of XPS.

## **Wat is Open XML SDK?**
We horen soms de vraag: Waarom zouden we Aspose‑producten gebruiken in plaats van het gratis Open XML SDK? Deze vraag is eenvoudig te beantwoorden: functionaliteit en mogelijkheden. Volgens de[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) wordt Open XML SDK gedefinieerd als: “The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly‑typed way.” Dat wil zeggen, in plaats van een bestand uit te pakken om XML te extraheren, die XML in een DOM‑boom te laden en direct met XML‑elementen en attributen te werken, biedt Open XML SDK klassen die dat voor je doen.

## **Wat is Aspose.Slides?**
Aspose.Slides is een klassengebibliotheek die uw toepassing in staat stelt de volgende presentatieverwerkingstaken uit te voeren:

- Programmeren met een **Presentation** objectmodel.
- Conversies van hoge kwaliteit tussen alle populaire ondersteunde PowerPoint‑presentatieformaten, inclusief conversie naar PDF en XPS.
- Mogelijkheid om dia‑miniaturen te genereren in bekende formaten zoals PNG, JPEG en BMP, evenals dia‑export naar SVG.
- Mogelijkheid om presentaties vanaf nul te bouwen of door samenvoeging van één of meerdere documenten.
- Ondersteuning voor het toevoegen van animaties, OLE‑frames, tabellen, het maken en beheren van grafieken.
- Beschikbaarheid van uitgebreide controle voor het beheren van tekstopmaak op TextFrames‑, Paragraphs‑ en Portions‑niveau.  
Voor meer details over de ondersteunde functies, bezoek [Aspose.Slides Features](/slides/nl/cpp/product-overview/).

## **Vergelijk Open XML SDK en Aspose.Slides**
De volgende tabel vergelijkt de functies van Open XML SDK en Aspose.Slides.

|**Kenmerk of Categorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Ondersteunde presentatiesformaten|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversie van PPT naar PPTX|Nee|Ja|
|<p>High‑level programmeren met een Presentation Document Object Model (DOM):</p><p>- Tekst zoeken en vervangen.</p><p>- Dia's samenstellen in presentaties.</p>|Nee|Ja|
|Gedetailleerd programmeren met een documentobjectmodel, toegang tot afzonderlijke elementen en opmaak zoals TextHolders, TextFrames, Paragraphs en Portions.|Ja|Ja|
|Low‑level directe en volledige toegang tot de onderliggende XML‑elementen en attributen, zoals relaties‑identifiers, lijst‑identifiers van een OOXML‑document.|Ja|Nee|
|<p>Renderen:</p><p>- Presentaties renderen naar PDF, PDF‑notities, XPS, TIFF‑afbeeldingen.</p><p>- Dia‑miniaturen renderen naar PNG, JPEG, BMP, SVG en TIFF.</p><p>- Specificeren van beeldresolutie, kwaliteit, compressie en andere opties.</p>|Nee|Ja|

## **Conclusie**
Open XML SDK en Aspose.Slides concurreren niet rechtstreeks omdat ze verschillende behoeften en doelgroepen bedienen. Open XML SDK is een klassengebibliotheek die een sterk getypeerde manier biedt om met OOXML‑documenten te werken. Aspose.Slides is een zeer bruikbare presentatieverwerkingsbibliotheek die uitstekende ondersteuning biedt voor vrijwel alle Microsoft PowerPoint‑bestandsformaten. Als u alleen een vrij eenvoudige programmeerbewerking op een PPTX‑document moet uitvoeren, kan Open XML SDK een geschikte keuze zijn. Met Open XML SDK kunt u eenvoudig eenvoudige taken uitvoeren, zoals het genereren van een simpel PPTX‑document, of het verwijderen van opmerkingen, kop‑ en voetteksten, het extraheren van afbeeldingen, enzovoort. Sommige taken kunnen met Open XML SDK worden bereikt, maar niet met Aspose.Slides. Bijvoorbeeld, als u directe toegang nodig heeft tot de XML‑elementen en attributen van een OOXML‑document, moet u Open XML SDK gebruiken. Als u daarentegen complexe bewerkingen op documenten moet uitvoeren, zoals de volgende taken, is Aspose.Slides de beste optie:

- Ondersteuning van oudere PowerPoint‑formaten naast PPTX.
- Vormen kopiëren of klonen binnen dia's op een manier die objecten, stijlen en andere opmaak op een geschikte manier combineert.
- Opgemaakte of onopgemaakte tekst vervangen.
- Animaties toepassen en connectors gebruiken met vormen.
- Een document converteren naar PDF of XPS zodat het er precies uitziet zoals Microsoft PowerPoint het zou hebben geconverteerd.
- Een C++‑applicatie ontwikkelen voor zowel desktop‑ als console‑omgevingen.