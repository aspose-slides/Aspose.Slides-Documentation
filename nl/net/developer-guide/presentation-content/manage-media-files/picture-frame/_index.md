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
description: "Voeg afbeeldingskaders toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET. Vereenvoudig uw workflow en verbeter het slide-ontwerp."
---
## **Introductie**

Een afbeeldingskader is een vorm die een afbeelding bevat — het is als een foto in een kader.  

U kunt een afbeelding aan een dia toevoegen via een afbeeldingskader. Op die manier kunt u de afbeelding opmaken door het afbeeldingskader te bewerken.

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die gebruikers in staat stellen snel presentaties te maken van afbeeldingen. 

{{% /alert %}} 

## **Maak een afbeeldingskader**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage) object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) die bij het presentatie‑object hoort en die gebruikt zal worden om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe) aan op basis van de breedte en hoogte van de afbeelding via de `AddPictureFrame`‑methode van het vormobject dat bij de betreffende dia hoort.  
6. Voeg een afbeeldingskader (dat de afbeelding bevat) toe aan de dia.  
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe u een afbeeldingskader maakt:

```c#
// Instantieert de Presentation-klasse die een PPTX‑bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{
    // Haalt de eerste dia op
    ISlide slide = pres.Slides[0];

    // Laadt een afbeelding en voegt deze toe aan de afbeeldingcollectie van de presentatie
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Voegt een afbeeldingskader toe met dezelfde hoogte en breedte
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Past enige opmaak toe op het afbeeldingskader
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Schrijft de presentatie naar een PPTX‑bestand
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Afbeeldingskaders stellen u in staat snel presentatiedia's te maken op basis van afbeeldingen. Wanneer u een afbeeldingskader combineert met de opslaan‑opties van Aspose.Slides, kunt u in‑ en uitvoerbewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren. Misschien wilt u deze pagina’s bekijken: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/net/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/net/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/net/conversion/jpg-to-png/), converteer [PNG naar JPG](https://products.aspose.com/slides/nl/net/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/net/conversion/png-to-svg/), converteer [SVG naar PNG](https://products.aspose.com/slides/nl/net/conversion/svg-to-png/).

{{% /alert %}}

## **Maak een afbeeldingskader met relatieve schaal**

Door de relatieve schaal van een afbeelding aan te passen, kunt u een complexer afbeeldingskader maken.  

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een afbeelding toe aan de presentatie‑image‑collection.  
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage) object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) die bij het presentatie‑object hoort en die gebruikt zal worden om de vorm te vullen.  
5. Specificeer de relatieve breedte en hoogte van de afbeelding in het afbeeldingskader.  
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code laat zien hoe u een afbeeldingskader met relatieve schaal maakt:

```c#
// Instantieert de Presentation-klasse die een PPTX‑bestand vertegenwoordigt
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

U kunt rasterafbeeldingen extraheren uit [PictureFrame]-objecten en deze opslaan in PNG, JPG en andere formaten. Het onderstaande codevoorbeeld laat zien hoe u een afbeelding uit het document “sample.pptx” kunt extraheren en opslaan in PNG‑formaat.

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

Wanneer een presentatie SVG‑grafieken bevat die zijn geplaatst binnen [PictureFrame]‑vormen, maakt Aspose.Slides voor .NET het mogelijk de originele vectorafbeeldingen met volledige getrouwheid op te halen. Door de vormcollectie van de dia te doorlopen, kunt u elk [PictureFrame] identificeren, controleren of de onderliggende [IPPImage] SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.

Het volgende codevoorbeeld laat zien hoe u een SVG‑afbeelding uit een afbeeldingskader kunt extraheren:

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

