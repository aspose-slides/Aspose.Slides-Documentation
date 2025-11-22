---
title: Управление маркированными и нумерованными списками в презентациях на Python
linktitle: Управление списками
type: docs
weight: 70
url: /ru/python-net/manage-bullet-and-numbered-lists/
keywords:
- маркер
- маркированный список
- нумерованный список
- символический маркер
- изображение-меркер
- пользовательский маркер
- многоуровневый список
- создать маркер
- добавить маркер
- добавить список
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять маркированными и нумерованными списками в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides for Python via .NET. Пошаговое руководство с примерами кода, помогающее быстро начать работу."
---

## **Обзор**

Эффективное управление маркированными и нумерованными списками важно при создании убедительных презентаций. С Aspose.Slides for Python вы можете легко автоматизировать форматирование списков в своих слайдах программно. Эта статья проведет вас через понятные примеры того, как создавать, изменять и настраивать маркированные и нумерованные списки с помощью Python. Откройте для себя простые, но мощные способы управления отступами, стилями, схемами нумерации и маркерами, позволяющие вашим презентациям выглядеть профессионально и последовательно каждый раз.

**Зачем использовать маркированные списки?**

Маркированные списки помогают организовать и ясно представить информацию, повышая читаемость и вовлечённость. Обычно маркированный список служит трем ключевым целям:

- Выделяет важную информацию, сразу привлекая внимание.
- Позволяет читателям быстро просмотреть и определить основные пункты.
- Эффективно передаёт существенные детали в лаконичном формате.

**Зачем использовать нумерованные списки?**

Нумерованные списки — ещё один ценный инструмент для чёткой организации и представления вашего контента. Они особенно полезны, когда порядок или иерархия элементов имеет значение. Используйте нумерованные списки вместо маркеров, когда шаги или пункты должны следовать определённому порядку (например, *Шаг 1, Шаг 2, Шаг 3* и т.д.), или когда необходимо позже ссылаться на конкретные шаги в тексте (например, *см. Шаг 3*). Это делает ваши инструкции или объяснения яснее, проще для восприятия и обеспечивает лёгкую навигацию и ссылки на ваш контент.

## **Создание символных маркеров**

Чтобы создать маркированный список, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите слайд (на котором нужно добавить список) из коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на выбранный слайд.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) добавленной фигуры.
1. Удалите абзац по умолчанию в текстовом фрейме.
1. Создайте первый абзац с помощью класса [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Установите тип маркера `SYMBOL` и задайте символ маркера.
1. Установите текст абзаца.
1. Задайте отступ абзаца, чтобы контролировать расположение маркера.
1. Установите цвет маркера.
1. Установите высоту маркера.
1. Добавьте созданный абзац в коллекцию абзацев текстового фрейма.
1. Добавьте второй абзац и повторите шаги 7–12.
1. Сохраните презентацию.

Следующий код Python демонстрирует, как создать маркированный список на слайде:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The symbol bullets](symbol_bullets.png)

## **Создание изображений‑маркеров**

Aspose.Slides for Python via .NET позволяет настраивать маркеры в маркированных списках. Вы можете заменять стандартные маркеры пользовательскими символами или изображениями. Если вы хотите добавить визуальный интерес к списку или привлечь больше внимания к отдельным элементам, можете использовать собственное изображение в качестве маркера.

{{% alert color="primary" %}}
Идеально, если вы планируете заменить обычный символ маркера изображением, выбирать простую графику с прозрачным фоном. Такие изображения хорошо работают в качестве пользовательских маркеров.
{{% /alert %}}

Имейте в виду, что изображение будет уменьшено до очень небольшого размера. Поэтому настоятельно рекомендуется выбирать изображение, которое остаётся чётким и визуально эффективным, когда используется как маркер в списке.

Чтобы создать изображение‑маркер, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите нужный слайд из коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на выбранный слайд, используя метод `add_auto_shape`.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) добавленной фигуры.
1. Удалите абзац по умолчанию из текстового фрейма.
1. Загрузите изображение с диска, добавьте его в [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/), и получите экземпляр [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/), возвращённый методом [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/#methods).
1. Создайте первый экземпляр [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Установите тип маркера `PICTURE`, затем назначьте изображение.
1. Установите текст абзаца.
1. Задайте отступ абзаца, чтобы позиционировать маркер.
1. Установите цвет маркера.
1. Установите высоту маркера.
1. Добавьте абзац в коллекцию абзацев текстового фрейма.
1. Добавьте второй абзац и повторите шаги 8–13.
1. Сохраните презентацию.

Предположим, у нас есть файл «image.png»:

![A picture for the bullets](picture_for_bullets.png)

Следующий код Python показывает, как создать маркеры‑изображения на слайде:
```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The picture bullets](picture_bullets.png)

## **Создание многоуровневых списков**

Чтобы создать маркированный список, содержащий элементы на нескольких уровнях (подсписки под основными пунктами), выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите нужный слайд из коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на выбранный слайд, используя метод `add_auto_shape`.
1. Получите [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) добавленной фигуры.
1. Удалите абзац по умолчанию из текстового фрейма.
1. Создайте первый экземпляр [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и задайте его глубину 0 (основной уровень).
1. Создайте второй абзац и задайте его глубину 1 (первый подуровень).
1. Создайте третий абзац и задайте его глубину 2 (второй подуровень).
1. Создайте четвёртый абзац и задайте его глубину 3 (третий подуровень).
1. Добавьте все созданные абзацы в коллекцию абзацев текстового фрейма.
1. Сохраните презентацию.

Следующий код Python показывает, как создать многоуровневый маркированный список:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The multilevel list](multilevel_list.png)

## **Создание нумерованных маркеров**

Создание чётких и упорядоченных нумерованных списков просто с Aspose.Slides for Python. Нумерованные списки значительно повышают читаемость и помогают вести аудиторию через шаги или упорядоченную информацию. Будь то учебные слайды, документация процессов или планирование презентаций, нумерованные списки гарантируют, что ваше сообщение остаётся структурированным и лёгким для восприятия.

Aspose.Slides позволяет легко добавлять, настраивать и форматировать нумерованные списки программно. Вы можете задавать разные стили нумерации — числовой (1, 2, 3), буквенный (A, B, C) или римские цифры (I, II, III) — в соответствии с контекстом или желаемым оформлением презентаций.

Следующий код Python показывает, как создать нумерованный список на слайде:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The numbered bullets](numbered_bullets.png)

## **FAQ**

**Можно ли экспортировать маркированные и нумерованные списки, созданные с Aspose.Slides, в другие форматы, такие как PDF или изображения?**

Да, Aspose.Slides полностью сохраняет форматирование и структуру маркеров и нумерованных списков при экспорте презентаций в форматы PDF, изображения и другие, обеспечивая согласованные результаты.

**Можно ли импортировать маркеры или нумерованные списки из существующих презентаций?**

Да, Aspose.Slides позволяет импортировать и редактировать маркеры или нумерованные списки из существующих презентаций, сохраняя их исходное форматирование и внешний вид.

**Поддерживает ли Aspose.Slides маркеры и нумерованные списки в презентациях, созданных на нескольких языках?**

Да, Aspose.Slides полностью поддерживает многоязычные презентации, позволяя создавать маркеры и нумерованные списки на любом языке, включая специальные или нелатинские символы.