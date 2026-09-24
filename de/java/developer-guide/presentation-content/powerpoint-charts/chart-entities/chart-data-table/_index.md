---
title: Diagrammdatentabellen in Präsentationen mit Java anpassen
linktitle: Datentabelle
type: docs
url: /de/java/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Passen Sie Schriftarten, Rahmen und Legenden‑Schlüssel von Diagrammdatentabellen in PowerPoint‑Präsentationen mit Aspose.Slides für Java an."
---
## **Überblick**

Aspose.Slides für Java ermöglicht das Anzeigen eines Datenblatts eines Diagramms und das Anpassen seiner Textformatierung, Rahmen und Legenden‑Schlüssel. Dieser Artikel erklärt, wie das Tabellenblatt aktiviert, dessen Text formatiert, jeder Rahmenart gesteuert und Legenden‑Schlüssel ein- oder ausgeblendet werden. Die Beispiele speichern die konfigurierten Diagramme in PPTX‑Dateien.

## **Schriftarteigenschaften festlegen**

Um das Datenblatt eines Diagramms anzuzeigen, übergeben Sie `true` an [setDataTable](https://reference.aspose.com/slides/de/java/com.aspose.slides/chart/#setDataTable-boolean-). Verwenden Sie [getChartDataTable](https://reference.aspose.com/slides/de/java/com.aspose.slides/chart/#getChartDataTable--) , um auf die Tabelle zuzugreifen und deren Textformatierung zu konfigurieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) .
1. Fügen Sie der ersten Folie ein gruppiertes Säulendiagramm hinzu.
1. Aktivieren Sie das Datenblatt des Diagramms.
1. Aktivieren Sie fetten Text mit [setFontBold](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) und übergeben Sie `20` an [setFontHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) für Text mit 20 Punkt.
1. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel benötigt `test.pptx` im Arbeitsverzeichnis mit mindestens einer Folie. Es fügt ein Diagramm mit Standarddaten an Position (50, 50) ein, mit einer Breite von 600 Punkten und einer Höhe von 400 Punkten. Die gespeicherte `output.pptx` enthält das Diagramm mit aktiviertem Datenblatt und den angegebenen Schrifteinstellungen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Datenblattrahmen anpassen**

Aktivieren Sie das Tabellenblatt mit [IChart.setDataTable](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichart/#setDataTable-boolean-) und greifen Sie über [IChart.getChartDataTable](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichart/#getChartDataTable--) darauf zu. Sie können drei Arten von Rahmen unabhängig steuern:

- [setBorderHorizontal](https://reference.aspose.com/slides/de/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) steuert die horizontalen Zellenrahmen.
- [setBorderVertical](https://reference.aspose.com/slides/de/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) steuert die vertikalen Zellenrahmen.
- [setBorderOutline](https://reference.aspose.com/slides/de/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) steuert den äußeren Rahmen der Tabelle.

Übergeben Sie `true` an jede Methode, um die jeweiligen Rahmen anzuzeigen, oder `false`, um sie zu verbergen. Das folgende Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten, zeigt horizontale Rahmen und den äußeren Rahmen an und blendet vertikale Rahmen aus. Es benötigt keine Eingabedatei. Die Position und Größe des Diagramms werden in Punkten angegeben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Diagrammdatentabellen mit allen Rahmen aktiviert, ohne horizontale Rahmen, ohne vertikale Rahmen und ohne äußeren Rahmen](data-table-borders.png)

## **Legenden‑Schlüssel ein- oder ausblenden**

Legenden‑Schlüssel sind kleine farbige Markierungen neben den Seriennamen im Datenblatt. Sie helfen den Lesern, jede Tabellenzeile einer Diagrammserie zuzuordnen. Übergeben Sie `true` an [setShowLegendKey](https://reference.aspose.com/slides/de/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) , um diese Markierungen anzuzeigen, oder `false`, um sie zu verbergen.

Die separate Legende des Diagramms wird über [IChart.setLegend](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichart/#setLegend-boolean-) gesteuert. Diese Einstellungen sind unabhängig: Das Ausblenden der separaten Legende blendet nicht die Schlüssel im Datenblatt aus, und das Ausblenden der Schlüssel im Datenblatt blendet nicht die separate Legende aus.

Das folgende Beispiel erstellt ein Diagramm mit Standarddaten, aktiviert sein Datenblatt und zeigt Legenden‑Schlüssel darin an, während die separate Legende ausgeblendet wird. Alle Tabellenrahmen werden explizit aktiviert. Es wird keine Eingabepräsentation benötigt. Um nur die Schlüssel der Tabelle auszublenden, übergeben Sie `false` an [setShowLegendKey](https://reference.aspose.com/slides/de/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Diagrammdatentabellen mit angezeigten Legenden‑Schlüsseln links und ausgeblendeten rechts](data-table-legend-keys.png)

## **FAQ**

**Kann ich Legenden‑Schlüssel in einem Diagrammdatenblatt anzeigen?**

Ja. Übergeben Sie `true` an [setShowLegendKey](https://reference.aspose.com/slides/de/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), um Legenden‑Schlüssel anzuzeigen, oder `false`, um sie zu verbergen.

**Wird das Datenblatt beim Exportieren der Präsentation nach PDF, HTML oder Bildern erhalten bleiben?**

Ja. Aspose.Slides rendert das Diagramm und das angezeigte Datenblatt als Teil der Folie beim Exportieren zu [PDF](/slides/de/java/convert-powerpoint-to-pdf/), [HTML](/slides/de/java/convert-powerpoint-to-html/) oder [images](/slides/de/java/convert-powerpoint-to-png/).

**Kann ich mit Datentabellen in aus einer Vorlage geladenen Diagrammen arbeiten?**

Ja. Für ein Diagramm, das aus einer bestehenden Präsentation oder Vorlage geladen wurde, verwenden Sie [hasDataTable](https://reference.aspose.com/slides/de/java/com.aspose.slides/chart/#hasDataTable--) und [setDataTable](https://reference.aspose.com/slides/de/java/com.aspose.slides/chart/#setDataTable-boolean-), um zu prüfen oder zu ändern, ob sein Datenblatt angezeigt wird.

**Wie kann ich Diagramme finden, die ein aktiviertes Datenblatt haben?**

Iterieren Sie über die Shapes jeder Folie, identifizieren Sie die Diagramme und rufen Sie deren Methode [hasDataTable](https://reference.aspose.com/slides/de/java/com.aspose.slides/chart/#hasDataTable--) auf. Ein Wert von `true` bedeutet, dass das Datenblatt aktiviert ist.