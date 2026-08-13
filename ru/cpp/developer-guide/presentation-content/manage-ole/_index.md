---
title: "Управление OLE в презентациях с использованием C++"
linktitle: "Управление OLE"
type: docs
weight: 40
url: /ru/cpp/manage-ole/
keywords:
- OLE объект
- Связывание и встраивание объектов
- добавить OLE
- встроить OLE
- добавить объект
- встроить объект
- добавить файл
- встроить файл
- связанный объект
- связанный файл
- изменить OLE
- значок OLE
- заголовок OLE
- извлечь OLE
- извлечь объект
- извлечь файл
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Оптимизируйте управление OLE-объектами в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Встраивайте, обновляйте и экспортируйте OLE-содержимое без проблем."
---
## **Введение**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) — это технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении посредством связывания или встраивания. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Затем эта диаграмма помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке по значку диаграмма открывается в соответствующем приложении (Excel) или запрашивается выбор приложения для открытия или редактирования объекта. 
- OLE‑объект может отображать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/ru/cpp/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑объектных фреймов ([OleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/oleobjectframe/)).

## **Добавление OLE‑объектных фреймов на слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд как OLE‑объектный фрейм с помощью Aspose.Slides for C++. Делается это так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Считайте файл Excel в массив байтов. 
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/oleobjectframe/) на слайд, передав массив байтов и другую информацию об OLE‑объекте. 
5. Запишите изменённую презентацию в файл PPTX. 

В примере ниже мы добавили диаграмму из файла Excel на слайд как [OleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/oleobjectframe/) с помощью Aspose.Slides for C++.
**Note** что конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение внедряемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно определить тип файла и выбрать нужное приложение для открытия OLE‑объекта.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Добавление связанных OLE‑объектных фреймов**

Aspose.Slides for C++ позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/oleobjectframe/) без встраивания данных, а только с ссылкой на файл.

Этот код C++ демонстрирует, как добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/oleobjectframe/) со связанным файлом Excel на слайд:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Добавить OLE‑объектный фрейм со связанным файлом Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Доступ к OLE‑объектным фреймам**

Если OLE‑объект уже встроен в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с вложенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation). 
2. Получите ссылку на слайд, используя его индекс. 
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/oleobjectframe/).  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде находится единственная форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ioleobjectframe/). Это был нужный OLE‑объектный фрейм для доступа. 
4. После получения доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним. 

В примере ниже демонстрируется доступ к OLE‑объектному фрейму (встроенный объект диаграммы Excel в слайде) и его файловым данным.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Получить данные встроенного файла.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Получить расширение встроенного файла.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Доступ к свойствам связанного OLE‑объектного фрейма**

Aspose.Slides позволяет получать свойства связанного OLE‑объектного фрейма.

Этот код C++ показывает, как проверить, является ли OLE‑объект связанным, и получить путь к связанному файлу:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Проверить, является ли OLE‑объект связанным.
    if (oleFrame->get_IsObjectLink())
    {
        // Вывести полный путь к связанному файлу.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Вывести относительный путь к связанному файлу, если он присутствует.
        // Только презентации PPT могут содержать относительный путь.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Изменение данных OLE‑объекта**

{{% alert color="info" %}} 

В этом разделе пример кода использует [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, вы можете легко получить доступ к этому объекту и изменить его данные следующим образом:

1. Загрузите презентацию с вложенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Получите форму [OLEObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/oleobjectframe/).  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде одна форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ioleobjectframe/). Это был нужный OLE‑объектный фрейм для доступа. 
4. После получения доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним. 
5. Создайте объект `Workbook` и получите доступ к OLE‑данным. 
6. Получите нужный `Worksheet` и измените данные. 
7. Сохраните обновлённый `Workbook` в поток. 
8. Замените данные OLE‑объекта данными из потока. 

В примере ниже OLE‑объектный фрейм (встроенный объект диаграммы Excel в слайде) доступен, и его файловые данные изменены для обновления данных диаграммы.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells для C++ должен быть запущен до использования любых его типов.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Прочитать данные OLE‑объекта как объект Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Изменить данные Workbook.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Изменить данные объекта OLE‑фрейма.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for C++ позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP файлы в виде объектов. При двойном щелчке по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователь получает запрос выбрать подходящую программу для открытия.

Этот код C++ демонстрирует, как встроить HTML и ZIP в слайд:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установка типов файлов для встроенных объектов**

При работе с презентациями может потребоваться заменить старый OLE‑объект новым или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for C++ позволяет задать тип файла для встроенного объекта, что даёт возможность обновить данные OLE‑фрейма или его расширение.

Этот код C++ показывает, как установить тип файла для встроенного OLE‑объекта в `zip`:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Изменить тип файла на ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот предварительный просмотр видит пользователь до доступа к объекту. Если необходимо использовать конкретное изображение и текст в качестве элементов предварительного просмотра, можно задать изображение значка и заголовок с помощью Aspose.Slides for C++.

Этот код C++ показывает, как задать изображение значка и заголовок для встроенного объекта: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Добавить изображение в ресурсы презентации.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Установить заголовок и изображение для предварительного просмотра OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Предотвращение изменения размера и перемещения OLE‑объектного фрейма**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и позицию OLE‑объектного фрейма, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет предварительный просмотр. Чтобы предотвратить запрос PowerPoint о обновлении данных объекта, установите метод `set_UpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ioleobjectframe/) в `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Извлечение встроенных файлов**

Aspose.Slides for C++ позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation) с OLE‑объектами, которые необходимо извлечь. 
2. Пройдитесь по всем формам в презентации и получите формы [OLEObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/oleobjectframe/). 
3. Доступ к данным встроенных файлов из OLE‑объектных фреймов и запись их на диск. 

Этот код C++ показывает, как извлечь файлы, встроенные в слайд в виде OLE‑объектов:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **FAQ**

### Will the OLE content be rendered when exporting slides to PDF/images?

What is visible on the slide is rendered—the icon/substitute image (preview). The "live" OLE content is not executed during rendering. If needed, set your own preview image to ensure the expected appearance in the exported PDF.

### How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?

Lock the shape: Aspose.Slides provides [shape-level locks](/slides/ru/cpp/applying-protection-to-presentation/). This is not encryption, but it effectively prevents accidental edits and movement.

### Why does a linked Excel object "jump" or change size when I open the presentation?

PowerPoint may refresh the preview of the linked OLE. For a stable appearance, follow the [Working Solution for Worksheet Resizing](/slides/ru/cpp/working-solution-for-worksheet-resizing/) practices—either fit the frame to the range, or scale the range to a fixed frame and set an appropriate substitute image.

### Will relative paths for linked OLE objects be preserved in the PPTX format?

In PPTX, "relative path" information is not available—only the full path. Relative paths are found in the older PPT format. For portability, prefer reliable absolute paths/accessible URIs or embedding.