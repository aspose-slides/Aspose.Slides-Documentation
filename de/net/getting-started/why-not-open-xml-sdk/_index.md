---
title: Warum nicht Open XML SDK
type: docs
weight: 50
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
description: "Erfahren Sie, warum Aspose.Slides eine bessere Wahl als das kostenlose Open XML SDK ist: Funktionen vergleichen, automatisierungsfreie Konvertierung und breite Unterstützung für PPT, PPTX und ODP."
---
## **Übersicht**

Dieser Artikel erklärt, wann Entwickler das Open XML SDK oder Aspose.Slides für die Arbeit mit Präsentationsdokumenten wählen könnten. Er beschreibt das Open XML SDK als Bibliothek zum Manipulieren von OOXML‑Paketen und deren zugrunde liegenden XML‑Elementen, während Aspose.Slides als Präsentations‑Verarbeitungsbibliothek mit einem hoch‑leveligen Objektmodell und Unterstützung für viele PowerPoint‑bezogene Aufgaben präsentiert wird.

Der Artikel vergleicht beide Optionen anhand unterstützter Formate, Programmiermodells, Rendering‑ und Druckfunktionen, Plattformunterstützung und typischer Anwendungsfälle. Außerdem wird klargestellt, dass das Open XML SDK für einfache PPTX‑Operationen oder den direkten Zugriff auf OOXML‑Elemente geeignet sein kann, während Aspose.Slides für komplexe Präsentationsaufgaben wie die Arbeit mit mehreren PowerPoint‑Formaten, das Kopieren oder Klonen von Formen, das Ersetzen von Text, das Anwenden von Animationen und das Konvertieren von Präsentationen zu PDF, TIFF oder XPS besser geeignet ist.

## **Was ist Open XML SDK?**
Manchmal erhalten wir diese Frage: *Warum sollten wir Aspose‑Produkte statt des kostenlosen Open XML SDK verwenden?* 

Wir finden es einfach, diese Frage anhand von Funktionen und Merkmalen zu beantworten. 

Laut der [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) wird das Open XML SDK folgendermaßen definiert: 

> „Das Open XML SDK 2.0 vereinfacht die Aufgabe, Open XML‑Pakete und die zugrunde liegenden Open XML‑Schema‑Elemente innerhalb eines Pakets zu manipulieren. Das Open XML SDK 2.0 fasst viele gängige Aufgaben zusammen, die Entwickler an Open XML‑Paketen ausführen, sodass Sie komplexe Vorgänge mit nur wenigen Codezeilen durchführen können. OOXML‑Dokumente sind im Wesentlichen gezippte XML‑Dateien und das Open XML SDK ist eine Sammlung von Klassen, die es Ihnen ermöglicht, mit dem Inhalt von OOXML‑Dokumenten stark typisiert zu arbeiten. Das bedeutet, anstatt eine Datei zu entzippen, XML zu extrahieren, dieses XML in einen DOM‑Baum zu laden und direkt mit XML‑Elementen und Attributen zu arbeiten, stellt das Open XML SDK Klassen bereit, die das erledigen.“

## **Was ist Aspose.Slides?**
Aspose.Slides ist eine Klassenbibliothek, die Anwendungen folgende Präsentations‑Verarbeitungsaufgaben ermöglicht: 

- Programmierung mit einem Präsentations‑Objektmodell.  
- Hochwertige Konvertierungen aller gängigen unterstützten PowerPoint‑Präsentationsformate, einschließlich Konvertierung zu PDF, XPS, TIFF und Druck.  
- Erzeugen von Folien‑Thumbnails in bekannten Formaten wie PNG, JPEG und BMP sowie Export von Folien nach SVG.  
- Erstellen von Präsentationen von Grund auf oder durch Kombinieren von Elementen aus einem oder mehreren Dokumenten.  
- Hinzufügen von Animationen, OLE‑Frames, Tabellen, Erstellen und Verwalten von Diagrammen.  
- Umfassende Kontrolle und Verwaltung der Textformatierung auf TextFrame‑, Absatz‑ und Portion‑Ebene.  

