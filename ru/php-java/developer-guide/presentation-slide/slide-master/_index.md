---
title: Управление шаблонами слайдов презентации в PHP
linktitle: Шаблон слайда
type: docs
weight: 70
url: /ru/php-java/slide-master/
keywords:
- шаблон слайда
- мастер‑слайд
- PPT мастер‑слайд
- несколько мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонирование мастер‑слайда
- копировать мастер‑слайд
- дублировать мастер‑слайд
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте шаблонами слайдов в Aspose.Slides для PHP через Java: создавайте, редактируйте и применяйте макеты, темы и заполнители к PPT, PPTX и ODP с лаконичными примерами."
---

## **Что такое Slide Master в PowerPoint**

**Slide Master** — это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, можете использовать Slide Master. 

Slide Master полезен, потому что позволяет задать и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм Slide Master из PowerPoint. 

VBA также позволяет манипулировать Slide Master и выполнять те же операции, что поддерживаются в PowerPoint: менять фон, добавлять фигуры, настраивать макет и т.п. Aspose.Slides предоставляет гибкие механизмы для работы с Slide Master и выполнения базовых задач. 

Это базовые операции с Slide Master:

- Создать Slide Master.
- Применить Slide Master к слайдам презентации.
- Изменить фон Slide Master. 
- Добавить изображение, заполнитель, Smart Art и т.д. к Slide Master.

Это более продвинутые операции с Slide Master: 

- Сравнение Slide Master.
- Объединение Slide Master.
- Применение нескольких Slide Master.
- Копирование слайда с Slide Master в другую презентацию.
- Поиск дублирующих Slide Master в презентациях.
- Установка Slide Master как представления по умолчанию для презентации.

{{% alert color="primary" %}} 

Возможно, вам будет интересен Aspose [**Онлайн просмотрщик PowerPoint**](https://products.aspose.app/slides/viewer), поскольку это живой пример некоторых основных процессов, описанных здесь.

{{% /alert %}} 


## **Как применяется Slide Master**

Прежде чем работать со Slide Master, имеет смысл понять, как они используются в презентациях и как применяются к слайдам. 

* Каждая презентация имеет как минимум один Slide Master по умолчанию. 
* Презентация может содержать несколько Slide Master. Вы можете добавить несколько Slide Master и использовать их для стилизации разных частей презентации разными способами. 

В **Aspose.Slides** Slide Master представлен типом [**MasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). 

Объект Aspose.Slides [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) содержит список [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) типа [**MasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), в котором находятся все шаблоны слайдов, определённые в презентации.

Помимо CRUD‑операций, класс [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) имеет полезные методы: [**addClone(LayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/#addClone) и [**insertClone(int index, MasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/#insertClone). Эти методы наследуются от базовой функции клонирования слайдов, но при работе со Slide Master они позволяют реализовать сложные сценарии.

Когда в презентацию добавляется новый слайд, к нему автоматически применяется Slide Master. По умолчанию выбирается Slide Master предыдущего слайда. 

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides), и каждый новый слайд добавляется в конец коллекции. Если презентация содержит единственный Slide Master, он будет выбран для всех новых слайдов. Поэтому не требуется явно задавать Slide Master для каждого нового слайда.

Принцип тот же в PowerPoint и в Aspose.Slides. Например, в PowerPoint, когда вы добавляете новый слайд, достаточно нажать на строку под последним слайдом, и будет создан новый слайд (с тем же Slide Master, что и у предыдущего):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides то же действие можно выполнить методом [addClone(Slide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).


## **Slide Master в иерархии Slides**

Использование Slide Layout вместе со Slide Master обеспечивает максимальную гибкость. Slide Layout позволяет задать те же стили, что и Slide Master (фон, шрифты, фигуры и т.п.). Однако при комбинации нескольких Slide Layout на одном Slide Master появляется новый стиль. Применяя Slide Layout к отдельному слайду, вы можете изменить его стиль по сравнению со стилем, установленным Slide Master.

Slide Master находится выше всех остальных элементов: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)



Каждый объект [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getLayoutSlides) со списком Slide Layout. Тип [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/Slide/#getLayoutSlide), указывающее на применённый к слайду Slide Layout. Взаимодействие между слайдом и Slide Master происходит через Slide Layout.

{{% alert color="info" title="Note" %}}

* В Aspose.Slides все настройки слайда (Slide Master, Slide Layout и сам слайд) являются объектами, наследующими класс [**BaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide).
* Поэтому Slide Master и Slide Layout могут содержать одинаковые свойства, и важно знать, как их значения применяются к объекту [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). Сначала к слайду применяется Slide Master, затем — Slide Layout. Например, если и Slide Master, и Slide Layout задают фон, в результате будет использован фон из Slide Layout.

{{% /alert %}}


## **Что содержит Slide Master**

Чтобы понять, как можно изменять Slide Master, необходимо знать его составные части. Ниже перечислены основные свойства [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getBackground) — получить/установить фон слайда.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getBodyStyle) — получить/установить стили текста тела слайда.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getShapes) — получить/установить все фигуры Slide Master (заполнители, рамки изображений и т.д.).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getControls) — получить/установить элементы управления ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/#getThemeManager) — получить менеджер темы.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getHeaderFooterManager) — получить менеджер заголовков и нижних колонтитулов.

