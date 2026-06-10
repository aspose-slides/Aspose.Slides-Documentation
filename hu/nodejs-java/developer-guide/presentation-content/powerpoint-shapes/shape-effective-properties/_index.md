---
title: Alakzatok hatékony tulajdonságainak lekérése prezentációkból JavaScript-ben
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/nodejs-java/shape-effective-properties/
keywords:
- alakzati tulajdonságok
- kamera tulajdonságok
- fényrig
- élezett alakzat
- szövegdoboz
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan számolja ki és alkalmazza az Aspose.Slides for Node.js Java segítségével a hatékony alakzati tulajdonságokat a pontos PowerPoint rendereléshez."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és **hatékony** tulajdonságok közötti különbséget. A helyi értékek olyan értékek, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. Részlet tulajdonságai egy dián.  
1. Sablon alakzat szövegstílusai egy elrendezésen vagy mesterdián, ha a részlet szövegtáblájának alakzata rendelkezik ilyen stílussal.  
1. Általános szövegbeállítások egy prezentációban.  

A helyi értékek meghatározhatók vagy elhagyhatók bármely szinten. Amikor az Aspose.Slides-nek szüksége van a végleges, "rendereltként" megjelenő formázásra, feloldja az öröklődési láncot, és **hatékony** értékeket ad vissza. Ezeket a helyi formátum objektum `getEffective` metódusának meghívásával kaphatja meg.

Az alábbi példa bemutatja, hogyan lehet hatékony értékeket lekérni. Feltételezi, hogy az első dián az első alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) szövegtáblával és legalább egy résszel rendelkezik.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Az effektív formázási adatok a jelenlegi kiszámított formázást képviselik az öröklődés alkalmazása után. A jelenlegi megvalósításban egyes effektív adatobjektumok belsőleg gyorsítótárazva lehetnek. A `getEffective` újbóli meghívása a szülő vagy az örökölt formázás módosítása után frissítheti a gyorsítótárat, és egy korábban lekért objektum már nem feltétlenül tükrözi a korábbi állapotot. Ha meg kell őriznie az effektív értékeket későbbi újrahasználatra, másolja a szükséges tulajdonságokat, például a betűmagasságot, a kitöltő színt, a betűstílust vagy az igazítást, egy saját adatobjektumba.
{{% /alert %}}

## **Kamera hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérését. A hatékony kamera adatobjektum változtathatatlan kamera tulajdonságokat tartalmaz, és a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) által visszaadott hatékony értékeken keresztül érhető el.

Az alábbi kódrészlet bemutatja, hogyan lehet a kamera hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat 3D formázással rendelkezik.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Fényrig hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a fényrig hatékony tulajdonságainak lekérését. A hatékony fényrig adatobjektum változtathatatlan fényrig tulajdonságokat tartalmaz, és a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) által visszaadott hatékony értékeken keresztül érhető el.

Az alábbi kódrészlet bemutatja, hogyan lehet a fényrig hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat 3D formázással rendelkezik.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Élezett alakzat hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi egy alakzat élezett tulajdonságainak hatékony lekérését. A hatékony alakzat élezett adatobjektum változtathatatlan felületrelief tulajdonságokat tartalmaz egy alakzatra, és a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) által visszaadott hatékony értékeken keresztül érhető el.

Az alábbi kódrészlet bemutatja, hogyan lehet egy alakzat felső élezésének hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat 3D formázással rendelkezik.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Szövegdoboz hatékony tulajdonságainak lekérése**

Az Aspose.Slides használatával lekérhető egy szövegdoboz hatékony tulajdonságai. A visszaadott hatékony adatobjektum a szövegdoboz formázási tulajdonságait tartalmazza.

Az alábbi kódrészlet bemutatja, hogyan lehet a szövegdoboz formázási tulajdonságait hatékonyan lekérni. Feltételezi, hogy az első dián az első alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) szövegtáblával rendelkezik.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Szövegstílus hatékony tulajdonságainak lekérése**

Az Aspose.Slides használatával lekérhető egy szövegstílus hatékony tulajdonságai. A visszaadott hatékony adatobjektum a szövegstílus tulajdonságait tartalmazza.

Az alábbi kódrészlet bemutatja, hogyan lehet a szövegstílus hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) szövegtáblával rendelkezik.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **A betűmagasság hatékony értékének lekérése**

