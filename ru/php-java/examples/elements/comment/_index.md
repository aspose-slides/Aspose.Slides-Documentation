---
title: "Комментарий"
type: docs
weight: 230
url: /ru/php-java/examples/elements/comment/
keywords:
- "комментарий"
- "современный комментарий"
- "добавить комментарий"
- "доступ к комментарию"
- "удалить комментарий"
- "ответить на комментарий"
- "пример кода"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "PHP"
- "Aspose.Slides"
description: "Управляйте комментариями слайдов в PHP с помощью Aspose.Slides: добавляйте, читайте, отвечайте, редактируйте, удаляйте и работайте с вложенными комментариями для PowerPoint и OpenDocument."
---
Продемонстрировано добавление, чтение, удаление и ответ на современные комментарии с использованием **Aspose.Slides for PHP via Java**.

## **Добавление современного комментария**

Создайте комментарий, написанный пользователем, и сохраните презентацию.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Добавить современный комментарий.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Доступ к современному комментарию**

Прочитайте современный комментарий из существующей презентации.

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

## **Удаление современного комментария**

Удалите комментарий и сохраните обновлённый файл.

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

## **Ответ на современный комментарий**

Добавьте ответы к родительскому современному комментарию.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Добавить автора комментария.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Добавить родительский комментарий и ответы.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Установить родительский комментарий для ответов.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Сохранить презентацию с ответами.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```