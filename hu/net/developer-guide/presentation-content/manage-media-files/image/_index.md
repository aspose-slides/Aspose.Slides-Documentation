---
title: Optimalizálja a képek kezelését prezentációkban .NET környezetben
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
- SVG betűtípusok
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Egyszerűsítse a képek kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for .NET használatával, optimalizálja a teljesítményt és automatizálja a munkafolyamatot."
---
## **Bevezetés**

A képek élénkebbé és vizuálisan vonzóbbá teszik az előadásokat. A Microsoft PowerPointban képeket szúrhat be a diákra fájlokból, az internetről vagy más forrásokból. Hasonlóan az Aspose.Slides többféleképpen is lehetővé teszi, hogy képeket adjunk hozzá az előadásdiákhoz.

{{% alert  title="Tipp" color="info" %}} 
Az Aspose ingyenes konvertereket kínál — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyekkel gyorsan létrehozhat előadásokat képekből. 
{{% /alert %}} 

{{% alert title="Információ" color="info" %}}
Ha képet szeretne képkockaként hozzáadni – különösen ha átméretezést, effektusok alkalmazását vagy más szabványos formázási lehetőségeket tervez – tekintse meg a [Picture Frame](/slides/hu/net/picture-frame/) oldalt. 
{{% /alert %}} 

