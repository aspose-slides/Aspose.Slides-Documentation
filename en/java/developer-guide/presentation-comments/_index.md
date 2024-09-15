---
title: Presentation Comments
type: docs
weight: 100
url: /java/presentation-comments/
keywords: "Comments, PowerPoint comments, PowerPoint presentation, Java, Aspose.Slides for Java"
description: "Add comments and replies in PowerPoint presentation in Java"
---

In PowerPoint, a comment appears as a note or annotation on a slide. When a comment is clicked, its contents or messages are revealed. 

### **Why Add Comments to Presentations?**

You may want to use comments to provide feedback or communicate with your colleagues when you review presentations.

To allow you to use comments in PowerPoint presentations, Aspose.Slides for Java provides

* The [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class, which contains the collections of authors (from the [ICommentAuthorCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentAuthorCollection) interface). The authors add comments to slides. 
* The  [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentCollection) interface, which contains the collection of comments for individual authors. 
* The  [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) class, which contains information on authors and their comments: who added the comment, the time the comment was added, the comment's position, etc. 
* The [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/CommentAuthor) class, which contains information on individual authors: the author's name, his initials, comments associated with the author's name, etc. 

## **Add Slide Comment**
This Java code shows you how to add a comment to a slide in a PowerPoint presentation:

```java
// Instantiates the Presentation class
Presentation pres = new Presentation();
try {
    // Adds an empty slide
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Adds an author
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Sets the position for comments
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Adds slide comment for an author on slide 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Adds slide comment for an author on slide 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Accesses ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // When null is passed as an argument, comments from all authors are brought to the selected slide
    IComment[] Comments = slide.getSlideComments(author);

    // Accesses the comment at index 0 for slide 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Selects the Author's comments collection at index 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Access Slide Comments**
This Java code shows you how to access an existing comment on a slide in a PowerPoint presentation:

```java
// Instantiates the Presentation class
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Reply Comments**
A parent comment is the top or original comment in a hierarchy of comments or replies. Using the [getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#getParentComment--) or [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) methods (from the [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) interface), you can set or get a parent comment. 

This Java code shows you how to add comments and get replies to them:

```java
Presentation pres = new Presentation();
try {
    // Adds a comment
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Adds a reply to comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Adds another reply to comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Add a reply to an existing reply
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Displays the comments hierarchy on console
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

    // Removes comment1 and all replies to it
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 

* When the [Remove](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#remove--) method (from the [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) interface) is used to delete a comment, the replies to the comment also get deleted. 
* If the [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) setting results in a circular reference, [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException) will be thrown.

{{% /alert %}}

## **Add Modern Comment**

In 2021, Microsoft introduced *modern comments* in PowerPoint. The modern comments feature significantly improves collaboration in PowerPoint. Through modern comments, PowerPoint users get to resolve comments, anchor comments to objects and texts, and engage in interactions a lot more easily than before. 

In [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-11-release-notes/), we implemented support for modern comments by adding the [ModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/ModernComment) class. The [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) and [insertModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) methods were added to the [CommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection) class. 

This Java code shows you how to add a modern comment to a slide in a PowerPoint presentation: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove Comment**

### **Delete All Comments and Authors**

This Java code shows you how to remove all comments and authors in a presentation:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Deletes all comments from the presentation
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Deletes all authors
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Delete Specific Comments**

This Java code shows you how to delete specific comments on a slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // add comments...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // remove all comments that contain "comment 1" text
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

