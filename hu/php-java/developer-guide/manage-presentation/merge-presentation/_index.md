---
title: "Hatékonyan egyesítse a prezentációkat PHP-ben"
linktitle: "Prezentációk egyesítése"
type: docs
weight: 40
url: /hu/php-java/merge-presentation/
keywords:
- "PowerPoint egyesítése"
- "prezentációk egyesítése"
- "diák egyesítése"
- "PPT egyesítése"
- "PPTX egyesítése"
- "ODP egyesítése"
- "PowerPoint kombinálása"
- "prezentációk kombinálása"
- "diák kombinálása"
- "PPT kombinálása"
- "PPTX kombinálása"
- "ODP kombinálása"
- PHP
- Aspose.Slides
description: "Könnyedén egyesítheti a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkat az Aspose.Slides for PHP via Java segítségével, egyszerűsítve a munkafolyamatot."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi prezentációk egyesítését úgy, hogy egy prezentáció diáit egy másikba klónozza. Ez a cikk bemutatja, hogyan lehet teljes prezentációkat vagy kiválasztott diákat egyesíteni, hogyan használjunk dia-mestert vagy egy adott elrendezést az egyesítés során, hogyan kezeljünk különböző dia méretű prezentációkat, és hogyan adhatunk egyesített diákat egy prezentáció szekcióhoz. Emellett gyakorlati megjegyzéseket tartalmaz az egyesített tartalommal kapcsolatban, beleértve az előadói jegyzeteket, megjegyzéseket, jelszóval védett forrásfájlokat és a szálhasználatot.

## **Prezentációk egyesítése**

Amikor egy prezentációt egy másikhoz egyesítesz, lényegében a diákat egyetlen prezentációba kombinálod, hogy egy fájlt kapj.

{{% alert title="Info" color="info" %}}
A legtöbb prezentációs program (PowerPoint vagy OpenOffice) nem tartalmaz olyan funkciókat, amelyek lehetővé teszik a felhasználók számára, hogy prezentációkat ilyen módon kombináljanak.

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/hu/php-java/) azonban lehetővé teszi a prezentációk különböző módokon történő egyesítését. Az összes alakzatot, stílust, szöveget, formázást, megjegyzéseket, animációkat stb. megőrizve egyesítheted a prezentációkat, anélkül, hogy a minőség vagy az adatok veszteségétől kellene tartanod.

**Lásd még**

[Dia másolása](/slides/hu/php-java/clone-slides/).

{{% /alert %}}

### **Mi egyesíthető**

Az Aspose.Slides használatával egyesíthet

* teljes prezentációkat. A prezentációk összes diája egyetlen prezentációba kerül.
* meghatározott diákat. A kiválasztott diák egy prezentációba kerülnek.
* prezentációkat egyformátumban (PPT → PPT, PPTX → PPTX stb.) és különböző formátumokban (PPT → PPTX, PPTX → ODP stb.) egymáshoz.

{{% alert title="Note" color="warning" %}} 
Az prezentációkon kívül az Aspose.Slides más fájlok egyesítését is lehetővé teszi:

