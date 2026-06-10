---
title: "Fejlessze előadásait Androidon az AutoFit segítségével"
linktitle: "AutoFit beállítások"
type: docs
weight: 30
url: /hu/androidjava/manage-autofit-settings/
keywords:
- "szövegmező"
- "autofit"
- "nem autofit"
- "szöveg illesztése"
- "szöveg zsugorítása"
- "szöveg tördelése"
- "alakzat átméretezése"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Kezelje az AutoFit beállításokat az Aspose.Slides for Android Java segítségével, hogy optimalizálja a szöveg megjelenítését PowerPoint és OpenDocument prezentációiban, és javítsa a tartalom olvashatóságát."
---
## **Bevezetés**

Alapértelmezés szerint, amikor szövegmezőt adsz hozzá, a Microsoft PowerPoint a **Resize shape to fix text** beállítást használja a szövegmezőhöz – automatikusan átméretezi a szövegmezőt, hogy a szövege mindig beleférjen.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Amikor a szöveg a szövegmezőben hosszabbá vagy nagyobbá válik, a PowerPoint automatikusan megnöveli a szövegmező magasságát, hogy több szöveget tudjon tartalmazni.  
* Amikor a szöveg a szövegmezőben rövidebbé vagy kisebbé válik, a PowerPoint automatikusan csökkenti a szövegmező magasságát, hogy eltávolítsa a fölösleges helyet.

PowerPointban ezek a 4 fontos paraméter vagy lehetőség szabályozza a szövegmező automatikus méretezését:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Az Aspose.Slides for Android via Java hasonló lehetőségeket kínál – néhány tulajdonságot a [TextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat) osztályban – amelyekkel vezérelheted a szövegmezők automatikus méretezését a prezentációkban.

## **Resize a Shape to Fit Text**

Ha azt szeretnéd, hogy a szöveg mindig beleférjen a dobozba a módosítások után, a **Resize shape to fix text** opciót kell használnod. Ennek beállításához állítsd be a [AutofitType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat) osztályból) **Shape**‑re.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ez a Java‑kód megmutatja, hogyan adhatod meg, hogy a szöveg mindig beleférjen a dobozba egy PowerPoint‑prezentációban:

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

Ha a szöveg hosszabbá vagy nagyobbá válik, a szövegmező automatikusan át lesz méretezve (magasság növelésével), hogy minden szöveg beleférjen. Ha a szöveg rövidebb lesz, a folyamat fordítottját hajtja végre.

## **Do Not Autofit**

Ha azt szeretnéd, hogy egy szövegmező vagy alakzat megtartsa a méreteit függetlenül a benne lévő szöveg változásaitól, a **Do not Autofit** opciót kell használnod. Ennek beállításához állítsd be a [AutofitType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat) osztályból) **None**‑ra.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ez a Java‑kód megmutatja, hogyan adhatod meg, hogy a szövegmező megtartsa a méreteit egy PowerPoint‑prezentációban:

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

Amikor a szöveg túl hosszú lesz a dobozhoz képest, kilóg.

## **Shrink Text on Overflow**

Ha a szöveg túl hosszú lesz a dobozhoz képest, a **Shrink text on overflow** opcióval megadhatod, hogy a szöveg méretét és a betűközöket csökkenteni kell a dobozba való illeszkedés érdekében. Ennek beállításához állítsd be a [AutofitType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat) osztályból) **Normal**‑ra.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ez a Java‑kód megmutatja, hogyan adhatod meg, hogy a szöveget zsugorítani kell, ha túlcsordul egy PowerPoint‑prezentációban:

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
Amikor a **Shrink text on overflow** opciót használják, a beállítás csak akkor lép életbe, ha a szöveg túl hosszú lesz a dobozhoz képest.
{{% /alert %}}

## **Wrap Text**

Ha azt szeretnéd, hogy a szöveg egy alakzatban a szélesség túllépésekor megtörjön az alakzaton belül, a **Wrap text in shape** paramétert kell használnod. Ennek beállításához állítsd be a [WrapText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat) osztályból) **true**‑ra.

Ez a Java‑kód bemutatja a Wrap Text beállítás használatát egy PowerPoint‑prezentációban:

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
Ha a `WrapText` tulajdonságot **False**‑ra állítod egy alakzatra, és a szöveg hosszabb lesz az alakzat szélességénél, a szöveg egyetlen sorban a alakzat szélén túlra nyúlik.
{{% /alert %}}

## **GYIK**

**Befolyásolják-e a szövegkeret belső margói az AutoFit működését?**

Igen. A belső margók (padding) csökkentik a használható szövegtérületet, ezért az AutoFit korábban lép életbe – a betűméretet vagy az alakzat méretét hamarabb módosítja. Ellenőrizd és igazítsd a margókat, mielőtt finomhangolnád az AutoFitet.

**Hogyan viszonyul az AutoFit a kézi és a puha sortörésekhez?**

A kényszerített sortörések megmaradnak, és az AutoFit a betűméretet és a sortávolságot köréjük igazítja. A szükségtelen sortörések eltávolítása gyakran csökkenti, hogy mennyire kell a szöveget zsugorítani.

**A téma betűtípusának megváltoztatása vagy a betűtípus-helyettesítés befolyásolja az AutoFit eredményét?**

Igen. Egy másik, eltérő glifmérőkkel rendelkező betűtípusra való helyettesítés megváltoztatja a szöveg szélességét/magasságát, ami módosíthatja a végső betűméretet és a sortörést. Bármilyen betűtípus‑változtatás vagy helyettesítés után ellenőrizd újra a diák megjelenését.