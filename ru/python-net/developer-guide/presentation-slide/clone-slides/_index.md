---
title: Клонирование слайдов PowerPoint на Python
linktitle: Клонировать слайды
type: docs
weight: 40
url: /ru/python-net/clone-slides/
keywords:
- клонирование слайда
- копировать слайд
- сохранить слайд
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Быстро клонируйте или дублируйте слайды PowerPoint с помощью Aspose.Slides for Python via .NET. Следуйте нашим понятным примерам кода и советам, чтобы автоматизировать создание PPT за секунды, повысить производительность и избавиться от рутинной работы."
---
## **Введение**

Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides также позволяет копировать (клонировать) любой слайд, а затем вставлять клонированный слайд в текущую презентацию или любую другую открытую презентацию. Клонирование слайда создаёт новый слайд, который разработчики могут изменять, не влияя на оригинальный слайд. Существует несколько способов клонирования слайда:

- Клонировать в конце презентации.
- Клонировать в другом месте внутри презентации.
- Клонировать в конце другой презентации.
- Клонировать в другом месте в другой презентации.
- Клонировать в определённой позиции в другой презентации.

В Aspose.Slides for Python via .NET коллекция [slide collection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), предоставляемая объектом [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), предлагает методы `add_clone` и `insert_clone` для выполнения этих вариантов клонирования слайдов.

## **Установка**

```bash
pip install aspose.slides
```

## **Клонирование в конец в той же презентации**

