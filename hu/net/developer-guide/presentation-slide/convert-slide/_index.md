---
title: Prezentációs diák képekké konvertálása .NET-ben
linktitle: Dia képpé
type: docs
weight: 41
url: /hu/net/convert-slide/
keywords:
- dia konvertálása
- dia exportálása
- dia képre
- dia mentése képként
- dia EMF-be
- dia PNG-be
- dia JPEG-be
- dia bitmapre
- dia TIFF-be
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP bemutatók diáját PNG, JPEG, GIF, TIFF, EMF és egyéb képformátumokba C#-ban az Aspose.Slides for .NET használatával."
---
## **Bevezetés**

Az Aspose.Slides for .NET képes a PowerPoint és OpenDocument bemutatók egyedi diákját PNG, JPEG, GIF, TIFF és egyéb képformátumokban megjeleníteni.

A dia képpé konvertálásához kövesse az alábbi lépéseket:

1. Töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztállyal.
2. Válassza ki a megjeleníteni kívánt diát.
3. Szükség esetén állítsa be a renderelést a [RenderingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/renderingoptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) osztállyal.
4. Hívja meg a [GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/getimage/) metódust. Ez egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumot ad vissza.
5. Hívja meg az [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/save/) metódust, és adja meg a kimeneti formátumot egy [ImageFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/) értékkel.

## **Diát PNG képpé konvertálása**

A legegyszerűbb konverzió az alapértelmezett renderelési beállításokat használja. A kapott [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektum memóriában feldolgozható vagy fájlba menthető.

Az alábbi C# példa az első diát rendereli, és PNG képként menti el:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Diák konvertálása egyéni méretű képekké**

Használja a [GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/getimage/) túlterhelést, amely egy [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) értéket fogad, hogy a diát pontos képpont mérettel renderelje.

Az alábbi példa egy 1820 × 1040 JPEG képet hoz létre:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Diák konvertálása jegyzetekkel és megjegyzésekkel rendelkező képekké**

Alapértelmezés szerint a diaképek nem tartalmaznak jegyzeteket vagy megjegyzéseket. Rendeljen egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notescommentslayoutingoptions/) objektumot a [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) tulajdonsághoz, hogy szabályozza, hol jelenjenek meg a jegyzetek és megjegyzések.

