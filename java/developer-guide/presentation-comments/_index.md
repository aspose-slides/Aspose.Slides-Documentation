---
title: Presentation Comments
type: docs
weight: 100
url: /java/presentation-comments/
keywords: "PowerPoint presentation comments"
description: "Add PowerPoint comments and reply presentation comments in Java."
---


## **Add Comment Reply**
New methods [**getParentComment**](https://apireference.aspose.com/slides/java/com.aspose.slides/IComment#getParentComment--) and [**setParentComment**](https://apireference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) have been added to [**IComment**](https://apireference.aspose.com/slides/java/com.aspose.slides/IComment) interface and [**Comment**](https://apireference.aspose.com/slides/java/com.aspose.slides/Comment) class in Aspose.Slides for Java. It allows to get or set the parent comment, thus creating a dialog in the form of a hierarchy of comments and replies.

The code snippet below shows a sample of adding some comments and some replies to them:

```java
Presentation pres = new Presentation();
try {
    // Add comment
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Add reply for comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Add reply for comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Add reply to reply
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Display hierarchy on console
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);
    // Remove comment1 and all its replies
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

**Attention: remove** method of [**IComment**](https://apireference.aspose.com/slides/java/com.aspose.slides/IComment) interface removes the comment with all its replies.

**NOTE:** If setting **ParentComment** leads to a circular reference, the exception of type **PptxEditException** will be thrown.
