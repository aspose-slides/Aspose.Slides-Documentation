---
title: Изменение размеров фигур на слайдах презентаций в .NET
type: docs
weight: 130
url: /ru/net/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Легко изменяйте размер фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для .NET — автоматизируйте настройку макетов слайдов и повышайте продуктивность."
---
## **Обзор**

Один из самых часто задаваемых вопросов клиентами Aspose.Slides for .NET — как изменить размер фигур так, чтобы при изменении размера слайда данные не обрезались. Эта короткая техническая статья показывает, как это сделать.

## **Изменение размера фигур**

Чтобы фигуры не смещались при изменении размера слайда, обновите позицию и размеры каждой фигуры, чтобы они соответствовали новому макету слайда.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Загрузите файл презентации.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Получите исходный размер слайда.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Измените размер слайда без масштабирования существующих фигур.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Получите новый размер слайда.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Измените размер и позицию фигур на каждом слайде.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Масштабируйте размер фигуры.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Масштабируйте позицию фигуры.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Если в слайде есть таблица, приведённый выше код работать не будет. В этом случае каждый элемент таблицы необходимо масштабировать.

{{% /alert %}}

Используйте следующий код, чтобы изменить размер слайдов, содержащих таблицы. Для таблиц масштабируйте высоту отдельных строк и ширину столбцов вместо ширины и высоты фигуры — одновременное масштабирование обоих параметров удвоит масштаб таблицы и сместит её за пределы слайда.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
            if (shape is ITable)
            {
                // Масштабировать размер таблицы через её строки и столбцы.
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
            else
            {
                // Масштабировать размер фигуры.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Масштабировать позицию фигуры.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Часто задаваемые вопросы**

### Почему после изменения размера слайда фигуры искажаются или обрезаются?

При изменении размера слайда фигуры сохраняют своё первоначальное положение и размер, если масштаб явно не изменён. Это может привести к обрезке содержимого или смещению фигур.

### Работает ли предоставленный код для всех типов фигур?

Базовый пример работает для большинства типов фигур (текстовые поля, изображения, диаграммы и т.д.). Однако для таблиц необходимо обрабатывать строки и столбцы отдельно, так как высота и ширина таблицы определяются размерами её ячеек.

### Как изменить размер таблиц при изменении размера слайда?

Необходимо пройтись по всем строкам и столбцам таблицы и пропорционально изменить их высоту и ширину, как показано во втором примере кода.

### Будет ли это изменение работать для главных слайдов и слайдов‑разметки?

Да, но также следует пройтись по [Masters](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/masters/) и [LayoutSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/layoutslides/) и применить ту же логику масштабирования к их фигурам, чтобы обеспечить согласованность презентации.

### Можно ли изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?

Да. Вы можете установить [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/ru/net/aspose.slides/islidesize/orientation/) для изменения ориентации. Убедитесь, что логика масштабирования настроена соответствующим образом, чтобы сохранить макет.

### Есть ли ограничение на размер слайда, который я могу задать?

Aspose.Slides поддерживает пользовательские размеры, но очень большие размеры могут влиять на производительность или совместимость с некоторыми версиями PowerPoint.

### Как предотвратить искажение фигур с фиксированным соотношением сторон?

Можно проверить свойство `AspectRatioLocked` у фигуры перед масштабированием. Если оно заблокировано, изменяйте ширину или высоту пропорционально, а не масштабируя их по отдельности.