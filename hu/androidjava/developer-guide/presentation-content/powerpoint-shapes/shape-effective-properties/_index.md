---
title: Alakzat hatékony tulajdonságainak lekérése prezentációkból Androidon
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/androidjava/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- világítási rig
- bevél alak
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan számítja ki és alkalmazza az Aspose.Slides Androidra Java segítségével a hatékony alakzattulajdonságokat a pontos PowerPoint megjelenítéshez."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és **hatékony** tulajdonságok közötti különbséget. A helyi értékek olyan értékek, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. Részlet tulajdonságok egy diaon.
1. Prototípus alakzat szövegstílusok egy elrendezésen vagy fődian, ha a részlet szövegkeret alakzata rendelkezik ilyennel.
1. Globális szövegbeállítások egy bemutatóban.

A helyi értékek meghatározhatók vagy elhagyhatók bármely szinten. Amikor az Aspose.Slides a végső „megjelenítettként” formázásra van szüksége, feloldja az öröklődési láncot, és **hatékony** értékeket ad vissza. Ezeket a helyi formátumobjektumon meghívott `getEffective()` metódussal kaphatja meg.

A következő példa azt mutatja, hogyan lehet hatékony értékeket lekérni. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) szövegkerettel és legalább egy résszel rendelkezik.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
A hatékony formázási adatok a jelenleg kiszámított formázást jelölik az öröklődés alkalmazása után. A jelenlegi megvalósításban néhány hatékony adatobjektum, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformateffectivedata/), belsőleg gyorsítótárazott lehet. A `getEffective()` újbóli meghívása a szülő vagy az örökölt formázás megváltoztatása után frissítheti a gyorsítótárazott adatokat, és egy korábban lekérdezett objektum már nem feltétlenül tükrözi a korábbi állapotot. Ha meg szeretné őrizni a hatékony értékeket későbbi felhasználásra, másolja a szükséges tulajdonságokat, például betűmagasság, kitöltőszín, betűstílus vagy igazítás, a saját adatobjektumába.
{{% /alert %}}

## **Hatékony kamera tulajdonságok lekérése**

Az Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérését. A [ICameraEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icameraeffectivedata/) interfész egy immutable (változtathatatlan) objektumot képvisel, amely a hatékony kamera tulajdonságokat tartalmazza. Egy [ICameraEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icameraeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/) révén érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/) számára.

Az alábbi kódrészlet bemutatja, hogyan lehet a kamera hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata 3D formázással rendelkezik.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Hatékony Light Rig tulajdonságok lekérése**

Az Aspose.Slides lehetővé teszi a Light Rig hatékony tulajdonságainak lekérését. A [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilightrigeffectivedata/) interfész egy immutable (változtathatatlan) objektumot képvisel, amely a hatékony fényrig tulajdonságokat tartalmazza. Egy [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilightrigeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/) révén érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/) számára.

Az alábbi kódrészlet bemutatja, hogyan lehet a fényrig hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata 3D formázással rendelkezik.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Hatékony bevel alakzat tulajdonságok lekérése**

Az Aspose.Slides lehetővé teszi egy alakzat bevel hatékony tulajdonságainak lekérését. A [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapebeveleffectivedata/) interfész egy immutable (változtathatatlan) objektumot képvisel, amely a alakzat felületének hatékony relief tulajdonságait tartalmazza. Egy [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapebeveleffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/) révén érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/) számára.

Az alábbi kódrészlet bemutatja, hogyan lehet egy alakzat felső beveljének hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata 3D formázással rendelkezik.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Hatékony szövegkeret tulajdonságok lekérése**

Az Aspose.Slides segítségével lekérheti egy szövegkeret hatékony tulajdonságait. A [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformateffectivedata/) interfész a hatékony szövegkeret formázási tulajdonságokat tartalmazza.

Az alábbi kódrészlet bemutatja, hogyan lehet a szövegkeret hatékony formázási tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) szövegkerettel rendelkezik.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Hatékony szövegstílus tulajdonságok lekérése**

Az Aspose.Slides segítségével lekérheti egy szövegstílus hatékony tulajdonságait. A [ITextStyleEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextstyleeffectivedata/) interfész a hatékony szövegstílus tulajdonságokat tartalmazza.

Az alábbi kódrészlet bemutatja, hogyan lehet a szövegstílus hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) szövegkerettel rendelkezik.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **A hatékony betűmagasság értékének lekérése**

