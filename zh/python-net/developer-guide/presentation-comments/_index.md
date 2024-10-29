---
title: 演示评论
type: docs
weight: 100
url: /zh/python-net/presentation-comments/
keywords: "评论, PowerPoint 评论, PowerPoint 演示, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中的 PowerPoint 演示中添加评论和回复"
---

在 PowerPoint 中，评论作为幻灯片上的注释或标注出现。当点击评论时，其内容或消息会被显示。

### **为什么要在演示文稿中添加评论？**

当您审查演示文稿时，您可能希望使用评论来提供反馈或与同事进行沟通。

为了让您在 PowerPoint 演示文稿中使用评论，Aspose.Slides for Python via .NET 提供了

* [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，它包含作者集合（来自 [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/) 属性）。作者将评论添加到幻灯片。
* [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) 接口，它包含单个作者的评论集合。
* [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) 类，它包含作者及其评论的信息：谁添加了评论、评论添加的时间、评论的位置等。
* [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) 类，它包含个别作者的信息：作者的姓名、缩写、与作者姓名相关的评论等。

## **添加幻灯片评论**
此 Python 代码演示了如何在 PowerPoint 演示中的幻灯片上添加评论：

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# 实例化 Presentation 类
with slides.Presentation() as presentation:
    # 添加一个空幻灯片
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # 添加作者
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # 设置评论的位置
    point = draw.PointF(0.2, 0.2)

    # 在幻灯片1上为作者添加幻灯片评论
    author.comments.add_comment("你好 Jawad，这是幻灯片评论", presentation.slides[0], point, datetime.date.today())

    # 在幻灯片2上为作者添加幻灯片评论
    author.comments.add_comment("你好 Jawad，这是第二个幻灯片评论", presentation.slides[1], point, datetime.date.today())

    # 访问幻灯片1
    slide = presentation.slides[0]

    # 当传递 null 作为参数时，将所有作者的评论归入所选幻灯片
    comments = slide.get_slide_comments(author)

    # 访问幻灯片1的索引0处的评论
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # 选择索引0的作者评论集合
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **访问幻灯片评论**
此 Python 代码演示了如何访问 PowerPoint 演示中幻灯片上的现有评论：

```python
import aspose.slides as slides

# 实例化 Presentation 类
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " 有评论: " + comment.text + 
            " 作者: " + comment.author.name + 
            " 发布于: " + str(comment.created_time) + "\n")
```

## **回复评论**
父评论是在评论或回复的层次结构中最顶部或最原始的评论。利用 `parent_comment` 属性（来自 [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) 接口），您可以设置或获取父评论。

此 Python 代码演示了如何添加评论并获得其回复：

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # 添加评论
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("评论1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # 为评论1添加回复
    author2 = pres.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("评论1的回复1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # 为评论1添加另一条回复
    reply2 = author2.comments.add_comment("评论1的回复2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # 为现有回复添加回复
    subReply = author1.comments.add_comment("回复2的子回复3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("评论2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("评论3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("评论3的回复4", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # 在控制台上显示评论层次结构
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

    # 删除评论1及其所有回复
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="注意" %}} 

* 当使用 `Remove` 方法（来自 [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) 接口）删除评论时，评论的回复也会被删除。
* 如果 `parent_comment` 设置导致循环引用，将抛出 `PptxEditException`。

{{% /alert %}}

## **添加现代评论**

在 2021 年，微软在 PowerPoint 中引入了 *现代评论*。现代评论功能显著改善了 PowerPoint 中的协作。通过现代评论，PowerPoint 用户可以更轻松地解决评论、将评论锚定到对象和文本，并进行更多的互动。

我们通过添加 [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) 类实现对现代评论的支持。在 [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) 类中添加了 `add_modern_comment` 和 `insert_modern_comment` 方法。

此 Python 代码演示了如何在 PowerPoint 演示中向幻灯片添加现代评论：

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("某个作者", "SA")
    modernComment = newAuthor.comments.add_modern_comment("这是一个现代评论", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **删除评论**

### **删除所有评论和作者**

此 Python 代码演示了如何删除演示文稿中的所有评论和作者：

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # 删除演示文稿中的所有评论
    for author in presentation.comment_authors:
        author.comments.clear()

    # 删除所有作者
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **删除特定评论**

此 Python 代码演示了如何删除幻灯片上的特定评论：

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # 添加评论...
    author = presentation.comment_authors.add_author("作者", "A")
    author.comments.add_comment("评论1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("评论2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # 移除所有包含“评论1”文本的评论
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "评论1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```