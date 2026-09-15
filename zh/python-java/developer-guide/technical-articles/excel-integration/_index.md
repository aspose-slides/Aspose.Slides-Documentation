---
title: 将 Excel 数据集成到 PowerPoint 演示文稿中
linktitle: Excel 集成
type: docs
weight: 330
url: /zh/python-java/excel-integration/
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
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中使用 ExcelDataWorkbook API 从 Excel 工作簿读取数据。加载工作表和单元格并使用其值生成数据驱动的 PowerPoint 演示文稿。"
---
## **介绍**

PowerPoint 演示文稿是一种展示和传达信息的强大方式。它们通常与 Excel 工作簿一起使用，其中 Excel 作为结构化数据的极佳来源，而 PowerPoint 则擅长为观众可视化这些数据。

在许多实际场景中，Excel 与 PowerPoint 的组合是必不可少的：邮件合并、填充数据表、为每条数据记录生成一张幻灯片（批量幻灯片生成）、创建培训材料以及将多个 Excel 报告合并为单个演示文稿，等等。

直到目前，使用 Aspose.Slides API 实现这些功能需要依赖像 Aspose.Cells 这样的第三方解决方案。虽然这些工具功能强大，但对于只需要基本数据集成功能的用户来说，它们可能过于复杂且成本高昂。

## **工作原理**

为了让 Excel 数据的使用更加简便流畅，Aspose.Slides 引入了用于从 Excel 工作簿读取数据并将内容导入演示文稿的新类。该功能为希望在演示工作流中将 Excel 作为数据源的 API 用户开辟了强大的新可能性。

新功能旨在提供通用的数据访问，并未集成到演示文稿对象模型 (DOM) 中。这意味着 *它不允许编辑或保存 Excel 文件* —— 它唯一的目的只是打开工作簿并在其内容中导航以检索单元格数据。

该功能的核心是全新的 [ExcelDataWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/exceldataworkbook/) 类。该类允许您从本地文件或流加载 Excel 工作簿。加载后，它提供了多个 [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/exceldataworkbook/#getCell) 方法的重载，您可以使用这些方法按位置（例如行列索引或命名范围）检索特定单元格。

对 [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/exceldataworkbook/#getCell) 的每次调用都会返回一个 [ExcelDataCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/exceldatacell/) 对象。该对象代表 Excel 工作簿中的单个单元格，并以简洁直观的方式提供对其值的访问。

#### **导入 Excel 图表**

扩展功能的下一步是 [ExcelWorkbookImporter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/excelworkbookimporter/) 类。该实用类提供了将 Excel 工作簿内容导入演示文稿的功能。它包含多个 [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) 方法的重载，帮助您从指定的 Excel 工作簿中检索所选图表，并在指定坐标处将其添加到给定形状集合的末尾。

#### **导入 Excel 表格**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/excelworkbookimporter/) 类同样包含多个 [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) 方法的重载。这些方法允许您从指定工作表中导入指定的单元格范围，并在指定坐标处将其作为表格添加到给定形状集合的末尾。

简而言之，这是一个轻量且直接的读取 Excel 数据的 API——正是许多开发者在无需完整电子表格处理库的情况下所需的。

## **让我们编写代码**

### **邮件合并场景示例**

在下面的示例中，我们将通过基于存储在 Excel 工作簿中的数据生成多个演示文稿，来实现一个简单的邮件合并场景。

要开始，我们需要两样东西：

1. 一个包含数据的 Excel 工作簿
   ![Excel 数据示例](example1_image0.png)

2. 一个 PowerPoint 演示文稿模板
   ![PowerPoint 模板示例](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# 加载包含员工数据的 Excel 工作簿。
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# 加载演示文稿模板。
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # 循环遍历 Excel 行（排除第 0 行标题）。
    for row_index in range(1, 5):

        # 为每条员工记录创建演示文稿。
        employee_presentation = Presentation()

        try:
            # 删除默认的空白幻灯片。
            employee_presentation.getSlides().removeAt(0)

            # 将模板幻灯片克隆到演示文稿中。
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # 从目标形状获取段落（假设使用形状索引 1）。
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # 用 Excel 数据替换占位符。
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # 将个性化演示文稿保存为单独的文件。
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![结果](example1_image2.png)

### **Excel 表格示例**

在第二个示例中，我们简单地复制 Excel 表格中的数据，并以更具视觉吸引力的格式显示在 PowerPoint 幻灯片上。

在本示例中，我们复用了第一个示例中的同一 Excel 工作簿，其中包含一个简单的员工表格。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# 加载包含员工数据的 Excel 工作簿。
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# 创建 PowerPoint 演示文稿。
presentation = Presentation()

try:
    # 向第一张幻灯片添加表格形状。
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # 使用 Excel 工作簿中的数据填充 PowerPoint 表格。
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # 将生成的演示文稿保存为文件。
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![结果](example2_image0.png)

### **导入 Excel 图表示例**

在本示例中，我们从前面示例中使用的 Excel 工作簿的第一个工作表导入图表。该图表将在生成的演示文稿中链接到外部工作簿。

首先，我们基于员工表格在 Excel 工作簿中添加一个饼图。

![Excel 图表示例](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# 创建 PowerPoint 演示文稿。
presentation = Presentation()
try:
    # 获取第一张幻灯片的形状集合。
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # 从工作簿的第一张工作表导入名为 "Chart 1" 的图表并将其添加到形状集合中。
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # 将生成的演示文稿保存为文件。
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![结果](example3_image1.png)

### **导入所有 Excel 图表示例**

假设您有一个包含大量图表的 Excel 工作簿，需要将它们全部导入到演示文稿中。每个图表都应放置在新幻灯片上。

以下代码遍历源 Excel 文件中的所有工作表，提取每个工作表中的图表，并使用空白幻灯片布局将每个图表添加到单独的幻灯片中。在生成的演示文稿中，仅嵌入图表数据，而不是整个工作簿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# 加载包含员工数据的 Excel 工作簿。
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# 创建 PowerPoint 演示文稿。
presentation = Presentation()
try:
    # 检索空白幻灯片布局。
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # 删除默认幻灯片，以便结果每个图表对应一张幻灯片。
    presentation.getSlides().removeAt(0)

    # 获取 Excel 工作簿中所有工作表的名称。
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # 检索将图表索引映射到图表名称的映射表（针对该工作表）。
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # 使用空白布局添加幻灯片。
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # 将指定的图表从 Excel 工作簿导入到幻灯片的形状集合中。
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # 将生成的演示文稿保存为文件。
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **导入 Excel 表格示例**

在本示例中，我们直接将 Excel 工作表中的格式化表格导入到 PowerPoint 演示文稿中。

源 Excel 工作表包含一个带有员工数据的格式化表格：

![Excel 表格示例](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# 创建 PowerPoint 演示文稿。
presentation = Presentation()
try:
    # 获取第一张幻灯片及其形状集合。
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # 从工作簿的第一张工作表导入表格并将其添加到形状集合中。
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # 将生成的演示文稿保存为文件。
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![结果](example4_image1.png)

## **总结**

此机制直接在 Aspose.Slides 中可用，将 Excel 数据和演示文稿的处理合二为一。它使您能够创建包含可视化图表和以 Excel 表格形式呈现数据的幻灯片——无需任何额外库或复杂集成。