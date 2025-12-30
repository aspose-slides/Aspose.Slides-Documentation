---
title: Создать просмотрщик презентаций в PHP
linktitle: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/php-java/presentation-viewer/
keywords: 
- просмотр презентации
- просмотрщик презентаций
- создать просмотрщик презентаций
- просмотр PPT
- просмотр PPTX
- просмотр ODP
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Создайте пользовательский просмотрщик презентаций, используя Aspose.Slides для PHP через Java. Легко отображайте файлы PowerPoint и OpenDocument без Microsoft PowerPoint."
---

Aspose.Slides for PHP via Java используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открывая презентации в Microsoft PowerPoint, например. Однако иногда разработчикам может потребоваться просматривать слайды как изображения в их предпочтительном просмотрщике изображений или создавать собственный просмотрщик презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельный слайд как изображение. В этой статье описано, как это сделать.

## **Создать SVG-изображение со слайда**

Чтобы создать SVG‑изображение из слайда презентации с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Откройте файловый поток.
4. Сохраните слайд как SVG‑изображение в файловый поток.
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```


## **Создать SVG с пользовательским идентификатором фигуры**

Aspose.Slides можно использовать для создания [SVG](https://docs.fileformat.com/page-description-language/svg/) из слайда с пользовательским идентификатором фигуры. Для этого используйте метод `setId` из [SvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` можно использовать для установки идентификатора фигуры.
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```

```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```


## **Создать миниатюру слайда**

Aspose.Slides помогает создавать миниатюрные изображения слайдов. Чтобы создать миниатюру слайда с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите миниатюрное изображение ссылочного слайда с заданным масштабом.
4. Сохраните миниатюрное изображение в любом требуемом формате изображения.
```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **Создать миниатюру слайда с пользовательскими размерами**

Чтобы создать изображение миниатюры слайда с пользовательскими размерами, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите миниатюрное изображение ссылочного слайда с заданными размерами.
4. Сохраните миниатюрное изображение в любом требуемом формате изображения.
```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **Создать миниатюру слайда с заметками докладчика**

Чтобы создать миниатюру слайда с заметками докладчика с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/).
2. Используйте метод `RenderingOptions.setSlidesLayoutOptions` для установки положения заметок докладчика.
3. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
4. Получите ссылку на слайд по его индексу.
5. Получите миниатюрное изображение ссылочного слайда с указанными параметрами рендеринга.
6. Сохраните миниатюрное изображение в любом требуемом формате изображения.
```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```


## **Живой пример**

Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) чтобы увидеть, что можно реализовать с помощью API Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Могу ли я встроить просмотрщик презентаций в веб‑приложение?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для рендеринга слайдов в виде изображений или HTML и отображать их в браузере. Навигацию и функции масштабирования можно реализовать с помощью JavaScript для интерактивного опыта.

**Как лучший способ отображать слайды внутри пользовательского просмотрщика?**

Рекомендуемый подход — рендерить каждый слайд как изображение (например, PNG или SVG) или преобразовывать его в HTML с помощью Aspose.Slides, затем отображать результат в элементе picture box (для десктопа) или в HTML‑контейнере (для веба).

**Как обрабатывать большие презентации с большим количеством слайдов?**

Для больших наборов слайдов рекомендуется использовать отложенную загрузку или рендеринг по требованию. Это означает генерацию содержимого слайда только тогда, когда пользователь переходит к нему, что снижает потребление памяти и время загрузки.