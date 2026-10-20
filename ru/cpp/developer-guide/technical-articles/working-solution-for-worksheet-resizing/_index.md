---
title: Рабочее решение для изменения размера листа
type: docs
weight: 130
url: /ru/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предпросмотра
- изменение размера изображения
- Excel
- рабочий лист
- PowerPoint
- презентация
- C++
- Aspose.Slides для C++
description: "Рабочее решение для изменения размера листа в презентациях PowerPoint с использованием C++"
---
{{% alert color="info" title="Note" %}}

Встраиваемые в презентацию PowerPoint листы Excel в виде OLE‑объектов с использованием компонентов Aspose могут изменять размер неожиданно после первого активации. Такое поведение создает заметную визуальную разницу между OLE‑объектом до и после активации. В этой статье объясняется проблема и описываются два способа её решения.

{{% /alert %}}

## **Предыстория**

В статье [Управление OLE](/slides/ru/cpp/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с использованием Aspose.Slides для C++. Чтобы решить [проблему предварительного просмотра объекта](/slides/ru/cpp/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа OLE‑кадру. В полученной презентации, когда вы дважды щелкнете OLE‑кадр, отображающий изображение листа, активируется рабочая книга Excel. Конечные пользователи могут вносить любые желаемые изменения в реальную рабочую книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной рабочей книги Excel. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размера OLE‑кадра и встроенной рабочей книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel есть собственный размер окна, она пытается сохранить оригинальный размер при первой активации. С другой стороны, OLE‑кадр имеет свой собственный размер. По словам Microsoft, когда рабочая книга Excel активируется, Excel и PowerPoint согласовывают размер, чтобы обеспечить правильные пропорции в процессе встраивания. Изменение размера происходит на основе различий между размером окна Excel и размером и положением OLE‑кадра.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Масштабировать OLE‑кадр в презентации PowerPoint, чтобы он соответствовал общей высоте и ширине выбранных строк и столбцов.
- Сохранить постоянный размер OLE‑кадра и масштабировать выбранные строки и столбцы, чтобы они помещались внутри него.

### **Scale the OLE Frame Size**

Этот подход устанавливает размер OLE‑кадра так, чтобы он соответствовал общей высоте и ширине выбранных строк и столбцов во встроенном листе Excel.

В примере загружается существующая рабочая книга Excel и выбираются первые 10 строк и 13 столбцов первого листа с использованием нулевой индексации. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) определяет отображаемый диапазон. Предпросмотр рендерится с разрешением 96 DPI, а его пиксельные размеры преобразуются в пункты с использованием 72 пункта на дюйм. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) внедряет изменённую рабочую книгу в кадр с этими размерами. Предпросмотр назначается через [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) для замены заполнителя "EMBEDDED OLE OBJECT" в сохранённой презентации.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Установите отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Получите ширину и высоту OLE‑изображения в пунктах.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Нам нужно использовать изменённую рабочую книгу.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Добавьте OLE‑изображение в ресурсы презентации.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Создайте кадр OLE‑объекта.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Вспомогательная функция предварительного просмотра использует [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) для выбора диапазона и удаляет поля, колонтитулы и верхние колонтитулы. При включённой опции [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) рендерит диапазон как PNG‑изображение. Вспомогательная функция копирует отрисованные данные изображения в новый поток памяти, позиционированный в начале, для использования в презентации.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Scale the Cell Range Size**

Этот подход масштабирует высоты выбранных строк и ширины выбранных столбцов, чтобы соответствовать пользовательскому размеру OLE‑кадра.

В примере загружается существующая рабочая книга Excel и выбираются первые 10 строк и 13 столбцов первого листа с использованием нулевой индексации. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) определяет отображаемый диапазон, а приведённая ниже вспомогательная функция масштабирует этот диапазон так, чтобы он помещался в кадр шириной 400 пунктов и высотой 100 пунктов. После сохранения изменённой рабочей книги в массив байтов, [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) внедряет её с указанными размерами. Предпросмотр, отрендеренный при 96 DPI, назначается через [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), поэтому сохранённая презентация отображает выбранные ячейки вместо стандартного заполнителя.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Установите отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабировать диапазон ячеек, чтобы он соответствовал размеру кадра.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Нужно использовать изменённую рабочую книгу.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Добавьте OLE‑изображение в ресурсы презентации.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Создайте кадр OLE‑объекта.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Вспомогательная функция масштабирования вычисляет отдельные коэффициенты ширины и высоты для выбранного диапазона, сохраняя относительные ширины его столбцов и относительные высоты его строк. Она преобразует рассчитанные размеры из пунктов в дюймы перед применением их с помощью [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) и [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). Выбранный диапазон должен иметь ненулевую ширину и высоту.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Ожидаемая ширина диапазона ячеек в пунктах.</param>
/// <param name="height">Ожидаемая высота диапазона ячеек в пунктах.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Эта вспомогательная функция предварительного просмотра рендерит изменённый диапазон с использованием [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Она использует [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) для ограничения печати этим диапазоном, удаляет поля, колонтитулы и верхние колонтитулы и возвращает PNG‑поток, позиционированный в начале.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Заключение**

{{% alert color="info" title="Note" %}}

Существует два подхода к устранению проблемы изменения размера листа. Выберите подход, который лучше всего соответствует вашим требованиям и сценариям использования. Оба подхода работают одинаково, независимо от того, созданы ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничений на размер OLE‑кадра.

{{% /alert %}}

## **Часто задаваемые вопросы**

**Почему встроенный лист Excel меняет размер при первой активации в PowerPoint?**

Это происходит потому, что Excel пытается сохранить оригинальный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласуют размер, чтобы сохранить соотношение сторон, что может привести к изменению размера.

**Можно ли полностью предотвратить эту проблему изменения размера?**

Да. Масштабируя OLE‑кадр под размер диапазона ячеек Excel или масштабируя диапазон ячеек под нужный размер OLE‑кадра, можно избежать нежелательного изменения размера.

**Какой метод масштабирования использовать: масштабирование OLE‑кадра или масштабирование диапазона ячеек?**

Выберите **OLE frame scaling**, если хотите сохранить оригинальные размеры строк и столбцов Excel. Выберите **cell range scaling**, если нужен фиксированный размер OLE‑кадра в вашей презентации.

**Будут ли эти решения работать, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и с нуля.

**Есть ли ограничение размера OLE‑кадра при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑кадра, при условии правильной установки масштаба.

**Можно ли избежать текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?**

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя OLE‑кадра, можно отобразить пользовательское изображение предварительного просмотра вместо стандартного заполнителя.

## **Связанные статьи**

[Создание диаграммы Excel и её встраивание в презентацию как OLE‑объект](/slides/ru/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)