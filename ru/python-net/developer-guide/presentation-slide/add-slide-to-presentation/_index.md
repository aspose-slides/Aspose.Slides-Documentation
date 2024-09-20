---
title: Добавить слайд в презентацию
type: docs
weight: 10
url: /python-net/add-slide-to-presentation/
keywords: "Добавить слайд в презентацию, Python, Aspose.Slides"
description: "Добавить слайд в презентацию на Python"
---

## **Добавить слайд в презентацию**
Перед тем как говорить о добавлении слайдов в файлы презентаций, давайте обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит мастер/макетный слайд и другие обычные слайды. Это означает, что файл презентации содержит по крайней мере один или больше слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides для Python через .NET. Каждый слайд имеет уникальный идентификатор, и все обычные слайды организованы в порядке, указанном на основе нулевого индекса. Aspose.Slides для Python через .NET позволяет разработчикам добавлять пустые слайды в свои презентации. Чтобы добавить пустой слайд в презентацию, пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), установив ссылку на свойство Slides (коллекция объектов слайдов) объекта Presentation.
- Добавьте пустой слайд в презентацию в конце коллекции обычных слайдов, вызвав методы AddEmptySlide, предоставленные объектом ISlideCollection.
- Выполните некоторые действия с вновь добавленным пустым слайдом.
- Наконец, сохраните файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, который представляет файл презентации
with slides.Presentation() as pres:
    # Создайте экземпляр класса SlideCollection
    slds = pres.slides

    for i in range(len(pres.layout_slides)):
        # Добавьте пустой слайд в коллекцию Slides
        slds.add_empty_slide(pres.layout_slides[i])
        
    # Выполните некоторые действия с вновь добавленным слайдом

    # Сохраните файл PPTX на диск
    pres.save("EmptySlide.pptx", slides.export.SaveFormat.PPTX)
```