Weitere Details zu den verfügbaren Funktionen finden Sie auf der Seite [Aspose.Slides Features](/slides/de/net/product-overview/).

## **Open XML SDK mit Aspose.Slides vergleichen**
Diese Tabelle vergleicht die Fähigkeiten und Funktionen von Open XML SDK mit denen von Aspose.Slides.

|**Feature oder Feature‑Kategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertierung von PPT zu PPTX|Nein|Ja|
|<p>High‑Level‑Programmierung mit einem Presentation Document Object Model (DOM):</p><p>- Suchen und Ersetzen von Text.</p><p>- Zusammenstellen von Folien in Präsentationen.</p>|Nein|Ja|
|Detaillierte Programmierung mit einem Dokument‑Objektmodell; Zugriff auf einzelne Elemente und Formatierungen wie TextHolders, TextFrames, Paragraphs und Portions.|Ja|Ja|
|Low‑Level‑direkter und vollständiger Zugriff auf die zugrunde liegenden XML‑Elemente und -Attribute wie Beziehungs‑IDs, Listen‑IDs eines OOXML‑Dokuments.|Ja|Nein|
|<p>Rendering und Druck:</p><p>- Rendern von Präsentationen zu PDF, PDF‑Notes, XPS, TIFF‑Bildern.</p><p>- Rendern von Folien‑Thumbnails zu PNG, JPEG, BMP, SVG und TIFF.</p><p>- Festlegen von Bildauflösung, Qualität, Kompression und anderen Optionen.</p><p>- Drucken von Präsentationen über die .NET‑Druckinfrastruktur. Die Komponente verfügt über eine integrierte Druckmethode, um die Präsentationen wie in der Druckvorschau von MS PowerPoint anzuzeigen.</p>|Nein|Ja|
|Unterstützte Plattformen|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Fazit**
Open XML SDK und Aspose.Slides stehen nicht in direktem Wettbewerb, da sie deutlich unterschiedliche Bedürfnisse bedienen und unterschiedliche Zielgruppen ansprechen. 

{{% alert color="primary" %}} 

Open XML SDK ist eine Klassenbibliothek, die eine stark typisierte Vorgehensweise für die Arbeit mit OOXML‑Dokumenten bietet, während Aspose.Slides eine äußerst nützliche Bibliothek zur Präsentationsverarbeitung ist, die großartige Unterstützung für nahezu alle Microsoft PowerPoint‑Dateiformate liefert. 

{{% /alert %}} 

Wenn Ihr Workflow eine grundlegende Programmieroperation an einem PPTX‑Dokument ist, könnte das Open XML SDK eine gute Wahl sein. Mit dem Open XML SDK sollten Sie in der Lage sein, einfache Aufgaben wie das Erzeugen eines simplen PPTX‑Dokuments oder das Entfernen von Kommentaren, Kopf‑/Fußzeilen, das Extrahieren von Bildern usw. durchzuführen. Bestimmte Aufgaben können mit dem Open XML SDK ausgeführt werden, jedoch nicht mit Aspose.Slides. Beispielsweise sollten Sie das Open XML SDK verwenden, wenn Sie direkt auf die XML‑Elemente und -Attribute eines OOXML‑Dokuments zugreifen müssen. 

Wenn Sie komplexe Aufgaben an Dokumenten erledigen müssen – wie die unten aufgeführten – dann ist Aspose.Slides die beste Option. 

- Vorgänge, die ältere PowerPoint‑Formate (und PPTX) betreffen.  
- Kopieren oder Klonen von Formen innerhalb von Folien in einer Weise, die Objekte, Stile und andere Formatierungselemente angemessen kombiniert.  
- Ersetzen von formatiertem oder nicht formatiertem Text.  
- Anwenden von Animationen und Verwenden von Verbindungs‑Elementen mit Formen.  
- Konvertieren eines Dokuments zu PDF, TIFF oder XPS, sodass das Ergebnis wie bei einer Konvertierung durch Microsoft PowerPoint aussieht.  
- Entwicklung einer .NET‑ oder Java‑Anwendung sowohl für Desktop‑ als auch für webbasierte Umgebungen.