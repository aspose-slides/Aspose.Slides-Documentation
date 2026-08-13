---
title: Beheer afbeeldingframes in presentaties in .NET
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/net/picture-frame/
keywords:
- afbeeldingframe
- afbeeldingframe toevoegen
- afbeeldingframe maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff‑eigenschap
- opmaak van afbeeldingframe
- eigenschappen van afbeeldingframe
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Afbeeldingsframes toevoegen aan PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor .NET. Versnel uw workflow en verbeter het ontwerp van dia's."
---
## **Inleiding**

Een afbeeldingframe is een vorm die een afbeelding bevat - het is als een foto in een lijst. 

U kunt een afbeelding aan een dia toevoegen via een afbeeldingframe. Op deze manier kunt u de afbeelding formatteren door het afbeeldingframe te formatteren.

{{% alert  title="Tip" color="info" %}} 
Aspose biedt gratis converters - [JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt) - die gebruikers in staat stellen snel presentaties te maken van afbeeldingen. 
{{% /alert %}} 

## **Maak een afbeeldingframe**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse. 
2. Haalt een referentie naar een dia op via de index. 
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage) object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) die gekoppeld is aan het presentatie‑object en die zal worden gebruikt om de vorm te vullen. 
4. Geef de breedte en hoogte van de afbeelding op. 
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe) op basis van de breedte en hoogte van de afbeelding via de `AddPictureFrame`‑methode die beschikbaar is op het vorm‑object dat aan de genoemde dia is gekoppeld. 
6. Voeg een afbeeldingframe (dat de afbeelding bevat) toe aan de dia. 
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand. 

Deze C#‑code laat zien hoe u een afbeeldingframe maakt:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{
    // Haalt de eerste dia op
    ISlide slide = pres.Slides[0];

    // Laadt een afbeelding en voegt deze toe aan de afbeeldingcollectie van de presentatie
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Voegt een afbeeldingframe toe met dezelfde hoogte en breedte
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Past enige opmaak toe op het afbeeldingframe
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Schrijft de presentatie naar een PPTX-bestand
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
Afbeeldingsframes stellen u in staat snel presentatiedia's te maken op basis van afbeeldingen. Wanneer u een afbeeldingframe combineert met de opslag‑opties van Aspose.Slides, kunt u in‑ en uitvoerbewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren. U wilt misschien deze pagina's bekijken: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/net/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/net/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/net/conversion/jpg-to-png/), converteer [PNG naar JPG](https://products.aspose.com/slides/nl/net/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/net/conversion/png-to-svg/), converteer [SVG naar PNG](https://products.aspose.com/slides/nl/net/conversion/svg-to-png/). 
{{% /alert %}}

## **Maak een afbeeldingframe met relatieve schaal**

Door de relatieve schaal van een afbeelding aan te passen, kunt u een gecompliceerder afbeeldingframe maken. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse. 
2. Haalt een referentie naar een dia op via de index. 
3. Voeg een afbeelding toe aan de afbeeldingcollectie van de presentatie. 
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage) object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) die gekoppeld is aan het presentatie‑object en die zal worden gebruikt om de vorm te vullen. 
5. Geef de relatieve breedte en hoogte van de afbeelding op in het afbeeldingframe. 
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand. 

