---
title: Макет слайдов
type: docs
weight: 60
url: /php-java/slide-layout/
keyword: "Установить размер слайда, установить параметры слайда, указать размер слайда, видимость нижнего колонтитула, дочерний нижний колонтитул, масштабирование содержимого, размер страницы, Java, Aspose.Slides"
description: "Установите размер и параметры слайда PowerPoint"
---

Макет слайда содержит заполнители и информацию о форматировании для всего содержимого, которое появляется на слайде. Макет определяет доступные заполнители содержимого и их размещение.

Макеты слайдов позволяют быстро создавать и оформлять презентации (независимо от их сложности). Вот некоторые из наиболее популярных макетов слайдов, используемых в презентациях PowerPoint:

* **Макет титульного слайда**. Этот макет состоит из двух текстовых заполнителей. Один заполнитель предназначен для заголовка, а другой — для подзаголовка.
* **Макет заголовка и содержания**. Этот макет содержит относительно небольшой заполнитель в верхней части для заголовка и больший заполнитель для основного содержания (график, абзацы, маркированный список, нумерованный список, изображения и т. д.).
* **Пустой макет**. Этот макет не имеет заполнителей, поэтому позволяет создавать элементы с нуля.

Поскольку основной слайд является верхним иерархическим слайдом, который хранит информацию о макетах слайдов, вы можете использовать основной слайд для доступа к макетам слайдов и внесения изменений в них. Макет слайда может быть доступен по типу или имени. Аналогично, каждый слайд имеет уникальный идентификатор, который может быть использован для доступа к нему.

Кроме того, вы можете внести изменения непосредственно в конкретный макет слайда в презентации.

* Чтобы позволить вам работать с макетами слайдов (включая те, которые находятся в основных слайдах), Aspose.Slides предоставляет свойства, такие как [getLayoutSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides--) и [getMasters()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) в классе [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
* Для выполнения связанных задач Aspose.Slides предоставляет [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/baseslideheaderfootermanager/) и многие другие типы.

{{% alert title="Информация" color="info" %}}

Для получения дополнительной информации о работе с основными слайдами в частности смотрите статью [Мастер-слайд](https://docs.aspose.com/slides/php-java/slide-master/).

{{% /alert %}}

## **Добавить макет слайда в презентацию**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите доступ к [коллекции MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/).
1. Просмотрите существующие макеты слайдов, чтобы убедиться, что требуемый макет слайда уже существует в коллекции макетов слайдов. В противном случае добавьте нужный макет слайда.
1. Добавьте пустой слайд на основе нового макета слайда.
1. Сохраните презентацию.

Этот код PHP показывает, как добавить макет слайда в презентацию PowerPoint:

```php
  # Создает экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("AccessSlides.pptx");
  try {
    # Проходит по типам макетов слайдов
    $layoutSlides = $pres->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }
    if (java_is_null($layoutSlide)) {
      # Ситуация, когда презентация не содержит некоторые типы макетов.
      # файл презентации содержит только пустые и пользовательские типы макетов.
      # Но макеты слайдов с пользовательскими типами имеют разные имена слайдов,
      # такие как "Заголовок", "Заголовок и содержание" и т. д. И можно использовать эти
      # имена для выбора макета слайда.
      # Вы также можете использовать набор типов форм заполнителей. Например,
      # Титульный слайд должен иметь только тип заполнителя заголовка и т. д.
      foreach($layoutSlides as $titleAndObjectLayoutSlide) {
        if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
          $layoutSlide = $titleAndObjectLayoutSlide;
          break;
        }
      }
      if (java_is_null($layoutSlide)) {
        foreach($layoutSlides as $titleLayoutSlide) {
          if (java_values($titleLayoutSlide->getName()) == "Title") {
            $layoutSlide = $titleLayoutSlide;
            break;
          }
        }
        if (java_is_null($layoutSlide)) {
          $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
          if (java_is_null($layoutSlide)) {
            $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
          }
        }
      }
    }
    # Добавляет пустой слайд с добавленным макетом слайда
    $pres->getSlides()->insertEmptySlide(0, $layoutSlide);
    # Сохраняет презентацию на диск
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Удалить неиспользуемый макет слайда**

Aspose.Slides предоставляет метод [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) из класса [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/), чтобы вы могли удалить нежелательные и неиспользуемые макеты слайдов. Этот код PHP показывает, как удалить макет слайда из презентации PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установить размер и тип для макета слайда**

Чтобы позволить вам установить размер и тип для конкретного макета слайда, Aspose.Slides предоставляет свойства [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) и [getSize()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getSize--) (из класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)). Этот Java демонстрирует операцию:

```php
  # Создает экземпляр объекта Presentation, представляющего файл презентации
  $presentation = new Presentation("demo.pptx");
  try {
    $auxPresentation = new Presentation();
    try {
      # Устанавливает размер слайда для созданной презентации так же, как у источника
      $auxPresentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);
      # getType());
      $auxPresentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);
      # Клонирует требуемый слайд
      $auxPresentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
      $auxPresentation->getSlides()->removeAt(0);
      # Сохраняет презентацию на диск
      $auxPresentation->save("size.pptx", SaveFormat::Pptx);
    } finally {
      $auxPresentation->dispose();
    }
  } finally {
    $presentation->dispose();
  }
