---
title: Создание 3D‑эффектов в презентациях с использованием Node.js
linktitle: 3D‑презентация
type: docs
weight: 232
url: /ru/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Применяйте и рендерите 3D‑эффекты для фигур и текста PowerPoint в Node.js с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides для Node.js через Java может создавать, изменять, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструзия, скосы, освещение, материал, градиентные или картинные заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена 3D‑эффектам форматирования фигур и текста в PowerPoint. Она не охватывает вставку или редактирование отдельных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat), чтобы применить 3D‑форматирование к фигуре. Метод возвращает объект [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Он применяет 3D‑форматирование к текстовому фрейму вместо тела фигуры.

Самыми важными членами API являются:

| Член API | Что контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или соответствие предустановке вращения в PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Предустановка освещения, направление и вращение света. | Изменение того, как отражения и тени выглядят на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) и [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) и [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Насколько далеко фигура выходит назад от своей передней грани. | Превратить плоскую фигуру в заметно толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Цвет экструзированных боковых граней. | Сделать глубину видимой или согласовать цвет сторон с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) и [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину для фигур или текста, особенно вместе со скосами и настройками материала. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) и [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Поднятые или закруглённые кромки на передней и задней гранях. | Добавить смягчённый или формованный край вместо острого плоского лица. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) и [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в отрисованном выводе. |

## **Создание 3D‑фигуры**

Фигура обычно требует четырёх типов настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, потому что вид по умолчанию может скрывать экструзию.
- Настройки освещения, потому что свет делает грани и стороны читаемыми.
- Настройки материала, потому что поверхность влияет на отображение света.
- Настройки экструзии или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст к его передней грани и применяет 3D‑форматирование. Значения вращения камеры указаны в градусах, а высота экструзии — 100 пунктов. Пример рендерит слайд в PNG‑изображение вдвое большего размера, чем по умолчанию, и сохраняет презентацию как PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Отрендеренное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели **3‑D Rotation**. Значения вращения по осям X, Y и Z соответствуют вращениям, которые вы задаёте через API камеры.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera). Этот пример создаёт прямоугольник, выбирает ортографический фронтальный вид и задаёт его вращения X, Y и Z равными 20, 30 и 40 градусам соответственно. Он конфигурирует фигуру в памяти без сохранения файла:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Используйте камеру, когда нужно изменить точку зрения наблюдателя. Это не меняет 2D‑геометрию фигуры на слайде, а лишь меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

### **Копирование ориентации камеры из шаблонной фигуры**

Чтобы совпать с ориентацией шаблонной фигуры, прочитайте её предустановку камеры через [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) и углы вращения через [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation). Пример открывает `template.pptx` и копирует ориентацию камеры с первой фигуры первого слайда во вторую фигуру. Обе фигуры уже имеют 3D‑освещение, а у второй фигуры нет явного вращения камеры.

Углы указаны в градусах. Индекс `0` — широта, индекс `1` — долгота, индекс `2` — оборот. Передайте их в [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) в этом порядке. Если источник возвращает `null`, значит явного вращения нет, поэтому оставьте углы второй фигуры неопределёнными. Явное вращение `(0, 0, 0)` возвращает три нуля и должно быть скопировано.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

При повторном открытии `camera-copy.pptx` в PowerPoint стрелка справа будет иметь ту же предустановку камеры и вращение, что и прямоугольник слева. Обе фигуры используют одинаковое освещение и глубину экструзии.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Используйте [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight), чтобы задать толщину, и [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor), чтобы получить цвет боков. Этот пример задаёт прямоугольнику экструзию 100 пунктов с пурпурными боками и вращает камеру, чтобы показать его толщину. Он конфигурирует фигуру в памяти без сохранения файла:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Метод [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) задаёт глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) управляет высотой эффекта экструзии, как показано в этом примере.

## **Использование градиентных или картинных заливок с 3D‑эффектами**

3D‑форматирование не зависит от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или картинную заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

Этот пример применяет градиент от синего к оранжевому к передней грани и тёмно‑оранжевый цвет к экструзии высотой 150 пунктов. Позиции градиентных остановок 0 и 100 отмечают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд рендерится в PNG‑изображение вдвое большего размера:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Отрендеренный результат сохраняет градиент на передней грани и отдельно рендерит экструзию:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Чтобы использовать картинную заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Этот пример требует существующего файла `image.jpg` в рабочей директории. Он растягивает изображение, чтобы заполнить прямоугольник, применяет экструзию 150 пунктов и задаёт вращение камеры в градусах. Фигура конфигурируется в памяти без сохранения или рендеринга файла:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Картинка рендерится на передней грани, а экструзия отображается как 3D‑боковая поверхность:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовый фрейм. Это полезно для эффектов, похожих на WordArt, где сами буквы требуют экструзии, материала, освещения и настроек камеры.

Следующий пример создаёт текст с оранжево‑белым узором сетки, применяет подъёмную арку и конфигурирует 3D‑параметры через [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Высота экструзии и глубина указаны в пунктах, а вращение света — в градусах. Заливка и контур фигуры скрыты, поэтому виден только текст. Пример рендерит PNG‑изображение вдвое больше стандартных размеров слайда и сохраняет презентацию как PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Текст отрисовывается как изогнутые, экструзированные 3D‑буквы:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, сохраняя 3D‑вид фигуры, вызовите [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) через [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Когда значение `true`, текст остаётся вне 3D‑сцены. Когда `false`, текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: камера, освещение, материал и экструзия остаются сконфигурированными через [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat). Это также отличается от обычного вращения. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) вращает фигуру в плоскости слайда, а [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Оставление текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Следующий автономный пример создаёт синий прямоугольник с текстом и клонирует его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры указаны в градусах, высота экструзии — 40 пунктов. Пример сохраняет презентацию как PPTX и рендерит сравнительный слайд в PNG вдвое большего размера.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читается. Оба прямоугольника сохраняют одинаковую видимую экструзию и 3D‑ориентацию.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Экспорт и поведение при рендеринге**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растровизуется или рисуется в вывод как 2D‑результат. Это применяется, когда вы рендерите слайды в [PNG](/slides/ru/nodejs-java/convert-powerpoint-to-png/), экспортируете в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), экспортируете в [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/), или создаёте кадры для [видеоконвертации](/slides/ru/nodejs-java/convert-powerpoint-to-video/).

Имейте в виду следующие моменты:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать зрителю после экспорта.
- Итоговый вид зависит от комбинации камеры, освещения, материала, экструзии, заливки и масштабирования слайда.
- Если необходимо узнать унаследованные или тематические значения форматирования, читайте [effective shape properties](/slides/ru/nodejs-java/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструзия, скос, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки обязательны для видимой 3D‑фигуры?**

Как минимум необходимо задать вращение камеры и либо экструзию, либо глубину. На практике также задают освещение и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты к фигурам и тексту?**

Да. Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) для тела фигуры и [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный результат содержит отрисованный внешний вид, а не редактируемый 3D‑объект.

**Можно ли получить окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте API эффективного форматирования, описанное в [Shape Effective Properties](/slides/ru/nodejs-java/shape-effective-properties/), чтобы прочитать финальные параметры камеры, освещения, скосов и связанных 3D‑значений.