---
title: Beheer superscript en subscript in presentaties met JavaScript
linktitle: Superscript en Subscript
type: docs
weight: 80
url: /nl/nodejs-java/superscript-and-subscript/
keywords:
- superscript
- subscript
- superscript toevoegen
- subscript toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheers superscript en subscript in Aspose.Slides voor Node.js via Java en til uw presentaties naar een hoger niveau met professionele tekstopmaak voor maximaal effect."
---
## **Overzicht**

Aspose.Slides biedt functionaliteit om superscript- en subscript‑tekst te integreren in uw PowerPoint‑presentaties (PPT, PPTX) en OpenDocument‑presentaties (ODP). Of u nu chemische formules, wiskundige vergelijkingen wilt benadrukken of inhoud wilt annoteren met voetnoten, deze gespecialiseerde opmaakopties dragen bij aan duidelijkheid en nauwkeurigheid. In dit artikel leert u hoe u superscript‑ en subscript‑stijlen naadloos toepast en professionele resultaten behaalt op elke dia.

## **Superscript‑ en Subscript‑tekst beheren**

U kunt superscript‑ en subscript‑tekst toevoegen binnen elk alinea‑deel. Om superscript‑ of subscript‑tekst in een Aspose.Slides‑tekstvak te plaatsen, moet u de [**setEscapement**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-)‑methode van de [PortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PortionFormat)‑klasse gebruiken.

Deze eigenschap geeft de superscript‑ of subscript‑waarde terug of stelt deze in (waarde van -100 % (subscript) tot 100 % (superscript)). Bijvoorbeeld:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) van het type [Rectangle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeType#Rectangle) toe aan de dia.
- Open het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame) dat bij de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) hoort.
- Maak bestaande alinea’s leeg.
- Maak een nieuw alinea‑object aan om superscript‑tekst te bevatten en voeg dit toe aan de [Paragraphs collection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame#getParagraphs--) van het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame).
- Maak een nieuw portion‑object.
- Stel de Escapement‑eigenschap in voor de portion tussen 0 en 100 om superscript toe te passen. (0 betekent geen superscript)
- Voeg tekst toe aan de [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Portion) en voeg die vervolgens toe aan de portion‑collectie van de alinea.
- Maak een nieuw alinea‑object aan om subscript‑tekst te bevatten en voeg dit toe aan de IParagraphs‑collectie van het ITextFrame.
- Maak een nieuw portion‑object.
- Stel de Escapement‑eigenschap in voor de portion tussen 0 en -100 om subscript toe te passen. (0 betekent geen subscript)
- Voeg tekst toe aan de [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Portion) en voeg die vervolgens toe aan de portion‑collectie van de alinea.
- Sla de presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder.

```javascript
// Instantieer een Presentation-klasse die een PPTX vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Verkrijg dia
    var slide = pres.getSlides().get_Item(0);
    // Maak tekstvak
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Maak alinea voor superscript-tekst
    var superPar = new aspose.slides.Paragraph();
    // Maak portion met gewone tekst
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Maak portion met superscript-tekst
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Maak alinea voor subscript-tekst
    var paragraph2 = new aspose.slides.Paragraph();
    // Maak portion met gewone tekst
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Maak portion met subscript-tekst
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Voeg alinea's toe aan tekstvak
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Worden superscript en subscript behouden bij export naar PDF of andere formaten?**

Ja, Aspose.Slides behoudt superscript‑ en subscript‑opmaak correct bij het exporteren van presentaties naar PDF, PPT/PPTX, afbeeldingen en andere ondersteunde formaten. De gespecialiseerde opmaak blijft ongewijzigd in alle uitvoerbestanden.

**Kunnen superscript en subscript worden gecombineerd met andere opmaakstijlen, zoals vet of cursief?**

Ja, Aspose.Slides staat toe meerdere tekststijlen te combineren binnen één portion tekst. U kunt vet, cursief, onderstrepen en tegelijk superscript of subscript toepassen door de overeenkomstige eigenschappen in [PortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/) te configureren.

**Werkt superscript‑ en subscript‑opmaak voor tekst in tabellen, grafieken of SmartArt?**

Ja, Aspose.Slides ondersteunt opmaak binnen de meeste objecten, inclusief tabellen en grafiekelementen. Bij gebruik van SmartArt moet u de juiste elementen (zoals [SmartArtNode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartnode/)) en hun tekstcontainers benaderen, en vervolgens de [PortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/)‑eigenschappen op dezelfde manier instellen.