```

## **Установить видимость нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Установите заполнитель нижнего колонтитула слайда в видимый режим. 
1. Установите заполнитель даты и времени в видимый режим. 
1. Сохраните презентацию. 

Этот код PHP показывает, как установить видимость для нижнего колонтитула слайда (и выполнить связанные задачи):

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getSlides()->get_Item(0)->getHeaderFooterManager();
    # Метод isFooterVisible используется для указания, что заполнитель нижнего колонтитула слайда отсутствует
    if (!$headerFooterManager->isFooterVisible()) {
      $headerFooterManager->setFooterVisibility(true);// Метод setFooterVisibility используется для установки видимости заполнителя нижнего колонтитула слайда

    }
    # Метод isSlideNumberVisible используется для указания, что заполнитель номера страницы слайда отсутствует
    if (!$headerFooterManager->isSlideNumberVisible()) {
      $headerFooterManager->setSlideNumberVisibility(true);// Метод setSlideNumberVisibility используется для установки видимости заполнителя номера страницы слайда

    }
    # Метод isDateTimeVisible используется для указания, что заполнитель даты и времени слайда отсутствует
    if (!$headerFooterManager->isDateTimeVisible()) {
      $headerFooterManager->setDateTimeVisibility(true);// Метод SetFooterVisibility используется для установки видимости заполнителя даты и времени слайда

    }
    $headerFooterManager->setFooterText("Footer text");// Метод SetFooterText используется для установки текста для заполнителя нижнего колонтитула слайда.

    $headerFooterManager->setDateTimeText("Date and time text");// Метод SetDateTimeText используется для установки текста для заполнителя даты и времени слайда.

  } finally {
    $presentation->dispose();
  }
```

## **Установить видимость дочернего нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на основной слайд по его индексу. 
1. Установите основной слайд и все дочерние заполнители нижних колонтитулов в видимый режим.
1. Установите текст для основного слайда и всех дочерних заполнителей нижних колонтитулов. 
1. Установите текст для основного слайда и всех дочерних заполнителей даты и времени. 
1. Сохраните презентацию. 

Этот код PHP демонстрирует операцию:

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);// Метод setFooterAndChildFootersVisibility используется для установки видимости основного слайда и всех дочерних заполнителей нижних колонтитулов

    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// Метод setSlideNumberAndChildSlideNumbersVisibility используется для установки видимости основного слайда и всех дочерних заполнителей номера страницы

    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// Метод setDateTimeAndChildDateTimesVisibility используется для установки видимости основного слайда и всех дочерних заполнителей даты и времени

    $headerFooterManager->setFooterAndChildFootersText("Footer text");// Метод setFooterAndChildFootersText используется для установки текста для основного слайда и всех дочерних заполнителей нижних колонтитулов

    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// Метод setDateTimeAndChildDateTimesText используется для установки текста для основного слайда и всех дочерних заполнителей даты и времени

  } finally {
    $presentation->dispose();
  }
```

## **Установить размер слайда с учетом масштабирования содержимого**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию, содержащую слайд, для которого вы хотите установить размер.
1. Создайте еще один экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) для генерации новой презентации.
1. Получите ссылку на слайд (из первой презентации) по его индексу.
1. Установите заполнитель нижнего колонтитула слайда в видимый режим. 
1. Установите заполнитель даты и времени в видимый режим. 
1. Сохраните презентацию. 

Этот код PHP демонстрирует операцию:

```php
  # Создает объект Presentation, представляющий файл презентации
  $presentation = new Presentation("demo.pptx");
  try {
    # Устанавливает размер слайда для созданной презентации так же, как у источника
    $presentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);// Метод SetSize используется для установки размера слайда с масштабированием содержимого для обеспечения соответствия

    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);// Метод SetSize используется для установки размера слайда с максимальным размером содержимого

    # Сохраняет презентацию на диск
    $presentation->save("Set_Size&Type_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Установить размер страницы при конвертации в PDF**

Некоторые презентации (например, постеры) часто конвертируются в PDF-документы. Если вы хотите конвертировать свою презентацию PowerPoint в PDF, чтобы получить лучшие параметры печати и доступности, вам нужно установить размеры слайдов, которые подходят для PDF-документов (например, A4).

Aspose.Slides предоставляет класс [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/), чтобы вы могли указать предпочитаемые настройки для слайдов. Этот код PHP показывает, как использовать свойство [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) (из класса `SlideSize`), чтобы установить конкретный размер бумаги для слайдов в презентации:

```php
  # Создает объект Presentation, представляющий файл презентации
  $presentation = new Presentation();
  try {
    # Устанавливает свойство SlideSize.Type
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);
    # Устанавливает разные параметры для параметров PDF
    $opts = new PdfOptions();
    $opts->setSufficientResolution(600);
    # Сохраняет презентацию на диск
    $presentation->save("SetPDFPageSize_out.pdf", SaveFormat::Pdf, $opts);
  } finally {
    $presentation->dispose();
  }
```