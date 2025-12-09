---
title: FAQ
type: docs
weight: 340
url: /de/java/faqs/
keywords:
- FAQ
- Präsentationsformat
- Out-of-Memory-Fehler
- Foliengröße
- Text extrahieren
- Text abrufen
- Absatzgröße
- Tabellen formatieren
- Schriftart
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erhalten Sie Antworten auf häufig gestellte Fragen zu Aspose.Slides für Java, einschließlich Unterstützung für PowerPoint und OpenDocument, Installationsanleitungen, Lizenzierung und Fehlerbehebung."
---

## **Unterstützte Dateiformate**

**Q: Welche Dateiformate unterstützt Aspose.Slides für Java?**

**A**: Aspose.Slides für Java unterstützt die Dateiformate, die in [Unterstützte Dateiformate](/slides/de/java/supported-file-formats/) beschrieben sind.

## **Ausnahmen**

**Q: Beim Laden einer großen PPT-Datei mit Bildern erhalte ich eine Out of memory-Ausnahme. Gibt es eine Begrenzung in Aspose.Slides bezüglich der Dateigröße?**

**A**: Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es sollte ausreichend Speicherplatz vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Speicher zu halten. Normalerweise benötigen Bilder im Speicher mehr Platz als auf der Festplatte, insbesondere wenn Bilder zusätzliche Effekte besitzen.

Im Allgemeinen kann Aspose.Slides für Java Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die Methode `getSlideSize` der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) verwenden, um die Größe der Folien in einer Präsentation festzulegen.

**Q: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Größe der Folien in Microsoft PowerPoint‑Dokumenten auf Präsentationsebene definiert wird, gibt es keine Möglichkeit, dies zu tun.

**Q: Unterstützt Aspose.Slides für Java die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien in Bilder rendern und diese Bilder für die Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q: Ist es möglich, den gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für Java bietet die Klasse [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/slideutil/) an, die verschiedene Methoden zum Abrufen des gesamten Textes aus Präsentationen bereitstellt.

**Q: Warum unterscheiden sich die Absatzgrößen unter Windows und Linux?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den jeweiligen Absatz darstellt. Die Textgrößenberechnung stützt sich auf die Metriken der im PowerPoint‑Dokument angegebenen Schriftart. Fehlt die angegebene Schriftart, wird sie durch die ähnlichste Schriftart ersetzt, deren Metriken jedoch von den Originalen abweichen. Dadurch führt die Berechnung der Absatzgrößen in verschiedenen Systemen zu unterschiedlichen Ergebnissen, abhängig von der Menge installierter Schriftarten. Um auf verschiedenen Betriebssystemen dasselbe Ergebnis zu erzielen, müssen Sie dieselben Schriftarten auf den Systemen installieren oder sie zur Laufzeit als [externe Schriftarten](/slides/de/java/custom-font/) laden.

## **Formatierung und Bilder**

**Q: Wie kann ich die Farbe eines Tabellenrahmens festlegen?**

**A**: Sie können die Farbe aller Tabellenrahmen oder nur den Rahmen um die gesamte Tabelle ändern. Um alle Rahmen zu ändern, verwenden Sie bitte die Methode `getCellFormat` aus dem Interface [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/). Für den Rahmen der gesamten Tabelle sollten Sie die Zellen iterieren und die Farbe der äußeren Rahmen ändern.

**Q: Welche Maße verwendet Aspose.Slides für Java, um Bilder zu positionieren?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**Q: Warum unterscheiden sich die Schriftarten in den Ausgabedokumenten beim Konvertieren von PPT zu PDF oder Bildern?**

**A**: Dieses Problem kann darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten auf dem Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten auf dem Betriebssystem installieren oder sie als externe Schriftarten mit der Klasse [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) laden, wie unten gezeigt:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```
