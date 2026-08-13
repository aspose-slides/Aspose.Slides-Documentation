---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /de/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML ist ein Name für eine Familie von XML‑basierten Formaten für Präsentationsdokumente. Office OpenXML (OOXML) ist das XML‑basierte Format, das in den Microsoft‑Office‑2007‑Anwendungen eingeführt wurde. Office OpenXML ist ein Containerformat für mehrere spezialisierte XML‑basierte Auszeichnungssprachen. PresentationML ist die Auszeichnungssprache, die von Microsoft Office PowerPoint 2007 zum Speichern von Dokumenten verwendet wird.

{{% /alert %}} 

## **PresentationML in Aspose.Slides für Java**
OOXML PresentationML‑Dokumente liegen als PPTX‑Dateien vor, also gezippte XML‑Pakete, die der [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) Spezifikation entsprechen. Aspose.Slides für Java unterstützt das Erstellen, Lesen, Manipulieren und Schreiben von PresentationML‑Dokumenten umfassend. Darüber hinaus kann Aspose.Slides für Java PresentationML‑Dokumente in ein weit verbreitetes Dokumentformat wie PDF exportieren. Das ist möglich, weil Aspose.Slides für Java mit dem Ziel entwickelt wurde, Präsentationsdokumente vollständig zu verarbeiten, und PresentationML im Grunde die interne Darstellung von Dokumenten als gezipptes XML‑Paket enthält.

**Ein von Aspose.Slides für Java erzeugtes PPTX‑Dokument, das in Microsoft PowerPoint geöffnet wurde** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Anzeige desselben von Aspose.Slides für Java erzeugten PPTX‑Dokuments in einem ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML ist offen, warum Aspose.Slides für Java verwenden?**
Da PresentationML XML‑basiert ist, ist es durchaus möglich, Anwendungen zu erstellen, die PresentationML‑Dokumente mit XML‑Klassen verarbeiten und erzeugen, ohne auf eine Drittanbieter‑Klassenbibliothek wie Aspose.Slides für Java zurückzugreifen. Es gibt jedoch mehrere Vorteile bei der Verwendung von Aspose.Slides für Java gegenüber XML‑Klassen beim Arbeiten mit PresentationML‑Dokumenten.

Die OOXML‑Spezifikation umfasst mehrere tausend Seiten, sodass man zum richtigen Umgang mit PresentationML‑Dokumenten viel Zeit und Aufwand investieren muss, um das Format zu verstehen. Mit Aspose.Slides für Java hingegen verwendet man einfach Klassen sowie deren Methoden und Eigenschaften, um Vorgänge auszuführen, die bei Verwendung von XML‑Klassen komplex erscheinen würden.

Einige der Funktionen, die Aspose.Slides bietet, stehen nicht einmal zur Verfügung, wenn Sie mit PresentationML‑Dokumenten über XML‑Klassen arbeiten:
- Exportieren von PPT‑Dokumenten in das PDF‑Format.
- Rendern einer Folie in jedes Bildformat, das vom Java‑Framework unterstützt wird.
- Automatisches Kopieren von Folienmastervorlagen aus einer Quellpräsentation mithilfe der Klon‑Funktion.
- Schutz auf Formen anwenden.

Unten ist ein Beispiel für ein PresentationML‑Dokument mit einer einzelnen Folie, die ein Textfeld mit dem Text „Hello World“ enthält. Um den Text mit XML‑Klassen zu lesen, müssen Sie ein Programm schreiben, das diesen einfachen Text aus dem folgenden Fragment analysiert. Aspose.Slides erledigt das für Sie.

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