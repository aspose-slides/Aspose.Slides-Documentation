---
title: Alakzat hatékony tulajdonságainak lekérése a prezentációkból Java-ban
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/java/shape-effective-properties/
keywords:
- alakzati tulajdonságok
- kamera tulajdonságok
- fényrig
- lépcsőzetes alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan számolja ki és alkalmazza az Aspose.Slides for Java a hatékony alakzati tulajdonságokat a pontos PowerPoint megjelenítéshez."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és **hatékony** tulajdonságok közötti különbséget. A helyi értékek olyan értékek, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. Rész tulajdonságok egy dián.  
1. Prototípus alakzat szövegstílusok egy elrendezésen vagy fődián, ha a részlet szövegkeret alakzatának van ilyen.  
1. Globális szövegbeállítások egy prezentációban.

A helyi értékek bárhol definiálhatók vagy elhagyhatók. Amikor az Aspose.Slidesnek szüksége van a végleges, "renderelt" formázásra, feloldja az öröklődési láncot, és **hatékony** értékeket ad vissza. Ezeket a `getEffective` metódus meghívásával kaphatja meg a helyi formátumobjektumon.

Az alábbi példa bemutatja, hogyan lehet hatékony értékeket lekérni. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) szövegkerettel és legalább egy résszel rendelkezik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
A hatékony formázási adatok a jelenleg kiszámított formázást képviselik, miután az öröklődés alkalmazásra került. A jelenlegi megvalósításban egyes hatékony adatobjektumok, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPortionFormatEffectiveData), belsőleg gyorsítótárazva lehetnek. A `getEffective` újbóli meghívása a szülő vagy az örökölt formázás módosítása után frissítheti a gyorsítótárazott adatot, és a korábban lekért objektum már nem tükrözi a korábbi állapotot. Ha meg szeretné őrizni a hatékony értékeket későbbi újrafelhasználáshoz, másolja a szükséges tulajdonságokat, mint a betűmagasság, a kitöltőszín, a betűstílus vagy az igazítás, saját adatobjektumába.
{{% /alert %}}

## **A kamera hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérését. A [ICameraEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICameraEffectiveData) interfész egy immutable (változtathatatlan) objektumot képvisel, amely a kamera hatékony tulajdonságait tartalmazza. Egy [ICameraEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICameraEffectiveData) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormatEffectiveData) révén érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormat) számára.

Az alábbi kódrészlet bemutatja, hogyan lehet a kamera hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata 3D formázással rendelkezik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **A fényrig hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a fényrig (light rig) hatékony tulajdonságainak lekérését. A [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ILightRigEffectiveData) interfész egy immutable objektumot képvisel, amely a fényrig hatékony tulajdonságait tartalmazza. Egy [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ILightRigEffectiveData) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormatEffectiveData) révén érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormat) számára.

Az alábbi kódrészlet bemutatja, hogyan lehet a fényrig hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata 3D formázással rendelkezik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **A lépcsőzetes alakzat hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi egy alakzat lépcsőzetes (bevel) tulajdonságainak hatékony lekérését. A [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeBevelEffectiveData) interfész egy immutable objektumot képvisel, amely a alakzat hatékony felületrelief tulajdonságait tartalmazza. Egy [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeBevelEffectiveData) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormatEffectiveData) révén érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormat) számára.

Az alábbi kódrészlet bemutatja, hogyan lehet a forma felső lépcsőzetes (bevel) tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata 3D formázással rendelkezik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **A szövegkeret hatékony tulajdonságainak lekérése**

Az Aspose.Slides segítségével lekérheti egy szövegkeret hatékony tulajdonságait. A [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormatEffectiveData) interfész hatékony szövegkeret-formázási tulajdonságokat tartalmaz.

Az alábbi kódrészlet bemutatja, hogyan lehet a szövegkeret hatékony formázási tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) szövegkerettel rendelkezik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **A szövegstílus hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi egy szövegstílus hatékony tulajdonságainak lekérését. A [ITextStyleEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextStyleEffectiveData) interfész hatékony szövegstílus‑tulajdonságokat tartalmaz.

Az alábbi kódrészlet bemutatja, hogyan lehet a szövegstílus hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) szövegkerettel rendelkezik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **A hatékony betűmagasság értékének lekérése**