* [Képek](https://products.aspose.com/slides/hu/php-java/merger/image-to-image/), például [JPG → JPG](https://products.aspose.com/slides/hu/php-java/merger/jpg-to-jpg/) vagy [PNG → PNG](https://products.aspose.com/slides/hu/php-java/merger/png-to-png/)
* Dokumentumokat, például [PDF → PDF](https://products.aspose.com/slides/hu/php-java/merger/pdf-to-pdf/) vagy [HTML → HTML](https://products.aspose.com/slides/hu/php-java/merger/html-to-html/)
* Két különböző fájlt, például [kép → PDF](https://products.aspose.com/slides/hu/php-java/merger/image-to-pdf/) vagy [JPG → PDF](https://products.aspose.com/slides/hu/php-java/merger/jpg-to-pdf/) vagy [TIFF → PDF](https://products.aspose.com/slides/hu/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Egyesítési beállítások**

Alkalmazhatsz olyan beállításokat, amelyek meghatározzák, hogy

* az eredmény prezentáció minden diája megőrizze az egyedi stílusát
* egy meghatározott stílus legyen használva az összes dián az eredmény prezentációban. 

A prezentációk egyesítéséhez az Aspose.Slides a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) metódusokat (a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) osztályból) biztosítja. Többféle implementációja létezik az `addClone` metódusoknak, amelyek meghatározzák az egyesítési folyamat paramétereit. Minden Presentation objektumnak van egy [slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getslides/) gyűjteménye, ezért a prezentációból hívhatod meg az `addClone` metódust, amelybe a diák egyesíteni kívánt célja.

Az `addClone` metódus egy `Slide` objektumot ad vissza, amely a forrásdia klónja. A kimeneti prezentáció diái egyszerűen a forrás diák másolatai. Ennek köszönhetően módosíthatod a kapott diákat (például stílusokat, formázási beállításokat vagy elrendezéseket alkalmazhatsz) anélkül, hogy a forrás prezentációkat érintenéd.

## **Prezentációk egyesítése**

Az Aspose.Slides a [addClone(Slide)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) metódust biztosítja, amely lehetővé teszi a diák egyesítését úgy, hogy a diák megtartják az elrendezésüket és stílusukat (alapértelmezett paraméterek).

Ezt a PHP kódot használva megtekintheted, hogyan egyesítsd a prezentációkat:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Prezentációk egyesítése dia-mesterrel**

Az Aspose.Slides a [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) metódust biztosítja, amely lehetővé teszi a diák egyesítését egy dia-mester sablon alkalmazásával. Így szükség esetén megváltoztathatod a kimeneti prezentáció diáinak stílusát.

Ez a kód demonstrálja a leírt műveletet:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
A dia-mester elrendezését a rendszer automatikusan határozza meg. Ha megfelelő elrendezést nem lehet meghatározni, és a `allowCloneMissingLayout` logikai paraméter az `addClone` metódusban true értékre van állítva, akkor a forrás dia elrendezése lesz használva. Ellenkező esetben a [PptxEditException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/PptxEditException) lesz dobva.

{{% /alert %}}

Ha azt szeretnéd, hogy a kimeneti prezentáció diái másik diaelrendezést kapjanak, használj helyette a [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) metódust az egyesítés során.

## **Specifikus diák egyesítése prezentációkból**

Több prezentációból származó specifikus diák egyesítése hasznos egyedi diákészletek létrehozásához. Az Aspose.Slides for PHP via Java lehetővé teszi, hogy csak a szükséges diát válaszd ki és importáld. Az API megőrzi az eredeti diák formázását, elrendezését és dizájnját.

A következő PHP kód új prezentációt hoz létre, hozzáadja a címdiát két másik prezentációból, és elmenti az eredményt egy fájlba:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Prezentációk egyesítése diaelrendezéssel**

Ez a PHP kód bemutatja, hogyan kombinálj diákat több prezentációból, miközben a kívánt diaelrendezést alkalmazod, és egyetlen kimeneti prezentációt kapsz:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Prezentációk egyesítése eltérő dia méretekkel**

{{% alert title="Note" color="warning" %}} 
Nem egyesíthetsz különböző dia méretű prezentációkat. 
{{% /alert %}}

Két különböző dia méretű prezentáció egyesítéséhez át kell méretezni az egyiket, hogy mérete megegyezzen a másikéval.

Ez a példa kód demonstrálja a leírt műveletet:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Diák egyesítése egy prezentáció szekciójába**

Ez a PHP kód megmutatja, hogyan egyesíts egy adott diát egy prezentáció szekciójába:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

A dia a szekció végéhez kerül hozzáadásra.

## **Lásd még**

Az Aspose ingyenes [Online Kollázs Készítő](https://products.aspose.app/slides/hu/collage) szolgáltatást kínál. Ezzel az online szolgáltatással [JPG → JPG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG → PNG képeket egyesíthetsz, [fotórácsokat](https://products.aspose.app/slides/hu/collage/photo-grid) hozhatsz létre, és még sok más.

Nézd meg az [Aspose INGYENES Online Egyesítő](https://products.aspose.app/slides/hu/merger) szolgáltatást. Lehetővé teszi PowerPoint prezentációk egyesítését ugyanabban a formátumban (pl. PPT → PPT, PPTX → PPTX) vagy különböző formátumok között (pl. PPT → PPTX, PPTX → ODP).

[![Aspose INGYENES Online Egyesítő](slides-merger.png)](https://products.aspose.app/slides/hu/merger)

## **GYIK**

**Vannak-e korlátozások a diák számát illetően a prezentációk egyesítésekor?**

Nem szigorú korlátozások. Az Aspose.Slides képes nagy fájlok kezelésére, de a teljesítmény a fájl méretétől és a rendszer erőforrásaitól függ. Nagyon nagy prezentációk esetén ajánlott 64‑bit JVM-et használni és elegendő heap memóriát kiosztani.

**Egyesíthetek-e olyan prezentációkat, amelyek beágyazott videót vagy audiót tartalmaznak?**

Igen, az Aspose.Slides megőrzi a diákba beágyazott multimédia tartalmat, de a végleges prezentáció jelentősen nagyobb lehet.

**Megmaradnak-e a betűtípusok a prezentációk egyesítésekor?**

Igen. A forrás prezentációkban használt betűtípusok megmaradnak a kimeneti fájlban, feltéve, hogy a rendszerre telepítve vannak vagy [beágyazva](/slides/hu/php-java/embedded-font/) vannak.