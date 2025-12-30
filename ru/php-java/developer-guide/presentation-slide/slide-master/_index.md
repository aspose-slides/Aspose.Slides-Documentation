---
title: У管理ение мастер‑слайдами презентации в PHP
linktitle: Слайд‑Мастер
type: docs
weight: 70
url: /ru/php-java/slide-master/
keywords:
- мастер слайд
- мастер‑слайд
- мастер‑слайд PPT
- множество мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонировать мастер‑слайд
- копировать мастер‑слайд
- дублировать мастер‑слайд
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте мастер‑слайдами в Aspose.Slides для PHP через Java: создавайте, редактируйте и применяйте макеты, темы и заполнители к PPT, PPTX и ODP с лаконичными примерами."
---

## **Что такое Slide Master в PowerPoint**

**Slide Master** — это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства для слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать Slide Master. 

Slide Master полезен, потому что позволяет задать и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм Slide Master из PowerPoint. 

VBA также позволяет манипулировать Slide Master и выполнять те же операции, что поддерживаются в PowerPoint: изменять фон, добавлять фигуры, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы, позволяющие использовать Slide Masters и выполнять базовые задачи с ними. 

Это базовые операции с Slide Master:

- Создать Slide Master.
- Применить Slide Master к слайдам презентации.
- Изменить фон Slide Master. 
- Добавить изображение, заполнитель, SmartArt и т.п. в Slide Master.

Это более продвинутые операции, связанные со Slide Master: 

- Сравнение Slide Masters.
- Объединение Slide Masters.
- Применение нескольких Slide Masters.
- Копирование слайда с Slide Master в другую презентацию.
- Поиск дублирующих Slide Masters в презентациях.
- Установка Slide Master как представления по умолчанию для презентации.

{{% alert color="primary" %}} 

Возможно, вам стоит ознакомиться с Aspose [**Онлайн‑просмотрщиком PowerPoint**](https://products.aspose.app/slides/viewer), потому что это живой пример некоторых из описанных здесь основных процессов.

{{% /alert %}} 


## **Как применяется Slide Master**

Прежде чем работать со Slide Master, стоит понять, как они используются в презентациях и применяются к слайдам. 

* Каждая презентация имеет как минимум один Slide Master по умолчанию. 
* Презентация может содержать несколько Slide Masters. Вы можете добавить несколько Slide Masters и использовать их для стилизации разных частей презентации различными способами. 

В **Aspose.Slides** Slide Master представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/) . 

Объект [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) в Aspose.Slides содержит список [**getMasters** ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) из типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) , который включает список всех мастер‑слайдов, определённых в презентации.

Помимо CRUD‑операций, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) содержит полезные методы: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) и [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . Эти методы унаследованы от базовой функции клонирования слайдов. Но при работе с Slide Masters они позволяют реализовать сложные сценарии.

Когда в презентацию добавляется новый слайд, к нему автоматически применяется Slide Master. По умолчанию выбирается Slide Master предыдущего слайда. 

**Примечание**: Слайды презентации хранятся в списке [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--) , и каждый новый слайд добавляется в конец коллекции. Если презентация содержит один Slide Master, он используется для всех новых слайдов. Поэтому вам не нужно явно задавать Slide Master для каждого нового слайда.

Принцип тот же в PowerPoint и Aspose.Slides. Например, в PowerPoint, добавив новую презентацию, вы можете просто нажать на нижнюю линию под последним слайдом, и будет создан новый слайд (с последним Slide Master):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить аналогичную задачу с помощью метода [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) класса [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .


## **Slide Master в иерархии Slides**

Использование Slide Layouts с Slide Master обеспечивает максимальную гибкость. Slide Layout позволяет задать все те же стили, что и Slide Master (фон, шрифты, фигуры и т.п.). Однако при комбинации нескольких Slide Layouts на Slide Master создаётся новый стиль. Применяя Slide Layout к отдельному слайду, вы можете изменить его стиль, отличный от того, что задан Slide Master.

Slide Master превосходит все остальные элементы настройки: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)



Каждый объект [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) имеет свойство [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--) со списком Slide Layouts. Объект типа [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) имеет свойство [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--) со ссылкой на применённый к слайду Slide Layout. Взаимодействие между слайдом и Slide Master происходит через Slide Layout.

{{% alert color="info" title="Примечание" %}}

* В Aspose.Slides все настройки слайда (Slide Master, Slide Layout и сам слайд) являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide).
* Поэтому Slide Master и Slide Layout могут реализовывать одинаковые свойства, и важно знать, как их значения будут применяться к объекту [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). Сначала к слайду применяется Slide Master, затем—Slide Layout. Например, если у Slide Master и Slide Layout заданы значения фона, конечный фон берётся из Slide Layout.

{{% /alert %}}


## **Что содержит Slide Master**

Чтобы понять, как можно изменить Slide Master, нужно знать его составляющие. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) :

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) — получить/установить фон слайда.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) — получить/установить стили текста тела слайда.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) — получить/установить все фигуры Slide Master (заполнители, рамки изображений и т.п.).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) — получить/установить элементы управления ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) — получить менеджер тем.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) — получить менеджер колонтитулов.

Методы Slide Master:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) — получить все слайды, зависящие от Slide Master.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) — позволяет создать новый Slide Master на основе текущего и новой темы; новый Slide Master будет применён ко всем зависимым слайдам.


## **Получить Slide Master**

В PowerPoint Slide Master доступен через меню View → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)



