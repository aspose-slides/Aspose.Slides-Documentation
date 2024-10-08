---
title: Круговая диаграмма
type: docs
url: /ru/cpp/pie-chart/
---



## **Вторые параметры графиков для круговых диаграмм и круговых диаграмм со столбцами**
Aspose.Slides для C++ теперь поддерживает вторые параметры графиков для круговых диаграмм или круговых диаграмм со столбцами. В этой теме мы увидим на примере, как задать эти параметры с использованием Aspose.Slides. Чтобы задать свойства, выполните следующие шаги:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте график на слайд.
1. Укажите вторые параметры графиков.
1. Запишите презентацию на диск.

В приведенном ниже примере мы установили разные свойства для круговой диаграммы.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}



## **Установите автоматические цвета секторов круговой диаграммы**
Aspose.Slides для C++ предоставляет простой API для установки автоматических цветов секторов круговой диаграммы. Пример кода применяет указанные выше свойства.

1. Создайте экземпляр класса Presentation.
1. Получите доступ к первому слайду.
1. Добавьте график с данными по умолчанию.
1. Установите заголовок графика.
1. Установите первую серию на отображение значений.
1. Установите индекс таблицы данных графика.
1. Получите рабочий лист данных графика.
1. Удалите сгенерированные по умолчанию серии и категории.
1. Добавьте новые категории.
1. Добавьте новые серии.

Запишите измененную презентацию в файл PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}