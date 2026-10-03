---
title: Warum nicht Open XML SDK
type: docs
weight: 180
url: /de/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- Vergleich
- Präsentationsobjektmodell
- hochwertige Konvertierung
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, warum Aspose.Slides eine bessere Wahl als das kostenlose Open XML SDK ist: vergleichen Sie Funktionen, automatisierungsfreie Konvertierung und breite Unterstützung für PPT, PPTX und ODP."
---
## **Übersicht**

Dieser Artikel erklärt, wann Entwickler Open XML SDK oder Aspose.Slides für die Arbeit mit Präsentationsdokumenten wählen könnten. Er beschreibt Open XML SDK als Bibliothek zum Manipulieren von OOXML‑Paketen und deren zugrunde liegenden XML‑Elementen, während Aspose.Slides als Präsentationsverarbeitungsbibliothek mit einem hochrangigen Objektmodell und Unterstützung für viele PowerPoint‑bezogene Aufgaben präsentiert wird.

Der Artikel vergleicht beide Optionen anhand unterstützter Formate, Programmiermodells, Rendering, Plattformunterstützung und typischer Anwendungsfälle. Außerdem wird geklärt, dass Open XML SDK für grundlegende PPTX‑Operationen oder den direkten Zugriff auf OOXML‑Elemente geeignet sein kann, während Aspose.Slides besser für komplexe Präsentationsaufgaben ist, wie das Arbeiten mit mehreren PowerPoint‑Formaten, das Kopieren oder Klonen von Shapes, das Ersetzen von Text, das Anwenden von Animationen und das Konvertieren von Präsentationen in PDF, TIFF oder XPS.

## **Was ist Open XML SDK?**
Laut der [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) ist Open XML SDK definiert als:

Der Open XML SDK 2.0 vereinfacht das Manipulieren von Open XML‑Paketen und den zugrunde liegenden Open XML‑Schema‑Elementen innerhalb eines Pakets. Der Open XML SDK 2.0 kapselt viele gängige Aufgaben, die Entwickler an Open XML‑Paketen ausführen, sodass Sie komplexe Vorgänge mit nur wenigen Codezeilen erledigen können.

OOXML‑Dokumente sind im Wesentlichen gezippte XML‑Dateien und Open XML SDK ist eine Sammlung von Klassen, die es Ihnen ermöglicht, mit dem Inhalt von OOXML‑Dokumenten stark typisiert zu arbeiten. Das bedeutet, anstatt eine Datei zu entzippen, das XML zu extrahieren, es in einen DOM‑Baum zu laden und direkt mit XML‑Elementen und -Attributen zu arbeiten, stellt Open XML SDK Klassen zur Verfügung, die dies erledigen.

## **Was ist Aspose.Slides?**
Aspose.Slides ist eine Klassenbibliothek, die Ihrer Anwendung die folgenden Präsentationsverarbeitungsaufgaben ermöglicht:

- Programmierung mit einem **Presentation**‑Objektmodell.
- Hochwertige Konvertierungen zwischen allen gängigen unterstützten PowerPoint‑Präsentationsformaten, einschließlich Konvertierung zu PDF, XPS und TIFF.
- Möglichkeit, Folien‑Thumbnails in bekannten Formaten wie PNG, JPEG und BMP zu erzeugen sowie Folien‑Export nach SVG.
- Möglichkeit, Präsentationen von Grund auf neu zu erstellen oder durch Kombinieren aus einem oder mehreren Dokumenten zusammenzustellen.
- Unterstützung für das Hinzufügen von Animationen, Ole‑Frames, Tabellen, das Erstellen und Verwalten von Diagrammen.
- Umfangreiche Kontrolle für die Verwaltung der Textformatierung auf Ebene von TextFrames, Absätzen und Portionen.

Weitere Details zu den unterstützten Funktionen finden Sie unter [Aspose.Slides Features](/slides/de/java/product-overview/).

## **Open XML SDK mit Aspose.Slides vergleichen**
{{% alert color="info" title="Note" %}}

Die folgende Tabelle vergleicht die Funktionen von Open XML SDK und Aspose.Slides.

{{% /alert %}}

|**Feature oder Feature-Kategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertierung von PPT nach PPTX|Nein|Ja|
|<p>Hochrangige Programmierung mit einem Presentation Document Object Model (DOM):</p><p>- Suchen und Ersetzen von Text.</p><p>- Zusammenstellen von Folien in Präsentationen.</p>|Nein|Ja|
|Detaillierte Programmierung mit einem Dokumentobjektmodell, Zugriff auf einzelne Elemente und Formatierungen wie TextHolders, TextFrames, Absätze und Portionen.|Ja|Ja|
|Niedrigstufiger direkter und vollständiger Zugriff auf die zugrunde liegenden XML‑Elemente und -Attribute wie Beziehungs‑IDs, Listen‑IDs eines OOXML‑Dokuments.|Ja|Nein|
|<p>Rendering:</p><p>- Rendern von Präsentationen zu PDF, PDF‑Notizen, XPS, TIFF‑Bildern.</p><p>- Rendern von Folien‑Thumbnails zu PNG, JPEG, BMP, SVG und TIFF.</p><p>- Angabe von Bildauflösung, Qualität, Kompression und weiteren Optionen. </p>|Nein|Ja |
|Unterstützte Plattformen|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Fazit**
{{% alert color="info" title="Note" %}}

Open XML SDK und Aspose.Slides stehen nicht in direktem Wettbewerb, da sie unterschiedliche Bedürfnisse und Zielgruppen ansprechen. Open XML SDK ist eine Klassenbibliothek, die eine stark typisierte Arbeit mit OOXML‑Dokumenten ermöglicht. Aspose.Slides ist eine sehr nützliche Bibliothek zur Präsentationsverarbeitung, die umfassende Unterstützung für nahezu alle Microsoft‑PowerPoint-Dateiformate bietet.

Wenn Sie lediglich eine relativ einfache Programmieroperation an einem PPTX‑Dokument durchführen möchten, könnte Open XML SDK die passende Wahl sein. Mit Open XML SDK können Sie problemlos einfache Aufgaben wie das Erzeugen eines einfachen PPTX‑Dokuments, das Entfernen von Kommentaren, Kopf‑/Fußzeilen, das Extrahieren von Bildern und Ähnliches erledigen. Einige Aufgaben können mit Open XML SDK erreicht werden, aber nicht mit Aspose.Slides. Beispielsweise, wenn Sie direkten Zugriff auf die XML‑Elemente und -Attribute eines OOXML‑Dokuments benötigen, sollten Sie Open XML SDK verwenden. Wenn Sie jedoch komplexe Vorgänge an Dokumenten durchführen müssen, wie die folgenden Aufgaben, ist die Verwendung von Aspose.Slides die beste Option:

- Unterstützung älterer PowerPoint‑Formate zusätzlich zu PPTX.
- Kopieren oder Klonen von Shapes in Folien auf eine Weise, die Objekte, Stile und andere Formatierungen angemessen kombiniert.
- Ersetzen von formatiertem oder unformatiertem Text.
- Anwenden von Animationen und Nutzung von Verbindungslinien mit Shapes.
- Konvertieren eines Dokuments zu PDF, TIFF oder XPS, sodass es exakt wie die Konvertierung durch Microsoft PowerPoint aussieht.
- Entwicklung einer .NET‑ oder Java‑Anwendung sowohl für Desktop‑ als auch für webbasierte Umgebungen.

{{% /alert %}}