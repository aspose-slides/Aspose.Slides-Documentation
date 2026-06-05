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
- 3D экструзия
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Применяйте и визуализируйте 3D‑эффекты для фигур и текста PowerPoint на Android с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Android via Java может создавать, редактировать, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="primary" %}}
Эта статья посвящена 3D‑форматированию фигур и текста в PowerPoint. Она не охватывает вставку или редактирование отдельные файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) для применения 3D‑форматирования к фигуре. Метод возвращает [IThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Он применяет 3D‑форматирование к текстовому фрейму, а не к телу фигуры.

Самые важные члены API:

| API member | Что управляет | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Точка просмотра, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращайте объект в 3‑D пространстве или используйте предустановку вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Предустановка освещения, направление и вращение света. | Измените отображение бликов и теней на 3‑D поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) и [setMaterial](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделайте одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Наглубление фигуры обратно от её передней грани. | Преобразуйте плоскую фигуру в видимый толстый 3‑D объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Цвет экструзированных боковых граней. | Сделайте глубину видимой или согласуйте цвет боков с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getDepth--) и [setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Дополнительная 3‑D глубина, используемая форматированием PowerPoint. | Тонко настройте глубину фигур или текста, особенно совместно с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Поднятые или скруглённые кромки на передних и задних гранях. | Добавьте смягчённую или формованную кромку вместо острой плоской грани. |
| [getContourColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), и [setContourWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Контур вокруг 3‑D объекта. | Подчеркните границу объекта в отрисованном выводе. |

## **Создание 3D‑формы**

Фигуре обычно нужны четыре типа настроек, чтобы она выглядела убедительно 3D:

- Настройки камеры, потому что вид по умолчанию может скрывать экструзию.  
- Настройки света, потому что освещение делает грани и боковики читаемыми.  
- Настройки материала, потому что поверхность влияет на то, как свет отображается.  
- Настройки экструзии или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст к передней грани, применяет 3D‑форматирование, сохраняет презентацию как PPTX и рендерит слайд в PNG‑изображение.

```java
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

Сгенерированное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3‑D‑вращение настраивается в панели 3‑D‑Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, задаваемому через API камеры.

![Панель 3‑D‑Rotation в PowerPoint с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Используйте камеру, когда нужно изменить точку зрения наблюдателя. Это не меняет 2D‑геометрию фигуры на слайде, а меняет 3D‑вид, который используют PowerPoint и Aspose.Slides при рендеринге.

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint управление глубиной задаёт эту видимую толщину, а управление цветом задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint, сопоставленные с свойствами цвета экструзии и высоты экструзии](img_02_02.png)

Установите [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) для толщины и [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) для цвета боков:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Используйте [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) когда необходимо работать напрямую со значением глубины PowerPoint или комбинировать глубину с фаской, материалом и эффектами текста. Во многих сценариях фигур `setExtrusionHeight` яснее, потому что сразу задаёт видимую экструзию.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

В этом примере градиентная заливка применяется к фигуре, а боковым граням задаётся более тёмный цвет экструзии:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

Отрисованный результат сохраняет градиент на передней грани и отдельно рендерит экструзию:

![Отрисованный 3D‑прямоугольник с градиентом от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы вместо этого использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

Изображение рендерится на передней грани, а экструзия отображается как 3D‑поверхность боков:

![Отрисованный 3D‑прямоугольник с фото‑залогой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовый фрейм. Это удобно для эффектов типа WordArt, когда сами буквы нуждаются в экструзии, материале, освещении и настройках камеры.

Следующий пример создаёт текст с узорной заливкой, применяет трансформацию WordArt и настраивает 3D‑параметры у [ITextFrameFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

Текст отображается как изогнутые, экструзированные 3D‑буквы:

![Отрисованный 3D‑текст с арочной трансформацией WordArt, оранженной узорной заливкой и тёмной экструзией](img_02_05.png)

## **Поведение при экспорте и рендеринге**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированного макета 3D‑сцена растеризуется или отрисовывается в вывод как 2D‑результат. Это относится к рендерингу слайдов в [PNG](/slides/ru/androidjava/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/), или созданию кадров для [видеоконвертации](/slides/ru/androidjava/convert-powerpoint-to-video/).

Имейте в виду следующее:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.  
- Финальный вид зависит от комбинации камеры, световой установки, материала, экструзии, заливки и масштабирования слайда.  
- Если необходимо просмотреть унаследованные или тематические значения форматирования, читайте [Эффективные свойства фигур](/slides/ru/androidjava/shape-effective-properties/).  
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **Часто задаваемые вопросы**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, например вращение, экструзия, фаска, освещение и материал. Эта статья охватывает именно 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**

Как минимум нужно задать вращение камеры и либо экструзию, либо глубину. На практике также задают световую установку и материал, чтобы рендеренные грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты одновременно к фигурам и тексту?**

Да. Используйте [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) для тела фигуры и [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) для текста.

**Будут ли 3D‑эффекты сохранены при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров для видеоконвертации. Экспортированный вывод содержит отрисованный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте API эффективного форматирования, описанное в [Эффективных свойствах фигур](/slides/ru/androidjava/shape-effective-properties/), чтобы получить финальные значения камеры, световой установки, фаски и связанных 3D‑параметров.