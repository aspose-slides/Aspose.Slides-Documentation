---
title: Изменение размеров фигур на слайдах презентации в .NET
type: docs
weight: 130
url: /ru/net/re-sizing-shapes-on-slide/
keywords:
- изменение размера фигуры
- изменение размеров фигуры
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Легко изменяйте размеры фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для .NET — автоматизируйте настройку макета слайдов и повышайте производительность."
---

## **Обзор**

Один из самых часто задаваемых вопросов клиентами Aspose.Slides for .NET — как изменить размер фигур так, чтобы при изменении размера слайда данные не обрезались. В этой короткой технической статье показано, как это сделать.

## **Изменение размера фигур**

Чтобы фигуры не смещались при изменении размера слайда, обновите позицию и размеры каждой фигуры в соответствии с новым макетом слайда.
```c#
 // Загрузить файл презентации.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Получить исходный размер слайда.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Изменить размер слайда без масштабирования существующих фигур.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Получить новый размер слайда.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Изменить размер и позицию фигур на каждом слайде.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Масштабировать размер фигуры.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Масштабировать позицию фигуры.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
Если слайд содержит таблицу, приведённый выше код работать не будет. В этом случае необходимо изменить размер каждой ячейки таблицы.
{{% /alert %}}

Используйте следующий код, чтобы изменить размер слайдов, содержащих таблицы. Для таблиц установка ширины или высоты является особым случаем: необходимо скорректировать высоту отдельных строк и ширину столбцов, чтобы изменить общий размер таблицы.
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Получить исходный размер слайда.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Изменить размер слайда без масштабирования существующих фигур.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Получить новый размер слайда.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Масштабировать размер фигуры.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Масштабировать позицию фигуры.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Масштабировать размер фигуры.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Масштабировать позицию фигуры.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Масштабировать размер фигуры.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Масштабировать позицию фигуры.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Почему после изменения размера слайда фигуры искажаются или обрезаются?**

При изменении размера слайда фигуры сохраняют свою исходную позицию и размер, если явно не изменить масштаб. Это может привести к обрезке содержимого или смещению фигур.

**Работает ли предоставленный код для всех типов фигур?**

Базовый пример работает для большинства типов фигур (текстовые поля, изображения, диаграммы и т.д.). Однако для таблиц необходимо отдельно обрабатывать строки и столбцы, поскольку высота и ширина таблицы определяются размерами отдельных ячеек.

**Как изменить размер таблиц при изменении размера слайда?**

Необходимо пройтись по всем строкам и столбцам таблицы и пропорционально изменить их высоту и ширину, как показано во втором примере кода.

**Будет ли это изменение работать для шаблонных слайдов и слайдов макета?**

Да, но также следует пройтись по [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) и [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) и применить ту же логику масштабирования к их фигурам, чтобы обеспечить согласованность во всей презентации.

**Можно ли изменить ориентацию слайда (портрет/альбом) вместе с изменением размера?**

Да. Можно установить [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/), чтобы изменить ориентацию. Убедитесь, что логика масштабирования настроена соответствующим образом для сохранения макета.

**Есть ли ограничение на размер слайда, который я могу установить?**

Aspose.Slides поддерживает пользовательские размеры, но очень большие размеры могут повлиять на производительность или совместимость с некоторыми версиями PowerPoint.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Можно проверить свойство `AspectRatioLocked` у фигуры перед масштабированием. Если оно заблокировано, изменяйте ширину или высоту пропорционально, а не масштабируйте их по отдельности.