---
title: Warum nicht Open XML SDK
type: docs
weight: 180
url: /de/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- Vergleich
- Präsentationsobjektmodell
- hochwertige Konvertierung
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, warum Aspose.Slides die bessere Wahl gegenüber dem kostenlosen Open XML SDK ist: Vergleichen Sie Funktionen, automatisierungsfreie Konvertierung und umfassende Unterstützung für PPT, PPTX und ODP."
---
## **Übersicht**

Dieser Artikel erklärt, wann Entwickler Open XML SDK oder Aspose.Slides für die Arbeit mit Präsentationsdokumenten wählen könnten. Er beschreibt Open XML SDK als Bibliothek zum Manipulieren von OOXML‑Paketen und deren zugrunde liegenden XML‑Elementen, während Aspose.Slides als Präsentationsverarbeitungs‑Bibliothek mit einem hoch‑stufigen Objektmodell und Unterstützung für viele PowerPoint‑bezogene Aufgaben präsentiert wird.

Der Artikel vergleicht beide Optionen anhand unterstützter Formate, Programmiermodells, Rendering, Plattformunterstützung und typischer Anwendungsfälle. Er verdeutlicht außerdem, dass Open XML SDK für grundlegende PPTX‑Operationen oder den direkten Zugriff auf OOXML‑Elemente geeignet sein kann, während Aspose.Slides eher für komplexe Präsentationsaufgaben wie die Arbeit mit mehreren PowerPoint‑Formaten, das Kopieren oder Klonen von Shapes, das Ersetzen von Text, das Anwenden von Animationen und das Konvertieren von Präsentationen zu PDF, TIFF oder XPS geeignet ist.

## **What Is Open XML SDK?**
Manchmal erhalten wir diese Frage: *Why should we use Aspose products rather than the free Open XML SDK?*

Wir finden es einfach, diese Frage anhand von Funktionen und Merkmalen zu beantworten.

Laut der [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) wird Open XML SDK wie folgt definiert:

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **What Is Aspose.Slides?**
Aspose.Slides ist eine Klassenbibliothek, die Anwendungen das Ausführen folgender Präsentationsverarbeitungs‑Aufgaben ermöglicht:

- Programmierung mit einem Präsentations‑Objektmodell.

- Hochwertige Konvertierungen aller gängigen unterstützten PowerPoint‑Präsentationsformate, einschließlich Konvertierung zu PDF, XPS und TIFF.

- Erzeugen von Folien‑Thumbnails in bekannten Formaten wie PNG, JPEG und BMP sowie Export von Folien nach SVG.

- Aufbau von Präsentationen von Grund auf oder durch Kombinieren von Elementen aus einem oder mehreren Dokumenten.

- Hinzufügen von Animationen, OLE‑Frames, Tabellen, Erstellen und Verwalten von Diagrammen.

- Umfassende Steuerung und Verwaltung der Textformatierung auf TextFrame‑, Paragraph‑ und Portion‑Ebene.

  Für weitere Details zu den verfügbaren Funktionen siehe die Seite [Aspose.Slides Features](/slides/de/net/product-overview/).

## **Compare Open XML SDK with Aspose.Slides**
This table compares Open XML SDK capabilities and features with Aspose.Slides.

|**Feature oder Feature-Kategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertierung von PPT zu PPTX|Nein|Ja|
|<p>Programmierung auf hoher Ebene mit einem Presentation Document Object Model (DOM): </p><p>- Texte suchen und ersetzen.</p><p>- Folien in Präsentationen zusammenstellen.</p>|Nein|Ja|
|Detaillierte Programmierung mit einem Dokumentenobjektmodell; Zugriff auf einzelne Elemente und Formatierungen wie TextHolders, TextFrames, Paragraphs und Portions.|Ja|Ja|
|Niedrigstufiger direkter und vollständiger Zugriff auf die zugrunde liegenden XML‑Elemente und Attribute wie Beziehungskennungen, Listenkkennungen eines OOXML‑Dokuments.|Ja|Nein|
|<p>Präsentations‑Rendering:</p><p>- Präsentationen in PDF, PDF‑Notizen, XPS, TIFF‑Bilder rendern.</p><p>- Folien‑Vorschaubilder in PNG, JPEG, BMP, SVG und TIFF rendern.</p><p>- Bildauflösung, Qualität, Kompression und weitere Optionen festlegen.</p>|Nein|Ja|
|Unterstützte Plattformen|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Fazit**
Open XML SDK und Aspose.Slides konkurrieren nicht direkt, da sie grundlegend unterschiedliche Bedürfnisse adressieren und unterschiedliche Zielgruppen ansprechen.

{{% alert color="info" title="Note" %}}

Open XML SDK ist eine Klassenbibliothek, die eine stark typisierte Vorgehensweise für die Arbeit mit OOXML‑Dokumenten bietet, während Aspose.Slides eine äußerst nützliche Bibliothek zur Präsentationsverarbeitung ist, die hervorragende Unterstützung für nahezu alle Microsoft PowerPoint‑Dateiformate liefert.

{{% /alert %}}

Wenn Ihr Workflow eine grundlegende Programmieroperation an einem PPTX‑Dokument ist, könnte Open XML SDK eine gute Wahl sein. Mit Open XML SDK sollten Sie in der Lage sein, einfache Aufgaben wie das Erzeugen eines einfachen PPTX‑Dokuments oder das Entfernen von Kommentaren, Kopf‑/Fußzeilen, das Extrahieren von Bildern usw. durchzuführen. Bestimmte Aufgaben können mit Open XML SDK ausgeführt werden, aber nicht mit Aspose.Slides. Zum Beispiel, wenn Sie direkt auf die XML‑Elemente und Attribute eines OOXML‑Dokuments zugreifen müssen, sollten Sie Open XML SDK verwenden.

Wenn Sie komplexe Aufgaben an Dokumenten ausführen müssen – wie die unten aufgeführten Aufgaben – dann ist Aspose.Slides Ihre beste Option.

- Vorgänge mit älteren PowerPoint‑Formaten (und auch PPTX).
- Kopieren oder Klonen von Shapes innerhalb von Folien, wobei Objekte, Stile und andere Formatierungselemente angemessen kombiniert werden.
- Ersetzen von formatiertem oder unformatiertem Text.
- Anwenden von Animationen und Verwenden von Verbindungsstücken mit Shapes.
- Konvertieren eines Dokuments zu PDF, TIFF oder XPS, sodass es wie bei einer Konvertierung durch Microsoft PowerPoint aussieht.
- Entwicklung einer .NET‑ oder Java‑Anwendung in Desktop‑ und Web‑Umgebungen.