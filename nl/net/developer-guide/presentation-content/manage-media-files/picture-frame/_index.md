---
title: Beheer afbeeldingskaders in presentaties in .NET
linktitle: Afbeeldingskader
type: docs
weight: 10
url: /nl/net/picture-frame/
keywords:
- afbeeldingskader
- afbeeldingskader toevoegen
- afbeeldingskader maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff-eigenschap
- opmaak van afbeeldingskader
- eigenschappen van afbeeldingskader
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
description: "Voeg afbeeldingskaders toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET. Vereenvoudig uw workflow en verbeter het ontwerp van dia's."
---
## **Introductie**

Een afbeeldingskader is een vorm die een afbeelding bevat — het is als een foto in een lijst. 

U kunt een afbeelding aan een dia toevoegen via een afbeeldingskader. Op deze manier kunt u de afbeelding opmaken door het afbeeldingskader op te maken.

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die gebruikers in staat stellen snel presentaties te maken vanuit afbeeldingen. 

{{% /alert %}} 

## **Maak een afbeeldingskader**

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse. 
2. Haal de referentie van een dia op via de index. 
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage)‑object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) die aan het presentatie‑object is gekoppeld en die zal worden gebruikt om de vorm te vullen. 
4. Geef de breedte en hoogte van de afbeelding op. 
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe) op basis van de breedte en hoogte van de afbeelding via de `AddPictureFrame`‑methode die wordt aangeboden door het vorm‑object dat aan de verwijzende dia is gekoppeld. 
6. Voeg een afbeeldingskader (met de afbeelding) toe aan de dia. 
7. Sla de gewijzigde presentatie op als een PPTX‑bestand. 

