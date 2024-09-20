---
title: Управление OLE
type: docs
weight: 40
url: /cpp/manage-ole/
keywords: "Добавить OLE, Добавить объект, Включить объект Объектное связывание и встроенное использование, OLE Объектная рамка, Включить OLE, Презентация PowerPoint, C++, CPP, Aspose.Slides для C++ "
description: "Добавить OLE объект в презентацию PowerPoint на C++"
---

{{% alert title="Информация" color="info" %}}

OLE (Объектное связывание и встроенное использование) — это технология Microsoft, которая позволяет размещать данные и объекты, созданные в одном приложении, в другом приложении через связывание или встраивание. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Диаграмма затем помещается внутрь слайда PowerPoint. Эта диаграмма Excel считается OLE объектом. 

- OLE объект может отображаться как значок. В этом случае, когда вы дважды щелкаете по значку, диаграмма открывается в связанной программе (Excel), или вам предлагается выбрать программу для открытия или редактирования объекта. 
- OLE объект может отображать фактическое содержимое — например, содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, интерфейс диаграммы загружается, и вы можете изменить данные диаграммы в приложении PowerPoint.

[Aspose.Slides для C++](https://products.aspose.com/slides/cpp/) позволяет вставлять OLE объекты в слайды в виде OLE объектных рамок ([OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)).



## **Добавление OLE Объектных Рамок в Слайды**

Предположим, вы уже создали диаграмму в Microsoft Excel и хотите встроить эту диаграмму в слайд в качестве OLE объектной рамки с использованием Aspose.Slides для C++. Вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд через его индекс.
3. Откройте файл Excel, содержащий объект диаграммы Excel, и сохраните его в `MemoryStream`.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) на слайд, содержащий массив байтов и другую информацию о OLE объекте.
5. Запишите измененную презентацию в файл PPTX.

В следующем примере мы добавили диаграмму из файла Excel в слайд в качестве [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) с использованием Aspose.Slides для C++.  
**Обратите внимание**, что конструктор [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_ole_embedded_data_info) принимает расширение встраиваемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать правильное приложение для открытия этого OLE объекта.

``` cpp
// Путь к каталогу документов.
String dataDir = u"";
// Создает экземпляр класса Presentation, представляющего PPTX
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);
// Загружает файл Excel в поток
SharedPtr<MemoryStream> mstream = System::MakeObject<MemoryStream>();

SharedPtr<FileStream> fs = System::MakeObject<FileStream>(dataDir + u"book1.xlsx", FileMode::Open, FileAccess::Read);

ArrayPtr<uint8_t> buf = System::MakeArray<uint8_t>(4096, 0);
while (true)
{
    int32_t bytesRead = fs->Read(buf, 0, buf->get_Length());
    if (bytesRead <= 0)
    {
        break;
    }
    mstream->Write(buf, 0, bytesRead);
}

// Создает объект данных для встраивания
SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(mstream->ToArray(), u"xlsx");
// Добавляет форму Ole Object Frame
SharedPtr<IOleObjectFrame> oleObjectFrame = sld->get_Shapes()->AddOleObjectFrame(0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), dataInfo);
// Записывает файл PPTX на диск
pres->Save(dataDir + u"OleEmbed_out.pptx", SaveFormat::Pptx);
```

## **Доступ к OLE Объектным Рамкам**
Если OLE объект уже встроен в слайд, вы можете легко найти или получить доступ к этому объекту следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

2. Получите ссылку на слайд, используя его индекс.

3. Получите доступ к форме [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame).

   В нашем примере мы использовали ранее созданный PPTX, который имеет только одну форму на первом слайде. Затем мы *привели* этот объект к [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). Это была желаемая OLE объектная рамка для доступа.

4. Как только OLE объектная рамка доступна, вы можете выполнять с ней любые операции.

