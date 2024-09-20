---
title: Таблица данных графика
type: docs
url: /cpp/chart-data-table/
---

## **Установить свойства шрифта для таблицы данных графика**
Aspose.Slides для C++ позволяет изменять свойства шрифта для таблицы данных графика.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Добавьте график на слайд.
1. Установите таблицу графика.
1. Установите высоту шрифта.
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