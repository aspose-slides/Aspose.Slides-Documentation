---
title: Настройка легенд диаграмм в презентациях в .NET
linktitle: Легенда диаграммы
type: docs
url: /ru/net/chart-legend/
keywords:
- легенда диаграммы
- положение легенды
- размер шрифта
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides for .NET, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---

## **Rасположение легенды**
Чтобы задать свойства легенды, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд.
- Добавьте диаграмму на слайд.
- Установите свойства легенды.
- Сохраните презентацию в файл PPTX.

В приведённом ниже примере мы задали позицию и размер легенды диаграммы.
```c#
// Создать экземпляр класса Presentation
Presentation presentation = new Presentation();

// Get reference of the slide
ISlide slide = presentation.Slides[0];

// Add a clustered column chart on the slide
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
Aspose.Slides for .NET позволяет разработчикам установить размер шрифта легенды. Выполните следующие шаги:

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


## **Установить размер шрифта отдельного элемента легенды**
Aspose.Slides for .NET позволяет разработчикам установить размер шрифта отдельных элементов легенды. Выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Создайте диаграмму по умолчанию.
- Получите доступ к элементу легенды.
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

**Могу ли я включить легенду так, чтобы диаграмма автоматически выделяла для неё место, а не накладывала её?**

Да. Используйте режим без наложения ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/)= `false`); в этом случае область построения будет уменьшена, чтобы разместить легенду.

**Могу ли я создать многострочные подписи легенды?**

Да. Длинные подписи автоматически переносятся, когда места недостаточно; принудительные разрывы строки поддерживаются с помощью символов новой строки в имени ряда.

**Как сделать так, чтобы легенда использовала цветовую схему темы презентации?**

Не задавайте явные цвета/заливки/шрифты для легенды или её текста. Они будут наследоваться из темы и корректно обновляться при изменении дизайна.