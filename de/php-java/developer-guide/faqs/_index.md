---
title: FAQs
type: docs
weight: 340
url: /php-java/faqs/
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
- PHP
- Java
- Aspose.Slides für PHP über Java
---

## **Unterstützte Dateiformate**

**Q: Welche Dateiformate unterstützt Aspose.Slides für PHP über Java?**

**A**: Aspose.Slides für PHP über Java unterstützt die in [Unterstützte Dateiformate](/slides/php-java/supported-file-formats/) beschriebenen Dateiformate.

## **Ausnahmen**

**Q: Ich erhalte eine Speicherfehlermeldung beim Laden einer großen PPT-Datei mit Bildern. Gibt es eine Einschränkung der Dateigröße in Aspose.Slides?**

**A**: Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es sollte genügend Speicherplatz vorhanden sein, um die gesamte Präsentationsstruktur und Bilder im Arbeitsspeicher unterzubringen. Normalerweise benötigen Bilder im Arbeitsspeicher mehr Platz als auf der Festplatte, insbesondere wenn Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für PHP über Java Präsentationsdateien von ca. 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die `getSlideSize`-Methode der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse verwenden, um die Größe der Folien in einer Präsentation zu definieren.

**Q: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Größe der Folien auf der Präsentationsebene in Microsoft PowerPoint-Dokumenten definiert ist, gibt es keine Möglichkeit, dies zu tun.

**Q: Unterstützt Aspose.Slides für PHP über Java die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien als Bilder rendern und diese Bilder zur Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q: Ist es möglich, gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für PHP über Java bietet die [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/) Klasse, die verschiedene Methoden zum Abrufen des gesamten Textes aus den Präsentationen bereitstellt.

**Q: Warum sind die Absatzgrößen unter Windows und Linux unterschiedlich?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den angegebenen Absatz darstellt. Die Berechnung der Textgröße basiert auf den Metriken der in der PowerPoint-Präsentation angegebenen Schriftart. Wenn die angegebene Schriftart fehlt, wird sie durch die ähnlichste Schriftart ersetzt, aber diese Schriftart hat andere Metriken als die ursprünglichen. Infolgedessen führt die Berechnung der Absatzgrößen in verschiedenen Systemen zu unterschiedlichen Ergebnissen, abhängig von der installierten Schriftarten. Um dasselbe Ergebnis auf verschiedenen Betriebssystemen zu erzielen, müssen Sie dieselben Schriftarten auf den Systemen installieren oder sie zur Laufzeit als [externe Schriftarten](/slides/php-java/custom-font/) laden.

## **Formatierung und Bilder**

**Q: Wie kann ich die Farbe eines Tabellenrahmens festlegen?**

**A**: Sie können die Farbe aller Tabellenrahmen oder nur des Rahmens um die gesamte Tabelle ändern. Um alle Rahmen zu ändern, verwenden Sie bitte die `getCellFormat`-Methode der [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) Klasse. Für den Rahmen der gesamten Tabelle sollten Sie die Zellen durchlaufen und die Farbe der äußeren Rahmen ändern.

**Q: Welche Maße verwendet Aspose.Slides für PHP über Java, um Bilder zu platzieren?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**Q: Warum sind die Schriftarten bei der Konvertierung von PPT in PDF oder Bilder in den Ausgabedokumenten unterschiedlich?**

**A**: Dieses Problem könnte darauf hindeuten, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten laden, indem Sie die [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) Klasse wie unten gezeigt verwenden:
```cs
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```