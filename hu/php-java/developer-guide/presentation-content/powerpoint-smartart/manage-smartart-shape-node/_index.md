---
title: SmartArt alakzat csomópontok kezelése prezentációkban PHP használatával
linktitle: SmartArt alakzat csomópont
type: docs
weight: 30
url: /hu/php-java/manage-smartart-shape-node/
keywords:
- SmartArt csomópont
- gyermek csomópont
- csomópont hozzáadása
- csomópont pozíciója
- csomópont elérése
- csomópont eltávolítása
- egyéni pozíció
- asszisztens csomópont
- kitöltési formátum
- csomópont renderelése
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "SmartArt alakzat csomópontok kezelése PPT és PPTX fájlokban az Aspose.Slides for PHP via Java segítségével. Szerezzen világos kódrészleteket és tippeket a prezentációk hatékonyabbá tételéhez."
---
## **Áttekintés**

A PowerPoint‑prezentációkban a SmartArt grafikát csomópontok szervezik, amelyek szöveget tartalmaznak és meghatározzák a diagram szerkezetét. Az Aspose.Slides lehetővé teszi, hogy programozottan dolgozzon ezekkel a SmartArt csomópontokkal: új csomópontok és gyermekcsomópontok hozzáadása, gyermekcsomópontok beszúrása adott pozícióban, meglévő csomópontok elérése, valamint a szövegük, szintjük és pozíciójuk olvasása.

Ez a cikk bemutatja, hogyan kezelje a SmartArt alakzat csomópontjait. Megmutatja, hogyan távolítson el csomópontokat, hogyan dolgozzon gyermekcsomópontokkal index vagy pozíció alapján, hogyan változtassa asszisztens csomópontot normál csomóponttá, hogyan állítsa be a SmartArt csomópont alakzatok pozícióját, méretét és forgását, hogyan állítsa be a csomópont kitöltési formátumát, és hogyan generáljon bélyegképet egy SmartArt gyermekcsomópontról.

