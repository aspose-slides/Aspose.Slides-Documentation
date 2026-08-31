---
title: Dlaczego nie Open XML SDK
type: docs
weight: 120
url: /pl/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porównywanie
- model obiektowy prezentacji
- konwersja wysokiej jakości
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji i szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, w jakich sytuacjach deweloperzy mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich elementami XML, natomiast Aspose.Slides prezentowane jest jako biblioteka przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPointem.

Artykuł porównuje oba rozwiązania pod kątem obsługiwanych formatów, modelu programowania, renderowania, wsparcia platform oraz typowych przypadków użycia. Wyjaśnia także, że Open XML SDK może być odpowiedni do podstawowych operacji na PPTX lub bezpośredniego dostępu do elementów OOXML, podczas gdy Aspose.Slides jest bardziej odpowiedni do złożonych zadań, takich jak obsługa wielu formatów PowerPointa, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwertowanie prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**
Według [Biblioteka MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) Open XML SDK jest definiowane jako: 

Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML i elementami schematu Open XML wewnątrz pakietu. Open XML SDK 2.0 kapsułkuje wiele typowych zadań wykonywanych przez deweloperów na pakietach Open 

XML, dzięki czemu można wykonywać złożone operacje za pomocą kilku linijek kodu.

Dokumenty OOXML to w zasadzie spakowane pliki XML, a Open XML SDK to zbiór klas umożliwiających pracę z zawartością dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik, wyodrębniać XML, ładować go do drzewa DOM i operować bezpośrednio na elementach i atrybutach XML, Open XML SDK dostarcza klasy do wykonania tych operacji.

## **Czym jest Aspose.Slides?**
Aspose.Slides to biblioteka klas, która umożliwia aplikacji wykonywanie następujących zadań przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego **Presentation**.  
- Wysokiej jakości konwersje pomiędzy wszystkimi popularnymi obsługiwanymi formatami prezentacji PowerPoint, w tym konwersja do PDF, XPS i TIFF.  
- Generowanie miniatur slajdów w znanych formatach, takich jak PNG, JPEG i BMP, wraz z eksportem slajdu do SVG.  
- Tworzenie prezentacji od podstaw lub przez łączenie jednego lub wielu dokumentów.  
- Obsługa dodawania animacji, ramek Ole, tabel, tworzenia i zarządzania wykresami.  
- Rozbudowana kontrola nad formatowaniem tekstu na poziomach TextFrames, Paragraphs i Portions.  

Po więcej szczegółów na temat obsługiwanych funkcji, odwiedź [Funkcje Aspose.Slides](/slides/pl/java/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
{{% alert color="info" %}} 

Poniższa tabela porównuje funkcje Open XML SDK i Aspose.Slides.

{{% /alert %}} 

|**Funkcja lub Kategoria Funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|Nie|Tak|
|<p>Programowanie wysokiego poziomu przy użyciu modelu obiektowego dokumentu prezentacji (DOM):</p><p>- Znajdź i zamień tekst.</p><p>- Składanie slajdów w prezentacjach.</p>|Nie|Tak|
|Szczegółowe programowanie z modelem obiektowym dokumentu, dostęp do poszczególnych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Tak|Tak|
|Niskopoziomowy bezpośredni i pełny dostęp do podstawowych elementów XML i atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Tak|Nie|
|<p>Renderowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p>|Nie|Tak |
|Obsługiwane platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Wnioski**
{{% alert color="info" %}} 

Open XML SDK i Aspose.Slides nie konkurują ze sobą bezpośrednio, ponieważ adresują zupełnie inne potrzeby i grupy odbiorców. Open XML SDK to biblioteka klas zapewniająca silnie typowany sposób pracy z dokumentami OOXML. Aspose.Slides to bardzo użyteczna biblioteka przetwarzania prezentacji, oferująca szerokie wsparcie dla niemal wszystkich formatów plików Microsoft PowerPoint.

Jeśli potrzebujesz jedynie podstawowych operacji programistycznych na dokumencie PPTX, Open XML SDK może być odpowiednim wyborem. Dzięki Open XML SDK będziesz komfortowo wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów itp. Niektóre zadania można zrealizować przy użyciu Open XML SDK, ale nie da się ich wykonać przy pomocy Aspose.Slides. Na przykład, jeśli musisz bezpośrednio uzyskać dostęp do elementów XML i atrybutów dokumentu OOXML, powinieneś użyć Open XML SDK. Jednak w przypadku bardziej złożonych operacji na dokumentach, takich jak poniższe, Aspose.Slides jest najlepszym rozwiązaniem:

- Obsługa starszych formatów PowerPoint oprócz PPTX.  
- Kopiowanie lub klonowanie kształtów na slajdach w sposób łączący obiekty, style i inne formatowanie w odpowiedni sposób.  
- Zamiana sformatowanego lub niesformatowanego tekstu.  
- Stosowanie animacji i użycie łączników z kształtami.  
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby wyglądał dokładnie tak, jak po konwersji w Microsoft PowerPoint.  
- Tworzenie aplikacji .NET lub Java zarówno w środowiskach desktopowych, jak i webowych.  

{{% /alert %}}