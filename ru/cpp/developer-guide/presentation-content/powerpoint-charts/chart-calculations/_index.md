---
title: Оптимизация вычислений диаграмм для презентаций на C++
linktitle: Вычисления диаграмм
type: docs
weight: 50
url: /ru/cpp/chart-calculations/
keywords:
- вычисления диаграмм
- элементы диаграммы
- позиция элемента
- фактическая позиция
- дочерний элемент
- родительский элемент
- значения диаграммы
- фактическое значение
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Понимание вычислений диаграмм, обновления данных и контроля точности в Aspose.Slides для C++ для PPT и PPTX, с практическими примерами кода на C++."
---

## **Вычисление фактических значений элементов диаграммы**
Aspose.Slides for C++ предоставляет простой API для получения этих свойств. Это поможет вам вычислить фактические значения элементов диаграммы. Фактические значения включают позицию элементов, реализующих интерфейс IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) и фактические значения осей (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Сохранение презентации
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **Вычисление фактической позиции родительских элементов диаграммы**
Aspose.Slides for C++ предоставляет простой API для получения этих свойств. Методы IActualLayout предоставляют информацию о фактической позиции родительского элемента диаграммы. Необходимо предварительно вызвать метод IChart::ValidateChartLayout(), чтобы заполнить свойства фактическими значениями.
``` cpp
// Создание пустой презентации
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```


## **Скрытие элементов диаграммы**
Эта тема поможет вам понять, как скрыть информацию в диаграмме. С помощью Aspose.Slides for C++ вы можете скрыть **Заголовок, Вертикальную ось, Горизонтальную ось** и **Линии сетки** в диаграмме. Ниже приведён пример кода, показывающий, как использовать эти свойства.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Установка диапазона данных для диаграммы**
Aspose.Slides for C++ предоставил самый простой API для установки диапазона данных диаграммы самым удобным способом. Чтобы установить диапазон данных для диаграммы:

- Откройте экземпляр класса Presentation, содержащий диаграмму.
- Получите ссылку на слайд, используя его Index.
- Пройдитесь по всем фигурам, чтобы найти нужную диаграмму.
- Получите доступ к данным диаграммы и задайте диапазон.
- Сохраните изменённую презентацию в файл PPTX.

Примеры кода ниже показывают, как обновить диаграмму.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**Работают ли внешние рабочие книги Excel в качестве источника данных и как это влияет на пересчёт?**

Да. Диаграмма может ссылаться на внешнюю рабочую книгу: при подключении или обновлении внешнего источника формулы и значения берутся из этой книги, и диаграмма отражает изменения во время операций открытия/редактирования. API позволяет вам [указать внешний рабочий файл](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) пути и управлять связанными данными.

**Могу ли я вычислять и отображать линии тренда без самостоятельной реализации регрессии?**

Да. [Линии тренда](/slides/ru/cpp/trend-line/) (линейные, экспоненциальные и другие) добавляются и обновляются Aspose.Slides; их параметры автоматически пересчитываются из данных рядов, поэтому вам не требуется реализовывать собственные расчёты.

**Если презентация содержит несколько диаграмм с внешними ссылками, могу ли я управлять тем, какую рабочую книгу использует каждая диаграмма для вычисляемых значений?**

Да. Каждая диаграмма может указывать на свою собственную [внешнюю рабочую книгу](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/), либо вы можете создавать/заменять внешнюю рабочую книгу для каждой диаграммы независимо от остальных.