---
title: Dlaczego nie Open XML SDK
type: docs
weight: 100
url: /pl/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porównanie
- model obiektu prezentacji
- wysokiej jakości konwersja
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji i szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich podstawowymi elementami XML, natomiast Aspose.Slides przedstawia jako bibliotekę przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPointem.

Artykuł porównuje obie opcje pod kątem obsługiwanych formatów, modelu programowania, renderowania, wsparcia platform oraz typowych scenariuszy użycia. Wyjaśnia także, że Open XML SDK może być odpowiedni do podstawowych operacji na PPTX lub bezpośredniego dostępu do elementów OOXML, podczas gdy Aspose.Slides jest bardziej odpowiedni do złożonych zadań prezentacji, takich jak praca z wieloma formatami PowerPoint, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwertowanie prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**

Czasami słyszymy pytanie: dlaczego powinniśmy używać produktów Aspose zamiast darmowego Open XML SDK? Odpowiedź jest prosta: funkcje i możliwości. Zgodnie z [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany jako: Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML i podstawowymi elementami schematu Open XML w pakiecie. Open XML SDK 2.0 encapsuluje wiele typowych zadań, które programiści wykonują na pakietach Open XML, tak aby można było wykonać złożone operacje przy użyciu zaledwie kilku wierszy kodu. Dokumenty OOXML są w zasadzie spakowanymi plikami XML, a Open XML SDK to zbiór klas umożliwiających pracę z zawartością dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik, aby wyodrębnić XML, ładować ten XML do drzewa DOM i pracować bezpośrednio z elementami i atrybutami XML, Open XML SDK udostępnia klasy realizujące te operacje.

## **Czym jest Aspose.Slides?**

Aspose.Slides to biblioteka klas, która pozwala Twojej aplikacji wykonywać następujące zadania przetwarzania prezentacji:

- Programowanie z modelem obiektowym **Presentation**.
- Wysokiej jakości konwersje pomiędzy wszystkimi popularnymi obsługiwanymi formatami prezentacji PowerPoint, w tym konwersja do PDF i XPS.
- Możliwość generowania miniatur slajdów w popularnych formatach, takich jak PNG, JPEG i BMP, wraz z eksportem slajdu do SVG.
- Możliwość tworzenia prezentacji od podstaw lub przez łączenie jednego lub wielu dokumentów.
- Obsługa dodawania animacji, ramek Ole, tabel, tworzenia i zarządzania wykresami.
- Dostępność rozbudowanej kontroli nad formatowaniem tekstu na poziomach TextFrames, Paragraphs i Portions.  
  Aby uzyskać więcej informacji o obsługiwanych funkcjach, odwiedź [Aspose.Slides Features](/slides/pl/cpp/product-overview/).

## **Porównanie Open XML SDK i Aspose.Slides**

|**Funkcja lub kategoria funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|No|Yes|
|<p>Programowanie wysokiego poziomu z modelem obiektowym dokumentu prezentacji (DOM):</p><p>- Znajdowanie i zamiana tekstu.</p><p>- Łączenie slajdów w prezentacjach.</p>|No|Yes|
|Programowanie szczegółowe z modelem obiektowym dokumentu, dostęp do pojedynczych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Yes|Yes|
|Niskopoziomowy bezpośredni i pełny dostęp do podstawowych elementów XML i atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Yes|No|
|<p>Renderowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p>|No|Yes|

## **Podsumowanie**

Open XML SDK i Aspose.Slides nie konkurują bezpośrednio, ponieważ zaspokajają zupełnie inne potrzeby i grupy odbiorców. Open XML SDK jest biblioteką klas zapewniającą silnie typowany sposób pracy z dokumentami OOXML. Aspose.Slides jest bardzo użyteczną biblioteką przetwarzania prezentacji, oferującą wsparcie dla prawie wszystkich formatów plików Microsoft PowerPoint. Jeśli potrzebujesz jedynie podstawowej operacji programistycznej na dokumencie PPTX, Open XML SDK może być odpowiednim wyborem. Dzięki Open XML SDK będziesz komfortowo wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów i podobne. Niektóre zadania można osiągnąć przy pomocy Open XML SDK, ale nie przy użyciu Aspose.Slides. Na przykład, jeśli musisz bezpośrednio uzyskać dostęp do elementów i atrybutów XML dokumentu OOXML, powinieneś użyć Open XML SDK. Jednak jeśli potrzebujesz wykonywać złożone operacje na dokumentach, takie jak wymienione poniżej, użycie Aspose.Slides jest najlepszą opcją:

- Wsparcie starszych formatów PowerPoint oprócz PPTX.
- Kopiowanie lub klonowanie kształtów w slajdach w sposób łączący obiekty, style i inne formatowanie w odpowiedni sposób.
- Zamiana sformatowanego lub niesformatowanego tekstu.
- Stosowanie animacji oraz użycie łączy pomiędzy kształtami.
- Konwersja dokumentu do PDF lub XPS tak, aby wyglądał dokładnie tak, jak Microsoft PowerPoint by go przekonwertował.
- Tworzenie aplikacji C++ zarówno w środowiskach desktopowych, jak i konsolowych.