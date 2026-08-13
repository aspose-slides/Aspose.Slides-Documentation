---
title: Dlaczego nie Open XML SDK
type: docs
weight: 120
url: /pl/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porównanie
- model obiektowy prezentacji
- wysokiej jakości konwersja
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji i szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich podstawowymi elementami XML, podczas gdy Aspose.Slides jest przedstawiany jako biblioteka przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPoint.

Artykuł porównuje obie opcje pod kątem obsługiwanych formatów, modelu programowania, możliwości renderowania i drukowania, wsparcia platform oraz typowych scenariuszy użycia. Wyjaśnia także, że Open XML SDK może być odpowiedni do podstawowych operacji na plikach PPTX lub bezpośredniego dostępu do elementów OOXML, natomiast Aspose.Slides jest bardziej właściwy dla złożonych zadań, takich jak obsługa wielu formatów PowerPoint, kopiowanie lub klonowanie kształtów, zamiana tekstu, stosowanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Co to jest Open XML SDK?**
Zgodnie z [Biblioteka MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany jako:

Open XML SDK 2.0 upraszcza zadanie manipulacji pakietami Open XML oraz podstawowymi elementami schematu Open XML w pakiecie. Open XML SDK 2.0 kapsułkuje wiele typowych zadań, które programiści wykonują na pakietach Open XML, tak aby można było przeprowadzić złożone operacje przy użyciu kilku linii kodu.

Dokumenty OOXML to zasadniczo spakowane pliki XML, a Open XML SDK jest zestawem klas, które umożliwiają pracę z zawartością dokumentów OOXML w sposób silnie typowany. Zamiast rozpakowywać plik w celu wyodrębnienia XML, ładować ten XML do drzewa DOM i pracować bezpośrednio z elementami i atrybutami XML, Open XML SDK dostarcza klasy do wykonania tych czynności.

## **Co to jest Aspose.Slides?**
Aspose.Slides jest biblioteką klas, która umożliwia aplikacji wykonywanie następujących zadań przetwarzania prezentacji:

- Programowanie z modelem obiektowym **Presentation**.
- Wysokiej jakości konwersje między wszystkimi popularnymi obsługiwanymi formatami prezentacji PowerPoint, w tym konwersję do PDF, XPS i TIFF.
- Możliwość generowania miniatur slajdów w znanych formatach, takich jak PNG, JPEG i BMP, wraz z eksportem slajdów do SVG.
- Możliwość budowania prezentacji od podstaw lub poprzez łączenie jednego bądź wielu dokumentów.
- Obsługa dodawania animacji, ramek Ole, tabel, tworzenia i zarządzania wykresami.
- Rozbudowana kontrola nad formatowaniem tekstu na poziomach TextFrames, Paragraphs i Portions.

Po więcej informacji o obsługiwanych funkcjach, odwiedź [Funkcje Aspose.Slides](/slides/pl/java/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
{{% alert color="info" %}} 

Poniższa tabela porównuje funkcje Open XML SDK i Aspose.Slides.

{{% /alert %}} 

|**Funkcja lub kategoria funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|Nie|Tak|
|<p>Programowanie na wysokim poziomie z modelem obiektowym dokumentu prezentacji (DOM):</p><p>- Znajdź i zamień tekst.</p><p>- Złóż slajdy w prezentacjach.</p>|Nie|Tak|
|Szczegółowe programowanie przy użyciu modelu obiektowego dokumentu, dostęp do poszczególnych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Tak|Tak|
|Niskopoziomowy bezpośredni i pełny dostęp do podstawowych elementów XML i atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Tak|Nie|
|<p>Renderowanie:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p>|Nie|Tak|
|Obsługiwane platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Wnioski**
{{% alert color="info" %}} 

Open XML SDK i Aspose.Slides nie konkurują bezpośrednio, ponieważ adresują zupełnie różne potrzeby i grupy odbiorców. Open XML SDK jest biblioteką klas zapewniającą silnie typowany sposób pracy z dokumentami OOXML. Aspose.Slides jest bardzo przydatną biblioteką przetwarzania prezentacji, która zapewnia doskonałe wsparcie dla prawie wszystkich formatów plików Microsoft PowerPoint.

Jeśli potrzebujesz jedynie stosunkowo prostej operacji programistycznej na dokumencie PPTX, Open XML SDK może być odpowiednim wyborem. Z Open XML SDK z łatwością wykonasz proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów i podobne. Niektóre zadania można zrealizować przy użyciu Open XML SDK, lecz nie da się ich wykonać przy pomocy Aspose.Slides. Na przykład, jeśli musisz bezpośrednio uzyskać dostęp do elementów XML i atrybutów dokumentu OOXML, powinieneś użyć Open XML SDK. Jednak jeśli potrzebujesz wykonywać złożone operacje na dokumentach, takie jak wymienione poniżej, Aspose.Slides jest najlepszą opcją:

- Obsługa starszych formatów PowerPoint oprócz PPTX.
- Kopiowanie lub klonowanie kształtów w slajdach w sposób łączący obiekty, style i inne formatowanie w odpowiedni sposób.
- Zamiana sformatowanego lub niesformatowanego tekstu.
- Stosowanie animacji i użycie łączników z kształtami.
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby wyglądał dokładnie tak, jak zrobiłby to Microsoft PowerPoint.
- Tworzenie aplikacji .NET lub Java w środowiskach desktopowych i webowych.

{{% /alert %}}