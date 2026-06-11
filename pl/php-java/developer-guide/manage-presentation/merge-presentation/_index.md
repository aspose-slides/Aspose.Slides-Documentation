---
title: "Efektywne scalanie prezentacji w PHP"
linktitle: "Scalanie prezentacji"
type: docs
weight: 40
url: /pl/php-java/merge-presentation/
keywords:
- "scalać PowerPoint"
- "scalać prezentacje"
- "scalać slajdy"
- "scalać PPT"
- "scalać PPTX"
- "scalać ODP"
- "łączyć PowerPoint"
- "łączyć prezentacje"
- "łączyć slajdy"
- "łączyć PPT"
- "łączyć PPTX"
- "łączyć ODP"
- "PHP"
- "Aspose.Slides"
description: "Bezproblemowo scalaj prezentacje PowerPoint (PPT, PPTX) oraz OpenDocument (ODP) przy użyciu Aspose.Slides for PHP via Java, usprawniając swój przepływ pracy."
---
## **Przegląd**

Aspose.Slides umożliwia scalanie prezentacji przez klonowanie slajdów z jednej prezentacji do drugiej. Ten artykuł wyjaśnia, jak scalać całe prezentacje lub wybrane slajdy, używać szablonu master lub określonego układu podczas scalania, obsługiwać prezentacje o różnych rozmiarach slajdów oraz dodawać scalone slajdy do sekcji prezentacji. Zawiera także praktyczne uwagi dotyczące scalanej zawartości, w tym notatki prelegenta, komentarze, pliki źródłowe zabezpieczone hasłem oraz wykorzystanie wątków.

## **Scalanie prezentacji**

Kiedy scalasz jedną prezentację z drugą, w praktyce łączysz ich slajdy w jednej prezentacji, uzyskując jeden plik.

{{% alert title="Info" color="info" %}}

Większość programów do prezentacji (PowerPoint lub OpenOffice) nie posiada funkcji umożliwiających użytkownikom łączenie prezentacji w taki sposób.

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/pl/php-java/), umożliwia natomiast scalanie prezentacji na różne sposoby. Możesz scalać prezentacje ze wszystkimi ich kształtami, stylami, tekstami, formatowaniem, komentarzami, animacjami itp., nie martwiąc się o utratę jakości czy danych.

**Zobacz także**

[Klonuj slajdy](/slides/pl/php-java/clone-slides/).

{{% /alert %}}

### **Co można scalać**

Z Aspose.Slides możesz scalać 

* całe prezentacje. Wszystkie slajdy z prezentacji kończą się w jednej prezentacji
* konkretne slajdy. Wybrane slajdy kończą się w jednej prezentacji
* prezentacje w jednym formacie (PPT do PPT, PPTX do PPTX itp.) oraz w różnych formatach (PPT do PPTX, PPTX do ODP itp.) względem siebie. 

{{% alert title="Note" color="warning" %}} 

Oprócz prezentacji, Aspose.Slides umożliwia scalanie innych plików:

