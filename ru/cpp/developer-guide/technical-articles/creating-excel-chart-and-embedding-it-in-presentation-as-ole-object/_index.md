---
title: Создание диаграмм Excel и их встраивание в презентации как OLE-объекты
type: docs
weight: 40
url: /ru/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Диаграмма Excel
- встроить диаграмму
- OLE-объект
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создайте диаграмму Excel с помощью Aspose.Cells для C++ и встроите рабочую книгу в презентацию PowerPoint с использованием Aspose.Slides, включая предварительный просмотр диаграммы."
---
## **Обзор**

В этой статье показано, как создать столбчатую диаграмму Excel с помощью Aspose.Cells для C++ и встроить её рабочую книгу в презентацию PowerPoint с помощью Aspose.Slides для C++. Встроенная рабочая книга содержит как исходные данные, так и диаграмму. Отдельный PNG‑просмотр отображает диаграмму на слайде до активации OLE‑объекта.

В результате получается встроенный объект Excel, а не нативная диаграмма PowerPoint. Редактирование рабочей книги через OLE требует настольного приложения, поддерживающего активацию OLE, и совместимой установки Excel.

## **Требования**

Настройте ваш проект C++ с заголовками и библиотеками Aspose.Cells для C++ и Aspose.Slides для C++. Поместите пример кода в точку входа вашего приложения, разместив объявления include на уровне файла. Для создания презентации с помощью этих библиотек Microsoft Office не требуется.

Входные файлы не требуются: пример создает данные и диаграмму в памяти, затем записывает `OutputChart.pptx` в текущий рабочий каталог. Применяйте лицензии для обоих продуктов при работе вне режима оценки.

## **Как работает встраивание**

1. Создайте рабочую книгу с листом данных и листом диаграммы.  
2. Сделайте лист диаграммы активным, чтобы рабочая книга открывалась на диаграмме.  
3. Установите диапазон отображения OLE рабочей книги и визуализируйте диаграмму в PNG.  
4. Сохраните рабочую книгу как XLSX в памяти и встроите эти байты в слайд.  
5. Назначьте PNG в качестве предварительного просмотра OLE‑объекта и сохраните презентацию как PPTX.

Диапазон отображения рабочей книги и рамка на слайде выполняют разные функции. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) принимает нулевые индексы начальной/конечной строки и столбца. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) же принимает верхнюю строку, левый столбец, нижнюю строку и правый столбец. В примере в качестве правых нижних границ используется индекс строки 55 и индекс столбца 25; эти значения являются параметрами макета, а не количеством строк или столбцов данных.

Рамка слайда использует единицы измерения — пункты. Пример помещает её в границы слайда и центрирует, сохраняет соотношение сторон PNG, вместо того чтобы растягивать предварительный просмотр для заполнения слайда.

## **Создание и встраивание диаграммы**

Следующий полный пример заполняет `DataSheet` четырьмя строками и пятью столбцами значений. Каждая строка становится серией диаграммы. `ChartSheet` выбран как активный лист перед сохранением рабочей книги.

Рабочая книга явно сохраняется как XLSX, соответствуя расширению `xlsx`, переданному в [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG загружается из потока в памяти без промежуточного преобразования в bitmap. Aspose.Cells возвращает вектор байтов, который пример копирует в массивный тип, принимаемый Aspose.Slides. Инициализируйте Aspose.Cells перед использованием его объектов и освобождайте ресурсы после их уничтожения. Назначение через [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) заменяет стандартный заполнитель OLE.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Инициализировать Cells перед созданием любых его объектов.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Отобразить предварительный просмотр диаграммы и отдельно сериализовать редактируемую рабочую книгу.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Скопировать буферы Cells в тип массива, используемый Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Поместить предварительный просмотр в слайд без изменения его пропорций.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Освободить ресурсы Cells после уничтожения всех объектов Cells.
Aspose::Cells::Cleanup();
```

## **Ожидаемый результат**

`OutputChart.pptx` содержит один слайд с встроенной рабочей книгой Excel и предварительным просмотром диаграммы. Рабочая книга содержит исходные данные и столбчатую диаграмму с четырьмя сериями. Предпросмотр центрирован на слайде и сохраняет свои пропорции.

![Столбчатая диаграмма Excel, отображаемая как предварительный просмотр встроенной рабочей книги](excel-chart-ole-preview.png)

В совместимой настольной среде PowerPoint с установленным Excel двойным щелчком по объекту можно активировать и редактировать встроенную рабочую книгу. Активация и редактирование зависят от поддержки OLE и настроек безопасности хост‑приложения.

## **Вопросы и ответы**

**Зачем требуется изображение предварительного просмотра?**  
Встроенная рабочая книга и её предварительный просмотр на слайде — отдельный контент. Предоставьте изображение диаграммы, чтобы слайд показывал диаграмму вместо стандартного заполнителя «EMBEDDED OLE OBJECT». См. [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Обновляется ли предварительный просмотр автоматически при изменении рабочей книги в коде?**  
Считайте предварительный просмотр как снимок. При программном обновлении данных рабочей книги необходимо заново создать изображение диаграммы и заменить как предварительный просмотр, так и данные встроенной рабочей книги.

**Можно ли использовать XLS вместо XLSX?**  
Да. Сохраните рабочую книгу в формате XLS и используйте `xls` в качестве расширения встроенных данных. Расширение должно соответствовать реальному формату рабочей книги; изменение только расширения не конвертирует данные.

**Почему объект может изменить размер после активации?**  
Хост‑приложение может обновлять представление OLE‑объекта при активации рабочей книги. И диапазон отображения OLE рабочей книги, и размеры рамки на слайде имеют значение. См. [Рабочее решение для изменения размера диаграммы в PPTX](/slides/ru/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Связанные разделы**

- [Рабочее решение для изменения размера диаграммы в PPTX](/slides/ru/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/cpp/object-preview-issue-when-adding-oleobjectframe/)