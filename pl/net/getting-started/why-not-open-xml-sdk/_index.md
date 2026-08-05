---
title: Dlaczego nie Open XML SDK
type: docs
weight: 50
url: /pl/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- porównywanie
- model obiektu prezentacji
- konwersja wysokiej jakości
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji oraz szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy deweloperzy mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich elementami XML, natomiast Aspose.Slides jest przedstawiony jako biblioteka przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPointem.

Artykuł porównuje obie opcje pod kątem obsługiwanych formatów, modelu programowania, możliwości renderowania i drukowania, wsparcia platform oraz typowych scenariuszy użycia. Wyjaśnia również, że Open XML SDK może być odpowiedni do podstawowych operacji na PPTX lub bezpośredniego dostępu do elementów OOXML, podczas gdy Aspose.Slides jest bardziej odpowiedni do złożonych zadań, takich jak praca z wieloma formatami PowerPoint, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**
Czasami pojawia się pytanie: *Dlaczego powinniśmy używać produktów Aspose zamiast darmowego Open XML SDK?* 

Łatwo jest odpowiedzieć na to pytanie, odwołując się do funkcji i możliwości.

Zgodnie z [Biblioteką MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany w następujący sposób:

> "Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML oraz elementami schematu Open XML znajdującymi się w pakiecie. Open XML SDK 2.0 kapsułkuje wiele typowych zadań, które programiści wykonują na pakietach Open XML, tak aby można było przeprowadzać złożone operacje w kilku liniach kodu. Dokumenty OOXML to zasadniczo spakowane pliki XML, a Open XML SDK jest zestawem klas umożliwiających pracę z zawartością dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik w celu wyodrębnienia XML, ładować ten XML do drzewa DOM i pracować bezpośrednio z elementami i atrybutami XML, Open XML SDK dostarcza klasy, które to robią."

## **Czym jest Aspose.Slides?**
Aspose.Slides to biblioteka klas, która umożliwia aplikacjom wykonywanie następujących zadań przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego prezentacji.
- Konwersje wysokiej jakości obejmujące wszystkie popularne obsługiwane formaty prezentacji PowerPoint, w tym konwersję do PDF, XPS, TIFF oraz drukowanie.
- Generowanie miniatur slajdów w dobrze znanych formatach, takich jak PNG, JPEG i BMP, wraz z eksportem slajdów do SVG.
- Tworzenie prezentacji od podstaw lub poprzez łączenie elementów z jednego lub wielu dokumentów.
- Dodawanie animacji, ramek OLE, tabel, tworzenie i zarządzanie wykresami.
- Rozbudowane sterowanie i zarządzanie formatowaniem tekstu na poziomach TextFrames, Paragraphs i Portions.

Więcej informacji o dostępnych funkcjach znajdziesz na stronie [Funkcje Aspose.Slides](/slides/pl/net/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
Poniższa tabela porównuje możliwości i funkcje Open XML SDK z Aspose.Slides.

|**Funkcja lub Kategoria Funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT na PPTX|Nie|Tak|
|<p>Programowanie wysokiego poziomu przy użyciu modelu obiektowego dokumentu prezentacji (DOM): </p><p>- Znajdowanie i zamiana tekstów.</p><p>- Łączenie slajdów w prezentacjach.</p>|Nie|Tak|
|Szczegółowe programowanie przy użyciu modelu obiektowego dokumentu; dostęp do poszczególnych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Tak|Tak|
|Niskopoziomowy, bezpośredni i pełny dostęp do leżących u podstaw elementów XML i atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Tak|Nie|
|<p>Renderowanie i drukowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p><p>- Drukowanie prezentacji przy użyciu infrastruktury drukowania .NET. Komponent posiada wbudowaną metodę drukowania, która drukuje prezentacje tak, jak jest to pokazane w podglądzie wydruku MS PowerPoint.</p>|Nie|Tak|
|Obsługiwane platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Wnioski**
Open XML SDK i Aspose.Slides nie konkurują bezpośrednio, ponieważ zaspokajają zupełnie różne potrzeby i są skierowane do innych odbiorców.

{{% alert color="primary" %}} 

Open XML SDK jest biblioteką klas zapewniającą silnie typowany sposób pracy z dokumentami OOXML, natomiast Aspose.Slides jest niezwykle przydatną biblioteką przetwarzania prezentacji, która oferuje doskonałe wsparcie dla prawie wszystkich formatów plików Microsoft PowerPoint. 

{{% /alert %}} 

Jeśli Twój przepływ pracy polega na podstawowych operacjach programistycznych na dokumencie PPTX, Open XML SDK może być dobrym wyborem. Dzięki Open XML SDK możesz swobodnie wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów itp. Niektóre zadania można wykonać przy użyciu Open XML SDK, ale nie przy użyciu Aspose.Slides. Na przykład, jeśli potrzebujesz bezpośredniego dostępu do elementów i atrybutów XML dokumentu OOXML, powinieneś użyć Open XML SDK.

Jeśli musisz wykonać złożone zadania na dokumentach — takie jak wymienione poniżej — Aspose.Slides jest Twoją najlepszą opcją.

- Operacje obejmujące starsze formaty PowerPoint (oraz PPTX).
- Kopiowanie lub klonowanie kształtów w slajdach w sposób łączący obiekty, style i inne elementy formatowania w odpowiedni sposób.
- Zastępowanie sformatowanego lub niesformatowanego tekstu.
- Stosowanie animacji i używanie łączników z kształtami.
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby wygląd był taki, jak po konwersji w Microsoft PowerPoint.
- Tworzenie aplikacji .NET lub Java zarówno w środowiskach desktopowych, jak i webowych.