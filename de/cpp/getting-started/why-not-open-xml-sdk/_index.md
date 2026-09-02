---
title: Warum nicht Open XML SDK
type: docs
weight: 100
url: /de/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- Vergleich
- Präsentationsobjektmodell
- hochwertige Konvertierung
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, warum Aspose.Slides die bessere Wahl gegenüber dem kostenlosen Open XML SDK ist: vergleichen Sie Funktionen, automatisierungsfreie Konvertierung und umfangreiche Unterstützung für PPT, PPTX und ODP."
---
## **Übersicht**

Dieser Artikel erklärt, wann Entwickler das Open XML SDK oder Aspose.Slides für die Arbeit mit Präsentationsdokumenten wählen könnten. Er beschreibt das Open XML SDK als Bibliothek zum Manipulieren von OOXML‑Paketen und deren zugrunde liegenden XML‑Elementen, während Aspose.Slides als Präsentationsverarbeitungsbibliothek mit einem hochrangigen Objektmodell und Unterstützung für viele PowerPoint‑bezogene Aufgaben präsentiert wird.

Der Artikel vergleicht beide Optionen anhand unterstützter Formate, Programmiermodells, Rendering, Plattformunterstützung und typischer Anwendungsfälle. Er stellt außerdem klar, dass das Open XML SDK für grundlegende PPTX‑Operationen oder den direkten Zugriff auf OOXML‑Elemente geeignet sein kann, während Aspose.Slides eher für komplexe Präsentationsaufgaben wie die Arbeit mit mehreren PowerPoint‑Formaten, das Kopieren oder Klonen von Formen, das Ersetzen von Text, das Anwenden von Animationen und das Konvertieren von Präsentationen zu PDF, TIFF oder XPS geeignet ist.

## **Was ist Open XML SDK?**
Wir hören manchmal diese Frage: Warum sollten wir Aspose‑Produkte statt des kostenlosen Open XML SDK verwenden? Diese Frage lässt sich leicht beantworten: Funktionen und Funktionalität. Laut der [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) ist das Open XML SDK definiert als: Das Open XML SDK 2.0 vereinfacht die Aufgabe, Open XML‑Pakete und die zugrunde liegenden Open XML‑Schema‑Elemente innerhalb eines Pakets zu manipulieren. Das Open XML SDK 2.0 fasst viele gängige Aufgaben zusammen, die Entwickler mit Open XML‑Paketen ausführen, sodass Sie komplexe Vorgänge mit nur wenigen Codezeilen erledigen können. OOXML‑Dokumente sind im Wesentlichen gezippte XML‑Dateien und das Open XML SDK ist eine Sammlung von Klassen, die es Ihnen ermöglichen, mit dem Inhalt von OOXML‑Dokumenten stark typisiert zu arbeiten. Das bedeutet, anstatt eine Datei zu entzippen, um XML zu extrahieren, dieses XML in einen DOM‑Baum zu laden und direkt mit XML‑Elementen und -Attributen zu arbeiten, bietet das Open XML SDK Klassen dafür.

## **Was ist Aspose.Slides?**
Aspose.Slides ist eine Klassenbibliothek, die Ihrer Anwendung die folgenden Präsentationsverarbeitungsaufgaben ermöglicht:

- Programmierung mit einem **Presentation**‑Objektmodell.
- Hochqualitative Konvertierungen zwischen allen gängigen unterstützten PowerPoint‑Präsentationsformaten, einschließlich Konvertierung zu PDF und XPS.
- Möglichkeit, Folien‑Thumbnails in bekannten Formaten wie PNG, JPEG und BMP zu erzeugen sowie Folien nach SVG zu exportieren.
- Möglichkeit, Präsentationen von Grund auf neu zu erstellen oder durch Kombination aus einem oder mehreren Dokumenten zu bauen.
- Unterstützung für das Hinzufügen von Animationen, Ole‑Frames, Tabellen, das Erstellen und Verwalten von Diagrammen.
- Umfangreiche Steuerung für das Verwalten der Textformatierung auf Ebene von TextFrames, Paragraphs und Portions.
  Für weitere Details zu den unterstützten Funktionen besuchen Sie bitte [Funktionen von Aspose.Slides](/slides/de/cpp/product-overview/).

## **Open XML SDK und Aspose.Slides vergleichen**
Die folgende Tabelle vergleicht die Funktionen von Open XML SDK und Aspose.Slides.

|**Funktion oder Funktionskategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertierung von PPT zu PPTX|Nein|Ja|
|<p>Programmierung auf hoher Ebene mit einem Presentation Document Object Model (DOM):</p><p>- Text suchen und ersetzen.</p><p>- Folien in Präsentationen zusammenstellen.</p>|Nein|Ja|
|Detailierte Programmierung mit einem Dokumentobjektmodell, Zugriff auf einzelne Elemente und Formatierungen wie TextHolders, TextFrames, Paragraphs und Portions.|Ja|Ja|
|Direkter und vollständiger Low-Level-Zugriff auf die zugrunde liegenden XML-Elemente und -Attribute wie Beziehungskennungen, Listenkennungen eines OOXML-Dokuments.|Ja|Nein|
|<p>Rendern:</p><p>- Präsentationen in PDF, PDF-Notizen, XPS, TIFF-Bilder rendern.</p><p>- Folien-Thumbnails in PNG, JPEG, BMP, SVG und TIFF rendern.</p><p>- Bildauflösung, Qualität, Kompression und weitere Optionen festlegen.</p>|Nein|Ja|

## **Fazit**
Open XML SDK und Aspose.Slides stehen nicht im direkten Wettbewerb, da sie sehr unterschiedliche Bedürfnisse und Zielgruppen adressieren. Open XML SDK ist eine Klassenbibliothek, die einen stark typisierten Zugriff auf OOXML‑Dokumente ermöglicht. Aspose.Slides ist eine sehr nützliche Bibliothek zur Präsentationsverarbeitung, die umfassende Unterstützung für nahezu alle Microsoft PowerPoint‑Dateiformate bietet. Wenn Sie lediglich eine relativ einfache Programmieroperation an einem PPTX‑Dokument durchführen müssen, könnte das Open XML SDK eine geeignete Wahl sein. Mit dem Open XML SDK erledigen Sie mühelos einfache Aufgaben wie das Erzeugen eines einfachen PPTX‑Dokuments oder das Entfernen von Kommentaren, Kopf‑/Fußzeilen, das Extrahieren von Bildern und Ähnliches. Einige Aufgaben können mit dem Open XML SDK erreicht werden, aber nicht mit Aspose.Slides. Beispielsweise, wenn Sie direkten Zugriff auf die XML‑Elemente und -Attribute eines OOXML‑Dokuments benötigen, sollten Sie das Open XML SDK verwenden. Wenn Sie jedoch komplexe Vorgänge an Dokumenten ausführen müssen, wie die folgenden Aufgaben, ist Aspose.Slides Ihre beste Option:

- Unterstützung älterer PowerPoint‑Formate zusätzlich zu PPTX.
- Kopieren oder Klonen von Formen innerhalb von Folien, wobei Objekte, Stile und andere Formatierungen angemessen kombiniert werden.
- Ersetzen von formatiertem oder unformatiertem Text.
- Anwenden von Animationen und Nutzung von Verbindungsstücken mit Formen.
- Konvertieren eines Dokuments zu PDF oder XPS, sodass es exakt wie eine Konvertierung durch Microsoft PowerPoint aussieht.
- Entwicklung einer C++‑Anwendung sowohl für Desktop‑ als auch für Konsolen‑Umgebungen.