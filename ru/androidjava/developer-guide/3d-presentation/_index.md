---
title: Создайте 3D эффекты в презентациях на Android
linktitle: 3D презентация
type: docs
weight: 232
url: /ru/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D экструзия
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Применяйте и рендерьте 3D эффекты для фигур и текста PowerPoint на Android с помощью Aspose.Slides. Настройте камеру, освещение, материал, экструзию, заливки и 3D текст."
---
## **Обзор**

Aspose.Slides for Android via Java может создавать, редактировать, сохранять и рендерить 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или рисунковые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена 3D‑форматированию фигур и текста в PowerPoint. Она не относится к вставке или редактированию отдельные файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) для применения 3D‑форматирования к фигуре. Метод возвращает [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Этот метод применяет 3D‑форматирование к текстовой рамке вместо тела фигуры.

Самыми важными членами API являются:

| API member | Что управляет | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или соответствие предустановке 3D‑вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Предустановка освещения, направление и вращение света. | Изменение отображения световых бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) и [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) и [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Насколько далеко фигура выступает назад от своей передней грани. | Преобразовать плоскую фигуру в явно толcстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Цвет экструзированных боковых граней. | Сделать глубину видимой или согласовать цвет боков с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) и [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину фигур или текста, особенно вместе с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Поднятые или закруглённые кромки на передних и задних гранях. | Добавить смягчённый или формованный край вместо острой плоской грани. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) и [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) и [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в отрендеренном выводе. |

## **Создание 3D‑фигуры**

Фигуре обычно требуются четыре типа настроек, чтобы она выглядела убедительно 3D:

- Настройки камеры, поскольку вид по умолчанию может скрывать экструзию.  
- Настройки освещения, поскольку свет делает грани и боковины читаемыми.  
- Настройки материала, поскольку поверхность влияет на то, как свет отображается.  
- Настройки экструзии или глубины, поскольку плоской фигуре нужна толщина.  

Следующий пример создаёт прямоугольник, добавляет текст на его переднюю грань и применяет 3D‑форматирование. Значения вращения камеры заданы в градусах, высота экструзии — 100 пунктов. Пример рендерит слайд в PNG‑изображение вдвое больше стандартных размеров и сохраняет презентацию как PPTX.

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

Отрендеренный слайд показывает прямоугольник как густой 3D‑блок:

![Отрендеренный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели **3‑D Rotation**. Значения вращения по осям X, Y и Z соответствуют вращениям, задаваемым через API камеры.

![PowerPoint 3‑D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Этот пример создаёт прямоугольник, выбирает ортографический фронтальный вид и задаёт вращения X, Y и Z — соответственно 20°, 30° и 40°. Он конфигурирует фигуру в памяти без сохранения файла:

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

Используйте камеру, когда необходимо изменить точку зрения наблюдателя. Это не изменяет 2D‑геометрию фигуры на слайде, а лишь меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

### **Копирование ориентации камеры из шаблонной фигуры**

Чтобы согласовать ориентацию с шаблонной фигурой, считайте её предустановку камеры через [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) и углы вращения через [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). Пример открывает `template.pptx` и копирует ориентацию камеры первой фигуры первого слайда во вторую фигуру. Обе фигуры уже имеют 3D‑освещение, а у второй фигуры нет явного вращения камеры.

Углы заданы в градусах. Индекс `0` — широта, индекс `1` — долгота, индекс `2` — революция. Передайте их в [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) в этом порядке. Если источник возвращает `null`, значит явно вращения нет, поэтому оставьте углы второй фигуры неустановленными. Явное вращение `(0, 0, 0)` возвращает три нуля и должно быть скопировано.

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

При повторном открытии `camera-copy.pptx` в PowerPoint стрелка справа будет иметь ту же предустановку камеры и вращение, что и прямоугольник слева. Обе фигуры используют одинаковое освещение и глубину экструзии.

![Синий 3D‑прямоугольник и стрелка вправо с совпадающей ориентацией камеры, вид сверху и справа](camera-orientation.png)

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Используйте [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) для установки толщины и [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) для доступа к цвету боков. Этот пример задаёт прямоугольнику экструзию 100 пунктов с пурпурными боками и вращает камеру, чтобы показать толщину. Фигура конфигурируется в памяти без сохранения файла:

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

Метод [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) задаёт глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) управляет высотой эффекта экструзии, как показано в этом примере.

## **Использование градиентных или рисунковых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Можно применить сплошной цвет, градиент, узор или рисунок к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

В этом примере применяется градиент от синего к оранжевому на переднюю грань и тёмно‑оранжевая заливка 150‑пунктовой экструзии. Позиции градиентных остановок 0 и 100 обозначают начало и конец градиента. Значения вращения камеры заданы в градусах. Слайд рендерится в PNG‑изображение вдвое больше стандартных размеров:

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

Отрендеренный вывод сохраняет градиент на передней грани и отдельным рендерит экструзию:

![Отрендеренный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы вместо этого использовать рисунковую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Пример предполагает наличие файла `image.jpg` в текущем каталоге. Изображение растягивается, заполняя прямоугольник, применяется экструзия 150 пунктов и задаётся вращение камеры в градусах. Фигура конфигурируется в памяти без сохранения или рендеринга файла:

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

Изображение рендерится на передней грани, а экструзия отображается как 3D‑боковая поверхность:

![Отрендеренный 3D‑прямоугольник с фотографической заливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

Форматирование 3D у фигуры влияет на её тело. Форматирование 3D у текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, когда сами буквы нуждаются в экструзии, материале, освещении и настройках камеры.

Следующий пример создаёт текст с оранжево‑белым узором сетки, применяет верхний арочный изгиб и настраивает 3D‑параметры через [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Высота и глубина экструзии указаны в пунктах, а вращение света — в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример рендерит PNG‑изображение вдвое больших размеров слайда и сохраняет презентацию как PPTX:

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

Текст отрисован как изогнутый, экструзированный 3D‑шрифт:

![Отрендеренный 3D‑текст с арочным преобразованием WordArt, оранжевой заливкой узором и темной экструзией](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, одновременно сохраняя 3D‑вид фигуры, вызовите [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) через [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). При значении `true` текст остаётся вне 3D‑сцены. При `false` текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и экструзия продолжают быть настроены через [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Это также отличается от обычного вращения. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) вращает фигуру в плоскости слайда, тогда как [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) управляет пользовательским вращением текста внутри его ограничивающего блока. Сохранение текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Следующий автономный пример создаёт синий прямоугольник с текстом и клонирует его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры заданы в градусах, высота экструзии — 40 пунктов. Пример сохраняет презентацию как PPTX и рендерит сравнение в PNG‑изображение вдвое больше стандартных размеров.

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

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читаем. Оба прямоугольника сохраняют одинаковую видимую экструзию и 3D‑ориентацию.

![Параллельные 3D‑прямоугольники: слева текст следует 3D‑ориентации, справа остаётся плоским](keep_text_flat.png)

## **Экспорт и поведение рендеринга**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растрируется или рисуется в вывод как 2D‑результат. Это касается рендеринга слайдов в [PNG](/slides/ru/androidjava/convert-powerpoint-to-png/), экспорта в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), экспорта в [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/), а также генерации кадров для [конвертации видео](/slides/ru/androidjava/convert-powerpoint-to-video/).

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.  
- Финальный внешний вид зависит от комбинации камеры, световой рампы, материала, экструзии, заливки и масштабирования слайда.  
- Если необходимо изучить унаследованные или тематические значения форматирования, читайте [effective shape properties](/slides/ru/androidjava/shape-effective-properties/).  
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В таких форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **Вопросы и ответы**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**  
Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**  
3D‑модель — отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструзия, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**  
Минимум — задать вращение камеры и либо экструзию, либо глубину. На практике также задают световую рампу и материал, чтобы полученные грани имели чёткие блики и тени.

**Можно ли применить 3D‑эффекты и к фигурам, и к тексту?**  
Да. Используйте [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) для тела фигуры и [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**  
Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для конвертации в видео. Экспортированный результат содержит отрендеренный внешний вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и настроек темы?**  
Да. Используйте API эффективного форматирования, описанные в [effective shape properties](/slides/ru/androidjava/shape-effective-properties/), чтобы получить окончательные значения камеры, световой рампы, фаски и связанных 3D‑параметров.