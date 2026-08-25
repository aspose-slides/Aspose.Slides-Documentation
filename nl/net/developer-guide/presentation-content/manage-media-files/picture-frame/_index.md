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
- ingesloten afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- opmaak van afbeeldingframe
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Afbeeldingsframes maken, opmaken, koppelen, bijsnijden, extraheren en comprimeren in presentaties met Aspose.Slides voor .NET."
---
## **Overzicht**

Een afbeeldingframe is een dia‑vorm die een afbeelding toont. In Aspose.Slides zijn de afbeeldingsresource en de vorm die deze weergeeft aparte objecten: een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) bezit ingebedde afbeeldingsresources via zijn [Images](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/images/)‑collectie, terwijl een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingseffecten en andere frame‑niveau instellingen regelt.

Deze scheiding is handig wanneer dezelfde afbeelding meer dan één keer wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/), en gebruik die afbeeldingsresource bij het maken van afbeeldingframes.

Afbeeldingframes kunnen raster‑afbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is nuttig om te bepalen hoe de afbeelding moet worden opgeslagen voordat formattering of optimalisatie wordt toegepast.

## **Een ingebedde afbeelding toevoegen en formatteren**

Voor een ingebedde afbeelding voeg je de afbeeldingsdata toe aan de presentatie en maak je een afbeeldingframe met [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addpictureframe/). De afbeelding wordt onderdeel van het presentatie‑pakket, waardoor de presentatie zelf‑containend blijft wanneer hij naar een andere computer wordt verplaatst.

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

Het afbeeldingframe bepaalt de weergegeven geometrie; het wijzigen van de frame‑grootte verandert de originele pixelafmetingen die in de ingebedde afbeeldingsresource zijn opgeslagen. Dit onderscheid wordt belangrijk bij later bijsnijden of comprimeren van een afbeelding.

## **Relatieve schaal gebruiken**

[IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) biedt relatieve breedte‑ en hoogteschaling voor het frame. Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldingsgrootte. Relatieve schaal is handig wanneer een workflow een relatie tot de bronafbeeldingsgrootte wil behouden in plaats van handmatig de eindafmetingen te berekenen.

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

Relatieve schaal wijzigt de schaalinstellingen van het frame; het her­samplet of comprimeert de ingebedde afbeelding niet.

## **Ingebedde en gekoppelde afbeeldingen**

Een ingebedde afbeelding slaat afbeeldingsdata binnen de presentatie op en is daardoor de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding slaat een externe locatie op via het [ISlidesPicture](https://reference.aspose.com/slides/nl/net/aspose.slides/islidespicture/)‑koppelingspad in plaats van de afbeeldingsdata op dezelfde manier in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in de PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de applicatie die de presentatie opent of rendert. Als het pad verandert, het bestand wordt verplaatst, of de resource niet beschikbaar is, wordt de gekoppelde afbeelding mogelijk niet zoals verwacht weergegeven. Voor presentaties die moeten worden gemaild, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingebedde afbeeldingen doorgaans betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een afbeeldingframe en wijst het naar een lokaal afbeeldingsbestand. Het behandelt alleen het koppelen van afbeeldingen; het koppelen van video’s is een apart mediaproces en wordt opzettelijk niet gemengd in dit voorbeeld.

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

Gebruik koppelingen wanneer extern bestandsbeheer intentioneel is. Gebruik ze niet louter als vervanging voor compressie: een kleine PPTX met defecte afbeeldings‑afhankelijkheden is meestal minder bruikbaar dan een grotere, zelf‑containende presentatie.

## **Afbeeldingen uit afbeeldingframes extraheren**

Voordat je een afbeelding uit een bestaande presentatie extraheert, controleer je of een vorm daadwerkelijk een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) is en of deze een ingebedde afbeelding bevat. Gekoppelde afbeeldingframes bevatten mogelijk geen afbeeldingsbytes die op dezelfde manier kunnen worden geëxtraheerd.

### **Een raster‑afbeelding extraheren**

De moderne afbeeldings‑API gebruikt [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) direct en vereist niet langer de oudere systeem‑image‑wrapper. Het volgende voorbeeld zoekt de eerste ingebedde raster‑afbeelding op een dia en slaat deze op als PNG:

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

Opslaan via [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) zet de geëxtraheerde afbeelding om naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes die in de presentatie zijn opgeslagen wilt hebben in plaats van een geconverteerd raster‑bestand, gebruik dan de binaire data van de afbeeldingsresource.

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

Het behouden van SVG‑inhoud als SVG bewaart de vector‑bron binnen de presentatie. Raster‑exporten zoals PNG of JPEG renderen die vector‑inhoud onvermijdelijk naar pixels. PDF‑ of SVG‑dia‑export is eveneens een render‑operatie, dus de geëxporteerde graphics moeten niet worden beschouwd als een bit‑voor‑bit‑kopie van de originele ingebedde SVG; gebruik de ingebedde [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/)‑data wanneer de originele vector‑resource zelf nodig is.

## **Een afbeelding bijsnijden**

Bijsnijden verandert welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/) zijn percentages van de afmetingen van de bronafbeelding. Bijsnijden verwijdert de verborgen pixels niet direct uit de ingebedde afbeelding; het wijzigt alleen het zichtbare gebied.

Het volgende voorbeeld vindt veilig een afbeeldingframe en past bijsnijdwaarden toe:

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

Omdat de verborgen afbeeldingsdata nog aanwezig is, kan het bijsnijden later worden aangepast zonder de originele pixels te verliezen. Als bestandsgrootte belangrijker is dan omkeerbaarheid, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden afbeeldingsdata verwijderen**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwijdert afbeeldingsdata buiten het huidige bijsnijd‑rechthoek en retourneert de resulterende afbeeldingsresource. Dit kan de bestandsgrootte verkleinen, maar is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet meer beschikbaar voor een later “uncrop”‑proces.

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

