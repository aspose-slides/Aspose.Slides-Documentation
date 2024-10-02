---
title: Presentation Comments
type: docs
weight: 100
url: /python-net/presentation-comments/
keywords: "Comments, PowerPoint comments, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add comments and replies in PowerPoint presentation in Python"
---

In PowerPoint, a comment appears as a note or annotation on a slide. When a comment is clicked, its contents or messages are revealed. 

### **Why Add Comments to Presentations?**

You may want to use comments to provide feedback or communicate with your colleagues when you review presentations.

To allow you to use comments in PowerPoint presentations, Aspose.Slides for Python via .NET provides

* The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class , which contains the collections of authors (from the [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/) property). The authors add comments to slides. 
* The  [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) interface, which contains the collection of comments for individual authors. 
* The [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) class, which contains information on authors and their comments: who added the comment, the time the comment was added, the comment's position, etc. 
* The [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) class, which contains information on individual authors: the author's name, his initials, comments associated with the author's name, etc. 

## **Add Slide Comment**
This Python code shows you how to add a comment to a slide in a PowerPoint presentation:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instantiates the Presentation class
with slides.Presentation() as presentation:
    # Adds an empty slide
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Adds an author
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Sets the position for comments
    point = draw.PointF(0.2, 0.2)

    # Adds slide comment for an author on slide 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Adds slide comment for an author on slide 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Accessing ISlide 1
    slide = presentation.slides[0]

    # When null is passed as an argument, comments from all authors are brought to the selected slide
    comments = slide.get_slide_comments(author)

    # Accesses the comment at index 0 for slide 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Selects the Author's comments collection at index 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Access Slide Comments**
This Python code shows you how to access an existing comment on a slide in a PowerPoint presentation:

```python
import aspose.slides as slides

# Instantiates the Presentation class
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Reply Comments**
A parent comment is the top or original comment in a hierarchy of comments or replies. Using the `parent_comment` property (from the [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) interface), you can set or get a parent comment. 

This Python code shows you how to add comments and get replies to them:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Adds a comment
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Adds a reply to comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Adds another reply to comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Adds a reply to existing reply
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Displays the comments hierarchy on console
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

    # Removes comment1 and all replies to it
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 

* When the `Remove` method (from the [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) interface) is used to delete a comment, the replies to the comment also get deleted. 
* If the `parent_comment` setting results in a circular reference, `PptxEditException` will be thrown.

{{% /alert %}}

## **Add Modern Comment**

In 2021, Microsoft introduced *modern comments* in PowerPoint. The modern comments feature significantly improves collaboration in PowerPoint. Through modern comments, PowerPoint users get to resolve comments, anchor comments to objects and texts, and engage in interactions a lot more easily than before. 

We implemented support for modern comments by adding the [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) class. The `add_modern_comment` and `insert_modern_comment` methods were added to the [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) class. 

This Python code shows you how to add a modern comment to a slide in a PowerPoint presentation:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Comment**

### **Delete All Comments and Authors**

This Python code shows you how to remove all comments and authors in a presentation:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Deletes all comments from the presentation
    for author in presentation.comment_authors:
        author.comments.clear()

    # Deletes all authors
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Delete Specific Comments**

This Python code shows you how to delete specific comments on a slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # add comments...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # remove all comments that contain "comment 1" text
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

