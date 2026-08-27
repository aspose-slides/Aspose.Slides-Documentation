---
title: Szövegdobozok kezelése prezentációkban PHP használatával
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/php-java/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Az Aspose.Slides for PHP lehetővé teszi szövegdobozok egyszerű létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, elősegítve a prezentáció automatizálását."
---
## **Bevezetés**

A diákon lévő szövegek általában szövegdobozokban vagy alakzatokban vannak. Ezért a diára szöveg hozzáadásához először szövegdobozt kell létrehozni, majd szöveget helyezni a dobozba. Az Aspose.Slides for PHP via Java a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) osztályt biztosítja, amely lehetővé teszi egy szöveget tartalmazó alakzat hozzáadását.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides emellett a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztályt is biztosítja, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden, a `Shape` osztályon keresztül hozzáadott alakzat tud szöveget tartalmazni. A [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) osztályon keresztül hozzáadott alakzatok azonban tartalmazhatnak szöveget.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Ezért, ha egy olyan alakzattal dolgozik, amelyhez szöveget szeretne hozzáadni, ellenőriznie kell, hogy az `AutoShape` osztályon keresztül lett-e létrehozva. Csak ekkor lesz lehetősége a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) használatára, amely az `AutoShape` tulajdonsága. Tekintse meg a [Update Text](/slides/hu/php-java/manage-textbox/#update-text) szekciót ezen az oldalon.
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

A szövegdoboz létrehozásához egy dián kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) objektumot, amelynek alakzat típusa [Rectangle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapetype/#Rectangle), a dián egy megadott pozícióban, és szerezze meg a frissen hozzáadott `AutoShape` objektum referenciáját.  
4. Adjon egy `TextFrame`-et az `AutoShape` objektumhoz, amely szöveget tartalmaz. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*  
5. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a PHP kód – a fenti lépések megvalósítása – megmutatja, hogyan adhat szöveget egy diához:

```php
  # Példányosítja a Presentation objektumot
  $pres = new Presentation();
  try {
    # Megkapja a prezentáció első diáját
    $sld = $pres->getSlides()->get_Item(0);
    # Hozzáad egy AutoShape-ot, amelynek típusa Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Hozzáad egy TextFrame-et a Rectangle objektumhoz
    $ashp->addTextFrame(" ");
    # Eléri a szövegkeretet
    $txtFrame = $ashp->getTextFrame();
    # Létrehozza a Paragraph objektumot a szövegkerethez
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Létrehozza a Portion objektumot a bekezdéshez
    $portion = $para->getPortions()->get_Item(0);
    # Beállítja a szöveget
    $portion->setText("Aspose TextBox");
    # Elmenti a prezentációt a lemezre
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szövegdoboz alakzat ellenőrzése**

Az Aspose.Slides a [isTextBox](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/istextbox/) metódust kínálja a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) osztályból, amely lehetővé teszi az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Szövegdoboz és alakzat](istextbox.png)

Ez a PHP kód megmutatja, hogyan ellenőrizhető, hogy egy alakzat szövegdobozként lett-e létrehozva:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Fontos megjegyezni, hogy ha egyszerűen csak egy autoshapet ad hozzá a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) osztály `addAutoShape` metódusával, akkor az autoshape `isTextBox` metódusa `false` értéket ad vissza. Azonban miután szöveget ad az autoshapehöz a `addTextFrame` vagy a `setText` metódussal, a `isTextBox` tulajdonság `true` értéket ad vissza.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() false értéket ad vissza
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() true értéket ad vissza

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() false értéket ad vissza
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() true értéket ad vissza

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() false értéket ad vissza
$shape3->addTextFrame("");
// shape3->isTextBox() false értéket ad vissza

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() false értéket ad vissza
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() false értéket ad vissza
```

## **Az a alakzat megtalálása, amelyik a TextFrame-et birtokolja**

Általános szövegfeldolgozó kódban előfordulhat, hogy egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) objektumot kap, anélkül, hogy tudná, melyik prezentációs objektum tartalmazza azt. Használja a [TextFrame::getParentShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentShape) metódust a tulajdonos [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) visszakereséséhez.

Egy olyan szövegkeret esetén, amely egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) vagy egy másik szöveget tartalmazó alakzat része, a [TextFrame::getParentShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentShape) visszaadja a tulajdonost, míg a [TextFrame::getParentCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentCell) `null` értéket ad. Mindkét metódus csak olvasási célú navigációt biztosít, ezért hívásuk nem változtatja meg a tulajdonjogot. Mindig ellenőrizze a visszatérő értéket a `java_is_null` függvénnyel, mielőtt a shape-hez hozzáférne.

