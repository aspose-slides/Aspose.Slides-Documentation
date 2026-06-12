---
title: Beheer presentatie‑zoom in JavaScript
linktitle: Zoom beheren
type: docs
weight: 60
url: /nl/nodejs-java/manage-zoom/
keywords:
- zoom
- zoomframe
- dia‑zoom
- sectie‑zoom
- samenvatting‑zoom
- zoom toevoegen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas Zoom aan met Aspose.Slides voor Node.js — spring tussen secties, voeg miniaturen en overgangen toe in PPT-, PPTX- en ODP‑presentaties."
---
## **Inleiding**

Zooms in PowerPoint maken het mogelijk om naar specifieke dia’s, secties en gedeelten van een presentatie te springen en daarvan terug te keren. Wanneer je presenteert, kan deze mogelijkheid om snel door de inhoud te navigeren erg handig zijn. 

![overzicht_afbeelding](overview.png)

* Om een volledige presentatie op één dia samen te vatten, gebruik je een [Summary Zoom](#Summary-Zoom).
* Om alleen geselecteerde dia’s weer te geven, gebruik je een [Slide Zoom](#Slide-Zoom).
* Om alleen één sectie weer te geven, gebruik je een [Section Zoom](#Section-Zoom).

## **Slide Zoom**

Een slide‑zoom kan je presentatie dynamischer maken, doordat je vrijelijk tussen dia’s kunt navigeren in elke volgorde die je kiest zonder de stroom van je presentatie te onderbreken. Slide‑zooms zijn ideaal voor korte presentaties zonder veel secties, maar je kunt ze ook in andere presentatiescenario’s gebruiken.

Slide‑zooms helpen je meerdere stukjes informatie te verkennen terwijl je het gevoel hebt op één enkel canvas te werken. 

![overzicht_afbeelding](slidezoomsel.png)

Voor slide‑zoom‑objecten biedt Aspose.Slides de enumeratie [ZoomImageType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ZoomImageType), de klasse [ZoomFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ZoomFrame) en enkele methoden onder de klasse [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection).

### **Zoom‑frames maken**

Je kunt een zoom‑frame op een dia toevoegen op deze manier:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Maak nieuwe dia’s aan waar je de zoom‑frames aan wilt koppelen. 
3. Voeg een identificatietekst en een achtergrond toe aan de aangemaakte dia’s.
4. Voeg zoom‑frames (met verwijzingen naar de aangemaakte dia’s) toe aan de eerste dia.
5. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een zoom‑frame op een dia maakt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voegt nieuwe dia's toe aan de presentatie
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Creëert een achtergrond voor de tweede dia
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Creëert een tekstvak voor de tweede dia
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Creëert een achtergrond voor de derde dia
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Creëert een tekstvak voor de derde dia
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Voegt ZoomFrame‑objecten toe
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Slaat de presentatie op
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Zoom‑frames maken met aangepaste afbeeldingen**

Met Aspose.Slides voor Node.js via Java kun je een zoom‑frame met een andere dia‑voorbeeldafbeelding maken op deze manier:
1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Maak een nieuwe dia aan waar je het zoom‑frame aan wilt koppelen. 
3. Voeg een identificatietekst en een achtergrond toe aan de dia.
4. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PPImage)‑object door een afbeelding toe te voegen aan de Images‑collectie van het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑object dat gebruikt zal worden om het frame te vullen.
5. Voeg zoom‑frames (met verwijzing naar de aangemaakte dia) toe aan de eerste dia.
6. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een zoom‑frame met een andere afbeelding maakt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voeg een nieuwe dia toe aan de presentatie
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Creëert een achtergrond voor de tweede dia
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Creëert een tekstvak voor de derde dia
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Creëert een nieuwe afbeelding voor het zoom‑object
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Voegt het ZoomFrame‑object toe
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Slaat de presentatie op
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Zoom‑frames opmaken**

In de vorige secties hebben we laten zien hoe je eenvoudige zoom‑frames maakt. Om complexere zoom‑frames te maken, moet je de opmaak van een simpel frame aanpassen. Er zijn verschillende opmaakopties die je op een zoom‑frame kunt toepassen. 

Je kunt de opmaak van een zoom‑frame op een dia als volgt regelen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Maak nieuwe dia’s aan waar je het zoom‑frame aan wilt koppelen. 
3. Voeg een identificatietekst en een achtergrond toe aan de aangemaakte dia’s.
4. Voeg zoom‑frames (met verwijzingen naar de aangemaakte dia’s) toe aan de eerste dia.
5. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PPImage)‑object door een afbeelding toe te voegen aan de Images‑collectie van het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑object dat gebruikt zal worden om het frame te vullen.
6. Stel een aangepaste afbeelding in voor het eerste zoom‑frame‑object.
7. Pas de lijnopmaak aan voor het tweede zoom‑frame‑object.
8. Verwijder de achtergrond van de afbeelding van het tweede zoom‑frame‑object.
9. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je de opmaak van een zoom‑frame op een dia wijzigt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voegt nieuwe dia's toe aan de presentatie
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Creëert een achtergrond voor de tweede dia
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Creëert een tekstvak voor de tweede dia
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Creëert een achtergrond voor de derde dia
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Creëert een tekstvak voor de derde dia
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Voegt ZoomFrame‑objecten toe
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Creëert een nieuwe afbeelding voor het zoom‑object
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Stelt een aangepaste afbeelding in voor zoomFrame1‑object
    zoomFrame1.setImage(picture);
    // Stelt een zoom‑frame‑opmaak in voor zoomFrame2‑object
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Instelling: laat geen achtergrond zien voor zoomFrame2‑object
    zoomFrame2.setShowBackground(false);
    // Slaat de presentatie op
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Section Zoom**

Een section‑zoom is een koppeling naar een sectie in je presentatie. Je kunt section‑zooms gebruiken om terug te keren naar secties die je extra wilt benadrukken. Of je kunt ze gebruiken om te laten zien hoe bepaalde delen van je presentatie met elkaar verbonden zijn. 

![overzicht_afbeelding](seczoomsel.png)

Voor section‑zoom‑objecten biedt Aspose.Slides de klasse [SectionZoomFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SectionZoomFrame) en enkele methoden onder de klasse [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection).

### **Section‑zoom‑frames maken**

Je kunt een section‑zoom‑frame op een dia toevoegen op deze manier:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Maak een nieuwe dia. 
3. Voeg een identificatie‑achtergrond toe aan de aangemaakte dia.
4. Maak een nieuwe sectie aan waar je het zoom‑frame aan wilt koppelen. 
5. Voeg een section‑zoom‑frame (met verwijzingen naar de aangemaakte sectie) toe aan de eerste dia.
6. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een zoom‑frame op een dia maakt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voeg een nieuwe dia toe aan de presentatie
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voeg een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);
    // Voeg een SectionZoomFrame-object toe
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Slaat de presentatie op
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Section‑zoom‑frames maken met aangepaste afbeeldingen**

