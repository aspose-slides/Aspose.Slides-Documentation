---
title: 管理文本框
type: docs
weight: 20
url: /cpp/manage-textbox/
keywords: "文本框, 文本框架, 添加文本框, 带超链接的文本框, C++, Aspose.Slides for C++"
description: "在 C++ 中将文本框或文本框架添加到 PowerPoint 演示文稿"
---

幻灯片上的文本通常存在于文本框或形状中。因此，要向幻灯片添加文本，您必须添加一个文本框，然后在文本框中放入一些文本。Aspose.Slides for C++ 提供了 [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) 接口，允许您添加一个包含文本的形状。

{{% alert title="信息" color="info" %}}

Aspose.Slides 还提供了 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) 接口，允许您向幻灯片添加形状。然而，并非通过 `IShape` 接口添加的所有形状都可以包含文本。但通过 [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) 接口添加的形状可以包含文本。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

因此，当处理您希望添加文本的形状时，您可能需要检查并确认它是通过 `IAutoShape` 接口进行转换的。只有这样，您才能处理属于 `IAutoShape` 的 [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) 属性。请参见本页上的 [更新文本](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) 部分。

{{% /alert %}}

## **在幻灯片上创建文本框**

要在幻灯片上创建文本框，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 获取新创建的演示文稿中第一张幻灯片的引用。
3. 在幻灯片上添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) 对象，并将 [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) 设置为 `Rectangle`，并在指定位置获取新添加的 `IAutoShape` 对象的引用。
4. 向 `IAutoShape` 对象添加一个将包含文本的 `TextFrame` 属性。在下面的示例中，我们添加了以下文本：*Aspose TextBox*
5. 最后，通过 `Presentation` 对象写出 PPTX 文件。

以下 C++ 代码—上述步骤的实现—向您展示了如何向幻灯片添加文本：

```cpp
// 实例化 Presentation
auto pres = System::MakeObject<Presentation>();

// 获取演示文稿中的第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 添加类型设置为矩形的 AutoShape
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 向矩形添加 TextFrame
ashp->AddTextFrame(u" ");

// 访问文本框
auto txtFrame = ashp->get_TextFrame();

// 创建文本框的段落对象
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// 创建段落的部分对象
auto portion = para->get_Portions()->idx_get(0);

// 设置文本
portion->set_Text(u"Aspose TextBox");

// 将演示文稿保存到磁盘
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **检查文本框形状**

Aspose.Slides 提供 [get_IsTextBox()](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) 方法（来自 [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) 类），允许您检查形状并查找文本框。

![文本框和形状](istextbox.png)

此 C++ 代码向您展示了如何检查形状是否作为文本框创建：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
for (auto&& slide : pres->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        auto autoShape = System::DynamicCast_noexcept<Aspose::Slides::AutoShape>(shape);
        if (autoShape != nullptr)
        {
            System::Console::WriteLine(autoShape->get_IsTextBox() ? System::String(u"形状是文本框") : System::String(u"形状不是文本框"));
        }
    }
}
```

## **在文本框中添加列**

Aspose.Slides 提供 [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 和 [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) 方法（来自 [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) 接口和 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) 类），允许您向文本框添加列。您可以指定文本框中的列数并设置列之间的间距（以点为单位）。

以下 C++ 代码演示了所描述的操作：

```cpp
auto presentation = System::MakeObject<Presentation>();
// 获取演示文稿中的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 添加类型设置为矩形的 AutoShape
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// 向矩形添加 TextFrame
aShape->AddTextFrame(String(u"所有这些列都限于在单个文本容器内 -- ") 
    + u"您可以添加或删除文本，新的或剩余的文本会自动调整 " 
    + u"自身以在容器内流动。不过，您不能让文本从一个容器流向另一个容器 " 
    + u"因为我们告诉您 PowerPoint 的文本列选项是有限的！");

// 获取文本框的文本格式
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// 指定 TextFrame 中的列数
format->set_ColumnCount(3);

// 指定列之间的间距
format->set_ColumnSpacing(10);

// 保存演示文稿
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **在文本框架中添加列**
Aspose.Slides for C++ 提供 [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 方法（来自 [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) 接口），允许您在文本框架中添加列。通过此方法，您可以指定文本框架中所需的列数。

此 C++ 代码向您展示了如何在文本框架中添加列：

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"所有这些列都被强制保持在单个文本容器内 -- ") 
    + u"您可以添加或删除文本，新的或剩余的文本会自动调整 " 
    + u"自身以保持在容器内。不过，您不能让文本从一个容器溢出到另一个容器 " 
    + u"因为 PowerPoint 的文本列选项是有限的！");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **更新文本**

Aspose.Slides 允许您更改或更新文本框中包含的文本或演示文稿中包含的所有文本。

此 C++ 代码演示了一种操作，更新或更改演示文稿中的所有文本：

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //更改文本
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //更改格式
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//保存修改后的演示文稿
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **添加带超链接的文本框** 

您可以在文本框中插入链接。当单击文本框时，用户将被引导打开链接。

要添加包含链接的文本框，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。
2. 获取新创建的演示文稿中第一张幻灯片的引用。
3. 在幻灯片上添加一个 `AutoShape` 对象，将 `ShapeType` 设置为 `Rectangle`，并获取新添加的 AutoShape 对象的引用。
4. 向 `AutoShape` 对象添加一个包含 *Aspose TextBox* 作为默认文本的 `TextFrame`。
5. 实例化 `IHyperlinkManager` 类。
6. 将 `IHyperlinkManager` 对象分配给与您所需部分的 [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) 方法关联。
7. 最后，通过 `Presentation` 对象写出 PPTX 文件。

以下 C++ 代码—上述步骤的实现—向您展示了如何将带超链接的文本框添加到幻灯片：

```cpp
// 实例化表示 PPTX 的 Presentation 类
auto presentation = System::MakeObject<Presentation>();

// 获取演示文稿中的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 添加类型设置为矩形的 AutoShape 对象
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// 将形状转换为 AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// 访问与 AutoShape 关联的 ITextFrame 属性
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// 向框架中添加一些文本
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// 为部分文本设置超链接
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// 保存 PPTX 演示文稿
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```