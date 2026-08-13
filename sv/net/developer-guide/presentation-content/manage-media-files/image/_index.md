---
title: Optimera bildhantering i presentationer i .NET
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/net/image/
keywords:
- lägg till bild
- lägg till bild
- lägg till bitmap
- ersätt bild
- ersätt bild
- från webben
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- externa SVG-resurser
- SVG-resolver
- länkade SVG-bilder
- SVG-typsnitt
- lägg till EMF
- lägg till WMF
- lägg till TIFF
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Förenkla bildhantering i PowerPoint och OpenDocument med Aspose.Slides för .NET, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och visuellt tilltalande. I Microsoft PowerPoint kan du infoga bilder på bilderna från filer, internet eller andra källor. På samma sätt låter Aspose.Slides dig lägga till bilder i presentationsbilder på flera sätt.

{{% alert title="Tips" color="info" %}} 
Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter dig snabbt skapa presentationer från bilder. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Om du vill lägga till en bild som en bildram—särskilt om du planerar att ändra storlek, applicera effekter eller använda andra standardformateringsalternativ—se [Bildram](/slides/sv/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Obs" color="warning" %}}
Du kan konvertera bilder från ett format till ett annat. Se följande sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/net/conversion/image-to-jpg/), [JPG till bild](https://products.aspose.com/slides/sv/net/conversion/jpg-to-image/), [JPG till PNG](https://products.aspose.com/slides/sv/net/conversion/jpg-to-png/), [PNG till JPG](https://products.aspose.com/slides/sv/net/conversion/png-to-jpg/), [PNG till SVG](https://products.aspose.com/slides/sv/net/conversion/png-to-svg/), och [SVG till PNG](https://products.aspose.com/slides/sv/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides stöder bilder i populära format såsom JPEG, PNG, BMP, GIF och andra. 

## **Lägg till lokalt lagrade bilder på bilder**

Du kan lägga till en eller flera bilder som är lagrade på din dator på en presentationsbild. Följande C#‑exempelkod visar hur du lägger till en bild på en bild:

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

## **Lägg till bilder från webben på bilder**

Om bilden du vill lägga till på en bild inte är lagrad på din dator kan du lägga till den direkt från webben. 

Följande C#‑exempelkod visar hur du lägger till en bild från webben på en bild:

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

## **Lägg till bilder på bildmaster**

En bildmaster lagrar och styr information såsom tema och layout för de bilder som använder den. När du lägger till en bild på en bildmaster visas bilden på varje bild som baseras på den mastern. 

Följande C#‑exempelkod visar hur du lägger till en bild på en bildmaster:

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

## **Lägg till bilder som bildbakgrunder**

Du kan använda en bild som bakgrund för en eller flera bilder. För detaljer, se *[Ställa in bilder som bakgrunder för bilder](/slides/sv/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägg till SVG i presentationer**

SVG‑innehåll kan läggas till i en presentation med klassen [SvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/svgimage/). Det resulterande [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/)-objektet kan sedan läggas till i presentationens bildsamling och användas för att skapa en bildram.

Följande C#‑exempel importerar en självständig SVG‑sträng. Alla bilder, stilar och andra resurser som används av denna SVG är inbäddade direkt i SVG‑innehållet.

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

## **Importera SVG‑innehåll med externa resurser**

SVG‑filer som exporteras från designverktyg, diagramredigerare, ikonsystem och webbpipelines kan referera till resurser som lagras utanför SVG‑dokumentet. Till exempel kan en SVG innehålla en bildlänk såsom `images/photo.png`, ett CSS‑`url(...)`‑värde eller en teckensnittslänk.

För att importera sådant SVG‑innehåll, skapa en implementation av [IExternalResourceResolver](https://reference.aspose.com/slides/sv/net/aspose.slides.import/iexternalresourceresolver/) och skicka den, tillsammans med en bas‑URI, till en lämplig `SvgImage`‑konstruktor. Bas‑URI identifierar platsen för SVG‑dokumentet och används för att lösa relativa länkar.

Gränssnittet [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/) ger åtkomst till information om den importerade SVG‑filen:

- `SvgContent` returnerar SVG‑markup som en sträng.
- `SvgData` returnerar SVG‑innehållet som en byte‑array.
- `BaseUri` returnerar bas‑URI:n som används för relativa länkar.
- `ExternalResourceResolver` returnerar den resolver som tilldelats SVG‑bilden.

### **Implementera en extern resurshanterare**

Resolvern har två metoder:

- [ResolveUri](https://reference.aspose.com/slides/sv/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) kombinerar bas‑URI:n och en relativ resursslänk och returnerar en absolut URI. Returnera `null` när länken inte kan lösas eller inte är tillåten.
- [GetEntity](https://reference.aspose.com/slides/sv/net/aspose.slides.import/iexternalresourceresolver/getentity/) returnerar en läsbar ström för en absolut resurspost. Returnera `null` när resursen saknas, blockeras eller är otillgänglig. En reservström kan också returneras när så är lämpligt.

Följande resolver laddar länkade resurser endast från en tillåten lokal katalog. Nätverksresurser och sökvägar utanför den tillåtna katalogen blockeras. En valfri reservbild returneras för olösta bildlänkar.

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

        // Denna resolver tillåter avsiktligt endast lokala filer.
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

        // Använd en reserv endast för bildresurser. Att returnera en bildström
        // för ett saknat teckensnitt eller en stilmall skulle inte vara giltigt.
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

### **Lös länkade resurser under SVG‑import**

Anta att `assets/diagram.svg` innehåller en relativ referens som:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Följande C#‑exempel skickar SVG‑filens URI som bas‑URI och tillhandahåller en anpassad resolver. Resolvern konverterar den relativa bildlänken till en absolut URI och returnerar en ström som innehåller den länkade resursen medan Aspose.Slides bearbetar SVG‑filen.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Bas‑URI:n representerar platsen för SVG‑dokumentet.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage visar källinnehållet, binära data, bas‑URI och resolvern.
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

Klassen `SvgImage` erbjuder också överlagringar som accepterar SVG‑data som en byte‑array eller en ström, tillsammans med en extern resurshanterare och en bas‑URI.

{{% alert title="Viktigt" color="warning" %}}
Resurshanteraren gör externa resurser tillgängliga medan Aspose.Slides bearbetar och renderar SVG‑filen. Den modifierar inte den ursprungliga SVG‑markupen eller inbäddar automatiskt de lösta resurserna i den.

När ett `ISvgImage` läggs till i presentationens bildsamling kan PPTX‑filen innehålla både den ursprungliga SVG‑representationen och en raster‑reservbild. En länkad resurs kan visas i den genererade reservbilden medan en relativ länk som `images/photo.png` förblir oförändrad i den lagrade SVG‑filen. En applikation som renderar den inhemska SVG‑representationen kan därför utelämna det länkade innehållet när den ursprungliga externa resursen är otillgänglig.
{{% /alert %}}

### **Skapa en portabel SVG‑bild**

För att skapa en SVG‑bild som inte är beroende av externa filer, gör SVG‑filen självständig innan du skapar `SvgImage`. Till exempel, ersätt länkade bild‑URL:er med `data:`‑URI:er som innehåller bilddata:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

När alla erforderliga resurser är inbäddade i SVG‑innehållet, skapa `SvgImage`, lägg till den i presentationens bildsamling och infoga den i en bildram som i föregående exempel.

### **Hantera saknade eller blockerade resurser**

Returnera `null` från `ResolveUri` när en resurs‑URI är ogiltig, förbjuden eller inte kan lösas. Returnera `null` från `GetEntity` när resursen inte kan läsas. Aspose.Slides fortsätter att bearbeta SVG‑filen utan den resursen när det är möjligt.

En reservström kan returneras för en saknad resurs, men dess innehåll måste vara kompatibelt med den begärda resurstypen. Till exempel, returnera en bildström endast för en saknad bild, inte för ett teckensnitt eller en stilmall.

{{% alert title="Säkerhet" color="warning" %}}
Lös inte godtyckliga filsökvägar eller obegränsade nätverks‑URL:er från opålitliga SVG‑filer. Begränsa tillåtna scheman, kataloger och värdar. För nätverksresurser, tillämpa även tidsgränser för anslutning, begränsningar för svarsstorlek och validering av innehåll.
{{% /alert %}}

## **Konvertera SVG till en uppsättning former**
Aspose.Slides kan konvertera en SVG till en uppsättning former, liknande motsvarande funktionalitet i PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Denna funktionalitet tillhandahålls av en överlagring av metoden [AddGroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/addgroupshape/methods/1) på gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection) som tar ett [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage)‑objekt som första argument.

Följande C#‑exempelkod visar hur du använder denna metod för att konvertera en SVG‑fil till en uppsättning former:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// SVG-filens namn
string svgFileName = "sample.svg";

// Presentationens utfilnamn
string outPptxPath = "presentation.pptx";

// Skapa en ny presentation
using (IPresentation presentation = new Presentation())
{
    // Läs SVG-filens innehåll
    string svgContent = File.ReadAllText(svgFileName);

    // Skapa ett SvgImage-objekt
    ISvgImage svgImage = new SvgImage(svgContent);

    // Hämta bildstorleken
    SizeF slideSize = presentation.SlideSize.Size;

    // Konvertera SVG-bilden till en grupp former och skala den till bildens storlek
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Spara presentationen i PPTX-format
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Lägg till bilder som EMF på bilder**
Aspose.Slides för .NET låter dig generera EMF‑bilder från Excel‑arbetsblad med Aspose.Cells och lägga till dem i presentationsbilder.

Följande C#‑exempelkod visar hur du gör detta:

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

    // Spara arbetsboken till en ström
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

## **Byt ut bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling, inklusive bilder som används av bildformer. Detta avsnitt beskriver flera sätt att uppdatera bilder i samlingen. Du kan ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)-instans, eller en annan bild som redan finns i samlingen.

Följ stegen nedan:

1. Ladda presentationsfilen som innehåller bilder med klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Ladda en ny bild från en fil till en byte‑array.
1. Ersätt mål‑bilden med den nya bilden med hjälp av byte‑arrayen.
1. I det andra tillvägagångssättet, ladda bilden i ett [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)-objekt och ersätt mål‑bilden med det objektet.
1. I det tredje tillvägagångssättet, ersätt mål‑bilden med en bild som redan finns i presentationens bildsamling.
1. Skriv den modifierade presentationen som en PPTX‑fil.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Skapa ett Presentation-objekt som representerar en presentationsfil.
using Presentation presentation = new Presentation("sample.pptx");

// Första sättet.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Andra sättet.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Tredje sättet.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Spara presentationen till en fil.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
Med Asposes gratis [Text till GIF](https://products.aspose.app/slides/sv/text-to-gif)-konverterare kan du enkelt animera text och skapa GIF‑filer från text. 
{{% /alert %}}

## **FAQ**

**Förblir originalbildens upplösning intakt efter infogning?**

Ja. Källpixlarna bevaras, men det slutliga utseendet beror på hur [bilden](/slides/sv/net/picture-frame/) skalas på bilden och eventuell komprimering vid sparning.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder samtidigt?**

Placera logotypen på master‑bilden eller en layout och ersätt den i presentationens bildsamling—uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp former, varpå enskilda delar blir redigerbara med vanliga formegenskaper.

**Hur kan jag ange en bild som bakgrund för flera bilder på en gång?**

[Tilldela bilden som bakgrund](/slides/sv/net/presentation-background/) på master‑bilden eller den relevanta layouten—alla bilder som använder den master/layouten ärver bakgrunden.

**Hur förhindrar jag att en presentation blir för stor på grund av många bilder?**

Återanvänd en enda bildresurs istället för dubbletter, välj rimliga upplösningar, applicera komprimering vid sparning och håll återkommande grafik på master‑nivån där det är lämpligt.