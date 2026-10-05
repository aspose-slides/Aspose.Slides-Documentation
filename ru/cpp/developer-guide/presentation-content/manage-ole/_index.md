---
title: Управление OLE в презентациях с использованием C++
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/cpp/manage-ole/
keywords:
- OLE‑объект
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
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для C++. Встраивайте, обновляйте и экспортируйте OLE‑содержимое без проблем."
---
## **Введение**

{{% alert color="info" title="Примечание" %}}

OLE (Object Linking & Embedding) — это технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении посредством связывания или встраивания. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма помещается в слайд PowerPoint. Такая диаграмма считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке значка диаграмма открывается в соответствующем приложении (Excel) или появляется запрос выбора приложения для открытия или редактирования объекта. 
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается интерфейс диаграммы, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides для C++](https://products.aspose.com/slides/cpp/) позволяет вставлять OLE‑объекты на слайды в виде OLE‑object frames ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **Добавление OLE Object Frames на слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд как OLE‑object frame с помощью Aspose.Slides для C++. Это можно сделать так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). 
2. Получите ссылку на слайд по его индексу. 
3. Прочитайте файл Excel как массив байтов. 
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) на слайд, указав массив байтов и другую информацию об OLE‑объекте. 
5. Сохраните изменённую презентацию в файл PPTX. 

В примере ниже мы добавили диаграмму из файла Excel на слайд как [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) с помощью Aspose.Slides для C++. **Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение встраиваемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно определить тип файла и выбрать нужное приложение для открытия данного OLE‑объекта.

```cpp
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

// Подготовьте данные для OLE‑объекта.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Добавьте OLE‑object frame на слайд.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Добавление связанных OLE Object Frames**

Aspose.Slides для C++ позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) без встраивания данных, а только со ссылкой на файл.

Этот код на C++ показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) с привязанным файлом Excel на слайд:

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

// Добавьте OLE object frame со связанным файлом Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Доступ к OLE Object Frames**

Если OLE‑объект уже встроен в слайд, его можно легко найти или получить доступ следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). 
2. Получите ссылку на слайд, используя его индекс. 
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде находится единственная форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Это был нужный OLE‑object frame для доступа. 
4. После получения доступа к OLE‑object frame вы можете выполнять любые операции с ним. 

В примере ниже показан доступ к OLE‑object frame (объект диаграммы Excel, встроенный в слайд) и его файловым данным.

```cpp
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

### **Доступ к свойствам связанных OLE Object Frame**

Aspose.Slides позволяет получать свойства связанных OLE‑object frame.

Этот код на C++ показывает, как проверить, связан ли OLE‑объект, и получить путь к связанному файлу:

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

    // Проверить, связан ли OLE‑объект.
    if (oleFrame->get_IsObjectLink())
    {
        // Вывести полный путь к связанному файлу.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Вывести относительный путь к связанному файлу, если он есть.
        // Только презентации PPT могут содержать относительный путь.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Изменение данных OLE Object**

{{% alert color="info" title="Примечание" %}}

В этом разделе пример кода использует [Aspose.Cells для C++](https://docs.aspose.com/cells/cpp/). 

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, его можно легко получить и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). 
2. Получите ссылку на слайд по его индексу. 
3. Получите форму [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде одна форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Это был нужный OLE‑object frame для доступа. 
4. После получения доступа к OLE‑object frame вы можете выполнять любые операции с ним. 
5. Создайте объект `Workbook` и получите доступ к OLE‑данным. 
6. Получите нужный `Worksheet` и измените данные. 
7. Сохраните обновлённый `Workbook` в поток. 
8. Измените данные OLE‑объекта из потока. 

В примере ниже OLE‑object frame (объект диаграммы Excel, встроенный в слайд) получен, и его файловые данные изменены для обновления данных диаграммы.

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

// Aspose.Cells для C++ должен быть запущен перед использованием любых его типов.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Получить первую форму как OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Прочитать данные OLE объекта как объект Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Изменить данные workbook.
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

    // Изменить данные объекта OLE frame.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Встраивание других типов файлов в слайды**

Помимо Excel‑диаграмм, Aspose.Slides для C++ позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящую программу для его открытия.

Этот код на C++ показывает, как встроить HTML и ZIP в слайд:

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

## **Установка типа файлов для встроенных объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides для C++ позволяет задать тип файла для встроенного объекта, что даёт возможность обновить данные OLE‑рамки или её расширение.

Этот код на C++ показывает, как задать тип файла для встроенного OLE‑объекта как `zip`:

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

## **Установка значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот превью‑изображение видят пользователи перед доступом к объекту. Если требуется использовать конкретное изображение и текст в превью, можно задать значок и заголовок с помощью Aspose.Slides для C++.

Этот код на C++ показывает, как задать значок и заголовок для встроенного объекта:

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

// Добавьте изображение в ресурсы презентации.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Установите заголовок и изображение для предварительного просмотра OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Предотвращение изменения размера и перемещения OLE Object Frame**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и позицию OLE‑object frame, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет превью. Чтобы отключить запрос PowerPoint о обновлении данных объекта, вызовите метод [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) со значением `false`:

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

Aspose.Slides для C++ позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), содержащий OLE‑объекты, которые нужно извлечь. 
2. Пройдитесь по всем формам в презентации и получите доступ к формам [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). 
3. Получите данные встроенных файлов из OLE‑object frame и запишите их на диск. 

Этот код на C++ показывает, как извлечь файлы, встроенные в слайд как OLE‑объекты:

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

## **Вопросы и ответы**

**Будет ли OLE‑содержание отрисовано при экспорте слайдов в PDF/изображения?**  

Отображается то, что видно на слайде — значок/замещающее изображение (превью). «Живое» OLE‑содержание не исполняется во время отрисовки. При необходимости задайте собственное превью‑изображение, чтобы обеспечить ожидаемый вид в экспортированном PDF.  

Чтобы также сохранить встроенный файл как вложение PDF, вызовите [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) со значением `true`. Этот параметр отключён по умолчанию. Пример и инструкции по проверке вложения см. в статье [Preserve Embedded OLE Files as PDF Attachments](/slides/ru/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**  

Заблокируйте форму: Aspose.Slides предоставляет [shape-level locks](/slides/ru/cpp/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещение.

**Почему связанный объект Excel «скачок» или меняет размер при открытии презентации?**  

PowerPoint может обновлять превью связанного OLE. Для стабильного отображения следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/cpp/working-solution-for-worksheet-resizing/): либо подгоните рамку под диапазон, либо масштабируйте диапазон до фиксированной рамки и задайте подходящее замещающее изображение.

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**  

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути встречаются в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.