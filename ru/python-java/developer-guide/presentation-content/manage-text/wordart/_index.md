---
title: Создание и применение эффектов WordArt в Python через Java
linktitle: WordArt
type: docs
weight: 110
url: /ru/python-java/wordart/
keywords:
- WordArt
- создание WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отражения
- эффект свечения
- трансформация WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создайте и настройте эффекты WordArt в Aspose.Slides для Python через Java. Это пошаговое руководство помогает разработчикам улучшать презентации с профессиональным текстом в Python через Java."
---
## **Обзор**

Эффекты WordArt позволяют добавлять визуально привлекательный, стилизованный текст в ваши презентации PowerPoint. С помощью Aspose.Slides разработчики могут программно создавать, настраивать и управлять WordArt так же, как в Microsoft PowerPoint — без необходимости установки Office. Эта статья предоставляет обзор работы с WordArt, включая применение трансформаций текста, стилей заливки, обводки, теней и других параметров форматирования, чтобы сделать содержание презентации более выразительным и захватывающим. WordArt позволяет рассматривать текст как графический объект. Он состоит из эффектов или специальных модификаций, применяемых к тексту, чтобы сделать его более привлекательным или заметным.

## **Создать простой шаблон WordArt и применить его к тексту**

**Использование Aspose.Slides**

Сначала мы создаём простой текст с помощью этого кода на Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Затем увеличиваем размер шрифта, чтобы эффект был более заметным:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![Меню эффектов WordArt в PowerPoint](image-20200930113926-1.png)

В меню справа вы можете выбрать предопределённый эффект WordArt. В меню слева можно задать параметры нового WordArt.

Это некоторые из доступных параметров или опций:

