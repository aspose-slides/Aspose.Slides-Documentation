---
title: Создание 3D‑эффектов в презентациях с использованием Java
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
description: "Применяйте и рендерите 3D‑эффекты для фигур и текста PowerPoint в Java с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, выдавливание, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Java может создавать, редактировать, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как вращение, выдавливание, фаски, освещение, материал, градиентные или картинные заливки и 3D‑текст.

{{% alert color="info" %}}
Эта статья о 3D‑форматировании фигур и текста в PowerPoint. Она не о вставке или редактировании самостоятельных файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides отображает эти 3D‑эффекты в экспортированном 2D‑выводе.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/).`getThreeDFormat()` чтобы применить 3D‑форматирование к фигуре. Возвращаемый объект формата управляет 3D‑сценой для этой фигуры.

Для текста используйте [ITextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Это применяет 3D‑форматирование к текстовому кадру вместо тела фигуры.

Самые важные члены API:

| API‑член | Что контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getCamera--) | Точка зрения, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращайте объект в 3D‑пространстве или сопоставьте предустановку вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getLightRig--) | Предустановка света, направление и вращение света. | Измените, как выглядят блики и тени на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getMaterial--) и [setMaterial](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделайте одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Насколько далеко фигура выступает назад от своей передней грани. | Преобразуйте плоскую фигуру в видимый толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Цвет вытянутых боковых сторон. | Сделайте глубину видимой или согласуйте цвет боков с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getDepth--) и [setDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Дополнительная 3D‑глубина, используемая в форматировании 3D PowerPoint. | Точно настройте глубину для фигур или текста, особенно совместно с фаской и параметрами материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Поднятые или закругленные края на передних и задних гранях. | Добавьте смягченный или сформованный край вместо острого плоского лица. |
| [getContourColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getContourWidth--), и [setContourWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Контур вокруг 3D‑объекта. | Выделите границу объекта в отрендеренном выводе. |

## **Создание 3D‑фигуры**

Фигура обычно нуждается в четырёх типах настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, потому что вид по умолчанию может скрывать выдавливание.
- Настройки света, потому что освещение делает грани и боковины различимыми.
- Настройки материала, потому что поверхность влияет на то, как свет отображается.
- Настройки выдавливания или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст на его переднюю грань, применяет 3D‑форматирование, сохраняет презентацию как PPTX и рендерит слайд в PNG‑изображение.

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

Отображённый слайд показывает прямоугольник как толстый 3D‑блок:

![Отображённый синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается на панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, которое задаётся через API камеры.

![Панель 3‑D‑вращения PowerPoint с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через 3D‑формат, возвращаемый `shape.getThreeDFormat()`:

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

Используйте камеру, когда нужно изменить то, как наблюдатель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку зрения, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление выдавливания и глубины**

Выдавливание делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint параметр глубины задаёт эту видимую толщину, а параметр цвета задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint, сопоставленные с параметрами цвета выдавливания и высоты выдавливания](img_02_02.png)

Задайте высоту выдавливания для толщины и цвет выдавливания для цвета боков:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Используйте настройку глубины, когда требуется работать напрямую со значением глубины PowerPoint или комбинировать глубину с фаской, материалом и текстовыми эффектами. Во многих сценариях фигур более понятной настройкой является высота выдавливания, поскольку она напрямую выражает видимое выдавливание.

## **Использование градиентных или картинных заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или картинную заливку к передней грани и при этом использовать те же настройки камеры, света, материала и выдавливания.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет выдавливания к боковым сторонам:

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

![Отображённый 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым выдавливанием](img_02_03.png)

Чтобы вместо этого использовать картинную заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

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
} finally {
    presentation.dispose();
}
```

![Отображённый 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым выдавливанием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовый кадр. Это полезно для эффектов, похожих на WordArt, где сами буквы нуждаются в выдавливании, материале, освещении и настройках камеры.

Следующий пример создаёт текст с узорчатой заливкой, применяет трансформацию WordArt и настраивает 3D‑параметры на [ITextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/):

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

![Отображённый 3D‑текст с арочной трансформацией WordArt, оранжевой узорчатой заливкой и тёмным выдавливанием](img_02_05.png)

## **Поведение при экспорте и рендеринге**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растрируется или выводится в виде 2D‑результата. Это происходит, когда вы рендерите слайды в [PNG](/slides/ru/java/convert-powerpoint-to-png/), экспортируете в [PDF](/slides/ru/java/convert-powerpoint-to-pdf/), экспортируете в [HTML](/slides/ru/java/convert-powerpoint-to-html/), или генерируете кадры для [video conversion](/slides/ru/java/convert-powerpoint-to-video/).

Имейте в виду следующие моменты:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Финальный вид зависит от комбинации камеры, светового комплекса, материала, выдавливания, заливки и масштаба слайда.
- Если нужно просмотреть унаследованные или тематические значения форматирования, читайте [effective shape properties](/slides/ru/java/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑параметры.

## **FAQ**

### Может ли Aspose.Slides создавать интерактивные 3D‑презентации?

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

### В чём разница между 3D‑моделью и 3D‑эффектом?

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, выдавливание, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

### Какие настройки обязательны для видимой 3D‑фигуры?

Минимум — установить вращение камеры и либо выдавливание, либо глубину. На практике также задают световой комплекс и материал, чтобы у отрендеренных граней были чёткие блики и тени.

### Можно ли применять 3D‑эффекты к фигурам и к тексту одновременно?

Да. Используйте [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/).`getThreeDFormat()` для тела фигуры и [ITextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` для текста.

### Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный результат содержит отрендеренный вид, а не редактируемый 3D‑объект.

### Можно ли прочитать окончательные 3D‑значения после применения наследования и тем?

Да. Используйте API эффективного форматирования, описанные в [Shape Effective Properties](/slides/ru/java/shape-effective-properties/), чтобы получить окончательные значения камеры, светового комплекса, фаски и связанных 3D‑параметров.