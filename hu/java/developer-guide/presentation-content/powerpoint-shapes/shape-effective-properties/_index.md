---
title: Alakzat hatékony tulajdonságainak lekérése prezentációkból Java-ban
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/java/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- fényrig
- ferde alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan számítja ki és alkalmazza az Aspose.Slides for Java a hatékony alakzattulajdonságokat a pontos PowerPoint rendereléshez."
---
## **Áttekintés**

Ez a téma a **helyi** és **hatékony** tulajdonságok közötti különbséget magyarázza. A helyi értékek azok az értékek, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. Részlet tulajdonságok egy dián.
1. Prototípus alakzat szövegstílusok egy elrendezésen vagy mester diámon, ha a részlet szövegkeret alakzatának van ilyen.
1. Globális szövegbeállítások egy prezentációban.

A helyi értékek bármely szinten definiálhatók vagy elhagyhatók. Amikor az Aspose.Slidesnek a végső, „rendereltként megjelenő” formázásra van szüksége, feloldja az öröklődési láncot, és **hatékony** értékeket ad vissza. Ezeket a helyi formátumobjektum `getEffective` metódusának meghívásával kaphatja meg.

A következő példa azt mutatja, hogyan lehet lekérni a hatékony értékeket. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) egy szövegkerettel és legalább egy résszel.

```java
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

{{% alert color="primary" %}}
A hatékony formázási adatok a öröklődés alkalmazása után számított aktuális formázást képviselik. A jelenlegi megvalósításban egyes hatékony adatok objektumai, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPortionFormatEffectiveData), belsőleg is gyorsítótárazottak lehetnek. A `getEffective` újbóli meghívása a szülő vagy örökölt formázás módosítása után frissítheti a gyorsítótárat, és egy korábban lekért objektum már nem feltétlenül tükrözi a korábbi állapotot. Ha a hatékony értékeket későbbi újbóli felhasználásra szeretné megőrizni, másolja a szükséges tulajdonságokat, például betűmagasságot, kitöltőszínt, betűstílust vagy igazítást a saját adatobjektumába.
{{% /alert %}}

## **Kamera hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérését. A [ICameraEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICameraEffectiveData) interfész egy immutábilis objektumot képvisel, amely a kamera hatékony tulajdonságait tartalmazza. Egy [ICameraEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICameraEffectiveData) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormatEffectiveData) segítségével érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormat) számára.

A következő kódrészlet bemutatja, hogyan lehet a kamera hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzatában 3D formázás van.

```java
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

Az Aspose.Slides lehetővé teszi egy fényrig hatékony tulajdonságainak lekérését. Az [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ILightRigEffectiveData) interfész egy immutábilis objektum, amely a fényrig hatékony tulajdonságait tartalmazza. Egy [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ILightRigEffectiveData) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormatEffectiveData) által érhető el, amely hatékony értékeket ad a [IThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormat).

Az alábbi kódrészlet bemutatja, hogyan lehet a fényrig hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzatában 3D formázás van.

```java
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

## **A bevel alakzat hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a bevel alakzat hatékony tulajdonságainak lekérését. A [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeBevelEffectiveData) interfész egy immutábilis objektum, amely egy alakzat hatékony felületrelief tulajdonságait tartalmazza. Egy [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeBevelEffectiveData) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormatEffectiveData) által érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IThreeDFormat) számára.

Az alábbi kódrészlet bemutatja, hogyan lehet egy alakzat felső beveljének hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzatában 3D formázás van.

```java
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

Az Aspose.Slides segítségével lekérheti egy szövegkeret hatékony tulajdonságait. A [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormatEffectiveData) interfész a szövegkeret hatékony formázási tulajdonságait tartalmazza.

A következő kódrészlet bemutatja, hogyan lehet a szövegkeret hatékony formázási tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) egy szövegkerettel.

```java
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

Az Aspose.Slides segítségével lekérheti egy szövegstílus hatékony tulajdonságait. A [ITextStyleEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextStyleEffectiveData) interfész a szövegstílus hatékony tulajdonságait tartalmazza.

A következő kódrészlet bemutatja, hogyan lehet a szövegstílus hatékony tulajdonságait lekérni. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) egy szövegkerettel.

```java
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

