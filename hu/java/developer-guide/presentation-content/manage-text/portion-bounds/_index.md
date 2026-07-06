---
title: Szövegrész határainak lekérése prezentációkból Java-ban
linktitle: Rész határok
type: docs
weight: 47
url: /hu/java/portion-bounds/
keywords:
- szövegrész határai
- szövegrész
- szöveg rész
- szöveg koordinátái
- szöveg pozíciója
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan lehet lekérni a szövegrész határait PowerPoint prezentációkban az Aspose.Slides for Java használatával."
---
## **Áttekintés**

Egy szövegrész egy bekezdésen belüli konkrét szövegtöredéket képvisel, és lehetővé teszi, hogy a töredékkel a környező tartalomtól függetlenül dolgozzon. Az Aspose.Slides‑ben a részek akkor használhatók, amikor a szövegtöredék határait kell lekérni, csak a bekezdés egy részére kell formázást alkalmazni, vagy részletesebb szinten kell a szöveg viselkedését szabályozni.

Ez a cikk bemutatja, hogyan lehet egy rész határoló téglalapját lekérdezni a [IPortion.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPortion#getRect--) használatával. Emellett megmutatja, hogyan lehet egy rész kezdetének koordinátáit lekérni a [IPortion.getCoordinates](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPortion#getCoordinates--) használatával. Továbbá kiemeli a gyakori, a részekkel kapcsolatos helyzeteket, például egyetlen szövegtöredékhez hiperhivatkozás alkalmazását, a formázás átvitelének megértését a rész, bekezdés, szövegkeret és téma öröklődésén keresztül, valamint a megadott betűtípus hiányának kezelését.

## **A szövegrész határainak lekérése**

Használja a [IPortion.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPortion#getRect--) metódust egy szövegrész határoló téglalapjának lekéréséhez:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **A szövegrész koordinátáinak lekérése**

Használja a [IPortion.getCoordinates](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPortion#getCoordinates--) metódust egy szövegrész kezdetének koordinátáinak lekéréséhez:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak a szöveg egy részére egy bekezdésen belül?**

Igen, a [hiperhivatkozást hozzárendelni](/slides/hu/java/manage-hyperlinks/) egy egyedi részhez; csak az a töredék lesz kattintható, nem pedig a teljes bekezdés.

**Hogyan működik a stílus öröklődés: mit felülír egy rész, és mi kerül át a bekezdésből vagy a szövegkeretből?**

A rész szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva az [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) objektumban, az Aspose.Slides a [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) objektumból veszi át. Ha ott sem van beállítva, akkor az Aspose.Slides a [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) vagy a [theme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/theme/) stílusát használja.

**Mi történik, ha egy részhez megadott betűtípus hiányzik a célgépen vagy szerveren?**

A [betűtípus-helyettesítési szabályok](/slides/hu/java/font-selection-sequence/) érvényesek. A szöveg újrarendeződhet: a metrikák, elválasztás és a szélesség változhat, ami a pontos elhelyezés szempontjából fontos.

**Állíthatok-e a részhez specifikus szövegtöltés átlátszóságot vagy fokozatot a bekezdés többi részétől függetlenül?**

Igen, a szövegszín, a kitöltés és az átlátszóság az [IPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/) szintjén eltérhet a szomszédos töredékektől.