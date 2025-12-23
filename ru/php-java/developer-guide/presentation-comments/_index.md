---
title: Управление комментариями к презентациям в PHP
linktitle: Комментарии к презентациям
type: docs
weight: 100
url: /ru/php-java/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии к слайдам
- добавить комментарий
- доступ к комментарию
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Эффективно управляйте комментариями к презентациям с помощью Aspose.Slides for PHP via Java: добавляйте, читайте, редактируйте и удаляйте комментарии в файлах PowerPoint быстро и просто."
---

В PowerPoint комментарий отображается как заметка или аннотация на слайде. При щелчке по комментарию его содержимое или сообщения раскрываются. 

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии для предоставления обратной связи или общения с коллегами при проверке презентаций.

Чтобы вы могли использовать комментарии в презентациях PowerPoint, Aspose.Slides for PHP via Java предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) содержит коллекцию авторов (из интерфейса [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection)). Авторы добавляют комментарии к слайдам.
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection) содержит коллекцию комментариев для отдельных авторов.
* Класс [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) содержит информацию об авторах и их комментариях: кто добавил комментарий, время добавления, позицию комментария и т.д.
* Класс [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor) содержит информацию об отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора, и т.д.

## **Добавление комментариев к слайдам**
Этот PHP‑код показывает, как добавить комментарий к слайду в презентации PowerPoint:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Добавляет пустой слайд
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Добавляет автора
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Устанавливает позицию для комментариев
    $point = new Point2DFloat(0.2, 0.2);
    # Добавляет комментарий к слайду для автора на слайде 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Добавляет комментарий к слайду для автора на слайде 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Получает ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Когда в качестве аргумента передается null, комментарии всех авторов выводятся на выбранный слайд
    $Comments = $slide->getSlideComments($author);
    # Получает комментарий с индексом 0 для слайда 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Выбирает коллекцию комментариев автора с индексом 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получение комментариев со слайда**
Этот PHP‑код показывает, как получить существующий комментарий со слайда в презентации PowerPoint:
```php
  # Создает экземпляр класса Presentation
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
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ответы на комментарии**
Родительским комментарием является верхний или оригинальный комментарий в иерархии комментариев или ответов. С помощью методов [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) или [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (из интерфейса [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)) можно установить или получить родительский комментарий.

Этот PHP‑код показывает, как добавлять комментарии и получать ответы на них:
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Добавляет комментарий
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Добавляет ответ к comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Добавляет еще один ответ к comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Добавляет ответ к существующему ответу
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Выводит иерархию комментариев в консоль
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # Удаляет comment1 и все ответы к нему
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" title="Attention" %}} 

* При использовании метода [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) (из интерфейса [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)) для удаления комментария также удаляются ответы на этот комментарий.
* Если настройка [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) приводит к круговой ссылке, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Добавление современных комментариев**

В 2021 году Microsoft представила *современные комментарии* в PowerPoint. Функция современных комментариев значительно улучшает совместную работу в PowerPoint. С помощью современных комментариев пользователи PowerPoint могут решать комментарии, привязывать их к объектам и текстам и взаимодействовать гораздо проще, чем ранее. 

В [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/) мы реализовали поддержку современных комментариев, добавив класс [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment). Методы [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) и [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) были добавлены в класс [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection).

Этот PHP‑код показывает, как добавить современный комментарий к слайду в презентации PowerPoint:
```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Удаление комментариев**

### **Удалить все комментарии и авторов**
Этот PHP‑код показывает, как удалить все комментарии и авторов в презентации:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # Удаляет все комментарии из презентации
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Удаляет всех авторов
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


### **Удалить конкретные комментарии**
Этот PHP‑код показывает, как удалить конкретные комментарии со слайда:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # добавить комментарии...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # удалить все комментарии, содержащие текст "comment 1"
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
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Вопросы и ответы**

**Поддерживает ли Aspose.Slides статус, например «решено», для современных комментариев?**  
Да. [Modern comments](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) предоставляют метод [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/); вы можете задать [состояние комментария](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) (например, отметить его как решённое), и это состояние сохраняется в файле и распознаётся PowerPoint.

**Поддерживаются ли ветвленные обсуждения (цепочки ответов) и существует ли ограничение вложенности?**  
Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), позволяя создавать произвольные цепочки ответов. API не объявляет конкретного предела вложенности.

**В какой системе координат определяется позиция маркера комментария на слайде?**  
Позиция хранится как точка с плавающей запятой в системе координат слайда. Это позволяет разместить маркер комментария точно там, где это необходимо.