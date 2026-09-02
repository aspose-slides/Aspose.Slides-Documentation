---
title: Waarom niet Open XML SDK
type: docs
weight: 100
url: /nl/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- vergelijken
- presentatie‑objectmodel
- hoogwaardige conversie
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Zie waarom Aspose.Slides een betere keuze is dan de gratis Open XML SDK: vergelijk functies, conversie zonder automatisering en brede ondersteuning voor PPT, PPTX en ODP."
---
## **Overzicht**

Dit artikel legt uit wanneer ontwikkelaars kunnen kiezen voor Open XML SDK of Aspose.Slides voor het werken met presentatiedocumenten. Het beschrijft Open XML SDK als een bibliotheek voor het manipuleren van OOXML‑pakketten en hun onderliggende XML‑elementen, terwijl Aspose.Slides wordt gepresenteerd als een presentatie‑verwerkingsbibliotheek met een hoog‑niveau objectmodel en ondersteuning voor veel PowerPoint‑gerelateerde taken.

Het artikel vergelijkt beide opties op basis van ondersteunde formaten, programmeermodel, rendering, platformondersteuning en veelvoorkomende gebruikssituaties. Het maakt ook duidelijk dat Open XML SDK geschikt kan zijn voor eenvoudige PPTX‑bewerkingen of directe toegang tot OOXML‑elementen, terwijl Aspose.Slides beter past bij complexe presentatietaken zoals werken met meerdere PowerPoint‑formaten, vormen kopiëren of klonen, tekst vervangen, animaties toepassen en presentaties converteren naar PDF, TIFF of XPS.

## **Wat is Open XML SDK?**
We horen soms de vraag: waarom zouden we Aspose‑producten gebruiken in plaats van de gratis Open XML SDK? Deze vraag is eenvoudig te beantwoorden: functionaliteit en mogelijkheden. Volgens de[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) wordt Open XML SDK gedefinieerd als: *De Open XML SDK 2.0 vereenvoudigt de taak van het manipuleren van Open XML‑pakketten en de onderliggende Open XML‑schema‑elementen binnen een pakket.* De Open XML SDK 2.0 omvat veelgebruikte taken die ontwikkelaars uitvoeren op Open XML‑pakketten, zodat je complexe operaties kunt uitvoeren met slechts een paar regels code. OOXML‑documenten zijn in feite gezipt XML‑bestanden en Open XML SDK is een verzameling klassen die je in staat stelt om op een sterk getypeerde manier met de inhoud van OOXML‑documenten te werken. In plaats van een bestand uit te pakken om XML te extraheren, die XML in een DOM‑boom te laden en direct met XML‑elementen en attributen te werken, biedt Open XML SDK klassen om dat te doen.

## **Wat is Aspose.Slides?**
Aspose.Slides is een class‑library die jouw applicatie de volgende presentatie‑verwerkingstaken laat uitvoeren:

- Programmeren met een **Presentation**‑objectmodel.
- Hoge‑kwaliteit conversies tussen alle populaire ondersteunde PowerPoint‑presentatieformaten, inclusief conversie naar PDF en XPS.
- Mogelijkheid om miniatuur‑afbeeldingen van dia's te genereren in bekende formaten zoals PNG, JPEG en BMP, evenals dia‑export naar SVG.
- Mogelijkheid om presentaties vanaf nul op te bouwen of te combineren uit één of meerdere documenten.
- Ondersteuning voor het toevoegen van animaties, OLE‑frames, tabellen, en het maken en beheren van grafieken.
- Uitgebreide controle voor het beheren van tekstopmaak op TextFrames‑, Paragraaf‑ en Portion‑niveau.

Voor meer details over de ondersteunde functies, bezoek de[Aspose.Slides-features](/slides/nl/cpp/product-overview/).

## **Vergelijk Open XML SDK en Aspose.Slides**
De volgende tabel vergelijkt de functies van Open XML SDK en Aspose.Slides.

|**Functie of Functiecategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Ondersteunde presentatieformaten|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversie van PPT naar PPTX|Nee|Ja|
|<p>Programmeren op hoog niveau met een Presentation Document Object Model (DOM):</p><p>- Tekst zoeken en vervangen.</p><p>- Dia's samenstellen in presentaties.</p>|Nee|Ja|
|Gedetailleerd programmeren met een document‑objectmodel, toegang tot individuele elementen en opmaak zoals TextHolders, TextFrames, Paragraphs en Portions.|Ja|Ja|
|Lage‑niveau directe en volledige toegang tot de onderliggende XML‑elementen en attributen, zoals relatie‑identifiers en lijst‑identifiers van een OOXML‑document.|Ja|Nee|
|<p>Rendering:</p><p>- Renderen van presentaties naar PDF, PDF‑Notes, XPS, TIFF‑afbeeldingen.</p><p>- Renderen van dia‑miniaturen naar PNG, JPEG, BMP, SVG en TIFF.</p><p>- Specificeren van afbeeldingsresolutie, kwaliteit, compressie en andere opties.</p>|Nee|Ja|

## **Conclusie**
Open XML SDK en Aspose.Slides concurreren niet rechtstreeks omdat ze verschillende behoeften en doelgroepen bedienen. Open XML SDK is een class‑library die een sterk getypeerde manier biedt om met OOXML‑documenten te werken. Aspose.Slides is een zeer bruikbare presentatie‑verwerkingsbibliotheek die uitstekende ondersteuning biedt voor bijna alle Microsoft PowerPoint‑bestandsformaten. Als je alleen een vrij eenvoudige programmeer‑operatie op een PPTX‑document hoeft uit te voeren, kan Open XML SDK een passende keuze zijn. Met Open XML SDK kun je gemakkelijk eenvoudige taken uitvoeren, zoals het genereren van een simpel PPTX‑document, het verwijderen van opmerkingen, kop‑ en voetteksten, het extraheren van afbeeldingen, enzovoort. Sommige taken kunnen met Open XML SDK worden bereikt, maar niet met Aspose.Slides. Bijvoorbeeld, als je directe toegang nodig hebt tot de XML‑elementen en attributen van een OOXML‑document, moet je Open XML SDK gebruiken. Als je echter complexe bewerkingen op documenten moet uitvoeren, zoals een van de volgende taken, dan is Aspose.Slides de beste optie:

- Ondersteuning voor oudere PowerPoint‑formaten naast PPTX.
- Vormen kopiëren of klonen binnen dia's op een manier die objecten, stijlen en andere opmaak op een gepaste manier combineert.
- Opgemaakte of onopgemaakte tekst vervangen.
- Animaties toepassen en connectors gebruiken met vormen.
- Een document converteren naar PDF of XPS zodat het er precies uitziet zoals Microsoft PowerPoint het zou hebben geconverteerd.
- Een C++‑applicatie ontwikkelen in zowel desktop‑ als console‑omgevingen.