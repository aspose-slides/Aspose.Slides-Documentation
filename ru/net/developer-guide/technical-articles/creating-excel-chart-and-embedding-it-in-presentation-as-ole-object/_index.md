---
title: Создание диаграмм Excel и их встраивание в презентации как OLE-объекты
type: docs
weight: 50
url: /ru/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Диаграмма Excel
- Встроить диаграмму
- OLE-объект
- PowerPoint
- Презентация
- .NET
- C#
- Aspose.Slides
description: "Создайте диаграмму Excel с помощью Aspose.Cells for .NET и встроите книгу в презентацию PowerPoint с помощью Aspose.Slides, включая предварительный просмотр диаграммы."
---
## **Обзор**

В этой статье показано, как создать столбчатую диаграмму Excel с помощью Aspose.Cells for .NET и встроить её книгу в презентацию PowerPoint с помощью Aspose.Slides for .NET. Встроенная книга содержит как исходные данные, так и диаграмму. Отдельное PNG‑предпросмотр отображает диаграмму на слайде до активации OLE‑объекта.

Результатом является встроенный объект Excel, а не нативная диаграмма PowerPoint. Редактирование книги через OLE требует настольного приложения, поддерживающего активацию OLE, и совместимой установки Excel.

## **Требования**

Добавьте ссылки на Aspose.Cells for .NET и Aspose.Slides for .NET в ваш проект C#. Пример использует верхнеуровневые инструкции и требует C# 9 или более новой версии. Microsoft Office не требуется для генерации презентации с помощью этих библиотек.

Входные файлы не требуются: пример создаёт данные и диаграмму в памяти, затем записывает `OutputChart.pptx` в текущий рабочий каталог. Примените лицензии для обоих продуктов при запуске вне режима оценки.

## **Как работает встраивание**

1. Создайте книгу с листом данных и листом диаграммы.  
2. Сделайте лист диаграммы активным, чтобы книга открывалась на диаграмме.  
3. Установите диапазон отображения OLE книги и отрисуйте диаграмму в PNG.  
4. Сохраните книгу в формате XLSX в памяти и внедрите эти байты в слайд.  
5. Назначьте PNG в качестве предварительного просмотра OLE‑объекта и сохраните презентацию в формате PPTX.

Диапазон отображения книги и рамка на слайде имеют разные роли. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) принимает нулевые индексы начала/конца строки и столбца. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) вместо этого принимает верхнюю строку, левый столбец, нижнюю строку и правый столбец. В примере в качестве правых нижних границ используется индекс строки 55 и индекс столбца 25; эти значения являются выбором компоновки, а не количеством строк или столбцов данных.

Рамка слайда использует единицы измерения в пунктах. Пример помещает её в пределах слайда и центрирует, сохраняя пропорции PNG, вместо растягивания предварительного просмотра до заполнения слайда.

## **Создание и встраивание диаграммы**

Следующий полностью готовый пример заполняет `DataSheet` четырьмя строками и пятью столбцами значений. Каждая строка становится серией диаграммы. `ChartSheet` выбирается как активный лист перед сохранением книги.

Книга явно сохраняется в формате XLSX, соответствующим расширению `xlsx`, переданному в [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG загружается напрямую из потока без промежуточного преобразования в bitmap. Присвоение через [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) заменяет стандартный заполнитель OLE.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Отрисовать предварительный просмотр диаграммы и отдельно сериализовать редактируемую книгу.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Поместить предварительный просмотр в слайд, не изменяя его соотношение сторон.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Ожидаемый результат**

`OutputChart.pptx` содержит один слайд с встроенной книгой Excel и предварительным просмотром диаграммы. Книга содержит исходные данные и столбчатую диаграмму с четырьмя сериями. Предпросмотр центрирован на слайде и сохраняет свои пропорции.

![Столбчатая диаграмма Excel, отображаемая как предварительный просмотр встроенной книги](excel-chart-ole-preview.png)

В совместимой настольной среде PowerPoint с установленным Excel двойным щелчком по объекту активируйте и редактируйте встроенную книгу. Активация и редактирование зависят от поддержки OLE в хост‑приложении и настроек безопасности.

## **Часто задаваемые вопросы**

**Зачем нужен предварительный просмотр изображения?**  
Встроенная книга и её предварительный просмотр на слайде — это отдельный контент. Предоставьте изображение диаграммы, чтобы слайд отображал диаграмму вместо стандартного заполнителя «EMBEDDED OLE OBJECT». См. [Object Preview Issue when Adding OleObjectFrame](/slides/ru/net/object-preview-issue-when-adding-oleobjectframe/).

**Обновляется ли предварительный просмотр автоматически при изменении книги программно?**  
Считайте предварительный просмотр снимком. При программном обновлении данных книги необходимо заново сгенерировать изображение диаграммы и заменить как предварительный просмотр, так и данные встроенной книги.

**Можно ли использовать XLS вместо XLSX?**  
Да. Сохраните книгу в формате XLS и используйте `xls` как расширение встроенных данных. Расширение должно соответствовать фактическому формату книги; изменение только расширения не преобразует данные.

**Почему объект может менять размер после активации?**  
Хост‑приложение может обновить представление OLE‑объекта при активации книги. И диапазон отображения OLE книги, и размеры рамки на слайде имеют значение. См. [Working Solution for Chart Resizing in PPTX](/slides/ru/net/working-solution-for-chart-resizing-in-pptx/).

## **Связанные разделы**

- [Рабочее решение для изменения размера диаграммы в PPTX](/slides/ru/net/working-solution-for-chart-resizing-in-pptx/)
- [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/net/object-preview-issue-when-adding-oleobjectframe/)
- [Автоматическое обновление OLE‑объектов с помощью надстройки PowerPoint](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)