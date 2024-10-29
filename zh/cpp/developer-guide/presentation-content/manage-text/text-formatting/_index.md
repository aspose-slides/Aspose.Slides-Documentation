---
title: 文本格式化
type: docs
weight: 50
url: /zh/cpp/text-formatting/
keywords:
- 高亮文本
- 正则表达式
- 对齐文本段落
- 文本透明度
- 段落字体属性
- 字体家族
- 文本旋转
- 自定义角度旋转
- 文本框
- 行间距
- 自适应属性
- 文本框锚点
- 文本制表
- 默认文本样式
- C++
- Aspose.Slides for .C++
description: "在 C++ 中管理和操作文本及文本框属性"
---

## **高亮文本**
新添加了 HighlightText 方法到 ITextFrame 和 TextFrame 类。它允许使用文本样本高亮文本部分的背景颜色，类似于 PowerPoint 2019 中的文本高亮工具。

下面的代码片段展示了如何使用此功能：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose 提供一个简单的 [免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **使用正则表达式高亮文本**
新添加了 HighlightRegex 方法到 ITextFrame 和 TextFrame 类。它允许使用正则表达式以背景颜色高亮文本部分，类似于 PowerPoint 2019 中的文本高亮工具。

下面的代码片段展示了如何使用此功能：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **设置文本背景颜色**

Aspose.Slides 允许您为文本的背景指定首选颜色。

下面的 C++ 代码展示了如何为整个文本设置背景颜色：

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"黑色");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" 红色 ");

    auto portion3 = System::MakeObject<Portion>(u"黑色");
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

下面的 C++ 代码展示了如何只为文本的部分设置背景颜色：

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"黑色");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" 红色 ");

    auto portion3 = System::MakeObject<Portion>(u"黑色");
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
        return portion->get_Text().Contains(u"红色");
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
文本格式化是创建任何文档或演示文稿的关键元素之一。我们知道 Aspose.Slides for C++ 支持向幻灯片添加文本，但在本主题中，我们将看到如何控制幻灯片中文本段落的对齐。请按照以下步骤使用 Aspose.Slides for C++ 对齐文本段落：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 访问幻灯片中的占位符形状，并将其类型转换为 AutoShape。
4. 从 AutoShape 公开的 TextFrame 中获取需要对齐的段落。
5. 对齐段落。段落可以对齐为右、左、居中和两端对齐。
6. 将修改后的演示文稿写为 PPTX 文件。

上述步骤的实现如下所示。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **设置文本透明度**
本文展示如何使用 Aspose.Slides 为任何文本形状设置透明度属性。在为文本设置透明度时，请遵循以下步骤：

1. 创建一个 Presentation 类的实例。
2. 获取幻灯片的引用。
3. 设置阴影颜色。
4. 将演示文稿写为 PPTX 文件。

上述步骤的实现如下所示。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **设置文本字符间距**

Aspose.Slides 允许您设置文本框中字母之间的间距。这样一来，您就可以通过扩展或压缩字符间距来调整文本行或块的视觉密度。

下面的 C++ 代码展示了如何扩展一行文本的间距并压缩另一行文本的间距：

```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // 扩展
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // 收缩

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **管理段落的字体属性**

演示文稿通常包含文本和图像。文本可以以多种方式格式化，要么是突出特定部分和单词，要么是遵循企业样式。文本格式化帮助用户改变演示内容的外观和感觉。本文展示如何使用 Aspose.Slides for C++ 来配置幻灯片中文本段落的字体属性。使用 Aspose.Slides for C++ 管理段落的字体属性：

1. 创建一个 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。
3. 访问幻灯片中的占位符形状并将其类型转换为 AutoShape。
4. 从 AutoShape 公开的 TextFrame 中获取段落。
5. 使段落两端对齐。
5. 访问段落的文本部分。
6. 使用 FontData 定义字体，并相应地设置文本部分的字体。
   1. 设置字体为粗体。
   2. 设置字体为斜体。
7. 使用部分对象公开的 FillFormat 设置字体颜色。
8. 将修改后的演示文稿写为 PPTX 文件。

上述步骤的实现如下所示。它将一个没有装饰的演示文稿格式化为其中一个幻灯片上的字体。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}


## **管理文本的字体家族**
部分用于在段落中容纳具有相似格式样式的文本。本文展示如何使用 Aspose.Slides for C++ 创建一个文本框并定义特定字体以及字体家族类别的各种其他属性。要创建文本框并设置其中文本的字体属性：

1. 创建一个 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个矩形类型的 AutoShape。
4. 删除与 AutoShape 相关联的填充样式。
5. 访问 AutoShape 的 TextFrame。
6. 向 TextFrame 添加一些文本。
7. 访问与 TextFrame 关联的 Portion 对象。
8. 定义要用于该 Portion 的字体。
9. 使用 Portion 对象公开的相关属性设置其他字体属性，如粗体、斜体、下划线、颜色和高度。
10. 将修改后的演示文稿写为 PPTX 文件。

上述步骤的实现如下所示。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **设置文本的字体大小**

Aspose.Slides 允许您为段落中现有文本和以后可能添加到段落的其他文本选择首选的字体大小。

下面的 C++ 代码展示了如何设置段落中包含的文本的字体大小：

```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// 获取第一个形状，例如。
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // 获取第一个段落，例如。
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // 将段落中所有文本部分的默认字体大小设置为 20 pt。
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // 将段落中当前文本部分的字体大小设置为 20 pt。
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **设置文本旋转**

