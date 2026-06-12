---
title: Správa poznámek prezentace v PHP
linktitle: Poznámky k prezentaci
type: docs
weight: 110
url: /cs/php-java/presentation-notes/
keywords:
- poznámky
- snímek s poznámkami
- přidat poznámky
- odebrat poznámky
- styl poznámek
- hlavní poznámky
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Přizpůsobte poznámky k prezentaci pomocí Aspose.Slides pro PHP přes Java. Plynule pracujte s poznámkami ve formátech PowerPoint a OpenDocument a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování snímků s poznámkami z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odebrat poznámky a jak použít styl na snímky s poznámkami v prezentaci. Aspose.Slides umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou odstranit poznámky následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

## **Odstranění poznámek ze snímku**
Poznámky některého konkrétního snímku lze odstranit, jak je ukázáno v příkladu níže:

```php
  # Vytvořte objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Odstranění poznámek z první snímku
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Uložení prezentace na disk
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Odstranění poznámek z prezentace**
Poznámky ze všech snímků prezentace lze odstranit, jak je ukázáno v příkladu níže:

```php
  # Vytvořte objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Odstranění poznámek ze všech snímků
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Uložení prezentace na disk
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání stylu poznámek**
[getNotesStyle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) metoda byla přidána do třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/MasterNotesSlide). Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v níže uvedeném příkladu.

```php
  # Vytvořte objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Získat styl textu MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Nastavit symbolovou odrážku pro odstavce první úrovně
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

## **Často kladené otázky**

**Který prvek API poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné prostřednictvím správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notesslidemanager/) a [method](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notesslidemanager/getnotesslide/), který vrací objekt poznámek, nebo `null`, pokud nejsou žádné poznámky.

**Existují rozdíly v podpoře poznámek napříč verzemi PowerPointu, se kterými knihovna pracuje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97–novější) a ODP; poznámky jsou v těchto formátech podporovány bez ohledu na nainstalovanou kopii PowerPointu.