* [Obrazy](https://products.aspose.com/slides/pl/php-java/merger/image-to-image/), takie jak [JPG do JPG](https://products.aspose.com/slides/pl/php-java/merger/jpg-to-jpg/) lub [PNG do PNG](https://products.aspose.com/slides/pl/php-java/merger/png-to-png/)
* Dokumenty, takie jak [PDF do PDF](https://products.aspose.com/slides/pl/php-java/merger/pdf-to-pdf/) lub [HTML do HTML](https://products.aspose.com/slides/pl/php-java/merger/html-to-html/)
* I dwa różne typy plików, takie jak [obraz do PDF](https://products.aspose.com/slides/pl/php-java/merger/image-to-pdf/) lub [JPG do PDF](https://products.aspose.com/slides/pl/php-java/merger/jpg-to-pdf/) lub [TIFF do PDF](https://products.aspose.com/slides/pl/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opcje scalania**

Możesz zastosować opcje określające, czy

* każdy slajd w prezentacji wyjściowej zachowuje unikalny styl
* określony styl jest używany dla wszystkich slajdów w prezentacji wyjściowej. 

Aby scalać prezentacje, Aspose.Slides udostępnia metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) (z klasy [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/)). Istnieje kilka implementacji metod `addClone`, które określają parametry procesu scalania prezentacji. Każdy obiekt Presentation posiada kolekcję [slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getslides/), więc możesz wywołać metodę `addClone` z prezentacji, do której chcesz scalić slajdy.

Metoda `addClone` zwraca obiekt `Slide`, który jest klonem slajdu źródłowego. Slajdy w prezentacji wynikowej są po prostu kopią slajdów ze źródła. Dzięki temu możesz wprowadzać zmiany w powstałych slajdach (np. stosować style, opcje formatowania lub układy), nie martwiąc się o wpływ na źródłowe prezentacje.

## **Scalanie prezentacji** 

Aspose.Slides udostępnia metodę [addClone(Slide)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) , która pozwala łączyć slajdy, zachowując ich układy i style (parametry domyślne).

Ten kod PHP pokazuje, jak scalić prezentacje:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Scalanie prezentacji z szablonem master** 

Aspose.Slides udostępnia metodę [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) , która pozwala łączyć slajdy, stosując szablon szablonu master prezentacji. W ten sposób, w razie potrzeby, możesz zmienić styl slajdów w prezentacji wynikowej.

Ten kod demonstruje opisaną operację:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

Układ slajdu dla szablonu master jest określany automatycznie. Gdy nie można określić odpowiedniego układu, jeśli parametr boolowski `allowCloneMissingLayout` metody `addClone` jest ustawiony na true, używany jest układ slajdu źródłowego. W przeciwnym razie zostanie zgłoszony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

Jeśli chcesz, aby slajdy w prezentacji wynikowej miały inny układ slajdu, użyj zamiast tego metody [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) .

## **Scalanie konkretnych slajdów z prezentacji** 

Scalanie konkretnych slajdów z wielu prezentacji jest przydatne przy tworzeniu niestandardowych zestawień slajdów. Aspose.Slides for PHP via Java umożliwia wybór i importowanie wyłącznie potrzebnych slajdów. API zachowuje formatowanie, układ i projekt oryginalnych slajdów.

Następujący kod PHP tworzy nową prezentację, dodaje slajdy tytułowe z dwóch innych prezentacji i zapisuje wynik do pliku:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Scalanie prezentacji z układem slajdu** 

Ten kod PHP pokazuje, jak połączyć slajdy z prezentacji, stosując wybrany układ slajdu, aby uzyskać jedną prezentację wynikową:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Scalanie prezentacji o różnych rozmiarach slajdów** 

{{% alert title="Note" color="warning" %}} 

Nie można scalać prezentacji o różnych rozmiarach slajdów. 

{{% /alert %}}

Aby scalić 2 prezentacje o różnych rozmiarach slajdów, należy zmienić rozmiar jednej z nich, aby dopasować go do rozmiaru drugiej prezentacji. 

Ten przykładowy kod demonstruje opisaną operację:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Scalanie slajdów do sekcji prezentacji** 

Ten kod PHP pokazuje, jak scalić konkretny slajd do sekcji w prezentacji:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

Slajd jest dodawany na końcu sekcji. 

## **Zobacz także**


Aspose udostępnia [DARMOWY Kreator Kolaży Online](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz scalać [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub obrazy PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), i więcej.

Sprawdź [Aspose DARMOWY Online Merger](https://products.aspose.app/slides/pl/merger). Pozwala on scalać prezentacje PowerPoint w tym samym formacie (np. PPT do PPT, PPTX do PPTX) lub w różnych formatach (np. PPT do PPTX, PPTX do ODP).

[![Aspose DARMOWY Online Merger](slides-merger.png)](https://products.aspose.app/slides/pl/merger)

## **FAQ**

**Czy istnieją jakieś ograniczenia liczby slajdów przy scalaniu prezentacji?**

Nie ma sztywnych ograniczeń. Aspose.Slides radzi sobie z dużymi plikami, ale wydajność zależy od rozmiaru i zasobów systemowych. Dla bardzo dużych prezentacji zaleca się użycie 64‑bitowej JVM oraz przydzielenie wystarczającej pamięci sterty.

**Czy mogę scalać prezentacje z osadzonym wideo lub dźwiękiem?**

Tak, Aspose.Slides zachowuje multimedia osadzone w slajdach, ale finalna prezentacja może stać się znacznie większa.

**Czy czcionki zostaną zachowane przy scalaniu prezentacji?**

Tak. Czcionki użyte w prezentacjach źródłowych są zachowane w pliku wynikowym, zakładając że są zainstalowane w systemie lub [osadzone](/slides/pl/php-java/embedded-font/).