---
title: Képek kezelésének optimalizálása a bemutatókban .NET-ben
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
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Egyszerűsítse a képek kezelését PowerPointban és OpenDocumentben az Aspose.Slides for .NET segítségével, optimalizálja a teljesítményt és automatizálja a munkafolyamatát."
---
## **Bevezetés**

A képek élőbbé és érdekesebbé teszik a bemutatókat. A Microsoft PowerPointban képeket szúrhat be fájlból, az internetről vagy más helyekről a diákra. Hasonlóképpen, az Aspose.Slides lehetővé teszi, hogy különböző módokon képeket adjon a diákhoz a bemutatójában.

{{% alert  title="Tipp" color="primary" %}} 

Az Aspose ingyenes konvertereket biztosít — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyek lehetővé teszik, hogy gyorsan bemutatókat készítsen képekből. 

{{% /alert %}} 

{{% alert title="Információ" color="info" %}}

Ha képet szeretne keretobjektumként hozzáadni — különösen ha szabványos formázási beállításokat szeretne használni a méretének módosításához, effektusok hozzáadásához stb. — lásd a [Képkeret](/slides/hu/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Megjegyzés" color="warning" %}}

Képek és PowerPoint‑bemutatók bemeneti/kimeneti műveleteit manipulálva képet konvertálhat az egyik formátumból a másikba. Lásd ezeket az oldalakat: konvertálja a [kép JPG-re](https://products.aspose.com/slides/hu/net/conversion/image-to-jpg/); konvertálja a [JPG képet](https://products.aspose.com/slides/hu/net/conversion/jpg-to-image/); konvertálja a [JPG PNG-re](https://products.aspose.com/slides/hu/net/conversion/jpg-to-png/), konvertálja a [PNG JPG-re](https://products.aspose.com/slides/hu/net/conversion/png-to-jpg/); konvertálja a [PNG SVG‑re](https://products.aspose.com/slides/hu/net/conversion/png-to-svg/), konvertálja a [SVG PNG‑re](https://products.aspose.com/slides/hu/net/conversion/svg-to-png/).

{{% /alert %}}

Az Aspose.Slides támogatja a képek kezelését a következő népszerű formátumokban: JPEG, PNG, BMP, GIF és egyebek. 

## **Képek helyi tárolásból a diákhoz**

A számítógépén lévő egy vagy több képet hozzáadhat egy diához a bemutatóban. Az alábbi C# példakód megmutatja, hogyan adjon képet egy diához:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Képek hozzáadása a webről a diákhoz**

Ha a diához hozzáadni kívánt kép nem érhető el a számítógépén, közvetlenül a webről is hozzáadhatja azt. 

Az alábbi C# példakód megmutatja, hogyan adjon képet a webről egy diához:

```c#
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

## **Képek hozzáadása a diamesterekhez**

A diamester a legfelső dia, amely tárolja és szabályozza az alatta lévő diák információit (téma, elrendezés stb.). Így, ha egy képet a diamesterhez ad hozzá, az a kép minden alatta lévő dián megjelenik. 

Az alábbi C# példakód megmutatja, hogyan adjon képet egy diamesterhez:

```c#
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

Előfordulhat, hogy egy képet háttérként szeretne használni egy adott dián vagy több dián. Ebben az esetben lásd a *[Képek beállítása háttérként a diákhoz](https://docs.aspose.com/slides/hu/net/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG hozzáadása a bemutatókhoz**
Bármilyen képet hozzáadhat vagy beilleszthet egy bemutatóba a [AddPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/methods/addpictureframe) metódus használatával, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection) felülethez tartozik.

SVG képen alapuló képobjektum létrehozásához a következő módon járhat el:

1. Hozzon létre SvgImage objektumot a ImageShapeCollection-be való beszúráshoz
2. Hozzon létre PPImage objektumot az ISvgImage‑ből
3. Hozzon létre PictureFrame objektumot az IPPImage interfész használatával

Az alábbi példakód megmutatja, hogyan valósítsa meg a fenti lépéseket egy SVG kép hozzáadásához egy bemutatóba:
``` csharp 
// A dokumentumok könyvtárának elérési útja
string dataDir = @"D:\Documents\";

// Forrás SVG fájl neve
string svgFileName = dataDir + "sample.svg";

// Kimeneti bemutató fájl neve
string outPptxPath = dataDir + "presentation.pptx";

// Új bemutató létrehozása
using (var p = new Presentation())
{
    // SVG fájl tartalmának beolvasása
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage objektum létrehozása
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImage objektum létrehozása
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Új PictureFrame létrehozása 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Bemutató mentése PPTX formátumban
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **SVG konvertálása alakzatkészletre**
Az Aspose.Slides SVG‑konverziója egy alakzatkészletre hasonló a PowerPoint SVG‑kezelő funkciójához:

![PowerPoint Popup Menu](img_01_01.png)

A funkcionalitást a [AddGroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/addgroupshape/methods/1) metódus egyik túlterhelése biztosítja a [IShapeCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection) felületen, amely az első argumentumként egy [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage) objektumot vár.

Az alábbi példakód megmutatja, hogyan használja a leírt módszert egy SVG fájl alakzatkészletté konvertálásához:

``` csharp 
// A dokumentumok könyvtárának elérési útja
string dataDir = @"D:\Documents\";

// Forrás SVG fájl neve
string svgFileName = dataDir + "sample.svg";

// Kimeneti bemutató fájl neve
string outPptxPath = dataDir + "presentation.pptx";

// Új bemutató létrehozása
using (IPresentation presentation = new Presentation())
{
    // SVG fájl tartalmának beolvasása
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage objektum létrehozása
    ISvgImage svgImage = new SvgImage(svgContent);

    // Dia méretének lekérése
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG képet alakzatcsoporttá konvertálás, a dia méretére méretezve
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Bemutató mentése PPTX formátumban
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Képek hozzáadása EMF‑ként a diákhoz**
Az Aspose.Slides for .NET lehetővé teszi, hogy az Excel‑lapokból EMF képeket generáljon, és ezeket az EMF képeket a diákba adja hozzá az Aspose.Cells‑szel. 

Az alábbi példakód megmutatja, hogyan hajtsa végre a leírt feladatot:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //A munkafüzet mentése adatfolamba
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Képek cseréje a Képgyűjteményben**

Az Aspose.Slides lehetővé teszi, hogy a bemutató képgyűjteményében (beleértve a dia‑alakzatok által használtakat) tárolt képeket cserélje. Ez a szakasz több megközelítést mutat be a gyűjtemény képeinek frissítésére. Az API egyszerű módszereket kínál egy kép nyers bájtadatokkal, egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) példánnyal vagy egy már létező képpel történő cseréjéhez.

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó bemutatófájlt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztállyal.
1. Töltsön be egy új képet egy fájlból bájt‑tömbbe.
1. Cserélje le a célképet az új képre a bájt‑tömb használatával.
1. A második megközelítésben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumba, és cserélje le a célképet ezzel az objektummal.
1. A harmadik megközelítésben cserélje le a célképet egy már a bemutató képgyűjteményében létező képre.
1. Írja a módosított bemutatót PPTX‑fájlként.

```cs
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

// A bemutató mentése fájlba.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Információ" color="info" %}}

Az Aspose INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterrel egyszerűen animálhat szövegeket, GIF‑eket hozhat létre szövegekből stb. 

{{% /alert %}}

## **GYIK**

**Megmarad az eredeti kép felbontása a beszúrás után?**

Igen. A forrás‑pixelek megmaradnak, de a végső megjelenés attól függ, hogy a [picture](/slides/hu/net/picture-frame/) hogyan van méretezve a dián és milyen tömörítés kerül alkalmazásra mentéskor.

**Mi a legjobb mód a logó cseréjére egyszerre több tucat dián?**

Helyezze a logót a mester‑diára vagy egy elrendezésre, és cserélje le a bemutató képgyűjteményében – a módosítások minden, azt az erőforrást használó elemre kiterjednek.

**Átalakítható-e a beillesztett SVG szerkeszthető alakzatokká?**

Igen. Az SVG konvertálható egy alakzatcsoporttá, amelynek egyes részei szerkeszthetők a szabványos alakzattulajdonságokkal.

**Hogyan állíthatom be egy kép háttérként több diára egyszerre?**

[A kép beállítása háttérként](/slides/hu/net/presentation-background/) a mester‑dián vagy a megfelelő elrendezésen – a mester/eljárás‑elrendezést használó diák örökölni fogják a hátteret.

**Hogyan akadályozhatom meg, hogy a bemutató a sok kép miatt „felrobbanjon” méretben?**

Használjon egyetlen képernyőforrást a másolások helyett, válasszon megfelelő felbontást, alkalmazzon tömörítést mentéskor, és a gyakran ismétlődő grafikákat a mester‑diákon helyezze el, ahol indokolt.