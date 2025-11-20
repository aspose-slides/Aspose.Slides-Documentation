---
title: Управление OLE в презентациях с использованием C#
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/net/manage-ole/
keywords:
- OLE-объект
- Связывание и внедрение объектов
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
- .NET
- C#
- Aspose.Slides
description: "Оптимизируйте управление OLE-объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для .NET. Встраивайте, обновляйте и экспортируйте OLE-контент без проблем."
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении с помощью связывания или встраивания. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Затем эта диаграмма помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке по значку диаграмма открывается в связанном приложении (Excel) или появляется запрос выбрать приложение для открытия/редактирования объекта. 
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) позволяет вставлять OLE‑объекты на слайды в виде OLE‑объектных фреймов ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Добавление OLE‑объектных фреймов на слайды**

Предположим, вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд в виде OLE‑объектного фрейма с помощью Aspose.Slides for .NET, вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Прочтите файл Excel как массив байтов.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд, содержащий массив байтов и другую информацию об OLE‑объекте.
5. Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) с помощью Aspose.Slides for .NET.  
**Note** что конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение внедряемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint корректно определить тип файла и выбрать правильное приложение для открытия данного OLE‑объекта.
```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Подготовьте данные для OLE‑объекта.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Добавьте OLE‑объектный фрейм на слайд.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


### **Добавление связанных OLE‑объектных фреймов**

Aspose.Slides for .NET позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) без встраивания данных, а только со ссылкой на файл.

Этот код C# показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) со связанным файлом Excel на слайд:
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте OLE‑объектный фрейм со связанным файлом Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Доступ к OLE‑объектным фреймам**

Если OLE‑объект уже встроен в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). В нашем примере мы использовали ранее созданный PPTX, на первом слайде которого находится единственная форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Это и был нужный OLE‑объектный фрейм для доступа.
4. После получения доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним.

В примере ниже показывается, как получить доступ к OLE‑объектному фрейму (встроенному объекту диаграммы Excel) и к его файловым данным.
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получите первую форму как OLE‑объектный фрейм.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Получите данные встроенного файла.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Получите расширение встроенного файла.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **Доступ к свойствам связанных OLE‑объектных фреймов**

Aspose.Slides позволяет получать свойства связанных OLE‑объектных фреймов.

Этот код C# демонстрирует, как проверить, связан ли OLE‑объект, и затем получить путь к связанному файлу:
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Получите первую форму как OLE-объектный фрейм.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Проверьте, является ли OLE-объект связанным.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Выведите полный путь к связанному файлу.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Выведите относительный путь к связанному файлу, если он присутствует.
        // Только презентации PPT могут содержать относительный путь.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **Изменение данных OLE‑объекта**

{{% alert color="primary" %}} 

В этом разделе пример кода ниже использует [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, вы можете легко получить к нему доступ и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу. 
3. Получите форму [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). В нашем примере мы использовали ранее созданный PPTX, на первом слайде которого одна форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Это был нужный OLE‑объектный фрейм для доступа.
4. После получения доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним.
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.
6. Получите нужный `Worksheet` и измените данные.
7. Сохраните обновлённый `Workbook` в поток.
8. Измените данные OLE‑объекта из потока.

В примере ниже OLE‑объектный фрейм (встроенный объект диаграммы Excel) доступен, и его файловые данные изменяются для обновления данных диаграммы.
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получите первую форму как OLE‑объектный фрейм.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Прочитайте данные OLE‑объекта как объект Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Измените данные рабочей книги.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Измените данные OLE‑фрейма объекта.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for .NET позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователя по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящее приложение для открытия.

Этот код C# показывает, как встроить HTML и ZIP в слайд:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Установка типов файлов для встраиваемых объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for .NET позволяет задать тип файла для встраиваемого объекта, что даёт возможность обновить данные OLE‑фрейма или его расширение.

Этот код C# показывает, как установить тип файла для встраиваемого OLE‑объекта в `zip`:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Измените тип файла на ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Установка изображений и заголовков иконок для встраиваемых объектов**

После встраивания OLE‑объекта автоматически добавляется превью в виде значка. Это превью видят пользователи до доступа к объекту. Если требуется использовать конкретное изображение и текст в превью, можно задать изображение значка и заголовок с помощью Aspose.Slides for .NET.

Этот код C# показывает, как задать изображение значка и заголовок для встраиваемого объекта: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Добавьте изображение в ресурсы презентации.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Установите заголовок и изображение для превью OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Предотвращение изменения размера и перемещения OLE‑объектного фрейма**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и позицию OLE‑объектного фрейма, так как PowerPoint обновляет данные из связанного OLE‑объекта и обновляет превью. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, установите свойство `UpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) в `false`:
```cs
oleFrame.UpdateAutomatic = false;
```


## **Извлечение встраиваемых файлов**

Aspose.Slides for .NET позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего OLE‑объекты, которые необходимо извлечь.
2. Пройдитесь по всем формам в презентации и получите доступ к формам [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. Получите данные встроенных файлов из OLE‑объектных фреймов и запишите их на диск.

Этот код C# демонстрирует, как извлечь файлы, встроенные в слайд в виде OLE‑объектов:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```


## **FAQ**

**Будет ли OLE‑контент отрисован при экспорте слайдов в PDF/изображения?**

Отрисовывается то, что видно на слайде — значок/замещающее изображение (превью). «Живой» OLE‑контент не исполняется во время рендеринга. При необходимости задайте собственное превью‑изображение, чтобы обеспечить ожидаемый вид в экспортированном PDF.

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [блокировки на уровне формы](/slides/ru/net/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel «прыгает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного вида следуйте рекомендациям из статьи [Working Solution for Worksheet Resizing](/slides/ru/net/working-solution-for-worksheet-resizing/) — либо подгоняйте фрейм под диапазон, либо масштабируйте диапазон под фиксированный фрейм и задайте подходящее замещающее изображение.

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути встречаются в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.