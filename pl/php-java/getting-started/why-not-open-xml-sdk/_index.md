---
title: Dlaczego nie Open XML SDK
type: docs
weight: 120
url: /pl/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porównywanie
- model obiektu prezentacji
- konwersja wysokiej jakości
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji oraz szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich elementami XML, podczas gdy Aspose.Slides przedstawiany jest jako biblioteka przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPointem.

Artykuł porównuje obie opcje pod względem obsługiwanych formatów, modelu programowania, możliwości renderowania i drukowania, wsparcia platform oraz typowych przypadków użycia. Wyjaśnia również, że Open XML SDK może być odpowiedni do podstawowych operacji na plikach PPTX lub bezpośredniego dostępu do elementów OOXML, natomiast Aspose.Slides jest bardziej właściwy do złożonych zadań, takich jak praca z wieloma formatami PowerPointa, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**
Według [Biblioteka MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany jako:

Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML i podstawowymi elementami schematu Open XML wewnątrz pakietu. Open XML SDK 2.0 kapsułkuje wiele typowych zadań, które programiści wykonują na pakietach Open XML, tak aby można było przeprowadzać skomplikowane operacje przy użyciu zaledwie kilku linii kodu.

Dokumenty OOXML są w zasadzie spakowanymi plikami XML, a Open XML SDK jest zestawem klas umożliwiających pracę z zawartością dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik w celu wyodrębnienia XML, ładować ten XML do drzewa DOM i pracować bezpośrednio z elementami i atrybutami XML, Open XML SDK dostarcza klasy, które to umożliwiają.

## **Czym jest Aspose.Slides?**
Aspose.Slides to biblioteka klas, która pozwala aplikacji wykonać następujące zadania przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego **Presentation**.
- Wysokiej jakości konwersje między wszystkimi popularnymi obsługiwanymi formatami prezentacji PowerPoint, w tym konwersja do PDF, XPS i TIFF.
- Możliwość generowania miniatur slajdów w znanych formatach, takich jak PNG, JPEG i BMP oraz eksportu slajdu do SVG.
- Możliwość tworzenia prezentacji od podstaw lub poprzez łączenie jednego lub wielu dokumentów.
- Obsługa dodawania animacji, ramek Ole, tabel, tworzenia i zarządzania wykresami.
- Rozbudowana kontrola nad formatowaniem tekstu w poziomach TextFrames, Paragraphs i Portions.

Aby uzyskać więcej informacji o obsługiwanych funkcjach, odwiedź [Funkcje Aspose.Slides](/slides/pl/php-java/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
{{% alert color="primary" %}} 

Poniższa tabela porównuje funkcje Open XML SDK i Aspose.Slides.

{{% /alert %}} 

|**Funkcja lub Kategoria Funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|Nie|Tak|
|<p>Programowanie wysokiego poziomu przy użyciu modelu obiektowego dokumentu prezentacji (DOM):</p><p>- Znajdź i zamień tekst.</p><p>- Zestaw slajdów w prezentacjach.</p>|Nie|Tak|
|Szczegółowe programowanie z modelem obiektowym dokumentu, dostęp do pojedynczych elementów i formatowania, takiego jak TextHolders, TextFrames, Paragraphs i Portions.|Tak|Tak|
|Niskopoziomowy bezpośredni i pełny dostęp do podstawowych elementów XML i atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Tak|Nie|
|<p>Renderowanie:</p><p>- Renderuj prezentacje do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderuj miniatury slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określ rozdzielczość obrazu, jakość, kompresję i inne opcje.</p>|Nie|Tak|
|Obsługiwane platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Wnioski**
{{% alert color="primary" %}} 

Open XML SDK i Aspose.Slides nie konkurują ze sobą bezpośrednio, ponieważ adresują zupełnie różne potrzeby i grupy odbiorców. Open XML SDK jest biblioteką klas zapewniającą silnie typowany sposób pracy z dokumentami OOXML. Aspose.Slides to bardzo przydatna biblioteka przetwarzania prezentacji, oferująca szerokie wsparcie dla prawie wszystkich formatów plików Microsoft PowerPoint.

Jeśli potrzebujesz jedynie dość podstawowej operacji programistycznej na dokumencie PPTX, Open XML SDK może być odpowiednim wyborem. Dzięki Open XML SDK bez problemu wykonasz proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów i podobne. Niektóre zadania można zrealizować przy użyciu Open XML SDK, ale nie przy użyciu Aspose.Slides. Przykładowo, jeśli musisz bezpośrednio uzyskać dostęp do elementów XML i atrybutów dokumentu OOXML, powinieneś użyć Open XML SDK. Jeżeli jednak potrzebujesz wykonać złożone operacje na dokumentach, takie jak:

- Obsługa starszych formatów PowerPoint oprócz PPTX.
- Kopiowanie lub klonowanie kształtów w slajdach w sposób łączący obiekty, style i inne formatowanie w odpowiedni sposób.
- Zamiana sformatowanego lub niesformatowanego tekstu.
- Stosowanie animacji i użycie łączników z kształtami.
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby wyglądał dokładnie tak, jak po konwersji w Microsoft PowerPoint.
- Tworzenie aplikacji .NET lub Java w środowiskach desktopowych i webowych.

to Aspose.Slides jest najlepszym rozwiązaniem.

{{% /alert %}}