Az Aspose.Slides segítségével lekérheti a hatékony betűmagasságot. Az alábbi kód bemutatja, hogyan változik egy részlet hatékony betűmagassága, miután a helyi betűmagasság‑értékeket a prezentáció különböző szerkezeti szintjein állítják be.

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

## **A tábla hatékony kitöltési formátumának lekérése**

Az Aspose.Slides segítségével lekérheti a táblázat különböző részeinek hatékony kitöltési formátumát. A [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IFillFormatEffectiveData) interfész hatékony kitöltési formázási tulajdonságokat tartalmaz. A cella formázásának magasabb prioritása van, mint a sor formázásának, a sor formázásának magasabb prioritása van, mint az oszlop formázásának, és az oszlop formázásának magasabb prioritása van, mint a teljes táblázat formázásának.

Ennek következtében a [ICellFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICellFormatEffectiveData) tulajdonságai használatosak a táblacella kirajzolásához. Az alábbi kódrészlet bemutatja, hogyan lehet a táblázat különböző részeinek hatékony kitöltési formátumát lekérni. Feltételezi, hogy az első dia első alakzata egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

### A `getEffective` visszaad egy pillanatképet?

Nem mindig. A hatékony adatok a számított formázást képviselik az öröklődés alkalmazása után, de egyes hatékony adatobjektumok belsőleg gyorsítótárazva lehetnek. Egy későbbi `getEffective` hívás újraszámíthatja a formázást és frissítheti a gyorsítótárat, ezért a korábban lekért objektumot nem szabad tartós pillanatképként kezelni.

### Mikor kell újra beolvasni a hatékony tulajdonságokat?

Hívja újra a `getEffective` metódust, miután megváltoztatta a helyi formázást, a szülő stílusokat, az elrendezés formázását, a fődia formázását vagy a prezentáció‑szintű alapértelmezéseket. A következő hívás újraértékeli a formázási hierarchiát, és a aktuális hatékony eredményt adja vissza.

### Befolyásolja egy elrendezés/fődia módosítása vagy eltávolítása a már lekért hatékony tulajdonságokat?

Igen, de a változás csak a következő `getEffective` híváskor jelenik meg. Ha egy szülő formázási forrás megváltozik vagy eltávolításra kerül, a korábban lekért hatékony adatok elavultak lehetnek. Amint a `getEffective` újra meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a betűtípusok, színek, méretek vagy egyéb értékek módosulhatnak.

### Módosíthatok értékeket a hatékony adatobjektumokon keresztül?

Nem. A hatékony adatobjektumok csak a kiszámított értékeket exponálják. A módosításokat a helyi formázási objektumokban kell elvégezni, majd újra kell lekérni a hatékony értékeket.

### Mi történik, ha egy tulajdonság nincs beállítva sem az alakzat szintjén, sem az elrendezésen/fődián, sem a globális beállításokban?

A hatékony értéket az alapértelmezett mechanizmus határozza meg, amely tartalmazza a PowerPoint és az Aspose.Slides alapértelmezéseit. Ez a feloldott érték a jelenlegi hatékony adatok részévé válik.

### A hatékony betűértékből meg tudom határozni, hogy melyik szint biztosította a méretet vagy a betűtípust?

Nem közvetlenül. A hatékony adatok a végleges értéket adják vissza. A forrás megtalálásához ellenőrizze a helyi értékeket a részlet, bekezdés, szövegkeret és a szövegstílusok (elrendezés, fődia, prezentáció) szintjein, hogy lássa, hol jelenik meg először a kifejezett definíció.

### Miért néznek néha azonosnak a hatékony és a helyi értékek?

Mert a helyi érték végül végleges lett (nem volt szükség magasabb szintű öröklődésre). Ilyen esetben a hatékony érték megegyezik a helyi értékkel.

### Mikor érdemes hatékony tulajdonságokat használni, és mikor csak a helyiével dolgozni?

Használja a hatékony adatokat, amikor a „renderelt” eredményre van szükség az összes öröklődés alkalmazása után, például színek, behúzások vagy méretek egyeztetéséhez. Ha ezeket az értékeket későbbi formázási változások ellenére is meg szeretné őrizni, másolja a szükséges tulajdonságokat saját objektumába. Ha egy adott szinten szeretne formázást módosítani, változtassa meg a helyi tulajdonságokat, majd ha szükséges, olvassa újra a hatékony adatokat a végeredmény ellenőrzéséhez.