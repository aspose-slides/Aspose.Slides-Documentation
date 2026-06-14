---
title: 在 Python 中管理簡報註解
linktitle: 簡報註解
type: docs
weight: 100
url: /zh-hant/python-net/presentation-comments/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 精通簡報註解：快速輕鬆地在 PowerPoint 檔案中新增、閱讀、編輯與刪除註解。"
---
## **概述**

本文說明如何在 Aspose.Slides 中管理簡報註解。它會展示與註解相關的主要類型，並示範如何在投影片中加入註解、存取現有註解、處理回覆、使用現代註解以及從簡報中移除註解。

範例聚焦於 PowerPoint 中常見的審閱與協作情境，例如為作者指派註解、讀取註解內容與中繼資料、建立回覆鏈，以及清除全部註解或刪除特定註解。

在 PowerPoint 中，註解會顯示為投影片上的備註或標註。點擊註解時，會顯示其內容或訊息。

## **為何要在簡報中加入註解？**

在審閱簡報時，您可能希望使用註解提供回饋或與同事溝通。

為了讓您在 PowerPoint 簡報中使用註解，Aspose.Slides for Python via .NET 提供

* [Presentation]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/）類別，包含作者集合（來自 [CommentAuthorCollection]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/commentauthorcollection/）屬性）。作者會將註解加入投影片。
* [CommentCollection]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/commentcollection/）類別，包含個別作者的註解集合。
* [Comment]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/）類別，包含關於作者與其註解的資訊：誰加入了註解、加入時間、註解位置等。
* [CommentAuthor]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/commentauthor/）類別，包含單一作者的資訊：作者名稱、縮寫、與該作者相關的註解等。

## **加入投影片註解**
以下 Python 程式碼示範如何在 PowerPoint 簡報的投影片中加入註解：

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# 實例化 Presentation 類別
with slides.Presentation() as presentation:
    # 新增空白投影片
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # 新增作者
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # 設定註解的位置
    point = draw.PointF(0.2, 0.2)

    # 為作者在投影片 1 上新增投影片註解
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # 為作者在投影片 2 上新增投影片註解
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # 存取 ISlide 1
    slide = presentation.slides[0]

    # 當參數傳入 null 時，會將所有作者的註解帶入選取的投影片
    comments = slide.get_slide_comments(author)

    # 取得投影片 1 索引 0 的註解
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # 選取作者索引 0 的註解集合
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **存取投影片註解**
以下 Python 程式碼示範如何存取 PowerPoint 簡報投影片上已存在的註解：

```python
import aspose.slides as slides

# 實例化 Presentation 類別
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **回覆註解**
父註解是階層中最高層或原始的註解。使用 [Comment]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/）類別的 `parent_comment` 屬性，您可以設定或取得父註解。

以下 Python 程式碼示範如何加入註解並取得其回覆：

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # 新增註解
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # 為 comment1 新增回覆
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # 為 comment1 再新增一次回覆
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # 為既有回覆新增回覆
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # 在主控台顯示註解階層
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

    # 移除 comment1 以及其所有回覆
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="注意" %}} 

* 當使用 [Comment]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/）類別的 `remove` 方法刪除註解時，該註解的回覆也會被一併刪除。 
* 如果 `parent_comment` 設定導致循環參照，會拋出 `PptxEditException`。

{{% /alert %}}

## **加入現代註解**

2021 年，Microsoft 在 PowerPoint 中引入 *現代註解*。現代註解功能大幅提升了 PowerPoint 的協作體驗。透過現代註解，使用者可以解決註解、將註解錨定於物件或文字，並更輕鬆地進行互動。

我們透過加入 [ModernComment]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/）類別來支援現代註解，並在 [CommentCollection]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/commentcollection/）類別中新增 `add_modern_comment` 與 `insert_modern_comment` 方法。

以下 Python 程式碼示範如何在 PowerPoint 簡報的投影片中加入現代註解：

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **移除註解**

### **刪除全部註解與作者**

以下 Python 程式碼示範如何移除簡報中所有的註解與作者：

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # 刪除簡報中所有註解
    for author in presentation.comment_authors:
        author.comments.clear()

    # 刪除所有作者
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **刪除特定註解**

以下 Python 程式碼示範如何刪除投影片上特定的註解：

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # 新增註解...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # 移除所有包含「comment 1」文字的註解
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**Aspose.Slides 是否支援現代註解的「已解決」狀態？**

是的。[Modern comments]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/）提供 `status` 屬性；您可以讀取與設定 [comment 的狀態]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncommentstatus/）(例如標記為已解決)，此狀態會儲存在檔案中並被 PowerPoint 辨識。

**是否支援串列討論（回覆鏈），且有巢狀深度限制嗎？**

是的。每個註解都可以參照其 [parent comment]（https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/parent_comment/），允許任意深度的回覆鏈。API 未宣告特定的巢狀深度上限。

**註解標記在投影片上的位置是以哪種座標系統定義的？**

位置以浮點座標點儲存在投影片的座標系統中，使您能夠精確地將註解標記放置在需要的位置。