Met Aspose.Slides voor Node.js via Java kun je een section‑zoom‑frame met een andere dia‑voorbeeldafbeelding maken op deze manier:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de aangemaakte dia.
4. Maak een nieuwe sectie aan waar je het zoom‑frame aan wilt koppelen. 
5. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PPImage)‑object door een afbeelding toe te voegen aan de Images‑collectie van het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑object dat gebruikt zal worden om het frame te vullen.
6. Voeg een section‑zoom‑frame (met een verwijzing naar de aangemaakte sectie) toe aan de eerste dia.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een zoom‑frame met een andere afbeelding maakt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voeg een nieuwe dia toe aan de presentatie
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voeg een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);
    // Creëert een nieuwe afbeelding voor het zoom‑object
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Voegt SectionZoomFrame‑object toe
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Slaat de presentatie op
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Section‑zoom‑frames opmaken**

Om complexere section‑zoom‑frames te maken, moet je de opmaak van een simpel frame aanpassen. Er zijn verschillende opmaakopties die je op een section‑zoom‑frame kunt toepassen. 

Je kunt de opmaak van een section‑zoom‑frame op een dia als volgt regelen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de aangemaakte dia.
4. Maak een nieuwe sectie aan waar je het zoom‑frame aan wilt koppelen. 
5. Voeg een section‑zoom‑frame (met verwijzingen naar de aangemaakte sectie) toe aan de eerste dia.
6. Verander de grootte en positie van het aangemaakte section‑zoom‑object.
7. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PPImage)‑object door een afbeelding toe te voegen aan de Images‑collectie van het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑object dat gebruikt zal worden om het frame te vullen.
8. Stel een aangepaste afbeelding in voor het aangemaakte section‑zoom‑frame‑object.
9. Schakel de *terugkeer naar de oorspronkelijke dia vanuit de gekoppelde sectie* in. 
10. Verwijder de achtergrond van de afbeelding van het section‑zoom‑frame‑object.
11. Pas de lijnopmaak aan voor het tweede zoom‑frame‑object.
12. Wijzig de duur van de overgang.
13. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je de opmaak van een section‑zoom‑frame wijzigt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voeg een nieuwe dia toe aan de presentatie
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voeg een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);
    // Voeg SectionZoomFrame-object toe
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Opmaak voor SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Slaat de presentatie op
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Summary Zoom**

