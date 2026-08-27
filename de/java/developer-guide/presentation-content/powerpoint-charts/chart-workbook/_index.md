---
title: Diagramm-Arbeitsmappen in Präsentationen mit Java verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/java/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsmappenzelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externe Arbeitsmappe
- externe Daten
- Diagramm-Cache
- Arbeitsmappen-Wiederherstellung
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Java: Verwalten Sie Diagramm‑Arbeitsmappen in PowerPoint‑ und OpenDocument‑Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp für Diagrammwerte angibt.

Er behandelt außerdem die Arbeit mit externen Arbeitsmappen als Diagrammdatenquellen. Die Beispiele zeigen, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer mit einem Diagramm verknüpften externen Arbeitsmappe abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**
Aspose.Slides stellt die Methoden [ReadWorkbookStream](https://reference.aspose.com/slides/de/java/com.aspose.slides/IChartData#readWorkbookStream--) und [WriteWorkbookStream](https://reference.aspose.com/slides/de/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) bereit, mit denen Sie Diagramm‑Daten‑Arbeitsmappen (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine dem Quellformat ähnliche Struktur besitzen.

Dieser Java‑Code demonstriert ein Beispiel:

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

### **Diagrammlayout nach Arbeitsmappen‑Änderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine geänderte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategorien‑Sammlungen bei. Diese Inkonsistenz kann dazu führen, dass `chart.validateChartLayout()` eine `ArgumentOutOfRangeException` (Parameter: index) auslöst. Um die Ausnahme zu vermeiden, leeren Sie die vorhandenen Serien und Kategorien **vor** dem Schreiben der aktualisierten Arbeitsmappe zurück in das Diagramm.

```java
// Nach dem Ändern des Arbeitsmappen-Streams (z. B. mit Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Vorhandene Datenreferenzen löschen.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Aktualisierte Arbeitsmappe zurück in das Diagramm schreiben.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Jetzt schlägt die Validierung.
chart.validateChartLayout();
```

Das Leeren der Sammlungen stellt sicher, dass die Diagrammdatenstruktur mit der neuen Arbeitsmappe übereinstimmt, sodass `validateChartLayout()` ohne Fehler abgeschlossen werden kann.

## **Eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://apireference.aspose.com/slides/de/java/com.aspose.slides/presentation) .
2. Rufen Sie über den Index die Referenz einer Folie ab.
3. Fügen Sie ein Bubble‑Diagramm mit Daten hinzu.
4. Greifen Sie auf die Diagramm‑Serien zu.
5. Setzen Sie die Arbeitsmappen‑Zelle als Datenbeschriftung.
6. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie Sie eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
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

Dieser Java‑Code demonstriert einen Vorgang, bei dem die Methode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/de/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:

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

## **Den Datentyp der Quelle angeben**

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

## **Erkennen nicht unterstützter eingebetteter Arbeitsmappen‑Formate**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappenformat (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die Methode `getEmbeddedWorkbookType` auf [IChartData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IChartData) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/java/com.aspose.slides/WorkbookType) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

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

        // Lese oder bearbeite hier die Diagramm-Arbeitsmappendaten.
    }
} finally {
    presentation.dispose();
}
```

## **Externe Arbeitsmappe**

{{% alert color="info" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/de/java/aspose-slides-for-java-19-4-release-notes/), wir haben die Unterstützung für externe Arbeitsmappen als Datenquelle für Diagramme implementiert.
{{% /alert %}} 

### **Eine externe Arbeitsmappe erstellen**

Mit den Methoden **`readWorkbookStream`** und **`setExternalWorkbook`** können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe extern machen.

Dieser Java‑Code demonstriert den Prozess zur Erstellung einer externen Arbeitsmappe:

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

### **Eine externe Arbeitsmappe setzen**

Mit der Methode **`setExternalWorkbook`** können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zur externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Obwohl Sie die Daten in Arbeitsmappen, die an entfernten Orten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle verwenden. Wird ein relativer Pfad zu einer externen Arbeitsmappe angegeben, wird er automatisch in einen vollständigen Pfad umgewandelt.

Dieser Java‑Code zeigt, wie Sie eine externe Arbeitsmappe setzen:

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

Der zweite (`boolean`)-Parameter der Methode `setExternalWorkbook` gibt an, ob eine Excel‑Arbeitsmappe geladen werden soll oder nicht. 

* Wenn sein Wert auf `false` gesetzt ist, wird nur der Pfad der Arbeitsmappe aktualisiert – die Diagrammdaten werden nicht aus der Ziel‑Arbeitsmappe geladen oder aktualisiert. Diese Einstellung kann sinnvoll sein, wenn die Ziel‑Arbeitsmappe nicht existiert oder nicht verfügbar ist. 
* Wenn sein Wert auf `true` gesetzt ist, werden die Diagrammdaten aus der Ziel‑Arbeitsmappe aktualisiert.

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

### **Den Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms abrufen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://apireference.aspose.com/slides/de/java/com.aspose.slides/presentation) .
2. Rufen Sie über den Index die Referenz einer Folie ab.
3. Erstellen Sie ein Objekt für die Diagramm‑Form.
4. Erstellen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), der die Datenquelle des Diagramms darstellt.
5. Geben Sie die relevante Bedingung an, basierend darauf, dass der Quelltyp dem Typ der externen Arbeitsmappen‑Datenquelle entspricht.

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

### **Eine Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Verwendet ein Diagramm eine fehlende oder nicht verfügbare externe Arbeitsmappe, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/), konfigurieren Sie diese mit [SpreadsheetOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/spreadsheetoptions/), und rufen Sie vor dem Öffnen der Präsentation [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) mit `true` auf.

Das folgende Java‑Beispiel öffnet eine Präsentation, deren Diagramm auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [IChart.getChartData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichart/#getChartData--) und [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) auf die wiederhergestellten Daten zu:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Lese oder bearbeite hier die wiederhergestellten Arbeitsmappendaten.
} finally {
    presentation.dispose();
}
```

Ist die externe Arbeitsmappe nicht verfügbar und ist die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Rückgriff ist, da der Cache Änderungen, die nach der letzten Aktualisierung der Präsentation an der externen Arbeitsmappe vorgenommen wurden, möglicherweise nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm besitzt einen [Datenquellentyp](https://reference.aspose.com/slides/de/java/com.aspose.slides/chartdata/#getDataSourceType--) und einen [Pfad zu einer externen Arbeitsmappe](https://reference.aspose.com/slides/de/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ist die Quelle eine externe Arbeitsmappe, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von entfernten Arbeitsmappen über Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle genutzt werden.

**Überschreibt Aspose.Slides die externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/de/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) , der zum Lesen der Daten verwendet wird. Die externe Datei selbst wird beim Speichern der Präsentation nicht geändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz ist, den Schutz im Vorfeld zu entfernen oder eine entschlüsselte Kopie vorzubereiten (zum Beispiel mit [Aspose.Cells](/cells/java/)) und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei beim nächsten Laden der Daten in jedem Diagramm berücksichtigt.