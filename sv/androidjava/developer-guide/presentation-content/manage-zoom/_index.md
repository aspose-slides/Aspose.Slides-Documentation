---
title: Hantera presentationszoom på Android
linktitle: Hantera zoom
type: docs
weight: 60
url: /sv/androidjava/manage-zoom/
keywords:
- zoom
- zoomram
- bildzoom
- sektionzoom
- sammanfattningszoom
- lägg till zoom
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa och anpassa zoom med Aspose.Slides för Android via Java — hoppa mellan sektioner, lägg till miniatyrbilder och övergångar i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

Zoom‑funktioner i PowerPoint låter dig hoppa till och från specifika bilder, sektioner och delar av en presentation. När du presenterar kan denna möjlighet att snabbt navigera i innehållet vara mycket användbar. 

![overview_image](overview.png)

* För att sammanfatta hela presentationen på en enda bild, använd en [Summary Zoom](#Summary-Zoom).
* För att endast visa utvalda bilder, använd en [Slide Zoom](#Slide-Zoom).
* För att visa en enda sektion, använd en [Section Zoom](#Section-Zoom).

## **Bildzoom**
En bildzoom kan göra din presentation mer dynamisk genom att låta dig navigera fritt mellan bilder i vilken ordning du väljer utan att avbryta presentationens flöde. Bildzoomer är utmärkta för korta presentationer utan många sektioner, men du kan ändå använda dem i olika presentationsscenario.

Bildzoomer hjälper dig att fördjupa dig i flera informationsbitar samtidigt som du känner dig på en enda yta. 

![overview_image](slidezoomsel.png)

För bildzoom‑objekt tillhandahåller Aspose.Slides uppräkningen [ZoomImageType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ZoomImageType), gränssnittet [IZoomFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IZoomFrame) och några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection).

### **Skapa zoomramar**

Du kan lägga till en zoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Skapa nya bilder som du avser att länka zoomramarna till. 
3. Lägg till en identifieringstext och bakgrund till de skapade bilderna.
4. Lägg till zoomramar (som innehåller referenser till de skapade bilderna) på den första bilden.
5. Skriv den modifierade presentationen som en PPTX‑fil.

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

    //Lägger till ZoomFrame‑objekt
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Skapa zoomramar med anpassade bilder**

Med Aspose.Slides för Android via Java kan du skapa en zoomram med en annan bildförhandsvisning på följande sätt:
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Skapa en ny bild som du avser att länka zoomramen till. 
3. Lägg till en identifieringstext och bakgrund till bilden.
4. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPPImage)-objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet och som kommer att användas för att fylla ramen.
5. Lägg till zoomramar (som innehåller referensen till den skapade bilden) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX‑fil.

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

    // Skapar en ny bild för zoom‑objektet
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Lägger till ZoomFrame‑objektet
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatera zoomramar**

I de föregående avsnitten visade vi hur du skapar enkla zoomramar. För att skapa mer komplicerade zoomramar måste du ändra formateringen av en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en zoomram. 

Du kan styra en zoomramens formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Skapa nya bilder att länka till som du avser att länka zoomramen till. 
3. Lägg till någon identifieringstext och bakgrund till de skapade bilderna.
4. Lägg till zoomramar (som innehåller referenser till de skapade bilderna) på den första bilden.
5. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPPImage)-objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet och som kommer att användas för att fylla ramen.
6. Ställ in en anpassad bild för det första zoomramobjektet.
7. Ändra linjeformatet för det andra zoomramobjektet.
8. Ta bort bakgrunden från en bild i det andra zoomramobjektet.
5. Skriv den modifierade presentationen som en PPTX‑fil.

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

## **Sektionzoom**

Ett sektionzoom är en länk till en sektion i din presentation. Du kan använda sektionzoomer för att återgå till sektioner du vill betona. Eller så kan du använda dem för att framhäva hur vissa delar av din presentation hänger ihop. 

![overview_image](seczoomsel.png)

För sektionzoom‑objekt tillhandahåller Aspose.Slides gränssnittet [ISectionZoomFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISectionZoomFrame) samt några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection).

### **Skapa sektionzoomramar**

Du kan lägga till en sektionzoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Skapa en ny bild. 
3. Lägg till en identifieringsbakgrund till den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Lägg till en sektionzoomram (som innehåller referenser till den skapade sektionen) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX‑fil.

``` java
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 1", slide);

    //Lägger till ett SectionZoomFrame-objekt
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Skapa sektionzoomramar med anpassade bilder**

Med Aspose.Slides för Android via Java kan du skapa en sektionzoomram med en annan bildförhandsvisning på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Skapa en ny bild.
3. Lägg till en identifieringsbakgrund till den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPPImage)-objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet och som kommer att användas för att fylla ramen.
5. Lägg till en sektionzoomram (som innehåller en referens till den skapade sektionen) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX‑fil.

``` java 
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 1", slide);

    // Skapar en ny bild för zoom‑objektet
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Lägger till SectionZoomFrame‑objekt
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatera sektionzoomramar**

