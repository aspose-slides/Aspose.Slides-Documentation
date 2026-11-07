---
title: Связать диаграммы с внешними рабочими книгами
description: Связать данные диаграммы с внешней рабочей книгой и обновить их.
type: docs
url: /ru/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Обзор**

Укажите диаграмме внешний рабочий лист вместо встраивания всех исходных данных в презентацию. Вы можете задать путь к рабочему листу и выбрать, обновлять ли диаграмму из этого файла. Сохранённая диаграмма также может содержать кэшированные данные отображения.

## **Пример использования**

Этот пример C# использует Aspose.Slides for .NET. Создайте корректный рабочий лист продаж с North = 55 и South = 40 и запишите его как sales.xlsx рядом с выводом. Сбросьте значение North в диаграмме до 20, затем привяжите диаграмму к абсолютному пути рабочего листа и обновите её: North снова станет 55. Явный диапазон охватывает заголовок и две строки данных. Держите файл sales.xlsx доступным при открытии или обновлении связанной диаграммы; презентация не встраивает этот внешний файл. Входной файл не требуется. Сохраняются *external-chart-workbook.pptx* и *external-chart-workbook.png*. Установите библиотеку с помощью [руководства по установке](/slides/ru/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **Часто задаваемые вопросы**

### **Могу ли я прочитать все кэшированные значения, когда связанный файл отсутствует?**

Aspose.Slides for .NET 26.11 может [читать сохранённые значения диаграмм напрямую](/slides/ru/net/chart-workbook/#read-cached-chart-values-without-a-workbook) без открытия связанного рабочего листа. Это включает обычные значения, значения X/Y, размеры пузырей и категориальные значения, если такие кэши существуют. Кэшированные данные могут быть отсутствующими или устаревшими; это не полный рабочий лист. Обновление из источника всё равно требует доступного поддерживаемого рабочего листа. Для других SDK и версий проверьте их соответствующее руководство по диаграммам.

### **Что произойдёт, если внешний рабочий лист будет перемещён?**

Обновите путь к внешнему рабочему листу диаграммы до нового расположения и сделайте этот файл доступным там, где обрабатывается презентация. Не полагайтесь на кэшированные данные для полноценных операций доступа к данным, когда они отсутствуют.

### **Могу ли я выбрать, обновлять ли кэшированные данные диаграммы при связывании?**

Да. Выберите, обновлять ли данные диаграммы при установке ссылки. Обновление требует доступного поддерживаемого рабочего листа; пропуск обновления фиксирует ссылку без чтения новых значений из файла.

## **Руководства**

- [Управление рабочими листами диаграмм в презентациях в .NET](/slides/ru/net/chart-workbook/)

Связанная возможность: [Заполнение редактируемых диаграмм данными](/slides/ru/features/chart-data-binding/).