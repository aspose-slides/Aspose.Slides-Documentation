---
title: Szövegrésszek kezelése Android prezentációkban
linktitle: Szövegrész
type: docs
weight: 70
url: /hu/androidjava/portion/
keywords:
- szövegrész
- szövegrészlet
- szövegkoordináták
- szövegpozíció
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet szövegrésszeket PowerPoint prezentációkban az Aspose.Slides for Android Java használatával, növelve a teljesítményt és a testreszabhatóságot."
---
## **Bevezetés**

A szövegrész egy bekezdésen belüli konkrét szövegrészt képvisel, és lehetővé teszi, hogy a környező tartalomtól függetlenül dolgozzon ezzel a résszel. Az Aspose.Slides-ben a részek akkor használhatók, amikor egy szövegrész pozícióját kell lekérdezni, csak a bekezdés egy részére kell formázást alkalmazni, vagy részletesebb szinten kell a szöveg viselkedését szabályozni.

## **A szövegrész koordinátáinak lekérése**
[**getCoordinates()**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPortion#getCoordinates--) metódust hozzáadták az [IPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/) és a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) osztályhoz, amely lehetővé teszi a rész elejének koordinátáinak lekérését.

```java
// PPTX-et képviselő Presentation osztály példányosítása
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

**Alkalmazhatok hiperhivatkozást csak a bekezdésen belül egy szövegrészre?**

Igen, az egyedi résznél [hiperhivatkozást rendelhet](/slides/hu/androidjava/manage-hyperlinks/); csak ez a rész lesz kattintható, nem a teljes bekezdés.

**Hogyan működik a stílusöröklés: mit felülír a Portion, és mi származik a Paragraph/TextFrame-ből?**

A Portion szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) esetén, a motor a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) értékét veszi; ha ott sem, akkor a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/theme/) stílusból.

**Mi történik, ha a Portion-hoz megadott betűtípus hiányzik a célgépen/kiszolgálón?**

[A betűtípus-helyettesítési szabályok](/slides/hu/androidjava/font-selection-sequence/) érvényesek. A szöveg átlétezhet: a metrikák, elválasztás és a szélesség megváltozhat, ami a pontos pozícionálásnál fontos.

**Beállíthatok Portion-specifikus szövegtöltés átlátszóságot vagy színátmenetet a bekezdés többitől függetlenül?**

Igen, a szövegszín, a kitöltés és az átlátszóság a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) szintjén eltérhet a szomszédos részeketől.