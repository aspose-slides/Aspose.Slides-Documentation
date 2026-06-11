---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /pl/cpp/presentationml-pptx-xml/
---
## **O PresentationML**
PresentationML jest nazwą rodziny formatów opartych na XML dla dokumentów prezentacji. Office OpenXML (OOXML) jest formatem opartym na XML wprowadzonym w aplikacjach Microsoft Office 2007. Office OpenXML jest formatem kontenera dla kilku wyspecjalizowanych języków znaczników opartych na XML. PresentationML jest językiem znaczników używanym przez Microsoft Office PowerPoint 2007 do przechowywania jego dokumentów. 

## **PresentationML w Aspose.Slides dla C++**
Dokumenty OOXML PresentationML występują jako pliki PPTX, które są spakowanymi pakietami XML zgodnymi ze specyfikacjami [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides dla C++ szeroko wspiera tworzenie, odczyt, manipulację i zapisywanie dokumentów PresentationML. Ponadto Aspose.Slides dla C++ umożliwia eksportowanie dokumentów PresentationML do różnych powszechnie używanych formatów dokumentów, takich jak PDF, TIFF i XPS. Jest to możliwe, ponieważ Aspose.Slides dla C++ został zaprojektowany z myślą o kompleksowej obsłudze dokumentów prezentacji, a PresentationML zasadniczo przechowuje wewnętrzną prezentację dokumentów jako spakowany pakiet XML. 

## **PresentationML jest otwarty, dlaczego używać Aspose.Slides dla C++**
Ponieważ PresentationML jest oparty na XML, możliwe jest budowanie aplikacji do przetwarzania i generowania dokumentów PresentationML przy użyciu klas XML bez polegania na bibliotekach klas innych firm, takich jak Aspose.Slides dla C++. Jednak istnieje kilka zalet korzystania z Aspose.Slides dla C++ w porównaniu z klasami XML podczas pracy z dokumentami PresentationML. 

Specyfikacja OOXML ma kilka tysięcy stron. Oznacza to, że aby prawidłowo obsługiwać dokumenty PresentationML, trzeba poświęcić dużo czasu i wysiłku na zrozumienie formatu takich dokumentów. Z drugiej strony, używając Aspose.Slides dla C++, wystarczy używać odpowiednich klas i ich metod / właściwości do wykonywania operacji, które wydają się dość skomplikowane przy użyciu klas XML. 

Poniżej znajdują się niektóre funkcje, które są nawet niedostępne podczas pracy z dokumentami PresentationML za pomocą klas XML: 

- Eksportowanie dokumentów PPT do formatów PDF, TIFF, XPS
- Eksportowanie slajdów w dokumentach PPT do formatów SVG
- Renderowanie slajdu do dowolnego formatu obrazu obsługiwanego przez framework C++
- Automatyczne kopiowanie szablonów z prezentacji źródłowych przy użyciu funkcji klonowania
- Zastosowanie ochrony na kształtach

Weźmy przykład dokumentu PresentationML zawierającego pojedynczy slajd z jedną ramką tekstową zawierającą tekst “Hello World”. Aby odczytać tekst przy użyciu klas XML, trzeba napisać program, który potrafi sparsować ten prosty tekst z następującego fragmentu: 
## **Przykład**


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