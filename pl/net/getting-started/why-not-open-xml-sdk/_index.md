---
title: Dlaczego nie Open XML SDK
type: docs
weight: 180
url: /pl/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- porównanie
- model obiektowy prezentacji
- wysokiej jakości konwersja
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zobacz, dlaczego Aspose.Slides jest lepszym wyborem niż darmowy Open XML SDK: porównaj funkcje, konwersję bez automatyzacji i szerokie wsparcie dla PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, kiedy programiści mogą wybrać Open XML SDK lub Aspose.Slides do pracy z dokumentami prezentacji. Opisuje Open XML SDK jako bibliotekę do manipulacji pakietami OOXML i ich podstawowymi elementami XML, podczas gdy Aspose.Slides przedstawiany jest jako biblioteka przetwarzania prezentacji z wysokopoziomowym modelem obiektowym i wsparciem dla wielu zadań związanych z PowerPointem.

Artykuł porównuje obie opcje pod kątem obsługiwanych formatów, modelu programowania, renderowania, wsparcia platform oraz typowych scenariuszy użycia. Wyjaśnia również, że Open XML SDK może być odpowiedni do podstawowych operacji na plikach PPTX lub bezpośredniego dostępu do elementów OOXML, podczas gdy Aspose.Slides jest bardziej odpowiedni do złożonych zadań prezentacji, takich jak praca z wieloma formatami PowerPoint, kopiowanie lub klonowanie kształtów, zastępowanie tekstu, dodawanie animacji oraz konwersja prezentacji do PDF, TIFF lub XPS.

## **Czym jest Open XML SDK?**
Czasami pojawia się pytanie: *Dlaczego mielibyśmy używać produktów Aspose zamiast darmowego Open XML SDK?*

Łatwo jest odpowiedzieć na to pytanie, odnosząc się do funkcji i możliwości.

Zgodnie z [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK jest definiowany w następujący sposób:

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Czym jest Aspose.Slides?**
Aspose.Slides to biblioteka klas, która umożliwia aplikacjom wykonywanie następujących zadań przetwarzania prezentacji:

- Programowanie przy użyciu modelu obiektowego prezentacji.
- Wysokiej jakości konwersje obejmujące wszystkie popularne obsługiwane formaty prezentacji PowerPoint, w tym konwersję do PDF, XPS i TIFF.
- Generowanie miniatur slajdów w znanych formatach, takich jak PNG, JPEG i BMP, oraz eksport slajdów do SVG.
- Tworzenie prezentacji od podstaw lub poprzez łączenie elementów z jednego lub wielu dokumentów.
- Dodawanie animacji, ramek OLE, tabel, tworzenie i zarządzanie wykresami.
- Rozbudowana kontrola i zarządzanie formatowaniem tekstu na poziomach TextFrames, Paragraphs i Portions.

  Aby uzyskać więcej szczegółów na temat dostępnych funkcji, zobacz stronę [Aspose.Slides Features](/slides/pl/net/product-overview/).

## **Porównanie Open XML SDK z Aspose.Slides**
Ta tabela porównuje możliwości i funkcje Open XML SDK z Aspose.Slides.

|**Funkcja lub kategoria funkcji**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Obsługiwane formaty prezentacji|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konwersja z PPT do PPTX|Nie|Tak|
|<p>Programowanie wysokiego poziomu przy użyciu modelu obiektowego dokumentu prezentacji (DOM): </p><p>- Znajdź i zamień teksty.</p><p>- Składaj slajdy w prezentacjach.</p>|Nie|Tak|
|Szczegółowe programowanie przy użyciu modelu obiektowego dokumentu; dostęp do poszczególnych elementów i formatowania, takich jak TextHolders, TextFrames, Paragraphs i Portions.|Tak|Tak|
|Bezpośredni i pełny dostęp niskiego poziomu do podstawowych elementów XML i atrybutów, takich jak identyfikatory relacji, identyfikatory list dokumentu OOXML.|Tak|Nie|
|<p>Renderowanie prezentacji:</p><p>- Renderowanie prezentacji do PDF, PDF Notes, XPS, obrazów TIFF.</p><p>- Renderowanie miniatur slajdów do PNG, JPEG, BMP, SVG i TIFF.</p><p>- Określanie rozdzielczości obrazu, jakości, kompresji i innych opcji.</p>|Nie|Tak|
|Obsługiwane platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Wniosek**
Open XML SDK i Aspose.Slides nie konkurują bezpośrednio, ponieważ adresują zupełnie różne potrzeby i kierowane są do różnych odbiorców.

{{% alert color="info" title="Note" %}}

Open XML SDK to biblioteka klas zapewniająca typowo silne podejście do pracy z dokumentami OOXML, podczas gdy Aspose.Slides to niezwykle przydatna biblioteka przetwarzania prezentacji, oferująca szerokie wsparcie dla praktycznie wszystkich formatów plików Microsoft PowerPoint.

{{% /alert %}}

Jeśli Twój przepływ pracy to podstawowa operacja programistyczna na dokumencie PPTX, Open XML SDK może być dobrym wyborem. Dzięki Open XML SDK powinieneś swobodnie wykonywać proste zadania, takie jak generowanie prostego dokumentu PPTX, usuwanie komentarzy, nagłówków/stopki, wyodrębnianie obrazów i podobne. Niektóre zadania można wykonać przy użyciu Open XML SDK, ale nie przy użyciu Aspose.Slides. Na przykład, jeśli musisz bezpośrednio uzyskać dostęp do elementów XML i atrybutów dokumentu OOXML, powinieneś użyć Open XML SDK.

Jeśli potrzebujesz wykonywać złożone zadania na dokumentach — takie jak poniższe — Aspose.Slides jest Twoją najlepszą opcją.

- Operacje obejmujące starsze formaty PowerPoint (oraz PPTX).
- Kopiowanie lub klonowanie kształtów na slajdach w sposób łączący obiekty, style i inne elementy formatowania w odpowiedni sposób.
- Zastępowanie sformatowanego lub niesformatowanego tekstu.
- Dodawanie animacji i używanie łączników z kształtami.
- Konwersja dokumentu do PDF, TIFF lub XPS tak, aby wyglądał jak po konwersji wykonanej przez Microsoft PowerPoint.
- Tworzenie aplikacji .NET lub Java w środowiskach desktopowych i webowych.