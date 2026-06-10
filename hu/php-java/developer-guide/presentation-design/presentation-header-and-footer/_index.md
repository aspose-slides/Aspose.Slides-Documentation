---
title: Prezentáció fejlécek és láblécek kezelése PHP-ben
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/php-java/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- szórólap
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Használja az Aspose.Slides for PHP via Java-t, hogy fejléceket és lábléceket adjon hozzá, és testreszabja azokat PowerPoint és OpenDocument prezentációkban, professzionális megjelenés érdekében."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi a fejléc és lábléc beállításainak kezelését PowerPoint‑prezentációkban. A fejlécek és láblécek a prezentáció mester szintjén kezelhetők, és az API metódusokat biztosít a lábléc szövegének beállításához, a lábléc láthatóságának módosításához, valamint a mester‑jegyzet diák fejléc szövegének frissítéséhez.

A fejléceket és lábléceket a szórólap‑ és jegyzet‑diákon is kezelheti. Ez magában foglalja a fejléc, lábléc, dia‑szám és dátum‑idő helyőrzők láthatóságának és szövegének módosítását a jegyzet‑mesterben, minden gyermek‑jegyzet‑dián vagy egy adott jegyzet‑dián.

## **Fejlécek és láblécek kezelése egy prezentációban**

Egyes diák jegyzetei eltávolíthatók, ahogyan az alábbi példában szerepel:

```php
  # Prezentáció betöltése
  $pres = new Presentation("headerTest.pptx");
  try {
    # Lábléc beállítása
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Fejléc elérése és frissítése
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Prezentáció mentése
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Fejlécek és láblécek kezelése a szórólap‑ és jegyzet‑diákon**

Az Aspose.Slides for PHP via Java támogatja a fejlécek és láblécek használatát a szórólap‑ és jegyzet‑diákon. Kérjük, kövesse az alábbi lépéseket:

- Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) videót tartalmazó prezentációt.
- Változtassa meg a fejléc és lábléc beállításait a jegyzet‑mesteren és az összes jegyzet‑dián.
- Állítsa be a mester‑jegyzet dia és minden gyermek lábléc helyőrző láthatóvá.
- Állítsa be a mester‑jegyzet dia és minden gyermek dátum‑ és időhelyőrző láthatóvá.
- Csak az első jegyzet‑dia fejléc és lábléc beállításait módosítsa.
- Állítsa be a jegyzet‑dia fejléc helyőrzőjét láthatóvá.
- Állítsa be a szöveget a jegyzet‑dia fejléc helyőrzőjébe.
- Állítsa be a szöveget a jegyzet‑dia dátum‑idő helyőrzőjébe.
- Írja ki a módosított prezentációfájlt.

A kódrészlet a lenti példában érhető el.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # A főcím és lábléc beállításainak módosítása a jegyzet‑mesterhez és az összes jegyzet‑diához
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// a mester‑jegyzet diát és az összes gyermek lábléc helyőrzőt láthatóvá teszi

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// a mester‑jegyzet diát és az összes gyermek fejléc helyőrzőt láthatóvá teszi

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// a mester‑jegyzet diát és az összes gyermek dia‑szám helyőrzőt láthatóvá teszi

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// a mester‑jegyzet diát és az összes gyermek dátum‑ és időhelyőrzőt láthatóvá teszi

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// szöveget állít be a mester‑jegyzet dián és az összes gyermek fejléc helyőrzőkben

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// szöveget állít be a mester‑jegyzet dián és az összes gyermek lábléc helyőrzőkben

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// szöveget állít be a mester‑jegyzet dián és az összes gyermek dátum‑ és időhelyőrzőkben

    }
    # A fejléc és lábléc beállításainak módosítása csak az első jegyzet‑diára
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// ezt a jegyzet‑diát a fejléc helyőrző láthatóvá teszi

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// ezt a jegyzet‑diát a lábléc helyőrző láthatóvá teszi

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// ezt a jegyzet‑diát a dia‑szám helyőrző láthatóvá teszi

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// ezt a jegyzet‑diát a dátum‑idő helyőrző láthatóvá teszi

      $headerFooterManager->setHeaderText("New header text");// szöveget állít be a jegyzet‑dia fejléc helyőrzőjében

      $headerFooterManager->setFooterText("New footer text");// szöveget állít be a jegyzet‑dia lábléc helyőrzőjében

      $headerFooterManager->setDateTimeText("New date and time text");// szöveget állít be a jegyzet‑dia dátum‑idő helyőrzőjében

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Hozzáadhatok "fejlécet" a normál diákhoz?**

A PowerPoint‑ban a "Header" csak a jegyzetekhez és szórólapokhoz létezik; a normál diákon a támogatott elemek a lábléc, a dátum/idő és a dia‑szám. Az Aspose.Slides esetében ez ugyanazokat a korlátozásokat jelenti: fejléc csak a Notes/Handout számára, a diákon — Footer/DateTime/SlideNumber.

**Mi a teendő, ha a layout nem tartalmaz láblécet—bekapcsolhatom a láthatóságát?**

Igen. Ellenőrizze a láthatóságot a fejléc/lábléc kezelővel, és szükség esetén engedélyezze. Ezek az API‑jelzők és metódusok olyan esetekre lettek tervezve, amikor a helyőrző hiányzik vagy rejtve van.

**Hogyan állíthatom be, hogy a dia‑szám 1‑nél más értékről induljon?**

Állítsa be a prezentáció [first slide number](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/setfirstslidenumber/) értékét; ezután az összes számozás újraszámításra kerül. Például kezdheti 0‑val vagy 10‑zel, és elrejtheti a számot a címdian.

**Mi történik a fejlécekkel/láblécekkel PDF-/képek/HTML‑export során?**

Akkor ezek a prezentáció szabványos szövegelemként kerülnek renderelésre. Vagyis ha az elemek láthatóak a diákon/jegyzet‑oldalakon, akkor a kimeneti formátumbban is megjelennek a többi tartalommal együtt.