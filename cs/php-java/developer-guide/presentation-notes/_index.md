---
title: Spravovat poznámky prezentace v PHP
linktitle: Poznámky prezentace
type: docs
weight: 110
url: /cs/php-java/presentation-notes/
keywords:
- poznámky
- snímek s poznámkami
- přidat poznámky
- odstranit poznámky
- styl poznámek
- hlavní poznámky
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Přizpůsobte poznámky prezentace pomocí Aspose.Slides pro PHP přes Java. Bezproblémově pracujte s poznámkami PowerPoint a OpenDocument a zvýšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování poznámkových snímků z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odstranit poznámky a jak použít styl na poznámkové snímky v prezentaci. Aspose.Slides umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou odstranit poznámky následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

Pro čtení nebo změnu rozměrů stránky poznámek, změnu orientace a kontrolu chování exportu viz [Velikost stránky poznámek](/slides/cs/php-java/notes-size/).

## **Odstranit poznámky ze snímku**
Poznámky z konkrétního snímku lze odstranit, jak je ukázáno v níže uvedeném příkladu:

```php
  # Vytvořte objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Odstranění poznámek z prvního snímku
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

## **Odstranit poznámky z prezentace**
Poznámky ze všech snímků v prezentaci lze odstranit, jak je ukázáno v níže uvedeném příkladu:

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

## **Přidat styl poznámek**
Metoda [getNotesStyle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/MasterNotesSlide) poskytuje přístup ke stylu textu poznámek. Implementace je ukázána v níže uvedeném příkladu.

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

## **FAQ**

**Který objekt API poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné prostřednictvím správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notesslidemanager/) a [metodu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notesslidemanager/getnotesslide/), která vrací objekt poznámek, nebo `null`, pokud žádné poznámky neexistují.

**Existují rozdíly v podpoře poznámek mezi verzemi PowerPointu, se kterými knihovna pracuje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97‑novější) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.