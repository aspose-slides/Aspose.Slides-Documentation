---
title: Szövegdobozok kezelése prezentációkban PHP-vel
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
description: "Aspose.Slides for PHP egyszerűvé teszi a szövegdobozok létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, ezáltal javítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon a szövegek általában szövegdobozokban vagy alakzatokban jelennek meg. Ezért a diára szöveget hozzáadni egy szövegdobozt kell létrehozni, majd szöveget helyezni a dobobozba. Az Aspose.Slides for PHP via Java a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) osztályt biztosítja, amely lehetővé teszi, hogy szöveget tartalmazó alakzatot adjunk hozzá.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides emellett a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztályt is biztosítja, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden a `Shape` osztályon keresztül hozzáadott alakzat képes szöveget tárolni. Azonban a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) osztályon keresztül hozzáadott alakzatok tartalmazhatnak szöveget.
{{% /alert %}}

{{% alert title="Megjegyzés" color="warning" %}} 
Ezért, ha olyan alakzattal dolgozunk, amelyhez szöveget szeretnénk hozzáadni, ellenőrizni kell, hogy az `AutoShape` osztályon keresztül lett-e létrehozva. Csak ekkor lehet a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) tulajdonsággal dolgozni, amely az `AutoShape` alatti tulajdonság. Lásd a [Update Text](/slides/hu/php-java/manage-textbox/#update-text) szakaszt ezen az oldalon.
{{% /alert %}}

## **Szövegdoboz létrehozása a dián**

A szövegdoboz létrehozásához a dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) objektumot, amelynek alakzattípusa [Rectangle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapetype/#Rectangle), a dián megadott pozícióban, és szerezze meg az újonnan hozzáadott `AutoShape` objektum referenciáját.  
4. Adjon egy `TextFrame` elemet az `AutoShape` objektumhoz, amely szöveget tartalmaz. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*  
5. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a PHP kód – a fenti lépések megvalósítása – megmutatja, hogyan adjon szöveget egy diához:

```php
  # Példányosítja a Presentation objektumot
  $pres = new Presentation();
  try {
    # Lekéri a prezentáció első diáját
    $sld = $pres->getSlides()->get_Item(0);
    # Hozzáad egy AutoShape-et típusként Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Hozzáad egy TextFrame-et a Rectangle-hez
    $ashp->addTextFrame(" ");
    # Eléri a szövegkeretet
    $txtFrame = $ashp->getTextFrame();
    # Létrehozza a Paragraph objektumot a szövegkerethez
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Létrehozza a Portion objektumot a bekezdéshez
    $portion = $para->getPortions()->get_Item(0);
    # Beállítja a szöveget
    $portion->setText("Aspose TextBox");
    # Mentés a prezentációt a lemezre
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alakzat ellenőrzése szövegdobozként**

Az Aspose.Slides a [isTextBox](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/istextbox/) metódust biztosítja az [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) osztályból, amely lehetővé teszi az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Szövegdoboz és alakzat](istextbox.png)

Ez a PHP kód megmutatja, hogyan ellenőrizhetjük, hogy egy alakzat szövegdobozként lett-e létrehozva:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Vegye figyelembe, hogy ha egyszerűen csak egy autoshape‑t ad hozzá a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) osztály `addAutoShape` metódusával, az autoshape `isTextBox` metódusa `false` értéket ad vissza. Azonban ha szöveget ad a autoshape‑hez a `addTextFrame` vagy a `setText` metódussal, a `isTextBox` tulajdonság `true` értéket ad vissza.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() false-t ad vissza
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() true-t ad vissza

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() false-t ad vissza
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() true-t ad vissza

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() false-t ad vissza
$shape3->addTextFrame("");
// shape3->isTextBox() false-t ad vissza

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() false-t ad vissza
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() false-t ad vissza
```

## **Oszlopok hozzáadása szövegdobozhoz**

Az Aspose.Slides a [setColumnCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/setcolumncount/) és a [setColumnSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/setcolumnspacing/) metódusokat biztosítja a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/) osztályból, amelyek lehetővé teszik oszlopok hozzáadását a szövegdobozokhoz. Megadhatja a szövegdobozban lévő oszlopok számát, és beállíthatja az oszlopok közötti távolságot pontban.