С помощью Aspose.Slides вы можете получить Slide Master так:
```php
  $pres = new Presentation();
  try {
    # Получает доступ к мастер‑слайду презентации
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


Интерфейс [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) представляет Slide Master. Свойство [Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--) (связанное с типом [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)) содержит список всех Slide Masters, определённых в презентации. 


## **Добавить изображение в Slide Master**

Когда вы добавляете изображение в Slide Master, это изображение появляется на всех слайдах, зависящих от данного мастера. 

Например, разместив логотип компании и несколько изображений на Slide Master, а затем вернувшись в режим редактирования слайдов, вы увидите эти изображения на каждом слайде. 

![todo:image_alt_text](slide-master_4.png)

Вы можете добавить изображения в Slide Master с помощью Aspose.Slides:
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


{{% alert color="primary" title="См. также" %}} 

Для получения дополнительной информации о добавлении изображений в слайд см. статью [Picture Frame](/slides/ru/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Добавить заполнитель в Slide Master**

Эти текстовые поля — стандартные заполнители на Slide Master: 

* Click to edit Master title style
* Edit Master text styles
* Second level
* Third level 

Они также отображаются на слайдах, основанных на Slide Master. Вы можете отредактировать эти заполнители на Slide Master, и изменения автоматически применятся к слайдам. 

В PowerPoint вы можете добавить заполнитель через путь Slide Master → Insert Placeholder :

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Предположим, что у нас есть слайд с заполнителями, шаблонизированными из Slide Master :

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование Title и Subtitle на Slide Master следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала получаем содержимое заполнителя Title из объекта Slide Master и затем используем поле `PlaceHolder.FillFormat` :
```php

```


Стиль и форматирование заголовка изменятся для всех слайдов, основанных на данном мастере :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="См. также" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **Изменить фон Slide Master**

При изменении цвета фона мастер‑слайда все обычные слайды в презентации получают новый цвет. Этот PHP‑код демонстрирует операцию:
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


{{% alert color="primary" title="См. также" %}} 

- [Presentation Background](https://docs.aspose.com/slides/php-java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/php-java/presentation-theme/)

{{% /alert %}}

## **Клонировать Slide Master в другую презентацию**

Чтобы клонировать Slide Master в другую презентацию, вызовите метод [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) из целевой презентации, передав в него нужный Slide Master. Этот PHP‑код показывает, как клонировать Slide Master в другую презентацию:
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



## **Добавить несколько Slide Masters в презентацию**

Aspose.Slides позволяет добавить несколько Slide Masters и Slide Layouts в любую презентацию. Это даёт возможность задавать стили, макеты и параметры форматирования слайдов различными способами. 

В PowerPoint вы можете добавить новые Slide Masters и Layouts (из меню "Slide Master") следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

С помощью Aspose.Slides вы можете добавить новый Slide Master, вызвав метод [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :
```php
  # Добавляет новый мастер‑слайд
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```



## **Сравнить Slide Masters**

Master Slide реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide), содержащий метод [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) , который можно использовать для сравнения слайдов. Он возвращает `true` для Master Slides, идентичных по структуре и статическому содержимому.

Два Master Slides равны, если их фигуры, стили, тексты, анимация и прочие настройки совпадают. Сравнение не учитывает уникальные идентификаторы (например, SlideId) и динамический контент (например, текущие даты в заполнителях). 


## **Установить Slide Master как представление по умолчанию для презентации**

Aspose.Slides позволяет установить Slide Master как представление по умолчанию для презентации. Представление по умолчанию — то, что вы видите первым при открытии файла. 

Этот код показывает, как установить Slide Master как представление по умолчанию:
```php
  # Создает экземпляр класса Presentation, представляющего файл презентации
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


## **Удалить неиспользуемые Master Slides**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) из класса [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) для удаления нежелательных и неиспользуемых мастер‑слайдов. Этот PHP‑код демонстрирует, как удалить мастер‑слайд из PowerPoint‑презентации:
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

Slide Master — это шаблон слайда, определяющий макет, стили, темы, шрифты, фон и другие свойства слайдов в презентации. Он позволяет задать и изменить внешний вид всех слайдов сразу.  

**Как применяется Slide Master в презентации?**

Каждая презентация имеет минимум один Slide Master по умолчанию. При добавлении нового слайда к нему автоматически применяется Slide Master, обычно наследуемый от мастера предыдущего слайда. Презентация может содержать несколько Slide Masters для стилизации разных частей по‑разному.  

**Какие элементы можно настраивать в Slide Master?**

Slide Master состоит из нескольких основных свойств, которые можно настраивать:

- **Background** — задаёт фон слайда.
- **BodyStyle** — определяет стили текста тела.
- **Shapes** — управляет всеми фигурами на Slide Master, включая заполнители и рамки изображений.
- **Controls** — работа с элементами управления ActiveX.
- **ThemeManager** — доступ к менеджеру тем.
- **HeaderFooterManager** — управление колонтитулами.  

**Как добавить изображение в Slide Master?**

Добавление изображения в Slide Master гарантирует его появление на всех слайдах, зависящих от этого мастера. Например, размещение логотипа компании на Slide Master отобразит его на каждом слайде презентации.  

**Как Slide Masters соотносятся с Slide Layouts?**

Slide Layouts работают совместно с Slide Masters, обеспечивая гибкость в дизайне слайдов. Slide Master задаёт глобальные стили и темы, а Slide Layouts позволяют варьировать размещение контента. Иерархия выглядит так:

- **Slide Master** → задаёт глобальные стили.
- **Slide Layout** → предоставляет разные схемы размещения контента.
- **Slide** → наследует дизайн от выбранного Slide Layout.

**Можно ли иметь несколько Slide Masters в одной презентации?**

Да, презентация может содержать несколько Slide Masters. Это позволяет стилизовать разные разделы презентации разными способами, обеспечивая гибкость дизайна.  

**Как получить и изменить Slide Master с помощью Aspose.Slides?**

В Aspose.Slides Slide Master представлен классом [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) . Вы можете получить Slide Master, вызвав метод [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) объекта [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .