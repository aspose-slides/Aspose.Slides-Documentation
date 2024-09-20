---
title: Легенда графика
type: docs
url: /net/chart-legend/
keywords: "Легенда графика, размер шрифта легенды, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Настройка позиционирования и размера шрифта для легенды графика в презентациях PowerPoint на C# или .NET"
---

## **Позиционирование легенды**
Чтобы установить свойства легенды, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд.
- Добавьте график на слайд.
- Установите свойства легенды.
- Запишите презентацию в файл PPTX.

В приведенном ниже примере мы настроили позицию и размер для легенды графика.

```c#
// Создайте экземпляр класса Presentation
Presentation presentation = new Presentation();

// Получите ссылку на слайд
ISlide slide = presentation.Slides[0];

// Добавьте групповой столбчатый график на слайд
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Установите свойства легенды
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Запишите презентацию на диск
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **Установить размер шрифта легенды**
Aspose.Slides для .NET позволяет разработчикам устанавливать размер шрифта легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Создайте график по умолчанию.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Запишите презентацию на диск.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Установить размер шрифта для отдельных элементов легенды**
Aspose.Slides для .NET позволяет разработчикам устанавливать размер шрифта для отдельных элементов легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Создайте график по умолчанию.
- Получите доступ к элементу легенды.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Запишите презентацию на диск.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```