---  
title: Warum nicht Open XML SDK  
type: docs  
weight: 100  
url: /cpp/why-not-open-xml-sdk/  
---  
  
## **Was ist Open XML SDK?**  
Wir hören manchmal diese Frage: Warum sollten wir Aspose-Produkte anstelle des kostenlosen Open XML SDK verwenden? Diese Frage ist leicht zu beantworten: Funktionen und Funktionalität. Laut der [MSDN-Bibliothek](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) wird Open XML SDK wie folgt definiert: Das Open XML SDK 2.0 vereinfacht die Aufgabe, Open XML-Pakete und die zugrunde liegenden Open XML-Schemaelemente innerhalb eines Pakets zu manipulieren. Das Open XML SDK 2.0 kapselt viele häufige Aufgaben, die Entwickler an Open XML-Paketen ausführen, sodass Sie komplexe Operationen mit nur wenigen Codezeilen durchführen können. OOXML-Dokumente sind im Wesentlichen komprimierte XML-Dateien, und Open XML SDK ist eine Sammlung von Klassen, die es Ihnen ermöglicht, mit dem Inhalt von OOXML-Dokumenten in einer stark typisierten Weise zu arbeiten. Anstatt eine Datei zu entpacken, um XML zu extrahieren, dieses XML in einen DOM-Baum zu laden und direkt mit XML-Elementen und -Attributen zu arbeiten, stellt das Open XML SDK Klassen zur Verfügung, um dies zu tun.  
## **Was ist Aspose.Slides?**  
Aspose.Slides ist eine Klassenbibliothek, die es Ihrer Anwendung ermöglicht, die folgenden Präsentationsverarbeitungsaufgaben durchzuführen:  
  
- Programmierung mit einem **Präsentation**-Objektmodell.  
- Hochwertige Konvertierungen zwischen allen gängigen unterstützten PowerPoint-Präsentationsformaten, einschließlich Konvertierung nach PDF und XPS.  
- Möglichkeit, Folienminiaturen in bekannten Formaten wie PNG, JPEG und BMP sowie den Folienexport nach SVG zu erstellen.  
- Möglichkeit, Präsentationen von Grund auf neu zu erstellen oder aus einem oder mehreren Dokumenten zu kombinieren.  
- Unterstützung für das Hinzufügen von Animationen, OLE-Frames, Tabellen, Erstellen und Verwalten von Diagrammen.  
- Verfügbarkeit umfangreicher Steuerung zur Verwaltung der Textformatierung auf TextFrame-, Absatz- und Teilebene.  
  Für weitere Details zu den unterstützten Funktionen besuchen Sie bitte [Aspose.Slides Funktionen](/slides/net/product-overview/).  
## **Vergleich von Open XML SDK und Aspose.Slides**  
Die folgende Tabelle vergleicht die Funktionen von Open XML SDK und Aspose.Slides.  
  
|**Funktion oder Funktionskategorie**|**Open XML SDK**|**Aspose.Slides**|  
| :- | :- | :- |  
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|  
|Konvertierung von PPT nach PPTX|Nein|Ja|  
|<p>Hochgradige Programmierung mit einem Dokumentenobjektmodell (DOM):</p><p>- Text suchen und ersetzen.</p><p>- Folien in Präsentationen zusammenstellen.</p>|Nein|Ja|  
|Detaillierte Programmierung mit einem Dokumentenobjektmodell, Zugang zu einzelnen Elementen und Formatierungen wie TextHaltern, TextFrames, Absätzen und Teilen.|Ja|Ja|  
|Niedriggradiger direkter und vollständiger Zugriff auf die zugrunde liegenden XML-Elemente und -Attribute wie Beziehungsidentifikatoren, Listenidentifikatoren eines OOXML-Dokuments.|Ja|Nein|  
|<p>Rendering:</p><p>- Präsentationen nach PDF, PDF-Notizen, XPS, TIFF-Bildern rendern.</p><p>- Folienminiaturen in PNG, JPEG, BMP, SVG und TIFF rendern.</p><p>- Bildauflösung, Qualität, Kompression und andere Optionen angeben.</p>|Nein|Ja|  
  
## **Fazit**  
Open XML SDK und Aspose.Slides konkurrieren nicht direkt miteinander, da sie ganz unterschiedliche Bedürfnisse und Zielgruppen ansprechen. Open XML SDK ist eine Klassenbibliothek, die einen stark typisierten Weg bietet, um mit OOXML-Dokumenten zu arbeiten. Aspose.Slides ist eine sehr nützliche Bibliothek zur Präsentationsverarbeitung, die eine hervorragende Unterstützung für nahezu alle Microsoft PowerPoint-Dateiformate bietet. Wenn Sie nur eine recht einfache Programmieroperation an einem PPTX-Dokument durchführen müssen, könnte Open XML SDK eine geeignete Wahl sein. Mit Open XML SDK werden Sie ziemlich komfortabel einfache Aufgaben wie das Erstellen eines einfachen PPTX-Dokuments oder das Entfernen von Kommentaren, Kopf-/Fußtiteln, das Extrahieren von Bildern oder anderen Dingen ausführen können. Einige Aufgaben können mit Open XML SDK erreicht werden, aber nicht mit Aspose.Slides. Wenn Sie beispielsweise direkt auf die XML-Elemente und -Attribute eines OOXML-Dokuments zugreifen müssen, sollten Sie das Open XML SDK verwenden. Wenn Sie jedoch komplexe Operationen an Dokumenten durchführen müssen, wie einige der folgenden Aufgaben, dann ist die Verwendung von Aspose.Slides Ihre beste Option:  
  
- Unterstützung älterer PowerPoint-Formate zusätzlich zu PPTX.  
- Formen innerhalb von Folien kopieren oder klonen, sodass Objekte, Stile und andere Formatierungen angemessen kombiniert werden.  
- Ersetzen von formatiertem oder unformatiertem Text.  
- Anwendung von Animationen und Verwendung von Verbindungen mit verwendeten Formen.  
- Konvertierung eines Dokuments in PDF oder XPS, damit es genau so aussieht, als hätte Microsoft PowerPoint es konvertiert.  
- Entwicklung einer C++-Anwendung sowohl in Desktop- als auch in konsolenbasierten Umgebungen.  