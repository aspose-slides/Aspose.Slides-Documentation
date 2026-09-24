---
title: Diagrammdatentabellen in Präsentationen für Android anpassen
linktitle: Datentabelle
type: docs
url: /de/androidjava/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schriftart-Eigenschaften
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Passen Sie Schriftarten, Rahmen und Legendenzeichen der Diagrammdatentabelle in PowerPoint-Präsentationen mit Aspose.Slides für Android via Java an."
---
## **Übersicht**

Aspose.Slides für Android via Java ermöglicht das Anzeigen einer Diagrammdatentabelle und das Anpassen ihrer Textformatierung, Rahmen und Legendenzeichen. Dieser Artikel erklärt, wie die Tabelle aktiviert, ihr Text formatiert, jeder Rahmenart gesteuert und Legendenzeichen ein‑ oder ausgeblendet werden. Die Beispiele speichern die konfigurierten Diagramme in PPTX-Dateien.

## **Schriftart‑Eigenschaften festlegen**

Um die Datentabelle eines Diagramms anzuzeigen, übergeben Sie `true` an [setDataTable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). Verwenden Sie [getChartDataTable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chart/#getChartDataTable--) , um auf die Tabelle zuzugreifen und ihre Textformatierung zu konfigurieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/).
2. Fügen Sie der ersten Folie ein gruppiertes Säulendiagramm hinzu.
3. Aktivieren Sie die Datentabelle des Diagramms.
4. Aktivieren Sie Fettdruck mit [setFontBold](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) und übergeben Sie `20` an [setFontHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-), um Text mit 20 Punkt zu erhalten.
5. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erfordert `test.pptx` im Arbeitsverzeichnis mit mindestens einer Folie. Es fügt ein Diagramm mit Standarddaten an Position (50, 50) hinzu, mit einer Breite von 600 Punkten und einer Höhe von 400 Punkten. Die gespeicherte `output.pptx` enthält das Diagramm mit aktivierter Datentabelle und den angewendeten Schriftarteinstellungen.

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

## **Datentabelle‑Rahmen anpassen**

Aktivieren Sie die Tabelle mit [IChart.setDataTable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) und greifen Sie über [IChart.getChartDataTable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/#getChartDataTable--) darauf zu. Sie können drei Rahmenarten unabhängig steuern:

- [setBorderHorizontal](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) steuert horizontale Zellenrahmen.
- [setBorderVertical](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) steuert vertikale Zellenrahmen.
- [setBorderOutline](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) steuert den äußeren Rahmen der Tabelle.

Übergeben Sie `true` an jede Methode, um ihre Rahmen anzuzeigen, oder `false`, um sie zu verbergen. Das folgende Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten, zeigt horizontale Rahmen und den äußeren Rahmen an und versteckt vertikale Rahmen. Es benötigt keine Eingabedatei. Position und Größe des Diagramms werden in Punkten angegeben.

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

Der Vergleich unten verwendet in allen vier Fällen dieselben Diagrammdaten und Legendenzeicheneinstellungen. Beginnend mit allen aktivierten Rahmen, deaktiviert jede weitere Variante nur eine Rahmen‑Einstellung. Die links unten Variante entspricht den Rahmeneinstellungen im Beispiel.

![Diagrammdatentabellen mit allen Rahmen aktiviert, ohne horizontale Rahmen, ohne vertikale Rahmen und ohne äußeren Rahmen](data-table-borders.png)

## **Legendenzeichen ein‑ oder ausblenden**

Legendenzeichen sind kleine farbige Markierungen neben den Seriennamen in der Datentabelle. Sie helfen Lesern, jede Tabellenzeile einer Diagrammserie zuzuordnen. Übergeben Sie `true` an [setShowLegendKey](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) , um diese Markierungen anzuzeigen, oder `false`, um sie zu verbergen.

Die separate Legende des Diagramms wird über [IChart.setLegend](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) gesteuert. Diese Einstellungen sind unabhängig: Das Verbergen der separaten Legende versteckt nicht die Schlüssel in der Datentabelle, und das Verbergen der Tabellen‑Schlüssel versteckt nicht die separate Legende.

Das folgende Beispiel erstellt ein Diagramm mit Standarddaten, aktiviert dessen Datentabelle und zeigt Legendenzeichen darin an, während die separate Legende ausgeblendet wird. Alle Tabellenrahmen sind ausdrücklich aktiviert. Es wird keine Eingabepräsentation benötigt. Um nur die Tabellen‑Schlüssel zu verbergen, übergeben Sie `false` an [setShowLegendKey](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

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

Der Vergleich unten zeigt dieselbe Tabelle mit aktivierten und deaktivierten Legendenzeichen. Alle Rahmen bleiben aktiviert, und die separate Diagrammlegende ist in beiden Fällen ausgeblendet.

![Diagrammdatentabellen mit Legendenzeichen links angezeigt und rechts ausgeblendet](data-table-legend-keys.png)

## **FAQ**

**Kann ich Legendenzeichen in der Datentabelle eines Diagramms anzeigen?**

Ja. Übergeben Sie `true` an [setShowLegendKey](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), um Legendenzeichen anzuzeigen, oder `false`, um sie zu verbergen.

**Bleibt die Datentabelle erhalten, wenn die Präsentation nach PDF, HTML oder Bildern exportiert wird?**

Ja. Aspose.Slides rendert das Diagramm und seine angezeigte Datentabelle als Teil der Folie beim Exportieren nach [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/de/androidjava/convert-powerpoint-to-html/) oder [Bildern](/slides/de/androidjava/convert-powerpoint-to-png/).

**Kann ich mit Datentabellen in Diagrammen arbeiten, die aus einer Vorlage geladen wurden?**

Ja. Für ein Diagramm, das aus einer vorhandenen Präsentation oder Vorlage geladen wurde, verwenden Sie [hasDataTable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chart/#hasDataTable--) und [setDataTable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chart/#setDataTable-boolean-), um zu prüfen oder zu ändern, ob seine Datentabelle angezeigt wird.

**Wie kann ich Diagramme finden, bei denen eine Datentabelle aktiviert ist?**

Durchlaufen Sie die Formen jeder Folie, identifizieren Sie die Diagramme und rufen Sie deren [hasDataTable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chart/#hasDataTable--) Methode auf. Ein Wert von `true` zeigt an, dass die Datentabelle aktiviert ist.