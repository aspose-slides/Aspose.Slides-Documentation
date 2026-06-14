---
title: 管理 C++ 簡報註解
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
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 精通簡報註解：快速輕鬆地在 PowerPoint 檔案中新增、閱讀、編輯與刪除註解。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中管理簡報註解。它展示了與註解相關的主要類型，並示範如何向投影片新增註解、存取現有註解、處理回覆、使用現代註解，以及從簡報中移除註解。

這些範例聚焦於 PowerPoint 中常見的審閱與協作情境，例如指派註解給作者、讀取註解內容與中繼資料、建立回覆鏈，以及清除所有註解或刪除選取的註解。

在 PowerPoint 中，註解會顯示為投影片上的備註或標註。點選註解時，會顯示其內容或訊息。

### **為何要在簡報中新增註解？**

在審閱簡報時，您可能想使用註解提供回饋或與同事溝通。

為了讓您能在 PowerPoint 簡報中使用註解，Aspose.Slides for C++ 提供
* The [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別，包含作者集合（來自 [get_CommentAuthors()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) 方法）。作者會向投影片新增註解。
* The  [ICommentCollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_comment_collection) 介面，包含各個作者的註解集合。
* The  [IComment](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_comment) 類別，包含關於作者及其註解的資訊：誰新增了註解、註解新增的時間、註解的位置等等。
* The [CommentAuthor](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.comment_author) 類別，包含個別作者的資訊：作者姓名、縮寫、與作者姓名相關的註解等等。

## **新增投影片註解**
此 C++ 程式碼示範如何在 PowerPoint 簡報的投影片上新增註解：

```cpp
// 建立 Presentation 類別的實例
auto presentation = System::MakeObject<Presentation>();
// 新增一個空白投影片
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// 新增作者
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// 設定註解的位置
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// 取得 ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// 取得 ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// 在投影片 1 上為作者新增投影片註解
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// 在投影片 2 上為作者新增投影片註解
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// 當以 null 作為參數傳入時，會將所有作者的註解帶入選取的投影片
auto comments = slide1->GetSlideComments(author);

// 取得投影片 1 中索引為 0 的註解
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // 選取索引為 0 的作者註解集合
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **存取投影片註解**
此 C++ 程式碼示範如何在 PowerPoint 簡報的投影片上存取現有的註解：

```cpp
// 建立 Presentation 類別的實例
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **回覆註解**
父註解是註解或回覆層級中的最上層或原始註解。使用 [ParentComment](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) 屬性（來自 [IComment](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_comment) 介面），您可以設定或取得父註解。

此 C++ 程式碼示範如何新增註解以及取得其回覆：

```cpp
auto pres = System::MakeObject<Presentation>();

// 取得 ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// 新增註解
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// 為 comment1 新增回覆
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// 為 comment1 再新增另一個回覆
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// 為現有回覆新增回覆
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// 在主控台顯示註解層次結構
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// 移除 comment1 以及其所有回覆
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* 當使用 [Remove](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) 方法（來自 [IComment](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_comment) 介面）刪除註解時，該註解的回覆也會一併被刪除。
* 如果設定 [ParentComment](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) 產生循環參考，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)。
{{% /alert %}}

## **新增現代註解**

2021 年，Microsoft 在 PowerPoint 中推出 *modern comments*（現代註解）。現代註解功能大幅提升了 PowerPoint 的協作能力。透過現代註解，PowerPoint 使用者可以更輕鬆地解決註解、將註解錨定於物件和文字，並進行互動。

在 [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/zh-hant/cpp/aspose-slides-for-cpp-21-11-release-notes/) 中，我們透過加入 [ModernComment](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.modern_comment) 類別實作了對現代註解的支援。已在 [CommentCollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.comment_collection) 類別中加入 [AddModernComment](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) 與 [InsertModernComment](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) 方法。

此 C++ 程式碼示範如何在 PowerPoint 簡報的投影片上新增現代註解： 

```cpp
auto pres = System::MakeObject<Presentation>();
// 取得 ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **移除註解**

### **刪除所有註解與作者**

此 C++ 程式碼示範如何在簡報中移除所有註解與作者：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// 刪除簡報中的所有註解
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// 刪除所有作者
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **刪除特定註解**

此 C++ 程式碼示範如何在投影片上刪除特定註解：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// 新增註解...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// 移除所有包含 "comment 1" 文字的註解
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **常見問題**

**Aspose.Slides 是否支援現代註解的「已解決」狀態？**

是的。[Modern comments](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/moderncomment/) 提供 [get_Status](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/moderncomment/get_status/) 與 [set_Status](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/moderncomment/set_status/) 方法；您可以讀取與設定 [comment’s state](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/moderncommentstatus/)（例如將其標記為已解決），此狀態會儲存在檔案中，且會被 PowerPoint 識別。

**是否支援串聯討論（回覆鏈），且有巢狀深度限制嗎？**

是的。每個註解都可以參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/comment/set_parentcomment/)，從而實現任意深度的回覆鏈。API 沒有宣告特定的巢狀深度限制。

**註解標記在投影片上的位置是以什麼座標系統定義的？**

位置以浮點座標點儲存在投影片的座標系統中。這讓您能精確地將註解標記放置在需要的位置。