För att skapa mer komplicerade sektionzoomramar måste du ändra formateringen av en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en sektionzoomram. 

Du kan styra en sektionzoomramens formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Skapa en ny bild.
3. Lägg till en identifieringsbakgrund till den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Lägg till en sektionzoomram (som innehåller referenser till den skapade sektionen) på den första bilden.
6. Ändra storlek och position för det skapade sektionzoom‑objektet.
7. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPPImage)-objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet och som kommer att användas för att fylla ramen.
8. Ställ in en anpassad bild för det skapade sektionzoomramobjektet.
9. Aktivera funktionen *återgå till den ursprungliga bilden från den länkade sektionen*.
10. Ta bort bakgrunden från en bild i sektionzoomramobjektet.
11. Ändra linjeformatet för det andra zoomramobjektet.
12. Ändra övergångens varaktighet.
13. Skriv den modifierade presentationen som en PPTX‑fil.

``` java
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
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
    pres.save("presentation.ppptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Sammanfattningszoom**

En sammanfattningszoom är som en landningssida där alla delar av din presentation visas samtidigt. När du presenterar kan du använda zoomen för att gå från en plats i presentationen till en annan i vilken ordning du vill. Du kan vara kreativ, hoppa framåt eller återbesöka delar av ditt bildspel utan att avbryta presentationens flöde.

![overview_image](sumzoomsel.png)

För sammanfattningszoom‑objekt tillhandahåller Aspose.Slides gränssnitten [ISummaryZoomFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISummaryZoomSection) och [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) samt några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection).

### **Skapa en sammanfattningszoom**

Du kan lägga till en sammanfattningszoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till sammanfattningszoomramen på den första bilden.
4. Skriv den modifierade presentationen som en PPTX‑fil.

``` java 
Presentation pres = new Presentation();
try {
    // Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 1", slide);

    // Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 2", slide);

    // Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 3", slide);

    // Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 4", slide);

    // Lägger till ett SummaryZoomFrame-objekt
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Lägg till och ta bort en sammanfattningszoomsektion**

Alla sektioner i en sammanfattningszoomram representeras av [ISummaryZoomSection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISummaryZoomSection)-objekt som lagras i [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISummaryZoomSectionCollection)-objektet. Du kan lägga till eller ta bort ett sammanfattningszoomsektion‑objekt via [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISummaryZoomSectionCollection)-gränssnittet på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en sammanfattningszoomram i den första bilden.
4. Lägg till en ny bild och sektion i presentationen.
5. Lägg till den skapade sektionen i sammanfattningszoomramen.
6. Ta bort den första sektionen från sammanfattningszoomramen.
7. Skriv den modifierade presentationen som en PPTX‑fil.

``` java
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 1", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 2", slide);

    // Lägger till SummaryZoomFrame-objekt
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Lägger till ett avsnitt i Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Tar bort avsnitt från Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Sparar presentationen
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatera sammanfattningszoomsektioner**

För att skapa mer komplicerade sammanfattningszoomsektion‑objekt måste du ändra formateringen av en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på ett sammanfattningszoomsektion‑objekt. 

Du kan styra formateringen för ett sammanfattningszoomsektion‑objekt i en sammanfattningszoomram på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en sammanfattningszoomram på den första bilden.
4. Hämta ett sammanfattningszoomsektion‑objekt för det första objektet från `ISummaryZoomSectionCollection`.
7. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPPImage)-objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet och som kommer att användas för att fylla ramen.
8. Ställ in en anpassad bild för det skapade sektionzoomramobjektet.
9. Aktivera funktionen *återgå till den ursprungliga bilden från den länkade sektionen*.
11. Ändra linjeformatet för det andra zoomramobjektet.
12. Ändra övergångens varaktighet.
13. Skriv den modifierade presentationen som en PPTX‑fil.

``` java
Presentation pres = new Presentation();
try {
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 1", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Lägger till ett nytt avsnitt i presentationen
    pres.getSections().addSection("Section 2", slide);

    // Lägger till ett SummaryZoomFrame-objekt
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Hämtar det första SummaryZoomSection-objektet
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatering för SummaryZoomSection-objektet
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

**Kan jag kontrollera återgång till den 'föräldra' bilden efter att ha visat målet?**

Ja. [Zoom frame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zoomframe/) eller [section](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sectionzoomframe/) har ett återvänd‑till‑förälder‑beteende som, när det är aktiverat, skickar tittarna tillbaka till den ursprungliga bilden efter att de har besökt mål­innehållet.

**Kan jag justera 'hastigheten' eller varaktigheten för Zoom‑övergången?**

Ja. Zoom stödjer att ställa in en övergångsvaraktighet så att du kan kontrollera hur länge hopp‑animationen tar.

**Finns det begränsningar för hur många Zoom‑objekt en presentation kan innehålla?**

Det finns ingen dokumenterad hård API‑gräns. Praktiska begränsningar beror på presentationens totala komplexitet och betraktarens prestanda. Du kan lägga till många Zoom‑ramar, men tänk på filstorlek och renderingtid.