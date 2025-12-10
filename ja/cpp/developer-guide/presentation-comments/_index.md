---
title: C++でプレゼンテーションコメントを管理する
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/cpp/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPoint コメント
- プレゼンテーションコメント
- スライドコメント
- コメントの追加
- コメントへのアクセス
- コメントの編集
- コメントへの返信
- コメントの削除
- コメントの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してプレゼンテーションコメントをマスター：PowerPoint ファイルのコメントを高速かつ簡単に追加、読み取り、編集、削除できます。"
---

PowerPoint では、コメントはスライド上のメモまたは注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

### **プレゼンテーションにコメントを追加する理由は？**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とコミュニケーションを取るためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for C++ は以下を提供します。

* The [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスは、作者のコレクション（[get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) メソッドから取得）を含みます。作者はスライドにコメントを追加します。 
* The [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) インターフェイスは、個々の作者のコメントコレクションを保持します。 
* The [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) クラスは、作者とそのコメントに関する情報（コメントを追加した人物、追加された時間、コメントの位置など）を含みます。 
* The [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) クラスは、個々の作者に関する情報（作者名、イニシャル、作者名に関連付けられたコメントなど）を含みます。 

## **スライドコメントの追加**
この C++ コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示します。  
```cpp
// Presentation クラスのインスタンス化
auto presentation = System::MakeObject<Presentation>();
// 空のスライドを追加
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// 作者を追加
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// コメントの位置を設定
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// ISlide 1 にアクセス
auto slide1 = presentation->get_Slides()->idx_get(0);
// ISlide 2 にアクセス
auto slide2 = presentation->get_Slides()->idx_get(1);

// スライド 1 の作者向けスライドコメントを追加
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// スライド 2 の作者向けスライドコメントを追加
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// 引数に null を渡すと、すべての作者のコメントが選択されたスライドに取得されます
auto comments = slide1->GetSlideComments(author);

// スライド 1 のインデックス 0 のコメントにアクセス
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // インデックス 0 の作者のコメントコレクションを選択
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```


## **スライドコメントへのアクセス**
この C++ コードは、PowerPoint プレゼンテーションのスライド上の既存のコメントにアクセスする方法を示します。  
```cpp
// Presentation クラスのインスタンス化
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


## **コメントへの返信**

親コメントは、コメントや返信の階層における最上位または元のコメントです。[ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) プロパティ（[IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) インターフェイスの）を使用して、親コメントを設定または取得できます。  

この C++ コードは、コメントを追加し、それへの返信を取得する方法を示します。  
```cpp
auto pres = System::MakeObject<Presentation>();

// ISlide 1 にアクセス
auto slide1 = pres->get_Slides()->idx_get(0);

// コメントを追加
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// comment1 に返信を追加
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// comment1 に別の返信を追加
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// 既存の返信に対して返信を追加
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// コンソールにコメント階層を表示
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

// comment1 とそれへのすべての返信を削除
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```


{{% alert color="warning" title="Attention" %}} 
* [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) メソッド（[IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) インターフェイスの）を使用してコメントを削除すると、そのコメントへの返信も削除されます。 
* [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) 設定が循環参照になると、[PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) がスローされます。  
{{% /alert %}}

## **モダンコメントの追加**

2021 年に、Microsoft は PowerPoint に *モダンコメント* を導入しました。モダンコメント機能は、PowerPoint におけるコラボレーションを大幅に向上させます。モダンコメントを使用すると、PowerPoint ユーザーはコメントを解決したり、オブジェクトやテキストにコメントを固定したり、以前よりもはるかに簡単にやり取りできるようになります。  

[Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment) クラスを追加することでモダンコメントのサポートを実装しました。[AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) および [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) メソッドが [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection) クラスに追加されました。  

この C++ コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示します。  
```cpp
auto pres = System::MakeObject<Presentation>();
// ISlide 1 にアクセス
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **コメントの削除**

### **すべてのコメントと作者を削除**

この C++ コードは、プレゼンテーション内のすべてのコメントと作者を削除する方法を示します。  
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// プレゼンテーションからすべてのコメントを削除
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// すべての作者を削除
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```


### **特定のコメントを削除**

この C++ コードは、スライド上の特定のコメントを削除する方法を示します。  
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// コメントを追加...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// "comment 1" テキストを含むすべてのコメントを削除
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


## **FAQ**

**Aspose.Slides はモダンコメントに対して「解決済み」などのステータスをサポートしていますか？**  
はい。[Modern comments](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/) は [get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/get_status/) と [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/set_status/) メソッドを提供します。これにより、[comment’s state](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/)（例: 解決済みとしてマーク） を取得および設定でき、この状態はファイルに保存され PowerPoint で認識されます。

**スレッド形式のディスカッション（返信チェーン）はサポートされていますか？また、ネストの上限はありますか？**  
はい。各コメントは [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/comment/set_parentcomment/) を参照できるため、任意の深さの返信チェーンが可能です。API には特定のネスト深度上限は定義されていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**  
位置はスライドの座標系で浮動小数点数のポイントとして保存されます。これにより、必要な場所に正確にコメントマーカーを配置できます。