В следующем примере выполняется доступ к OLE объектной рамке (объект диаграммы Excel, встроенный в слайд), и затем его данные файла записываются в файл Excel:

``` cpp
// Путь к каталогу документов.
const String templatePath = u"../templates/AccessingOLEObjectFrame.pptx";

// Загружает желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Получает первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Приводит форму к OleObjectFrame
SharedPtr<OleObjectFrame> oleObjectFrame = System::AsCast<OleObjectFrame>(sld->get_Shapes()->idx_get(0));

// Читает OLE объект и записывает его на диск
if (oleObjectFrame != nullptr)
{
    // Получает встроенные данные файла
    ArrayPtr<uint8_t> data = oleObjectFrame->get_EmbeddedFileData();

    // Получает расширение встроенного файла
    String fileExtention = oleObjectFrame->get_EmbeddedFileExtension();

    // Создает путь для сохранения извлеченного файла
    String extractedPath = Path::Combine(GetOutPath(), u"excelFromOLE_out" + fileExtention);

    // Сохраняет извлеченные данные
    SharedPtr<FileStream> fstr = System::MakeObject<FileStream>(extractedPath, FileMode::Create, FileAccess::Write);
    fstr->Write(data, 0, data->get_Length());
}
```

## **Изменение Данных OLE Объекта**
Если OLE объект уже встроен в слайд, вы можете получить доступ к этому объекту и изменить его данные следующим образом:

1. Откройте желаемую презентацию с встроенным OLE объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

2. Получите ссылку на слайд через его индекс. 

3. Получите доступ к форме [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame).

   В нашем примере мы использовали ранее созданный PPTX, который имеет одну форму на первом слайде. Затем мы *привели* этот объект к [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). Это была желаемая OLE объектная рамка для доступа.

4. Как только OLE объектная рамка доступна, вы можете выполнять с ней любые операции.

5. Создайте объект Workbook и получите доступ к OLE данным.

6. Получите доступ к нужному листу и измените данные.

7. Сохраните обновленный Workbook в потоках.

8. Измените данные OLE объекта на данные из потока.

В следующем примере выполняется доступ к OLE объектной рамке (объект диаграммы Excel, встроенный в слайд), и затем его данные файла изменяются для изменения данных диаграммы:

``` cpp
intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> ToCellsMemoryStream(System::ArrayPtr<uint8_t> buffer)
{
    intrusive_ptr<BString> array = new BString(buffer->data_ptr(), buffer->Count());
    auto stream = new Aspose::Cells::Systems::IO::MemoryStream(array);

    return stream;
}

System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}

void ChangeOLEObjectData()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(GetDataPath() + u"ChangeOLEObjectData.pptx");
    System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

    System::SharedPtr<OleObjectFrame> ole;

    // Обходит все формы для Ole рамки
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        if (System::ObjectExt::Is<OleObjectFrame>(shape))
        {
            ole = System::ExplicitCast<OleObjectFrame>(shape);
        }
    }
    
    if (ole != nullptr)
    {
        // Читает данные объекта в Workbook
        intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> cellsInputStream = ToCellsMemoryStream(ole->get_ObjectData());
        intrusive_ptr<Aspose::Cells::IWorkbook> Wb = Aspose::Cells::Factory::CreateIWorkbook(cellsInputStream);

        // Изменяет данные книги
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(0,4)->PutValue(u"E");
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(1, 4)->PutValue(12);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(2, 4)->PutValue(14);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(3, 4)->PutValue(15);

        intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
        Wb->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);
        
        // Изменяет данные объекта Ole рамки
        cellsOutputStream->SetPosition(0);
        System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);
        ole->set_ObjectData(msout->ToArray());
        
        pres->Save(GetOutPath() + u"OleEdit_out.pptx", Export::SaveFormat::Pptx);
    }
}
```

## Встраивание Других Типов Файлов в Слайды

