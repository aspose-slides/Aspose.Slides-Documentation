---
title: Warum nicht Open XML SDK
type: docs
weight: 120
url: /de/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- Vergleich
- Präsentationsobjektmodell
- Hochqualitative Konvertierung
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, warum Aspose.Slides eine bessere Wahl als das kostenlose Open XML SDK ist: Funktionen vergleichen, automatisierungsfreie Konvertierung und umfangreiche Unterstützung für PPT, PPTX und ODP."
---
## **Übersicht**

Dieser Artikel erklärt, wann Entwickler Open XML SDK oder Aspose.Slides für die Arbeit mit Präsentationsdokumenten wählen könnten. Er beschreibt Open XML SDK als eine Bibliothek zum Manipulieren von OOXML‑Paketen und deren zugrunde liegenden XML‑Elementen, während Aspose.Slides als eine Bibliothek zur Präsentationsverarbeitung mit einem hoch‑leveligen Objektmodell und Unterstützung für viele PowerPoint‑bezogene Aufgaben vorgestellt wird.

Der Artikel vergleicht beide Optionen anhand unterstützter Formate, Programmiermodells, Rendering, Plattformunterstützung und gängiger Anwendungsfälle. Er verdeutlicht zudem, dass Open XML SDK für einfache PPTX‑Operationen oder den direkten Zugriff auf OOXML‑Elemente geeignet sein kann, während Aspose.Slides für komplexe Präsentationsaufgaben wie die Arbeit mit mehreren PowerPoint‑Formaten, das Kopieren oder Klonen von Formen, das Ersetzen von Text, das Anwenden von Animationen und das Konvertieren von Präsentationen in PDF, TIFF oder XPS besser geeignet ist.

## **Was ist Open XML SDK?**

Laut der [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) ist Open XML SDK definiert als: 

Das Open XML SDK 2.0 vereinfacht die Aufgabe, Open XML‑Pakete und die zugrunde liegenden Open XML‑Schematenelemente innerhalb eines Pakets zu manipulieren. Das Open XML SDK 2.0 kapselt viele gängige Aufgaben, die Entwickler an Open XML‑Paketen durchführen, sodass Sie komplexe Vorgänge mit nur wenigen Codezeilen ausführen können.

OOXML‑Dokumente sind im Wesentlichen gezippte XML‑Dateien und das Open XML SDK ist eine Sammlung von Klassen, die es ermöglicht, mit dem Inhalt von OOXML‑Dokumenten auf stark typisierte Weise zu arbeiten. Das bedeutet, anstatt eine Datei zu entzippen, um XML zu extrahieren, das XML in einen DOM‑Baum zu laden und direkt mit XML‑Elementen und -Attributen zu arbeiten, stellt das Open XML SDK Klassen bereit, die dies erledigen.

## **Was ist Aspose.Slides?**

Aspose.Slides ist eine Klassenbibliothek, die es Ihrer Anwendung ermöglicht, die folgenden Präsentationsverarbeitungsaufgaben auszuführen:

- Programmierung mit einem **Presentation**‑Objektmodell.
- Hochqualitative Konvertierungen zwischen allen gängigen unterstützten PowerPoint‑Präsentationsformaten, einschließlich Konvertierung nach PDF, XPS und TIFF.
- Fähigkeit, Folien‑Thumbnails in bekannten Formaten wie PNG, JPEG und BMP zu erzeugen sowie den Export von Folien nach SVG.
- Fähigkeit, Präsentationen von Grund auf neu zu erstellen oder durch Kombination aus einem oder mehreren Dokumenten.
- Unterstützung für das Hinzufügen von Animationen, Ole‑Frames, Tabellen, das Erstellen und Verwalten von Diagrammen.
- Verfügbarkeit umfangreicher Kontrolle für das Verwalten der Textformatierung auf Ebene von TextFrames, Absätzen und Portions.

Für weitere Details zu den unterstützten Funktionen besuchen Sie bitte [Aspose.Slides Features](/slides/de/php-java/product-overview/).

## **Open XML SDK mit Aspose.Slides vergleichen**

{{% alert color="info" %}} 
Die folgende Tabelle vergleicht die Funktionen von Open XML SDK und Aspose.Slides.
{{% /alert %}} 

|**Funktion oder Funktionskategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertierung von PPT zu PPTX|Nein|Ja|
|<p>Programmierung auf hoher Ebene mit einem Presentation Document Object Model (DOM):</p><p>- Text suchen und ersetzen.</p><p>- Folien in Präsentationen zusammenstellen.</p>|Nein|Ja|
|Detaillierte Programmierung mit einem Dokumentobjektmodell, Zugriff auf einzelne Elemente und Formatierungen wie TextHolders, TextFrames, Paragraphs und Portions.|Ja|Ja|
|Niedrigstufiger direkter und vollständiger Zugriff auf die zugrunde liegenden XML-Elemente und -Attribute wie Beziehungskennungen, Listenkkennungen eines OOXML‑Dokuments.|Ja|Nein|
|<p>Rendering:</p><p>- Präsentationen in PDF, PDF‑Notizen, XPS, TIFF‑Bilder rendern.</p><p>- Folien‑Thumbnails in PNG, JPEG, BMP, SVG und TIFF rendern.</p><p>- Bildauflösung, Qualität, Kompression und weitere Optionen festlegen.</p>|Nein|Ja|
|Unterstützte Plattformen|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Fazit**

{{% alert color="info" %}} 

Open XML SDK und Aspose.Slides konkurrieren nicht direkt miteinander, da sie unterschiedliche Bedürfnisse und Zielgruppen ansprechen. Open XML SDK ist eine Klassenbibliothek, die eine stark typisierte Möglichkeit bietet, mit OOXML‑Dokumenten zu arbeiten. Aspose.Slides ist eine sehr nützliche Bibliothek zur Präsentationsverarbeitung, die umfangreiche Unterstützung für nahezu alle Microsoft‑PowerPoint‑Dateiformate bietet.

Wenn Sie lediglich eine relativ einfache Programmieroperation an einem PPTX‑Dokument durchführen müssen, könnte Open XML SDK eine geeignete Wahl sein. Mit Open XML SDK können Sie problemlos einfache Aufgaben erledigen, wie das Erzeugen eines einfachen PPTX‑Dokuments oder das Entfernen von Kommentaren, Kopf‑/Fußzeilen, das Extrahieren von Bildern oder Ähnliches. Einige Aufgaben können mit Open XML SDK erreicht werden, jedoch nicht mit Aspose.Slides. Beispielsweise, wenn Sie direkten Zugriff auf die XML‑Elemente und -Attribute eines OOXML‑Dokuments benötigen, sollten Sie Open XML SDK verwenden. Wenn Sie jedoch komplexe Vorgänge an Dokumenten ausführen müssen, wie einige der folgenden Aufgaben, ist die Verwendung von Aspose.Slides Ihre beste Option:

- Unterstützung älterer PowerPoint‑Formate zusätzlich zu PPTX.
- Formen in Folien kopieren oder klonen, wobei Objekte, Stile und andere Formatierungen angemessen kombiniert werden.
- Formatierten oder unformatierten Text ersetzen.
- Animationen anwenden und Verbinder mit Formen verwenden.
- Ein Dokument in PDF, TIFF oder XPS konvertieren, sodass es exakt so aussieht, wie Microsoft PowerPoint es konvertieren würde.
- Entwicklung einer .NET‑ oder Java‑Anwendung in Desktop‑ und webbasierten Umgebungen.

{{% /alert %}}