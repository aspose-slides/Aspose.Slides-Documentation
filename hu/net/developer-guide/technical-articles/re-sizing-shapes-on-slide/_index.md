---
title: Alakzatok átméretezése a .NET prezentációs diákon
type: docs
weight: 130
url: /hu/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /hu/net/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzatméret módosítása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Könnyedén átméretezhet alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for .NET segítségével—automatizálja a diák elrendezésének módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Ha megváltoztatja egy bemutató dia méretét, előfordulhat, hogy át kell méretezni és áthelyezni a formákat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan skálázhatja a formákat manuálisan, és hogyan kezelje a táblákat a diákon, a mesterdiákon és az elrendezéseken.

## **Alakzatok átméretezése**

Az egyes formák relatív pozíciójának és méretének megőrzéséhez szorozza a vízszintes koordinátákat és a szélességet a dia új szélessége és az eredeti szélesség hányadosával. Alkalmazza a megfelelő magasságharányt a függőleges koordinátákra és a magasságra.

Az első példában egy olyan bemutatót tölt be, amelynek diái nem tartalmaznak táblákat, megváltoztatja a dia méretét A4-re, és elmenti az eredményt. A [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) függvényt a [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) értékkel használja, hogy a későbbi ciklus vezérelje a méretezést. A hányadosok mértékegység nélküli értékek; a forma pozíciói és méretei pontban vannak megadva. A különböző szélesség‑ és magasságharányok torzíthatják a formákat, és egy forma méretének megváltoztatása nem méretezi a betűméreteket.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
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

{{% alert color="info" title="Megjegyzés" %}}
A táblákat külön kell kezelni: a táblák oszlopszélességét és sormagasságát kell skálázni, a tábla teljes szélességét és magasságát nem. A sormagasságok nagyobbak maradhatnak a kért értéknél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példában a táblák is támogatottak, és a formákat a mesterek és elrendezések mellett az egyes diákon is feldolgozza, mielőtt elmentené a méretezett bemutatót. A segédfüggvény minden [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) elemet úgy kezel, hogy skálázza az [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) és a [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) értékeket. Ezután a tábla pozícióját skálázza anélkül, hogy külön skálázná a tábla teljes méreteit.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
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

**Miért torzul vagy vágódik le a forma a dia átméretezése után?**

Ha a dia méretét úgy változtatja meg, hogy a formákat nem méretezi újra, azok megőrzik az eredeti pozícióikat és méreteiket, és a dia szélén túlnyúlhatnak. A szélesség és magasság különböző hányadosokkal történő skálázása is torzíthatja a formákat.

**A megadott kód minden alakzattípusra működik?**

Az első példa közvetlenül módosítja a forma határait, és olyan diákra van szánva, amelyek nem tartalmaznak táblákat. A második példa külön kezeli a táblákat. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblákat, mivel ezek a példák nem méretezik a betűméreteket, és a tábla tartalma korlátozhatja a sormagasságokat.

**Hogyan méretezem át a táblákat a dia átméretezésekor?**

Skálázza az oszlopszélességeket a szélességharánnyal, a minimális sormagasságokat a magasségharánnyal, majd skálázza a tábla pozícióját, ahogy a második példában is látható.

**Ez a méretezés működik a mesterdiákon és az elrendezési diákon is?**

Igen. A második példa végig iterál a [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) és minden mester [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) elemein, és ugyanezt a méretezési logikát alkalmazza a formáikra.

**Megváltoztathatom-e a dia tájolását (álló/fekvő) a méretezés mellett?**

Igen. Állítsa be a [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) értékét a dia méretének módosítása után, és még a célméretek beolvasása előtt, hogy a méretarányok a végső tájolást tükrözzék.

**Van korlátozás a beállítható dia méretre?**

A [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) segítségével megadhat egyéni dia méreteket. A támogatott méretek a bemutató formátumától és attól az alkalmazástól is függnek, amelyben a fájlt megnyitja.

**Hogyan akadályozhatom meg, hogy egy rögzített képarányú forma torzuljon?**

Használja ugyanazt a méretarányt a szélességhez és a magassághoz. Ahhoz, hogy az eredeti elrendezés az új dia méreteiben is elférjen, a kisebbik hányadost használja mindkét dimenzióra és pozícióra. Ez megőrzi az arányokat, de előfordulhat, hogy egy oldalon marad üres hely.