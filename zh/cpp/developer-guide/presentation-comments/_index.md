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
description: "使用 Aspose.Slides for C++ 管理演示文稿批注：快速轻松地在 PowerPoint 演示文稿中添加、读取、编辑、回复和删除批注。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for C++ 管理演示文稿的批注。它阐述了主要的批注相关类型，并演示了如何向幻灯片添加批注、访问现有批注、处理回复和现代批注，以及从演示文稿中删除批注。

示例涵盖了 PowerPoint 中常见的审阅与协作场景，例如为作者分配批注、读取批注文本和元数据、构建回复链，以及删除选定的批注或全部批注。

在 PowerPoint 中，批注显示为幻灯片上的注释。选中批注后会显示其文本及相关讨论。

当打开演示文稿时显示或隐藏批注，请参见[打开演示文稿时显示或隐藏批注](/slides/zh/cpp/presentation-view-properties/)。

## **为什么要在演示文稿中添加批注？**

在审阅演示文稿时，您可以使用批注提供反馈并与同事协作。

Aspose.Slides for C++ 提供以下用于处理批注的 API：

* The [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类，提供对演示文稿批注作者的访问。
* The [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) 接口，表示与单个作者关联的批注。
* The [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) 接口，提供有关批注的信息，包括作者、创建时间、位置和文本。
* The [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) 类，提供有关作者的信息，包括姓名、缩写以及关联的批注。

## **添加幻灯片批注**

示例创建了两个幻灯片，并使用 [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) 注册了一个批注作者。它使用 [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) 在每个幻灯片上放置一个批注，然后使用 [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) 获取该作者在第一张幻灯片上的批注。控制台两次显示第一条批注的文本，演示了通过幻灯片和作者两种方式访问，并且保存的演示文稿包含这两个批注。

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

## **查找或创建批注作者**

当自动审阅重复处理同一演示文稿时，应在添加作者之前搜索由 [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) 返回的集合。 [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) 同时匹配姓名和缩写，并返回匹配作者的数组；如果没有匹配项，则返回空数组。相比之下， [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) 仅按姓名搜索，不考虑缩写。使用已存在于集合中的姓名和缩写调用 [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) 会抛出异常。

示例需要一个至少包含一张幻灯片的演示文稿文件。在两次遍历中，它复用第一个匹配的作者，只有在结果为空时才创建新的作者。如果有多个匹配项，则选择数组的第一个元素，而不合并或删除其他作者。随后为选定的作者调用 [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) 并保存演示文稿。第二次遍历打开第一次遍历的输出并重复该操作。

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

第二次遍历会添加另一条批注，但不会再添加作者或删除已有批注。最终文件 `review_pass_2.pptx` 包含这两个新批注以及任何原有批注。复用作者并不会对批注去重：若要避免重复添加相同批注，需要在添加前实现单独的重复检测。

## **访问幻灯片批注**

示例打开一个现有的演示文稿，并读取由 [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) 返回的集合。对于每个作者，它遍历由 [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) 返回的集合，并打印幻灯片编号、批注文本、作者姓名和创建时间。输入的演示文稿必须包含批注才能在控制台产生输出。

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

父批注是回复层级顶部的原始批注。 [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) 接口的 [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) 和 [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) 方法允许您获取或设置批注的父批注。

示例由两位作者创建批注，并使用 [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) 构建回复，包括对另一个回复的回复。向 [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) 传入 `nullptr` 可检索所有作者的批注；控制台根据回复层级的深度对每条记录进行缩进。示例保存完整的讨论，对第一条根批注调用 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/)，并保存第二个演示文稿，其中该批注及其回复已被删除。

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

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
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

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* 当使用 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) 方法的 [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) 接口删除批注时，该批注的所有回复也会被删除。
* 如果 [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) 方法导致循环引用，则会抛出 [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加现代批注**

现代批注可以关联到幻灯片本身、特定形状或 AutoShape 内的文本范围。 [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) 方法除了接受幻灯片和批注标记坐标外，还接受一个 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 参数。

如果为 shape 参数传入 `nullptr`，则该批注为幻灯片级批注。其标记由提供的坐标定位，但不关联到特定形状，因此 [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) 返回 `nullptr`。如果提供了 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)，则批注锚定到该形状。坐标仍然定义批注标记在幻灯片上的位置，而形状关联可通过 [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) 获取。

### **将现代批注锚定到形状**

示例调用 [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) 两次：一次使用 `nullptr` shape 创建幻灯片级批注，另一次使用矩形作为锚点。调用 [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) 对幻灯片级批注的空检查输出 `True`，对锚定批注输出 `Revenue title`。两个批注均随演示文稿一起保存。

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

任何实现了 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 的幻灯片对象都可以用作形状锚点。常见示例包括 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/) 以及诸如图表等的 [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) 实例。

示例使用 [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) 将批注关联到五种形状类型：AutoShape、图片框、组形状、连接线和图表。图片使用嵌入的图像数据，无需外部图像。每个批注都有自己的标记位置，保存的演示文稿保留了这五种形状的关联。

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

对于关联到 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 的现代批注， [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) 和 [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) 控制形状文本框中所选文本的起始位置。类似地， [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) 和 [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) 控制选择的长度。这些方法共同将批注关联到 AutoShape 内的特定文本范围。

 [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) 和 [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) 方法使用 [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) 枚举中的值：

- `NotDefined` — 未定义特定的现代批注状态。
- `Active` — 批注处于活动状态。
- `Resolved` — 批注已解决。
- `Closed` — 批注已关闭。

示例将现代批注锚定到矩形文本中“quarterly revenue”这几个词。它根据文本计算零基的选择起始位置，并将其传递给 [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/)，随后使用选中字符数调用 [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/)。调用带有 `Resolved` 的 [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) 后，保存并重新打开演示文稿。四个控制台检查应各自输出 `True`，以确认形状锚点、文本范围和状态均被保留。

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

示例需要一个包含现代批注的现有演示文稿，并打印其文本、状态和锚点详情。要检查它，请先确定哪些批注实现了 [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/)，然后检查 [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/)、[IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/)、[IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) 和 [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/)。`nullptr` shape 表示幻灯片级批注。对于 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 锚点，文本选择方法标识形状文本框中的关联范围。

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

Aspose.Slides for C++ 可让您从演示文稿中删除所有批注及其作者，或仅删除选定的批注而保留其余内容。以下示例演示了这两种方法并保存更新后的演示文稿。

### **删除所有批注及批注作者**

示例打开一个现有的演示文稿，对每个作者调用 [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/)，随后调用 [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) 删除作者本身。保存的演示文稿既不包含批注，也不包含批注作者。请使用包含批注的演示文稿以观察删除效果。

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

示例在同一张幻灯片上创建两个批注，并使用 [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) 按作者查找批注。它先收集文本等于 “comment 1” 的批注，然后调用 [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/)，以避免在选择期间对集合进行修改。保存的演示文稿仅保留 “comment 2”。

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

是。 [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) 和 [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) 使用 [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) 值，包括 `Resolved`。该状态存储在演示文稿中，重新打开文件后仍可读取。

**是否支持线程式讨论（回复链），以及是否有限制嵌套层级？**

是。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/)，从而实现回复链。API 并未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置使用何种坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标定义，您可以在幻灯片上精确定位它。