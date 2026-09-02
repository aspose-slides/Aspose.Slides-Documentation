---
title: Optimaliseer afbeeldingsbeheer in presentaties in .NET
linktitle: Afbeeldingen beheren
type: docs
weight: 10
url: /nl/net/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- afbeelding vervangen
- afbeeldingscollectie
- afbeeldingskader
- gekoppelde afbeelding
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- SVG naar vormen
- externe SVG-bronnen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u raster‑ en SVG‑afbeeldingen kunt toevoegen, hergebruiken, koppelen, vervangen en beheren in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor .NET."
---
## **Inleiding**

Aspose.Slides for .NET biedt verschillende manieren om met afbeeldingen te werken, en elke manier heeft een ander doel. U kunt een afbeelding opslaan in een presentatie, weergeven in een afbeeldingskader, gebruiken als dia‑achtergrond, koppelen naar een externe afbeelding, een gedeelde afbeeldingsbron vervangen, of SVG‑inhoud converteren naar bewerkbare vormen.

Dit artikel richt zich op afbeeldingsbronnen en hoe ze in een presentatie worden gebruikt. Voor bijsnijden, transparantie, effecten, uitrekken en andere opmaak die op een individueel afbeeldingskader wordt toegepast, zie [Picture Frame](/slides/nl/net/picture-frame/) .

## **Begrijp het afbeeldingenmodel**

De volgende API‑concepten zijn nauw verwant maar niet verwisselbaar:

- De [presentation image collection](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection/) slaat afbeeldingsbronnen op die door de presentatie worden gebruikt. Gebruik [ImageCollection.AddImage](https://reference.aspose.com/slides/nl/net/aspose.slides/imagecollection/addimage/) om afbeeldingsgegevens toe te voegen en een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/)‑resource te ontvangen.
- Een [picture frame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) is een vorm die een afbeelding op een dia, indeling of master weergeeft. Gebruik [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addpictureframe/) om een afbeeldingsresource op een dia te plaatsen.
- Een dia‑achtergrond gebruikt een afbeelding als onderdeel van de vulling van de dia in plaats van als een vorm. Het gedraagt zich daarom niet als een afbeeldingskader.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/replaceimage/) vervangt een afbeeldingsresource. Als verschillende presentatiedelen die resource gebruiken, gebruiken ze allemaal de vervanging.
- Het converteren van een SVG naar vormen maakt bewerkbare dia‑vormen. Na conversie wordt de inhoud niet meer beheerd als één afbeeldingsresource.

Een typisch werkproces is daarom: afbeeldingsgegevens toevoegen aan de afbeeldingscollectie, een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) ontvangen, en die resource vervolgens gebruiken in één of meer afbeeldingskaders of vullingen.

## **Een ingebedde afbeelding toevoegen**

Om een lokale afbeelding in te voegen, leest u het bestand, voegt u de gegevens toe aan de afbeeldingscollectie en maakt u een afbeeldingskader dat de geretourneerde `IPPImage` gebruikt.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

De op deze manier toegevoegde afbeelding wordt ingebed in de presentatie, zodat het resulterende bestand niet afhankelijk is van de beschikbaarheid van het oorspronkelijke afbeeldingsbestand.

### **Een afbeelding van internet toevoegen**

Wanneer een afbeelding beschikbaar is via HTTP of HTTPS, downloadt u de bytes met `HttpClient`, voegt u ze toe aan de presentatie‑afbeeldingscollectie, en gebruikt u de geretourneerde afbeeldingsresource op dezelfde manier als een lokale afbeelding.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

In langdurige toepassingen hergebruikt u `HttpClient` in plaats van voor elke aanvraag een nieuw exemplaar te maken. Valideer ook externe URL‑s, responsgroottes en content‑types wanneer de bron niet vertrouwd is.

## **Afbeeldingen hergebruiken over dia’s heen**

Als dezelfde afbeelding meer dan één keer nodig is, voegt u deze eenmaal aan de presentatie toe en hergebruikt u de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) bij het maken van extra afbeeldingskaders. Dit voorkomt herhaaldelijk laden van dezelfde brongegevens en maakt de relatie tussen de gedeelde afbeeldingsresource en de toepassingen expliciet.

Voor grafische elementen die automatisch op veel dia’s moeten verschijnen, zoals een bedrijfslogo, kunt u overwegen het afbeeldingskader op een [slide master](/slides/nl/net/slide-master/) of indeling te plaatsen in plaats van een gelijkwaardige vorm op elke dia toe te voegen.

## **Een afbeelding als dia‑achtergrond gebruiken**

