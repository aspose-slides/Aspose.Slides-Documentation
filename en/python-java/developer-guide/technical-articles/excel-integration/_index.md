---
title: Integrate Excel Data into PowerPoint Presentations
linktitle: Excel Integration
type: docs
weight: 330
url: /python-java/excel-integration/
keywords:
- Excel
- workbook
- read Excel
- integrate Excel
- data source
- mail merge
- import table
- Excel into PowerPoint
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Read data from Excel workbooks in Aspose.Slides for Python via Java using the ExcelDataWorkbook API. Load sheets and cells and use values to generate data-driven PowerPoint presentations."
---

## **Introduction**

PowerPoint presentations are a powerful way to display and communicate information. They are often used in conjunction with Excel workbooks, where Excel serves as an excellent source of structured data and PowerPoint excels at visualizing that data for an audience.

There are many practical scenarios where combining Excel and PowerPoint is essential: mail merges, populating data tables, generating one slide per data record (batch slide generation), creating training materials, and consolidating multiple Excel reports into a single presentation, to name a few.

Until now, implementing such features with the Aspose.Slides API required relying on third-party solutions like Aspose.Cells. While these tools are robust, they can be overly complex and costly for users who only need basic data integration functionality.

## **How It Works**

To make working with Excel data easier and more streamlined, Aspose.Slides has introduced new classes for reading data from Excel workbooks and importing content into a presentation. This feature opens up powerful new possibilities for API users who want to leverage Excel as a data source within their presentation workflows.

The new functionality is designed for general-purpose data access and is not integrated into the Presentation Document Object Model (DOM). That means *it does not allow editing or saving Excel files* — its sole purpose is to open workbooks and navigate through their content to retrieve cell data.

At the core of this feature is the new [ExcelDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/exceldataworkbook/) class. This class allows you to load an Excel workbook from a local file or a stream. Once loaded, it provides several overloads of the [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/exceldataworkbook/#getCell) method, which you can use to retrieve specific cells by their position (e.g., row and column indices or named ranges).

Each call to [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/exceldataworkbook/#getCell) returns an [ExcelDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/exceldatacell/) object. This object represents a single cell in the Excel workbook and gives you access to its value in a simple and intuitive way.

#### **Import an Excel Chart**

The next step to extend functionality is the [ExcelWorkbookImporter](https://reference.aspose.com/slides/python-java/aspose.slides/excelworkbookimporter/) class. This utility class provides functionality for importing content from an Excel workbook into a presentation. It contains several overloads of the [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) method, which help you to retrieve the selected chart from the specified Excel workbook and add it to the end of the given shape collection at the specified coordinates.

#### **Import an Excel Table**

The [ExcelWorkbookImporter](https://reference.aspose.com/slides/python-java/aspose.slides/excelworkbookimporter/) class also contains several overloads of the [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) method. These methods allow you to import a specified cell range from a specified worksheet and add it as a table to the end of the given shape collection at the specified coordinates.

In short, it's a lightweight and straightforward API for reading Excel data — exactly what many developers need without the overhead of a full spreadsheet processing library.

## **Let's Code**

### **Mail Merge Scenario Example**

In the following example, we'll implement a simple mail merge scenario by generating multiple presentations based on data stored in an Excel workbook.

To get started, we need two things:

1. An Excel workbook containing the data

![Excel data example](example1_image0.png)

2. A PowerPoint presentation template

![PowerPoint template example](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Load the Excel workbook with employee data.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Load the presentation template.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Loop through Excel rows (excluding header at row 0).
    for row_index in range(1, 5):

        # Create a presentation for each employee record.
        employee_presentation = Presentation()

        try:
            # Remove the default blank slide.
            employee_presentation.getSlides().removeAt(0)

            # Clone the template slide into the presentation.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Get paragraphs from the target shape (assumes shape index 1 is used).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Replace the placeholders with data from Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Save the personalized presentation to a separate file.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Result](example1_image2.png)

### **Excel Table Example**

In the second example, we simply copy data from an Excel table and display it on a PowerPoint slide in a more visually appealing format.

In this example, we reuse the same Excel workbook from the first example, which contains a simple employee table.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Load the Excel workbook containing the employee data.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Create a PowerPoint presentation.
presentation = Presentation()

try:
    # Add a table shape to the first slide.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Fill the PowerPoint table with data from the Excel workbook.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Save the resulting presentation to a file.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example2_image0.png)

### **Import an Excel Chart Example**

In this example, we import a chart from the first worksheet of the Excel workbook used in the previous example. The chart will link to the external workbook in the resulting presentation.

First, we add a pie chart to the Excel workbook based on the employee table.

![Excel Chart example](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Create a PowerPoint presentation.
presentation = Presentation()
try:
    # Get the shapes collection of the first slide.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Import the chart named "Chart 1" from the first sheet of the workbook and add it to the shapes collection.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Save the resulting presentation to a file.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example3_image1.png)

### **Import All Excel Charts Example**

Let's imagine you have an Excel workbook full of charts and you need to import them all into a presentation. Each chart should be placed on a new slide.

The following code iterates through all worksheets in the source Excel file, extracts the charts from each worksheet, and adds each chart to a separate slide using a blank slide layout. In the resulting presentation, only the chart data will be embedded, not the entire workbook.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Load the Excel workbook containing the employee data.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Create a PowerPoint presentation.
presentation = Presentation()
try:
    # Retrieve the blank slide layout.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Remove the default slide so that the result contains one slide per chart.
    presentation.getSlides().removeAt(0)

    # Get the names of all worksheets contained in the Excel workbook.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Retrieve a map that maps chart indexes to chart names for the worksheet.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Add a slide using the blank layout.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Import the specified chart from the Excel workbook into the slide's shapes collection.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Save the resulting presentation to a file.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Import an Excel Table Example**

In this example, we import a formatted table from an Excel worksheet directly into a PowerPoint presentation.

The source Excel worksheet contains a formatted table with employee data:

![Excel Table example](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Create a PowerPoint presentation.
presentation = Presentation()
try:
    # Get the first slide and its shapes collection.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Import the table from the first sheet of the workbook and add it to the shapes collection.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Save the resulting presentation to a file.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example4_image1.png)

## **Summary**

This mechanism, available directly in Aspose.Slides, combines working with Excel data and presentations in one place. It allows you to create slides with visual charts and data presented as Excel tables—without any additional libraries or complex integrations.
