---
title: Управление OLE-объектами в презентациях на .NET
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/net/manage-ole/
keywords:
- OLE-объект
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
- .NET
- C#
- Aspose.Slides
description: "Оптимизируйте управление OLE-объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для .NET. Встраивайте, обновляйте и экспортируйте OLE‑контент без проблем."
---

{{% alert title="Инфо" color="info" %}}

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении с помощью связывания или встраивания. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма затем помещается в слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке значка диаграмма открывается в связанном приложении (Excel) или появляется запрос выбора приложения для открытия или редактирования объекта. 
- OLE‑объект может отображать своё фактическое содержимое, например содержание диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑кадров объектов ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Добавление OLE‑кадров объектов в слайды**

Предположим, что вы уже создали диаграмму в Microsoft Excel и хотите встроить её в слайд как OLE‑кадр объекта с помощью Aspose.Slides for .NET. Делается это так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Прочитайте файл Excel как массив байтов. 
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд, передав массив байтов и другую информацию об OLE‑объекте. 
5. Сохраните изменённую презентацию в файл PPTX. 

В примере ниже мы добавили диаграмму из файла Excel на слайд в виде [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) с помощью Aspose.Slides for .NET.  
**Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение встраиваемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно определить тип файла и выбрать нужное приложение для открытия OLE‑объекта.
```csharp
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Подготовьте данные для OLE‑объекта.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Добавьте OLE‑кадр объекта на слайд.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


### **Добавление связанных OLE‑кадров объектов**

Aspose.Slides for .NET позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) без встраивания данных, а только со ссылкой на файл.

В этом C#‑коде показано, как добавить [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) со связанным файлом Excel на слайд:
```csharp
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте OLE‑кадр объекта со связанным файлом Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Доступ к OLE‑кадрам объектов**

Если OLE‑объект уже встроен в слайд, его можно легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Получите ссылку на слайд, указав его индекс. 
3. Доступ к форме [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде находится единственная форма. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Это и был нужный OLE‑кадр объекта. 
4. После получения доступа к OLE‑кадру объекта вы можете выполнять любые операции с ним. 

В примере ниже доступен OLE‑кадр объекта (встроенный в слайд объект диаграммы Excel) и его данные файла.
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получить первую форму как кадр OLE‑объекта.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Получить данные встроенного файла.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Получить расширение встроенного файла.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **Доступ к свойствам связанного OLE‑кадра объекта**

Aspose.Slides позволяет получить свойства связанного OLE‑кадра объекта.

В этом C#‑коде показано, как проверить, связан ли OLE‑объект, и получить путь к связанному файлу:
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Получить первую форму как кадр OLE‑объекта.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Проверить, связан ли OLE‑объект.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Вывести полный путь к связанному файлу.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Вывести относительный путь к связанному файлу, если он присутствует.
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

В этом разделе пример кода использует [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, его можно легко получить и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Доступ к форме [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).  
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде одна форма. Затем мы *привели* объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Это был нужный OLE‑кадр объекта. 
4. После получения доступа к OLE‑кадру объекта вы можете выполнять любые операции с ним. 
5. Создайте объект `Workbook` и получите доступ к OLE‑данным. 
6. Доступ к нужному `Worksheet` и изменение данных. 
7. Сохраните обновлённый `Workbook` в поток. 
8. Измените данные OLE‑объекта из потока. 

В примере ниже доступен OLE‑кадр объекта (встроенный в слайд объект диаграммы Excel), и его данные файла изменяются для обновления данных диаграммы.
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получить первую форму как кадр OLE‑объекта.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Прочитать данные OLE‑объекта как объект Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Изменить данные рабочей книги.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Изменить данные объекта OLE‑кадра.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides for .NET позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP файлы как объекты. При двойном щелчке пользователем вставленного объекта он автоматически открывается в соответствующей программе, либо пользователь получает запрос выбора подходящей программы для открытия.

В этом C#‑коде показано, как встроить HTML и ZIP в слайд:
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


## **Установка типов файлов для встроенных объектов**

При работе с презентациями может возникнуть необходимость заменить старый OLE‑объект новым или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for .NET позволяет установить тип файла для встроенного объекта, что даёт возможность обновить данные OLE‑кадра или его расширение.

В этом C#‑коде показано, как установить тип файла для встроенного OLE‑объекта в `zip`:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Изменить тип файла на ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Установка изображений‑значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот предварительный просмотр видят пользователи перед доступом к объекту. Если необходимо использовать конкретное изображение и текст в качестве элементов предварительного просмотра, можно задать изображение‑значок и заголовок с помощью Aspose.Slides for .NET.

В этом C#‑коде показано, как установить изображение‑значок и заголовок для встроенного объекта: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Добавьте изображение в ресурсы презентации.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Установите заголовок и изображение для предварительного просмотра OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Предотвращение изменения размера и перемещения OLE‑кадра объекта**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с предложением обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение OLE‑кадра, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет его предварительный просмотр. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, установите свойство `UpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) в `false`:
```cs
oleFrame.UpdateAutomatic = false;
```


## **Извлечение встроенных файлов**

Aspose.Slides for .NET позволяет извлекать файлы, встроенные в слайды как OLE‑объекты, следующим образом:
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий OLE‑объекты, которые нужно извлечь. 
2. Пройдитесь по всем формам в презентации и получайте доступ к формам [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). 
3. Доступ к данным встроенных файлов из OLE‑кадров объектов и запись их на диск. 

В этом C#‑коде показано, как извлечь файлы, встроенные в слайд как OLE‑объекты:
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

**Будут ли OLE‑содержимое отображаться при экспорте слайдов в PDF/изображения?**

Отображается то, что видно на слайде — значок/заменяющее изображение (preview). «Живое» OLE‑содержание не выполняется во время рендеринга. При необходимости задайте собственное изображение‑превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокировать форму: Aspose.Slides предоставляет [shape-level locks](/slides/ru/net/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного внешнего вида используйте рекомендации [Working Solution for Worksheet Resizing](/slides/ru/net/working-solution-for-worksheet-resizing/) — либо подогнать кадр под диапазон, либо масштабировать диапазон до фиксированного кадра и задать подходящее заменяющее изображение.

**Будут ли относительные пути для связанных OLE‑объектов сохраняться в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути есть в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.