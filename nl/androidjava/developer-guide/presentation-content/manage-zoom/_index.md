---
title: Beheer presentatie‑zoom op Android
linktitle: Beheer zoom
type: docs
weight: 60
url: /nl/androidjava/manage-zoom/
keywords:
- zoom
- zoomframe
- dia‑zoom
- sectie‑zoom
- samenvatting‑zoom
- zoom toevoegen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en pas Zoom aan met Aspose.Slides voor Android via Java — spring tussen secties, voeg miniaturen en overgangen toe in PPT, PPTX en ODP‑presentaties."
---
## **Inleiding**

Zooms in PowerPoint stellen u in staat om naar specifieke dia's, secties en delen van een presentatie te springen en weer terug te keren. Tijdens het presenteren kan deze mogelijkheid om snel door de inhoud te navigeren zeer handig blijken. 

![overview_image](overview.png)

* Om een volledige presentatie samen te vatten op één dia, gebruik een [Summary Zoom](#Summary-Zoom).
* Om alleen geselecteerde dia's weer te geven, gebruik een [Slide Zoom](#Slide-Zoom).
* Om slechts één sectie weer te geven, gebruik een [Section Zoom](#Section-Zoom).

## **Dia Zoom**
Een dia‑zoom kan uw presentatie dynamischer maken, waardoor u vrij tussen dia's kunt navigeren in elke gewenste volgorde zonder de stroom van uw presentatie te onderbreken. Dia‑zooms zijn ideaal voor korte presentaties zonder veel secties, maar u kunt ze ook in andere presentatiescenario's gebruiken.

Dia‑zooms helpen u meerdere stukken informatie te verkennen terwijl u het gevoel heeft zich op één enkel canvas te bevinden. 

![overview_image](slidezoomsel.png)

Voor dia‑zoomobjecten biedt Aspose.Slides de enumeratie [ZoomImageType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ZoomImageType), de interface [IZoomFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IZoomFrame) en enkele methoden onder de interface [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection).

### **Zoomframes maken**

U kunt een zoomframe op een dia als volgt toevoegen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
2. Maak nieuwe dia's aan waaraan u de zoomframes wilt koppelen. 
3. Voeg een identificatietekst en achtergrond toe aan de gemaakte dia's.
4. Voeg zoomframes (met de verwijzingen naar de gemaakte dia's) toe aan de eerste dia.
5. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

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

    //Voegt ZoomFrame‑objecten toe
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Zoomframes maken met aangepaste afbeeldingen**
Met Aspose.Slides for Android via Java kunt u een zoomframe met een andere dia‑previewafbeelding maken als volgt:
1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
2. Maak een nieuwe dia aan waaraan u het zoomframe wilt koppelen. 
3. Voeg een identificatietekst en achtergrond toe aan de dia.
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPPImage)-object aan door een afbeelding toe te voegen aan de Images-collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)-object hoort en die zal worden gebruikt om het frame te vullen.
5. Voeg zoomframes (met de verwijzing naar de gemaakte dia) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

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

    // Maakt een nieuwe afbeelding voor het zoom‑object
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Voegt het ZoomFrame‑object toe
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Zoomframes opmaken**
In de vorige secties hebben we laten zien hoe u eenvoudige zoomframes maakt. Om complexere zoomframes te maken, moet u de opmaak van een simpel frame aanpassen. Er zijn verschillende opmaakopties die u op een zoomframe kunt toepassen. 

U kunt de opmaak van een zoomframe op een dia als volgt regelen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
2. Maak nieuwe dia's aan waaraan u het zoomframe wilt koppelen. 
3. Voeg enige identificatietekst en achtergrond toe aan de gemaakte dia's.
4. Voeg zoomframes (met de verwijzingen naar de gemaakte dia's) toe aan de eerste dia.
5. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPPImage)-object aan door een afbeelding toe te voegen aan de Images-collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)-object hoort en die zal worden gebruikt om het frame te vullen.
6. Stel een aangepaste afbeelding in voor het eerste zoomframe‑object.
7. Wijzig het lijnformaat voor het tweede zoomframe‑object.
8. Verwijder de achtergrond van de afbeelding van het tweede zoomframe‑object.
5. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

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

    //Voegt ZoomFrame‑objecten toe
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Maakt een nieuwe afbeelding voor het zoom‑object
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Stelt aangepaste afbeelding in voor zoomFrame1‑object
    zoomFrame1.setImage(picture);

    // Stelt een zoomframe‑opmaak in voor zoomFrame2‑object
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Instelling om de achtergrond niet te tonen voor zoomFrame2‑object
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

Voor sectie‑zoomobjecten biedt Aspose.Slides de interface [ISectionZoomFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISectionZoomFrame) en enkele methoden onder de interface [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection).

### **Sectie‑zoomframes maken**

U kunt een sectie‑zoomframe op een dia als volgt toevoegen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
2. Maak een nieuwe dia aan. 
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waaraan u het zoomframe wilt koppelen. 
5. Voeg een sectie‑zoomframe (met verwijzingen naar de gemaakte sectie) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