Een achtergrondafbeelding wordt toegewezen aan de vulling van de dia; hij wordt niet toegevoegd als een afbeeldingskader‑vorm. Dit is nuttig wanneer de afbeelding de volledige dia‑achtergrond moet bedekken en niet moet worden bewerkt als een normaal dia‑object.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Voor extra achtergrondopties, inclusief master‑ en indelingsachtergronden, zie [Presentation Background](/slides/nl/net/presentation-background/) .

## **Ingebedde afbeeldingen en gekoppelde afbeeldingen**

Ingebedde en gekoppelde afbeeldingen hebben verschillende draagbaarheid‑ en bestands‑grootte‑afwegingen:

- **Ingebedde afbeelding:** de afbeeldingsgegevens worden opgeslagen binnen de presentatie. De presentatie is autonoom, maar de bestandsgrootte omvat de afbeeldingsgegevens.
- **Gekoppelde afbeelding:** de presentatie slaat een pad of URL op naar een externe afbeelding. Dit kan de presentatiegrootte verkleinen, maar de externe bron moet toegankelijk blijven wanneer de presentatie wordt geopend of gerenderd.

Een gekoppelde afbeelding kan worden gemaakt door het externe pad of de URL toe te wijzen via [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/nl/net/aspose.slides/islidespicture/linkpathlong/) in plaats van de afbeeldingsgegevens te embedden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Gebruik alleen gekoppelde afbeeldingen wanneer de implementatie‑omgeving betrouwbaar toegang heeft tot de externe bron. Voor presentaties die offline moeten werken of tussen systemen verplaatst worden, zijn ingebedde afbeeldingen doorgaans veiliger.

## **Werken met SVG‑afbeeldingen**

SVG is een vectorformaat, waardoor het nuttig kan zijn voor pictogrammen, diagrammen en andere grafische elementen die moeten schalen zonder dezelfde detail‑verliezen als rasterafbeeldingen. Aspose.Slides ondersteunt SVG zowel als een afbeeldingsresource als als bron voor bewerkbare dia‑vormen.

### **Een SVG als afbeelding toevoegen**

Maak een [SvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/svgimage/), voeg deze toe aan de afbeeldingscollectie, en plaats de resulterende afbeeldingsresource in een afbeeldingskader.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **SVG‑bestanden met externe bronnen**

Een SVG kan externe afbeeldingen, stijl‑bladen of fonts refereren. Voor deze gevallen biedt [SvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/svgimage/) constructors die een [IExternalResourceResolver](https://reference.aspose.com/slides/nl/net/aspose.slides.import/iexternalresourceresolver/) en een basis‑URI accepteren. De resolver kan een relatieve URI omzetten naar een toegestane absolute URI en een stream teruggeven voor de gevraagde bron.

De resolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt, maar hij herschrijft de SVG niet tot een autonoom document. Als de SVG draagbaar moet blijven, embed dan de vereiste bronnen in de SVG zelf, bijvoorbeeld door `data:`‑URI‘s te gebruiken voor gekoppelde afbeeldingen.

Wanneer SVG‑bestanden uit onbetrouwbare bronnen komen, beperk dan de schema’s, bestandslocaties en hosts waartoe de resolver toegang heeft. Netwerk‑resolvers moeten tevens time‑outs, limieten voor responsgrootte en content‑validatie toepassen.

### **SVG converteren naar bewerkbare vormen**

Aspose.Slides kan een SVG omzetten naar een groep bewerkbare dia‑vormen, vergelijkbaar met de overeenkomstige PowerPoint‑opdracht.

![PowerPoint Popup Menu](img_01_01.png)

Gebruik de overload van [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addgroupshape/) die een [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/) accepteert om de conversie uit te voeren.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Gebruik de SVG‑naar‑vormen‑conversie wanneer individuele vector‑elementen bewerkt moeten worden als PowerPoint‑vormen. Als de SVG alleen moet worden weergegeven, is het eenvoudiger om deze als afbeelding te behouden en vermijd je het creëren van talrijke afzonderlijke vormen.

## **Een bestaande afbeeldingsresource vervangen**

Gebruik [IPPImage.ReplaceImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/replaceimage/) wanneer u een bestaande afbeeldingsresource wilt vervangen. Dit is bijzonder nuttig voor gedeelde grafische elementen zoals logo’s.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Als meerdere afbeeldingskaders, achtergronden, masters of indelingen dezelfde afbeeldingsresource gebruiken, werkt het vervangen van die resource al die toepassingen bij. Als slechts één afbeeldingskader moet wijzigen, wijs dan een andere afbeelding toe aan dat kader in plaats van de gedeelde resource te vervangen.

`ReplaceImage` biedt ook overloads die een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) of een andere [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) accepteren.

## **Praktische richtlijnen voor afbeeldingsbeheer**

### **Presentatiegrootte beheersen**

