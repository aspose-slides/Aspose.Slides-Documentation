---
title: プレゼンテーションのコメント
type: docs
weight: 100
url: /ja/cpp/presentation-comments/
keywords: "コメント, PowerPoint コメント, PowerPoint プレゼンテーション, C++, Aspose.Slides for C++"
description: "C++ で PowerPoint プレゼンテーションにコメントと返信を追加する"
---

PowerPoint では、コメントはスライド上のノートや注釈として表示されます。コメントがクリックされると、その内容やメッセージが表示されます。

### **プレゼンテーションにコメントを追加する理由は？**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とコミュニケーションを取るためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for C++ は以下を提供します。

* [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラス。これは著者のコレクション（[get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) メソッドから取得）を含みます。著者はスライドにコメントを追加します。
* [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) インターフェース。これは個々の著者のコメントのコレクションを含みます。
* [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) クラス。これは著者とそのコメントに関する情報を含みます：誰がコメントを追加したか、コメントが追加された時間、コメントの位置など。
* [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) クラス。これは個々の著者に関する情報を含みます：著者の名前、イニシャル、著者の名前に関連付けられたコメントなど。

## **スライドコメントを追加する**
この C++ コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています：

```cpp
// Presentation クラスをインスタンス化
auto presentation = System::MakeObject<Presentation>();
// 空のスライドを追加
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// 著者を追加
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// コメントの位置を設定
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// ISlide 1 にアクセス
auto slide1 = presentation->get_Slides()->idx_get(0);
// ISlide 2 にアクセス
auto slide2 = presentation->get_Slides()->idx_get(1);

// スライド 1 の著者のためにスライドコメントを追加
author->get_Comments()->AddComment(u"こんにちは Jawad, これはスライドコメントです", slide1, point, DateTime::get_Now());

// スライド 2 の著者のためにスライドコメントを追加
author->get_Comments()->AddComment(u"こんにちは Jawad, これは2つ目のスライドコメントです", slide2, point, DateTime::get_Now());

// null が引数として渡されると、すべての著者のコメントが選択したスライドに表示されます
auto comments = slide1->GetSlideComments(author);

// スライド 1 のインデックス 0 のコメントにアクセス
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // インデックス 0 の著者のコメントコレクションを選択
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **スライドコメントにアクセスする**
この C++ コードは、PowerPoint プレゼンテーションのスライドにある既存のコメントにアクセスする方法を示しています：

```cpp
// Presentation クラスをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" にはコメントがあります: " + comment->get_Text()
                        + u" 著者: " + comment->get_Author()->get_Name()
                        + u" 投稿日時: " + comment->get_CreatedTime() + u"\n");
    }
}
```

## **返信コメント**
親コメントは、コメントまたは返信の階層における最上位または元のコメントです。[ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) プロパティ（[IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) インターフェースから）を使用することで、親コメントを設定または取得できます。

この C++ コードは、コメントを追加し、それへの返信を取得する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>();

// ISlide 1 にアクセス
auto slide1 = pres->get_Slides()->idx_get(0);

// コメントを追加
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"コメント1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// コメント1への返信を追加
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"コメント1への返信1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// コメント1への別の返信を追加
auto reply2 = author2->get_Comments()->AddComment(u"コメント1への返信2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// 既存の返信への返信を追加
auto subReply = author1->get_Comments()->AddComment(u"返信2へのサブ返信3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"コメント2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"コメント3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"コメント3への返信4", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
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

// コメント1とそのすべての返信を削除
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="注意" %}} 

* [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) メソッド（[IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) インターフェースから）を使用してコメントを削除すると、そのコメントへの返信も削除されます。 
* [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) 設定が循環参照を引き起こす場合、[PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) がスローされます。

{{% /alert %}}

## **モダンコメントを追加する**

2021年、Microsoft は PowerPoint に*モダンコメント*を導入しました。モダンコメント機能は、PowerPoint におけるコラボレーションを大幅に改善します。モダンコメントを通じて、PowerPoint ユーザーはコメントを解決し、コメントをオブジェクトやテキストに固定し、以前よりもはるかに簡単にインタラクションを行うことができます。

[Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment) クラスを追加することによりモダンコメントのサポートを実装しました。[AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) および [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) メソッドが [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection) クラスに追加されました。

この C++ コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示しています：

```cpp
auto pres = System::MakeObject<Presentation>();
// ISlide 1 にアクセス
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"ある著者", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"これはモダンコメントです", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **コメントを削除する**

### **すべてのコメントと著者を削除する**

この C++ コードは、プレゼンテーションからすべてのコメントと著者を削除する方法を示しています：

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
        
// すべての著者を削除
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);

```

### **特定のコメントを削除する**

この C++ コードは、スライド上の特定のコメントを削除する方法を示しています：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// コメントを追加...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"著者", u"A");
author->get_Comments()->AddComment(u"コメント1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"コメント2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// "コメント1" テキストを含むすべてのコメントを削除
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"コメント1")
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