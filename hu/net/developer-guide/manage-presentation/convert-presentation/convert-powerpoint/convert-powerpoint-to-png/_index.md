---
title: PowerPoint diák konvertálása PNG-be .NET-ben
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/net/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-be
- PPTX exportálása PNG-be
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PowerPoint prezentációkat gyorsan magas minőségű PNG képekké az Aspose.Slides for .NET segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a prezentációs diákat PNG képekké konvertálni az Aspose.Slides for .NET segítségével. Betölthet prezentációkat olyan formátumokban, mint a PPT, PPTX és ODP, megjelenítheti az egyes diákat, és különálló PNG képként mentheti el őket.

Az alábbi példák bemutatják a bélyegképek renderelését, a méretarányok beállítását, a kimeneti méretek pixelben való megadását, valamint egy gradient rendering stílus kiválasztását.

## **PowerPoint konvertálása PNG-be**

Töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztállyal, és érje el a diákat a [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) gyűjteményen keresztül. A példa minden diát a [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) paraméter nélküli hívásával renderel, hogy bélyegképet hozzon létre. Ezután a [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) metódust hívja a [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) formátummal, hogy minden renderelt diát PNG képként mentse.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
A paraméter nélküli [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) túlterhelés 0,2-es méretarányban renderel. Például egy 720 × 540 pont méretű dia 144 × 108 pixel bélyegképet eredményez. A kimeneti méretek szabályozásához használja a méretarányos vagy egy explicit képmérettel rendelkező túlterheléseket, ahogy az alább látható.
{{% /alert %}}

## **PowerPoint konvertálása PNG-be egyéni méretekkel**

Adjon át vízszintes és függőleges méretarány‑értékeket a [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) metódusnak a renderelt méretek szabályozásához. Ebben a példában mindkét faktor 2, így egy 720 × 540 pont méretű dia 1440 × 1080 pixel képet eredményez. Az egyenlő méretarányok megőrzik a dia arányait. Minden képet PNG formátumban ment a [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **PowerPoint konvertálása PNG-be egyedi mérettel**

A kimeneti pixelméretek megadásához méretet adjon át a [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) metódusnak a méretarányok helyett. Ez a példa minden diát 960 × 720 pixel méretben renderel, és az eredményt a [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) menti. Válasszon olyan méreteket, amelyek megfelelnek a dia arányának, hogy elkerülje a kép nyúlását.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Gradient renderelési stílus kiválasztása**

Tegyük fel, hogy egy dián gradient kitöltések vannak, de az exportált PNG átmenetei könnyebbek vagy egyéb módon eltérnek attól, amit a PowerPoint‑ban látsz. Használhatja a [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) tulajdonságot a [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) osztályban, hogy kiválassza, hogyan legyenek renderelve a gradientek.

Töltse le a [gradient-styles.pptx](gradient-styles.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Az első diája két lineáris gradientet tartalmaz: ciánból narancssárgába felül, valamint kékkel sárgára alul. Minden gradientnek két stoppontja van, 0 % és 100 %.

A következő példa betölti ezt a prezentációt, és a [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) segítségével mindkét módban rendereli az első diát.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Az alábbi képek az ugyanarról a diáról származó kimenetet mutatják, mindkét gradienttel minden képen:

| Default | PowerPointUI |
| --- | --- |
| ![Cian-narancs és kék-sárga gradientek, Default móddal renderelve](gradient-Default.png) | ![Ugyanazok a gradientek, PowerPointUI módon renderelve](gradient-PowerPointUI.png) |

Ebben a példában a `Default` világosabb köztes színeket eredményez, míg a `PowerPointUI` sötétebb köztes színeket. A különbség a gradient színeitől és stoppontjaitól függ.

Válassza a `Default`‑et, ha a szabványos Aspose.Slides kimenet megfelel az igényeinek. Próbálja a `PowerPointUI`‑t, ha az a prioritás, hogy a megjelenés megegyezzen a PowerPoint‑éval. Hasonlítsa össze mindkét kimenetet a kívánt eredménnyel; egyik mód sem tekinthető általánosan előnyösebbnek.

## **FAQ**

**Hogyan exportálhatok egy konkrét alakzatot, például diagramot vagy képet, a teljes dia helyett?**

Az Aspose.Slides támogatja a [bélyegképek létrehozása egyedi alakzatokhoz](/slides/hu/net/create-shape-thumbnails/), amely lehetővé teszi egy alakzat PNG képként való renderelését.

**Támogatott a párhuzamos konvertálás egy szerveren?**

Igen. Használjon egy külön prezentációs példányt minden szál vagy folyamat számára; [ne osszon meg egyetlen példányt a szálak között](/slides/hu/net/multithreading/).

**Mik az értékelési korlátozások PNG exportálásakor?**

Az értékelési mód vízjelet ad a kimeneti képekhez, és [egyéb korlátozásokat](/slides/hu/net/licensing/) alkalmaz, amíg licenc nincs aktiválva.