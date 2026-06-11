---
title: "Zarządzanie grafikami SmartArt w prezentacjach przy użyciu PHP"
linktitle: "Grafiki SmartArt"
type: docs
weight: 20
url: /pl/php-java/manage-smartart-shape/
keywords:
- obiekt SmartArt
- grafika SmartArt
- styl SmartArt
- kolor SmartArt
- tworzenie SmartArt
- dodawanie SmartArt
- edycja SmartArt
- zmiana SmartArt
- dostęp do SmartArt
- typ układu SmartArt
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Automatyzuj tworzenie, edycję i stylizowanie grafiki SmartArt w PowerPoint przy użyciu PHP i Aspose.Slides, prezentując zwięzłe przykłady kodu oraz wskazówki nastawione na wydajność."
---
## **Przegląd**

Aspose.Slides umożliwia programowe tworzenie i zarządzanie grafikami SmartArt w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak dodać kształt SmartArt do slajdu, uzyskać dostęp do istniejących kształtów SmartArt, znaleźć SmartArt o określonym typie układu oraz zaktualizować jego wygląd, zmieniając styl SmartArt lub styl kolorów.

Przykłady pokazują, jak pracować z kształtami SmartArt poprzez kolekcję kształtów slajdu prezentacji, sprawdzić, czy kształt jest SmartArt, a następnie modyfikować lub przeglądać jego właściwości.

## **Utworzenie kształtu SmartArt**
Aspose.Slides for PHP via Java udostępnia API do tworzenia kształtów SmartArt. Aby utworzyć kształt SmartArt na slajdzie, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu, używając jego indeksu.
3. [Dodaj kształt SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addSmartArt) ustawiając jego [LayoutType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArtLayoutType).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaj kształt Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Zapisz prezentację
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Rysunek: Kształt SmartArt dodany do slajdu**|

## **Dostęp do kształtu SmartArt na slajdzie**
Poniższy kod będzie używany do uzyskania dostępu do kształtów SmartArt dodanych w slajdzie prezentacji. W przykładzie kodu przejdziemy przez każdy kształt wewnątrz slajdu i sprawdzimy, czy jest to kształt [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt). Jeśli kształt jest typu SmartArt, zostanie rzutowany na instancję [**SmartArt**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt).

```php
  # Załaduj żądaną prezentację
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Przejdź przez każdy kształt na pierwszym slajdzie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dostęp do kształtu SmartArt o określonym typie układu**
Poniższy przykładowy kod pomoże uzyskać dostęp do kształtu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt) o konkretnym LayoutType. Należy pamiętać, że nie można zmienić LayoutType SmartArt, ponieważ jest on tylko do odczytu i ustawia się go wyłącznie podczas dodawania kształtu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) i wczytaj prezentację zawierającą kształt SmartArt.
2. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.
3. Przejdź przez każdy kształt wewnątrz pierwszego slajdu.
4. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt), i rzutuj wybrany kształt na SmartArt, jeśli tak jest.
5. Sprawdź kształt SmartArt o określonym LayoutType i wykonaj wymagane działania.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Przejdź przez każdy kształt na pierwszym slajdzie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArtEx
        $smart = $shape;
        # Sprawdzanie układu SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zmienianie stylu kształtu SmartArt**
W tym przykładzie nauczymy się zmieniać szybki styl dowolnego kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) i wczytaj prezentację zawierającą kształt SmartArt.
2. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.
3. Przejdź przez każdy kształt wewnątrz pierwszego slajdu.
4. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt), i rzutuj wybrany kształt na SmartArt, jeśli tak jest.
5. Znajdź kształt SmartArt o określonym stylu.
6. Ustaw nowy styl dla kształtu SmartArt.
7. Zapisz prezentację.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Pobierz pierwszy slajd
    $slide = $pres->getSlides()->get_Item(0);
    # Przejdź przez każdy kształt na pierwszym slajdzie
    foreach($slide->getShapes() as $shape) {
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArtEx
        $smart = $shape;
        # Sprawdzanie stylu SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Zmienianie stylu SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Zapisz prezentację
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Rysunek: Kształt SmartArt ze zmienionym stylem**|

## **Zmienianie stylu kolorów kształtu SmartArt**
W tym przykładzie nauczymy się zmieniać styl kolorów dowolnego kształtu SmartArt. W poniższym przykładowym kodzie uzyskamy dostęp do kształtu SmartArt o określonym stylu kolorów i zmienimy jego styl.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) i wczytaj prezentację zawierającą kształt SmartArt.
2. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.
3. Przejdź przez każdy kształt wewnątrz pierwszego slajdu.
4. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt), i rzutuj wybrany kształt na SmartArt, jeśli tak jest.
5. Znajdź kształt SmartArt o określonym stylu kolorów.
6. Ustaw nowy styl kolorów dla kształtu SmartArt.
7. Zapisz prezentację.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Pobierz pierwszy slajd
    $slide = $pres->getSlides()->get_Item(0);
    # Przejdź przez każdy kształt na pierwszym slajdzie
    foreach($slide->getShapes() as $shape) {
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArtEx
        $smart = $shape;
        # Sprawdzanie typu koloru SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Zmienianie typu koloru SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Zapisz prezentację
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Rysunek: Kształt SmartArt ze zmienionym stylem kolorów**|

## **FAQ**

**Czy mogę animować SmartArt jako pojedynczy obiekt?**

Tak. SmartArt jest kształtem, więc możesz zastosować [standardowe animacje](/slides/pl/php-java/powerpoint-animation/) za pomocą API animacji (wejście, wyjście, podkreślenie, ścieżki ruchu) tak jak w przypadku innych kształtów.

**Jak mogę znaleźć konkretny SmartArt na slajdzie, jeśli nie znam jego wewnętrznego identyfikatora?**

Ustaw i użyj tekstu alternatywnego (AltText) oraz wyszukaj kształt po tej wartości — jest to zalecany sposób lokalizowania docelowego kształtu.

**Czy mogę grupować SmartArt z innymi kształtami?**

Tak. Możesz grupować SmartArt z innymi kształtami (obrazami, tabelami itp.), a następnie [manipulować grupą](/slides/pl/php-java/group/).

**Jak uzyskać obraz konkretnego SmartArt (np. do podglądu lub raportu)?**

Wyeksportuj miniaturę/obraz kształtu; biblioteka może [renderować pojedyncze kształty](/slides/pl/php-java/create-shape-thumbnails/) do plików rastrowych (PNG/JPG/TIFF).

**Czy wygląd SmartArt zostanie zachowany przy konwersji całej prezentacji do PDF?**

Tak. Silnik renderujący dąży do wysokiej wierności przy [eksportowaniu do PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/), oferując szereg opcji jakości i zgodności.