---
title: Häufig gestellte Fragen
type: docs
weight: 340
url: /de/python-java/faqs/
keywords:
- FAQ
- Präsentationsformat
- Out-of-Memory-Fehler
- Foliengröße
- Text extrahieren
- Absatzgröße
- Tabellenrahmen
- Schriftart
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Finden Sie Antworten auf häufige Fragen zu Aspose.Slides für Python via Java, einschließlich Dateiformaten, Speicherverbrauch, Foliengrößen, Text, Tabellen, Bildern und Schriftarten."
---
## **Übersicht**

Dieses FAQ behandelt unterstützte Dateiformate, Speicherverbrauch bei großen Präsentationen, Foliengrößen und -vorschauen, Textextraktion, Tabellenrahmen, Bildplatzierung und Schriftartunterschiede beim Konvertieren von Präsentationen zu PDF oder Bildern.

## **FAQ**

### **Unterstützte Dateiformate**

**Welche Dateiformate unterstützt Aspose.Slides für Python via Java?**

Siehe [Unterstützte Dateiformate](/slides/de/python-java/supported-file-formats/) für die unterstützten Präsentations-, Dokument‑ und Bildformate sowie deren Import‑ und Exportfähigkeiten.

### **Ausnahmen**

**Warum erhalte ich einen Out‑of‑Memory‑Fehler beim Laden einer großen Präsentation mit Bildern? Gibt es ein Limit für die Dateigröße?**

Es gibt keinen einzelnen Dateigrößen‑Schwellenwert, der vorhersagt, ob eine Präsentation in den Speicher passt. Der Speicherbedarf hängt von der Struktur der Präsentation, von dekomprimierten Bildern, Effekten und den von Ihnen durchgeführten Vorgängen ab. Bilder können viel mehr Speicher belegen als ihre komprimierte Größe auf der Festplatte.

Aspose.Slides für Python via Java verwendet die Java‑Engine über JPype, daher muss der JVM‑Heap ausreichend Speicher für die Verarbeitung haben. Der verfügbare System‑RAM allein gibt nicht an, wie viel Speicher die JVM nutzen kann. Geben Sie Präsentationen mit [Presentation.dispose](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#dispose) frei, wenn Sie sie nicht mehr benötigen. Informationen zur Umgebungskonfiguration finden Sie unter [Systemanforderungen](/slides/de/python-java/system-requirements/) und [Installation](/slides/de/python-java/installation/).

### **Arbeiten mit Folien**

**Kann ich die Größe der Folien in einer Präsentation ändern?**

Ja. Verwenden Sie [Presentation.getSlideSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getslidesize), um die Foliengrößeneinstellungen der Präsentation abzurufen, und anschließend [SlideSize.setSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/#setsize), um die Abmessungen festzulegen und zu bestimmen, wie vorhandener Inhalt skaliert wird.

**Können Folien in derselben Präsentation unterschiedliche Größen haben?**

Nein. Microsoft‑PowerPoint‑Dokumente definieren die Foliengröße auf Präsentationsebene, sodass alle Folien dieselben Abmessungen haben.

**Kann ich eine Folie vor dem Speichern der Präsentation anzeigen?**

Ja. Rendern Sie die Folie zu einem Bild und zeigen Sie dieses Bild in Ihrer Anwendung an. Sie müssen die Präsentation nicht zuerst speichern.

### **Arbeiten mit Text**

**Kann ich den gesamten Text einer Präsentation abrufen?**

Ja. Die Klasse [SlideUtil](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/) bietet Methoden zum Abrufen von Text aus Präsentationen und einzelnen Folien.

**Warum sind die Absatzgrößen unter Windows und Linux unterschiedlich?**

Die Abmessungen von Absätzen hängen von den Metriken der zum Rendern des Textes verwendeten Schriftarten ab. Fehlt eine Schriftart, kann ein Ersatz andere Zeichenbreiten und Zeilenhöhen haben, was den Zeilenumbruch und die Absatzabmessungen ändert. Installieren Sie dieselben Schriftarten auf beiden Systemen oder laden Sie dieselben Schriftdateien mit [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#loadexternalfonts) bevor Sie Präsentationen erstellen oder laden.

### **Formatierung und Bilder**

**Wie kann ich die Farbe eines Tabellenrahmens festlegen?**

Verwenden Sie [Cell.getCellFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/cell/#getcellformat), um die Rahmenformatierung jeder Zelle abzurufen und die Füllfarbe für die entsprechenden Rahmen festzulegen. Um alle Rahmen zu ändern, verarbeiten Sie alle Zellen. Um nur den äußeren Rahmen der Tabelle zu ändern, aktualisieren Sie nur die nach außen gerichteten Rahmen der Zellen entlang der Kanten.

**Welche Einheiten werden für die Positionierung und Größe von Bildern verwendet?**

Die Koordinaten und Abmessungen von Shapes werden in Punkten gemessen. Ein Zoll entspricht 72 Punkten; diese Werte sind keine Pixelkoordinaten.

### **Arbeiten mit Schriftarten**

**Warum ändern sich Schriftarten, wenn ich eine Präsentation in PDF oder Bilder konvertiere?**

Die erforderlichen Schriftarten können auf dem System, das die Konvertierung durchführt, fehlen. Installieren Sie die Originalschriftarten oder verwenden Sie [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#loadexternalfonts), um Ordner mit ihnen hinzuzufügen. Laden Sie externe Schriftarten, bevor Sie Präsentationen erstellen oder öffnen.

Das folgende Beispiel registriert einen Schriftordner. Ersetzen Sie den Pfad durch einen vorhandenen Ordner, der Ihre Schriftdateien enthält. Es setzt die in [Installation](/slides/de/python-java/installation/) beschriebene Umgebung voraus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

Das Beispiel lässt die JVM für nachfolgende Präsentationsoperationen laufen. Informationen zur Verwendung in Notebooks und zu JVM‑Lebenszyklusbeschränkungen finden Sie unter [Einschränkungen und API‑Unterschiede](/slides/de/python-java/limitations-and-api-differences/).