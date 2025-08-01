---
title: Сохраняйте презентации с помощью Python
linktitle: Сохранение презентации
type: docs
weight: 80
url: /ru/python-net/save-presentation/
keywords:
- сохранить PowerPoint
- сохранить презентацию
- сохранить PPT
- сохранить PPTX
- сохранить ODP
- сохранить презентацию в файл
- сохранить презентацию в поток
- тип просмотра
- строгий формат Office Open XML
- прогресс сохранения
- Python
- Aspose.Slides
description: "Узнайте, как сохранять презентации в Python с помощью Aspose.Slides—экспортируйте в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---

## **Сохранить презентацию**
В открытии презентации описывается, как использовать класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для открытия презентации. Эта статья объясняет, как создать и сохранить презентации.
Класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаете ли вы презентацию с нуля или модифицируете существующую, по завершении вы хотите сохранить презентацию. С помощью Aspose.Slides для Python через .NET ее можно сохранить как **файл** или **поток**. Эта статья объясняет, как сохранить презентацию различными способами:

### **Сохранение презентации в файлы**
Сохраните презентацию в файлы, вызвав метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Просто передайте имя файла и формат сохранения в метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). В следующих примерах показано, как сохранить презентацию с помощью Aspose.Slides для Python через .NET, используя Python.

```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл PPT
with slides.Presentation() as presentation:
    
    #...выполните некоторые действия здесь...

    # Сохраните вашу презентацию в файл
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Сохранение презентации в потоки**
Можно сохранить презентацию в поток, передав выходной поток в метод Save класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Существует много типов потоков, в которые можно сохранить презентацию. В приведенном ниже примере мы создали новый файл презентации, добавили текст в фигуру и сохранили презентацию в поток.

```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл PPT
with slides.Presentation() as presentation:
    
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 200, 200)

    # Сохраните вашу презентацию в поток
    with open("Save_As_Stream_out.pptx", "bw") as stream:
        presentation.save(stream, slides.export.SaveFormat.PPTX)
```


### **Сохранение презентаций с предопределенным типом просмотра**
Aspose.Slides для Python через .NET предоставляет возможность установить тип просмотра для созданной презентации, когда она открывается в PowerPoint через класс [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/). Свойство [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) используется для установки типа просмотра с помощью перечисления [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл PPT
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("pres-will-open-SlideMasterView.pptx", slides.export.SaveFormat.PPTX)

```

### **Сохранение презентаций в строгом формате Office Open XML**
Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Для этой цели он предоставляет класс [**PptxOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/), где вы можете установить свойство Conformance при сохранении файла презентации. Если вы установите его значение как Conformance.Iso29500_2008_Strict, то выходной файл презентации будет сохранен в строгом формате Office Open XML.

Следующий пример кода создает презентацию и сохраняет ее в строгом формате Office Open XML. При вызове метода Save для презентации объект **[PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** передается в него с установленным свойством [**Conformance**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) как [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/python-net/aspose.slides.export/conformance/).

```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации
with slides.Presentation() as presentation:
    # Получите первый слайд
    slide = presentation.slides[0]

    # Добавьте автозадание типа линия
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    options = slides.export.PptxOptions()
    options.conformance = slides.export.Conformance.ISO29500_2008_STRICT

    # Сохраните презентацию в строгом формате Office Open XML
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX, options)

```


### **Сохранение обновлений прогресса в процентах**
Интерфейс [**IProgressCallback**](https://reference.aspose.com/slides/python-net/aspose.slides/iprogresscallback/) был добавлен в интерфейс [**ISaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/isaveoptions/) и абстрактный класс [**SaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/). Интерфейс **IProgressCallback** представляет собой объект обратного вызова для сохранения обновлений прогресса в процентах.

Следующие фрагменты кода показывают, как использовать интерфейс IProgressCallback:

```py
# [TODO[не поддерживается еще]: реализация python интерфейсов .net]
```

{{% alert title="Информация" color="info" %}}

Используя собственное API, Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/splitter), которое позволяет пользователям разбивать свои презентации на несколько файлов. По сути, приложение сохраняет выбранные слайды из данной презентации как новые файлы PowerPoint (PPTX или PPT). 

{{% /alert %}}