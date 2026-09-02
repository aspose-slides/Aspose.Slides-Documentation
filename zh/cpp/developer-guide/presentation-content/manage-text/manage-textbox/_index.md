---
title: 使用 C++ 管理演示文稿中的文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/cpp/manage-textbox/
keywords:
- 文本框
- 文本帧
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
description: "Aspose.Slides for C++ 让您轻松在 PowerPoint 和 OpenDocument 文件中创建、编辑和克隆文本框，从而提升演示文稿自动化。"
---
## **介绍**

幻灯片上的文本通常存在于文本框或形状中。因此，要向幻灯片添加文本，需要先添加一个文本框，然后在文本框内放入文本。Aspose.Slides for C++ 提供了 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_auto_shape) 接口，允许您添加包含文本的形状。

{{% alert title="Info" color="info" %}}
Aspose.Slides 还提供了 [IShape](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_shape) 接口，允许您向幻灯片添加形状。然而，并非所有通过 `IShape` 接口添加的形状都能容纳文本。但通过 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_auto_shape) 接口添加的形状可能包含文本。 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
因此，在处理希望添加文本的形状时，您可能需要检查并确认它是通过 `IAutoShape` 接口进行转换的。只有这样，您才能使用 `IAutoShape` 下的属性 [TextFrame](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.text_frame)。请参阅本页面的 [Update Text](https://docs.aspose.com/slides/zh/cpp/manage-textbox/#update-text) 部分。 
{{% /alert %}}

## **在幻灯片上创建文本框**

要在幻灯片上创建文本框，请执行以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。 
2. 获取新创建的演示文稿中第一张幻灯片的引用。 
3. 在幻灯片的指定位置添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_auto_shape) 对象，使用 [ShapeType](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) 设置为 `Rectangle`，并获取新添加的 `IAutoShape` 对象的引用。 
4. 向 `IAutoShape` 对象添加 `TextFrame` 属性，以包含文本。在下面的示例中，我们添加了以下文本：*Aspose TextBox* 
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

下面的 C++ 代码——上述步骤的实现——演示了如何向幻灯片添加文本：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// 实例化 Presentation
auto pres = System::MakeObject<Presentation>();

// 获取演示文稿中的第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 添加 AutoShape，类型设为 Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 向矩形添加 TextFrame
ashp->AddTextFrame(u" ");

// 访问文本框
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

Aspose.Slides 提供了来自 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 接口的 [get_IsTextBox](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/get_istextbox/) 方法，允许您检查形状并识别文本框。

![文本框和形状](istextbox.png)

下面的 C++ 代码演示了如何检查形状是否被创建为文本框： 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
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

请注意，如果仅使用来自 [IShapeCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/) 接口的 `AddAutoShape` 方法添加自动形状，则该自动形状的 `get_IsTextBox` 方法将返回 `false`。然而，在使用 `AddTextFrame` 方法或 `set_Text` 方法向自动形状添加文本后，`get_IsTextBox` 方法将返回 `true`。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

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

## **查找拥有 TextFrame 的形状**

在通用的文本处理代码中，您可能会收到一个 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)，但并不知道它属于哪个演示文稿对象。使用 [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/get_parentshape/) 可以返回拥有它的 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/)。

对于属于 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 或其他包含文本的形状的文本框，`ITextFrame::get_ParentShape` 返回所有者，而 `ITextFrame::get_ParentCell` 返回 `nullptr`。这两种方法均提供只读导航，调用它们不会更改所有权。在访问形状之前，请始终检查返回值是否为 `nullptr`。

请参阅完整示例，其中识别形状和表格单元格所有者，包括与 SmartArt 节点关联的形状，见 [搜索和替换文本](/slides/zh/cpp/search-and-replace-text/)。

## **向文本框添加列**

Aspose.Slides 提供了 [set_ColumnCount](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 和 [set_ColumnSpacing](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) 方法（来自 [ITextFrameFormat](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_text_frame_format) 接口和 [TextFrameFormat](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_text_frame_format) 类），允许您向文本框添加列。您可以指定文本框中的列数并设置列间的点距。

下面的 C++ 代码演示了上述操作：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// 获取演示文稿中的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 添加 AutoShape，类型设为 Rectangle
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

// 指定列间距
format->set_ColumnSpacing(10);

// 保存演示文稿
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **向 TextFrame 添加列**

Aspose.Slides for C++ 提供了 [set_ColumnCount](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 方法（来自 [ITextFrameFormat](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_text_frame_format) 接口），允许您在 TextFrame 中添加列。通过此方法，您可以指定在 TextFrame 中希望的列数。

下面的 C++ 代码演示了如何在 TextFrame 中添加列：

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Aspose.Slides 允许您更改或更新文本框中的文本或演示文稿中所有文本。

下面的 C++ 代码演示了在演示文稿中更新或更改所有文本的操作：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
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

## **添加带超链接的文本框** 

您可以在文本框内插入链接。单击文本框时，用户将被引导打开该链接。 

要添加包含链接的文本框，请执行以下步骤：

1. 创建 `Presentation` 类的实例。 
2. 获取新创建的演示文稿中第一张幻灯片的引用。 
3. 在幻灯片的指定位置添加一个 `AutoShape` 对象，`ShapeType` 设置为 `Rectangle`，并获取新添加的 AutoShape 对象的引用。 
4. 向 `AutoShape` 对象添加 `TextFrame`，其默认文本为 *Aspose TextBox*。 
5. 实例化 `IHyperlinkManager` 类。 
6. 将 `IHyperlinkManager` 对象分配给与 `TextFrame` 中首选部分关联的 [set_HyperlinkClick](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) 方法。 
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

下面的 C++ 代码——上述步骤的实现——演示了如何在幻灯片上添加带超链接的文本框：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// 实例化一个表示 PPTX 的 Presentation 类
auto presentation = System::MakeObject<Presentation>();

// 获取演示文稿中的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 添加一个类型为 Rectangle 的 AutoShape 对象
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// 将形状转换为 AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// 访问与 AutoShape 关联的 ITextFrame 属性
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// 向框中添加一些文本
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// 为该部分文本设置超链接
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// 保存 PPTX 演示文稿
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **常见问题**

**在使用母版幻灯片时，文本框和文本占位符有什么区别？**

A [占位符](/slides/zh/cpp/manage-placeholder/) inherits style/position from the [母版](https://reference.aspose.com/slides/zh/cpp/aspose.slides/masterslide/) and can be overridden on [布局](https://reference.aspose.com/slides/zh/cpp/aspose.slides/layoutslide/), whereas a regular text box is an independent object on a specific slide and doesn’t change when you switch layouts.

**如何在不更改图表、表格和 SmartArt 中的文本的情况下，对整个演示文稿进行批量文本替换？**

Limit your iteration to auto-shapes that have text frames and exclude embedded objects ([图表](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chart/), [表格](https://reference.aspose.com/slides/zh/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartart/)) by traversing their collections separately or skipping those object types.