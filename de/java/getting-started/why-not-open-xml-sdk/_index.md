---  
title: Warum nicht Open XML SDK  
type: docs  
weight: 120  
url: /de/java/why-not-open-xml-sdk/  
---  
  
{{% alert color="primary" %}}  
  
Manchmal hören wir diese Frage:  
  
**Warum sollten wir Aspose-Produkte anstelle des kostenlosen Open XML SDK verwenden?**  
  
Diese Frage ist leicht zu beantworten: **Funktionen und Funktionalität**.  
  
{{% /alert %}}  
## **Was ist das Open XML SDK?**  
Laut der [MSDN-Bibliothek](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) wird das Open XML SDK definiert als:  
  
Das Open XML SDK 2.0 vereinfacht die Aufgabe, Open XML-Pakete und die zugrunde liegenden Open XML-Schema-Elemente innerhalb eines Pakets zu manipulieren. Das Open XML SDK 2.0 kapselt viele gängige Aufgaben ein, die Entwickler bei der Arbeit mit Open XML-Paketen durchführen, sodass Sie komplexe Operationen mit nur wenigen Codezeilen durchführen können.  
  
OOXML-Dokumente sind im Wesentlichen komprimierte XML-Dateien, und das Open XML SDK ist eine Sammlung von Klassen, die es Ihnen ermöglicht, mit dem Inhalt von OOXML-Dokumenten auf stark typisierte Weise zu arbeiten. Anstatt eine Datei zu entpacken, um XML zu extrahieren, dieses XML in einen DOM-Baum zu laden und direkt mit XML-Elementen und -Attributen zu arbeiten, bietet das Open XML SDK Klassen, um dies zu tun.  
## **Was ist Aspose.Slides?**  
Aspose.Slides ist eine Klassenbibliothek, die es Ihrer Anwendung ermöglicht, die folgenden Präsentationsverarbeitungsaufgaben auszuführen:  
  
- Programmierung mit einem **Präsentations**-Objektmodell.  
- Hochwertige Konvertierungen zwischen allen gängigen unterstützten PowerPoint-Präsentationsformaten, einschließlich Konvertierung zu PDF, XPS und TIFF.  
- Fähigkeit, Folien-Thumbnails in bekannten Formaten wie PNG, JPEG und BMP zu erstellen sowie Folienexport nach SVG.  
- Fähigkeit, Präsentationen von Grund auf neu zu erstellen oder aus einem oder mehreren Dokumenten zu kombinieren.  
- Unterstützung für das Hinzufügen von Animationen, Ole-Frames, Tabellen, Erstellen und Verwalten von Diagrammen.  
- Verfügbarkeit umfangreicher Kontrolle zur Verwaltung der Textformatierung auf TextFrame-, Absatz- und Portionsebene.  
  
Für weitere Details zu den unterstützten Funktionen besuchen Sie bitte [Aspose.Slides-Funktionen](/slides/de/java/product-overview/).  
## **Vergleich Open XML SDK und Aspose.Slides**  
{{% alert color="primary" %}}  
  
Die folgende Tabelle vergleicht die Funktionen des Open XML SDK und von Aspose.Slides.  
  
{{% /alert %}}  
  
|**Funktion oder Funktionskategorie**|**Open XML SDK**|**Aspose.Slides**|  
| :- | :- | :- |  
|Unterstützte Präsentationsformate|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|  
|Konvertierung von PPT zu PPTX |Nein|Ja|  
|<p>Hochlevelige Programmierung mit einem Präsentations-Dokument-Objektmodell (DOM):</p><p>- Text suchen und ersetzen.</p><p>- Folien in Präsentationen zusammenstellen.</p>|Nein|Ja|  
|Detaillierte Programmierung mit einem Dokument-Objektmodell, Zugriff auf einzelne Elemente und Formatierungen wie TextHolder, TextFrames, Absätze und Portionen.|Ja|Ja|  
|Niedrigleveliger direkter und vollständiger Zugriff auf die zugrunde liegenden XML-Elemente und -Attribute wie Beziehungs-IDs, Listen-IDs eines OOXML-Dokuments.|Ja|Nein|  
|<p>Rendering:</p><p>- Präsentationen in PDF, PDF-Notizen, XPS, TIFF-Bilder rendern.</p><p>- Folien-Thumbnails in PNG, JPEG, BMP, SVG und TIFF rendern.</p><p>- Bildauflösung, Qualität, Kompression und andere Optionen angeben.</p>|Nein|Ja |  
|Unterstützte Plattformen|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|  
## **Fazit**  
{{% alert color="primary" %}}  
  
Open XML SDK und Aspose.Slides konkurrieren nicht direkt miteinander, da sie ganz unterschiedliche Bedürfnisse und Zielgruppen ansprechen. Open XML SDK ist eine Klassenbibliothek, die einen stark typisierten Ansatz zum Arbeiten mit OOXML-Dokumenten bietet. Aspose.Slides ist eine sehr nützliche Bibliothek zur Präsentationsverarbeitung, die hervorragende Unterstützung für nahezu alle Microsoft PowerPoint-Dateiformate bietet.  
  
Wenn Sie nur eine recht grundlegende Programmieroperation an einem PPTX-Dokument durchführen müssen, dann könnte das Open XML SDK eine geeignete Wahl sein. Mit dem Open XML SDK werden Sie relativ komfortabel einfache Aufgaben wie das Erzeugen eines einfachen PPTX-Dokuments oder das Entfernen von Kommentaren, Kopf- und Fußzeilen sowie das Extrahieren von Bildern oder anderen Inhalten durchführen können. Einige Aufgaben können mit dem Open XML SDK erreicht werden, aber nicht mit Aspose.Slides. Wenn Sie beispielsweise direkten Zugriff auf die XML-Elemente und -Attribute eines OOXML-Dokuments benötigen, sollten Sie das Open XML SDK verwenden. Wenn Sie jedoch komplexe Operationen an Dokumenten durchführen müssen, wie einige der folgenden Aufgaben, dann ist die Verwendung von Aspose.Slides Ihre beste Option:  
  
- Unterstützung älterer PowerPoint-Formate zusätzlich zu PPTX.  
- Formen innerhalb von Folien kopieren oder duplizieren, um Objekte, Stile und andere Formatierungen angemessen zu kombinieren.  
- Formatierte oder unformatierte Texte ersetzen.  
- Anwendungen von Animationen und Verwendung von Verbindern mit den verwendeten Formen.  
- Ein Dokument in PDF, TIFF oder XPS konvertieren, damit es genau so aussieht, wie Microsoft PowerPoint es konvertiert hätte.  
- Eine .NET- oder Java-Anwendung sowohl in Desktop- als auch in webbasierter Umgebung entwickeln.  
  
{{% /alert %}}  