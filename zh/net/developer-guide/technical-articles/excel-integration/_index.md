---
title: 将 Excel 数据集成到 PowerPoint 演示文稿中
linktitle: Excel 集成
type: docs
weight: 330
url: /zh/net/excel-integration/
keywords:
- Excel
- 工作簿
- 读取 Excel
- 集成 Excel
- 数据源
- 邮件合并
- 导入表格
- Excel 到 PowerPoint
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 ExcelDataWorkbook API 在 Aspose.Slides 中读取 Excel 工作簿的数据。加载工作表和单元格并使用其值生成数据驱动的 PowerPoint 演示文稿。"
---
## **简介**

PowerPoint 演示文稿是展示和传达信息的强大方式。它们通常与 Excel 工作簿一起使用，Excel 充当结构化数据的优秀源头，而 PowerPoint 则擅长将这些数据可视化呈现给观众。

在许多实际场景中，Excel 与 PowerPoint 的结合是必不可少的：邮件合并、填充数据表、为每条数据记录生成一张幻灯片（批量幻灯片生成）、创建培训材料以及将多个 Excel 报表整合到一个演示文稿中，等等。

直到目前，使用 Aspose.Slides API 实现这些功能仍需依赖诸如 Aspose.Cells 等第三方解决方案。虽然这些工具功能强大，但对于仅需要基本数据集成功能的用户来说，它们可能过于复杂且成本高昂。

## **工作原理**

为了让 Excel 数据的使用更加简便和流畅，Aspose.Slides 引入了用于读取 Excel 工作簿并将内容导入演示文稿的新类。该功能为希望在演示工作流中将 Excel 作为数据源的 API 用户打开了强大的新可能性。

该新功能旨在用于通用数据访问，并未集成到演示文稿对象模型（DOM）中。这意味着 *它不允许编辑或保存 Excel 文件* —— 其唯一目的在于打开工作簿并遍历其内容以获取单元格数据。

