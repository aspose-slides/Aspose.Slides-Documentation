---
title: "Zarządzaj notatkami prezentacji w PHP"
linktitle: "Notatki prezentacji"
type: docs
weight: 110
url: /pl/php-java/presentation-notes/
keywords:
- notatki
- slajd notatek
- dodaj notatki
- usuń notatki
- styl notatek
- główne notatki
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dostosuj notatki prezentacji za pomocą Aspose.Slides dla PHP poprzez Java. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją wydajność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usunąć notatki oraz jak zastosować styl do slajdów z notatkami w prezentacji. Aspose.Slides pozwala usunąć notatki z dowolnego slajdu oraz zastosować formatowanie do istniejących notatek. Deweloperzy mogą usuwać notatki w następujący sposób:

- Usunąć notatki z określonego slajdu w prezentacji.
- Usunąć notatki ze wszystkich slajdów w prezentacji.

Aby odczytać lub zmienić wymiary strony notatek, zmienić orientację i sprawdzić zachowanie przy eksporcie, zobacz [Rozmiar strony notatek](/slides/pl/php-java/notes-size/).

## **Usuwanie notatek ze slajdu**

Notatki z określonego slajdu można usunąć, jak pokazano w poniższym przykładzie:

```php
  # Utwórz obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Usuwanie notatek z pierwszego slajdu
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Zapisywanie prezentacji na dysku
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usuwanie notatek z prezentacji**

Notatki ze wszystkich slajdów w prezentacji można usunąć, jak pokazano w poniższym przykładzie:

```php
  # Utwórz obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Usuwanie notatek ze wszystkich slajdów
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Zapisywanie prezentacji na dysku
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dodanie stylu notatek**

Metoda [getNotesStyle](https://reference.aspose.com/slides/pl/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/MasterNotesSlide) zapewnia dostęp do stylu tekstu notatek. Implementacja jest przedstawiona w poniższym przykładzie.

```php
  # Utwórz obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Pobierz styl tekstu MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Ustaw znak wypunktowania jako symbol dla paragrafów pierwszego poziomu
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

**Który element API zapewnia dostęp do notatek określonego slajdu?**

Notatki są dostępne poprzez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notesslidemanager/) oraz [metodę](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notesslidemanager/getnotesslide/), która zwraca obiekt notatek lub `null`, jeśli notatek nie ma.

**Czy istnieją różnice w obsłudze notatek w zależności od wersji PowerPoint, z którymi działa biblioteka?**

Biblioteka obsługuje szeroki zakres formatów Microsoft PowerPoint (97–nowsze) oraz ODP; notatki są wspierane w tych formatach bez konieczności posiadania zainstalowanej kopii programu PowerPoint.