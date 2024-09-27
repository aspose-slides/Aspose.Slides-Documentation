---
title: Управление OLE
type: docs
weight: 40
url: /ru/net/manage-ole/
keywords: "Добавить OLE, Добавить объект, Вставить объект, Связывание и встраивание объектов, OLE Object Frame, Вставить OLE, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET "
description: "Добавьте OLE-объект в презентацию PowerPoint на C# или .NET"
---

{{% alert title="Информация" color="info" %}}

OLE (Связывание и встраивание объектов) — это технология Microsoft, которая позволяет размещать данные и объекты, созданные в одном приложении, в другом приложении через связывание или встраивание.

{{% /alert %}}

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма затем размещается внутри слайда PowerPoint. Эта диаграмма Excel считается OLE-объектом.

- OLE-объект может отображаться в виде значка. В этом случае, когда вы дважды щелкаете значок, диаграмма открывается в связанном приложении (Excel), или вам предлагают выбрать приложение для открытия или редактирования объекта.
- OLE-объект может отображать фактическое содержимое, например, содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, интерфейс диаграммы загружается, и вы можете изменить данные диаграммы в приложении PowerPoint.

[Aspose.Slides для .NET](https://products.aspose.com/slides/net/) позволяет вставлять OLE-объекты в слайды в качестве OLE Object Frames ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Добавление OLE Object Frame в слайды**
Предположим, вы уже создали диаграмму в Microsoft Excel и хотите встроить эту диаграмму в слайд в качестве OLE Object Frame с использованием Aspose.Slides для .NET, вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс.
3. Откройте файл Excel, содержащий объект диаграммы Excel, и сохраните его в `MemoryStream`.
4. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд, содержащий массив байтов и другую информацию об OLE-объекте.
5. Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили диаграмму из файла Excel на слайд в качестве [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) с использованием Aspose.Slides для .NET.  
**Примечание**: конструктор [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo) принимает расширение встраиваемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint корректно интерпретировать тип файла и выбрать правильное приложение для открытия этого OLE-объекта.

```csharp
// Создает экземпляр класса Presentation, который представляет файл PPTX
using (Presentation pres = new Presentation())
{
    // Получает доступ к первому слайду
    ISlide sld = pres.Slides[0];

    // Загружает файл excel в поток
    MemoryStream mstream = new MemoryStream();
    using (FileStream fs = new FileStream("book1.xlsx", FileMode.Open, FileAccess.Read))
    {
        byte[] buf = new byte[4096];

        while (true)
        {
            int bytesRead = fs.Read(buf, 0, buf.Length);
            if (bytesRead <= 0)
                break;
            mstream.Write(buf, 0, bytesRead);
        }
    }

    // Создает объект данных для встраивания
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.ToArray(), "xlsx");

    // Добавляет форму Ole Object Frame
    IOleObjectFrame oleObjectFrame = sld.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width,
        pres.SlideSize.Size.Height, dataInfo);

    // Записывает файл PPTX на диск
    pres.Save("OleEmbed_out.pptx", SaveFormat.Pptx);
}
```
### Добавление Linked OLE Object frames

Aspose.Slides для .NET позволяет добавлять [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) без встраивания данных, а только с ссылкой на файл.

Этот код на C# показывает, как добавить [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) с связанным файлом Excel на слайд:

```csharp 
using (Presentation pres = new Presentation())
{
	// Получает доступ к первому слайду
	ISlide slide = pres.Slides[0];

	// Добавляет Ole Object Frame с связанным файлом Excel
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book1.xlsx");

	// Записывает файл PPTX на диск
	pres.Save("OleLinked_out.pptx", SaveFormat.Pptx);
}
```

## **Доступ к OLE Object Frames**
Если OLE-объект уже встроен в слайд, вы можете легко найти или получить доступ к этому объекту следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к форме [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   В нашем примере мы использовали ранее созданный PPTX, на первом слайде которого есть только одна форма. Мы затем *привели* этот объект к [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). Это был желаемый OLE Object Frame, к которому нужно было получить доступ.
4. После доступа к OLE Object Frame вы можете выполнять любые операции с ним.
В приведенном ниже примере доступ к OLE Object Frame (встроенный в слайд объект диаграммы Excel) – и затем его данные файла записываются в файл Excel:
```csharp 
// Загружает PPTX в объект презентации
using (Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx"))
{
    // Получает доступ к первому слайду
    ISlide sld = pres.Slides[0];

    // Приводит форму к OleObjectFrame
    OleObjectFrame oleObjectFrame = sld.Shapes[0] as OleObjectFrame;

    // Читает OLE-объект и записывает его на диск
    if (oleObjectFrame != null)
    {
        // Получает встроенные данные файла
        byte[] data = oleObjectFrame.EmbeddedData.EmbeddedFileData;

        // Получает расширение встроенного файла
        string fileExtention = oleObjectFrame.EmbeddedData.EmbeddedFileExtension;

        // Создает путь для сохранения извлеченного файла
        string extractedPath = "excelFromOLE_out" + fileExtention;

        // Сохраняет извлеченные данные
        using (FileStream fstr = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))
        {
            fstr.Write(data, 0, data.Length);
        }
    }
}
```

### Доступ к свойствам Linked OLE Object Frames

Aspose.Slides позволяет вам получать доступ к свойствам связанных OLE Object Frame.

Этот код на C# показывает, как проверить, связан ли OLE-объект, а затем получить путь к связанному файлу:
```csharp
using (Presentation pres = new Presentation("OleLinked.ppt"))
{
	// Получает доступ к первому слайду
	ISlide slide = pres.Slides[0];

	// Получает первую форму как Ole Object Frame
	OleObjectFrame oleObjectFrame = slide.Shapes[0] as OleObjectFrame;

	// Проверяет, связан ли Ole Object.
	if (oleObjectFrame != null && oleObjectFrame.IsObjectLink)
	{
		// Печатает полный путь к связанному файлу
		Console.WriteLine("Ole Object Frame связан с: " + oleObjectFrame.LinkPathLong);

		// Печатает относительный путь к связанному файлу, если он присутствует.
		// Только презентации PPT могут содержать относительный путь.
		string relativePath = oleObjectFrame.LinkPathRelative;
		if (!string.IsNullOrEmpty(relativePath))
		{
			Console.WriteLine("Относительный путь Ole Object Frame: " + oleObjectFrame.LinkPathRelative);
		}
	}
}
```
## **Изменение данных OLE Object**

Если OLE-объект уже встроен в слайд, вы можете легко получить к нему доступ и изменить его данные следующим образом:

1. Откройте желаемую презентацию с встроенным OLE-объектом, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс. 
3. Получите доступ к форме [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   В нашем примере мы использовали ранее созданный PPTX, на первом слайде которого есть одна форма. Мы затем *привели* этот объект к [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). Это был желаемый OLE Object Frame, к которому нужно было получить доступ.
4. После доступа к OLE Object Frame вы можете выполнять любые операции с ним.
5. Создайте объект Workbook и получите доступ к данным OLE.
6. Получите доступ к нужному рабочему листу и измените данные.
7. Сохраните обновленную книгу в потоках.
8. Измените данные OLE-объекта с помощью данных из потока.
В приведенном ниже примере доступ к OLE Object Frame (встроенный в слайд объект диаграммы Excel) – и затем его данные файла изменяются, чтобы изменить данные диаграммы:
```csharp 
using (Presentation pres = new Presentation("ChangeOLEObjectData.pptx"))
{
    ISlide slide = pres.Slides[0];

    OleObjectFrame ole = null;

    // Перебирает все формы для Ole frame
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is OleObjectFrame)
        {
            ole = (OleObjectFrame)shape;
        }
    }

    if (ole != null)
    {
        using (MemoryStream msln = new MemoryStream(ole.EmbeddedData.EmbeddedFileData))
        {
            // Читает данные объекта в Workbook
            Workbook Wb = new Workbook(msln);

            using (MemoryStream msout = new MemoryStream())
            {
                // Изменяет данные книги
                Wb.Worksheets[0].Cells[0, 4].PutValue("E");
                Wb.Worksheets[0].Cells[1, 4].PutValue(12);
                Wb.Worksheets[0].Cells[2, 4].PutValue(14);
                Wb.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                Wb.Save(msout, so1);

                // Изменяет данные объекта Ole Frame
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.ToArray(), ole.EmbeddedData.EmbeddedFileExtension);
                ole.SetEmbeddedData(newData);
            }
        }
    }

    pres.Save("OleEdit_out.pptx", SaveFormat.Pptx);
}
```
## **Встраивание других типов файлов в слайды**

Помимо диаграмм Excel, Aspose.Slides для .NET позволяет встроить другие типы файлов в слайды. Например, вы можете вставить файлы HTML, PDF и ZIP в качестве объектов на слайде. Когда пользователь дважды щелкает на вставленном объекте, объект автоматически запускается в соответствующей программе, или пользователь перенаправляется для выбора подходящей программы для открытия объекта. 

Этот код на C# показывает, как встроить HTML и ZIP в слайд:

```csharp
using (Presentation pres = new Presentation())
{
  ISlide slide = pres.Slides[0];
  
  byte[] htmlBytes = File.ReadAllBytes("embedOle.html");
  IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
  IOleObjectFrame oleFrameHtml = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
  oleFrameHtml.IsObjectIcon = true;

  byte[] zipBytes = File.ReadAllBytes("embedOle.zip");
  IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
  IOleObjectFrame oleFrameZip = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, dataInfoZip);
  oleFrameZip.IsObjectIcon = true;

  pres.Save("embeddedOle.pptx", SaveFormat.Pptx);
}
```
## **Установка типов файлов для встроенных объектов**

При работе с презентациями вам может понадобиться заменить старые OLE-объекты новыми. Или вам может понадобиться заменить неподдерживаемый OLE-объект на поддерживаемый. 

Aspose.Slides для .NET позволяет установить тип файла для встроенного объекта. Таким образом, вы можете изменить данные OLE-рамки или ее расширение. 

Этот код на C# показывает, как установить тип файла для встроенного OLE-объекта:

```csharp
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    Console.WriteLine($"Текущее расширение встроенных данных: {oleObjectFrame.EmbeddedData.EmbeddedFileExtension}");
   
    oleObjectFrame.SetEmbeddedData(new OleEmbeddedDataInfo(File.ReadAllBytes("embedOle.zip"), "zip"));
   
    pres.Save("embeddedChanged.pptx", SaveFormat.Pptx);
}
```
## **Установка изображений значков и заголовков для встроенных объектов**

После встраивания OLE-объекта автоматически добавляется предварительный просмотр, состоящий из изображения значка и заголовка. Предварительный просмотр — это то, что пользователи видят перед тем, как получить доступ к OLE-объекту или открыть его. 

Если вы хотите использовать конкретное изображение и текст в качестве элементов в предварительном просмотре, вы можете установить изображение значка и заголовок с помощью Aspose.Slides для .NET.

Этот код на C# показывает, как установить изображение значка и заголовок для встроенного объекта: 

```csharp
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];

    IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    oleObjectFrame.SubstitutePictureTitle = "Мой заголовок";
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleObjectFrame.IsObjectIcon = false;

    pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```
## **Извлечение встроенных файлов**

Aspose.Slides для .NET позволяет извлекать файлы, встроенные в слайды в качестве OLE-объектов, следующим образом:
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который содержит OLE-объект, который вы собираетесь извлечь.
2. Переберите все формы в презентации и получите доступ к форме [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. Получите данные встроенного файла из OLE Object Frame и запишите их на диск. 
Этот код на C# показывает, как извлечь файл, встроенный в слайд в качестве OLE-объекта:
```csharp
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];

    for (var index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;
        
        if (oleFrame != null)
        {
            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
            
            File.WriteAllBytes($"oleFrame{index}{extension}", data);
        }
    }
}
```