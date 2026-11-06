---
title: C++ でプレゼンテーション コメントを管理する
linktitle: プレゼンテーション コメント
type: docs
weight: 100
url: /ja/cpp/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPoint コメント
- プレゼンテーション コメント
- スライド コメント
- コメントを追加
- コメントにアクセス
- コメントを編集
- コメントに返信
- コメントを削除
- コメントを削除
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してプレゼンテーション コメントを管理します：PowerPoint プレゼンテーション内のコメントを追加、読み取り、編集、返信、削除を迅速かつ簡単に行えます。"
---
## **概要**

この記事では、Aspose.Slides for C++ を使用してプレゼンテーションのコメントを管理する方法を説明します。主なコメント関連型を紹介し、スライドへのコメント追加、既存コメントへのアクセス、返信やモダンコメントの操作、プレゼンテーションからのコメント削除の方法を実演します。

例では、PowerPoint の一般的なレビューや共同作業シナリオ（コメントを作成者に割り当てる、コメントテキストやメタデータを読む、返信チェーンを構築する、選択したコメントまたはすべてのコメントを削除する）を取り上げています。

PowerPoint では、コメントはスライド上の注釈として表示されます。コメントを選択すると、そのテキストと関連するディスカッションが表示されます。

プレゼンテーションを開くときにコメントを表示または非表示にする場合は、コメント自体を変更せずに行う方法については、[プレゼンテーションを開くときにコメントを表示または非表示にする](/slides/ja/cpp/presentation-view-properties/) を参照してください。

## **なぜプレゼンテーションにコメントを追加するのか？**

プレゼンテーションのレビュー時に、フィードバックを提供し同僚と協働するためにコメントを使用できます。

Aspose.Slides for C++ は、コメント操作のために以下の API を提供します:

