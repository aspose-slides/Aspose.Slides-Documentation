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
- model obiektowy prezentacji
- konwersja wysokiej jakości
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji i szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę służącą do manipulacji pakietami OOXML i ich elementami XML, natomiast Aspose.Slides jako bibliotekę przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPointem.

Artykuł porównuje oba rozwiązania pod kątem obsługiwanych formatów, modelu programowania, możliwości renderowania i drukowania, wsparcia platform oraz typowych przypadków użycia. Wyjaśnia również, że Open XML SDK może być odpowiedni dla podstawowych operacji na PPTX lub bezpośredniego dostępu do elementów OOXML, podczas gdy Aspose.Slides lepiej sprawdza się w złożonych zadaniach, takich jak praca z wieloma formatami PowerPointa, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**
Czasami pojawia się pytanie: *Dlaczego powinniśmy używać produktów Aspose zamiast darmowego Open XML SDK?*  

Odpowiedź na to pytanie jest prosta, jeśli spojrzeć na funkcje i możliwości.  

Zgodnie z [Biblioteka MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK definiuje się w następujący sposób:

> "Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML i ich podstawowymi elementami schematu Open XML w pakiecie. Open XML SDK 2.0 kapsułkuje wiele typowych zadań wykonywanych przez programistów na pakietach Open XML, tak aby można było wykonać złożone operacje przy użyciu kilku linii kodu. Dokumenty OOXML są w istocie spakowanymi plikami XML, a Open XML SDK jest zestawem klas umożliwiających pracę z treścią dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik w celu wyodrębnienia XML, ładować ten XML do drzewa DOM i pracować bezpośrednio z elementami i atrybutami XML, Open XML SDK dostarcza klasy, które to realizują."

## **Czym jest Aspose.Slides?**
Aspose.Slides to biblioteka klas, która umożliwia aplikacjom wykonywanie następujących zadań przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego prezentacji.  
- Wysokiej jakości konwersje obejmujące wszystkie popularne formaty PowerPoint, w tym konwersję do PDF, XPS, TIFF oraz drukowanie.  
- Generowanie miniatur slajdów w znanych formatach, takich jak PNG, JPEG i BMP, a także eksport slajdów do SVG.  
- Tworzenie prezentacji od podstaw lub poprzez łączenie elementów z jednego lub wielu dokumentów.  
- Dodawanie animacji, ramek OLE, tabel, tworzenie i zarządzanie wykresami.  
- Rozbudowane sterowanie i zarządzanie formatowaniem tekstu na poziomach TextFrames, Paragraphs i Portions.  

Po więcej szczegółów na temat dostępnych funkcji zobacz stronę [Funkcje Aspose.Slides](/slides/pl/net/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
Poniższa tabela porównuje możliwości i funkcje Open XML SDK z Aspose.Slides.

|**Funkcja lub Kategoria funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|Nie|Tak|
|<p>Programowanie wysokiego poziomu przy użyciu modelu obiektowego dokumentu prezentacji (DOM):</p><p>- Znajdowanie i zamiana tekstów.</p><p>- Składanie slajdów w prezentacjach.</p>|Nie|Tak|
|Szczegółowe programowanie przy użyciu modelu obiektowego dokumentu; dostęp do poszczególnych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Tak|Tak|
|Niskopoziomowy, bezpośredni i pełny dostęp do podstawowych elementów XML i atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Tak|Nie|
|<p>Renderowanie i drukowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p><p>- Drukowanie prezentacji przy użyciu infrastruktury drukowania .NET. Komponent posiada wbudowaną metodę drukowania, aby wydrukować prezentacje tak, jak w podglądzie wydruku programu MS PowerPoint.</p>|Nie|Tak|
|Obsługiwane platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Wnioski**
Open XML SDK i Aspose.Slides nie konkurują ze sobą bezpośrednio, ponieważ adresują zupełnie inne potrzeby i są skierowane do różnych odbiorców.  

{{% alert color="info" %}}  

Open XML SDK to biblioteka klas zapewniająca silnie typowany sposób pracy z dokumentami OOXML, natomiast Aspose.Slides to niezwykle przydatna biblioteka przetwarzania prezentacji oferująca doskonałe wsparcie dla prawie wszystkich formatów plików Microsoft PowerPoint.  

{{% /alert %}}  

Jeśli Twój scenariusz to podstawowa operacja programistyczna na dokumencie PPTX, Open XML SDK może być dobrym wyborem. Dzięki Open XML SDK możesz z łatwością wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów i podobne. Niektóre zadania można wykonać przy pomocy Open XML SDK, a nie przy użyciu Aspose.Slides. Przykładowo, jeśli potrzebujesz bezpośredniego dostępu do elementów XML i atrybutów dokumentu OOXML, powinieneś użyć Open XML SDK.  

Jeśli musisz wykonywać złożone zadania na dokumentach — takie jak wymienione poniżej — Aspose.Slides jest najlepszą opcją.  

- Operacje obejmujące starsze formaty PowerPoint (oraz PPTX).  
- Kopiowanie lub klonowanie kształtów w slajdach w sposób łączący obiekty, style i inne elementy formatowania w odpowiedni sposób.  
- Zamiana sformatowanego lub niesformatowanego tekstu.  
- Stosowanie animacji i używanie łączy między kształtami.  
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby wyglądał tak, jakby konwersję wykonał Microsoft PowerPoint.  
- Tworzenie aplikacji .NET lub Java w środowiskach desktopowych i internetowych.