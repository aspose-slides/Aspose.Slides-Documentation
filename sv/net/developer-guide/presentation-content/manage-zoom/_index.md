---
title: Hantera presentationszoom i .NET
linktitle: Hantera Zoom
type: docs
weight: 60
url: /sv/net/manage-zoom/
keywords:
- zoom
- zoomram
- bildzoom
- sektionzoom
- sammanfattningszoom
- lägg till zoom
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa och anpassa Zoom med Aspose.Slides för .NET — hoppa mellan sektioner, lägg till miniatyrbilder och övergångar i PPT-, PPTX- och ODP-presentationer."
---
## **Introduction**

Zoom-funktioner i PowerPoint låter dig hoppa till och från specifika bilder, sektioner och delar av en presentation. När du presenterar kan denna möjlighet att snabbt navigera i innehållet vara mycket användbar. 

![overview_image](overview.png)

* För att sammanfatta en hel presentation på en enda bild, använd en [Summary Zoom](#Summary-Zoom).
* För att bara visa utvalda bilder, använd en [Slide Zoom](#Slide-Zoom).
* För att bara visa en enda sektion, använd en [Section Zoom](#Section-Zoom).

## **Slide Zoom**
En slide zoom kan göra din presentation mer dynamisk, genom att du kan navigera fritt mellan bilder i vilken ordning du önskar utan att avbryta presentationens flöde. Slide zooms är utmärkta för korta presentationer utan många sektioner, men du kan fortfarande använda dem i olika presentationsscenarier.

Slide zooms hjälper dig att gräva djupare i flera informationsbitar samtidigt som du känner dig på en enda duk. 

![overview_image](slidezoomsel.png)

För slide‑zoom‑objekt tillhandahåller Aspose.Slides enumerationen [ZoomImageType](https://reference.aspose.com/slides/sv/net/aspose.slides/zoomimagetype), gränssnittet [IZoomFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/izoomframe) och några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection).

### **Create Zoom Frames**

Du kan lägga till en zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Skapa nya bilder som du avser att länka zoom‑ramarna till. 
3. Lägg till identifierande text och bakgrund på de skapade bilderna.
4. Lägg till zoom‑ramar (med referenser till de skapade bilderna) på den första bilden.
5. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar en zoom‑ram på en bild:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Lägger till nya bilder i presentationen
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Skapar en bakgrund för den andra bilden
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Skapar en textruta för den andra bilden
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Skapar en bakgrund för den tredje bilden
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Skapar en textruta för den tredje bilden
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Lägger till ZoomFrame-objekt
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Sparar presentationen
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Create Zoom Frames with Custom Images**
Med Aspose.Slides för .NET kan du skapa en zoom‑ram med en annan förhandsgranskningsbild för bilden så här: 
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Skapa en ny bild som du avser att länka zoom‑ramen till. 
3. Lägg till identifierande text och bakgrund på bilden.
4. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i Images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-objektet som ska användas för att fylla ramen.
5. Lägg till zoom‑ramar (med referensen till den skapade bilden) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar en zoom‑ram med en annan bild:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Skapar en bakgrund för den andra bilden
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Skapar en textruta för den tredje bilden
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Skapar en ny bild för zoom-objektet
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Lägger till ZoomFrame-objektet
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Sparar presentationen
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Format Zoom Frames**
I föregående avsnitt visade vi hur du skapar enkla zoom‑ramar. För att skapa mer komplicerade zoom‑ramar måste du ändra formateringen för en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en zoom‑ram. 

Du kan kontrollera en zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Skapa nya bilder att länka till som du avser att länka zoom‑ramen till. 
3. Lägg till identifierande text och bakgrund på de skapade bilderna.
4. Lägg till zoom‑ramar (med referenser till de skapade bilderna) på den första bilden.
5. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i Images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-objektet som ska användas för att fylla ramen.
6. Ställ in en anpassad bild för det första zoom‑ramobjektet.
7. Ändra linjeformateringen för det andra zoom‑ramobjektet.
8. Ta bort bakgrunden från en bild i det andra zoom‑ramobjektet.
5. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du ändrar formateringen för en zoom‑ram på en bild: 

``` csharp 
using (Presentation pres = new Presentation())
{
    //Lägger till nya bilder i presentationen
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Skapar en bakgrund för den andra bilden
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Skapar en textruta för den andra bilden
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Skapar en bakgrund för den tredje bilden
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Skapar en textruta för den tredje bilden
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Lägger till ZoomFrame-objekt
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Skapar en ny bild för zoom-objektet
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Ställer in anpassad bild för zoomFrame1-objektet
    zoomFrame1.ZoomImage = ppImage;

    // Ställer in ett zoom‑ramformat för zoomFrame2-objektet
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Inställning för att inte visa bakgrund för zoomFrame2-objektet
    zoomFrame2.ShowBackground = false;

    // Sparar presentationen
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Section Zoom**

En section zoom är en länk till en sektion i din presentation. Du kan använda section zooms för att återgå till sektioner du verkligen vill betona. Eller så kan du använda dem för att visa hur vissa delar av din presentation hänger ihop. 

![overview_image](seczoomsel.png)

För section‑zoom‑objekt tillhandahåller Aspose.Slides gränssnittet [ISectionZoomFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/isectionzoomframe) och några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection).

### **Create Section Zoom Frames**

Du kan lägga till en section‑zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Skapa en ny bild. 
3. Lägg till en identifierande bakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoom‑ramen till. 
5. Lägg till en section‑zoom‑ram (med referenser till den skapade sektionen) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar en zoom‑ram på en bild:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 1", slide);

    // Lägger till ett SectionZoomFrame-objekt
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Sparar presentationen
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Create Section Zoom Frames with Custom Images**

Med Aspose.Slides för .NET kan du skapa en section‑zoom‑ram med en annan förhandsgranskningsbild för bilden så här: 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Skapa en ny bild.
3. Lägg till en identifierande bakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoom‑ramen till. 
5. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i Images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-objektet som ska användas för att fylla ramen.
5. Lägg till en section‑zoom‑ram (med en referens till den skapade sektionen) på den första bilden.
6. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar en zoom‑ram med en annan bild:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 1", slide);

    // Skapar en ny bild för zoom-objektet
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Lägger till SectionZoomFrame-objekt
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Sparar presentationen
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Format Section Zoom Frames**

För att skapa mer komplicerade section‑zoom‑ramar måste du ändra formateringen för en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en section‑zoom‑ram. 

Du kan kontrollera formateringen för en section‑zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Skapa en ny bild.
3. Lägg till identifierande bakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoom‑ramen till. 
5. Lägg till en section‑zoom‑ram (med referenser till den skapade sektionen) på den första bilden.
6. Ändra storlek och position för det skapade section‑zoom‑objektet.
7. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i Images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-objektet som ska användas för att fylla ramen.
8. Ställ in en anpassad bild för det skapade section‑zoom‑ramobjektet.
9. Ställ in *återgång till originalbilden från den länkade sektionen*.
10. Ta bort bakgrunden från en bild i section‑zoom‑ramobjektet.
11. Ändra linjeformateringen för det andra zoom‑ramobjektet.
12. Ändra övergångstiden.
13. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du ändrar formateringen för en section‑zoom‑ram:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 1", slide);

    // Lägg till SectionZoomFrame-objekt
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formatering för SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Sparar presentationen
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Summary Zoom**

En summary zoom fungerar som en landningssida där alla delar av din presentation visas samtidigt. När du presenterar kan du använda zoom‑funktionen för att gå från en plats i presentationen till en annan i vilken ordning du vill. Du kan vara kreativ, hoppa fram eller återgå till delar av ditt bildspel utan att avbryta flödet i presentationen.

![overview_image](sumzoomsel.png)

För summary‑zoom‑objekt tillhandahåller Aspose.Slides gränssnitten [ISummaryZoomFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/sv/net/aspose.slides/isummaryzoomsection) och [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/isummaryzoomsectioncollection) samt några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection).

### **Create a Summary Zoom**

Du kan lägga till en summary‑zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Skapa nya bilder med identifierande bakgrund och nya sektioner för de skapade bilderna.
3. Lägg till summary‑zoom‑ramen på den första bilden.
4. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du skapar en summary‑zoom‑ram på en bild:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 1", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 2", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 3", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 4", slide);

    // Lägger till ett SummaryZoomFrame-objekt
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Sparar presentationen
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Add and Remove a Summary Zoom Section**

Alla sektioner i en summary‑zoom‑ram representeras av [ISummaryZoomFrameSection](https://reference.aspose.com/slides/sv/net/aspose.slides/isummaryzoomsection)-objekt, som lagras i [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/isummaryzoomsectioncollection)-objektet. Du kan lägga till eller ta bort ett summary‑zoom‑sektionobjekt via [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/isummaryzoomsectioncollection)-gränssnittet på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Skapa nya bilder med identifierande bakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en summary‑zoom‑ram i den första bilden.
4. Lägg till en ny bild och sektion i presentationen.
5. Lägg till den skapade sektionen i summary‑zoom‑ramen.
6. Ta bort den första sektionen från summary‑zoom‑ramen.
7. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du lägger till och tar bort sektioner i en summary‑zoom‑ram:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Lägger till en ny bild i presentationen
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 1", slide);

    //Lägger till en ny bild i presentationen
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 2", slide);

    // Lägger till SummaryZoomFrame-objekt
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Lägger till en ny bild i presentationen
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Lägger till en sektion i Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Tar bort sektion från Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Sparar presentationen
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Format Summary Zoom Sections**

För att skapa mer komplicerade summary‑zoom‑sektionobjekt måste du ändra formateringen för en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på ett summary‑zoom‑sektionobjekt. 

Du kan kontrollera formateringen för ett summary‑zoom‑sektionobjekt i en summary‑zoom‑ram på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Skapa nya bilder med identifierande bakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en summary‑zoom‑ram på den första bilden.
4. Hämta ett summary‑zoom‑sektionobjekt för det första objektet från `ISummaryZoomSectionCollection`.
7. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i images‑samlingen som är kopplad till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-objektet som ska användas för att fylla ramen.
8. Ställ in en anpassad bild för det skapade section‑zoom‑ramobjektet.
9. Ställ in *återgång till originalbilden från den länkade sektionen*.
11. Ändra linjeformateringen för det andra zoom‑ramobjektet.
12. Ändra övergångstiden.
13. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du ändrar formateringen för ett summary‑zoom‑sektionobjekt:

``` csharp 
using (Presentation pres = new Presentation())
{
    // Lägger till en ny bild i presentationen
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 1", slide);

    // Lägger till en ny bild i presentationen
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Lägger till en ny sektion i presentationen
    pres.Sections.AddSection("Section 2", slide);

    // Lägger till ett SummaryZoomFrame-objekt
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Hämtar det första SummaryZoomSection-objektet
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Formatering för SummaryZoomSection-objekt
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Sparar presentationen
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. The [Zoom frame](https://reference.aspose.com/slides/sv/net/aspose.slides/zoomframe/) or [section](https://reference.aspose.com/slides/sv/net/aspose.slides/sectionzoomframe/) has a `ReturnToParent` behavior that, when enabled, sends viewers back to the originating slide after they visit the target content.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Zoom supports setting a `TransitionDuration` so you can control how long the jump animation takes.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.