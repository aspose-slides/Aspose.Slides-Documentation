---
title: Správa textových polí v prezentacích pomocí PHP
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/php-java/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat sloupec textu
- přidat hyperodkaz
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Aspose.Slides pro PHP usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, čímž zlepšuje automatizaci vašich prezentací."
---
## **Úvod**

Texty na snímcích se typicky nacházejí v textových polích nebo tvarech. Proto pro přidání textu na snímek musíte nejprve přidat textové pole a poté do něj vložit text. Aspose.Slides pro PHP via Java poskytuje třídu [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/), která umožňuje přidat tvar obsahující text.

{{% alert title="Info" color="info" %}}

Aspose.Slides také poskytuje třídu [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/), která umožňuje přidávat tvary na snímky. Ne všechny tvary přidané pomocí třídy `Shape` však mohou obsahovat text. Tvary přidané pomocí třídy [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) mohou text obsahovat.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Proto, když pracujete s tvarem, do kterého chcete přidat text, měli byste zkontrolovat a potvrdit, že byl vytvořen pomocí třídy `AutoShape`. Teprve poté budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/), což je vlastnost třídy `AutoShape`. Viz sekce [Update Text](/slides/cs/php-java/manage-textbox/#update-text) na této stránce.

{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole na snímku postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na první snímek nově vytvořené prezentace. 
3. Přidejte objekt [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) s typem tvaru nastaveným na [Rectangle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapetype/#Rectangle) na zadané pozici na snímku a získejte odkaz na nově přidaný objekt `AutoShape`.
4. Přidejte `TextFrame` k objektu `AutoShape`, který bude obsahovat text. V níže uvedeném příkladu jsme přidali tento text: *Aspose TextBox*
5. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento PHP kód—implementace výše uvedených kroků—ukazuje, jak přidat text na snímek:

```php
  # Vytvoří instanci Presentation
  $pres = new Presentation();
  try {
    # Získá první snímek v prezentaci
    $sld = $pres->getSlides()->get_Item(0);
    # Přidá AutoShape s typem nastaveným na Obdélník
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Přidá TextFrame do Obdélníku
    $ashp->addTextFrame(" ");
    # Přistoupí k textovému rámci
    $txtFrame = $ashp->getTextFrame();
    # Vytvoří objekt Paragraph pro textový rámec
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Vytvoří objekt Portion pro odstavec
    $portion = $para->getPortions()->get_Item(0);
    # Nastaví text
    $portion->setText("Aspose TextBox");
    # Uloží prezentaci na disk
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kontrola, zda se jedná o textové pole**

Aspose.Slides poskytuje metodu [isTextBox](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/istextbox/) ze třídy [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/), která umožňuje prozkoumat tvary a identifikovat textová pole.

![Text box and shape](istextbox.png)

Tento PHP kód ukazuje, jak zjistit, zda byl tvar vytvořen jako textové pole:

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

Všimněte si, že pokud jen přidáte auto‑shape pomocí metody `addAutoShape` ze třídy [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/), metoda `isTextBox` vrátí `false`. Po přidání textu do auto‑shape pomocí metody `addTextFrame` nebo `setText` však vlastnost `isTextBox` vrátí `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() vrací false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() vrací true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() vrací false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() vrací true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() vrací false
$shape3->addTextFrame("");
// shape3->isTextBox() vrací false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() vrací false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() vrací false
```

## **Nalezení tvaru, který vlastní TextFrame**

V obecném kódu pro zpracování textu můžete obdržet [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) aniž byste věděli, který objekt prezentace jej obsahuje. Použijte metodu [TextFrame::getParentShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentShape) k návratu k vlastnímu [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/).

Pro textový rámec, který patří k [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) nebo jinému tvaru obsahujícímu text, metoda [TextFrame::getParentShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentShape) vrací vlastníka a metoda [TextFrame::getParentCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentCell) vrací `null`. Obě metody poskytují jen read‑only navigaci, takže jejich volání nezmění vlastnictví. Vždy před přístupem k tvaru zkontrolujte vrácenou hodnotu pomocí `java_is_null`.

Kompletní příklad, který identifikuje vlastníky tvarů i buněk tabulky, včetně tvarů spojených s uzly SmartArt, najdete v sekci [Search and Replace Text](/slides/cs/php-java/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Aspose.Slides poskytuje metody [setColumnCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/setcolumncount/) a [setColumnSpacing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/setcolumnspacing/) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/), které umožňují přidávat sloupce do textových polí. Můžete určit počet sloupců a nastavit mezery mezi sloupci v bodech.

Tento kód demonstruje popsanou operaci:

```php
  $pres = new Presentation();
  try {
    # Získá první snímek v prezentaci
    $slide = $pres->getSlides()->get_Item(0);
    # Přidá AutoShape s typem nastaveným na Obdélník
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Přidá TextFrame do Obdélníku
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Získá formát textu TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Určuje počet sloupců v TextFrame
    $format->setColumnCount(3);
    # Určuje mezery mezi sloupci
    $format->setColumnSpacing(10);
    # Uloží prezentaci
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání sloupců do TextFrame**
Aspose.Slides for PHP via Java poskytuje metodu [setColumnCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/setcolumncount/) ze třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/), která umožňuje přidávat sloupce v textových rámečcích. Pomocí této vlastnosti můžete nastavit požadovaný počet sloupců v TextFrame.

Tento PHP kód ukazuje, jak přidat sloupec do TextFrame:

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

## **Aktualizace textu**

Aspose.Slides umožňuje změnit nebo aktualizovat text obsažený v textovém poli nebo ve všech textech v celé prezentaci. 

Tento PHP kód ukazuje operaci, při které jsou všechny texty v prezentaci aktualizovány nebo změněny:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Kontroluje, zda tvar podporuje textový rámec (IAutoShape).
        $autoShape = $shape;
        # Prochází odstavce v textovém rámci
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          # Prochází každou část (portion) v odstavci
          foreach($paragraph->getPortions() as $portion) {
            $portion->setText($portion->getText()->replace("years", "months"));// Změní text

            $portion->getPortionFormat()->setFontBold(NullableBool::True);// Změní formátování

          }
        }
      }
    }
    # Uloží upravenou prezentaci
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání textového pole s hyperodkazem** 

