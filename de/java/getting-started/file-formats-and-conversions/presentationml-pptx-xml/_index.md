---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /de/java/presentationml-pptx-xml/
---

{{% alert color="primary" %}} 

PresentationML ist ein Begriff für eine Familie von XML-basierten Formaten für Präsentationsdokumente. Office OpenXML (OOXML) ist das XML-basierte Format, das in den Microsoft Office 2007-Anwendungen eingeführt wurde. Office OpenXML ist ein Containerformat für mehrere spezialisierte XML-basierte Auszeichnungssprachen. PresentationML ist die Auszeichnungssprache, die von Microsoft Office PowerPoint 2007 verwendet wird, um Dokumente zu speichern.

{{% /alert %}} 

## **PresentationML in Aspose.Slides für Java**
OOXML PresentationML-Dokumente kommen als PPTX-Dateien, komprimierte XML-Pakete, die der [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) Spezifikation folgen. Aspose.Slides für Java unterstützt umfangreich das Erstellen, Lesen, Manipulieren und Schreiben von PresentationML-Dokumenten. Darüber hinaus ist Aspose.Slides für Java in der Lage, PresentationML-Dokumente in ein weit verbreitetes Dokumentformat wie PDF zu exportieren. Dies ist möglich, weil Aspose.Slides für Java mit dem Ziel entwickelt wurde, Präsentationsdokumente umfassend zu behandeln, und PresentationML im Wesentlichen die interne Präsentation von Dokumenten als komprimiertes XML-Paket speichert.

**Ein von Aspose.Slides für Java generiertes PPTX-Dokument, das in Microsoft PowerPoint geöffnet wurde** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Das gleiche von Aspose.Slides für Java generierte PPTX-Dokument in einer ZIP-Datei anzeigen** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML ist offen, Warum Aspose.Slides für Java verwenden?**
Da PresentationML XML-basiert ist, ist es durchaus möglich, Anwendungen zu erstellen, die PresentationML-Dokumente mit XML-Klassen verarbeiten und generieren, ohne auf eine Drittanbieter-Klassenbibliothek wie Aspose.Slides für Java zurückzugreifen. Es gibt jedoch mehrere Vorteile bei der Verwendung von Aspose.Slides für Java gegenüber XML-Klassen beim Arbeiten mit PresentationML-Dokumenten.

Die OOXML-Spezifikation ist mehrere tausend Seiten lang, daher muss man viel Zeit und Mühe investieren, um das Format richtig zu verstehen. Auf der anderen Seite verwendet man mit Aspose.Slides für Java einfach Klassen und deren Methoden und Eigenschaften, um Operationen durchzuführen, die mit XML-Klassen komplex erscheinen.

Einige der Funktionen, die Aspose.Slides bietet, sind nicht einmal verfügbar, wenn man mit PresentationML-Dokumenten über XML-Klassen arbeitet:

- Exportiere PPT-Dokumente ins PDF-Format.
- Rendern einer Folie in jedes vom Java-Framework unterstützte Bildformat.
- Automatisches Kopieren von Masterfolien aus Quellpräsentationen mithilfe der Klon-Funktion.
- Anwendung von Schutz auf Formen.

Nachfolgend ein Beispiel für ein PresentationML-Dokument mit einer einzelnen Folie, die ein Textfeld mit dem Text „Hello World“ enthält. Um den Text mit XML-Klassen zu lesen, muss man ein Programm schreiben, das diesen einfachen Text aus dem folgenden Fragment parsen kann. Aspose.Slides erledigt das für dich.

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