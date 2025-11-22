---
title: Легенда диаграммы
type: docs
url: /ru/net/chart-legend/
keywords: "Легенда диаграммы, размер шрифта легенды, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Установите позицию и размер шрифта легенды диаграммы в презентациях PowerPoint на C# или .NET"
---

## **Расположение легенды**
Чтобы задать свойства легенды, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд.
- Добавьте диаграмму на слайд.
- Установите свойства легенды.
- Сохраните презентацию в файл PPTX.

В приведенном ниже примере мы задали положение и размер легенды диаграммы.
```c#
// Создать экземпляр класса Presentation
Presentation presentation = new Presentation();

// Получить ссылку на слайд
ISlide slide = presentation.Slides[0];

// Добавить кластеризованную столбчатую диаграмму на слайд
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Установить свойства легенды
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Сохранить презентацию на диск
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **Установить размер шрифта легенды**
Aspose.Slides для .NET позволяет разработчикам установить размер шрифта легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Создайте диаграмму по умолчанию.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Сохраните презентацию на диск.
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


## **Установить размер шрифта отдельной записи легенды**
Aspose.Slides для .NET позволяет разработчикам задать размер шрифта отдельных записей легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Создайте диаграмму по умолчанию.
- Получите доступ к записи легенды.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Сохраните презентацию на диск.
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


## **FAQ**

**Можно ли включить легенду так, чтобы диаграмма автоматически выделяла для неё место, а не накладывала её?**

Да. Используйте режим без наложения ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`); в этом случае область построения уменьшится, чтобы разместить легенду.

**Можно ли создавать многострочные метки легенды?**

Да. Длинные метки автоматически переносятся, если места недостаточно; принудительные переносы строки поддерживаются с помощью символов новой строки в имени серии.

**Как заставить легенду следовать цветовой схеме темы презентации?**

Не задавайте явные цвета/заливки/шрифты для легенды или её текста. Они будут наследоваться от темы и корректно обновятся при изменении дизайна.