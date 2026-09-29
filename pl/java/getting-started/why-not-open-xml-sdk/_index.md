---
title: Dlaczego nie Open XML SDK
type: docs
weight: 180
url: /pl/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porównanie
- model obiektowy prezentacji
- konwersja wysokiej jakości
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji oraz szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich elementami XML, podczas gdy Aspose.Slides jest przedstawiony jako biblioteka przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i obsługą wielu zadań związanych z PowerPoint.

Artykuł porównuje obie opcje pod kątem obsługiwanych formatów, modelu programowania, renderowania, wsparcia platform oraz typowych przypadków użycia. Wyjaśnia również, że Open XML SDK może być odpowiedni do podstawowych operacji na PPTX lub bezpośredniego dostępu do elementów OOXML, podczas gdy Aspose.Slides jest bardziej odpowiedni dla złożonych zadań prezentacji, takich jak praca z wieloma formatami PowerPoint, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwertowanie prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**

Zgodnie z [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany jako:

Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML oraz leżącymi w nich elementami schematu Open XML. Open XML SDK 2.0 kapsułkuje wiele typowych zadań, które programiści wykonują na pakietach Open XML, dzięki czemu możesz wykonywać złożone operacje przy użyciu kilku linijek kodu.

Dokumenty OOXML to w zasadzie skompresowane pliki XML, a Open XML SDK jest zestawem klas, które umożliwiają pracę z zawartością dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik, wyodrębniać XML, ładować go do drzewa DOM i pracować bezpośrednio z elementami i atrybutami XML, Open XML SDK udostępnia klasy do tego.

## **Czym jest Aspose.Slides?**

Aspose.Slides jest biblioteką klas, która pozwala twojej aplikacji wykonywać następujące zadania przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego **Presentation**.
- Konwersje wysokiej jakości pomiędzy wszystkimi popularnymi obsługiwanymi formatami prezentacji PowerPoint, w tym konwersja do PDF, XPS i TIFF.
- Możliwość generowania miniatur slajdów w znanych formatach, takich jak PNG, JPEG i BMP, oraz eksportu slajdów do SVG.
- Możliwość tworzenia prezentacji od podstaw lub poprzez łączenie jednego lub wielu dokumentów.
- Wsparcie dla dodawania animacji, ramek Ole, tabel, tworzenia i zarządzania wykresami.
- Dostępność rozbudowanej kontroli nad formatowaniem tekstu na poziomach TextFrames, Paragraphs i Portions.

Aby uzyskać więcej szczegółów na temat obsługiwanych funkcji, odwiedź [Funkcje Aspose.Slides](/slides/pl/java/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
{{% alert color="info" title="Note" %}}
Poniższa tabela porównuje funkcje Open XML SDK i Aspose.Slides.
{{% /alert %}}

|**Funkcja lub Kategoria Funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|No|Yes|
|<p>Programowanie wysokopoziomowe przy użyciu modelu obiektowego dokumentu prezentacji (DOM):</p><p>- Znajdź i zamień tekst.</p><p>- Zbuduj slajdy w prezentacjach.</p>|No|Yes|
|Szczegółowe programowanie przy użyciu modelu obiektowego dokumentu, dostęp do poszczególnych elementów i formatowania, takiego jak TextHolders, TextFrames, Paragraphs i Portions.|Yes|Yes|
|Niskopoziomowy bezpośredni i pełny dostęp do leżących pod spodem elementów XML oraz atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Yes|No|
|<p>Renderowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p>|No|Yes|
|Obsługiwane platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Wniosek**
{{% alert color="info" title="Note" %}}
Open XML SDK i Aspose.Slides nie konkurują ze sobą bezpośrednio, ponieważ odpowiadają na zupełnie różne potrzeby i grupy odbiorców. Open XML SDK jest biblioteką klas zapewniającą silnie typowy sposób pracy z dokumentami OOXML. Aspose.Slides jest bardzo przydatną biblioteką przetwarzania prezentacji, która zapewnia doskonałe wsparcie dla niemal wszystkich formatów plików Microsoft PowerPoint.

Jeśli potrzebujesz jedynie dość podstawowej operacji programistycznej na dokumencie PPTX, wtedy Open XML SDK może być odpowiednim wyborem. Korzystając z Open XML SDK będziesz komfortowo wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów i inne. Niektóre zadania można zrealizować przy użyciu Open XML SDK, ale nie są one możliwe w Aspose.Slides. Na przykład, jeśli potrzebujesz bezpośredniego dostępu do elementów i atrybutów XML dokumentu OOXML, powinieneś użyć Open XML SDK. Jednakże, jeśli musisz wykonać złożone operacje na dokumentach, takie jak niektóre z poniższych zadań, użycie Aspose.Slides jest najlepszą opcją:

- Obsługa starszych formatów PowerPoint oprócz PPTX.
- Kopiowanie lub klonowanie kształtów na slajdach w sposób łączący obiekty, style i inne formatowanie w odpowiedni sposób.
- Zastępowanie sformatowanego lub niesformatowanego tekstu.
- Stosowanie animacji i użycie łączników z kształtami.
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby wyglądał dokładnie tak, jak konwertowałby go Microsoft PowerPoint.
- Tworzenie aplikacji .NET lub Java zarówno w środowiskach desktopowych, jak i webowych.
{{% /alert %}}