A shape- és táblacella-tulajdonosokat, valamint a SmartArt csomópontokhoz kapcsolódó alakzatokat bemutató teljes példa a [Search and Replace Text](/slides/hu/php-java/search-and-replace-text/) oldalon található.

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az Aspose.Slides a [setColumnCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/setcolumncount/) és a [setColumnSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/setcolumnspacing/) metódusokat a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/) osztályból kínálja, amelyek lehetővé teszik oszlopok hozzáadását a szövegdobozokhoz. Megadhatja az oszlopok számát, valamint a pontokban kifejezett oszloptávolságot az oszlopok között.

Ez a kód demonstrálja a leírt műveletet:

```php
  $pres = new Presentation();
  try {
    # Lekéri a prezentáció első diáját
    $slide = $pres->getSlides()->get_Item(0);
    # Hozzáad egy AutoShape-ot, amelynek típusa Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Hozzáad egy TextFrame-et a Rectangle-hez
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Lekéri a TextFrame szövegformátumát
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Megadja az oszlopok számát a TextBox-ban
    $format->setColumnCount(3);
    # Megadja az oszlopok közötti távolságot
    $format->setColumnSpacing(10);
    # Elmenti a prezentációt
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Oszlopok hozzáadása egy TextFrame-hez**
Az Aspose.Slides for PHP via Java a [setColumnCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/setcolumncount/) metódust biztosítja a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/) osztályból, amely lehetővé teszi oszlopok hozzáadását a szövegkeretekhez. Ezen tulajdonság segítségével megadhatja a kívánt oszlopszámot egy TextFrame-ben.

Ez a PHP kód megmutatja, hogyan adhat egy oszlopot egy szövegkerethez:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi egy szövegdobozban vagy egy teljes prezentációban lévő összes szöveg módosítását vagy frissítését.

Ez a PHP kód bemutat egy olyan műveletet, amelyben a prezentáció összes szövege frissítésre vagy módosításra kerül:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Ellenőrzi, hogy az alakzat támogatja-e a szövegkeretet (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Végigiterál a szövegkeret bekezdésein
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Végigiterál a bekezdés minden részletén
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Módosítja a szöveget

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Módosítja a formázást

            }
          }
        }
      }
    }
    # Elmenti a módosított prezentációt
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szövegdoboz hozzáadása hiperhivatkozással** 

Hiperhivatkozást helyezhet el egy szövegdobozban. Amikor a szövegdobozra kattintanak, a felhasználók a link megnyitására kerülnek.

A hivatkozást tartalmazó szövegdoboz hozzáadásához kövesse ezeket a lépéseket:

1. Hozzon létre egy `Presentation` példányt.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adjon hozzá egy `AutoShape` objektumot, amelynek `ShapeType`-ja `Rectangle`, a dián egy megadott pozícióban, és szerezze meg a frissen hozzáadott AutoShape objektum referenciáját.  
4. Adjon egy `TextFrame`-et az `AutoShape` objektumhoz, amely alapértelmezett szövegként *Aspose TextBox*-ot tartalmaz.  
5. Hozza létre a `HyperlinkManager` osztályt.  
6. Rendeljen hiperhivatkozást a [setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) metódussal a `TextFrame` kedvenc részehez.  
7. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a PHP kód – a fenti lépések megvalósítása – megmutatja, hogyan adhat hiperhivatkozással ellátott szövegdobozt egy diához:

```php
  # Elindít egy Presentation osztály példányt, amely egy PPTX-et képvisel
  $pres = new Presentation();
  try {
    # Lekéri a prezentáció első diáját
    $slide = $pres->getSlides()->get_Item(0);
    # Hozzáad egy AutoShape objektumot, amelynek típusa Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Átkonvertálja az alakzatot AutoShape-re
    $pptxAutoShape = $shape;
    # Hozzáfér az AutoShape-hez tartozó ITextFrame tulajdonsághoz
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Hozzáad némi szöveget a kerethez
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Beállítja a hiperhivatkozást a részlet szövegéhez
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Elmenti a PPTX prezentációt
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Mi a különbség egy szövegdoboz és egy szöveghelyőrző között, amikor fődiasorokkal dolgozunk?**

A [placeholder](/slides/hu/php-java/manage-placeholder/) az [master](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) stílusát/pozícióját örökli, és a [layouts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) során felülírható, míg egy szabályos szövegdoboz egy önálló objektum egy adott dián, és nem változik, ha elrendezést váltunk.

**Hogyan végezhetek tömeges szövegcsere műveletet a prezentációban anélkül, hogy a diagramok, táblázatok és SmartArt szövegét érinteném?**

Korlátozza az iterációt azokra az autoshapekre, amelyek szövegkerettel rendelkeznek, és hagyja ki a beágyazott objektumokat ([charts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/)) úgy, hogy azok gyűjteményeit külön bejárja, vagy egyszerűen kihagyja ezeket az objektumtípusokat.