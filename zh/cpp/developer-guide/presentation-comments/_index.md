---
title: 在 C++ 中管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/cpp/presentation-comments/
keywords:
- 批注
- 现代批注
- PowerPoint 批注
- 演示文稿批注
- 幻灯片批注
- 添加批注
- 访问批注
- 编辑批注
- 回复批注
- 删除批注
- 删除批注
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 管理演示文稿批注：在 PowerPoint 演示文稿中快速轻松地添加、读取、编辑、回复和删除批注。"
---
## **概述**

本文解释了如何使用 Aspose.Slides for C++ 管理演示文稿批注。它介绍了主要的批注相关类型，并演示了如何向幻灯片添加批注、访问现有批注、使用回复和现代批注以及从演示文稿中删除批注。

示例涵盖了 PowerPoint 中常见的审阅和协作场景，例如将批注分配给作者、读取批注文本和元数据、构建回复链，以及删除选定的批注或全部批注。

在 PowerPoint 中，批注以注释的形式显示在幻灯片上。选择批注时会显示其文本和相关讨论。

## **为什么向演示文稿添加批注？**

在审阅演示文稿时，您可以使用批注提供反馈并与同事协作。

Aspose.Slides for C++ 提供以下用于处理批注的 API：

* The [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类，提供对演示文稿的批注作者的访问。
* The [ICommentCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icommentcollection/) 接口，表示与单个作者关联的批注。
* The [IComment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icomment/) 接口，提供有关批注的信息，包括作者、创建时间、位置和文本。
* The [CommentAuthor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/commentauthor/) 类，提供有关作者的信息，包括姓名、首字母和关联的批注。

## **添加幻灯片批注**

以下示例展示了如何在 PowerPoint 演示文稿中向幻灯片添加批注：

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **访问幻灯片批注**

以下示例展示了如何访问 PowerPoint 演示文稿中已有的批注：

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **回复批注**

父批注是回复层级顶部的原始批注。[get_ParentComment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icomment/get_parentcomment/) 和 [set_ParentComment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icomment/set_parentcomment/) 方法属于 [IComment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icomment/) 接口，可用于获取或设置批注的父级。

以下示例展示了如何添加回复并检查生成的批注层级结构：

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* 当使用 [IComment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icomment/) 接口的 [Remove](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icomment/remove/) 方法删除批注时，该批注的所有回复也会被删除。
* 如果 [set_ParentComment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icomment/set_parentcomment/) 方法导致循环引用，则会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加现代批注**

现代批注可以关联到幻灯片本身、特定形状或 AutoShape 中的文本范围。[ICommentCollection::AddModernComment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icommentcollection/addmoderncomment/) 方法在接受幻灯片和批注标记坐标之外，还接受一个 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 参数。

当 `nullptr` 作为形状参数传入时，批注为幻灯片级批注。其标记位置由提供的坐标确定，但不关联到特定形状，因此 [IModernComment::get_Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_shape/) 返回 `nullptr`。当提供了 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 时，批注锚定到该形状。坐标仍然定义批注标记在幻灯片上的位置，形状关联可通过 [IModernComment::get_Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_shape/) 获取。

### **将现代批注锚定到形状**

以下示例创建了一个幻灯片级现代批注和一个锚定到特定 AutoShape 的现代批注，然后读取每个批注关联的形状。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **将批注锚定到不同的形状类型**

任何实现了 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 的幻灯片对象都可以用作形状锚点。常见示例包括 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iconnector/) 和 [IGraphicalObject](https://reference.aspose.com/slides/zh/cpp/aspose.slides/igraphicalobject/)（如图表）实例。

以下示例创建了几种常见的形状类型，并为每一种关联了一个现代批注。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");
auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **将批注锚定到文本并设置其状态**

对于关联到 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 的现代批注，[IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_textselectionstart/) 和 [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/set_textselectionstart/) 控制形状文本框中所选文本的起始位置。类似地，[IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_textselectionlength/) 和 [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/set_textselectionlength/) 控制选区的长度。这些方法共同将批注关联到 AutoShape 中的特定文本范围。

[IModernComment::get_Status](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_status/) 和 [IModernComment::set_Status](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/set_status/) 方法使用 [ModernCommentStatus](https://reference.aspose.com/slides/zh/cpp/aspose.slides/moderncommentstatus/) 枚举的值：

- `NotDefined` — 未定义特定的现代批注状态。
- `Active` — 批注处于活动状态。
- `Resolved` — 批注已解决。
- `Closed` — 批注已关闭。

以下示例创建了一个锚定到形状的现代批注，关联到文本选区，将其标记为已解决，保存演示文稿，并在重新打开文件后验证这些值。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **检查现有的现代批注**

要检查现有演示文稿，首先判断哪些批注实现了 [IModernComment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/)，然后检查 [IModernComment::get_Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_shape/)、[IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_textselectionstart/)、[IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_textselectionlength/) 和 [IModernComment::get_Status](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_status/)。`nullptr` 形状表示该批注为幻灯片级批注。对于锚定到 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 的批注，文本选区方法可识别形状文本框中的关联范围。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **删除批注**

### **删除所有批注和批注作者**

以下示例展示了如何从演示文稿中删除所有批注和批注作者：

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **删除特定批注**

以下示例展示了如何从幻灯片中删除特定批注：

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **常见问题**

**Aspose.Slides 是否支持现代批注的已解决状态？**

是的。[IModernComment::get_Status](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/get_status/) 和 [IModernComment::set_Status](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imoderncomment/set_status/) 使用 [ModernCommentStatus](https://reference.aspose.com/slides/zh/cpp/aspose.slides/moderncommentstatus/) 的值，其中包括 `Resolved`。该状态会存储在演示文稿中，文件重新打开后仍可读取。

**是否支持线程式讨论（回复链），是否有嵌套层数限制？**

是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icomment/set_parentcomment/)，从而实现回复链。API 并未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置采用何种坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标定义，您可以精确地将其放置在幻灯片的任意位置。