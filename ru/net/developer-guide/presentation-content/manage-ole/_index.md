---
title: У管理 OLE-объектами в презентациях на .NET
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
description: "Оптимизируйте управление OLE‑объектами в PowerPoint и файлах OpenDocument с помощью Aspose.Slides для .NET. Встраивайте, обновляйте и экспортируйте OLE‑контент без усилий."
---
## **Введение**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) — Microsoft технология, позволяющая размещать данные и объекты, созданные в одном приложении, в другом приложении через связывание или внедрение. 
{{% /alert %}}

Рассмотрим диаграмму, созданную в MS Excel. Затем эта диаграмма помещается в слайд PowerPoint. Эта диаграмма Excel считается OLE‑объектом.

- OLE‑объект может отображаться в виде значка. В этом случае при двойном щелчке по значку диаграмма откроется в связанном приложении (Excel), либо будет предложено выбрать приложение для открытия или редактирования объекта. 
- OLE‑объект может показывать своё фактическое содержимое, например содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, загружается её интерфейс, и вы можете изменять данные диаграммы непосредственно в PowerPoint.

[Aspose.Slides для .NET](https://products.aspose.com/slides/net/) позволяет вставлять OLE‑объекты в слайды в виде OLE‑объектных фреймов ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Добавление OLE‑объектных фреймов в слайды**

Предполагая, что вы уже создали диаграмму в Microsoft Excel и хотите внедрить её в слайд в виде OLE‑объектного фрейма с помощью Aspose.Slides для .NET, вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Прочитайте файл Excel как массив байтов.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд, содержащий массив байтов и другую информацию об OLE‑объекте.
5. Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили диаграмму из файла Excel на слайд в виде [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) с помощью Aspose.Slides для .NET. **Примечание**: конструктор [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) принимает расширение внедряемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать соответствующее приложение для открытия этого OLE‑объекта.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Подготовьте данные для OLE-объекта.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Добавьте OLE-объектный фрейм на слайд.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Добавление связанных OLE‑объектных фреймов**

Aspose.Slides для .NET позволяет добавить [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) без встраивания данных, а только с ссылкой на файл.

Этот код на C# показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) со связанным файлом Excel на слайд:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте OLE-объектный фрейм со связанным файлом Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Доступ к OLE‑объектным фреймам**

Если OLE‑объект уже встроен в слайд, вы можете легко найти или получить к нему доступ следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к фигуре [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде только одна фигура. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Это был нужный OLE‑объектный фрейм для доступа.
4. После получения доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним.

В приведённом ниже примере доступ к OLE‑объектному фрейму (объекту диаграммы Excel, встроенному в слайд) и его файловым данным получен.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получите первую фигуру как OLE-объектный фрейм.
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

Этот код на C# показывает, как проверить, связан ли OLE‑объект, и затем получить путь к связанному файлу:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Получите первую фигуру как OLE-объектный фрейм.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Проверьте, связан ли OLE-объект.
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

{{% alert color="info" title="Note" %}}
В этом разделе приведённый ниже пример кода использует [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/).
{{% /alert %}}

Если OLE‑объект уже внедрён в слайд, вы можете легко получить доступ к этому объекту и изменить его данные следующим образом:

1. Загрузите презентацию с встроенным OLE‑объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к фигуре [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   В нашем примере мы использовали ранее созданный PPTX, в котором на первом слайде одна фигура. Затем мы *привели* этот объект к типу [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Это был нужный OLE‑объектный фрейм для доступа.
4. После получения доступа к OLE‑объектному фрейму вы можете выполнять любые операции с ним.
5. Создайте объект `Workbook` и получите доступ к OLE‑данным.
6. Получите доступ к нужному `Worksheet` и измените данные.
7. Сохраните обновлённый `Workbook` в поток.
8. Замените данные OLE‑объекта из потока.

В приведённом ниже примере доступа к OLE‑объектному фрейму (объекту диаграммы Excel, внедрённому в слайд) получен, а его файловые данные изменены для обновления данных диаграммы.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получите первую фигуру как OLE‑объектный фрейм.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Прочитайте данные OLE‑объекта как объект Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Измените данные workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Измените данные объекта OLE‑фрейма.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides для .NET позволяет встраивать в слайды другие типы файлов. Например, можно вставлять файлы HTML, PDF и ZIP в виде объектов. При двойном щелчке пользователя по вставленному объекту он автоматически открывается в соответствующей программе, либо пользователю предлагается выбрать подходящую программу для открытия.

Этот код на C# показывает, как встроить HTML и ZIP в слайд:

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

## **Установка типов файлов для встроенных объектов**

При работе с презентациями может потребоваться заменить старые OLE‑объекты новыми или заменить неподдерживаемый OLE‑объект поддерживаемым. Aspose.Slides для .NET позволяет задать тип файла для встроенного объекта, что позволяет обновить данные OLE‑фрейма или его расширение.

Этот код на C# показывает, как установить тип файла для встроенного OLE‑объекта в `zip`:

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

    // Измените тип файла на ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE‑объекта автоматически добавляется предварительный просмотр, состоящий из изображения значка. Этот предварительный просмотр видят пользователи перед доступом к OLE‑объекту или его открытием. Если вы хотите использовать определённое изображение и текст в качестве элементов предварительного просмотра, вы можете задать изображение значка и заголовок с помощью Aspose.Slides для .NET.

Этот код на C# показывает, как установить изображение значка и заголовок для встроенного объекта: 

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

    // Задайте заголовок и изображение для превью OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Предотвращение изменения размера и перемещения OLE‑объектного фрейма**

После добавления связанного OLE‑объекта в слайд презентации, при открытии презентации в PowerPoint может появиться сообщение с просьбой обновить ссылки. Нажатие кнопки "Update Links" может изменить размер и положение OLE‑объектного фрейма, потому что PowerPoint обновляет данные из связанного OLE‑объекта и обновляет предварительный просмотр. Чтобы предотвратить запрос PowerPoint об обновлении данных объекта, установите свойство `UpdateAutomatic` интерфейса [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) в значение `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Сохраняйте размер и положение OLE‑объектного фрейма, когда PowerPoint обновляет ссылку.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Извлечение встроенных файлов**

Aspose.Slides для .NET позволяет извлекать файлы, встроенные в слайды в виде OLE‑объектов, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего OLE‑объекты, которые вы планируете извлечь.
2. Пройдитесь по всем фигурам в презентации и получите доступ к фигурам [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. Получите данные встроенных файлов из OLE‑объектных фреймов и запишите их на диск.

Этот код на C# показывает, как извлечь файлы, встроенные в слайд, в виде OLE‑объектов:

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

**Будет ли содержимое OLE отображаться при экспорте слайдов в PDF/изображения?**

На слайде рендерится только то, что видно — значок/замещающее изображение (превью). "Живое" содержимое OLE не исполняется при рендеринге. При необходимости задайте собственное изображение превью, чтобы обеспечить ожидаемый вид в экспортированном PDF.  
Чтобы также сохранить встроенный файл как вложение PDF, установите [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) в `true`. Эта опция отключена по умолчанию. Для примера и инструкций по проверке вложения см. [Preserve Embedded OLE Files as PDF Attachments](/slides/ru/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Как заблокировать OLE‑объект на слайде, чтобы пользователи не могли перемещать/редактировать его в PowerPoint?**

Заблокируйте фигуру: Aspose.Slides предоставляет [shape-level locks](/slides/ru/net/applying-protection-to-presentation/). Это не шифрование, но эффективно предотвращает случайные изменения и перемещения.

**Почему связанный объект Excel "перепрыгивает" или меняет размер при открытии презентации?**

PowerPoint может обновлять превью связанного OLE. Чтобы обеспечить стабильный вид, следуйте рекомендациям из [Working Solution for Worksheet Resizing](/slides/ru/net/working-solution-for-worksheet-resizing/) — либо подгоните фрейм под диапазон, либо масштабируйте диапазон к фиксированному фрейму и задайте подходящее заменяющее изображение.

**Сохранятся ли относительные пути для связанных OLE‑объектов в формате PPTX?**

В PPTX информация о «относительном пути» недоступна — сохраняется только полный путь. Относительные пути присутствуют в старом формате PPT. Для переносимости предпочтительнее использовать надёжные абсолютные пути/доступные URI или встраивание.