---
title: Pythonでプレゼンテーションコメントを管理
linktitle: プレゼンテーション コメント
type: docs
weight: 100
url: /ja/python-net/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPointコメント
- プレゼンテーションコメント
- スライドコメント
- コメント追加
- コメント取得
- コメント編集
- コメント返信
- コメント削除
- コメント除去
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してプレゼンテーションコメントをマスター: PowerPoint ファイルのコメントを迅速かつ簡単に追加、読み取り、編集、削除できます。"
---

PowerPoint では、コメントはスライド上のメモまたは注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とやり取りしたりするためにコメントを使用したい場合があります。

To allow you to use comments in PowerPoint presentations, Aspose.Slides for Python via .NET provides

* The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスは、著者のコレクション（[CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/) プロパティ）を含みます。著者はスライドにコメントを追加します。 
* The  [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) インターフェイスは、個々の著者向けのコメントコレクションを含みます。 
* The [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) クラスは、著者とそのコメントに関する情報（コメントを追加したユーザー、追加された日時、コメントの位置など）を保持します。 
* The [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) クラスは、個々の著者に関する情報（著者名、イニシャル、著者名に関連付けられたコメントなど）を保持します。 

## **スライドにコメントを追加**

この Python コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示します：
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Presentation クラスのインスタンスを作成
with slides.Presentation() as presentation:
    # 空のスライドを追加
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # 作者を追加
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # コメントの位置を設定
    point = draw.PointF(0.2, 0.2)

    # スライド 1 の作者にスライドコメントを追加
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # スライド 2 の作者にスライドコメントを追加
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # ISlide 1 にアクセス
    slide = presentation.slides[0]

    # null を引数として渡すと、すべての作者のコメントが選択したスライドに取得される
    comments = slide.get_slide_comments(author)

    # スライド 1 のインデックス 0 のコメントにアクセス
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # インデックス 0 の作者のコメントコレクションを選択
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```




## **スライドのコメントにアクセス**

この Python コードは、PowerPoint プレゼンテーションのスライド上の既存のコメントにアクセスする方法を示します：
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```



## **コメントに返信**

親コメントは、コメントや返信の階層における最上位または元となるコメントです。[IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) インターフェイスの `parent_comment` プロパティを使用して、親コメントを設定または取得できます。 

この Python コードは、コメントを追加し、それらへの返信を取得する方法を示します：
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

    # comment1 に別の返信を追加
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

* `Remove` メソッド（[IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) インターフェイス）を使用してコメントを削除すると、そのコメントへの返信も同時に削除されます。 
* `parent_comment` の設定が循環参照になると、`PptxEditException` がスローされます。

{{% /alert %}}

## **モダンコメントを追加**

2021 年に Microsoft は PowerPoint に *モダンコメント* を導入しました。モダンコメント機能は PowerPoint におけるコラボレーションを大幅に向上させます。モダンコメントを利用することで、ユーザーはコメントを解決したり、オブジェクトやテキストにコメントを固定したり、以前よりもはるかに簡単にやり取りできるようになります。 

We implemented support for modern comments by adding the [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) class. The `add_modern_comment` and `insert_modern_comment` methods were added to the [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) class. 

この Python コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示します：
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **コメントを削除**

### **すべてのコメントと著者を削除**

この Python コードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示します：
```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # プレゼンテーションのすべてのコメントを削除
    for author in presentation.comment_authors:
        author.comments.clear()

    # すべての作者を削除
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


### **特定のコメントを削除**

この Python コードは、スライド上の特定のコメントを削除する方法を示します：
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
    
    # "comment 1" というテキストを含むすべてのコメントを削除
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **よくある質問**

**Aspose.Slides はモダンコメントに「解決済み」などのステータスをサポートしていますか？**

はい。 [Modern comments](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) は [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) プロパティを公開しています。コメントの状態（例: 解決済みとしてマーク）を取得および設定でき、この状態はファイルに保存され、PowerPoint に認識されます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？また、入れ子の上限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/) を参照できるため、任意の長さの返信チェーンを構築できます。API では特定の入れ子深さの上限は宣言されていません。

**コメントマーカーの位置はスライドのどの座標系で定義されていますか？**

位置はスライドの座標系における浮動小数点数のポイントとして保存されます。このため、コメントマーカーを必要な場所に正確に配置できます。