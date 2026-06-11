---
title: Hantera presentationszoom i JavaScript
linktitle: Hantera zoom
type: docs
weight: 60
url: /sv/nodejs-java/manage-zoom/
keywords:
- zoom
- zoomram
- bildzoom
- sektionzoom
- sammanfattningszoom
- lägga till zoom
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och anpassa Zoom med Aspose.Slides för Node.js — hoppa mellan sektioner, lägg till miniatyrbilder och övergångar i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

Zoom-funktionerna i PowerPoint låter dig hoppa till och från specifika bilder, sektioner och delar av en presentation. När du presenterar kan denna möjlighet att snabbt navigera i innehållet vara väldigt användbar. 

![overview_image](overview.png)

* För att sammanfatta en hel presentation på en enda bild, använd en [Summary Zoom](#Summary-Zoom).
* För att bara visa utvalda bilder, använd en [Slide Zoom](#Slide-Zoom).
* För att bara visa en enskild sektion, använd en [Section Zoom](#Section-Zoom).

## **Bildzoom**

En bildzoom kan göra din presentation mer dynamisk och låta dig navigera fritt mellan bilder i vilken ordning du önskar utan att avbryta presentationens flöde. Bildzoomer är utmärkta för korta presentationer utan många sektioner, men du kan även använda dem i olika presentationsscenario.

Bildzoomer hjälper dig att gräva ner dig i flera informationsdelar samtidigt som du känner dig på en enda yta. 

![overview_image](slidezoomsel.png)

För bildzoom‑objekt tillhandahåller Aspose.Slides uppräkningen [ZoomImageType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ZoomImageType), klassen [ZoomFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ZoomFrame) samt några metoder under klassen [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection).

### **Skapa zoomramar**

Du kan lägga till en zoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Skapa nya bilder som du avser länka zoomramarna till. 
3. Lägg till en identifieringstext och bakgrund till de skapade bilderna.
4. Lägg till zoomramar (som innehåller referenserna till de skapade bilderna) på den första bilden.
5. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till nya bilder i presentationen
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Skapar en bakgrund för den andra bilden
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Skapar en textruta för den andra bilden
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Skapar en bakgrund för den tredje bilden
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Skapar en textruta för den tredje bilden
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Lägger till ZoomFrame-objekt
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Sparar presentationen
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Skapa zoomramar med anpassade bilder**

Med Aspose.Slides för Node.js via Java kan du skapa en zoomram med en annan bildförhandsgranskning på bilden på följande sätt:
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Skapa en ny bild som du avser länka zoomramen till. 
3. Lägg till en identifieringstext och bakgrund till bilden.
4. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PPImage)‑objekt genom att lägga till en bild i bildsamlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑objektet som ska användas för att fylla ramen.
5. Lägg till zoomramar (som innehåller referensen till den skapade bilden) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till en ny bild i presentationen
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Skapar en bakgrund för den andra bilden
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Skapar en textruta för den tredje bilden
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Skapar en ny bild för zoom‑objektet
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Lägger till ZoomFrame‑objektet
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Sparar presentationen
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formatera zoomramar**

I föregående avsnitt visade vi hur du skapar enkla zoomramar. För att skapa mer komplicerade zoomramar måste du ändra formateringen av en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en zoomram. 

Du kan kontrollera en zoomramens formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Skapa nya bilder att länka till som du avser att länka zoomramen till. 
3. Lägg till lite identifieringstext och bakgrund till de skapade bilderna.
4. Lägg till zoomramar (som innehåller referenserna till de skapade bilderna) på den första bilden.
5. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PPImage)‑objekt genom att lägga till en bild i bildsamlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑objektet som ska användas för att fylla ramen.
6. Ange en anpassad bild för det första zoomram‑objektet.
7. Ändra linjeformatet för det andra zoomram‑objektet.
8. Ta bort bakgrunden från en bild av det andra zoomram‑objektet.
5. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till nya bilder i presentationen
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Skapar en bakgrund för den andra bilden
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Skapar en textruta för den andra bilden
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Skapar en bakgrund för den tredje bilden
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Skapar en textruta för den tredje bilden
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Lägger till ZoomFrame-objekt
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Skapar en ny bild för zoom‑objektet
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ställer in en anpassad bild för zoomFrame1-objektet
    zoomFrame1.setImage(picture);
    // Ställer in format för zoomramen för zoomFrame2-objektet
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Inställning för att inte visa bakgrund för zoomFrame2-objektet
    zoomFrame2.setShowBackground(false);
    // Sparar presentationen
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sektionzoom**

En sektionzoom är en länk till en sektion i din presentation. Du kan använda sektionzoomer för att gå tillbaka till sektioner du verkligen vill betona. Eller så kan du använda dem för att framhäva hur vissa delar av din presentation hänger ihop. 

![overview_image](seczoomsel.png)

För sektionzoom‑objekt tillhandahåller Aspose.Slides klassen [SectionZoomFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SectionZoomFrame) och några metoder under klassen [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection).

### **Skapa sektionzoomramar**

Du kan lägga till en sektionzoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Skapa en ny bild. 
3. Lägg till en identifieringsbakgrund till den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Lägg till en sektionzoomram (som innehåller referenser till den skapade sektionen) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till en ny bild i presentationen
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);
    // Lägger till ett SectionZoomFrame-objekt
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Sparar presentationen
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Skapa sektionzoomramar med anpassade bilder**

