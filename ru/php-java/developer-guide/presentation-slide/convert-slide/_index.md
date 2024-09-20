---
title: Конвертация слайда
type: docs
weight: 35
url: /php-java/convert-slide/
keywords: "Конвертация слайда в изображение, экспорт слайда как изображение, сохранить слайд как изображение, слайд в изображение, слайд в PNG, слайд в JPEG, слайд в Bitmap, Java, java, Aspose.Slides"
description: "Конвертация слайда PowerPoint в изображение (Bitmap, PNG или JPG)"
---

Aspose.Slides для PHP через Java позволяет вам конвертировать слайды (в презентациях) в изображения. Поддерживаемые форматы изображений: BMP, PNG, JPG (JPEG), GIF и другие.

Чтобы конвертировать слайд в изображение, выполните следующие действия:

1. Сначала,
   * конвертируйте слайд в изображение, используя метод [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) или

2. Во-вторых, задайте дополнительные параметры для конвертации и конвертируемые объекты слайдов через
   * интерфейс [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) или
   * интерфейс [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions).

## **О Bitmap и других форматах изображений**

В Java объект [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) позволяет вам работать с изображениями, определенными пиксельными данными. Вы можете использовать экземпляр этого класса для сохранения изображений в широком диапазоне форматов (JPG, PNG и т. д.).

{{% alert title="Информация" color="info" %}}

Aspose недавно разработал онлайн-конвертер [Text to GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Конвертирование слайдов в Bitmap и сохранение изображений в PNG**

Этот код PHP показывает, как конвертировать первый слайд презентации в объект bitmap, а затем как сохранить изображение в формате PNG:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Конвертирует первый слайд в презентации в объект Images
    $slideImage = $pres->getSlides()->get_Item(0)->getImage();
    # Сохраняет изображение в формате PNG
    try {
      # сохраняет изображение на диске.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Этот пример кода показывает, как конвертировать первый слайд презентации в объект bitmap с использованием метода [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-):

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Получает размер слайда презентации
    $slideSize = new Java("java.awt.Dimension", $slideSize->getWidth(), $slideSize->getHeight());
    # Создает объект Images с размером слайда
    $slideImage = $sld->getImage(new RenderingOptions(), $slideSize);
    try {
      # сохраняет изображение на диске.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Совет" color="primary" %}} 

Вы можете конвертировать слайд в объект Images и затем использовать объект непосредственно где-то. Либо вы можете конвертировать слайд в Images, а затем сохранить изображение в формате JPEG или любом другом формате, который вы предпочитаете.

{{% /alert %}}  

## **Конвертирование слайдов в изображения с пользовательскими размерами**

Может потребоваться получить изображение определенного размера. Используя перегрузку метода [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) , вы можете конвертировать слайд в изображение с конкретными размерами (длина и ширина).

Этот пример кода демонстрирует предложенную конвертацию с использованием метода [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-):

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Конвертирует первый слайд презентации в Bitmap с указанным размером
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 1820, 1040));
    # Сохраняет изображение в формате JPEG
    try {
      # сохраняет изображение на диске.
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Конвертирование слайдов с заметками и комментариями в изображения**

Некоторые слайды содержат заметки и комментарии. 

Aspose.Slides предоставляет два интерфейса — [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) и [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions) — которые позволяют контролировать рендеринг слайдов презентации в изображения. Оба интерфейса содержат интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions), который позволяет добавлять заметки и комментарии на слайд при конвертировании слайда в изображение.

{{% alert title="Информация" color="info" %}} 

С помощью интерфейса [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) вы можете указать предпочитаемое положение для заметок и комментариев в результирующем изображении.

{{% /alert %}} 

Этот код PHP демонстрирует процесс конвертации слайда с заметками и комментариями:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # Создает параметры рендеринга
    $options = new RenderingOptions();
    # Устанавливает положение заметок на странице
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Устанавливает положение комментариев на странице
    $options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);
    # Устанавливает ширину области вывода комментариев
    $options->getNotesCommentsLayouting()->setCommentsAreaWidth(500);
    # Устанавливает цвет для области комментариев
    $options->getNotesCommentsLayouting()->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);
    # Конвертирует первый слайд презентации в объект Bitmap
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, 2.0, 2.0);
    # Сохраняет изображение в формате GIF
    try {
      $slideImage->save("Slide_Notes_Comments_0.gif", ImageFormat::Gif);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Этот код PHP демонстрирует процесс конвертации слайда с заметками с использованием метода [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-):

```php
  $pres = new Presentation("PresentationNotes.pptx");
  try {
    # Получает размер заметок презентации
    $notesSize = $pres->getNotesSize()->getSize();
    # Создает параметры рендеринга
    $options = new RenderingOptions();
    # Устанавливает положение заметок
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Создает объект Images с размером заметок
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, $notesSize);
    # Сохраняет изображение в формате PNG
    try {
      # сохраняет изображение на диске.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Примечание" color="warning" %}} 

В процессе конвертации любого слайда в изображение свойство [NotesPositions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) не может быть установлено в BottomFull (чтобы указать положение для заметок), потому что текст заметки может быть большим, что значит, он может не поместиться в заданный размер изображения.

{{% /alert %}} 

## **Конвертирование слайдов в изображения с использованием ITiffOptions**

Интерфейс [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) предоставляет вам больше контроля (в терминах параметров) над результирующим изображением. С помощью этого интерфейса вы можете указывать размер, разрешение, цветовую палитру и другие параметры для результирующего изображения.

Этот код PHP демонстрирует процесс конвертации, в котором ITiffOptions используется для получения черно-белого изображения с разрешением 300dpi и размером 2160 × 2800:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # Получает слайд по индексу
    $slide = $pres->getSlides()->get_Item(0);
    # Создает объект TiffOptions
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));
    # Устанавливает шрифт, используемый в случае, если исходный шрифт не найден
    $options->setDefaultRegularFont("Arial Black");
    # Устанавливает положение заметок на странице
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Устанавливает формат пикселей (черно-белый)
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);
    # Устанавливает разрешение
    $options->setDpiX(300);
    $options->setDpiY(300);
    # Конвертирует слайд в объект Bitmap
    $slideImage = $slide->getImage($options);
    # Сохраняет изображение в формате TIFF
    try {
      $slideImage->save("PresentationNotesComments.tiff", ImageFormat::Tiff);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Примечание" color="warning" %}} 

Поддержка Tiff не гарантируется в версиях ниже JDK 9.

{{% /alert %}} 

## **Конвертирование всех слайдов в изображения**

Aspose.Slides позволяет вам конвертировать все слайды в одной презентации в изображения. По сути, вы получаете возможность конвертировать презентацию (в целом) в изображения. 

Этот пример кода показывает, как конвертировать все слайды в презентации в изображения:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Генерирует презентацию в массив изображений слайд за слайдом
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      # Проверяет скрытые слайды (не рендерит скрытые слайды)
      if ($pres->getSlides()->get_Item($i)->getHidden()) {
        continue;
      }
      # Конвертирует слайд в объект Bitmap
      $slideImage = $pres->getSlides()->get_Item($i)->getImage(2.0, 2.0);
      # Сохраняет изображение в формате PNG
      try {
        $slideImage->save("Slide_" . $i . ".png", ImageFormat::Png);
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