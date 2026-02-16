---
title: Comment
type: docs
weight: 230
url: /php-java/examples/elements/comment/
keywords:
- comment
- modern comment
- add comment
- access comment
- remove comment
- reply to comment
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Manage slide comments in PHP with Aspose.Slides: add, read, reply, edit, delete, and work with threaded comments for PowerPoint and OpenDocument."
---

Demonstrates adding, reading, removing, and replying to modern comments using **Aspose.Slides for PHP via Java**.

## **Add a Modern Comment**

Create a comment authored by a user and save the presentation.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Add a modern comment.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Modern Comment**

Read a modern comment from an existing presentation.

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Modern Comment**

Remove a comment and save the updated file.

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Reply to a Modern Comment**

Add replies to a parent modern comment.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Add a comment author.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Add a parent comment and replies.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Set the parent comment for replies.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Save the presentation with replies.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
