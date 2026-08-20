---
title: Beheer afbeeldingsframes in presentaties in .NET
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/net/picture-frame/
keywords:
- afbeeldingsframe
- afbeeldingsframe toevoegen
- afbeeldingsframe maken
- ingebedde afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- afbeeldingsframe opmaak
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak, formatteer, koppel, snijd bij, extraheer en comprimeer afbeeldingsframes in presentaties met Aspose.Slides voor .NET."
---
## **Overzicht**

Een afbeeldingsframe is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsbron en de vorm die deze weergeeft afzonderlijke objecten: een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) bezit ingebedde afbeeldingsbronnen via zijn [Images](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/images/)‑collectie, terwijl een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingseffecten en andere frame‑niveau‑instellingen van de afbeelding beheert.

Deze scheiding is nuttig wanneer dezelfde afbeelding meerdere keren wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/), en gebruik die afbeeldingsbron bij het maken van afbeeldingsframes.

Afbeeldingsframes kunnen rasterafbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt de draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is handig om te bepalen hoe de afbeelding moet worden opgeslagen voordat formattering of optimalisatie wordt toegepast.

## **Een ingebedde afbeelding toevoegen en opmaken**

Voor een ingebedde afbeelding voeg je de afbeeldingsgegevens toe aan de presentatie en maak je een afbeeldingsframe met [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addpictureframe/). De afbeelding wordt onderdeel van het presentatiepakket, zodat de presentatie zelfstandig blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een JPEG‑afbeelding toe, maakt een frame met de oorspronkelijke afmetingen van de afbeelding en past lijnopmaak en rotatie toe:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Het afbeeldingsframe bepaalt de weergegeven geometrie; het wijzigen van de framemaat verandert de oorspronkelijke pixelafmetingen die zijn opgeslagen in de ingebedde afbeeldingsbron niet. Dit onderscheid wordt later belangrijk bij het bijsnijden of comprimeren van een afbeelding.

## **Relatieve schaal gebruiken**

[IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) biedt relatieve breedte‑ en hoogteschaal voor het frame. Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldingsgrootte. Relatieve schaal is nuttig wanneer een workflow de verhouding tot de bronafbeeldingsgrootte moet behouden in plaats van handmatig de uiteindelijke afmetingen te berekenen.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Relatieve schaal wijzigt de schaalinstellingen van het frame; het herschaalt of comprimeert de ingebedde afbeelding niet.

## **Ingebedde en gekoppelde afbeeldingen**

Een ingebedde afbeelding slaat afbeeldingsgegevens op binnen de presentatie en is daarom de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding slaat een extern pad op via de [ISlidesPicture](https://reference.aspose.com/slides/nl/net/aspose.slides/islidespicture/)‑koppeling in plaats van de afbeeldingsgegevens op dezelfde manier in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in het PPTX‑bestand verkleinen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de toepassing die de presentatie opent of rendert. Als het pad verandert, het bestand wordt verplaatst of de bron is niet beschikbaar, wordt de gekoppelde afbeelding mogelijk niet correct weergegeven. Voor presentaties die moeten worden gemaild, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingebedde afbeeldingen doorgaans betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een afbeeldingsframe en wijst het naar een lokaal afbeeldingsbestand. Het behandelt alleen afbeeldingskoppelingen; video‑koppelingen zijn een aparte mediastroom en worden bewust niet in dit voorbeeld gemixt.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Gebruik koppelingen wanneer extern bestandbeheer opzettelijk is. Gebruik ze niet enkel als vervanging voor compressie: een klein PPTX‑bestand met gebroken afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere, zelfstandige presentatie.

## **Afbeeldingen uit afbeeldingsframes extraheren**

Controleer voordat je een afbeelding uit een bestaande presentatie extraheert of een vorm daadwerkelijk een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) is en of deze een ingebedde afbeelding bevat. Gekoppelde afbeeldingsframes bevatten mogelijk geen afbeeldingsbytes die op dezelfde manier kunnen worden geëxtraheerd.

### **Een rasterafbeelding extraheren**

