---
title: Создание 3D-эффектов в презентациях с использованием Node.js
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
description: "Применяйте и рендерьте 3D-эффекты для фигур и текста PowerPoint в Node.js с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D-текст."
---
## **Обзор**

Aspose.Slides for Node.js via Java может создавать, редактировать, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или картинные заливки и 3D‑текст.

{{% alert color="primary" %}}
Эта статья посвящена 3D‑эффектам форматирования фигур и текста PowerPoint. Она не касается вставки или редактирования отдельные файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` для применения 3D‑форматирования к фигуре. Возвращаемый объект [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/) управляет 3D‑сценой для этой фигуры.

Для текста используйте [TextFrameFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`. Это применяет 3D‑форматирование к текстовому кадру вместо тела фигуры.

Самыми важными членами API являются:

| Элемент API | Что он управляет | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getCamera) | Точка просмотра, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или соответствие предустановке вращения 3D в PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getLightRig) | Предустановка освещения, направление и вращение света. | Изменить отображение бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getMaterial) и [setMaterial](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setMaterial) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Насколько далеко фигура вытягивается назад от её передней грани. | Превратить плоскую фигуру в явно толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Цвет экструзированных боковых граней. | Сделать глубину видимой или согласовать цвет боковой стороны с заливкой спереди. |
| [getDepth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getDepth) и [setDepth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setDepth) | Дополнительная 3D‑глубина, используемая 3D‑форматированием PowerPoint. | Точно настроить глубину для фигур или текста, особенно совместно с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getBevelTop) и [getBevelBottom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Поднятые или закруглённые края на передней и задней гранях. | Добавить смягчённый или формованный край вместо острого плоского. |
| [getContourColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#getContourWidth) и [setContourWidth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в выводе. |

## **Создание 3D‑фигуры**

Фигура обычно требует четырёх типов настроек, чтобы выглядеть убедительно в 3D:

- Настройки камеры, поскольку вид по умолчанию спереди может скрывать экструзию.
- Настройки освещения, поскольку освещение делает грани и боковые стороны различимыми.
- Настройки материала, поскольку поверхность влияет на то, как отображается свет.
- Настройки экструзии или глубины, поскольку плоской фигуре необходима толщина.

В следующем примере создаётся прямоугольник, добавляется текст к его передней грани, применяется 3D‑форматирование, презентация сохраняется как PPTX и слайд рендерится в PNG‑изображение.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

Отрендеренный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, установленному через API камеры.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через 3D‑формат, возвращаемый `shape.getThreeDFormat()`:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Используйте камеру, когда нужно изменить то, как зритель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Меняется только 3D‑точка просмотра, используемая PowerPoint и Aspose.Slides при рендеринге.

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint управление глубиной задаёт эту видимую толщину, а управление цветом задаёт цвет боковых граней.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Установите высоту экструзии для толщины и цвет экструзии для бокового цвета:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Используйте настройку глубины, когда необходимо работать напрямую со значением глубины PowerPoint или комбинировать глубину с фаской, материалом и текстовыми эффектами. Во многих сценариях фигур высота экструзии – более понятная настройка, поскольку она напрямую задаёт видимую экструзию.

## **Использование градиентных или картинных заливок с 3D‑эффектами**

3D‑форматирование не зависит от заливки фигуры. Можно применить сплошной цвет, градиент, узор или картинную заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

В этом примере к фигуре применяется градиентная заливка, а к боковым сторонам – более тёмный цвет экструзии:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

Отрендеренный 3D‑прямоугольник с градиентом от синего к оранжевому и оранжевой экструзией:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Чтобы вместо этого использовать картинную заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

Картинка рендерится на передней грани, а экструзия – как 3D‑боковая поверхность:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовый кадр. Это полезно для эффектов типа WordArt, когда сами буквы требуют экструзии, материала, освещения и настроек камеры.

В следующем примере создаётся текст с узорной заливкой, применяется трансформация WordArt и настраиваются 3D‑параметры [TextFrameFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/):

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

Отрендеренный 3D‑текст с арочной трансформацией WordArt, оранжевой узорной заливкой и тёмной экструзией:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Экспорт и поведение при рендеринге**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это относится к рендерингу слайдов в [PNG](/slides/ru/nodejs-java/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/) или генерации кадров для [video conversion](/slides/ru/nodejs-java/convert-powerpoint-to-video/).

Имейте в виду следующие моменты:

- Экспортированные изображения и PDF не являются интерактивными. Объект нельзя вращать после экспорта.
- Окончательный вид зависит от комбинации камеры, освещения, материала, экструзии, заливки и масштабирования слайда.
- Если нужно просмотреть унаследованные или основанные на теме значения форматирования, читайте [effective shape properties](/slides/ru/nodejs-java/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые зритель мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат его поддерживает.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применённое к обычной фигуре или тексту PowerPoint, например вращение, экструзия, фаска, освещение и материал. Эта статья посвящена 3D‑эффектам.

**Какие настройки требуются для видимой 3D‑фигуры?**

Минимум — установить вращение камеры и либо экструзию, либо глубину. На практике также задают освещение и материал, чтобы отрендеренные грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты и к фигурам, и к тексту?**

Да. Используйте [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` для тела фигуры и [TextFrameFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный вывод содержит отрисованный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте API эффективного форматирования, описанные в [Shape Effective Properties](/slides/ru/nodejs-java/shape-effective-properties/), чтобы получить финальные значения камеры, освещения, фаски и связанных 3D‑параметров.