Aspose.Slides maakt het mogelijk de transparanseeffecten van een afbeelding op te halen. Deze C#‑code demonstreert de bewerking:

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
Alle effecten die op afbeeldingen worden toegepast, kunt u vinden in [Aspose.Slides.Effects](https://reference.aspose.com/slides/nl/net/aspose.slides.effects/).
{{% /alert %}}

## **Opmaak van afbeeldingskader**

Aspose.Slides biedt vele opmaakopties die op een afbeeldingskader kunnen worden toegepast. Met die opties kunt u een afbeeldingskader aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/)klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage) object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) die bij het presentatie‑object hoort en die gebruikt zal worden om de vorm te vullen.  
4. Specificeer de breedte en hoogte van de afbeelding.  
5. Maak een `PictureFrame` aan op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](http://www.aspose.com/api/net/slides/nl/aspose.slides/ishapecollection/methods/addpictureframe)‑methode van het [IShapes](http://www.aspose.com/api/net/slides/nl/aspose.slides/ishapecollection)‑object dat bij de betreffende dia hoort.  
6. Voeg het afbeeldingskader (dat de afbeelding bevat) toe aan de dia.  
7. Stel de lijnkleur van het afbeeldingskader in.  
8. Stel de lijndikte van het afbeeldingskader in.  
9. Roteer het afbeeldingskader door een positieve of negatieve waarde op te geven.  
   * Een positieve waarde roteert de afbeelding met de klok mee.  
   * Een negatieve waarde roteert de afbeelding tegen de klok in.  
10. Voeg het afbeeldingskader (dat de afbeelding bevat) opnieuw toe aan de dia.  
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code demonstreert het opmaakproces van een afbeeldingskader:

```c#
// Instantieert de Presentation-klasse die een PPTX‑bestand vertegenwoordigt
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

    // Past enige opmaak toe op het afbeeldingskader
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Schrijft de presentatie naar een PPTX‑bestand
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose heeft recentelijk een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit [JPG/JPEG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen wilt samenvoegen, of [raster‑rasters maken van foto’s](https://products.aspose.app/slides/nl/collage/photo-grid), kunt u deze dienst gebruiken. 

{{% /alert %}}

## **Afbeelding toevoegen als koppeling**

Om de grootte van een presentatie te beperken, kunt u afbeeldingen (of video’s) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie te embedden. Deze C#‑code toont hoe u een afbeelding en video in een placeholder kunt toevoegen:

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

Deze C#‑code toont hoe u een bestaande afbeelding op een dia kunt bijsnijden:

```c#
using (Presentation presentation = new Presentation())
{
    // Creëert een nieuw afbeeldingobject
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

Als u de bijgesneden gebieden van een afbeelding in een kader wilt verwijderen, kunt u de [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)‑methode gebruiken. Deze methode retourneert de bijgesneden afbeelding of de originele afbeelding als bijsnijden overbodig is.

Deze C#‑code demonstreert de bewerking:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haalt het PictureFrame op van de eerste dia
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Verwijdert bijgesneden gebieden van de PictureFrame‑afbeelding en retourneert de bijgesneden afbeelding
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Slaat het resultaat op
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="OPMERKING" color="warning" %}} 

De [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)‑methode voegt de bijgesneden afbeelding toe aan de presentatie‑image‑collection. Indien de afbeelding alleen in het verwerkte [PictureFrame] wordt gebruikt, kan deze instelling de presentatiesize verkleinen. Anders neemt het aantal afbeeldingen in de uiteindelijke presentatie toe.

Deze methode zet WMF/EMF‑metabestanden om naar raster‑PNG‑afbeeldingen tijdens de bijsnijdbewerking. 
{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met de [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/compressimage/)‑methode. Deze methode verkleint een afbeelding door de bestandsgrootte te reduceren op basis van de vormgrootte en de opgegeven resolutie, met de optie om bijgesneden gebieden te verwijderen.  

Hij past de grootte en resolutie van de afbeelding aan, net als de PowerPoint‑functie **Afbeeldingsopmaak → Afbeeldingen comprimeren → Resolutie**.

De volgende C#‑voorbeelden laten zien hoe u een afbeelding in een presentatie comprimeert door een doelresolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Comprimeer de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
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

Of direct een aangepaste DPI‑waarde gebruiken:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Comprimeer de afbeelding naar 150 DPI (webresolutie), verwijder bijgesneden gebieden.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="OPMERKING" color="warning" %}} 

