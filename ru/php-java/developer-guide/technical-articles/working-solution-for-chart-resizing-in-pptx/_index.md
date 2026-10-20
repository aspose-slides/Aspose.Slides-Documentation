---
title: Рабочее решение проблемы изменения размера диаграмм в PPTX
type: docs
weight: 40
url: /ru/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграмм
- диаграмма Excel
- OLE объект
- вставить диаграмму
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Исправьте неожиданное изменение размера диаграммы в PPTX при использовании встроенных OLE объектов Excel с Aspose.Slides for PHP via Java. Установите фиксированные размеры диаграммы, чтобы сохранить согласованные размеры диаграммы и кадра OLE."
---
## **Обзор**

Диаграммы Excel, встроенные как OLE‑объекты в презентации PowerPoint с помощью компонентов Aspose, могут менять размер после первого активации. Это приводит к заметному различию во внешнем виде диаграммы до и после активации. В этой статье объясняется причина изменения размера и показывается, как предотвратить её, согласовав фиксированные размеры диаграммы с OLE‑кадром.

В статье [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for PHP via Java и встроить её в презентацию PowerPoint с помощью Aspose.Slides for PHP via Java. Чтобы решить проблему [просмотра объекта](/slides/ru/php-java/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение диаграммы кадру OLE‑объекта диаграммы. В полученной презентации, когда вы дважды щёлкаете кадр OLE‑объекта, отображающий изображение диаграммы, активируется диаграмма Excel. Пользователи могут редактировать встроенную книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной книги. Размер кадра OLE‑объекта изменяется, когда пользователь возвращается к слайду, и фактор изменения размера зависит от исходных размеров как кадра OLE‑объекта, так и встроенной книги Excel.

## **Причина изменения размера**

Встроенная книга Excel имеет собственные размеры окна, которые Excel пытается сохранить при первой активации объекта. Кадр OLE на слайде имеет независимо определённые размеры. Когда книга Excel активируется, Excel и PowerPoint согласовывают размер объекта, чтобы сохранить его пропорции в процессе встраивания. Различия между окном книги и кадром OLE могут приводить к изменению размера объекта.

## **Рабочее решение**

Согласуйте размер диаграммы с кадром OLE на слайде и сделайте размеры диаграммы независимыми от окна книги. Это решение работает как с новой презентацией, так и с существующим шаблоном.

Пример требует Aspose.Cells for PHP via Java и Aspose.Slides for PHP via Java. Настройте оба продукта с одним экземпляром PHP/Java Bridge, загрузите оба PHP‑обёртки и сделайте обе Java‑библиотеки доступными мосту. Входные файлы не требуются. Он создаёт простую столбчатую диаграмму на активном листе диаграмм и встраивает книгу в формате XLS. Изображение предпросмотра диаграммы не назначается; диаграмма становится видимой, когда OLE‑объект активируется в PowerPoint.

Пример создаёт новую презентацию с OLE‑кадром размером 9,5 × 4 дюйма, расположенным в 0,5 дюйма от левого края и в 1 дюйме от верхнего. Координаты и размеры слайда указаны в пунктах (72 пункта за дюйм). Для существующей презентации см. раздел [Использовать шаблон](#use-a-template).

## **Установить фиксированный размер диаграммы**

Установите [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) в false, чтобы размеры диаграммы были независимы от окна книги. Установите размеры [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) через [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) и [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), преобразуя пункты в пиксели с учётом 96 пикселей на дюйм: кадр 684 × 288 пунктов соответствует диаграмме 912 × 384 пикселей. Установите [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) в значение CUSTOM типа [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). Пример встраивает книгу с помощью [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) и сохраняет презентацию с OLE‑кадром 9,5 × 4 дюйма.

Числовые результаты Java преобразуются с помощью `java_values` перед использованием в качестве индексов PHP. Байт‑массив книги остаётся в массиве Java при передаче в [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Координаты и размеры слайда указаны в пунктах (72 пункта за дюйм).
        $width = 684; // 9,5 дюйма.
        $height = 288; // 4 дюйма.

        $chart->setSizeWithWindow(false);
        // Преобразуйте пункты в пиксели диаграммы, используя 96 пикселей за дюйм.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Использовать шаблон**

Логика определения размеров одинаковая для существующей презентации. Чтобы адаптировать пример:

1. Загрузите шаблон презентации вместо создания пустой презентации.  
2. Убедитесь, что первый слайд содержит как минимум три формы, затем используйте форму с индексом 2 в качестве заполнителя.  
3. Возьмите ширину и высоту кадра из этой формы вместо фиксированных значений 684 и 288. Оставьте расчёты размеров без изменений.  
4. Добавьте OLE‑кадр в позицию заполнителя вместо фиксированных координат 36 и 72.  
5. Удалите заполнитель перед сохранением презентации.

## **FAQ**

**Почему моя встроенная диаграмма Excel меняет размер после активации в PowerPoint?**

Это происходит потому, что Excel пытается восстановить исходный размер окна при первой активации, тогда как кадр OLE‑объекта в PowerPoint имеет собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может вызывать изменение размера.

**Как сохранить согласованные размеры диаграммы и OLE‑кадра?**

Установите фиксированные размеры диаграммы, соответствующие кадру OLE, и используйте пользовательский размер печати диаграммы перед встраиванием книги. Пример выше показывает необходимые настройки и преобразования единиц.

**Достаточно ли согласовать размер окна книги?**

Одного согласования размера окна книги недостаточно для надёжного предотвращения изменения размера кадра OLE после активации. Используйте фиксированные размеры диаграммы, как показано в примере.

**Работает ли это решение и с шаблонными, и с новыми презентациями?**

Да. Для шаблона используйте размеры и позицию заполнителя. Для новой презентации укажите размеры и позицию кадра напрямую.

**Можно ли использовать этот пример с диаграммами, созданными в других табличных программах?**

Пример использует книгу Excel, созданную с помощью Aspose.Cells. Он не демонстрирует поведение активации для других табличных программ.

## **Связанные разделы**

- [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)