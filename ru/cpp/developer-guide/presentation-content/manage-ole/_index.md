---
title: Управление OLE в презентациях с помощью C++
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/cpp/manage-ole/
keywords:
- OLE-объект
- Связывание и внедрение объектов
- добавление OLE
- внедрение OLE
- добавление объекта
- внедрение объекта
- добавление файла
- внедрение файла
- связанный объект
- связанный файл
- изменение OLE
- значок OLE
- заголовок OLE
- извлечение OLE
- извлечение объекта
- извлечение файла
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Оптимизируйте управление OLE-объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для C++. Внедряйте, обновляйте и экспортируйте OLE-контент без проблем."
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) – это технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении с помощью связывания или внедрения. 

{{% /alert %}} 

Рассмотрите диаграмму, созданную в MS Excel. Эта диаграмма затем помещается на слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке по значку диаграмма открывается в связанном приложении (Excel) или появляется запрос выбрать приложение для открытия или редактирования объекта. 
- OLE‑объект может отображать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) позволяет вставлять OLE‑объекты на слайды в виде OLE‑кадров объектов ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **Добавление OLE‑кадров объектов на слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её на слайд в виде OLE‑кадра объекта с помощью Aspose.Slides for C++, вы можете сделать это так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Прочитайте файл Excel как массив байтов.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) на слайд, передав массив байтов и другую информацию об OLE‑объекте.
5. Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) с помощью Aspose.Slides for C++. **Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение внедряемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно определять тип файла и выбирать соответствующее приложение для открытия OLE‑объекта.
``` cpp
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


### **Добавление связанных OLE‑кадров объектов**

Aspose.Slides for C++ позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) без внедрения данных, а только со ссылкой на файл.

Этот C++‑код демонстрирует, как добавить [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) со связанным файлом Excel на слайд:
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Добавьте OLE‑кадр объекта со связанным файлом Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Доступ к OLE‑кадрам объектов**

Если OLE‑объект уже внедрён в слайд, вы можете легко найти или получить к нему доступ следующим способом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). В нашем примере мы использовали предварительно созданный PPTX, содержащий только одну форму на первом слайде. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Это был нужный OLE‑кадр объекта для доступа.
4. После получения доступа к OLE‑кадру объекта вы можете выполнять любые операции над ним.

В примере ниже доступен OLE‑кадр объекта (объект диаграммы Excel, внедрённый в слайд) и его файловые данные.
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Получить данные встроенного файла.
    // Получить расширение встроенного файла.
    // ...
}
```


### **Доступ к свойствам связанных OLE‑кадров объектов**

Aspose.Slides позволяет получать свойства связанных OLE‑кадров объектов.

Этот C++‑код показывает, как проверить, является ли OLE‑объект связанным, и затем получить путь к связанному файлу:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Проверить, является ли OLE объект связанным.
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

{{% alert color="primary" %}} 

В этом разделе пример кода ниже использует [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Если OLE‑объект уже внедрён в слайд, вы можете легко получить к нему доступ и изменить его данные следующим образом:

1. Загрузите презентацию с внедрённым OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите форму [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). В нашем примере мы использовали предварительно созданный PPTX, содержащий одну форму на первом слайде. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Это был нужный OLE‑кадр объекта для доступа.
4. После получения доступа к OLE‑кадру объекта вы можете выполнять любые операции над ним.
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.
6. Получите нужный `Worksheet` и измените данные.
7. Сохраните обновлённый `Workbook` в поток.
8. Измените данные OLE‑объекта из потока.

В примере ниже OLE‑кадр объекта (объект диаграммы Excel, внедрённый в слайд) доступен, и его файловые данные изменены для обновления данных диаграммы.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Получить первую фигуру как OLE-кадр объекта.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Прочитать данные OLE-объекта как объект Workbook.
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

    // Изменить данные объекта OLE-кадра.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for C++ позволяет встраивать в слайды и другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователя по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящую программу для его открытия.

Этот C++‑код показывает, как внедрить HTML и ZIP в слайд:
``` cpp
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

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for C++ позволяет установить тип файла для встроенного объекта, что даёт возможность обновлять данные OLE‑кадра или его расширение.

Этот C++‑код показывает, как установить тип файла для встроенного OLE‑объекта в `zip`:
``` cpp
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

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот предварительный просмотр видят пользователи до доступа или открытия OLE‑объекта. Если вы хотите использовать конкретное изображение и текст в качестве элементов предварительного просмотра, вы можете установить изображение значка и заголовок с помощью Aspose.Slides for C++.

Этот C++‑код показывает, как установить изображение значка и заголовок для встроенного объекта: 
``` cpp
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


## **Предотвращение изменения размера и перемещения OLE‑кадра объекта**

После того как вы добавите связанный OLE‑объект на слайд презентации, при открытии презентации в PowerPoint вы можете увидеть сообщение с запросом обновить ссылки. Нажатие кнопки "Update Links" может изменить размер и позицию OLE‑кадра, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет предварительный просмотр. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, установите метод `set_UpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) в значение `false`:
```cpp
oleFrame->set_UpdateAutomatic(false);
```


## **Извлечение встроенных файлов**

Aspose.Slides for C++ позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), содержащего OLE‑объекты, которые вы хотите извлечь.
2. Пройдитесь по всем формулам в презентации и получите доступ к формам [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).
3. Получите данные встроенных файлов из OLE‑кадров объектов и запишите их на диск.

Этот C++‑код показывает, как извлечь файлы, встроенные в слайд, в виде OLE‑объектов:
``` cpp
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

**Будет ли OLE‑содержание отрисовано при экспорте слайдов в PDF/изображения?**

Отрисовывается то, что видно на слайде — значок/замещающее изображение (превью). «Живое» OLE‑содержание не выполняется при рендеринге. При необходимости задайте собственное изображение превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [блокировки на уровне формы](/slides/ru/cpp/applying-protection-to-presentation/). Это не шифрование, но эффективно препятствует случайным изменениям и перемещениям.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного отображения следуйте рекомендациям [Working Solution for Worksheet Resizing](/slides/ru/cpp/working-solution-for-worksheet-resizing/) — либо подгоните кадр под диапазон, либо масштабируйте диапазон до фиксированного кадра и задайте соответствующее замещающее изображение.

**Будут ли относительные пути для связанных OLE‑объектов сохранены в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.