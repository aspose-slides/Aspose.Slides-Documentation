---
title: Маркер данных диаграммы
type: docs
url: /cpp/chart-data-marker/
---

## **Установить маркер диаграммы**
Aspose.Slides для C++ предоставляет простой API для автоматической установки маркера серии диаграммы. В следующей функции каждый маркер серии диаграммы будет автоматически получать различный символ по умолчанию.

Пример кода ниже демонстрирует, как автоматически установить маркер серии диаграммы.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **Установить параметры маркера диаграммы**
Маркеры могут быть установлены на точках данных диаграммы внутри конкретной серии. Чтобы установить параметры маркера диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Создайте диаграмму по умолчанию.
- Установите изображение.
- Возьмите первую серию диаграммы.
- Добавьте новую точку данных.
- Запишите презентацию на диск.

В приведенном ниже примере мы установили параметры маркера диаграммы на уровне точек данных.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **Установить маркер диаграммы на уровне точек данных серии**
Теперь маркеры могут быть установлены на точках данных диаграммы внутри конкретной серии. Чтобы установить параметры маркера диаграммы, выполните следующие шаги:

- Создайте экземпляр класса Presentation.
- Создайте диаграмму по умолчанию.
- Установите изображение.
- Возьмите первую серию диаграммы.
- Добавьте новую точку данных.
- Запишите презентацию на диск.

В приведенном ниже примере мы установили параметры маркера диаграммы на уровне точек данных.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptionsonSeries-SetMarkerOptionsonSeries.cpp" >}}



## **Применить цвет к точкам данных**
Вы можете применить цвет к точкам данных на диаграмме, используя Aspose.Slides для C++. Классы [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) и **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)** добавлены для получения доступа к свойствам уровней точек данных. Эта статья демонстрирует, как вы можете получить доступ и применить цвет к точкам данных в диаграмме.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}