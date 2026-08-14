---
title: Клонирование слайдов PowerPoint на Python
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
description: "Быстро клонируйте или дублируйте слайды PowerPoint с помощью Aspose.Slides для Python через .NET. Следуйте нашим понятным примерам кода и советам, чтобы автоматизировать создание PPT за секунды, повысить продуктивность и избавиться от ручной работы."
---
## **Введение**

Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides также позволяет копировать (клонировать) любой слайд, а затем вставлять клонированный слайд в текущую презентацию или любую другую открытую презентацию. Клонирование слайда создаёт новый слайд, который разработчики могут изменять, не влияя на оригинальный слайд. Существует несколько способов клонирования слайда:

- Клонирование в конце презентации.
- Клонирование в другом месте внутри презентации.
- Клонирование в конце другой презентации.
- Клонирование в другом месте другой презентации.
- Клонирование в определённой позиции в другой презентации.

В Aspose.Slides для Python через .NET, [коллекция слайдов](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/) предоставляемая объектом [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) содержит методы `add_clone` и `insert_clone` для выполнения этих типов клонирования слайдов.

## **Установка**

```bash
pip install aspose.slides
```

## **Клонирование в конце в той же презентации**

Если вы хотите клонировать слайд в той же презентации и добавить его в конец существующих слайдов, используйте метод `add_clone`. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите коллекцию слайдов из объекта [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Вызовите метод `add_clone` у [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд, который нужно клонировать.
1. Сохраните изменённую презентацию.

В приведённом ниже примере первый слайд (индекс 0) клонируется и добавляется в конец презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Клонировать выбранный слайд в конец коллекции слайдов в той же презентации.
    presentation.slides.add_clone(presentation.slides[0])
    # Сохранить изменённую презентацию на диск.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в определённую позицию внутри той же презентации**

Если вы хотите клонировать слайд в той же презентации и разместить его в другом месте, используйте метод `insert_clone`:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите коллекцию слайдов из объекта [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Вызовите метод `insert_clone` у [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд, который нужно клонировать, и целевой индекс для его новой позиции.
1. Сохраните изменённую презентацию.

В приведённом ниже примере слайд с индексом 1 (позиция 2) клонируется в индекс 2 (позиция 3) внутри той же презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Клонировать выбранный слайд в указанную позицию (индекс) в той же презентации.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Сохранить изменённую презентацию на диск.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в конце другой презентации**

Если вам нужно клонировать слайд из одной презентации и добавить его в конец другой презентации:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для исходной презентации (той, которая содержит слайд для клонирования).
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для целевой презентации (куда будет добавлен слайд).
1. Получите коллекцию слайдов из целевой презентации.
1. Вызовите `add_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд из исходной презентации.
1. Сохраните изменённую целевую презентацию.

В приведённом ниже примере слайд с индексом 0 в исходной презентации клонируется в конец целевой презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего исходный файл презентации.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд).
    with slides.Presentation() as target_presentation:
        # Клонировать выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Сохранить целевую презентацию на диск.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в определённую позицию в другой презентации**

Если вам нужно клонировать слайд из одной презентации и вставить его в другую презентацию в определённую позицию:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для исходной презентации (той, которая содержит слайд для клонирования).
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для целевой презентации (куда будет добавлен слайд).
1. Получите коллекцию слайдов из целевой презентации.
1. Вызовите метод `insert_clone` у целевой [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав слайд из исходной презентации и желаемый целевой индекс.
1. Сохраните изменённую целевую презентацию.

В приведённом ниже примере слайд с индексом 0 в исходной презентации клонируется в индекс 2 (позиция 3) в целевой презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего исходный файл презентации.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Вставить клон первого слайда из исходного в позицию с индексом 2 в целевой презентации.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Сохранить целевую презентацию на диск.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование слайда вместе с его мастер‑слайдом в другую презентацию**

Если вам нужно клонировать слайд **со своим мастер‑слайдом** из одной презентации и использовать его в другой, сначала склонируйте требуемый мастер‑слайд из исходной презентации в целевую презентацию. Затем используйте этот мастер целевой презентации при клонировании слайда. Метод `add_clone(Slide, MasterSlide)` ожидает **мастер‑слайд из целевой презентации**, а не из исходной.

Для клонирования слайда вместе с его мастером выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для исходной презентации (той, которая содержит слайд для клонирования).
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для целевой презентации.
1. Получите доступ к исходному слайду, который будет клонирован, и к его мастер‑слайду.
1. Получите [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/) из коллекции мастеров целевой презентации.
1. Вызовите `add_clone` у целевого [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/), передав исходный мастер для его клонирования в целевую презентацию.
1. Получите [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/) из коллекции слайдов целевой презентации.
1. Вызовите `add_clone` у целевого [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/), передав исходный слайд и склонированный мастер целевой презентации.
1. Сохраните изменённую целевую презентацию.

В приведённом ниже примере слайд с индексом 0 в исходной презентации клонируется в конец целевой презентации с использованием мастера, склонированного из исходной презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего исходный файл презентации.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Создать экземпляр класса Presentation для целевой презентации, в которую будет клонирован слайд.
    with slides.Presentation() as target_presentation:
        # Получить первый слайд из исходной презентации.
        source_slide = source_presentation.slides[0]
        # Получить мастер‑слайд, используемый первым слайдом.
        source_master = source_slide.layout_slide.master_slide
        # Клонировать мастер‑слайд в коллекцию мастеров целевой презентации.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Клонировать слайд из исходной презентации в конец целевой презентации, используя клонированный мастер.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Сохранить целевую презентацию на диск.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование в конец в указанном разделе**

С помощью Aspose.Slides для Python через .NET вы можете клонировать слайд из одного раздела презентации и вставить его в другой раздел внутри той же презентации. Для этого используйте метод `add_clone(Slide, Section)` класса [SlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/).

Ниже приведён пример на Python, показывающий, как клонировать слайд и вставить клон в указанный раздел:

```py
import aspose.slides as slides

# Создать новую пустую презентацию.
with slides.Presentation() as presentation:
    # Добавить пустой слайд на основе макета первого слайда.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Добавить форму-эллипс на новый слайд; этот слайд будет клонирован позже.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Добавить ещё один пустой слайд на основе макета первого слайда.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Создать раздел с именем "Section2", который начинается с slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Клонировать ранее созданный слайд в раздел "Section2".
    presentation.slides.add_clone(slide, section)
    # Сохранить презентацию в файл PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Обеспечение совпадения размеров слайдов**

При клонировании слайдов в другую презентацию убедитесь, что у целевой презентации такой же размер слайда, как у исходной. Если размеры слайдов различаются, Aspose.Slides не масштабирует автоматически склонированные формы — их оригинальные координаты и размеры сохраняются, что может привести к смещённому отображению содержимого или выходу его за границы слайда.

Вы можете установить размер слайда целевой презентации, чтобы он соответствовал исходному, перед клонированием мастера и слайда:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Сделайте это до клонирования мастера и слайда.

## **Вопросы и ответы**

### Клонируются ли заметки выступающего и комментарии рецензента?

Да. Страницы заметок и комментарии рецензентов включаются в клон. Если вы не хотите их, [удалите их](/slides/ru/python-net/presentation-notes/) после вставки.

### Как обрабатываются диаграммы и их источники данных?

Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, OLE‑встроенной книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/python-net/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

### Могу ли я управлять позицией вставки и разделами клона?

Да. Вы можете вставить клон на определённый индекс слайда и поместить его в выбранный [раздел](/slides/ru/python-net/slide-section/). Если целевой раздел не существует, создайте его сначала, а затем переместите слайд в него.