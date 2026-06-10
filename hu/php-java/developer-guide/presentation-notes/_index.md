---
title: Prezentációs jegyzetek kezelése PHP-ben
linktitle: Prezentációs jegyzetek
type: docs
weight: 110
url: /hu/php-java/presentation-notes/
keywords:
- jegyzetek
- jegyzetdia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzet stílus
- mester jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Testreszabhatja a prezentációs jegyzeteket az Aspose.Slides for PHP segítségével Java-n keresztül. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument jegyzetekkel, hogy növelje a produktivitását."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzetdiák eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, beleértve a jegyzetek eltávolításának módját és a jegyzetdiákra alkalmazott stílus beállítását a prezentációban. Az Aspose.Slides lehetővé teszi, hogy bármely diáról eltávolítsa a jegyzeteket, és a meglévő jegyzetekre stílust alkalmazzon. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Egy adott diáról távolítsa el a jegyzeteket a prezentációban.
- A prezentáció összes diájáról távolítsa el a jegyzeteket.

## **Jegyzetek eltávolítása egy diáról**
Egy adott diáról a jegyzetek a lenti példában mutatott módon távolíthatók el:

```php
  # Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Az első dia jegyzeteinek eltávolítása
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # A prezentáció mentése lemezre
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Jegyzetek eltávolítása egy prezentációból**
A prezentáció minden diájáról a jegyzetek a lenti példában mutatott módon távolíthatók el:

```php
  # Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Az összes dia jegyzeteinek eltávolítása
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # A prezentáció mentése lemezre
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Jegyzetstílus hozzáadása**
[getNotesStyle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) metódust hozzáadták a [MasterNotesSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MasterNotesSlide) osztályhoz. Ez a tulajdonság a jegyzet szövegének stílusát határozza meg. A megvalósítást az alábbi példában mutatjuk be.

```php
  # Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # A MasterNotesSlide szövegstílusának lekérése
      $notesStyle = $notesMaster->getNotesStyle();
      # Szimbólum jelölő beállítása az első szintű bekezdésekhez
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Melyik API-objektum biztosít hozzáférést egy adott dia jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notesslidemanager/) és egy [method](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notesslidemanager/getnotesslide/) amely visszaadja a jegyzetobjektumot, vagy `null`, ha nincs jegyzet.

**Vannak eltérések a jegyzetek támogatásában a könyvtár által támogatott PowerPoint verziók között?**

A könyvtár széles körű Microsoft PowerPoint formátumot (1997‑től napjainkig) és ODP‑t támogat; a jegyzetek ezekben a formátumokban elérhetők anélkül, hogy a PowerPoint telepített példányára támaszkodna.