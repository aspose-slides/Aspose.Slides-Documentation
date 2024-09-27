---
title: Слайд Мастер
type: docs
weight: 70
url: /ru/php-java/slide-master/
keywords: "Добавить Слайд Мастер, мастер-слайд PPT, слайд мастер PowerPoint, Изображение на Слайд Мастер, Заполнитель, Несколько Слайд Мастеров, Сравнить Слайд Мастера, Java, Aspose.Slides для PHP через Java"
description: "Добавьте или измените слайд мастер в презентации PowerPoint"
---

## **Что такое Слайд Мастер в PowerPoint**

**Слайд Мастер** — это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства для слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать слайд мастер.

Слайд Мастер полезен, потому что позволяет вам задать и изменить вид всех слайдов презентации сразу. Aspose.Slides поддерживает механизм Слайд Мастера из PowerPoint.

VBA также позволяет вам управлять Слайд Мастером и выполнять те же операции, которые поддерживаются в PowerPoint: изменять фоны, добавлять фигуры, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы, которые позволяют вам использовать Слайды Мастеры и выполнять с ними основные задачи.

Вот основные операции Слайд Мастера:

- Создать или изменить Слайд Мастер.
- Применить Слайд Мастер к слайдам презентации.
- Изменить фон Слайда Мастера.
- Добавить изображение, заполнитель, Smart Art и т.д. на Слайд Мастер.

Вот более продвинутые операции, связанные с Слайд Мастером:

- Сравнить Слайд Мастера.
- Объединить Слайд Мастера.
- Применить несколько Слайд Мастеров.
- Копировать слайд с Слайд Мастером в другую презентацию.
- Найти дубликаты Слайд Мастеров в презентациях.
- Установить Слайд Мастер в качестве представления по умолчанию для презентации.

{{% alert color="primary" %}} 

Вам может быть интересно ознакомиться с Aspose [**Онлайн Просмотрщиком PowerPoint**](https://products.aspose.app/slides/viewer), поскольку это живая реализация некоторых из основных процессов, описанных здесь.

{{% /alert %}} 


## **Как применяется Слайд Мастер**

Прежде чем работать с слайд мастером, вам может понадобиться понять, как они используются в презентациях и применяются к слайдам.

* Каждая презентация по умолчанию имеет как минимум один Слайд Мастер.
* Презентация может содержать несколько Слайд Мастеров. Вы можете добавить несколько Слайд Мастеров и использовать их для оформления различных частей презентации различными способами.

В **Aspose.Slides** Слайд Мастер представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/).

Объект Aspose.Slides [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) содержит список [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/), который содержит список всех мастер-слайдов, определенных в презентации.

Помимо операций CRUD, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) содержит следующие полезные методы: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Эти методы унаследованы от основной функции клонирования слайдов. Но при работе со Слайдами Мастерами эти методы позволяют вам реализовать сложные настройки.

Когда новый слайд добавляется в презентацию, к нему автоматически применяется Слайд Мастер. Слайд Мастер предыдущего слайда по умолчанию выбирается автоматически.

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--) и каждый новый слайд по умолчанию добавляется в конец коллекции. Если презентация содержит один Слайд Мастер, этот слайд мастер выбирается для всех новых слайдов. Это причина, по которой вам не нужно определять Слайд Мастер для каждого нового слайда, который вы создаете.

Принцип такой же как в PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новую презентацию, вы можете просто нажать на нижнюю строку под последним слайдом, и тогда будет создан новый слайд (с Слайд Мастером последней презентации):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить эквивалентную задачу с помощью метода [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) из класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).


## **Слайд Мастер в иерархии слайдов**

Использование макетов слайдов с Слайд Мастером позволяет максимальную гибкость. Макет слайда позволяет задать все те же стили, что и Слайд Мастер (фон, шрифты, фигуры и т.д.). Однако, когда несколько макетов слайдов объединяются на Слайд Мастере, создается новый стиль. Когда вы применяете макет слайда к одному слайду, вы можете изменить его стиль с того, который был применен Слайд Мастером.

Слайд Мастер имеет приоритет над всеми элементами настройки: Слайд Мастер -> Макет Слайда -> Слайд:

![todo:image_alt_text](slide-master_2)

Каждый объект [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--) с списком макетов слайдов. Тип [Слайд](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--) с ссылкой на макет слайда, примененный к слайду. Взаимодействие между слайдом и Слайд Мастером происходит через макет слайда.

{{% alert color="info" title="Примечание" %}}

* В Aspose.Slides все настройки слайдов (Слайд Мастер, Макет Слайда и сам слайд) фактически являются объектами слайда, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide).
* Следовательно, Слайд Мастер и Макет Слайда могут реализовывать одни и те же свойства, и вам нужно знать, как их значения будут применены к объекту [Слайд](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). Сначала к слайду применяется Слайд Мастер, а затем применяется Макет Слайда. Например, если у Слайд Мастера и Макета Слайда оба есть значение фона, слайд в итоге получит фон от Макета Слайда.

{{% /alert %}}


## **Что включает в себя Слайд Мастер**

Чтобы понять, как можно изменить Слайд Мастер, вам необходимо знать его составляющие. Вот основные свойства [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) получить/установить фон слайда.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) - получить/установить текстовые стили тела слайда.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) получить/установить все фигуры Слайда Мастера (заполнители, рамки для изображений и т.д.).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) получить/установить элементы управления ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) - получить менеджер тем.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) - получить менеджер заголовков и подвалов.

