---
title: Lijnvormen toevoegen aan presentaties in C++
linktitle: Lijn
type: docs
weight: 50
url: /nl/cpp/line/
keywords:
- lijn
- lijn maken
- lijn toevoegen
- gewone lijn
- lijn configureren
- lijn aanpassen
- stippellijnstijl
- pijlkop
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u de lijnopmaak in PowerPoint-presentaties kunt bewerken met Aspose.Slides voor C++. Ontdek eigenschappen, methoden en voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lijnvormen aan PowerPoint‑dia’s toe te voegen via code. Dit artikel laat zien hoe u een eenvoudige lijn maakt en hoe u een lijn kunt aanpassen zodat deze als een pijl wordt weergegeven.

U leert hoe u een lijnvorm aan een dia toevoegt, het uiterlijk ervan aanpast en de bijgewerkte presentatie opslaat. De voorbeelden richten zich op praktische lijn‑opmaakinstellingen zoals stijl, breedte, stippellijnpatroon, pijl‑kopopties en vulkleur.

## **Maak een eenvoudige lijn**
Om een eenvoudige rechte lijn aan een geselecteerde dia van de presentatie toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van [Presentatieklasse](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van het type Line toe met de [AddAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addautoshape/) methode van het Shapes‑object.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Maak een pijlvormige lijn**
Aspose.Slides voor C++ stelt ontwikkelaars ook in staat om enkele eigenschappen van de lijn te configureren zodat deze aantrekkelijker oogt. Laten we een paar eigenschappen van een lijn instellen zodat deze eruitziet als een pijl. Volg de onderstaande stappen:

- Maak een instantie van [Presentatieklasse](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van het type Line toe met de AddAutoShape‑methode van het Shapes‑object.
- Stel de lijnstijl in op een van de stijlen die door Aspose.Slides voor C++ worden aangeboden.
- Stel de breedte van de lijn in.
- Stel de [Dash‑style](https://reference.aspose.com/slides/nl/cpp/aspose.slides/linedashstyle/) van de lijn in op een van de door Aspose.Slides voor C++ aangeboden stijlen.
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/cpp/aspose.slides/lineformat/) en de lengte van het startpunt van de lijn in.
- Stel de Arrow Head Style en de lengte van het eindpunt van de lijn in.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **Veelgestelde vragen**

**Kan ik een gewone lijn omzetten in een connector zodat hij “vastklikt” op vormen?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/autoshape/) van het type [Line](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapetype/)) wordt niet automatisch een connector. Gebruik het specifieke [Connector](https://reference.aspose.com/slides/nl/cpp/aspose.slides/connector/)‑type en de [bijbehorende API’s](/slides/nl/cpp/connector/) voor verbindingen.

**Wat moet ik doen als de eigenschappen van een lijn worden geërfd van het thema en het moeilijk is de uiteindelijke waarden te bepalen?**

[Lees de effectieve eigenschappen](/slides/nl/cpp/shape-effective-properties/) via de interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilinefillformateffectivedata/) – deze houden al rekening met overerving en thema‑stijlen.

**Kan ik een lijn vergrendelen tegen bewerken (verplaatsen, formaat wijzigen)?**

Ja. Shapes bieden [lock‑objecten](https://reference.aspose.com/slides/nl/cpp/aspose.slides/autoshape/get_autoshapelock/) waardoor u [bewerkingsoperaties kunt weigeren](/slides/nl/cpp/applying-protection-to-presentation/).