---
title: Zarządzanie węzłami kształtu SmartArt w prezentacjach przy użyciu PHP
linktitle: Węzeł kształtu SmartArt
type: docs
weight: 30
url: /pl/php-java/manage-smartart-shape-node/
keywords:
- węzeł SmartArt
- węzeł podrzędny
- dodaj węzeł
- pozycja węzła
- dostęp do węzła
- usuń węzeł
- niestandardowa pozycja
- węzeł asystenta
- format wypełnienia
- renderowanie węzła
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj węzłami kształtu SmartArt w plikach PPT i PPTX przy użyciu Aspose.Slides for PHP via Java. Uzyskaj przejrzyste przykłady kodu i wskazówki ułatwiające przygotowanie prezentacji."
---
## **Przegląd**

Grafika SmartArt w prezentacjach PowerPoint jest organizowana za pomocą węzłów zawierających tekst i definiujących strukturę diagramu. Aspose.Slides pozwala programowo pracować z tymi węzłami SmartArt: dodawać nowe węzły i węzły podrzędne, wstawiać węzły podrzędne w określonej pozycji, uzyskiwać dostęp do istniejących węzłów oraz odczytywać ich tekst, poziom i pozycję.

Ten artykuł wyjaśnia, jak zarządzać węzłami kształtów SmartArt. Pokazuje, jak usuwać węzły, pracować z węzłami podrzędnymi według indeksu lub pozycji, zmienić węzeł asystenta na zwykły węzeł, dostosować pozycję, rozmiar i obrót kształtów węzłów SmartArt, ustawić formaty wypełnienia węzłów oraz wygenerować miniaturkę dla węzła podrzędnego SmartArt.

