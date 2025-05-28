---
title: Управляйте маркированными и нумерованными списками в презентациях на Python
linktitle: Управление списками
type: docs
weight: 70
url: /ru/python-net/manage-bullet-and-numbered-lists/
keywords:
- маркер
- маркированный список
- нумерованный список
- символ маркера
- графический маркер
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
description: "Узнайте, как управлять маркированными и нумерованными списками в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Пошаговое руководство с примерами кода, которое поможет быстро начать работу."
---

В **Microsoft PowerPoint** вы можете создавать маркированные и нумерованные списки так же, как в Word и других текстовых редакторах. **Aspose.Slides для Python через .NET** также позволяет использовать маркировку и нумерацию на слайдах ваших презентаций.

### Почему использовать маркированные списки?

Маркированные списки помогают вам быстро и эффективно организовывать и представлять информацию.

**Пример маркированного списка**

В большинстве случаев маркированный список выполняет три основные функции:

- привлекает внимание ваших читателей или зрителей к важной информации
- позволяет вашим читателям или зрителям легко находить ключевые моменты
- эффективно передает и сообщает важные детали.

### Почему использовать нумерованные списки?

Нумерованные списки также помогают в организации и представлении информации. В идеале, вам следует использовать номера (вместо маркеров), когда важен порядок записей (например, *шаг 1, шаг 2* и т.д.) или когда запись должна быть ссылаемой (например, *см. шаг 3*).

**Пример нумерованного списка**

Это краткое изложение шагов (шаг 1 по шагу 15) в процедуре **Создание маркировки** ниже:

1. Создайте экземпляр класса презентации.
2. Выполните несколько задач (шаг 3 по шагу 14).
3. Сохраните презентацию.

## Создание маркировки

Для создания маркированного списка выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите доступ к слайду (в который вы хотите добавить маркированный список) в коллекции слайдов через объект [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на выбранном слайде.
4. Получите доступ к [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) добавленной формы.
5. Удалите параграф по умолчанию в [text_frame]().
6. Создайте экземпляр первого параграфа с использованием класса [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
8. Установите тип маркера на Символ и затем установите символ маркера.
9. Установите текст параграфа.
10. Установите отступ параграфа для установки маркера.
11. Установите цвет маркера.
12. Установите высоту маркера.
13. Добавьте созданный параграф в коллекцию параграфов [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
14. Добавьте второй параграф и повторите шаги 7-12.
15. Сохраните презентацию.

Этот пример кода на Python — реализация вышеперечисленных шагов — показывает, как создать маркированный список на слайде:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1
    paragraph.paragraph_format.bullet.color.color = draw.Color.red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "Мой текст"

    textFrame.paragraphs.add(paragraph)
    
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## Создание изображений в маркировке

Aspose.Slides для Python через .NET позволяет вам изменять маркеры в маркированных списках. Вы можете заменить маркеры на свои символы или изображения. Если вы хотите добавить визуальный интерес к списку или привлечь еще большее внимание к записям в списке, вы можете использовать свое собственное изображение в качестве маркера.

 {{% alert color="primary" %}} 

В идеале, если вы собираетесь заменить обычный символ маркера на изображение, вам стоит выбрать простое графическое изображение с прозрачным фоном. Такие изображения лучше всего подходят в качестве настраиваемых символов маркировки.

В любом случае изображение, которое вы выберете, будет уменьшено до очень небольшого размера, поэтому мы настоятельно рекомендуем выбрать изображение, которое будет хорошо выглядеть (как замена символу маркера) в списке.

{{% /alert %}} 

Чтобы создать изображение в маркировке, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите доступ к нужному слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Добавьте [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на выбранном слайде.
4. Получите доступ к [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) добавленной формы.
5. Удалите параграф по умолчанию в [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. Создайте экземпляр первого параграфа, используя класс [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. Загрузите изображение с диска и добавьте его в [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и затем используйте экземпляр [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/), который был возвращен из метода [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/).
8. Установите тип маркера на Изображение и затем установите изображение.
9. Установите текст параграфа.
10. Установите отступ параграфа для установки маркера.
11. Установите цвет маркера.
12. Установите высоту маркеров.
13. Добавьте созданный параграф в коллекцию параграфов [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
14. Добавьте второй параграф и повторите шаги 7-13.
15. Сохраните презентацию.

 Этот код на Python показывает, как создать изображение в маркировке на слайде:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "Мой текст"

    textFrame.paragraphs.add(paragraph)
    
    pres.save("pres-bullets.pptx", slides.export.SaveFormat.PPTX)
```

## Создание многоуровневых маркированных списков

Чтобы создать маркированный список, который содержит элементы на разных уровнях — дополнительные списки под основным маркированным списком — выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите доступ к нужному слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Добавьте [auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на выбранном слайде.
4. Получите доступ к [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) добавленной формы.
5. Удалите параграф по умолчанию в [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. Создайте экземпляр первого параграфа, используя класс [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/), и установите глубину равной 0.
7. Создайте экземпляр второго параграфа с использованием класса Paragraph и глубиной, установленной на 1.
8. Создайте экземпляр третьего параграфа с использованием класса Paragraph и глубиной, установленной на 2.
9. Создайте экземпляр четвертого параграфа с использованием класса Paragraph и глубиной, установленной на 3.
10. Добавьте созданные параграфы в коллекцию параграфов [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
11. Сохраните презентацию.

Этот код, который является реализацией вышеперечисленных шагов, показывает, как создать многоуровневый маркированный список на Python:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 300, 300)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.depth = 0
    paragraph.text = "Мой текст Глубина 0"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 0
    paragraph2.text = "Мой текст Глубина 1"
    textFrame.paragraphs.add(paragraph2)
    
    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "Мой текст Глубина 2"
    textFrame.paragraphs.add(paragraph3)
    
    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "Мой текст Глубина 3"
    textFrame.paragraphs.add(paragraph4)
    
    pres.save("pres-bullets2.pptx", slides.export.SaveFormat.PPTX)
```

## Создание номеров

 Этот код на Python показывает, как создать нумерованный список на слайде:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.text = "Мой текст 1"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Мой текст 2"
    textFrame.paragraphs.add(paragraph2)
    
    pres.save("pres-bullets3.pptx", slides.export.SaveFormat.PPTX)
```