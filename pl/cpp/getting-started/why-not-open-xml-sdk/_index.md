---
title: Dlaczego nie Open XML SDK
type: docs
weight: 100
url: /pl/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porównanie
- model obiektu prezentacji
- konwersja wysokiej jakości
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji oraz szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich podstawowymi elementami XML, podczas gdy Aspose.Slides przedstawiono jako bibliotekę przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i obsługą wielu zadań związanych z PowerPointem.

Artykuł porównuje obie opcje pod kątem obsługiwanych formatów, modelu programowania, możliwości renderowania i drukowania, wsparcia platform oraz typowych scenariuszy użycia. Wyjaśnia również, że Open XML SDK może być odpowiedni do podstawowych operacji na PPTX lub bezpośredniego dostępu do elementów OOXML, natomiast Aspose.Slides jest lepszy dla złożonych zadań prezentacji, takich jak praca z wieloma formatami PowerPoint, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**
Czasami słyszymy to pytanie: Dlaczego powinniśmy używać produktów Aspose zamiast darmowego Open XML SDK? Odpowiedź jest prosta: funkcje i możliwości. Zgodnie z[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany jako: Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML oraz podstawowymi elementami schematu Open XML w obrębie pakietu. Open XML SDK 2.0 kapsułkuje wiele typowych zadań, które programiści wykonują na pakietach Open XML, umożliwiając przeprowadzanie złożonych operacji przy użyciu kilku linii kodu. Dokumenty OOXML to zasadniczo spakowane pliki XML, a Open XML SDK jest zestawem klas, które pozwalają pracować z treścią dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik w celu wyodrębnienia XML, wczytywać ten XML do drzewa DOM i działać bezpośrednio na elementach i atrybutach XML, Open XML SDK zapewnia klasy do tego.

## **Czym jest Aspose.Slides?**
Aspose.Slides jest biblioteką klas, która pozwala Twojej aplikacji wykonywać następujące zadania przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego **Presentation**.
- Wysokiej jakości konwersje pomiędzy wszystkimi popularnymi obsługiwanymi formatami prezentacji PowerPoint, w tym konwersja do PDF i XPS.
- Możliwość generowania miniatur slajdów w znanych formatach, takich jak PNG, JPEG i BMP, wraz z eksportem slajdu do SVG.
- Możliwość tworzenia prezentacji od podstaw lub poprzez łączenie jednego lub wielu dokumentów.
- Obsługa dodawania animacji, ramek Ole, tabel, tworzenia i zarządzania wykresami.
- Dostęp do rozbudowanej kontroli formatowania tekstu na poziomach TextFrames, Paragraphs i Portions.  
Aby uzyskać więcej szczegółów na temat obsługiwanych funkcji, odwiedź [Aspose.Slides Features](/slides/pl/cpp/product-overview/).

## **Porównanie Open XML SDK i Aspose.Slides**
The following table compares Open XML SDK and Aspose.Slides features.

|**Funkcja lub Kategoria Funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|No|Yes|
|<p>Programowanie wysokiego poziomu przy użyciu modelu obiektowego dokumentu prezentacji (DOM):</p><p>- Znajdź i zamień tekst.</p><p>- Składanie slajdów w prezentacjach.</p>|No|Yes|
|Szczegółowe programowanie przy użyciu modelu obiektowego dokumentu, dostęp do poszczególnych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Yes|Yes|
|Niskopoziomowy, bezpośredni i pełny dostęp do podstawowych elementów XML i atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Yes|No|
|<p>Renderowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p>|No|Yes|

## **Wnioski**
Open XML SDK i Aspose.Slides nie rywalizują ze sobą bezpośrednio, ponieważ zaspokajają zupełnie różne potrzeby i grupy odbiorców. Open XML SDK jest biblioteką klas zapewniającą silnie typowany sposób pracy z dokumentami OOXML. Aspose.Slides jest bardzo przydatną biblioteką przetwarzania prezentacji, która oferuje doskonałe wsparcie dla prawie wszystkich formatów plików Microsoft PowerPoint. Jeśli potrzebujesz jedynie dość podstawowej operacji programistycznej na dokumencie PPTX, Open XML SDK może być odpowiednim wyborem. Korzystając z Open XML SDK, będziesz swobodnie wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów czy inne. Niektóre zadania można wykonać przy pomocy Open XML SDK, ale nie przy użyciu Aspose.Slides. Na przykład, jeśli musisz bezpośrednio uzyskać dostęp do elementów i atrybutów XML dokumentu OOXML, powinieneś użyć Open XML SDK. Jednakże, jeśli musisz wykonać złożone operacje na dokumentach, takie jak niektóre z poniższych zadań, użycie Aspose.Slides będzie najlepszą opcją:

- Obsługa starszych formatów PowerPoint oprócz PPTX.
- Kopiowanie lub klonowanie kształtów w slajdach w sposób łączący obiekty, style i inne formatowanie w odpowiedni sposób.
- Zamiana sformatowanego lub niesformatowanego tekstu.
- Stosowanie animacji i użycie łączników z kształtami.
- Konwersja dokumentu do PDF lub XPS, aby wyglądał dokładnie tak, jak przetworzyłby go Microsoft PowerPoint.
- Tworzenie aplikacji C++ zarówno w środowiskach desktopowych, jak i konsolowych.