Методы Слайд Мастера:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) - получить все слайды, зависящие от Слайда Мастера.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - позволяет создать новый Слайд Мастер на основе текущего Слайда Мастера и новой темы. Новый Слайд Мастер затем будет применен ко всем зависимым слайдам.


## **Получение Слайд Мастера**

В PowerPoint к Слайд Мастеру можно получить доступ через меню Вид -> Слайд Мастер:

![todo:image_alt_text](slide-master_3.jpg)

Используя Aspose.Slides, вы можете получить доступ к Слайд Мастеру следующим образом: 

```php
  $pres = new Presentation();
  try {
    # Получает доступ к мастер-слайду презентации
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

Интерфейс [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) представляет собой Слайд Мастер. Свойство [Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--) (связаное с типом [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)) содержит список всех Слайд Мастеров, определенных в презентации. 


## **Добавление изображения на Слайд Мастер**

Когда вы добавляете изображение на Слайд Мастер, это изображение появится на всех слайдах, зависящих от этого слайда мастера.

Например, вы можете разместить логотип вашей компании и несколько изображений на Слайд Мастер, а затем вернуться в режим редактирования слайдов. Вы должны увидеть изображение на каждом слайде.

![todo:image_alt_text](slide-master_4.png)

Вы можете добавлять изображения на слайд мастер с Aspose.Slides:

```php
  $pres = new Presentation();
  try {
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pres->getMasters()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Смотрите также" %}} 

Для получения дополнительной информации о добавлении изображений на слайд, смотрите статью [Рамка для изображения](/slides/ru/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Добавление заполнителя на Слайд Мастер**

Эти текстовые поля являются стандартными заполнителями на Слайд Мастер: 

* Нажмите, чтобы редактировать стиль заголовка мастера

* Редактировать текстовые стили мастера

* Второй уровень

* Третий уровень 

  Они также появляются на слайдах, основанных на Слайд Мастере. Вы можете редактировать эти заполнители на Слайд Мастере, и изменения будут автоматически применены к слайдам.

В PowerPoint вы можете добавить заполнитель через путь Слайд Мастер -> Вставить заполнитель:

![todo:image_alt_text](slide-master_5.png)

Давайте рассмотрим более сложный пример с заполнителями с помощью Aspose.Slides. Рассмотрим слайд с заполнителями, созданными на основе Слайда Мастера:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подзаголовка на Слайд Мастере следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала мы получаем содержимое заполнителя заголовка из объекта Слайда Мастера, а затем используем поле `PlaceHolder.FillFormat`: 

```php

```

Стиль и форматирование заголовка изменятся на всех слайдах, основанных на слайд мастере:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Смотрите также" %}} 

* [Установить текст подсказки в заполнителе](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Форматирование текста](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **Изменение фона на Слайд Мастере**

Когда вы изменяете цвет фона мастер-слайда, все обычные слайды в презентации получат новый цвет. Этот код PHP демонстрирует операцию:

```php
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $master->getBackground()->setType(BackgroundType::OwnBackground);
    $master->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $master->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Смотрите также" %}} 

- [Фон презентации](https://docs.aspose.com/slides/php-java/presentation-background/)

- [Тема презентации](https://docs.aspose.com/slides/php-java/presentation-theme/)

  {{% /alert %}}

## **Клонирование Слайда Мастера в Другую Презентацию**

Чтобы клонировать Слайд Мастер в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) из целевой презентации вместе с Слайд Мастером, переданным в него. Этот код PHP показывает, как клонировать Слайд Мастер в другую презентацию:

```php
  $presSource = new Presentation();
  $presTarget = new Presentation();
  try {
    $master = $presTarget->getMasters()->addClone($presSource->getMasters()->get_Item(0));
  } finally {
    if (!java_is_null($presSource)) {
      $presSource->dispose();
    }
  }
```


## **Добавление нескольких Слайд Мастеров в Презентацию**

Aspose.Slides позволяет добавлять несколько Слайд Мастеров и Макетов Слайдов в любую данную презентацию. Это позволяет настроить стили, макеты и параметры форматирования для слайдов презентации различными способами.

В PowerPoint вы можете добавить новые Слайд Мастера и Макеты (из меню "Слайд Мастер") следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

Используя Aspose.Slides, вы можете добавить новый Слайд Мастер, вызвав метод  [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-):

```php
  # Добавляет новый мастер-слайд
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);

```


## **Сравнение Слайд Мастеров**

Слайд Мастер реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide), который содержит метод [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), который затем может быть использован для сравнения слайдов. Он возвращает `true` для Мастер Слайдов, идентичных по структуре и статическому содержимому.

Два Мастер Слайда равны, если их фигуры, стили, тексты, анимация и другие настройки и т.д. равны. Сравнение не учитывает уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущее значение даты в Заполнителе Даты). 


## **Установить Слайд Мастер в качестве представления по умолчанию для Презентации**

Aspose.Slides позволяет установить Слайд Мастер в качестве представления по умолчанию для презентации. Представление по умолчанию – это то, что вы видите первым, когда открываете презентацию.

Этот код показывает, как установить Слайд Мастер в качестве представления по умолчанию для презентации:

```php
  # Создает экземпляр класса Presentation, который представляет файл презентации
  $presentation = new Presentation();
  try {
    # Устанавливает представление по умолчанию как SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Сохраняет презентацию
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Удаление неиспользуемого мастер-слайда**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (из класса [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)), который позволяет вам удалить ненужные и неиспользуемые мастер-слайды. Этот код PHP показывает, как удалить мастер-слайд из презентации PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```