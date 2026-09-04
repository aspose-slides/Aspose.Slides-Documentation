---
title: "Automatisierung der PowerPoint-Generierung in Python: Dynamische Präsentationen einfach erstellen"
linktitle: Automatisierung der PowerPoint-Generierung
type: docs
weight: 20
url: /de/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- Cloud-Plattformen
- Cloud-Integration
- PowerPoint-Generierung automatisieren
- Präsentationen programmgesteuert erzeugen
- PowerPoint-Automatisierung
- Dynamische Folienerstellung
- Automatisierte Geschäftsberichte
- PPT-Automatisierung
- Python-Präsentation
- Python
- Aspose.Slides
description: "Automatisieren Sie die PowerPoint-Generierung mit Aspose.Slides für Python via Java: Erstellen Sie eine Geschäftspräsentation mit Diagrammen, Tabellen und Aufzählungspunkten in Cloud-Anwendungen."
---
## **Einführung**

Das manuelle Erstellen von Präsentationen wird wiederholend, wenn sich deren Inhalt häufig ändert. Wochenberichte, Schulungsunterlagen und Kundenpräsentationen verwenden oft eine gemeinsame Struktur, benötigen jedoch für jede Auslieferung neue Daten.

Aspose.Slides for Python via Java ermöglicht das Erzeugen dieser Präsentationen aus Python‑Anwendungen. Sie können die Erstellung von Folien in Webportale, geplante Jobs und Cloud‑Worker integrieren und dabei Daten aus Datenbanken, APIs oder hochgeladenen Dateien nutzen.

## **Häufige Anwendungsfälle für PowerPoint‑Automatisierung in Python**

- **Geschäftsberichte und Dashboards:** Verkaufszahlen und Leistungskennzahlen in Diagramme und Tabellen umwandeln.
- **Personalisierte Vertriebspräsentationen:** Folien mit kundenspezifischen Daten füllen und dabei ein konsistentes Design beibehalten.
- **Bildungsinhalte:** Lektionen, Quizfragen und Kurszusammenfassungen aus strukturierten Materialien zusammenstellen.
- **Daten‑ und KI‑gestützte Erkenntnisse:** Ergebnisse aus Analyse‑ oder Sprachverarbeitungsdiensten als Präsentationsinhalt verwenden.
- **Medienbasierte Folien:** Hochgeladene Bilder oder Screenshots mit erläuterndem Text kombinieren.
- **Dokumenten‑Workflows:** Inhalt, der von anderen Tools extrahiert wurde, in Präsentationslayouts einbinden.
- **Entwickler‑Tools:** Release‑Zusammenfassungen, technische Übersichten oder Demonstrationen aus Projektdaten generieren.

## **Voraussetzungen**

Folgen Sie [Installation](/slides/de/python-java/installation/), um Python, Java, JPype und Aspose.Slides einzurichten. Für Cloud‑Bereitstellungen lesen Sie außerdem [Slides on Cloud Platforms](/slides/de/python-java/slides-on-cloud-platforms/).

Das Beispiel verwendet feste Geschäftsdaten, sodass es ohne Datenbank oder externen Dienst ausgeführt werden kann. Ersetzen Sie diese Werte durch Daten aus Ihrer Anwendung, wenn Sie es in einen Bericht‑Workflow integrieren.

{{% alert color="info" title="Note" %}}
Sie können das Beispiel ohne Lizenz testen, aber die Evaluierungsausgabe enthält ein Wasserzeichen und unterliegt Evaluierungsbeschränkungen. Siehe [Evaluate Aspose.Slides](/slides/de/python-java/evaluate-aspose-slides/) für Details und Informationen zur temporären Lizenz.
{{% /alert %}}

## **Präsentation erstellen**

Das nachstehende komplette Skript erstellt eine Präsentation mit vier Folien. Jeder Schritt verwendet dieselbe Präsentation, und im letzten Schritt wird sie als `presentation.pptx` gespeichert.

### **Titelfolie erstellen**

