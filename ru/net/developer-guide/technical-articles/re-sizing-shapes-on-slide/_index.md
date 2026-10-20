---
title: Изменение размеров фигур на слайдах презентации в .NET
type: docs
weight: 130
url: /ru/net/resizing-shapes-on-slide/
aliases:
  - /net/изменение-размера-фигур-на-слайде/
  - /ru/net/re-sizing-shapes-on-slide/
keywords:
  - изменение размера фигуры
  - изменить размер фигуры
  - PowerPoint
  - OpenDocument
  - презентация
  - .NET
  - C#
  - Aspose.Slides
description: "Легко изменяйте размеры фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для .NET — автоматизируйте настройки макета слайдов и повышайте продуктивность."
---
## **Обзор**

Когда вы меняете размер слайда презентации, вам также может потребоваться изменить размер и положение его фигур, чтобы они соответствовали новым габаритам. Эта статья показывает, как вручную масштабировать фигуры и как работать с таблицами на слайдах, мастерах и макетах.

## **Изменение размеров фигур**

Чтобы сохранить относительное положение и размер каждой фигуры, умножьте её горизонтальные координаты и ширину на отношение новой ширины слайда к исходной ширине. Примените соответствующее отношение высоты к её вертикальным координатам и высоте.

Первый пример загружает презентацию, в которой слайды не содержат таблиц, меняет размер слайда на A4 и сохраняет результат. Он использует [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) с [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) — чтобы последующий цикл контролировал масштабирование. Отношения безразмерны; позиции фигур и их размеры измеряются в пунктах. Разные коэффициенты ширины и высоты могут искажать фигуры, а изменение размеров фигуры не масштабирует её размеры шрифтов.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Таблицы требуют отдельной обработки: масштабируйте их ширину столбцов и высоту строк вместо задания общей ширины и высоты таблицы. Высота строк может оставаться больше запрошенной, если содержимое ячеек требует дополнительного места.
{{% /alert %}}

Второй пример поддерживает таблицы и обрабатывает фигуры на мастерах и макетах, а также отдельные слайды, перед сохранением изменённой презентации. Его вспомогательный метод обрабатывает каждый [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) путем масштабирования [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) и [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Затем он масштабирует позицию таблицы, не масштабируя её общие размеры отдельно.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Изменить размеры фигур, определённых на мастерах и макетах, а также на отдельных слайдах.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Размеры таблицы задаются шириной столбцов и высотой строк.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **Часто задаваемые вопросы**

**Почему фигуры искажаются или обрезаются после изменения размера слайда?**

Если изменить размер слайда без масштабирования фигур, они сохранят свои исходные позиции и размеры и могут выйти за пределы слайда. Масштабирование ширины и высоты разными коэффициентами также может искажать фигуры.

**Работает ли предоставленный код для всех типов фигур?**

Первый пример изменяет границы фигур напрямую и предназначен для слайдов без таблиц. Второй пример обрабатывает таблицы отдельно. Проверьте получившийся макет, особенно текст и таблицы, поскольку эти примеры не масштабируют размеры шрифтов, а содержимое таблиц может ограничивать высоту строк.

**Как изменить размер таблиц при изменении размера слайда?**

Масштабируйте ширину столбцов по коэффициенту ширины и минимальную высоту строк — по коэффициенту высоты, затем масштабируйте позицию таблицы, как показано во втором примере.

**Будет ли такое масштабирование работать для слайдов‑мастеров и макетных слайдов?**

Да. Второй пример проходит по [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) и по каждому [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) мастера, применяя ту же логику изменения размеров к их фигурам.

**Можно ли изменить ориентацию слайда (портрет/альбом) вместе с изменением размера?**

Да. Установите [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) после изменения размера слайда и перед чтением целевых габаритов, чтобы коэффициенты масштабирования учитывали окончательную ориентацию.

**Существует ли ограничение на размер слайда, который я могу установить?**

Вы можете задавать пользовательские размеры слайда с помощью [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Поддерживаемые размеры также зависят от формата презентации и приложения, используемого для открытия файла.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Используйте один и тот же коэффициент масштабирования для ширины и высоты. Чтобы вписать исходный макет в новые габариты слайда, используйте меньший из коэффициентов ширины и высоты для обеих размеров и позиций. Это сохраняет пропорции, но может оставить свободное пространство по одной из сторон.