---
title: Hantera presentationzoom i Java
linktitle: Hantera zoom
type: docs
weight: 60
url: /sv/java/manage-zoom/
keywords:
- zoom
- zoomram
- bildzoom
- sektionzoom
- sammanfattningszoom
- lägg till zoom
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa och anpassa zoom med Aspose.Slides för Java — hoppa mellan sektioner, lägg till miniatyrbilder och övergångar i PPT-, PPTX- och ODP-presentationer."
---
## **Introduction**

Zoom-funktionerna i PowerPoint låter dig hoppa till och från specifika bilder, sektioner och delar av en presentation. När du presenterar kan denna förmåga att snabbt navigera i innehållet vara mycket användbar. 

![overview_image](overview.png)

* För att sammanfatta en hel presentation på en enda bild, använd en [Summary Zoom](#Summary-Zoom).
* För att bara visa utvalda bilder, använd en [Slide Zoom](#Slide-Zoom).
* För att bara visa en enskild sektion, använd en [Section Zoom](#Section-Zoom).

## **Slide Zoom**
En slide‑zoom kan göra din presentation mer dynamisk genom att låta dig navigera fritt mellan bilder i valfri ordning utan att avbryta flödet i din presentation. Slide‑zooms är utmärkta för korta presentationer utan många sektioner, men du kan även använda dem i olika presentationsscenario.

Slide‑zooms hjälper dig att gräva ner dig i flera informationsbitar samtidigt som du upplever att du befinner dig på en enda yta. 

![overview_image](slidezoomsel.png)

För slide‑zoom‑objekt tillhandahåller Aspose.Slides uppräkningen [ZoomImageType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ZoomImageType) , gränssnittet [IZoomFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IZoomFrame) och några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection) .

### **Skapa Zoom‑ramar**

Du kan lägga till en zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
2. Skapa nya bilder som du avser att länka zoom‑ramarna till. 
3. Lägg till en identifieringstext och bakgrund på de skapade bilderna.
4. Lägg till zoom‑ramar (som innehåller referenser till de skapade bilderna) på den första bilden.
5. Skriv ut den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar en zoom‑ram på en bild:

``` java
Presentation pres = new Presentation();
try {
    //Lägger till nya bilder i presentationen
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Skapar en bakgrund för den andra bilden
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Skapar en textruta för den andra bilden
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Skapar en bakgrund för den tredje bilden
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Skapa en textruta för den tredje bilden
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Lägger till ZoomFrame-objekt
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Skapa Zoom‑ramar med anpassade bilder**
Med Aspose.Slides för Java kan du skapa en zoom‑ram med en annan förhandsgranskningsbild för bilden på följande sätt: 
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
2. Skapa en ny bild som du avser att länka zoom‑ramen till. 
3. Lägg till en identifieringstext och bakgrund på bilden.
4. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPPImage)‑objekt genom att lägga till en bild i Images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑objektet och som kommer att användas för att fylla ramen.
5. Lägg till zoom‑ramar (som innehåller referensen till den skapade bilden) på den första bilden.
6. Skriv ut den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar en zoom‑ram med en annan bild:

``` java
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Skapar en bakgrund för den andra bilden
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Skapar en textruta för den tredje bilden
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Skapar en ny bild för zoom-objektet
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Lägger till ZoomFrame-objektet
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatera Zoom‑ramar**
I föregående avsnitt visade vi hur du skapar enkla zoom‑ramar. För att skapa mer komplexa zoom‑ramar måste du ändra formateringen för en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en zoom‑ram. 

Du kan kontrollera en zoom‑ramens formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
2. Skapa nya bilder som du avser att länka zoom‑ramarna till. 
3. Lägg till någon identifieringstext och bakgrund på de skapade bilderna.
4. Lägg till zoom‑ramar (som innehåller referenser till de skapade bilderna) på den första bilden.
5. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPPImage)‑objekt genom att lägga till en bild i Images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑objektet och som kommer att användas för att fylla ramen.
6. Ställ in en anpassad bild för det första zoom‑ramobjektet.
7. Ändra linjeformatet för det andra zoom‑ramobjektet.
8. Ta bort bakgrunden från en bild i det andra zoom‑ramobjektet.
5. Skriv ut den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du ändrar en zoom‑ramens formatering på en bild: 

``` java 
Presentation pres = new Presentation();
try {
    //Lägger till nya bilder i presentationen
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Skapar en bakgrund för den andra bilden
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Skapar en textruta för den andra bilden
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Skapar en bakgrund för den tredje bilden
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Skapar en textruta för den tredje bilden
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Lägger till ZoomFrame-objekt
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Skapar en ny bild för zoom-objektet
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Ställer in anpassad bild för zoomFrame1-objektet
    zoomFrame1.setImage(picture);

    // Ställer in ett zoomramformat för zoomFrame2-objektet
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Inställning för att inte visa bakgrund för zoomFrame2-objektet
    zoomFrame2.setShowBackground(false);

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Section Zoom**

En sektion‑zoom är en länk till en sektion i din presentation. Du kan använda sektion‑zooms för att återgå till sektioner du vill lyfta fram. Eller så kan du använda dem för att belysa hur vissa delar av din presentation hänger ihop. 

![overview_image](seczoomsel.png)

För sektion‑zoom‑objekt tillhandahåller Aspose.Slides gränssnittet [ISectionZoomFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISectionZoomFrame) och några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection) .

### **Skapa Sektion‑Zoom‑ramar**

Du kan lägga till en sektion‑zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
2. Skapa en ny bild. 
3. Lägg till en identifieringsbakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoom‑ramen till. 
5. Lägg till en sektion‑zoom‑ram (som innehåller referenser till den skapade sektionen) på den första bilden.
6. Skriv ut den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar en zoom‑ram på en bild:

``` java
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);

    //Lägger till ett SectionZoomFrame-objekt
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Skapa Sektion‑Zoom‑ramar med anpassade bilder**

