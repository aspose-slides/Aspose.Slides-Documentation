---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /php-java/presentationml-pptx-xml/
---

{{% alert color="primary" %}} 

PresentationML ist ein Name für eine Familie von XML-basierten Formaten für Präsentationsdokumente. Office OpenXML (OOXML) ist das XML-basierte Format, das in den Microsoft Office 2007-Anwendungen eingeführt wurde. Office OpenXML ist ein Containerformat für mehrere spezialisierte XML-basierte Auszeichnungssprachen. PresentationML ist die Auszeichnungssprache, die von Microsoft Office PowerPoint 2007 verwendet wird, um Dokumente zu speichern.

{{% /alert %}} 

## **PresentationML in Aspose.Slides für PHP über Java**
OOXML PresentationML-Dokumente liegen als PPTX-Dateien vor, die als gezippte XML-Pakete folgen der [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) Spezifikation. Aspose.Slides für PHP über Java unterstützt umfangreich das Erstellen, Lesen, Bearbeiten und Schreiben von PresentationML-Dokumenten. Außerdem ist Aspose.Slides für PHP über Java in der Lage, PresentationML-Dokumente in ein weit verbreitetes Dokumentenformat wie PDF zu exportieren. Dies ist möglich, weil Aspose.Slides für PHP über Java mit dem Ziel entwickelt wurde, Präsentationsdokumente umfassend zu handhaben, und PresentationML im Grunde die interne Darstellung von Dokumenten als gezipptes XML-Paket enthält.

**Ein von Aspose.Slides für PHP über Java generiertes PPTX-Dokument, das in Microsoft PowerPoint geöffnet wurde**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Anzeige desselben von Aspose.Slides für PHP über Java generierten PPTX-Dokuments in einer ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML ist offen, warum Aspose.Slides für PHP über Java verwenden?**
Da PresentationML XML-basiert ist, ist es durchaus möglich, Anwendungen zu erstellen, um PresentationML-Dokumente mithilfe von XML-Klassen zu verarbeiten und zu generieren, ohne sich auf eine Drittanbieter-Klassenbibliothek wie Aspose.Slides für PHP über Java verlassen zu müssen. Es gibt jedoch mehrere Vorteile bei der Verwendung von Aspose.Slides für PHP über Java gegenüber XML-Klassen, wenn man mit PresentationML-Dokumenten arbeitet.

Die OOXML-Spezifikation umfasst mehrere tausend Seiten, sodass Sie viel Zeit und Mühe investieren müssen, um das Format richtig zu verstehen, wenn Sie die PresentationML-Dokumente bearbeiten möchten. Auf der anderen Seite können Sie mit Aspose.Slides für PHP über Java einfach Klassen und deren Methoden und Eigenschaften verwenden, um Operationen durchzuführen, die über XML-Klassen komplex erscheinen.

Einige der Funktionen, die Aspose.Slides bietet, sind nicht einmal verfügbar, wenn Sie mit PresentationML-Dokumenten über XML-Klassen arbeiten:

- Export von PPT-Dokumenten in das PDF-Format.
- Rendering einer Folie in ein beliebiges von der Java-Plattform unterstütztes Bildformat.
- Automatisches Kopieren von Masterfolien aus Quellpräsentationen mit der Klonfunktion.
- Anwendung von Schutz auf Formen.

Nachfolgend finden Sie ein Beispiel für ein PresentationML-Dokument mit einer einzigen Folie, die ein Textfeld mit dem Text "Hallo Welt" enthält. Um den Text mit XML-Klassen zu lesen, müssen Sie ein Programm schreiben, das diesen einfachen Text aus dem folgenden Fragment parsen kann. Aspose.Slides erledigt das für Sie.

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
```php

```