Do textového pole můžete vložit odkaz. Po kliknutí na textové pole se uživatelé přesměrují na tento odkaz. 

Pro přidání textového pole obsahujícího odkaz postupujte takto:

1. Vytvořte instanci třídy `Presentation`. 
2. Získejte odkaz na první snímek nově vytvořené prezentace. 
3. Přidejte objekt `AutoShape` s `ShapeType` nastaveným na `Rectangle` na požadovanou pozici na snímku a získejte odkaz na nově přidaný objekt `AutoShape`.
4. Přidejte `TextFrame` k objektu `AutoShape`, který bude obsahovat *Aspose TextBox* jako výchozí text. 
5. Vytvořte instanci třídy `HyperlinkManager`. 
6. Přiřaďte hyperodkaz pomocí metody [setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) k požadované části `TextFrame`.
7. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento PHP kód—implementace výše uvedených kroků—ukazuje, jak přidat textové pole s hyperodkazem na snímek:

```php
  # Vytvoří instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek v prezentaci
    $slide = $pres->getSlides()->get_Item(0);
    # Přidá objekt AutoShape s typem nastaveným na Obdélník
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Přetypuje tvar na AutoShape
    $pptxAutoShape = $shape;
    # Přistoupí k vlastnosti ITextFrame spojené s AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Přidá nějaký text do rámce
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Nastaví hyperodkaz pro text části
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Uloží PPTX prezentaci
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jaký je rozdíl mezi textovým polem a zástupným textovým polem při práci s hlavními snímky?**

[Placeholder](/slides/cs/php-java/manage-placeholder/) dědí styl/umístění z [masteru](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/) a může být přepsán v [layoutech](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/), zatímco běžné textové pole je nezávislý objekt na konkrétním snímku a nemění se při přepínání layoutů.

**Jak mohu provést hromadnou náhradu textu v celé prezentaci, aniž bych zasáhl do textu uvnitř grafů, tabulek a SmartArt?**

Omezte iteraci jen na auto‑shapes, které mají TextFrame, a vyloučte vložené objekty ([charts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/cs/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/)) tím, že jejich kolekce projdete odděleně nebo tyto typy objektů přeskočíte.