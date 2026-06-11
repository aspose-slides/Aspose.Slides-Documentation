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
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji oraz szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich elementami XML, natomiast Aspose.Slides przedstawiany jest jako biblioteka przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPointem.

Artykuł porównuje oba rozwiązania pod kątem obsługiwanych formatów, modelu programowania, możliwości renderowania i drukowania, wsparcia platform oraz typowych przypadków użycia. Wyjaśnia również, że Open XML SDK może być odpowiedni do podstawowych operacji na plikach PPTX lub bezpośredniego dostępu do elementów OOXML, podczas gdy Aspose.Slides jest lepszy przy złożonych zadaniach, takich jak obsługa wielu formatów PowerPoint, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Co to jest Open XML SDK?**
Zgodnie z [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany jako:

Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML i podstawowymi elementami schematu Open XML wewnątrz pakietu. Open XML SDK 2.0 kapsułkuje wiele typowych zadań, które programiści wykonują na pakietach Open XML, tak aby można było wykonać złożone operacje przy użyciu kilku linii kodu.

Dokumenty OOXML są w zasadzie spakowanymi plikami XML, a Open XML SDK jest zbiorem klas, które pozwalają pracować z zawartością dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik w celu wyodrębnienia XML, wczytywać ten XML do drzewa DOM i pracować bezpośrednio z elementami i atrybutami XML, Open XML SDK dostarcza klasy umożliwiające te operacje.

## **Co to jest Aspose.Slides?**
Aspose.Slides to biblioteka klas, która umożliwia aplikacji wykonywanie następujących zadań przetwarzania prezentacji:

- Programowanie z modelem obiektowym **Presentation**.
- Wysokiej jakości konwersje między wszystkimi popularnymi obsługiwanymi formatami prezentacji PowerPoint, w tym konwersja do PDF, XPS i TIFF.
- Możliwość generowania miniatur slajdów w dobrze znanych formatach, takich jak PNG, JPEG i BMP, oraz eksportu slajdu do SVG.
- Możliwość budowania prezentacji od podstaw lub poprzez łączenie jednego lub wielu dokumentów.
- Obsługa dodawania animacji, ramek Ole, tabel, tworzenia i zarządzania wykresami.
- Rozbudowana kontrola nad formatowaniem tekstu w elementach TextFrames, akapitach i fragmentach.

Aby uzyskać więcej informacji o obsługiwanych funkcjach, odwiedź [Aspose.Slides Features](/slides/pl/java/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
{{% alert color="primary" %}} 

Poniższa tabela porównuje funkcje Open XML SDK i Aspose.Slides.

{{% /alert %}} 

|**Funkcja lub kategoria funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|Nie|Tak|
|<p>Programowanie wysokiego poziomu z modelem obiektowym dokumentu prezentacji (DOM):</p><p>- Znajdź i zamień tekst.</p><p>- Zbuduj slajdy w prezentacjach.</p>|Nie|Tak|
|Szczegółowe programowanie z modelem obiektowym dokumentu, dostęp do poszczególnych elementów i formatowanie, takie jak TextHolders, TextFrames, Paragraphs i Portions.|Tak|Tak|
|Niskopoziomowy, pełny dostęp do podstawowych elementów i atrybutów XML, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Tak|Nie|
|<p>Renderowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p>|Nie|Tak |
|Obsługiwane platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Wniosek**
{{% alert color="primary" %}} 

Open XML SDK i Aspose.Slides nie konkurują ze sobą bezpośrednio, ponieważ adresują zupełnie inne potrzeby i grupy odbiorców. Open XML SDK jest biblioteką klas zapewniającą silnie typowany sposób pracy z dokumentami OOXML. Aspose.Slides jest bardzo przydatną biblioteką przetwarzania prezentacji, oferującą znakomite wsparcie dla prawie wszystkich formatów plików Microsoft PowerPoint.

Jeśli potrzebujesz jedynie podstawowej operacji programistycznej na dokumencie PPTX, Open XML SDK może być odpowiednim wyborem. Dzięki Open XML SDK wygodnie wykonasz proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów i podobne. Niektóre zadania można zrealizować przy użyciu Open XML SDK, ale nie przy użyciu Aspose.Slides. Na przykład, jeśli musisz bezpośrednio uzyskać dostęp do elementów i atrybutów XML dokumentu OOXML, powinieneś użyć Open XML SDK. Jednakże, jeśli potrzebujesz wykonać złożone operacje na dokumentach, takie jak poniższe, Aspose.Slides jest najlepszym rozwiązaniem:

- Obsługa starszych formatów PowerPoint oprócz PPTX.
- Kopiowanie lub klonowanie kształtów na slajdach w sposób łączący obiekty, style i inne formatowanie w odpowiedni sposób.
- Zamiana sformatowanego lub niesformatowanego tekstu.
- Stosowanie animacji i używanie łączników z kształtami.
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby wygląd był identyczny z tym, jaki uzyskałby Microsoft PowerPoint.
- Tworzenie aplikacji .NET lub Java w środowiskach desktopowych i internetowych.

{{% /alert %}}