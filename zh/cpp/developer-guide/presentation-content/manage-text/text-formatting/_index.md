---
title: 在 C++ 中格式化 PowerPoint 文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/cpp/text-formatting/
keywords:
- 突出显示文本
- 正则表达式
- 对齐段落
- 文本样式
- 文本背景
- 文本透明度
- 字符间距
- 字体属性
- 字体系列
- 文本旋转
- 旋转角度
- 文本框
- 行间距
- 自动适应属性
- 文本框锚点
- 文本制表
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中格式化和设置文本样式。自定义字体、颜色、对齐方式等。"
---

## **突出显示文本**
已在 ITextFrame 和 TextFrame 类中添加了新的 HighlightText 方法。该方法允许使用文本示例，以背景颜色突出显示文本部分，类似于 PowerPoint 2019 中的“文本突出显示颜色”工具。

下面的代码片段演示了如何使用此功能：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 
Aspose 提供了一个简单的免费在线 PowerPoint 编辑服务[free online PowerPoint editing service](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **使用正则表达式突出显示文本**
已在 ITextFrame 和 TextFrame 类中添加了新的 HighlightRegex 方法。该方法允许使用正则表达式，以背景颜色突出显示文本部分，类似于 PowerPoint 2019 中的“文本突出显示颜色”工具。

下面的代码片段演示了如何使用此功能：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **设置文本背景颜色**

Aspose.Slides 允许您为文本的背景指定首选颜色。

下面的 C++ 代码展示了如何为整段文本设置背景颜色：
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));
    auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    for (auto&& portion : portions)
    {
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Blue());
    }
    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


下面的 C++ 代码展示了如何仅为文本的一部分设置背景颜色：
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));

	auto predicate = [](System::SharedPtr<IPortion> portion) -> bool {
        return portion->get_Text().Contains(u"Red");
	};

	auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    System::SharedPtr<IPortion> redPortion;
	for (auto&& portion : portions)
        if (predicate(portion))
            redPortion = portion;

    redPortion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Red());

    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


## **对齐文本段落**
文本格式是创建任何文档或演示文稿时的关键要素。我们知道 Aspose.Slides for C++ 支持向幻灯片添加文本，但在本主题中，我们将了解如何控制幻灯片中文本段落的对齐方式。请按照以下步骤使用 Aspose.Slides for C++ 对齐文本段落：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 访问幻灯片中的占位符形状，并将其强制转换为 AutoShape。
4. 从 AutoShape 暴露的 TextFrame 中获取需要对齐的 Paragraph。
5. 对 Paragraph 进行对齐。段落可以对齐到右、左、居中或两端对齐。
6. 将修改后的演示文稿写入 PPTX 文件。

下面给出上述步骤的实现示例：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **设置文本透明度**
本文演示如何使用 Aspose.Slides 为任意文本形状设置透明度属性。要为文本设置透明度，请按以下步骤操作：

1. 创建一个 Presentation 类的实例。
2. 获取幻灯片的引用。
3. 设置阴影颜色。
4. 将演示文稿写入 PPTX 文件。

下面给出上述步骤的实现示例：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **设置字符间距**
Aspose.Slides 允许您设置文本框中字母之间的间距。通过调整字符间距，您可以改变一行或一段文本的视觉密度。

下面的 C++ 代码展示了如何为一行文本扩大间距并为另一行文本压缩间距：
```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // 展开
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // 压缩

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```


## **管理文本字体属性**
演示文稿通常包含文本和图像。文本可以以多种方式进行格式化，以突出特定章节和单词，或符合企业样式。文本格式化帮助用户改变演示内容的外观和感觉。本文展示如何使用 Aspose.Slides for C++ 配置幻灯片中文本段落的字体属性。使用 Aspose.Slides for C++ 管理段落字体属性的步骤：

1. 创建 `Presentation` 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问幻灯片中的占位符形状，并将其强制转换为 AutoShape。
1. 从 AutoShape 暴露的 TextFrame 中获取 Paragraph。
1. 对段落进行两端对齐。
1. 访问 Paragraph 的文本 Portion。
1. 使用 FontData 定义字体，并相应地为 Portion 设置 Font。
   1. 将字体设为粗体。
   1. 将字体设为斜体。
