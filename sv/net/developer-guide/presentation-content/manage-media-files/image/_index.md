---
title: Optimera bildhantering i presentationer i .NET
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/net/image/
keywords:
- lägg till bild
- lägg till foto
- lägg till bitmap
- ersätt bild
- ersätt foto
- från webben
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- lägg till EMF
- lägg till WMF
- lägg till TIFF
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Effektivisera bildhantering i PowerPoint och OpenDocument med Aspose.Slides för .NET, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och intressanta. I Microsoft PowerPoint kan du infoga bilder från en fil, internet eller andra platser på bilder. På samma sätt låter Aspose.Slides dig lägga till bilder på bilder i dina presentationer genom olika metoder.

{{% alert  title="Tip" color="primary" %}} 

Aspose erbjuder kostnadsfria konverterare—[JPEG to PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG to PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som gör att man snabbt kan skapa presentationer från bilder. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Om du vill lägga till en bild som ett bildramobjekt—särskilt om du planerar att använda standardformateringsalternativ på den för att ändra storlek, lägga till effekter osv.—se [Picture Frame](https://docs.aspose.com/slides/sv/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Du kan manipulera in/ut‑operationer som involverar bilder och PowerPoint‑presentationer för att konvertera en bild från ett format till ett annat. Se dessa sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/net/conversion/image-to-jpg/); konvertera [JPG to image](https://products.aspose.com/slides/sv/net/conversion/jpg-to-image/); konvertera [JPG to PNG](https://products.aspose.com/slides/sv/net/conversion/jpg-to-png/), konvertera [PNG to JPG](https://products.aspose.com/slides/sv/net/conversion/png-to-jpg/); konvertera [PNG to SVG](https://products.aspose.com/slides/sv/net/conversion/png-to-svg/), konvertera [SVG to PNG](https://products.aspose.com/slides/sv/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides stöder operationer med bilder i dessa populära format: JPEG, PNG, BMP, GIF och andra. 

## **Lägg till bilder lagrade lokalt på bilder**

Du kan lägga till en eller flera bilder från din dator på en bild i en presentation. Detta exempel i C# visar hur du lägger till en bild på en bild:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Lägg till bilder från webben på bilder**

Om bilden du vill lägga till på en bild inte finns på din dator kan du lägga till bilden direkt från webben. 

Detta exempel visar hur du lägger till en bild från webben på en bild i C#:

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

## **Lägg till bilder på bildmaster**

En bildmaster är den översta bilden som lagrar och styr information (tema, layout osv.) om alla bilder under den. Så när du lägger till en bild på en bildmaster visas den bilden på varje bild under den bildmastern. 

Detta C#‑exempel visar hur du lägger till en bild på en bildmaster:

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

## **Lägg till bilder som bildbakgrund**

Du kan välja att använda en bild som bakgrund för en specifik bild eller flera bilder. I så fall bör du se *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/sv/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägg till SVG i presentationer**
Du kan lägga till eller infoga vilken bild som helst i en presentation genom att använda metoden [AddPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/methods/addpictureframe) som tillhör gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection).

För att skapa ett bildobjekt baserat på en SVG‑bild kan du göra på detta sätt:

1. Skapa ett SvgImage‑objekt för att infoga det i ImageShapeCollection
2. Skapa ett PPImage‑objekt från ISvgImage
3. Skapa ett PictureFrame‑objekt med IPPImage‑gränssnittet

Detta exempel visar hur du implementerar stegen ovan för att lägga till en SVG‑bild i en presentation:
``` csharp 
// Sökvägen till dokumentkatalogen
string dataDir = @"D:\Documents\";

// Källfilnamn för SVG
string svgFileName = dataDir + "sample.svg";

// Utdatafilnamn för presentation
string outPptxPath = dataDir + "presentation.pptx";

// Skapa ny presentation
using (var p = new Presentation())
{
    // Läs SVG-filens innehåll
    string svgContent = File.ReadAllText(svgFileName);

    // Skapa SvgImage‑objekt
    ISvgImage svgImage = new SvgImage(svgContent);

    // Skapa PPImage‑objekt
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Skapar en ny PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Spara presentation i PPTX‑format
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Konvertera SVG till en uppsättning former**
Aspose.Slides konvertering av SVG till en uppsättning former liknar den funktion i PowerPoint som används för att arbeta med SVG‑bilder:

![PowerPoint Popup Menu](img_01_01.png)

Funktionen tillhandahålls av en av överlagringarna av metoden [AddGroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/addgroupshape/methods/1) i gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection) som tar ett [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage)‑objekt som första argument.

Detta exempel visar hur du använder den beskrivna metoden för att konvertera en SVG‑fil till en uppsättning former:

``` csharp 
// Sökvägen till dokumentkatalogen
string dataDir = @"D:\Documents\";

// Källfilnamn för SVG
string svgFileName = dataDir + "sample.svg";

// Utdatafilnamn för presentation
string outPptxPath = dataDir + "presentation.pptx";

// Skapa ny presentation
using (IPresentation presentation = new Presentation())
{
    // Läs SVG-filens innehåll
    string svgContent = File.ReadAllText(svgFileName);

    // Skapa SvgImage‑objekt
    ISvgImage svgImage = new SvgImage(svgContent);

    // Hämta bildstorlek
    SizeF slideSize = presentation.SlideSize.Size;

    // Konvertera SVG‑bild till grupp av former och skala till bildstorlek
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Spara presentation i PPTX‑format
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Lägg till bilder som EMF på bilder**
Aspose.Slides för .NET låter dig generera EMF‑bilder från Excel‑ark och lägga till bilderna som EMF på bilder med Aspose.Cells. 

Detta exempel visar hur du utför den beskrivna uppgiften:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Spara arbetsboken till ström
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

## **Ersätt bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling (inklusive de som används av bildformer). Detta avsnitt visar flera tillvägagångssätt för att uppdatera bilder i samlingen. API‑et erbjuder enkla metoder för att ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)‑instans eller en annan bild som redan finns i samlingen.

Följ stegen nedan:

1. Läs in presentationsfilen som innehåller bilder med hjälp av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Läs in en ny bild från en fil till en byte‑array.
3. Ersätt målbilden med den nya bilden med byte‑arrayen.
4. I det andra tillvägagångssättet, läs in bilden i ett [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)‑objekt och ersätt målbilden med det objektet.
5. I det tredje tillvägagångssättet, ersätt målbilden med en bild som redan finns i presentationens bildsamling.
6. Skriv den modifierade presentationen som en PPTX‑fil.

```cs
// Instansiera Presentation-klassen som representerar en presentationsfil.
using Presentation presentation = new Presentation("sample.pptx");

// Det första sättet.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Det andra sättet.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Det tredje sättet.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Spara presentationen till en fil.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Med den kostnadsfria Aspose [Text to GIF](https://products.aspose.app/slides/sv/text-to-gif)‑konvertern kan du enkelt animera text, skapa GIF‑ar från text osv. 

{{% /alert %}}

## **FAQ**

**Behåller den ursprungliga bildupplösningen sin integritet efter infogning?**

Ja. Ursprungspixlarna bevaras, men det slutgiltiga utseendet beror på hur [picture](/slides/sv/net/picture-frame/) skalas på bilden och eventuell kompression som tillämpas vid sparning.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder på en gång?**

Placera logotypen på master‑bilden eller en layout och ersätt den i presentationens bildsamling—uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varpå enskilda delar blir redigerbara med standardformsegenskaper.

**Hur kan jag sätta en bild som bakgrund för flera bilder på en gång?**

[Tilldela bilden som bakgrund](/slides/sv/net/presentation-background/) på master‑bilden eller den relevanta layouten—alla bilder som använder den master-/layouten kommer att ärva bakgrunden.

**Hur förhindrar jag att presentationen "sväller" i storlek på grund av många bilder?**

Återanvänd en enda bildresurs istället för dubletter, välj rimliga upplösningar, tillämpa kompression vid sparning och behåll återkommande grafik på master‑bilden där det är lämpligt.