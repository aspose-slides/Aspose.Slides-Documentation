---
title: Beheer SmartArt-vormknooppunten in presentaties met C++
linktitle: SmartArt-vormknooppunt
type: docs
weight: 30
url: /nl/cpp/manage-smartart-shape-node/
keywords:
- SmartArt-knooppunt
- sub-knooppunt
- knooppunt toevoegen
- knooppuntpositie
- knooppunt benaderen
- knooppunt verwijderen
- aangepaste positie
- assistent-knooppunt
- vulformaat
- knooppunt renderen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer SmartArt-vormknooppunten in PPT en PPTX met Aspose.Slides voor C++. Verkrijg duidelijke codevoorbeelden en tips om uw presentaties te stroomlijnen."
---
## **Overzicht**

SmartArt‑afbeeldingen in PowerPoint‑presentaties worden georganiseerd via knooppunten die tekst bevatten en de structuur van het diagram definiëren. Aspose.Slides stelt u in staat om programmatic met deze SmartArt‑knooppunten te werken: nieuwe knooppunten en sub‑knooppunten toevoegen, sub‑knooppunten op een specifieke positie invoegen, bestaande knooppunten benaderen, en hun tekst, niveau en positie lezen.

Dit artikel legt uit hoe u SmartArt‑vormknooppunten beheert. Het laat zien hoe u knooppunten verwijdert, werkt met sub‑knooppunten op basis van index of positie, een assistent‑knooppunt verandert in een gewoon knooppunt, de positie, grootte en rotatie van SmartArt‑knooppunt‑vormen aanpast, vulformaten voor knooppunten instelt, en een miniatuurafbeelding genereert voor een SmartArt‑sub‑knooppunt.

## **Een SmartArt‑knooppunt toevoegen**
Aspose.Slides voor C++ biedt de eenvoudigste API om de SmartArt‑vormen op de gemakkelijkste manier te beheren. De volgende voorbeeldcode helpt bij het toevoegen van een knooppunt en een sub‑knooppunt binnen een SmartArt‑vorm.

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse en laad de presentatie met een SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia via de index.
- Loop door elke vorm op de eerste dia.
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dat zo is.
- Voeg een nieuw knooppunt toe aan de NodeCollection van de SmartArt‑vorm en stel de tekst in het TextFrame in.
- Voeg nu een sub‑knooppunt toe aan het nieuw toegevoegde SmartArt‑knooppunt en stel de tekst in het TextFrame in.
- Sla de presentatie op.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **SmartArt‑knooppunt toevoegen op een specifieke positie**
In de volgende voorbeeldcode leggen we uit hoe u sub‑knooppunten kunt toevoegen die bij de respectieve knooppunten van een SmartArt‑vorm horen op een specifieke positie.

- Maak een instantie van de `Presentation`‑klasse.
- Verkrijg de referentie van de eerste dia via de index.
- Voeg een SmartArt‑vorm van het type StackedList toe aan de verkregen dia.
- Benader het eerste knooppunt in de toegevoegde SmartArt‑vorm.
- Voeg nu een sub‑knooppunt toe voor het geselecteerde knooppunt op positie 2 en stel de tekst in.
- Sla de presentatie op.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Een SmartArt‑knooppunt benaderen**
De volgende voorbeeldcode helpt bij het benaderen van knooppunten binnen een SmartArt‑vorm. Let op: u kunt het LayoutType van de SmartArt niet wijzigen, aangezien dit alleen‑lezen is en alleen wordt ingesteld wanneer de SmartArt‑vorm wordt toegevoegd.

- Maak een instantie van de `Presentation`‑klasse en laad de presentatie met een SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia via de index.
- Loop door elke vorm op de eerste dia.
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dat zo is.
- Loop door alle knooppunten binnen de SmartArt‑vorm.
- Benader en toon informatie zoals de positie, het niveau en de tekst van het SmartArt‑knooppunt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Een SmartArt‑sub‑knooppunt benaderen**
De volgende voorbeeldcode helpt bij het benaderen van de sub‑knooppunten die bij de respectieve knooppunten van een SmartArt‑vorm horen.

- Maak een instantie van de PresentationEx‑klasse en laad de presentatie met een SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia via de index.
- Loop door elke vorm op de eerste dia.
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArtEx indien dat zo is.
- Loop door alle knooppunten binnen de SmartArt‑vorm.
- Voor elk geselecteerd SmartArt‑vormknooppunt, loop door alle sub‑knooppunten binnen dat specifieke knooppunt.
- Benader en toon informatie zoals de positie, het niveau en de tekst van het sub‑knooppunt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Een SmartArt‑sub‑knooppunt benaderen op een specifieke positie**
In dit voorbeeld leren we hoe we de sub‑knooppunten op een bepaalde positie kunnen benaderen die bij de respectieve knooppunten van een SmartArt‑vorm horen.