Az alábbi példa a levágott jegyzeteket a dia alá, a megjegyzéseket pedig a jobb oldalára helyezi:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Figyelmeztetés" color="warning" %}}
A dia‑kép konvertálásakor ne állítsa be a [NotesPosition](https://reference.aspose.com/slides/hu/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) tulajdonságot a [BottomFull](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notespositions/) értékre. A jegyzetek több szöveget is tartalmazhatnak, mint amit a fix képméret befogad. Helyette a [BottomTruncated](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notespositions/) értéket használja.
{{% /alert %}}

## **Diák konvertálása TIFF beállítások használatával**

A [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) osztály lehetővé teszi a renderelt TIFF kép méretének, felbontásának és egyéb tulajdonságainak vezérlését.

Az alábbi példa az első diát 2160 × 2880 TIFF képként, 300 DPI felbontással rendereli:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Az összes dia konvertálása képekké**

Iteráljon a diagyűjteményen, hogy a teljes bemutatót képsorozattá konvertálja. A rejtett diák is belekerülnek, hacsak kifejezetten nem hagyja ki őket.

Az alábbi példa minden diát JPEG képként renderel, vízszintes és függőleges méretezési faktorral 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Enhanced Metafile (EMF) kimenet létrehozása**

Az Enhanced Metafile (EMF) akkor hasznos, amikor vektor alapú grafikákat kell cserélni a Microsoft Office-szal vagy más Windows alkalmazásokkal, amelyek támogatják a Windows metafájlokat. A pixel alapú képpel ellentétben egy EMF meg tudja őrizni a vektoros rajzolási műveleteket, amelyek méretezésekor nem veszítenek annyira a élességben. Az EMF azonban elsősorban kompatibilitási formátum Windows metafájl‑támogatással rendelkező alkalmazások számára, nem pedig általános csereformátum. Továbbá a komplex diatartalmak, mint a bitmap képek és bizonyos effektusok, rasterizált elemekként tárolhatók a vektor metafájl konténerben.

### **Dia exportálása EMF-be**

Az [ISlide.WriteAsEmf](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/writeasemf/) metódus egy [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/) objektumot EMF formátumban ír egy célfolyamra. Az alábbi példa betölt egy bemutatót, kiválasztja az első diát, és egy EMF fájlfolyamba írja:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

A hívó felelős a [ISlide.WriteAsEmf](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/writeasemf/) metódusnak átadott folyamért, és le kell zárnia vagy el kell engednie azt. Az Aspose.Slides a folyam aktuális pozíciójában ír, és nyitva hagyja a folyamat.

### **SVG kép konvertálása EMF-be, és hozzáadása a bemutatóhoz**

Használja az [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/writeasemf/) metódust az SVG tartalom EMF-be konvertálásához. A kapott bájtok hozzáadhatók a bemutatóhoz a [IImageCollection.AddImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection/addimage/) használatával, és egy diára helyezhetők a [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addpictureframe/) segítségével.

Az alábbi példa egy [SvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/svgimage/) objektumot hoz létre SVG jelölésből, memóriában EMF-be konvertálja, az első diára beilleszti a metafájlt, majd elmenti a bemutatót:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/writeasemf/) nem birtokolja a célfolyamot. Írás után a folyam pozíciója a generált adatok végén van. A `Position`‑t állítsa vissza a kezdetre, mielőtt ugyanazt a kereshető folyamat átadná egy olvasónak, ahogy fent mutattuk. Hagyja a folyamatot nyitva, amíg a fogyasztó be nem fejezi a olvasást, majd utána zárja be. Alternatívaként hívja meg a `ToArray`‑t, és adja át a kapott bájt tömböt a [IImageCollection.AddImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection/addimage/) metódusnak; a `ToArray` a teljes puffert adja vissza a folyamat aktuális pozíciójától függetlenül.

Az EMF generálás elérhető azokban az operációs rendszerekben, amelyeket a kiválasztott Aspose.Slides for .NET build támogat, de a renderelés különbözhet platformonként, ha a betűtípusok vagy a natív grafikai függőségek nem állnak rendelkezésre. Telepítse a forrás tartalom által használt betűtípusokat, vagy állítson be megfelelő helyettesítéseket, kövesse a [platform követelményeket](/slides/hu/net/system-requirements/) a Aspose.Slides csomaghoz, és ellenőrizze az eredményt a cél EMF‑fogyasztó alkalmazásban. A Linux és macOS alkalmazások gyakran korlátozott vagy eltérő támogatással rendelkeznek a Windows metafájlok megjelenítésére és szerkesztésére.

## **Színes Emoji renderelés**

{{% alert title="Megjegyzés" color="info" %}}
A színes emoji‑k helyes rendereléséhez a bemutatóban használt emoji betűkészleteknek telepítve és elérhetőeknek kell lenniük azon a rendszeren, amely a konvertálást végzi. Például, ha a bemutató **Segoe UI Emoji** betűtípust használ, és ez hiányzik, az emojik monokrómként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **GYIK**

**Támogatja az Aspose.Slides a diák animációval történő renderelését?**

Nem. A [GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/getimage/) metódus a dia statikus képét rendereli, és nem exportál animációkat.

**Exportálhatók a rejtett diák képek formájában?**

Igen. A rejtett diák hasonlóan renderelhetők, mint a normál diák. Tartalmazza őket a feldolgozási ciklusban, ahogy az előző példában is látható.

**Megmaradnak-e az árnyékok és egyéb effektusok a diaképeken?**

Igen. Az Aspose.Slides az árnyékokat, átlátszóságot és egyéb támogatott grafikai effektusokat a diaképeken megjeleníti.