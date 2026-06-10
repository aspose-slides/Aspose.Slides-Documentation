---
title: Prezentációs témák kezelése PHP-ben
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/php-java/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- téma színe
- kiegészítő paletta
- téma betűtípusa
- téma stílusa
- téma effektusa
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Az Aspose.Slides for PHP (Java) segítségével a prezentációk fő témáit kezelheted, testreszabhatod és átalakíthatod PowerPoint fájlokban, biztosítva a konzisztens márkázást."
---
## **Bevezetés**

A prezentációs téma meghatározza a tervezési elemek tulajdonságait. Amikor egy prezentációs témát választasz, lényegében egy meghatározott vizuális elemek és azok tulajdonságainak halmazát választod ki.

A PowerPointben a téma színeket, [fonts](/slides/hu/php-java/powerpoint-fonts/), [background styles](/slides/hu/php-java/presentation-background/), és effektusokat tartalmaz.

![theme-constituents](theme-constituents.png)

## **Téma színének módosítása**

A PowerPoint téma meghatározott színkészletet használ a dia különböző elemeihez. Ha nem tetszenek a színek, új színeket alkalmazva módosíthatod a témát. Az új téma szín kiválasztásához az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SchemeColor) felsorolásban értékeket biztosít.

Ez a PHP kód megmutatja, hogyan változtathatod meg a téma akcentus színét:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Az eredményül kapott szín tényleges értékét így határozhatod meg:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

A színváltoztatás szemléltetéséhez egy másik elemet hozunk létre, és hozzárendeljük az akcentus színt (az előző műveletből). Ezután megváltoztatjuk a színt a témában:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

Az új szín automatikusan alkalmazásra kerül mindkét elemre.

### **Téma színének beállítása egy további palettából**

Amikor a fő téma színre (1) fényerő-transzformációkat alkalmazol, a további palettáról (2) színek jönnek létre. Ezeket a téma színeket beállíthatod és lekérheted.

![additional-palette-colors](additional-palette-colors.png)

**1** – Fő téma színek  

**2** – A további palettáról származó színek.

Ez a PHP kód bemutat egy műveletet, ahol a további palettaszíneket a fő téma színből nyerjük, majd alakzatokban használjuk:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Akcent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Akcent 4, világosabb 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Akcent 4, világosabb 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Akcent 4, világosabb 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Akcent 4, sötétebb 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Akcent 4, sötétebb 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **`SchemeColor` leképezése a `ColorScheme` színekre**

Amikor a [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) használatával dolgozol, észreveheted, hogy a következő téma színértékeket tartalmazza:

`Background1`, `Background2`, `Text1`, és `Text2`.

Azonban a `Presentation::getMasterTheme()::getColorScheme()` egy [ColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorscheme/) objektumot ad vissza, amely a megfelelő színeket a következőképpen jeleníti meg:

`Dark1`, `Dark2`, `Light1`, és `Light2`.

Ez a különbség csak a névben van. Ezek az értékek ugyanazokra a téma színhelyekre vonatkoznak, és a leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus konverzió a `Text`/`Background` és a `Dark`/`Light` között. Egyszerűen csak alternatív nevek ugyanazokra a téma színekre.

Ez a néveltérés a Microsoft Office terminológiájából származik. A régebbi Office verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` elnevezéseket használták, míg az újabb felhasználói felületek ugyanazokat a helyeket `Text 1`, `Background 1`, `Text 2` és `Background 2` néven jelenítik meg.

## **Téma betűtípusa módosítása**

Az Aspose.Slides ezen speciális azonosítókat használja a témák és egyéb célokra szánt betűtípusok kiválasztásához (hasonlóan a PowerPointhez):

* **+mn-lt** – Szövegtörzs betűkészlet Latin (Minor Latin Font)
* **+mj-lt** – Fejléc betűkészlet Latin (Major Latin Font)
* **+mn-ea** – Szövegtörzs betűkészlet Kelet-Ázsiai (Minor East Asian Font)
* **+mj-ea** – Fejléc betűkészlet Kelet-Ázsiai (Major East Asian Font)

Ez a PHP kód megmutatja, hogyan rendeljük hozzá a Latin betűtípust egy témaelemhez:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

Ez a PHP kód megmutatja, hogyan változtathatod meg a prezentációs téma betűtípusát:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

A betűtípus minden szövegdobozban frissülni fog.

{{% alert color="primary" title="TIP" %}}  
Érdemes megnézni a [PowerPoint fonts](/slides/hu/php-java/powerpoint-fonts/).  
{{% /alert %}}

## **Téma háttérstílusának módosítása**

Alapértelmezés szerint a PowerPoint alkalmazás 12 előre definiált hátteret kínál, de egy tipikus prezentációban csak 3-at mentenek el.

![todo:image_alt_text](presentation-design_8.png)

Például, ha elmented a prezentációt a PowerPoint alkalmazásban, a következő PHP kóddal megállapíthatod, hány előre definiált háttér található a prezentációban:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}}  
A [BackgroundFillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) tulajdonságot a [FormatScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FormatScheme) osztályból használva hozzáadhatsz vagy elérheted a háttérstílust egy PowerPoint témában.  
{{% /alert %}}  

Ez a PHP kód megmutatja, hogyan állítható be a prezentáció háttere:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Index útmutató**: 0 a kitöltés nélküli állapotot jelenti. Az indexelés 1‑től kezdődik.

{{% alert color="primary" title="TIP" %}}  
Érdemes megnézni a [PowerPoint Background](/slides/hu/php-java/presentation-background/).  
{{% /alert %}}

## **Téma effektusának módosítása**

Egy PowerPoint téma általában 3 értéket tartalmaz minden stílussorozathoz. Ezeket a sorozatokat összekapcsolják a 3 effektussal: finom, közepes és intenzív. Például ez a végeredmény, ha az effektusok egy adott alakzatra kerülnek alkalmazásra:

![todo:image_alt_text](presentation-design_10.png)

A [FormatScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FormatScheme) osztályból származó 3 tulajdonság ([FillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FormatScheme#getEffectStyles--)) használatával a téma elemeit még rugalmasabban módosíthatod, mint a PowerPoint opciói.

Ez a PHP kód megmutatja, hogyan változtatható meg egy téma effektus az elemek részeinek módosításával:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

A változások a kitöltőszínben, kitöltéstípusban, árnyékhatásban stb.:

![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

**Alkalmazhatok egy témát egyetlen diára anélkül, hogy a mastert módosítanám?**  

Igen. Az Aspose.Slides támogatja a diaszintű téma felülírásokat, így egy helyi témát alkalmazhatsz csak arra a diára, miközben a master téma változatlan marad (a [SlideThemeManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidethememanager/) segítségével).

**Mi a legbiztonságosabb módja egy téma átvitelének az egyik prezentációból a másikba?**  

A [Clone slides](/slides/hu/php-java/clone-slides/) a masterrel együtt a célprezentációba másolva megőrzi az eredeti mastert, elrendezéseket és a kapcsolódó témát, így a megjelenés konzisztens marad.

**Hogyan tekinthetem meg a „hatékony” értékeket minden öröklődés és felülírás után?**  

Használd az API „effective” nézeteit (/slides/hu/php-java/shape-effective-properties/) a téma/szín/betűtípus/effektus esetén. Ezek a végleges, feloldott tulajdonságokat adják vissza a master és a helyi felülírások alkalmazása után.