---
title: Комментарии к презентации
type: docs
weight: 100
url: /php-java/presentation-comments/
keywords: "Комментарии, комментарии PowerPoint, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Добавление комментариев и ответов в презентацию PowerPoint"
---

В PowerPoint комментарий отображается как заметка или аннотация на слайде. При нажатии на комментарий его содержание или сообщения становятся видимыми.

### **Почему стоит добавлять комментарии к презентациям?**

Вы можете захотеть использовать комментарии, чтобы предоставить обратную связь или общаться с коллегами при рассмотрении презентаций.

Чтобы вы могли использовать комментарии в презентациях PowerPoint, Aspose.Slides для PHP через Java предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), который содержит коллекции авторов (из интерфейса [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection)). Авторы добавляют комментарии на слайды.
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection), который содержит коллекцию комментариев для отдельных авторов.
* Класс [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment), который содержит информацию об авторах и их комментариях: кто добавил комментарий, время добавления комментария, позиция комментария и т. д.
* Класс [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor), который содержит информацию о конкретных авторах: имя автора, его инициалы, комментарии, связанные с именем автора и т. д.

## **Добавить комментарий к слайду**
Этот код PHP показывает, как добавить комментарий к слайду в презентации PowerPoint:

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Добавление пустого слайда
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Добавление автора
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Установка позиции для комментариев
    $point = new Point2DFloat(0.2, 0.2);
    # Добавление комментария к слайду для автора на слайде 1
    $author->getComments()->addComment("Привет, Jawad, это комментарий к слайду", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Добавление комментария к слайду для автора на слайде 2
    $author->getComments()->addComment("Привет, Jawad, это второй комментарий к слайду", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Доступ к ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Когда null передается в качестве аргумента, комментарии от всех авторов извлекаются для выбранного слайда
    $Comments = $slide->getSlideComments($author);
    # Доступ к комментарию по индексу 0 для слайда 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Выбор коллекции комментариев Автора по индексу 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Доступ к комментариям слайда**
Этот код PHP показывает, как получить доступ к существующему комментарию на слайде в презентации PowerPoint:

```php
  # Создание экземпляра класса Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " имеет комментарий: " . $comment->getText() . " с Автором: " . $comment->getAuthor()->getName() . " опубликованное в: " . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ответить на комментарии**
Родительский комментарий — это верхний или оригинальный комментарий в иерархии комментариев или ответов. Используя методы [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) или [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (из интерфейса [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)), вы можете установить или получить родительский комментарий.

Этот код PHP показывает, как добавить комментарии и получить ответы на них:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Добавление комментария
    $author1 = $pres->getCommentAuthors()->addAuthor("Автор_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("комментарий1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Добавление ответа на комментарий1
    $author2 = $pres->getCommentAuthors()->addAuthor("Автор_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("ответ 1 на комментарий 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Добавление еще одного ответа на комментарий1
    $reply2 = $author2->getComments()->addComment("ответ 2 на комментарий 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Добавление ответа на существующий ответ
    $subReply = $author1->getComments()->addComment("подответ 3 на ответ 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("комментарий 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("комментарий 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("ответ 4 на комментарий 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Отображение иерархии комментариев в консоли
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)); $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # Удаление комментария1 и всех ответов на него
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Внимание" %}} 

* При использовании метода [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) (из интерфейса [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)) для удаления комментария, отвечающие на комментарий также будут удалены.
* Если установка [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) приводит к циклической ссылке, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Добавить современный комментарий**

В 2021 году Microsoft представила *современные комментарии* в PowerPoint. Функция современных комментариев значительно улучшает совместную работу в PowerPoint. Благодаря современным комментариям пользователи PowerPoint могут разрешать комментарии, прикреплять комментарии к объектам и текстам, а также взаимодействовать гораздо легче, чем раньше.

В [Aspose Slides для Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/) мы реализовали поддержку современных комментариев, добавив класс [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment). Методы [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) и [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) были добавлены в класс [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection).

Этот код PHP показывает, как добавить современный комментарий к слайду в презентации PowerPoint:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Некто Автор", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("Это современный комментарий", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Удалить комментарий**

### **Удалить все комментарии и авторов**

Этот код PHP показывает, как удалить все комментарии и авторов в презентации:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Удаление всех комментариев из презентации
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Удаление всех авторов
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Удалить конкретные комментарии**

Этот код PHP показывает, как удалить конкретные комментарии на слайде:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # добавление комментариев...
    $author = $presentation->getCommentAuthors()->addAuthor("Автор", "A");
    $author->getComments()->addComment("комментарий 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("комментарий 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # удаление всех комментариев, содержащих текст "комментарий 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("комментарий 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```