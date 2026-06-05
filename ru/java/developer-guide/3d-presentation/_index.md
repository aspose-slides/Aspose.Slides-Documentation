---
title: Создание 3D‑эффектов в презентациях с использованием Java
linktitle: 3D‑презентация
type: docs
weight: 232
url: /ru/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Применяйте и отображайте 3D‑эффекты для фигур и текста PowerPoint в Java с Aspose.Slides. Настраивайте камеру, освещение, материал, экструдирование, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Java может создавать, редактировать, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или изображения‑заливки и 3D‑текст.

{{% alert color="primary" %}}
Эта статья посвящена 3D‑эффектам форматирования фигур и текста в PowerPoint. Она не касается вставки или редактирования отдельных файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/).`getThreeDFormat()` для применения 3D‑форматирования к фигуре. Возвращаемый объект формата управляет 3D‑сценой этой фигуры.

Для текста используйте [ITextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Это применяет 3D‑форматирование к текстовому кадру, а не к телу фигуры.

Самые важные члены API:

| Член API | Что контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getCamera--) | Точка зрения, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или соответствие предустановке вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getLightRig--) | Предустановка света, направление и вращение света. | Изменение отображения бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getMaterial--) и [setMaterial](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, глянцевой или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Насколько далеко фигура вытягивается назад от своей передней грани. | Превратить плоскую фигуру в видимо толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Цвет экструзированных боковых граней. | Сделать видимой глубину или согласовать цвет боков с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getDepth--) и [setDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Дополнительная 3D‑глубина, используемая в форматировании PowerPoint. | Точно настроить глубину фигур или текста, особенно вместе с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Приподнятые или скруглённые кромки на передних и задних гранях. | Добавить смягчённую или формованную кромку вместо острой плоской грани. |
| [getContourColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getContourWidth--), и [setContourWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Контур вокруг 3D‑объекта. | Выделить границу объекта в отображаемом выводе. |

## **Создание 3D‑формы**

Фигуре обычно нужны четыре типа настроек, чтобы она выглядела правдоподобно 3D:

- Настройки камеры, потому что вид по умолчанию может скрывать экструзию.
- Настройки освещения, потому что свет делает грани и боковые стороны различимыми.
- Настройки материала, потому что поверхность влияет на то, как свет отображается.
- Настройки экструзии или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст на его переднюю грань, применяет 3D‑форматирование, сохраняет презентацию как PPTX и рендерит слайд в PNG‑изображение.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

Отображённое изображение слайда показывает прямоугольник как плотный 3D‑блок:

![Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение формы с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели «3‑D Rotation». Значения вращения по осям X, Y и Z соответствуют тем, что задаются через API камеры.

![Панель 3‑D Rotation PowerPoint с подсвеченными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через 3D‑формат, возвращаемый `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Используйте камеру, когда требуется изменить точку зрения наблюдателя. Это не меняет 2D‑геометрию фигуры на слайде, а меняет 3D‑точку зрения, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление экструдирования и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint параметр глубины задаёт эту видимую толщину, а параметр цвета задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint, сопоставленные со свойствами цвета экструдирования и высоты экструдирования](img_02_02.png)

Установите высоту экструдирования для толщины и цвет экструдирования для цвета боков:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Используйте настройку глубины, когда необходимо работать непосредственно со значением глубины PowerPoint или сочетать глубину с фаской, материалом и текстовыми эффектами. Во многих случаях высота экструдирования является более понятной настройкой, поскольку она напрямую выражает видимую экструдированную часть.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Можно применить сплошной цвет, градиент, узор или заливку изображением к передней грани и при этом использовать те же настройки камеры, света, материала и экструдирования.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет экструдирования к бокам:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

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

Отрисованный вывод сохраняет градиент на передней грани и отдельным образом рендерит экструдирование:

![Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым экструдированием](img_02_03.png)

Чтобы использовать заливку изображением, добавьте изображение в презентацию и назначьте его в заливку фигуры:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Изображение отображается на передней грани, а экструдирование — как 3D‑боковая поверхность:

![Отрисованный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым экструдированием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовый кадр. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют экструдирования, материала, освещения и настроек камеры.

Следующий пример создаёт текст с узорной заливкой, применяет трансформацию WordArt и настраивает 3D‑параметры на [ITextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/):

```java
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

Текст отображается как изогнутый, экструзированный 3D‑шрифт:

![Отрисованный 3D‑текст с арочным преобразованием WordArt, оранженной узорной заливкой и тёмным экструдированием](img_02_05.png)

## **Экспорт и поведение при рендеринге**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированного макета 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это происходит при рендеринге слайдов в [PNG](/slides/ru/java/convert-powerpoint-to-png/), экспорте в [PDF](/slides/ru/java/convert-powerpoint-to-pdf/), экспорте в [HTML](/slides/ru/java/convert-powerpoint-to-html/), или при создании кадров для [конвертации видео](/slides/ru/java/convert-powerpoint-to-video/).

Имейте в виду следующее:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Окончательный вид зависит от сочетания камеры, световой схемы, материала, экструдирования, заливки и масштабирования слайда.
- Если нужно просмотреть унаследованные или тематические значения форматирования, читайте [эффективные свойства фигур](/slides/ru/java/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, где поддерживается.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, например вращение, экструзия, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**

Минимум — установить вращение камеры и либо экструдирование, либо глубину. На практике также задают световую схему и материал, чтобы у полученных граней были чёткие блики и тени.

**Можно ли применять 3D‑эффекты и к фигурам, и к тексту?**

Да. Используйте [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/).`getThreeDFormat()` для тела фигуры и [ITextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный файл содержит отрисованный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте API эффективного форматирования, описанное в [Эффективные свойства фигур](/slides/ru/java/shape-effective-properties/), чтобы получить окончательные значения камеры, световой схемы, фаски и связанных 3D‑параметров.