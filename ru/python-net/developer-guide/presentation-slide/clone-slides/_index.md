---
title: Клонирование слайдов PowerPoint в Python
linktitle: Клонировать слайды
type: docs
weight: 40
url: /ru/python-net/clone-slides/
keywords:
- клонировать слайд
- копировать слайд
- сохранять слайд
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Быстро клонируйте или дублируйте слайды PowerPoint с помощью Aspose.Slides for Python via .NET. Следуйте нашим понятным примерам кода и советам, чтобы автоматизировать создание PPT за секунды, повысить продуктивность и избавиться от ручной работы."
---
## **Введение**

Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides также позволяет копировать (клонировать) любой слайд, а затем вставлять клонированный слайд в текущую презентацию или любую другую открытую презентацию. Клонирование слайда создаёт новый слайд, который разработчики могут изменять, не затрагивая оригинальный слайд. Существует несколько способов клонирования слайда:

- Клонирование в конец презентации.  
- Клонирование в другое место внутри презентации.  
- Клонирование в конец другой презентации.  
- Клонирование в другое место в другой презентации.  
- Клонирование в определённое место в другой презентации.

В Aspose.Slides for Python via .NET коллекция [slide collection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), доступная через объект [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), предоставляет методы `add_clone` и `insert_clone` для выполнения этих типов клонирования слайдов.

## **Установка**

```bash
pip install aspose.slides
```

## **Клонирование в конец внутри той же презентации**

Если нужно клонировать слайд в той же презентации и добавить его в конец существующих слайдов, используйте метод `add_clone`. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).  
1. Получите коллекцию слайдов из объекта [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).  
1. Вызовите метод `add_clone` у [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд, который нужно клонировать.  
1. Сохраните изменённую презентацию.

В примере ниже первый слайд (индекс 0) клонируется и добавляется в конец презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation для представления файла презентации.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Клонировать нужный слайд в конец коллекции слайдов той же презентации.
    presentation.slides.add_clone(presentation.slides[0])
    # Сохранить изменённую презентацию на диск.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в определённое место внутри той же презентации**

Если нужно клонировать слайд в той же презентации и разместить его в другом месте, используйте метод `insert_clone`:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).  
1. Получите коллекцию слайдов из объекта [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).  
1. Вызовите метод `insert_clone` у [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд для клонирования и целевой индекс его новой позиции.  
1. Сохраните изменённую презентацию.

В примере ниже слайд с индексом 1 (позиция 2) клонируется в индекс 2 (позиция 3) внутри той же презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation для представления файла презентации.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Клонировать нужный слайд в указанную позицию (индекс) внутри той же презентации.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Сохранить изменённую презентацию на диск.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в конец другой презентации**

Если необходимо клонировать слайд из одной презентации и добавить его в конец другой презентации:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для исходной презентации (той, где находится слайд для клонирования).  
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для целевой презентации (куда будет добавлен слайд).  
1. Получите коллекцию слайдов из целевой презентации.  
1. Вызовите `add_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд из исходной презентации.  
1. Сохраните изменённую целевую презентацию.

В примере ниже слайд с индексом 0 в исходной презентации клонируется в конец целевой презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation для представления исходного файла презентации.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд).
    with slides.Presentation() as target_presentation:
        # Клонировать нужный слайд из исходной презентации в конец коллекции слайдов целевой презентации.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Сохранить целевую презентацию на диск.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в определённое место в другой презентации**

Если нужно клонировать слайд из одной презентации и вставить его в другую презентацию в определённое положение:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для исходной презентации (той, где находится слайд).  
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для целевой презентации.  
1. Получите коллекцию слайдов из целевой презентации.  
1. Вызовите метод `insert_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд из исходной презентации и желаемый целевой индекс.  
1. Сохраните изменённую целевую презентацию.

В примере ниже слайд с индексом 0 в исходной презентации клонируется в индекс 2 (позиция 3) целевой презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation для представления исходного файла презентации.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Вставить клон первого слайда из источника на позицию с индексом 2 в целевой презентации.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Сохранить целевую презентацию на диск.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование слайда вместе с его мастер‑слайдом в другую презентацию**

Если нужно клонировать слайд **вместе с его мастер‑слайдом** из одной презентации и использовать его в другой, сначала клонируйте необходимый мастер‑слайд из исходной презентации в целевую. Затем используйте этот мастер‑слайд при клонировании самого слайда. Метод `add_clone(Slide, MasterSlide)` ожидает **мастер‑слайд из целевой презентации**, а не из исходной.

Для клонирования слайда вместе с его мастером выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для исходной презентации.  
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для целевой презентации.  
1. Получите доступ к исходному слайду и его мастер‑слайду.  
1. Получите [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/) из коллекции мастеров целевой презентации.  
1. Вызовите `add_clone` у целевой [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/), передав исходный мастер‑слайд для его клонирования в целевую презентацию.  
1. Получите [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/) из коллекции слайдов целевой презентации.  
1. Вызовите `add_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав исходный слайд и только что склонированный мастер‑слайд.  
1. Сохраните изменённую целевую презентацию.

В примере ниже слайд с индексом 0 в исходной презентации клонируется в конец целевой презентации с использованием мастера, склонированного из исходной презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation для представления исходного файла презентации.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Создать экземпляр класса Presentation для целевой презентации, в которую будет клонирован слайд.
    with slides.Presentation() as target_presentation:
        # Получить первый слайд из исходной презентации.
        source_slide = source_presentation.slides[0]
        # Получить мастер‑слайд, используемый первым слайдом.
        source_master = source_slide.layout_slide.master_slide
        # Клонировать мастер‑слайд в коллекцию мастеров целевой презентации.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Клонировать слайд из исходной презентации в конец целевой презентации, используя склонированный мастер.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Сохранить целевую презентацию на диск.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в конец в указанном разделе**

С помощью Aspose.Slides for Python via .NET можно клонировать слайд из одного раздела презентации и вставить его в другой раздел той же презентации. Для этого используйте метод `add_clone(Slide, Section)` класса [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/).

Ниже приведён пример на Python, показывающий, как клонировать слайд и вставить его в указанный раздел:

```py
import aspose.slides as slides

# Создать новую пустую презентацию.
with slides.Presentation() as presentation:
    # Добавить пустой слайд на основе макета первого слайда.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Добавить форму эллипса на новый слайд; этот слайд будет клонирован позже.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Добавить ещё один пустой слайд на основе макета первого слайда.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Создать раздел с именем "Section2", который начинается со slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Клонировать ранее созданный слайд в раздел "Section2".
    presentation.slides.add_clone(slide, section)
    # Сохранить презентацию в виде файла PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Клонируются ли заметки выступающего и комментарии рецензента?

Да. Страницы заметок и комментарии включаются в клон. Если они не нужны, [remove them](/slides/ru/python-net/presentation-notes/) после вставки.

### Как обрабатываются диаграммы и их источники данных?

Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, OLE‑встроенной книгой), эта связь сохраняется как [OLE object](/slides/ru/python-net/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

### Можно ли управлять позицией вставки и разделами клона?

Да. Вы можете вставить клон в определённый индекс слайда и разместить его в выбранном [section](/slides/ru/python-net/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд в него.