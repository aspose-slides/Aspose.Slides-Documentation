---
title: Presentation Comments
type: docs
weight: 100
url: /nodejs-java/presentation-comments/
keywords: "Comments, PowerPoint comments, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Add comments and replies in PowerPoint presentation in Javascript"
---

In PowerPoint, a comment appears as a note or annotation on a slide. When a comment is clicked, its contents or messages are revealed. 

### **Why Add Comments to Presentations?**

You may want to use comments to provide feedback or communicate with your colleagues when you review presentations.

To allow you to use comments in PowerPoint presentations, Aspose.Slides for Node.js via Java provides

* The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class, which contains the collections of authors (from the [CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection) interface). The authors add comments to slides.
* The  [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) interface, which contains the collection of comments for individual authors.
* The  [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) class, which contains information on authors and their comments: who added the comment, the time the comment was added, the comment's position, etc.
* The [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor) class, which contains information on individual authors: the author's name, his initials, comments associated with the author's name, etc.

## **Add Slide Comment**
This Javascript code shows you how to add a comment to a slide in a PowerPoint presentation:

```javascript
    // Instantiates the Presentation class
    var pres = new  aspose.slides.Presentation();
    try {
        // Adds an empty slide
        pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
        // Adds an author
        var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
        // Sets the position for comments
        var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
        // Adds slide comment for an author on slide 1
        author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
        // Adds slide comment for an author on slide 2
        author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
        // Accesses ISlide 1
        var slide = pres.getSlides().get_Item(0);
        // When null is passed as an argument, comments from all authors are brought to the selected slide
        var Comments = slide.getSlideComments(author);
        // Accesses the comment at index 0 for slide 1
        var str = Comments[0].getText();
        pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
        if (Comments.length > 0) {
            // Selects the Author's comments collection at index 0
            var commentCollection = Comments[0].getAuthor().getComments();
            var Comment = commentCollection.get_Item(0).getText();
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Access Slide Comments**
This Javascript code shows you how to access an existing comment on a slide in a PowerPoint presentation:

```javascript
    // Instantiates the Presentation class
    var pres = new  aspose.slides.Presentation("Comments1.pptx");
    try {
        pres.getCommentAuthors().forEach(function(commentAuthor) {
            var author = commentAuthor;
            author.getComments().forEach(function(comment1) {
                var comment = comment1;
                console.log(((((((("ISlide :" + comment.getSlide().getSlideNumber()) + " has comment: ") + comment.getText()) + " with Author: ") + comment.getAuthor().getName()) + " posted on time :") + comment.getCreatedTime()) + "\n");
            });
        });
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Reply Comments**
A parent comment is the top or original comment in a hierarchy of comments or replies. Using the [getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) or [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) methods (from the [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) interface), you can set or get a parent comment.

This Javascript code shows you how to add comments and get replies to them:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        // Adds a comment
        var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
        var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
        // Adds a reply to comment1
        var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
        var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
        reply1.setParentComment(comment1);
        // Adds another reply to comment1
        var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
        reply2.setParentComment(comment1);
        // Add a reply to an existing reply
        var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
        subReply.setParentComment(reply2);
        var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
        var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
        var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
        reply3.setParentComment(comment3);
        // Displays the comments hierarchy on console
        var slide = pres.getSlides().get_Item(0);
        var comments = slide.getSlideComments(null);
        for (var i = 0; i < comments.length; i++) {
            var comment = comments[];
            while (comment.getParentComment() != null) {
                console.log("\t");
                comment = comment.getParentComment();
            }
            console.log((comments[].getAuthor().getName() + " : ") + comments[].getText());
            console.log();
        }
        pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
        // Removes comment1 and all replies to it
        comment1.remove();
        pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

{{% alert color="warning" title="Attention" %}} 

* When the [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--) method (from the [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) interface) is used to delete a comment, the replies to the comment also get deleted.
* If the [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) setting results in a circular reference, [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) will be thrown.

{{% /alert %}}

## **Add Modern Comment**

In 2021, Microsoft introduced *modern comments* in PowerPoint. The modern comments feature significantly improves collaboration in PowerPoint. Through modern comments, PowerPoint users get to resolve comments, anchor comments to objects and texts, and engage in interactions a lot more easily than before. 

In [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-11-release-notes/), we implemented support for modern comments by adding the [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment) class. The [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) and [nsertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) methods were added to the [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) class.

This Javascript code shows you how to add a modern comment to a slide in a PowerPoint presentation:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
        var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
        pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Remove Comment**

### **Delete All Comments and Authors**

This Javascript code shows you how to remove all comments and authors in a presentation:

```javascript
    var presentation = new  aspose.slides.Presentation("example.pptx");
    try {
        // Deletes all comments from the presentation
        presentation.getCommentAuthors().forEach(function(author) {
            author.getComments().clear();
        });
        // Deletes all authors
        presentation.getCommentAuthors().clear();
        presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```

### **Delete Specific Comments**

This Javascript code shows you how to delete specific comments on a slide:

```javascript
    var presentation = new  aspose.slides.Presentation();
    try {
        var slide = presentation.getSlides().get_Item(0);
        // add comments...
        var author = presentation.getCommentAuthors().addAuthor("Author", "A");
        author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
        author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
        // remove all comments that contain "comment 1" text
        presentation.getCommentAuthors().forEach(function(commentAuthor) {
            var toRemove = java.newInstanceSync("java.util.ArrayList");
            slide.getSlideComments(commentAuthor).forEach(function(comment) {
                if (comment.getText().equals("comment 1")) {
                    toRemove.add(comment);
                }
            });
            toRemove.forEach(function(comment) {
                commentAuthor.getComments().remove(comment);
            }
        });
        presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```

