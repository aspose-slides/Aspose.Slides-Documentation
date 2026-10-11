---
title: A bemutató jegyzetek kezelése PHP-ban
linktitle: Bemutatójegyzetek
type: docs
weight: 110
url: /hu/php-java/presentation-notes/
keywords:
- jegyzetek
- jegyzet dia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzet stílus
- mester jegyzetek
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Testreszabhatja a bemutató jegyzeteket az Aspose.Slides PHP-hoz Java-n keresztül. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument jegyzetekkel a termelékenység növelése érdekében."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzetdiák eltávolítását egy bemutatóból. Ebben a témában bemutatjuk ezt a funkciót, beleértve a jegyzetek eltávolítását és a jegyzetdiák stílusának alkalmazását egy bemutatóban. Az Aspose.Slides lehetővé teszi, hogy bármely diáról eltávolítsa a jegyzeteket, valamint meglévő jegyzetek stilizálását is végrehajtsa. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy adott diáról a bemutatóban.
- Jegyzetek eltávolítása az összes diáról a bemutatóban.

A jegyzetoldal méretének olvasásához vagy módosításához, az orientáció váltásához és az export viselkedésének ellenőrzéséhez tekintse meg a [Jegyzetoldal mérete](/slides/hu/php-java/notes-size/).

## **Jegyzetek eltávolítása egy diáról**
A specifikus diáról származó jegyzetek az alábbi példában látható módon távolíthatók el:

```php
  # Hozzon létre egy Presentation objektumot, amely egy bemutató fájlt képvisel
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Az első dia jegyzeteinek eltávolítása
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # A bemutató mentése lemezre
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Jegyzetek eltávolítása egy bemutatóból**
Az összes diáról származó jegyzetek az alábbi példában látható módon távolíthatók el:

```php
  # Hozzon létre egy Presentation objektumot, amely egy bemutató fájlt képvisel
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Az összes dia jegyzeteinek eltávolítása
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # A bemutató mentése lemezre
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Jegyzetstílus hozzáadása**
A [getNotesStyle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) metódus a [MasterNotesSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/MasterNotesSlide) osztályban hozzáférést biztosít a jegyzetek szövegstílusához. A megvalósítást az alábbi példa mutatja be.

```php
  # Hozzon létre egy Presentation objektumot, amely egy bemutató fájlt képvisel
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Szerezze meg a MasterNotesSlide szövegstílusát
      $notesStyle = $notesMaster->getNotesStyle();
      # Állítsa be a szimbólum típusú jelölőt az első szintű bekezdésekhez
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

**Melyik API entitás biztosít hozzáférést egy adott dia jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notesslidemanager/) és egy [method](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notesslidemanager/getnotesslide/) amely visszaadja a jegyzet objektumot, vagy `null`, ha nincsenek jegyzetek.

**Vannak-e különbségek a jegyzettámogatásban a könyvtár által támogatott PowerPoint verziók között?**

A könyvtár a Microsoft PowerPoint széles körű formátumkészletét (97‑újabb) és az ODP‑t célozza meg; a jegyzetek ezekben a formátumokban támogatottak anélkül, hogy a telepített PowerPoint példányra támaszkodnának.