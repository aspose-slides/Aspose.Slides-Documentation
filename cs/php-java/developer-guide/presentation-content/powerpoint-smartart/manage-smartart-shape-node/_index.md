---
title: "Správa uzlů tvaru SmartArt v prezentacích pomocí PHP"
linktitle: "Uzel tvaru SmartArt"
type: docs
weight: 30
url: /cs/php-java/manage-smartart-shape-node/
keywords:
- uzel SmartArt
- poduzel
- přidat uzel
- pozice uzlu
- přístup k uzlu
- odstranit uzel
- vlastní pozice
- asistenční uzel
- formát výplně
- renderovat uzel
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte uzly tvaru SmartArt v souborech PPT a PPTX pomocí Aspose.Slides pro PHP přes Java. Získejte přehledné ukázky kódu a tipy pro zefektivnění vašich prezentací."
---
## **Přehled**

Grafika SmartArt v prezentacích PowerPoint je organizována pomocí uzlů, které obsahují text a definují strukturu diagramu. Aspose.Slides umožňuje programově pracovat s těmito uzly SmartArt: přidávat nové uzly a poduzly, vkládat poduzly na konkrétní pozici, přistupovat k existujícím uzlům a číst jejich text, úroveň a pozici.

Tento článek vysvětluje, jak spravovat uzly tvarů SmartArt. Ukazuje, jak odstranit uzly, pracovat s poduzly podle indexu nebo pozice, změnit asistenční uzel na běžný uzel, upravit pozici, velikost a rotaci tvarů uzlů SmartArt, nastavit výplňové formáty uzlů a vygenerovat náhledový obrázek pro poduzel SmartArt.

