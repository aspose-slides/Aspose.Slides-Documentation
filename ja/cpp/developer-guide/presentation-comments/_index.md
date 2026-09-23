---
title: "C++でプレゼンテーションコメントを管理する"
linktitle: "プレゼンテーション コメント"
type: docs
weight: 100
url: /ja/cpp/presentation-comments/
keywords:
- "コメント"
- "モダンコメント"
- "PowerPoint コメント"
- "プレゼンテーション コメント"
- "スライド コメント"
- "コメントの追加"
- "コメントへのアクセス"
- "コメントの編集"
- "コメントへの返信"
- "コメントの削除"
- "コメントの削除"
- "PowerPoint"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ を使用してプレゼンテーションコメントを管理します：PowerPoint プレゼンテーション内のコメントを追加、読み取り、編集、返信、削除を迅速かつ簡単に行うことができます。"
---
## **概要**

この記事では、Aspose.Slides for C++ を使用してプレゼンテーションのコメントを管理する方法を説明します。コメントに関連する主要な型を紹介し、スライドへのコメントの追加、既存のコメントへのアクセス、返信やモダンコメントの操作、プレゼンテーションからのコメント削除の方法を示します。

これらの例は、PowerPoint の一般的なレビューおよびコラボレーションシナリオ（コメントを作成者に割り当てる、コメントテキストとメタデータを読み取る、返信チェーンを構築する、選択したコメントまたはすべてのコメントを削除する）をカバーしています。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連するディスカッションが表示されます。

プレゼンテーションを開くときにコメントを表示または非表示にしたいが、コメント自体は変更したくない場合は、[Show or Hide Comments When Opening a Presentation](/slides/ja/cpp/presentation-view-properties/) を参照してください。

## **なぜプレゼンテーションにコメントを追加するのか？**

プレゼンテーションをレビューする際に、コメントを使用してフィードバックを提供し、同僚と協働できます。

Aspose.Slides for C++ は、コメント操作のために以下の API を提供します。

* The [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスは、プレゼンテーションのコメント作成者へのアクセスを提供します。
* The [ICommentCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icommentcollection/) インターフェイスは、個々の作成者に関連付けられたコメントの集合を表します。
* The [IComment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icomment/) インターフェイスは、コメントの作成者、作成時刻、位置、テキストなどの情報を提供します。
* The [CommentAuthor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/commentauthor/) クラスは、作成者の名前、イニシャル、および関連するコメントの情報を提供します。

## **スライドコメントの追加**

以下の例は、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示します：

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

## **スライドコメントへのアクセス**

以下の例は、PowerPoint プレゼンテーション内の既存のコメントへアクセスする方法を示します：

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

## **コメントへの返信**

親コメントは、返信階層の最上位にある元のコメントです。[IComment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icomment/) インターフェイスの [get_ParentComment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icomment/get_parentcomment/) および [set_ParentComment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icomment/set_parentcomment/) メソッドを使用して、コメントの親を取得または設定できます。

以下の例は、返信を追加し、生成されたコメント階層を検査する方法を示します：

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
* [IComment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icomment/) インターフェイスの [Remove](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icomment/remove/) メソッドでコメントを削除すると、そのコメントへのすべての返信も削除されます。
* [set_ParentComment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icomment/set_parentcomment/) メソッドで循環参照が作成された場合、[PptxEditException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxeditexception/) がスローされます。
{{% /alert %}}

## **モダンコメントの追加**

モダンコメントは、スライド自体、特定のシェイプ、または AutoShape 内のテキスト範囲に関連付けることができます。[ICommentCollection::AddModernComment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icommentcollection/addmoderncomment/) メソッドは、スライドとコメントマーカー座標に加えて [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) 引数も受け取ります。

`nullptr` がシェイプ引数として渡された場合、コメントはスライドレベルのコメントになります。マーカーは指定された座標で配置されますが、特定のシェイプには関連付けられないため、[IModernComment::get_Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_shape/) は `nullptr` を返します。`IShape` が提供された場合、コメントはそのシェイプに固定されます。座標は依然としてスライド上のマーカー位置を定義し、シェイプの関連付けは [IModernComment::get_Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_shape/) で取得できます。

### **モダンコメントをシェイプに固定する**

以下の例は、スライドレベルのモダンコメントと特定の AutoShape に固定されたモダンコメントの両方を作成し、各コメントから関連シェイプを取得します。

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

### **異なるシェイプタイプへのコメント固定**

[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) を実装する任意のスライドオブジェクトをシェイプアンカーとして使用できます。一般的な例としては、[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iconnector/)、およびチャートなどの [IGraphicalObject](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igraphicalobject/) インスタンスがあります。

以下の例は、いくつかの一般的なシェイプタイプを作成し、各シェイプにモダンコメントを関連付けます。

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

### **テキストへのコメント固定とステータス設定**

[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) に関連付けられたモダンコメントの場合、[IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_textselectionstart/) と [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/set_textselectionstart/) はシェイプのテキストフレーム内で選択されたテキストの開始位置を制御します。同様に、[IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_textselectionlength/) と [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/set_textselectionlength/) は選択範囲の長さを制御します。これらのメソッドを組み合わせることで、コメントを AutoShape 内の特定のテキスト範囲に関連付けます。

[IModernComment::get_Status](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_status/) と [IModernComment::set_Status](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/set_status/) メソッドは、[ModernCommentStatus](https://reference.aspose.com/slides/ja/cpp/aspose.slides/moderncommentstatus/) 列挙体の値を使用します。

- `NotDefined` — 特定のモダンコメントステータスは定義されていません。
- `Active` — コメントはアクティブです。
- `Resolved` — コメントは解決済みです。
- `Closed` — コメントはクローズされています。

以下の例は、シェイプに固定されたモダンコメントを作成し、テキスト選択に関連付け、解決済みとしてマークし、プレゼンテーションを保存してファイルを再度開いた後に値を検証します。

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

### **既存のモダンコメントの検査**

既存のプレゼンテーションを検査するには、どのコメントが [IModernComment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/) を実装しているか確認し、[IModernComment::get_Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_shape/)、[IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_textselectionstart/)、[IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_textselectionlength/)、および [IModernComment::get_Status](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_status/) を調べます。`nullptr` のシェイプはスライドレベルのコメントを示します。[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) がアンカーの場合、テキスト選択メソッドはシェイプのテキストフレーム内の関連範囲を特定します。

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

## **コメントの削除**

### **すべてのコメントとコメント作成者の削除**

以下の例は、プレゼンテーションからすべてのコメントとコメント作成者を削除する方法を示します：

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

### **特定のコメントの削除**

以下の例は、スライドから特定のコメントを削除する方法を示します：

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

## **よくある質問**

**Aspose.Slides はモダンコメントの解決済みステータスをサポートしていますか？**

はい。 [IModernComment::get_Status](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/get_status/) と [IModernComment::set_Status](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imoderncomment/set_status/) は、`Resolved` を含む [ModernCommentStatus](https://reference.aspose.com/slides/ja/cpp/aspose.slides/moderncommentstatus/) の値を使用します。ステータスはプレゼンテーションに保存され、ファイルを再度開いた後でも読み取れます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？ また、ネストの上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icomment/set_parentcomment/) を参照できるため、返信チェーンが可能です。API には特定のネスト深度上限は定義されていません。

**コメントマーカーの位置はスライド上のどの座標系で定義されていますか？**

マーカーの位置はスライド座標系の浮動小数点座標で定義されており、スライド上の正確な位置に配置できます。