``` java
Presentation pres = new Presentation();
try {
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);

    //Voegt een SectionZoomFrame-object toe
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Sectie‑zoomframes maken met aangepaste afbeeldingen**

Met Aspose.Slides for Android via Java kunt u een sectie‑zoomframe met een andere dia‑previewafbeelding maken als volgt:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waaraan u het zoomframe wilt koppelen. 
5. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPPImage)-object aan door een afbeelding toe te voegen aan de Images-collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)-object hoort en die zal worden gebruikt om het frame te vullen.
5. Voeg een sectie‑zoomframe (met een verwijzing naar de gemaakte sectie) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

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

    // Maakt een nieuwe afbeelding voor het zoom object
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt SectionZoomFrame object toe
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Sectie‑zoomframes opmaken**

Om complexere sectie‑zoomframes te maken, moet u de opmaak van een simpel frame aanpassen. Er zijn verschillende opmaakopties die u op een sectie‑zoomframe kunt toepassen. 

U kunt de opmaak van een sectie‑zoomframe op een dia als volgt beheren:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waaraan u het zoomframe wilt koppelen. 
5. Voeg een sectie‑zoomframe (met verwijzingen naar de gemaakte sectie) toe aan de eerste dia.
6. Wijzig de grootte en positie van het gemaakte sectie‑zoomobject.
7. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPPImage)-object aan door een afbeelding toe te voegen aan de Images-collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)-object hoort en die zal worden gebruikt om het frame te vullen.
8. Stel een aangepaste afbeelding in voor het gemaakte sectie‑zoomframe‑object.
9. Stel de *terugkeer naar de oorspronkelijke dia vanuit de gekoppelde sectie* functionaliteit in. 
10. Verwijder de achtergrond van de afbeelding van het sectie‑zoomframe‑object.
11. Wijzig het lijnformaat voor het tweede zoomframe‑object.
12. Wijzig de transitie‑duur.
13. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

``` java
Presentation pres = new Presentation();
try {
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 1", slide);

    //Voegt SectionZoomFrame-object toe
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //Opmaak voor SectionZoomFrame
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

    //Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Samenvatting‑Zoom**

Een samenvatting‑zoom is als een landingspagina waarop alle onderdelen van uw presentatie in één keer worden weergegeven. Tijdens het presenteren kunt u de zoom gebruiken om van de ene naar de andere plek in uw presentatie te gaan, in elke gewenste volgorde. U kunt creatief zijn, vooruit springen of gedeelten van uw diavoorstelling opnieuw bekijken zonder de stroom van uw presentatie te onderbreken.

![overview_image](sumzoomsel.png)

Voor samenvatting‑zoomobjecten biedt Aspose.Slides de interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISummaryZoomSection) en [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) en enkele methoden onder de interface [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection).

### **Een samenvatting‑zoom maken**

U kunt een samenvatting‑zoomframe op een dia als volgt toevoegen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
2. Maak nieuwe dia's met een identificatie‑achtergrond en nieuwe secties voor de gemaakte dia's.
3. Voeg het samenvatting‑zoomframe toe aan de eerste dia.
4. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

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

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 3", slide);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.getSections().addSection("Section 4", slide);

    // Voegt een SummaryZoomFrame-object toe
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Slaat de presentatie op
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Een samenvatting‑zoomsectie toevoegen en verwijderen**

U kunt een samenvatting‑zoomsectie‑object via de interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) als volgt toevoegen of verwijderen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
2. Maak nieuwe dia's met een identificatie‑achtergrond en nieuwe secties voor de gemaakte dia's.
3. Voeg een samenvatting‑zoomframe toe aan de eerste dia.
4. Voeg een nieuwe dia en sectie toe aan de presentatie.
5. Voeg de gemaakte sectie toe aan het samenvatting‑zoomframe.
6. Verwijder de eerste sectie uit het samenvatting‑zoomframe.
7. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

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

### **Samenvatting‑zoomsecties opmaken**

U kunt de opmaak van een samenvatting‑zoomsectieobject in een samenvatting‑zoomframe als volgt regelen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
2. Maak nieuwe dia's met een identificatie‑achtergrond en nieuwe secties voor de gemaakte dia's.
3. Voeg een samenvatting‑zoomframe toe aan de eerste dia.
4. Haal een samenvatting‑zoomsectieobject op voor het eerste object uit de `ISummaryZoomSectionCollection`.
7. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPPImage)-object aan door een afbeelding toe te voegen aan de images-collectie die bij het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)-object hoort en die zal worden gebruikt om het frame te vullen.
8. Stel een aangepaste afbeelding in voor het gemaakte sectie‑zoomframe‑object.
9. Stel de *terugkeer naar de oorspronkelijke dia vanuit de gekoppelde sectie* functionaliteit in. 
11. Wijzig het lijnformaat voor het tweede zoomframe‑object.
12. Wijzig de transitie‑duur.
13. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

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

**Kan ik de terugkeer naar de 'ouder'-dia regelen na het tonen van het doel?**

Ja. Het [Zoom frame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zoomframe/) of [section](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sectionzoomframe/) heeft een terug‑naar‑ouder‑gedrag dat, wanneer ingeschakeld, de kijkers terugstuurt naar de oorspronkelijke dia nadat ze de doelinhoud hebben bekeken.

**Kan ik de 'snelheid' of duur van de Zoom‑transitie aanpassen?**

Ja. Zoom ondersteunt het instellen van een transitie‑duur zodat u kunt bepalen hoe lang de springanimatie duurt.

**Zijn er limieten aan hoeveel Zoom‑objecten een presentatie kan bevatten?**

Er is geen harde API‑limiet gedocumenteerd. Praktische limieten hangen af van de algehele complexiteit van de presentatie en de prestaties van de viewer. U kunt veel Zoom‑frames toevoegen, maar houd rekening met de bestandsgrootte en render‑tijd.