Grote rasterafbeeldingen kunnen een presentatie onnodig groot maken. Gebruik bron‑afbeeldingen met afmetingen die passen bij de beoogde weergavegrootte, hergebruik gedeelde afbeeldingsbronnen waar mogelijk, en vermijd het insluiten van meerdere kopieën van dezelfde afbeelding met volledige resolutie.

Voor rasterafbeeldingen die al in afbeeldingskaders zijn geplaatst, kan [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/compressimage/) de afbeeldingsgegevens verkleinen op basis van de geselecteerde resolutie en bijsnijd‑instellingen. Dit is verwerking van afbeeldingskaders in plaats van beheer van de afbeeldingscollectie, zie daarom [Picture Frame](/slides/nl/net/picture-frame/) voor gerelateerde opmaakbewerkingen.

### **Kiezen tussen ingebedde en gekoppelde inhoud**

Inbedden maakt de presentatie draagbaar omdat alle benodigde afbeeldingsgegevens in het bestand zitten. Koppelen kan de bestandsgrootte verkleinen, maar introduceert een externe afhankelijkheid. Gebruik koppelingen alleen wanneer die afhankelijkheid acceptabel en stabiel is.

### **Gedeelde branding hergebruiken**

Voor terugkerende logo’s, watermerken of decoratieve grafische elementen, gebruik één afbeeldingsresource en hergebruik deze. Als het grafische element deel uitmaakt van het presentatiedesign in plaats van van de dia‑inhoud, plaats het dan op een master of indeling zodat het door de relevante dia’s wordt geërfd.

### **SVG‑bronnen draagbaar houden**

Een zelfstandig SVG‑bestand is gemakkelijker te verplaatsen en consistent te renderen dan een SVG dat afhankelijk is van externe bestanden of netwerkbronnen. Waar mogelijk embed de benodigde bronnen vóór het importeren van de SVG. Converteer SVG naar vormen alleen wanneer de individuele vector‑elementen bewerkt moeten worden.

### **De moderne, cross‑platform afbeeldings‑API gebruiken**

Voor nieuwe .NET‑code gebruikt u de Aspose.Slides‑[IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/)‑ en [Images](https://reference.aspose.com/slides/nl/net/aspose.slides/images/)‑API’s in plaats van te vertrouwen op `System.Drawing.Image` of `Bitmap`. Zie [Modern API](/slides/nl/net/modern-api/) voor migratierichtlijnen.

WMF en EMF vereisen speciale aandacht. Wanneer deze formaten via een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) worden verwerkt, converteert [ImageCollection.AddImage](https://reference.aspose.com/slides/nl/net/aspose.slides/imagecollection/addimage/) het metafile‑bestand naar een raster‑PNG‑representatie vóór invoeging. Als het behoud van de metafile‑gegevens belangrijk is, gebruik dan de stream‑gebaseerde overload van [ImageCollection.AddImage](https://reference.aspose.com/slides/nl/net/aspose.slides/imagecollection/addimage/) . Het genereren van EMF‑inhoud uit spreadsheets of andere producten is een afzonderlijke integratieworkflow en valt buiten de reikwijdte van dit artikel.

## **FAQ**

**Wat is het verschil tussen de afbeeldingscollectie en een afbeeldingskader?**

De afbeeldingscollectie slaat herbruikbare afbeeldingsbronnen op. Een afbeeldingskader is een dia‑vorm die een van die bronnen weergeeft en beeld‑specifieke opmaak biedt zoals bijsnijden en effecten.

**Wat is de beste manier om hetzelfde logo overal te vervangen?**

Als het logo al gedeeld wordt als één afbeeldingsresource, vervang die resource met [IPPImage.ReplaceImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/replaceimage/). Voor branding over de hele presentatie kan het plaatsen van het logo op een master of indeling ook duplicatie van dia‑inhoud verminderen.

**Waarom verdwijnt een gekoppelde afbeelding op een andere computer?**

Een gekoppelde afbeelding is afhankelijk van het externe bestand of de URL. Als die bron vanaf de andere computer niet bereikbaar is, kan de gekoppelde afbeelding niet worden weergegeven. Embed de afbeelding wanneer de presentatie autonoom moet zijn.

**Kan een ingevoegde SVG bewerkt worden als PowerPoint‑vormen?**

Ja. Converteer de SVG met [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addgroupshape/); de resulterende groep bevat bewerkbare dia‑vormen in plaats van één SVG‑afbeelding.

**Hoe kan ik presentaties met veel afbeeldingen kleiner houden?**

Hergebruik gedeelde afbeeldingsbronnen, vermijd onnodig grote rasterbronnen, comprimeer geschikte rasterafbeeldingen wanneer passend, plaats herhaalde branding op masters of indelingen, en gebruik alleen gekoppelde afbeeldingen wanneer een externe afhankelijkheid acceptabel is.