Помимо диаграмм Excel, Aspose.Slides для C++ позволяет вам встраивать другие типы файлов в слайды. Например, вы можете вставлять HTML, PDF и ZIP файлы в качестве объектов в слайд. Когда пользователь дважды щелкает по вставленному объекту, объект автоматически запускается в соответствующей программе, или пользователь перенаправляется для выбора подходящей программы для открытия объекта. 

Этот код C++ показывает, как встроить HTML и ZIP в слайд:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto htmlBytes = System::IO::File::ReadAllBytes(u"embedOle.html");

auto dataInfoHtml = System::MakeObject<OleEmbeddedDataInfo>(htmlBytes, u"html");
auto oleFrameHtml = slide->get_Shapes()->AddOleObjectFrame(150.0f, 120.0f, 50.0f, 50.0f, dataInfoHtml);
oleFrameHtml->set_IsObjectIcon(true);
        
auto zipBytes = System::IO::File::ReadAllBytes(u"embedOle.zip");
auto dataInfoZip = System::MakeObject<OleEmbeddedDataInfo>(zipBytes, u"zip");
auto oleFrameZip = slide->get_Shapes()->AddOleObjectFrame(150.0f, 220.0f, 50.0f, 50.0f, dataInfoZip);
oleFrameZip->set_IsObjectIcon(true);
        
pres->Save(u"embeddedOle.pptx", SaveFormat::Pptx);

```

## Установка Типов Файлов для Встроенных Объектов

При работе над презентациями вам может понадобиться заменить старые OLE объекты новыми. Либо вам может понадобиться заменить неподдерживаемый OLE объект на поддерживаемый. 

Aspose.Slides для C++ позволяет вам установить тип файла для встроенного объекта. Таким образом, вы можете изменить данные OLE рамки или ее расширение. 

Этот код C++ показывает, как установить тип файла для встроенного OLE объекта:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shapes()->idx_get(0));
Console::WriteLine(u"Текущая расширение встроенных данных: {0}", oleObjectFrame->get_EmbeddedData()->get_EmbeddedFileExtension());

oleObjectFrame->SetEmbeddedData(System::MakeObject<OleEmbeddedDataInfo>(File::ReadAllBytes(u"embedOle.zip"), u"zip"));

pres->Save(u"embeddedChanged.pptx", SaveFormat::Pptx);
```

## Установка Изображений Значков и Заголовков для Встроенных Объектов

После того, как вы встроите OLE объект, автоматически добавляется предварительный просмотр, состоящий из изображения значка и заголовка. Предварительный просмотр — это то, что пользователи видят, прежде чем получить доступ или открыть OLE объект. 

Если вы хотите использовать определенное изображение и текст в качестве элементов в предварительном просмотре, вы можете установить изображение значка и заголовок с помощью Aspose.Slides для C++.

Этот код C++ показывает, как установить изображение значка и заголовок для встроенного объекта: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slide(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto oleImage = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
oleObjectFrame->set_SubstitutePictureTitle(u"Мой заголовок");
oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleObjectFrame->set_IsObjectIcon(false);

pres->Save(u"embeddedOle-newImage.pptx", SaveFormat::Pptx);
```

## Извлечение Встроенных Файлов

Aspose.Slides для C++ позволяет вам извлекать файлы, встроенные в слайды в качестве OLE объектов следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), содержащего OLE объект, который вы собираетесь извлечь.
2. Пройдите по всем формам в презентации и получите доступ к форме [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame).
3. Получите данные встроенного файла из OLE объектной рамки и запишите их на диск. 

Этот код C++ показывает, как извлечь файл, встроенный в слайд в качестве OLE объекта:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);

for (int32_t index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shapes()->idx_get(index);

    auto oleFrame = System::AsCast<IOleObjectFrame>(shape);

    if (oleFrame != nullptr)
    {
        auto data = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        String extension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        File::WriteAllBytes(String::Format(u"oleFrame{0}{1}", index, extension), data);
    }
}
```