Een summary‑zoom werkt als een landingspagina waarop alle onderdelen van je presentatie in één keer worden getoond. Tijdens het presenteren kun je met een summary‑zoom van de ene naar de andere plaats in je presentatie gaan in elke gewenste volgorde. Je kunt creatief zijn, vooruit springen of delen van je diavoorstelling opnieuw bekijken zonder de stroom van je presentatie te onderbreken.

![overzicht_afbeelding](sumzoomsel.png)

Voor summary‑zoom‑objecten biedt Aspose.Slides de klassen [SummaryZoomFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SummaryZoomSection) en [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SummaryZoomSectionCollection) en enkele methoden onder de klasse [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection).

### **Summary‑zoom maken**

Je kunt een summary‑zoom‑frame op een dia toevoegen op deze manier:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de aangemaakte dia’s.
3. Voeg het summary‑zoom‑frame toe aan de eerste dia.
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een summary‑zoom‑frame op een dia maakt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voegt een nieuwe dia toe aan de presentatie
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);
    // Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 2", slide);
    // Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 3", slide);
    // Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 4", slide);
    // Voegt een SummaryZoomFrame-object toe
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Slaat de presentatie op
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Summary‑zoom‑secties toevoegen en verwijderen**

Alle secties in een summary‑zoom‑frame worden vertegenwoordigd door [SummaryZoomSection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SummaryZoomSection)‑objecten, die worden opgeslagen in het [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SummaryZoomSectionCollection)‑object. Je kunt een summary‑zoom‑sectie‑object toevoegen of verwijderen via de klasse [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SummaryZoomSectionCollection) op deze manier:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de aangemaakte dia’s.
3. Voeg een summary‑zoom‑frame toe aan de eerste dia.
4. Voeg een nieuwe dia en sectie toe aan de presentatie.
5. Voeg de aangemaakte sectie toe aan het summary‑zoom‑frame.
6. Verwijder de eerste sectie uit het summary‑zoom‑frame.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je secties toevoegt en verwijdert in een summary‑zoom‑frame:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voegt een nieuwe dia toe aan de presentatie
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);
    // Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 2", slide);
    // Voegt een SummaryZoomFrame-object toe
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voegt een nieuwe sectie toe aan de presentatie
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Voegt een sectie toe aan de Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Verwijdert een sectie uit de Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Slaat de presentatie op
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Summary‑zoom‑secties opmaken**

Om complexere summary‑zoom‑sectie‑objecten te maken, moet je de opmaak van een simpel frame aanpassen. Er zijn verschillende opmaakopties die je op een summary‑zoom‑sectie‑object kunt toepassen. 

Je kunt de opmaak van een summary‑zoom‑sectie‑object in een summary‑zoom‑frame als volgt regelen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation).
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de aangemaakte dia’s.
3. Voeg een summary‑zoom‑frame toe aan de eerste dia.
4. Haal een summary‑zoom‑sectie‑object op voor het eerste object uit de `ISummaryZoomSectionCollection`.
5. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PPImage)‑object door een afbeelding toe te voegen aan de images‑collectie van het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑object dat gebruikt zal worden om het frame te vullen.
6. Stel een aangepaste afbeelding in voor het aangemaakte sectie‑zoom‑frame‑object.
7. Schakel de *terugkeer naar de oorspronkelijke dia vanuit de gekoppelde sectie* in. 
8. Pas de lijnopmaak aan voor het tweede zoom‑frame‑object.
9. Wijzig de duur van de overgang.
10. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je de opmaak van een summary‑zoom‑sectie‑object wijzigt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voegt een nieuwe dia toe aan de presentatie
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);
    // Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 2", slide);
    // Voegt een SummaryZoomFrame-object toe
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Haalt het eerste SummaryZoomSection-object op
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Opmaak voor SummaryZoomSection-object
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Slaat de presentatie op
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik bepalen of er teruggegaan moet worden naar de ‘ouder‑dia’ na het tonen van het doel?**

Ja. Het [Zoom frame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zoomframe/) of de [section](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectionzoomframe/) heeft een `setReturnToParent`‑methode die, wanneer ingeschakeld, kijkers terugstuurt naar de bron‑dia nadat ze de doelinhoud hebben bezocht.

**Kan ik de ‘snelheid’ of duur van de Zoom‑overgang aanpassen?**

Ja. Zoom biedt een `setTransitionDuration`‑methode zodat je de tijd van de spronganimatie kunt regelen.

**Zijn er limieten voor het aantal Zoom‑objecten dat een presentatie kan bevatten?**

Er is geen harde API‑limiet gedocumenteerd. Praktische limieten hangen af van de algehele complexiteit van de presentatie en de prestaties van de viewer. Je kunt veel Zoom‑frames toevoegen, maar houd rekening met bestandsgrootte en rendertijd.