De methode kan een nieuwe afbeeldingsresource aan de presentatie toevoegen. Als de originele afbeelding ook door andere afbeeldingframes wordt gebruikt, hebben die frames nog steeds hun bestaande resource nodig, zodat het verwijderen van bijgesneden gebieden niet per se het totale aantal afbeeldingen vermindert. Het bijsnijden van WMF‑ of EMF‑inhoud met deze methode rastert het bijgesneden resultaat naar PNG.

## **Raster‑afbeeldingen comprimeren**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/compressimage/) vermindert de resolutie van een raster‑afbeelding relatief ten opzichte van de grootte waarin de afbeelding wordt weergegeven. Het kan ook bijgesneden gebieden in dezelfde bewerking verwijderen. De methode retourneert `true` wanneer de afbeelding is geschaald of bijgesneden en `false` wanneer er geen wijziging nodig was.

Gebruik een vooraf gedefinieerde [PicturesCompression](https://reference.aspose.com/slides/nl/net/aspose.slides.export/picturescompression/)‑waarde wanneer een standaard doelresolutie voldoende is:

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

Een aangepaste positieve DPI‑waarde kan in plaats van een enum‑waarde worden doorgegeven wanneer een specifiek doel vereist is.

Compressie is bedoeld voor raster‑afbeeldingen. SVG‑ en metafile‑inhoud wordt niet gereduceerd door deze raster‑compressieworkflow. Houd er ook rekening mee dat een lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie op basis van de grootste weergave‑ of exportgrootte van de afbeelding in plaats van de laagst mogelijke DPI globaal toe te passen.

## **Beheer van afbeeldings‑transformatieseffecten**

Voor een volledige workflow die helderheid, contrast, kleurtransformaties, vervaging, alfa‑effecten, geordende ketens, inspectie, verwijdering en round‑trip‑verificatie omvat, zie [Image Transform Effects](/slides/nl/net/image-transform-effects/).

## **Geometrie van afbeeldingframes vergrendelen**

De [IPictureFrameLock](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframelock/)‑instellingen bepalen welke bewerkingsacties zijn uitgeschakeld voor een afbeeldingframe. Bijvoorbeeld, de vergrendeling van de beeldverhouding behoudt de proporties van de vorm terwijl deze wordt vergroot of verkleind.

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

De vergrendeling geldt voor de afbeeldingframe‑vorm. Het dwingt de bronafbeelding niet om te worden geresampled of permanent aangepast naar dezelfde beeldverhouding.

## **De StretchOffset‑waarden aanpassen**

Wanneer de vulmodus van een afbeelding “stretch” is, definiëren de stretch‑offset‑waarden op [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/) het vulrechthoek ten opzichte van de omhullende doos van het afbeeldingframe. Positieve percentages creëren een insnijding vanaf een rand, terwijl negatieve percentages een uitstulping veroorzaken.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare afbeelding wordt uitgerekt.

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

Gebruik stretch‑offsets voor de plaatsing van de vulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om randen van de bronafbeelding te verbergen.

## **Opslag, bestandsgrootte en exportoverwegingen**

De belangrijkste afwegingen zijn makkelijker te beheren wanneer afbeeldingsopslag en afbeeldingframe‑formattering afzonderlijk worden behandeld:

- **Ingebedde afbeeldingen** maken de presentatie zelf‑containend en zijn het betrouwbaarst voor delen en server‑side rendering, maar grote raster‑afbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die beschikbaar moeten blijven op de opgeslagen paden of locaties.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingebed tot bijgesneden gebieden expliciet worden verwijderd of tijdens compressie.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote raster‑afbeeldingen, maar offert de bronresolutie op. Het dient pas te worden toegepast nadat de uiteindelijke weergavegrootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten als SVG blijven wanneer vectorbehoud belangrijk is. Extraheer de ingebedde SVG rechtstreeks wanneer je de vector‑resource zelf nodig hebt. Raster‑dia‑exporten converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten een bestaande [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/)‑resource hergebruiken wanneer mogelijk in plaats van herhaaldelijk hetzelfde bestand in de presentatie‑workflow te laden.

Voor grote presentaties is afbeeldingoptimalisatie meestal het meest effectief wanneer deze selectief wordt toegepast: houd logo’s en diagrammen als vector‑content, comprimeer foto’s volgens hun werkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer later bewerken niet vereist is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een afbeeldingframe en een afbeeldingsresource?**

Een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) vertegenwoordigt een afbeeldingsresource die aan de presentatie is gekoppeld. Een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau geometrie en opmaak opslaat, zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen insluiten of koppelen?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet worden zonder toegang tot externe resources. Koppel afbeeldingen alleen wanneer het opzettelijk is om afbeeldingsbestanden buiten de PPTX te houden en de externe locaties betrouwbaar kunnen worden beheerd.

**Vermindert bijsnijden de PPTX‑bestandsgrootte?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) of beeldcompressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden weggegooid.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verlagen en het verwijderen van bijgesneden gebieden wist afbeeldingsdata. Houd de originele bronafbeelding buiten de presentatie als later bewerken met hoge resolutie vereist kan zijn.

**Hoe moeten SVG‑afbeeldingen worden behandeld?**

Behoud SVG‑content als SVG wanneer vector‑fidelity van belang is. De ingebedde [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/) kan direct worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype voordat je afbeelding‑frame‑specifieke leden gebruikt. Pattern‑matching met [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) of het filteren van de vorm‑collectie op die interface voorkomt ongeldige casts en laat de code dia’s zonder afbeeldingframes correct afhandelen.