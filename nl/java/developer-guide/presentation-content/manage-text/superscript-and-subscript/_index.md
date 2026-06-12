---
title: Beheer superscript en subscript in presentaties met Java
linktitle: Superscript en Subscript
type: docs
weight: 80
url: /nl/java/superscript-and-subscript/
keywords:
- superscript
- subscript
- superscript toevoegen
- subscript toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheers superscript en subscript in Aspose.Slides voor Java en verbeter uw presentaties met professionele tekstopmaak voor maximale impact."
---
## **Overzicht**

Aspose.Slides biedt functionaliteit voor het integreren van superscript‑ en subscripttekst in uw PowerPoint‑presentaties (PPT, PPTX) en OpenDocument‑presentaties (ODP). Of u nu chemische formules, wiskundige vergelijkingen wilt markeren of inhoud wilt annoteren met voetnoten, deze gespecialiseerde opmaakopties bevorderen duidelijkheid en nauwkeurigheid. In dit artikel leert u hoe u superscript‑ en subscriptstijlen naadloos toepast en professionele resultaten behaalt op elke dia.

## **Beheer superscript‑ en subscripttekst**
U kunt superscript‑ en subscripttekst toevoegen binnen elk alinea‑gedeelte. Voor het toevoegen van superscript‑ of subscripttekst in een Aspose.Slides‑tekstvak moet u de [**setEscapement**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) methode van de klasse [PortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PortionFormat) gebruiken.

Deze eigenschap geeft de superscript‑ of subscripttekst terug of stelt deze in (waarde van -100 % (subscript) tot 100 % (superscript)). Bijvoorbeeld:

- Maak een instantie aan van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation).
- Haal de referentie van een dia op met behulp van de index.
- Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) van het type [Rectangle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ShapeType#Rectangle) toe aan de dia.
- Toegang tot het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrame) dat bij de [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) hoort.
- Verwijder bestaande alinea’s.
- Maak een nieuw alinea‑object aan voor superscripttekst en voeg het toe aan de [IParagraphs collection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrame#getParagraphs--) van het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrame).
- Maak een nieuw portion‑object aan.
- Stel de Escapement‑eigenschap in voor de portion tussen 0 en 100 om superscript toe te voegen. (0 betekent geen superscript).
- Stel wat tekst in voor [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Portion) en voeg deze vervolgens toe aan de portion‑collectie van de alinea.
- Maak een nieuw alinea‑object aan voor subscripttekst en voeg het toe aan de IParagraphs‑collectie van het ITextFrame.
- Maak een nieuw portion‑object aan.
- Stel de Escapement‑eigenschap in voor de portion tussen 0 en -100 om subscript toe te voegen. (0 betekent geen subscript).
- Stel wat tekst in voor [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Portion) en voeg deze vervolgens toe aan de portion‑collectie van de alinea.
- Sla de presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder getoond.

```java
// Maak een Presentation-klasse instantie die een PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal dia op
    ISlide slide = pres.getSlides().get_Item(0);

    // Maak tekstvak
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Maak alinea voor superscript-tekst
    IParagraph superPar = new Paragraph();

    // Maak gedeelte met gewone tekst
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Maak gedeelte met superscript-tekst
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Maak alinea voor subscript-tekst
    IParagraph paragraph2 = new Paragraph();

    // Maak gedeelte met gewone tekst
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Maak gedeelte met subscript-tekst
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Voeg alinea's toe aan tekstvak
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Worden superscript en subscript behouden bij export naar PDF of andere formaten?**

Ja, Aspose.Slides behoudt de superscript‑ en subscript‑opmaak correct bij het exporteren van presentaties naar PDF, PPT/PPTX, afbeeldingen en andere ondersteunde formaten. De gespecialiseerde opmaak blijft intact in alle uitvoerbestanden.

**Kunnen superscript en subscript worden gecombineerd met andere opmaakstijlen zoals vet of cursief?**

Ja, Aspose.Slides maakt het mogelijk om verschillende tekststijlen te mengen binnen één portion tekst. U kunt vet, cursief, onderstrepen inschakelen en tegelijkertijd superscript of subscript toepassen door de bijbehorende eigenschappen in [PortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portionformat/) te configureren.

**Werkt superscript‑ en subscript‑opmaak voor tekst in tabellen, grafieken of SmartArt?**

Ja, Aspose.Slides ondersteunt opmaak binnen de meeste objecten, waaronder tabellen en grafiekelementen. Bij het werken met SmartArt moet u de juiste elementen (zoals [SmartArtNode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/smartartnode/)) en hun tekstcontainers benaderen en vervolgens de [PortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portionformat/) eigenschappen op dezelfde manier configureren.