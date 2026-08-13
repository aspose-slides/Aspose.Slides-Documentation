---
title: "Afbeeldingsbeheer in presentaties optimaliseren in .NET"
linktitle: "Afbeeldingen beheren"
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
- externe SVG‑bronnen
- SVG‑resolver
- gelinkte SVG‑afbeeldingen
- SVG‑lettertypen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Versnel het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor .NET, optimaliseer de prestaties en automatiseer je werkstroom."
---
## **Introductie**

Afbeeldingen maken presentaties boeiender en visueel aantrekkelijker. In Microsoft PowerPoint kun je afbeeldingen op dia's invoegen vanuit bestanden, internet of andere bronnen. Op dezelfde manier maakt Aspose.Slides het mogelijk om afbeeldingen aan presentatiedia's toe te voegen op verschillende manieren.

{{% alert  title="Tip" color="info" %}} 
Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die je in staat stellen snel presentaties te maken van afbeeldingen. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Als je een afbeelding wilt toevoegen als afbeeldingskader—vooral als je van plan bent deze te vergroten/verkleinen, effecten toe te passen of andere standaardopmaakopties te gebruiken—zie [Afbeeldingskader](/slides/nl/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Je kunt afbeeldingen van het ene naar het andere formaat converteren. Zie de volgende pagina's: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/net/conversion/image-to-jpg/), [JPG naar afbeelding](https://products.aspose.com/slides/nl/net/conversion/jpg-to-image/), [JPG naar PNG](https://products.aspose.com/slides/nl/net/conversion/jpg-to-png/), [PNG naar JPG](https://products.aspose.com/slides/nl/net/conversion/png-to-jpg/), [PNG naar SVG](https://products.aspose.com/slides/nl/net/conversion/png-to-svg/), en [SVG naar PNG](https://products.aspose.com/slides/nl/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides ondersteunt afbeeldingen in populaire formaten zoals JPEG, PNG, BMP, GIF en andere. 

## **Afbeeldingen die lokaal zijn opgeslagen toevoegen aan dia's**

Je kunt een of meer afbeeldingen die op je computer zijn opgeslagen toevoegen aan een presentatiedia. De volgende C#-voorbeeldcode laat zien hoe je een afbeelding aan een dia toevoegt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Afbeeldingen van het web aan dia's toevoegen**

Als de afbeelding die je aan een dia wilt toevoegen niet op je computer is opgeslagen, kun je deze direct van het web toevoegen. 

De volgende C#-voorbeeldcode toont hoe je een afbeelding van het web aan een dia toevoegt:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Een dia‑master slaat informatie op en beheert zaken zoals het thema en de lay‑out voor de dia's die de master gebruiken. Wanneer je een afbeelding aan een dia‑master toevoegt, verschijnt de afbeelding op elke dia die op die master is gebaseerd. 

De volgende C#‑voorbeeldcode laat zien hoe je een afbeelding aan een dia‑master toevoegt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Je kunt een afbeelding gebruiken als achtergrond voor één of meerdere dia's. Voor details, zie *[Afbeeldingen instellen als achtergrond voor dia's](/slides/nl/net/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG toevoegen aan presentaties**

SVG-inhoud kan aan een presentatie worden toegevoegd met behulp van de klasse [SvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/svgimage/). Het resulterende [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/)-object kan vervolgens worden toegevoegd aan de afbeeldingscollectie van de presentatie en worden gebruikt om een afbeeldingskader te maken.

Het volgende C#‑voorbeeld importeert een zelfstandige SVG‑string. Alle afbeeldingen, stijlen en andere bronnen die door deze SVG worden gebruikt, worden rechtstreeks in de SVG‑inhoud ingebed.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **SVG-inhoud importeren met externe bronnen**

SVG‑bestanden die uit ontwerptools, diagrameditoren, icoonsystemen en web‑pijplijnen zijn geëxporteerd, kunnen verwijzen naar bronnen die buiten het SVG‑document zijn opgeslagen. Bijvoorbeeld kan een SVG een afbeeldingslink bevatten zoals `images/photo.png`, een CSS‑`url(...)`‑waarde of een lettertype‑URL.

Om dergelijke SVG‑inhoud te importeren, maak je een implementatie van [IExternalResourceResolver](https://reference.aspose.com/slides/nl/net/aspose.slides.import/iexternalresourceresolver/) aan en geef je deze, samen met een basis‑URI, door aan een geschikt `SvgImage`‑constructor. De basis‑URI identificeert de locatie van het SVG‑document en wordt gebruikt om relatieve koppelingen op te lossen.

De interface [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage/) biedt toegang tot informatie over de geïmporteerde SVG:

- `SvgContent` retourneert de SVG‑markup als een string.
- `SvgData` retourneert de SVG‑inhoud als een byte‑array.
- `BaseUri` retourneert de basis‑URI die wordt gebruikt voor relatieve links.
- `ExternalResourceResolver` retourneert de resolver die aan de SVG‑afbeelding is toegewezen.

### **Implementeer een externe resource‑resolver**

De resolver heeft twee methoden:

- `ResolveUri` combineert de basis‑URI en een relatieve resource‑link en retourneert een absolute URI. Retourneer `null` wanneer de link niet kan worden opgelost of niet is toegestaan.
- `GetEntity` retourneert een leesbare stream voor een absolute resource‑URI. Retourneer `null` wanneer de bron ontbreekt, geblokkeerd of niet beschikbaar is. Een fallback‑stream kan ook worden geretourneerd wanneer dat passend is.

De volgende resolver laadt gekoppelde bronnen alleen vanuit een toegestane lokale map. Netwerkbronnen en paden buiten de toegestane map worden geblokkeerd. Een optionele fallback‑afbeelding wordt geretourneerd voor niet‑opgeloste afbeeldingslinks.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Deze resolver staat opzettelijk alleen lokale bestanden toe.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Gebruik alleen een fallback voor afbeeldingsbronnen. Het retourneren van een afbeeldingsstream
        // voor een ontbrekend lettertype of stylesheet zou niet geldig zijn.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Gekoppelde bronnen oplossen tijdens SVG‑import**

Stel dat `assets/diagram.svg` een relatieve verwijzing bevat zoals:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Het volgende C#‑voorbeeld geeft de SVG‑bestands‑URI door als basis‑URI en levert een aangepaste resolver. De resolver zet de relatieve afbeeldingslink om in een absolute URI en retourneert een stream die de gekoppelde bron bevat terwijl Aspose.Slides de SVG verwerkt.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// De basis-URI geeft de locatie van het SVG-document weer.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

De klasse `SvgImage` biedt ook overloads die SVG‑gegevens accepteren als een byte‑array of een stream, samen met een externe resource‑resolver en een basis‑URI.

{{% alert title="Important" color="warning" %}}
De resource‑resolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt en rendert. Hij wijzigt de oorspronkelijke SVG‑markup niet en embed niet automatisch de opgeloste bronnen erin.

Wanneer een `ISvgImage` wordt toegevoegd aan de afbeeldingscollectie van de presentatie, kan het PPTX‑bestand zowel de oorspronkelijke SVG‑representatie als een raster‑fallback‑afbeelding bevatten. Een gekoppelde bron kan verschijnen in de gegenereerde fallback‑afbeelding terwijl een relatieve link zoals `images/photo.png` onveranderd blijft in de opgeslagen SVG. Een applicatie die de native SVG‑representatie rendert, kan daarom de gekoppelde inhoud weglaten wanneer de oorspronkelijke externe bron niet beschikbaar is.
{{% /alert %}}

### **Maak een draagbare SVG‑afbeelding**

Om een SVG‑afbeelding te maken die niet afhankelijk is van externe bestanden, maak je de SVG zelf‑containend vóór het aanmaken van de `SvgImage`. Vervang bijvoorbeeld gekoppelde afbeelding‑URL’s door `data:`‑URI’s die de afbeeldingsgegevens bevatten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nadat alle benodigde bronnen in de SVG‑inhoud zijn ingebed, maak je de `SvgImage`, voeg je deze toe aan de afbeeldingscollectie van de presentatie, en voeg je deze in een afbeeldingskader in zoals getoond in het vorige voorbeeld.

### **Afhandelen van ontbrekende of geblokkeerde bronnen**

Retourneer `null` vanuit `ResolveUri` wanneer een resource‑URI ongeldig, verboden of niet kan worden opgelost. Retourneer `null` vanuit `GetEntity` wanneer de bron niet gelezen kan worden. Aspose.Slides blijft de SVG verwerken zonder die bron wanneer mogelijk.

Een fallback‑stream kan worden geretourneerd voor een ontbrekende bron, maar de inhoud moet compatibel zijn met het gevraagde resourcetype. Retourneer bijvoorbeeld alleen een afbeeldingsstream voor een ontbrekende afbeelding, niet voor een lettertype of stylesheet.

{{% alert title="Security" color="warning" %}}
Los geen willekeurige bestandspaden of onbeperkte netwerk‑URL’s op uit onbetrouwbare SVG‑bestanden. Beperk de toegestane schema’s, mappen en hosts. Voor netwerkbronnen moet je ook verbindings‑time‑outs, limieten voor de responsgrootte en inhoudsvalidatie toepassen.
{{% /alert %}}

## **SVG omzetten naar een set vormen**

Aspose.Slides kan een SVG omzetten in een set vormen, vergelijkbaar met de overeenkomstige functionaliteit in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Deze functionaliteit wordt geleverd door een overload van de [AddGroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/addgroupshape/methods/1)-methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection)-interface die een [ISvgImage](https://reference.aspose.com/slides/nl/net/aspose.slides/isvgimage)-object als eerste argument neemt.

De volgende C#‑voorbeeldcode laat zien hoe je deze methode gebruikt om een SVG‑bestand om te zetten in een set vormen:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Bron‑SVG‑bestandnaam
string svgFileName = "sample.svg";

// Uitvoer‑presentatie‑bestandsnaam
string outPptxPath = "presentation.pptx";

// Maak een nieuwe presentatie
using (IPresentation presentation = new Presentation())
{
    // Lees de SVG‑bestandsinhoud
    string svgContent = File.ReadAllText(svgFileName);

    // Maak een SvgImage‑object
    ISvgImage svgImage = new SvgImage(svgContent);

    // Haal de dia‑grootte op
    SizeF slideSize = presentation.SlideSize.Size;

    // Converteer de SVG‑afbeelding naar een groep vormen en schaal deze naar de dia‑grootte
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Sla de presentatie op in PPTX‑formaat
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Afbeeldingen als EMF aan dia's toevoegen**

Aspose.Slides for .NET stelt je in staat om EMF‑afbeeldingen te genereren uit Excel-werkbladen met Aspose.Cells en deze toe te voegen aan presentatiedia's.

De volgende C#‑voorbeeldcode laat zien hoe je dit doet:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Sla het werkboek op naar een stream
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Afbeeldingen in de afbeeldingscollectie vervangen**

Aspose.Slides laat je afbeeldingen die zijn opgeslagen in de afbeeldingscollectie van een presentatie vervangen, inclusief afbeeldingen die door dia‑vormen worden gebruikt. Deze sectie beschrijft verschillende manieren om afbeeldingen in de collectie bij te werken. Je kunt een afbeelding vervangen met ruwe byte‑data, een [IImage]-instantie, of een andere afbeelding die al in de collectie bestaat.

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de [Presentation]-klasse.  
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.  
3. Vervang de doelafbeelding door de nieuwe afbeelding met behulp van de byte‑array.  
4. In de tweede aanpak laad je de afbeelding in een [IImage]-object en vervang je de doelafbeelding door dat object.  
5. In de derde aanpak vervang je de doelafbeelding door een afbeelding die al in de afbeeldingscollectie van de presentatie bestaat.  
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation‑klasse die een presentatiebestand vertegenwoordigt.
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
Met Aspose's gratis [Text naar GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter kun je eenvoudig tekst animeren en GIF‑bestanden van tekst maken. 
{{% /alert %}}

## **FAQ**

**Blijft de originele resolutie van de afbeelding na invoegen behouden?**

Ja. De bronpixels worden bewaard, maar het uiteindelijke uiterlijk hangt af van hoe de [afbeelding](/slides/nl/net/picture-frame/) op de dia wordt geschaald en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's tegelijk te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingscollectie van de presentatie — updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden omgezet in bewerkbare vormen?**

Ja. Je kunt een SVG omzetten in een groep vormen, waarna individuele delen bewerkbaar zijn met standaard vorm‑eigenschappen.

**Hoe kan ik een afbeelding instellen als achtergrond voor meerdere dia's tegelijk?**

[Ken de afbeelding toe als achtergrond](/slides/nl/net/presentation-background/) op de master‑dia of de betreffende lay‑out — alle dia's die die master/lay‑out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat een presentatie te groot wordt door veel afbeeldingen?**

Herbruik één afbeelding in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en bewaar herhaalde afbeeldingen op de master waar dit gepast is.