Методы Slide Master:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getDependingSlides) — получить все слайды, зависящие от данного Slide Master.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#applyExternalThemeToDependingSlides) — позволяет создать новый Slide Master на основе текущего и новой темы; новый Slide Master затем применяется ко всем зависимым слайдам.


## **Получить Slide Master**

В PowerPoint доступ к Slide Master осуществляется через меню View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)



В Aspose.Slides доступ к Slide Master выглядит так: 
```php
  $pres = new Presentation();
  try {
    # Предоставляет доступ к мастер-слайду презентации
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


Класс [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) представляет Slide Master. Метод [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getMasters) (возвращающий [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection)) возвращает список всех Slide Master, определённых в презентации. 


## **Добавить изображение в Slide Master**

При добавлении изображения в Slide Master оно будет отображаться на всех слайдах, зависящих от данного шаблона. 

Например, можно разместить логотип компании и несколько изображений на Slide Master, а затем вернуться в режим редактирования слайдов — изображение появится на каждом слайде. 

![todo:image_alt_text](slide-master_4.png)

Добавить изображения в Slide Master с помощью Aspose.Slides можно так:
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


{{% alert color="primary" title="See also" %}} 

Для получения дополнительной информации о добавлении изображений см. статью [Picture Frame](/slides/ru/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Добавить заполнитель в Slide Master**

Эти текстовые поля являются стандартными заполнителями на Slide Master: 

* Щелкните, чтобы отредактировать стиль заголовка Master
* Отредактируйте стили текста Master
* Второй уровень
* Третий уровень 

Они также отображаются на слайдах, основанных на Slide Master. Вы можете редактировать эти заполнители в Slide Master, и изменения автоматически применятся к слайдам. 

В PowerPoint добавить заполнитель можно через путь Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Предположим, что слайд содержит заполнители, полученные из Slide Master:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подзаголовка на Slide Master следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала получаем содержимое заполнителя заголовка из объекта Slide Master и затем используем поле `PlaceHolder.FillFormat`:
```php

