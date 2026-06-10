---
title: Diák elérése a bemutatóban PHP-ben
linktitle: Dia elérése
type: docs
weight: 20
url: /hu/php-java/access-slide-in-presentation/
keywords:
- dia elérése
- dia index
- dia azonosító
- dia pozíció
- pozíció módosítása
- dia tulajdonságok
- dia száma
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan érheti el és kezelheti a diákat PowerPoint és OpenDocument bemutatókban az Aspose.Slides for PHP via Java segítségével. Növelje a termelékenységet kódpéldákkal."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet hozzáférni a diákhoz és kezelni őket egy bemutatóban az Aspose.Slides segítségével. Bemutatja, hogyan lehet a diát a nullától kezdődő index alapján lekérni a diakollekcióból, valamint hogyan lehet egy diát elérni az egyedi azonosítója alapján a `getSlideById` metódus használatával.

Megtanulhatja, hogyan lehet megváltoztatni egy dia pozícióját a `setSlideNumber` metódus használatával, valamint hogyan lehet a bemutató első dia számát a `setFirstSlideNumber` metódussal megadni. A példák bemutatják egy bemutató betöltését, diahivatkozások lekérését, dia sorrend vagy számozás frissítését, valamint a módosított bemutató mentését.

## **Dia elérése index alapján**

Minden dia egy bemutatóban numerikusan van elrendezve a dia pozíciója alapján, 0‑tól kezdve. Az első dia elérhető a 0‑ás indexen; a második dia a 1‑es indexen; stb.

A Presentation osztály, amely egy bemutatófájlt képvisel, az összes diát egy [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) gyűjteményként (a [Slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) objektumok gyűjteménye) teszi elérhetővé. Ez a PHP kód megmutatja, hogyan lehet egy diát az indexe alapján elérni:

```php
  # Példányosít egy Presentation objektumot, amely egy bemutatófájlt képvisel
  $pres = new Presentation("demo.pptx");
  try {
    # A dia indexének használatával hozzáfér egy diához
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **Dia elérése ID alapján**

Minden diához egy egyedi azonosító tartozik. A [getSlideById](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlideById-long-) metódus (amely a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályban érhető el) segítségével célozhatja meg ezt az azonosítót. Ez a PHP kód megmutatja, hogyan adjon meg egy érvényes dia ID-t, és hogyan érje el azt a [getSlideById](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlideById-long-) metódussal:

```php
  # Példányosít egy Presentation objektumot, amely egy bemutatófájlt képvisel
  $pres = new Presentation("demo.pptx");
  try {
    # Lekéri egy dia azonosítót
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # A diát az azonosítójával érheti el
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Dia pozíciójának módosítása**

Az Aspose.Slides lehetővé teszi egy dia pozíciójának megváltoztatását. Például megadhatja, hogy az első dia a második dia legyen.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a diát (amelynek a pozícióját módosítani kívánja) az indexe alapján.
3. Állítson be egy új pozíciót a diának a [setSlideNumber](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#setSlideNumber) metódus segítségével.
4. Mentse el a módosított bemutatót.

Ez a PHP kód egy olyan műveletet mutat be, amelyben az 1‑es pozícióban lévő dia a 2‑es pozícióba kerül:

```php
  # Példányosít egy Presentation objektumot, amely egy bemutatófájlt képvisel
  $pres = new Presentation("Presentation.pptx");
  try {
    # Lekéri a diát, amelynek pozíciója megváltozik
    $sld = $pres->getSlides()->get_Item(0);
    # Beállítja a dia új pozícióját
    $sld->setSlideNumber(2);
    # Mentse el a módosított bemutatót
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Az első dia a másodikká vált; a második dia az elsővé. Amikor egy dia pozícióját módosítja, a többi dia automatikusan igazodik.

## **Dia számának beállítása**

A [setFirstSlideNumber](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) metódus (amely a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályban érhető el) segítségével megadhat egy új számot az első diához egy bemutatóban. Ez a művelet a többi dia számát is újraszámolja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a dia számát.
3. Állítsa be a dia számát.
4. Mentse el a módosított bemutatót.

Ez a PHP kód egy olyan műveletet mutat be, amelyben az első dia száma 10‑re van állítva:

```php
  # Példányosít egy Presentation objektumot, amely egy bemutatófájlt képvisel
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Lekéri a dia számát
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Beállítja a dia számát
    $pres->setFirstSlideNumber(10);
    # Mentse el a módosított bemutatót
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Ha inkább kihagyná az első diát, a számozást a második diával kezdheti (és elrejtheti az első dia számozását) így:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Beállítja az első bemutató dia számát
    $presentation->setFirstSlideNumber(0);
    # Megjeleníti a dia számát minden dián
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Elrejti az első dia számát
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Elmenti a módosított bemutatót
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **GYIK**

**A felhasználó által látott dia száma egyezik a gyűjtemény nullától kezdődő indexével?**

A dián megjelenő szám tetszőleges értékkel (például 10) kezdődhet, és nem kell, hogy megegyezzen az indexszel; a kapcsolatot a bemutató **[first slide number](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/setfirstslidenumber/)** beállítása szabályozza.

**A rejtett diák befolyásolják az indexelést?**

Igen. Egy rejtett dia továbbra is része a gyűjteménynek, és számít az indexelésben; a „rejtett” a megjelenítésre vonatkozik, nem pedig a gyűjteményben elfoglalt helyére.

**Megváltozik egy dia indexe, amikor más diákat hozzáadnak vagy eltávolítanak?**

Igen. Az indexek mindig a jelenlegi sorrendet tükrözik, és újraszámolódnak beszúrás, törlés és áthelyezés esetén.