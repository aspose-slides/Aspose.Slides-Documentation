---
title: 在 C++ 中管理簡報註解
linktitle: 簡報註解
type: docs
weight: 100
url: /zh-hant/cpp/presentation-comments/
keywords:
- 註解
- 現代註解
- PowerPoint 註解
- 簡報註解
- 投影片註解
- 新增註解
- 存取註解
- 編輯註解
- 回覆註解
- 移除註解
- 刪除註解
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 管理簡報註解：快速且輕鬆地在 PowerPoint 簡報中新增、閱讀、編輯、回覆以及移除註解。"
---
## **概述**

本文說明如何使用 Aspose.Slides for C++ 管理簡報註解。它介紹了主要的註解相關型別，並示範如何向投影片新增註解、存取現有註解、處理回覆與現代註解，以及如何從簡報中移除註解。

這些範例涵蓋了 PowerPoint 中常見的審閱與協作情境，例如指派註解作者、讀取註解文字與中繼資料、建立回覆鏈，及移除選取的註解或全部註解。

在 PowerPoint 中，註解顯示為投影片上的註記。選取註解時會顯示其文字與相關討論。

## **為何要在簡報中加入註解？**

在審閱簡報時，您可以使用註解提供回饋並與同事協作。

Aspose.Slides for C++ 提供以下 API 以處理註解：

* [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別，可存取簡報的註解作者。
* [ICommentCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icommentcollection/) 介面，代表與單一作者相關的註解集合。
* [IComment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icomment/) 介面，提供註解資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/commentauthor/) 類別，提供作者資訊，包括名稱、縮寫與相關註解。

## **新增投影片註解**

以下範例示範如何在 PowerPoint 簡報的投影片中新增註解：

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

## **存取投影片註解**

以下範例示範如何存取 PowerPoint 簡報中現有的註解：

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

## **回覆註解**

父註解是回覆階層頂端的原始註解。[IComment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icomment/) 介面的 [get_ParentComment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icomment/get_parentcomment/) 與 [set_ParentComment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icomment/set_parentcomment/) 方法可取得或設定註解的父項。

以下範例示範如何新增回覆並檢查產生的註解階層：

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

{{% alert color="warning" title="警告" %}}
* 當使用 [IComment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icomment/) 介面的 [Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icomment/remove/) 方法刪除註解時，該註解的所有回覆也會被刪除。  
* 若 [set_ParentComment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icomment/set_parentcomment/) 方法造成循環參照，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **新增現代註解**

現代註解可以與投影片本身、特定圖形，或 AutoShape 內的文字範圍相關聯。[ICommentCollection::AddModernComment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icommentcollection/addmoderncomment/) 方法除了接受投影片與註解標記座標外，還接受一個 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 參數。

當 shape 參數傳入 `nullptr` 時，註解為投影片層級的註解。其標記位置由提供的座標決定，但不會與特定圖形關聯，因此 [IModernComment::get_Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_shape/) 會回傳 `nullptr`。若提供 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/)，則註解會錨定於該圖形。座標仍決定註解標記在投影片上的位置，而圖形關聯可透過 [IModernComment::get_Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_shape/) 取得。

### **將現代註解錨定至圖形**

以下範例同時建立投影片層級的現代註解與錨定於特定 AutoShape 的現代註解，並讀取每個註解的關聯圖形。

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

### **將註解錨定至不同圖形類型**

任何實作 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 的投影片物件皆可作為圖形錨點。常見範例包括 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iconnector/)，以及如圖表等 [IGraphicalObject](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igraphicalobject/) 實例。

以下範例建立多種常見圖形類型，並為每一個圖形關聯現代註解。

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

### **將註解錨定至文字並設定其狀態**

對於與 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 相關聯的現代註解，[IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_textselectionstart/) 與 [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/set_textselectionstart/) 控制所選文字在圖形文字框中的起始位置。同理，[IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_textselectionlength/) 與 [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/set_textselectionlength/) 控制選取的長度。這些方法共同將註解與 AutoShape 內的特定文字範圍關聯。

[IModernComment::get_Status](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_status/) 與 [IModernComment::set_Status](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/set_status/) 方法使用 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/moderncommentstatus/) 列舉中的值：

- `NotDefined` — 未定義特定的現代註解狀態。  
- `Active` — 註解為活躍狀態。  
- `Resolved` — 註解已解決。  
- `Closed` — 註解已關閉。

以下範例建立一個錨定於圖形的現代註解，將其與文字選取關聯，標記為已解決，保存簡報，並在重新開啟檔案後驗證其值。

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

### **檢查現有的現代註解**

若要檢查現有簡報，請先找出實作 [IModernComment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/) 的註解，然後檢查 [IModernComment::get_Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_shape/)、[IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_textselectionstart/)、[IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_textselectionlength/) 與 [IModernComment::get_Status](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_status/)。`nullptr` 形狀表示投影片層級的註解。對於以 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 錨定的註解，文字選取方法會指出該圖形文字框中的相關範圍。

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

## **移除註解**

### **移除全部註解與註解作者**

以下範例示範如何從簡報中移除所有註解與註解作者：

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

### **移除特定註解**

以下範例示範如何從投影片中移除特定註解：

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

## **常見問題**

**Aspose.Slides 是否支援現代註解的解決狀態？**

是的。[IModernComment::get_Status](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/get_status/) 與 [IModernComment::set_Status](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imoderncomment/set_status/) 使用 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/moderncommentstatus/) 的值，包括 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可讀取。

**是否支援串接式討論（回覆鏈），且有巢狀限制嗎？**

是的。每個註解都可以參照其[父註解](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icomment/set_parentcomment/)，從而形成回覆鏈。API 並未定義特定的巢狀深度限制。

**註解標記在投影片上的位置以何種座標系統定義？**

標記位置以浮點座標表示，使用投影片的座標系統，讓您可以精確地將其放置於投影片上。