---
title: "在 Python 中自动化 PowerPoint 生成：轻松创建动态演示文稿"
linktitle: 自动化 PowerPoint 生成
type: docs
weight: 20
url: /zh/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- 云平台
- 云集成
- 自动化 PowerPoint 生成
- 以编程方式生成演示文稿
- PowerPoint 自动化
- 动态幻灯片创建
- 自动化业务报告
- PPT 自动化
- Python 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 自动化 PowerPoint 生成：在云应用中创建包含图表、表格和项目符号的业务演示文稿。"
---
## **介绍**

手动创建演示文稿在内容频繁变化时会变得重复。每周报告、培训材料和客户演示通常共享相同的结构，但每次交付都需要新的数据。

Aspose.Slides for Python via Java 允许您从 Python 应用程序生成这些演示文稿。您可以将幻灯片创建集成到 Web 门户、计划任务和云工作程序中，使用来自数据库、API 或上传文件的数据。

## **Python 中 PowerPoint 自动化的常见用例**

- **业务报告和仪表板:** 将销售数字和绩效指标转换为图表和表格。
- **个性化销售演示:** 在保持一致设计的同时，用客户特定数据填充幻灯片。
- **教育内容:** 从结构化材料组装课程、测验和课程摘要。
- **数据和 AI 驱动的洞察:** 使用分析或语言处理服务的结果作为演示内容。
- **基于媒体的幻灯片:** 将上传的图像或截图与说明文字相结合。
- **文档工作流:** 将其他工具提取的内容映射到演示布局中。
- **开发者工具:** 从项目数据生成发布摘要、技术概览或演示。

## **先决条件**

请遵循[Installation](/slides/zh/python-java/installation/)设置 Python、Java、JPype 和 Aspose.Slides。对于云部署，还请查看[Slides on Cloud Platforms](/slides/zh/python-java/slides-on-cloud-platforms/)。

示例使用固定的业务数据，这样无需数据库或外部服务即可运行。将这些值替换为您应用程序中的数据，以便在报告工作流中集成。

{{% alert color="info" title="Note" %}}
您可以在没有许可证的情况下尝试示例，但评估输出会包含水印，并受评估限制。有关详细信息和临时许可证信息，请参阅[Evaluate Aspose.Slides](/slides/zh/python-java/evaluate-aspose-slides/)。
{{% /alert %}}

## **构建演示文稿**

下面的完整脚本创建一个包含四张幻灯片的演示文稿。每一步都使用同一个演示文稿，最后一步将其保存为 `presentation.pptx`。

### **创建标题幻灯片**

在新的[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)中使用默认幻灯片并应用标题布局。用报告标题和受众填充其标题和副标题占位符。

![标题幻灯片](slide_0.png)

### **添加带柱形图的幻灯片**

添加一个空白幻灯片，并使用[ShapeCollection.addChart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addChart)创建图表。使用五个地区和一个销售系列填充其嵌入的工作簿。该数值在 PowerPoint 中仍可编辑。

![带图表的幻灯片](slide_1.png)

### **添加带表格的幻灯片**

使用[ShapeCollection.addTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addTable)创建表格，并用指标名称和值填充两列。示例通过 JPype 传递显式的 Java double 数组以设置列宽和行高。

![带表格的幻灯片](slide_2.png)

### **添加带项目符号的摘要幻灯片**

创建文本形状，为每个操作项添加一个[Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/)。对每个段落应用符号项目符号和黑色文本，并移除形状的填充和轮廓。

![带摘要的幻灯片](slide_3.png)

### **保存演示文稿**

使用[Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save)写入 PowerPoint 文件。通过在 `finally` 块中调用[Presentation.dispose](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#dispose)释放演示文稿。

### **完整 Python 示例**

将此脚本保存在可写目录中，并使用上述配置的 Python 环境运行。它仅在必要时启动 JVM，并保持其可用直至进程退出。有关笔记本和服务使用，请参阅[JVM lifecycle guidance](/slides/zh/python-java/limitations-and-api-differences/#import-the-library)。

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # 创建标题幻灯片。
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # 添加图表幻灯片。
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # 添加表格幻灯片。
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # 添加摘要幻灯片。
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

这些插图显示了 Java 示例中对应的幻灯片。外观可能因已安装的字体和评估模式而有所不同。

## **在云应用中使用示例**

在构建演示文稿之前获取报告数据，然后将其传递给图表、表格和文本生成步骤。为每个作业使用单独的输出路径。保存后，您的应用程序可以将文件上传到对象存储或作为下载返回。

在同一工作进程中跨作业保持 JVM 运行，并在作业完成后释放每个演示文稿。将报告设计所需的字体与部署一起打包，以减少不同环境之间的差异。

## **结论**

此示例使用 Python 生成完整的业务演示文稿，包含可编辑的图表、表格和文本。将示例数据替换为应用程序数据后，同样的方法可用于周期性报告、客户演示和教育材料。

## **常见问题**

**脚本是否需要 Microsoft PowerPoint 或 Excel？**

不需要。Aspose.Slides 在没有任何应用程序的情况下创建幻灯片和图表的嵌入工作簿。

**表格示例为什么使用 Java 数组？**

底层方法接受 Java double 数组。显式数组能够明确通过 JPype 传递的数值类型。

**我可以将同一演示文稿另存为 PDF 或 ODP 吗？**

可以。在释放之前，使用相应的[SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/)值将其保存为其他输出文件名。请参阅[Supported File Formats](/slides/zh/python-java/supported-file-formats/)了解特定格式的功能。

**我可以使用品牌模板吗？**

可以。加载您的模板而不是创建空白演示文稿，然后将布局和占位符选择适配到该模板。示例假设使用新默认演示文稿的布局和占位符顺序。