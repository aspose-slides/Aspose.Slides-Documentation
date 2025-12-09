---
title: FAQ
type: docs
weight: 340
url: /de/net/faqs/
keywords:
- FAQ
- PowerPoint
- Präsentationsformat
- Speicherüberlauf-Fehler
- Foliengröße
- Text extrahieren
- Text abrufen
- Absatzgröße
- Tabellen formatieren
- Schriftart
- .NET
- C#
- Aspose.Slides
description: "Erhalten Sie Antworten auf häufig gestellte Fragen zu Aspose.Slides für .NET, einschließlich Unterstützung für PowerPoint und OpenDocument, Installationsanleitungen, Lizenzierung und Fehlerbehebung."
---

## **Unterstützte Dateiformate**

**Q: Welche Dateiformate unterstützt Aspose.Slides für .NET?**

**A**: Aspose.Slides für .NET unterstützt die Dateiformate, die in [Unterstützte Dateiformate](/slides/de/net/supported-file-formats/) beschrieben sind.

## **Ausnahmen**

**Q: Ich erhalte eine OutOfMemoryException beim Laden einer großen PPT-Datei mit Bildern. Gibt es eine Beschränkung in Aspose.Slides bezüglich der Dateigröße?**

**A**: Es gibt keine feste Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es muss ausreichend Speicher vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Arbeitsspeicher unterzubringen. Normalerweise belegen Bilder im Speicher mehr Platz als auf der Festplatte, insbesondere wenn sie zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für .NET Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die `SlideSize`‑Eigenschaft der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse verwenden, um die Größe der Folien in einer Präsentation festzulegen.

**Q: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Foliengröße auf Präsentationsebene in Microsoft‑PowerPoint‑Dokumenten definiert ist, gibt es keine Möglichkeit, dies zu tun.

**Q: Unterstützt Aspose.Slides für .NET die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien in Bilder rendern und diese Bilder für die Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q: Ist es möglich, den gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für .NET stellt die [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/)‑Klasse im Namespace `Aspose.Slides.Util` bereit, die verschiedene Methoden zum Abrufen des gesamten Textes aus Präsentationen bietet.

**Q: Warum unterscheiden sich die Absatzgrößen unter Windows und Linux?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den jeweiligen Absatz darstellt. Die Textgrößenberechnung nutzt die Metriken der im PowerPoint‑Dokument angegebenen Schriftart. Fehlt die angegebene Schriftart, wird sie durch die ähnlichste Schriftart ersetzt, die jedoch andere Metriken hat. Dadurch führt die Berechnung der Absatzgrößen in verschiedenen Systemen zu unterschiedlichen Ergebnissen, abhängig vom Satz installierter Schriftarten. Um auf verschiedenen Betriebssystemen das gleiche Ergebnis zu erzielen, müssen Sie dieselben Schriftarten auf den Systemen installieren oder sie zur Laufzeit als [externe Schriftarten](/slides/de/net/custom-font/) laden.

## **Formatierung und Bilder**

**Q: Wie kann ich die Farbe des Tabellengitters festlegen?**

**A**: Sie können die Farbe aller Tabellengitter oder nur den Rand um die gesamte Tabelle ändern. Zum Ändern aller Ränder verwenden Sie die `CellFormat`‑Eigenschaft des [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)‑Interfaces. Für den Rand der gesamten Tabelle sollten Sie die Zellen iterieren und die Farbe der äußeren Ränder ändern.

**Q: Welche Maßeinheit verwendet Aspose.Slides für .NET zum Platzieren von Bildern?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**Q: Warum unterscheiden sich die Schriftarten in den Ausgabedokumenten, wenn ich PPT in PDF oder Bilder konvertiere?**

**A**: Dieses Problem kann darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten auf dem Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten auf dem Betriebssystem installieren oder sie als externe Schriftarten mit der [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)‑Klasse wie unten gezeigt laden:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