Deze C#‑code laat zien hoe u een afbeeldingframe maakt met relatieve schaal:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation presentation = new Presentation())
{
    // Laadt een afbeelding en voegt deze toe aan de afbeeldingcollectie van de presentatie
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Voegt een afbeeldingframe toe aan de dia
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Stelt de relatieve schaalbreedte en -hoogte in
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Slaat de presentatie op
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Rasterafbeeldingen extraheren uit afbeeldingframes**

U kunt rasterafbeeldingen extraheren uit [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe) objecten en ze opslaan in PNG, JPG en andere formaten. Het code‑voorbeeld hieronder toont hoe u een afbeelding uit het document "sample.pptx" extraheert en opslaat in PNG‑formaat.

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

## **SVG‑afbeeldingen extraheren uit afbeeldingframes**

Wanneer een presentatie SVG‑grafieken bevat die binnen [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) vormen zijn geplaatst, stelt Aspose.Slides voor .NET u in staat de originele vector‑afbeeldingen met volledige getrouwheid op te halen. Door de vormcollectie van de dia te doorlopen, kunt u elk [PictureFrame] identificeren, controleren of de onderliggende [IPPImage] SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.

Het volgende code‑voorbeeld toont hoe u een SVG‑afbeelding uit een afbeeldingframe haalt:

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

## **Transparantie van een afbeelding verkrijgen**

Aspose.Slides stelt u in staat het transparantie‑effect op een afbeelding op te halen. Deze C#‑code demonstreert de bewerking:

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

## **Helderheid en contrast van een afbeelding verkrijgen**

Aspose.Slides stelt u in staat de helderheids‑ en contrast‑effecten op een afbeelding op te halen. De [ILuminance](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iluminance/) interface vertegenwoordigt dit afbeeldingstransformatie‑effect.

Deze C#‑code toont hoe u de helderheids‑ en contrastinstellingen van een afbeeldingframe kunt ophalen:

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
Alle effecten die op afbeeldingen worden toegepast, zijn te vinden in [Aspose.Slides.Effects](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/). 
{{% /alert %}}

## **Opmaak van afbeeldingframes**

Aspose.Slides biedt veel opmaakopties die op een afbeeldingframe kunnen worden toegepast. Met behulp van deze opties kunt u een afbeeldingframe aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/)klasse. 
2. Haalt een referentie naar een dia op via de index. 
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage) object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) die gekoppeld is aan het presentatie‑object en die zal worden gebruikt om de vorm te vullen. 
4. Geef de breedte en hoogte van de afbeelding op. 
5. Maak een `PictureFrame` op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](http://www.aspose.com/api/net/slides/nl/aspose.slides/ishapecollection/methods/addpictureframe)‑methode die beschikbaar is op het [IShapes](http://www.aspose.com/api/net/slides/nl/aspose.slides/ishapecollection) object dat gekoppeld is aan de genoemde dia. 
6. Voeg het afbeeldingframe (dat de afbeelding bevat) toe aan de dia. 
7. Stel de lijnkleur van het afbeeldingframe in. 
8. Stel de lijndikte van het afbeeldingframe in. 
9. Roteer het afbeeldingframe door een positieve of negatieve waarde op te geven. 
   * Een positieve waarde roteert de afbeelding met de klok mee. 
   * Een negatieve waarde roteert de afbeelding tegen de klok in. 
10. Voeg het afbeeldingframe (dat de afbeelding bevat) toe aan de dia. 
11. Schrijf de aangepaste presentatie weg als een PPTX‑bestand. 

Deze C#‑code toont het opmaakproces van een afbeeldingframe:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation presentation = new Presentation())
{
    // Haalt de eerste dia op
    ISlide slide = presentation.Slides[0];

    // Laadt een afbeelding en voegt deze toe aan de afbeeldingcollectie van de presentatie
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Voegt een afbeeldingframe toe met de overeenkomstige hoogte en breedte van de afbeelding
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Past enige opmaak toe op het afbeeldingframe
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Schrijft de presentatie naar een PPTX-bestand
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Aspose heeft recentelijk een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit [JPG/JPEG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen wilt samenvoegen, of [roosters uit foto’s](https://products.aspose.app/slides/nl/collage/photo-grid) wilt maken, kunt u deze service gebruiken. 
{{% /alert %}}

## **Een afbeelding toevoegen als koppeling**

Om grote presentaties te voorkomen, kunt u afbeeldingen (of video's) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie in te sluiten. Deze C#‑code laat zien hoe u een afbeelding en video toevoegt aan een placeholder:

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

## **Afbeeldingen bijsnijden**

Deze C#‑code laat zien hoe u een bestaande afbeelding op een dia kunt bijsnijden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Creëert een nieuw afbeeldingobject
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Voegt een PictureFrame toe aan een dia
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Bijsnijdt de afbeelding (percentagewaarden)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Slaat het resultaat op
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Bijsneden delen van een afbeelding verwijderen**

Als u de bijgesneden delen van een afbeelding in een frame wilt verwijderen, kunt u de [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) methode gebruiken. Deze methode retourneert de bijgesneden afbeelding of de oorspronkelijke afbeelding als bijsnijden niet nodig is.

Deze C#‑code demonstreert de bewerking:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haalt het PictureFrame op van de eerste dia
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Verwijdert bijgesneden delen van de PictureFrame-afbeelding en retourneert de bijgesneden afbeelding
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Slaat het resultaat op
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
De [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) methode voegt de bijgesneden afbeelding toe aan de afbeeldingcollectie van de presentatie. Als de afbeelding alleen wordt gebruikt in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/), kan deze instelling de grootte van de presentatie verkleinen. Anders zal het aantal afbeeldingen in de resulterende presentatie toenemen. 

Deze methode converteert WMF/EMF‑metabestanden naar raster‑PNG‑afbeeldingen tijdens de bijsnijdbewerking. 
{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met de [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/compressimage/) methode. Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de gespecificeerde resolutie, met de optie om bijgesneden delen te verwijderen. 

Hij past de grootte en resolutie van de afbeelding aan, vergelijkbaar met de PowerPoint‑functie **Picture Format → Compress Pictures → Resolution**. 

De volgende C#‑voorbeelden tonen hoe u een afbeelding in een presentatie kunt comprimeren door een doelresolutie op te geven en eventueel bijgesneden delen te verwijderen:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Comprimeer de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijder bijgesneden delen.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Controleer het resultaat van de compressie.
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

Of rechtstreeks een aangepaste DPI‑waarde gebruiken:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Comprimeer de afbeelding tot 150 DPI (webresolutie), waarbij bijgesneden delen worden verwijderd.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
De methode converteert de afbeelding naar een lagere resolutie op basis van de vormgrootte en opgegeven DPI. Bijgesneden gebieden kunnen ook worden verwijderd om de bestandsgrootte te optimaliseren. Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook wordt de JPEG‑kwaliteit behouden of licht verminderd op basis van de resolutie, vergelijkbaar met hoe PowerPoint omgaat met hoge‑resolutie JPEG‑bestanden. 
{{% /alert %}}

## **Beeldverhouding vergrendelen**

Als u wilt dat een vorm met een afbeelding zijn beeldverhouding behoudt, zelfs nadat u de afmetingen van de afbeelding wijzigt, kunt u de [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframelock/aspectratiolocked/) eigenschap gebruiken om de *Lock Aspect Ratio*‑instelling in te schakelen. 

Deze C#‑code laat zien hoe u de beeldverhouding van een vorm kunt vergrendelen:

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

    // Stelt de vorm in om de beeldverhouding te behouden bij het schalen
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 
Deze *Lock Aspect Ratio*‑instelling behoudt alleen de beeldverhouding van de vorm en niet van de afbeelding die erin zit. 
{{% /alert %}}

## **De StretchOff‑eigenschap gebruiken**

Met de [StretchOffsetLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsetright) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) eigenschappen van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat) interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat) klasse kunt u een vulrechthoek specificeren. 

Wanneer rekken voor een afbeelding wordt opgegeven, wordt een bronrechthoek geschaald om in de opgegeven vulrechthoek te passen. Elke rand van de vulrechthoek wordt gedefinieerd door een procentuele offset vanaf de overeenkomstige rand van de omgrenzende doos van de vorm. Een positief percentage geeft een inspringing aan, een negatief percentage een uitsprong. 

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/)klasse. 
2. Haalt een referentie naar een dia op via de index. 
3. Voeg een rechthoek `AutoShape` toe. 
4. Maak een afbeelding. 
5. Stel het vultype van de vorm in. 
6. Stel de picture‑fill‑modus van de vorm in. 
7. Voeg een afbeelding toe om de vorm te vullen. 
8. Geef afbeeldingsoffsets op vanaf de overeenkomstige rand van de omgrenzende doos van de vorm 
9. Schrijf de aangepaste presentatie weg als een PPTX‑bestand. 

Deze C#‑code demonstreert een proces waarin de StretchOff‑eigenschap wordt gebruikt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Stelt de afbeelding in zodat deze vanaf elke kant wordt uitgerekt in het vormlichaam
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Hoe kan ik achterhalen welke afbeeldingsformaten worden ondersteund voor PictureFrame?

Aspose.Slides ondersteunt zowel rasterafbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vectorafbeeldingen (bijvoorbeeld SVG) via het afbeelding‑object dat aan een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) is toegewezen. De lijst met ondersteunde formaten overlapt over het algemeen met de mogelijkheden van de dia‑ en afbeelding‑conversie‑engine.

### Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX?

Het insluiten van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; afbeeldingen linken houdt de presentatie‑grootte klein, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een koppeling toe te voegen om de bestandsgrootte te verkleinen.

### Hoe kan ik een afbeelding vergrendelen tegen per ongeluk verplaatsen/vergroten?

Gebruik [vormvergrendelingen](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/pictureframelock/) voor een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of vergroten uit te schakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart [beschermings‑artikel](/slides/nl/net/applying-protection-to-presentation/) en wordt ondersteund voor verschillende vormtypen, waaronder [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/).

### Wordt de vector‑fidelity van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) te extraheren als de oorspronkelijke vector. Bij het [exporteren naar PDF](/slides/nl/net/convert-powerpoint-to-pdf/) of [rasterformaten](/slides/nl/net/convert-powerpoint-to-png/) kan het resultaat gerasterd worden, afhankelijk van de exportinstellingen; het feit dat de oorspronkelijke SVG als vector is opgeslagen, wordt bevestigd door het extractie‑gedrag.