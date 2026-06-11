---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /pl/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML jest nazwą rodziny formatów opartych na XML przeznaczonych do dokumentów prezentacji. Office OpenXML (OOXML) to format oparty na XML wprowadzony w aplikacjach Microsoft Office 2007. Office OpenXML jest formatem kontenera dla kilku wyspecjalizowanych języków znaczników opartych na XML. PresentationML jest językiem znaczników używanym przez Microsoft Office PowerPoint 2007 do przechowywania dokumentów.

{{% /alert %}} 

## **PresentationML w Aspose.Slides for Java**
Dokumenty OOXML PresentationML występują jako pliki PPTX, spakowane pakiety XML, które spełniają specyfikację [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java w pełni wspiera tworzenie, odczyt, modyfikowanie i zapisywanie dokumentów PresentationML. Dodatkowo Aspose.Slides for Java potrafi eksportować dokumenty PresentationML do powszechnie używanego formatu, takiego jak PDF. Jest to możliwe, ponieważ Aspose.Slides for Java został zaprojektowany z myślą o kompleksowym obsługiwaniu dokumentów prezentacji, a PresentationML zasadniczo przechowuje wewnętrzną reprezentację dokumentów w postaci spakowanego pakietu XML.

**Dokument PPTX wygenerowany przez Aspose.Slides for Java i otwarty w Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Podgląd tego samego dokumentu PPTX wygenerowanego przez Aspose.Slides for Java w archiwum ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML jest otwarty, dlaczego warto używać Aspose.Slides for Java?**
Ponieważ PresentationML opiera się na XML, możliwe jest stworzenie aplikacji przetwarzających i generujących dokumenty PresentationML przy użyciu klas XML, bez korzystania z zewnętrznej biblioteki klas, takiej jak Aspose.Slides for Java. Jednak istnieje kilka zalet używania Aspose.Slides for Java w porównaniu z klasami XML przy pracy z dokumentami PresentationML.

Specyfikacja OOXML liczy kilka tysięcy stron, więc aby prawidłowo obsługiwać dokumenty PresentationML, trzeba poświęcić dużo czasu i wysiłku na zrozumienie formatu. Z drugiej strony, korzystając z Aspose.Slides for Java, po prostu używasz klas oraz ich metod i właściwości do wykonywania operacji, które wydają się skomplikowane przy użyciu klas XML.

Niektóre z funkcji oferowanych przez Aspose.Slides nie są w ogóle dostępne przy pracy z dokumentami PresentationML za pomocą klas XML:

- Eksportowanie dokumentów PPT do formatu PDF.
- Renderowanie slajdu do dowolnego formatu obrazu obsługiwanego przez platformę Java.
- Automatyczne kopiowanie szablonów (masterów) z prezentacji źródłowej przy użyciu funkcji klonowania.
- Zastosowanie ochrony do kształtów.

Poniżej znajduje się przykład dokumentu PresentationML z pojedynczym slajdem zawierającym pole tekstowe z napisem “Hello World”. Aby odczytać tekst przy użyciu klas XML, należy napisać program, który potrafi sparsować ten prosty tekst z następującego fragmentu. Aspose.Slides robi to za Ciebie.

**XML**

``` xml
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