Med Aspose.Slides för Java kan du skapa en sektion‑zoom‑ram med en annan förhandsgranskningsbild för bilden på följande sätt: 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
2. Skapa en ny bild.
3. Lägg till en identifieringsbakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoom‑ramen till. 
5. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPPImage)‑objekt genom att lägga till en bild i Images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑objektet och som kommer att användas för att fylla ramen.
5. Lägg till en sektion‑zoom‑ram (som innehåller en referens till den skapade sektionen) på den första bilden.
6. Skriv ut den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar en zoom‑ram med en annan bild:

``` java 
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);

    // Skapar en ny bild för zoom-objektet
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Lägger till SectionZoomFrame-objekt
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatera Sektion‑Zoom‑ramar**

För att skapa mer komplexa sektion‑zoom‑ramar måste du ändra formateringen för en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en sektion‑zoom‑ram. 

Du kan kontrollera en sektion‑zoom‑ramens formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
2. Skapa en ny bild.
3. Lägg till identifieringsbakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoom‑ramen till. 
5. Lägg till en sektion‑zoom‑ram (som innehåller referenser till den skapade sektionen) på den första bilden.
6. Ändra storlek och position för det skapade sektion‑zoom‑objektet.
7. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPPImage)‑objekt genom att lägga till en bild i Images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑objektet och som kommer att användas för att fylla ramen.
8. Ställ in en anpassad bild för det skapade sektion‑zoom‑ramobjektet.
9. Ställ in *återgå till den ursprungliga bilden från den länkade sektionen*‑funktionen. 
10. Ta bort bakgrunden från en bild i sektion‑zoom‑ramobjektet.
11. Ändra linjeformatet för det andra zoom‑ramobjektet.
12. Ändra övergångens varaktighet.
13. Skriv ut den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du ändrar en sektion‑zoom‑ramens formatering:

``` java
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);

    // Lägg till SectionZoomFrame-objekt
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatering för SectionZoomFrame
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

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Summary Zoom**