De moderne afbeeldings‑API gebruikt [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) rechtstreeks en vereist niet meer de oudere systeem‑image‑wrapper. Het volgende voorbeeld zoekt de eerste ingebedde rasterafbeelding op een dia en slaat deze op als PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Opslaan via [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) converteert de geëxtraheerde afbeelding naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes wilt hebben die in de presentatie zijn opgeslagen in plaats van een geconverteerd rasterbestand, gebruik dan de binaire data van de afbeeldingsbron.

### **Een SVG‑afbeelding extraheren**

Voor een SVG‑afbeelding biedt de [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) een [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/)‑object. Hiermee kun je de SVG‑data direct ophalen in plaats van de afbeelding eerst te rasteren.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Het behouden van SVG‑inhoud als SVG bewaart de vectorbron binnen de presentatie. Rasterexporten zoals PNG of JPEG renderen die vectorinhoud onvermijdelijk naar pixels. PDF‑ of SVG‑dia‑export is eveneens een render‑operatie, dus de geëxporteerde graphics mogen niet worden beschouwd als een bit‑voor‑bit‑kopie van de oorspronkelijke ingebedde SVG; gebruik de ingebedde [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/)‑data wanneer de originele vectorbron zelf vereist is.

## **Een afbeelding bijsnijden**

Bijsnijden bepaalt welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/) zijn percentages van de bronafbeeldingsafmetingen. Bijsnijden verwijdert de verborgen pixels niet onmiddellijk uit de ingebedde afbeelding; het verandert alleen het zichtbare gebied.

Het volgende voorbeeld zoekt veilig een afbeeldingsframe en past bijsnijdwaarden toe:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Omdat de verborgen afbeeldingsdata nog aanwezig is, kan de bijsnijding later worden aangepast zonder verlies van de originele pixels. Als bestandsgrootte belangrijker is dan revertibiliteit, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden afbeeldingsdata verwijderen**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwijdert afbeeldingsdata buiten het huidige bijsnijdrechthoek en retourneert de resulterende afbeeldingsbron. Dit kan de bestandsgrootte verkleinen, maar het is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet meer beschikbaar voor een latere ontbijsnijd‑bewerking.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

De methode kan een nieuwe afbeeldingsbron aan de presentatie toevoegen. Als de oorspronkelijke afbeelding ook door andere afbeeldingsframes wordt gebruikt, hebben die frames nog steeds hun bestaande bron nodig, dus het verwijderen van bijgesneden gebieden verkleint niet noodzakelijkerwijs het totale aantal afbeeldingen. Het bijsnijden van WMF‑ of EMF‑inhoud met deze methode rastert het bijgesneden resultaat naar PNG.

## **Rasterafbeeldingen comprimeren**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/compressimage/) vermindert de rasterresolutie relatief ten opzichte van de grootte waarin de afbeelding wordt weergegeven. Het kan ook bijgesneden gebieden in dezelfde bewerking verwijderen. De methode retourneert `true` wanneer de afbeelding is geschaald of bijgesneden en `false` wanneer geen wijziging nodig was.

