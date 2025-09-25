---
title: Integrate Excel Data into PowerPoint Presentations
linktitle: Excel Integration
type: docs
weight: 330
url: /cpp/excel-integration/
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
- C++
- Aspose.Slides
description: "Read data from Excel workbooks in Aspose.Slides using the ExcelDataWorkbook API. Load sheets and cells and use values to generate data-driven PowerPoint presentations."
---

## **Introduction**

PowerPoint presentations are a powerful way to display and communicate information. They are often used in conjunction with Excel workbooks, where Excel serves as an excellent source of structured data and PowerPoint excels at visualizing that data for an audience.

There are many practical scenarios where combining Excel and PowerPoint is essential: mail merges, populating data tables, generating one slide per data record (batch slide generation), creating training materials, and consolidating multiple Excel reports into a single presentation, to name a few.

Until now, implementing such features with the Aspose.Slides API required relying on third-party solutions like Aspose.Cells. While these tools are robust, they can be overly complex and costly for users who only need basic data integration functionality.

## **How It Works**

To make working with Excel data easier and more streamlined, Aspose.Slides has introduced a new class for reading data from Excel workbooks. This feature opens up powerful new possibilities for API users who want to leverage Excel as a data source within their presentation workflows.

The new functionality is designed for general-purpose data access and is not integrated into the Presentation Document Object Model (DOM). That means *it does not allow editing or saving Excel files* — its sole purpose is to open workbooks and navigate through their content to retrieve cell data.

At the core of this feature is the new [ExcelDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.excel/exceldataworkbook/) class. This class allows you to load an Excel workbook from a local file or a stream. Once loaded, it provides several overloads of the [GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.excel/exceldataworkbook/getcell/) method, which you can use to retrieve specific cells by their position (e.g., row and column indices or named ranges).

Each call to [GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.excel/exceldataworkbook/getcell/) returns an instance of the [ExcelDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.excel/exceldatacell/) class. This object represents a single cell in the Excel workbook and gives you access to its value in a simple and intuitive way.

In short, it's a lightweight and straightforward API for reading Excel data — exactly what many developers need without the overhead of a full spreadsheet processing library.

## **Let's Code**

### **Example 1**

In the following example, we'll implement a simple Mail Merge scenario by generating multiple presentations based on data stored in an Excel workbook.

To get started, we need two things:
1. An Excel workbook containing the data

![Excel data example](example1_image0.png)

2.  PowerPoint presentation template

![PowerPoint template example](example1_image1.png)

```cpp
// Load the Excel workbook with employee data.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Load the presentation template.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Loop through Excel rows (excluding header at row 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Create a new presentation for each employee record.
    auto employeePresentation = MakeObject<Presentation>();

    // Remove the default blank slide.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Clone the template slide into the new presentation.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Get paragraphs from the target shape (assumes shape index 1 is used).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Replace the placeholders with data from Excel.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Save the personalized presentation to a separate file.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Result](example1_image2.png)

### **Example 2**

In the second example, we simply copy data from an Excel table and display it on a PowerPoint slide in a more visually appealing format.

In this example, we reuse the same Excel workbook from the first example, which contains a simple employee table.

```cpp
// Load the Excel workbook containing the employee data.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Create a new PowerPoint presentation.
auto presentation = MakeObject<Presentation>();

// Add a table shape to the first slide.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Fill the PowerPoint table with data from the Excel workbook.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Save the resulting presentation to a file.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Result](example2_image0.png)

## **Summary**

This mechanism, available directly in Aspose.Slides, combines working with Excel data and presentations in one place. It allows you to create slides with visual charts and data presented as Excel tables - without any additional libraries or complex integrations.