## **Přidání uzlu SmartArt**
Aspose.Slides for PHP via Java poskytuje nejjednodušší API pro správu tvarů SmartArt nejjednodušším způsobem. Následující ukázkový kód pomůže přidat uzel a poduzel do tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Procházejte každým tvarem v první snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/) a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/).
1. [Přidejte nový uzel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnodecollection/#addNode) do tvaru SmartArt **NodeCollection** a nastavte text v TextFrame.
1. Nyní [přidejte](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnodecollection/#addNode) **poduzel** do nově přidaného uzlu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/) a nastavte text v TextFrame.
1. Uložte prezentaci.

```php
  # Načtěte požadovanou prezentaci
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Procházejte všechny tvary v prvním snímku
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Zkontrolujte, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypujte tvar na SmartArt
        $smart = $shape;
        # Přidání nového uzlu SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Přidání textu
        $TemNode->getTextFrame()->setText("Test");
        # Přidání nového poduzlu do rodičovského uzlu. Bude přidán na konec kolekce
        $newNode = $TemNode->getChildNodes()->addNode();
        # Přidání textu
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Ukládání prezentace
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání uzlu SmartArt na konkrétní pozici**
V následujícím ukázkovém kódu je vysvětleno, jak přidat poduzly patřící k příslušným uzlům tvaru SmartArt na konkrétní pozici.

1. Vytvořte instanci třídy Presentation.
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArt) typu **StackedList** do získaného snímku.
1. Přistupte k prvnímu uzlu v přidaném tvaru SmartArt.
1. Nyní přidejte **poduzel** pro vybraný **uzel** na pozici 2 a nastavte jeho text.
1. Uložte prezentaci.

```php
  # Vytvoření instance prezentace
  $pres = new Presentation();
  try {
    # Přístup k snímku prezentace
    $slide = $pres->getSlides()->get_Item(0);
    # Přidání Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Přístup k uzlu SmartArt na indexu 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Přidání nového poduzlu na pozici 2 do rodičovského uzlu
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Přidat text
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Uložit prezentaci
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přístup k uzlu SmartArt**
Následující ukázkový kód pomůže přistupovat k uzlům uvnitř tvaru SmartArt. Všimněte si, že nelze měnit LayoutType SmartArt, protože je pouze pro čtení a je nastaven jen při přidání tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Procházejte každým tvarem v první snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/) a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/).
1. Procházejte všechny **uzly** uvnitř tvaru SmartArt.
1. Přistupte k informacím a zobrazte údaje, jako jsou pozice uzlu SmartArt, úroveň a text.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Získat první snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Procházejte všechny tvary v prvním snímku
    foreach($slide->getShapes() as $shape) {
      # Zkontrolujte, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypujte tvar na SmartArt
        $smart = $shape;
        # Procházejte všechny uzly uvnitř SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Přístup k uzlu SmartArt na indexu i
          $node = $smart->getAllNodes()->get_Item($i);
          # Vytiskněte parametry uzlu SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přístup k poduzlu SmartArt**
Následující ukázkový kód pomůže přistupovat k poduzlům patřícím k příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Procházejte každým tvarem v první snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/) a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/).
1. Procházejte všechny **uzly** uvnitř tvaru SmartArt.
1. Pro každý vybraný uzel **SmartArt** procházejte všechny **poduzly** uvnitř konkrétního uzlu.
1. Přistupte k informacím a zobrazte údaje, jako jsou pozice **poduzlu**, úroveň a text.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Získat první snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Procházejte všechny tvary v prvním snímku
    foreach($slide->getShapes() as $shape) {
      # Zkontrolujte, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypujte tvar na SmartArt
        $smart = $shape;
        # Procházejte všechny uzly uvnitř SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Přístup k uzlu SmartArt na indexu i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Procházejte poduzly v uzlu SmartArt na indexu i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Přístup k poduzlu v uzlu SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Vytiskněte parametry poduzlu SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přístup k poduzlu SmartArt na konkrétní pozici**
V tomto příkladu se naučíte, jak přistupovat k poduzlům na konkrétní pozici patřícím k příslušným uzlům tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Přidejte tvar SmartArt typu **StackedList**.
1. Přistupte k přidanému tvaru SmartArt.
1. Přistupte k uzlu s indexem 0 v přístupu tvaru SmartArt.
1. Nyní pomocí metody **get_Item()** přistupte k **poduzlu** na pozici 1 pro vybraný uzel SmartArt.
1. Přistupte k informacím a zobrazte údaje, jako jsou pozice **poduzlu**, úroveň a text.

```php
  # Vytvořte instanci prezentace
  $pres = new Presentation();
  try {
    # Přístup k prvnímu snímku
    $slide = $pres->getSlides()->get_Item(0);
    # Přidání tvaru SmartArt do prvního snímku
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Přístup k uzlu SmartArt na indexu 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Přístup k poduzlu na pozici 1 v rodičovském uzlu
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Vytiskněte parametry poduzlu SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Odstranění uzlu SmartArt**
V tomto příkladu se naučíte, jak odstranit uzly uvnitř tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Procházejte každým tvarem v první snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/) a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/).
1. Zkontrolujte, zda má SmartArt více než 0 uzlů.
1. Vyberte uzel SmartArt, který má být odstraněn.
1. Nyní odstraňte vybraný uzel pomocí metody [**removeNode**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnodecollection/#removeNode).
1. Uložte prezentaci.

```php
  # Načtěte požadovanou prezentaci
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Procházejte všechny tvary v prvním snímku
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Zkontrolujte, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypujte tvar na SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Přístup k uzlu SmartArt na indexu 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Odstranění vybraného uzlu
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Uložit prezentaci
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Odstranění uzlu SmartArt z konkrétní pozice**
V tomto příkladu se naučíte, jak odstranit uzly uvnitř tvaru SmartArt na konkrétní pozici.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte odkaz na první snímek pomocí jeho indexu.
1. Procházejte každým tvarem v první snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/) a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/).
1. Vyberte uzel tvaru SmartArt s indexem 0.
1. Nyní zkontrolujte, zda má vybraný uzel SmartArt více než 2 poduzly.
1. Odstraňte uzel na **Pozici 1** pomocí metody [**removeNode**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnodecollection/#removeNode).
1. Uložte prezentaci.

```php
  # Načtěte požadovanou prezentaci
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Procházejte všechny tvary v prvním snímku
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Zkontrolujte, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypujte tvar na SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Přístup k uzlu SmartArt na indexu 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Odstranění poduzlu na pozici 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Uložit prezentaci
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavení vlastní pozice pro poduzel v objektu SmartArt**
Aspose.Slides for PHP via Java podporuje nastavení vlastností [SmartArtShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArtShape) **X** a **Y**. Níže uvedený úryvek kódu ukazuje, jak nastavit vlastní pozici, velikost a rotaci tvaru SmartArtShape; také si všimněte, že přidání nových uzlů způsobí přepočet pozic a velikostí všech uzlů. S vlastními nastaveními pozice může uživatel uzly nastavit podle požadavků.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Přesun tvaru SmartArt na novou pozici
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Změna šířek tvaru SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Změna výšky tvaru SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Změna rotace tvaru SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Kontrola asistenčního uzlu**
{{% alert color="primary" %}} 

V tomto článku budeme dále zkoumat funkce tvarů SmartArt přidaných do snímků prezentace programově pomocí Aspose.Slides for PHP via Java.

{{% /alert %}} 

Pro naše zkoumání v různých částech tohoto článku použijeme následující zdrojový tvar SmartArt.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Obrázek: Zdrojový tvar SmartArt na snímku**|

V následujícím ukázkovém kódu budeme zkoumat, jak identifikovat **asistenční uzly** ve sbírce uzlů SmartArt a měnit je.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a načtěte prezentaci s tvarem SmartArt.
1. Získejte odkaz na druhý snímek pomocí jeho indexu.
1. Procházejte každým tvarem v první snímku.
1. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/) a pokud ano, přetypujte vybraný tvar na [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/).
1. Procházejte všechny uzly uvnitř tvaru SmartArt a zkontrolujte, zda jsou **asistenční uzly**.
1. Změňte stav asistenčního uzlu na běžný uzel.
1. Uložte prezentaci.

```php
  # Vytvoření instance prezentace
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Procházejte všechny tvary v prvním snímku
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Zkontrolujte, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypujte tvar na SmartArt
        $smart = $shape;
        # Procházení všech uzlů tvaru SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Zkontrolujte, zda je uzel asistenční
          if ($node->isAssistant()) {
            # Nastavení asistenčního uzlu na false a převod na běžný uzel
            $node->isAssistant();
          }
        }
      }
    }
    # Uložit prezentaci
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Obrázek: Asistenční uzly změněny v tvaru SmartArt na snímku**|