## **SmartArt csomópont hozzáadása**
Az Aspose.Slides for PHP via Java biztosítja a legegyszerűbb API‑t a SmartArt alakzatok kezeléséhez a legegyszerűbb módon. Az alábbi példakód segít csomópont és gyermekcsomópont hozzáadásában egy SmartArt alakzaton belül.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztály példányt és töltse be az előadást SmartArt Shape‑szel.  
1. Szerezze be az első dia referenciáját az Index segítségével.  
1. Iteráljon minden alakzaton az első dián.  
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusú‑e, és ha igen, végezze a típuskonverziót a kiválasztott alakzatra [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/).  
1. [Add a new Node](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartnodecollection/#addNode) a SmartArt shape **NodeCollection**‑hez és állítsa be a szöveget a TextFrame‑ben.  
1. Most, [Add](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartnodecollection/#addNode) egy **Child Node** a most hozzáadott [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) Node‑hoz és állítsa be a szöveget a TextFrame‑ben.  
1. Mentse el az előadást.

```php
  # Töltsük be a kívánt prezentációt
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Bejárjuk az első dián lévő összes alakzatot
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Ellenőrizzük, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Átcasteljük az alakzatot SmartArt-ra
        $smart = $shape;
        # Új SmartArt csomópont hozzáadása
        $TemNode = $smart->getAllNodes()->addNode();
        # Szöveg hozzáadása
        $TemNode->getTextFrame()->setText("Test");
        # Új gyermekcsomópont hozzáadása a szülőcsomóponthoz. A gyűjtemény végére kerül hozzáadásra
        $newNode = $TemNode->getChildNodes()->addNode();
        # Szöveg hozzáadása
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Prezentáció mentése
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt csomópont hozzáadása adott pozícióban**
Az alábbi példakódban bemutatjuk, hogyan adhatunk hozzá gyermekcsomópontokat a SmartArt alakzat megfelelő csomópontjaihoz egy meghatározott pozíción.

1. Hozzon létre egy Presentation osztály példányt.  
1. Szerezze be az első dia referenciáját az Index segítségével.  
1. Adjunk egy [**StackedList**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArtLayoutType#StackedList) típusú [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArt) alakzatot a hozzáfért diára.  
1. Hozzáférés az első csomóponthoz a hozzáadott SmartArt shape‑ben.  
1. Most, adjon hozzá egy **Child Node** a kiválasztott **Node**‑hoz a 2. pozíción, és állítsa be a szöveget.  
1. Mentse el az előadást.

```php
  # Prezentáció példány létrehozása
  $pres = new Presentation();
  try {
    # A prezentáció dia elérése
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art IShape hozzáadása
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # SmartArt csomópont elérése a 0-s indexen
    $node = $smart->getAllNodes()->get_Item(0);
    # Új gyermekcsomópont hozzáadása a szülőcsomópontban a 2-es pozíción
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Szöveg hozzáadása
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Prezentáció mentése
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt csomópont elérése**
Az alábbi példakód segít elérni a csomópontokat egy SmartArt shape‑en belül. Kérjük, vegye figyelembe, hogy a SmartArt LayoutType‑ja csak olvasható, és csak akkor állítható be, amikor a SmartArt shape hozzá van adva.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztály példányt és töltse be az előadást SmartArt Shape‑szel.  
1. Szerezze be az első dia referenciáját az Index segítségével.  
1. Iteráljon minden alakzaton az első dián.  
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusú‑e, és ha igen, végezze a típuskonverziót [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusra.  
1. Iteráljon minden **Nodes**‑on a SmartArt Shape‑en belül.  
1. Hozzáférés és információk megjelenítése, mint például a SmartArt csomópont pozíciója, szintje és szövege.

```php
  # Prezentáció osztály példányosítása
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Első dia lekérése
    $slide = $pres->getSlides()->get_Item(0);
    # Bejárás az első dián lévő összes alakzaton
    foreach($slide->getShapes() as $shape) {
      # Ellenőrzés, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Átcastolás SmartArt-ra
        $smart = $shape;
        # Bejárás a SmartArt összes csomópontján
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # SmartArt csomópont elérése i indexen
          $node = $smart->getAllNodes()->get_Item($i);
          # SmartArt csomópont paramétereinek kiírása
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

## **SmartArt gyermekcsomópont elérése**
Az alábbi példakód segít elérni a gyermekcsomópontokat a SmartArt shape megfelelő csomópontjaihoz.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztály példányt és töltse be az előadást SmartArt Shape‑szel.  
1. Szerezze be az első dia referenciáját az Index segítségével.  
1. Iteráljon minden alakzaton az első dián.  
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusú‑e, és ha igen, végezze a típuskonverziót [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusra.  
1. Iteráljon minden **Nodes**‑on a SmartArt Shape‑en belül.  
1. Minden kiválasztott SmartArt shape **Node**‑nél iteráljon minden **Child Nodes**‑on az adott csomóponton belül.  
1. Hozzáférés és információk megjelenítése, mint például a **Child Node** pozíciója, szintje és szövege.

```php
  # Prezentáció osztály példányosítása
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Első dia lekérése
    $slide = $pres->getSlides()->get_Item(0);
    # Bejárás az első dián lévő összes alakzaton
    foreach($slide->getShapes() as $shape) {
      # Ellenőrzés, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Átcastolás SmartArt-ra
        $smart = $shape;
        # Bejárás a SmartArt összes csomópontján
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # SmartArt csomópont elérése i indexen
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Gyermekcsomópontok bejárása a SmartArt csomópontban i indexen
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Gyermekcsomópont elérése a SmartArt csomópontban
            $node = $node0->getChildNodes()->get_Item($j);
            # SmartArt gyermekcsomópont paramétereinek kiírása
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

## **SmartArt gyermekcsomópont elérése adott pozícióban**
Ebben a példában megtanuljuk, hogyan érjünk el gyermekcsomópontokat egy adott pozícióban, amely a SmartArt shape megfelelő csomópontjaihoz tartozik.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztály példányt.  
1. Szerezze be a második dia referenciáját az Index segítségével.  
1. Adjunk egy [**StackedList**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArtLayoutType#StackedList) típusú SmartArt shape‑t.  
1. Hozzáférés a hozzáadott SmartArt shape‑hez.  
1. Hozzáférés a 0‑s indexű csomóponthoz a hozzáfért SmartArt shape‑ben.  
1. Most, a **get_Item()** metódus segítségével érje el a **Child Node**‑t az 1‑es pozíción a hozzáfért SmartArt node‑nál.  
1. Hozzáférés és információk megjelenítése, mint például a **Child Node** pozíciója, szintje és szövege.

```php
  # A prezentáció példányosítása
  $pres = new Presentation();
  try {
    # Az első dia elérése
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt alakzat hozzáadása az első dián
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # SmartArt csomópont elérése a 0-s indexen
    $node = $smart->getAllNodes()->get_Item(0);
    # Gyermekcsomópont elérése az 1-es pozícióban a szülőcsomópontban
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # SmartArt gyermekcsomópont paramétereinek kiírása
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt csomópont eltávolítása**
Ebben a példában megtanuljuk, hogyan távolítsuk el a csomópontokat a SmartArt shape‑ben.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztály példányt és töltse be az előadást SmartArt Shape‑szel.  
1. Szerezze be az első dia referenciáját az Index segítségével.  
1. Iteráljon minden alakzaton az első dián.  
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusú‑e, és ha igen, végezze a típuskonverziót [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusra.  
1. Ellenőrizze, hogy a SmartArt több mint 0 csomóponttal rendelkezik‑e.  
1. Válassza ki a törlendő SmartArt csomópontot.  
1. Most, a **removeNode** metódussal távolítsa el a kiválasztott csomópontot.  
1. Mentse el az előadást.

```php
  # Töltsük be a kívánt prezentációt
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Bejárjuk az első dián lévő összes alakzatot
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Ellenőrizzük, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Átcastoljuk az alakzatot SmartArt-ra
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # SmartArt csomópont elérése a 0-s indexen
          $node = $smart->getAllNodes()->get_Item(0);
          # A kiválasztott csomópont eltávolítása
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Prezentáció mentése
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt csomópont eltávolítása adott pozícióból**
Ebben a példában megtanuljuk, hogyan távolítsuk el a csomópontokat a SmartArt shape‑ben egy adott pozíción.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztály példányt és töltse be az előadást SmartArt Shape‑szel.  
1. Szerezze be az első dia referenciáját az Index segítségével.  
1. Iteráljon minden alakzaton az első dián.  
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusú‑e, és ha igen, végezze a típuskonverziót [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusra.  
1. Válassza ki a SmartArt shape csomópontját a 0‑s indexen.  
1. Most ellenőrizze, hogy a kiválasztott SmartArt csomópont több mint 2 gyermekcsomóponttal rendelkezik‑e.  
1. Most, a **removeNode** metódussal távolítsa el az 1‑es **Position**‑on lévő csomópontot.  
1. Mentse el az előadást.

```php
  # Töltsük be a kívánt prezentációt
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Bejárjuk az első dián lévő összes alakzatot
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Ellenőrizzük, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Átcastoljuk az alakzatot SmartArt-ra
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # SmartArt csomópont elérése a 0-s indexen
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # A gyermekcsomópont eltávolítása az 1-es pozícióban
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Prezentáció mentése
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Egyéni pozíció beállítása egy gyermekcsomóponthoz egy SmartArt objektumban**
Az Aspose.Slides for PHP via Java támogatja a [SmartArtShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#setX) és [Y](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#setY) tulajdonságok beállítását. Az alábbi kódrészlet megmutatja, hogyan állítható be egyedi SmartArtShape pozíció, méret és forgatás; vegye figyelembe, hogy új csomópontok hozzáadása minden csomópont pozíciójának és méretének újraszámítását eredményezi. Az egyéni pozícióbeállításokkal a felhasználó a csomópontokat igények szerint állíthatja be.

```php
  # Prezentáció osztály példányosítása
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # SmartArt alakzat áthelyezése új pozícióba
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # SmartArt alakzat szélességének módosítása
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # SmartArt alakzat magasságának módosítása
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # SmartArt alakzat forgatásának módosítása
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Asszisztens csomópont ellenőrzése**
{{% alert color="primary" %}} 

Ebben a cikkben tovább vizsgáljuk a SmartArt alakzatok funkcióit, amelyeket programozottan adhatunk hozzá a prezentáció diákhoz az Aspose.Slides for PHP via Java segítségével.

{{% /alert %}} 

A vizsgálathoz a következő forrás SmartArt shape‑t használjuk a cikk különböző szakaszaiban.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Ábra: Forrás SmartArt alakzat a dián**|

Az alábbi példakódban azt vizsgáljuk, hogyan azonosíthatók **Asszisztens csomópontok** a SmartArt csomópontgyűjteményben, és hogyan változtathatók meg.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztály példányt és töltse be az előadást SmartArt Shape‑szel.  
1. Szerezze be a második dia referenciáját az Index segítségével.  
1. Iteráljon minden alakzaton az első dián.  
1. Ellenőrizze, hogy az alakzat [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusú‑e, és ha igen, végezze a típuskonverziót [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusra.  
1. Iteráljon minden csomóponton a SmartArt shape‑en belül, és ellenőrizze, hogy **Assistant Nodes**‑e‑k‑e.  
1. Módosítsa az Asszisztens csomópont státuszát normál csomóponttá.  
1. Mentse el az előadást.

```php
  # Prezentáció példányosítása
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Bejárjuk az első dián lévő összes alakzatot
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Ellenőrizzük, hogy az alakzat SmartArt típusú-e
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Átcastoljuk az alakzatot SmartArt-ra
        $smart = $shape;
        # Bejárás a SmartArt alakzat összes csomópontján
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Ellenőrzés, hogy a csomópont Assistant csomópont-e
          if ($node->isAssistant()) {
            # Az Assistant csomópont állapotának false-ra állítása, hogy normál csomópont legyen
            $node->isAssistant();
          }
        }
      }
    }
    # Prezentáció mentése
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Ábra: Asszisztens csomópontok megváltoztatva a SmartArt alakzatban a dián**|

## **Csomópont kitöltési formátumának beállítása**
Az Aspose.Slides for PHP via Java lehetővé teszi egyedi SmartArt alakzatok hozzáadását és a kitöltési formátumuk beállítását. Ez a cikk bemutatja, hogyan hozhatók létre és érhetők el a SmartArt alakzatok, illetve hogyan állítható be a kitöltési formátumuk az Aspose.Slides for PHP via Java használatával.

Kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztály példányt.  
1. Szerezze be egy dia referenciáját az indexe alapján.  
1. Adjunk egy [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) shape‑t a [**LayoutType**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) beállításával.  
1. Állítsa be a **Fill Format**‑ot a SmartArt shape csomópontokhoz.  
1. Írja ki a módosított prezentációt PPTX fájlként.

```php
  # A prezentáció példányosítása
  $pres = new Presentation();
  try {
    # Diának elérése
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt shape és csomópontok hozzáadása
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Csomópont kitöltési színének beállítása
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Prezentáció mentése
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt gyermekcsomópont bélyegképének generálása**
A fejlesztők a következő lépések szerint generálhatnak bélyegképet egy SmartArt gyermekcsomópontról:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztály példányt.  
1. [Add SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartnodecollection/#addNode).  
1. Szerezze be egy csomópont referenciáját az Index segítségével.  
1. Szerezze meg a bélyegkép képet.  
1. Mentse el a bélyegképet a kívánt képformátumban.

```php
  # Prezentáció osztály példányosítása, amely a PPTX fájlt képviseli
  $pres = new Presentation();
  try {
    # SmartArt hozzáadása
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Csomópont referenciájának lekérése az Index használatával
    $node = $smart->getNodes()->get_Item(1);
    # Bélyegkép lekérése
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Bélyegkép mentése
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

## **FAQ**

**Támogatott a SmartArt animáció?**

Igen. A SmartArt‑ot szabályos alakzatként kezelik, így alkalmazhat [standard animációkat](/slides/hu/php-java/shape-animation/) (belépés, kilépés, hangsúlyozás, mozgásút) és beállíthatja az időzítést. Szükség esetén animálhatja a SmartArt csomópontokon belüli alakzatokat is.

**Hogyan találhatom meg megbízhatóan egy adott SmartArt‑ot egy dián, ha a belső azonosítója ismeretlen?**

Keressen és azonosítson alternatív szöveg alapján ([alternative text](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getalternativetext/)). Egy egyedi AltText megadása a SmartArt‑nek lehetővé teszi, hogy programozottan megtalálja anélkül, hogy belső azonosítókra támaszkodna.

**Megmarad a SmartArt megjelenése, ha az előadást PDF‑re konvertáljuk?**

Igen. Az Aspose.Slides a [PDF export](/slides/hu/php-java/convert-powerpoint-to-pdf/) során magas vizuális hűséggel rendereli a SmartArt‑ot, megőrizve a elrendezést, színeket és hatásokat.

**Kivonhatok képet az egész SmartArt‑ról (például előnézetekhez vagy jelentésekhez)?**

Igen. Renderelhet egy SmartArt shape‑t [raszteres formátumokba](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) vagy [SVG‑be](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/writeassvg/) a skálázható vektorkimenethez, ami alkalmas bélyegképekhez, jelentésekhez vagy webes felhasználáshoz.