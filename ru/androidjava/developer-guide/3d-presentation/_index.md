---
title: Создание 3D эффектов в презентациях на Android
linktitle: 3D презентация
type: docs
weight: 232
url: /ru/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D вытягивание
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Применяйте и рендерите 3D‑эффекты для фигур и текста PowerPoint на Android с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, вытягивание, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Android via Java может создавать, редактировать, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, вытягивание, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" %}}
Эта статья о 3D‑форматировании фигур и текста PowerPoint. Она не о вставке или редактировании отдельных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides отображает эти 3D‑эффекты в экспортированном 2D‑выводе.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) для применения 3D‑форматирования к фигуре. Метод возвращает [IThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Это применяет 3D‑форматирование к текстовой рамке вместо тела фигуры.

Самые важные члены API:

| Элемент API | Что управляет | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Точка зрения, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или соответствие предустановке 3D‑вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Предустановка света, направление и вращение света. | Изменить отображение бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) и [setMaterial](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, глянцевой или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Насколько фигура выступает назад от её передней грани. | Преобразовать плоскую фигуру в явно толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Цвет вытянутых боковых граней. | Сделать глубину видимой или согласовать цвет боков с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getDepth--) и [setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину для фигур или текста, особенно совместно с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Поднятые или закругленные края на передних и задних гранях. | Добавить смягченный или формованный край вместо острой плоской грани. |
| [getContourColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), и [setContourWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в отрисованном выводе. |

## **Создание 3D‑фигуры**

Обычно фигуре нужны четыре типа настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, поскольку вид спереди по умолчанию может скрывать вытягивание.  
- Настройки освещения, потому что свет делает грани и боковые стороны различимыми.  
- Настройки материала, поскольку поверхность влияет на то, как отображается свет.  
- Настройки вытягивания или глубины, потому что плоской фигуре требуется толщина.

Следующий пример создаёт прямоугольник, добавляет текст к его передней грани, применяет 3D‑форматирование, сохраняет презентацию как PPTX и рендерит слайд в PNG‑изображение.

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

Отрендеренный слайд показывает прямоугольник как толстый 3D‑блок:

![Отрендеренный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по X, Y и Z соответствуют вращению, которое вы задаёте через API камеры.

![Окно 3‑D‑вращения PowerPoint с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

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

Используйте камеру, когда нужно изменить то, как зритель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку зрения, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление вытягивания и глубины**

Вытягивание делает фигуру толстой, расширяя её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint сопоставлены с параметрами цвета вытягивания и высоты вытягивания](img_02_02.png)

Установите [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) для толщины и [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) для цвета боков:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

Используйте [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) когда нужно работать непосредственно с значением глубины PowerPoint или комбинировать её с фаской, материалом и текстовыми эффектами. Во многих сценариях фигур более понятно использовать `setExtrusionHeight`, так как он напрямую задаёт видимое вытягивание.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и вытягивания.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет вытягивания к боковым сторонам:

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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

Отрендеренный результат сохраняет градиент на передней грани и отдельно отображает вытягивание:

![Отрендеренный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым вытягиванием](img_02_03.png)

Чтобы использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

Изображение отображается на передней грани, а вытягивание — как 3D‑боковая поверхность:

![Отрендеренный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым вытягиванием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют вытягивания, материала, освещения и настроек камеры.

Следующий пример создаёт текст с узорной заливкой, применяет трансформацию WordArt и настраивает 3D‑параметры на [ITextFrameFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
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

Отрендеренный 3D‑текст с арочным преобразованием WordArt, оранжевой узорной заливкой и тёмным вытягиванием:

![Отрендеренный 3D‑текст с арочным преобразованием WordArt, оранжевой паттерн‑заливкой и темным вытягиванием](img_02_05.png)

## **Поведение экспорта и рендеринга**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растрируется или вписывается в вывод как 2D‑результат. Это относится к рендерингу слайдов в [PNG](/slides/ru/androidjava/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/) или генерации кадров для [video conversion](/slides/ru/androidjava/convert-powerpoint-to-video/).

Имейте в виду следующие моменты:

- Экспортированные изображения и PDF не являются интерактивными. Объект нельзя вращать после экспорта.  
- Окончательный вид зависит от сочетания камеры, светового оборудования, материала, вытягивания, заливки и масштабирования слайда.  
- Если необходимо просмотреть унаследованные или основанные на теме значения форматирования, читайте [effective shape properties](/slides/ru/androidjava/shape-effective-properties/).  
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат отображается, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

### Можно ли с помощью Aspose.Slides создавать интерактивные 3D‑презентации?

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

### В чём разница между 3D‑моделью и 3D‑эффектом?

3D‑модель — отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — форматирование, применяемое к обычной фигуре или тексту PowerPoint, например вращение, вытягивание, фаска, освещение и материал. Эта статья охватывает именно 3D‑эффекты.

### Какие настройки обязательны для видимой 3D‑фигуры?

Минимум — задать вращение камеры и либо вытягивание, либо глубину. На практике также задают световое оборудование и материал, чтобы отрисованные грани имели чёткие блики и тени.

### Можно ли применять 3D‑эффекты как к фигурам, так и к тексту?

Да. Используйте [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) для тела фигуры и [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) для текста.

### Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров для видеоконвертации. Экспортированный результат содержит отрисованный вид, а не редактируемый 3D‑объект.

### Можно ли прочитать окончательные 3D‑значения после применения наследования и настроек темы?

Да. Используйте API эффективного форматирования, описанное в [Shape Effective Properties](/slides/ru/androidjava/shape-effective-properties/), чтобы получить финальные значения камеры, светового оборудования, фаски и связанных 3D‑параметров.