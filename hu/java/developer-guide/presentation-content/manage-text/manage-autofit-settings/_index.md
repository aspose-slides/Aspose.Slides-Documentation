---
title: "Javában az AutoFit használatával fejlessze előadásait"
linktitle: "Autofit beállítások"
type: docs
weight: 30
url: /hu/java/manage-autofit-settings/
keywords:
- szövegdoboz
- automatikus illesztés
- ne automatikus illesztés
- szöveg illesztése
- szöveg zsugorítása
- szöveg tördelése
- alakzat átméretezése
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelje az AutoFit beállításokat az Aspose.Slides for Java-ban a szöveg megjelenítés optimalizálása érdekében PowerPoint és OpenDocument prezentációiban, és javítsa a tartalom olvashatóságát."
---
## **Bevezetés**

Alapértelmezés szerint, amikor egy szövegdobozt ad hozzá, a Microsoft PowerPoint a **Resize shape to fix text** beállítást használja a szövegdobozhoz – automatikusan átméretezi a szövegdobozt, hogy a szövege mindig beleférjen.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Amikor a szövegdoboz szövege hosszabb vagy nagyobb lesz, a PowerPoint automatikusan nagyobbá teszi a szövegdobozt – megemeli a magasságát – hogy több szöveget tudjon tartalmazni.  
* Amikor a szövegdoboz szövege rövidebb vagy kisebb lesz, a PowerPoint automatikusan csökkenti a szövegdobozt – lecsökkenti a magasságát – hogy eltávolítsa a fölösleges helyet.

PowerPointban ezek a négy fontos paraméter vagy beállítás irányítja a szövegdoboz automatikus illesztésének viselkedését:

* **Ne automatikusan illeszkedjen**
* **Szöveg zsugorítása túlcsordulás esetén**
* **Alakzat átméretezése a szöveghez igazítva**
* **Szöveg tördelése az alakzatban**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Az Aspose.Slides for Java hasonló lehetőségeket kínál – néhány tulajdonságot a [TextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat) osztály alatt – amelyekkel vezérelheti a szövegdobozok automatikus illesztésének viselkedését a prezentációkban.

## **Alakzat átméretezése a szöveghez igazítva**

Ha azt szeretné, hogy a szöveg mindig beleférjen a keretbe a módosítások után, a **Resize shape to fix text** beállítást kell használnia. Ennek beállításához állítsa be a [AutofitType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat#getAutofitType--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat) osztályból) `Shape` értékre.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ez a Java‑kód megmutatja, hogyan adhatja meg, hogy a szöveg mindig illeszkedjen a keretébe egy PowerPoint‑prezentációban:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ha a szöveg hosszabb vagy nagyobb lesz, a szövegdoboz automatikusan átméreteződik (magassága nő), hogy az egész szöveg beleférjen. Ha a szöveg rövidebb, a fordított történik.

## **Ne automatikusan illeszkedjen**

Ha azt szeretné, hogy egy szövegdoboz vagy alakzat megtartsa méreteit a benne lévő szöveg változtatásaival függetlenül, a **Do not Autofit** beállítást kell használnia. Ennek beállításához állítsa be a [AutofitType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat#getAutofitType--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat) osztályból) `None` értékre.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ez a Java‑kód megmutatja, hogyan adhatja meg, hogy egy szövegdoboz megtartsa méreteit egy PowerPoint‑prezentációban:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Amikor a szöveg túl hosszú lesz a keretéhez képest, kifolyik.

## **Szöveg zsugorítása túlcsordulás esetén**

Ha a szöveg túl hosszú lesz a keretéhez képest, a **Shrink text on overflow** lehetőséggel meghatározhatja, hogy a szöveg méretét és távolságait csökkenteni kell a keretbe való illeszkedés érdekében. Ennek beállításához állítsa be a [AutofitType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat#getAutofitType--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat) osztályból) `Normal` értékre.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ez a Java‑kód megmutatja, hogyan adhatja meg, hogy a szöveg zsugorodjon túlcsordulás esetén egy PowerPoint‑prezentációban:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Amikor a **Shrink text on overflow** beállítást használják, a beállítás csak akkor kerül alkalmazásra, amikor a szöveg túl hosszú lesz a keretéhez képest.
{{% /alert %}}

## **Szöveg tördelése**

Ha azt szeretné, hogy a szöveg egy alakzatban a keret szélességének túllépése esetén megtörjön, a **Wrap text in shape** paramétert kell használnia. Ennek beállításához állítsa be a [WrapText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat#getWrapText--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat) osztályból) `true` értékre.

Ez a Java‑kód megmutatja, hogyan használja a Szöveg tördelése beállítást egy PowerPoint‑prezentációban:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Ha a `WrapText` tulajdonságot `False`‑ra állítja egy alakzatra, amikor a szöveg hosszabb lesz az alakzat szélességénél, a szöveg egy sorban a keret határain túlra fog nyúlni.
{{% /alert %}}

## **GYIK**

**Érinti a szövegdoboz belső margója az AutoFit működését?**

Igen. A kitöltés (belső margók) csökkenti a szöveg használható területét, ezért az AutoFit korábban lép életbe – a betűméretet csökkentve vagy az alakzatot korábban átméretezve. Ellenőrizze és igazítsa a margókat, mielőtt finomhangolná az AutoFitet.

**Hogyan működik az AutoFit a kézi és puha sortörésekkel?**

A kényszerített sortörések megmaradnak, és az AutoFit a betűméretet és a távolságot körülöttük módosítja. A felesleges sortörések eltávolítása gyakran csökkenti, hogy mennyire kell agresszíven zsugorítani a szöveget.

**A téma betűtípusa vagy a betűtípus helyettesítése befolyásolja az AutoFit eredményét?**

Igen. Ha egy másik, eltérő glifmetrikákkal rendelkező betűtípusra vált, az megváltoztatja a szöveg szélességét/magasságát, ami módosíthatja a végső betűméretet és a sortörést. Minden betűtípus‑változtatás vagy helyettesítés után ellenőrizze újra a diák tartalmát.