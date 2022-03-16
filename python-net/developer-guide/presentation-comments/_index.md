---
title: Presentation Comments
type: docs
weight: 100
url: /python-net/presentation-comments/
keywords: "Comments, PowerPoint comments, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add comments and replies in PowerPoint presentation in Python"
---



Slide comment is like an annotation in PDF file or a note that one can attach with a slide. Slide comments are generally used while reviewing the slides in PowerPoint. However, they can also serve as a useful utility for highlighting something important in the presentation slide and giving the needed explanation for that.
## **Add Slide Comment**
In Aspose.Slides for Python via .NET, the presentation slide comment are associated with a particular author. The [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class holds the collection of authors in [**ICommentAuthorCollection** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/icommentauthorcollection/)that are responsible for adding slide comments. For each author, there is a collection of comments in [**ICommentCollection**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/icommentcollection/). The [**IComment**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/icomment/) class includes information like an author who added slide comment, time of creation, slide where a comment is added, the position of slide comment on the selected slide and the comment text. The [**CommentAuthor**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/commentauthor/) class includes the author's name, his initials and list of associated comments. In the following example, we have added the code snippet for adding the slide comments.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instantiate Presentation class
with slides.Presentation() as presentation:
    # Adding Empty slide
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Adding Author
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Position of comments
    point = draw.PointF(0.2, 0.2)

    # Adding slide comment for an author on slide 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Adding slide comment for an author on slide 1
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Accessing ISlide 1
    slide = presentation.slides[0]

    # if null is passed as an argument then it will bring comments from all authors on selected slide
    comments = slide.get_slide_comments(author)

    # Accessin the comment at index 0 for slide 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Select comments collection of Author at index 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Access Slide Comments**
In the following example, we will learn how to access the existing slide comments and can even modify the comments as well.

```py
import aspose.slides as slides

# Instantiate Presentation class
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Reply Comments**
A new property [**ParentComment**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/icomment/) has been added to [**IComment**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/icomment/) interface and [**Comment**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/comment/) class in Aspose.Slides for Python via .NET. It allows to get or set the parent comment, thus creating a dialog in the form of a hierarchy of comments and replies.

The code snippet below shows a sample of adding some comments and some replies to them:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Add comment
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Add reply for comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Add reply for comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Add reply to reply
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Display hierarchy on console
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

    # Remove comment1 and all its replies
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 
Remove method of [**IComment**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/icomment/) interface removes the comment with all its replies.
{{% /alert %}}

{{% alert color="info" title="Note" %}} 
If setting [**ParentComment**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/icomment/) leads to a circular reference, the exception of type **PptxEditException** will be thrown.
{{% /alert %}}