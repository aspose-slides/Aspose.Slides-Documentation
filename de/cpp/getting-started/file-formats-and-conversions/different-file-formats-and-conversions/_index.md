---
title: Unterschiedliche Dateiformate und Konversionen
type: docs
weight: 50
url: /cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **Über PPT**
[PPT](https://de.wikipedia.org/wiki/Microsoft_PowerPoint) ist das Präsentationsdokumentdateiformat, das von verschiedenen Versionen von Microsoft PowerPoint erstellt, gelesen, manipuliert und geschrieben werden kann. Dies ist das binäre Format für Präsentationsdokumente, das von Microsoft entwickelt wurde.
### **PPT in Aspose.Slides für C++**
Aspose.Slides für C++ kann PPT-Dateien lesen, die von der unten aufgeführten Software erstellt wurden.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Ebenso können PPT-Dateien, die von Aspose.Slides für C++ erstellt wurden, von dem oben genannten Software-Set gelesen werden.
### **Umfassende Unterstützung für PPT**
Aspose.Slides für C++ bietet Unterstützung für fast alle Funktionen, die mit dem PPT-Dokumentdateiformat verbunden sind. Es deckt nicht nur die grundlegenden / erweiterten Funktionen ab, die von verschiedenen Microsoft PowerPoint-Versionen für PPT-Dokumentmanipulationen bereitgestellt werden, sondern auch einige Funktionen, die sogar von Microsoft PowerPoint nicht unterstützt werden. Der Hauptvorteil der Verwendung der Aspose.Slides für C++ API-Bibliothek ist die Benutzerfreundlichkeit beim Umgang mit solchen Funktionen.

Neben den grundlegenden Aufgaben im Zusammenhang mit dem Erstellen, Lesen und Schreiben von PPT-Dokumentdateien gibt es mehrere Funktionen, die von Aspose.Slides für C++ bereitgestellt werden, wie:

- Import anderer MS Office-Dateiformate als OLE-Objekte in PPT-Dokumenten.
- Export von PPT-Dokumenten in PDF-, TIFF- und XPS-Formate.
- Exportieren von Folien in den PPT-Dokumenten in SVG-Formate.
- Rendering von Folien in jedes vom C++-Framework unterstützte Bildformat.
- Festlegung der Größe von Folien im PPT-Dokument.
- Verwalten von Animationen auf Formen.
- Verwalten von Diashows.
- Text auf Folien formatieren.
- Text aus den PPT-Dokumenten scannen.
- Tabellen auf Folien bearbeiten.
- Automatisches Kopieren von Masterfolien mit der Klonfunktion.

Eine von Aspose.Slides für C++ generierte PPT-Datei, die in Microsoft PowerPoint geöffnet wurde
## **PresentationML (PPTX, XML)**
### **Über PresentationML**
PresentationML ist ein Name für eine Familie von XML-basierten Formaten für Präsentationsdokumente. Office OpenXML (OOXML) ist das XML-basierte Format, das in den Microsoft Office 2007-Anwendungen eingeführt wurde. Office OpenXML ist ein Containerformat für mehrere spezialisierte auf XML basierende Auszeichnungssprachen. PresentationML ist die Auszeichnungssprache, die von Microsoft Office PowerPoint 2007 verwendet wird, um seine Dokumente zu speichern.
### **PresentationML in Aspose.Slides für C++**
OOXML PresentationML-Dokumente liegen als PPTX-Dateien vor, die ZIP-komprimierte XML-Pakete sind und den [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) Spezifikationen folgen. Aspose.Slides für C++ unterstützt umfassend das Erstellen, Lesen, Manipulieren und Schreiben von PresentationML-Dokumenten. Darüber hinaus ist Aspose.Slides für C++ in der Lage, PresentationML-Dokumente in verschiedene weit verbreitete Dokumentformate wie PDF, TIFF und XPS zu exportieren. Dies ist möglich, da Aspose.Slides für C++ mit dem Ziel entwickelt wurde, Präsentationsdokumente umfassend zu verarbeiten, und PresentationML im Wesentlichen die interne Präsentation von Dokumenten als ZIP-komprimiertes XML-Paket enthält.

Ein von Aspose.Slides für C++ generiertes PPTX-Dokument, das in Microsoft PowerPoint geöffnet wurde

Anzeigen des von Aspose.Slides für C++ generierten PPTX-Dokuments in Zip-Anwendung
### **PresentationML ist offen, warum Aspose.Slides für C++ verwenden**
Da PresentationML auf XML basiert, ist es durchaus möglich, Anwendungen zur Verarbeitung und Generierung von PresentationML-Dokumenten mit XML-Klassen zu erstellen, ohne auf Dritthersteller-Klassenbibliotheken wie Aspose.Slides für C++ angewiesen zu sein. Es gibt jedoch mehrere Vorteile der Verwendung von Aspose.Slides für C++, anstatt mit XML-Klassen zu arbeiten, wenn es um PresentationML-Dokumente geht.

Die OOXML-Spezifikation ist mehrere Tausend Seiten lang. Das bedeutet, um die PresentationML-Dokumente richtig zu verarbeiten, müssen Sie viel Zeit und Mühe investieren, um das Format solcher Dokumente zu verstehen. Im Gegensatz dazu müssen Sie bei der Verwendung von Aspose.Slides für C++ einfach die entsprechenden Klassen und deren jeweilige Methoden / Eigenschaften verwenden, um Operationen auszuführen, die über XML-Klassen ziemlich kompliziert erscheinen.

Die folgenden Funktionen sind sogar nicht verfügbar, wenn Sie mit PresentationML-Dokumenten über XML-Klassen arbeiten:

- Export von PPT-Dokumenten in PDF-, TIFF- und XPS-Formate
- Exportieren von Folien in den PPT-Dokumenten in SVG-Formate
- Rendering von Folien in jedes vom C++-Framework unterstützte Bildformat
- Automatisches Kopieren von Masterfolien aus Quellpräsentationen mit der Klonfunktion
- Anwendung von Schutz auf Formen

Nehmen wir ein Beispiel für ein PresentationML-Dokument mit einer einzigen Folie mit einem Textfeld, das den Text „Hello World“ enthält. Um den Text über XML-Klassen zu lesen, müssen Sie ein Programm schreiben, das diesen einfachen Text aus dem folgenden Fragment analysieren kann:

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
## **PPT zu PPTX-Konversion**
### **Über Konversion**
Aspose.Slides unterstützt jetzt auch die Konversion von PPT zu PPTX.
### **Unterstützte Funktionen bei der Konversion**
Aspose.Slides für C++ bietet teilweise Unterstützung für die Konversion von PPT-Dokumentdateiformat-Präsentationen in PPTX-Dateiformat-Präsentationen. Da die Unterstützung für die genannte Präsentationskonvertierungsfunktion gerade in Aspose.Slides für C++ eingeführt wurde, hat sie im Moment eine begrenzte Fähigkeit und funktioniert nur für die einfache Form von Präsentationen. Der Hauptvorteil, den die Aspose.Slides für C++ API-Bibliothek bei der Konversion von PPT-Präsentationen in das PPTX-Format bietet, ist die Benutzerfreundlichkeit der API zur Erreichung des gewünschten Ziels. Bitte fahren Sie zu diesem[link]() zur Codebeispiel-Sektion für weitere Details. Der folgende Abschnitt veranschaulicht klar, welche Funktionen beim Konvertieren von PPT-Format-Präsentationen in PPTX-Format-Präsentationen unterstützt und nicht unterstützt werden.
### **Unterstützte Funktionen**
Die folgenden Funktionen werden während der Konversion unterstützt:

- Konversion der Struktur von Masterfolien, Layouts und Folien
- Konversion der Struktur von Masterfolien, Layouts und Folien
- Konversion von Diagrammen
- Gruppieren von Formen
- Konversion von Autohaltungen einschließlich Rechtecken und Ellipsen. Es ist jedoch möglich, dass Autohaltungen falsche Anpassungswerte haben
- Formen mit benutzerdefinierter Geometrie. Manchmal werden sie möglicherweise nicht konvertiert
- Texturen und Bilder als Füllstil für Autohaltungen. Manchmal werden sie möglicherweise nicht konvertiert
- Konversion von Platzhaltern
- Konversion von Text in Textfeldern und Textbehältern. Punkte, Ausrichtung und Tabulatoren sind jedoch nicht vollständig implementiert
### **Nicht unterstützte Funktionen**
Die folgenden Funktionen werden während der Konversion nicht unterstützt:

- Folien mit Notizen, da das Lesen von Notizen in PPTX nicht implementiert ist. Falls PPT dies hat, kann es derzeit nicht als PPTX gespeichert werden.
* Konversion von Linien und Polylinien
- Linien- und Füllformate
- Farbverlauf-Stile für Füllungen
- OLE-Frames, Tabellen, Video- und Audio-Frames usw.
- Animationen und andere Diashow-Eigenschaften werden übersprungen
  Neue oder fehlende Funktionen werden in den kommenden Versionen von Aspose.Slides für C++ hinzugefügt.

Quell-PPT-Präsentation

Konvertierte PPTX-Präsentation
## **Portable Document Format (PDF)**
### **Über PDF**
Das [Portable Document Format](https://de.wikipedia.org/wiki/PDF) ist ein Dateiformat, das von Adobe Systems zur Austausch von Dokumenten zwischen verschiedenen Organisationen erstellt wurde. Der Zweck dieses Formats war es, zu ermöglichen, dass die Inhalte der Dokumente so dargestellt werden können, dass ihr visuelles Erscheinen nicht von der Plattform abhängt, auf der sie betrachtet werden.
### **PDF in Aspose.Slides für C++**
Jedes Präsentationsdokument, das in Aspose.Slides für C++ geladen werden kann, kann in ein PDF-Dokument konvertiert werden, das den [PDF 1.5](https://de.wikipedia.org/wiki/PDF/A) oder [PDF /A-1b](https://de.wikipedia.org/wiki/PDF/A) je nach Wahl entspricht. Aspose.Slides für C++ exportiert die Präsentationsdokumente in PDF, so dass die exportierten PDF-Dokumente meistens dem ursprünglichen Präsentationsdokument sehr ähnlich aussehen. Die Aspose-Lösung unterstützt die folgenden Funktionen der Präsentationsdokumente beim Konvertieren in PDF-Dokumente:

- Bilder, Textkästen und andere Formen
- Text und Formatierung
- Absätze und Formatierung
- Hyperlinks
- Kopf- und Fußzeilen
- Aufzählungen
- Tabellen

Sie können die Präsentationsdokumente direkt nur mit der Aspose.Slides für C++-Komponente in PDF-Dokumente exportieren. Das heißt, Sie benötigen für diesen Zweck keine andere Drittanbieter- oder Aspose.Pdf-Komponente. Darüber hinaus können Sie den Präsentation-zu-PDF-Export mit verschiedenen Optionen anpassen, wie in diesem Thema erklärt wird](/slides/cpp/converting-presentation-to-pdf/).

Ein Präsentationsdokument, das durch Aspose.Slides für C++ in ein PDF-Dokument konvertiert wurde
## **XML Parser Specification (XPS)**
### **Über XPS**
Die [XML Parser Specification](https://de.wikipedia.org/wiki/Open_XML_Paper_Specification) ist eine Seitenbeschreibungssprache und ein festes Dokumentformat, das ursprünglich von Microsoft entwickelt wurde. Wie PDF ist XPS ein Dokumentformat mit festem Layout, das entwickelt wurde, um die Dokumenttreue zu bewahren und ein geräteunabhängiges Dokumentaussehen bereitzustellen.
### **XPS in Aspose.Slides für C++**
Jedes Präsentationsdokument, das von Aspose.Slides für C++ geladen werden kann, kann in das XPS-Format konvertiert werden. Aspose.Slides für C++ verwendet die hochauflösende Seitenlayout- und Rendering-Engine, um Ausgaben im festen Layout XPS-Dokumentformat zu erstellen. Es ist erwähnenswert, dass Aspose.Slides für C++ XPS direkt erzeugt, ohne von den Windows Presentation Foundation (WPF)-Klassen abhängig zu sein, die mit dem C++ Framework 3.5 verpackt sind, was es Aspose.Slides für C++ ermöglicht, XPS-Dokumente auf Maschinen zu erstellen, die ältere Versionen des C++-Frameworks verwenden. Sie können lernen, wie Sie die Präsentationsdokumente über Aspose.Slides für C++ in XPS-Dokumente exportieren können, in diesem Thema](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/).

Ein Präsentationsdokument, das durch Aspose.Slides für C++ in ein XPS-Dokument konvertiert wurde