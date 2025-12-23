---
title: Эффективное объединение презентаций в PHP
linktitle: Объединить презентации
type: docs
weight: 40
url: /ru/php-java/merge-presentation/
keywords:
- объединить PowerPoint
- объединить презентации
- объединить слайды
- объединить PPT
- объединить PPTX
- объединить ODP
- комбинировать PowerPoint
- комбинировать презентации
- комбинировать слайды
- комбинировать PPT
- комбинировать PPTX
- комбинировать ODP
- PHP
- Aspose.Slides
description: "Легко объединяйте презентации PowerPoint (PPT, PPTX) и OpenDocument (ODP) с помощью Aspose.Slides for PHP via Java, упрощая ваш рабочий процесс."
---

## **Объединение презентаций**

Когда вы объединяете одну презентацию с другой, вы фактически комбинируете их слайды в одну презентацию, получая один файл. 

{{% alert title="Info" color="info" %}}

Большинство программ для создания презентаций (PowerPoint или OpenOffice) не имеют функций, позволяющих пользователям объединять презентации таким способом. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), однако, позволяет объединять презентации разными способами. Вы можете объединять презентации со всеми их фигурами, стилями, текстами, форматированием, комментариями, анимациями и т.д., не беспокоясь о потере качества или данных.

**Смотрите также**

[Clone Slides](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **Что можно объединять**

С помощью Aspose.Slides вы можете объединять 

* все презентации. Все слайды из презентаций окажутся в одной презентации
* отдельные слайды. Выбранные слайды окажутся в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т.д.) друг с другом. 

{{% alert title="Note" color="warning" %}} 

Помимо презентаций, Aspose.Slides позволяет объединять другие файлы:

* [Images](https://products.aspose.com/slides/php-java/merger/image-to-image/), например [JPG to JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) или [PNG to PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Документы, например [PDF to PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) или [HTML to HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* И два разных файла, такие как [image to PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) или [JPG to PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) или [TIFF to PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Параметры объединения**

Вы можете задать параметры, определяющие, будет ли

* каждый слайд в итоговой презентации сохраняет уникальный стиль
* для всех слайдов в итоговой презентации используется один и тот же стиль. 

Для объединения презентаций Aspose.Slides предоставляет методы [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (из интерфейса [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)). Существует несколько реализаций методов `AddClone`, определяющих параметры процесса объединения презентаций. Каждый объект Presentation имеет коллекцию [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) , поэтому вы можете вызвать метод `AddClone` у презентации, в которую хотите добавить слайды.

Метод `AddClone` возвращает объект `ISlide`, который является клоном исходного слайда. Слайды в результирующей презентации просто копируются из исходных слайдов. Поэтому вы можете вносить изменения в полученные слайды (например, применять стили, параметры форматирования или макеты), не боясь затронуть исходные презентации.

## **Объединение презентаций** 

Aspose.Slides предоставляет метод [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , который позволяет объединять слайды, при этом слайды сохраняют свои макеты и стили (параметры по умолчанию).

Этот код PHP показывает, как объединить презентации:
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


## **Объединение презентаций с шаблоном слайд‑мастера** 

Aspose.Slides предоставляет метод [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) , который позволяет объединять слайды, применяя шаблон слайд‑мастера. Таким образом, при необходимости вы можете изменить стиль слайдов в итоговой презентации.

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


{{% alert title="Note" color="warning" %}} 

Макет слайда для слайд‑мастера определяется автоматически. Если подходящий макет не может быть определён, и параметр `allowCloneMissingLayout` метода `AddClone` установлен в true, используется макет исходного слайда. В противном случае будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

Если вы хотите, чтобы слайды в итоговой презентации имели другой макет, используйте метод [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) вместо этого при объединении.

## **Объединение отдельных слайдов из презентаций** 

Объединение конкретных слайдов из нескольких презентаций полезно для создания индивидуальных наборов слайдов. Aspose.Slides for PHP via Java позволяет выбирать и импортировать только нужные вам слайды. API сохраняет форматирование, макет и дизайн оригинальных слайдов.

Следующий код PHP создаёт новую презентацию, добавляет титульные слайды из двух других презентаций и сохраняет результат в файл:
```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```

```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```


## **Объединение презентаций с макетом слайдов** 

Этот код PHP показывает, как объединить слайды из презентаций, применяя к ним выбранный вами макет слайда, чтобы получить одну итоговую презентацию:
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


## **Объединение презентаций с разными размерами слайдов** 

{{% alert title="Note" color="warning" %}} 

Нельзя объединять презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить 2 презентации с разными размерами слайдов, необходимо изменить размер одной из презентаций, чтобы её размеры совпадали с размерами другой. 

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


## **Объединение слайдов в раздел презентации** 

Этот код PHP показывает, как объединить конкретный слайд в раздел презентации:
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


Слайд добавляется в конец раздела. 

## **См. также**


Aspose предоставляет [БЕСПЛАТНЫЙ онлайн‑сервис создания коллажей](https://products.aspose.app/slides/collage). С помощью этого онлайн‑сервиса вы можете объединять изображения [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG, создавать [фото‑решётки](https://products.aspose.app/slides/collage/photo-grid), и многое другое.

Ознакомьтесь с [Aspose FREE Online Merger](https://products.aspose.app/slides/merger). Он позволяет объединять презентации PowerPoint в одном формате (например, PPT в PPT, PPTX в PPTX) или между различными форматами (например, PPT в PPTX, PPTX в ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **FAQ**

**Существует ли ограничение на количество слайдов при объединении презентаций?**

Нет строгих ограничений. Aspose.Slides может обрабатывать большие файлы, но производительность зависит от их размера и ресурсов системы. Для очень больших презентаций рекомендуется использовать 64‑битную JVM и выделять достаточный объём памяти heap.

**Можно ли объединять презентации с встроенными видео или аудио?**

Да, Aspose.Slides сохраняет мультимедийный контент, встроенный в слайды, но итоговая презентация может существенно увеличиться в размере.

**Сохраняются ли шрифты при объединении презентаций?**

Да. Шрифты, использованные в исходных презентациях, сохраняются в выходном файле, при условии, что они установлены в системе или [встроены](/slides/ru/php-java/embedded-font/).