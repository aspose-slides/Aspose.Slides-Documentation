---
title: Diagramm‑Arbeitsmappen in Präsentationen auf Android verwalten
linktitle: Diagramm‑Arbeitsmappe
type: docs
weight: 70
url: /de/androidjava/chart-workbook/
keywords:
- Diagramm‑Arbeitsmappe
- Diagrammdaten
- Arbeitsmappe‑Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externe Arbeitsmappe
- externe Daten
- Diagramm‑Cache
- Arbeitsmappen‑Wiederherstellung
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Android via Java: verwalten Sie mühelos Diagramm‑Arbeitsmappen in PowerPoint- und OpenDocument‑Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagramm‑Datenbeschriftungen verwendet, auf Arbeitsblatt‑Kollektionen zugreift und den Datentyp‑Quellentyp für Diagrammwerte angibt.

Er behandelt außerdem die Arbeit mit externen Arbeitsmappen als Diagramm‑Datenquellen. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer externen Arbeitsmappe, die mit einem Diagramm verknüpft ist, abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

## **Diagrammdatendaten aus einer Arbeitsmappe lesen und schreiben**
Aspose.Slides stellt die [ReadWorkbookStream](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) und [WriteWorkbookStream](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) Methoden bereit, mit denen Sie Diagramm‑Arbeitsmappen (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis:** Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelle besitzen.

Dieser Java‑Code demonstriert einen Beispielvorgang:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Diagrammlayout nach Arbeitsmappen‑Modifizierung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine modifizierte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategorien‑Kollektionen bei. Diese Diskrepanz kann dazu führen, dass [IChart.validateChartLayout](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChart#validateChartLayout--) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die vorhandenen Serien und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben.

```java
// Nach dem Ändern des Arbeitsmappen-Streams (z. B. mit Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Vorhandene Datenreferenzen löschen.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Das Leeren der Kollektionen stellt sicher, dass die Diagrammdatenstruktur mit der neuen Arbeitsmappe übereinstimmt, sodass `validateChartLayout` ohne Fehler abgeschlossen werden kann.

## **Eine Arbeitsmappen‑Zelle als Diagramm‑Datenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) Klasse.  
2. Holen Sie sich über den Index einen Verweis auf eine Folie.  
3. Fügen Sie ein Blasendiagramm mit einigen Daten hinzu.  
4. Greifen Sie auf die Diagramm‑Serie zu.  
5. Legen Sie die Arbeitsmappen‑Zelle als Datenbeschriftung fest.  
6. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie Sie eine Arbeitsmappen‑Zelle als Diagramm‑Datenbeschriftung festlegen:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Arbeitsblätter verwalten**

Dieser Java‑Code demonstriert einen Vorgang, bei dem die Methode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) verwendet wird, um auf eine Arbeitsblatt‑Kollektion zuzugreifen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Datentyp‑Quelle angeben**

Dieser Java‑Code zeigt, wie Sie einen Typ für eine Datenquelle angeben:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nicht unterstützte eingebettete Arbeitsmappen‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet werden kann. Sie können die Methode `getEmbeddedWorkbookType` auf [IChartData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartData) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/WorkbookType) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Eingebettete Arbeitsmappe ist im .xlsb-Format, das nicht unterstützt wird.
            continue;
        }

        // Diagramm‑Arbeitsmappendaten hier lesen oder ändern.
    }
} finally {
    presentation.dispose();
}
```

## **Externe Arbeitsmappe**

Aspose.Slides unterstützt externe Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappe erstellen**

Mit den Methoden **`readWorkbookStream`** und **`setExternalWorkbook`** können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe extern machen.

Dieser Java‑Code demonstriert den Erstellungsprozess einer externen Arbeitsmappe:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Externe Arbeitsmappe zuweisen**

Mit der Methode **`setExternalWorkbook`** können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zur externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Während Sie die Daten in Arbeitsmappen, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle nutzen. Wird ein relativer Pfad für eine externe Arbeitsmappe angegeben, wird er automatisch in einen vollständigen Pfad umgewandelt.

Dieser Java‑Code zeigt, wie Sie eine externe Arbeitsmappe festlegen:

```java
import com.aspose.slides.*;

// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Der Parameter `updateChartData` (unter der Methode `setExternalWorkbook`) gibt an, ob eine Excel‑Arbeitsmappe geladen wird oder nicht.

* Wenn `updateChartData` auf `false` gesetzt ist, wird nur der Arbeitsmappen‑Pfad aktualisiert – die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Diese Einstellung ist nützlich, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.  
* Wenn `updateChartData` auf `true` gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

```java
import com.aspose.slides.*;

// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms ermitteln**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) Klasse.  
2. Holen Sie sich über den Index einen Verweis auf eine Folie.  
3. Erstellen Sie ein Objekt für die Diagramm‑Form.  
4. Erstellen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), das die Datenquelle des Diagramms darstellt.  
5. Geben Sie die relevante Bedingung an, basierend darauf, dass der Quelltyp dem externen Arbeitsmappen‑Datenquelltyp entspricht.

Dieser Java‑Code demonstriert den Vorgang:

```java
import com.aspose.slides.*;

// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Speichert die Präsentation
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen auf dieselbe Weise bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieser Java‑Code implementiert den beschriebenen Prozess:

```java
import com.aspose.slides.*;

// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Verwendet ein Diagramm eine externe Arbeitsmappe, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Dokument gecachten Daten rekonstruieren. Erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/), konfigurieren Sie es mit [SpreadsheetOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/spreadsheetoptions/), und rufen Sie [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) mit `true` auf, bevor Sie die Präsentation öffnen.

Das folgende Java‑Beispiel öffnet eine Präsentation, deren Diagramm eine nicht verfügbare externe Arbeitsmappe referenziert, und greift über [IChart.getChartData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/#getChartData--) und [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) auf die wiederhergestellten Daten zu:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Wiederhergestellte Arbeitsmappendaten hier lesen oder ändern.
} finally {
    presentation.dispose();
}
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten als akzeptabler Fallback gilt, da der Cache möglicherweise Änderungen enthält, die nach dem letzten Speichern der Präsentation an der externen Arbeitsmappe vorgenommen wurden.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [data source type](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) und einen [path to an external workbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ist die Quelle eine externe Arbeitsmappe, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wird ein relativer Pfad angegeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen auf Netzwerkressourcen/Freigaben verwenden?**

Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten entfernter Arbeitsmappen aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides die externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) und verwendet ihn zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht geändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert kein Passwort beim Verknüpfen. Ein gängiger Ansatz ist, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mithilfe von [Aspose.Cells](/cells/androidjava/)) vorzubereiten und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, werden Änderungen an dieser Datei bei jedem nächsten Laden der Daten in allen Diagrammen wirksam.