1. 使用 Portion 对象暴露的 FillFormat 设置字体颜色。
1. 将修改后的演示文稿写入 PPTX 文件。

下面给出上述步骤的实现示例。该示例对未做任何装饰的演示文稿的其中一张幻灯片的字体进行格式化。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **管理文本的字体系列**
段落中的 Portion 用于保存具有相同格式的文本。本文展示如何使用 Aspose.Slides for C++ 创建包含文本的文本框，并为其定义特定的字体以及字体系列的各种属性。创建文本框并设置其中文本的字体属性的步骤：

1. 创建 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加类型为 Rectangle 的 AutoShape。
4. 移除与 AutoShape 关联的填充样式。
5. 访问 AutoShape 的 TextFrame。
6. 向 TextFrame 添加一些文本。
7. 访问与 TextFrame 关联的 Portion 对象。
8. 为 Portion 定义使用的字体。
9. 使用 Portion 对象暴露的相关属性设置粗体、斜体、下划线、颜色和高度等其他字体属性。
10. 将修改后的演示文稿写入 PPTX 文件。

下面给出上述步骤的实现示例。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **设置文本的字体大小**
Aspose.Slides 允许您为段落中已有的文本以及以后可能添加的文本选择首选的字体大小。

下面的 C++ 代码展示了如何为段落中的文本设置字体大小：
```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// 获取第一个形状，例如。
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // 获取第一段落，例如。
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // 将段落中所有文本部分的默认字体大小设置为 20 磅。
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // 将段落中当前文本部分的字体大小设置为 20 磅。
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **设置文本旋转**
Aspose.Slides for C++ 允许开发者旋转文本。文本可以设置为 Horizontal、Vertical、Vertical270、WordArtVertical、EastAsianVertical、MongolianVertical 或 WordArtVerticalRightToLeft。要旋转任意 TextFrame 中的文本，请按以下步骤操作：

1. 创建 `Presentation` 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意 Shape。
4. 访问该 Shape 的 TextFrame。
5. 旋转文本。
6. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **幻灯片中的 Tab 与 Effective Tab**
- EffectiveTabs.ExplicitTabCount（在本例中为 2）属性等于 Tabs.Count。
- EffectiveTabs 集合包含所有 Tab（来自 Tabs 集合以及默认 Tab）。
- EffectiveTabs.DefaultTabSize（294）属性显示默认 Tab 之间的距离（本例中为第 3 与第 4 个 Tab）。
- EffectiveTabs.GetTabByIndex(index) 当 index = 0 时返回第一个显式 Tab（Position = 731），index = 1 时返回第二个 Tab（Position = 1241）。如果尝试使用 index = 2，则返回第一个默认 Tab（Position = 1470），依此类推。
- EffectiveTabs.GetTabAfterPosition(pos) 用于获取文本后面的下一个制表位。例如，有文本 “Helloworld!”。要渲染该文本，需要知道从哪里开始绘制 “world!”。首先计算 “Hello” 的像素长度，然后将该值传入 GetTabAfterPosition，即可得到绘制 “world!” 的下一个制表位。

## **段落的行间距**
Aspose.Slides 在 `ParagraphFormat` 下提供了 `SpaceAfter`、`SpaceBefore` 和 `SpaceWithin` 属性，帮助您管理段落的行间距。三者的使用方式如下：

* 若要以百分比指定段落的行间距，请使用正值。
* 若要以磅值指定段落的行间距，请使用负值。

例如，设置 `SpaceBefore` 为 -16 即可为段落应用 16pt 的行间距。

指定特定段落行间距的步骤：

1. 加载包含带文本 AutoShape 的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 访问 TextFrame。
4. 访问 Paragraph。
5. 设置 Paragraph 的属性。
6. 保存演示文稿。

下面的 C++ 代码展示了如何为段落指定行间距：
```cpp
// 文档目录的路径。
System::String dataDir = GetDataPath();

// 创建 Presentation 类的实例
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// 通过索引获取幻灯片的引用
auto sld = presentation->get_Slides()->idx_get(0);

