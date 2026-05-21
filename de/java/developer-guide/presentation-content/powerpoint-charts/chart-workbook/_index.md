---
title: Verwalten von Diagramm-Workbooks in Präsentationen mit Java
linktitle: Diagramm-Workbook
type: docs
weight: 70
url: /de/java/chart-workbook/
keywords:
- Diagramm-Workbook
- Diagrammdaten
- Workbook-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- Externes Workbook
- Externe Daten
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Java: Verwalten Sie Diagramm-Workbooks mühelos in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm-Workbooks in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Workbook-Streams liest und schreibt, Workbook-Zellen als Diagrammdatenbeschriftungen verwendet, auf Worksheet-Sammlungen zugreift und den Datentyp für Diagrammwerte angibt.

Er behandelt außerdem die Arbeit mit externen Workbooks als Datenquelle für Diagramme. Die Beispiele demonstrieren, wie man ein externes Workbook erstellt und zuweist, den Pfad eines mit einem Diagramm verknüpften externen Workbooks abruft und Diagrammdaten bearbeitet, wenn das Workbook verfügbar ist.

## **Diagrammdaten aus einem Workbook lesen und schreiben**
Aspose.Slides stellt die Methoden [ReadWorkbookStream](https://reference.aspose.com/slides/de/java/com.aspose.slides/IChartData#readWorkbookStream--) und [WriteWorkbookStream](https://reference.aspose.com/slides/de/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) bereit, mit denen Sie Diagramm-Workbooks (die mit Aspose.Cells bearbeitete Diagrammdaten enthalten) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen auf die gleiche Weise organisiert sein oder eine dem Quell‑Workbook ähnliche Struktur besitzen.

Dieser Java-Code demonstriert einen Beispielvorgang:

```java
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

## **Eine Workbook-Zelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/java/com.aspose.slides/presentation) Klasse.  
2. Rufen Sie über den Index eine Referenz auf eine Folie ab.  
3. Fügen Sie ein Bubble-Diagramm mit einigen Daten hinzu.  
4. Greifen Sie auf die Diagrammserie zu.  
5. Setzen Sie die Workbook-Zelle als Datenbeschriftung.  
6. Speichern Sie die Präsentation.

Dieser Java-Code zeigt, wie man eine Workbook-Zelle als Diagrammdatenbeschriftung festlegt:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
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

## **Worksheets verwalten**

Dieser Java-Code demonstriert einen Vorgang, bei dem die Methode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/de/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) verwendet wird, um auf eine Worksheet-Sammlung zuzugreifen:

```java
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

## **Datentyp der Datenquelle angeben**

Dieser Java-Code zeigt, wie man einen Typ für eine Datenquelle angibt:

```java
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

## **Nicht unterstützte eingebettete Workbook-Formate erkennen**

Aspose.Slides unterstützt das Excel-Binär-Workbook (.xlsb)-Format, das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die Methode `getEmbeddedWorkbookType` auf [IChartData](https://reference.aspose.com/slides/de/java/com.aspose.slides/IChartData) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/java/com.aspose.slides/WorkbookType) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Das eingebettete Workbook ist im .xlsb-Format, das nicht unterstützt wird.
            continue;
        }

        // Lesen oder Ändern Sie hier die Diagramm-Workbook-Daten.
    }
} finally {
    presentation.dispose();
}
```

## **Externes Workbook**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/de/java/aspose-slides-for-java-19-4-release-notes/), haben wir die Unterstützung für externe Workbooks als Datenquelle für Diagramme implementiert.
{{% /alert %}} 

### **Ein externes Workbook erstellen**

Mit den Methoden **`readWorkbookStream`** und **`setExternalWorkbook`** können Sie entweder ein externes Workbook von Grund auf neu erstellen oder ein internes Workbook extern machen.

Dieser Java-Code demonstriert den Prozess zur Erstellung eines externen Workbooks:

```java
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

### **Ein externes Workbook zuweisen**

Mit der Methode **`setExternalWorkbook`** können Sie einem Diagramm ein externes Workbook als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einem externen Workbook zu aktualisieren (falls dieses verschoben wurde).

Obwohl Sie die Daten in Workbooks, die an entfernten Speicherorten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Workbooks dennoch als externe Datenquelle verwenden. Wenn ein relativer Pfad für ein externes Workbook angegeben wird, wird er automatisch in einen vollständigen Pfad umgewandelt.

Dieser Java-Code zeigt, wie man ein externes Workbook zuweist:

```java
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

Der Parameter `ChartData` (bei der Methode `setExternalWorkbook`) gibt an, ob ein Excel-Workbook geladen werden soll oder nicht.

* Wenn der Wert `ChartData` auf `false` gesetzt ist, wird nur der Workbook-Pfad aktualisiert – die Diagrammdaten werden nicht aus dem Ziel‑Workbook geladen oder aktualisiert. Diese Einstellung kann sinnvoll sein, wenn das Ziel‑Workbook nicht existiert oder nicht verfügbar ist.  
* Wenn der Wert `ChartData` auf `true` gesetzt ist, werden die Diagrammdaten aus dem Ziel‑Workbook aktualisiert.

```java
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

### **Den Pfad des externen Datenquellen‑Workbooks eines Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/java/com.aspose.slides/presentation) Klasse.  
2. Rufen Sie über den Index eine Referenz auf eine Folie ab.  
3. Erzeugen Sie ein Objekt für die Diagrammform.  
4. Erzeugen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), der die Datenquelle des Diagramms darstellt.  
5. Geben Sie die entsprechende Bedingung an, basierend darauf, dass der Quelltyp mit dem externen Workbook‑Datenquellentyp übereinstimmt.

Dieser Java-Code demonstriert den Vorgang:

```java
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

Sie können die Daten in externen Workbooks auf dieselbe Weise bearbeiten, wie Sie Änderungen am Inhalt interner Workbooks vornehmen. Wenn ein externes Workbook nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieser Java-Code implementiert den beschriebenen Vorgang:

```java
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

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einem externen oder eingebetteten Workbook verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [Datenquellentyp](https://reference.aspose.com/slides/de/java/com.aspose.slides/chartdata/#getDataSourceType--) und einen [Pfad zu einem externen Workbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ist die Quelle ein externes Workbook, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Workbooks unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Workbooks verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Workbooks können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von entfernten Workbooks über Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle verwendet werden.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/de/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) und verwendet ihn zum Einlesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz ist, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](/cells/java/)) und diese Kopie zu verlinken.

**Können mehrere Diagramme dasselbe externe Workbook referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei verweisen, wird eine Aktualisierung dieser Datei beim nächsten Laden der Daten in jedem Diagramm wirksam.