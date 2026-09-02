---
title: Dlaczego nie Open XML SDK
type: docs
weight: 50
url: /pl/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
  - Open XML SDK
  - porównanie
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

Ten artykuł wyjaśnia, kiedy deweloperzy mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulowania pakietami OOXML i ich elementami XML, podczas gdy Aspose.Slides prezentowany jest jako biblioteka przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPoint.

Artykuł porównuje obie opcje pod względem obsługiwanych formatów, modelu programowania, renderowania, wsparcia platform oraz typowych scenariuszy użycia. Wyjaśnia także, że Open XML SDK może być odpowiedni dla podstawowych operacji na PPTX lub bezpośredniego dostępu do elementów OOXML, natomiast Aspose.Slides jest bardziej stosowny do złożonych zadań, takich jak praca z wieloma formatami PowerPoint, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**
Czasami pojawia się pytanie: *Dlaczego powinniśmy używać produktów Aspose zamiast darmowego Open XML SDK?*  

Odpowiedź na to pytanie jest prosta, gdy patrzymy na funkcje i możliwości.  

Zgodnie z [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany w następujący sposób:

> "Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML oraz podstawowymi elementami schematu Open XML wewnątrz pakietu. Open XML SDK 2.0 kapsułkuje wiele typowych zadań, które programiści wykonują na pakietach Open XML, tak aby można było przeprowadzić skomplikowane operacje przy użyciu kilku linii kodu. Dokumenty OOXML są zasadniczo spakowanymi plikami XML, a Open XML SDK jest zbiorem klas pozwalających pracować z treścią dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik w celu wyodrębnienia XML, ładować ten XML do drzewa DOM i pracować bezpośrednio z elementami i atrybutami XML, Open XML SDK udostępnia klasy umożliwiające te czynności."

## **Czym jest Aspose.Slides?**
Aspose.Slides to biblioteka klas, która umożliwia aplikacjom wykonywanie następujących zadań przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego prezentacji.  
- Konwersje wysokiej jakości obejmujące wszystkie popularne formaty prezentacji PowerPoint, w tym konwersję do PDF, XPS i TIFF.  
- Generowanie miniaturek slajdów w znanych formatach, takich jak PNG, JPEG i BMP, oraz eksport slajdów do SVG.  
- Tworzenie prezentacji od podstaw lub poprzez łączenie elementów z jednego lub wielu dokumentów.  
- Dodawanie animacji, ramek OLE, tabel, tworzenie i zarządzanie wykresami.  
- Rozbudowane sterowanie i zarządzanie formatowaniem tekstu na poziomach TextFrames, Paragraphs i Portions.  

Po więcej szczegółów na temat dostępnych funkcji zobacz stronę [Aspose.Slides Features](/slides/pl/net/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
Poniższa tabela porównuje możliwości i funkcje Open XML SDK z Aspose.Slides.

|**Funkcja lub kategoria funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|No|Yes|
|<p>Programowanie wysokiego poziomu z modelem obiektowym dokumentu prezentacji (DOM): </p><p>- Znajdź i zamień teksty.</p><p>- Zgromadź slajdy w prezentacjach.</p>|No|Yes|
|Szczegółowe programowanie z modelem obiektowym dokumentu; dostęp do poszczególnych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Yes|Yes|
|Niskopoziomowy, bezpośredni i pełny dostęp do podstawowych elementów XML oraz atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Yes|No|
|<p>Renderowanie prezentacji:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniaturek slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p>|No|Yes|
|Obsługiwane platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Wnioski**
Open XML SDK i Aspose.Slides nie konkurują ze sobą bezpośrednio, ponieważ spełniają zupełnie inne potrzeby i są skierowane do różnych odbiorców.  

{{% alert color="info" %}}  

Open XML SDK jest biblioteką klas zapewniającą silnie typowany sposób pracy z dokumentami OOXML, natomiast Aspose.Slides to niezwykle przydatna biblioteka przetwarzania prezentacji, która oferuje doskonałe wsparcie dla praktycznie wszystkich formatów plików Microsoft PowerPoint.  

{{% /alert %}}  

Jeśli Twój przepływ pracy polega na podstawowej operacji programistycznej na dokumencie PPTX, Open XML SDK może być dobrym wyborem. Dzięki Open XML SDK możesz komfortowo wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów i podobne. Niektóre zadania można wykonać przy użyciu Open XML SDK, a nie przy użyciu Aspose.Slides. Na przykład, jeśli musisz uzyskać bezpośredni dostęp do elementów XML i atrybutów dokumentu OOXML, powinieneś użyć Open XML SDK.  

Jeśli potrzebujesz wykonać złożone zadania na dokumentach — takie jak poniższe — Aspose.Slides jest Twoją najlepszą opcją.

- Operacje obejmujące starsze formaty PowerPoint (oraz PPTX).  
- Kopiowanie lub klonowanie kształtów w slajdach w sposób łączący obiekty, style i inne elementy formatowania w odpowiedni sposób.  
- Zastępowanie sformatowanego lub niesformatowanego tekstu.  
- Stosowanie animacji i używanie łączników z kształtami.  
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby rezultat wyglądał tak, jakby został wykonany przez Microsoft PowerPoint.  
- Tworzenie aplikacji .NET lub Java w środowiskach desktopowych i webowych.