- Maak een instantie van de `Presentation`‑klasse.
- Verkrijg de referentie van de eerste dia via de index.
- Voeg een SmartArt‑vorm van het type StackedList toe.
- Benader de toegevoegde SmartArt‑vorm.
- Benader het knooppunt op index 0 van de verkregen SmartArt‑vorm.
- Benader nu het sub‑knooppunt op positie 1 van het verkregen SmartArt‑knooppunt met de methode GetNodeByPosition().
- Benader en toon informatie zoals de positie, het niveau en de tekst van het sub‑knooppunt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Een SmartArt‑knooppunt verwijderen**
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm kunnen verwijderen.

- Maak een instantie van de `Presentation`‑klasse en laad de presentatie met een SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia via de index.
- Loop door elke vorm op de eerste dia.
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dat zo is.
- Controleer of de SmartArt meer dan 0 knooppunten heeft.
- Selecteer het SmartArt‑knooppunt dat verwijderd moet worden.
- Verwijder nu het geselecteerde knooppunt met de RemoveNode()-methode* Sla de presentatie op.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Een SmartArt‑knooppunt verwijderen op een specifieke positie**
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm op een bepaalde positie kunnen verwijderen.

- Maak een instantie van de `Presentation`‑klasse en laad de presentatie met een SmartArt‑vorm.
- Verkrijg de referentie van de eerste dia via de index.
- Loop door elke vorm op de eerste dia.
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dat zo is.
- Selecteer het SmartArt‑vormknooppunt op index 0.
- Controleer nu of het geselecteerde SmartArt‑knooppunt meer dan 2 sub‑knooppunten heeft.
- Verwijder nu het knooppunt op positie 1 met de RemoveNodeByPosition()-methode.
- Sla de presentatie op.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Een aangepaste positie instellen voor een SmartArt‑sub‑knooppunt**
Nu ondersteunt Aspose.Slides het instellen van de X‑ en Y‑eigenschappen van SmartArtShape. Het codefragment hieronder toont hoe u een aangepaste positie, grootte en rotatie van SmartArtShape instelt; let tevens op dat het toevoegen van nieuwe knooppunten een herberekening van de posities en groottes van alle knooppunten veroorzaakt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Een assistent‑knooppunt controleren**
In de volgende voorbeeldcode onderzoeken we hoe we assistent‑knooppunten in de SmartArt‑knooppuntencollectie kunnen identificeren en aanpassen.

- Maak een instantie van de PresentationEx‑klasse en laad de presentatie met een SmartArt‑vorm.
- Verkrijg de referentie van de tweede dia via de index.
- Loop door elke vorm op de eerste dia.
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArtEx indien dat zo is.
- Loop door alle knooppunten binnen de SmartArt‑vorm en controleer of ze assistent‑knooppunten zijn.
- Verander de status van het assistent‑knooppunt naar een normaal knooppunt.
- Sla de presentatie op.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Het vulformaat van een knooppunt instellen**
Aspose.Slides voor C++ maakt het mogelijk om aangepaste SmartArt‑vormen toe te voegen en hun vulformaten in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen kunt creëren en benaderen en hun vulformaat instelt met Aspose.Slides voor C++.

Volg de onderstaande stappen:

- Maak een instantie van de `Presentation`‑klasse.
- Verkrijg de referentie van een dia via de index.
- Voeg een SmartArt‑vorm toe door de LayoutType in te stellen.
- Stel de FillFormat in voor de knooppunten van de SmartArt‑vorm.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Genereer een miniatuur van een SmartArt‑sub‑knooppunt**
Ontwikkelaars kunnen een miniatuur van een sub‑knooppunt van een SmartArt genereren door de onderstaande stappen te volgen:

1. Instantieer de `Presentation`‑klasse die het PPTX‑bestand vertegenwoordigt.
2. Voeg SmartArt toe.
3. Verkrijg de referentie van een knooppunt via de index.
4. Haal de miniatuurafbeelding op.
5. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

Het voorbeeld hieronder genereert een miniatuur van een SmartArt‑sub‑knooppunt

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Wordt SmartArt‑animatie ondersteund?**

Ja. SmartArt wordt behandeld als een gewone vorm, dus u kunt [standaardanimaties](/slides/nl/cpp/shape-animation/) (invoer, uitgang, nadruk, bewegingspaden) toepassen en de timing aanpassen. U kunt ook vormen binnen SmartArt‑knooppunten animeren wanneer dat nodig is.

**Hoe kan ik een specifieke SmartArt op een dia betrouwbaar vinden als de interne ID onbekend is?**

Wijs en zoek op [alternatieve tekst](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/set_alternativetext/). Door een onderscheidende AltText aan de SmartArt toe te wijzen, kunt u deze programmeermatig vinden zonder te vertrouwen op interne identifiers.

**Zal het uiterlijk van SmartArt behouden blijven bij het converteren van de presentatie naar PDF?**

Ja. Aspose.Slides rendert SmartArt met hoge visuele nauwkeurigheid tijdens [PDF-export](/slides/nl/cpp/convert-powerpoint-to-pdf/), waarbij lay-out, kleuren en effecten behouden blijven.

**Kan ik een afbeelding van de volledige SmartArt extraheren (voor previews of rapporten)?**

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/) of naar [SVG](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/writeassvg/) voor schaalbare vectoroutput, waardoor het geschikt is voor miniaturen, rapporten of webgebruik.