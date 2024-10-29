---
title: FAQs
type: docs
weight: 340
url: /de/java/faqs/
keywords:
- FAQ
- PowerPoint
- Präsentationsformat
- Speicherfehler
- Foliengröße
- Text extrahieren
- Text abrufen
- Absatzgröße
- Tabellen formatieren
- Schriftart
- Java
- Aspose.Slides für Java
---

## **Unterstützte Dateiformate**

**F: Welche Dateiformate werden von Aspose.Slides für Java unterstützt?**

**A**: Aspose.Slides für Java unterstützt die Dateiformate, die in [Unterstützte Dateiformate](/slides/de/java/supported-file-formats/) beschrieben sind.

## **Ausnahmen**

**F: Ich erhalte eine Ausnahme aufgrund von Speichermangel, während ich eine große PPT-Datei mit Bildern lade. Gibt es eine Einschränkung bei Aspose.Slides hinsichtlich der Dateigröße?**

**A**: Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es sollte genügend Platz vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Speicher aufzunehmen. Normalerweise belegen Bilder im Speicher mehr Platz als auf der Festplatte, insbesondere wenn die Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für Java Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**F: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die `getSlideSize`-Methode, die von der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) -Klasse bereitgestellt wird, verwenden, um die Größe der Folien in einer Präsentation zu definieren.

**F: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Größe der Folien auf Präsentationsebene in Microsoft PowerPoint-Dokumenten definiert ist, gibt es keine Möglichkeit, dies zu tun.

**F: Unterstützt Aspose.Slides für Java das Vorschauen einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien in Bilder rendern und diese Bilder zur Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**F: Ist es möglich, den gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für Java bietet die [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/slideutil/) -Klasse, die verschiedene Methoden zum Abrufen des gesamten Textes aus Präsentationen bereitstellt.

**F: Warum sind die Absatzgrößen unter Windows und Linux-Betriebssystemen unterschiedlich?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den gegebenen Absatz darstellt. Die Berechnung der Textgröße basiert auf den Metriken der im PowerPoint-Dokument angegebenen Schriftart. Wenn die angegebene Schriftart fehlt, wird sie durch die ähnlichste Schriftart ersetzt, jedoch hat diese Schriftart unterschiedliche Metriken als die ursprünglichen. Infolgedessen führt die Berechnung der Absatzgrößen in unterschiedlichen Systemen zu unterschiedlichen Ergebnissen, abhängig von der installierten Schriftarten. Um dasselbe Ergebnis auf unterschiedlichen Betriebssystemen zu erzielen, müssen Sie die gleichen Schriftarten auf den Systemen installieren oder sie zur Laufzeit als [externe Schriftarten](/slides/de/java/custom-font/) laden.

## **Formatierung und Bilder**

**F: Wie kann ich die Farbe eines Tabellenrandes festlegen?**

**A**: Sie können die Farbe aller Tabellenränder oder nur den Rand um die gesamte Tabelle ändern. Um alle Ränder zu ändern, verwenden Sie bitte die `getCellFormat`-Methode der [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) -Schnittstelle. Für den Rand der gesamten Tabelle sollten Sie die Zellen durchlaufen und die Farbe der äußeren Ränder ändern.

**F: Welche Maße verwendet Aspose.Slides für Java, um Bilder zu platzieren?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**F: Warum sind die Schriftarten bei der Konvertierung von PPT in PDF oder Bilder in den Ausgabedokumenten unterschiedlich?**

**A**: Dieses Problem könnte darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten unter Verwendung der [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) -Klasse laden, wie unten gezeigt:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```