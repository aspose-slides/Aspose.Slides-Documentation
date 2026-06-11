---
title: Konwertuj PPT do PPTX w JavaScript
linktitle: PPT do PPTX
type: docs
weight: 20
url: /pl/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Szybko konwertuj starsze prezentacje PPT na nowoczesny format PPTX przy użyciu Aspose.Slides dla Node.js — przejrzysty samouczek, darmowe przykłady kodu, bez zależności od Microsoft Office."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak skonwertować prezentację PowerPoint w formacie PPT do formatu PPTX przy użyciu JavaScript oraz aplikacji online do konwersji PPT na PPTX. Omówiono następujący temat.

- Konwertuj PPT do PPTX w JavaScript

## **Java – konwersja PPT do PPTX**

Aby zobaczyć przykładowy kod JavaScript do konwersji PPT do PPTX, zobacz sekcję poniżej, czyli [Convert PPT to PPTX](#convert-ppt-to-pptx). Kod po prostu wczytuje plik PPT i zapisuje go w formacie PPTX. Określając różne formaty zapisu, możesz także zapisać plik PPT w wielu innych formatach, takich jak PDF, XPS, ODP, HTML itp., jak opisano w poniższych artykułach.

- [Konwertuj PPT do PDF w JavaScript](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/)
- [Konwertuj PPT do XPS w JavaScript](/slides/pl/nodejs-java/convert-powerpoint-to-xps/)
- [Konwertuj PPT do HTML w JavaScript](/slides/pl/nodejs-java/convert-powerpoint-to-html/)
- [Konwertuj PPT do ODP w JavaScript](/slides/pl/nodejs-java/save-presentation/)
- [Konwertuj PPT do PNG w JavaScript](/slides/pl/nodejs-java/convert-powerpoint-to-png/)

## **O konwersji PPT do PPTX**
Konwertuj starszy format PPT do PPTX przy użyciu Aspose.Slides API. Jeśli potrzebujesz przekonwertować tysiące prezentacji PPT do formatu PPTX, najlepszym rozwiązaniem jest wykonanie tego programowo. Dzięki Aspose.Slides API można to zrobić w kilku linijkach kodu. API zapewnia pełną kompatybilność przy konwersji prezentacji PPT do PPTX i umożliwia:

- Konwertuj skomplikowane struktury masterów, układów i slajdów.
- Konwertuj prezentację z wykresami.
- Konwertuj prezentację z grupami kształtów, auto‑kształtami (takimi jak prostokąty i elipsy), kształtami o niestandardowej geometrii.
- Konwertuj prezentację zawierającą tekstury i style wypełnienia obrazami dla auto‑kształtów.
- Konwertuj prezentację z polami zastępczymi, ramkami tekstowymi i kontenerami tekstu.

{{% alert color="primary" %}} 

Sprawdź aplikację [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx)

Ta aplikacja została zbudowana w oparciu o [**Aspose.Slides API**](https://products.aspose.com/slides/pl/nodejs-java/), więc możesz zobaczyć działający przykład podstawowych możliwości konwersji PPT do PPTX. Aspose.Slides Conversion to aplikacja internetowa, która umożliwia przeciągnięcie pliku prezentacji w formacie PPT i pobranie go po konwersji do PPTX.

Znajdź inne działające przykłady [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pl/conversion/).

{{% /alert %}} 

## **Konwersja PPT do PPTX**
Aspose.Slides for Node.js via Java umożliwia programistom dostęp do pliku PPT przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i konwersję do odpowiedniego formatu [PPTX](https://docs.fileformat.com/presentation/pptx/). Obecnie obsługuje częściową konwersję [PPT](https://docs.fileformat.com/presentation/ppt/) do PPTX.

Aspose.Slides for Node.js via Java oferuje klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation), która reprezentuje plik prezentacji **PPTX**. Klasa Presentation może teraz również uzyskać dostęp do **PPT** po utworzeniu obiektu. Poniższy przykład pokazuje, jak przekonwertować prezentację PPT na prezentację PPTX.

```javascript
// Utwórz obiekt Presentation, który reprezentuje plik PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Zapisywanie prezentacji PPTX w formacie PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Rysunek: źródłowa prezentacja PPT**|

Powyższy fragment kodu wygenerował następującą prezentację PPTX po konwersji

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Rysunek: Wygenerowana prezentacja PPTX po konwersji**|

## **FAQ**

**Jaka jest różnica między formatami PPT i PPTX?**

PPT to starszy binarny format pliku używany przez Microsoft PowerPoint, natomiast PPTX to nowszy format oparty na XML, wprowadzony w Microsoft Office 2007. Pliki PPTX zapewniają lepszą wydajność, mniejszy rozmiar pliku i usprawnione odzyskiwanie danych.

**Czy Aspose.Slides obsługuje konwersję wsadową wielu plików PPT do PPTX?**

Tak, możesz używać Aspose.Slides w pętli, aby programowo konwertować wiele plików PPT do PPTX, co czyni go odpowiednim do scenariuszy konwersji wsadowej.

**Czy zawartość i formatowanie zostaną zachowane po konwersji?**

Aspose.Slides zachowuje wysoką wierność przy konwersji prezentacji. Układy slajdów, animacje, kształty, wykresy i inne elementy projektu są zachowywane podczas konwersji PPT do PPTX.

**Czy mogę konwertować inne formaty, takie jak PDF lub HTML, z plików PPT?**

Tak, Aspose.Slides obsługuje konwersję plików PPT do wielu formatów, w tym PDF, XPS, HTML, ODP oraz formatów obrazu takich jak PNG i JPEG.

**Czy można konwertować PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak, Aspose.Slides jest samodzielnym API i nie wymaga Microsoft PowerPoint ani żadnego oprogramowania firm trzecich do wykonania konwersji.

**Czy dostępne jest narzędzie online do konwersji PPT na PPTX?**

Tak, możesz skorzystać z darmowej aplikacji internetowej [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx), aby wykonać konwersję bezpośrednio w przeglądarce, bez potrzeby pisania kodu.