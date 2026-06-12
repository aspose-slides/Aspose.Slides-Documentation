---
title: Beheer Presentatie-Zoom in .NET
linktitle: Zoom beheren
type: docs
weight: 60
url: /nl/net/manage-zoom/
keywords:
- zoom
- zoomframe
- diazoom
- sectiezoom
- samenvattingszoom
- zoom toevoegen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak en pas Zoom aan met Aspose.Slides voor .NET — spring tussen secties, voeg miniaturen en overgangen toe voor PPT-, PPTX- en ODP-presentaties."
---
## **Introductie**

Zooms in PowerPoint stellen je in staat om naar specifieke dia’s, secties en delen van een presentatie te springen en terug te keren. Tijdens het presenteren kan deze mogelijkheid om snel door de inhoud te navigeren zeer nuttig zijn. 

![overview_image](overview.png)

* Om een volledige presentatie op één dia samen te vatten, gebruik je een [Samenvattingszoom](#Summary-Zoom).
* Om alleen geselecteerde dia’s weer te geven, gebruik je een [Diazoom](#Slide-Zoom).
* Om alleen één sectie weer te geven, gebruik je een [Sectiezoom](#Section-Zoom).

## **Diazoom**
Een diazoom kan je presentatie dynamischer maken, doordat je vrij tussen dia’s kunt navigeren in elke gewenste volgorde zonder de stroom van je presentatie te onderbreken. Diazooms zijn ideaal voor korte presentaties zonder veel secties, maar je kunt ze ook in andere presentatiescenario’s gebruiken.

Diazooms helpen je meerdere informatie‑onderdelen te verkennen terwijl je het gevoel hebt op één enkel canvas te werken. 

![overview_image](slidezoomsel.png)

Voor diazoom‑objecten biedt Aspose.Slides de [ZoomImageType](https://reference.aspose.com/slides/nl/net/aspose.slides/zoomimagetype)‑enumeratie, de [IZoomFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/izoomframe)‑interface en een aantal methoden onder de [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection)‑interface.

### **Zoomframes maken**

Je kunt een zoomframe op een dia toevoegen op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Maak nieuwe dia’s aan waaraan je de zoomframes wilt linken. 
3. Voeg een identificatietekst en een achtergrond toe aan de gemaakte dia’s.
4. Voeg zoomframes (met de verwijzingen naar de gemaakte dia’s) toe aan de eerste dia.
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe je een zoomframe op een dia maakt:

``` csharp 
using (Presentation pres = new Presentation())
{
    // Voegt nieuwe dia's toe aan de presentatie
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Maakt een achtergrond voor de tweede dia
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Maakt een tekstvak voor de tweede dia
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Maakt een achtergrond voor de derde dia
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Maakt een tekstvak voor de derde dia
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    // Voegt ZoomFrame-objecten toe
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Slaat de presentatie op
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Zoomframes maken met aangepaste afbeeldingen**
Met Aspose.Slides for .NET kun je een zoomframe met een andere dia‑preview‑afbeelding maken op de volgende manier: 
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Maak een nieuwe dia aan waaraan je het zoomframe wilt linken. 
3. Voeg een identificatietekst en een achtergrond toe aan de dia.
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage)‑object door een afbeelding toe te voegen aan de Images‑collectie die is gekoppeld aan het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑object waarmee het frame wordt gevuld.
5. Voeg zoomframes (met de verwijzing naar de gemaakte dia) toe aan de eerste dia.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe je een zoomframe met een andere afbeelding maakt:

``` csharp 
using (Presentation pres = new Presentation())
{
    // Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Maakt een achtergrond voor de tweede dia
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Maakt een tekstvak voor de derde dia
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Maakt een nieuwe afbeelding voor het zoomobject
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Voegt het ZoomFrame-object toe
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Slaat de presentatie op
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Zoomframes opmaken**
In de vorige secties hebben we je laten zien hoe je eenvoudige zoomframes maakt. Om ingewikkelder zoomframes te maken, moet je de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die je kunt toepassen op een zoomframe. 

Je kunt de opmaak van een zoomframe op een dia aanpassen op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Maak nieuwe dia’s aan waaraan je het zoomframe wilt linken. 
3. Voeg een identificatietekst en een achtergrond toe aan de gemaakte dia’s.
4. Voeg zoomframes (met de verwijzingen naar de gemaakte dia’s) toe aan de eerste dia.
5. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage)‑object door een afbeelding toe te voegen aan de Images‑collectie die is gekoppeld aan het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑object waarmee het frame wordt gevuld.
6. Stel een aangepaste afbeelding in voor het eerste zoomframe‑object.
7. Wijzig de lijnopmaak voor het tweede zoomframe‑object.
8. Verwijder de achtergrond van de afbeelding van het tweede zoomframe‑object.
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe je de opmaak van een zoomframe op een dia wijzigt: 

``` csharp 
using (Presentation pres = new Presentation())
{
    //Voegt nieuwe dia's toe aan de presentatie
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //Maakt een achtergrond voor de tweede dia
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //Maakt een tekstvak voor de tweede dia
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //Maakt een achtergrond voor de derde dia
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //Maakt een tekstvak voor de derde dia
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Voegt ZoomFrame-objecten toe
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //Maakt een nieuwe afbeelding voor het zoomobject
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Stelt een aangepaste afbeelding in voor zoomFrame1-object
    zoomFrame1.ZoomImage = ppImage;

    //Stelt een zoomframe-opmaak in voor zoomFrame2-object
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    //Instelling om de achtergrond niet te tonen voor zoomFrame2-object
    zoomFrame2.ShowBackground = false;

    //Slaat de presentatie op
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Sectiezoom**

Een sectiezoom is een koppeling naar een sectie in je presentatie. Je kunt sectiezooms gebruiken om terug te keren naar secties die je echt wilt benadrukken. Of je kunt ze gebruiken om te laten zien hoe bepaalde delen van je presentatie met elkaar verbonden zijn. 

![overview_image](seczoomsel.png)

Voor sectiezoom‑objecten biedt Aspose.Slides de [ISectionZoomFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/isectionzoomframe)‑interface en een aantal methoden onder de [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection)‑interface.

### **Sectiezoom‑frames maken**

Je kunt een sectiezoom‑frame aan een dia toevoegen op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Maak een nieuwe dia. 
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waaraan je het zoomframe wilt linken. 
5. Voeg een sectiezoom‑frame (met de verwijzingen naar de gemaakte sectie) toe aan de eerste dia.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe je een zoomframe op een dia maakt:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 1", slide);

    // Voegt een SectionZoomFrame-object toe
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Slaat de presentatie op
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Sectiezoom‑frames maken met aangepaste afbeeldingen**

Met Aspose.Slides for .NET kun je een sectiezoom‑frame met een andere dia‑preview‑afbeelding maken op de volgende manier: 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waaraan je het zoomframe wilt linken. 
5. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage)‑object door een afbeelding toe te voegen aan de Images‑collectie die is gekoppeld aan het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑object waarmee het frame wordt gevuld.
5. Voeg een sectiezoom‑frame (met een verwijzing naar de gemaakte sectie) toe aan de eerste dia.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe je een zoomframe met een andere afbeelding maakt:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 1", slide);

    // Maakt een nieuwe afbeelding voor het zoomobject
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Voegt SectionZoomFrame-object toe
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Slaat de presentatie op
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Sectiezoom‑frames opmaken**

Om ingewikkelder sectiezoom‑frames te maken, moet je de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die je kunt toepassen op een sectiezoom‑frame. 

Je kunt de opmaak van een sectiezoom‑frame op een dia aanpassen op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waaraan je het zoomframe wilt linken. 
5. Voeg een sectiezoom‑frame (met de verwijzingen naar de gemaakte sectie) toe aan de eerste dia.
6. Wijzig de grootte en positie van het gemaakte sectiezoom‑object.
7. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage)‑object door een afbeelding toe te voegen aan de Images‑collectie die is gekoppeld aan het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑object waarmee het frame wordt gevuld.
8. Stel een aangepaste afbeelding in voor het gemaakte sectiezoom‑frame‑object.
9. Schakel de *terugkeer naar de originele dia vanaf de gelinkte sectie*‑functionaliteit in. 
10. Verwijder de achtergrond van de afbeelding van het sectiezoom‑frame‑object.
11. Wijzig de lijnopmaak voor het tweede zoomframe‑object.
12. Wijzig de overgangsduur.
13. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe je de opmaak van een sectiezoom‑frame wijzigt:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 1", slide);

    // Voeg SectionZoomFrame-object toe
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Opmaak voor SectionZoomFrame
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

    // Slaat de presentatie op
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Samenvattingszoom**

Een samenvattingszoom is als een landingspagina waarop alle onderdelen van je presentatie tegelijk worden weergegeven. Tijdens het presenteren kun je de zoom gebruiken om van de ene naar de andere plek in je presentatie te gaan, in elke volgorde die je wilt. Je kunt creatief zijn, vooruit springen, of onderdelen van je diavoorstelling opnieuw bezoeken zonder de stroom van je presentatie te onderbreken.

![overview_image](sumzoomsel.png)

Voor samenvattingszoom‑objecten biedt Aspose.Slides de [ISummaryZoomFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/nl/net/aspose.slides/isummaryzoomsection) en [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/isummaryzoomsectioncollection)‑interfaces en een aantal methoden onder de [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection)‑interface.

### **Een samenvattingszoom maken**

Je kunt een samenvattingszoom‑frame aan een dia toevoegen op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de gemaakte dia’s.
3. Voeg het samenvattingszoom‑frame toe aan de eerste dia.
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe je een samenvattingszoom‑frame op een dia maakt:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 1", slide);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 2", slide);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 3", slide);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 4", slide);

    // Voegt een SummaryZoomFrame-object toe
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Slaat de presentatie op
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Een samenvattingszoom‑sectie toevoegen en verwijderen**

Alle secties in een samenvattingszoom‑frame worden vertegenwoordigd door [ISummaryZoomFrameSection](https://reference.aspose.com/slides/nl/net/aspose.slides/isummaryzoomsection)‑objecten, die worden opgeslagen in het [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/isummaryzoomsectioncollection)‑object. Je kunt een samenvattingszoom‑sectie‑object toevoegen of verwijderen via de [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/isummaryzoomsectioncollection)‑interface op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de gemaakte dia’s.
3. Voeg een samenvattingszoom‑frame toe aan de eerste dia.
4. Voeg een nieuwe dia en sectie toe aan de presentatie.
5. Voeg de gemaakte sectie toe aan het samenvattingszoom‑frame.
6. Verwijder de eerste sectie uit het samenvattingszoom‑frame.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe je secties toevoegt en verwijdert in een samenvattingszoom‑frame:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 1", slide);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 2", slide);

    // Voegt een SummaryZoomFrame-object toe
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Voegt een sectie toe aan de Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Verwijdert een sectie uit de Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Slaat de presentatie op
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Samenvattingszoom‑secties opmaken**

Om ingewikkelder samenvattingszoom‑sectie‑objecten te maken, moet je de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die je kunt toepassen op een samenvattingszoom‑sectie‑object. 

Je kunt de opmaak van een samenvattingszoom‑sectie‑object in een samenvattingszoom‑frame aanpassen op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Maak nieuwe dia’s met identificatie‑achtergrond en nieuwe secties voor de gemaakte dia’s.
3. Voeg een samenvattingszoom‑frame toe aan de eerste dia.
4. Haal een samenvattingszoom‑sectie‑object voor het eerste object op uit de `ISummaryZoomSectionCollection`.
7. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage)‑object door een afbeelding toe te voegen aan de images‑collectie die is gekoppeld aan het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑object waarmee het frame wordt gevuld.
8. Stel een aangepaste afbeelding in voor het gemaakte sectie‑zoom‑frame‑object.
9. Schakel de *terugkeer naar de originele dia vanaf de gelinkte sectie*‑functionaliteit in. 
11. Wijzig de lijnopmaak voor het tweede zoomframe‑object.
12. Wijzig de overgangsduur.
13. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe je de opmaak van een samenvattingszoom‑sectie‑object wijzigt:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Voegt een nieuwe dia toe aan de presentatie
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 1", slide);

    //Voegt een nieuwe dia toe aan de presentatie
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Voegt een nieuwe sectie toe aan de presentatie
    pres.Sections.AddSection("Section 2", slide);

    // Voegt een SummaryZoomFrame-object toe
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Haalt het eerste SummaryZoomSection-object op
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Opmaak voor SummaryZoomSection-object
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Slaat de presentatie op
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik het terugkeren naar de ’ouder‑dia’ regelen nadat de doelinhoud is weergegeven?**

Ja. Het [Zoom frame](https://reference.aspose.com/slides/nl/net/aspose.slides/zoomframe/) of de [section](https://reference.aspose.com/slides/nl/net/aspose.slides/sectionzoomframe/) heeft een `ReturnToParent`‑gedrag dat, wanneer ingeschakeld, de kijker terugstuurt naar de oorspronkelijke dia na het bezoeken van de doelinhoud.

**Kan ik de ’snelheid’ of duur van de Zoom‑overgang aanpassen?**

Ja. Zoom ondersteunt het instellen van een `TransitionDuration` zodat je kunt bepalen hoe lang de spring‑animatie duurt.

**Zijn er limieten aan het aantal Zoom‑objecten dat een presentatie kan bevatten?**

Er is geen harde API‑limiet gedocumenteerd. Praktische limieten hangen af van de algehele complexiteit van de presentatie en de prestaties van de viewer. Je kunt veel Zoom‑frames toevoegen, maar houd rekening met bestandsgrootte en rendertijd.