---
title: "在 C++ 中自动化 PowerPoint 生成：轻松创建动态演示文稿"
linktitle: 自动化 PowerPoint 生成
type: docs
weight: 20
url: /zh/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- 云平台
- 自动化 PowerPoint 生成
- 编程生成演示文稿
- PowerPoint 自动化
- 动态幻灯片创建
- 自动化业务报告
- PPT 自动化
- C++ 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在云平台上自动化幻灯片创建——快速可靠地生成、编辑和转换 PowerPoint 与 OpenDocument 文件。"
---

## **简介**

手动创建 PowerPoint 演示文稿可能既耗时又重复——尤其是内容基于经常变化的动态数据时。无论是生成每周业务报告、整理教学材料，还是制作客户可直接使用的销售演示稿，自动化都能节省无数小时并确保团队之间的一致性。

对于 C++ 开发者来说，自动化创建 PowerPoint 演示文稿开辟了强大的可能性。您可以将幻灯片生成集成到 Web 门户、桌面工具、后端服务或云平台中，实现数据的动态转换，按需生成专业且符合品牌形象的演示文稿。

在本文中，我们将探讨 C++ 应用（包括在云平台上的部署）中自动化 PowerPoint 生成的常见使用场景，以及它为何正在成为现代解决方案的关键特性。从实时业务数据的抽取到将文本或图像转换为幻灯片，目标是将原始内容转化为结构化、可视化的格式，让受众能够瞬间理解。

## **C++ 中 PowerPoint 自动化的常见使用场景**

在需要动态组装、个性化或频繁更新演示内容的情境下，PowerPoint 自动化尤为有用。最常见的真实场景包括：

- **业务报告与仪表盘**  
  通过从数据库或 API 获取实时数据，生成销售摘要、关键绩效指标或财务绩效报告。

- **个性化的销售与营销演示稿**  
  使用 CRM 或表单数据自动创建客户专属的推介稿，确保快速交付和品牌统一。

- **教育内容**  
  将学习材料、测验或课程摘要转换为结构化的幻灯片，供在线学习平台使用。

- **数据与 AI 驱动的洞察**  
  利用自然语言处理或分析引擎将原始数据或长文本转化为简要的演示文稿。

- **媒体类幻灯片**  
  从上传的图片、标注截图或视频关键帧中组装演示文稿，并附上说明文字。

- **文档转换**  
  自动将 Word 文档、PDF 或表单输入转换为可视化演示稿，几乎不需手动干预。

- **开发者和技术工具**  
  直接从代码或 markdown 内容生成技术演示、文档概览或变更日志的幻灯片格式。

通过自动化这些工作流，组织可以规模化内容创作，保持一致性，并将时间释放给更具策略性的工作。

## **动手编码**

本文示例选用了 **[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/)** 来演示 PowerPoint 自动化，因为它功能全面且在以编程方式处理演示文稿时使用便捷。

与需要直接操作 Open XML 结构的底层库不同（往往导致代码冗长且难以阅读），Aspose.Slides 提供了更高层次的 API。它抽象掉了复杂性，使开发者可以专注于演示逻辑——如布局、格式化和数据绑定——而无需深入了解 PowerPoint 文件格式的细节。

虽然 Aspose.Slides 是商业库，但它提供了一个 **[免费试用](https://releases.aspose.com/slides/cpp/)** 版本，完全能够运行本文提供的示例。对于演示概念、测试功能或构建本文所示的概念验证来说，试用版已足够。这使得在无需提前购买许可证的情况下，能够方便地尝试自动化 PowerPoint 生成。

下面我们将通过实际案例，使用真实内容构建一个示例演示文稿。

### **创建标题幻灯片**

首先创建一个新演示文稿，并添加一个包含主标题和副标题的标题幻灯片。
```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```


![标题幻灯片](slide_0.png)

### **添加包含柱状图的幻灯片**

接下来，我们创建一张展示区域销售业绩的柱状图幻灯片。
```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```


![包含柱状图的幻灯片](slide_1.png)

### **添加包含表格的幻灯片**

现在添加一张以表格形式呈现关键绩效指标的幻灯片。
```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```


![包含表格的幻灯片](slide_2.png)

### **添加包含项目符号的摘要幻灯片**

最后，我们使用简洁的项目符号列表加入摘要和行动计划。
```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```

```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```


![包含文本的幻灯片](slide_3.png)

### **保存演示文稿**

最终，将演示文稿保存到磁盘：
```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **结论**

在 C++ 应用中实现 PowerPoint 自动化能够显著节省时间并降低手工工作量。通过集成图表、表格和文本等动态内容，开发者可以快速生成一致、专业的演示文稿——这对业务报告、客户会议或教学内容尤为适用。

本文演示了如何从零开始自动创建演示文稿，包括添加标题幻灯片、图表和表格。该方法可广泛应用于各种需要自动化、数据驱动的演示场景。

借助合适的工具，C++ 开发者能够高效实现 PowerPoint 自动化，提升生产力并确保演示文稿的一致性。