---
title: Слияние презентаций
type: docs
weight: 40
url: /ru/php-java/merge-presentation/
keywords: "Слияние PowerPoint, PPTX, PPT, комбинирование PowerPoint, слияние презентации, комбинирование презентации, Java"
description: "Слияние или комбинирование презентаций PowerPoint"
---


{{% alert  title="Совет" color="primary" %}} 

Вы можете ознакомиться с **бесплатным онлайн** [приложением Merger от Aspose](https://products.aspose.app/slides/merger). Оно позволяет пользователям объединять презентации PowerPoint в одном и том же формате (PPT в PPT, PPTX в PPTX и т. д.) и сливать презентации в разных форматах (PPT в PPTX, PPTX в ODP и т. д.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Слияние презентаций**

Когда вы сливаете одну презентацию с другой, вы фактически комбинируете их слайды в одной презентации, чтобы получить один файл. 

{{% alert title="Информация" color="info" %}}

Большинство программ для презентаций (PowerPoint или OpenOffice) не имеют функций, позволяющих пользователям объединять презентации таким образом. 

[**Aspose.Slides для PHP через Java**](https://products.aspose.com/slides/php-java/), однако, позволяет вам сливать презентации различными способами. Вы можете объединять презентации со всеми их фигурами, стилями, текстами, форматированием, комментариями, анимациями и т. д. без опасений относительно потери качества или данных.

**Смотрите также**

[Клонирование слайдов](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **Что можно объединить**

С помощью Aspose.Slides вы можете объединять 

* целые презентации. Все слайды из презентаций окажутся в одной презентации
* конкретные слайды. Выбранные слайды окажутся в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т. д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т. д.) друг с другом. 

{{% alert title="Примечание" color="warning" %}} 

Кроме презентаций, Aspose.Slides позволяет вам объединять и другие файлы:

* [Изображения](https://products.aspose.com/slides/php-java/merger/image-to-image/), такие как [JPG в JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) или [PNG в PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Документы, такие как [PDF в PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) или [HTML в HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* И два разных файла, такие как [изображение в PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) или [JPG в PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) или [TIFF в PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Опции слияния**

Вы можете применить параметры, которые определяют, будет ли

* каждый слайд в итоговой презентации сохранять уникальный стиль
* для всех слайдов в итоговой презентации используется один и тот же стиль. 

Для слияния презентаций Aspose.Slides предоставляет методы [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (из интерфейса [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)). Существует несколько реализаций методов `AddClone`, которые определяют параметры процесса слияния презентаций. У каждого объекта Presentation есть коллекция [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--), поэтому вы можете вызывать метод `AddClone` из презентации, в которую вы хотите объединить слайды.

Метод `AddClone` возвращает объект `ISlide`, который является клоном исходного слайда. Слайды в итоговой презентации просто копируются из исходных. Таким образом, вы можете вносить изменения в полученные слайды (например, применять стили или параметры форматирования или макета) без опасений о том, что исходные презентации будут затронуты. 

## **Слияние презентаций** 

Aspose.Slides предоставляет метод [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , который позволяет вам комбинировать слайды, сохраняя их макеты и стили (параметры по умолчанию).

Этот PHP код показывает, как объединить презентации:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Слияние презентаций с использованием мастер-слайда**

Aspose.Slides предоставляет метод [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) , который позволяет вам комбинировать слайды, применяя шаблон презентации мастер-слайда. Таким образом, если необходимо, вы сможете изменить стиль для слайдов в итоговой презентации.

Этот код демонстрирует описанную операцию:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Примечание" color="warning" %}} 

Макет слайда для мастер-слайда определяется автоматически. Когда подходящий макет не может быть определен, если параметр `allowCloneMissingLayout` метода `AddClone` установлен в true, используется макет исходного слайда. В противном случае будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

Если вы хотите, чтобы слайды в итоговой презентации имели другой макет слайда, используйте метод [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) вместо при слиянии.

## **Слияние определенных слайдов из презентаций**

Этот PHP код показывает, как выбрать и объединить определенные слайды из разных презентаций, чтобы получить одну итоговую презентацию:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Слияние презентаций с макетом слайда**

Этот PHP код показывает, как комбинировать слайды из презентаций, применяя к ним предпочтительный макет слайда, чтобы получить одну итоговую презентацию:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Слияние презентаций с разными размерами слайдов**

{{% alert title="Примечание" color="warning" %}} 

Вы не можете объединять презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить 2 презентации с разными размерами слайдов, вам нужно изменить размер одной из презентаций так, чтобы его размер соответствовал размеру другой презентации. 

Этот пример кода демонстрирует описанную операцию:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Слияние слайдов в разделе презентации**

Этот PHP код показывает, как объединить конкретный слайд в раздел презентации:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

Слайд добавляется в конце раздела. 

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб-приложение Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн-сервиса вы можете объединять [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG изображения, создавать [фото сетки](https://products.aspose.app/slides/collage/photo-grid) и так далее. 

{{% /alert %}}