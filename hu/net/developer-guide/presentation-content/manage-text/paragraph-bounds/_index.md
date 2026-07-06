---
title: Bekezdés határok lekérése prezentációkból .NET-ben
linktitle: Bekezdés határok
type: docs
weight: 43
url: /hu/net/paragraph-bounds/
keywords:
- bekezdés határok
- bekezdés koordináta
- bekezdés méret
- szövegkeret
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés határokat az Aspose.Slides for .NET-ben a szöveg elhelyezésének optimalizálása érdekében a PowerPoint-prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet lekérni a bekezdések határait, méretét és koordinátáit az Aspose.Slides-ban. Megmutatja, hogyan lehet egy bekezdés téglalapot visszakapni egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) segítségével a [IParagraph.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getrect/) metódus használatával, hogyan lehet bekezdés koordinátákat szerezni egy táblázatcellás szövegkeretben, és kiemeli a fontos részleteket, például a mértékegységeket, a szövegtördelés hatását a határokra, a pixelbe való átváltást és a hatékony bekezdésformázási értékeket.

## **Bekezdés téglalap koordinátáinak lekérése**

Használja az [IParagraph.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getrect/) metódust a bekezdés határoló téglalapjának lekéréséhez.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **A bekezdés méretének lekérése egy táblázatcellában lévő TextFrame-ben**

A táblázatcellában lévő szövegkeretben lévő [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) méretének és koordinátáinak lekéréséhez használja az [IParagraph.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getrect/) metódust. A visszaadott téglalap a táblázatcellához tartozó szövegkeretre vonatkozik, ezért, ha diaszintű koordinátákra van szüksége, adja hozzá a táblázat pozícióját és a cella eltolását.

A következő példa lekéri a bekezdés határait egy táblázatcellán belül, és téglalapokat rajzol a diára a határok megjelenítéséhez:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Milyen egységekben mérik a bekezdés koordinátáit?**

A koordinátákat pontban (point) mérik, ahol egy hüvelyk 72 pontnak felel meg. Ez a dián minden koordinátára és méretre érvényes.

**A szövegtördelés befolyásolja a bekezdés határait?**

Igen. Ha a [TextFrameFormat.WrapText](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/wraptext/) be van kapcsolva az [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) esetén, a szöveg megtörik, hogy illeszkedjen a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők pixelre az exportált képen?**

Igen. A pontokat pixelekre a következő képlettel lehet átalakítani: pixel = pont × (DPI / 72). Az eredmény a rendereléshez vagy exportáláshoz választott DPI-től függ.

**Hogyan kaphatom meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílus öröklődését?**

Használja a [effective paragraph formatting data structure](/slides/hu/net/shape-effective-properties/) struktúrát; ez visszaadja a végsokasú összevont értékeket a behúzásokra, a távolságokra, a tördelésre, a jobbról balra írásra (RTL) és egyebekre vonatkozóan.