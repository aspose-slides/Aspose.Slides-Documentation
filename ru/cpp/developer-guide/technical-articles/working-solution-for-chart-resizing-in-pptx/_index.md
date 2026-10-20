---
title: Рабочее решение проблемы изменения размера диаграммы в PPTX
type: docs
weight: 60
url: /ru/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- изменение размера диаграммы
- диаграмма Excel
- OLE‑объект
- встраивание диаграммы
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Исправьте неожиданное изменение размеров диаграммы в PPTX при использовании встроенных OLE‑объектов Excel с Aspose.Slides для C++. Установите фиксированные размеры диаграммы, чтобы сохранить согласованность размеров диаграммы и OLE‑рамки."
---
## **Фон**

Диаграммы Excel, встроенные как OLE‑объекты в презентации PowerPoint с использованием компонентов Aspose, могут изменять размер после первой активации. Это может вызвать заметную разницу во внешнем виде диаграммы до и после активации. В этой статье объясняется, почему происходит изменение размеров, и показывается, как предотвратить его, подогнав фиксированные размеры диаграммы под OLE‑рамку.

В статье [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) мы объяснили, как создать диаграмму Excel с помощью Aspose.Cells for C++ и встроить её в презентацию PowerPoint с использованием Aspose.Slides for C++. Чтобы решить проблему [проблема предварительного просмотра объекта](/slides/ru/cpp/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение диаграммы OLE‑рамке объекта диаграммы. В полученной презентации, когда вы дважды щёлкните OLE‑рамку, отображающую изображение диаграммы, активируется диаграмма Excel. Пользователи могут редактировать встроенную книгу Excel, а затем вернуться к слайду, щёлкнув вне активированной книги. Размер OLE‑рамки меняется при возвращении к слайду, и коэффициент изменения зависит от исходных размеров как OLE‑рамки, так и встроенной книги Excel.

## **Причина изменения размеров**

Встроенная книга Excel имеет собственные размеры окна, которые Excel пытается сохранить при первой активации объекта. OLE‑рамка на слайде имеет независимо определённые размеры. Когда книга Excel активируется, Excel и PowerPoint согласовывают размер объекта, чтобы сохранить его пропорции в процессе встраивания. Различия между окном книги и OLE‑рамкой могут приводить к изменению размера объекта.

## **Рабочее решение**

Подогнать размер диаграммы к OLE‑рамке на слайде и сделать размеры диаграммы независимыми от окна книги. Это решение работает как с новой презентацией, так и с существующим шаблоном.

Для примера требуются Aspose.Cells for C++ и Aspose.Slides for C++. Он создаёт простую столбчатую диаграмму на активном листе диаграмм и встраивает книгу в формате XLS. Изображение предварительного просмотра диаграммы не задаётся; диаграмма становится видимой, когда OLE‑объект активируется в PowerPoint.

Поместите пример кода в точку входа вашего приложения, разместив объявления include на уровне файла. Инициализируйте Aspose.Cells перед созданием его объектов и освобождайте ресурсы после их уничтожения. Пример копирует вектор байтов книги, возвращённый Aspose.Cells, в массивный тип, принимаемый Aspose.Slides.

Пример создаёт новую презентацию с OLE‑рамкой размером 9,5 × 4 дюйма, расположенной на полдюйма от левого края и в 1 дюйме от верхнего. Координаты и размеры слайда указаны в пунктах (72 пункта на дюйм). Для существующей презентации см. раздел [Использовать шаблон](#use-a-template).

## **Установить фиксированный размер диаграммы**

Установите [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) в значение false, чтобы размеры диаграммы были независимы от окна книги. Задайте размеры [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) через [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) и [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), преобразуя пункты в пиксели при 96 пикселях на дюйм: рамка 684 × 288 пунктов соответствует диаграмме 912 × 384 пикселя. Установите [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) в значение Custom типа [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). Пример встраивает книгу с помощью [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) и сохраняет презентацию с OLE‑рамкой 9,5 × 4 дюйма.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Координаты и размеры слайда указаны в пунктах (72 пункта на дюйм).
    auto width = 684.f; // 9,5 дюйма.
    auto height = 288.f; // 4 дюйма.

    chart.SetSizeWithWindow(false);
    // Преобразуйте пункты в пиксели диаграммы, используя 96 пикселей на дюйм.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Скопируйте байтовый вектор Cells в тип массива, принимаемый Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Использовать шаблон**

Логика расчёта размеров такая же для существующей презентации. Чтобы адаптировать пример:

1. Загрузите шаблон презентации вместо создания пустой презентации.  
2. Убедитесь, что на первом слайде имеется как минимум три фигуры, затем используйте фигуру с индексом 2 в качестве заполнителя.  
3. Возьмите ширину и высоту рамки из этой фигуры вместо фиксированных значений 684 и 288. Оставьте расчёты размеров без изменений.  
4. Добавьте OLE‑рамку в позицию заполнителя вместо фиксированных координат 36 и 72.  
5. Удалите заполнитель перед сохранением презентации.

## **Часто задаваемые вопросы**

**Почему встроенная диаграмма Excel меняет размер после её активации в PowerPoint?**  
Это происходит потому, что Excel пытается восстановить исходный размер окна при первой активации, тогда как OLE‑рамка в PowerPoint имеет собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может привести к изменению размеров.

**Как обеспечить согласованность размеров диаграммы и OLE‑рамки?**  
Установите фиксированные размеры диаграммы, соответствующие OLE‑рамке, и используйте пользовательский размер печати диаграммы перед встраиванием книги. Приведённый выше пример показывает необходимые настройки и преобразования единиц.

**Достаточно ли подогнать размер окна книги?**  
Подгонка только окна книги надёжно не предотвращает изменение размера OLE‑рамки после активации. Используйте фиксированные размеры диаграммы, как показано в примере.

**Работает ли это решение как для шаблонных, так и для новых презентаций?**  
Да. Для шаблона используйте размеры и позицию заполнителя. Для новой презентации укажите размеры и позицию рамки напрямую.

**Можно ли использовать этот пример с диаграммами, созданными в других табличных программах?**  
Пример использует книгу Excel, созданную с помощью Aspose.Cells. Он не демонстрирует поведение активации для других табличных программ.

## **Связанные разделы**

- [Создать диаграммы Excel и встроить их как OLE‑объекты в презентации](/slides/ru/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)