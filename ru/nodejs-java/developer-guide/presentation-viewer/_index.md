---
title: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/nodejs-java/presentation-viewer/
keywords:
- просмотр презентации
- просмотрщик презентаций
- просмотр PPT
- просмотр PPTX
- просмотр ODP
- PowerPoint
- OpenDocument
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "Просмотрщик презентаций PowerPoint на JavaScript"
---

Aspose.Slides для Node.js через Java используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открывая презентации в Microsoft PowerPoint, например. Однако иногда разработчикам может потребоваться просматривать слайды как изображения в их предпочитаемом просмотрщике изображений или создавать собственный просмотрщик презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельный слайд в виде изображения. В этой статье описано, как это сделать.

## **Создать SVG‑изображение со слайда**

Чтобы создать SVG‑изображение из слайда презентации с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Откройте файловый поток.
1. Сохраните слайд как SVG‑изображение в файловый поток.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **Создать SVG с пользовательским идентификатором фигуры**

Aspose.Slides можно использовать для создания [SVG](https://docs.fileformat.com/page-description-language/svg/) из слайда с пользовательским идентификатором фигуры. Для этого используйте метод `setId` из [SvgShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` можно использовать для установки идентификатора фигуры.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```


## **Создать миниатюру слайда**

Aspose.Slides помогает вам создавать миниатюры слайдов. Чтобы создать миниатюру слайда с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите изображение‑миниатюру указанного слайда с определённым масштабом.
1. Сохраните изображение‑миниатюру в любом необходимом формате изображения.
```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Создать миниатюру слайда с пользовательскими размерами**

Чтобы создать изображение‑миниатюру слайда с пользовательскими размерами, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите изображение‑миниатюру указанного слайда с заданными размерами.
1. Сохраните изображение‑миниатюру в любом необходимом формате изображения.
```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Создать миниатюру слайда с заметками докладчика**

Чтобы создать миниатюру слайда с заметками докладчика с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/).
1. Используйте метод `RenderingOptions.setSlidesLayoutOptions` для установки положения заметок докладчика.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите изображение‑миниатюру указанного слайда с указанными параметрами рендеринга.
1. Сохраните изображение‑миниатюру в любом необходимом формате изображения.
```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **Пример**

Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) чтобы увидеть, что можно реализовать с помощью API Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **Часто задаваемые вопросы**

**Можно ли встроить просмотрщик презентаций в веб‑приложение Node.js?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для рендеринга слайдов в виде изображений или HTML и отображать их в браузере. Функции навигации и масштабирования можно реализовать с помощью JavaScript для интерактивного опыта.

**Какой лучший способ отображать слайды внутри собственного просмотрщика?**

Рекомендуемый подход — рендерить каждый слайд как изображение (например, PNG или SVG) или преобразовывать его в HTML с помощью Aspose.Slides, а затем отображать результат в элементе PictureBox (для настольных приложений) или в HTML‑контейнере (для веба).

**Как работать с большими презентациями, содержащими множество слайдов?**

Для больших презентаций рекомендуется использовать отложенную загрузку или рендеринг слайдов по запросу. Это значит генерировать содержимое слайда только тогда, когда пользователь переходит к нему, что снижает нагрузку на память и время загрузки.