En summary‑zoom är som en landningssida där alla delar av din presentation visas på en gång. När du presenterar kan du använda zoomen för att gå från en plats i din presentation till en annan i vilken ordning du vill. Du kan vara kreativ, hoppa framåt eller återbesöka delar av ditt bildspel utan att avbryta flödet i din presentation.

![overview_image](sumzoomsel.png)

För summary‑zoom‑objekt tillhandahåller Aspose.Slides gränssnitten [ISummaryZoomFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISummaryZoomFrame) , [ISummaryZoomSection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISummaryZoomSection) och [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISummaryZoomSectionCollection) samt några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection) .

### **Create a Summary Zoom**

Du kan lägga till en summary‑zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till summary‑zoom‑ramen på den första bilden.
4. Skriv ut den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar en summary‑zoom‑ram på en bild:

``` java 
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 2", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 3", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 4", slide);

    // Lägger till ett SummaryZoomFrame-objekt
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Add and Remove a Summary Zoom Section**

Alla sektioner i en summary‑zoom‑ram representeras av [ISummaryZoomSection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISummaryZoomSection)‑objekt, som lagras i [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISummaryZoomSectionCollection)‑objektet. Du kan lägga till eller ta bort ett summary‑zoom‑sektion‑objekt via gränssnittet [ISummaryZoomSectionCollection] på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en summary‑zoom‑ram i den första bilden.
4. Lägg till en ny bild och sektion i presentationen.
5. Lägg till den skapade sektionen i summary‑zoom‑ramen.
6. Ta bort den första sektionen från summary‑zoom‑ramen.
7. Skriv ut den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du lägger till och tar bort sektioner i en summary‑zoom‑ram:

``` java
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 2", slide);

    // Lägger till SummaryZoomFrame-objekt
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Lägger till en sektion i Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Tar bort sektion från Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Format Summary Zoom Sections**

För att skapa mer komplexa summary‑zoom‑sektion‑objekt måste du ändra formateringen för en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på ett summary‑zoom‑sektion‑objekt. 

Du kan kontrollera formateringen för ett summary‑zoom‑sektion‑objekt i en summary‑zoom‑ram på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en summary‑zoom‑ram på den första bilden.
4. Hämta ett summary‑zoom‑sektion‑objekt för det första objektet från `ISummaryZoomSectionCollection` .
7. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPPImage)‑objekt genom att lägga till en bild i images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑objektet och som kommer att användas för att fylla ramen.
8. Ställ in en anpassad bild för det skapade sektion‑zoom‑ramobjektet.
9. Ställ in *återgå till den ursprungliga bilden från den länkade sektionen*‑funktionen. 
11. Ändra linjeformatet för det andra zoom‑ramobjektet.
12. Ändra övergångens varaktighet.
13. Skriv ut den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du ändrar formateringen för ett summary‑zoom‑sektion‑objekt:

``` java
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 2", slide);

    // Lägger till ett SummaryZoomFrame-objekt
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Hämtar det första SummaryZoomSection-objektet
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatering för SummaryZoomSection-objekt
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

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag styra återgången till den "föräldra"-bilden efter att målet har visats?**

Ja. [Zoom frame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/zoomframe/) eller [section](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sectionzoomframe/) har ett `ReturnToParent`‑beteende som, när det är aktiverat, skickar tittarna tillbaka till den ursprungliga bilden efter att de har besökt mål­innehållet.

**Kan jag justera "hastigheten" eller varaktigheten för Zoom‑övergången?**

Ja. Zoom stöder att ange ett `TransitionDuration` så att du kan kontrollera hur lång tid hoppanimationen tar.

**Finns det begränsningar för hur många Zoom‑objekt en presentation kan innehålla?**

Det finns ingen hård API‑gräns dokumenterad. Praktiska gränser beror på presentationens totala komplexitet och tittarens prestanda. Du kan lägga till många Zoom‑ramar, men bör ta hänsyn till filstorlek och renderingtid.