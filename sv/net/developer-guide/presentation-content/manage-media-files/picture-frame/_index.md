---
title: Hantera bildramar i presentationer i .NET
linktitle: Bildram
type: docs
weight: 10
url: /sv/net/picture-frame/
keywords:
- bildram
- lägg till bildram
- skapa bildram
- lägg till bild
- skapa bild
- extrahera bild
- rasterbild
- vektorbild
- beskär bild
- beskuret område
- StretchOff-egenskap
- formatering av bildram
- egenskaper för bildram
- relativ skala
- bildeffekt
- bildförhållande
- bildtransparens
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lägg till bildramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Effektivisera ditt arbetsflöde och förbättra bilddesign."
---
## **Introduktion**

En bildram är en form som innehåller en bild – det är som en bild i en ram. 

Du kan lägga till en bild på en bildspelssida via en bildram. På så sätt kan du formatera bilden genom att formatera bildramen.

{{% alert  title="Tip" color="info" %}} 
Aspose tillhandahåller gratis konverterare—[JPEG to PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG to PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter användare skapa presentationer snabbt från bilder. 
{{% /alert %}} 

## **Skapa en Bildram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation). 
2. Hämta en bildslides referens via dess index. 
3. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection) som är associerad med presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe) baserat på bildens bredd och höjd via `AddPictureFrame`‑metoden som exponeras av form‑objektet som är associerat med den refererade bilden.
6. Lägg till en bildram (som innehåller bilden) på bilden.
7. Skriv den ändrade presentationen som en PPTX‑fil.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansierar Presentation-klassen som representerar en PPTX-fil
using (Presentation pres = new Presentation())
{
    // Hämtar den första bilden
    ISlide slide = pres.Slides[0];

    // Laddar en bild och lägger till den i presentationens bildsamling
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Lägger till en bildram med samma höjd och bredd
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Tillämpa viss formatering på bildramen
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Skriver presentationen till en PPTX-fil
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
Bildramar låter dig snabbt skapa presentationsbilder baserade på bilder. När du kombinerar bildram med sparalternativen i Aspose.Slides kan du manipulera in‑/ut‑operationer för att konvertera bilder från ett format till ett annat. Du kanske vill se dessa sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/net/conversion/image-to-jpg/); konvertera [JPG to image](https://products.aspose.com/slides/sv/net/conversion/jpg-to-image/); konvertera [JPG to PNG](https://products.aspose.com/slides/sv/net/conversion/jpg-to-png/), konvertera [PNG to JPG](https://products.aspose.com/slides/sv/net/conversion/png-to-jpg/); konvertera [PNG to SVG](https://products.aspose.com/slides/sv/net/conversion/png-to-svg/), konvertera [SVG to PNG](https://products.aspose.com/slides/sv/net/conversion/svg-to-png/).
{{% /alert %}}

## **Skapa en Bildram med Relativ Skala**

Genom att ändra en bilds relativa skalning kan du skapa en mer avancerad bildram. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation). 
2. Hämta en bildslides referens via dess index. 
3. Lägg till en bild i presentationens bildsamling.
4. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection) som är associerad med presentationsobjektet och som kommer att användas för att fylla formen.
5. Ange bildens relativa bredd och höjd i bildramen.
6. Skriv den ändrade presentationen som en PPTX‑fil.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansierar Presentation-klassen som representerar en PPTX-fil
using (Presentation presentation = new Presentation())
{
    // Laddar en bild och lägger till den i presentationens bildsamling
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Lägger till en bildram på bilden
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Ställer in relativ skala för höjd och bredd
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Sparar presentationen
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extrahera rasterbilder från Bildramar**

Du kan extrahera rasterbilder från [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe)-objekt och spara dem i PNG, JPG och andra format. Kodexemplet nedan visar hur du extraherar en bild från dokumentet "sample.pptx" och sparar den i PNG‑format.

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Extrahera SVG‑bilder från Bildramar**

När en presentation innehåller SVG‑grafik placerad inuti [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/)-former, låter Aspose.Slides för .NET dig hämta de ursprungliga vektorbilderna med full korrekthet. Genom att gå igenom bildens form‑samling kan du identifiera varje [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/), kontrollera om den underliggande [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) innehåller SVG‑innehåll, och sedan spara den bilden till disk eller en ström i dess ursprungliga SVG‑format.

Följande kodexempel demonstrerar hur du extraherar en SVG‑bild från en bildram:

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Hämta transparens för en bild**

Aspose.Slides låter dig hämta den transparenseffekt som applicerats på en bild. Denna C#‑kod demonstrerar operationen:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **Hämta ljusstyrka och kontrast för en bild**

Aspose.Slides låter dig hämta ljusstyrke‑ och kontrasteffekten som applicerats på en bild. Gränssnittet [ILuminance](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/iluminance/) representerar denna bildtransform‑effekt.

Denna C#‑kod visar hur du får ljusstyrke‑ och kontrastinställningarna från en bildram:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
Alla effekter som applicerats på bilder finns i [Aspose.Slides.Effects](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/).
{{% /alert %}}

## **Formatering av Bildram**

Aspose.Slides erbjuder många formateringsalternativ som kan tillämpas på en bildram. Med dessa alternativ kan du ändra en bildram så att den uppfyller specifika krav.

1. Skapa en instans av klassen [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/) .
2. Hämta en bildslides referens via dess index. 
3. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection) som är associerad med presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en `PictureFrame` baserat på bildens bredd och höjd via [AddPictureFrame](http://www.aspose.com/api/net/slides/sv/aspose.slides/ishapecollection/methods/addpictureframe)-metoden som exponeras av [IShapes](http://www.aspose.com/api/net/slides/sv/aspose.slides/ishapecollection)-objektet som är associerat med den refererade bilden.
6. Lägg till bildramen (som innehåller bilden) på bilden.
7. Ställ in bildramens linjefärg.
8. Ställ in bildramens linjebredd.
9. Rotera bildramen genom att ge den ett positivt eller negativt värde.
   * Ett positivt värde roterar bilden medurs. 
   * Ett negativt värde roterar bilden moturs.
10. Lägg till bildramen (som innehåller bilden) på bilden.
11. Skriv den ändrade presentationen som en PPTX‑fil.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansierar Presentation-klassen som representerar en PPTX-fil
using (Presentation presentation = new Presentation())
{
    // Hämtar den första bilden
    ISlide slide = presentation.Slides[0];

    // Laddar en bild och lägger till den i presentationens bildsamling
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Lägger till en bildram med bildens motsvarande höjd och bredd
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Tillämpa viss formatering på bildramen
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Skriver presentationen till en PPTX-fil
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Aspose har nyligen utvecklat en [free Collage Maker](https://products.aspose.app/slides/sv/collage). Om du någonsin behöver [merge JPG/JPEG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑bilder, [create grids from photos](https://products.aspose.app/slides/sv/collage/photo-grid), kan du använda den här tjänsten. 
{{% /alert %}}

## **Lägg till en bild som länk**

För att undvika stora presentationsfiler kan du lägga till bilder (eller videor) via länkar i stället för att bädda in filerna direkt i presentationerna. Denna C#‑kod visar hur du lägger till en bild och video i en platshållare:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Beskär bilder**

Denna C#‑kod visar hur du beskär en befintlig bild på en bildslide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Skapar ett nytt bildobjekt
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Lägger till en Bildram på en Bild
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Beskär bilden (procentvärden)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Sparar resultatet
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Ta bort beskurna områden i en bildram**

Om du vill ta bort de beskurna områdena i en bild som finns i en ram kan du använda metoden [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Metoden returnerar den beskurna bilden eller originalbilden om beskärning inte behövs.

Denna C#‑kod demonstrerar operationen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Hämtar bildramen från den första bilden
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Tar bort beskurna områden i bildramens bild och returnerar den beskurna bilden
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Sparar resultatet
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoden [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) lägger till den beskurna bilden i presentationens bildsamling. Om bilden endast används i den bearbetade [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/), kan detta minska presentationsstorleken. Annars ökar antalet bilder i den resulterande presentationen.

Metoden konverterar WMF/EMF‑metafiler till raster‑PNG‑bild i beskärningssteget. 
{{% /alert %}}

## **Komprimera bilder**

Du kan komprimera en bild i en presentation med hjälp av metoden [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/compressimage/).
Metoden komprimerar en bild genom att minska dess storlek utifrån formens storlek och angiven upplösning, med möjlighet att ta bort beskurna områden. 

Den justerar bildens storlek och upplösning på liknande sätt som PowerPoints **Picture Format → Compress Pictures → Resolution**‑funktion.

Följande C#‑exempel visar hur du komprimerar en bild i en presentation genom att ange en målupplösning och eventuellt ta bort beskurna områden:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimera bilden med en målupplösning på 150 DPI (webbupplösning) och ta bort beskurna områden.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Kontrollera resultatet av komprimeringen.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Eller genom att ange ett eget DPI‑värde direkt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimera bilden till 150 DPI (webbupplösning) och ta bort beskurna områden.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoden konverterar bilden till en lägre upplösning baserat på formens storlek och angivet DPI. Beskurna regioner kan också raderas för att optimera filstorleken.  
Om bilden är en metafil (WMF/EMF) eller SVG kommer kompression inte att tillämpas. JPEG‑kvaliteten bevaras eller minskas något beroende på upplösning, på samma sätt som PowerPoint hanterar högupplösta JPEG‑filer.
{{% /alert %}}

## **Lås bildförhållande**

Om du vill att en form som innehåller en bild ska behålla sitt bildförhållande även efter att du ändrat bildens dimensioner kan du använda egenskapen [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframelock/aspectratiolocked/) för att ställa in *Lock Aspect Ratio*-inställningen. 

Denna C#‑kod visar hur du låser en forms bildförhållande:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Sätter formen att bevara bildförhållandet vid storleksändring
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Denna *Lock Aspect Ratio*-inställning bevarar endast formens bildförhållande och inte bilden som den innehåller.
{{% /alert %}}

## **Använd StretchOff‑egenskapen**

Genom att använda egenskaperna [StretchOffsetLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/properties/stretchoffsetright) och [StretchOffsetBottom](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) från gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat) kan du ange en fyllningsrektangel. 

När stretchning specificeras för en bild skalas en källrektangel för att passa den angivna fyllningsrektangeln. Varje kant av fyllningsrektangeln definieras av en procentuell förskjutning från motsvarande kant av formens avgränsningsruta. En positiv procentandel betyder en inskjutning medan en negativ procentandel betyder en utskjutning.

1. Skapa en instans av [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/)‑klassen. 
2. Hämta en bildslides referens via dess index. 
3. Lägg till en rektangel `AutoShape`. 
4. Skapa en bild. 
5. Ställ in formens fyllningstyp. 
6. Ställ in formens bildfyllningsläge. 
7. Lägg till en bild för att fylla formen. 
8. Specificera bildens förskjutningar från motsvarande kant av formens avgränsningsruta. 
9. Skriv den ändrade presentationen som en PPTX‑fil. 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Ställer in bilden så att den sträcks från varje sida i formens kropp
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Hur kan jag ta reda på vilka bildformat som stöds för PictureFrame?

Aspose.Slides stödjer både rasterbilder (PNG, JPEG, BMP, GIF osv.) och vektorbilder (t.ex. SVG) via bildobjektet som tilldelas en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/). Listan över stödjade format överlappar i allmänhet med funktionerna i bild‑ och konverteringsmotorn för slides.

### Hur påverkar det PPTX‑storlek och prestanda att lägga till dussintals stora bilder?

Att bädda in stora bilder ökar filstorlek och minnesanvändning; att länka bilder hjälper hålla presentationsstorleken nere men kräver att de externa filerna fortsatt är åtkomliga. Aspose.Slides ger möjlighet att lägga till bilder via länk för att minska filstorleken.

### Hur kan jag låsa ett bildobjekt så att det inte flyttas/skalas av misstag?

Använd [shape locks](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/pictureframelock/) för en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/) (t.ex. inaktivera flyttning eller skalning). Låsningsmekanismen beskrivs för former i en separat [protection article](/slides/sv/net/applying-protection-to-presentation/) och stöds för olika formtyper, inklusive [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/).

### Bevaras SVG‑vektorgenskaper när en presentation exporteras till PDF/bilder?

Aspose.Slides låter dig extrahera en SVG från en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/) som den ursprungliga vektorn. När du [exporterar till PDF](/slides/sv/net/convert-powerpoint-to-pdf/) eller [rasterformat](/slides/sv/net/convert-powerpoint-to-png/) kan resultatet rasteriseras beroende på exportinställningarna; det faktum att den ursprungliga SVG:n lagras som en vektor bekräftas av extraktionsbeteendet.