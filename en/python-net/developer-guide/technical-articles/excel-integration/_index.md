---
title: Integrate Excel Data into PowerPoint Presentations
linktitle: Excel Integration
type: docs
weight: 330
url: /python-net/excel-integration/
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
- Aspose.Slides
description: "Read data from Excel workbooks in Aspose.Slides using the ExcelDataWorkbook API. Load sheets and cells and use values to generate data-driven PowerPoint presentations."
---

## **Introduction**

PowerPoint presentations are a powerful way to display and communicate information. They are often used in conjunction with Excel workbooks, where Excel serves as an excellent source of structured data and PowerPoint excels at visualizing that data for an audience.

There are many practical scenarios where combining Excel and PowerPoint is essential: mail merges, populating data tables, generating one slide per data record (batch slide generation), creating training materials, and consolidating multiple Excel reports into a single presentation, to name a few.

Until now, implementing such features with the Aspose.Slides API required relying on third-party solutions like Aspose.Cells. While these tools are robust, they can be overly complex and costly for users who only need basic data integration functionality.

## **How It Works**

To make working with Excel data easier and more streamlined, Aspose.Slides has introduced new classes for reading data from Excel workbooks and importing content into a presentation. This feature opens up powerful new possibilities for API users who want to leverage Excel as a data source within their presentation workflows.

The new functionality is designed for general-purpose data access and is not integrated into the Presentation Document Object Model (DOM). That means *it does not allow editing or saving Excel files* — its sole purpose is to open workbooks and navigate through their content to retrieve cell data.

At the core of this feature is the new [ExcelDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.excel/exceldataworkbook/) class. This class allows you to load an Excel workbook from a local file or a stream. Once loaded, it provides several overloads of the [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) method, which you can use to retrieve specific cells by their position (e.g., row and column indices or named ranges).

Each call to [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) returns an instance of the [ExcelDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.excel/exceldatacell/) class. This object represents a single cell in the Excel workbook and gives you access to its value in a simple and intuitive way.

#### **Import an Excel Chart**

The next step to extend functionality is the [ExcelWorkbookImporter](https://reference.aspose.com/slides/python-net/aspose.slides.importing/excelworkbookimporter/) class. This utility class provides functionality for importing content from an Excel workbook into a presentation. It contains several overloads of the [add_chart_from_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/) method, which help you to retrieve the selected chart from the specified Excel workbook and add it to the end of the given shape collection at the specified coordinates.

In short, it's a lightweight and straightforward API for reading Excel data — exactly what many developers need without the overhead of a full spreadsheet processing library.

## **Let's Code**

### **Mail Merge Scenario Example**

In the following example, we'll implement a simple Mail Merge scenario by generating multiple presentations based on data stored in an Excel workbook.

To get started, we need two things:
1. An Excel workbook containing the data

![Excel data example](example1_image0.png)

2.  PowerPoint presentation template

![PowerPoint template example](example1_image1.png)

```py
import aspose.slides as slides

# Load the Excel workbook with employee data.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Load the presentation template.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Loop through Excel rows (excluding header at row 0).
    for row_index in range(1, 5):

        # Create a new presentation for each employee record.
        with slides.Presentation() as employee_presentation:

            # Remove the default blank slide.
            employee_presentation.slides.remove_at(0)

            # Clone the template slide into the new presentation.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Get paragraphs from the target shape (assumes shape index 1 is used).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Replace the placeholders with data from Excel.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Save the personalized presentation to a separate file.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Result](example1_image2.png)

### **Excel Table Example**

In the second example, we simply copy data from an Excel table and display it on a PowerPoint slide in a more visually appealing format.

In this example, we reuse the same Excel workbook from the first example, which contains a simple employee table.

```py
# Load the Excel workbook containing the employee data.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Create a new PowerPoint presentation.
with slides.Presentation() as presentation:

    # Add a table shape to the first slide.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Fill the PowerPoint table with data from the Excel workbook.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Save the resulting presentation to a file.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Result](example2_image0.png)

### **Import an Excel Chart Example**

In this example, we import a chart from the first worksheet of the Excel workbook used in the previous example. The chart will link to the external workbook in the resulting presentation.

First, we add a Pie chart to the Excel workbook based on the employees table.

![Excel Chart example](example3_image0.png)

```py
# Create a new PowerPoint presentation.
with slides.Presentation() as presentation:
    # Get the shapes collection of the first slide.
    shapes = presentation.slides[0].shapes

    # Import the chart named "Chart 1" from the first sheet of the workbook and add it to the shapes collection.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Save the resulting presentation to a file.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Result](example3_image1.png)

### **Import All Excel Charts Example**

Let's imagine you have an Excel workbook full of charts and you need to import them all into a presentation. Each chart should be placed on a new slide.

The following code iterates through all worksheets in the source Excel file, extracts the charts from each worksheet, and adds each chart to a separate slide using a blank slide layout. In the resulting presentation, only the chart data will be embedded, not the entire workbook.

```py
# Load the Excel workbook containing the employee data.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Create a new PowerPoint presentation.
with slides.Presentation() as presentation:
    # Retrieve the blank slide layout.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Get the names of all worksheets contained in the Excel workbook.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Retrieve a dictionary that maps chart indexes to chart names for the worksheet.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Add a new slide using the blank layout.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Import the specified chart from the Excel workbook into the slide's shapes collection.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Save the resulting presentation to a file.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Summary**

This mechanism, available directly in Aspose.Slides, combines working with Excel data and presentations in one place. It allows you to create slides with visual charts and data presented as Excel tables - without any additional libraries or complex integrations.
