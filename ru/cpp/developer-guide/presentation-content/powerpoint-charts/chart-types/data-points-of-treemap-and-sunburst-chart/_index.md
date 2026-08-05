---
title: Настройка точек данных в диаграммах Treemap и Sunburst на C++
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- диаграмма Treemap
- диаграмма Sunburst
- иерархическая диаграмма
- точка данных
- метка данных
- цвет ветки
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как создавать иерархические данные и настраивать уровни, подписи и цвета в диаграммах Treemap и Sunburst с помощью Aspose.Slides для C++."
---
## **Обзор**

Диаграммы Treemap и Sunburst отображают одинаковый тип иерархических данных, но используют разные макеты. Treemap рисует иерархию как вложенные прямоугольники, площади которых представляют значения листьев. Sunburst отображает её в виде концентрических колец: группы верхнего уровня находятся ближе к центру, а категории листьев — на внешнем кольце.

В Aspose.Slides for C++ каждый числовой показатель представляет собой [IChartDataPoint](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/). Его метод [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) предоставляет доступ к листу и его родительским группам. Эта статья объясняет это сопоставление и показывает, как создать и оформить оба типа диаграмм из одних и тех же примерных данных.

![Диаграмма Treemap с ветвями Consumer и Business](treemap-hierarchy.png)

![Диаграмма Sunburst с той же иерархией Consumer и Business](sunburst-hierarchy.png)

## **Понимание категорий, точек данных и уровней**

В примере ниже три уровня категорий и один числовой ряд:

| Ветка | Стебель | Лист | Выручка |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Каждая строка создает одну категорию‑лист и одну точку данных. Уровни группировки категорий описывают путь от этого листа к его родителям. Для первой строки путь выглядит так: `Consumer > Computers > Laptops`.

Индексы, возвращаемые [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), идут от листа к корню:

| Индекс `get_DataPointLevels()` | Логический уровень | Отображение Treemap | Отображение Sunburst |
| ---: | --- | --- | --- |
| `0` | Leaf | Прямоугольник значения | Сегмент внешнего кольца |
| `1` | Stem | Прямоугольник родителя или заголовок | Сегмент среднего кольца |
| `2` | Branch | Прямоугольник верхнего уровня или заголовок | Сегмент внутреннего кольца |

Этот порядок одинаков для обоих типов диаграмм, хотя их визуальные макеты различаются. Родительский сегмент разделяется несколькими листьями. Чтобы отформатировать его, используйте соответствующий уровень первой точки данных в этой группе. Например, ветка `Consumer` начинается с точки `Laptops`, а стебель `Software` — с точки `Licenses`. Хранить ссылки на эти точки проще и безопаснее, чем использовать необъяснённые выражения типа `dataPoints->idx_get(0)` или `dataPoints->idx_get(6)`.

## **Создание и настройка обоих типов диаграмм**

Ниже приведён полный пример, который создаёт Treemap на первом слайде и Sunburst на втором слайде. Он строит иерархию, отображает значение для `Tablets`, задаёт фиксированные цвета выбранным уровням, форматирует подпись ветки и сохраняет презентацию.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Добавьте листовые категории. Элемент группировки устанавливается только при начале новой группы;
    // следующие категории остаются в этой группе, пока не будет установлен другой элемент.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Показать категорию и значение у листа Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Форматировать ветку Consumer через первый лист в этой ветке.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Форматировать стебель Software через первый лист в этом стебле.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout влияет на метки родителя в Treemap; Sunburst использует кольцевые сегменты.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ячейки категорий и ячейки значений используют одну и ту же строку листа, поэтому их позиции в коллекции остаются согласованными. Когда вы работаете с уже существующей диаграммой, а не создаёте новую, сначала изучите строки категорий и сохраните именованные ссылки на точки данных и уровни, которые планируете форматировать.

## **Поведение и практические соображения**

### **Отличия Treemap и Sunburst**