Az Aspose.Slides használatával lekérhető a betűmagasság hatékony értéke. Az alábbi kód bemutatja, hogyan változik egy részlet hatékony betűmagassága, amikor a helyi betűmagasság értékeket különböző prezentációs struktúraszinteken állítják be.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Táblázat hatékony kitöltési formátumának lekérése**

Az Aspose.Slides használatával lekérhető a táblázat különböző részeinek hatékony kitöltési formázása. A visszaadott hatékony adatobjektum a kitöltési formázási tulajdonságokat tartalmazza. A cella formázása magasabb prioritással bír, mint a sor formázása, a sor formázása magasabb prioritással bír, mint az oszlop formázása, és az oszlop formázása magasabb prioritással bír, mint a táblázat egészére vonatkozó formázás.

Ennek eredményeként a hatékony cellaformázási tulajdonságok kerülnek felhasználásra a táblázat cellájának kirajzolásához. Az alábbi kódrészlet bemutatja, hogyan lehet a táblázat különböző részeinek hatékony kitöltési formázását lekérni. Feltételezi, hogy az első dián az első alakzat egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/) .

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Visszaadja a `getEffective` egy pillanatképet?**

Nem mindig. A hatékony adatok a kiszámított formázást képviselik az öröklődés alkalmazása után, de egyes hatékony adatobjektumok belsőleg gyorsítótárazva lehetnek. Egy későbbi `getEffective` hívás újraszámolhatja a formázást és frissítheti a gyorsítótárat, ezért egy korábban lekért objektumot nem szabad tartós pillanatképnek tekinteni.

**Mikor kell újra beolvasni a hatékony tulajdonságokat?**

Hívja újra a `getEffective`‑et a helyi formázás, a szülő stílusok, az elrendezés formázása, a mester formázása vagy a prezentáció szintű alapértelmezések módosítása után. A következő hívás újraértékeli a formázási hierarchiát és visszaadja a jelenlegi hatékony eredményt.

**Az elrendezés/mester dia módosítása vagy eltávolítása befolyásolja a már lekért hatékony tulajdonságokat?**

Igen, de a változás a következő `getEffective` híváskor jelenik meg. Ha egy szülő formázási forrás megváltozik vagy eltávolításra kerül, a korábban lekért hatékony adatok elavultak lehetnek. Amint a `getEffective` újra meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a betűtípusok, színek, méretek vagy egyéb értékek módosulhatnak.

**Módosíthatok értékeket a hatékony adatobjektumokon keresztül?**

Nem. A hatékony adatobjektumok csak a számított értékeket mutatják. A módosításokat a helyi formázási objektumokban kell végrehajtani, majd újra lekérni a hatékony értékeket.

**Mi történik, ha egy tulajdonság nincs beállítva az alakzat szintjén, sem az elrendezésen/mesteren, sem a globális beállításokban?**

A hatékony értéket az alapértelmezett mechanizmus határozza meg, amely magában foglalja a PowerPoint és az Aspose.Slides alapértelmezéseit. Ez a feloldott érték része lesz a jelenlegi hatékony adatoknak.

**Egy hatékony betűértékből meg tudom állapítani, melyik szint biztosította a méretet vagy a betűtípust?**

Nem közvetlenül. A hatékony adat a végleges értéket adja vissza. A forrás meghatározásához ellenőrizze a helyi értékeket a részleten, bekezdésen, szövegdobozon és a szövegstílusokon az elrendezésen, a mesteren és a prezentáción belül, hogy hol jelenik meg először a kifejezett meghatározás.

**Miért tűnik néha a hatékony érték megegyezni a helyi értékkel?**

Mert a helyi érték végsővé vált (nem volt szükség magasabb szintű öröklődésre). Ilyen esetekben a hatékony érték megegyezik a helyivel.

**Mikor kell hatékony tulajdonságokat használni, és mikor csak a helyi tulajdonságokkal dolgozni?**

Használja a hatékony adatokat, ha a "rendereltként" megjelenő eredményre van szüksége az összes öröklődés alkalmazása után, például színek, behúzások vagy méretek igazításához. Ha ezeket az értékeket későbbi formázási változásoktól függetlenül meg kell őrizni, másolja a szükséges tulajdonságokat egy saját objektumba. Ha egy adott szinten szeretne formázást módosítani, változtassa meg a helyi tulajdonságokat, majd – ha szükséges – olvassa újra a hatékony adatokat a végeredmény ellenőrzéséhez.