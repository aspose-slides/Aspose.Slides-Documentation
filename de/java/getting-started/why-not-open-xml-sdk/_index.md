---
title: Warum nicht Open XML SDK
type: docs
weight: 120
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
description: "Erfahren Sie, warum Aspose.Slides die bessere Wahl gegenüber dem kostenlosen Open XML SDK ist: vergleichen Sie Funktionen, automatisierungsfreie Konvertierung und umfassende Unterstützung für PPT, PPTX und ODP."
---
## **Übersicht**

Dieser Artikel erklärt, wann Entwickler Open XML SDK oder Aspose.Slides für die Arbeit mit Präsentationsdokumenten wählen könnten. Er beschreibt Open XML SDK als Bibliothek zum Manipulieren von OOXML‑Paketen und deren zugrunde liegenden XML‑Elementen, während Aspose.Slides als Präsentationsverarbeitungsbibliothek mit einem hochrangigen Objektmodell und Unterstützung für viele PowerPoint‑bezogene Aufgaben präsentiert wird.

Der Artikel vergleicht beide Optionen anhand unterstützter Formate, Programmiermodells, Rendering, Plattformunterstützung und typischer Anwendungsfälle. Außerdem wird klargestellt, dass Open XML SDK für grundlegende PPTX‑Operationen oder den direkten Zugriff auf OOXML‑Elemente geeignet sein kann, während Aspose.Slides besser für komplexe Präsentationsaufgaben geeignet ist, wie das Arbeiten mit mehreren PowerPoint‑Formaten, das Kopieren oder Klonen von Shapes, das Ersetzen von Text, das Anwenden von Animationen und das Konvertieren von Präsentationen zu PDF, TIFF oder XPS.

## **Was ist Open XML SDK?**
Laut der [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) ist Open XML SDK definiert als:

Der Open XML SDK 2.0 vereinfacht die Aufgabe, Open XML‑Pakete und die zugrunde liegenden Open XML‑Schemas innerhalb eines Pakets zu manipulieren. Der Open XML SDK 2.0 kapselt viele gängige Aufgaben, die Entwickler an Open XML‑Paketen ausführen, sodass Sie komplexe Vorgänge mit nur wenigen Code‑Zeilen erledigen können.

OOXML‑Dokumente sind im Wesentlichen gezippte XML‑Dateien, und Open XML SDK ist eine Sammlung von Klassen, die es Ihnen ermöglichen, mit dem Inhalt von OOXML‑Dokumenten typsicher zu arbeiten. Das bedeutet, anstatt eine Datei zu entzippen, um XML zu extrahieren, dieses XML in einen DOM‑Baum zu laden und direkt mit XML‑Elementen und Attributen zu arbeiten, stellt Open XML SDK Klassen bereit, die dies übernehmen.

## **Was ist Aspose.Slides?**
Aspose.Slides ist eine Klassenbibliothek, die Ihrer Anwendung ermöglicht, die folgenden Präsentationsverarbeitungsaufgaben auszuführen:

- Programmierung mit einem **Presentation**‑Objektmodell.
- Hochwertige Konvertierungen zwischen allen gängigen unterstützten PowerPoint‑Präsentationsformaten, einschließlich Konvertierung zu PDF, XPS und TIFF.
- Möglichkeit, Folien‑Thumbnails in bekannten Formaten wie PNG, JPEG und BMP zu erzeugen sowie Folien nach SVG zu exportieren.
- Möglichkeit, Präsentationen von Grund auf neu zu erstellen oder durch Kombinieren aus einem oder mehreren Dokumenten zu bauen.
- Unterstützung für das Hinzufügen von Animationen, Ole‑Frames, Tabellen, das Erstellen und Verwalten von Diagrammen.
- Umfangreiche Kontrolle für die Verwaltung der Textformatierung auf den Ebenen TextFrames, Absätze und Portionen.

Für weitere Details zu den unterstützten Funktionen besuchen Sie bitte [Aspose.Slides Features](/slides/de/java/product-overview/).

## **Open XML SDK mit Aspose.Slides vergleichen**
{{% alert color="info" %}} 

Die folgende Tabelle vergleicht die Funktionen von Open XML SDK und Aspose.Slides.

{{% /alert %}} 

|**Funktion oder Funktionskategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertierung von PPT zu PPTX|Nein|Ja|
|<p>Hochrangige Programmierung mit einem Presentation Document Object Model (DOM):</p><p>- Suchen und Ersetzen von Text.</p><p>- Zusammenstellen von Folien in Präsentationen.</p>|Nein|Ja|
|Detaillierte Programmierung mit einem Dokumenten‑Objektmodell, Zugriff auf einzelne Elemente und Formatierungen wie TextHolders, TextFrames, Absätze und Portionen.|Ja|Ja|
|Niedrig‑rangiger direkter und vollständiger Zugriff auf die zugrunde liegenden XML‑Elemente und Attribute wie Beziehungs‑IDs, Listen‑IDs eines OOXML‑Dokuments.|Ja|Nein|
|<p>Rendering:</p><p>- Rendern von Präsentationen zu PDF, PDF‑Notizen, XPS, TIFF‑Bildern.</p><p>- Rendern von Folien‑Thumbnails zu PNG, JPEG, BMP, SVG und TIFF.</p><p>- Festlegen von Bildauflösung, Qualität, Kompression und anderen Optionen.</p>|Nein|Ja|
|Unterstützte Plattformen|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|

## **Fazit**
{{% alert color="info" %}} 

Open XML SDK und Aspose.Slides stehen nicht in direkter Konkurrenz, da sie unterschiedliche Bedürfnisse und Zielgruppen ansprechen. Open XML SDK ist eine Klassenbibliothek, die einen typsicheren Weg zum Arbeiten mit OOXML‑Dokumenten bietet. Aspose.Slides ist eine sehr nützliche Bibliothek zur Präsentationsverarbeitung, die umfangreiche Unterstützung für nahezu alle Microsoft‑PowerPoint‑Dateiformate bereitstellt.

Wenn Sie lediglich eine recht einfache Programmieraufgabe an einem PPTX‑Dokument erledigen müssen, könnte Open XML SDK die geeignete Wahl sein. Mit Open XML SDK können Sie problemlos einfache Aufgaben wie das Erzeugen eines einfachen PPTX‑Dokuments oder das Entfernen von Kommentaren, Kopf‑/Fußzeilen, das Extrahieren von Bildern usw. durchführen. Einige Aufgaben können mit Open XML SDK erledigt werden, die mit Aspose.Slides nicht möglich sind. Beispiel: Wenn Sie direkten Zugriff auf die XML‑Elemente und Attribute eines OOXML‑Dokuments benötigen, sollten Sie Open XML SDK verwenden. Wenn Sie jedoch komplexe Vorgänge an Dokumenten ausführen müssen, wie einige der folgenden Aufgaben, ist Aspose.Slides die beste Option:

- Unterstützung älterer PowerPoint‑Formate zusätzlich zu PPTX.
- Kopieren oder Klonen von Shapes in Folien, wobei Objekte, Stile und andere Formatierungen auf geeignete Weise kombiniert werden.
- Ersetzen von formatiertem oder unformatiertem Text.
- Anwenden von Animationen und Nutzung von Verbindern mit Shapes.
- Konvertieren eines Dokuments zu PDF, TIFF oder XPS, sodass es exakt wie bei einer Konvertierung durch Microsoft PowerPoint aussieht.
- Entwicklung einer .NET‑ oder Java‑Anwendung sowohl in Desktop‑ als auch in webbasierten Umgebungen.

{{% /alert %}}