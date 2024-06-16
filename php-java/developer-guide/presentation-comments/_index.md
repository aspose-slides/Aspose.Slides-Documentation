---
title: Presentation Comments
type: docs
weight: 100
url: /php-java/presentation-comments/
keywords: "Comments, PowerPoint comments, PowerPoint presentation, Java, Aspose.Slides for PHP via Java"
description: "Add comments and replies in PowerPoint presentation "
---

In PowerPoint, a comment appears as a note or annotation on a slide. When a comment is clicked, its contents or messages are revealed. 

### **Why Add Comments to Presentations?**

You may want to use comments to provide feedback or communicate with your colleagues when you review presentations.

To allow you to use comments in PowerPoint presentations, Aspose.Slides for PHP via Java provides

* The [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class, which contains the collections of authors (from the [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/ICommentAuthorCollection) interface). The authors add comments to slides.
* The  [ICommentCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/ICommentCollection) interface, which contains the collection of comments for individual authors.
* The  [IComment](https://reference.aspose.com/slides/php-java/com.aspose.slides/IComment) class, which contains information on authors and their comments: who added the comment, the time the comment was added, the comment's position, etc.
* The [CommentAuthor](https://reference.aspose.com/slides/php-java/com.aspose.slides/CommentAuthor) class, which contains information on individual authors: the author's name, his initials, comments associated with the author's name, etc.

## **Add Slide Comment**
This PHP code shows you how to add a comment to a slide in a PowerPoint presentation:

```php
  // Instantiates the Presentation class
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    // Adds an empty slide
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    // Adds an author
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    // Sets the position for comments
    $point = new Point2DFloat(0.2, 0.2);
    // Adds slide comment for an author on slide 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    // Adds slide comment for an author on slide 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    // Accesses ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    // When null is passed as an argument, comments from all authors are brought to the selected slide
    $Comments = $slide->getSlideComments($author);
    // Accesses the comment at index 0 for slide 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if ($Array->getLength($Comments) > 0) {
      // Selects the Author's comments collection at index 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Access Slide Comments**
This PHP code shows you how to access an existing comment on a slide in a PowerPoint presentation:

```php
  // Instantiates the Presentation class
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```


## **Reply Comments**
A parent comment is the top or original comment in a hierarchy of comments or replies. Using the [getParentComment](https://reference.aspose.com/slides/php-java/com.aspose.slides/IComment#getParentComment--) or [setParentComment](https://reference.aspose.com/slides/php-java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) methods (from the [IComment](https://reference.aspose.com/slides/php-java/com.aspose.slides/IComment) interface), you can set or get a parent comment.

This PHP code shows you how to add comments and get replies to them:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    // Adds a comment
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    // Adds a reply to comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    // Adds another reply to comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    // Add a reply to an existing reply
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    // Displays the comments hierarchy on console
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < $Array->getLength($comments); $i++) {
      $comment = $comments[$i];
      while ($comment->getParentComment() != null) {
        System::out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    // Removes comment1 and all replies to it
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

{{% alert color="warning" title="Attention" %}} 

* When the [Remove](https://reference.aspose.com/slides/php-java/com.aspose.slides/IComment#remove--) method (from the [IComment](https://reference.aspose.com/slides/php-java/com.aspose.slides/IComment) interface) is used to delete a comment, the replies to the comment also get deleted.
* If the [setParentComment](https://reference.aspose.com/slides/php-java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) setting results in a circular reference, [PptxEditException](https://reference.aspose.com/slides/php-java/com.aspose.slides/PptxEditException) will be thrown.

{{% /alert %}}

## **Add Modern Comment**

In 2021, Microsoft introduced *modern comments* in PowerPoint. The modern comments feature significantly improves collaboration in PowerPoint. Through modern comments, PowerPoint users get to resolve comments, anchor comments to objects and texts, and engage in interactions a lot more easily than before. 

In [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/), we implemented support for modern comments by adding the [ModernComment](https://reference.aspose.com/slides/php-java/com.aspose.slides/ModernComment) class. The [addModernComment](https://reference.aspose.com/slides/php-java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) and [insertModernComment](https://reference.aspose.com/slides/php-java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) methods were added to the [CommentCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/CommentCollection) class.

This PHP code shows you how to add a modern comment to a slide in a PowerPoint presentation:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Remove Comment**

### **Delete All Comments and Authors**

This PHP code shows you how to remove all comments and authors in a presentation:

```php
  $presentation = new Presentation("example.pptx");
  try {
    // Deletes all comments from the presentation
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    // Deletes all authors
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if ($presentation != null) {
      $presentation->dispose();
    }
  }

```

### **Delete Specific Comments**

This PHP code shows you how to delete specific comments on a slide:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    // add comments...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    // remove all comments that contain "comment 1" text
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if ($presentation != null) {
      $presentation->dispose();
    }
  }

```

