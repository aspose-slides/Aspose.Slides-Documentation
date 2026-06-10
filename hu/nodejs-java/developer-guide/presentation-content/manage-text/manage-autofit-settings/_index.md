---
title: Fejlessze előadásait az AutoFit használatával JavaScriptben
linktitle: Autofit beállítások
type: docs
weight: 30
url: /hu/nodejs-java/manage-autofit-settings/
keywords:
- szövegdoboz
- autofit
- ne automatikus illesztés
- szöveg illesztése
- szöveg zsugorítása
- szöveg tördelése
- alakzat átméretezése
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje az AutoFit beállításokat az Aspose.Slides for Node.js-ben, hogy optimalizálja a szöveg megjelenítését PowerPoint és OpenDocument prezentációiban, és javítsa a tartalom olvashatóságát."
---
## **Introduction**

Alapértelmezés szerint, amikor szövegdobozt ad hozzá, a Microsoft PowerPoint a **Resize shape to fix text** beállítást használja a szövegdobozhoz – automatikusan átméretezi a szövegdobozt, hogy a szöveg mindig beleférjen.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Amikor a szövegdoboz szövege hosszabbá vagy nagyobbra nő, a PowerPoint automatikusan megnöveli a szövegdobozt – növeli a magasságát – hogy több szöveget is el tudjon fogadni.  
* Amikor a szövegdoboz szövege rövidebbé vagy kisebbé válik, a PowerPoint automatikusan csökkenti a szövegdobozt – csökkenti a magasságát – hogy felszabadítson felesleges helyet.  

A PowerPointban ezek a 4 fontos paraméter vagy beállítás, amely a szövegdoboz automatikus illesztésének viselkedését szabályozza:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Az Aspose.Slides for Node.js via Java has similar options — néhány tulajdonság a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat) osztályban — amelyek lehetővé teszik a szövegdobozok automatikus illesztésének viselkedésének szabályozását a prezentációkban.

## **Resize Shape to Fit Text**

Ha azt szeretné, hogy a dobozban lévő szöveg mindig beleférjen a dobozba a szöveg módosítása után, a **Resize shape to fix text** beállítást kell használnia. Ennek megadásához hívja meg a [setAutofitType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) metódust a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat) osztályból a `Shape` értékkel.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ha a szöveg hosszabbá vagy nagyobbra válik, a szövegdobozt automatikusan átméretezi (magasságát növeli), hogy az összes szöveg beleférjen. Ha a szöveg rövidebb lesz, a fordított történik.

## **Do Not Autofit**

Ha azt szeretné, hogy egy szövegdoboz vagy alakzat megtartsa méreteit függetlenül a benne lévő szöveg módosulásától, a **Do not Autofit** beállítást kell használnia. Ennek megadásához hívja meg a [setAutofitType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) metódust a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat) osztályból a `None` értékkel.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ha a szöveg túl hosszú lesz a dobozhoz képest, kifolyik.

## **Shrink Text on Overflow**

Ha egy szöveg túl hosszúra nő a dobozhoz képest, a **Shrink text on overflow** opcióval megadhatja, hogy a szöveg méretét és távolságait csökkenteni kell, hogy beleférjen a dobozba. Ennek megadásához hívja meg a [setAutofitType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) metódust a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat) osztályból a `Normal` értékkel.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Információ" color="info" %}}
A **Shrink text on overflow** opció használatakor a beállítás csak akkor kerül alkalmazásra, amikor a szöveg túl hosszú lesz a dobozhoz képest.
{{% /alert %}}

## **Wrap Text**

Ha azt szeretné, hogy a alakzatban lévő szöveg megtörjön az alakzat szélessége mentén, amikor a szöveg túllépi az alakzat szélét (csak a szélesség), a **Wrap text in shape** paramétert kell használnia. Ennek megadásához a [setWrapText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) metódust kell meghívnia a [TextFrameFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrameFormat) osztályból a `true` értékkel.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Megjegyzés" color="warning" %}}
Ha egy alakzatra a `setWrapText` metódust `False` értékkel hívja, amikor az alakzaton belüli szöveg hosszabb lesz az alakzat szélességénél, a szöveg egy sorban túlcsordul az alakzat szélén.
{{% /alert %}}

## **GYIK**

**A szövegkeret belső margói befolyásolják az AutoFit-et?**

Igen. A kitöltés (belső margók) csökkentik a szöveghez rendelkezésre álló területet, ezért az AutoFit korábban lép életbe — a betűméretet vagy az alakzat méretét hamarabb csökkenti. Ellenőrizze és állítsa be a margókat, mielőtt finomhangolná az AutoFit-et.

**Hogyan működik az AutoFit a kézi és lágy sortörésekkel?**

A kényszerített sortörések megmaradnak, és az AutoFit a körülöttük lévő betűméretet és távolságot igazítja. A felesleges sortörések eltávolítása gyakran csökkenti, hogy az AutoFit mennyire kell agresszíven összezsugorítja a szöveget.

**A téma betűtípusának módosítása vagy a betűtípus‑helyettesítés aktiválása befolyásolja az AutoFit eredményeit?**

Igen. Ha egy olyan betűtípusra helyettesít, amelynek más glyfméretei vannak, a szöveg szélessége/magassága megváltozik, ami módosíthatja a végső betűméretet és a sortörést. Minden betűtípus‑változtatás vagy helyettesítés után ellenőrizze újra a diákat.