// 访问 TextFrame
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// 访问段落
auto para = tf1->get_Paragraphs()->idx_get(0);

// 设置段落的属性
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// 保存演示文稿
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **设置 TextFrame 的 AutofitType 属性**
本节将探讨 TextFrame 的不同格式属性。本文介绍如何设置 TextFrame 的 AutofitType 属性、文本锚点以及在演示文稿中旋转文本。Aspose.Slides for C++ 允许开发者为任意 TextFrame 设置 AutofitType 属性。AutofitType 可以设为 Normal 或 Shape。设为 Normal 时，形状保持不变，文本会自行调整；设为 Shape 时，形状会根据所需容纳的文本进行调整。设置 TextFrame 的 AutofitType 属性的步骤如下：

1. 创建 Presentation 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意 Shape。
4. 访问该 Shape 的 TextFrame。
5. 设置 TextFrame 的 AutofitType。
6. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **设置 TextFrame 的锚点**
Aspose.Slides for C++ 允许开发者设置任意 TextFrame 的锚点。TextAnchorType 指定文本在形状中的放置位置，可设为 Top、Center、Bottom、Justified 或 Distributed。设置 TextFrame 锚点的步骤如下：

1. 创建 `Presentation` 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意 Shape。
4. 访问该 Shape 的 TextFrame。
5. 设置 TextAnchorType。
6. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **为 TextFrame 设置自定义旋转角度**
Aspose.Slides for C++ 现已支持为 TextFrame 设置自定义旋转角度。在本节中，我们将通过示例演示如何在 Aspose.Slides 中设置 RotationAngle 属性。RotationAngle 已添加到 IChartTextBlockFormat 和 ITextFrameFormat 接口，允许为 TextFrame 设置自定义旋转角度。设置 RotationAngle 属性的步骤如下：

1. 创建 Presentation 类的实例。
2. 在幻灯片上添加图表。
3. 设置 RotationAngle 属性。
4. 将演示文稿写入 PPTX 文件。

下面的示例展示了如何设置 RotationAngle 属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **设置校对语言**
Aspose.Slides 提供了由 [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) 类公开的 [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) 属性，以便为 PowerPoint 文档设置校对语言。校对语言用于检查 PowerPoint 中的拼写和语法。

下面的 C++ 代码展示了如何为 PowerPoint 设置校对语言：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **设置默认语言**
下面的 C++ 代码展示了如何为整个 PowerPoint 演示文稿设置默认语言：
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// 添加一个带文本的矩形形状
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// 检查第一段落的首个 Portion 语言
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **设置默认文本样式**
如果您需要一次性为演示文稿中的所有文本元素应用相同的默认文本格式，可使用 [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) 接口的 `get_DefaultTextStyle` 方法并设置首选的格式。下面的代码示例展示了如何为新演示文稿中所有幻灯片的文本设置默认粗体字体（14 pt）。
```c++
auto presentation = MakeObject<Presentation>();

// 获取顶级段落格式。
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **提取带有全大写效果的文本**
在 PowerPoint 中，应用 **All Caps** 字体效果后，即使原始文本为小写，也会在幻灯片上显示为大写。当使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。处理方法是检查 [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/)——如果其值为 `All`，则将返回的字符串转换为大写，以使输出与幻灯片上看到的内容一致。

假设我们在 sample2.pptx 的第一张幻灯片上有如下文本框。

![The All Caps effect](all_caps_effect.png)

下面的代码示例展示了如何提取带有 **All Caps** 效果的文本：
```cpp
auto presentation = MakeObject<Presentation>(u"sample2.pptx");
auto autoShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```


输出：
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **常见问题**

**如何修改幻灯片中表格的文本？**

要修改幻灯片中表格的文本，需要使用 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象。您可以遍历表格中的所有单元格，通过访问每个单元格的文本框和段落格式属性来更改其文本。

**如何为 PowerPoint 幻灯片中的文本应用渐变色？**

要为文本应用渐变色，请使用 [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) 中的 `get_FillFormat` 方法。将填充格式设为 `Gradient`，并定义渐变的起始颜色和结束颜色，以及方向、透明度等其他属性，以在文本上创建渐变效果。