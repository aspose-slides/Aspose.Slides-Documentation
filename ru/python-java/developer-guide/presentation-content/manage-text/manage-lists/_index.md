---
title: Управление маркированными и нумерованными списками в презентациях с использованием Python через Java
linktitle: Управление списками
type: docs
weight: 60
url: /ru/python-java/manage-lists/
keywords:
- маркер
- маркированный список
- нумерованный список
- символьный маркер
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
- Java
- Aspose.Slides
description: "Узнайте, как создавать и форматировать маркированные списки, графические маркеры, многоуровневые списки и нумерованные списки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides for Python via Java позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка — это абзац, параметры маркера которого задаются через формат абзаца.

Используйте метод [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/#getParagraphFormat) для доступа к настройкам списка на уровне абзаца. Основной точкой входа является [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getBullet), который возвращает объект [BulletFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/). С помощью этого объекта вы можете задать тип маркера, символ, изображение, цвет, размер, стиль нумерации и начальный номер.

В этой статье показано, как:

- создать маркированный список с пользовательским символом
- создать маркер‑изображение
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации

## **Создать маркированный список**

Чтобы создать маркированный список, добавьте объекты [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) в [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) и задайте [BulletFormat.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setType) как [BulletType.Symbol](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bullettype/#Symbol). Затем можно использовать [BulletFormat.setChar](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#getColor) и [BulletFormat.setHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setHeight) для управления внешним видом маркера.

Следующий код на Python демонстрирует, как создать маркированный список на слайде:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Символы маркеров](symbol_bullets.png)

## **Создать нумерованный список**

Используйте нумерованные списки, когда порядок элементов имеет значение. Установите [BulletFormat.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setType) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bullettype/#Numbered). Вы также можете выбрать формат нумерации с помощью [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) или задать начальное значение с помощью [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), если список должен начинаться не с 1.

Следующий код на Python показывает, как создать нумерованный список на слайде:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Нумерованные маркеры](numbered_bullets.png)

## **Создать маркер‑изображение**

Aspose.Slides позволяет заменить обычный символ маркера изображением. Маркеры‑изображения лучше всего работают с простыми картинками, которые остаются читаемыми при небольшом размере, например, иконками или небольшими прозрачными PNG‑файлами.

{{% alert color="info" title="Note" %}}
Если вы планируете заменить обычный символ маркера изображением, выберите простую графику с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских символов маркеров.

Учтите, что изображение будет масштабировано до очень маленького размера. По этой причине настоятельно рекомендуется выбирать изображение, которое остаётся чётким и визуально эффективным, когда используется как маркер в списке.
{{% /alert %}}

Чтобы создать маркер‑изображение, добавьте изображение в [Presentation.getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) и присвойте полученный объект изображения методу [BulletFormat.getPicture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#getPicture). Установите [BulletFormat.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bulletformat/#setType) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bullettype/#Picture) до присвоения изображения.

Предположим, у нас есть изображение с именем «image.png»:

![Изображение для маркеров](picture_for_bullets.png)

Следующий код на Python показывает, как создать маркеры‑изображения на слайде:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Графические маркеры](picture_bullets.png)

## **Создать многоуровневый список**

Используйте [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setDepth) для размещения элементов списка на разных уровнях. Уровень 0 — верхний уровень, уровень 1 — вложенный под ним и т.д.

Следующий код на Python показывает, как создать многоуровневый маркированный список:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Многоуровневый список](multilevel_list.png)

## **Изменить существующий список**

Чтобы изменить форматирование списка в существующей презентации, получите целевой абзац и обновите его настройки, полученные через [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getBullet). Те же свойства, которые использовались для создания списков, могут быть применены для просмотра или изменения списков, загруженных из файлов PPT, PPTX или ODP.

Следующий код на Python меняет первый абзац в текстовом кадре, задавая стиль нумерованного списка:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?**

Да. Aspose.Slides сохраняет форматирование списка, если целевой формат поддерживает соответствующее расположение текста и функции маркеров.

**Могу ли я редактировать списки в существующих презентациях?**

Да. Загрузите презентацию, получите целевой абзац, просмотрите или обновите его настройки через [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getBullet) и сохраните презентацию.

**Могут ли списки содержать нелатинский текст?**

Да. Текст элементов списка может содержать символы Unicode, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что используемые в презентации шрифты поддерживают необходимые символы.