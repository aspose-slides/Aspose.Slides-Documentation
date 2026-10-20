---
title: Рабочее решение для изменения размера диаграмм в PPTX
type: docs
weight: 60
url: /ru/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE‑объект
- встраивание диаграммы
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Исправьте непредвиденное изменение размера диаграммы в PPTX при использовании встроенных OLE‑объектов Excel с Aspose.Slides для .NET. Установите фиксированные размеры диаграммы, чтобы сохранить согласованность размеров диаграммы и кадра OLE."
---
## **Фон**

Диаграммы Excel, встроенные как OLE‑объекты в презентации PowerPoint с использованием компонентов Aspose, могут менять размер после первого активации. Это может вызвать заметную разницу во внешнем виде диаграммы до и после активации. Эта статья объясняет, почему происходит изменение размера, и показывает, как предотвратить его, сопоставив фиксированные размеры диаграммы с OLE‑кадром.

В статье [Создание диаграмм Excel и их вставка в качестве OLE‑объектов в презентации](/slides/ru/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells для .NET и встроить её в презентацию PowerPoint с помощью Aspose.Slides для .NET. Чтобы решить проблему [проблема предварительного просмотра объекта](/slides/ru/net/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение диаграммы кадру OLE‑объекта диаграммы. В полученной презентации, когда вы дважды щёлкните по кадру OLE‑объекта, отображающему изображение диаграммы, активируется диаграмма Excel. Пользователи могут редактировать встроенную книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной книги. Размер кадра OLE‑объекта меняется, когда пользователь возвращается к слайду, и коэффициент изменения размера варьируется в зависимости от исходных размеров как кадра OLE‑объекта, так и встроенной книги Excel.

## **Причина изменения размера**

Встроенная книга Excel имеет собственные размеры окна, которые Excel пытается сохранить при первой активации объекта. Кадр OLE на слайде имеет независимо определённые размеры. Когда книга Excel активируется, Excel и PowerPoint согласовывают размер объекта, чтобы сохранить его пропорции в процессе встраивания. Различия между окном книги и кадром OLE могут привести к изменению размера объекта.

## **Рабочее решение**

Сопоставьте размер диаграммы с кадром OLE на слайде и держите размеры диаграммы независимыми от окна книги. Это решение работает как с новой презентацией, так и с существующим шаблоном.

Для примера требуются Aspose.Cells для .NET и Aspose.Slides для .NET. Он создаёт простую столбчатую диаграмму на активном листе диаграмм и встраивает книгу в формате XLS. Предпросмотр изображения диаграммы не задаётся; диаграмма становится видимой, когда OLE‑объект активируется в PowerPoint.

Пример создаёт новую презентацию с OLE‑кадром размером 9.5 × 4‑inch, расположенным на 0.5 inch от левого края и 1 inch от верха. Координаты и размеры слайда указаны в пунктах (72 пункта на дюйм). Для существующей презентации см. [Использовать шаблон](#use-a-template).

## **Установить фиксированный размер диаграммы**

Установите [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) в значение false, чтобы размеры диаграммы были независимы от окна книги. Установите размеры [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) через [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) и [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), преобразуя пункты в пиксели с использованием 96 пикселей на дюйм: кадр размером 684 × 288 пунктов соответствует диаграмме размером 912 × 384 пикселя. Установите [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) в пользовательское значение [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). В примере книга встраивается с помощью [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) и сохраняется презентация с OLE‑кадром размером 9.5 × 4‑inch.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Координаты и размеры слайда указаны в пунктах (72 пункта на дюйм).
var width = 684f; // 9,5 дюйма.
var height = 288f; // 4 дюйма.

chart.SizeWithWindow = false;
// Преобразовать пункты в пиксели диаграммы, используя 96 пикселей на дюйм.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Использовать шаблон**

Логика масштабирования та же для существующей презентации. Чтобы адаптировать пример:

1. Загрузите презентацию‑шаблон вместо создания пустой презентации.
2. Убедитесь, что на первом слайде присутствует как минимум три фигуры, затем используйте фигуру с индексом 2 в качестве заполнителя.
3. Возьмите ширину и высоту кадра из этой фигуры вместо фиксированных значений 684 и 288. Оставьте вычисления размеров без изменений.
4. Добавьте OLE‑кадр в позицию заполнителя вместо фиксированных координат 36 и 72.
5. Удалите заполнитель перед сохранением презентации.

## **Вопросы и ответы**

**Почему моя встроенная диаграмма Excel меняет размер после активации в PowerPoint?**

Это происходит потому, что Excel пытается восстановить исходный размер окна при первой активации, тогда как кадр OLE‑объекта в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может привести к изменению размера.

**Как сохранить согласованность размеров диаграммы и кадра OLE?**

Установите фиксированные размеры диаграммы, соответствующие кадру OLE, и используйте пользовательский размер печати диаграммы перед встраиванием книги. Приведённый выше пример показывает необходимые настройки и преобразования единиц.

**Достаточно ли сопоставить размер окна книги?**

Сопоставление только размера окна книги надёжно не предотвращает изменение размера кадра OLE после активации. Используйте фиксированные размеры диаграммы, как показано в примере.

**Работает ли это решение как с презентациями на основе шаблонов, так и с новыми презентациями?**

Да. Для шаблона используйте размеры и позицию заполнителя. Для новой презентации указывайте размеры и позицию кадра напрямую.

**Могу ли я использовать этот пример с диаграммами, созданными в других электронных таблицах?**

Пример использует книгу Excel, созданную с помощью Aspose.Cells. Он не демонстрирует поведение активации для других программ работы с электронными таблицами.

## **Связанные разделы**

- [Создание диаграмм Excel и их вставка в качестве OLE‑объектов в презентации](/slides/ru/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Автоматическое обновление OLE‑объектов с помощью надстройки PowerPoint](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)