---
title: FAQ
type: docs
weight: 340
url: /de/net/faqs/
keywords:
- FAQ
- PowerPoint
- Präsentationsformat
- OutOfMemory-Fehler
- Foliengröße
- Text extrahieren
- Text abrufen
- Absatzgröße
- Tabellen formatieren
- Schriftart
- .NET
- C#
- Aspose.Slides
description: "Erhalten Sie Antworten auf häufig gestellte Fragen zu Aspose.Slides für .NET, einschließlich Unterstützung für PowerPoint und OpenDocument, Installationshinweise, Lizenzierung und Fehlerbehebung."
---

## **Unterstützte Dateiformate**

**Q: Welche Dateiformate unterstützt Aspose.Slides für .NET?**

**A**: Aspose.Slides für .NET unterstützt die Dateiformate, die in [Unterstützte Dateiformate](/slides/de/net/supported-file-formats/) beschrieben sind.

## **Ausnahmen**

**Q: Ich erhalte eine OutOfMemoryException beim Laden einer großen PPT-Datei mit Bildern. Gibt es eine Beschränkung in Aspose.Slides bezüglich der Dateigröße?**

**A**: Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es sollte genügend Speicherplatz vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Arbeitsspeicher unterzubringen. Normalerweise belegen Bilder im Speicher mehr Platz als auf der Festplatte, insbesondere wenn Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für .NET Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die `SlideSize`‑Eigenschaft der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse verwenden, um die Größe der Folien in einer Präsentation festzulegen.

**Q: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Foliengröße in Microsoft‑PowerPoint‑Dokumenten auf Präsentationsebene definiert wird, gibt es dafür keine Möglichkeit.

**Q: Unterstützt Aspose.Slides für .NET die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien zu Bildern rendern und diese Bilder für die Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q: Ist es möglich, den gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für .NET stellt die [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/)‑Klasse im Namespace `Aspose.Slides.Util` bereit, die verschiedene Methoden zum Abrufen des gesamten Textes aus Präsentationen bietet.

**Q: Warum unterscheiden sich die Absatzgrößen unter Windows und Linux?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße des jeweiligen Absatzes. Die Textgrößenberechnung verwendet die Metriken der im PowerPoint‑Dokument angegebenen Schriftart. Ist die angegebene Schriftart nicht vorhanden, wird sie durch die ähnlichste Schriftart ersetzt, deren Metriken von den Originalen abweichen. Dadurch führen unterschiedliche Systeme zu unterschiedlichen Ergebnissen, abhängig von der Menge installierter Schriftarten. Um auf verschiedenen Betriebssystemen das gleiche Ergebnis zu erzielen, müssen die gleichen Schriftarten auf den Systemen installiert oder zur Laufzeit als [externe Schriftarten](/slides/de/net/custom-font/) geladen werden.

## **Formatierung und Bilder**

**Q: Wie kann ich die Farbe des Tabellenrahmens festlegen?**

**A**: Sie können die Farbe aller Tabellenrahmen oder nur den Rahmen um die gesamte Tabelle ändern. Zum Ändern aller Rahmen verwenden Sie die `CellFormat`‑Eigenschaft des [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)‑Interfaces. Für den Rahmen der gesamten Tabelle sollten Sie die Zellen iterieren und die Farbe der äußeren Rahmen ändern.

**Q: Welche Maße verwendet Aspose.Slides für .NET zum Platzieren von Bildern?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**Q: Warum unterscheiden sich die Schriftarten in den Ausgabedokumenten, wenn PPT in PDF oder Bilder konvertiert wird?**

**A**: Dieses Problem kann darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wird, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten über die [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)‑Klasse laden, wie unten gezeigt:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
