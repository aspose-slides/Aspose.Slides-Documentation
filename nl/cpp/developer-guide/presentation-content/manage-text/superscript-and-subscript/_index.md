---
title: Superscript en subscript beheren in presentaties met C++
linktitle: Superscript en Subscript
type: docs
weight: 80
url: /nl/cpp/superscript-and-subscript/
keywords:
- bovenschrift
- onderschrift
- bovenschrift toevoegen
- onderschrift toevoegen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheers bovenschrift en onderschrift in Aspose.Slides voor C++ en til uw presentaties naar een hoger niveau met professionele tekstopmaak voor maximale impact."
---
## **Overzicht**

Aspose.Slides biedt mogelijkheden om superscript‑ en subscript‑tekst in je PowerPoint‑presentaties (PPT, PPTX) en OpenDocument‑presentaties (ODP) te integreren. Of je nu chemische formules, wiskundige vergelijkingen wilt benadrukken of inhoud wilt voorzien van voetnoten, deze gespecialiseerde opmaakopties helpen je om duidelijkheid en precisie te behouden. In dit artikel leer je hoe je superscript‑ en subscript‑stijlen naadloos toepast en professioneel resultaat behaalt in elke dia.

## **Superscript‑ en subscript‑tekst beheren**

Je kunt superscript‑ en subscript‑tekst toevoegen binnen elk alinea‑gedeelte. Om superscript‑ of subscript‑tekst in een Aspose.Slides‑tekstframe toe te voegen, moet je de **Escapement**‑eigenschap van de `PortionFormat`‑klasse gebruiken.

Deze eigenschap geeft de superscript‑ of subscript‑waarde terug of stelt deze in (waarde van -100 % (subscript) tot 100 % (superscript)). Bijvoorbeeld:

- Maak een instantie van de klasse [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
- Verkrijg de referentie van een dia door diens Index te gebruiken.
- Voeg een IAutoShape van het type Rechthoek toe aan de dia.
- Open het ITextFrame dat bij de IAutoShape hoort.
- Verwijder bestaande alinea's
- Maak een nieuw alinea‑object aan om superscript‑tekst te bevatten en voeg dit toe aan de IParagraphs‑collectie van het ITextFrame.
- Maak een nieuw portion‑object aan.
- Stel de Escapement‑eigenschap van het portion in tussen 0 en 100 om superscript toe te voegen. (0 betekent geen superscript)
- Stel een tekst in voor Portion en voeg deze vervolgens toe aan de portion‑collectie van de alinea.
- Maak een nieuw alinea‑object aan om subscript‑tekst te bevatten en voeg dit toe aan de IParagraphs‑collectie van het ITextFrame.
- Maak een nieuw portion‑object aan.
- Stel de Escapement‑eigenschap van het portion in tussen 0 en -100 om subscript toe te voegen. (0 betekent geen subscript)
- Stel een tekst in voor Portion en voeg deze vervolgens toe aan de portion‑collectie van de alinea.
- Sla de presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**Worden superscript en subscript behouden bij export naar PDF of andere formaten?**

Ja, Aspose.Slides behoudt superscript‑ en subscript‑opmaak correct bij het exporteren van presentaties naar PDF, PPT/PPTX, afbeeldingen en andere ondersteunde formaten. De gespecialiseerde opmaak blijft intact in alle uitvoerbestanden.

**Kunnen superscript en subscript gecombineerd worden met andere opmaakstijlen zoals vet of cursief?**

Ja, Aspose.Slides maakt het mogelijk om verschillende tekststijlen binnen één portion te combineren. Je kunt vet, cursief, onderstrepen en tegelijkertijd superscript of subscript inschakelen door de bijbehorende eigenschappen in [PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portionformat/) te configureren.

**Werkt superscript‑ en subscriptopmaak voor tekst binnen tabellen, grafieken of SmartArt?**

Ja, Aspose.Slides ondersteunt opmaak binnen de meeste objecten, inclusief tabellen en grafiekelementen. Bij het werken met SmartArt moet je de juiste elementen (zoals [SmartArtNode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartartnode/)) en hun tekstcontainers benaderen, en vervolgens de [PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portionformat/)‑eigenschappen op een vergelijkbare manier instellen.