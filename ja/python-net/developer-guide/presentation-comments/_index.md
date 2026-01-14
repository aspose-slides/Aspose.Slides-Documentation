---
title: Pythonでプレゼンテーションコメントを管理する
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/python-net/presentation-comments/
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
- コメントを削除
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してプレゼンテーションのコメントをマスターし、PowerPoint ファイルのコメントを素早く簡単に追加、読み取り、編集、削除できます。"
---

PowerPointでは、コメントはスライド上のノートや注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とコミュニケーションを取るためにコメントを使用したい場合があります。

PowerPointプレゼンテーションでコメントを使用できるように、Aspose.Slides for Python via .NETは以下を提供します

* The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスは、著者のコレクション（[CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/) プロパティから）を含みます。著者はスライドにコメントを追加します。 
* The [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) クラスは、個々の著者のコメントコレクションを含みます。 
* The [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) クラスは、著者とそのコメントに関する情報（コメントを追加した人、追加された時間、コメントの位置など）を含みます。 
* The [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) クラスは、個々の著者に関する情報（著者の名前、イニシャル、著者名に関連付けられたコメントなど）を含みます。 

## **スライドコメントの追加**
このPythonコードは、PowerPointプレゼンテーションのスライドにコメントを追加する方法を示します：
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Presentation クラスのインスタンス化
with slides.Presentation() as presentation:
    # 空のスライドを追加
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # 作者を追加
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # コメントの位置を設定
    point = draw.PointF(0.2, 0.2)

    # スライド 1 の作者向けスライドコメントを追加
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # スライド 2 の作者向けスライドコメントを追加
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # ISlide 1 にアクセス
    slide = presentation.slides[0]

    # 引数に null を渡すと、すべての作者のコメントが選択されたスライドに取得される
    comments = slide.get_slide_comments(author)

    # スライド 1 のインデックス 0 のコメントにアクセス
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # インデックス 0 の作者のコメントコレクションを選択
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```


## **スライドコメントへのアクセス**
このPythonコードは、PowerPointプレゼンテーションのスライド上にある既存のコメントにアクセスする方法を示します：
```python
import aspose.slides as slides

# Presentation クラスのインスタンス化
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **コメントへの返信**
親コメントは、コメントや返信の階層における最上位または元のコメントです。[Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) クラスの `parent_comment` プロパティを使用すると、親コメントを設定または取得できます。

このPythonコードは、コメントを追加し、それらへの返信を取得する方法を示します：
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # コメントを追加
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # comment1 に対する返信を追加
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # comment1 に対する別の返信を追加
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # 既存の返信に対する返信を追加
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # コンソールにコメント階層を表示
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

    # comment1 とそれへのすべての返信を削除
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" title="Attention" %}} 
* `remove` メソッド（[Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) クラス）を使用してコメントを削除すると、そのコメントへの返信も削除されます。 
* `parent_comment` の設定が循環参照になると、`PptxEditException` がスローされます。 
{{% /alert %}}

## **モダンコメントの追加**

2021年に、MicrosoftはPowerPointに*モダンコメント*を導入しました。モダンコメント機能はPowerPointのコラボレーションを大幅に向上させます。モダンコメントにより、PowerPointユーザーはコメントを解決したり、オブジェクトやテキストにコメントを固定したり、以前よりもはるかに簡単にやり取りできるようになります。

私たちは [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) クラスを追加することでモダンコメントのサポートを実装しました。また、`add_modern_comment` および `insert_modern_comment` メソッドを [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) クラスに追加しました。

このPythonコードは、PowerPointプレゼンテーションのスライドにモダンコメントを追加する方法を示します：
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **コメントの削除**

### **すべてのコメントと著者の削除**

このPythonコードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示します：
```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # プレゼンテーションからすべてのコメントを削除します
    for author in presentation.comment_authors:
        author.comments.clear()

    # すべての作者を削除します
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


### **特定のコメントの削除**

このPythonコードは、スライド上の特定のコメントを削除する方法を示します：
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # コメントを追加...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # "comment 1" テキストを含むすべてのコメントを削除
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Aspose.Slidesはモダンコメントに対して「解決済み」などのステータスをサポートしていますか？**

はい。[Modern comments](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) は [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) プロパティを提供します。このプロパティでコメントの状態（例: 解決済みとしてマーク）を取得・設定でき、状態はファイルに保存されPowerPointで認識されます。

**スレッド形式のディスカッション（返信チェーン）はサポートされていますか？ネストの上限はありますか？**

はい。各コメントはその [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/) を参照できるため、任意の深さの返信チェーンを構成できます。API には具体的なネスト深度の上限は明示されていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**

位置はスライドの座標系での浮動小数点数のポイントとして保存されます。これにより、コメントマーカーを必要な場所に正確に配置できます。