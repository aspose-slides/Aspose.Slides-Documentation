---
title: "Sorok és oszlopok kezelése PowerPoint táblázatokban PHP használatával"
linktitle: "Sorok és oszlopok"
type: docs
weight: 20
url: /hu/php-java/manage-rows-and-columns/
keywords:
- "táblázat sor"
- "táblázat oszlop"
- "első sor"
- "táblázat fejléc"
- "sor klónozása"
- "oszlop klónozása"
- "sor másolása"
- "oszlop másolása"
- "sor eltávolítása"
- "oszlop eltávolítása"
- "sor szövegformázás"
- "oszlop szövegformázás"
- "táblázat stílus"
- "PowerPoint"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Kezelje a táblázat sorait és oszlopait PowerPoint-ban az Aspose.Slides for PHP via Java segítségével, és gyorsítsa fel a prezentáció szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides for PHP via Java lehetővé teszi a táblázatszerkezet és formázás kezelését PowerPoint‑prezentációkban a [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) osztályon keresztül. Megjelölhet egy fejlécsort, klónozhat vagy eltávolíthat sorokat és oszlopokat, valamint alkalmazhat szöveges formázást egy teljes sorra vagy oszlopra.

Ez a cikk ezeknek a műveleteknek a magyarázatát adja PHP példákkal. Bemutatja, hogyan lehet lekérni egy táblázat stílus‑presetjét a későbbi újrahasználathoz is. A táblázatsorok és -oszlopok indexelése nullától indul.

## **Sor magasságának szabályozása**

Használja a [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) metódust a sor minimális magasságának pontban való beállításához. Ez egy alsó határ, nem fix magasság. A [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) visszaadja a tényleges magasságot. A sort a [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/) segítségével érheti el.

A példa betölti a [row-height-input.pptx](row-height-input.pptx) fájlt, amelyben a táblázat az első dián az első alakzat. Az első sor 70 pontnál kezdődik. A cellák 18 pontos Arial szöveget, sortörést és 6 pontos felső‑alsó margót használnak; a második oszlopban a hosszabb szöveg több sorba törik. A példa a minimumot 100 pontra növeli, majd 20 pontra csökkenti, minden változtatás után kiírja a tényleges magasságot, és elmenti a két eredményt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A mellékelt prezentációval a minimum növelése helyet ad a sornak. A csökkentés eltávolítja ezt a felesleges helyet, de a tényleges magasság továbbra is nagyobb lesz, mint 20 pont, mert a szöveg és a cellamargók több helyet igényelnek. A minimum önmagában nem kényszerítheti a sort a tartalom által igényelt hely alá.

Több tényező befolyásolja a tényleges magasságot:

- **Szöveg és betűméret:** hosszabb szöveg, kifejezett sortörés vagy nagyobb betűméret több függőleges helyet igényelhet.
- **Sortörés és oszlopszélesség:** sortörés engedélyezése esetén a [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) használata a oszlop szélességének csökkentésével több sort eredményezhet. Szélesebb oszlop csökkentheti a függőleges helyigényt.
- **Cellamargók:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) és [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) függőleges helyet adnak hozzá. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) és [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) csökkentik a szöveg számára elérhető szélességet, ami további sortörést okozhat.

Ezzel a táblázattal, amelyben nincsenek egyesített cellák, a legtöbb függőleges helyet igénylő cella határozza meg a sor alacsonyabb határát. A sor rövidebbé tételéhez gyakran a szöveget, a betűméretet vagy a margókat kell csökkenteni, vagy egy oszlopot szélesíteni.

Az alábbi képek ugyanazt a táblázatot mutatják azonos méretben. A bemutatott eredményekben a tényleges magasságok 70, 100 és 55,2 pont voltak: az utolsó sor magasabb maradt a 20 pontos minimumnál. A pontos szövegmérések a környezetben elérhető betűkészletektől függően változhatnak. Töltse le a mentett eredményeket: [increased minimum](row-height-increased.pptx) és [decreased minimum](row-height-decreased.pptx).

| Eredeti: minimum 70 pt, tényleges 70 pt | Növelve: minimum 100 pt, tényleges 100 pt | Csökkentve: minimum 20 pt, tényleges 55.2 pt |
| --- | --- | --- |
| ![Eredeti táblázat 70 pontos első sorral.](row-height-before.png) | ![Táblázat az első sor minimum 100 pontra növelése után.](row-height-increased.png) | ![Táblázat az első sor minimum 20 pontra csökkentése után; a tördelődő szöveg miatt a sor magasabb marad a minimumnál.](row-height-decreased.png) |

## **Az első sor beállítása fejlécnek**

Használja a [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) metódust az első sor fejlécként való megjelöléséhez. A megjelenése a táblára alkalmazott táblázat‑stílustól függ.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztállyal.
2. Hozza el az első diát.
3. Hozza el a táblázatot, amely az első alakzatként szerepel a dián.
4. Engedélyezze a fejlécformázást az első sorra.
5. Mentse el a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amelyben a táblázat az első dián az első alakzat. Az első sorra engedélyezi a fejlécformázást, majd elmenti a `First_row_header.pptx` fájlt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Táblázatsor vagy -oszlop klónozása**

