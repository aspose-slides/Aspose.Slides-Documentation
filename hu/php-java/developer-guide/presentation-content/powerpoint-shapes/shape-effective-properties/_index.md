---
title: Alakzat hatékony tulajdonságainak lekérése a prezentációkból PHP-ban
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/php-java/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- fény rig
- perem alakzat
- szövegdoboz
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel, hogyan számítja ki és alkalmazza az Aspose.Slides for PHP (Java-n keresztül) a hatékony alakzat tulajdonságokat a pontos PowerPoint megjelenítéshez."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és **hatékony** tulajdonságok közötti különbséget. A helyi értékek olyan értékek, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. Részlet tulajdonságai egy dián.
1. Prototype alakzat szövegstílusai egy elrendezésen vagy mesterdián, ha a részlet szövegdoboz alakzata rendelkezik ilyennel.
1. Globális szövegbeállítások egy prezentációban.

A helyi értékek meghatározhatók vagy elhagyhatók bármely szinten. Amikor az Aspose.Slides-nek a végső „renderelt” formázásra van szüksége, feloldja az öröklődési láncot, és **hatékony** értékeket ad vissza. Ezeket a helyi formátumobjektum `getEffective` metódusának meghívásával kaphatja meg.

Az alábbi példa bemutatja, hogyan lehet hatékony értékeket lekérni. Feltételezi, hogy az első dián az első alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) szövegdobozzal és legalább egy résszel rendelkezik.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
A hatékony formázási adatok a jelenlegi számított formázást képviselik az öröklődés alkalmazása után. A jelenlegi megvalósításban egyes hatékony adatobjektumok, amelyeket például a [PortionFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/geteffective/) metódus ad vissza, lehetnek belsőleg gyorsítótárazva. A `getEffective` újbóli meghívása a szülő vagy az örökölt formázás módosítása után frissítheti a gyorsítótárazott adatokat, és egy korábban lekért objektum már nem feltétlenül tükrözi a korábbi állapotot. Ha a hatékony értékeket későbbi felhasználásra meg kell őrizni, másolja a szükséges tulajdonságokat, például betűmagasság, kitöltőszín, betűstílus vagy igazítás, saját adatobjektumába.
{{% /alert %}}

## **A kamera hatékony tulajdonságainak lekérése**

Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérését. A [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/geteffective/) által visszaadott hatékony adatok a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) végső kamera tulajdonságait tartalmazzák.

Az alábbi kódminta bemutatja, hogyan lehet a kamera hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat 3D formázással rendelkezik.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **A fény rig hatékony tulajdonságainak lekérése**

Aspose.Slides lehetővé teszi a fény rig hatékony tulajdonságainak lekérését. A [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/geteffective/) által visszaadott hatékony adatok a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) végső fény rig tulajdonságait tartalmazzák.

Az alábbi kódminta bemutatja, hogyan lehet a fény rig hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat 3D formázással rendelkezik.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **A perem alakzat hatékony tulajdonságainak lekérése**

Aspose.Slides lehetővé teszi egy alakzat peremének hatékony tulajdonságainak lekérését. A [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/geteffective/) által visszaadott hatékony adatok a [ThreeDFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/) végső felületrelief tulajdonságait tartalmazzák.

Az alábbi kódminta bemutatja, hogyan lehet egy alakzat felső peremének hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat 3D formázással rendelkezik.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Egy szövegdoboz hatékony tulajdonságainak lekérése**

Aspose.Slides használatával lekérheti egy szövegdoboz hatékony tulajdonságait. A [TextFrameFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/geteffective/) által visszaadott hatékony adatok a szövegdoboz formázási tulajdonságait tartalmazzák.

Az alábbi kódminta bemutatja, hogyan lehet a szövegdoboz formázási tulajdonságait hatékonyan lekérni. Feltételezi, hogy az első dián az első alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) szövegdobozzal rendelkezik.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Egy szövegstílus hatékony tulajdonságainak lekérése**

Aspose.Slides használatával lekérheti egy szövegstílus hatékony tulajdonságait. A [TextStyle.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textstyle/geteffective/) által visszaadott hatékony adatok a szövegstílus tulajdonságait tartalmazzák.

Az alábbi kódminta bemutatja, hogyan lehet a szövegstílus hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) szövegdobozzal rendelkezik.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **A hatékony betűmagasság értékének lekérése**