![Параметры форматирования WordArt](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем шаблон заполнения [PatternStyle.SmallGrid](https://reference.aspose.com/slides/ru/python-java/aspose.slides/patternstyle/#SmallGrid) к тексту и добавляем чёрную обводку текста с помощью этого кода:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Получившийся текст:

![Текст с шаблонной заливкой и чёрной обводкой](image-20200930114108-4.png)

## **Применение других эффектов WordArt**

**Использование Microsoft PowerPoint**

Из интерфейса программы вы можете применять эти эффекты к тексту, блоку текста, фигуре или аналогичному элементу:

![Эффекты текста и фигур в PowerPoint](image-20200930114129-5.png)

Например, эффекты Тень, Отражение и Светящееся могут быть применены к тексту; эффекты 3D Формат и 3D Вращение — к блоку текста; эффект Мягкие края — к фигуре (это всё равно воздействует, если эффект 3D Формат не установлен).

### **Применение теневых эффектов**

Следующий код на Python применяет теневой эффект только к тексту:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

API Aspose.Slides поддерживает три типа теней: [OuterShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/innershadow/) и [PresetShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presetshadow/).

С помощью [PresetShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presetshadow/) можно применить тень к тексту, используя предустановленные значения.

**Использование Microsoft PowerPoint**

В PowerPoint доступен один тип тени. Пример:

![Настройки тени в PowerPoint](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides действительно позволяет одновременно применять два типа теней: [InnerShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/innershadow/) и [PresetShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presetshadow/).

**Примечания:**
- Когда одновременно используются [OuterShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/outershadow/) и [PresetShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presetshadow/), применяется только эффект [OuterShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/outershadow/).
- Если одновременно используются [OuterShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/outershadow/) и [InnerShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/innershadow/), итоговый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется эффект [OuterShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/outershadow/).

### **Применить отражение к тексту**

Мы добавляем отражение к тексту с помощью этого примера кода на Python через Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Применить светящийся эффект к тексту**

Мы применяем светящийся эффект к тексту, чтобы он светился или выделялся, используя следующий код:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

Результат операции:

![Текст со светящимся эффектом](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
Вы можете менять параметры тени, отражения и свечения. Свойства эффектов задаются отдельно для каждой части текста.
{{% /alert %}}

### **Использование трансформаций в WordArt**

Используйте [TextFrameFormat.setTransform](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setTransform) для трансформации всего блока текста:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Результат:

![Текст с трансформацией дуги](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Как Microsoft PowerPoint, так и Aspose.Slides for Python via Java предоставляют определённое количество предопределённых типов трансформаций.
{{% /alert %}}

**Использование PowerPoint**

Для доступа к предопределённым типам трансформаций перейдите к: **Format** -> **TextEffect** -> **Transform**

**Использование Aspose.Slides**

Чтобы выбрать тип трансформации, используйте перечисление [TextShapeType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textshapetype/).

### **Применить 3D‑эффекты к тексту и фигуркам**

Мы применяем 3D‑эффект к текстовой фигуре с помощью этого примера кода:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Получившийся текст и его фигура:

![Фигура текста с 3D‑эффектами](image-20200930114816-9.png)

Мы применяем 3D‑эффект к тексту с помощью этого кода на Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Результат операции:

![Текст с 3D‑эффектами](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
Применение 3D‑эффектов к тексту или его фигурам и взаимодействие между эффектами регулируются определёнными правилами.

Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D‑эффект содержит 3D‑представление объекта и сцену, в которой объект размещён.

- Когда сцена задаётся и для фигуры, и для текста, приоритет отдаётся сцене фигуры — сцена текста игнорируется.
- Когда у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.
- В остальных случаях, когда у фигуры изначально нет 3D‑эффекта, фигура остаётся плоской, и 3D‑эффект применяется только к тексту.

Эти правила относятся к методам [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getLightRig) и [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Применить внешние теневые эффекты к тексту**

Aspose.Slides for Python via Java предоставляет классы [OuterShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/outershadow/) и [InnerShadow](https://reference.aspose.com/slides/ru/python-java/aspose.slides/innershadow/), позволяющие применять теневые эффекты к тексту в [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/). Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation].
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте прямоугольную форму на слайд.
4. Получите доступ к текстовой рамке, связанной с формой.
5. Отключите заливку формы.
6. Включите внешний теневой эффект.
7. Задайте радиус размытия тени.
8. Задайте направление тени.
9. Задайте расстояние тени.
10. Выровняйте тень по верхнему левому углу.
11. Установите цвет тени черным.
12. Сохраните презентацию в файл [PPTX].

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Получить ссылку на слайд
    slide = presentation.getSlides().get_Item(0)

    # Добавить AutoShape типа Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Добавить TextFrame к прямоугольнику
    auto_shape.addTextFrame("Aspose TextBox")

    # Отключить заливку фигуры, если нужно получить тень текста
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Добавить внешнюю тень и установить все необходимые параметры
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Сохранить презентацию на диск
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Применить внутренний теневой эффект к фигурам**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation].
2. Получите ссылку на слайд.
3. Добавьте прямоугольную форму.
4. Включите внутренний теневой эффект.
5. Задайте все необходимые параметры.
6. Установите тип цвета тени, используя цвет темы.
7. Задайте цвет темы.
8. Сохраните презентацию в файл [PPTX].

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Получить ссылку на слайд
    slide = presentation.getSlides().get_Item(0)

    # Добавить AutoShape типа Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Добавить TextFrame к прямоугольнику
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Включить InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Установить все необходимые параметры
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Установить ColorType как Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Установить Scheme Color
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Сохранить презентацию
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Можно ли использовать эффекты WordArt с разными шрифтами или сценариями (например, арабским, китайским)?**

Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и сценариями. Эффекты WordArt, такие как тень, заливка и обводка, могут быть применены независимо от языка, хотя доступность шрифтов и их рендеринг могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам мастера слайдов?**

Да, вы можете применять эффекты WordArt к фигурам на мастерах слайдов, включая заполнители заголовков, нижние колонтитулы или фоновой текст. Изменения, внесённые в макет мастера, отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Незначительно. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут слегка увеличить размер файла за счёт добавления метаданных форматирования, но разница обычно несущественна.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете отрисовывать слайды с WordArt в изображения (например, PNG, JPEG) с помощью [Shape.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) или [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage). Это позволяет предварительно увидеть результат в памяти или на экране до сохранения или экспорта всей презентации.