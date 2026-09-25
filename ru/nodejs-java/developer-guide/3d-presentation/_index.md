---
title: Создание 3D‑эффектов в презентациях с использованием Node.js
linktitle: 3D Презентация
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
description: "Применяйте и визуализируйте 3D‑эффекты для фигур и текста PowerPoint в Node.js с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Node.js via Java может создавать, изменять, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена 3D‑форматированию фигур и текста в PowerPoint. Она не охватывает вставку или редактирование отдельных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортированный 2D‑результат.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getThreeDFormat), чтобы применить 3D‑форматирование к фигуре. Метод возвращает [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Он применяет 3D‑форматирование к текстовой рамке, а не к телу фигуры.

Самые важные члены API:

| Член API | Что управляет | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getCamera) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Поворот объекта в 3D‑пространстве или применение предустановки вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getLightRig) | Предустановка света, направление и вращение света. | Изменение отображения бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getMaterial) и [setMaterial](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setMaterial) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Насколько глубоко фигура выступает назад от своей передней грани. | Превратить плоскую фигуру в явно толсто́е 3D‑представление. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Цвет экструзированных боковых сторон. | Сделать глубину видимой или согласовать цвет боков с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getDepth) и [setDepth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setDepth) | Дополнительная 3D‑глубина, используемая в PowerPoint. | Точно настроить глубину фигур или текста, особенно совместно с фасками и материалом. |
| [getBevelTop](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getBevelTop) и [getBevelBottom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Приподнятые или скруглённые кромки на передних и задних гранях. | Добавить смягчённые или формованные кромки вместо острого плоского края. |
| [getContourColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getContourWidth) и [setContourWidth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Обводка вокруг 3D‑объекта. | Выделить границы объекта в рендеренном выводе. |

## **Создание 3D‑фигуры**

Обычно фигуре требуются четыре типа настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, потому что вид по умолчанию может скрывать экструзию.
- Настройки света, потому что освещение делает грани и боковые стороны различимыми.
- Настройки материала, потому что поверхность влияет на то, как свет отображается.
- Настройки экструзии или глубины, потому что плоской фигуре нужна толщина.

В следующем примере создаётся прямоугольник, добавляется текст к его передней грани и применяется 3D‑форматирование. Значения вращения камеры указаны в градусах, высота экструзии — 100 поинтов. Пример рендерит слайд в PNG‑изображение вдвое большего размера и сохраняет презентацию как PPTX.

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

![Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Поворот фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют тем, что задаются через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getCamera). Этот пример создаёт прямоугольник, выбирает ортографический вид спереди и задаёт вращения X, Y и Z — соответственно 20, 30 и 40 градусов. Фигура конфигурируется в памяти без сохранения файла:

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

Используйте камеру, когда требуется изменить то, как пользователь видит объект. Это не меняет 2D‑геометрию фигуры на слайде, а лишь изменяет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, выступая за переднюю грань. В PowerPoint контроль глубины задаёт видимую толщину, а контроль цвета определяет цвет боковых граней.

![Элементы управления глубиной в PowerPoint, сопоставленные со свойствами цвета экструзии и высоты экструзии](img_02_02.png)

Используйте [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) для установки толщины и [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) для получения цвета боков. Этот пример задаёт прямоугольнику экструзию 100 поинтов с пурпурными боками и вращает камеру, чтобы показать толщину. Фигура конфигурируется в памяти без сохранения файла:

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

Метод [ThreeDFormat.setDepth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setDepth) задаёт глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) управляет высотой эффекта экструзии, как показано в этом примере.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

В этом примере к передней грани применяется градиент от синего к оранжевому, а к 150‑поинтовой экструзии — тёмно‑оранжевый цвет. Позиции градиентных остановок 0 и 100 обозначают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд рендерится в PNG‑изображение вдвое большего размера:

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

Отрендеренный вывод сохраняет градиент на передней грани и отдельно рендерит экструзию:

![Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. В этом примере предполагается наличие файла «image.jpg» в рабочем каталоге. Изображение растягивается, чтобы заполнить прямоугольник, задаётся экструзия 150 поинтов и вращение камеры в градусах. Фигура конфигурируется в памяти без сохранения или рендеринга файла:

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

Изображение рендерится на передней грани, а экструзия — как 3D‑боковая поверхность:

![Отрисованный 3D‑прямоугольник с фото‑заливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют экструзии, материала, освещения и настроек камеры.

В следующем примере создаётся текст с оранжево‑белым узором сетки, применяется арочная трансформация вверх и настраиваются 3D‑параметры через [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Высота экструзии и глубина указаны в поинтах, вращение света — в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример рендерит PNG‑изображение вдвое большего размера и сохраняет презентацию как PPTX:

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

![Отрисованный 3D‑текст с арочной трансформацией WordArt, оранжевой узор‑заливкой и тёмной экструзией](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, сохраняя 3D‑внешний вид фигуры, вызовите [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) через [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). При значении `true` текст исключается из 3D‑сцены. При `false` текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, свет, материал и экструзия остаются настроенными через [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getThreeDFormat). Это также отличается от обычного вращения. [Shape.setRotation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#setRotation) вращает фигуру в плоскости слайда, тогда как [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Оставление текста вне 3D‑сцены не сбрасывает ни один из этих углов.

В следующем самодостаточном примере создаётся синий прямоугольник с текстом и клонируется рядом с оригиналом. Оба прямоугольника имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры указаны в градусах, высота экструзии — 40 поинтов. Пример сохраняет презентацию как PPTX и рендерит сравнение слайдов в PNG вдвое большего размера.

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

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и более читаемым. Оба прямоугольника сохраняют одинаковую видимую экструзию и 3D‑ориентацию.

![Бок‑о‑бок 3D‑прямоугольники: текст следует 3D‑ориентации слева и остаётся плоским справа](keep_text_flat.png)

## **Экспорт и поведение при рендеринге**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или отрисовывается в вывод как 2D‑результат. Это применимо, когда вы рендерите слайды в [PNG](/slides/ru/nodejs-java/convert-powerpoint-to-png/), экспортируете в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), в [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/), или генерируете кадры для [видео‑конвертации](/slides/ru/nodejs-java/convert-powerpoint-to-video/).

Имейте в виду следующее:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Итоговый внешний вид зависит от комбинации камеры, светового комплекса, материала, экструзии, заливки и масштабирования слайда.
- Если нужно проверить унаследованные или тематические значения форматирования, читайте [эффективные свойства фигур](/slides/ru/nodejs-java/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В таких форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструзия, фаска, освещение и материал. Эта статья охватывает 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**

Как минимум нужно задать вращение камеры и либо экструзию, либо глубину. На практике также задают световой набор и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты как к фигур​, так и к тексту?**

Да. Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getThreeDFormat) для тела фигуры и [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный материал содержит отрисованный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте API эффективного форматирования, описанные в [Эффективные свойства фигур](/slides/ru/nodejs-java/shape-effective-properties/), чтобы получить окончательные значения камеры, светового комплекта, фаски и связанных 3D‑параметров.