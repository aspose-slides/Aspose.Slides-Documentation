---
title: Różne formaty plików i konwersje
type: docs
weight: 50
url: /pl/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **O PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) jest formatem pliku prezentacji, który może być tworzony, odczytywany, modyfikowany i zapisywany przez różne wersje Microsoft PowerPoint. Jest to binarny format dokumentów prezentacji opracowany przez firmę Microsoft.
### **PPT w Aspose.Slides for C++**
Aspose.Slides for C++ może odczytywać pliki PPT utworzone przez poniższe oprogramowanie.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Podobnie, pliki PPT stworzone przez Aspose.Slides for C++ mogą być odczytywane przez wymienione powyżej programy.
### **Kompleksowe wsparcie dla PPT**
Aspose.Slides for C++ zapewnia wsparcie dla prawie wszystkich funkcji związanych z formatem pliku dokumentu PPT. Obejmuje nie tylko podstawowe i zaawansowane funkcje udostępniane przez różne wersje Microsoft PowerPoint do manipulacji dokumentami PPT, ale także niektóre funkcje, które nie są obsługiwane nawet przez Microsoft PowerPoint. Główną zaletą korzystania z biblioteki API Aspose.Slides for C++ jest łatwość obsługi takich funkcji.

Dodatkowo, oprócz podstawowych zadań związanych z tworzeniem, odczytywaniem i zapisywaniem plików dokumentów PPT, Aspose.Slides for C++ oferuje kilka funkcji, takich jak:
- Importowanie innych formatów plików MS Office jako obiekty OLE w dokumentach PPT.
- Eksportowanie dokumentów PPT do formatów PDF, TIFF, XPS.
- Eksportowanie slajdów w dokumentach PPT do formatu SVG.
- Renderowanie slajdu do dowolnego formatu obrazu obsługiwanego przez platformę C++.
- Ustawianie rozmiaru slajdów w dokumencie PPT.
- Zarządzanie animacjami kształtów.
- Zarządzanie pokazami slajdów.
- Formatowanie tekstu na slajdach.
- Skanowanie tekstu z dokumentów PPT.
- Obsługa tabel na slajdach.
- Automatyczne kopiowanie wzorców przy użyciu funkcji klonowania.