Az Aspose.Slides segítségével lekérheti a hatékony betűmagasságot. Az alábbi kód bemutatja, hogyan változik egy részlet hatékony betűmagassága, miután a helyi betűmagasság értékeket különböző prezentációs szerkezeti szinteken állították be.

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

## **Táblázat hatékony kitöltési formátumának lekérése**

Az Aspose.Slides segítségével lekérheti a különböző táblázatrészek hatékony kitöltési formázását. A [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IFillFormatEffectiveData) interfész a hatékony kitöltési formázási tulajdonságokat tartalmazza. A cella formázása nagyobb prioritással bír, mint a sorformázás, a sorformázás nagyobb prioritással bír, mint az oszlopformázás, és az oszlopformázás nagyobb prioritással bír, mint a teljes táblázat formázása.

Ennek következtében a [ICellFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICellFormatEffectiveData) tulajdonságait használja a táblázat cellájának rajzolásához. A következő kódrészlet bemutatja, hogyan lehet a táblázat különböző részeinek hatékony kitöltési formázását lekérni. Feltételezi, hogy az első dia első alakzata egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable).

```java
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

**A `getEffective` egy pillanatképet ad vissza?**

Nem mindig. A hatékony adatok a öröklődés alkalmazása után számított formázást képviselik, de egyes hatékony adatobjektumok belsőleg gyorsítótárazottak lehetnek. Egy későbbi `getEffective` hívás újraszámíthatja a formázást és frissítheti a gyorsítótárat, ezért a korábban lekért objektust nem szabad állandó pillanatképnek tekinteni.

**Mikor kell újra lekérni a hatékony tulajdonságokat?**

Hívja újra a `getEffective` metódust a helyi formázás, a szülő stílusok, az elrendezés formázása, a mester formázása vagy a prezentáció szintű alapértelmezések módosítása után. A következő hívás újraértékeli a formázási hierarchiát, és visszaadja az aktuális hatékony eredményt.

**A elrendezés/mester dia módosítása vagy eltávolítása befolyásolja-e a már lekért hatékony tulajdonságokat?**

Igen, de a változás a következő `getEffective` híváskor jelenik meg. Ha egy szülő formázási forrás megváltozik vagy eltávolításra kerül, a korábban lekért hatékony adatok elavultak lehetnek. Miután a `getEffective` újra meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a kapott betűtípusok, színek, méretek vagy egyéb értékek megváltozhatnak.

**Módosíthatok-e értékeket a hatékony adatok objektumaiban?**

Nem. A hatékony adatok objektumai csak a számított értékeket mutatják. Változtassa meg a helyi formázási objektumokat, majd kérje le újból a hatékony értékeket.

**Mi történik, ha egy tulajdonság nincs beállítva az alakzat szintjén, sem az elrendezésen/mesteren, sem a globális beállításokban?**

A hatékony értéket az alapértelmezett mechanizmus határozza meg, amely magában foglalja a PowerPoint és az Aspose.Slides alapértelmezéseit. Ez a megoldott érték a jelenlegi hatékony adatok részévé válik.

**A hatékony betűértékből megállapítható, hogy melyik szint biztosította a méretet vagy a betűtípust?**

Nem közvetlenül. A hatékony adatok a végső értéket adják vissza. A forrás megtalálásához ellenőrizze a helyi értékeket a részlet, bekezdés, szövegkeret és a szövegstílusok szintjén az elrendezésen, a mesteren és a prezentáción, hogy hol jelenik meg az első explicit meghatározás.

**Miért tűnnek néha a hatékony értékek azonosnak a helyi értékekkel?**

Mert a helyi érték végsővé vált (nem volt szükség magasabb szintű öröklődésre). Ilyen esetekben a hatékony érték megegyezik a helyivel.

**Mikor használjak hatékony tulajdonságokat, és mikor csak a helyiékkel dolgozzak?**

Használja a hatékony adatokat, amikor az összes öröklődés alkalmazása után a „renderelt” eredményre van szükség, például színek, behúzások vagy méretek egyeztetéséhez. Ha ezeket az értékeket a későbbi formázási változásoktól függetlenül szeretné megőrizni, másolja a szükséges tulajdonságokat saját objektumába. Ha egy adott szinten szeretne formázást módosítani, változtassa meg a helyi tulajdonságokat, majd szükség esetén olvassa újra a hatékony adatokat az eredmény ellenőrzéséhez.