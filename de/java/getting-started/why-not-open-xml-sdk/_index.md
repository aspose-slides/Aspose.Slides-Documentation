---
title: Warum nicht Open XML SDK
type: docs
weight: 120
url: /de/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- Vergleich
- Präsentationsobjektmodell
- Hochqualitative Konvertierung
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, warum Aspose.Slides die bessere Wahl als das kostenlose Open XML SDK ist: Funktionen vergleichen, automatisierungsfreie Konvertierung und breite Unterstützung für PPT, PPTX und ODP."
---
## **Übersicht**

Dieser Artikel erklärt, wann Entwickler Open XML SDK oder Aspose.Slides für die Arbeit mit Präsentationsdokumenten wählen könnten. Er beschreibt Open XML SDK als eine Bibliothek zum Manipulieren von OOXML‑Paketen und deren zugrunde liegenden XML‑Elementen, während Aspose.Slides als eine Präsentations‑Verarbeitungsbibliothek mit einem hoch‑leveligen Objektmodell und Unterstützung für viele PowerPoint‑bezogene Aufgaben präsentiert wird.

Der Artikel vergleicht beide Optionen anhand von unterstützten Formaten, Programmiermodell, Render‑ und Druck‑Fähigkeiten, Plattformunterstützung und typischen Anwendungsfällen. Außerdem wird klargestellt, dass Open XML SDK für grundlegende PPTX‑Operationen oder direkten Zugriff auf OOXML‑Elemente geeignet sein kann, während Aspose.Slides besser für komplexe Präsentationsaufgaben geeignet ist, wie das Arbeiten mit mehreren PowerPoint‑Formaten, das Kopieren oder Klonen von Formen, das Ersetzen von Text, das Anwenden von Animationen und das Konvertieren von Präsentationen zu PDF, TIFF oder XPS.

## **Was ist Open XML SDK?**
Laut der [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) ist Open XML SDK definiert als:

Das Open XML SDK 2.0 vereinfacht die Aufgabe, Open XML‑Pakete und die zugrunde liegenden Open XML‑Schema‑Elemente innerhalb eines Pakets zu manipulieren. Das Open XML SDK 2.0 fasst viele gängige Aufgaben zusammen, die Entwickler an Open XML‑Paketen ausführen, sodass Sie komplexe Vorgänge mit nur wenigen Codezeilen erledigen können.

OOXML‑Dokumente sind im Wesentlichen komprimierte XML‑Dateien, und Open XML SDK ist eine Sammlung von Klassen, die es Ihnen ermöglicht, mit dem Inhalt von OOXML‑Dokumenten typensicher zu arbeiten. Das bedeutet, anstatt eine Datei zu entpacken, XML zu extrahieren, dieses XML in einen DOM‑Baum zu laden und direkt mit XML‑Elementen und Attributen zu arbeiten, stellt Open XML SDK Klassen bereit, die dies übernehmen.

## **Was ist Aspose.Slides?**
Aspose.Slides ist eine Klassenbibliothek, die Ihrer Anwendung ermöglicht, die folgenden Präsentations‑Verarbeitungsaufgaben auszuführen:

- Programmierung mit einem **Presentation**‑Objektmodell.
- Hochqualitative Konvertierungen zwischen allen gängigen unterstützten PowerPoint‑Präsentationsformaten, einschließlich Konvertierung zu PDF, XPS und TIFF.
- Möglichkeit, Folien‑Thumbnails in bekannten Formaten wie PNG, JPEG und BMP zu erzeugen sowie Folienexport nach SVG.
- Möglichkeit, Präsentationen von Grund auf neu zu erstellen oder durch Kombinieren aus einem oder mehreren Dokumenten zusammenzustellen.
- Unterstützung für das Hinzufügen von Animationen, Ole‑Frames, Tabellen, das Erstellen und Verwalten von Diagrammen.
- Umfangreiche Kontrolle für die Verwaltung der Textformatierung auf TextFrame‑, Absatz‑ und Portion‑Ebene.

Weitere Details zu den unterstützten Funktionen finden Sie unter [Aspose.Slides Features](/slides/de/java/product-overview/).

## **Open XML SDK mit Aspose.Slides vergleichen**
{{% alert color="info" %}} 

Die folgende Tabelle vergleicht Funktionen von Open XML SDK und Aspose.Slides.

{{% /alert %}} 

|**Feature oder Feature‑Kategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertierung von PPT zu PPTX|Nein|Ja|
|<p>Hoch‑levelige Programmierung mit einem Presentation Document Object Model (DOM):</p><p>- Suchen und Ersetzen von Text.</p><p>- Zusammenstellen von Folien in Präsentationen.</p>|Nein|Ja|
|Detaillierte Programmierung mit einem Dokument‑Objektmodell, Zugriff auf einzelne Elemente und Formatierungen wie TextHolders, TextFrames, Paragraphs und Portions.|Ja|Ja|
|Niedrig‑leveliger direkter und vollständiger Zugriff auf die zugrunde liegenden XML‑Elemente und Attribute wie Beziehungs‑IDs, List‑IDs eines OOXML‑Dokuments.|Ja|Nein|
|<p>Rendering:</p><p>- Rendern von Präsentationen zu PDF, PDF‑Notes, XPS, TIFF‑Bildern.</p><p>- Rendern von Folien‑Thumbnails zu PNG, JPEG, BMP, SVG und TIFF.</p><p>- Angabe von Bildauflösung, Qualität, Kompression und anderen Optionen.</p>|Nein|Ja |
|Unterstützte Plattformen|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Fazit**
{{% alert color="info" %}} 

Open XML SDK und Aspose.Slides konkurrieren nicht direkt, da sie sehr unterschiedliche Bedürfnisse und Zielgruppen ansprechen. Open XML SDK ist eine Klassenbibliothek, die einen typensicheren Zugriff auf OOXML‑Dokumente ermöglicht. Aspose.Slides ist eine äußerst nützliche Bibliothek zur Präsentationsverarbeitung, die umfangreiche Unterstützung für fast alle Microsoft PowerPoint‑Dateiformate bietet.

Wenn Sie lediglich eine relativ einfache Programmieroperation an einem PPTX‑Dokument durchführen möchten, könnte Open XML SDK die passende Wahl sein. Mit Open XML SDK können Sie problemlos einfache Aufgaben erledigen, wie das Erzeugen eines simplen PPTX‑Dokuments, das Entfernen von Kommentaren, Kopf‑/Fußzeilen, das Extrahieren von Bildern und Ähnliches. Einige Aufgaben lassen sich mit Open XML SDK erreichen, aber nicht mit Aspose.Slides. Beispielsweise, wenn Sie direkten Zugriff auf die XML‑Elemente und Attribute eines OOXML‑Dokuments benötigen, sollten Sie Open XML SDK verwenden. Wenn Sie jedoch komplexe Vorgänge an Dokumenten ausführen müssen, wie die folgenden Aufgaben, ist Aspose.Slides die beste Option:

- Unterstützung älterer PowerPoint‑Formate zusätzlich zu PPTX.
- Kopieren oder Klonen von Formen innerhalb von Folien, wobei Objekte, Stile und weitere Formatierungen angemessen kombiniert werden.
- Ersetzen von formatiertem oder unformatiertem Text.
- Anwenden von Animationen und Nutzung von Verbindungs‑Elementen mit Formen.
- Konvertieren eines Dokuments zu PDF, TIFF oder XPS, sodass es exakt wie in Microsoft PowerPoint aussieht.
- Entwicklung einer .NET‑ oder Java‑Anwendung sowohl für Desktop‑ als auch für Web‑Umgebungen.

{{% /alert %}}