---
title: プレゼンテーションのコメント
type: docs
weight: 100
url: /python-net/presentation-comments/
keywords: "コメント、PowerPoint コメント、PowerPoint プレゼンテーション、Python、Aspose.Slides for Python via .NET"
description: "Python で PowerPoint プレゼンテーションにコメントと返信を追加"
---

PowerPointでは、コメントはスライド上のノートまたは注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。 

### **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、フィードバックを提供したり、同僚とコミュニケーションを取るためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるようにするために、Aspose.Slides for Python via .NET は以下を提供します。

* [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラス。これは、スライドにコメントを追加する著者のコレクションを含んでいます（[CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/) プロパティから）。 
* [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) インターフェース。これは、個々の著者のコメントのコレクションを含んでいます。 
* [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) クラス。これは、著者とそのコメントに関する情報を含んでいます：誰がコメントを追加したか、コメントが追加された時間、コメントの位置など。 
* [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) クラス。これは、個々の著者に関する情報を含んでいます：著者の名前、イニシャル、著者名に関連付けられたコメントなど。 

## **スライドコメントを追加**
この Python コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Presentation クラスのインスタンスを作成
with slides.Presentation() as presentation:
    # 空のスライドを追加
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # 著者を追加
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # コメントの位置を設定
    point = draw.PointF(0.2, 0.2)

    # スライド 1 の著者のためにスライドコメントを追加
    author.comments.add_comment("こんにちは、Jawad。これはスライドコメントです", presentation.slides[0], point, datetime.date.today())

    # スライド 2 の著者のためにスライドコメントを追加
    author.comments.add_comment("こんにちは、Jawad。これは2つ目のスライドコメントです", presentation.slides[1], point, datetime.date.today())

    # ISlide 1 にアクセス
    slide = presentation.slides[0]

    # 引数に null を渡すと、すべての著者からのコメントが選択したスライドに表示される
    comments = slide.get_slide_comments(author)

    # スライド 1 のインデックス 0 のコメントにアクセス
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # インデックス 0 の著者のコメントコレクションを選択
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **スライドコメントにアクセス**
この Python コードは、PowerPoint プレゼンテーションのスライド上の既存のコメントにアクセスする方法を示しています：

```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " のコメント: " + comment.text + 
            " 著者: " + comment.author.name + 
            " 投稿日時 :" + str(comment.created_time) + "\n")
```


## **返信コメント**
親コメントは、コメントまたは返信の階層における最上位または元のコメントです。 `parent_comment` プロパティ（[IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) インターフェースから）を使用して、親コメントを設定または取得することができます。 

この Python コードは、コメントを追加し、それに対する返信を取得する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # コメントを追加
    author1 = pres.comment_authors.add_author("著者_1", "A.A.")
    comment1 = author1.comments.add_comment("コメント1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # コメント1への返信を追加
    author2 = pres.comment_authors.add_author("著者_2", "B.B.")
    reply1 = author2.comments.add_comment("コメント1への返信1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # コメント1への別の返信を追加
    reply2 = author2.comments.add_comment("コメント1への返信2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # 既存の返信への返信を追加
    subReply = author1.comments.add_comment("返信2へのサブ返信3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("コメント2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("コメント3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("コメント3への返信4", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # コメントの階層をコンソールに表示
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # comment1 とそのすべての返信を削除
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="注意" %}} 

* [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) インターフェースから `Remove` メソッドを使用してコメントを削除すると、そのコメントへの返信も削除されます。 
* `parent_comment` 設定が循環参照を引き起こす場合、`PptxEditException` がスローされます。

{{% /alert %}}

## **モダンコメントを追加**

2021年に、Microsoft は PowerPoint に*モダンコメント*を導入しました。モダンコメント機能は、PowerPoint でのコラボレーションを大幅に改善します。モダンコメントを通じて、PowerPointユーザーはコメントを解決し、コメントをオブジェクトやテキストに固定し、以前よりもはるかに簡単に相互作用することができます。 

私たちは、[ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) クラスを追加することでモダンコメントのサポートを実装しました。 `add_modern_comment` および `insert_modern_comment` メソッドが [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) クラスに追加されました。 

この Python コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("いくつかの著者", "SA")
    modernComment = newAuthor.comments.add_modern_comment("これはモダンコメントです", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **コメントを削除**

### **すべてのコメントと著者を削除**

この Python コードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # プレゼンテーションからすべてのコメントを削除
    for author in presentation.comment_authors:
        author.comments.clear()

    # すべての著者を削除
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **特定のコメントを削除**

この Python コードは、スライド上の特定のコメントを削除する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # コメントを追加...
    author = presentation.comment_authors.add_author("著者", "A")
    author.comments.add_comment("コメント1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("コメント2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # "コメント1" テキストを含むすべてのコメントを削除
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "コメント1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```