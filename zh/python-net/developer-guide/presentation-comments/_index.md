---
title: 在 Python 中管理演示文稿评论
linktitle: 演示文稿评论
type: docs
weight: 100
url: /zh/python-net/presentation-comments/
keywords:
- 评论
- 现代评论
- PowerPoint 评论
- 演示文稿评论
- 幻灯片评论
- 添加评论
- 访问评论
- 编辑评论
- 回复评论
- 删除评论
- 删除评论
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: 使用 Aspose.Slides for Python via .NET 高效轻松地在 PowerPoint 文件中添加、读取、编辑和删除演示文稿评论。
---

在 PowerPoint 中，评论显示为幻灯片上的备注或注释。单击评论后，内容或信息会展开显示。

## **为什么要在演示文稿中添加评论？**

您可能希望在审阅演示文稿时使用评论来提供反馈或与同事沟通。

为使您能够在 PowerPoint 演示文稿中使用评论，Aspose.Slides for Python via .NET 提供

* 包含作者集合的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，作者通过 [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/) 属性获取并向幻灯片添加评论。 
* 包含各作者评论集合的 [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) 接口。 
* 包含作者及其评论信息的 [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) 类：谁添加了评论、添加时间、评论位置等。 
* 包含单个作者信息的 [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) 类：作者姓名、缩写、与作者关联的评论等。 

## **添加幻灯片评论**
以下 Python 代码演示如何在 PowerPoint 演示文稿的幻灯片上添加评论：

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# 实例化 Presentation 类
with slides.Presentation() as presentation:
    # 添加空白幻灯片
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # 添加作者
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # 设置评论的位置
    point = draw.PointF(0.2, 0.2)

    # 为作者在幻灯片 1 上添加评论
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # 为作者在幻灯片 2 上添加评论
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # 访问 ISlide 1
    slide = presentation.slides[0]

    # 当参数为 null 时，获取选定幻灯片上所有作者的评论
    comments = slide.get_slide_comments(author)

    # 获取幻灯片 1 上索引 0 的评论
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # 选择索引 0 处的作者评论集合
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **访问幻灯片评论**
以下 Python 代码演示如何访问 PowerPoint 演示文稿中幻灯片已有的评论：

```python
import aspose.slides as slides

# 实例化 Presentation 类
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **回复评论**
父评论是评论层级结构中的顶层或原始评论。使用 [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) 接口的 `parent_comment` 属性，可以设置或获取父评论。

以下 Python 代码演示如何添加评论并获取其回复：

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # 添加评论
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # 为 comment1 添加回复
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # 为 comment1 添加另一个回复
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # 为已有回复添加回复
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # 在控制台显示评论层次结构
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

    # 删除 comment1 及其所有回复
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 

* 当使用 `Remove` 方法（来自 [IComment] 接口）删除评论时，评论的回复也会被删除。 
* 如果 `parent_comment` 设置导致循环引用，将抛出 `PptxEditException`。

{{% /alert %}}

## **添加现代评论**

2021 年，Microsoft 在 PowerPoint 中推出了*现代评论*。现代评论功能显著提升了 PowerPoint 的协作效率。通过现代评论，用户可以解决评论、将评论锚定到对象和文本，并更便捷地进行交互。

我们通过添加 [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) 类实现了对现代评论的支持。在 [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) 类中加入了 `add_modern_comment` 与 `insert_modern_comment` 方法。

以下 Python 代码演示如何在 PowerPoint 幻灯片上添加现代评论：

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **删除评论**

### **删除所有评论和作者**

以下 Python 代码演示如何删除演示文稿中的所有评论和作者：

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

以下 Python 代码演示如何删除幻灯片上特定的评论：

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # 添加评论...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # 删除所有包含 "comment 1" 文本的评论
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**Aspose.Slides 是否支持类似 ‘已解决’ 的状态用于现代评论？**

是的。[Modern comments](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) 提供 `status` 属性；您可以读取和设置评论的状态（例如标记为已解决），该状态会保存在文件中并被 PowerPoint 识别。

**是否支持线程式讨论（回复链），并且是否有嵌套深度限制？**

是的。每条评论都可以引用其 `parent_comment`，从而形成任意深度的回复链。API 并未声明具体的嵌套深度限制。

**评论标记的位置在幻灯片中使用什么坐标系定义？**

位置以浮点坐标点的形式存储在幻灯片的坐标系中。这样您可以精确地将评论标记放置在需要的位置。