Aspose.Slides használatával lekérheti a hatékony betűmagasságot. Az alábbi kód azt mutatja be, hogyan változik egy részlet hatékony betűmagassága, amikor a helyi betűmagasság értékeket a prezentáció különböző szintjein állítják be.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Egy táblázat hatékony kitöltési formátumának lekérése**

Aspose.Slides használatával lekérheti a táblázat különböző részeinek hatékony kitöltési formátumát. A formátumobjektumok által visszaadott hatékony adatok a [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) tulajdonságait tartalmazzák. A cella formázása magasabb prioritással bír, mint a sor formázása, a sor formázása magasabb, mint az oszlop formázása, és az oszlop formázása magasabb, mint a teljes tábla formázása.

Ennek következtében a hatékony [CellFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellformat/) tulajdonságok kerülnek felhasználásra a tábla cellájának kirajzolásához. Az alábbi kódminta bemutatja, hogyan lehet a táblázat különböző részeinek hatékony kitöltési formátumát lekérni. Feltételezi, hogy az első dián az első alakzat egy [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/) objektum.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**A `getEffective` pillanatképet ad vissza?**

Nem mindig. A hatékony adatok az öröklődés alkalmazása után számított formázást képviselik, de egyes hatékony adatobjektumok belsőleg gyorsítótárazva lehetnek. Egy későbbi `getEffective` hívás újraszámolhatja a formázást és frissítheti a gyorsítótárat, ezért a korábban lekért objektust nem szabad tartós pillanatképként kezelni.

**Mikor kell újra lekérni a hatékony tulajdonságokat?**

Az `getEffective` hívást ismét meghívja a helyi formázás, a szülő stílusok, az elrendezés formázása, a mester formázása vagy a prezentáció szintű alapértelmezések módosítása után. A következő hívás újraértékeli a formázási hierarchiát, és visszaadja a jelenlegi hatékony eredményt.

**Akinosít vagy eltávolít egy elrendezés/mester diát, befolyásolja-e a már lekért hatékony tulajdonságokat?**

Igen, de a változás a következő `getEffective` híváskor jelenik meg. Ha egy szülő formázási forrás megváltozik vagy eltávolításra kerül, a korábban lekért hatékony adatok elavulhatnak. Amint a `getEffective` újból meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a kapott betűtípusok, színek, méretek vagy egyéb értékek megváltozhatnak.

**Módosíthatok értékeket a hatékony adatobjektumokon keresztül?**

Nem. A hatékony adatobjektumok csak a kiszámított értékeket mutatják. Végezze a módosításokat a helyi formázási objektumokon, majd újból kérje le a hatékony értékeket.

**Mi történik, ha egy tulajdonság nincs beállítva sem az alakzat szintjén, sem az elrendezésen/mesteren, sem a globális beállításokban?**

A hatékony értéket az alapértelmezett mechanizmus határozza meg, amely magában foglalja a PowerPoint és az Aspose.Slides alapértelmezéseit. Az így kapott érték a jelenlegi hatékony adatok részévé válik.

**Egy hatékony betűértékből megállapítható, hogy melyik szint biztosította a méretet vagy a betűtípust?**

Nem közvetlenül. A hatékony adatok a végső értéket adják vissza. A forrás megtalálásához ellenőrizze a helyi értékeket a részleten, bekezdésen, szövegdobozon és a szövegstílusokon az elrendezésen, mesteren és a prezentáció szintjén, hogy lássa, hol jelenik meg az első explicit meghatározás.

**Miért tűnnek néha a hatékony értékek azonosnak a helyiekkel?**

Mivel a helyi érték végül végsőnek bizonyult (nem volt szükség magasabb szintű öröklődésre). Ilyen esetekben a hatékony érték megegyezik a helyivel.

**Mikor kell hatékony tulajdonságokat használni, és mikor csak helyi tulajdonságokkal dolgozni?**

Használja a hatékony adatokat, amikor a teljes öröklődés után szükséges a „renderelt” eredmény, például színek, behúzások vagy méretek igazításához. Ha ezeket az értékeket későbbi formázási változásoktól függetlenül szeretné megőrizni, másolja a szükséges tulajdonságokat saját objektumába. Ha egy adott szinten szeretné módosítani a formázást, változtassa meg a helyi tulajdonságokat, majd szükség esetén olvassa újra a hatékony adatokat a végeredmény ellenőrzéséhez.