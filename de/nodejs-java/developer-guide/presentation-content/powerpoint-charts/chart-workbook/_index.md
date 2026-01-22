---
title: Verwalten von Diagramm-Arbeitsmappen in Präsentationen mit JavaScript
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/nodejs-java/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsblattzelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externe Arbeitsmappe
- externe Daten
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Node.js über Java: verwalten Sie Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---

## **Diagrammdaten aus Arbeitsmappe festlegen**
Aspose.Slides stellt die [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) und [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) Methoden bereit, mit denen Sie Diagrammdatensätze von Arbeitsmappen lesen und schreiben können (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden). **Hinweis**: Die Diagrammdaten müssen auf dieselbe Weise organisiert sein oder eine Struktur haben, die der Quelle ähnlich ist.

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


## **Arbeitsblattzelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie ein Blasendiagramm mit einigen Daten hinzu.  
4. Greifen Sie auf die Diagrammreihe zu.  
5. Legen Sie die Arbeitsblattzelle als Datenbeschriftung fest.  
6. Speichern Sie die Präsentation.

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
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

Dieses JavaScript‑Beispiel zeigt einen Vorgang, bei dem die [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) Methode verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:
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


## **Datentyp der Datenquelle angeben**

Dieses JavaScript‑Beispiel zeigt, wie Sie einen Typ für eine Datenquelle angeben:
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


## **Externe Arbeitsmappe**

Aspose.Slides unterstützt externe Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappe erstellen**

Durch die Verwendung der **`readWorkbookStream`** und **`setExternalWorkbook`** Methoden können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe extern machen.

Dieses JavaScript‑Beispiel demonstriert den Erstellungsprozess einer externen Arbeitsmappe:
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


### **Externe Arbeitsmappe festlegen**

Mit der **`setExternalWorkbook`** Methode können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann auch verwendet werden, um einen Pfad zu einer externen Arbeitsmappe zu aktualisieren (falls die Datei verschoben wurde).

Während Sie die Daten in Arbeitsmappen, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie solche Arbeitsmappen trotzdem als externe Datenquelle verwenden. Wird ein relativer Pfad für eine externe Arbeitsmappe angegeben, wird er automatisch in einen vollständigen Pfad umgewandelt.

Dieses JavaScript‑Beispiel zeigt, wie Sie eine externe Arbeitsmappe festlegen:
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


Der `ChartData`‑Parameter (unter der `setExternalWorkbook`‑Methode) gibt an, ob eine Excel‑Arbeitsmappe geladen wird oder nicht.

* Wenn der `ChartData`‑Wert auf `false` gesetzt ist, wird nur der Pfad zur Arbeitsmappe aktualisiert – die Diagrammdaten werden nicht aus der Ziel‑Arbeitsmappe geladen oder aktualisiert. Diese Einstellung ist nützlich, wenn die Ziel‑Arbeitsmappe nicht existiert oder nicht verfügbar ist.  
* Wenn der `ChartData`‑Wert auf `true` gesetzt ist, werden die Diagrammdaten aus der Ziel‑Arbeitsmappe aktualisiert.
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


### **Pfad zur externen Datenquellen‑Arbeitsmappe des Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Erstellen Sie ein Objekt für das Diagramm‑Shape.  
4. Erstellen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), das die Datenquelle des Diagramms repräsentiert.  
5. Geben Sie die relevante Bedingung an, basierend darauf, dass der Quelltyp dem Typ der externen Arbeitsmappe entspricht.

Dieses JavaScript‑Beispiel demonstriert den Vorgang:
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

Sie können die Daten in externen Arbeitsmappen genauso bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses JavaScript‑Beispiel implementiert den beschriebenen Prozess:
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


## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [Datenquellentyp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) und einen [Pfad zu einer externen Arbeitsmappe](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); wenn die Quelle eine externe Arbeitsmappe ist, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das erleichtert die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von Remote‑Arbeitsmappen aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [Verweis auf die externe Datei](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) und verwendet diesen zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was ist zu tun, wenn die externe Datei durch ein Passwort geschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz ist, den Schutz vorab zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](/cells/nodejs-java/)) und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Verweis. Wenn alle auf dieselbe Datei zeigen, wird ein Update dieser Datei in allen Diagrammen beim nächsten Laden der Daten sichtbar.