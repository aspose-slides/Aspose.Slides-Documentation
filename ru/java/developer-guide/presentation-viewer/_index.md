---
title: Создайте просмотрщик презентаций на Java
linktitle: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/java/presentation-viewer/
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
- Java
- Aspose.Slides
description: "Создайте пользовательский просмотрщик презентаций на Java с использованием Aspose.Slides. Легко отображайте файлы PowerPoint и OpenDocument без Microsoft PowerPoint."
---

Aspose.Slides for Java используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открывая презентации в Microsoft PowerPoint и аналогичных программах. Однако иногда разработчикам требуется просматривать слайды как изображения в предпочтительном просмотрщике изображений или создать собственный просмотрщик презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельный слайд в виде изображения. В этой статье описано, как это сделать.

## **Создание SVG‑изображения со слайда**

Чтобы создать SVG‑изображение из слайда презентации с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Откройте файловый поток.
1. Сохраните слайд как SVG‑изображение в файловый поток.
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **Создание SVG с пользовательским идентификатором фигуры**

Aspose.Slides можно использовать для генерации [SVG](https://docs.fileformat.com/page-description-language/svg/) из слайда с пользовательским идентификатором фигуры. Для этого используйте метод `setId` из [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/). Для установки идентификатора фигуры можно применять `CustomSvgShapeFormattingController`.
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **Создание миниатюры слайда**

Aspose.Slides помогает создавать миниатюры слайдов. Чтобы создать миниатюру слайда с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите миниатюру указанного слайда в заданном масштабе.
1. Сохраните миниатюру в любом нужном формате изображения.
```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Создание миниатюры слайда с пользовательскими размерами**

Чтобы создать миниатюру слайда с пользовательскими размерами, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите миниатюру указанного слайда с заданными размерами.
1. Сохраните миниатюру в любом нужном формате изображения.
```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Создание миниатюры слайда с нотами ораторов**

Чтобы создать миниатюру слайда с нотами ораторов с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/).
1. Вызовите метод `RenderingOptions.setSlidesLayoutOptions`, чтобы задать положение нот ораторов.
1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите миниатюру указанного слайда с применением параметров рендеринга.
1. Сохраните миниатюру в любом нужном формате изображения.
```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **Онлайн‑пример**

Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/), чтобы увидеть, что можно реализовать с помощью API Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Можно ли встроить просмотрщик презентаций в веб‑приложение?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для отрисовки слайдов в виде изображений или HTML и отображать их в браузере. Навигацию и функции масштабирования можно реализовать с помощью JavaScript для интерактивного опыта.

**Какой лучший способ отображать слайды в пользовательском просмотрщике?**

Рекомендуется отрисовывать каждый слайд как изображение (например, PNG или SVG) или конвертировать его в HTML с помощью Aspose.Slides, затем показывать результат в элементе `PictureBox` (для настольных приложений) или в HTML‑контейнере (для веба).

**Как работать с большими презентациями, содержащими множество слайдов?**

Для больших наборов рекомендуется использовать «ленивую» загрузку или отрисовку слайдов по требованию. Это означает генерацию содержимого слайда только при переходе пользователя к нему, что снижает потребление памяти и время загрузки.