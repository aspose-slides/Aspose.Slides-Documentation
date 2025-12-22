---
title: Создать просмотрщик презентаций на Android
linktitle: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/androidjava/presentation-viewer/
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
- Android
- Java
- Aspose.Slides
description: "Создайте пользовательский просмотрщик презентаций на Java, используя Aspose.Slides для Android. Легко отображайте файлы PowerPoint и OpenDocument без Microsoft PowerPoint."
---

Aspose.Slides для Android через Java используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открывая презентации, например, в Microsoft PowerPoint. Однако иногда разработчикам может потребоваться просматривать слайды в виде изображений в предпочитаемом просмотрщике изображений или создавать свой собственный просмотрщик презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельный слайд как изображение. В этой статье описано, как это сделать.

## **Создать SVG‑изображение со слайда**

Чтобы создать SVG‑изображение из слайда презентации с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
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


## **Создать SVG с пользовательским идентификатором формы**

Aspose.Slides можно использовать для генерации [SVG](https://docs.fileformat.com/page-description-language/svg/) из слайда с пользовательским ID формы. Для этого используйте метод `setId` из [ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` можно использовать для установки ID формы.
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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **Создать изображение миниатюры слайда**

Aspose.Slides помогает создавать изображения миниатюр слайдов. Чтобы создать миниатюру слайда с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите изображение миниатюры ссылки на слайд в определённом масштабе.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.
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


## **Создать миниатюру слайда с пользовательскими размерами**

Чтобы создать изображение миниатюры слайда с пользовательскими размерами, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите изображение миниатюры ссылки на слайд с заданными размерами.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.
```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Создать миниатюру слайда с заметками докладчика**

Чтобы создать миниатюру слайда с заметками докладчика с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/).
1. Используйте метод `RenderingOptions.setSlidesLayoutOptions` для установки положения заметок докладчика.
1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите изображение миниатюры ссылки на слайд с параметрами рендеринга.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.
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


## **Пример в работе**

Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/), чтобы увидеть, что можно реализовать с помощью API Aspose.Slides:

![Онлайн‑просмотрщик PowerPoint](online-PowerPoint-viewer.png)

## **FAQ**

**Могу ли я встроить просмотрщик презентаций в веб‑приложение?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для рендеринга слайдов в виде изображений или HTML и отображать их в браузере. Навигацию и функции масштабирования можно реализовать с помощью JavaScript для интерактивного взаимодействия.

**Какой лучший способ отображать слайды внутри кастомного просмотрщика?**

Рекомендуемый подход — рендерить каждый слайд как изображение (например, PNG или SVG) или конвертировать его в HTML с помощью Aspose.Slides, затем отображать результат в элементе picture box (для настольных приложений) или в HTML‑контейнере (для веба).

**Как работать с большими презентациями, содержащими много слайдов?**

Для больших наборов слайдов рекомендуется использовать отложенную загрузку или рендеринг по запросу. Это означает генерацию содержимого слайда только при переходе пользователя к нему, что снижает потребление памяти и время загрузки.