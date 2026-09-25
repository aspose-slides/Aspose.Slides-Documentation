---
title: Создание 3D‑эффектов в презентациях на Android
linktitle: 3D‑презентация
type: docs
weight: 232
url: /ru/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D экструдирование
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Применяйте и визуализируйте 3D‑эффекты для фигур и текста PowerPoint на Android с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструдирование, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Android via Java может создавать, редактировать, сохранять и визуализировать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструдирование, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена 3D‑форматированию фигур и текста в PowerPoint. Она не касается вставки или редактирования автономных файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) для применения 3D‑форматирования к фигуре. Метод возвращает [IThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Это применяет 3D‑форматирование к текстовому фрейму, а не к телу фигуры.

Самые важные члены API:

| Член API | Что контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Повернуть объект в 3D‑пространстве или сопоставить предустановку вращения 3D в PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Предустановка света, направление и вращение света. | Изменить отображение бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) и [setMaterial](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Материал поверхности, например плоский, матовый, пластиковый или металлический. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Насколько далеко форма вытягивается назад от её передней грани. | Преобразовать плоскую форму в визуально толщинный 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Цвет экструзированных боков. | Сделать глубину видимой или согласовать цвет боков с заливкой спереди. |
| [getDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getDepth--) и [setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Дополнительная 3D‑глубина, используемая форматированием 3D в PowerPoint. | Точно настроить глубину для форм или текста, особенно совместно с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Поднятые или закруглённые кромки на передних и задних гранях. | Добавить смягчённый или формованный край вместо острой плоской грани. |
| [getContourColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) и [setContourWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в визуализированном выводе. |

## **Создание 3D‑фигуры**

Фигура обычно требует четырёх типов настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, так как вид по умолчанию может скрывать экструдирование.
- Настройки освещения, поскольку свет делает грани и боковые стороны различимыми.
- Настройки материала, потому что материал поверхности влияет на то, как свет отображается.
- Настройки экструдирования или глубины, поскольку плоской фигуре нужна толщина.

Ниже приводится пример, создающий прямоугольник, добавляющий текст на переднюю грань и применяющий 3D‑форматирование. Значения вращения камеры указаны в градусах, высота экструдирования — 100 пунктов. Пример визуализирует слайд в PNG‑изображение в двойных размерах по умолчанию и сохраняет презентацию как PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Отрендеренное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отрендеренный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели «3‑D Rotation». Значения вращения по осям X, Y и Z соответствуют вращениям, задаваемым через API камеры.

![Панель PowerPoint 3‑D Rotation с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getCamera--). В этом примере создаётся прямоугольник, выбирается ортографический фронтальный вид и устанавливаются вращения X, Y и Z равными 20, 30 и 40 градусов соответственно. Фигура настраивается в памяти без сохранения файла:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Используйте камеру, когда нужно поменять точку обзора объекта. Это не меняет 2D‑геометрию фигуры на слайде, а лишь меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при визуализации.

## **Добавление экструдирования и глубины**

Экструдирование делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, сопоставленные с параметрами цвета и высоты экструдирования](img_02_02.png)

Используйте [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) для задания толщины и [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) для получения цвета боков. Пример придаёт прямоугольнику экструдирование 100 пунктов с фиолетовыми боками и вращает камеру, чтобы показать толщину. Фигура настраивается в памяти без сохранения файла:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Метод [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) задаёт глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) управляет высотой эффекта экструдирования, как показано в этом примере.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Можно применить сплошную заливку, градиент, узор или изображение к передней грани и при этом использовать те же настройки камеры, света, материала и экструдирования.

В этом примере к передней грани применяется градиент от синего к оранжевому, а к 150‑пунктовому экструдированию — тёмно‑оранжевый цвет. Позиции градиентных остановок 0 и 100 обозначают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд визуализируется в PNG‑изображение в двойных размерах по умолчанию:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Отрендеренный вывод сохраняет градиент на передней грани и отдельно визуализирует экструдирование:

![Отрендеренный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым экструдированием](img_02_03.png)

Чтобы вместо градиента использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. В примере требуется существующий файл «image.jpg» в рабочем каталоге. Изображение растягивается, заполняя прямоугольник, применяется экструдирование 150 пунктов и задаётся вращение камеры в градусах. Фигура настраивается в памяти без сохранения или визуализации файла:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Изображение визуализируется на передней грани, а экструдирование — как 3D‑боковая поверхность:

![Отрендеренный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым экструдированием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигур влияет на тело фигуры. 3D‑форматирование текста влияет на текстовый фрейм. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют экструдирования, материала, освещения и настроек камеры.

Следующий пример создаёт текст с оранжево‑белым узором сетки, применяет восходящий арк и настраивает 3D‑параметры через [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Высота экструдирования и глубина указаны в пунктах, вращение света — в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример визуализирует PNG‑изображение в двойных размерах по умолчанию и сохраняет презентацию как PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int patternColor = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Текст визуализируется как изогнутый, экструдированный 3D‑шрифт:

![Отрендеренный 3D‑текст с арочным преобразованием WordArt, оранжевой заливкой узором и тёмным экструдированием](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, сохраняя 3D‑вид фигуры, вызовите [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) через [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Когда значение `true`, текст исключён из 3D‑сцены. При `false` текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и экструдирование остаются настроенными через [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Это также отличается от обычного вращения. [IShape.setRotation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#setRotation-float-) вращает фигуру в плоскости слайда, а [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) управляет пользовательским вращением текста внутри его рамки. Оставление текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Ниже самостоятельный пример, создающий синий прямоугольник с текстом и копирующий его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Угол камеры задан в градусах, высота экструдирования — 40 пунктов. Пример сохраняет презентацию как PPTX и визуализирует сравнительный слайд в PNG в двойных размерах по умолчанию.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и лучше читаемым. Оба прямоугольника сохраняют одинаковое видимое экструдирование и 3D‑ориентацию.

![Два 3D‑прямоугольника рядом: текст следует 3D‑ориентации слева и остаётся плоским справа](keep_text_flat.png)

## **Экспорт и поведение визуализации**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При визуализации или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или прорисовывается в вывод как 2D‑результат. Это касается визуализации слайдов в [PNG](/slides/ru/androidjava/convert-powerpoint-to-png/), экспорта в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), экспорта в [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/), а также генерации кадров для [видеоконвертации](/slides/ru/androidjava/convert-powerpoint-to-video/).

Имейте в виду:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Окончательный вид зависит от комбинации камеры, светового комплекта, материала, экструдирования, заливки и масштабирования слайда.
- Если нужно проверить унаследованные или основанные на теме значения форматирования, читайте [эффективные свойства фигур](/slides/ru/androidjava/shape-effective-properties/).
- Некоторые форматы вывода не могут сохранять редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат визуализируется, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создает и визуализирует 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, где формат поддерживается.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструдирование, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**

Минимум — задать вращение камеры и либо экструдирование, либо глубину. На практике также задают световой комплект и материал, чтобы на визуализированных гранях были чёткие блики и тени.

**Можно ли применять 3D‑эффекты как к фигурам, так и к тексту?**

Да. Используйте [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) для тела фигуры и [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides визуализирует 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный файл содержит визуализированный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте API эффективного форматирования, описанные в разделе [Эффективные свойства фигур](/slides/ru/androidjava/shape-effective-properties/), чтобы получить окончательные значения камеры, светового комплекта, фаски и связанных 3D‑параметров.