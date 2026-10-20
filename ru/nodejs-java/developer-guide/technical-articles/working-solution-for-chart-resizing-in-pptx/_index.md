---
title: Рабочее решение проблемы изменения размеров диаграммы в PPTX
type: docs
weight: 40
url: /ru/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE-объект
- встраивание диаграммы
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Исправьте непредвиденное изменение размера диаграммы в PPTX при использовании встроенных объектов Excel OLE с Aspose.Slides for Node.js via Java. Установите фиксированные размеры диаграммы, чтобы сохранить согласованные размеры диаграммы и OLE-кадра."
---
## **Обзор**

Диаграммы Excel, встроенные как OLE‑объекты в презентации PowerPoint с использованием компонентов Aspose, могут изменять размер после первой активации. Это может вызвать заметную разницу во внешнем виде диаграммы до и после активации. В этой статье объясняется, почему происходит изменение размера, и показывается, как предотвратить его, сопоставив фиксированные размеры диаграммы с OLE‑кадром.

В [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for Node.js via Java и внедрить её в презентацию PowerPoint с помощью Aspose.Slides for Node.js via Java. Чтобы решить проблему [проблема предварительного просмотра объекта](/slides/ru/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение диаграммы кадру OLE‑объекта диаграммы. В полученной презентации, когда вы дважды щёлкните по кадру OLE‑объекта, отображающему изображение диаграммы, диаграмма Excel активируется. Пользователи могут редактировать встроенную книгу Excel и затем вернуться к слайду, щёлкнув вне активированной книги. Размер кадра OLE‑объекта изменяется, когда пользователь возвращается к слайду, и коэффициент изменения зависит от исходных размеров как кадра OLE‑объекта, так и встроенной книги Excel.

## **Причина изменения размера**

Встроенная книга Excel имеет собственные размеры окна, которые Excel пытается сохранить при первой активации объекта. Кадр OLE на слайде имеет независимо определённые размеры. Когда книга Excel активируется, Excel и PowerPoint согласовывают размер объекта, чтобы сохранить его пропорции в процессе встраивания. Различия между окном книги и кадром OLE могут привести к изменению размера объекта.

## **Рабочее решение**

Сопоставьте размер диаграммы с кадром OLE на слайде и сделайте размеры диаграммы независимыми от окна книги. Это решение работает как с новой презентацией, так и с существующим шаблоном.

Для примера требуются Aspose.Cells for Node.js via Java и Aspose.Slides for Node.js via Java. Установите пакеты Node.js `aspose.cells`, `aspose.slides.via.java` и `java`. Запустите два скрипта CommonJS ниже в отдельных процессах Node.js, используя один и тот же рабочий каталог, поскольку оба пакета Aspose инициализируют Java‑мост при загрузке. Он создаёт простую столбчатую диаграмму на активном листе диаграмм и встраивает книгу в формате XLS. Изображение предварительного просмотра диаграммы не назначается; диаграмма становится видимой, когда OLE‑объект активируется в PowerPoint.

Пример создаёт новую презентацию с OLE‑кадром размером 9,5 × 4 дюйма, расположенным на 0,5 дюйма от левого края и 1 дюйм от верхнего края. Координаты и размеры слайда указаны в пунктах (72 пункта = дюйм). Для существующей презентации см. [Использовать шаблон](#use-a-template).

## **Установить фиксированный размер диаграммы**

Установите [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) в false, чтобы размеры диаграммы были независимы от окна книги. Задайте размеры [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) через [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) и [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), преобразуя пункты в пиксели при 96 пикселях = дюйм: кадр 684 × 288 пунктов соответствует диаграмме 912 × 384 пикселя. Установите [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) в значение CUSTOM типа `PrintSizeType`. Пример встраивает книгу с помощью [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) и сохраняет презентацию с OLE‑кадром 9,5 × 4 дюйма.

Сохраните первый скрипт как `create-fixed-chart.js`. Он создаёт `chart-fixed-size.xls` с диаграммой 912 × 384 пикселя, соответствующей кадру 684 × 288 пунктов, используемому вторым скриптом. Входная книга не требуется.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Сопоставьте размеры OLE‑кадра в пунктах (72 пункта на дюйм).
    const width = 684; // 9,5 дюйма.
    const height = 288; // 4 дюйма.

    chart.setSizeWithWindow(false);
    // Преобразуйте пункты в пиксели диаграммы, используя 96 пикселей на дюйм.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Вся синхронная работа завершена; остановите процесс Java‑моста.
process.exit(0);
```

Сохраните второй скрипт как `embed-fixed-chart.js` и запустите его после `create-fixed-chart.js`. Он читает сгенерированную книгу XLS и сохраняет `chart-fixed-size.pptx`. Java‑мост требует явного массива байтов Java для данных книги и значений типа float Java для координат и размеров кадра. Расширение `xls` соответствует сохраняемому формату книги.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Координаты и размеры слайда указаны в пунктах (72 пункта на дюйм).
    const width = 684; // 9,5 дюйма.
    const height = 288; // 4 дюйма.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Вся синхронная работа завершена; остановите процесс Java‑моста.
process.exit(0);
```

## **Использовать шаблон**

Логика масштабирования одинакова для существующей презентации. Чтобы адаптировать пример:

1. Загрузите шаблон презентации вместо создания пустой презентации.  
2. Убедитесь, что на первом слайде присутствует как минимум три фигуры, затем используйте фигуру с индексом 2 в качестве заполнителя.  
3. Возьмите ширину и высоту кадра из этой фигуры вместо фиксированных значений 684 и 288. Используйте те же размеры в скрипте создания книги, оставив расчёты размеров без изменений, и заново сгенерируйте книгу XLS перед её встраиванием.  
4. Добавьте OLE‑кадр в позицию заполнителя вместо фиксированных координат 36 и 72.  
5. Удалите заполнитель перед сохранением презентации.

## **Часто задаваемые вопросы**

**Почему моя встроенная диаграмма Excel меняет размер после активации в PowerPoint?**

Это происходит потому, что Excel пытается восстановить исходный размер окна при первой активации, тогда как кадр OLE‑объекта в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может вызвать изменение размера.

**Как сохранить одинаковые размеры диаграммы и кадра OLE?**

Установите фиксированные размеры диаграммы, соответствующие кадру OLE, и используйте пользовательский размер печати диаграммы перед встраиванием книги. В примере показаны необходимые настройки и преобразования единиц.

**Достаточно ли сопоставить размер окна книги?**

Только сопоставление размера окна книги надёжно не предотвращает изменение размера кадра OLE после активации. Используйте фиксированные размеры диаграммы, как показано в примере.

**Работает ли это решение как с шаблонными, так и с новыми презентациями?**

Да. Для шаблона используйте размеры и позицию заполнителя. Для новой презентации указывайте размеры и позицию кадра напрямую.

**Можно ли использовать этот пример с диаграммами, созданными в других табличных программах?**

Пример использует книгу Excel, созданную с помощью Aspose.Cells. Он не демонстрирует поведение активации для других табличных программ.

## **Сопутствующие разделы**

- [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)