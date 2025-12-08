---
title: 在 Python 中管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/python-net/presentation-comments/
keywords:
- 批注
- 现代批注
- PowerPoint 批注
- 演示文稿批注
- 幻灯片批注
- 添加批注
- 访问批注
- 编辑批注
- 回复批注
- 移除批注
- 删除批注
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 精通演示文稿批注：在 PowerPoint 文件中快速轻松地添加、读取、编辑和删除批注。"
---

在 PowerPoint 中，批注显示为幻灯片上的注释或标注。点击批注时，会显示其内容或信息。

## **为什么要在演示文稿中添加批注？**

在审阅演示文稿时，您可能希望使用批注来提供反馈或与同事进行沟通。

为使您能够在 PowerPoint 演示文稿中使用批注，Aspose.Slides for Python via .NET 提供了

* [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，包含作者集合（来自 [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/) 属性）。作者向幻灯片添加批注。  
* [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) 接口，包含针对各个作者的批注集合。  
* [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) 类，包含关于作者及其批注的信息：谁添加了批注、批注添加时间、批注的位置等。  
* [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) 类，包含关于单个作者的信息：作者姓名、缩写、与作者姓名关联的批注等。  

## **添加幻灯片批注**
下面的 Python 代码演示如何在 PowerPoint 演示文稿的幻灯片中添加批注：
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# 实例化 Presentation 类
with slides.Presentation() as presentation:
    # 添加空幻灯片
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # 添加作者
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # 设置批注位置
    point = draw.PointF(0.2, 0.2)

    # 为作者在幻灯片 1 上添加幻灯片批注
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # 为作者在幻灯片 2 上添加幻灯片批注
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # 访问 ISlide 1
    slide = presentation.slides[0]

    # 当将 null 作为参数传递时，会将所有作者的批注带到选定的幻灯片
    comments = slide.get_slide_comments(author)

    # 访问幻灯片 1 索引 0 的批注
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # 选择作者的批注集合索引 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```


## **访问幻灯片批注**
下面的 Python 代码演示如何访问 PowerPoint 演示文稿中幻灯片上的现有批注：
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


## **回复批注**
父批注是批注或回复层级中的顶层或原始批注。使用 `parent_comment` 属性（来自 [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) 接口），您可以设置或获取父批注。

下面的 Python 代码演示如何添加批注并获取其回复：
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # 添加批注
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # 为 comment1 添加回复
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # 为 comment1 添加另一个回复
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # 为已有的回复添加回复
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # 在控制台显示批注层次结构
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
* 当使用 `Remove` 方法（来自 [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) 接口）删除批注时，该批注的回复也会被删除。  
* 如果 `parent_comment` 设置导致循环引用，将抛出 `PptxEditException`。 
{{% /alert %}}

## **添加现代批注**
2021 年，Microsoft 在 PowerPoint 中引入了 *现代批注*。现代批注功能显著提升了 PowerPoint 的协作能力。通过现代批注，PowerPoint 用户可以解决批注、将批注锚定到对象和文本，并且能够更轻松地进行交互。

我们通过添加 [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) 类实现了对现代批注的支持。在 [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) 类中添加了 `add_modern_comment` 和 `insert_modern_comment` 方法。

下面的 Python 代码演示如何在 PowerPoint 演示文稿的幻灯片中添加现代批注：
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **删除批注**

### **删除所有批注和作者**
下面的 Python 代码演示如何在演示文稿中删除所有批注和作者：
```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # 删除演示文稿中的所有批注
    for author in presentation.comment_authors:
        author.comments.clear()

    # 删除所有作者
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


### **删除特定批注**
下面的 Python 代码演示如何删除幻灯片上的特定批注：
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # 添加批注...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # 删除所有包含 "comment 1" 文本的批注
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

**Aspose.Slides 是否支持现代批注的“已解决”等状态？**  
是的。[Modern comments](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) 公开了一个 [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) 属性；您可以读取和设置 [comment’s state](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/)（例如，将其标记为已解决），该状态会保存在文件中，并被 PowerPoint 识别。

**是否支持线程式讨论（回复链），以及是否有限制嵌套深度？**  
是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/)，从而实现任意的回复链。API 并未声明具体的嵌套深度限制。

**批注标记在幻灯片上的位置是基于什么坐标系定义的？**  
位置以浮点坐标点存储在幻灯片的坐标系中。这使您能够将批注标记精确放置在所需位置。