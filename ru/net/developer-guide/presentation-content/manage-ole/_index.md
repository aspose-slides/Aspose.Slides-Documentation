---
title: Управление OLE‑объектами в презентациях на .NET
linktitle: Управление OLE
type: docs
weight: 40
url: /ru/net/manage-ole/
keywords:
- OLE‑объект
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
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для .NET. Встраивайте, обновляйте и экспортируйте OLE‑контент без проблем."
---
## **Введение**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) — технология Microsoft, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении через привязку или внедрение. 

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Затем эта диаграмма помещается на слайд PowerPoint. Такая диаграмма Excel считается OLE‑объектом. 

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке по значку диаграмма открывается в связанном приложении (Excel) или пользователю предлагается выбрать приложение для открытия или редактирования объекта. 
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/ru/net/) позволяет вставлять OLE‑объекты в слайды в виде кадров OLE‑объекта ([OleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe)).

## **Добавление кадров OLE‑объекта в слайды**

Предполагая, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд как кадр OLE‑объекта с помощью Aspose.Slides for .NET, сделайте следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Прочитайте файл Excel в виде массива байтов. 
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe) на слайд, передав массив байтов и другую информацию о OLE‑объекте. 
5. Сохраните изменённую презентацию как файл PPTX. 

В примере ниже мы добавили диаграмму из файла Excel на слайд как [OleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe) с помощью Aspose.Slides for .NET.  **Note** что конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ru/net/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение внедряемого объекта вторым параметром. Это расширение позволяет PowerPoint правильно распознать тип файла и выбрать подходящее приложение для открытия OLE‑объекта.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Подготовьте данные для OLE‑объекта.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Добавьте кадр OLE‑объекта на слайд.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Добавление связанных OLE‑кадров объектов**

Aspose.Slides for .NET позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe) без встраивания данных, а лишь с ссылкой на файл.

Этот код C# показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe) со связанным файлом Excel на слайд:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте кадр OLE‑объекта со связанным файлом Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Доступ к OLE‑кадрам объектов**

Если OLE‑объект уже встроен в слайд, его можно легко найти или получить доступ следующим образом:

1. Загрузите презентацию с вложенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation). 
2. Получите ссылку на слайд, используя его индекс. 
3. Получите форму [OleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe). В нашем примере использовалась ранее созданная PPTX, содержащая единственную форму на первом слайде. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ioleobjectframe). Это и был нужный кадр OLE‑объекта. 
4. После получения доступа к кадру OLE‑объекта вы можете выполнять любые операции с ним. 

В примере ниже доступ к кадру OLE‑объекта (встроенной в слайд диаграмме Excel) и к его файловым данным осуществляется.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получите первую форму как кадр OLE‑объекта.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Получите данные вложенного файла.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Получите расширение вложенного файла.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Доступ к свойствам связанных OLE‑кадров объектов**

Aspose.Slides позволяет получать свойства связанных OLE‑кадров объектов.

Этот код C# показывает, как проверить, является ли OLE‑объект связанным, и получить путь к связанному файлу:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Получите первую форму как кадр OLE‑объекта.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Проверьте, связан ли OLE‑объект.
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

{{% alert color="info" %}} 

В этом разделе пример кода использует [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Если OLE‑объект уже встроен в слайд, его можно легко получить и изменить его данные следующим образом:

1. Загрузите презентацию с вложенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Получите форму [OLEObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe). В нашем примере использовалась ранее созданная PPTX с одной формой на первом слайде. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ioleobjectframe). Это был нужный кадр OLE‑объекта. 
4. После получения доступа к кадру OLE‑объекта вы можете выполнять любые операции с ним. 
5. Создайте объект `Workbook` и получите доступ к OLE‑данным. 
6. Получите требуемый `Worksheet` и измените данные. 
7. Сохраните обновлённый `Workbook` в поток. 
8. Замените данные OLE‑объекта данными из потока. 

В примере ниже доступ к кадру OLE‑объекта (встроенной в слайд диаграмме Excel) получен, и его файловые данные изменены для обновления данных диаграммы.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Изменить данные workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
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

Помимо диаграмм Excel, Aspose.Slides for .NET позволяет встраивать в слайды другие типы файлов. Например, можно вставлять HTML, PDF и ZIP‑файлы в виде объектов. При двойном щелчке пользователя по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователь получает запрос выбрать подходящее приложение для открытия.

Этот код C# показывает, как встроить HTML и ZIP в слайд:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

## **Установка типа файлов для встроенных объектов**

При работе с презентациями может понадобиться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides for .NET позволяет задать тип файла для встроенного объекта, что дает возможность обновить данные кадра OLE или его расширение.

Этот код C# показывает, как установить тип файла для встроенного OLE‑объекта в `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр в виде значка. Этот предварительный просмотр видят пользователи перед доступом к объекту. Если требуется использовать конкретное изображение и текст в качестве элементов предварительного просмотра, можно задать значок и заголовок с помощью Aspose.Slides for .NET.

Этот код C# показывает, как задать изображение значка и заголовок для встроенного объекта: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Предотвращение изменения размера и перемещения кадра OLE‑объекта**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с запросом обновить ссылки. Нажатие кнопки «Update Links» может изменить размер и положение кадра OLE‑объекта, поскольку PowerPoint обновляет данные из связанного OLE‑объекта и обновляет его предварительный просмотр. Чтобы предотвратить запрос PowerPoint на обновление данных объекта, установите свойство `UpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ioleobjectframe/) в `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Сохранить размер и положение кадра OLE‑объекта при обновлении ссылки PowerPoint.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Извлечение встроенных файлов**

Aspose.Slides for .NET позволяет извлекать файлы, встроенные в слайды как OLE‑объекты, следующим образом:
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation), содержащего OLE‑объекты, которые необходимо извлечь. 
2. Пройдитесь по всем формам в презентации и получите формы [OLEObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe). 
3. Получите данные встроенных файлов из кадров OLE‑объекта и запишите их на диск. 

Этот код C# показывает, как извлечь файлы, встроенные в слайд как OLE‑объекты:

```c#
using Aspose.Slides;

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

### **Будет ли содержимое OLE отображаться при экспорте слайдов в PDF/изображения?**

Отображается то, что видно на слайде — значок/заместительное изображение (preview). «Живое» содержимое OLE не исполняется при рендеринге. При необходимости задайте собственное изображение превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.

### **Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте форму: Aspose.Slides предоставляет [shape-level locks](/slides/ru/net/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные правки и перемещения.

### **Почему связанный объект Excel «перепрыгивает» или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Для стабильного отображения используйте рекомендации из [Working Solution for Worksheet Resizing](/slides/ru/net/working-solution-for-worksheet-resizing/) — либо подгоните кадр под диапазон, либо масштабируйте диапазон до фиксированного кадра и задайте соответствующее заменяющее изображение.

### **Будут ли относительные пути для связанных OLE‑объектов сохранены в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути встречаются в более старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.