```c#
// Instantieert de Presentation-klasse die een PPTX-bestand voorstelt
using (Presentation pres = new Presentation())
{
    // Haalt de eerste dia op
    ISlide slide = pres.Slides[0];

    // Laadt een afbeelding en voegt deze toe aan de afbeeldingscollectie van de presentatie
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Voegt een afbeeldingskader toe met dezelfde hoogte en breedte
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Past wat opmaak toe op het afbeeldingskader
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Schrijft de presentatie weg naar een PPTX-bestand
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Afbeeldingskaders stellen u in staat snel presentatiedia's te maken op basis van afbeeldingen. Wanneer u een afbeeldingskader combineert met de opslaan‑opties van Aspose.Slides, kunt u in‑ en uitvoerbewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren. Mogelijk wilt u deze pagina's bekijken: converteer [image to JPG](https://products.aspose.com/slides/nl/net/conversion/image-to-jpg/); converteer [JPG to image](https://products.aspose.com/slides/nl/net/conversion/jpg-to-image/); converteer [JPG to PNG](https://products.aspose.com/slides/nl/net/conversion/jpg-to-png/), converteer [PNG to JPG](https://products.aspose.com/slides/nl/net/conversion/png-to-jpg/); converteer [PNG to SVG](https://products.aspose.com/slides/nl/net/conversion/png-to-svg/), converteer [SVG to PNG](https://products.aspose.com/slides/nl/net/conversion/svg-to-png/). 

{{% /alert %}} 

## **Maak een afbeeldingskader met relatieve schaal**

Door de relatieve schaal van een afbeelding aan te passen, kunt u een complexer afbeeldingskader maken. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse. 
2. Haal de referentie van een dia op via de index. 
3. Voeg een afbeelding toe aan de afbeeldingscollectie van de presentatie. 
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage)‑object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) die aan het presentatie‑object is gekoppeld en die zal worden gebruikt om de vorm te vullen. 
5. Geef de relatieve breedte en hoogte van de afbeelding op in het afbeeldingskader. 
6. Sla de gewijzigde presentatie op als een PPTX‑bestand. 

```c#
// Instantieert de Presentation-klasse die een PPTX-bestand voorstelt
using (Presentation presentation = new Presentation())
{
    // Laadt een afbeelding en voegt deze toe aan de afbeeldingcollectie van de presentatie
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Voegt een afbeeldingskader toe aan de dia
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Stelt de relatieve schaalbreedte en -hoogte in
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Slaat de presentatie op
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Rasterafbeeldingen extraheren uit afbeeldingskaders**

U kunt rasterafbeeldingen extraheren uit [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe)‑objecten en deze opslaan als PNG, JPG en andere formaten. Het onderstaande code‑voorbeeld laat zien hoe u een afbeelding uit het document "sample.pptx" kunt extraheren en opslaan in PNG‑formaat.

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

## **SVG‑afbeeldingen extraheren uit afbeeldingskaders**

Wanneer een presentatie SVG‑grafieken bevat die in [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/)‑vormen geplaatst zijn, stelt Aspose.Slides voor .NET u in staat de oorspronkelijke vectorafbeeldingen met volledige nauwkeurigheid op te halen. Door de vormcollectie van de dia te doorlopen, kunt u elk [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.

Het volgende code‑voorbeeld toont hoe u een SVG‑afbeelding uit een afbeeldingskader kunt extraheren:

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

## **Transparantie van een afbeelding ophalen**

Aspose.Slides stelt u in staat het transparantie‑effect van een afbeelding op te halen. Deze C#‑code demonstreert de bewerking:

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

## **Helderheid en contrast van een afbeelding ophalen**

Aspose.Slides stelt u in staat de helderheids‑ en contrast‑effecten van een afbeelding op te halen. De [ILuminance](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/iluminance/)‑interface vertegenwoordigt dit afbeeldingstransformatieseffect.

Deze C#‑code toont hoe u de helderheids‑ en contrastinstellingen van een afbeeldingskader kunt ophalen:

```csharp
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

{{% alert color="primary" %}} 
Alle effecten die op afbeeldingen worden toegepast, zijn te vinden in [Aspose.Slides.Effects](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/).
{{% /alert %}}

## **Opmaak van afbeeldingskader**

Aspose.Slides biedt tal van opmaakopties die op een afbeeldingskader kunnen worden toegepast. Met deze opties kunt u een afbeeldingskader aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/)‑klasse. 
2. Haal de referentie van een dia op via de index. 
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage)‑object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) die aan het presentatie‑object is gekoppeld en die zal worden gebruikt om de vorm te vullen. 
4. Geef de breedte en hoogte van de afbeelding op. 
5. Maak een `PictureFrame` op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](http://www.aspose.com/api/net/slides/nl/aspose.slides/ishapecollection/methods/addpictureframe)‑methode die wordt aangeboden door het [IShapes](http://www.aspose.com/api/net/slides/nl/aspose.slides/ishapecollection)‑object dat aan de verwijzende dia is gekoppeld. 
6. Voeg het afbeeldingskader (met de afbeelding) toe aan de dia. 
7. Stel de lijmkleur van het afbeeldingskader in. 
8. Stel de lijmdikte van het afbeeldingskader in. 
9. Roteer het afbeeldingskader door een positieve of negatieve waarde toe te passen. 
   * Een positieve waarde roteert de afbeelding met de klok mee. 
   * Een negatieve waarde roteert de afbeelding tegen de klok in. 
10. Voeg het afbeeldingskader (met de afbeelding) toe aan de dia. 
11. Sla de gewijzigde presentatie op als een PPTX‑bestand. 

```c#
// Instantieert de Presentation-klasse die een PPTX-bestand voorstelt
using (Presentation presentation = new Presentation())
{
    // Haalt de eerste dia op
    ISlide slide = presentation.Slides[0];

    // Laadt een afbeelding en voegt deze toe aan de afbeeldingcollectie van de presentatie
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Voegt een afbeeldingskader toe met dezelfde hoogte en breedte als de afbeelding
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Past wat opmaak toe op het afbeeldingskader
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Schrijft de presentatie naar een PPTX-bestand
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose heeft onlangs een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit [JPG/JPEG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen wilt samenvoegen, of [roosters uit foto’s wilt maken](https://products.aspose.app/slides/nl/collage/photo-grid), kunt u deze service gebruiken. 

{{% /alert %}}

## **Een afbeelding toevoegen als link**

Om grote presentaties te vermijden, kunt u afbeeldingen (of video’s) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie te embedden. Deze C#‑code laat zien hoe u een afbeelding en video aan een placeholder toevoegt:

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

## **Afbeeldingen bijsnijden**

Deze C#‑code laat zien hoe u een bestaande afbeelding op een dia kunt bijsnijden:

```c#
using (Presentation presentation = new Presentation())
{
    // Maakt een nieuw afbeeldingobject
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Voegt een PictureFrame toe aan een dia
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Bijsnijdt de afbeelding (percentage waarden)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Slaat het resultaat op
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Bijsneden gebieden van een afbeelding verwijderen**

Als u de bijgesneden gebieden van een afbeelding in een kader wilt verwijderen, kunt u de [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)‑methode gebruiken. Deze methode retourneert de bijgesneden afbeelding of de oorspronkelijke afbeelding als bijsnijden niet nodig is.

Deze C#‑code demonstreert de bewerking:

```c#
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

De [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)‑methode voegt de bijgesneden afbeelding toe aan de afbeeldingcollectie van de presentatie. Als de afbeelding alleen in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) wordt gebruikt, kan deze aanpak de presentatie‑grootte verkleinen. Anders neemt het aantal afbeeldingen in de resulterende presentatie toe.

Deze methode converteert WMF/EMF‑metabestanden naar raster‑PNG‑afbeeldingen tijdens de bijsnijdbewerking. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met de [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/compressimage/)‑methode.
Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de mogelijkheid om bijgesneden gebieden te verwijderen.

Hij past de grootte en resolutie van de afbeelding aan, vergelijkbaar met de PowerPoint‑functie **Afbeeldingsformaat → Afbeeldingen comprimeren → Resolutie**.

De volgende C#‑voorbeelden tonen hoe u een afbeelding in een presentatie kunt comprimeren door een doel‑resolutie op te geven en optioneel bijgesneden gebieden te verwijderen:

```csharp
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
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Comprimeer de afbeelding tot 150 DPI (webresolutie) en verwijder bijgesneden delen.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

De methode converteert de afbeelding naar een lagere resolutie op basis van de grootte van de vorm en de opgegeven DPI. Bijgesneden gebieden kunnen eveneens worden verwijderd om de bestandsgrootte te optimaliseren.  
Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. Bovendien wordt de JPEG‑kwaliteit behouden of iets verminderd op basis van de resolutie, vergelijkbaar met hoe PowerPoint omgaat met hoge‑resolutie JPEG’s. 

{{% /alert %}}

## **Beeldverhouding vergrendelen**

Als u wilt dat een vorm met een afbeelding zijn beeldverhouding behoudt, zelfs nadat u de afmetingen van de afbeelding hebt gewijzigd, kunt u de eigenschap [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframelock/aspectratiolocked/) gebruiken om de *Beeldverhouding vergrendelen*‑instelling in te stellen. 

Deze C#‑code laat zien hoe u de beeldverhouding van een vorm vergrendelt:

```c#
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

Deze *Beeldverhouding vergrendelen*‑instelling behoudt alleen de beeldverhouding van de vorm en niet van de afbeelding die erin zit. 

{{% /alert %}}

## **Gebruik de StretchOff‑eigenschap**

Door de [StretchOffsetLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsetright) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom)‑eigenschappen van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat)‑klasse te gebruiken, kunt u een vulrechthoek specificeren. 

Wanneer rekken voor een afbeelding wordt opgegeven, wordt een bronrechthoek geschaald om te passen binnen de opgegeven vulrechthoek. Elke rand van de vulrechthoek wordt gedefinieerd door een procentuele offset ten opzichte van de overeenkomstige rand van de begrenzings‑box van de vorm. Een positief percentage geeft een inset aan, een negatief percentage een outset. 

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/)‑klasse. 
2. Haal de referentie van een dia op via de index. 
3. Voeg een rechthoekige `AutoShape` toe. 
4. Maak een afbeelding. 
5. Stel het vultype van de vorm in. 
6. Stel de afbeeldingvullingsmodus van de vorm in. 
7. Voeg een afbeelding toe om de vorm te vullen. 
8. Geef de afbeeldingsoffsets op ten opzichte van de overeenkomstige rand van de begrenzings‑box van de vorm 
9. Sla de gewijzigde presentatie op als een PPTX‑bestand. 

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Stelt de afbeelding in die vanaf elke kant binnen het vormlichaam wordt uitgerekt
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Hoe kan ik achterhalen welke afbeeldingsformaten worden ondersteund voor PictureFrame?**

Aspose.Slides ondersteunt zowel raster‑afbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vector‑afbeeldingen (bijvoorbeeld SVG) via het afbeeldingobject dat aan een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) is toegewezen. De lijst met ondersteunde formaten overlapt over het algemeen met de mogelijkheden van de dia‑ en afbeelding‑conversie‑engine.

**Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX?**

Het insluiten van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; afbeeldingen via koppelingen toevoegen houdt de presentaties kleiner, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een link toe te voegen om de bestandsgrootte te verkleinen.

**Hoe kan ik een afbeeldingobject vergrendelen tegen per ongeluk verplaatsen/vergroten?**

Gebruik [vormvergrendelingen](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/pictureframelock/) voor een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of schalen uit te schakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart [beschermingsartikel](/slides/nl/net/applying-protection-to-presentation/) en wordt ondersteund voor verschillende vormtypen, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/).

**Wordt de vector‑nauwkeurigheid van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) te extraheren als de oorspronkelijke vector. Bij het [exporteren naar PDF](/slides/nl/net/convert-powerpoint-to-pdf/) of [rasterformaten](/slides/nl/net/convert-powerpoint-to-png/) kan het resultaat gerasterd worden, afhankelijk van de exportinstellingen; het feit dat de oorspronkelijke SVG als vector is opgeslagen, wordt bevestigd door het extractie‑gedrag.