De methode zet de afbeelding om naar een lagere resolutie op basis van de grootte van de vorm en de opgegeven DPI. Bijgesneden regio’s kunnen tevens worden verwijderd om de bestandsgrootte te optimaliseren.  
Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. De JPEG‑kwaliteit wordt behoudener of iets verminderd afhankelijk van de resolutie, vergelijkbaar met hoe PowerPoint omgaat met hoge‑resolutie JPEG‑s. 
{{% /alert %}}

## **Verhouding vergrendelen**

Als u wilt dat een vorm met een afbeelding de verhoudingen behoudt zelfs wanneer u de afmetingen van de afbeelding wijzigt, kunt u de [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframelock/aspectratiolocked/)‑eigenschap gebruiken om de instelling *Lock Aspect Ratio* in te schakelen.  

Deze C#‑code laat zien hoe u de verhouding van een vorm vergrendelt:

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

{{% alert title="OPMERKING" color="warning" %}} 

Deze *Lock Aspect Ratio*‑instelling behoudt alleen de verhouding van de vorm en niet van de afbeelding die erin zit. 
{{% /alert %}}

## **De StretchOff‑eigenschap gebruiken**

Door de eigenschappen [StretchOffsetLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsetright) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat)‑klasse te gebruiken, kunt u een vulrechthoek definiëren.  

Wanneer stretching voor een afbeelding wordt opgegeven, wordt een bronrechthoek geschaald om in de opgegeven vulrechthoek te passen. Elke rand van de vulrechthoek wordt gedefinieerd door een procentuele offset ten opzichte van de overeenkomstige rand van de omhullende van de vorm. Een positieve procentwaarde geeft een inspringing aan, een negatieve waarde een uitstulping.

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/)klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een rechthoekige `AutoShape` toe.  
4. Maak een afbeelding.  
5. Stel het vultype van de vorm in.  
6. Stel de afbeeldingsvulmodus van de vorm in.  
7. Voeg een afbeelding toe om de vorm te vullen.  
8. Specificeer afbeeldingsoffsets ten opzichte van de overeenkomstige rand van de omhullende van de vorm.  
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C#‑code toont een proces waarbij de StretchOff‑eigenschap wordt gebruikt:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Stelt de afbeelding in die van elke kant wordt uitgerekt binnen het vormlichaam
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Hoe kan ik achterhalen welke afbeeldingsformaten ondersteund worden voor PictureFrame?**

Aspose.Slides ondersteunt zowel raster‑afbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vector‑afbeeldingen (bijvoorbeeld SVG) via het afbeeldingobject dat aan een [PictureFrame] is toegewezen. De lijst met ondersteunde formaten overlapt meestal met de mogelijkheden van de dia‑ en afbeeldingsconversie‑engine.

**Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX?**

Het embedden van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; het koppelen van afbeeldingen helpt de presentatiesize klein te houden, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een koppeling toe te voegen om de bestandsgrootte te reduceren.

**Hoe kan ik een afbeelding vergrendelen tegen per ongeluk verplaatsen/bijschalen?**

Gebruik [shape locks](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/pictureframelock/) voor een [PictureFrame] (bijvoorbeeld om verplaatsen of schalen uit te schakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart [beschermingsartikel](/slides/nl/net/applying-protection-to-presentation/) en wordt ondersteund voor verschillende vormtypen, inclusief [PictureFrame].

**Wordt de vector‑fideliteit van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame] te extraheren als de originele vector. Bij het [exporteren naar PDF](/slides/nl/net/convert-powerpoint-to-pdf/) of [raster‑formaten](/slides/nl/net/convert-powerpoint-to-png/) kan het resultaat gerasterd worden afhankelijk van de exportinstellingen; het feit dat de oorspronkelijke SVG als vector is opgeslagen, wordt bevestigd door het extractiegedrag.