## **Nastavení výplňového formátu uzlu**
Aspose.Slides for PHP via Java umožňuje přidávat vlastní tvary SmartArt a nastavit jejich výplňový formát. Tento článek vysvětluje, jak vytvořit a přistupovat k tvarům SmartArt a nastavit jejich výplňový formát pomocí Aspose.Slides for PHP via Java.

Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte tvar [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/) nastavením jeho **LayoutType**.
1. Nastavte **Fill Format** pro uzly tvaru SmartArt.
1. Uložte upravenou prezentaci jako soubor PPTX.

```php
  # Vytvořte instanci prezentace
  $pres = new Presentation();
  try {
    # Přístup k snímku
    $slide = $pres->getSlides()->get_Item(0);
    # Přidání tvaru SmartArt a uzlů
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Nastavení výplňové barvy uzlu
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Uložit prezentaci
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vytvoření náhledu poduzlu SmartArt**
Vývojáři mohou vytvořit náhled poduzlu SmartArt podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. [Přidejte SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnodecollection/#addNode).
1. Získejte odkaz na uzel pomocí jeho indexu.
1. Získejte náhledový obrázek.
1. Uložte náhledový obrázek v libovolném požadovaném formátu.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přidání SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Získání reference na uzel pomocí jeho indexu
    $node = $smart->getNodes()->get_Item(1);
    # Získání miniatury
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Uložení miniatury
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Je podpora animací SmartArt?**

Ano. SmartArt je zpracován jako běžný tvar, takže můžete [použít standardní animace](/slides/cs/php-java/shape-animation/) (vstup, výstup, zdůraznění, trajektorie) a upravit časování. V případě potřeby můžete animovat i tvary uvnitř uzlů SmartArt.

**Jak spolehlivě najít konkrétní SmartArt na snímku, pokud je jeho interní ID neznámé?**

Přiřaďte a vyhledejte dle [alternativního textu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getalternativetext/). Nastavení výrazného AltText na SmartArt vám umožní najít jej programově bez použití interních identifikátorů.

**Zůstane vzhled SmartArt zachován při převodu prezentace do PDF?**

Ano. Aspose.Slides vykresluje SmartArt s vysokou vizuální věrností během [exportu do PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), zachovává rozložení, barvy a efekty.

**Mohu získat obrázek celého SmartArt (pro náhledy nebo zprávy)?**

Ano. Můžete renderovat tvar SmartArt do [rastrových formátů](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage) nebo do [SVG](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/writeassvg/) pro škálovatelný vektorový výstup, což je vhodné pro náhledy, zprávy nebo webové použití.