---
title: Конвертация PowerPoint в JPG
type: docs
weight: 60
url: /php-java/convert-powerpoint-to-jpg/
keywords: "Конвертировать PowerPoint в JPG, PPTX в JPEG, PPT в JPEG"
description: "Конвертировать PowerPoint в JPG: PPT в JPG, PPTX в JPG"
---


## **О конвертации PowerPoint в JPG**
С помощью [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) вы можете конвертировать презентацию PowerPoint PPT или PPTX в изображение JPG. Также возможно конвертировать PPT/PPTX в JPEG, PNG или SVG. Благодаря этой функции легко реализовать свой собственный просмотрщик презентаций, создать миниатюру для каждого слайда. Это может быть полезно, если вы хотите защитить слайды презентации от копирования, продемонстрировать презентацию в режиме только для чтения. Aspose.Slides позволяет конвертировать всю презентацию или отдельный слайд в форматы изображений. 

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует PowerPoint в изображения JPG, вы можете попробовать эти бесплатные онлайн-конвертеры: PowerPoint [PPTX в JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) и [PPT в JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Конвертация PowerPoint PPT/PPTX в JPG**
Вот шаги для конвертации PPT/PPTX в JPG:

1. Создайте экземпляр типа [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите объект слайда типа [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--).
3. Создайте миниатюру каждого слайда и затем конвертируйте его в JPG. [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) используется для получения миниатюры слайда, он возвращает объект [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) в результате. Метод [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) должен быть вызван из нужного слайда типа [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide), параметры масштабирования результирующей миниатюры передаются в метод.
4. После получения миниатюры слайда вызовите метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) из объекта миниатюры. Передайте в него имя результирующего файла и формат изображения. 

{{% alert color="primary" %}}

**Примечание**: Конвертация PPT/PPTX в JPG отличается от конвертации в другие типы в Aspose.Slides API. Для других типов вы обычно используете метод [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), но здесь вам нужен метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)). 

{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Создает изображение в полном масштабе
      $slideImage = $sld->getImage(1.0, 1.0);
      # Сохраняет изображение на диск в формате JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Конвертация PowerPoint PPT/PPTX в JPG с настроенными размерами**
Чтобы изменить размер результирующей миниатюры и изображения JPG, вы можете установить значения *ScaleX* и *ScaleY*, передав их в методы [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-):

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Определяет размеры
    $desiredX = 1200;
    $desiredY = 800;
    # Получает масштабированные значения X и Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Создает изображение в полном масштабе
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Сохраняет изображение на диск в формате JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Отображение комментариев при сохранении презентации в изображение**
Aspose.Slides для PHP через Java предоставляет возможность отображать комментарии на слайдах презентации при преобразовании этих слайдов в изображения. Этот PHP код демонстрирует данную операцию:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет приложение [БЕСПЛАТНЫЙ Коллаж](https://products.aspose.app/slides/collage). С помощью этого онлайн-сервиса вы можете объединить [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG изображения, создать [фотогруппы](https://products.aspose.app/slides/collage/photo-grid) и так далее. 

Используя те же принципы, описанные в этой статье, вы можете конвертировать изображения из одного формата в другой. Для получения дополнительной информации смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Смотрите также**

Смотрите другие варианты конвертации PPT/PPTX в изображения, такие как:

- [Конвертация PPT/PPTX в SVG](/slides/php-java/render-a-slide-as-an-svg-image/).