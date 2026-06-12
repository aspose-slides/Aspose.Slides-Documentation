---
title: Optimaliseer afbeeldingbeheer in presentaties in .NET
linktitle: Beheer afbeeldingen
type: docs
weight: 10
url: /nl/net/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van internet
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Optimaliseer het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor .NET, verbeter de prestaties en automatiseer je workflow."
---
## **Introductie**

Afbeeldingen maken presentaties boeiender en interessanter. In Microsoft PowerPoint kun je afbeeldingen invoegen vanaf een bestand, het internet of andere locaties op dia's. Op dezelfde manier maakt Aspose.Slides het mogelijk om afbeeldingen aan dia's in je presentaties toe te voegen via verschillende methoden.

{{% alert  title="Tip" color="primary" %}} 
Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen snel presentaties te maken vanuit afbeeldingen. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Wil je een afbeelding als frame‑object toevoegen—vooral als je van plan bent standaard opmaakopties te gebruiken om de grootte te wijzigen, effecten toe te voegen, enzovoort—bekijk dan [Afbeeldingsframe](https://docs.aspose.com/slides/nl/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Opmerking" color="warning" %}}
Je kunt in- en uitvoerbewerkingen met afbeeldingen en PowerPoint‑presentaties manipuleren om een afbeelding van het ene formaat naar het andere te converteren. Zie deze pagina’s: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/net/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/net/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/net/conversion/jpg-to-png/), converteer [PNG naar JPG](https://products.aspose.com/slides/nl/net/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/net/conversion/png-to-svg/), converteer [SVG naar PNG](https://products.aspose.com/slides/nl/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides ondersteunt bewerkingen met afbeeldingen in deze populaire formaten: JPEG, PNG, BMP, GIF en andere. 

## **Afbeeldingen lokaal aan dia's toevoegen**

Je kunt één of meerdere afbeeldingen op je computer aan een dia in een presentatie toevoegen. Deze voorbeeldcode in C# laat zien hoe je een afbeelding aan een dia toevoegt:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Afbeeldingen van het web aan dia's toevoegen**

Als de afbeelding die je aan een dia wilt toevoegen niet beschikbaar is op je computer, kun je de afbeelding rechtstreeks van het internet toevoegen. 

Deze voorbeeldcode laat zien hoe je een afbeelding van het internet aan een dia toevoegt in C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Afbeeldingen aan dia‑masters toevoegen**

Een dia‑master is de bovenste dia die informatie (thema, lay‑out, enz.) over alle onderliggende dia's opslaat en beheert. Dus wanneer je een afbeelding aan een dia‑master toevoegt, verschijnt die afbeelding op elke dia onder die dia‑master. 

Deze C#‑voorbeeldcode laat zien hoe je een afbeelding aan een dia‑master toevoegt:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Afbeeldingen als dia‑achtergronden toevoegen**

Je kunt besluiten een afbeelding als achtergrond te gebruiken voor een specifieke dia of meerdere dia's. In dat geval moet je *[Afbeeldingen als achtergronden voor dia's instellen](https://docs.aspose.com/slides/nl/net/presentation-background/#setting-images-as-background-for-slides)* bekijken.

## **SVG aan presentaties toevoegen**
Je kunt elke afbeelding aan een presentatie toevoegen of invoegen door de [AddPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/methods/addpictureframe)‑methode te gebruiken die behoort tot de [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection) interface.

Om een afbeeldingsobject te maken op basis van een SVG‑afbeelding, kun je dit op de volgende manier doen:

1. Maak een SvgImage‑object om het in ImageShapeCollection in te voegen
2. Maak een PPImage‑object van ISvgImage
3. Maak een PictureFrame‑object met behulp van de IPPImage‑interface

Deze voorbeeldcode laat zien hoe je de bovenstaande stappen implementeert om een SVG‑afbeelding aan een presentatie toe te voegen:
```csharp
// Het pad naar de documentenmap
string dataDir = @"D:\Documents\";

// Naam van bron‑SVG‑bestand
string svgFileName = dataDir + "sample.svg";

// Bestandsnaam van uitvoerpresentatie
string outPptxPath = dataDir + "presentation.pptx";

// Nieuwe presentatie maken
using (var p = new Presentation())
{
    // SVG‑bestandsinhoud lezen
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage‑object maken
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImage‑object maken
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Maakt een nieuw PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Presentatie opslaan in PPTX‑formaat
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **SVG naar een verzameling vormen converteren**
De conversie van SVG naar een verzameling vormen in Aspose.Slides is vergelijkbaar met de PowerPoint‑functionaliteit die wordt gebruikt om met SVG‑afbeeldingen te werken:

![PowerPoint pop‑upmenu](img_01_01.png)

De functionaliteit wordt geleverd door een van de overloads van de [AddGroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/addgroupshape/methods/1) methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection) interface die een [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage)‑object als eerste argument accepteert.

Deze voorbeeldcode laat zien hoe je de beschreven methode gebruikt om een SVG‑bestand naar een verzameling vormen te converteren:

```csharp
// Het pad naar de documentenmap
string dataDir = @"D:\Documents\";

// Naam van bron‑SVG‑bestand
string svgFileName = dataDir + "sample.svg";

// Bestandsnaam van uitvoerpresentatie
string outPptxPath = dataDir + "presentation.pptx";

// Nieuwe presentatie maken
using (IPresentation presentation = new Presentation())
{
    // SVG‑bestandsinhoud lezen
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage‑object maken
    ISvgImage svgImage = new SvgImage(svgContent);

    // Dia‑grootte ophalen
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG‑afbeelding omzetten naar groep vormen en schalen naar dia‑grootte
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Presentatie opslaan in PPTX‑formaat
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Afbeeldingen als EMF aan dia's toevoegen**
Aspose.Slides for .NET stelt je in staat om EMF‑afbeeldingen te genereren uit Excel‑bladen en de afbeeldingen als EMF op dia's toe te voegen met Aspose.Cells. 

Deze voorbeeldcode laat zien hoe je de beschreven taak uitvoert:

```csharp
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    // Sla de werkmap op naar stream
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Afbeeldingen in de afbeeldingscollectie vervangen**

Aspose.Slides laat je afbeeldingen die zijn opgeslagen in de afbeeldingscollectie van een presentatie (inclusief die gebruikt door dia‑vormen) vervangen. Deze sectie toont verschillende benaderingen om afbeeldingen in de collectie bij te werken. De API biedt eenvoudige methoden om een afbeelding te vervangen met behulp van ruwe byte‑gegevens, een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/)‑instantie, of een andere afbeelding die al in de collectie bestaat.

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
3. Vervang de doelafbeelding door de nieuwe afbeelding met behulp van de byte‑array.
4. In de tweede benadering laad je de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) object en vervang je de doelafbeelding door dat object.
5. In de derde benadering vervang je de doelafbeelding door een afbeelding die al bestaat in de afbeeldingscollectie van de presentatie.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```cs
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
using Presentation presentation = new Presentation("sample.pptx");

// De eerste manier.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// De tweede manier.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// De derde manier.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Sla de presentatie op naar een bestand.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
Met de gratis Aspose [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter kun je eenvoudig teksten animeren, GIF's van teksten maken, enzovoort. 
{{% /alert %}}

## **Veelgestelde vragen**

**Blijft de originele afbeeldingsresolutie behouden na invoeging?**

Ja. De bronpixels worden behouden, maar het uiteindelijke uiterlijk hangt af van hoe de [afbeelding](/slides/nl/net/picture-frame/) op de dia wordt geschaald en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo tegelijk op tientallen dia's te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingscollectie van de presentatie—updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden geconverteerd naar bewerkbare vormen?**

Ja. Je kunt een SVG omzetten naar een groep vormen; daarna worden de individuele onderdelen bewerkbaar met standaard vorm‑eigenschappen.

**Hoe kan ik een afbeelding als achtergrond voor meerdere dia's tegelijk instellen?**

[Ken de afbeelding toe als achtergrond](/slides/nl/net/presentation-background/) op de master‑dia of de betreffende lay‑out—alle dia's die die master/lay‑out gebruiken, nemen de achtergrond over.

**Hoe voorkom ik dat de presentatie in omvang “opschiet” door veel afbeeldingen?**

Hergebruik één afbeeldingsbron in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en houd herhaalde grafieken op de master waar passend.