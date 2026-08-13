---
title: Рабочее решение проблемы изменения размера листа
type: docs
weight: 130
url: /ru/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предварительного просмотра
- изменение размера изображения
- Excel
- лист
- PowerPoint
- презентация
- C++
- Aspose.Slides for C++
description: "Рабочее решение проблемы изменения размера листа в презентациях PowerPoint с использованием C++"
---
{{% alert color="info" %}}

Было замечено, что листы Excel, встроенные как OLE‑объекты в презентацию PowerPoint с помощью компонентов Aspose, изменяют масштаб до неопределённого значения после первой активации. Такое поведение создаёт заметную визуальную разницу в презентации между состоянием OLE‑объекта до и после активации. Мы подробно исследовали эту проблему и предоставили решение, описанное в этой статье.

{{% /alert %}}

## **Предыстория**

В статье [Управление OLE](/slides/ru/cpp/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с использованием Aspose.Slides for C++. Чтобы решить [проблему предварительного просмотра объекта](/slides/ru/cpp/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение выбранной области листа OLE‑кадру. В полученной презентации, когда вы дважды щёлкните по OLE‑кадру, отображающему изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые изменения в реальную рабочую книгу Excel, а затем возвращаться к слайду, щёлкнув за пределами активированной рабочей книги. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑кадра и встроенной рабочей книги Excel. 

## **Причина изменения размера**

Поскольку у рабочей книги Excel собственный размер окна, она пытается сохранить свой исходный размер при первой активации. С другой стороны, OLE‑кадр имеет свои размеры. По данным Microsoft, когда рабочая книга Excel активируется, Excel и PowerPoint согласовывают размер, чтобы он сохранял правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размерами и позицией OLE‑кадра.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Масштабировать размер OLE‑кадра в презентации PowerPoint, чтобы он соответствовал высоте и ширине требуемого количества строк и столбцов в OLE‑кадре.
- Оставить размер OLE‑кадра постоянным и масштабировать размеры участвующих строк и столбцов, чтобы они помещались в выбранный размер OLE‑кадра.

### **Масштабировать размер OLE‑кадра**

В этом подходе мы узнаем, как установить размер OLE‑кадра встроенной рабочей книги Excel, чтобы он соответствовал совокупному размеру участвующих строк и столбцов в листе Excel.

Предположим, у нас есть шаблон листа Excel, который нужно добавить в презентацию как OLE‑кадр. В этом случае размер OLE‑кадра сначала будет рассчитан на основе совокупных высот строк и ширин столбцов участвующих в рабочей книге. Затем мы установим размер OLE‑кадра равным этому рассчитанному значению. Чтобы избавиться от красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также захватим изображение нужных участков строк и столбцов в рабочей книге и установим его как изображение OLE‑кадра.

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

// Нам необходимо использовать изменённую рабочую книгу.
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

### **Масштабировать размер диапазона ячеек**

В этом подходе мы узнаем, как масштабировать высоты участвующих строк и ширину участвующих столбцов, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

Предположим, у нас есть шаблон листа Excel, который нужно добавить в презентацию как OLE‑кадр. В этом случае мы задаём размер OLE‑кадра и масштабируем размеры строк и столбцов, участвующих в области OLE‑кадра. Затем сохраняем рабочую книгу в поток, чтобы применить изменения, и преобразуем её в массив байтов для добавления в OLE‑кадр. Чтобы избавиться от красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также захватим изображение нужных участков строк и столбцов в рабочей книге и установим его как изображение OLE‑кадра.

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

// Установите отображаемый размер, когда файл рабочей книги используется как OLE-объект в PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабируйте диапазон ячеек, чтобы он соответствовал размеру кадра.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Нам необходимо использовать изменённую рабочую книгу.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Добавьте OLE-изображение в ресурсы презентации.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Создайте кадр OLE-объекта.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

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

{{% alert color="info" %}}

Существует два подхода к исправлению проблемы изменения размера листа. Выбор подходящего зависит от конкретных требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничения по размеру OLE‑кадра.

{{% /alert %}}

## **FAQ**

### Почему встроенный лист Excel меняет размер при первой активации в PowerPoint?

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может привести к изменению размера.

### Можно ли полностью предотвратить эту проблему изменения размера?

Да. Масштабируя OLE‑кадр под размер диапазона ячеек Excel или масштабируя диапазон ячеек под нужный размер OLE‑кадра, можно избежать нежелательного изменения размера.

### Какой метод масштабирования выбрать: масштабирование OLE‑кадра или масштабирование диапазона ячеек?

Выбирайте **масштабирование OLE‑кадра**, если хотите сохранить оригинальные размеры строк и столбцов Excel. Выбирайте **масштабирование диапазона ячеек**, если нужна фиксированная величина OLE‑кадра в презентации.

### Будут ли эти решения работать, если моя презентация основана на шаблоне?

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для созданных с нуля.

### Есть ли ограничение по размеру OLE‑кадра при использовании этих методов?

Нет. Вы можете задать любой размер OLE‑кадра, если правильно установите масштаб.

### Можно ли избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя OLE‑кадра, вы сможете показать пользовательское превью вместо стандартного заполнителя.

## **Связанные статьи**

[Создание диаграммы Excel и встраивание её в презентацию как OLE‑объект](/slides/ru/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)