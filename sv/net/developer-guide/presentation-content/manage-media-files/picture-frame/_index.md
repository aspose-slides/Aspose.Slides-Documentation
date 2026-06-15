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
- beskära bild
- beskuret område
- StretchOff-egenskap
- bildramformatering
- bildramegenskaper
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
description: "Lägg till bildramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Effektivisera ditt arbetsflöde och förbättra bilddesignen."
---
## **Introduktion**

En bildram är en form som innehåller en bild – den är som en bild i en ram. 

Du kan lägga till en bild på en bildspel genom en bildram. På så sätt kan du formatera bilden genom att formatera bildramen.

{{% alert  title="Tips" color="primary" %}} 
Aspose erbjuder gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter användare skapa presentationer snabbt från bilder. 
{{% /alert %}} 

## **Skapa en bildram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta en bilds referens genom dess index. 
3. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
4. Specificera bildens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe) baserat på bildens bredd och höjd via metoden `AddPictureFrame` som exponeras av formobjektet som är kopplat till den refererade bilden.
6. Lägg till en bildram (som innehåller bilden) på bilden.
7. Skriv den modifierade presentationen som en PPTX‑fil.

Den här C#‑koden visar hur du skapar en bildram:

```c#
// Skapar en instans av Presentation-klassen som representerar en PPTX-fil
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

    // Tillämpar viss formatering på bildramen
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Skriver presentationen till en PPTX-fil
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
Bildramar låter dig snabbt skapa presentationsbilder baserade på bilder. När du kombinerar bildram med sparalternativen i Aspose.Slides kan du manipulera in‑ och utdataoperationer för att konvertera bilder från ett format till ett annat. Du kanske vill se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/net/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/net/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/net/conversion/jpg-to-png/), konvertera [PNG till JPG](https://products.aspose.com/slides/sv/net/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/net/conversion/png-to-svg/), konvertera [SVG till PNG](https://products.aspose.com/slides/sv/net/conversion/svg-to-png/).
{{% /alert %}}

## **Skapa en bildram med relativ skala**

Genom att ändra en bilds relativa skalning kan du skapa en mer komplex bildram. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta en bilds referens genom dess index. 
3. Lägg till en bild i presentationens bildsamling.
4. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
5. Specificera bildens relativa bredd och höjd i bildramen.
6. Skriv den modifierade presentationen som en PPTX‑fil.

Den här C#‑koden visar hur du skapar en bildram med relativ skala:

```c#
// Instansierar Presentation-klassen som representerar en PPTX-fil
using (Presentation presentation = new Presentation())
{
    // Laddar en bild och lägger till den i presentationens bildsamling
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Lägger till en bildram på bilden
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Ställer in relativ skala för bredd och höjd
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Sparar presentationen
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extrahera rasterbilder från bildramar**

Du kan extrahera rasterbilder från [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe)-objekt och spara dem i PNG, JPG och andra format. Kodexemplet nedan visar hur du extraherar en bild från dokumentet “sample.pptx” och sparar den i PNG‑format.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Extrahera SVG‑bilder från bildramar**

När en presentation innehåller SVG‑grafik placerad i [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/)-former, låter Aspose.Slides för .NET dig hämta de ursprungliga vektorbilderna med fullständig trohet. Genom att gå igenom bildens formsamling kan du identifiera varje [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/), kontrollera om den underliggande [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)-objektet innehåller SVG‑innehåll, och sedan spara den bilden till disk eller en ström i dess ursprungliga SVG‑format.

Följande kodexempel visar hur du extraherar en SVG‑bild från en bildram:

```cs
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

Aspose.Slides gör det möjligt att hämta transparenseffekten som applicerats på en bild. Den här C#‑koden demonstrerar operationen:

```c#
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

{{% alert color="primary" %}} 
Alla effekter som applicerats på bilder finns i [Aspose.Slides.Effects](https://reference.aspose.com/slides/sv/net/aspose.slides.effects/).
{{% /alert %}}

## **Formatering av bildram**

Aspose.Slides erbjuder många formateringsalternativ som kan appliceras på en bildram. Med dessa alternativ kan du ändra en bildram så att den uppfyller specifika krav.

1. Skapa en instans av klassen [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/).
2. Hämta en bilds referens genom dess index. 
3. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage)-objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/net/aspose.slides/iimagecollection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
4. Specificera bildens bredd och höjd.
5. Skapa ett `PictureFrame` baserat på bildens bredd och höjd via metoden [AddPictureFrame](http://www.aspose.com/api/net/slides/sv/aspose.slides/ishapecollection/methods/addpictureframe) som exponeras av objektet [IShapes](http://www.aspose.com/api/net/slides/sv/aspose.slides/ishapecollection) som är kopplat till den refererade bilden.
6. Lägg till bildramen (som innehåller bilden) på bilden.
7. Ställ in bildramens linjefärg.
8. Ställ in bildramens linjebredd.
9. Rotera bildramen genom att ge den ett positivt eller negativt värde.
   * Ett positivt värde roterar bilden medurs. 
   * Ett negativt värde roterar bilden moturs.
10. Lägg till bildramen (som innehåller bilden) på bilden.
11. Skriv den modifierade presentationen som en PPTX‑fil.

Den här C#‑koden demonstrerar formateringsprocessen för bildramen:

```c#
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

    // Tillämpar viss formatering på bildramen
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Skriver presentationen till en PPTX-fil
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Aspose har nyligen utvecklat en [gratis Collage Maker](https://products.aspose.app/slides/sv/collage). Om du någonsin behöver [sammanfoga JPG/JPEG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑bilder, [skapa rutnät från foton](https://products.aspose.app/slides/sv/collage/photo-grid), kan du använda den här tjänsten. 
{{% /alert %}}

## **Lägg till en bild som en länk**

För att undvika stora presentationsstorlekar kan du lägga till bilder (eller videor) via länkar i stället för att bädda in filerna direkt i presentationerna. Den här C#‑koden visar hur du lägger till en bild och video i en platshållare:

```c#
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

Den här C#‑koden visar hur du beskär en befintlig bild på en bild:

```c#
using (Presentation presentation = new Presentation())
{
    // Skapar ett nytt bildobjekt
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Lägger till en PictureFrame på en bild
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

## **Ta bort beskurna områden i en bild**

Om du vill ta bort de beskurna områdena av en bild som finns i en ram, kan du använda metoden [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Denna metod returnerar den beskurna bilden eller originalbilden om beskärning är onödig.

Den här C#‑koden demonstrerar operationen:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Hämtar bildramen från den första bilden
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Tar bort beskurna områden av bildramens bild och returnerar den beskurna bilden
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Sparar resultatet
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="OBS" color="warning" %}} 
Metoden [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) lägger till den beskurna bilden i presentationens bildsamling. Om bilden endast används i den bearbetade [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/), kan denna konfiguration minska presentationsstorleken. Annars ökar antalet bilder i den resulterande presentationen.

Denna metod konverterar WMF/EMF‑metafiler till raster‑PNG‑bilder i beskärningsoperationen. 
{{% /alert %}}

## **Komprimera bilder**

Du kan komprimera en bild i en presentation med hjälp av metoden [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/compressimage/). Denna metod komprimerar en bild genom att minska dess storlek baserat på formens storlek och angiven upplösning, med möjlighet att ta bort beskurna områden. 

Den justerar bildens storlek och upplösning på ett sätt som liknar PowerPoints **Bildformat → Komprimera bilder → Upplösning**‑funktion.

Följande C#‑exempel visar hur du komprimerar en bild i en presentation genom att ange en målupplösning och eventuellt ta bort beskurna områden:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimera bilden med en målupplösning på 150 DPI (webbupplösning) och ta bort beskurna områden.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Kontrollera resultatet av kompressionen.
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

Eller genom att använda ett eget DPI‑värde direkt:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Komprimera bilden till 150 DPI (webbupplösning), ta bort beskurna områden.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="OBS" color="warning" %}} 
Metoden konverterar bilden till en lägre upplösning baserat på formens storlek och angivet DPI. Beskurna regioner kan också tas bort för att optimera filstorleken.  
Om bilden är en metafil (WMF/EMF) eller SVG, kommer komprimering inte att tillämpas. JPEG‑kvaliteten bevaras eller minskas något beroende på upplösning, på samma sätt som PowerPoint hanterar högupplösta JPEG‑bilder. 
{{% /alert %}}

## **Lås bildförhållande**

Om du vill att en form som innehåller en bild ska behålla sitt bildförhållande även efter att du ändrat bildens dimensioner, kan du använda egenskapen [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframelock/aspectratiolocked/) för att sätta inställningen *Lock Aspect Ratio*. 

Den här C#‑koden visar hur du låser ett objekts bildförhållande:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Ställer in formen så att bildförhållandet bevaras vid storleksändring
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="OBS" color="warning" %}} 
Denna *Lock Aspect Ratio*‑inställning bevarar endast formens bildförhållande och inte bilden den innehåller. 
{{% /alert %}}

## **Använd egenskapen StretchOff**

Genom att använda egenskaperna [StretchOffsetLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/properties/stretchoffsetright) och [StretchOffsetBottom](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) från gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat) kan du ange en fyllningsrektangel. 

När en bild sträcks anges en källrektangel som skalas för att passa den specificerade fyllningsrektangeln. Varje kant på fyllningsrektangeln definieras av en procentuell förskjutning från motsvarande kant på formens omgivningsruta. En positiv procentsats innebär ett inskjut, medan en negativ procentsats innebär ett utskjut.

1. Skapa en instans av klassen [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/).
2. Hämta en bilds referens genom dess index.
3. Lägg till en rektangel `AutoShape`. 
4. Skapa en bild.
5. Ställ in formens fyllningstyp.
6. Ställ in formens bildfyllningsläge.
7. Lägg till en bild för att fylla formen.
8. Specificera bildens förskjutningar från motsvarande kant på formens omgivningsruta
9. Skriv den modifierade presentationen som en PPTX‑fil.

Den här C#‑koden demonstrerar en process där en StretchOff‑egenskap används:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Ställer in att bilden sträcks från varje sida i formens kropp
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Hur kan jag ta reda på vilka bildformat som stöds för PictureFrame?**

Aspose.Slides stöder både rasterbilder (PNG, JPEG, BMP, GIF, etc.) och vektorbilder (t.ex. SVG) via bildobjektet som tilldelas en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/). Listan över stödda format sammanfaller generellt med kapaciteterna i bild‑ och konverteringsmotorn för bildspel.

**Hur påverkar tillägg av dussintals stora bilder PPTX‑storlek och prestanda?**

Inbäddning av stora bilder ökar filstorlek och minnesanvändning; länka bilder hjälper hålla presentationsstorleken nere men kräver att de externa filerna förblir tillgängliga. Aspose.Slides erbjuder möjligheten att lägga till bilder via länk för att minska filstorleken.

**Hur kan jag låsa ett bildobjekt så att det inte oavsiktligt flyttas eller skalas?**

Använd [formlås](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/pictureframelock/) för en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/) (t.ex. inaktivera flyttning eller skalning). Låsmekanismen beskrivs för former i en separat [skyddsartikel](/slides/sv/net/applying-protection-to-presentation/) och stöds för olika formtyper, inklusive [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/).

**Behålls SVG‑vektorns precision vid export av en presentation till PDF/bilder?**

Aspose.Slides gör det möjligt att extrahera en SVG från en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/pictureframe/) som den ursprungliga vektorn. Vid [export till PDF](/slides/sv/net/convert-powerpoint-to-pdf/) eller [rasterformat](/slides/sv/net/convert-powerpoint-to-png/) kan resultatet rasteriseras beroende på exportinställningarna; faktumet att den ursprungliga SVG‑filen bevaras som en vektor bekräftas av extraktionsbeteendet.