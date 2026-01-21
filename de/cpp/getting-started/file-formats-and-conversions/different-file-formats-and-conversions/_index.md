---
title: Verschiedene Dateiformate und Konvertierungen
type: docs
weight: 50
url: /de/cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **Über PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) ist das Präsentationsdateiformat, das von verschiedenen Versionen von Microsoft PowerPoint erstellt, gelesen, bearbeitet und geschrieben werden kann. Dies ist das Binärformat für Präsentationsdokumente, das von Microsoft entwickelt wurde.
### **PPT in Aspose.Slides für C++**
Aspose.Slides für C++ kann PPT‑Dateien lesen, die mit der unten aufgeführten Software erstellt wurden.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Ebenso können PPT‑Dateien, die von Aspose.Slides für C++ erstellt wurden, von der oben genannten Software gelesen werden.
### **Umfassende Unterstützung für PPT**
Aspose.Slides für C++ bietet Unterstützung für fast alle Funktionen, die mit dem PPT‑Dateiformat zusammenhängen. Es deckt nicht nur die grundlegenden / erweiterten Funktionen verschiedener Microsoft‑PowerPoint‑Versionen für die PPT‑Dokumentmanipulation ab, sondern auch einige Funktionen, die von Microsoft PowerPoint überhaupt nicht unterstützt werden. Der Hauptvorteil der Verwendung der Aspose.Slides‑für‑C++‑API‑Bibliothek liegt in der einfachen Handhabung solcher Funktionen.

Zusätzlich zu den Grundaufgaben des Erstellens, Lesens und Schreibens von PPT‑Dateien werden mehrere Funktionen von Aspose.Slides für C++ bereitgestellt, etwa:

- Import anderer MS‑Office‑Dateiformate als OLE‑Objekte in PPT‑Dokumenten.
- Export von PPT‑Dokumenten in PDF, TIFF, XPS‑Formate.
- Export von Folien in PPT‑Dokumenten in SVG‑Formate.
- Rendern von Folien in jedes von C++ Framework unterstützte Bildformat.
- Festlegen der Foliengröße im PPT‑Dokument.
- Verwalten von Animationen auf Formen.
- Verwalten von Bildschirmpräsentationen.
- Formatieren von Text auf Folien.
- Scannen von Text aus den PPT‑Dokumenten.
- Verarbeiten von Tabellen auf Folien.
- Automatisches Kopieren von Master‑Folien mittels Klon‑Funktion.

Ein PPT‑Datei, die von Aspose.Slides für C++ erzeugt wurde, und in Microsoft PowerPoint geöffnet wird
## **PresentationML (PPTX, XML)**
### **Über PresentationML**
PresentationML ist ein Sammelbegriff für eine Familie von XML‑basierten Formaten für Präsentationsdokumente. Office OpenXML (OOXML) ist das XML‑basierte Format, das in Microsoft‑Office‑2007‑Anwendungen eingeführt wurde. Office OpenXML ist ein Containerformat für mehrere spezialisierte XML‑basierte Auszeichnungssprachen. PresentationML ist die Auszeichnungssprache, die von Microsoft Office PowerPoint 2007 verwendet wird, um seine Dokumente zu speichern.
### **PresentationML in Aspose.Slides für C++**
OOXML‑PresentationML‑Dokumente liegen als PPTX‑Dateien vor, die gezippte XML‑Pakete gemäß den [OOXML ECMA‑376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) Spezifikationen sind. Aspose.Slides für C++ unterstützt das Erstellen, Lesen, Manipulieren und Schreiben von PresentationML‑Dokumenten umfassend. Darüber hinaus kann Aspose.Slides für C++ PresentationML‑Dokumente in verschiedene weit verbreitete Formate wie PDF, TIFF und XPS exportieren. Dies ist möglich, weil Aspose.Slides für C++ mit dem Ziel entwickelt wurde, Präsentationsdokumente umfassend zu verarbeiten, wobei PresentationML im Wesentlichen die interne Darstellung von Dokumenten als gezipptes XML‑Paket enthält.

Ein PPTX‑Dokument, das von Aspose.Slides für C++ erzeugt wurde, und in Microsoft PowerPoint geöffnet wird

