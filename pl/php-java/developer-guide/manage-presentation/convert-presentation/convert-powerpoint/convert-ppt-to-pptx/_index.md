---
title: Konwersja PPT do PPTX w PHP
linktitle: PPT do PPTX
type: docs
weight: 20
url: /pl/php-java/convert-ppt-to-pptx/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- PPT do PPTX
- zapisz PPT jako PPTX
- eksportuj PPT do PPTX
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Konwertuj starsze prezentacje PPT na nowoczesny format PPTX szybko dzięki Aspose.Slides for PHP via Java — przejrzysty tutorial, darmowe przykłady kodu, bez zależności od Microsoft Office."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentację PowerPoint w formacie PPT do formatu PPTX przy użyciu PHP oraz aplikacji do konwersji online PPT na PPTX. Omówiono następujący temat.

- Konwersja PPT na PPTX

## **Konwersja PPT na PPTX w PHP**

Przykładowy kod Java do konwersji PPT na PPTX można znaleźć w sekcji poniżej, tj. [Convert PPT to PPTX](#convert-ppt-to-pptx). Po prostu wczytuje plik PPT i zapisuje go w formacie PPTX. Określając różne formaty zapisu, można również zapisać plik PPT w wielu innych formatach, takich jak PDF, XPS, ODP, HTML itp., jak omówiono w tych artykułach.

- [Konwersja PPT do PDF w PHP](/slides/pl/php-java/convert-powerpoint-to-pdf/)
- [Konwersja PPT do XPS w PHP](/slides/pl/php-java/convert-powerpoint-to-xps/)
- [Konwersja PPT do HTML w PHP](/slides/pl/php-java/convert-powerpoint-to-html/)
- [Konwersja PPT do ODP w PHP](/slides/pl/php-java/save-presentation/)
- [Konwersja PPT do PNG w PHP](/slides/pl/php-java/convert-powerpoint-to-png/)

## **O konwersji PPT do PPTX**

Konwertuj starszy format PPT na PPTX przy użyciu Aspose.Slides API. Jeśli potrzebujesz przekonwertować tysiące prezentacji PPT do formatu PPTX, najlepszym rozwiązaniem jest wykonanie tego programowo. Dzięki Aspose.Slides API jest to możliwe w kilku linijkach kodu. API zapewnia pełną kompatybilność przy konwersji prezentacji PPT do PPTX i umożliwia:

- Konwertowanie skomplikowanych struktur masterów, układów i slajdów.
- Konwertowanie prezentacji z wykresami.
- Konwertowanie prezentacji z grupowanymi kształtami, auto‑kształtami (takimi jak prostokąty i elipsy), kształtami o niestandardowej geometrii.
- Konwertowanie prezentacji posiadających tekstury i style wypełnień obrazami dla auto‑kształtów.
- Konwertowanie prezentacji z placeholderami, ramkami tekstowymi i elementami tekstowymi.

{{% alert color="primary" %}} 

Zapoznaj się z aplikacją [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx)

Ta aplikacja została zbudowana w oparciu o [**Aspose.Slides API**](https://products.aspose.com/slides/pl/php-java/), więc możesz zobaczyć działający przykład podstawowych możliwości konwersji PPT do PPTX. Aspose.Slides Conversion to aplikacja internetowa, która umożliwia przeciągnięcie pliku prezentacji w formacie PPT i pobranie go po konwersji do PPTX.

Znajdź inne działające przykłady [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pl/conversion/).

{{% /alert %}} 

## **Konwersja PPT na PPTX**

Aspose.Slides for PHP via Java umożliwia teraz programistom dostęp do pliku PPT przy użyciu instancji klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i konwersję do odpowiedniego formatu [PPTX](https://docs.fileformat.com/presentation/pptx/). Obecnie obsługuje częściową konwersję [PPT ](https://docs.fileformat.com/presentation/ppt/)do PPTX. Aby uzyskać więcej informacji o obsługiwanych i nieobsługiwanych funkcjach w konwersji PPT do PPTX, przejdź do tej dokumentacji [link](/slides/pl/php-java/ppt-to-pptx-conversion/).

Aspose.Slides for PHP via Java udostępnia klasę [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation), która reprezentuje plik prezentacji **PPTX**. Klasa Presentation może teraz również uzyskać dostęp do **PPT** poprzez Presentation po zainicjowaniu obiektu. Poniższy przykład pokazuje, jak skonwertować prezentację PPT na prezentację PPTX.

```php
  # Utwórz obiekt Presentation, który reprezentuje plik PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # Zapisz prezentację PPTX w formacie PPTX
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Rysunek: Źródłowa prezentacja PPT**|

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Rysunek: Wygenerowana prezentacja PPTX po konwersji**|

## **FAQ**

**Jaka jest różnica między formatami PPT i PPTX?**

PPT jest starszym binarnym formatem plików używanym przez Microsoft PowerPoint, podczas gdy PPTX jest nowszym formatem opartym na XML, wprowadzonym w Microsoft Office 2007. Pliki PPTX zapewniają lepszą wydajność, mniejszy rozmiar pliku i lepsze odzyskiwanie danych.

**Czy Aspose.Slides obsługuje konwersję wsadową wielu plików PPT do PPTX?**

Tak, możesz używać Aspose.Slides w pętli, aby programowo konwertować wiele plików PPT na PPTX, co czyni ją odpowiednią do scenariuszy konwersji wsadowej.

**Czy zawartość i formatowanie zostaną zachowane po konwersji?**

Aspose.Slides utrzymuje wysoką wierność przy konwertowaniu prezentacji. Układy slajdów, animacje, kształty, wykresy i inne elementy projektu są zachowywane podczas konwersji PPT do PPTX.

**Czy mogę konwertować inne formaty, takie jak PDF lub HTML, z plików PPT?**

Tak, Aspose.Slides obsługuje konwersję plików PPT do [wielu formatów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/), w tym PDF, XPS, HTML, ODP oraz formatów obrazów, takich jak PNG i JPEG.

**Czy możliwe jest konwertowanie PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak, Aspose.Slides jest samodzielnym API i nie wymaga Microsoft PowerPoint ani żadnego oprogramowania firm trzecich do wykonania konwersji.

**Czy dostępne jest narzędzie online do konwersji PPT na PPTX?**

Tak, możesz skorzystać z darmowej aplikacji internetowej [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx), aby wykonać konwersję bezpośrednio w przeglądarce, bez pisania kodu.