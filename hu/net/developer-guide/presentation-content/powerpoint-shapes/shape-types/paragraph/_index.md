---
title: Bekezdés határainak lekérése prezentációkból .NET-ben
linktitle: Bekezdés
type: docs
weight: 60
url: /hu/net/paragraph/
keywords:
- bekezdés határai
- szövegrész határai
- bekezdés koordináta
- rész koordináta
- bekezdés mérete
- szövegrész mérete
- szövegkeret
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés és a szövegrész határait az Aspose.Slides for .NET-ben, hogy optimalizálja a szöveg elhelyezését a PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet megkapni a bekezdések és szövegrészek határait, méretét és koordinátáit az Aspose.Slides‑ben. Bemutatja, hogyan lehet lekérni egy bekezdés téglalapját egy `TextFrame`‑ben a `GetRect()` használatával, hogyan lehet a bekezdés és a rész koordinátáit egy táblázatcella szövegkeretben megkapni, és kiemeli a fontos részleteket, például a mérési egységeket, a szöveg tördelésének hatását a határokra, a pixelkonverziót és a hatékony bekezdésformázási értékeket.

## **Bekezdés‑ és szövegrész‑koordináták lekérése egy TextFrame‑ben**

Az Aspose.Slides for .NET segítségével a fejlesztők most már lekérhetik a téglalap koordinátákat egy `TextFrame` bekezdésgyűjteményén belül. Emellett lehetőség van a bekezdésen belüli rész koordinátáinak lekérésére a részgyűjteményben. Ebben a témában egy példán keresztül bemutatjuk, hogyan lehet a bekezdés téglalap koordinátáit és a rész pozícióját a bekezdésen belül megszerezni.

## **Bekezdés téglalap koordinátáinak lekérése**

Az új **GetRect()** metódus lett hozzáadva. Lehetővé teszi a bekezdés határtéglalapjának lekérését.

```c#
// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Bekezdés és szövegrész méretének lekérése egy táblázatcella TextFrame‑ben**

A [Rész](https://reference.aspose.com/slides/hu/net/aspose.slides/portion) vagy a [Bekezdés](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph) méretének és koordinátáinak lekéréséhez egy táblázatcella szövegkeretben használhatja az [IPortion.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/methods/getrect) és az [IParagraph.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/methods/getrect) metódusokat.

Ez a példa kód demonstrálja a leírt műveletet:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **GYIK**

**Milyen egységben vannak megadva a bekezdés és a szövegrészek koordinátái?**

Pontban, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre vonatkozik a dián.

**A szövegtördelés befolyásolja a bekezdés határait?**

Igen. Ha a [tördelés](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/wraptext/) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/)-ben, a szöveg a terület szélességéhez igazítva törik, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők pixelekre az exportált képen?**

Igen. A pontokat pixelekre a következő képlettel lehet átalakítani: pixelek = pontok × (DPI / 72). Az eredmény a renderelés/export során választott DPI‑tól függ.

**Hogyan kaphatom meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílusöröklődést?**

Használja a [hatékony bekezdésformázási adatstruktúrát](/slides/hu/net/shape-effective-properties/); ez visszaadja a behúzások, távolságok, tördelés, RTL és egyéb beállítások végső konszolidált értékeit.