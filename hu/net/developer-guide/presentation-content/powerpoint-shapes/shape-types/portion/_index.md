---
title: Szövegrészek kezelése bemutatókban .NET-ben
linktitle: Szövegrész
type: docs
weight: 70
url: /hu/net/portion/
keywords:
- szövegrész
- szövegtöredék
- szövegkoordináták
- szöveghelyzet
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan kezelje a szövegrészeket PowerPoint bemutatókban az Aspose.Slides for .NET használatával, növelve a teljesítményt és a testreszabhatóságot."
---
## **Áttekintés**

A szövegrészlet egy bekezdésen belüli konkrét szövegszakaszt jelöl, és lehetővé teszi, hogy a környező tartalomtól függetlenül dolgozzunk vele. Az Aspose.Slides‑ban a részek akkor használhatók, amikor a szövegszakasz pozícióját kell lekérdezni, csak a bekezdés egy részére kell formázást alkalmazni, vagy részletesebb szintű szövegviselkedést kell szabályozni.

Ez a cikk bemutatja, hogyan lehet a `GetCoordinates()` metódus használatával lekérni egy szövegrészlet kezdő koordinátáit. Emellett kiemeli a szövegrészletekkel kapcsolatos gyakori helyzeteket, például egyetlen szövegszakaszra történő hiperhivatkozás alkalmazását, a formázás feloldásának módját a rész, bekezdés, szövegdoboz és a téma öröklődése révén, valamint a megadott betűtípus hiánya esetén előforduló helyzeteket. Továbbá megjegyzi, hogy a szöveggörbítés, szín és átlátszóság egyes részeknél eltérően állítható be ugyanabban a bekezdésben.

## **A szövegrészlet koordinátáinak lekérése**
**GetCoordinates()** metódus hozzá lett adva az IPortion és a Portion osztályhoz, amely lehetővé teszi a rész kezdő koordinátáinak lekérését:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak a szöveg egy részére egyetlen bekezdésen belül?**

Igen, egy egyedi szövegrészlethez [rendelhetsz hiperhivatkozást](/slides/hu/net/manage-hyperlinks/); csak ez a rész lesz kattintható, nem az egész bekezdés.

**Hogyan működik a stílus öröklődés: mit felülír egy szövegrészlet, és mi kerül át a bekezdésből/Szövegdobozból?**

A szövegrészlet szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/net/aspose.slides/portion/) szinten, a motor a [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) szintjéről veszi át; ha ott sem van beállítva, akkor a [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/theme/) stílusából.

**Mi történik, ha a szövegrészlethez megadott betűtípus hiányzik a célgépen/kiszolgálón?**

[A betűtípus helyettesítési szabályok](/slides/hu/net/font-selection-sequence/) érvényesek. A szöveg újrarendeződhet: a metrikák, elválasztás és a szélesség változhat, ami a pontos elhelyezkedés szempontjából fontos.

**Beállíthatok szövegekhez egyedi kitöltési átlátszóságot vagy színátmenetet a szövegrészlet szintjén, függetlenül a bekezdés többi részétől?**

Igen, a szövegszín, kitöltés és átlátszóság a [Portion](https://reference.aspose.com/slides/hu/net/aspose.slides/portion/) szintjén eltérhet a szomszédos részeketől.