---
title: Alakzatok átméretezése a bemutató diákon .NET-ben
type: docs
weight: 130
url: /hu/net/resizing-shapes-on-slide/
aliases:
  - /hu/net/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for .NET segítségével – automatizálja a diaelrendezés módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Amikor megváltoztatja egy bemutató diaméreteit, előfordulhat, hogy át kell méretezni és át kell helyezni a benne lévő alakzatokat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan skálázhatja az alakzatokat manuálisan, valamint hogyan kell kezelni a táblázatokat diákon, mestereken és elrendezéseken.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív pozíciójának és méretének megőrzéséhez szorozza meg a vízszintes koordinátákat és a szélességet az új dia szélességének és az eredeti szélességnek arányával. A magasságaránnyal szorozza meg a függőleges koordinátákat és a magasságot.

Az első példa betölti azt a bemutatót, amelynek diái nem tartalmaznak táblázatot, A4-re módosítja a dia méretét, és elmenti az eredményt. A [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) metódust a [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) értékkel használja, hogy a későbbi ciklus vezérelje a skálázást. Az arányok egység nélküli értékek; az alakzat pozíciói és méretei pontban vannak megadva. A különböző szélesség‑ és magasságarányok torzíthatják az alakzatokat, és az alakzat méretének módosítása nem skálázza a betűméreteket.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Számítsa ki a független vízszintes és függőleges skálázási tényezőket.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
A táblázatokat külön kell kezelni: a táblázat oszlopszélességeit és sormagasságait kell skálázni, nem a táblázat teljes szélességét és magasságát. A sormagasságok nagyobbak lehetnek a kért értéknél, ha a cellatartalom több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a mestereken és elrendezéseken lévő alakzatokat is feldolgozza, mielőtt elmentené a átméretezett bemutatót. Segédprogramja minden [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) esetén a [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) és a [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) skálázásával kezeli a táblázatot. Ezután a táblázat pozícióját skálázza anélkül, hogy a teljes méreteket külön skálázná.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Számítsa ki a független vízszintes és függőleges skálázási tényezőket.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Átméretezze a mestereken és elrendezéseken, valamint az egyes diákon definiált alakzatokat.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // A táblázat méreteit az oszlopszélességek és a sormagasságok szabályozzák.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **GYIK**

**Miért torzul vagy vágódik le az alakzat a dia átméretezése után?**

Ha a dia méretét átméretezés nélkül változtatja meg, az alakzatok megtartják eredeti pozíciójukat és méretüket, és a dia szélén túl is nyúlhatnak. A szélesség és magasság különböző aránnyal történő skálázása szintén torzíthatja az alakzatokat.

**Működik a megadott kód minden alakzattípussal?**

Az első példa közvetlenül módosítja az alakzat határait, és diákra van szánva, amelyek nem tartalmaznak táblázatot. A második példa a táblázatokat külön kezeli. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblázatokat, mivel ezek a példák nem skálázzák a betűméreteket, és a táblázattartalom befolyásolhatja a sormagasságokat.

**Hogyan méretezhetem át a táblázatokat a dia átméretezésekor?**

Skálázza az oszlopszélességeket a szélességi aránnyal, a minimális sormagasságokat a magassági aránnyal, majd skálázza a táblázat pozícióját, ahogyan a második példában is látható.

**Ez az átméretezés működik‑e mester- és elrendezésdíákon is?**

Igen. A második példa bejárja a [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) és minden mester [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) elemeit, és ugyanazt az átméretezési logikát alkalmazza az alakzataikon.

**Megváltoztathatom a dia tájolását (álló/fekvő) az átméretezés során?**

Igen. Állítsa be a [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) értékét a dia méretének módosítása után, a célméretek beolvasása előtt, hogy a skálázási tényezők a végleges tájolásnak megfelelően legyenek.

**Van korlátozás a beállítható dia méretre?**

A [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) segítségével egyedi dia méreteket adhat meg. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függenek.

**Hogyan kerülhetem el, hogy a rögzített képarányú alakzatok torzuljanak?**

Használja ugyanazt a skálázási tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés új dia méretekhez való illesztéséhez alkalmazza a kisebbik arányt mindkét dimenzióra és pozícióra. Ez megőrzi az arányokat, de az egyik oldalon előfordulhat üres tér.