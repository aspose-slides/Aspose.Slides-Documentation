---
title: Создать просмотрщик презентаций на C#
linktitle: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/net/presentation-viewer/
keywords: 
- просматривать презентацию
- просмотрщик презентаций
- создать просмотрщик презентаций
- просматривать PPT
- просматривать PPTX
- просматривать ODP
- PowerPoint
- OpenDocument
- C#
- Csharp
- Aspose.Slides для .NET
description: "Узнайте, как создать пользовательский просмотрщик презентаций в .NET с использованием Aspose.Slides. Легко отображайте файлы PowerPoint (PPTX, PPT) и OpenDocument (ODP) без Microsoft PowerPoint или другого офисного программного обеспечения."
---

## **Обзор**

Aspose.Slides for .NET используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открывая презентацию в Microsoft PowerPoint, например. Однако разработчикам иногда требуется просматривать слайды в виде изображений в предпочитаемом просмотрщике изображений или использовать их в кастомном просмотрщике презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельные слайды как изображения. Эта статья объясняет, как это сделать.

## **Создание SVG‑изображения со слайда**

Чтобы создать SVG‑изображение из слайда презентации с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Откройте файловый поток.
1. Сохраните слайд как SVG‑изображение в файловый поток.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```


## **Создание SVG с пользовательским ID фигуры**

Aspose.Slides можно использовать для создания [SVG](https://docs.fileformat.com/page-description-language/svg/) из слайда с пользовательским `ID` фигуры. Для этого используйте свойство Id интерфейса [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape). Класс `CustomSvgShapeFormattingController` позволяет задать ID фигуры.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```


## **Создание миниатюры слайда**

Aspose.Slides помогает генерировать миниатюры слайдов. Чтобы создать миниатюру слайда с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Создайте изображение‑миниатюру указанного слайда в нужном масштабе.
1. Сохраните изображение‑миниатюру в предпочитаемом формате изображения.
```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **Создание миниатюры слайда с пользовательскими размерами**

Чтобы создать изображение‑миниатюру слайда с пользовательскими размерами, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Сгенерируйте изображение‑миниатюру указанного слайда с заданными размерами.
1. Сохраните изображение‑миниатюру в предпочитаемом формате изображения.
```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **Создание миниатюры слайда с заметками докладчика**

Чтобы создать миниатюру слайда с заметками докладчика с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) .
1. Используйте свойство `RenderingOptions.SlidesLayoutOptions` для установки положения заметок докладчика.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. Получите ссылку на слайд по его индексу.
1. Сгенерируйте изображение‑миниатюру указанного слайда, используя параметры рендеринга.
1. Сохраните изображение‑миниатюру в предпочитаемом формате изображения.
```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```


## **Рабочий пример**

Попробуйте бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) — чтобы увидеть, что можно реализовать с помощью API Aspose.Slides:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Можно ли встроить просмотрщик презентаций в веб‑приложение ASP.NET?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для рендеринга слайдов в виде изображений или HTML и отображать их в браузере. Навигацию и масштабирование можно реализовать с помощью JavaScript для интерактивного взаимодействия.

**Как лучше всего отображать слайды в пользовательском .NET‑просмотрщике?**

Рекомендуется рендерить каждый слайд как изображение (например, PNG или SVG) или конвертировать его в HTML с помощью Aspose.Slides, после чего показывать результат в элементе picture box (для настольных приложений) или в HTML‑контейнере (для веба).

**Как работать с большими презентациями, содержащими много слайдов?**

Для больших наборов слайдов рекомендуется использовать отложенную загрузку или рендеринг по запросу. Это означает генерацию содержимого слайда только при переходе к нему, что уменьшает потребление памяти и время загрузки.