- Treemap использует площадь для передачи значения и вложенные прямоугольники для передачи иерархии. Метод [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) управляет отображением меток родителей в этом типе диаграмм.
- Sunburst использует угол для передачи значения и глубину кольца для передачи иерархии. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) не управляет метками его колец.
- Оба типа диаграмм используют одинаковые уровни группировки категорий и одинаковый порядок лист‑родитель, возвращаемый [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), поэтому код построения данных и форматирования уровней может быть общим.
- Значения родителей вычисляются из их дочерних листьев. Не добавляйте отдельные числовые точки для веток или стеблей.

### **Сортировка и порядок сегментов**

Движок макета диаграммы определяет окончательное размещение прямоугольников и кольцевых сегментов. Сгруппируйте связанные строки категорий перед их добавлением, но не полагайтесь на конкретное положение прямоугольника или начальный угол. Если порядок имеет смысл, включите его в подписи или используйте тип диаграммы с явной осью категорий.

### **Тема и фиксированные цвета**

Неоформленные уровни диаграммы наследуют цвета из темы презентации. Пример использует явные RGB‑заливки для предсказуемого вывода. Если диаграмма должна подстраиваться под изменения темы, используйте цветовые схемы вместо фиксированных RGB‑значений и избегайте переопределения каждого уровня. Также проверяйте контраст подписи после изменения заливки ветки или стебля.

### **Подписи и доступное пространство**

PowerPoint может скрывать или усекать подписи, когда сегмент слишком мал. Увеличение размеров диаграммы, сокращение названий категорий или отображение меньшего количества полей подписи обычно дают более понятный результат. Подпись может объединять название категории, название ряда и значение через [IDataLabelFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/idatalabelformat/), но включение всех полей часто делает иерархические диаграммы трудными для восприятия.

### **Экспорт и визуализация**

Сохранение в PPTX оставляет диаграмму редактируемой. При рендеринге презентации Aspose.Slides в PDF или изображение поддерживаемые заливки и настройки подписи отображаются вместе с диаграммой. Подстановка шрифтов и небольшие различия в доступном пространстве макета могут изменить перенос строк или видимость подписи, поэтому установите требуемые шрифты и проверьте важные цели экспорта.

## **Часто задаваемые вопросы**

**Почему изменение уровня родителя влияет на несколько листьев?**

Ветка или стебель — это общий визуальный сегмент. Его [IChartDataPointLevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichartdatapointlevel/) можно достичь через дочерний лист, но форматирование относится к общему родительскому сегменту, а не только к этому листу.

**Почему отсутствует подпись данных?**

Сначала включите требуемые поля в объекте подписи [IDataLabelFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/idatalabelformat/). Затем проверьте, хватает ли сегменту места. Макет подписи родителя в Treemap, размеры диаграммы, длина подписи, размер шрифта и количество включённых полей влияют на возможность отображения подписи.

**Могу ли я задать точный порядок или координаты сегментов?**

Вы можете контролировать порядок строк‑источников и держать каждую группу сплошной, но не можете задать точные прямоугольники Treemap или углы Sunburst. Движок макета вычисляет их из иерархии, значений и доступного пространства.

**Почему цвета меняются после изменения темы презентации?**

Заливки, основанные на теме, предназначены следовать палитре презентации. Примените явные RGB‑цвета к уровням, которые должны оставаться фиксированными, либо сохраняйте цветовые схемы, если предпочтительно адаптировать их к новой теме.

**Сохранится ли пользовательское форматирование при экспорте в PDF и изображения?**

Да, поддерживаемые заливки диаграммы и настройки подписи включаются в процесс рендеринга. Для согласованных результатов на разных системах сделайте нужные шрифты доступными и протестируйте конечный размер экспорта, поскольку подгонка подписи зависит от макета.

## **Смотрите также**

- [Создать диаграммы Treemap](/slides/ru/cpp/create-chart/#create-tree-map-charts)
- [Создать диаграммы Sunburst](/slides/ru/cpp/create-chart/#create-sunburst-charts)
- [Экспортировать диаграммы презентаций](/slides/ru/cpp/export-chart/)
- [Управление темами презентаций](/slides/ru/cpp/presentation-theme/)