Aspose.Slides for C++ 允许开发人员旋转文本。文本可以设置为水平、垂直、垂直270、WordArt垂直、东亚垂直、蒙古垂直或 WordArt 右至左垂直。要旋转任何 TextFrame 的文本，请遵循以下步骤：

1. 创建一个 `Presentation` 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 TextFrame。
5. 旋转文本。
6. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}


## **演示文稿中的制表符和有效制表符**
- EffectiveTabs.ExplicitTabCount（在我们这里是 2）属性等于 Tabs.Count。
- EffectiveTabs 集合包括所有制表符（来自 Tabs 集合和默认制表符）
- EffectiveTabs.ExplicitTabCount（在我们这里是 2）属性等于 Tabs.Count。
- EffectiveTabs.DefaultTabSize（294）属性显示默认制表符之间的距离（在我们这个例子中为 3 和 4）。
- EffectiveTabs.GetTabByIndex(index) 的 index = 0 将返回第一个显式制表符（位置 = 731），index = 1 - 第二个制表符（位置 = 1241）。如果您尝试以 index = 2 获取下一个制表符，它将返回第一个默认制表符（位置 = 1470）等等。
- EffectiveTabs.GetTabAfterPosition(pos) 用于获取某些文本之后的下一个制表符。例如，您有文本： "Helloworld!"。要呈现这样的文本，您应该知道从哪里开始绘制 "world!"。首先，您需要计算 "Hello" 的长度（以像素为单位），并用该值调用 GetTabAfterPosition。您将获得绘制 "world!" 的下一个制表符位置。

## **段落的行间距**

Aspose.Slides 提供 `ParagraphFormat` 下的属性——`SpaceAfter`、`SpaceBefore` 和 `SpaceWithin`——以便您管理段落的行间距。这三个属性的用法如下：

* 要以百分比指定段落的行间距，请使用正值。
* 要以点指定段落的行间距，请使用负值。

例如，您可以通过将 `SpaceBefore` 属性设置为 -16 来为段落应用 16pt 的行间距。

以下是指定特定段落行间距的方法：

1. 加载包含带有文本的 AutoShape 的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 访问 TextFrame。
4. 访问段落。
5. 设置段落属性。
6. 保存演示文稿。

下面的 C++ 代码展示了如何为段落指定行间距：

``` cpp
// 文档目录的路径。
System::String dataDir = GetDataPath();

// 创建一个 Presentation 类的实例
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


## **设置文本框的 AutofitType 属性**
在本主题中，我们将探索文本框的不同格式属性。本文涵盖如何设置文本框的 AutofitType 属性、文本的锚点以及在演示文稿中旋转文本。Aspose.Slides for C++ 允许开发人员设置任何文本框的 AutofitType 属性。AutofitType 可以设置为 Normal 或 Shape。如果设置为 Normal，则形状将保持不变，而文本将会调整，使形状本身不会发生变化；如果将 AutofitType 设置为形状，则形状将被修改，使得只包含所需文本。要设置文本框的 AutofitType 属性，请遵循以下步骤：

1. 创建一个 Presentation 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 TextFrame。
5. 设置 TextFrame 的 AutofitType。
6. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}


## **设置 TextFrame 的锚点**
Aspose.Slides for C++ 允许开发人员设置任何 TextFrame 的锚点。TextAnchorType 指定文本在形状中放置的位置。TextAnchorType 可以设置为 Top、Center、Bottom、Justified 或 Distributed。要设置任何 TextFrame 的锚点，请遵循以下步骤：

1. 创建一个 `Presentation` 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 TextFrame。
5. 设置 TextFrame 的 TextAnchorType。
6. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}


## **为 TextFrame 设置自定义旋转角度**
Aspose.Slides for C++ 现在支持为文本框设置自定义旋转角度。在本主题中，我们将通过示例学习如何在 Aspose.Slides 中设置 RotationAngle 属性。新属性 RotationAngle 已添加到 IChartTextBlockFormat 和 ITextFrameFormat 接口，允许设置文本框的自定义旋转角度。要设置 RotationAngle 属性，请遵循以下步骤：

1. 创建一个 Presentation 类的实例。
2. 在幻灯片上添加一个图表。
3. 设置 RotationAngle 属性。
4. 将演示文稿写为 PPTX 文件。

在下面给出的示例中，我们设置了 RotationAngle 属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **设置校对语言**

Aspose.Slides 提供 [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) 属性（由 [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是用于检查 PowerPoint 中拼写和语法的语言。

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
// 设置校对语言的 Id

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **设置默认语言**

下面的 C++ 代码展示了如何为整个 PowerPoint 演示文稿设置默认语言：

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// 添加一个带有文本的新矩形形状
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"新文本");

// 检查第一个部分的语言
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **设置默认文本样式**

如果您需要一次将相同的默认文本格式应用于演示文稿中的所有文本元素，则可以使用 [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) 接口中的 `get_DefaultTextStyle` 方法来设置首选格式。下面的代码示例展示如何为新演示文稿中的所有幻灯片设置默认粗体字体（14pt）。

```c++
auto presentation = MakeObject<Presentation>();

// 获取顶层段落格式。
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```