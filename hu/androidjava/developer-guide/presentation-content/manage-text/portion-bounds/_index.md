---
title: Szövegrész határainak lekérése Androidon
linktitle: Rész határok
type: docs
weight: 47
url: /hu/androidjava/portion-bounds/
keywords:
- szövegrész határok
- szövegrész
- szövegrész
- szöveg koordináták
- szöveg pozíció
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a szövegrész határait PowerPoint prezentációkban az Androidra készült Aspose.Slides Java használatával."
---
## **Áttekintés**

Egy szövegrész egy bekezdésen belüli adott szövegdarabot jelöl, és lehetővé teszi, hogy az adott darabbal a környező tartalomtól függetlenül dolgozzon. Az Aspose.Slides-ban a részek akkor használhatók, ha le kell kérni egy szövegdarab határait, csak a bekezdés egy részére kell formázást alkalmazni, vagy részletesebb szinten kell szabályozni a szöveg viselkedését. Ez a cikk bemutatja, hogyan lehet lekérni egy rész határoló téglalapját az [IPortion.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPortion#getRect--) használatával. Emellett bemutatja, hogyan kérhető le egy rész elejének koordinátái az [IPortion.getCoordinates](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPortion#getCoordinates--) segítségével. Továbbá kiemeli a gyakori részhez kapcsolódó helyzeteket, például egyetlen szövegdarabhoz való hiperhivatkozás alkalmazását, a formázás feloldásának megértését a rész, bekezdés, szövegkeret és téma öröklődésén keresztül, valamint a megadott betűtípus hiányának kezelése esetén.

## **A szövegrész határainak lekérése**

Használja az [IPortion.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPortion#getRect--) metódust egy szövegrész határoló téglalapjának lekéréséhez:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **A szövegrész koordinátáinak lekérése**

Használja az [IPortion.getCoordinates](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPortion#getCoordinates--) metódust a szövegrész elejének koordinátáinak lekéréséhez:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak egy bekezdésen belül a szöveg egy részére?**

Igen, [hozzárendelhet hiperhivatkozást](/slides/hu/androidjava/manage-hyperlinks/) egy egyedi részhez; csak ez a darab lesz kattintható, nem pedig az egész bekezdés.

**Hogyan működik a stílus öröklődés: mit felülír egy rész, és mi származik bekezdésből vagy szövegkeretből?**

A rész szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) szinten, az Aspose.Slides a [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) szintjéről veszi. Ha ott sem van beállítva, az Aspose.Slides a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) vagy a [theme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/theme/) stílusát használja.

**Mi történik, ha a részhez megadott betűtípus hiányzik a célgépen vagy szerveren?**

A [Font substitution rules](/slides/hu/androidjava/font-selection-sequence/) érvényes. A szöveg újrafolyhat: a metrikák, elválasztás és a szélesség változhat, ami a pontos pozicionálásnál fontos.

**Beállíthatok-e a részhez specifikus szövegkitöltés átlátszóságot vagy fokozatot a bekezdés többi részétől függetlenül?**

Igen, a szövegszín, kitöltés és átlátszóság a [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) szinten eltérhet a szomszédos daraboktól.