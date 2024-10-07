---
title: Warum nicht Open XML SDK
type: docs
weight: 50
url: /net/why-not-open-xml-sdk/
---

## **Was ist Open XML SDK?**
Manchmal stellen wir diese Frage: *Warum sollten wir Aspose-Produkte anstelle des kostenlosen Open XML SDK verwenden?* 

Wir finden es einfach, diese Frage in Bezug auf Funktionen und Funktionalitäten zu beantworten. 

Laut der [MSDN-Bibliothek](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) wird Open XML SDK folgendermaßen definiert: 

> "Das Open XML SDK 2.0 vereinfacht die Aufgabe, Open XML-Pakete und die zugrunde liegenden Open XML-Schemaelemente innerhalb eines Pakets zu manipulieren. Das Open XML SDK 2.0 kapselt viele gängige Aufgaben, die Entwickler an Open XML-Paketen ausführen, sodass Sie komplexe Operationen mit nur wenigen Codezeilen durchführen können. OOXML-Dokumente sind im Wesentlichen gezippte XML-Dateien, und das Open XML SDK ist eine Sammlung von Klassen, die es Ihnen ermöglicht, mit dem Inhalt von OOXML-Dokumenten auf stark typisierte Weise zu arbeiten. Das bedeutet, anstatt eine Datei zu entpacken, um XML zu extrahieren, dieses XML in einen DOM-Baum zu laden und direkt mit XML-Elementen und -Attributen zu arbeiten, bietet das Open XML SDK Klassen, um dies zu tun."

## **Was ist Aspose.Slides?**
Aspose.Slides ist eine Klassenbibliothek, die Anwendungen ermöglicht, diese Präsentationsverarbeitungsaufgaben durchzuführen: 

- Programmierung mit einem Präsentationsobjektmodell.

- Hochwertige Konvertierungen, die alle gängigen unterstützten PowerPoint-Präsentationsformate umfassen, einschließlich Konvertierung in PDF, XPS, TIFF und Drucken.

- Generierung von Folien-Thumbnails in gängigen Formaten wie PNG, JPEG und BMP sowie das Exportieren von Folien nach SVG.

- Erstellen von Präsentationen von Grund auf oder durch Kombinieren von Elementen aus einem oder mehreren Dokumenten.

- Hinzufügen von Animationen, OLE-Frames, Tabellen, Erstellen und Verwalten von Diagrammen.

- Kontrolle (umfassende Kontrolle) und Verwaltung der Textformatierung auf den Ebenen TextFrames, Paragraphen und Portions. 

  Für weitere Einzelheiten zu den verfügbaren Funktionen siehe bitte die [Aspose.Slides-Funktionen](/slides/net/product-overview/) Seite.
## **Vergleich Open XML SDK mit Aspose.Slides**
Diese Tabelle vergleicht die Fähigkeiten und Funktionen von Open XML SDK mit Aspose.Slides.

|**Funktion oder Funktionskategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertierung von PPT nach PPTX |Nein|Ja|
|<p>Hochgradige Programmierung mit einem Präsentationsdokumentobjektmodell (DOM): </p><p>- Texte suchen und ersetzen.</p><p>- Folien in Präsentationen zusammenstellen.</p>|Nein|Ja|
|Detaillierte Programmierung mit einem Dokumentenobjektmodell; Zugang zu einzelnen Elementen und Formatierungen wie TextHolders, TextFrames, Paragraphen und Portions.|Ja|Ja|
|Niedriggradiger direkter und vollständiger Zugriff auf die zugrunde liegenden XML-Elemente und -Attribute wie Beziehungs-IDs, Listen-IDs eines OOXML-Dokuments.|Ja|Nein|
|<p>Rendering und Drucken:</p><p>- Präsentationen in PDF, PDF-Notizen, XPS, TIFF-Bilder rendern.</p><p>- Folien-Thumbnails in PNG, JPEG, BMP, SVG und TIFF rendern.</p><p>- Bildauflösung, Qualität, Kompression und andere Optionen angeben.</p><p>- Präsentationen mit der .NET-Druckinfrastruktur drucken. Die Komponente hat eine integrierte Druckmethode, um die Präsentationen so zu drucken, wie sie in der Druckvorschau von MS PowerPoint angezeigt werden.</p>|Nein|Ja|
|Unterstützte Plattformen|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Fazit**
Open XML SDK und Aspose.Slides konkurrieren nicht direkt, da sie erheblich unterschiedliche Bedürfnisse ansprechen und sich an unterschiedliche Zielgruppen richten. 

{{% alert color="primary" %}} 

Open XML SDK ist eine Klassenbibliothek, die einen stark typisierten Weg für die Arbeit mit OOXML-Dokumenten bietet, während Aspose.Slides eine unglaublich nützliche Präsentationsverarbeitungslibrary ist, die großartige Unterstützung für fast alle Microsoft PowerPoint-Dateiformate bietet. 

{{% /alert %}} 

Wenn Ihr Workflow eine grundlegende Programmieroperation an einem PPTX-Dokument ist, dann könnte Open XML SDK eine gute Wahl sein. Mit Open XML SDK sollten Sie sich wohlfühlen, einfache Aufgaben wie das Erstellen eines einfachen PPTX-Dokuments oder das Entfernen von Kommentaren, Kopf- und Fußzeilen, das Extrahieren von Bildern oder anderen durchzuführen. Bestimmte Aufgaben können mit Open XML SDK ausgeführt werden, jedoch nicht mit Aspose.Slides. Zum Beispiel, wenn Sie direkten Zugriff auf die XML-Elemente und -Attribute eines OOXML-Dokuments benötigen, sollten Sie Open XML SDK verwenden. 

Wenn Sie komplexe Aufgaben an Dokumenten durchführen müssen—wie Aufgaben in der folgenden Liste—dann ist Aspose.Slides Ihre beste Option. 

- Operationen mit älteren PowerPoint-Formaten (und PPTX ebenfalls).
- Kopieren oder Klonen von Formen innerhalb von Folien auf eine Weise, die Objekte, Stile und andere Formatierungselemente angemessen kombiniert.
- Ersetzen von formatiertem oder unformatiertem Text.
- Anwenden von Animationen und Verwenden von Verbindungen mit Formen.
- Konvertieren eines Dokuments in PDF, TIFF oder XPS, sodass es aussieht, als hätte Microsoft PowerPoint die Konvertierung durchgeführt.
- Entwickeln einer .NET- oder Java-Anwendung sowohl in Desktop- als auch in webbasierenden Umgebungen.