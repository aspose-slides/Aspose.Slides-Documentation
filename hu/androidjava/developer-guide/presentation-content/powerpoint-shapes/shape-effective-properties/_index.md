---
title: Alakzatok hatékony tulajdonságainak lekérése prezentációkból Androidon
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/androidjava/shape-effective-properties/
keywords:
- alakzattulajdonságok
- kamera tulajdonságok
- világítási rig
- ferde alakzat
- szövegdoboz
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan számítja és alkalmazza az Aspose.Slides for Android Java segítségével a hatékony alakzattulajdonságokat a pontos PowerPoint megjelenítéshez."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és a **hatékony** tulajdonságok közötti különbséget. A helyi értékek olyan értékek, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. Rész tulajdonságok egy dián.
1. Prototípus alakzat szövegstílusok egy elrendezésen vagy mesterdián, ha a rész szövegdoboz alakzata rendelkezik ilyennel.
1. Globális szövegbeállítások egy prezentációban.

A helyi értékek bármely szinten definiálhatók vagy kihagyhatók. Amikor az Aspose.Slides-nek szüksége van a végső, „renderelt” formázásra, feloldja az öröklési láncot és **hatékony** értékeket ad vissza. Ezeket a helyi formátumobjektum `getEffective()` metódusának meghívásával kaphatja meg.

A következő példában látható, hogyan lehet hatékony értékeket lekérni. Feltételezi, hogy az első dián az első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) szövegdobozzal és legalább egy részlettel.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Az effektív formázási adatok az öröklődés alkalmazása után a jelenleg kiszámított formázást képviselik. A jelenlegi implementációban egyes effektív adatobjektumok, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformateffectivedata/), lehetnek belsőleg gyorsítótárazva. A `getEffective()` újbóli meghívása a szülő vagy örökölt formázás megváltoztatása után frissítheti a gyorsítótárazott adatokat, és egy korábban lekért objektum már nem tükrözheti a korábbi állapotot. Ha későbbi újrahasználathoz meg kell őrizni az effektív értékeket, másolja a szükséges tulajdonságokat, például betűmagasság, kitöltőszín, betűstílus vagy igazítás, saját adatobjektumába.
{{% /alert %}}

## **A kamera hatékony tulajdonságainak lekérése**

Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérését. A [ICameraEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icameraeffectivedata/) interfész egy változtathatatlan objektumot reprezentál, amely a hatékony kamera tulajdonságokat tartalmazza. Egy [ICameraEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icameraeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/) révén érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/) számára.

```java
import com.aspose.slides.*;

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

## **A fényrig hatékony tulajdonságainak lekérése**

Aspose.Slides lehetővé teszi a fényrig hatékony tulajdonságainak lekérését. A [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilightrigeffectivedata/) interfész egy változtathatatlan objektumot reprezentál, amely a hatékony fényrig tulajdonságokat tartalmazza. Egy [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilightrigeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/) révén érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/) számára.

```java
import com.aspose.slides.*;

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

## **A forma rézsút (bevel) hatékony tulajdonságainak lekérése**

Aspose.Slides lehetővé teszi a forma rézsút (bevel) hatékony tulajdonságainak lekérését. A [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapebeveleffectivedata/) interfész egy változtathatatlan objektumot reprezentál, amely a forma hatékony felület-relief tulajdonságait tartalmazza. Egy [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapebeveleffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/) révén érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/) számára.

```java
import com.aspose.slides.*;

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

## **A szövegdoboz hatékony tulajdonságainak lekérése**

Az Aspose.Slides segítségével lekérheti egy szövegdoboz hatékony tulajdonságait. Az [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformateffectivedata/) interfész tartalmazza a hatékony szövegdoboz formázási tulajdonságokat.

```java
import com.aspose.slides.*;

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

## **A szövegstílus hatékony tulajdonságainak lekérése**

Az Aspose.Slides segítségével lekérheti egy szövegstílus hatékony tulajdonságait. Az [ITextStyleEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextstyleeffectivedata/) interfész tartalmazza a hatékony szövegstílus tulajdonságokat.

```java
import com.aspose.slides.*;

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

## **A hatékony betűmagasság érték lekérése**

Az Aspose.Slides segítségével lekérheti a hatékony betűmagasságot. Az alábbi kód bemutatja, hogyan változik egy részlet hatékony betűmagassága, ha különböző prezentációs struktúraszinteken helyi betűmagasságot állítanak be.

```java
import com.aspose.slides.*;

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