Med Aspose.Slides för Node.js via Java kan du skapa en sektionzoomram med en annan bildförhandsgranskning på bilden på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Skapa en ny bild.
3. Lägg till en identifieringsbakgrund till den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PPImage)‑objekt genom att lägga till en bild i bildsamlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑objektet som ska användas för att fylla ramen.
5. Lägg till en sektionzoomram (som innehåller en referens till den skapade sektionen) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till en ny bild i presentationen
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);
    // Skapar en ny bild för zoom‑objektet
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Lägger till SectionZoomFrame-objekt
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Sparar presentationen
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formatera sektionzoomramar**

För att skapa mer komplicerade sektionzoomramar måste du ändra formateringen av en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en sektionzoomram. 

Du kan kontrollera en sektionzoomramens formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Skapa en ny bild.
3. Lägg till identifieringsbakgrund till den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Lägg till en sektionzoomram (som innehåller referenser till skapad sektion) på den första bilden.
6. Ändra storlek och position för det skapade sektionzoom‑objektet.
7. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PPImage)‑objekt genom att lägga till en bild i bildsamlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑objektet som ska användas för att fylla ramen.
8. Ange en anpassad bild för det skapade sektionzoom‑ram‑objektet.
9. Aktivera *återgång till den ursprungliga bilden från den länkade sektionen*. 
10. Ta bort bakgrunden från en bild av sektionzoom‑ram‑objektet.
11. Ändra linjeformatet för det andra zoomram‑objektet.
12. Ändra övergångens varaktighet.
13. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till en ny bild i presentationen
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);
    // Lägg till SectionZoomFrame-objekt
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Formatering för SectionZoomFrame
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
    // Sparar presentationen
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sammanfattningszoom**

En sammanfattningszoom är som en landningssida där alla delar av din presentation visas samtidigt. När du presenterar kan du använda zoomen för att gå från en plats i presentationen till en annan i vilken ordning du vill. Du kan vara kreativ, hoppa fram eller återbesöka delar av ditt bildspel utan att avbryta presentationens flöde.

![overview_image](sumzoomsel.png)

För sammanfattningszoom‑objekt tillhandahåller Aspose.Slides klasserna [SummaryZoomFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SummaryZoomSection) och [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SummaryZoomSectionCollection) samt några metoder under klassen [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection).

### **Skapa sammanfattningszoom**

Du kan lägga till en sammanfattningszoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till sammanfattningszoomramen på den första bilden.
4. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till en ny bild i presentationen
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);
    // Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 2", slide);
    // Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 3", slide);
    // Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 4", slide);
    // Lägger till ett SummaryZoomFrame-objekt
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Sparar presentationen
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Lägga till och ta bort sammanfattningszoom‑sektion**

Alla sektioner i en sammanfattningszoomram representeras av [SummaryZoomSection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SummaryZoomSection)-objekt, som lagras i [SummaryZoomSectionCollection]-objektet. Du kan lägga till eller ta bort ett sammanfattningszoom‑sektion‑objekt via klassen [SummaryZoomSectionCollection] på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en sammanfattningszoomram i den första bilden.
4. Lägg till en ny bild och sektion i presentationen.
5. Lägg till den skapade sektionen i sammanfattningszoomramen.
6. Ta bort den första sektionen från sammanfattningszoomramen.
7. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till en ny bild i presentationen
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);
    // Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 2", slide);
    // Lägger till ett SummaryZoomFrame-objekt
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Lägger till en sektion i Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Tar bort sektion från Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Sparar presentationen
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formatera sammanfattningszoom‑sektioner**

För att skapa mer komplicerade sammanfattningszoom‑sektion‑objekt måste du ändra formateringen av en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på ett sammanfattningszoom‑sektion‑objekt. 

Du kan kontrollera formateringen för ett sammanfattningszoom‑sektion‑objekt i en sammanfattningszoomram på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en sammanfattningszoomram på den första bilden.
4. Hämta ett sammanfattningszoom‑sektion‑objekt för det första objektet från `ISummaryZoomSectionCollection`.
7. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PPImage)-objekt genom att lägga till en bild i bildsamlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-objektet som ska användas för att fylla ramen.
8. Ange en anpassad bild för det skapade sektionzoom‑ram‑objektet.
9. Aktivera *återgång till den ursprungliga bilden från den länkade sektionen*. 
11. Ändra linjeformatet för det andra zoomram‑objektet.
12. Ändra övergångens varaktighet.
13. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lägger till en ny bild i presentationen
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 1", slide);
    // Lägger till en ny bild i presentationen
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Lägger till en ny sektion i presentationen
    pres.getSections().addSection("Section 2", slide);
    // Lägger till ett SummaryZoomFrame-objekt
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Hämtar det första SummaryZoomSection-objektet
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Formatering för SummaryZoomSection-objektet
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
    // Sparar presentationen
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan jag kontrollera återgång till den 'föräldra' bild efter att ha visat målet?**

Ja. [Zoom frame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zoomframe/)‑ eller [section](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectionzoomframe/)‑objektet har en `setReturnToParent`‑metod som, när den är aktiverad, skickar tittarna tillbaka till den ursprungliga bilden efter att de har besökt mål­innehållet.

**Kan jag justera 'hastigheten' eller varaktigheten för Zoom‑övergången?**

Ja. Zoom erbjuder en `setTransitionDuration`‑metod så att du kan kontrollera hur lång tid hopp‑animationen tar.

**Finns det begränsningar för hur många Zoom‑objekt en presentation kan innehålla?**

Det finns ingen strikt API‑gräns dokumenterad. Praktiska begränsningar beror på den totala presentationskomplexiteten och tittarens prestanda. Du kan lägga till många Zoom‑ramar, men tänk på filstorlek och renderingtid.