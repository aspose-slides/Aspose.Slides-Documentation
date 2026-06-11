---
title: Zarządzaj nagłówkami i stopkami prezentacji w PHP
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/php-java/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- materiały drukowane
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Użyj Aspose.Slides dla PHP poprzez Java, aby dodać i dostosować nagłówki oraz stopki w prezentacjach PowerPoint i OpenDocument, uzyskując profesjonalny wygląd."
---
## **Przegląd**

Aspose.Slides umożliwia zarządzanie ustawieniami nagłówków i stopek w prezentacjach PowerPoint. Nagłówki i stopki są obsługiwane na poziomie mastera prezentacji, a API zapewnia metody do ustawiania tekstu stopki, zmiany widoczności stopki oraz aktualizacji tekstu nagłówka na slajdach master notes.

Możesz także zarządzać nagłówkami i stopkami dla slajdów materiałów drukowanych i notatek. Obejmuje to zmianę widoczności i tekstu pól zastępczych nagłówka, stopki, numeru slajdu oraz daty/godziny dla mastera notatek, wszystkich podrzędnych slajdów notatek lub pojedynczego slajdu notatek.

## **Zarządzanie nagłówkami i stopkami w prezentacji**

Notatki niektórych konkretnych slajdów mogą zostać usunięte, jak pokazano w poniższym przykładzie:

```php
  # Załaduj prezentację
  $pres = new Presentation("headerTest.pptx");
  try {
    # Ustawianie stopki
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Dostęp i aktualizacja nagłówka
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Zapisz prezentację
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Zarządzanie nagłówkami i stopkami w materiałach drukowanych i notatkach**
Aspose.Slides dla PHP poprzez Java obsługuje nagłówki i stopki w materiałach drukowanych i slajdach notatek. Proszę postępować zgodnie z poniższymi krokami:

- Załaduj [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) zawierający wideo.
- Zmien ustawienia nagłówka i stopki dla mastera notatek oraz wszystkich slajdów notatek.
- Ustaw widoczność pól stopki w masterze notatek oraz we wszystkich podrzędnych slajdach.
- Ustaw widoczność pól daty i godziny w masterze notatek oraz we wszystkich podrzędnych slajdach.
- Zmien ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek.
- Ustaw widoczność pola nagłówka w slajdzie notatek.
- Ustaw tekst w polu nagłówka slajdu notatek.
- Ustaw tekst w polu daty i godziny slajdu notatek.
- Zapisz zmodyfikowany plik prezentacji.

Fragment kodu podany w poniższym przykładzie.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Zmień ustawienia nagłówka i stopki dla mastera notatek i wszystkich slajdów notatek
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// pokaż master slajd notatek oraz wszystkie podrzędne pola stopki

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// pokaż master slajd notatek oraz wszystkie podrzędne pola nagłówka

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// pokaż master slajd notatek oraz wszystkie podrzędne pola numeru slajdu

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// pokaż master slajd notatek oraz wszystkie podrzędne pola daty i godziny

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// ustaw tekst w master slajdzie notatek oraz wszystkich podrzędnych polach nagłówka

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// ustaw tekst w master slajdzie notatek oraz wszystkich podrzędnych polach stopki

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// ustaw tekst w master slajdzie notatek oraz wszystkich podrzędnych polach daty i godziny

    }
    # Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// pokaż to pole nagłówka slajdu notatek

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// pokaż to pole stopki slajdu notatek

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// pokaż to pole numeru slajdu notatek

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// pokaż to pole daty i godziny slajdu notatek

      $headerFooterManager->setHeaderText("New header text");// ustaw tekst w polu nagłówka slajdu notatek

      $headerFooterManager->setFooterText("New footer text");// ustaw tekst w polu stopki slajdu notatek

      $headerFooterManager->setDateTimeText("New date and time text");// ustaw tekst w polu daty i godziny slajdu notatek

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę dodać „nagłówek” do zwykłych slajdów?**

W PowerPoint „nagłówek” istnieje tylko w notatkach i materiałach drukowanych; na zwykłych slajdach obsługiwane elementy to stopka, data/godzina oraz numer slajdu. W Aspose.Slides obowiązują te same ograniczenia: nagłówek tylko w notatkach/materialach drukowanych, a na slajdach — stopka/data i godzina/ numer slajdu.

**Co jeśli układ nie zawiera obszaru stopki — czy mogę „włączyć” jej widoczność?**

Tak. Sprawdź widoczność za pomocą menedżera nagłówka/stopki i włącz ją w razie potrzeby. Te wskaźniki i metody API są przeznaczone dla przypadków, gdy pole zastępcze jest nieobecne lub ukryte.

**Jak sprawić, aby numer slajdu zaczynał się od wartości innej niż 1?**

Ustaw [pierwszy numer slajdu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/setfirstslidenumber/) prezentacji; po tym wszystkie numery są przeliczane. Na przykład możesz zacząć od 0 lub 10 oraz ukryć numer na slajdzie tytułowym.

**Co się dzieje z nagłówkami/stopkami podczas eksportu do PDF/obrazów/HTML?**

Są renderowane jako zwykłe elementy tekstowe prezentacji. Oznacza to, że jeśli elementy są widoczne na slajdach/stronach notatek, pojawią się również w formacie wyjściowym wraz z resztą treści.