Если нужно клонировать слайд в той же презентации и добавить его в конец существующих слайдов, используйте метод `add_clone`. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите коллекцию слайдов из объекта [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Вызовите метод `add_clone` у [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд, который следует клонировать.
1. Сохраните изменённую презентацию.

В примере ниже первый слайд (индекс 0) клонируется и добавляется в конец презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющий файл презентации.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Клонируйте нужный слайд в конец коллекции слайдов в той же презентации.
    presentation.slides.add_clone(presentation.slides[0])
    # Сохраните изменённую презентацию на диск.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в определённую позицию в той же презентации**

Если нужно клонировать слайд в той же презентации и разместить его в другом месте, используйте метод `insert_clone`:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите коллекцию слайдов из объекта [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Вызовите метод `insert_clone` у [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд для клонирования и целевой индекс новой позиции.
1. Сохраните изменённую презентацию.

В примере ниже слайд с индексом 1 (позиция 2) клонируется в индекс 2 (позиция 3) в той же презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющий файл презентации.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Клонируйте нужный слайд в указанную позицию (индекс) в той же презентации.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Сохраните изменённую презентацию на диск.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в конец другой презентации**

Если необходимо клонировать слайд из одной презентации и добавить его в конец другой презентации:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для исходной презентации (которая содержит слайд для клонирования).
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для целевой презентации (куда будет добавлен слайд).
1. Получите коллекцию слайдов из целевой презентации.
1. Вызовите `add_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд из исходной презентации.
1. Сохраните изменённую целевую презентацию.

В примере ниже слайд с индексом 0 в исходной презентации клонируется в конец целевой презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющий исходный файл презентации.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд).
    with slides.Presentation() as target_presentation:
        # Клонируйте нужный слайд из исходной презентации в конец коллекции слайдов в целевой презентации.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Сохраните целевую презентацию на диск.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в определённую позицию в другой презентации**

Если необходимо клонировать слайд из одной презентации и вставить его в другую презентацию в определённую позицию:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для исходной презентации (которая содержит слайд для клонирования).
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для целевой презентации (куда будет добавлен слайд).
1. Получите коллекцию слайдов из целевой презентации.
1. Вызовите метод `insert_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд из исходной презентации и желаемый целевой индекс.
1. Сохраните изменённую целевую презентацию.

В примере ниже слайд с индексом 0 в исходной презентации клонируется в индекс 2 (позиция 3) в целевой презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющий файл исходной презентации.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Вставьте клон первого слайда из исходной презентации в позицию с индексом 2 в целевой презентации.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Сохраните целевую презентацию на диск.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование слайда вместе с его мастер‑слайдом в другую презентацию**

Если требуется клонировать слайд **со своим мастером** из одной презентации и использовать его в другой, сначала клонируйте необходимый мастер‑слайд из исходной презентации в целевую. Затем используйте этот целевой мастер при клонировании слайда. Метод `add_clone(Slide, MasterSlide)` ожидает **мастер‑слайд из целевой презентации**, а не из исходной.

Для клонирования слайда вместе с его мастер‑слайдом выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для исходной презентации (которая содержит слайд для клонирования).
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для целевой презентации.
1. Получите доступ к исходному слайду и его мастер‑слайду.
1. Получите [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/) из коллекции мастеров целевой презентации.
1. Вызовите `add_clone` у целевой [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/), передав исходный мастер для его клонирования в целевую презентацию.
1. Получите [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/) из коллекции слайдов целевой презентации.
1. Вызовите `add_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав исходный слайд и склонированный целевой мастер.
1. Сохраните изменённую целевую презентацию.

В примере ниже слайд с индексом 0 в исходной презентации клонируется в конец целевой презентации с использованием мастера, склонированного из исходной.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющий файл исходной презентации.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Создайте экземпляр класса Presentation для целевой презентации, в которой будет клонирован слайд.
    with slides.Presentation() as target_presentation:
        # Получите первый слайд из исходной презентации.
        source_slide = source_presentation.slides[0]
        # Получите мастер‑слайд, используемый первым слайдом.
        source_master = source_slide.layout_slide.master_slide
        # Клонируйте мастер‑слайд в коллекцию мастеров целевой презентации.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Клонируйте слайд из исходной презентации в конец целевой презентации, используя склонированный мастер.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Сохраните целевую презентацию на диск.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в конец в указанном разделе**

С помощью Aspose.Slides for Python via .NET вы можете клонировать слайд из одного раздела презентации и вставить его в другой раздел той же презентации. Для этого используйте метод `add_clone(Slide, Section)` класса [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/).

Ниже показан пример на Python, демонстрирующий, как клонировать слайд и вставить клон в указанный раздел:

```py
import aspose.slides as slides

# Создайте новую пустую презентацию.
with slides.Presentation() as presentation:
    # Добавьте пустой слайд на основе макета первого слайда.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Добавьте эллипс к новому слайду; этот слайд будет позже клонирован.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Добавьте ещё один пустой слайд на основе макета первого слайда.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Создайте раздел с именем "Section2", начинающийся со slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Клонируйте ранее созданный слайд в раздел "Section2".
    presentation.slides.add_clone(slide, section)
    # Сохраните презентацию в файл PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Обеспечение совпадения размеров слайдов**

При клонировании слайдов в другую презентацию убедитесь, что у целевой презентации такой же размер слайдов, как у исходной. Если размеры слайдов различаются, Aspose.Slides не масштабирует автоматически склонированные объекты — их исходные координаты и размеры сохраняются, что может привести к смещению содержимого или выходу за границы слайда.

Вы можете задать размер слайдов целевой презентации, совпадающий с размером исходной, перед клонированием мастера и слайда:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Сделайте это до клонирования мастера и слайда.

## **FAQ**

**Клонируются ли заметки выступающего и комментарии рецензентов?**

Да. Страница заметок и комментарии включаются в клон. Если они не нужны, [удалите их](/slides/ru/python-net/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, встраиваемой книгой OLE), связь сохраняется как [OLE object](/slides/ru/python-net/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Могу ли я управлять позицией вставки и разделами для клона?**

Да. Вы можете вставить клон в конкретный индекс слайда и разместить его в выбранном [section](/slides/ru/python-net/slide-section/). Если целевой раздел ещё не существует, сначала создайте его, а затем переместите слайд в него.