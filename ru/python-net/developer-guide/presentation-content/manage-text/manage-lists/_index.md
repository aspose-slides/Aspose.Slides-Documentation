---
title: "Управление маркированными и нумерованными списками в презентациях на Python"
linktitle: "Управление списками"
type: docs
weight: 70
url: /ru/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
  - "маркер"
  - "маркированный список"
  - "нумерованный список"
  - "символьный маркер"
  - "маркер‑изображение"
  - "пользовательский маркер"
  - "многоуровневый список"
  - "создать маркер"
  - "добавить маркер"
  - "добавить список"
  - "PowerPoint"
  - "OpenDocument"
  - "презентация"
  - "Python"
  - "Aspose.Slides"
description: "Узнайте, как создавать и форматировать маркированные, маркеры с изображением, многоуровневые и нумерованные списки в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides for Python via .NET."
---
## **Обзор**

Aspose.Slides for Python via .NET позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка представляет собой абзац, настройки маркера которого контролируются через его формат абзаца.

Используйте свойство [Paragraph.paragraph_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/paragraph_format/) для доступа к настройкам списка уровня абзаца. Основной точкой входа является [ParagraphFormat.bullet](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/bullet/), который возвращает объект [BulletFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/). С помощью этого объекта вы можете задавать тип маркера, символ, изображение, цвет, размер, стиль нумерации и начальное число.

В этой статье показано, как:

- создать маркированный список с пользовательским символом
- создать маркер‑изображение
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации

## **Создать маркированный список**

Чтобы создать маркированный список, добавьте объекты [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) в [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) и установите [BulletFormat.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/type/) в значение [BulletType.SYMBOL](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bullettype/). Затем вы можете задать [BulletFormat.char](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/color/), и [BulletFormat.height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/height/) для управления внешним видом маркера.

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

![Символьные маркеры](symbol_bullets.png)

## **Создать нумерованный список**

Используйте нумерованные списки, когда порядок элементов имеет значение. Установите [BulletFormat.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/type/) в значение [BulletType.NUMBERED](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bullettype/). Вы также можете выбрать формат нумерации с помощью [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/numbered_bullet_style/) или задать [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/), если список должен начинаться с числа, отличного от 1.

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

![Нумерованные маркеры](numbered_bullets.png)

## **Создать маркер‑изображение**

Aspose.Slides позволяет заменить обычный символ маркера изображением. Маркеры‑изображения лучше всего работают с простыми изображениями, которые остаются разборчивыми при небольшом размере, например, иконками или небольшими прозрачными PNG‑файлами.

{{% alert color="primary" %}}
Оптимально, если вы планируете заменить обычный символ маркера изображением, лучше выбрать простую графику с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских символов маркеров.
Имейте в виду, что изображение будет масштабировано до очень малого размера. По этой причине мы настоятельно рекомендуем выбирать изображение, которое остаётся чётким и визуально эффективным при использовании в качестве маркера списка.
{{% /alert %}}

Чтобы создать маркер‑изображение, добавьте изображение в [Presentation.images](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/images/) и присвойте возвращённый объект изображения свойству [BulletFormat.picture](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/picture/). Установите [BulletFormat.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bulletformat/type/) в значение [BulletType.PICTURE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/bullettype/) перед присвоением изображения.

Допустим, у нас есть "image.png":

![Изображение для маркеров](picture_for_bullets.png)

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

![Маркеры‑изображения](picture_bullets.png)

## **Создать многоуровневый список**

Используйте [ParagraphFormat.depth](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/depth/) для размещения элементов списка на разных уровнях. Уровень 0 — верхний уровень, уровень 1 — вложенный под ним и так далее.

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

![Многоуровневый список](multilevel_list.png)

## **Изменить существующий список**

Чтобы изменить форматирование списка в существующей презентации, получите доступ к целевому абзацу и обновите его настройки [ParagraphFormat.bullet](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/bullet/). Те же свойства, которые использовались для создания списков, могут быть применены для просмотра или изменения списков, загруженных из файлов PPT, PPTX или ODP.

Следующий код Python меняет первый абзац в текстовом кадре, чтобы использовать стиль нумерованного списка:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Вопросы и ответы**

**Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?**

Да. Aspose.Slides сохраняет форматирование списка, если целевой формат поддерживает соответствующее расположение текста и функции маркеров.

**Могу ли я редактировать списки в существующих презентациях?**

Да. Загрузите презентацию, получите доступ к целевому абзацу, просмотрите или обновите его настройки [ParagraphFormat.bullet](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/bullet/), и сохраните презентацию.

**Могут ли списки содержать нелатинский текст?**

Да. Текст элементов списка может содержать символы Unicode, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что шрифты, используемые в презентации, поддерживают необходимые вам символы.