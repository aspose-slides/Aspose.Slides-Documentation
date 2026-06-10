---
title: Szövegrészek kezelése bemutatókban Java használatával
linktitle: Szövegrész
type: docs
weight: 70
url: /hu/java/portion/
keywords:
- szövegrész
- szövegrész
- szöveg koordinátái
- szöveg pozíciója
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet szövegrészeket PowerPoint bemutatókban az Aspose.Slides for Java segítségével, növelve a teljesítményt és a testreszabhatóságot."
---
## **Áttekintés**

A szövegrészlet egy bekezdésen belül egy adott szövegrészt képviseli, és lehetővé teszi, hogy ezzel a résszel függetlenül dolgozzunk a környező tartalomtól. Az Aspose.Slides esetében a részek használhatók, ha a szövegrész pozíciójának lekérdezésére, csak a bekezdés egy részének formázására vagy a szöveg viselkedésének részletesebb szintű szabályozására van szükség.

Ez a cikk bemutatja, hogyan lehet a `getCoordinates()` metódussal lekérni egy részlet kezdetének koordinátáit. Emellett kiemeli a szövegrészhez kapcsolódó gyakori helyzeteket, például egyetlen szövegrészlethez hiperhivatkozás alkalmazását, a formázás megoldásának megértését a részlet, bekezdés, szövegkeret és téma öröklése révén, valamint azt, hogyan kell kezelni, ha a megadott betűtípus nem áll rendelkezésre. Továbbá megjegyzi, hogy a szöveg kitöltése, színe és átlátszósága különbözőképpen beállítható az egyes részeknél ugyanabban a bekezdésben.

## **Egy szövegrészlet koordinátáinak lekérése**
[**getCoordinates()**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPortion#getCoordinates--) metódus lett hozzáadva az [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) és a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) osztályokhoz, amely lehetővé teszi a részlet kezdetének koordinátáinak lekérését.

```java
// Példányosítsa a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // A prezentáció kontextusának újraformázása
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak a szöveg egy részére egyetlen bekezdésen belül?**

Igen, egy egyedi részlethez [rendelhetsz hiperhivatkozást](/slides/hu/java/manage-hyperlinks/); csak ez a rész lesz kattintható, nem pedig az egész bekezdés.

**Hogyan működik a stílusöröklés: mit felülír egy Portion, és mi származik a Paragraph/TextFrame-ből?**

A Portion szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/)-on, a motor a [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/)-ból veszi; ha ott sem van beállítva, a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/theme/) stílusból.

**Mi történik, ha egy Portion számára megadott betűtípus hiányzik a célgépen/kiszolgálón?**

[Betűtípus helyettesítési szabályok](/slides/hu/java/font-selection-sequence/) lépnek érvénybe. A szöveg újraáramlást (reflow) tapasztalhat: a metrikák, elválasztás és a szélesség változhat, ami a pontos pozicionálásnál lényeges.

**Beállíthatok egy Portion-hoz specifikus szövegkitöltés átlátszóságot vagy gradienst a bekezdés többi részétől függetlenül?**

Igen, a szövegszín, a kitöltés és az átlátszóság a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) szintjén eltérhet a szomszédos részeketől.