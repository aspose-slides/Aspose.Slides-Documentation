---
title: Управление OLE
type: docs
weight: 40
url: /python-net/manage-ole/
keywords: "Добавить OLE, Добавить объект, Встраивание объекта, Связывание и встраивание объектов, OLE объектный фрейм, Встраивание OLE, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавить OLE объект в презентацию PowerPoint на Python"
---

{{% alert title="Информация" color="info" %}}

OLE (Связывание и встраивание объектов) — это технология Microsoft, которая позволяет размещать данные и объекты, созданные в одном приложении, в другом приложении через связывание или встраивание.

{{% /alert %}} 

Рассмотрим диаграмму, созданную в MS Excel. Эта диаграмма затем помещается на слайд PowerPoint. Эта диаграмма Excel считается OLE объектом.

- OLE объект может отображаться в виде значка. В этом случае, когда вы дважды щелкаете на значке, диаграмма открывается в своем соответствующем приложении (Excel), или вас просят выбрать приложение для открытия или редактирования объекта.
- OLE объект может отображать реальные содержимое — например, содержимое диаграммы. В этом случае диаграмма активируется в PowerPoint, интерфейс диаграммы загружается, и вы можете изменять данные диаграммы в приложении PowerPoint.

[Aspose.Slides для Python через .NET](https://products.aspose.com/slides/python-net) позволяет вставлять OLE объекты в слайды в виде OLE объектных фреймов ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Добавление OLE Объектных Фреймов в Слайды**
Предположим, вы уже создали диаграмму в Microsoft Excel и хотите встроить эту диаграмму в слайд в виде OLE объектного фрейма с использованием Aspose.Slides для Python через .NET, вы можете сделать это следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Откройте файл Excel, содержащий объект диаграммы Excel, и сохраните его в `MemoryStream`.
1. Добавьте OLE объектный фрейм на слайд, содержащий массив байтов и другую информацию об OLE объекте.
1. Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили диаграмму из файла Excel на слайд в виде [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) с использованием Aspose.Slides для Python через .NET.  
**Обратите внимание** на то, что конструктор [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/) принимает расширение объекта для встраивания в качестве второго параметра. Это расширение позволяет PowerPoint правильно интерпретировать тип файла и выбрать подходящее приложение для открытия этого OLE объекта.

```py 
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющего PPTX
with slides.Presentation() as pres:
    # Получает доступ к первому слайду
    sld = pres.slides[0]

    # Загружает файл excel в поток
    with open(path + "book1.xlsx", "rb") as fs:
        bytes = fs.read()
    
        # Создает объект данных для встраивания
        dataInfo = slides.dom.ole.OleEmbeddedDataInfo(bytes, "xlsx")

        # Добавляет форму Ole Object Frame
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # Записывает файл PPTX на диск
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Доступ к OLE Объектным Фреймам**
Если OLE объект уже встроен в слайд, вы можете легко найти или получить доступ к этому объекту следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

1. Получите ссылку на слайд, используя его индекс.

1. Получите доступ к форме [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   В нашем примере мы использовали ранее созданный PPTX, который содержит только одну форму на первом слайде. Затем мы *привели* этот объект к [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). Это был желаемый OLE объектный фрейм, к которому нужно получить доступ.

1. Как только OLE объектный фрейм был доступен, вы можете выполнять любые операции с ним.

В приведенном ниже примере к OLE объектному фрейму (объекту диаграммы Excel, встроенному в слайд) производится доступ — а затем его данные файла записываются в файл Excel:

```py 
import aspose.slides as slides

# Загружает PPTX в объект презентации
with slides.Presentation(path + "AccessingOLEObjectFrame.pptx") as pres:
    # Получает доступ к первому слайду
    sld = pres.slides[0]

    # Приводит форму к OleObjectFrame
    oleObjectFrame = sld.shapes[0]

    # Читает OLE объект и записывает его на диск
    if type(oleObjectFrame) is slides.OleObjectFrame:
        # Получает данные встроенного файла
        data = oleObjectFrame.embedded_data.embedded_file_data

        # Получает расширение встроенного файла
        fileExtention = oleObjectFrame.embedded_data.embedded_file_extension

        # Создает путь для сохранения извлеченного файла
        extractedPath = "excelFromOLE_out" + fileExtention

        # Сохраняет извлеченные данные
        with open("out.xlsx", "wb") as fs:
            fs.write(data)
```

## **Изменение Данных OLE Объекта**

Если OLE объект уже встроен в слайд, вы можете легко получить доступ к этому объекту с помощью Aspose.Slides для Python через .NET и изменить его данные следующим образом:

1. Откройте желаемую презентацию, содержащую встроенный OLE объект, создавая экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

1. Получите ссылку на слайд через его индекс.

1. Получите доступ к форме [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   В нашем примере мы использовали ранее созданный PPTX, который содержит только одну форму на первом слайде. Мы затем *привели* этот объект к [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). Это был желаемый OLE объектный фрейм, к которому нужно было получить доступ.

1. Как только OLE объектный фрейм был доступен, вы можете выполнять любые операции с ним.

1. Создайте объект Workbook и получите доступ к OLE данным.

1. Получите доступ к желаемому Worksheet и измените данные.

1. Сохраните обновленный Workbook в потоках.

1. Измените данные OLE объекта из данных потока.

В приведенном ниже примере к OLE объектному фрейму (объекту диаграммы Excel, встроенному в слайд) осуществляется доступ — а затем его данные файла изменяются для изменения данных диаграммы.

```py 
# [TODO: требуется Aspose.Cells для Python через .NET]
```

## Встраивание Других Типов Файлов в Слайды

Кроме диаграмм Excel, Aspose.Slides для Python через .NET позволяет вам встраивать другие типы файлов в слайды. Например, вы можете вставлять HTML, PDF и ZIP файлы в качестве объектов в слайд. Когда пользователь дважды щелкает на вставленном объекте, объект автоматически запускается в соответствующей программе, или пользователь перенаправляется для выбора подходящей программы для открытия объекта.

Этот код на Python показывает, как встроить HTML и ZIP в слайд:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open(path + "index.html", "rb") as fs1:
        htmlBytes = fs1.read()
        dataInfoHtml = slides.dom.ole.OleEmbeddedDataInfo(htmlBytes, "html")
        oleFrameHtml = slide.shapes.add_ole_object_frame(150, 120, 50, 50, dataInfoHtml)
        oleFrameHtml.is_object_icon = True

    with open(path + "archive.zip", "rb") as fs2:
        zipBytes = fs2.read()
        dataInfoZip = slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip")
        oleFrameZip = slide.shapes.add_ole_object_frame(150, 220, 50, 50, dataInfoZip)
        oleFrameZip.is_object_icon = True

    pres.save("embeddedOle.pptx", slides.export.SaveFormat.PPTX)
```

## Установка Типов Файлов для Встроенных Объектов

При работе с презентациями вам может потребоваться заменить старые OLE объекты на новые. Или вам может потребоваться заменить неподдерживаемый OLE объект на поддерживаемый.

Aspose.Slides для Python через .NET позволяет установить тип файла для встроенного объекта. Таким образом, вы можете изменить данные OLE фрейма или его расширение.

Этот код на Python показывает, как установить тип файла для встроенного OLE объекта:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    print("Текущее расширение встроенных данных: " + oleObjectFrame.embedded_data.embedded_file_extension)
   
    with open(path + "1.zip", "rb") as fs2:
        zipBytes = fs2.read()

    oleObjectFrame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip"))
   
    pres.save("embeddedChanged.pptx", slides.export.SaveFormat.PPTX)
```

## Установка Изображений Иконок и Заголовков для Встроенных Объектов

После того как вы встроите OLE объект, автоматически добавляется предварительный просмотр, состоящий из изображения иконки и заголовка. Предварительный просмотр — это то, что пользователи видят до того, как получат доступ или откроют OLE объект.

Если вы хотите использовать конкретное изображение и текст в качестве элементов в предварительном просмотре, вы можете установить изображение иконки и заголовок с помощью Aspose.Slides для Python через .NET.

Этот код на Python показывает, как установить изображение иконки и заголовок для встроенного объекта: 

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    
    with open("img.jpeg", "rb") as in_file:
        oleImage = pres.images.add_image(in_file)

    oleObjectFrame.substitute_picture_title = "Мой заголовок"
    oleObjectFrame.substitute_picture_format.picture.image = oleImage
    oleObjectFrame.is_object_icon = False

    pres.save("embeddedOle-newImage.pptx", slides.export.SaveFormat.PPTX)
```



## Извлечение Встроенных Файлов

Aspose.Slides для Python через .NET позволяет вам извлекать файлы, встроенные в слайды в качестве OLE объектов, следующим образом:

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащий OLE объект, который вы собираетесь извлечь.
2. Пройдитесь через все формы в презентации и получите доступ к форме [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
3. Получите данные встроенного файла из OLE объектного фрейма и запишите их на диск. 

Этот код на Python показывает, как извлечь файл, встроенный в слайд в качестве OLE объекта:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    index = 0
    for shape in slide.shapes:

        if type(shape) is slides.OleObjectFrame:
            data = shape.embedded_data.embedded_file_data
            extension = shape.embedded_data.embedded_file_extension
            
            with open("oleFrame{idx}{ex}".format(idx = str(index), ex = extension), "wb") as fs:
                fs.write(data)
        index += 1
```