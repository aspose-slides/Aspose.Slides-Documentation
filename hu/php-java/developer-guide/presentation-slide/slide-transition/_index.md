---
title: Diaátmenetek kezelése prezentációkban PHP segítségével
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/php-java/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- speciális diaátmenet
- morph átmenet
- átmenettípus
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan testreszabhatja a diaátmeneteket az Aspose.Slides for PHP via Java segítségével, lépésről lépésre útmutatóval a PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a diaátmenetek a prezentációkban az Aspose.Slides segítségével. Megmutatja, hogyan alkalmazhatók átmeneti típusok a diákra, hogyan konfigurálhatók az átmenet viselkedései, például a kattintásra vagy egy meghatározott idő után történő előrehaladás, hogyan ellenőrizhetők és tilthatók le az automatikus előrehaladások, hogyan használható a Morph átmenet és annak típusai, valamint hogyan állíthatók be az átmeneti effektusok. A példák bemutatják, hogyan tölthető be vagy hozható létre egy prezentáció, hogyan módosíthatók a kiválasztott diák átmeneti beállításai, és hogyan menthető az eredmény PPTX fájlként. A cikk válaszol gyakori kérdésekre is, mint az átmenet sebessége, átmeneti hangok, ugyanazon átmenet több diára való alkalmazása, valamint a diához jelenleg beállított átmenet ellenőrzése.

## **Diaátmenet hozzáadása**
Egyszerű diaátmeneti effektus létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
2. Alkalmazzon egy diaátmeneti típust a diára az Aspose.Slides for PHP via Java által kínált átmeneti effektusok közül a TransitionType felsoroló típuson keresztül.  
3. Írja ki a módosított prezentáció fájlt.

```php
  # Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Alkalmazza a kör típusú átmenetet az 1. diára
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Alkalmazza a fűrész típusú átmenetet a 2. diára
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Mentse a prezentációt a lemezre
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Speciális diaátmenet hozzáadása**
Az előző szakaszban egyszerű átmeneti effektust alkalmaztunk a diára. Most, hogy ezt az egyszerű átmenetet még jobbá és vezérelhetőbbé tegyük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
2. Alkalmazzon egy diaátmeneti típust a diára az Aspose.Slides for PHP via Java által kínált átmeneti effektusok közül.  
3. Beállíthatja, hogy az átmenet „Advance On Click”, egy meghatározott idő után vagy mindkettő legyen.  
4. Ha a diaátmenet „Advance On Click” módra van állítva, az átmenet csak akkor halad tovább, ha a felhasználó rákattint a egérre. Ha az „Advance After Time” tulajdonság be van állítva, az átmenet automatikusan továbbhalad a megadott idő letelte után.  
5. Írja ki a módosított prezentációt prezentációfájlként.

```php
  # Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Alkalmazza a kör típusú átmenetet az 1. diára
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Állítsa be a 3 másodperces átmeneti időt
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Alkalmazza a fűrész típusú átmenetet a 2. diára
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Állítsa be az 5 másodperces átmeneti időt
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Alkalmazza a zoom típusú átmenetet a 3. diára
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Állítsa be a 7 másodperces átmeneti időt
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Mentse a prezentációt a lemezre
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Morph átmenet**
{{% alert color="primary" %}} 

Az Aspose.Slides for PHP via Java mostantól támogatja a [Morph Transition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/morphtransition/) funkciót. Ezek a PowerPoint 2019‑ben bevezetett új morph átmeneteket képviselik.

{{% /alert %}} 

A Morph átmenet lehetővé teszi a sima mozgás animálását az egyik dia és a következő közötti átmenetben. Ez a cikk bemutatja a koncepciót és a Morph átmenet használatát. A Morph átmenet hatékony alkalmazásához két diára lesz szüksége, amelyek legalább egy közös objektummal rendelkeznek. A legegyszerűbb módja ennek, ha a diát duplikálja, majd a második dián az objektumot más helyre helyezi.

Az alábbi kódrészlet megmutatja, hogyan adhat egy szöveges klónt a diához, és hogyan állíthat be egy [morph type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TransitionType) átmenetet a második diára.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Morph átmenet típusok**
Új [TransitionMorphType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TransitionMorphType) felsoroló típus került hozzáadásra. Különböző Morph diaátmenet típusokat képvisel.

A TransitionMorphType felsoroló típus három elemből áll:

- **ByObject**: A Morph átmenet úgy történik, hogy a formákat elválaszthatatlan objektumokként kezeli.  
- **ByWord**: A Morph átmenet szöveget szavanként továbbít, ahol csak lehetséges.  
- **ByChar**: A Morph átmenet karakterenként továbbítja a szöveget, ahol csak lehetséges.

Az alábbi kódrészlet megmutatja, hogyan állíthat be morph átmenetet egy diára, és hogyan változtathatja meg a morph típust:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Átmeneti effektusok beállítása**
Az Aspose.Slides for PHP via Java támogatja az átmeneti effektusok beállítását, például „from black”, „from left”, „from right” stb. Az átmeneti effektus beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
- Szerezze meg a dia hivatkozását.  
- Állítsa be az átmeneti effektust.  
- Írja ki a prezentációt egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Az alábbi példában beállítottuk az átmeneti effektusokat.

```php
  # Hozzon létre egy példányt a Presentation osztályból
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Állítsa be az effektust
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Mentse a prezentációt a lemezre
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **GYIK**

**Képes vagyok szabályozni a diaátmenet lejátszási sebességét?**

Igen. Állítsa be a diaátmenet [speed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/setspeed/) értékét a [TransitionSpeed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/transitionspeed/) beállítással (például slow/medium/fast).

**Csatolhatok hangot egy átmenethez és ismételhetem?**

Igen. Beágyazhat hangot az átmenethez, és szabályozhatja a viselkedést olyan beállításokkal, mint a hang módja és a körkörös lejátszás (például [setSound](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/setsoundloop/), valamint metaadatok, mint a [setSoundIsBuiltIn](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) és a [setSoundName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden diára?**

Állítsa be a kívánt átmeneti típust minden dia átmeneti beállításában; az átmenetek diánként tárolódnak, ezért ugyanazt a típust alkalmazva az összes dián egységes eredményt kap.

**Hogyan ellenőrizhetem, melyik átmenet van jelenleg egy dián beállítva?**

Vizsgálja meg a dia [transition settings](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getSlideShowTransition) értékeit, és olvassa ki a [transition type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowtransition/settype/) tulajdonságot; ez az érték pontosan megmondja, melyik effektus van alkalmazva.