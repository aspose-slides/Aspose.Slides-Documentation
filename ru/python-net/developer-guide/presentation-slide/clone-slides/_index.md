---
title: Клонирование слайдов PowerPoint в Python
linktitle: Клонировать слайды
type: docs
weight: 40
url: /ru/python-net/clone-slides/
keywords:
- клонировать слайд
- копировать слайд
- сохранить слайд
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Быстро клонируйте или дублируйте слайды PowerPoint с помощью Aspose.Slides for Python via .NET. Следуйте нашим понятным примерам кода и советам, чтобы автоматизировать создание PPT за секунды, повысить продуктивность и избавиться от ручной работы."
---

## **Обзор**

Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for Python via .NET позволяет клонировать любой слайд и вставлять полученный клон в текущую презентацию или в другую открытую презентацию. При клонировании создаётся новый слайд, который можно изменять, не влияя на оригинал.

Существует несколько способов клонирования слайда:

- Клонировать слайд в конец той же презентации.
- Клонировать слайд в определённую позицию в той же презентации.
- Клонировать слайд в конец другой презентации.
- Клонировать слайд в определённую позицию в другой презентации.
- Клонировать слайд вместе с его мастер‑слайдом в другую презентацию.

В Aspose.Slides for Python via .NET [slide collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) предоставляет методы `add_clone` и `insert_clone` для выполнения этих видов клонирования.

## **Клонирование в конец в той же презентации**

Если необходимо клонировать слайд в той же презентации и добавить его в конец существующих слайдов, используйте метод `add_clone`. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите коллекцию слайдов из объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Вызовите метод `add_clone` у [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), передав слайд, который требуется клонировать.
1. Сохраните изменённую презентацию.

В примере ниже первый слайд (индекс 0) клонируется и добавляется в конец презентации.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для представления файла презентации.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Клонируйте выбранный слайд в конец коллекции слайдов в той же презентации.
    presentation.slides.add_clone(presentation.slides[0])
    # Сохраните изменённую презентацию на диск.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонирование в определённую позицию в той же презентации**

Если необходимо клонировать слайд в той же презентации и разместить его в другой позиции, используйте метод `insert_clone`:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите коллекцию слайдов из объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Вызовите метод `insert_clone` у [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), передав слайд для клонирования и целевой индекс новой позиции.
1. Сохраните изменённую презентацию.

В примере ниже слайд с индексом 0 (позиция 1) клонируется в индекс 1 (позиция 2) внутри той же презентации.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для представления файла презентации.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Клонируйте выбранный слайд в указанную позицию (индекс) внутри той же презентации.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Сохраните изменённую презентацию на диск.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонирование в конец другой презентации**

Если нужно клонировать слайд из одной презентации и добавить его в конец другой презентации:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для исходной презентации (той, в которой находится слайд для клонирования).
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для целевой презентации (куда будет добавлен слайд).
1. Получите коллекцию слайдов из целевой презентации.
1. Вызовите `add_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), передав слайд из исходной презентации.
1. Сохраните изменённую целевую презентацию.

В примере ниже слайд с индексом 0 в исходной презентации клонируется в конец целевой презентации.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для представления исходного файла презентации.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Создайте экземпляр класса Presentation для целевого PPTX (куда будет склонирован слайд).
    with slides.Presentation() as target_presentation:
        # Клонируйте выбранный слайд из исходной презентации в конец коллекции слайдов в целевой презентации.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Сохраните целевую презентацию на диск.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонирование в определённую позицию в другой презентации**

Если необходимо клонировать слайд из одной презентации и вставить его в другую презентацию в определённую позицию:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для исходной презентации (которая содержит слайд для клонирования).
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для целевой презентации (куда будет добавлен слайд).
1. Получите коллекцию слайдов из целевой презентации.
1. Вызовите метод `insert_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), передав слайд из исходной презентации и требуемый целевой индекс.
1. Сохраните изменённую целевую презентацию.

В примере ниже слайд с индексом 0 в исходной презентации клонируется в индекс 1 (позиция 2) в целевой презентации.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для представления исходного файла презентации.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Вставьте клон первого слайда из исходного файла в позицию с индексом 2 в целевой презентации.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Сохраните целевую презентацию на диск.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонирование слайда вместе с его мастер‑слайдом в другую презентацию**

Если нужно клонировать слайд **совместно с его мастер‑слайдом** из одной презентации и использовать его в другой, сначала клонируйте нужный мастер‑слайд из исходной презентации в целевую. Затем используйте этот мастер‑слайд при клонировании слайда. Метод `add_clone(Slide, MasterSlide)` ожидает **мастер‑слайд из целевой презентации**, а не из исходной.

Чтобы клонировать слайд вместе с его мастер‑слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для исходной презентации.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для целевой презентации.
1. Получите доступ к исходному слайду и его мастер‑слайду.
1. Получите [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) из коллекции мастеров целевой презентации.
1. Вызовите `add_clone` у целевой [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/), передав исходный мастер‑слайд для его клонирования в целевую презентацию.
1. Получите [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) из коллекции слайдов целевой презентации.
1. Вызовите `add_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), передав исходный слайд и только что клонированный мастер‑слайд.
1. Сохраните изменённую целевую презентацию.

В примере ниже слайд с индексом 0 в исходной презентации клонируется в конец целевой презентации с использованием мастер‑слайда, клонированного из исходной презентации.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для представления исходного файла презентации.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Создайте экземпляр класса Presentation для целевой презентации, в которую будет клонирован слайд.
    with slides.Presentation() as target_presentation:
        # Получите первый слайд из исходной презентации.
        source_slide = source_presentation.slides[0]
        # Получите мастер‑слайд, используемый первым слайдом.
        source_master = source_slide.layout_slide.master_slide
        # Склонируйте мастер‑слайд в коллекцию мастеров целевой презентации.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Склонируйте слайд из исходной презентации в конец целевой презентации, используя склонированный мастер‑слайд.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Сохраните целевую презентацию на диск.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонирование в конец в указанном разделе**

С помощью Aspose.Slides for Python via .NET можно клонировать слайд из одного раздела презентации и вставить его в другой раздел той же презентации. Для этого используйте метод `add_clone(Slide, Section)` класса [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

Ниже приведён пример на Python, показывающий, как клонировать слайд и вставить клон в указанный раздел:
```py
import aspose.slides as slides

# Создайте новую пустую презентацию.
with slides.Presentation() as presentation:
    # Добавьте пустой слайд на основе макета первого слайда.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Добавьте эллипс в новый слайд; этот слайд будет клонирован позже.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Добавьте ещё один пустой слайд на основе макета первого слайда.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Создайте раздел с именем "Section2", который начинается со slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Склонируйте ранее созданный слайд в раздел "Section2".
    presentation.slides.add_clone(slide, section)
    # Сохраните презентацию в файл PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Клонируются ли заметки докладчика и комментарии рецензентов?**

Да. Страницы заметок и комментарии включаются в клон. Если они не нужны, [удалите их](/slides/ru/python-net/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, OLE‑встроенной книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/python-net/manage-ole/). После переноса файлов проверьте доступность данных и поведение обновления.

**Можно ли управлять позицией вставки и разделом для клона?**

Да. Вы можете вставить клон в конкретный индекс слайда и разместить его в выбранном [разделе](/slides/ru/python-net/slide-section/). Если целевой раздел отсутствует, создайте его предварительно и затем переместите слайд в него.