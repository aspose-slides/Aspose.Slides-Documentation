---
title: Warum nicht Open XML SDK
type: docs
weight: 120
url: /php-java/why-not-open-xml-sdk/
---

{{% alert color="primary" %}} 

Wir hören manchmal diese Frage:

**Warum sollten wir Aspose-Produkte anstelle des kostenlosen Open XML SDK verwenden?**

Diese Frage ist leicht zu beantworten: **Funktionen und Funktionalität**.

{{% /alert %}} 
## **Was ist Open XML SDK?**
Laut der [MSDN-Bibliothek](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) wird das Open XML SDK definiert als:

Das Open XML SDK 2.0 vereinfacht die Aufgabe, Open XML-Pakete und die zugrunde liegenden Open XML-Schematalemente innerhalb eines Pakets zu manipulieren. Das Open XML SDK 2.0 kapselt viele gängige Aufgaben ein, die Entwickler bei Open XML-Paketen ausführen, sodass Sie komplexe Operationen mit nur wenigen Zeilen Code durchführen können.

OOXML-Dokumente sind im Wesentlichen gezippte XML-Dateien, und das Open XML SDK ist eine Sammlung von Klassen, die es Ihnen ermöglichen, mit dem Inhalt von OOXML-Dokumenten in stark typisierter Weise zu arbeiten. Das heißt, anstatt eine Datei zu entpacken, um XML zu extrahieren, und dieses XML in einen DOM-Baum zu laden und direkt mit XML-Elementen und -Attributen zu arbeiten, stellt das Open XML SDK Klassen zur Verfügung, um dies zu tun.
## **Was ist Aspose.Slides?**
Aspose.Slides ist eine Klassenbibliothek, die Ihrer Anwendung die folgenden Präsentationsverarbeitungsaufgaben ermöglicht:

- Programmierung mit einem **Präsentations**-Objektmodell.
- Hochwertige Konvertierungen zwischen allen gängigen unterstützten PowerPoint-Präsentationsformaten, einschließlich Konvertierungen zu PDF, XPS und TIFF.
- Fähigkeit, Folienminiaturen in bekannten Formaten wie PNG, JPEG und BMP sowie Folienexport nach SVG zu erstellen.
- Fähigkeit, Präsentationen von Grund auf neu zu erstellen oder aus einem oder mehreren Dokumenten zu kombinieren.
- Unterstützung für das Hinzufügen von Animationen, Ole-Frames, Tabellen, Erstellen und Verwalten von Diagrammen.
- Verfügbarkeit umfangreicher Steuerungsoptionen zur Verwaltung der Textformatierung auf den Ebenen TextFrames, Absätze und Teile.

Für weitere Informationen zu den unterstützten Funktionen besuchen Sie bitte [Aspose.Slides-Funktionen](/slides/php-java/product-overview/).
## **Vergleich Open XML SDK und Aspose.Slides**
{{% alert color="primary" %}} 

Die folgende Tabelle vergleicht die Funktionen des Open XML SDK und von Aspose.Slides.

{{% /alert %}} 

|**Funktion oder Funktion Kategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertierung von PPT zu PPTX |Nein|Ja|
|<p>Hochgradige Programmierung mit einem Präsentations-Dokument-Objektmodell (DOM):</p><p>- Text suchen und ersetzen.</p><p>- Folien in Präsentationen zusammenstellen.</p>|Nein|Ja|
|Detaillierte Programmierung mit einem Dokument-Objektmodell, Zugang zu einzelnen Elementen und Formatierungen wie TextHolders, TextFrames, Absätzen und Teilen.|Ja|Ja|
|Niedriggradiger direkter und vollständiger Zugriff auf die zugrunde liegenden XML-Elemente und -Attribute wie Beziehungsidentifikatoren, Listenidentifikatoren eines OOXML-Dokuments.|Ja|Nein|
|<p>Rendering:</p><p>- Präsentationen in PDF, PDF-Notizen, XPS, TIFF-Bilder rendern.</p><p>- Foliensminiaturen in PNG, JPEG, BMP, SVG und TIFF rendern.</p><p>- Bildauflösung, Qualität, Kompression und andere Optionen festlegen.</p>|Nein|Ja |
|Unterstützte Plattformen|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|
## **Fazit**
{{% alert color="primary" %}} 

Das Open XML SDK und Aspose.Slides konkurrieren nicht direkt miteinander, da sie ganz unterschiedliche Bedürfnisse und Zielgruppen ansprechen. Das Open XML SDK ist eine Klassenbibliothek, die einen stark typisierten Ansatz zum Arbeiten mit OOXML-Dokumenten bietet. Aspose.Slides ist eine sehr nützliche Bibliothek zur Präsentationsverarbeitung, die eine großartige Unterstützung für nahezu alle Microsoft PowerPoint-Dateiformate bietet.

Wenn Sie lediglich eine ziemlich grundlegende Programmieroperation an einem PPTX-Dokument durchführen müssen, könnte das Open XML SDK eine geeignete Wahl sein. Mit dem Open XML SDK werden Sie recht komfortabel einfache Aufgaben wie das Erstellen eines einfachen PPTX-Dokuments oder das Entfernen von Kommentaren, Kopf- oder Fußzeilen, das Extrahieren von Bildern oder anderes durchführen können. Einige Aufgaben können mit dem Open XML SDK erreicht werden, können jedoch nicht mit Aspose.Slides erreicht werden. Beispielsweise, wenn Sie direkten Zugriff auf die XML-Elemente und -Attribute eines OOXML-Dokuments benötigen, sollten Sie das Open XML SDK verwenden. Wenn Sie jedoch komplexe Operationen an Dokumenten durchführen müssen, wie einige der folgenden Aufgaben, dann ist die Verwendung von Aspose.Slides Ihre beste Option:

- Unterstützung älterer PowerPoint-Formate zusätzlich zu PPTX.
- Formen innerhalb von Folien in einer Weise kopieren oder klonen, die Objekte, Stile und andere Formatierungen angemessen kombiniert.
- Formatierte oder unformatierte Texte ersetzen.
- Anwenden von Animationen und Verwendung von Verbindungsstücken mit verwendeten Formen.
- Konvertieren eines Dokuments in PDF, TIFF oder XPS, sodass es genau so aussieht, als hätte Microsoft PowerPoint es konvertiert.
- Entwicklung einer .NET- oder Java-Anwendung in Desktop- und webbasierenden Umgebungen.

{{% /alert %}}