* The [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスは、プレゼンテーションのコメント作成者へのアクセスを提供します。
* The [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) インターフェイスは、個々の作成者に関連付けられたコメントを表します。
* The [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) インターフェイスは、コメントの作成者、作成時刻、位置、テキストなどの情報を提供します。
* The [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) クラスは、作成者の名前、イニシャル、関連するコメントなどの情報を提供します。

## **スライドコメントの追加**

この例では、2 つのスライドを作成し、[AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) を使用してコメント作成者を登録します。[AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) を使用して各スライドに 1 つずつコメントを配置し、その後 [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) で最初のスライドのその作成者のコメントを取得します。コンソールは最初のコメントのテキストを 2 回表示し、スライドと作成者の両方からアクセスできることを示します。保存されたプレゼンテーションには両方のコメントが含まれます。

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

## **コメント作成者の検索または作成**

自動レビューが同じプレゼンテーションを繰り返し処理する場合、作成者を追加する前に [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) が返すコレクションを検索します。[FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) は名前とイニシャルの両方を一致させ、該当する作成者の配列を返します。一致がなければ空配列が返ります。対照的に、[FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) はイニシャルに関係なく名前だけで検索します。既にコレクションに存在する名前とイニシャルで [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) を呼び出すと例外がスローされます。

この例では、少なくとも 1 枚のスライドが含まれるプレゼンテーション ファイルが必要です。2 回のパスそれぞれで、最初に一致した作成者を再利用するか、結果が空の場合にのみ新規作成します。複数一致する場合は最初の配列要素を選択し、他の作成者を統合または削除しません。その後、選択した作成者に対して [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) を呼び出し、プレゼンテーションを保存します。2 回目のパスは、1 回目の出力を開いて同じ操作を繰り返します。

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

2 回目のパスは別の作成者を追加せず、既存のコメントを削除せずに別のコメントを追加します。最終ファイル `review_pass_2.pptx` には、元のコメントに加えて新しいコメントが両方含まれます。作成者を再利用してもコメントは重複排除されません。同じコメントを繰り返し追加しないようにするには、追加前に別途重複検出ロジックを実装してください。

## **スライドコメントへのアクセス**

この例では、既存のプレゼンテーションを開き、[get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) が返すコレクションを読み取ります。各作成者について、[get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) が返すコレクションを反復し、スライド番号、コメントテキスト、作成者名、作成時刻をコンソールに出力します。入力プレゼンテーションにコメントが含まれていないとコンソール出力は生成されません。

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

親コメントは返信階層の最上位にある元のコメントです。[get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) および [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) メソッド（[IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) インターフェイス）は、コメントの親を取得または設定できます。

この例では 2 人の作成者からコメントを作成し、[set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) を使用して返信を構築します。別の返信への返信も含めます。`nullptr` を [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) に渡すと全作成者のコメントが取得され、コンソールは返信階層の深さに応じて各エントリをインデント表示します。例は完全なディスカッションを保存し、最初のルートコメントに対して [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) を呼び出してそのコメントと返信を削除した上で、2 番目のプレゼンテーションを保存します。

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
* [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) インターフェイスの [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) メソッドでコメントを削除すると、そのコメントへのすべての返信も同時に削除されます。
* [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) メソッドで循環参照が作成されると、[PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/) がスローされます。
{{% /alert %}}

## **モダンコメントの追加**

モダンコメントはスライド自体、特定のシェイプ、または AutoShape 内のテキスト範囲に関連付けることができます。[ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) メソッドは、スライドとコメントマーカー座標に加えて [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 引数も受け取ります。

`nullptr` をシェイプ引数に渡すと、コメントはスライドレベルのコメントになります。マーカーは指定された座標で配置されますが、特定のシェイプには紐付いていないため、[IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) は `nullptr` を返します。[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) を指定すると、コメントはそのシェイプに固定されます。座標は依然としてスライド上のマーカー位置を定義し、シェイプの紐付けは [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) で取得できます。

### **シェイプにモダンコメントを固定する**

この例は [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) を 2 回呼び出します。1 回目は `nullptr` シェイプでスライドレベルコメント、2 回目は矩形をアンカーとして使用します。[get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) を呼び出すと、スライドレベルコメントは null チェックで `True`、アンカーされたコメントは `Revenue title` を出力します。両方のコメントはプレゼンテーションに保存されます。

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

[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) を実装しているスライドオブジェクトはすべてシェイプアンカーとして使用できます。代表的な例として [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/)、およびチャートなどの [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) インスタンスがあります。

この例は [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) を使用して、AutoShape、画像フレーム、グループ、コネクタ、チャートの 5 種類のシェイプそれぞれにコメントを関連付けます。画像は埋め込み画像データを使用するため、外部画像は不要です。各コメントは独自のマーカー位置を持ち、保存されたプレゼンテーションは 5 つのシェイプ関連付けをすべて保持します。

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

### **テキストにコメントを固定しステータスを設定する**

[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) に関連付けられたモダンコメントについては、[IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) と [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) がシェイプのテキストフレーム内で選択されたテキストの開始位置を制御します。同様に、[IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) と [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) が選択範囲の長さを制御します。これらのメソッドを組み合わせて、コメントを AutoShape 内の特定のテキスト範囲に関連付けます。

[IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) と [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) メソッドは、[ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) 列挙体の値を使用します。

- `NotDefined` — 特定のモダンコメントステータスが定義されていません。
- `Active` — コメントはアクティブです。
- `Resolved` — コメントは解決済みです。
- `Closed` — コメントはクローズされています。

この例は矩形のテキスト「quarterly revenue」にモダンコメントを固定します。テキストからゼロベースの選択開始位置を計算し、[set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) に渡し、[set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) で選択文字数を設定します。その後、[set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) に `Resolved` を指定して保存し、プレゼンテーションを再度開きます。4 つのコンソールチェックはすべて `True` を出力し、シェイプアンカー、テキスト範囲、ステータスが保持されていることを確認します。

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

### **既存のモダンコメントを検査する**

この例はモダンコメントを含む既存のプレゼンテーションを必要とし、コメントのテキスト、ステータス、アンカーの詳細を出力します。検査するには、まずコメントが [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/) を実装しているか確認し、次に [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/)、[IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/)、[IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/)、[IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) を調べます。`nullptr` シェイプはスライドレベルのコメントを示します。[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) がアンカーの場合、テキスト選択メソッドでシェイプのテキストフレーム内の対象範囲が特定できます。

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

Aspose.Slides for C++ を使用すると、プレゼンテーション全体からすべてのコメントと作成者を削除したり、残りのコメントは保持したまま選択したコメントだけを削除したりできます。以下の例は両方のアプローチを示し、更新されたプレゼンテーションを保存します。

### **すべてのコメントとコメント作成者を削除する**

この例は既存のプレゼンテーションを開き、各作成者に対して [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) を呼び出し、次に [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) で作成者自体を削除します。保存されたプレゼンテーションにはコメントもコメント作成者も含まれません。コメントを含むプレゼンテーションで実行すると削除が確認できます。

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

### **特定のコメントを削除する**

この例は 1 枚のスライドに 2 つのコメントを作成し、[GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) を使用して各作成者のコメントを取得します。テキストが「comment 1」と等しいコメントを収集し、[ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/) を呼び出して削除します。コレクションの選択中に変更が起こらないようにしています。保存されたプレゼンテーションには「comment 2」だけが残ります。

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

## **FAQ**

**Aspose.Slides はモダンコメントに解決済みステータスをサポートしていますか？**

はい。[IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) と [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) は [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) の値を使用し、`Resolved` も含まれます。ステータスはプレゼンテーションに保存され、ファイルを再度開いたときに再取得できます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？また、ネストの制限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) を参照でき、返信チェーンを実現します。API には特定のネスト深さ上限は定義されていません。

**コメントマーカーの位置はスライド上のどの座標系で定義されていますか？**

マーカー位置はスライド座標系の浮動小数点座標で定義され、スライド上の任意の場所に正確に配置できます。