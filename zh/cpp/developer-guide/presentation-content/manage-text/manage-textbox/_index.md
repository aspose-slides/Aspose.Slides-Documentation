---
title: 使用 C++ 在演示文稿中管理文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/cpp/manage-textbox/
keywords:
- 文本框
- 文本框架
- 添加文本
- 更新文本
- 创建文本框
- 检查文本框
- 添加文本列
- 添加超链接
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 让您能够轻松在 PowerPoint 和 OpenDocument 文件中创建、编辑和克隆文本框，提升演示文稿自动化水平。"
---

幻灯片上的文本通常存在于文本框或形状中。因此，要向幻灯片添加文本，需要先添加一个文本框，然后在文本框中放入一些文本。Aspose.Slides for C++ 提供了 [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) 接口，允许您添加包含文本的形状。

{{% alert title="Info" color="info" %}}
Aspose.Slides 还提供了 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) 接口，允许您向幻灯片添加形状。然而，并非所有通过 `IShape` 接口添加的形状都可以容纳文本。但通过 [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) 接口添加的形状可以包含文本。
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
因此，在处理想要添加文本的形状时，您可能需要检查并确认它是通过 `IAutoShape` 接口进行转换的。只有这样，您才能使用位于 `IAutoShape` 下的属性 [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame)。请参阅本页的 [Update Text](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) 部分。
{{% /alert %}}

## **在幻灯片上创建文本框**

要在幻灯片上创建文本框，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。  
2. 获取新建演示文稿中第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) 对象，并将 [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) 设置为 `Rectangle`，然后获取新添加的 `IAutoShape` 对象的引用。  
4. 向 `IAutoShape` 对象添加一个 `TextFrame` 属性，以容纳文本。在下面的示例中，我们添加了以下文本：*Aspose TextBox*  
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。  

以下 C++ 代码——上述步骤的实现——演示了如何向幻灯片添加文本：
```cpp
// 实例化 Presentation
auto pres = System::MakeObject<Presentation>();

// 获取演示文稿中的第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 添加类型为 Rectangle 的 AutoShape
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 向矩形添加 TextFrame
ashp->AddTextFrame(u" ");

// 访问文本框架
auto txtFrame = ashp->get_TextFrame();

// 为文本框创建 Paragraph 对象
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// 为段落创建 Portion 对象
auto portion = para->get_Portions()->idx_get(0);

// 设置文本
portion->set_Text(u"Aspose TextBox");

// 将演示文稿保存到磁盘
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```


## **检查文本框形状**

Aspose.Slides 提供了来自 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 接口的 [get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) 方法，帮助您检查形状并识别文本框。

![Text box and shape](istextbox.png)

下面的 C++ 代码演示了如何检查形状是否被创建为文本框：
```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```


请注意，如果仅使用 [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) 接口的 `AddAutoShape` 方法添加自动形状，则该自动形状的 `get_IsTextBox` 方法将返回 `false`。但在使用 `AddTextFrame` 方法或 `set_Text` 方法向自动形状添加文本后，`get_IsTextBox` 方法将返回 `true`。
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() 返回 false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() 返回 true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() 返回 false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() 返回 true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() 返回 false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() 返回 false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() 返回 false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() 返回 false
```


## **向文本框添加列**

Aspose.Slides 提供了 [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 和 [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) 方法（来自 [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) 接口和 [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) 类），允许您向文本框添加列。您可以指定文本框的列数并设置列之间的点间距。

以下 C++ 代码演示了上述操作：
```cpp
auto presentation = System::MakeObject<Presentation>();
// 获取演示文稿中的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 添加类型为 Rectangle 的 AutoShape
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// 向矩形添加 TextFrame
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// 获取 TextFrame 的文本格式
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// 指定 TextFrame 中的列数
format->set_ColumnCount(3);

// 指定列之间的间距
format->set_ColumnSpacing(10);

// 保存演示文稿
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **向文本帧添加列**

Aspose.Slides for C++ 提供了 [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 方法（来自 [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) 接口），允许您在文本帧中添加列。通过此方法，您可以指定文本帧中所需的列数。

以下 C++ 代码演示了如何在文本帧中添加列：
```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
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

Aspose.Slides 允许您更改或更新文本框中的文本，或演示文稿中所有文本。

以下 C++ 代码演示了将演示文稿中所有文本更新或更改的操作：
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

//保存已修改的演示文稿
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```


## **向文本框添加超链接**

您可以在文本框中插入链接。单击文本框时，用户将打开链接。

要添加包含链接的文本框，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。  
2. 获取新建演示文稿中第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个 `AutoShape` 对象，并将 `ShapeType` 设置为 `Rectangle`，然后获取新添加的 AutoShape 对象的引用。  
4. 向 `AutoShape` 对象添加一个 `TextFrame`，其默认文本为 *Aspose TextBox*。  
5. 实例化 `IHyperlinkManager` 类。  
6. 将 `IHyperlinkManager` 对象分配给与您所选 `TextFrame` 部分关联的 [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) 方法。  
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。  

以下 C++ 代码——上述步骤的实现——演示了如何向幻灯片添加带超链接的文本框：
```cpp
// 实例化一个表示 PPTX 的 Presentation 类
auto presentation = System::MakeObject<Presentation>();

// 获取演示文稿中的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 添加一个类型为 Rectangle 的 AutoShape 对象
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// 将形状转换为 AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// 访问 AutoShape 关联的 ITextFrame 属性
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// 向框中添加一些文本
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// 为该段文本设置超链接
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// 保存 PPTX 演示文稿
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```


## **常见问题**

**在使用母版幻灯片时，文本框和文本占位符有什么区别？**  
一个 [placeholder](/slides/zh/cpp/manage-placeholder/) 从 [master](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) 继承样式/位置，并且可以在 [layouts](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) 上被覆盖，而普通的文本框是特定幻灯片上的独立对象，在切换布局时不会改变。

**如何在整个演示文稿中进行批量文本替换，而不影响图表、表格和 SmartArt 中的文本？**  
将遍历范围限制为具有文本框的自动形状，并通过单独遍历或跳过这些对象类型，排除嵌入对象（[charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/cpp/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)）。