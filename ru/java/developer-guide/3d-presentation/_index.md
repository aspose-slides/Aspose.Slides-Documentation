---
title: Создание 3D-эффектов в презентациях с использованием Java
linktitle: 3D Презентация
type: docs
weight: 232
url: /ru/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D выдавливание
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Применяйте и рендерьте 3D-эффекты для фигур и текста PowerPoint в Java с помощью Aspose.Slides. Настройте камеру, освещение, материал, выдавливание, заливки и 3D-текст."
---
## **Обзор**

Aspose.Slides for Java может создавать, редактировать, сохранять и отрисовывать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, выдавливание, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена 3D‑форматированию фигур и текста в PowerPoint. Она не о вставке или редактировании автономных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) для применения 3D‑форматирования к фигуре. Метод возвращает объект [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Он применяет 3D‑форматирование к текстовому фрейму вместо тела фигуры.

Самые важные члены API:

| Член API | Что управляет | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или совпадение с предустановкой вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Предустановка света, направление и вращение света. | Изменить способ отображения бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) и [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) и [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Насколько глубоко фигура вытягивается назад от её передней грани. | Превратить плоскую фигуру в явно толщинный 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Цвет выдавленных боковых граней. | Сделать глубину видимой или согласовать цвет боков с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) и [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Дополнительная 3D‑глубина, используемая в форматировании PowerPoint. | Тонко настроить глубину фигур или текста, особенно совместно с фасками и материалом. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Выпуклые или скруглённые кромки на передних и задних гранях. | Добавить смягчённую или формованную кромку вместо острой плоской грани. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) и [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) и [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Контур вокруг 3D‑объекта. | Выделить границу объекта в отрисованном выводе. |

## **Создание 3D‑фигуры**

Фигура обычно нуждается в четырёх типах настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, так как вид по умолчанию может скрывать выдавливание.
- Настройки света, потому что освещение делает грани и боковые стороны различимыми.
- Настройки материала, поскольку поверхность влияет на то, как свет отображается.
- Настройки выдавливания или глубины, потому что плоской фигуре требуется толщина.

Ниже приведён пример, создающий прямоугольник, добавляющий к его передней грани текст и применяющий 3D‑форматирование. Значения вращения камеры указаны в градусах, высота выдавливания — 100 пунктов. Пример отрисовывает слайд в PNG‑изображение с двойными размерами по сравнению с размерами по умолчанию и сохраняет презентацию как PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

Отрисованное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели **3‑D Rotation**. Значения вращения по осям X, Y и Z соответствуют тем, которые задаются через API камеры.

![Панель PowerPoint 3‑D Rotation с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--). В этом примере создаётся прямоугольник, выбирается ортографический фронтальный вид и устанавливаются вращения X, Y и Z — соответственно 20, 30 и 40 градусов. Фигура конфигурируется в памяти без сохранения файла:

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

Используйте камеру, когда нужно изменить угол обзора наблюдателя. Это не меняет 2D‑геометрию фигуры на слайде, а лишь меняет 3D‑точку зрения, используемую PowerPoint и Aspose.Slides при отрисовке.

### **Копирование ориентации камеры из шаблонной фигуры**

Чтобы совпасть с ориентацией шаблонной фигуры, прочитайте её предустановку камеры с помощью [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) и её углы вращения с помощью [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--). Пример открывает `template.pptx` и копирует ориентацию камеры с первой фигуры первого слайда во вторую фигуру. Обе фигуры уже имеют 3D‑освещение, а у второй фигуры нет явного вращения камеры.

Углы указаны в градусах. Индекс `0` — широта, индекс `1` — долгота, индекс `2` — революция. Передайте их в [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) в том порядке. Если источник возвращает `null`, у него нет явного вращения, поэтому оставьте углы второй фигуры неустановленными. Явное вращение `(0, 0, 0)` возвращает три нуля и должно быть скопировано.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

При открытии `camera-copy.pptx` в PowerPoint стрелка справа будет иметь такой же предустановленный тип камеры и вращение, как и прямоугольник слева. Обе фигуры используют одинаковое освещение и глубину выдавливания.

![Синий 3D‑прямоугольник и правая стрелка с совпадающей ориентацией камеры, просмотр сверху и справа](camera-orientation.png)

## **Добавление выдавливания и глубины**

Выдавливание делает фигуру толщиной, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint, сопоставленные с параметрами цвета выдавливания и высоты выдавливания](img_02_02.png)