```


Стиль и форматирование заголовка изменятся для всех слайдов, основанных на этом шаблоне:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **Изменить фон Slide Master**

При изменении цвета фона мастер‑слайда все обычные слайды презентации получат новый цвет. Ниже приведён пример кода PHP, демонстрирующий эту операцию:
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


{{% alert color="primary" title="See also" %}} 

- [Presentation Background](https://docs.aspose.com/slides/php-java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/php-java/presentation-theme/)

{{% /alert %}}

## **Клонировать Slide Master в другую презентацию**

Чтобы клонировать Slide Master в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) целевой презентации, передав в него нужный Slide Master. Пример кода PHP:
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



## **Добавить несколько Slide Master в презентацию**

Aspose.Slides позволяет добавить несколько Slide Master и Slide Layout в любую презентацию. Это даёт возможность задавать стили, макеты и параметры форматирования слайдов различными способами. 

В PowerPoint новые Slide Master и Layout можно добавить из меню "Slide Master" следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

В Aspose.Slides новый Slide Master добавляется вызовом метода [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone):
```php
  # Добавляет новый мастер‑слайд
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```



## **Сравнение Slide Master**

Slide Master реализует класс [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide), содержащий метод [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#equals), который можно использовать для сравнения слайдов. Метод возвращает `true`, если Slide Master идентичен по структуре и статическому содержимому.

Два Slide Master считаются равными, если их фигуры, стили, тексты, анимации и другие параметры совпадают. При сравнении не учитываются уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущая дата в заполнитель даты). 


## **Установить Slide Master как представление по умолчанию для презентации**

Aspose.Slides позволяет задать Slide Master как представление по умолчанию для презентации. Это представление, которое открывается первым при запуске презентации. 

Пример кода, показывающий, как установить Slide Master как представление по умолчанию:
```php
  # Создает экземпляр класса Presentation, представляющего файл презентации
  $presentation = new Presentation();
  try {
    # Устанавливает вид по умолчанию как SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Сохраняет презентацию
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Удалить неиспользуемые Slide Master**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides) класса [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/), позволяющий удалить нежелательные и неиспользуемые шаблоны слайдов. Пример кода PHP, демонстрирующий удаление Slide Master из PowerPoint‑презентации:
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


## **FAQ**

**Что такое Slide Master в PowerPoint?**

Slide Master — это шаблон слайда, который определяет макет, стили, темы, шрифты, фон и прочие свойства слайдов в презентации. Он позволяет задавать и изменять внешний вид всех слайдов одновременно.  

**Как применяется Slide Master в презентации?**

Каждая презентация имеет как минимум один Slide Master по умолчанию. При добавлении нового слайда к нему автоматически применяется Slide Master, обычно наследуемый от предыдущего слайда. Презентация может содержать несколько Slide Master для стилизации разных частей по‑разному.  

**Какие элементы можно настраивать в Slide Master?**

Slide Master состоит из нескольких основных свойств, которые можно настраивать:

- **Background**: задаёт фон слайда.
- **BodyStyle**: определяет стили текста тела слайда.
- **Shapes**: управляет всеми фигурами на Slide Master, включая заполнители и рамки изображений.
- **Controls**: управляет элементами ActiveX.
- **ThemeManager**: доступ к менеджеру темы.
- **HeaderFooterManager**: управление заголовками и нижними колонтитулами.  

**Как добавить изображение в Slide Master?**

Добавление изображения в Slide Master гарантирует его появление на всех слайдах, зависящих от данного шаблона. Например, размещение логотипа компании на Slide Master отобразит его на каждом слайде презентации.  

**Как Slide Master связан с Slide Layout?**

Slide Layout работают совместно со Slide Master, обеспечивая гибкость в дизайне слайдов. Slide Master задаёт глобальные стили и темы, а Slide Layout позволяют варьировать расположение контента. Иерархия выглядит так:

- **Slide Master** → задаёт глобальные стили.
- **Slide Layout** → предоставляет различные варианты расположения контента.
- **Slide** → наследует дизайн от своего Slide Layout.

**Можно ли иметь несколько Slide Master в одной презентации?**

Да, презентация может содержать несколько Slide Master. Это позволяет стилизовать разные секции презентации различными способами, обеспечивая гибкость дизайна.  

**Как получить доступ к Slide Master и изменить его с помощью Aspose.Slides?**

В Aspose.Slides Slide Master представлен классом [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). Доступ к Slide Master можно получить с помощью метода [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) объекта [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).