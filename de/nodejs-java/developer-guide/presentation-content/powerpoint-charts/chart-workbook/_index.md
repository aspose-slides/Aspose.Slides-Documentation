---
title: Verwalten von Diagramm-Workbooks in Präsentationen mit JavaScript
linktitle: Diagramm-Workbook
type: docs
weight: 70
url: /de/nodejs-java/chart-workbook/
keywords:
- Diagramm-Workbook
- Diagrammdaten
- Workbook-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externes Workbook
- externe Daten
- Diagramm-Cache
- Workbook-Wiederherstellung
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Node.js über Java: Verwalten Sie Diagramm-Workbooks in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Workbooks in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Workbook‑Streams liest und schreibt, Workbook‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp der Datenquelle für Diagrammwerte festlegt.

Er behandelt außerdem die Arbeit mit externen Workbooks als Datenquelle für Diagramme. Die Beispiele demonstrieren, wie man ein externes Workbook erstellt und zuweist, den Pfad eines mit einem Diagramm verknüpften externen Workbooks abruft und Diagrammdaten bearbeitet, wenn das Workbook verfügbar ist.

## **Diagrammdaten aus einem Workbook lesen und schreiben**

Aspose.Slides stellt die [readWorkbookStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) und [writeWorkbookStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) Methoden zur Verfügung, mit denen Sie Diagramm‑Workbooks (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis:** Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine Struktur besitzen, die der Quelle ähnlich ist.

Dieser JavaScript‑Code demonstriert eine Beispieloperation:

```javascript
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Workbook‑Zelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie über ihren Index.  
3. Fügen Sie ein Blasendiagramm mit einigen Daten hinzu.  
4. Greifen Sie auf die Diagrammserie zu.  
5. Setzen Sie die Workbook‑Zelle als Datenbeschriftung.  
6. Speichern Sie die Präsentation.

Dieser JavaScript‑Code zeigt, wie Sie eine Workbook‑Zelle als Diagrammdatenbeschriftung festlegen:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Arbeitsblätter verwalten**

Dieser JavaScript‑Code demonstriert einen Vorgang, bei dem die [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--)‑Methode verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Datentyp der Datenquelle festlegen**

Dieser JavaScript‑Code zeigt, wie man einen Typ für eine Datenquelle festlegt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nicht unterstützte eingebettete Workbook‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binär‑Workbook‑Format (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die `getEmbeddedWorkbookType`‑Methode auf [ChartData](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/) zusammen mit der [WorkbookType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/workbooktype/)‑Enumeration verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // Das eingebettete Workbook ist im .xlsb-Format, das nicht unterstützt wird.
            continue;
        }

        // Lesen oder ändern Sie hier die Diagramm-Workbook-Daten.
    }
} finally {
    presentation.dispose();
}
```

## **Externes Workbook**

Aspose.Slides unterstützt externe Workbooks als Datenquelle für Diagramme.

### **Externes Workbook erstellen**

Mit den **`readWorkbookStream`**‑ und **`setExternalWorkbook`**‑Methoden können Sie entweder ein externes Workbook von Grund auf neu erstellen oder ein internes Workbook extern machen.

Dieser JavaScript‑Code demonstriert den Vorgang zur Erstellung eines externen Workbooks:

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Externes Workbook festlegen**

Mit der **`setExternalWorkbook`**‑Methode können Sie einem Diagramm ein externes Workbook als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einem externen Workbook zu aktualisieren (falls dieses verschoben wurde).

Während Sie die Daten in Workbooks, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie solche Workbooks dennoch als externe Datenquelle nutzen. Wenn ein relativer Pfad für ein externes Workbook angegeben wird, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieser JavaScript‑Code zeigt, wie Sie ein externes Workbook festlegen:

```javascript
// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Der `ChartData`‑Parameter (unter der `setExternalWorkbook`‑Methode) wird verwendet, um anzugeben, ob ein Excel‑Workbook geladen werden soll oder nicht.

* Wird der `ChartData`‑Wert auf `false` gesetzt, wird nur der Workbook‑Pfad aktualisiert – die Diagrammdaten werden nicht aus dem Ziel‑Workbook geladen oder aktualisiert. Diese Einstellung ist nützlich, wenn das Ziel‑Workbook nicht existiert oder nicht verfügbar ist.  
* Wird der `ChartData`‑Wert auf `true` gesetzt, werden die Diagrammdaten aus dem Ziel‑Workbook aktualisiert.

```javascript
// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Pfad des externen Datenquellen‑Workbooks des Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie über ihren Index.  
3. Erstellen Sie ein Objekt für die Diagramm‑Form.  
4. Erstellen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), das die Datenquelle des Diagramms darstellt.  
5. Geben Sie die relevante Bedingung an, basierend darauf, dass der Quelltyp dem Typ der externen Workbook‑Datenquelle entspricht.

Dieser JavaScript‑Code demonstriert den Vorgang:

```javascript
// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Speichert die Präsentation
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Workbooks auf dieselbe Weise bearbeiten, wie Sie Änderungen an internen Workbooks vornehmen. Wenn ein externes Workbook nicht geladen werden kann, wird eine Ausnahme ausgelöst.

```javascript
// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ein Workbook aus dem Diagramm‑Cache wiederherstellen**

Falls ein Diagramm ein externes Workbook verwendet, das fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Workbook aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/), konfigurieren Sie sie mit [SpreadsheetOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/spreadsheetoptions/), und rufen Sie [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) mit `true` auf, bevor Sie die Präsentation öffnen.

Das folgende JavaScript‑Beispiel öffnet eine Präsentation, deren Diagramm auf ein nicht verfügbares externes Workbook verweist, und greift über [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) auf die wiederhergestellten Daten zu:

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Lesen oder ändern Sie hier die wiederhergestellten Workbook-Daten.
} finally {
    presentation.dispose();
}
```

Ist das externe Workbook nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Rückgriff ist, da der Cache möglicherweise Änderungen am externen Workbook nach dem letzten Aktualisieren der Präsentation nicht enthält.

## **FAQ**

**Kann ich bestimmen, ob ein bestimmtes Diagramm mit einem externen oder eingebetteten Workbook verknüpft ist?**  
Ja. Ein Diagramm hat einen [Datenquellentyp](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) und einen [Pfad zu einem externen Workbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); ist die Quelle ein externes Workbook, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Workbooks unterstützt und wie werden sie gespeichert?**  
Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Workbooks verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**  
Ja, solche Workbooks können als externe Datenquelle verwendet werden. Das direkte Bearbeiten entfernter Workbooks aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**  
Nein. Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) und verwendet ihn zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**  
Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mithilfe von [Aspose.Cells](/cells/nodejs-java/)) vorzubereiten und dann auf diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Workbook‑Datei referenzieren?**  
Ja. Jedes Diagramm speichert seinen eigenen Link. Verweisen sie alle auf dieselbe Datei, wird eine Aktualisierung dieser Datei in jedem Diagramm beim nächsten Laden der Daten wirksam.