{{% alert title="Megjegyzés" color="warning" %}}
Átalakíthat képeket az egyik formátumból a másikba. Lásd az alábbi oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hu/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hu/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hu/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hu/net/conversion/png-to-svg/), és [SVG to PNG](https://products.aspose.com/slides/hu/net/conversion/svg-to-png/).
{{% /alert %}}

Az Aspose.Slides támogatja a népszerű képtípusokat, mint a JPEG, PNG, BMP, GIF és egyebek. 

## **Képek hozzáadása helyi tárolásból a diákhoz**

Képet vagy több képet adhat hozzá a számítógépén tárolt prezentációs diára. Az alábbi C# mintakód megmutatja, hogyan adhat hozzá egy képet egy diához:

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

Ha a diához hozzáadni kívánt kép nincs a számítógépén, közvetlenül a webről is hozzáadhatja.

Az alábbi C# mintakód megmutatja, hogyan adhat hozzá egy képet a webről egy diához:

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

## **Képek hozzáadása diamesterhez**

A diamester tárolja és szabályozza a témához és az elrendezéshez kapcsolódó információkat azok számára, akik ezt a mestert használják. Ha képet ad hozzá egy diamesterhez, a kép megjelenik minden, a mestert használó dián.

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

## **Képek hozzáadása diák háttérként**

Használhat képet egy vagy több dia háttérként. További részletekért lásd a *[Setting Images as Backgrounds for Slides](/slides/hu/net/presentation-background/#setting-images-as-background-for-slides)* oldalt.

## **SVG hozzáadása az előadásokhoz**

Az SVG tartalmat a [SvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/svgimage/) osztállyal adhatja hozzá egy prezentációhoz. A kapott [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) objektum ezután hozzáadható a prezentáció képgyűjteményéhez, és használható képkocka létrehozásához.

Az alábbi C# példa egy önmagában álló SVG sztringet importál. Az SVG által használt összes kép, stílus és egyéb erőforrás közvetlenül az SVG tartalomba van beágyazva.

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

A tervezőeszközök, diagramkészítők, ikonrendszerek és webes csővezetékek által exportált SVG fájlok hivatkozhatnak a SVG dokumentumon kívül tárolt erőforrásokra. Például egy SVG tartalmazhat egy képhivatkozást, mint például `images/photo.png`, egy CSS `url(...)` értéket vagy egy betűtípus URL-t.

Az ilyen SVG tartalom importálásához hozza létre egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/net/aspose.slides.import/iexternalresourceresolver/) implementációt, és adja át azt a bázis‑URI‑val együtt a megfelelő `SvgImage` konstruktorának. A bázis‑URI azonosítja az SVG dokumentum helyét, és a relatív hivatkozások feloldásához használatos.

Az [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/) interfész hozzáférést biztosít az importált SVG információihoz:

- `SvgContent` visszaadja az SVG jelölőnyelvet sztringként.
- `SvgData` visszaadja az SVG tartalmat bájt‑tömbként.
- `BaseUri` visszaadja a relatív hivatkozásokhoz használt bázis‑URI‑t.
- `ExternalResourceResolver` visszaadja az SVG képhez rendelt feloldót.

### **Külső erőforrás feloldó megvalósítása**

A feloldónak két metódusa van:

- [ResolveUri](https://reference.aspose.com/slides/hu/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) egyesíti a bázis‑URI‑t és egy relatív erőforrás‑hivatkozást, és abszolút URI‑t ad vissza. Ha a hivatkozást nem lehet feloldani vagy nem engedélyezett, `null`‑t kell visszaadni.
- [GetEntity](https://reference.aspose.com/slides/hu/net/aspose.slides.import/iexternalresourceresolver/getentity/) egy olvasható adatfolyamot ad vissza egy abszolút erőforrás‑URI‑hez. Ha az erőforrás hiányzik, blokkolva van vagy nem érhető el, `null`‑t kell visszaadni. Megfelelő esetben egy tartalék (fallback) adatfolyam is visszaadható.

Az alábbi feloldó csak az engedélyezett helyi könyvtárból tölti be a hivatkozott erőforrásokat. Hálózati erőforrások és az engedélyezett könyvtáron kívüli útvonalak blokkolva vannak. Feloldhatatlan képhivatkozások esetén egy opcionális tartalék kép kerül visszaadásra.

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

        // Csak képfájl erőforrásokhoz használjon tartalékot. Képadatfolyam visszaadása
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

### **Hivatkozott erőforrások feloldása SVG importáláskor**

Tegyük fel, hogy a `assets/diagram.svg` egy relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi C# példa a SVG fájl URI‑ját bázis‑URI‑ként adja át, és egy egyedi feloldót biztosít. A feloldó a relatív képhivatkozást abszolút URI‑vá alakítja, és egy olyan adatfolyamot ad vissza, amely a hivatkozott erőforrást tartalmazza, miközben az Aspose.Slides feldolgozza az SVG‑t.

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

// Az ISvgImage a forrás tartalmat, bináris adatot, alap URI-t és a feloldót teszi elérhetővé.
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

A `SvgImage` osztály további túlterheléseket is kínál, amelyek SVG adatot bájt‑tömbként vagy adatfolyamként fogadnak, valamint egy külső erőforrás‑feloldót és egy bázis‑URI‑t.

{{% alert title="Fontos" color="warning" %}}
A erőforrás‑feloldó külső erőforrásokat tesz elérhetővé, amíg az Aspose.Slides feldolgozza és megjeleníti az SVG‑t. Nem módosítja az eredeti SVG jelölőnyelvet, és nem ágyazza be automatikusan a feloldott erőforrásokat.
Amikor egy `ISvgImage` kerül a prezentáció képgyűjteményébe, a PPTX fájl tartalmazhatja az eredeti SVG ábrázolást és egy raszteres tartalék képet is. Egy hivatkozott erőforrás megjelenhet a generált tartalék képen, míg egy relatív hivatkozás, mint például `images/photo.png`, változatlan marad a tárolt SVG‑ben. A natív SVG ábrázolást renderelő alkalmazás ezért elhagyhatja a hivatkozott tartalmat, ha az eredeti külső erőforrás nem érhető el.
{{% /alert %}}

### **Hordozható SVG kép létrehozása**

Ahhoz, hogy olyan SVG képet hozzon létre, amely nem függ külső fájloktól, a `SvgImage` létrehozása előtt tegye az SVG‑t önmagában állóvá. Például cserélje le a hivatkozott képek URL‑jeit `data:` URI‑kra, amelyek a képadatot tartalmazzák:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután minden szükséges erőforrást beágyazott az SVG tartalomba, hozza létre a `SvgImage`‑t, adja hozzá a prezentáció képgyűjteményéhez, és szúrja be egy képkockába, ahogyan az előző példában is látható.

### **Hiányzó vagy blokkolt erőforrások kezelése**

`ResolveUri`‑ból térjen vissza `null`‑lal, ha az erőforrás‑URI érvénytelen, tiltott vagy nem oldható fel. `GetEntity`‑ből térjen vissza `null`‑lal, ha az erőforrás nem olvasható. Az Aspose.Slides lehetőleg a hiányzó erőforrás nélkül folytatja az SVG feldolgozását.
Hiányzó erőforrás esetén visszaadható egy tartalék adatfolyam, de annak tartalma kompatibilis kell legyen a kért erőforrás típussal. Például csak képadatfolyamot adjon vissza hiányzó kép esetén, betűtípus vagy stíluslap esetén ne.

{{% alert title="Biztonság" color="warning" %}}
Ne oldjon fel tetszőleges fájlutakat vagy korlátlan hálózati URL‑eket megbízhatatlan SVG fájlokból. Szűkítse a megengedett séma‑kat, könyvtárakat és hostokat. Hálózati erőforrások esetén alkalmazzon kapcsolati időkorlátokat, válaszméret‑korlátokat és tartalomvalidációt.
{{% /alert %}}

## **SVG átalakítása alakzatkészletté**
Az Aspose.Slides képes egy SVG‑t alakzatkészletté alakítani, hasonlóan a PowerPoint megfelelő funkciójához:

![PowerPoint Popup Menu](img_01_01.png)

Ez a funkcionalitás egy [AddGroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/addgroupshape/methods/1) metódus túlterhelésén keresztül érhető el, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection) interfész része, és első argumentumként egy [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage) objektumot vár.

Az alábbi C# mintakód megmutatja, hogyan használja ezt a metódust egy SVG fájl alakzatkészletté konvertálásához:

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
    // Olvassa be az SVG fájl tartalmát
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage objektum létrehozása
    ISvgImage svgImage = new SvgImage(svgContent);

    // Dia méretének lekérése
    SizeF slideSize = presentation.SlideSize.Size;

    // Az SVG képet alakzatcsoporttá konvertálja és a dia méretéhez méretezze
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // A prezentáció mentése PPTX formátumban
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Képek hozzáadása EMF‑ként a diákhoz**
Az Aspose.Slides for .NET lehetővé teszi, hogy EMF képeket generáljon Excel munkalapokból az Aspose.Cells segítségével, és ezeket a prezentációs diákra helyezze.

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

    // A munkafüzet mentése egy adatfolyamra
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

Az Aspose.Slides lehetővé teszi, hogy a prezentáció képgyűjteményében tárolt képeket, beleértve a diaelemek által használtakat, cserélje. Ez a szakasz több módszert ismertet a képek frissítésére a gyűjteményben. Képet cserélhet nyers bájtadatokkal, egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) példánnyal vagy egy már a gyűjteményben létező képpel.

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó prezentációfájlt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztállyal.  
2. Töltsön be egy új képet egy fájlból egy bájt tömbbe.  
3. Cserélje le a célképet az új képre a bájt tömb használatával.  
4. A második módszernél töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumba, és cserélje le a célképet ezzel az objektummal.  
5. A harmadik módszernél cserélje le a célképet egy olyan képre, amely már létezik a prezentáció képgyűjteményében.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy Presentation osztály példányt, amely egy prezentációs fájlt képvisel.
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

// A prezentáció mentése egy fájlba.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Információ" color="info" %}}
Az Aspose ingyenes [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterével könnyedén animálhat szöveget és GIF‑eket hozhat létre szövegből. 
{{% /alert %}}

## **GYIK**

**Megmarad-e az eredeti képfelbontás a beszúrás után?**  
Igen. A forrás‑pixeladatok megmaradnak, de a végső megjelenés attól függ, hogyan van a [picture](/slides/hu/net/picture-frame/) méretezve a dián és milyen tömörítés kerül alkalmazásra mentéskor.

**Mi a legjobb módja egy logó egyszerre több tucat diasoron történő cseréjének?**  
Helyezze a logót a mesterdiára vagy egy elrendezésre, és cserélje a prezentáció képgyűjteményében – a frissítés minden olyan elemre kiterjed, amely azt a forrást használja.

**Átalakítható-e a beillesztett SVG szerkeszthető alakzatokká?**  
Igen. Az SVG‑t konvertálhatja alakzatcsoporttá, ezután az egyes részek szerkeszthetőek lesznek a szokásos alakzattulajdonságokkal.

**Hogyan állíthatok be egy képet háttérként egyszerre több dia számára?**  
A képet állítsa be háttérnek a mesterdián vagy a megfelelő elrendezésen ([Assign the image as the background](/slides/hu/net/presentation-background/)). Az ezt a mestert/elrendezést használó diák öröklik a hátteret.

**Hogyan akadályozhatom meg, hogy egy prezentáció túl nagyra nő a sok kép miatt?**  
Használjon egyetlen képforrást a másolatok helyett, válasszon megfelelő felbontást, alkalmazzon tömörítést mentéskor, és ahol lehetséges, tartsa az ismétlődő grafikákat a mesterben.