---
title: Képek kezelése a prezentációkban .NET-ben
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/net/image/
keywords:
- kép hozzáadása
- fotó hozzáadása
- bitmap hozzáadása
- kép cseréje
- fotó cseréje
- webről
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- külső SVG erőforrások
- SVG feloldó
- hivatkozott SVG képek
- SVG betűkészletek
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Egyszerűsítse a képek kezelését PowerPointban és OpenDocumentban az Aspose.Slides for .NET segítségével, optimalizálva a teljesítményt és automatizálva a munkafolyamatát."
---
## **Bevezetés**

A képek élénkebbé és vizuálisan vonzóbbá teszik a bemutatókat. A Microsoft PowerPointban képeket szúrhat be a diákra fájlokból, az internetről vagy egyéb forrásokból. Hasonlóan, az Aspose.Slides többféleképpen teszi lehetővé képek hozzáadását a prezentációs diákhoz.

{{% alert  title="Tipp" color="primary" %}} 
Az Aspose ingyenes konvertereket biztosít – [JPEG PowerPointra](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG PowerPointra](https://products.aspose.app/slides/hu/import/png-to-ppt) – amelyekkel gyorsan hozhat létre prezentációkat képekből. 
{{% /alert %}} 

{{% alert title="Információ" color="info" %}}
Ha képet szeretne képkockaként hozzáadni – különösen, ha át szeretné méretezni, effektusokat alkalmazna, vagy egyéb szabványos formázási lehetőségeket használna – lásd a [Képkocka](/slides/hu/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Megjegyzés" color="warning" %}}
Képeket átkonvertálhat egyik formátumból a másikba. Tekintse meg a következő oldalakat: konvertálás [kép JPG‑re](https://products.aspose.com/slides/hu/net/conversion/image-to-jpg/), [JPG‑ról képre](https://products.aspose.com/slides/hu/net/conversion/jpg-to-image/), [JPG‑ról PNG‑re](https://products.aspose.com/slides/hu/net/conversion/jpg-to-png/), [PNG‑ról JPG‑re](https://products.aspose.com/slides/hu/net/conversion/png-to-jpg/), [PNG‑ról SVG‑re](https://products.aspose.com/slides/hu/net/conversion/png-to-svg/), és [SVG‑ról PNG‑re](https://products.aspose.com/slides/hu/net/conversion/svg-to-png/). 
{{% /alert %}}

Az Aspose.Slides a népszerű formátumokban, például a JPEG, PNG, BMP, GIF és másokban támogatja a képeket. 

## **Képek hozzáadása helyben tárolt fájlokból a diákhoz**

Hozzáadhat egy vagy több, a számítógépén tárolt képet egy prezentációs diához. Az alábbi C# mintakód megmutatja, hogyan adhat hozzá egy képet a diához:

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

## **Képek hozzáadása a webről a diákhoz**

Ha a diára szeretne felvenni egy képet, amely nincs a számítógépén tárolva, közvetlenül a webről adhatja hozzá. 

Az alábbi C# mintakód megmutatja, hogyan adhat hozzá egy képet a webről a diához:

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

## **Képek hozzáadása diamesterekhez**

A diamester tárolja és vezérli az olyan információkat, mint a téma és a elrendezés a hozzá tartozó diák számára. Amikor egy képet ad hozzá egy diamesterhez, a kép minden, azon a masteren alapuló dián megjelenik. 

Az alábbi C# mintakód megmutatja, hogyan adhat hozzá egy képet egy diamasterhez:

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

## **Képek hozzáadása diákhátterekhez**

Képet használhat háttérként egy vagy több diához. A részletekért lásd a *[Képek beállítása háttérként a diákhoz](/slides/hu/net/presentation-background/#setting-images-as-background-for-slides)* című oldalról.

## **SVG hozzáadása prezentációkhoz**

Az SVG tartalmat a [SvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/svgimage/) osztállyal adhatja hozzá a prezentációhoz. A létrehozott [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) objektum ezután hozzáadható a prezentáció képgyűjteményéhez, és felhasználható képkocka létrehozásához.

Az alábbi C# példa egy önálló SVG karakterláncot importál. Az SVG összes képe, stílusa és egyéb erőforrása közvetlenül az SVG tartalomban van beágyazva.

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

## **SVG tartalom importálása külső erőforrásokkal**

A tervezőeszközök, diagramkészítők, ikonrendszerek és webes folyamatok által exportált SVG‑fájlok hivatkozhatnak olyan erőforrásokra, amelyek az SVG‑dokumentumon kívül tárolódnak. Például egy SVG tartalmazhat egy `images/photo.png` képhivatkozást, egy CSS `url(...)` értéket vagy egy betűkészlet‑URL‑t.

Az ilyen SVG‑tartalom importálásához hozzon létre egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/net/aspose.slides.import/iexternalresourceresolver/) megvalósítást, és adja át, a bázis‑URI‑val együtt, a megfelelő `SvgImage` konstruktorának. A bázis‑URI az SVG‑dokumentum helyét jelöli, és a relatív hivatkozások feloldásához szükséges.

Az [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) felület hozzáférést biztosít az importált SVG információihoz:

- `SvgContent` a SVG‑markupt adja vissza karakterláncként.
- `SvgData` a SVG‑tartalmat adja vissza bájt‑tömbként.
- `BaseUri` a relatív hivatkozásokhoz használt bázis‑URI‑t adja vissza.
- `ExternalResourceResolver` a SVG‑képhez rendelt feloldót adja vissza.

### **Külső erőforrás‑feloldó megvalósítása**

A feloldónak két metódusa van:

- [ResolveUri](https://reference.aspose.com/slides/hu/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) egyesíti a bázis‑URI‑t és egy relatív erőforrás‑hivatkozást, és abszolút URI‑t ad vissza. `null`‑t adjon vissza, ha a hivatkozást nem lehet feloldani vagy nem engedélyezett.
- [GetEntity](https://reference.aspose.com/slides/hu/net/aspose.slides.import/iexternalresourceresolver/getentity/) egy olvasható stream‑et ad vissza egy abszolút erőforrás‑URI‑hez. `null`‑t adjon vissza, ha az erőforrás hiányzik, blokkolva van, vagy nem érhető el. Ha megfelelő, egy visszaeső (fallback) stream is visszaadható.

Az alábbi feloldó csak egy engedélyezett helyi könyvtárból tölti be a hivatkozott erőforrásokat. A hálózati erőforrások és az engedélyezett könyvtáron kívüli útvonalak blokkolva vannak. Egy opcionális visszaeső kép kerül visszaadásra a feloldhatatlan képhivatkozások esetén.

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

        // Ez a feloldó szándékosan csak helyi fájlokat engedélyez.
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

        // Csak kép erőforrásokhoz használjon visszaesőt. Képfolyam visszaadása
        // hiányzó betűtípus vagy stíluslap esetén nem lenne érvényes.
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

### **Relatív erőforrások feloldása SVG‑importálás közben**

Tegyük fel, hogy a `assets/diagram.svg` egy relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi C# példa a SVG‑fájl URI‑ját adja át bázis‑URI‑ként, és egy egyéni feloldót biztosít. A feloldó a relatív képhivatkozást abszolút URI‑ra alakítja, és egy stream‑et ad vissza a hivatkozott erőforrással, miközben az Aspose.Slides feldolgozza az SVG‑t.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Az alap URI a SVG dokumentum helyét jelöli.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// Az ISvgImage a forrás tartalmat, bináris adatokat, az alap URI-t és a feloldót teszi elérhetővé.
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

A `SvgImage` osztály további túlterheléseket is kínál, amelyek SVG‑adatot bájt‑tömbként vagy stream‑ként fogadnak, külső erőforrás‑feloldóval és bázis‑URI‑val együtt.

{{% alert title="Fontos" color="warning" %}}
A feloldó elérhetővé teszi a külső erőforrásokat, amíg az Aspose.Slides feldolgozza és rendereli az SVG‑t. Nem módosítja az eredeti SVG‑markupt, és nem ágyazza be automatikusan a feloldott erőforrásokat.
Amikor egy `ISvgImage` kerül a prezentáció képgyűjteményébe, a PPTX‑fájl mind az eredeti SVG‑reprezentációt, mind egy raszter visszaeső képet tartalmazhat. Egy hivatkozott erőforrás megjelenhet a generált visszaeső képen, míg egy relatív hivatkozás, például `images/photo.png`, változatlan marad a tárolt SVG‑ben. Egy olyan alkalmazás, amely a natív SVG‑reprezentációt rendereli, ezért elhagyhatja a hivatkozott tartalmat, ha az eredeti külső erőforrás nem érhető el.
{{% /alert %}}

### **Hordozható SVG‑kép létrehozása**

Az SVG‑kép létrehozásához, amely nem függ külső fájloktól, tegye önállóvá az SVG‑t a `SvgImage` létrehozása előtt. Például cserélje le a hivatkozott kép‑URL‑ket `data:` URI‑kra, amelyek tartalmazzák a kép adatait:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután minden szükséges erőforrás be van ágyazva az SVG‑tartalomba, hozza létre a `SvgImage`‑t, adja hozzá a prezentáció képgyűjteményéhez, és szúrja be egy képkockaként, ahogy az előző példában is látható.

### **Hiányzó vagy blokkolt erőforrások kezelése**

`ResolveUri` esetén adjon vissza `null`‑t, ha az erőforrás‑URI érvénytelen, tiltott vagy nem oldható fel. `GetEntity` esetén adjon vissza `null`‑t, ha az erőforrás nem olvasható. Az Aspose.Slides a lehető legjobban folytatja az SVG feldolgozását az adott erőforrás nélkül.

Egy hiányzó erőforrásra visszaeső stream is visszaadható, de annak tartalma kompatibilis kell legyen a kért erőforrás‑típussal. Például csak képes stream‑et adjon vissza hiányzó képnél, nem betűkészlet vagy stíluslap esetén.

{{% alert title="Biztonság" color="warning" %}}
Ne oldjon fel önkényes fájlútvonalakat vagy korlátlan hálózati URL‑ket megbízhatatlan SVG‑fájlokból. Korlátozza az engedélyezett sémákat, könyvtárakat és gazdagépeket. Hálózati erőforrások esetén alkalmazzon kapcsolat‑időkorlátokat, válaszméret‑korlátokat és tartalom‑validációt.
{{% /alert %}}

## **SVG konvertálása alakzatkészletté**
Az Aspose.Slides képes egy SVG‑t alakzatkészletté konvertálni, hasonlóan a PowerPoint megfelelő funkciójához:

![PowerPoint Popup Menu](img_01_01.png)

Ez a funkcionalitás az [AddGroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/addgroupshape/methods/1) metódus egy túlterhelésén keresztül érhető el az [IShapeCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection) felületen, amely első argumentumként egy [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage) objektumot vár.

Az alábbi C# mintakód megmutatja, hogyan használja ezt a metódust egy SVG‑fájl alakzatkészletté konvertálásához:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Forrás SVG fájl neve
string svgFileName = "sample.svg";

// Kimeneti prezentáció fájl neve
string outPptxPath = "presentation.pptx";

// Új prezentáció létrehozása
using (IPresentation presentation = new Presentation())
{
    // SVG fájl tartalmának beolvasása
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage objektum létrehozása
    ISvgImage svgImage = new SvgImage(svgContent);

    // Dia méretének lekérése
    SizeF slideSize = presentation.SlideSize.Size;

    // Az SVG képet alakzatcsoporttá konvertálja és méretezi a dia méretéhez
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Prezentáció mentése PPTX formátumban
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Képek hozzáadása EMF‑ként a diákhoz**
Az Aspose.Slides for .NET lehetővé teszi EMF képek generálását Excel‑munkalapokból az Aspose.Cells használatával, majd azok diákhoz való hozzáadását.

Az alábbi C# mintakód bemutatja, hogyan valósítható ez meg:

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

    // A munkafüzet mentése egy adatfolyamba
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

## **Képek cseréje a képgyűjteményben**

Az Aspose.Slides lehetővé teszi a prezentáció képgyűjteményében tárolt képek cseréjét, beleértve a diák alakzatainak által használt képeket is. Ez a szakasz több módot mutat be a gyűjtemény frissítésére. Képet cserélhet nyers bájtadatokkal, egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) példánnyal vagy egy már létező képpel a gyűjteményben.

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó prezentációs fájlt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztállyal.
1. Töltsön be egy új képet fájlból egy bájt‑tömbbe.
1. Cserélje le a célképet az új képre a bájt‑tömb használatával.
1. A második megközelítésben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumba, és cserélje le a célképet ezzel az objektummal.
1. A harmadik megközelítésben cserélje le a célképet egy olyan képpel, amely már szerepel a prezentáció képgyűjteményében.
1. Írja ki a módosított prezentációt PPTX‑fájlként.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// A Presentation osztály példányosítása, amely egy bemutató fájlt képvisel.
using Presentation presentation = new Presentation("sample.pptx");

// Az első mód.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// A második mód.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// A harmadik mód.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Prezentáció mentése egy fájlba.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
Az Aspose ingyenes [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterével könnyedén animálhat szöveget és készíthet GIF‑eket a szövegből. 
{{% /alert %}}

## **GYIK**

**Megmarad-e az eredeti kép felbontása a beillesztés után?**

Igen. A forrás‑pixelek megmaradnak, de a végső megjelenés attól függ, hogyan van méretezve a [képkocka](/slides/hu/net/picture-frame/) a dián és milyen tömörítés történik mentéskor.

**Mi a legjobb módja annak, hogy egyszerre cseréljünk ki egy logót számos dián?**

Helyezze a logót a mester‑diára vagy egy elrendezésre, és cserélje ki a prezentáció képgyűjteményében – a frissítés minden erőforrást használó elemhez eljut.

**Átalakítható‑e egy beillesztett SVG szerkeszthető alakzatokká?**

Igen. Egy SVG‑t konvertálhat alakzatcsoporttá, amely után az egyes részek szerkeszthetőek a szokásos alakzattulajdonságokkal.

**Hogyan állíthatok be egy képet háttérként több diára egyszerre?**

[Állítsa be a képet háttérként](/slides/hu/net/presentation-background/) a mester‑dián vagy a megfelelő elrendezésen – a mester/​elrendezést használó diák öröklik a hátteret.

**Hogyan akadályozhatom meg, hogy egy prezentáció túl nagyra nő a sok kép miatt?**

Használjon egyetlen kép‑erőforrást a duplikációk helyett, válasszon megfelelő felbontást, alkalmazzon tömörítést mentéskor, és a gyakran ismétlődő grafikákat a master‑dián tartsa, ahol indokolt.