Klónozzon sorokat vagy oszlopokat a tartalom és a formázás újbóli felhasználásához. A másolatot hozzáfűzheti a táblázat végéhez, vagy egy adott pozícióba beillesztheti.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztállyal.
2. Hozza el az első diát.
3. Határozza meg az oszlopok szélességét és a sorok magasságát.
4. Adjon hozzá egy táblázatot a [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) metódussal.
5. Klónozza a kívánt sorokat.
6. Klónozza a kívánt oszlopokat.
7. Mentse el a módosított prezentációt.

A példa a `Test.pptx` fájlt igényli, amely legalább egy diát tartalmaz. Létrehoz egy három oszlopos, öt soros táblázatot pontban megadott méretekkel. A másolatként az első sort és oszlopot a végére fűzi, majd a második sort és oszlopot a 3‑as indexen (a negyedik pozíció) szúrja be. Az eredményül kapott táblázat hét sort és öt oszlopot tartalmaz. A `false` argumentum letiltja a szomszédos egyesített sorok vagy oszlopok klónozását; ebben a táblázatban nincs egyesített cella.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sor vagy oszlop eltávolítása egy táblázatból**

Távolítson el sorokat vagy oszlopokat, amelyekre már nincs szükség a táblázatban. Egy elem eltávolítása eltolja a mögötte lévő sorok vagy oszlopok indexeit.

1. Hozzon létre egy prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztállyal.
2. Hozza el az első diát.
3. Határozza meg az oszlopok szélességét és a sorok magasságát.
4. Adjon hozzá egy táblázatot a [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) metódussal.
5. Távolítsa el a második sort és a második oszlopot.
6. Mentse el a módosított prezentációt.

Ez a példa egy három‑háromas táblázatot hoz létre, majd az 1‑es indexű sort és oszlopot eltávolítja, így egy két‑két táblázat marad a `TestTable_out.pptx` fájlban. A méretek pontban vannak megadva. A `false` argumentum letiltja a szomszédos egyesített sorok vagy oszlopok eltávolítását; ebben a táblázatban nincs egyesített cella.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Szövegformázás beállítása táblázatsoros szinten**

Alkalmazzon szövegformázást egy teljes sorra, hogy a cellái egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdés‑formázást és szövegtájolást anélkül, hogy egyenként formázná a cellákat.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztállyal.
2. Hozza el a táblázatot az első dián.
3. Használja a [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) metódust az első sorra.
4. Használja a [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) és a [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) metódusokat az első sorra.
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) metódust a második sorra.
6. Mentse el a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amelyben a táblázat az első dián az első alakzat, és legalább két sor található benne. 25 pontos szöveget, jobbra igazítást és 20 pontos jobb bekezdésmargót alkalmaz az első sorra, majd a második sorra függőleges szöveget állít be.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Szövegformázás beállítása táblázatoszlopos szinten**

Alkalmazzon szövegformázást egy teljes oszlopra, hogy a cellái egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdés‑formázást és szövegtájolást anélkül, hogy egyenként formázná a cellákat.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztállyal.
2. Hozza el a táblázatot az első dián.
3. Használja a [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) metódust az első oszlopra.
4. Használja a [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) és a [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) metódusokat az első oszlopra.
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) metódust a második oszlopra.
6. Mentse el a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amelyben a táblázat az első dián az első alakzat, és legalább két oszlop található benne. 25 pontos szöveget, jobbra igazítást és 20 pontos jobb bekezdésmargót alkalmaz az első oszlopra, majd a második oszlopra függőleges szöveget állít be.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Táblázat stílus tulajdonságainak lekérdezése**

Használja a [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) metódust a táblázatra alkalmazott preset lekérdezéséhez, amelyet később egy másik táblázaton is felhasználhat. Ez a presetet azonosítja, nem pedig az egyes cellák felülírt formázását.

A példa létrehoz egy táblázatot, alkalmazza a [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) presetet, majd visszaolvassa a presetet. Kiírja a `DarkStyle1` értékének megfelelő egész számot, és elmenti a táblázatot a `table.pptx` fájlban.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/érték/elrendezés/master témát, és továbbra is felülírhatja a kitöltéseket, szegélyeket és a szövegszíneket a téma felett.

**Rendezhetem a táblázatsorokat, mint az Excelben?**

Nem, az Aspose.Slides táblázatoknak nincs beépített rendezése vagy szűrése. Először memóriában rendezze az adatokat, majd töltse újra a táblázatsorokat ebben a sorrendben.

**Lehetnek csíkozott (csíkozott) oszlopok, miközben egyedi színeket tartok meg bizonyos cellákon?**

Igen. Kapcsolja be a csíkozott oszlopokat, majd felülírja a konkrét cellákat helyi formázással; a cellaszintű formázás felülbírálja a táblázat stílusát.