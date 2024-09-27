---
title: Управление OLE
type: docs
weight: 40
url: /ru/java/manage-ole/
---

{{% alert color="primary" %}} 

OLE (Объектное связывание и внедрение) — это технология Microsoft, которая позволяет размещать данные и объекты, созданные в одном приложении, в другом приложении через связывание или внедрение. 

{{% /alert %}} 

Рассмотрите диаграмму, созданную в MS Excel. Диаграмма затем размещается внутри слайда PowerPoint. Эта диаграмма Excel считается объектом OLE. 

- Объект OLE может отображаться в виде значка. В этом случае, когда вы дважды щелкаете значок, диаграмма открывается в связанном приложении (Excel), или вас просят выбрать приложение для открытия или редактирования объекта. 
- Объект OLE может отображать его фактическое содержимое, например, содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, интерфейс диаграммы загружается, и вы можете изменить данные диаграммы в приложении PowerPoint.

[Aspose.Slides для Java](https://products.aspose.com/slides/java/) позволяет вставлять объекты OLE в слайды в виде рамок объектов OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Добавление рамок объектов OLE на слайды**
Предположим, вы уже создали диаграмму в Microsoft Excel и хотите внедрить эту диаграмму в слайд в качестве рамки объекта OLE с помощью Aspose.Slides для Java. Вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
1. Получите ссылку на слайд, используя его индекс.
1. Откройте файл Excel, содержащий объект диаграммы Excel, и сохраните его в `MemoryStream`.
1. Добавьте [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) на слайд, содержащий массив байтов и другую информацию об объекте OLE.
1. Запишите изменённую презентацию как файл PPTX.

В приведенном ниже примере мы добавили диаграмму из файла Excel на слайд в качестве рамки объекта OLE с использованием Aspose.Slides для Java. 
**Обратите внимание**, что конструктор [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IOleEmbeddedDataInfo) принимает расширение встраиваемого объекта в качестве второго параметра. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать правильное приложение для открытия этого объекта OLE.

``` java 
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Загружает файл Excel в поток
    FileInputStream fs = new FileInputStream("book1.xlsx");
    ByteArrayOutputStream mstream = new ByteArrayOutputStream();
    byte[] buf = new byte[4096];
    while (true)
    {
        int bytesRead = fs.read(buf, 0, buf.length);
        if (bytesRead <= 0)
            break;
        mstream.write(buf, 0, bytesRead);
    }
    fs.close();

    // Создает объект данных для внедрения
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // Добавляет объект рамки Ole
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    // Сохраняет PPTX файл на диск
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к рамкам объектов OLE**
Если объект OLE уже встроен в слайд, вы можете легко найти или получить доступ к этому объекту следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к рамке объекта OLE.

   В нашем примере мы использовали ранее созданный PPTX, который имеет только одну фигуру на первом слайде. Затем мы *привели* этот объект к типу [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). Это была желаемая рамка объекта OLE, к которой нужно было получить доступ.
1. После доступа к рамке объекта OLE вы можете выполнять любые операции с ней.

В приведенном ниже примере происходит доступ к рамке объекта OLE (объект диаграммы Excel, встроенный в слайд), и затем его данные файла записываются в файл Excel.

``` java 
// Загружает PPTX в объект Presentation
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Приводит фигуру к OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // Читает OLE объект и записывает его на диск
    if (oleObjectFrame != null) {
        // Получает встроенные данные файла
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // Получает расширение встроенного файла
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // Создает путь для сохранения извлеченного файла
        String extractedPath = "excelFromOLE_out" + fileExtention;

        // Сохраняет извлеченные данные
        FileOutputStream fstr = new FileOutputStream(extractedPath);
        try {
            fstr.write(data, 0, data.length);
        } finally {
            fstr.close();
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменение данных объекта OLE**

Если объект OLE уже встроен в слайд, вы можете легко получить доступ к этому объекту и изменить его данные следующим образом:

1. Откройте желаемую презентацию с встроенным объектом OLE, создав экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
1. Получите ссылку на слайд, используя его индекс. 
1. Получите доступ к рамке объекта OLE.

   В нашем примере мы использовали ранее созданный PPTX, который имеет только одну фигуру на первом слайде. Мы затем *привели* этот объект к типу [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). Это была желаемая рамка объекта OLE, к которой нужно было получить доступ.
1. Как только рамка объекта OLE будет получена, вы можете выполнять с ней любые операции.
1. Создайте объект Workbook и получите доступ к данным OLE.
1. Получите доступ к необходимому листу и измените данные.
1. Сохраните обновленный Workbook в потоках.
1. Измените данные объекта OLE из данных потока.

В приведенном ниже примере происходит доступ к рамке объекта OLE (объект диаграммы Excel, встроенный в слайд), и затем данные файла изменяются, чтобы изменить данные диаграммы:

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // Проходит по всем фигурам для поиска рамки Ole
    for (IShape shape : slide.getShapes()) 
    {
        if (shape instanceof OleObjectFrame) 
        {
            ole = (OleObjectFrame) shape;
        }
    }

    if (ole != null) {
        ByteArrayInputStream msln = new ByteArrayInputStream(ole.getEmbeddedData().getEmbeddedFileData());
        try {
            // Читает данные объекта в Workbook
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // Изменяет данные книги
                Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
                Wb.save(msout, so1);

                // Изменяет данные объекта рамки Ole
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.toByteArray(), ole.getEmbeddedData().getEmbeddedFileExtension());
                ole.setEmbeddedData(newData);
            } finally {
                if (msout != null) msout.close();
            }
        } finally {
            if (msln != null) msln.close();
        }
    }

    pres.save("OleEdit_out.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Внедрение других типов файлов в слайды

Кроме диаграмм Excel, Aspose.Slides для Java позволяет вам внедрять другие типы файлов в слайды. Например, вы можете вставлять файлы HTML, PDF и ZIP в качестве объектов на слайд. Когда пользователь дважды щелкает на вставленном объекте, объект автоматически запускается в соответствующей программе или пользователю предлагается выбрать подходящую программу для открытия объекта. 

Этот код на Java показывает, как внедрить HTML и ZIP в слайд:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    byte[] htmlBytes = Files.readAllBytes(Paths.get("embedOle.html"));
    IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
    IOleObjectFrame oleFrameHtml = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
    oleFrameHtml.setObjectIcon(true);

    byte[] zipBytes = Files.readAllBytes(Paths.get("embedOle.zip"));
    IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
    IOleObjectFrame oleFrameZip = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, dataInfoZip);
    oleFrameZip.setObjectIcon(true);

    pres.save("embeddedOle.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Установка типов файлов для встроенных объектов

При работе с презентациями вам может понадобиться заменить старые объекты OLE на новые. Или вам может понадобиться заменить неподдерживаемый объект OLE на поддерживаемый. 

Aspose.Slides для Java позволяет вам устанавливать тип файла для встроенного объекта. Таким образом, вы можете изменить данные рамки OLE или его расширение. 

Этот код на Java показывает, как установить тип файла для встроенного объекта OLE:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("Текущее расширение встроенных данных: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Установка изображений значков и заголовков для встроенных объектов

После того как вы встраиваете объект OLE, предварительный просмотр, состоящий из изображения значка и заголовка, добавляется автоматически. Предварительный просмотр — это то, что видят пользователи, прежде чем они получат доступ или откроют объект OLE. 

Если вы хотите использовать конкретное изображение и текст в качестве элементов в предварительном просмотре, вы можете установить изображение значка и заголовок, используя Aspose.Slides для Java. 

Этот код на Java показывает, как установить изображение значка и заголовок для встроенного объекта: 

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

        IPPImage oleImage;
        IImage image = Images.fromFile("image.png");
        try {
             oleImage = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    oleObjectFrame.setSubstitutePictureTitle("Мой заголовок");
    oleObjectFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleObjectFrame.setObjectIcon(false);

    pres.save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Извлечение встроенных файлов

Aspose.Slides для Java позволяет вам извлекать файлы, встроенные в слайды в качестве объектов OLE следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащего объект OLE, который вы собираетесь извлечь.
2. Пройдите через все фигуры в презентации и получите доступ к фигуре [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).
3. Получите доступ к данным встроенного файла из рамки объекта OLE и запишите их на диск. 

Этот код на Java показывает, как извлечь файл, встроенный в слайд в качестве объекта OLE:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    for (int index = 0; index < slide.getShapes().size(); index++)
    {
        IShape shape = slide.getShapes().get_Item(index);
        IOleObjectFrame oleFrame = (IOleObjectFrame)shape;

        if (oleFrame != null) 
		{
            byte[] data = oleFrame.getEmbeddedData().getEmbeddedFileData();
            String extension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

            // Сохраняет извлеченные данные
            FileOutputStream fstr = new FileOutputStream("oleFrame" + index + extension);
            try {
                fstr.write(data, 0, data.length);
            } finally {
                fstr.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```