## **Dodaj węzeł SmartArt**
Aspose.Slides for PHP via Java udostępnia najprostsze API do zarządzania kształtami SmartArt w najłatwiejszy sposób. Poniższy przykładowy kod pomoże dodać węzeł i węzeł podrzędny wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) i wczytaj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) jeśli jest SmartArt.
1. [Dodaj nowy węzeł](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnodecollection/#addNode) w kształcie SmartArt [**NodeCollection**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/#getAllNodes) i ustaw tekst w TextFrame.
1. Teraz, [Dodaj](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnodecollection/#addNode) [**Child Node**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnode/#getChildNodes) w nowo dodanym węźle [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) i ustaw tekst w TextFrame.
1. Zapisz prezentację.

```php
  # Wczytaj żądaną prezentację
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArt
        $smart = $shape;
        # Dodawanie nowego węzła SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Dodawanie tekstu
        $TemNode->getTextFrame()->setText("Test");
        # Dodawanie nowego węzła podrzędnego w węźle nadrzędnym. Zostanie dodany na końcu kolekcji
        $newNode = $TemNode->getChildNodes()->addNode();
        # Dodawanie tekstu
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Zapisywanie prezentacji
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dodaj węzeł SmartArt w określonej pozycji**
W poniższym przykładowym kodzie wyjaśniono, jak dodać węzły podrzędne należące do odpowiednich węzłów kształtu SmartArt w określonej pozycji.

1. Utwórz instancję klasy Presentation.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt) typu [**StackedList**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArtLayoutType#StackedList) na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszego węzła w dodanym kształcie SmartArt.
1. Teraz, dodaj [**Child Node**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnode/#getChildNodes) dla wybranego [**Node**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArtNode) na pozycji 2 i ustaw jego tekst.
1. Zapisz prezentację.

```php
  # Tworzenie instancji prezentacji
  $pres = new Presentation();
  try {
    # Uzyskaj dostęp do slajdu prezentacji
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaj Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Dodawanie nowego węzła podrzędnego na pozycji 2 w węźle nadrzędnym
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Dodaj tekst
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Zapisz prezentację
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dostęp do węzła SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów wewnątrz kształtu SmartArt. Należy zauważyć, że nie można zmienić LayoutType SmartArt, ponieważ jest on tylko do odczytu i jest ustawiany wyłącznie podczas dodawania kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) jeśli jest SmartArt.
1. Przejdź przez wszystkie [**Nodes**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt#getAllNodes--) wewnątrz kształtu SmartArt.
1. Dostęp i wyświetlenie informacji, takich jak pozycja węzła SmartArt, poziom i tekst.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Pobierz pierwszy slajd
    $slide = $pres->getSlides()->get_Item(0);
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    foreach($slide->getShapes() as $shape) {
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArt
        $smart = $shape;
        # Przejdź przez wszystkie węzły wewnątrz SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Uzyskiwanie dostępu do węzła SmartArt o indeksie i
          $node = $smart->getAllNodes()->get_Item($i);
          # Wyświetlanie parametrów węzła SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dostęp do węzła podrzędnego SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów podrzędnych należących do odpowiednich węzłów kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) jeśli jest SmartArt.
1. Przejdź przez wszystkie [**Nodes**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArt#getAllNodes--) wewnątrz kształtu SmartArt.
1. Dla każdego wybranego [**Node**] kształtu SmartArt, przejdź przez wszystkie [**Child Nodes**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArtNode#getChildNodes--) wewnątrz danego węzła.
1. Dostęp i wyświetlenie informacji, takich jak pozycja, poziom i tekst [**Child Node**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnode/#getChildNodes).

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Pobierz pierwszy slajd
    $slide = $pres->getSlides()->get_Item(0);
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    foreach($slide->getShapes() as $shape) {
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArt
        $smart = $shape;
        # Przejdź przez wszystkie węzły wewnątrz SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Uzyskiwanie dostępu do węzła SmartArt o indeksie i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Przechodzenie przez węzły podrzędne w węźle SmartArt o indeksie i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Uzyskiwanie dostępu do węzła podrzędnego w węźle SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Wyświetlanie parametrów węzła podrzędnego SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dostęp do węzła podrzędnego SmartArt w określonej pozycji**
W tym przykładzie nauczymy się uzyskiwać dostęp do węzłów podrzędnych w określonych pozycjach, należących do odpowiednich węzłów kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Dodaj kształt SmartArt typu [**StackedList**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Uzyskaj dostęp do dodanego kształtu SmartArt.
1. Uzyskaj dostęp do węzła o indeksie 0 w wybranym kształcie SmartArt.
1. Teraz, uzyskaj dostęp do [**Child Node**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnode/#getChildNodes) na pozycji 1 w wybranym węźle SmartArt używając metody **get_Item()**.
1. Dostęp i wyświetlenie informacji, takich jak pozycja, poziom i tekst [**Child Node**].

```php
  # Utwórz instancję prezentacji
  $pres = new Presentation();
  try {
    # Uzyskiwanie dostępu do pierwszego slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Dodawanie kształtu SmartArt na pierwszym slajdzie
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Uzyskiwanie dostępu do węzła podrzędnego na pozycji 1 w węźle nadrzędnym
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Wyświetlanie parametrów węzła podrzędnego SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usuń węzeł SmartArt**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) jeśli jest SmartArt.
1. Sprawdź, czy SmartArt ma więcej niż 0 węzłów.
1. Wybierz węzeł SmartArt do usunięcia.
1. Teraz, usuń wybrany węzeł używając metody [**removeNode**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnodecollection/#removeNode).
1. Zapisz prezentację.

```php
  # Wczytaj żądaną prezentację
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Usuwanie wybranego węzła
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Zapisz prezentację
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usuń węzeł SmartArt z określonej pozycji**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt w konkretnej pozycji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) jeśli jest SmartArt.
1. Wybierz węzeł kształtu SmartArt o indeksie 0.
1. Teraz, sprawdź, czy wybrany węzeł SmartArt ma więcej niż 2 węzły podrzędne.
1. Teraz, usuń węzeł na **Pozycji 1** używając metody [**removeNode**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnodecollection/#removeNode).
1. Zapisz prezentację.

```php
  # Wczytaj żądaną prezentację
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Usuwanie węzła podrzędnego na pozycji 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Zapisz prezentację
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw niestandardową pozycję dla węzła podrzędnego w obiekcie SmartArt**
Aspose.Slides for PHP via Java obsługuje ustawianie właściwości [SmartArtShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#setX) i [Y](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#setY). Poniższy fragment kodu pokazuje, jak ustawić niestandardową pozycję, rozmiar i obrót SmartArtShape; należy również zauważyć, że dodawanie nowych węzłów powoduje przeliczenie pozycji i rozmiarów wszystkich węzłów. Dzięki ustawieniom niestandardowej pozycji użytkownik może ustawiać węzły zgodnie z wymaganiami.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Przenieś kształt SmartArt na nową pozycję
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Zmień szerokości kształtu SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Zmień wysokość kształtu SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Zmień obrót kształtu SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Sprawdź węzeł asystenta**
{{% alert color="primary" %}} 

W tym artykule przyjrzymy się dalej funkcjom kształtów SmartArt dodawanych do slajdów prezentacji programowo przy użyciu Aspose.Slides for PHP via Java.

{{% /alert %}} 

Użyjemy następującego źródłowego kształtu SmartArt do naszych badań w różnych sekcjach tego artykułu.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Rysunek: Źródłowy kształt SmartArt na slajdzie**|

W poniższym przykładowym kodzie zbadamy, jak zidentyfikować **Assistant Nodes** w kolekcji węzłów SmartArt i jak je zmienić.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do drugiego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) jeśli jest SmartArt.
1. Przejdź przez wszystkie węzły wewnątrz kształtu SmartArt i sprawdź, czy są [**Assistant Nodes**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArtNode#isAssistant--).
1. Zmień status węzła Assistant na zwykły węzeł.
1. Zapisz prezentację.

```php
  # Tworzenie instancji prezentacji
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Sprawdź, czy kształt jest typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Rzutuj kształt na SmartArt
        $smart = $shape;
        # Przejście przez wszystkie węzły kształtu SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Sprawdź, czy węzeł jest węzłem asystenta
          if ($node->isAssistant()) {
            # Ustawienie węzła asystenta na false i zamiana go na zwykły węzeł
            $node->isAssistant();
          }
        }
      }
    }
    # Zapisz prezentację
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Rysunek: Zmodyfikowane węzły Assistant w kształcie SmartArt na slajdzie**|

## **Ustaw format wypełnienia węzła**
Aspose.Slides for PHP via Java umożliwia dodawanie niestandardowych kształtów SmartArt i ustawianie ich formatu wypełnienia. Ten artykuł wyjaśnia, jak tworzyć i uzyskiwać dostęp do kształtów SmartArt oraz ustawiać ich format wypełnienia przy użyciu Aspose.Slides for PHP via Java.

Proszę wykonać poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartart/) ustawiając jego [**LayoutType**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Ustaw [**Fill Format**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getFillFormat) dla węzłów kształtu SmartArt.
1. Napisz zmodyfikowaną prezentację jako plik PPTX.

```php
  # Utwórz instancję prezentacji
  $pres = new Presentation();
  try {
    # Uzyskiwanie dostępu do slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Dodawanie kształtu SmartArt i węzłów
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Ustawianie koloru wypełnienia węzła
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Zapisz prezentację
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wygeneruj miniaturę węzła podrzędnego SmartArt**
Programiści mogą wygenerować miniaturę węzła podrzędnego SmartArt, wykonując poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. [Dodaj SmartArt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnodecollection/#addNode).
1. Uzyskaj referencję do węzła, używając jego indeksu.
1. Pobierz obraz miniatury.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

```php
  # Utwórz obiekt klasy Presentation reprezentujący plik PPTX
  $pres = new Presentation();
  try {
    # Dodaj SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Uzyskaj referencję do węzła używając jego indeksu
    $node = $smart->getNodes()->get_Item(1);
    # Pobierz miniaturkę
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Zapisz miniaturkę
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy obsługiwana jest animacja SmartArt?**

Tak. SmartArt jest traktowany jako zwykły kształt, więc możesz [zastosować standardowe animacje](/slides/pl/php-java/shape-animation/) (wejścia, wyjścia, podkreślenia, ścieżki ruchu) i dostosować ich czas. Możesz również animować kształty wewnątrz węzłów SmartArt w razie potrzeby.

**Jak mogę niezawodnie zlokalizować konkretny SmartArt na slajdzie, jeśli jego wewnętrzny identyfikator jest nieznany?**

Przypisz i wyszukuj według [alternatywnego tekstu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getalternativetext/). Ustawienie charakterystycznego AltText na SmartArt umożliwia programowe odnalezienie go bez polegania na wewnętrznych identyfikatorach.

**Czy wygląd SmartArt zostanie zachowany przy konwersji prezentacji do PDF?**

Tak. Aspose.Slides renderuje SmartArt z wysoką wiernością wizualną podczas [eksportu do PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/), zachowując układ, kolory i efekty.

**Czy mogę wyodrębnić obraz całego SmartArt (do podglądów lub raportów)?**

Tak. Możesz renderować kształt SmartArt do [formatów rastrowych](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage) lub do [SVG](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/writeassvg/) w celu uzyskania skalowalnego wektora, co sprawia, że nadaje się do miniatur, raportów lub użytku w sieci.