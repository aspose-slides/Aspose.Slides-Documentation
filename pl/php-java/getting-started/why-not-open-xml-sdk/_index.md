---
title: Dlaczego nie Open XML SDK
type: docs
weight: 120
url: /pl/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porównywanie
- model obiektowy prezentacji
- konwersja wysokiej jakości
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji oraz szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich elementami XML, podczas gdy Aspose.Slides przedstawiono jako bibliotekę przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPointem.

Artykuł porównuje obie opcje pod kątem obsługiwanych formatów, modelu programowania, renderowania, wsparcia platform oraz typowych scenariuszy użycia. Wyjaśnia również, że Open XML SDK może być odpowiedni do podstawowych operacji PPTX lub bezpośredniego dostępu do elementów OOXML, natomiast Aspose.Slides jest bardziej właściwy do złożonych zadań, takich jak praca z wieloma formatami PowerPointa, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**
Zgodnie z [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany jako:

Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML i ich elementami schematu Open XML w obrębie pakietu. Open XML SDK 2.0 kapsułkuje wiele typowych zadań, które programiści wykonują na pakietach Open XML, tak aby można było przeprowadzać złożone operacje w kilku linijkach kodu.

Dokumenty OOXML to w zasadzie spakowane pliki XML, a Open XML SDK to zbiór klas, które umożliwiają pracę z zawartością dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik, wyodrębniać XML, ładować go do drzewa DOM i pracować bezpośrednio z elementami i atrybutami XML, Open XML SDK dostarcza klasy umożliwiające te operacje.

## **Czym jest Aspose.Slides?**
Aspose.Slides to biblioteka klas, która pozwala aplikacji wykonywać następujące zadania przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego **Presentation**.
- Wysokiej jakości konwersje pomiędzy wszystkimi popularnymi obsługiwanymi formatami prezentacji PowerPoint, w tym konwersja do PDF, XPS i TIFF.
- Generowanie miniatur slajdów w znanych formatach, takich jak PNG, JPEG i BMP oraz eksport slajdów do SVG.
- Tworzenie prezentacji od podstaw lub łączenie ich z jednego lub wielu dokumentów.
- Obsługa dodawania animacji, ramek Ole, tabel, tworzenia i zarządzania wykresami.
- Rozbudowana kontrola formatowania tekstu w poziomach TextFrames, Paragraphs i Portions.

W celu uzyskania szczegółowych informacji o obsługiwanych funkcjach, odwiedź [Aspose.Slides Features](/slides/pl/php-java/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
{{% alert color="info" %}} 

Poniższa tabela porównuje funkcje Open XML SDK i Aspose.Slides.

{{% /alert %}} 

|**Funkcja lub kategoria funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|Nie|Tak|
|<p>Programowanie wysokiego poziomu z modelem obiektowym dokumentu prezentacji (DOM):</p><p>- Znajdź i zamień tekst.</p><p>- Składanie slajdów w prezentacjach.</p>|Nie|Tak|
|Programowanie szczegółowe z modelem obiektowym dokumentu, dostęp do poszczególnych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Tak|Tak|
|Niskopoziomowy, bezpośredni i pełny dostęp do podstawowych elementów i atrybutów XML, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Tak|Nie|
|<p>Renderowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p>|Nie|Tak|
|Obsługiwane platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Wnioski**
{{% alert color="info" %}} 

Open XML SDK i Aspose.Slides nie konkurują bezpośrednio, ponieważ adresują zupełnie inne potrzeby i grupy odbiorców. Open XML SDK to biblioteka klas zapewniająca silnie typowany sposób pracy z dokumentami OOXML. Aspose.Slides to bardzo użyteczna biblioteka przetwarzania prezentacji, która oferuje doskonałe wsparcie dla prawie wszystkich formatów plików Microsoft PowerPoint.

Jeśli potrzebujesz jedynie podstawowych operacji programistycznych na dokumencie PPTX, Open XML SDK może być odpowiednim wyborem. Dzięki Open XML SDK będziesz swobodnie wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów i podobne. Niektóre zadania można zrealizować przy użyciu Open XML SDK, ale nie przy użyciu Aspose.Slides. Na przykład, jeśli musisz bezpośrednio uzyskać dostęp do elementów i atrybutów XML dokumentu OOXML, powinieneś użyć Open XML SDK. Natomiast jeśli potrzebujesz wykonywać złożone operacje na dokumentach, takie jak niektóre z poniższych zadań, Aspose.Slides jest najlepszą opcją:

- Obsługa starszych formatów PowerPoint oprócz PPTX.
- Kopiowanie lub klonowanie kształtów na slajdach w sposób łączący obiekty, style i inne formatowanie w odpowiedni sposób.
- Zamiana sformatowanego lub niesformatowanego tekstu.
- Stosowanie animacji i użycie łączników z kształtami.
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby wygląd był identyczny z konwersją wykonaną przez Microsoft PowerPoint.
- Tworzenie aplikacji .NET lub Java w środowiskach desktopowych i internetowych.

{{% /alert %}}