Az Aspose.Slides segítségével lekérheti a hatékony betűmagasságot. Az alábbi kód azt mutatja be, hogyan változik egy részlet hatékony betűmagassága, ha a helyi betűmagasság értékeket különböző prezentációs struktúra szinteken állítják be.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A táblázat hatékony kitöltési formátumának lekérése**

Az Aspose.Slides segítségével lekérheti a táblázat különböző részeinek hatékony kitöltési formátumát. A [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformateffectivedata/) interfész a hatékony kitöltési formázási tulajdonságokat tartalmazza. A cella formázásának nagyobb prioritása van, mint a sor formázásának, a sor formázásnak nagyobb prioritása van, mint az oszlop formázásának, és az oszlop formázásnak nagyobb prioritása van, mint a teljes táblázat formázásának.

Ennek eredményeként a [ICellFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icellformateffectivedata/) tulajdonságai használatosak a táblázatcellák kirajzolásához. Az alábbi kódrészlet bemutatja, hogyan lehet a táblázat különböző részeinek hatékony kitöltési formátumát lekérni. Feltételezi, hogy az első dia első alakzata egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itable/) objektum.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **GYIK**

**A `getEffective()` pillanatképet ad vissza?**

Nem mindig. A hatékony adatok az öröklődés alkalmazása után kiszámított formázást jelölik, de egyes hatékony adatobjektumok belsőleg gyorsítótárazottak lehetnek. Egy későbbi `getEffective()` hívás újraszámíthatja a formázást és frissítheti a gyorsítótárazott adatokat, ezért egy korábban lekért objektumot nem szabad tartós pillanatképként kezelni.

**Mikor kell újból beolvasni a hatékony tulajdonságokat?**

Hívja meg a `getEffective()` metódust újra a helyi formázás, a szülő stílusok, az elrendezés, a fődia vagy a prezentáció szintű alapértelmezések módosítása után. A következő hívás újraértékeli a formázási hierarchiát és a jelenlegi hatékony eredményt adja vissza.

**A megváltoztatás vagy egy elrendezés/fődia eltávolítása befolyásolja a már lekért hatékony tulajdonságokat?**

Igen, de a változás csak a következő `getEffective()` híváskor jelenik meg. Ha egy szülő formázási forrás megváltozik vagy eltávolításra kerül, a korábban lekért hatékony adatok elavultak lehetnek. Amint a `getEffective()` újra végrehajtásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a betűtípusok, színek, méretek vagy egyéb értékek módosulhatnak.

**Módosíthatok értékeket a hatékony adatobjektumokon keresztül?**

Nem. A hatékony adatobjektumok csak a számított értékeket mutatják. A módosításokat a helyi formázási objektumokban kell elvégezni, majd újra le kell kérni a hatékony értékeket.

**Mi történik, ha egy tulajdonság nincs beállítva sem az alakzat szintjén, sem az elrendezésen/fődian, sem a globális beállításokban?**

A hatékony értéket a alapértelmezett mechanizmus határozza meg, amely magában foglalja a PowerPoint és az Aspose.Slides alapértelmezéseit. Ez az eredményül kapott érték a jelenlegi hatékony adatok része lesz.

**Az effektív betűérték alapján meg tudom határozni, melyik szint biztosította a méretet vagy a betűtípust?**

Nem közvetlenül. A hatékony adat csak a végső értéket adja vissza. A forrás megtalálásához ellenőrizze a helyi értékeket a részlet, bekezdés, szövegkeret és a szövegstílusok szintjein az elrendezésen, a fődian és a prezentáción, hogy hol jelenik meg az első explicit definíció.

**Miért tűnnek néha a hatékony értékek azonosnak a helyi értékekkel?**

Mert a helyi érték végsővé vált (nem volt szükség magasabb szintű öröklődésre). Ilyenkor a hatékony érték megegyezik a helyi értékkel.

**Mikor kell hatékony tulajdonságokat használni, és mikor csak a helyi értékekkel dolgozni?**

Használjon hatékony adatokat, ha a "megjelenítettként" eredményre van szüksége az összes öröklődés után, például színek, behúzások vagy méretek összehangolásához. Ha ezeket az értékeket későbbi formázási változásoktól függetlenül meg kell őrizni, másolja a szükséges tulajdonságokat egy saját objektumba. Ha egy adott szinten szeretne formázást módosítani, változtassa meg a helyi tulajdonságokat, majd szükség esetén olvassa újra a hatékony adatokat az eredmény ellenőrzéséhez.