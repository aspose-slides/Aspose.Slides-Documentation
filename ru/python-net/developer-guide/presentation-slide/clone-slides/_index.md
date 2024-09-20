---
title: Клонировать слайды
type: docs
weight: 40
url: /python-net/clone-slides/
keywords: "Клонировать слайд, Копировать слайд, Сохранить копию слайда, PowerPoint, Презентация, Python, Aspose.Slides"
description: "Клонировать слайд PowerPoint на Python"
---

## **Клонирование слайдов в презентации**
Клонирование – это процесс создания точной копии или реплики чего-либо. Aspose.Slides для Python через .NET также позволяет создать копию или клон любого слайда и затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайда создает новый слайд, который может быть изменен разработчиками без изменения оригинального слайда. Существует несколько возможных способов клонирования слайда:

- Клонировать в конце презентации.
- Клонировать в другое место в презентации.
- Клонировать в конце другой презентации.
- Клонировать в другое место в другой презентации.
- Клонировать в конкретном месте в другой презентации.

В Aspose.Slides для Python через .NET (коллекция объектов [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), предоставляемая объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) предоставляет методы [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) и [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) для выполнения вышеуказанных типов клонирования слайдов.
## **Клонировать в конце презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) в соответствии со следующими шагами:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Создайте экземпляр класса [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), ссылаясь на коллекцию слайдов, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Вызовите метод [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), предоставляемый объектом [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), и передайте слайд, который нужно клонировать, в качестве параметра методу [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
3. Запишите измененный файл презентации.

В приведенном ниже примере мы клонировали слайд (расположенный на первой позиции – индекс 0 – презентации) в конец презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации
with slides.Presentation(path + "CloneWithinSamePresentationToEnd.pptx") as pres:
    # Клонируйте нужный слайд в конец коллекции слайдов в той же презентации
    slds = pres.slides

    slds.add_clone(pres.slides[0])

    # Сохраните измененную презентацию на диск
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонировать в другое место в презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом месте, используйте метод [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Создайте экземпляр класса, ссылаясь на коллекцию **Slides**, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Вызовите метод [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/), предоставляемый объектом [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), и передайте слайд для клонирования вместе с индексом для новой позиции в качестве параметра методу [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).
1. Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы клонировали слайд (расположенный на нулевом индексе – позиции 1 – презентации) в индекс 1 – позиция 2 – презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации
with slides.Presentation(path + "CloneWithInSamePresentation.pptx") as pres:
    # Клонируйте нужный слайд в конец коллекции слайдов в той же презентации
    slds = pres.slides

    # Клонируйте нужный слайд в указанном индексе в той же презентации
    slds.insert_clone(2, pres.slides[1])

    # Сохраните измененную презентацию на диск
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонировать в конце другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другом файле презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащий презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащий целевую презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), ссылаясь на коллекцию **Slides**, предоставляемую объектом Presentation целевой презентации.
1. Вызовите метод [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), предоставляемый объектом [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), и передайте слайд из исходной презентации в качестве параметра методу [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд (с первого индекса исходной презентации) в конец целевой презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, чтобы загрузить исходный файл презентации
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Создайте экземпляр класса Presentation для целевой PPTX (куда будет клонироваться слайд)
    with slides.Presentation() as destPres:
        # Клонируйте нужный слайд из исходной презентации в конец коллекции слайдов в целевой презентации
        slds = destPres.slides
        slds.add_clone(srcPres.slides[0])

        # Сохраните целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонировать в другое место в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другом файле презентации, в конкретном месте:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащий исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащий презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), ссылаясь на коллекцию Slides, предоставляемую объектом Presentation целевой презентации.
1. Вызовите метод [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/), предоставленный объектом [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметра методу [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, чтобы загрузить исходный файл презентации
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Создайте экземпляр класса Presentation для целевой PPTX (куда будет клонироваться слайд)
    with slides.Presentation("Aspose2_out.pptx") as destPres:
        slds = destPres.slides
        slds.insert_clone(2, srcPres.slides[0])

        # Сохраните целевую презентацию на диск
        destPres.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонировать в конкретном месте в другой презентации**
Если вам нужно клонировать слайд с мастер-слайдом из одной презентации и использовать его в другой презентации, вам сначала нужно клонировать желаемый мастер-слайд из исходной презентации в целевую презентацию. Затем вам нужно использовать этот мастер-слайд для клонирования слайда с мастер-слайдом. Метод **add_clone(ISlide, IMasterSlide)** ожидает мастер-слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащего целевую презентацию, в которую будет клонироваться слайд.
1. Получите слайд, который нужно клонировать, вместе с мастер-слайдом.
1. Создайте экземпляр класса [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/), ссылаясь на коллекцию мастеров, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) целевой презентации.
1. Вызовите метод [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), предоставленный объектом [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/), и передайте мастер из исходного PPTX, который нужно клонировать, в качестве параметра методу [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), установив ссылку на коллекцию слайдов, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) целевой презентации.
2. Вызовите метод [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), предоставленный объектом [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), и передайте слайд из исходной презентации для клонирования и мастер-слайд в качестве параметра методу [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
3. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд с мастер-слайдом (расположенным на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер из исходного слайда.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, чтобы загрузить исходный файл презентации
with slides.Presentation(path + "CloneToAnotherPresentationWithMaster.pptx") as srcPres:
    # Создайте экземпляр класса Presentation для целевой презентации (куда будет клонироваться слайд)
    with slides.Presentation() as destPres:
        # Получите ISlide из коллекции слайдов в исходной презентации вместе с
        # Мастер-слайдом
        sourceSlide = srcPres.slides[0]
        sourceMaster = sourceSlide.layout_slide.master_slide

        # Клонируйте нужный мастер-слайд из исходной презентации в коллекцию мастеров в
        # Целевой презентации
        masters = destPres.masters
        destMaster = sourceSlide.layout_slide.master_slide

        # Клонируйте нужный мастер-слайд из исходной презентации в коллекцию мастеров в
        # Целевой презентации
        iSlide = masters.add_clone(sourceMaster)

        # Клонируйте нужный слайд из исходной презентации с нужным мастером в конец
        # Коллекции слайдов в целевой презентации
        slds = destPres.slides
        slds.add_clone(sourceSlide, iSlide, True)
      
        # Сохраните целевую презентацию на диск
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```



## Клонировать в конце в указанном разделе

С помощью Aspose.Slides для Python через .NET вы можете клонировать слайд из одного раздела презентации и вставить этот слайд в другой раздел в той же презентации. В этом случае вам необходимо использовать метод [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) из интерфейса [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/). 

Этот код на Python показывает, как клонировать слайд и вставить клонированный слайд в указанный раздел:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100) # для клонирования
    
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    section = pres.sections.add_section("Раздел2", slide2)

    pres.slides.add_clone(slide, section)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```