Plik PPT wygenerowany przez Aspose.Slides for C++ i otwarty w Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **O PresentationML**
PresentationML jest nazwą rodziny formatów opartych na XML dla dokumentów prezentacji. Office OpenXML (OOXML) to format oparty na XML wprowadzony w aplikacjach Microsoft Office 2007. Office OpenXML jest formatem kontenera dla kilku wyspecjalizowanych języków znaczników opartych na XML. PresentationML jest językiem znaczników używanym przez Microsoft Office PowerPoint 2007 do przechowywania dokumentów.
### **PresentationML w Aspose.Slides for C++**
Dokumenty OOXML PresentationML występują jako pliki PPTX, które są spakowanymi pakietami XML zgodnymi ze specyfikacją [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for C++ szeroko wspiera tworzenie, odczyt, modyfikację i zapisywanie dokumentów PresentationML. Dodatkowo, Aspose.Slides for C++ potrafi eksportować dokumenty PresentationML do różnych powszechnie używanych formatów, takich jak PDF, TIFF i XPS. Jest to możliwe, ponieważ Aspose.Slides for C++ został zaprojektowany z myślą o kompleksowej obsłudze dokumentów prezentacji, a PresentationML zasadniczo przechowuje wewnętrzną strukturę dokumentów jako spakowany pakiet XML.

Dokument PPTX wygenerowany przez Aspose.Slides for C++ i otwarty w Microsoft PowerPoint

Przeglądanie dokumentu PPTX wygenerowanego przez Aspose.Slides for C++ w aplikacji Zip
### **PresentationML jest otwarty, dlaczego używać Aspose.Slides for C++**
Ponieważ PresentationML opiera się na XML, możliwe jest tworzenie aplikacji przetwarzających i generujących dokumenty PresentationML przy użyciu klas XML bez polegania na bibliotekach klas firm trzecich, takich jak Aspose.Slides for C++. Jednak istnieje kilka zalet korzystania z Aspose.Slides for C++ w porównaniu z klasami XML podczas pracy z dokumentami PresentationML.

Specyfikacja OOXML jest bardzo obszerna i liczy kilka tysięcy stron. Oznacza to, że aby prawidłowo obsługiwać dokumenty PresentationML, trzeba poświęcić dużo czasu i wysiłku na zrozumienie formatu tych dokumentów. Z drugiej strony, używając Aspose.Slides for C++, wystarczy skorzystać z odpowiednich klas oraz ich metod / właściwości do wykonywania operacji, które wydają się dość skomplikowane przy użyciu klas XML.

Poniżej znajdują się niektóre funkcje, które są niedostępne przy pracy z dokumentami PresentationML za pomocą klas XML:
- Eksportowanie dokumentów PPT do formatów PDF, TIFF, XPS
- Eksportowanie slajdów w dokumentach PPT do formatu SVG
- Renderowanie slajdu do dowolnego formatu obrazu obsługiwanego przez platformę C++
- Automatyczne kopiowanie wzorców z prezentacji źródłowych przy użyciu funkcji klonowania.
- Zastosowanie ochrony na kształtach.

Rozważmy przykład dokumentu PresentationML zawierającego pojedynczy slajd z jednym polem tekstowym zawierającym tekst „Hello World”. Aby odczytać tekst przy użyciu klas XML, należy napisać program, który potrafi parsować ten prosty tekst z następującego fragmentu:

``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```
## **Konwersja PPT na PPTX**
### **O konwersji**
Aspose.Slides obecnie również obsługuje konwersję PPT do PPTX.
### **Funkcje obsługiwane w konwersji**
Aspose.Slides for C++ zapewnia częściowe wsparcie konwersji prezentacji w formacie pliku PPT do prezentacji w formacie PPTX. Ponieważ funkcja konwersji prezentacji została dopiero wprowadzona w Aspose.Slides for C++, na chwilę obecną ma ograniczone możliwości i działa jedynie dla prostych form prezentacji. Główną zaletą biblioteki API Aspose.Slides for C++ przy konwersji prezentacji PPT do formatu PPTX jest łatwość użycia API w osiąganiu zamierzonego celu. Proszę przejść do this[link]() w sekcji fragmentów kodu, aby uzyskać dalsze szczegóły. Poniższa sekcja jasno ilustruje, które funkcje są obsługiwane, a które nie, podczas konwersji prezentacji w formacie PPT do formatu PPTX.
### **Obsługiwane funkcje**
Poniższe funkcje są obsługiwane podczas konwersji:
- Konwersja struktury wzorców, układów i slajdów
- Konwersja struktury wzorców, układów i slajdów
- Konwersja wykresów
- Grupowanie kształtów
- Konwersja Auto‑kształtów, w tym prostokątów i elips. Jednak możliwe, że Auto‑kształty mogą mieć nieprawidłowe wartości dopasowań.
- Kształty o niestandardowej geometrii. Czasami mogą nie zostać przekonwertowane.
- Tekstury i styl wypełnienia obrazami dla Auto‑kształtów. Czasami mogą nie zostać przekonwertowane.
- Konwersja pól zastępczych
- Konwersja tekstu w ramkach tekstowych i pojemnikach na tekst. Jednak wypunktowanie, wyrównanie i tabulacje nie są w pełni zaimplementowane.
### **Niewspierane funkcje**
Poniższe funkcje nie są obsługiwane podczas konwersji:
- Slajd z notatkami, ponieważ odczytywanie notatek nie jest zaimplementowane w PPTX. Jeśli PPT je posiada, nie może być jeszcze zapisany jako PPTX*
- Konwersja linii i polilinii
- Formaty linii i wypełnienia
- Style wypełnienia gradientowego
- Ramki OLE, tabele, ramki wideo i audio itp.
- Animacje i inne właściwości pokazu slajdów są pomijane
Nowe lub brakujące funkcje będą dodawane w kolejnych wersjach Aspose.Slides for C++.

Źródłowa prezentacja PPT

Przekonwertowana prezentacja PPTX
## **Portable Document Format (PDF)**
### **O PDF**
[Portable Document Format](https://en.wikipedia.org/wiki/PDF) jest formatem pliku utworzonym przez Adobe System do wymiany dokumentów pomiędzy różnymi organizacjami. Celem tego formatu było umożliwienie przedstawienia zawartości dokumentów w sposób, w którym ich wygląd wizualny nie zależy od platformy, na której są wyświetlane.
### **PDF w Aspose.Slides for C++**
Każdy dokument prezentacji, który może zostać załadowany do Aspose.Slides for C++, może zostać skonwertowany do dokumentu PDF, który może spełniać specyfikację [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) lub [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) w zależności od wyboru. Aspose.Slides for C++ eksportuje dokumenty prezentacji do PDF w taki sposób, że w większości przypadków wyeksportowany dokument PDF wygląda prawie identycznie jak oryginalny dokument prezentacji. Rozwiązanie Aspose obsługuje następujące funkcje dokumentów prezentacji podczas konwersji do dokumentów PDF:
- Obrazy, pola tekstowe i inne kształty
- Tekst i formatowanie
- Akapity i formatowanie
- Hiperdłącza
- Nagłówki i stopki
- Wypunktowanie
- Tabele
Możesz wyeksportować dokumenty prezentacji do dokumentów PDF bezpośrednio, używając wyłącznie komponentu Aspose.Slides for C++. Oznacza to, że nie potrzebujesz żadnych dodatkowych bibliotek firm trzecich ani komponentu Aspose.Pdf w tym celu. Ponadto możesz dostosować eksport prezentacji do PDF, używając różnych opcji, jak opisano w [this topic](/slides/pl/cpp/convert-powerpoint-to-pdf/).

Dokument prezentacji skonwertowany do dokumentu PDF przy użyciu Aspose.Slides for C++
## **XML Parser Specification (XPS)**
### **O XPS**
[XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) jest językiem opisu stron i formatem dokumentu o stałym układzie, pierwotnie opracowanym przez Microsoft. Podobnie jak PDF, XPS jest formatem dokumentu o stałym układzie zaprojektowanym w celu zachowania wierności dokumentu i zapewnienia urządzeniowo niezależnego wyglądu.
### **XPS w Aspose.Slides for C++**
Każdy dokument prezentacji, który może zostać załadowany przez Aspose.Slides for C++, może być skonwertowany do formatu XPS. Aspose.Slides for C++ używa wysokiej jakości silnika układu i renderowania stron, aby wygenerować wynik w formacie dokumentu XPS o stałym układzie. Warto zauważyć, że Aspose.Slides for C++ generuje XPS bez zależności od klas Windows Presentation Foundation (WPF) pakowanych z platformą C++ Framework 3.5, co umożliwia Aspose.Slides for C++ tworzenie dokumentów XPS na maszynach z wersjami C++ Framework starszymi niż 3.5. Możesz dowiedzieć się o eksportowaniu dokumentów prezentacji do dokumentów XPS za pośrednictwem Aspose.Slides for C++ w [this topic](https://docs.aspose.com/slides/pl/cpp/convert-powerpoint-to-xps/).

Dokument prezentacji skonwertowany do dokumentu XPS przy użyciu Aspose.Slides for C++