Gebruik een vooraf gedefinieerde [PicturesCompression](https://reference.aspose.com/slides/nl/net/aspose.slides.export/picturescompression/)‑waarde wanneer een standaarddoelresolutie voldoende is:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Een aangepaste positieve DPI‑waarde kan worden doorgegeven in plaats van een enum‑waarde wanneer een specifieke doelresolutie vereist is.

Compressie is bedoeld voor rasterafbeeldingen. SVG‑ en metafile‑inhoud wordt niet verminderd door deze rastercompressieworkflow. Houd er ook rekening mee dat een lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden teruggehaald uit de geoptimaliseerde presentatie. Kies een doelresolutie op basis van de grootste weergave‑ of exportgrootte van de afbeelding in plaats van globaal de laagste DPI toe te passen.

## **Afbeeldingseffecten inspecteren**

Afbeeldingseffecten worden opgeslagen op de afbeelding die door het frame wordt gebruikt. De afbeeldingstransform‑collectie kan effecten bevatten zoals vaste alfamodulatie voor transparantie en luminantie voor helderheid en contrast. Het onderstaande voorbeeld leest beide soorten effecten veilig van het eerste afbeeldingsframe op een dia:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Deze effecten veranderen hoe de afbeelding in het frame wordt gerenderd; ze herschrijven de originele ingebedde afbeeldingsbytes niet.

## **Afbeeldingsframe‑geometrie vergrendelen**

De [IPictureFrameLock](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframelock/)‑instellingen bepalen welke bewerkingstypes voor een afbeeldingsframe zijn uitgeschakeld. Bijvoorbeeld, het vergrendelen van de beeldverhouding behoudt de proporties van de vorm tijdens het schalen.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

De vergrendeling is van toepassing op de vorm van het afbeeldingsframe. Het dwingt de bronafbeelding niet om te worden herschaald of permanent aangepast aan dezelfde beeldverhouding.

## **De StretchOffset‑waarden aanpassen**

Wanneer de vulmodus van de afbeelding op stretch staat, definiëren de stretch‑offset‑waarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/) het vul‑rechthoek ten opzichte van de begrenzende doos van het afbeeldingsframe. Positieve percentages creëren een inset vanaf een rand, terwijl negatieve percentages een outset creëren.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets veranderen het rechthoek waarin de zichtbare afbeeldingsvulling wordt uitgerekt.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Gebruik stretch‑offsets voor vulplaatsing. Gebruik bijsnijd‑eigenschappen wanneer het doel is om de randen van de bronafbeelding te verbergen.

## **Opslag, bestandsgrootte en exportoverwegingen**

De belangrijkste afwegingen zijn makkelijker te beheren wanneer afbeeldingsopslag en frame‑formatteringsinstellingen afzonderlijk worden behandeld:

- **Ingebedde afbeeldingen** maken de presentatie zelf‑bevattend en zijn het meest betrouwbaar voor delen en server‑side rendering, maar grote rasterafbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die op de opgeslagen paden of locaties beschikbaar blijven.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingebed totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote rasterafbeeldingen, maar verliest bronresolutie. Het moet worden toegepast nadat de beoogde weergave‑grootte op de dia bekend is.
- **SVG‑afbeeldingen** dienen als SVG te blijven wanneer vectorbewaring belangrijk is. Extraheer de ingebedde SVG direct wanneer je de vectorbron zelf nodig hebt. Raster‑dia‑exporten converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten een bestaande [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/)‑bron hergebruiken wanneer mogelijk in plaats van herhaaldelijk hetzelfde bestand in de presentatieworkflow te laden.

Voor grote presentaties is afbeeldingoptimalisatie meestal het effectiefst wanneer selectief uitgevoerd: behoud logo’s en diagrammen als vectorinhoud, comprimeer foto’s volgens hun werkelijke weergave‑grootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet vereist is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een afbeeldingsframe en een afbeeldingsbron?**

Een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) vertegenwoordigt een afbeeldingsbron die aan de presentatie is gekoppeld. Een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau‑geometrie en formattering zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen opslaat.

**Moet ik afbeeldingen embedden of koppelen?**

Embed afbeeldingen wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet kunnen worden zonder toegang tot externe bronnen. Koppel afbeeldingen alleen wanneer het uitdrukkelijk de bedoeling is om afbeeldingsbestanden buiten het PPTX te houden en de externe locaties betrouwbaar kunnen worden beheerd.

**Vermindert bijsnijden de PPTX‑bestandsgrootte?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) of compressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden weggehaald.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verlagen, en het verwijderen van bijgesneden gebieden verwijdert afbeeldingsdata. Houd de originele bronafbeelding buiten de presentatie als later bewerken met hoge resolutie vereist kan zijn.

**Hoe moeten SVG‑afbeeldingen worden behandeld?**

Behoud SVG‑inhoud als SVG wanneer vector‑fidelity van belang is. De ingebedde [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/) kan direct worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype voordat je leden gebruikt die specifiek zijn voor afbeeldingsframes. Patroon‑matching met [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) of filtering van de vorm‑collectie op die interface voorkomt ongeldige casts en laat de code dia’s verwerken die geen afbeeldingsframes bevatten.