该功能的核心是全新的 [ExcelDataWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.excel/exceldataworkbook/) 类。此类允许您从本地文件或流加载 Excel 工作簿。加载后，它提供了多个 [GetCell](https://reference.aspose.com/slides/zh/net/aspose.slides.excel/exceldataworkbook/getcell/) 方法的重载，您可以使用这些方法按照位置（例如行列索引或命名范围）检索特定单元格。

每次调用 [GetCell](https://reference.aspose.com/slides/zh/net/aspose.slides.excel/exceldataworkbook/getcell/) 都会返回一个 [ExcelDataCell](https://reference.aspose.com/slides/zh/net/aspose.slides.excel/exceldatacell/) 类的实例。该对象代表 Excel 工作簿中的单个单元格，并以简洁直观的方式提供对其值的访问。

#### **导入 Excel 图表**

扩展功能的下一步是使用 [ExcelWorkbookImporter](https://reference.aspose.com/slides/zh/net/aspose.slides.import/excelworkbookimporter/) 类。该实用类提供了将 Excel 工作簿内容导入演示文稿的功能。它包含多个 [AddChartFromWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) 方法的重载，帮助您从指定的 Excel 工作簿中获取选定的图表，并在指定坐标处将其添加到给定形状集合的末尾。

#### **导入 Excel 表格**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/zh/net/aspose.slides.import/excelworkbookimporter/) 类同样包含多个 [AddTableFromWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) 方法的重载。这些方法允许您从指定的工作表中导入特定的单元格范围，并在指定坐标处将其作为表格添加到给定形状集合的末尾。

简而言之，这是一套轻量且直观的 Excel 数据读取 API——正是许多开发人员在不需要完整电子表格处理库的情况下所需要的。

## **让我们编码**

### **邮件合并场景示例**

在下面的示例中，我们将通过基于存储在 Excel 工作簿中的数据生成多个演示文稿，实现一个简单的邮件合并场景。

要开始，我们需要两件事：
1. 包含数据的 Excel 工作簿

![Excel 数据示例](example1_image0.png)

2. PowerPoint 演示文稿模板

![PowerPoint 模板示例](example1_image1.png)

```csharp
// 加载包含员工数据的 Excel 工作簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 加载演示文稿模板。
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// 遍历 Excel 行（排除第 0 行的标题）。
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // 为每条员工记录创建一个新的演示文稿。
    using Presentation employeePresentation = new Presentation();

    // 删除默认的空白幻灯片。
    employeePresentation.Slides.RemoveAt(0);

    // 将模板幻灯片克隆到新演示文稿中。
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // 从目标形状获取段落（假设使用形状索引 1）。
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // 使用 Excel 数据替换占位符。
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // 将个性化的演示文稿保存为单独的文件。
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![结果](example1_image2.png)

### **Excel 表格示例**

在第二个示例中，我们仅仅复制 Excel 表格中的数据，并以更具视觉吸引力的格式显示在 PowerPoint 幻灯片上。

在本示例中，我们复用了第一个示例中的同一 Excel 工作簿，该工作簿包含一个简单的员工表。

```csharp
// 加载包含员工数据的 Excel 工作簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 创建一个新的 PowerPoint 演示文稿。
using Presentation presentation = new Presentation();

// 在第一张幻灯片上添加表格形状。
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// 使用 Excel 工作簿中的数据填充 PowerPoint 表格。
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// 将生成的演示文稿保存到文件。
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![结果](example2_image0.png)

### **导入 Excel 图表示例**

在本示例中，我们从前述示例使用的 Excel 工作簿的第一个工作表中导入图表。该图表将在生成的演示文稿中链接到外部工作簿。

首先，我们基于员工表在 Excel 工作簿中添加一个饼图。

![Excel 图表示例](example3_image0.png)

```csharp
// 创建一个新的 PowerPoint 演示文稿。
using Presentation presentation = new Presentation();

// 获取第一张幻灯片的形状集合。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// 从工作簿的第一张工作表中导入名为 "Chart 1" 的图表并将其添加到形状集合中。
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// 将生成的演示文稿保存到文件。
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![结果](example3_image1.png)

### **导入所有 Excel 图表示例**

假设您有一个充满图表的 Excel 工作簿，需要将所有图表导入到演示文稿中。每个图表都应放置在新幻灯片上。

下面的代码遍历源 Excel 文件中的所有工作表，从每个工作表中提取图表，并使用空白幻灯片布局将每个图表添加到单独的幻灯片中。在生成的演示文稿中，仅嵌入图表数据，而不是整个工作簿。

```csharp
// 加载包含员工数据的 Excel 工作簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 创建一个新的 PowerPoint 演示文稿。
using Presentation presentation = new Presentation();

// 检索空白幻灯片布局。
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// 获取 Excel 工作簿中所有工作表的名称。
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // 检索将图表索引映射到工作表中图表名称的字典。
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // 使用空白布局添加新幻灯片。
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // 将指定的图表从 Excel 工作簿导入到幻灯片的形状集合中。
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// 将生成的演示文稿保存到文件。
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **导入 Excel 表格示例**

在本示例中，我们直接将来自 Excel 工作表的格式化表格导入到 PowerPoint 演示文稿中。

源 Excel 工作表包含一个带有员工数据的格式化表格：

![Excel 表格示例](example4_image0.png)

```csharp
// 创建一个新的 PowerPoint 演示文稿。
using Presentation presentation = new Presentation();

// 获取第一张幻灯片的形状集合。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// 从工作簿的第一张工作表导入表格并将其添加到形状集合中。
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// 将生成的演示文稿保存到文件。
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![结果](example4_image1.png)


## **总结**

此机制直接在 Aspose.Slides 中提供，将 Excel 数据和演示文稿的操作结合于一处。它使您能够创建包含可视化图表和以 Excel 表格形式呈现的数据的幻灯片——无需任何额外库或复杂的集成。