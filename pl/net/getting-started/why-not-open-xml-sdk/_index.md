---
title: Dlaczego nie Open XML SDK
type: docs
weight: 50
url: /pl/net/why-not-open-xml-sdk/
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
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji oraz szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich podstawowymi elementami XML, podczas gdy Aspose.Slides jest przedstawiony jako biblioteka przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPointem.

Artykuł porównuje obie opcje pod kątem obsługiwanych formatów, modelu programowania, możliwości renderowania i drukowania, wsparcia platform oraz typowych scenariuszy użycia. Wyjaśnia również, że Open XML SDK może być odpowiedni do podstawowych operacji na PPTX lub bezpośredniego dostępu do elementów OOXML, podczas gdy Aspose.Slides jest lepszy do złożonych zadań prezentacji, takich jak praca z wieloma formatami PowerPoint, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Co to jest Open XML SDK?**
Czasami dostajemy to pytanie: *Dlaczego powinniśmy używać produktów Aspose zamiast darmowego Open XML SDK?*

Łatwo jest nam odpowiedzieć na to pytanie w kontekście funkcji i możliwości.

Zgodnie z [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany w następujący sposób:

> "Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML oraz podstawowymi elementami schematu Open XML w obrębie pakietu. Open XML SDK 2.0 kapsułkuje wiele typowych zadań, które programiści wykonują na pakietach Open XML, dzięki czemu możesz przeprowadzać złożone operacje przy użyciu kilku linii kodu. Dokumenty OOXML to w zasadzie spakowane pliki XML, a Open XML SDK jest zestawem klas, które umożliwiają pracę z zawartością dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik, aby wyodrębnić XML, ładować ten XML do drzewa DOM i bezpośrednio pracować z elementami i atrybutami XML, Open XML SDK dostarcza klasy umożliwiające to."

## **Co to jest Aspose.Slides?**
Aspose.Slides jest biblioteką klas, która pozwala aplikacjom na wykonanie następujących zadań przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego prezentacji.
- Konwersje wysokiej jakości obejmujące wszystkie popularne obsługiwane formaty prezentacji PowerPoint, w tym konwersję do PDF, XPS, TIFF oraz drukowanie.
- Generowanie miniaturek slajdów w popularnych formatach, takich jak PNG, JPEG i BMP, wraz z eksportem slajdów do SVG.
- Tworzenie prezentacji od podstaw lub poprzez łączenie elementów z jednego lub wielu dokumentów.
- Dodawanie animacji, ramek OLE, tabel, tworzenie i zarządzanie wykresami.
- Kontrolowanie (rozbudowana kontrola) i zarządzanie formatowaniem tekstu na poziomach TextFrames, Paragraphs i Portions.

Aby uzyskać więcej szczegółów na temat dostępnych funkcji, zobacz stronę [Aspose.Slides Features](/slides/pl/net/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
This table compares Open XML SDK capabilities and features with Aspose.Slides.

|**Funkcja lub kategoria funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|No|Yes|
|<p>Programowanie na wysokim poziomie z użyciem Presentation Document Object Model (DOM): </p><p>- Znajdowanie i zamiana tekstów.</p><p>- Składanie slajdów w prezentacjach.</p>|No|Yes|
|Szczegółowe programowanie przy użyciu modelu obiektowego dokumentu; dostęp do pojedynczych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Yes|Yes|
|Niskopoziomowy bezpośredni i pełny dostęp do podstawowych elementów XML oraz atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Yes|No|
|<p>Renderowanie i drukowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniaturek slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p><p>- Drukowanie prezentacji przy użyciu infrastruktury drukowania .NET. Komponent posiada wbudowaną metodę drukowania, aby wydrukować prezentacje tak, jak pokazuje podgląd wydruku w MS PowerPoint.</p>|No|Yes|
|Obsługiwane platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Wnioski**
Open XML SDK i Aspose.Slides nie konkurują ze sobą bezpośrednio, ponieważ spełniają zupełnie inne potrzeby i są skierowane do różnych odbiorców.

{{% alert color="primary" %}} 
Open XML SDK jest biblioteką klas, która zapewnia silnie typowany sposób pracy z dokumentami OOXML, natomiast Aspose.Slides jest niezwykle użyteczną biblioteką przetwarzania prezentacji, oferującą doskonałe wsparcie dla prawie wszystkich formatów plików Microsoft PowerPoint. 
{{% /alert %}} 

Jeśli Twój przepływ pracy obejmuje podstawowe operacje programistyczne na dokumencie PPTX, Open XML SDK może być dobrym wyborem. Korzystając z Open XML SDK, powinieneś swobodnie wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów lub inne. Niektóre zadania można wykonać przy użyciu Open XML SDK, ale nie da się ich wykonać przy użyciu Aspose.Slides. Na przykład, jeśli musisz mieć bezpośredni dostęp do elementów XML i atrybutów dokumentu OOXML, powinieneś użyć Open XML SDK.

Jeśli musisz wykonać złożone zadania na dokumentach — takie jak zadania z poniższej listy — wtedy Aspose.Slides jest najlepszą opcją.

- Operacje obejmujące starsze formaty PowerPoint (oraz PPTX).
- Kopiowanie lub klonowanie kształtów w ramach slajdów w sposób łączący obiekty, style i inne elementy formatowania w odpowiedni sposób.
- Zamiana sformatowanego lub niesformatowanego tekstu.
- Stosowanie animacji oraz używanie łączników z kształtami.
- Konwersja dokumentu do PDF, TIFF lub XPS, aby wyglądał tak, jakby konwersję wykonał Microsoft PowerPoint.
- Tworzenie aplikacji .NET lub Java zarówno w środowiskach desktopowych, jak i webowych.