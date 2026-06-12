---
title: Beheer superscript en subscript in presentaties op Android
linktitle: Superscript en Subscript
type: docs
weight: 80
url: /nl/androidjava/superscript-and-subscript/
keywords:
- superscript
- subscript
- superscript toevoegen
- subscript toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheers superscript en subscript in Aspose.Slides voor Android via Java en til uw presentaties naar een hoger niveau met professionele tekstopmaak voor maximale impact."
---
## **Overzicht**

Aspose.Slides biedt functies om superscript‑ en subscripttekst te integreren in uw PowerPoint‑presentaties (PPT, PPTX) en OpenDocument‑presentaties (ODP). Of u nu chemische formules, wiskundige vergelijkingen wilt benadrukken of inhoud wilt annoteren met voetnoten, deze speciale opmaakopties helpen om duidelijkheid en precisie te behouden. In dit artikel leert u hoe u superscript‑ en subscript‑stijlen naadloos toepast en professionele resultaten behaalt in elke dia.

## **Superscript‑ en subscripttekst beheren**
U kunt superscript‑ en subscripttekst toevoegen binnen elk alinea‑gedeelte. Om superscript‑ of subscripttekst toe te voegen in een Aspose.Slides‑tekstframe moet u de [**setEscapement**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-)‑methode van de klasse [PortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PortionFormat) gebruiken.

Deze eigenschap retourneert of stelt de superscript‑ of subscripttekst in (waarde van -100 % (subscript) tot 100 % (superscript)). Bijvoorbeeld:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
- Haal de referentie van een dia op door zijn index te gebruiken.
- Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape) van het type [Rectangle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ShapeType#Rectangle) toe aan de dia.
- Toegang tot het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrame) dat bij de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape) hoort.
- Verwijder bestaande alinea's
- Maak een nieuw alinea‑object aan om superscripttekst te bevatten en voeg het toe aan de [IParagraphs collection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) van het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITextFrame).
- Maak een nieuw portion‑object aan
- Stel de Escapement‑eigenschap in voor het portion tussen 0 en 100 om superscript toe te voegen. (0 betekent geen superscript)
- Stel enige tekst in voor [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Portion) en voeg deze vervolgens toe aan de portion‑collectie van de alinea.
- Maak een nieuw alinea‑object aan om subscripttekst te bevatten en voeg het toe aan de IParagraphs‑collectie van het ITextFrame.
- Maak een nieuw portion‑object aan
- Stel de Escapement‑eigenschap in voor het portion tussen 0 en -100 om subscript toe te voegen. (0 betekent geen subscript)
- Stel enige tekst in voor [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Portion) en voeg deze vervolgens toe aan de portion‑collectie van de alinea.
- Sla de presentatie op als een PPTX‑bestand.

```java
// Maak een Presentation‑klasse‑instantie die een PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal dia op
    ISlide slide = pres.getSlides().get_Item(0);

    // Maak tekstvak aan
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Maak alinea voor superscript‑tekst
    IParagraph superPar = new Paragraph();

    // Maak portion met gewone tekst
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Maak portion met superscript‑tekst
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Maak alinea voor subscript‑tekst
    IParagraph paragraph2 = new Paragraph();

    // Maak portion met gewone tekst
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Maak portion met subscript‑tekst
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Voeg alinea’s toe aan tekstvak
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Wordt superscript‑ en subscriptopmaak bewaard bij het exporteren naar PDF of andere formaten?**

Ja, Aspose.Slides behoudt superscript‑ en subscriptopmaak correct bij het exporteren van presentaties naar PDF, PPT/PPTX, afbeeldingen en andere ondersteunde formaten. De gespecialiseerde opmaak blijft intact in alle uitvoerbestanden.

**Kunnen superscript en subscript worden gecombineerd met andere opmaakstijlen zoals vet of cursief?**

Ja, Aspose.Slides stelt u in staat verschillende tekststijlen te combineren binnen één portion tekst. U kunt vet, cursief, onderstrepen inschakelen en tegelijkertijd superscript of subscript toepassen door de bijbehorende eigenschappen in [PortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portionformat/) te configureren.

**Werkt superscript‑ en subscriptopmaak voor tekst binnen tabellen, diagrammen of SmartArt?**

Ja, Aspose.Slides ondersteunt opmaak binnen de meeste objecten, waaronder tabellen en grafiekelementen. Bij het werken met SmartArt moet u de juiste elementen (zoals [SmartArtNode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/smartartnode/)) en hun tekstcontainers benaderen, en vervolgens de [PortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portionformat/)‑eigenschappen op een vergelijkbare manier configureren.