Используйте [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) для задания толщины и [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) для доступа к цвету боков. В этом примере прямоугольнику задаётся выдавливание = 100 пунктов с пурпурными боковыми гранями, а камера вращается, чтобы показать толщину. Фигура конфигурируется в памяти без сохранения файла:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

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

Метод [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) задаёт глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) управляет высотой эффекта выдавливания, как показано в этом примере.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и выдавливания.

Этот пример применяет градиент от синего к оранжевому к передней грани и тёмно‑оранжевый цвет к выдавливанию = 150 пунктов. Позиции градиента 0 и 100 обозначают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд отрисовывается в PNG‑изображение с двойными размерами по сравнению с размерами по умолчанию:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
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

Отрисованный результат сохраняет градиент на передней грани и отдельно отрисовывает выдавливание:

![Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым выдавливанием](img_02_03.png)

Чтобы использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. В этом примере предполагается наличие файла `image.jpg` в рабочем каталоге. Изображение растягивается, чтобы заполнить прямоугольник, задаётся выдавливание = 150 пунктов и вращение камеры в градусах. Фигура конфигурируется в памяти без сохранения или отрисовки файла:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
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

Рисунок отрисовывается на передней грани, а выдавливание – как 3D‑поверхность боков:

![Отрисованный 3D‑прямоугольник с фото‑заливкой на передней грани и оранжевым выдавливанием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовый фрейм. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют выдавливания, материала, освещения и настроек камеры.

Следующий пример создаёт текст с оранжево‑белым узором сетки, применяет вытянутый арочный изгиб и настраивает 3D‑параметры через [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Высота выдавливания и глубина указаны в пунктах, вращение света – в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример отрисовывает PNG‑изображение с двойными размерами слайда и сохраняет презентацию как PPTX:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color patternColor = new Color(255, 140, 0);
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

Текст отрисовывается как изогнутый, выдавленный 3D‑шрифт:

![Отрисованный 3D‑текст с арочным преобразованием WordArt, оранжевой узорной заливкой и тёмным выдавливанием](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, сохраняя 3D‑вид фигуры, вызовите [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) через [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--). При значении `true` текст не попадает в 3D‑сцену. При значении `false` текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и выдавливание остаются сконфигурированными через [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--). Это также отличается от обычного вращения. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) вращает фигуру в плоскости слайда, тогда как [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Оставление текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Ниже приводится полностью автономный пример, который создаёт синий прямоугольник с текстом и клонирует его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; отличается только настройка текста: `false` слева и `true` справа. Углы камеры указаны в градусах, высота выдавливания = 40 пунктов. Пример сохраняет презентацию как PPTX и отрисовывает сравнительный слайд в PNG с двойными размерами по сравнению с размерами по умолчанию.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
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

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читается. Оба прямоугольника сохраняют одинаковое видимое выдавливание и 3D‑ориентацию.

![Сравнение двух 3D‑прямоугольников: слева текст следует 3D‑ориентации, справа остаётся плоским](keep_text_flat.png)

## **Экспорт и поведение при отрисовке**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это происходит, когда вы рендерите слайды в [PNG](/slides/ru/java/convert-powerpoint-to-png/), экспортируете в [PDF](/slides/ru/java/convert-powerpoint-to-pdf/), экспортируете в [HTML](/slides/ru/java/convert-powerpoint-to-html/), или генерируете кадры для [видеоконверсии](/slides/ru/java/convert-powerpoint-to-video/).

Имейте в виду следующее:

- Экспортированные изображения и PDF не являются интерактивными. Объект нельзя вращать после экспорта.
- Финальный вид зависит от комбинации камеры, светового оборудования, материала, выдавливания, заливки и масштабирования слайда.
- Если необходимо просмотреть унаследованные или основанные на теме значения форматирования, читайте [эффективные свойства фигур](/slides/ru/java/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В таких форматах визуальный результат отображается, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, где формат это поддерживает.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — форматирование, применяемое к обычной фигуре PowerPoint или к тексту, такое как вращение, выдавливание, фаска, освещение и материал. Эта статья охватывает 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**

Минимум — задать вращение камеры и либо выдавливание, либо глубину. На практике также стоит задать световое оборудование и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты и к фигурам, и к тексту?**

Да. Используйте [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) для тела фигуры и [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при генерации изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконверсии. Экспортированный вывод содержит отрисованный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте API эффективного форматирования, описанное в [Shape Effective Properties](/slides/ru/java/shape-effective-properties/), чтобы прочитать финальные параметры камеры, светового оборудования, фаски и связанные 3D‑значения.