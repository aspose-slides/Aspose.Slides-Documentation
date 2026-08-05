---
title: "Настройка таблиц данных диаграмм в презентациях с использованием C++"
linktitle: "Таблица данных"
type: docs
url: /ru/cpp/chart-data-table/
keywords:
- "данные диаграммы"
- "таблица данных"
- "свойства шрифта"
- "PowerPoint"
- "презентация"
- "C++"
- "Aspose.Slides"
description: "Настройте таблицы данных диаграмм в C++ для PPT и PPTX с помощью Aspose.Slides, чтобы повысить эффективность и привлекательность презентаций."
---
## **Обзор**

В этой статье объясняется, как работать с таблицами данных диаграмм в Aspose.Slides. Показано, как отобразить таблицу данных для диаграммы и настроить её форматирование текста, задав свойства шрифта, такие как полужирный стиль и высота шрифта. В примере демонстрируется загрузка презентации, добавление диаграммы, включение таблицы данных диаграммы, применение настроек шрифта и сохранение обновлённой презентации.

Aspose.Slides for C++ позволяет изменять свойства шрифта для таблицы данных диаграммы.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation).
1. Добавьте диаграмму на слайд.
1. Установите таблицу диаграммы.
1. Задайте высоту шрифта.
1. Сохраните изменённую презентацию.

Ниже приведён пример.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Часто задаваемые вопросы**

**Могу ли я отображать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [ключи легенды](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/datatable/set_showlegendkey/), и вы можете включать или отключать их.

**Будет ли таблица данных сохранена при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/cpp/convert-powerpoint-to-html/)/[image](/slides/ru/cpp/convert-powerpoint-to-png/) включает диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из шаблонного файла?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, вы можете проверить и изменить, отображается ли таблица данных, используя свойства диаграммы ([отображается](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chart/set_hasdatatable/)).

**Как быстро найти, какие диаграммы в файле имеют включённую таблицу данных?**

Проверьте свойство каждой диаграммы, указывающее, отображается ли таблица данных ([отображается](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chart/get_hasdatatable/)), и пройдитесь по слайдам, чтобы определить диаграммы, у которых она включена.