---
title: Diagramm-Arbeitsmappen in Präsentationen mit JavaScript verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/nodejs-java/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsmappen-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- Externe Arbeitsmappe
- Externe Daten
- Diagramm-Cache
- Arbeitsmappen-Wiederherstellung
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Node.js über Java: verwalten Sie mühelos Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp für Diagrammwerte angibt.

Er behandelt außerdem die Arbeit mit externen Arbeitsmappen als Datenquelle für Diagramme. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer mit einem Diagramm verknüpften externen Arbeitsmappe abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**

Aspose.Slides stellt die Methoden [readWorkbookStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) und [writeWorkbookStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) bereit, mit denen Sie Diagramm‑Datenarbeitsmappen (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine Struktur haben, die der Quelle ähnlich ist.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Diagrammlayout nach Arbeitsmappen‑Änderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine geänderte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategoriesammlungen bei. Diese Diskrepanz kann dazu führen, dass [Chart.validateChartLayout](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Chart#validateChartLayout--) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die bestehenden Serien und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben.

```javascript
// Nach dem Ändern des Arbeitsmappen-Streams (z. B. mit Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Vorhandene Datenreferenzen löschen.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Das Löschen der Sammlungen sorgt dafür, dass die Diagrammdatenstruktur mit der neuen Arbeitsmappe übereinstimmt, sodass `validateChartLayout` ohne Fehler abgeschlossen werden kann.

## **Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation) Klasse.  
2. Rufen Sie den Verweis auf eine Folie über deren Index ab.  
3. Fügen Sie ein Blasendiagramm mit einigen Daten hinzu.  
4. Greifen Sie auf die Diagramm‑Serie zu.  
5. Legen Sie die Arbeitsmappen‑Zelle als Datenbeschriftung fest.  
6. Speichern Sie die Präsentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Dieses JavaScript‑Beispiel demonstriert eine Operation, bei der die Methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Datentyp für Datenquelle angeben**

Dieses JavaScript‑Beispiel zeigt, wie Sie einen Typ für eine Datenquelle angeben:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Erkennung nicht unterstützter eingebetteter Arbeitsmappen‑Formate**

Aspose.Slides unterstützt das Excel‑Binary‑Arbeitsmappenformat (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die Methode `getEmbeddedWorkbookType` auf [ChartData](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
            // Eingebettete Arbeitsmappe liegt im .xlsb-Format vor, das nicht unterstützt wird.
            continue;
        }

        // Hier Diagramm-Arbeitsmappendaten lesen oder ändern.
    }
} finally {
    presentation.dispose();
}
```

## **Externe Arbeitsmappe**

Aspose.Slides unterstützt externe Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappe erstellen**

Mit den Methoden **`readWorkbookStream`** und **`setExternalWorkbook`** können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe extern machen.

Dieses JavaScript‑Beispiel demonstriert den Erstellungsprozess einer externen Arbeitsmappe:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream liefert die Arbeitsmappen-Bytes als Node Buffer.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
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

Mit der Methode **`setExternalWorkbook`** können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann auch verwendet werden, um einen Pfad zur externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Obwohl Sie die Daten in Arbeitsmappen, die an entfernten Speicherorten oder Ressourcen liegen, nicht direkt bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle verwenden. Wenn ein relativer Pfad für eine externe Arbeitsmappe angegeben wird, wird er automatisch in einen vollständigen Pfad umgewandelt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Der zweite Parameter der `setExternalWorkbook`‑Methode, `updateChartData`, gibt an, ob die Excel‑Arbeitsmappe geladen wird oder nicht.

* Wenn `updateChartData` auf `false` gesetzt ist, wird nur der Arbeitsmappen‑Pfad aktualisiert — die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Diese Einstellung ist nützlich, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.  
* Wenn `updateChartData` auf `true` gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation) Klasse.  
2. Rufen Sie den Verweis auf eine Folie über deren Index ab.  
3. Erstellen Sie ein Objekt für die Diagramm‑Form.  
4. Erstellen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), das die Datenquelle des Diagramms darstellt.  
5. Geben Sie die entsprechende Bedingung an, basierend darauf, dass der Quelltyp dem Typ einer externen Arbeitsmappe entspricht.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Sie können die Daten in externen Arbeitsmappen auf dieselbe Weise bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Eine Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm eine externe Arbeitsmappe verwendet, die fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Arbeitsmappen‑Objekt aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/), konfigurieren Sie diese mit [SpreadsheetOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/spreadsheetoptions/), und rufen Sie [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) mit `true` auf, bevor Sie die Präsentation öffnen.

Das folgende JavaScript‑Beispiel öffnet eine Präsentation, deren Diagramm auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) auf die wiederhergestellten Daten zu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Hier wiederhergestellte Arbeitsmappendaten lesen oder ändern.
} finally {
    presentation.dispose();
}
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Fallback ist, da der Cache Änderungen, die nach dem letzten Speichern der Präsentation an der externen Arbeitsmappe vorgenommen wurden, möglicherweise nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm hat einen [Datenquellentyp](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) und einen [Pfad zu einer externen Arbeitsmappe](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); wenn die Quelle eine externe Arbeitsmappe ist, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen verwenden, die auf Netzwerkressourcen/Freigaben liegen?**

Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten entfernter Arbeitsmappen aus Aspose.Slides wird jedoch nicht unterstützt — sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides die externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) und verwendet ihn zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert kein Passwort beim Verknüpfen. Ein gängiger Ansatz ist, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](/cells/nodejs-java/)) vorzubereiten und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jeder Diagramm speichert seinen eigenen Link. Wenn alle auf dieselbe Datei zeigen, werden Änderungen an dieser Datei bei jedem Laden der Daten in den jeweiligen Diagrammen wirksam.