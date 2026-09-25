---
title: Создание и применение эффектов WordArt в Python через Java
linktitle: WordArt
type: docs
weight: 110
url: /ru/python-java/wordart/
keywords:
- WordArt
- создать WordArt
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
description: "Создавайте и настраивайте эффекты WordArt в Aspose.Slides для Python через Java. Это пошаговое руководство помогает разработчикам улучшать презентации с профессиональным текстом в Python через Java."
---
## **Обзор**

Эффекты WordArt позволяют оформлять текст с помощью заливок, контуров, теней, отражений, свечения, трансформаций и 3D‑форматирования. В этой статье объясняется, как создавать и настраивать эти эффекты в презентациях PowerPoint с использованием Aspose.Slides for Python via Java, без установленного Microsoft Office.

## **Создать простой шаблон WordArt и применить его к тексту**

В следующих примерах создаётся простой стиль WordArt путём задания текста, шрифта, шаблона заливки и контура.

Каждый пример создаёт новую презентацию и добавляет прямоугольник на первый слайд; входной файл не требуется. В первом примере текст устанавливается равным «Aspose.Slides». Позиция и размеры фигуры измеряются в пунктах:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Установите шрифт Arial Black размером 36 пунктов, чтобы форматирование было более заметным:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Примените шаблон заливки [SmallGrid](https://reference.aspose.com/slides/ru/python-java/aspose.slides/patternstyle/#SmallGrid) с тёмно-оранжевым передним планом и белым фоном, затем добавьте чёрный контур текста толщиной 1 пункт:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Полученный текст:

![The simple WordArt template](WordArt_template.png)

## **Применить другие эффекты WordArt**

В следующих примерах показано, как применять тени, отражения, свечение, трансформации и 3D‑эффекты к тексту.

### **Применить внешние теневые эффекты**

Внешняя тень добавляет глубину, размещая теневой слой за текстом. Можно настроить её цвет, направление, расстояние, радиус размытия, масштаб и наклон.

В этом примере вызывается [enableOuterShadowEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) и задаётся чёрная тень с радиусом размытия 4 пункта, направлением 230 градусов и расстоянием 30 пунктов. Значения масштаба 100 сохраняют размер тени, а горизонтальный наклон поворачивает её на 20 градусов. Преобразование альфа‑канала устанавливает непрозрачность 32 %:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Полученный текст:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Когда внешняя и предустановленная тени используются вместе, применяется только внешняя тень.
- Если одновременно применяются внешняя и внутренняя тени, конечный эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется только внешняя тень.
{{% /alert %}}

### **Применить эффекты отражения**

Отражение создаёт зеркальную копию текста. Регулируйте позицию, масштаб, размытие и непрозрачность, чтобы управлять внешним видом.

В этом примере вызывается [enableReflectionEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effectformat/#enableReflectionEffect) и отражение отражается вертикально с масштабом ‑100 %. Используется радиус размытия 0,5 пункта и расстояние 4,72 пункта. Непрозрачность уменьшается от 60 % до 0,9 % между позициями 0 % и 60 % вдоль отражения:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

Полученный текст:

![The Reflection effect](reflection_effect.png)

### **Применить эффекты свечения**

Свечение добавляет мягкий цветной контур вокруг текста. Настраивайте его цвет, непрозрачность и радиус, чтобы управлять эффектом.

В этом примере вызывается [enableGlowEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effectformat/#enableGlowEffect) и применяется красное свечение с непрозрачностью 54 % и радиусом 7 пунктов:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

Полученный текст:

![The Glow effect](glow_effect.png)

### **Применить трансформации WordArt**

Трансформации WordArt изгибают, растягивают или деформируют блок текста.

Установите [setTransform](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setTransform) в значение [ArchUpPour](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textshapetype/#ArchUpPour), чтобы изогнуть весь текстовый кадр вверх:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Полученный текст:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java предоставляет набор предопределённых [transformation types](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Применить 3D‑эффекты к фигурам и тексту**

Можно применить 3D‑эффекты к фигуре или к её тексту. Фаски, выдавливание, освещение и настройки камеры управляют итоговым видом.

В следующем примере используется [ThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/) для добавления круглых фасок, оранжевого выдавливания и тёмно‑красного контура к прямоугольнику. Размеры фасок, высота выдавливания, ширина контура и глубина измеряются в пунктах. Пластиковый материал, сбалансированное освещение, повернутое на 40 градусов вокруг оси Z, и перспективная камера определяют внешний вид:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Полученная фигура:

![The shape 3D effect](shape_3D_effect.png)

Этот пример применяет аналогичное 3D‑форматирование к тексту через [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat). Меньшие фаски формируют края букв, а выдавливание и освещение придают тексту объём:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Полученный текст:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Применение 3D‑эффектов к тексту или к их фигурам — а также взаимодействие между этими эффектами — регулируется определёнными правилами. Рассмотрим сцену, включающую как текст, так и содержащую его фигуру. 3D‑эффект включает 3D‑представление объекта и сцену, в которой он расположен.

- Если сцена задана одновременно для фигуры и текста, приоритет отдаётся сцене фигуры, а сцена текста игнорируется.
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.
- Если у фигуры вообще нет 3D‑эффекта, она считается плоской, и 3D‑эффект применяется только к тексту.

Эти поведения связаны с методами [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getLightRig) и [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Чтобы сохранить текст плоским и читаемым, одновременно удерживая 3D‑форматирование фигуры, см. [Keep Text Flat on a 3D Shape](/slides/ru/python-java/3d-presentation/) для сравнения обоих вариантов и полного примера на Python.

## **Вопросы и ответы**

**Можно ли использовать эффекты WordArt с разными шрифтами или алфавитами (например, арабским, китайским)?**

Да, Aspose.Slides for Python via Java поддерживает Unicode и работает со всеми основными шрифтами и алфавитами. Эффекты WordArt, такие как тень, заливка и контур, могут быть применены независимо от языка, хотя доступность шрифта и рендеринг могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайда?**

Да, эффекты WordArt можно применять к фигурам на шаблонах слайдов, включая заполнители заголовков, колонтитулы или фоновый текст. Изменения, внесённые в шаблон, отразятся на всех связанных слайдамах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Слегка. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут немного увеличить размер файла из‑за добавления метаданных формата, но разница обычно незначительна.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, можно отобразить слайды с WordArt в виде изображений (например, PNG, JPEG), используя [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage), или отобразить отдельные фигуры через [Shape.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage). Это позволяет предварительно увидеть результат в памяти или на экране до сохранения или экспорта полной презентации.