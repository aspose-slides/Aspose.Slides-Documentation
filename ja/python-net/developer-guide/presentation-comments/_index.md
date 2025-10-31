---
title: Pythonでプレゼンテーションコメントを管理する
linktitle: プレゼンテーションコメント
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
- コメント削除
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NETを使用してプレゼンテーションコメントをマスターしましょう：PowerPointファイル内のコメントを高速かつ簡単に追加、読み取り、編集、削除できます。"
---

PowerPointでは、コメントはスライド上のノートや注釈として表示されます。コメントをクリックすると、その内容やメッセージが表示されます。

## **なぜプレゼンテーションにコメントを追加するのか？**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とやり取りしたりするためにコメントを使用したい場合があります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for Python via .NET は次を提供します。

* Presentation クラスは、著者のコレクション（CommentAuthorCollection プロパティから取得）を含みます。著者はスライドにコメントを追加します。  
* ICommentCollection インターフェイスは、個々の著者のコメントコレクションを含みます。  
* IComment クラスは、コメントを追加した著者、コメントの追加時刻、コメントの位置など、著者とコメントに関する情報を含みます。  
* CommentAuthor クラスは、個々の著者に関する情報（名前、イニシャル、著者名に紐付くコメントなど）を含みます。  

## **スライドコメントの追加**
以下の Python コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示しています。

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

    # スライド1の著者用スライドコメントを追加
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # スライド2の著者用スライドコメントを追加
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # ISlide 1 にアクセス
    slide = presentation.slides[0]

    # 引数に null を渡すと、すべての著者のコメントが選択されたスライドに取得されます
    comments = slide.get_slide_comments(author)

    # スライド1のインデックス0のコメントにアクセス
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # インデックス0の著者のコメントコレクションを選択
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **スライドコメントへのアクセス**
以下の Python コードは、PowerPoint プレゼンテーションのスライド上に既存のコメントへアクセスする方法を示しています。

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

## **コメントへの返信**
親コメントは、コメントや返信の階層における最上位または元のコメントです。`parent_comment` プロパティ（IComment インターフェイス）を使用して、親コメントの取得または設定ができます。

以下の Python コードは、コメントを追加しそれへの返信を取得する方法を示します。

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

    # comment1 とそれに対するすべての返信を削除
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="注意" %}} 

* `Remove` メソッド（IComment インターフェイス）を使用してコメントを削除すると、コメントへの返信もすべて削除されます。  
* `parent_comment` 設定により循環参照が発生した場合、`PptxEditException` がスローされます。

{{% /alert %}}

## **モダンコメントの追加**

2021年、Microsoft は PowerPoint に *モダンコメント* を導入しました。モダンコメント機能は、PowerPoint でのコラボレーションを大幅に向上させます。モダンコメントにより、PowerPoint ユーザーはコメントを解決したり、オブジェクトやテキストにコメントを固定したり、以前よりはるかに簡単にやり取りできるようになります。

私たちは ModernComment クラスを追加し、モダンコメントのサポートを実装しました。`add_modern_comment` と `insert_modern_comment` メソッドを CommentCollection クラスに追加しました。

以下の Python コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示しています。

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

### **すべてのコメントと著者を削除**

以下の Python コードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示しています。

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

以下の Python コードは、スライド上の特定のコメントを削除する方法を示しています。

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

**Aspose.Slides はモダンコメントに対して「解決済み」のようなステータスをサポートしていますか？**

はい。Modern comments は status プロパティを公開しています。コメントの状態（例：解決済みとしてマーク）を読み書きでき、この状態はファイルに保存され、PowerPoint でも認識されます。

**スレッド形式のディスカッション（返信チェーン）はサポートされていますか？また、ネストの上限はありますか？**

はい。各コメントは parent_comment プロパティで親コメントを参照できるため、任意の深さの返信チェーンが可能です。API では特定のネスト深さ上限は定められていません。

**スライド上のコメントマーカーの位置はどの座標系で定義されていますか？**

位置はスライドの座標系での浮動小数点ポイントとして保存されます。これにより、コメントマーカーを必要な正確な位置に配置できます。