Az Aspose.Slides segítségével lekérheti a különböző táblázatrészek hatékony kitöltési formázását. Az [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformateffectivedata/) interfész tartalmazza a hatékony kitöltési formázási tulajdonságokat. A cella formázásnak nagyobb prioritása van, mint a sorformázásnak, a sorformázásnak nagyobb prioritása van, mint az oszlopformázásnak, és az oszlopformázásnak nagyobb prioritása van, mint a teljes táblázat formázásának.

Ennek következtében az [ICellFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icellformateffectivedata/) tulajdonságokat használják a táblázat cellájának megrajzolásához. Az alábbi kódrészlet bemutatja, hogyan lehet a különböző táblázatrészek hatékony kitöltési formázását lekérni. Feltételezi, hogy az első dián az első alakzat egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itable/) példány.

```java
import com.aspose.slides.*;

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

### A `getEffective()` egy pillanatképet ad vissza?

Nem mindig. Az effektív adatok a öröklődés alkalmazása után számított formázást képviselik, de egyes effektív adatobjektumok belsőleg gyorsítótárazva lehetnek. A későbbi `getEffective()` hívás újraszámíthatja a formázást és frissítheti a gyorsítótárat, így egy korábban lekért objektumot nem szabad tartós pillanatképnek tekinteni.

### Mikor kell újból olvasni a hatékony tulajdonságokat?

Hívja meg a `getEffective()` metódust újra, miután megváltoztatta a helyi formázást, a szülő stílusokat, az elrendezés formázását, a mester formázását vagy a prezentáció szintű alapértelmezéseket. A következő hívás újraértékeli a formázási hierarchiát, és a jelenlegi hatékony eredményt adja vissza.

### A layout/mester dia módosítása vagy eltávolítása befolyásolja a már lekért hatékony tulajdonságokat?

Igen, a változás a következő `getEffective()` híváskor érvényesül. Ha egy szülő formázási forrás megváltozik vagy eltávolításra kerül, a korábban lekért hatékony adatok elavultak lehetnek. Amint a `getEffective()` újra meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a betűtípusok, színek, méretek vagy egyéb értékek módosulhatnak.

### Módosíthatok értékeket a hatékony adatobjektumokon keresztül?

Nem. A hatékony adatobjektumok csak a kiszámított értékeket teszik elérhetővé. A módosításokat a helyi formázási objektumokban kell végrehajtani, majd újból lekérni a hatékony értékeket.

### Mi történik, ha egy tulajdonság nincs beállítva sem az alakzat szintjén, sem az elrendezésen/mesteren, sem a globális beállításokban?

A hatékony értéket a szabványos mechanizmus határozza meg, amely tartalmazza a PowerPoint és az Aspose.Slides alapértelmezéseit. Ez a feloldott érték a jelenlegi hatékony adatok részévé válik.

### Egy hatékony betűértékből megmondható, hogy melyik szint biztosította a méretet vagy a betűtípust?

Nem közvetlenül. A hatékony adat csak a végső értéket adja vissza. A forrást a részlet, a bekezdés, a szövegdoboz és a szövegstílus helyi értékeinek ellenőrzésével a layout, a mester és a prezentáció szintjén lehet megállapítani, ahol az első explicit meghatározás szerepel.

### Miért néznek ki néha az effektív értékek azonosnak a helyi értékekkel?

Mert a helyi érték végsővé vált (nem volt szükség magasabb szintű öröklődésre). Ilyen esetben az effektív érték megegyezik a helyi értékkel.

### Mikor kell hatékony tulajdonságokat használni, és mikor csak a helyi tulajdonságokkal dolgozni?

Használja a hatékony adatokat, ha a „renderelt” eredményre van szüksége az összes öröklődés alkalmazása után, például színek, behúzások vagy méretek összehangolásához. Ha ezeket az értékeket későbbi formázási változásoktól függetlenül meg kell őrizni, másolja a szükséges tulajdonságokat saját objektumába. Ha egy adott szinten szeretné megváltoztatni a formázást, módosítsa a helyi tulajdonságokat, és ha szükséges, olvassa újra a hatékony adatokat a változás ellenőrzéséhez.