Anzeige des von Aspose.Slides für C++ erzeugten PPTX‑Dokuments in einer Zip‑Anwendung
### **PresentationML ist Open, warum Aspose.Slides für C++ verwenden**
Da PresentationML XML‑basiert ist, ist es durchaus möglich, Anwendungen zur Verarbeitung und Erzeugung von PresentationML‑Dokumenten mit XML‑Klassen zu bauen, ohne auf Drittanbieter‑Klassenbibliotheken wie Aspose.Slides für C++ zurückzugreifen. Es gibt jedoch mehrere Vorteile bei der Nutzung von Aspose.Slides für C++ gegenüber reinen XML‑Klassen beim Arbeiten mit PresentationML‑Dokumenten.

Die OOXML‑Spezifikation umfasst mehrere tausend Seiten. Das bedeutet, dass Sie viel Zeit und Aufwand investieren müssten, um das Format solcher Dokumente vollständig zu verstehen. Mit Aspose.Slides für C++ hingegen nutzen Sie einfach die relevanten Klassen und deren Methoden / Eigenschaften, um Vorgänge auszuführen, die bei reinem XML‑Code recht komplex erscheinen.

Einige der Funktionen, die bei der Arbeit mit PresentationML‑Dokumenten über XML‑Klassen überhaupt nicht verfügbar sind, umfassen:

- Export von PPT‑Dokumenten in PDF, TIFF, XPS‑Formate
- Export von Folien in PPT‑Dokumenten in SVG‑Formate
- Rendern von Folien in jedes von C++ Framework unterstützte Bildformat
- Automatisches Kopieren von Master‑Folien aus Quell‑Präsentationen mittels Klon‑Funktion
- Anwenden von Schutz auf Formen

Betrachten wir ein Beispiel für ein PresentationML‑Dokument mit einer einzelnen Folie, die ein Textfeld mit dem Text „Hello World“ enthält. Um den Text über XML‑Klassen zu lesen, müssten Sie ein Programm schreiben, das diesen einfachen Text aus dem folgenden Fragment extrahiert:
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

## **PPT‑zu‑PPTX‑Konvertierung**
### **Über die Konvertierung**
Aspose.Slides unterstützt jetzt auch die Konvertierung von PPT nach PPTX.
### **Unterstützte Funktionen bei der Konvertierung**
Aspose.Slides für C++ bietet teilweise Unterstützung für die Konvertierung von Präsentationen im PPT‑Dateiformat in das PPTX‑Dateiformat. Da die Unterstützung für diese Konvertierungsfunktion erst kürzlich in Aspose.Slides für C++ eingeführt wurde, verfügt sie momentan über begrenzte Fähigkeiten und funktioniert nur für einfache Präsentationen. Der Hauptvorteil der Aspose.Slides‑für‑C++‑API‑Bibliothek bei der Konvertierung von PPT‑Präsentationen zu PPTX‑Präsentationen liegt in der einfachen Handhabung der API, um das gewünschte Ergebnis zu erzielen. Bitte gehen Sie zu diesem[link]() Abschnitt für Code‑Beispiele für weitere Details. Der folgende Abschnitt zeigt deutlich, welche Funktionen bei der Konvertierung von PPT‑Präsentationen zu PPTX‑Präsentationen unterstützt bzw. nicht unterstützt werden.
### **Unterstützte Funktionen**
Folgende Funktionen werden während der Konvertierung unterstützt:

- Konvertierung der Struktur von Master‑Folien, Layouts und Folien
- Konvertierung von Diagrammen
- Gruppierte Formen
- Konvertierung von Auto‑Shapes einschließlich Rechtecken und Ellipsen (Auto‑Shapes können jedoch falsche Anpassungswerte besitzen)
- Formen mit benutzerdefinierter Geometrie (können manchmal nicht konvertiert werden)
- Textur‑ und Bildfüllungen für Auto‑Shapes (können manchmal nicht konvertiert werden)
- Konvertierung von Platzhaltern
- Konvertierung von Text in Textfeldern und Textbehältern (Aufzählungszeichen, Ausrichtung und Tabulatoren sind nicht vollständig implementiert)
### **Nicht unterstützte Funktionen**
Folgende Funktionen werden während der Konvertierung nicht unterstützt:

