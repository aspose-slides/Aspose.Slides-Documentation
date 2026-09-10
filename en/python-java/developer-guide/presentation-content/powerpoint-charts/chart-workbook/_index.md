---
title: Manage Chart Workbooks in Presentations Using Python via Java
linktitle: Chart Workbook
type: docs
weight: 70
url: /python-java/chart-workbook/
keywords:
- chart workbook
- chart data
- workbook cell
- data label
- worksheet
- data source
- external workbook
- external data
- chart cache
- workbook recovery
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Discover Aspose.Slides for Python via Java: effortlessly manage chart workbooks in PowerPoint and OpenDocument formats to streamline your presentation data."
---

## **Overview**

This article explains how to work with chart workbooks in Aspose.Slides. It shows how to read and write chart data through workbook streams, use workbook cells as chart data labels, access worksheet collections, and specify the data source type for chart values.

It also covers working with external workbooks as chart data sources. The examples demonstrate how to create and assign an external workbook, retrieve the path of an external workbook linked to a chart, and edit chart data when the workbook is available.

## **Read and Write Chart Data from a Workbook**
Aspose.Slides provides the [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) and [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This Python code demonstrates a sample operation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Validate Chart Layout After Workbook Modification**

When you replace an embedded workbook with a modified one, the chart retains its original series and category collections. This inconsistency can cause [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) to throw an `ArgumentOutOfRangeException` (parameter: index). To avoid the exception, clear the existing series and categories **before** writing the updated workbook back to the chart.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Read the workbook after modifying it (e.g., using Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Clear existing data references.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Clearing the collections ensures that the chart data structure aligns with the new workbook, allowing [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) to complete without errors.

## **Set a Workbook Cell as a Chart Data Label**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Add a Bubble chart with some data.
1. Access the chart series.
1. Set the workbook cell as a data label.
1. Save the presentation.

This Python code shows you how to set a workbook cell as a chart data label:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Manage Worksheets**

This Python code demonstrates an operation where the [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) method is used to access a worksheet collection:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Specify the Data Source Type**

This Python code shows you how to specify a type for a data source:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides does not support the Excel binary workbook (.xlsb) format that can be embedded in some charts. You can use the [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) method on [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) together with the [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) enumeration to detect unsupported formats and skip those charts.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Embedded workbook is in .xlsb format, which is not supported.
            continue
        # Read or modify the chart workbook data here.
finally:
    presentation.dispose()
```

### **Create an External Workbook**

Using the [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) and [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) methods, you can either create an external workbook from scratch or make an internal workbook external.

This Python code demonstrates the external workbook creation process:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Set an External Workbook**

Using the [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This Python code shows you how to set an external workbook:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The second (`bool`) parameter of the [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) method is used to specify whether an Excel workbook will be loaded or not. 

* When its value is set to `False`, only the workbook path gets updated—the chart data will not be loaded or updated from the target workbook. You may want to use this setting when in a situation where the target workbook is nonexistent or unavailable. 
* When its value is set to `True`, the chart data gets updated from the target workbook.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Get the External Data Source Workbook Path of a Chart**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Create an object for the chart shape.
1. Create an object for the source ([ChartDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatasourcetype/)) type that represents the chart's data source.
1. Specify the relevant condition based on the source type being the same as the external workbook data source type.

This Python code demonstrates the operation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Edit Chart Data**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

This Python code is an implementation of the described process:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Recover a Workbook from the Chart Cache**

If a chart uses an external workbook that is missing or unavailable, Aspose.Slides can reconstruct the chart workbook from the data cached in the presentation. Create [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), configure it with [SpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/), and call [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) with `True` before opening the presentation.

The following Python example opens a presentation whose chart references an unavailable external workbook and accesses the recovered data through [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) and [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Read or modify the recovered workbook data here.
finally:
    presentation.dispose()
```

If the external workbook is unavailable and recovery is disabled, Aspose.Slides throws an exception. Enable recovery only when using the cached chart data is an acceptable fallback, because the cache may not contain changes made to the external workbook after the presentation was last updated.

## **FAQ**

**Can I determine whether a specific chart is linked to an external or an embedded workbook?**

Yes. A chart has a [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) and a [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); if the source is an external workbook, you can read the full path to make sure an external file is being used.

**Are relative paths to external workbooks supported, and how are they stored?**

Yes. If you specify a relative path, it is automatically converted to an absolute path. This is convenient for project portability; however, be aware that the presentation will store the absolute path in the PPTX file.

**Can I use workbooks located on network resources/shares?**

Yes, such workbooks can be used as an external data source. However, editing remote workbooks directly from Aspose.Slides is not supported—they can only be used as a source.

**Does Aspose.Slides overwrite the external XLSX when saving the presentation?**

No. The presentation stores a [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) and uses it for reading data. The external file itself is not modified when the presentation is saved.

**What should I do if the external file is password-protected?**

Aspose.Slides does not accept a password when linking. A common approach is to remove protection in advance or prepare a decrypted copy (for example, using [Aspose.Cells](/cells/python-java/)) and link to that copy.

**Can multiple charts reference the same external workbook?**

Yes. Each chart stores its own link. If they all point to the same file, updating that file will be reflected in each chart the next time the data is loaded.
