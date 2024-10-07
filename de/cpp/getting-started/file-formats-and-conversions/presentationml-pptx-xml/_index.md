---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /cpp/presentationml-pptx-xml/
---

## **Über PresentationML**
PresentationML ist der Name für eine Familie von XML-basierten Formaten für Präsentationsdokumente. Office OpenXML (OOXML) ist das XML-basierte Format, das in Microsoft Office 2007-Anwendungen eingeführt wurde. Office OpenXML ist ein Containerformat für mehrere spezialisierte XML-basierte Auszeichnungssprachen. PresentationML ist die Auszeichnungssprache, die von Microsoft Office PowerPoint 2007 verwendet wird, um seine Dokumente zu speichern. 
## **PresentationML in Aspose.Slides für C++**
OOXML PresentationML-Dokumente liegen als PPTX-Dateien vor, die gezippte XML-Pakete sind, die den [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) Spezifikationen entsprechen. Aspose.Slides für C++ unterstützt umfassend das Erstellen, Lesen, Manipulieren und Schreiben von PresentationML-Dokumenten. Darüber hinaus ist Aspose.Slides für C++ in der Lage, PresentationML-Dokumente in verschiedene weit verbreitete Dokumentformate wie PDF, TIFF und XPS zu exportieren. Dies ist möglich, weil Aspose.Slides für C++ mit dem Ziel entwickelt wurde, Präsentationsdokumente umfassend zu verarbeiten, und PresentationML im Wesentlichen die interne Präsentation von Dokumenten als gezipptes XML-Paket enthält. 

## **PresentationML ist offen, warum Aspose.Slides für C++ verwenden**
Da PresentationML XML-basiert ist, ist es durchaus möglich, Anwendungen zur Verarbeitung und Generierung von PresentationML-Dokumenten unter Verwendung von XML-Klassen zu erstellen, ohne auf Drittanbieter-Bibliotheken wie Aspose.Slides für C++ angewiesen zu sein. Es gibt jedoch mehrere Vorteile bei der Verwendung von Aspose.Slides für C++ im Vergleich zu XML-Klassen, wenn man mit PresentationML-Dokumenten arbeitet. 

Die OOXML-Spezifikation ist zu lang und umfasst mehrere tausend Seiten. Das bedeutet, um die PresentationML-Dokumente ordnungsgemäß zu verarbeiten, müssen Sie viel Zeit und Mühe investieren, um das Format solcher Dokumente zu verstehen. Andererseits müssen Sie bei der Verwendung von Aspose.Slides für C++ einfach die entsprechenden Klassen und deren jeweilige Methoden/Eigenschaften verwenden, um Operationen durchzuführen, die über XML-Klassen recht komplex erscheinen. 

Die folgenden Funktionen sind sogar nicht verfügbar, wenn man mit PresentationML-Dokumenten über XML-Klassen umgeht: 

- Export von PPT-Dokumenten in PDF-, TIFF-, XPS-Formate
- Export von Folien in den PPT-Dokumenten in SVG-Formate
- Rendering von Folien in ein beliebiges von C++ Framework unterstütztes Bildformat
- Automatisches Kopieren von Masterfolien aus Quellpräsentationen unter Verwendung der Klonfunktion
- Anwendung von Schutz auf Formen

Lassen Sie uns ein Beispiel für ein PresentationML-Dokument mit einer einzigen Folie betrachten, die ein Textfeld mit dem Text „Hallo Welt“ enthält. Um den Text über XML-Klassen zu lesen, müssen Sie ein Programm schreiben, das diesen einfachen Text aus dem folgenden Fragment parsen kann: 
## **Beispiel**


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

                <a:t>Hallo Welt

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