- Folie mit Notizen (Lesen von Notizen ist in PPTX nicht implementiert; falls PPT sie enthält, kann sie noch nicht als PPTX gespeichert werden)
- Konvertierung von Linien und Polylinien
- Linien‑ und Füllformate
- Gradient‑Füllstile
- OLE‑Frames, Tabellen, Video‑ und Audio‑Frames usw.
- Animationen und andere Bildschirmpräsentations‑Eigenschaften werden übersprungen

Neue oder fehlende Funktionen werden in zukünftigen Versionen von Aspose.Slides für C++ hinzugefügt.

Quell‑PPT‑Präsentation

Konvertierte PPTX‑Präsentation
## **Portable Document Format (PDF)**
### **Über PDF**
Das [Portable Document Format](https://en.wikipedia.org/wiki/PDF) ist ein Dateiformat, das von Adobe System zur Dokumentenübertragung zwischen verschiedenen Organisationen erstellt wurde. Ziel dieses Formats ist es, den Inhalt von Dokumenten so darzustellen, dass das visuelle Erscheinungsbild nicht von der Plattform abhängt, auf der es betrachtet wird.
### **PDF in Aspose.Slides für C++**
Jedes Präsentationsdokument, das in Aspose.Slides für C++ geladen werden kann, lässt sich in ein PDF‑Dokument konvertieren, das entweder [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) oder [PDF /A‑1b](https://en.wikipedia.org/wiki/PDF/A) entsprechen kann, je nach Wahl. Aspose.Slides für C++ exportiert die Präsentationsdokumente in PDF so, dass das exportierte PDF‑Dokument in den meisten Fällen dem Original nahezu identisch sieht. Die Aspose‑Lösung unterstützt beim Konvertieren in PDF‑Dokumente folgende Funktionen der Präsentationsdokumente:

- Bilder, Textfelder und andere Formen
- Text und Formatierung
- Absätze und Formatierung
- Hyperlinks
- Kopf‑ und Fußzeilen
- Aufzählungszeichen
- Tabellen

Sie können die Präsentationsdokumente direkt mit der Aspose.Slides‑für‑C++‑Komponente in PDF‑Dokumente exportieren. Das bedeutet, dass Sie dafür keine weitere Drittanbieter‑ oder Aspose.Pdf‑Komponente benötigen. Außerdem können Sie den Export von Präsentation zu PDF mit verschiedenen Optionen anpassen, wie in [diesem Thema](/slides/de/cpp/convert-powerpoint-to-pdf/) beschrieben.

Ein Präsentationsdokument, das über Aspose.Slides für C++ in ein PDF‑Dokument konvertiert wurde
## **XML Parser Specification (XPS)**
### **Über XPS**
Die [XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) ist eine Seitenbeschreibungssprache und ein festes Dokumentformat, das ursprünglich von Microsoft entwickelt wurde. Ähnlich wie PDF ist XPS ein festes Layout‑Dokumentformat, das die Dokumenttreue bewahrt und ein geräteunabhängiges Aussehen gewährleistet.
### **XPS in Aspose.Slides für C++**
Jedes Präsentationsdokument, das von Aspose.Slides für C++ geladen werden kann, lässt sich in das XPS‑Format konvertieren. Aspose.Slides für C++ verwendet die hochpräzise Seitenlayout‑ und Rendering‑Engine, um Ausgaben im festgelegten XPS‑Dokumentenformat zu erzeugen. Erwähnenswert ist, dass Aspose.Slides für C++ XPS direkt erzeugt, ohne von den Windows Presentation Foundation (WPF)‑Klassen aus dem C++ Framework 3.5 abhängig zu sein, wodurch XPS‑Dokumente auch auf Maschinen mit C++ Framework‑Versionen vor 3.5 erstellt werden können. Informationen zum Export von Präsentationsdokumenten nach XPS über Aspose.Slides für C++ finden Sie in [diesem Thema](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/).

Ein Präsentationsdokument, das über Aspose.Slides für C++ in ein XPS‑Dokument konvertiert wurde