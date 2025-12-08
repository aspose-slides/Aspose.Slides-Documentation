---
title: Таблица данных диаграммы
type: docs
url: /ru/nodejs-java/chart-data-table/
---

## **Установка параметров шрифта для таблицы данных диаграммы**

Aspose.Slides for Node.js via Java предоставляет поддержку изменения цвета категорий в серии.

1. Создать объект класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Добавить диаграмму на слайд.
1. Установить таблицу диаграммы.
1. Задать высоту шрифта.
1. Сохранить изменённую презентацию.

Ниже приведён пример.
```javascript
// Создание пустой презентации
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Могу ли я показывать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [legend keys](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datatable/setshowlegendkey/), и их можно включать или отключать.

**Сохранится ли таблица данных при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides отображает диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/ru/nodejs-java/convert-powerpoint-to-png/) включает диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из шаблонного файла?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, можно проверить и изменить, отображается ли таблица данных, с помощью свойства диаграммы [is shown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/).

**Как быстро найти, какие диаграммы в файле имеют включённую таблицу данных?**

Проверьте свойство каждой диаграммы, указывающее, отображается ли таблица данных [is shown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/), и пройдитесь по слайдам, чтобы определить диаграммы, у которых она включена.