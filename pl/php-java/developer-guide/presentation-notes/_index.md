---
title: "Zarządzaj notatkami prezentacji w PHP"
linktitle: "Notatki prezentacji"
type: docs
weight: 110
url: /pl/php-java/presentation-notes/
keywords:
  - "notatki"
  - "slajd z notatkami"
  - "dodaj notatki"
  - "usuń notatki"
  - "styl notatek"
  - "notatki główne"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentacja"
  - "PHP"
  - "Aspose.Slides"
description: "Dostosuj notatki prezentacji przy użyciu Aspose.Slides dla PHP poprzez Java. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją produktywność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usuwać notatki i jak zastosować styl do slajdów z notatkami w prezentacji. Aspose.Slides pozwala usunąć notatki z dowolnego slajdu oraz zastosować stylizację do istniejących notatek. Programiści mogą usuwać notatki w następujący sposób:

- Usunięcie notatek z określonego slajdu w prezentacji.
- Usunięcie notatek ze wszystkich slajdów w prezentacji.

## **Usuwanie notatek ze slajdu**
Notatki z wybranego slajdu można usunąć, jak pokazano w przykładzie poniżej:

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
Notatki ze wszystkich slajdów w prezentacji można usunąć, jak pokazano w przykładzie poniżej:

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
Metoda [getNotesStyle](https://reference.aspose.com/slides/pl/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) została dodana do klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/MasterNotesSlide). Ta właściwość określa styl tekstu notatek. Implementacja jest pokazana w poniższym przykładzie.

```php
  # Utwórz obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Pobierz styl tekstu MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Ustaw symbol wypunktowania dla paragrafów pierwszego poziomu
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

**Jakie element API zapewnia dostęp do notatek określonego slajdu?**

Do notatek dostęp uzyskuje się poprzez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notesslidemanager/) oraz [method](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notesslidemanager/getnotesslide/), który zwraca obiekt notatek lub `null`, jeśli notatek nie ma.

**Czy istnieją różnice w obsłudze notatek w zależności od wersji programu PowerPoint, z którymi działa biblioteka?**

Biblioteka obsługuje szeroki zakres formatów Microsoft PowerPoint (97‑nowsze) oraz ODP; notatki są obsługiwane w tych formatach bez potrzeby posiadania zainstalowanej kopii PowerPointa.