Ez a kód demonstrálja a leírt műveletet:

```php
  $pres = new Presentation();
  try {
    # Lekéri a prezentáció első diáját
    $slide = $pres->getSlides()->get_Item(0);
    # Hozzáad egy AutoShape-et típusként Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Hozzáad egy TextFrame-et a Rectangle-hez
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Lekéri a TextFrame szövegformátumát
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Meghatározza a oszlopok számát a TextFrame-ben
    $format->setColumnCount(3);
    # Meghatározza az oszlopok közötti távolságot
    $format->setColumnSpacing(10);
    # Mentés a prezentációt
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Oszlopok hozzáadása szövegkerethez**

Az Aspose.Slides for PHP via Java a [setColumnCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/setcolumncount/) metódust biztosítja a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/) osztályból, amely lehetővé teszi oszlopok hozzáadását a szövegkeretekben. Ezen tulajdonság segítségével megadhatja a kívánt oszlopszámot a szövegkeretben.

Ez a PHP kód megmutatja, hogyan adjon egy oszlopot egy szövegkerethez:

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

Az Aspose.Slides lehetővé teszi a szövegdobozban vagy a prezentációban lévő összes szöveg módosítását vagy frissítését.

Ez a PHP kód bemutat egy műveletet, amely a prezentációban lévő összes szöveget frissíti vagy megváltoztatja:

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
            # Végigiterál a bekezdés minden részén
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Megváltoztatja a szöveget

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Megváltoztatja a formázást

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

Hiperhivatkozást szúrhat be egy szövegdobozba. Amikor a szövegdobozra kattintanak, a felhasználók a hivatkozás megnyitására kerülnek irányításra.

A hivatkozást tartalmazó szövegdoboz hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adjon hozzá egy `AutoShape` objektumot, amelynek `ShapeType` értéke `Rectangle`, a dián megadott pozícióban, és szerezze meg az újonnan hozzáadott AutoShape objektum referenciáját.  
4. Adjon egy `TextFrame` elemet az `AutoShape` objektumhoz, amely *Aspose TextBox* alapértelmezett szöveget tartalmaz.  
5. Hozza létre a `HyperlinkManager` osztályt.  
6. Rendeljen hiperhivatkozást a [setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) metódus segítségével a `TextFrame` kívánt részéhez.  
7. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a PHP kód – a fenti lépések megvalósítása – megmutatja, hogyan adjon szövegdobozt hiperhivatkozással egy diához:

```php
  # Példányosít egy Presentation osztályt, amely egy PPTX-et képvisel
  $pres = new Presentation();
  try {
    # Lekéri a prezentáció első diáját
    $slide = $pres->getSlides()->get_Item(0);
    # Hozzáad egy AutoShape objektumot, amelynek típusa Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Átalakítja az alakzatot AutoShape típusra
    $pptxAutoShape = $shape;
    # Eléri az AutoShape-hez kapcsolódó ITextFrame tulajdonságot
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Szöveget ad a kerethez
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Beállítja a hiperhivatkozást a rész szövegéhez
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

**Mi a különbség egy szövegdoboz és egy szöveghelyettesítő között, amikor mesterdiákkal dolgozunk?**

Egy [placeholder](/slides/hu/php-java/manage-placeholder/) örökli a stílust/pozíciót a [master](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) diától, és felülírható a [layouts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) diáknál, míg egy hagyományos szövegdoboz egy független objektum egy adott dián, és nem változik, amikor elrendezéseket váltunk.

**Hogyan hajthatok végre tömeges szövegcserét a prezentációban anélkül, hogy a diagramok, táblázatok és SmartArt szövegét módosítanám?**

Korlátozza az iterációt azokra az autoshape‑okra, amelyeknek van szövegkerete, és hagyja ki a beágyazott objektumokat ([charts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/)) úgy, hogy külön gyűjteményeken járja be őket, vagy kihagyja ezeket az objektumtípusokat.