---
title: Конвертировать PPT и PPTX в JPG в PHP
linktitle: PowerPoint в JPG
type: docs
weight: 60
url: /ru/php-java/convert-powerpoint-to-jpg/
keywords: 
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в JPG
- презентацию в JPG
- слайд в JPG
- PPT в JPG
- PPTX в JPG
- сохранить PowerPoint как JPG
- сохранить презентацию как JPG
- сохранить слайд как JPG
- сохранить PPT как JPG
- сохранить PPTX как JPG
- экспортировать PPT в JPG
- экспортировать PPTX в JPG
- PHP
- Aspose.Slides
description: "Конвертировать слайды PowerPoint (PPT, PPTX) в высококачественные JPG-изображения в PHP с помощью Aspose.Slides for PHP, используя быстрые и надёжные примеры кода."
---

## **О конвертации PowerPoint в JPG**

С помощью [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) вы можете преобразовать презентацию PowerPoint PPT или PPTX в изображение JPG. Также возможно конвертировать PPT/PPTX в JPEG, PNG или SVG. Благодаря этим возможностям легко реализовать собственный просмотрщик презентаций, создать миниатюру для каждого слайда. Это может быть полезно, если вы хотите защитить слайды презентации от копирования, демонстрировать презентацию в режиме только для чтения. Aspose.Slides позволяет преобразовать всю презентацию или отдельный слайд в форматы изображений.

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides преобразует PowerPoint в изображения JPG, вы можете попробовать эти бесплатные онлайн‑конвертеры: PowerPoint [PPTX в JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) и [PPT в JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Преобразование PowerPoint PPT/PPTX в JPG**

Ниже перечислены шаги для конвертации PPT/PPTX в JPG:

1. Создайте экземпляр типа [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите объект слайда типа [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--).
3. Создайте миниатюру каждого слайда, а затем преобразуйте её в JPG. Метод [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) используется для получения миниатюры слайда, он возвращает объект [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images). Метод [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) должен вызываться у нужного слайда типа [ISlide], в него передаются масштабы получаемой миниатюры.
4. После получения миниатюры слайда вызовите метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) у объекта миниатюры. Передайте ему имя получаемого файла и формат изображения.

{{% alert color="primary" %}}

**Примечание**: Конвертация PPT/PPTX в JPG отличается от конвертации в другие типы в Aspose.Slides API. Для других типов обычно используется метод [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), но здесь необходимо использовать метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).

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


## **Преобразование PowerPoint PPT/PPTX в JPG с пользовательскими размерами**

Чтобы изменить размеры получаемой миниатюры и JPG‑изображения, вы можете задать значения *ScaleX* и *ScaleY*, передав их в методы [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-):

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


## **Отрисовка комментариев при сохранении слайдов как изображений**

Aspose.Slides for PHP via Java предоставляет возможность отрисовывать комментарии на слайдах презентации при их преобразовании в изображения. Этот код PHP демонстрирует процесс:

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


{{% alert title="Tip" color="primary" %}}

Aspose предлагает [БЕСПЛАТНОЕ веб‑приложение Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн‑сервиса вы можете объединять изображения [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG, создавать [фото‑решётки](https://products.aspose.app/slides/collage/photo-grid) и т.д.  

Используя те же принципы, описанные в этой статье, вы можете преобразовывать изображения из одного формата в другой. Для получения дополнительной информации см. эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Часто задаваемые вопросы**

**Поддерживает ли этот метод пакетную конвертацию?**

Да, Aspose.Slides позволяет пакетно конвертировать несколько слайдов в JPG за одну операцию.

**Поддерживает ли конвертация SmartArt, диаграммы и другие сложные объекты?**

Да, Aspose.Slides отображает всё содержимое, включая SmartArt, диаграммы, таблицы, фигуры и пр. Однако точность отображения может немного отличаться от PowerPoint, особенно при использовании пользовательских или отсутствующих шрифтов.

**Есть ли ограничения на количество обрабатываемых слайдов?**

Сам Aspose.Slides не накладывает строгих ограничений на количество обрабатываемых слайдов. Однако при работе с крупными презентациями или изображениями высокого разрешения может возникнуть ошибка нехватки памяти.

## **Смотрите также**

Смотрите другие варианты конвертации PPT/PPTX в изображение, например:

- [Конвертация PPT/PPTX в SVG](/slides/ru/php-java/render-a-slide-as-an-svg-image/).