---
title: Grupowe kształty prezentacji w PHP
linktitle: Grupa Kształtów
type: docs
weight: 40
url: /pl/php-java/group/
keywords:
- grupowy kształt
- grupa kształtów
- dodaj grupę
- tekst alternatywny
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Naucz się grupować i rozgrupowywać kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides for PHP via Java — szybki, krok po kroku przewodnik z darmowym kodem."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z grupowymi kształtami w Aspose.Slides. pokazuje, jak dodać grupowy kształt do slajdu, umieścić w nim kształty oraz zapisać zaktualizowaną prezentację. Demonstruje także, jak uzyskać dostęp do kształtów przechowywanych wewnątrz grupy i odczytać ich wartości `AlternativeText`. Dodatkowo krótko omawia powiązane możliwości grupowych kształtów, takie jak grupy zagnieżdżone, kolejność Z oraz opcje blokowania.

## **Dodaj grupowy kształt**
Aspose.Slides obsługuje pracę z grupowymi kształtami na slajdach. Funkcja ta pomaga programistom tworzyć bogatsze prezentacje. Aspose.Slides for PHP via Java umożliwia dodawanie i uzyskiwanie dostępu do grupowych kształtów. Można dodawać kształty do utworzonej grupy, aby ją wypełnić lub uzyskać dostęp do dowolnej właściwości grupowego kształtu. Aby dodać grupowy kształt do slajdu przy użyciu Aspose.Slides for PHP via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj odwołanie do slajdu, używając jego Index
3. Dodaj grupowy kształt do slajdu.
4. Dodaj kształty do utworzonego grupowego kształtu.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupowy kształt do slajdu.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Uzyskiwanie dostępu do kolekcji kształtów slajdów
    $slideShapes = $sld->getShapes();
    # Dodawanie grupowego kształtu do slajdu
    $groupShape = $slideShapes->addGroupShape();
    # Dodawanie kształtów wewnątrz dodanego grupowego kształtu
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Dodawanie ramki grupowego kształtu
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Zapisz plik PPTX na dysku
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dostęp do właściwości AltText**
Ten temat przedstawia proste kroki, wraz z przykładami kodu, dotyczące dodawania grupowego kształtu i uzyskiwania dostępu do właściwości AltText grupowych kształtów na slajdach. Aby uzyskać dostęp do AltText grupowego kształtu w slajdzie przy użyciu Aspose.Slides for PHP via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) reprezentującej plik PPTX.
2. Uzyskaj odwołanie do slajdu, używając jego Index.
3. Uzyskaj dostęp do kolekcji kształtów slajdu.
4. Uzyskaj dostęp do grupowego kształtu.
5. Uzyskaj dostęp do właściwości [Alternative Text](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getAlternativeText).

Poniższy przykład uzyskuje dostęp do alternatywnego tekstu grupowego kształtu.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Uzyskiwanie dostępu do kolekcji kształtów slajdów
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Uzyskiwanie dostępu do grupowego kształtu.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Uzyskiwanie dostępu do właściwości AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy obsługiwane jest zagnieżdżone grupowanie (grupa wewnątrz grupy)?**

Tak. [GroupShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/groupshape/) ma metodę [getParentGroup](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getparentgroup/), która bezpośrednio wskazuje wsparcie hierarchii (grupa może być dzieckiem innej grupy).

**Jak kontrolować kolejność Z grupy względem innych obiektów na slajdzie?**

Użyj metody [getZOrderPosition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getzorderposition/) klasy [GroupShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/groupshape/), aby sprawdzić jej pozycję w stosie wyświetlania.

**Czy mogę zapobiec przemieszczaniu/edycji/rozgrupowywaniu?**

Tak. Sekcja blokady grupy jest udostępniona poprzez [GroupShapeLock](https://reference.aspose.com/slides/pl/php-java/aspose.slides/groupshape/getgroupshapelock/), co pozwala ograniczyć operacje na obiekcie.