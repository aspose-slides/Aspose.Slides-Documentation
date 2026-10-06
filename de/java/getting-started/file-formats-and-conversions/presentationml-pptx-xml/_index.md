---
title: PresentationML (PPTX, XML) (Historisch)
type: docs
weight: 20
url: /de/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- historisch
- Java
- Aspose.Slides
description: "Historisch: ein älterer Überblick über das PresentationML (PPTX)-Format in Aspose.Slides für Java, beibehalten für vorhandene Links. Die aktuelle Liste der unterstützten Formate finden Sie in Supported File Formats."
---
{{% alert color="info" title="Hinweis" %}}

Dies ist eine historische Seite, die für vorhandene Links beibehalten wird. Sie beschreibt nicht die aktuelle Version von Aspose.Slides for Java. Für die Formate, die Aspose.Slides for Java lädt, importiert, speichert und rendert, sowie die API für jedes dieser Formate, siehe [Supported File Formats](/slides/de/java/supported-file-formats/). Zum Vergleich von PPTX mit PPT siehe [Understanding the Difference: PPT vs PPTX](/slides/de/java/ppt-vs-pptx/).

{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}

PresentationML ist ein Name für eine Familie von XML‑basierten Formaten für Präsentationsdokumente. Office OpenXML (OOXML) ist das XML‑basierte Format, das in Microsoft Office‑2007‑Anwendungen eingeführt wurde. Office OpenXML ist ein Containerformat für mehrere spezialisierte XML‑basierte Auszeichnungssprachen. PresentationML ist die Auszeichnungssprache, die von Microsoft Office PowerPoint 2007 zum Speichern von Dokumenten verwendet wird.

{{% /alert %}}

## **PresentationML in Aspose.Slides für Java**
OOXML PresentationML‑Dokumente werden als PPTX‑Dateien bereitgestellt, also als komprimierte XML‑Pakete, die der [OOXML ECMA‑376](https://ecma-international.org/publications-and-standards/standards/ecma-376/)‑Spezifikation entsprechen. Aspose.Slides for Java unterstützt das Erstellen, Lesen, Manipulieren und Schreiben von PresentationML‑Dokumenten umfassend. Darüber hinaus kann Aspose.Slides for Java PresentationML‑Dokumente in ein weit verbreitetes Dokumentformat wie PDF exportieren. Dies ist möglich, weil Aspose.Slides for Java mit dem Ziel entwickelt wurde, Präsentationsdokumente umfassend zu verarbeiten, und PresentationML im Grunde die interne Darstellung von Dokumenten als komprimiertes XML‑Paket enthält.

**Ein von Aspose.Slides for Java erzeugtes PPTX‑Dokument, das in Microsoft PowerPoint geöffnet wurde**

![Ein von Aspose.Slides for Java erzeugtes PPTX‑Dokument, das in Microsoft PowerPoint geöffnet wurde](presentationml-pptx-xml_1.png)


**Anzeige desselben von Aspose.Slides for Java erzeugten PPTX‑Dokuments als ZIP‑Paket**

![Dasselbe PPTX‑Dokument als ZIP‑Paket angezeigt](presentationml-pptx-xml_2.jpg)


## **PresentationML ist offen, warum Aspose.Slides for Java verwenden?**
Da PresentationML XML‑basiert ist, ist es durchaus möglich, Anwendungen zu erstellen, die PresentationML‑Dokumente mit XML‑Klassen verarbeiten und generieren, ohne dabei auf eine Drittanbieter‑Klassenbibliothek wie Aspose.Slides for Java zurückzugreifen. Es gibt jedoch mehrere Vorteile bei der Verwendung von Aspose.Slides for Java gegenüber XML‑Klassen bei der Arbeit mit PresentationML‑Dokumenten.

Die OOXML‑Spezifikation umfasst mehrere tausend Seiten, sodass man für die korrekte Handhabung von PresentationML‑Dokumenten viel Zeit und Aufwand investieren muss, um das Format zu verstehen. Mit Aspose.Slides for Java hingegen verwendet man einfach Klassen sowie deren Methoden und Eigenschaften, um Vorgänge auszuführen, die bei einer Umsetzung mit XML‑Klassen komplex erscheinen würden.

Einige der Funktionen, die Aspose.Slides bietet, sind sogar nicht verfügbar, wenn man mit PresentationML‑Dokumenten über XML‑Klassen arbeitet:

- Exportieren von PPT‑Dokumenten ins PDF‑Format.
- Rendern einer Folie in ein beliebiges Bildformat, das vom Java‑Framework unterstützt wird.
- Automatisches Kopieren von Masterfolien aus einer Quellpräsentation mithilfe der Klon‑Funktion.
- Schutz für Shapes anwenden.

Unten finden Sie ein Beispiel für ein PresentationML‑Dokument mit einer einzelnen Folie, die ein Textfeld mit dem Text “Hello World” enthält. Um den Text mit XML‑Klassen auszulesen, muss man ein Programm schreiben, das diesen einfachen Text aus dem folgenden Fragment parst. Aspose.Slides übernimmt das für Sie.

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