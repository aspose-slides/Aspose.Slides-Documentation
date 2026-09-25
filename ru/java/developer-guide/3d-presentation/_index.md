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
- 3D экструзия
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Применяйте и визуализируйте 3D-эффекты для фигур и текста PowerPoint в Java с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D-текст."
---
## **Обзор**

Aspose.Slides for Java может создавать, изменять, сохранять и отрисовывать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как вращение, вытягивание, скосы, освещение, материал, градиентные или картинные заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}

Эта статья посвящена 3D‑форматированию фигур и текста в PowerPoint. Она не охватывает вставку или редактирование отдельных файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортируемый 2D‑вывод.

{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getThreeDFormat--) для применения 3D‑форматирования к фигуре. Метод возвращает [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Он применяет 3D‑форматирование к текстовому кадру вместо тела фигуры.

Самые важные члены API:

| Член API | Что управляет | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getCamera--) | Точка наблюдения, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращайте объект в 3D‑пространстве или согласуйте его с предустановкой вращения 3D в PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getLightRig--) | Предустановка освещения, направление и вращение света. | Изменяет отображение бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getMaterial--) и [setMaterial](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Насколько фигура вытягивается назад от её передней грани. | Преобразовать плоскую фигуру в визуально толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Цвет вытянутых боковых граней. | Сделать глубину видимой или согласовать цвет боковых граней с заполнением передней части. |
| [getDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getDepth--) и [setDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настройте глубину для фигур или текста, особенно в сочетании с параметрами скосов и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getBevelTop--) и [getBevelBottom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Поднятые или скруглённые кромки на передней и задней гранях. | Добавьте смягчённую или сформованную кромку вместо острой плоской грани. |
| [getContourColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getContourColor--) и [getContourWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getContourWidth--) и [setContourWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в отрисованном выводе. |

## **Создание 3D‑фигуры**

Фигура обычно требует четыре типа настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, так как обычный вид спереди может скрывать вытягивание.
- Настройки освещения, поскольку свет делает грани и боковые поверхности различимыми.
- Настройки материала, так как поверхность влияет на отображение света.
- Настройки вытягивания или глубины, поскольку плоской фигуре нужна толщина.

В следующем примере создаётся прямоугольник, к его передней грани добавляется текст, и применяется 3D‑форматирование. Значения вращения камеры указаны в градусах, высота вытягивания — 100 поинтов. Пример отрисовывает слайд в PNG‑изображение в два раза больше обычных размеров и сохраняет презентацию как PPTX.

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

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по X, Y и Z соответствуют вращению, которое задаётся через API камеры.

![Панель 3‑D вращения PowerPoint с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getCamera--). Этот пример создаёт прямоугольник, выбирает ортографический фронтальный вид и задает вращения X, Y и Z — 20, 30 и 40 градусов соответственно. Он настраивает фигуру в памяти без сохранения файла:

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

Используйте камеру, когда нужно изменить то, как зритель видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку зрения, используемую PowerPoint и Aspose.Slides при отрисовке.

## **Добавление вытягивания и глубины**

Вытягивание делает фигуру толстой, расширяя её за переднюю грань. В PowerPoint элемент управления глубиной задаёт видимую толщину, а элемент управления цветом задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, соответствующие свойствам цвета вытягивания и высоты вытягивания](img_02_02.png)

Используйте [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) для установки толщины и [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) для доступа к цвету сторон. Этот пример задаёт прямоугольнику вытягивание 100 поинтов с фиолетовыми сторонами и вращает камеру, чтобы продемонстрировать толщину. Он настраивает фигуру в памяти без сохранения файла:

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

Метод [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setDepth-double-) задаёт глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) управляет высотой эффекта вытягивания, как показано в этом примере.

## **Использование градиентных или картинных заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или картинную заливку к передней грани и при этом использовать те же настройки камеры, освещения, материала и вытягивания.

В этом примере к передней грани применяется градиент от синего к оранжевому, а к 150‑поинтовому вытягиванию — тёмно‑оранжевый цвет. Остановки градиента на 0 % и 100 % обозначают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд отрисовывается в PNG‑изображение в два раза больше обычных размеров:

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

Отрисованный результат сохраняет градиент на передней грани и отрисовывает вытягивание отдельно:

![Отрисованный 3D‑прямоугольник с синё‑оранжевой градиентной заливкой и оранжевым вытягиванием](img_02_03.png)

Чтобы использовать картинную заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. В примере требуется существующий файл «image.jpg» в рабочем каталоге. Картинка растягивается, заполняя прямоугольник, применяется вытягивание 150 поинтов, и задаётся вращение камеры в градусах. Фигура настраивается в памяти без сохранения или отрисовки файла:

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

Картинка отрисовывается на передней грани, а вытягивание — как 3D‑боковая поверхность:

![Отрисованный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым вытягиванием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на её тело. 3D‑форматирование текста влияет на текстовый кадр. Это полезно для эффектов, похожих на WordArt, когда самим буквам требуется вытягивание, материал, освещение и настройки камеры.

В следующем примере создаётся текст с оранжево‑белым узором сетки, применяется арочный изгиб и настраиваются 3D‑параметры через [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Высота вытягивания и глубина указаны в поинтах, вращение света — в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример отрисовывает PNG‑изображение в два раза больше стандартных размеров слайда и сохраняет презентацию как PPTX:

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

Текст отрисован как изогнутые, вытянутые 3D‑буквы:

![Отрисованный 3D‑текст с арочным преобразованием WordArt, оранжевой паттерн‑заливкой и тёмным вытягиванием](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, сохраняя 3D‑видимость фигуры, вызовите [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) через [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Когда значение `true`, текст остаётся вне 3D‑сцены. Когда `false`, текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и вытягивание остаются настроенными через [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getThreeDFormat--). Это также отличается от обычного вращения. [IShape.setRotation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#setRotation-float-) вращает фигуру в плоскости слайда, тогда как [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) управляет пользовательским вращением текста внутри его ограничивающего блока. Оставление текста вне 3D‑сцены не сбрасывает ни один из этих углов.

В следующем автономном примере создаётся синий прямоугольник с текстом и копируется рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `false` слева и `true` справа. Углы камеры указаны в градусах, высота вытягивания — 40 поинтов. Пример сохраняет презентацию как PPTX и отрисовывает сравнительный слайд в PNG в два раза больше стандартных размеров.

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

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читается. Оба прямоугольника сохраняют одинаковое видимое вытягивание и 3D‑ориентацию.

![Бок о бок 3D‑прямоугольники: текст следует 3D‑ориентации слева и остаётся плоским справа](keep_text_flat.png)

## **Экспорт и поведение при отрисовке**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При отрисовке или экспорте в форматы фиксированного макета 3D‑сцена растеризуется или включается в вывод как 2D‑результат. Это происходит при отрисовке слайдов в [PNG](/slides/ru/java/convert-powerpoint-to-png/), экспорте в [PDF](/slides/ru/java/convert-powerpoint-to-pdf/), экспорте в [HTML](/slides/ru/java/convert-powerpoint-to-html/), или генерации кадров для [видеоконвертации](/slides/ru/java/convert-powerpoint-to-video/).

Имейте в виду следующие моменты:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Окончательный вид зависит от комбинации камеры, освещения, материала, вытягивания, заливки и масштабирования слайда.
- Если необходимо изучить наследованные или тематические значения форматирования, используйте [effective shape properties](/slides/ru/java/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат отрисовывается, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создает и отрисовывает 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, где формат это поддерживает.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, например вращение, вытягивание, скос, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**

Минимум — задать вращение камеры и либо вытягивание, либо глубину. На практике также задают освещение и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Могу ли я применять 3D‑эффекты как к фигурам, так и к тексту?**

Да. Используйте [IShape.getThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getThreeDFormat--) для тела фигуры и [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) для текста.

**Появятся ли 3D‑эффекты при экспорте в изображения, PDF, HTML или кадры видео?**

Да. Aspose.Slides отрисовывает 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный результат содержит отрисованное изображение, а не редактируемый 3D‑объект.

**Могу ли я прочитать окончательные 3D‑значения после применения наследования и тематических настроек?**

Да. Используйте API эффективного форматирования, описанное в [Shape Effective Properties](/slides/ru/java/shape-effective-properties/), чтобы получить конечные значения камеры, освещения, скосов и прочих 3D‑параметров.