Verwenden Sie die erste Folie einer neuen [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und wenden Sie das Titellayout an. Füllen Sie die Platzhalter für Titel und Untertitel mit der Bericht‑Überschrift und dem Publikum.

![Die Titelfolie](slide_0.png)

### **Folien mit Säulendiagramm hinzufügen**

Fügen Sie eine leere Folie hinzu und erstellen Sie ein Diagramm mit [ShapeCollection.addChart](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addChart). Befüllen Sie das eingebettete Arbeitsblatt mit fünf Regionen und einer Verkaufs‑Serie. Die Werte bleiben in PowerPoint editierbar.

![Die Folie mit dem Diagramm](slide_1.png)

### **Folien mit Tabelle hinzufügen**

Erstellen Sie eine Tabelle mit [ShapeCollection.addTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addTable) und füllen Sie zwei Spalten mit Metriknamen und Werten. Das Beispiel übergibt über JPype explizite Java‑Arrays von Doubles für Spaltenbreiten und Zeilenhöhen.

![Die Folie mit der Tabelle](slide_2.png)

### **Zusammenfassungsfolie mit Aufzählungspunkten hinzufügen**

Erstellen Sie eine Textform und fügen Sie für jeden Aktionspunkt einen [Paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/) hinzu. Wenden Sie ein Symbol‑Aufzählungszeichen und schwarzen Text auf jeden Paragraphen an und entfernen Sie die Füll‑ und Kontur‑Eigenschaften der Form.

![Die Folie mit der Zusammenfassung](slide_3.png)

### **Präsentation speichern**

Verwenden Sie [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save), um die PowerPoint‑Datei zu schreiben. Geben Sie die Präsentation mit [Presentation.dispose](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#dispose) in einem `finally`‑Block frei.

### **Vollständiges Python‑Beispiel**

Speichern Sie dieses Skript in einem beschreibbaren Verzeichnis und führen Sie es mit der oben konfigurierten Python‑Umgebung aus. Es startet die JVM nur bei Bedarf und lässt sie bis zum Beenden des Prozesses verfügbar. Für die Verwendung in Notebooks und Diensten siehe [JVM lifecycle guidance](/slides/de/python-java/limitations-and-api-differences/#import-the-library).

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # Erstelle die Titelfolie.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # Füge eine Diagrammfolie hinzu.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Füge eine Tabellenfolie hinzu.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # Füge eine Zusammenfassungsfolie hinzu.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Abbildungen zeigen die entsprechenden Folien aus dem Java‑Beispiel. Das Aussehen kann je nach installierten Schriftarten und Evaluierungsmodus variieren.

## **Beispiel in einer Cloud‑Anwendung verwenden**

Rufen Sie Berichtsdaten ab, bevor Sie die Präsentation erstellen, und übergeben Sie sie an die Diagramm‑, Tabellen‑ und Textgenerierungsschritte. Verwenden Sie für jeden Job einen separaten Ausgabepfad. Nach dem Speichern kann Ihre Anwendung die Datei in einen Objektspeicher hochladen oder als Download zurückgeben.

Lassen Sie die JVM über mehrere Jobs hinweg im selben Worker‑Prozess laufen und geben Sie jede Präsentation frei, sobald ihr Job abgeschlossen ist. Packen Sie die für Ihr Bericht‑Design benötigten Schriftarten zusammen mit der Bereitstellung, um Unterschiede zwischen Umgebungen zu reduzieren.

## **Fazit**

Dieses Beispiel erzeugt eine komplette Geschäftspräsentation aus Python mit editierbaren Diagrammen, Tabellen und Text. Der Austausch der Beispieldaten durch Anwendungsdaten macht denselben Ansatz nützlich für wiederkehrende Berichte, Kundenpräsentationen und Schulungsmaterialien.

## **FAQ**

**Benötigt das Skript Microsoft PowerPoint oder Excel?**

Nein. Aspose.Slides erstellt die Folien und das eingebettete Arbeitsblatt des Diagramms ohne diese Anwendungen.

**Warum verwendet das Tabellenbeispiel Java‑Arrays?**

Die zugrundeliegende Methode akzeptiert Arrays von Java‑Doubles. Explizite Arrays machen die über JPype übergebenen numerischen Typen deutlich.

**Kann ich dieselbe Präsentation als PDF oder ODP speichern?**

Ja. Bevor Sie sie freigeben, speichern Sie sie unter einem anderen Dateinamen mit dem entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/)-Wert. Siehe [Supported File Formats](/slides/de/python-java/supported-file-formats/) für formatbezogene Funktionen.

**Kann ich eine gebrandete Vorlage verwenden?**

Ja. Laden Sie Ihre Vorlage anstelle einer leeren Präsentation und passen Sie Layout und Platzhalterausswahl an diese Vorlage an. Das Beispiel geht von den Layouts und der Platzhalterreihenfolge einer neuen Standardpräsentation aus.