---
title: Beheer Presentatie‑Zoom in Java
linktitle: Zoom beheren
type: docs
weight: 60
url: /nl/java/manage-zoom/
keywords:
- zoom
- zoomframe
- dia-zoom
- sectie-zoom
- samenvatting-zoom
- zoom toevoegen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak en pas Zoom aan met Aspose.Slides voor Java — spring tussen secties, voeg miniaturen en overgangen toe in PPT-, PPTX- en ODP‑presentaties."
---
## **Inleiding**

Zooms in PowerPoint stellen u in staat om naar specifieke dia’s, secties en delen van een presentatie te springen en weer terug. Tijdens het presenteren kan deze mogelijkheid om snel door de inhoud te navigeren erg nuttig zijn. 

![overview_image](overview.png)

* Om een volledige presentatie op één dia samen te vatten, gebruikt u een [Summary Zoom](#Summary-Zoom).
* Om alleen geselecteerde dia’s weer te geven, gebruikt u een [Slide Zoom](#Slide-Zoom).
* Om alleen één sectie weer te geven, gebruikt u een [Section Zoom](#Section-Zoom).

## **Dia Zoom**
Een dia‑zoom kan uw presentatie dynamischer maken en u in staat stellen vrij te navigeren tussen dia’s in elke gewenste volgorde zonder de stroom van uw presentatie te onderbreken. Dia‑zooms zijn uitstekend voor korte presentaties zonder veel secties, maar u kunt ze ook in verschillende presentatiescenario’s gebruiken.

Dia‑zooms helpen u meerdere stukken informatie te onderzoeken terwijl u het gevoel heeft op één enkel canvas te werken. 

![overview_image](slidezoomsel.png)

Voor dia‑zoomobjecten biedt Aspose.Slides de [ZoomImageType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ZoomImageType) enumeratie, de [IZoomFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IZoomFrame) interface en enkele methoden onder de [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection) interface.

### **Zoomframes maken**

U kunt een zoomframe op een dia toevoegen op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Maak nieuwe dia’s die u wilt koppelen aan de zoomframes.  
3. Voeg een identificatietekst en een achtergrond toe aan de gemaakte dia’s.  
4. Voeg zoomframes (die verwijzingen naar de gemaakte dia’s bevatten) toe aan de eerste dia.  
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` java
Presentation pres = new Presentation();
try {
    //Voegt nieuwe dia's toe aan de presentatie
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Maakt een achtergrond voor de tweede dia
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Maakt een tekstvak voor de tweede dia
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Maakt een achtergrond voor de derde dia
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Maakt een tekstvak voor de derde dia
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Voegt ZoomFrame-objecten toe
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Zoomframes maken met aangepaste afbeeldingen**
Met Aspose.Slides for Java kunt u een zoomframe met een andere dia‑voorbeeldafbeelding maken op deze manier: 
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Maak een nieuwe dia die u wilt koppelen aan het zoomframe.  
3. Voeg een identificatietekst en een achtergrond toe aan de dia.  
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage) object door een afbeelding toe te voegen aan de Images‑collectie die gekoppeld is aan het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object en die zal worden gebruikt om het frame te vullen.  
5. Voeg zoomframes (die de referentie naar de gemaakte dia bevatten) toe aan de eerste dia.  
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` java
Presentation pres = new Presentation();
try {
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Maakt een achtergrond voor de tweede dia
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Maakt een tekstvak voor de derde dia
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Maakt een nieuwe afbeelding voor het zoomobject
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Voegt het ZoomFrame-object toe
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Zoomframes opmaken**
In de vorige secties hebben we u laten zien hoe u eenvoudige zoomframes maakt. Om meer gecompliceerde zoomframes te maken moet u de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die u kunt toepassen op een zoomframe. 

U kunt de opmaak van een zoomframe op een dia op deze manier regelen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Maak nieuwe dia’s om aan te koppelen die u wilt linken met het zoomframe.  
3. Voeg enkele identificatieteksten en een achtergrond toe aan de gemaakte dia’s.  
4. Voeg zoomframes (die verwijzingen naar de gemaakte dia’s bevatten) toe aan de eerste dia.  
5. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage) object door een afbeelding toe te voegen aan de Images‑collectie die gekoppeld is aan het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object en die zal worden gebruikt om het frame te vullen.  
6. Stel een aangepaste afbeelding in voor het eerste zoomframe‑object.  
7. Wijzig de lijnopmaak voor het tweede zoomframe‑object.  
8. Verwijder de achtergrond van een afbeelding van het tweede zoomframe‑object.  
9. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` java 
Presentation pres = new Presentation();
try {
    //Voegt nieuwe dia's toe aan de presentatie
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Maakt een achtergrond voor de tweede dia
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Maakt een tekstvak voor de tweede dia
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Maakt een achtergrond voor de derde dia
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Maakt een tekstvak voor de derde dia
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Voegt ZoomFrame-objecten toe
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Maakt een nieuwe afbeelding voor het zoomobject
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Stelt aangepaste afbeelding in voor zoomFrame1-object
    zoomFrame1.setImage(picture);

    // Stelt een zoomframe-opmaak in voor zoomFrame2-object
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Instelling om geen achtergrond te tonen voor zoomFrame2-object
    zoomFrame2.setShowBackground(false);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sectie Zoom**

Een sectie‑zoom is een koppeling naar een sectie in uw presentatie. U kunt sectie‑zooms gebruiken om terug te gaan naar secties die u echt wilt benadrukken. Of u kunt ze gebruiken om te laten zien hoe bepaalde delen van uw presentatie met elkaar verbonden zijn. 

![overview_image](seczoomsel.png)

Voor sectie‑zoomobjecten biedt Aspose.Slides de [ISectionZoomFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISectionZoomFrame) interface en enkele methoden onder de [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection) interface.

### **Sectie‑zoomframes maken**

U kunt een sectie‑zoomframe aan een dia toevoegen op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Maak een nieuwe dia.  
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.  
4. Maak een nieuwe sectie die u wilt koppelen aan het zoomframe.  
5. Voeg een sectie‑zoomframe (dat verwijzingen naar de gemaakte sectie bevat) toe aan de eerste dia.  
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` java
Presentation pres = new Presentation();
try {
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);

    // Voegt een SectionZoomFrame-object toe
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Sectie‑zoomframes maken met aangepaste afbeeldingen**

Met Aspose.Slides for Java kunt u een sectie‑zoomframe met een andere dia‑voorbeeldafbeelding maken op deze manier: 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Maak een nieuwe dia.  
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.  
4. Maak een nieuwe sectie die u wilt koppelen aan het zoomframe.  
5. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage) object door een afbeelding toe te voegen aan de Images‑collectie die gekoppeld is aan het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object en die zal worden gebruikt om het frame te vullen.  
5. Voeg een sectie‑zoomframe (dat een referentie naar de gemaakte sectie bevat) toe aan de eerste dia.  
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` java 
Presentation pres = new Presentation();
try {
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);

    // Maakt een nieuwe afbeelding voor het zoomobject
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt SectionZoomFrame-object toe
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Sectie‑zoomframes opmaken**

Om meer gecompliceerde sectie‑zoomframes te maken moet u de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die u kunt toepassen op een sectie‑zoomframe. 

U kunt de opmaak van een sectie‑zoomframe op een dia op deze manier regelen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Maak een nieuwe dia.  
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.  
4. Maak een nieuwe sectie die u wilt koppelen aan het zoomframe.  
5. Voeg een sectie‑zoomframe (dat verwijzingen naar de gemaakte sectie bevat) toe aan de eerste dia.  
6. Wijzig de grootte en positie van het gemaakte sectie‑zoomobject.  
7. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage) object door een afbeelding toe te voegen aan de Images‑collectie die gekoppeld is aan het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object en die zal worden gebruikt om het frame te vullen.  
8. Stel een aangepaste afbeelding in voor het gemaakte sectie‑zoomframe‑object.  
9. Stel de *return to the original slide from the linked section*‑mogelijkheid in.  
10. Verwijder de achtergrond van een afbeelding van het sectie‑zoomframe‑object.  
11. Wijzig de lijnopmaak voor het tweede zoomframe‑object.  
12. Wijzig de overgangsduur.  
13. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` java
Presentation pres = new Presentation();
try {
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);

    // Voeg SectionZoomFrame-object toe
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Opmaak voor SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Samenvatting Zoom**

Een samenvatting‑zoom is als een landingspagina waarop alle delen van uw presentatie tegelijk worden weergegeven. Terwijl u presenteert, kunt u de zoom gebruiken om van de ene naar de andere plek in uw presentatie te gaan in elke volgorde die u wilt. U kunt creatief zijn, vooruit springen of gedeelten van uw diavoorstelling opnieuw bekijken zonder de stroom van uw presentatie te onderbreken.

![overview_image](sumzoomsel.png)

Voor samenvatting‑zoomobjecten biedt Aspose.Slides de [ISummaryZoomFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISummaryZoomSection) en [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISummaryZoomSectionCollection) interfaces en enkele methoden onder de [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection) interface.

### **Een Samenvatting‑Zoom maken**

U kunt een samenvatting‑zoomframe aan een dia toevoegen op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de gemaakte dia’s.  
3. Voeg het samenvatting‑zoomframe toe aan de eerste dia.  
4. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` java 
Presentation pres = new Presentation();
try {
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 2", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 3", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 4", slide);

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Een Samenvatting‑Zoom‑sectie toevoegen en verwijderen**

Alle secties in een samenvatting‑zoomframe worden vertegenwoordigd door [ISummaryZoomSection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISummaryZoomSection) objecten, die worden opgeslagen in het [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISummaryZoomSectionCollection) object. U kunt een samenvatting‑zoom‑sectie‑object toevoegen of verwijderen via de [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISummaryZoomSectionCollection) interface op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de gemaakte dia’s.  
3. Voeg een samenvatting‑zoomframe toe aan de eerste dia.  
4. Voeg een nieuwe dia en sectie toe aan de presentatie.  
5. Voeg de gemaakte sectie toe aan het samenvatting‑zoomframe.  
6. Verwijder de eerste sectie uit het samenvatting‑zoomframe.  
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` java
Presentation pres = new Presentation();
try {
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 2", slide);

    // Voegt SummaryZoomFrame-object toe
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Voegt een sectie toe aan de Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Verwijdert sectie uit de Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Samenvatting‑Zoom‑secties opmaken**

Om meer gecompliceerde samenvatting‑zoom‑sectie‑objecten te maken moet u de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die u kunt toepassen op een samenvatting‑zoom‑sectie‑object. 

U kunt de opmaak voor een samenvatting‑zoom‑sectie‑object in een samenvatting‑zoomframe op deze manier regelen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de gemaakte dia’s.  
3. Voeg een samenvatting‑zoomframe toe aan de eerste dia.  
4. Haal een samenvatting‑zoom‑sectie‑object op voor het eerste object uit de `ISummaryZoomSectionCollection`.  
7. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage) object door een afbeelding toe te voegen aan de images‑collectie die gekoppeld is aan het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object en die zal worden gebruikt om het frame te vullen.  
8. Stel een aangepaste afbeelding in voor het gemaakte sectie‑zoomframe‑object.  
9. Stel de *return to the original slide from the linked section*‑mogelijkheid in.  
11. Wijzig de lijnopmaak voor het tweede zoomframe‑object.  
12. Wijzig de overgangsduur.  
13. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` java
Presentation pres = new Presentation();
try {
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 2", slide);

    // Voegt een SummaryZoomFrame-object toe
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Haalt het eerste SummaryZoomSection-object op
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Opmaak voor SummaryZoomSection-object
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik het terugkeren naar de 'ouder'-dia regelen nadat het doel is weergegeven?**

Ja. Het [Zoom frame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zoomframe/) of [section](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sectionzoomframe/) heeft een `ReturnToParent`‑gedrag dat, wanneer ingeschakeld, kijkers na het bezoeken van de doelinhoud terugstuurt naar de oorspronkelijke dia.

**Kan ik de 'snelheid' of duur van de Zoom‑overgang aanpassen?**

Ja. Zoom ondersteunt het instellen van een `TransitionDuration` zodat u de duur van de spronganimatie kunt beheersen.

**Zijn er limieten aan hoeveel Zoom‑objecten een presentatie kan bevatten?**

Er is geen harde API‑limiet gedocumenteerd. Praktische limieten hangen af van de algehele complexiteit van de presentatie en de prestaties van de viewer. U kunt veel Zoom‑frames toevoegen, maar houd rekening met bestandsgrootte en render‑tijd.