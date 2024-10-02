---
title: Форматирование фигур
type: docs
weight: 20
url: /ru/androidjava/shape-formatting/
keywords: "Формат фигуры, формат линий, стиль соединения, градиентная заливка, заливка узором, заливка изображением, заливка сплошным цветом, вращение фигур, эффекты 3D-обводки, эффект 3D-вращения, презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Форматирование фигуры в презентации PowerPoint на Java"
---

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать фигуры, изменяя или применяя определенные эффекты к их составным линиям. Кроме того, вы можете форматировать фигуры, задавая параметры, которые определяют, как они (то есть область внутри них) заполняются.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides для Android через Java** предоставляет интерфейсы и свойства, которые позволяют форматировать фигуры на основе известных параметров в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете указать предпочитаемый стиль линии для фигуры. Эти шаги описывают такую процедуру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) на слайд.
4. Установите цвет для линий фигуры.
5. Установите ширину для линий фигуры.
6. Установите [стиль линии](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) для линии фигуры.
7. Установите [стиль штриха](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) для линии фигуры.
8. Запишите измененную презентацию в файл PPTX.

Этот код на Java демонстрирует операцию, в которой мы отформатировали прямоугольник `AutoShape`:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем автозаполнение типа прямоугольник
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Устанавливаем цвет заливки для фигуры прямоугольника
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // Применяем некоторые форматирования к линиям прямоугольника
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Устанавливаем цвет линии для прямоугольника
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Записываем файл PPTX на диск
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Форматирование стилей соединения**
Это три типа опций соединения:

* Закругленное
* Угловое
* Скошенное

По умолчанию, когда PowerPoint соединяет две линии под углом (или угол фигуры), он использует настройку **Закругленное**. Однако, если вы хотите нарисовать фигуру с очень острыми углами, вам может понадобиться выбрать **Угловое**.

![join-style-powerpoint](join-style-powerpoint.png)

Этот код на Java демонстрирует операцию, в которой были созданы 3 прямоугольника (изображение выше) с настройками типов соединения Угловое, Скошенное и Закругленное:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {

    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем 3 автозаполнения прямоугольников
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // Устанавливаем цвет заливки для фигуры прямоугольника
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Устанавливаем ширину линий 
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // Устанавливаем цвет для линии прямоугольника
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Устанавливаем стиль соединения
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Добавляем текст к каждому прямоугольнику
    ((IAutoShape)shp1).getTextFrame().setText("Угловое соединение");
    ((IAutoShape)shp2).getTextFrame().setText("Скошенное соединение");
    ((IAutoShape)shp3).getTextFrame().setText("Закругленное соединение");

    // Записываем файл PPTX на диск
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Градиентная заливка**
В PowerPoint градиентная заливка — это опция форматирования, которая позволяет вам применить непрерывный смешивание цветов к фигуре. Например, вы можете применить два или более цветов в конфигурации, где один цвет постепенно исчезает и меняется на другой цвет.

Вот как использовать Aspose.Slides для применения градиентной заливки к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) фигуры на `Gradient`.
5. Добавьте ваши 2 предпочтительных цвета с определенными позициями, используя методы `Add`, предоставляемые коллекцией `GradientStops`, связанной с классом `GradientFormat`.
6. Запишите измененную презентацию в файл PPTX.

Этот код на Java демонстрирует операцию, в которой был использован эффект градиентной заливки на эллипсе:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем эллипс автозаполнения
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Применяем форматирование градиента к эллипсу
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Устанавливаем направление градиента
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Добавляем 2 градиентных остановки
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Записываем файл PPTX на диск
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Заливка узором**
В PowerPoint заливка узором — это опция форматирования, которая позволяет вам применить дизайн из двух цветов, состоящий из точек, полос, пересечений или клеток к фигуре. Кроме того, вы можете выбрать ваши предпочитаемые цвета для переднего плана и фона узора.

Aspose.Slides предоставляет более 45 предопределенных стилей, которые могут быть использованы для форматирования фигур и обогащения презентаций. Даже после выбора предопределенного узора, вы все равно можете указать цвета, которые должен содержать узор.

Вот как использовать Aspose.Slides для применения заливки узором к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) фигуры на `Pattern`.
5. Установите предпочтительный стиль узора для фигуры. 
6. Установите [Цвет фона](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getBackColor--) для [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
7. Установите [Цвет переднего плана](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getForeColor--) для [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
8. Запишите измененную презентацию в файл PPTX.

Этот код на Java демонстрирует операцию, где была использована заливка узором для украшения прямоугольника:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем прямоугольник автозаполнения
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Устанавливаем тип заливки на узор
    shp.getFillFormat().setFillType(FillType.Pattern);

    // Устанавливаем стиль узора
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Устанавливаем цвета узора
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Записываем файл PPTX на диск
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Заливка изображением**
В PowerPoint заливка изображением — это опция форматирования, которая позволяет вам поместить изображение внутри фигуры. По сути, вы можете использовать изображение в качестве фона фигуры.

Вот как использовать Aspose.Slides для заполнения фигуры изображением:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) фигуры на `Picture`.
5. Установите режим заливки изображения на Плитка.
6. Создайте объект `IPPImage`, используя изображение, которое будет использоваться для заполнения фигуры.
7. Установите свойство `Picture.Image` объекта `PictureFillFormat` на недавно созданный `IPPImage`.
8. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает вам, как заполнить фигуру изображением:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем прямоугольник автозаполнения
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // Устанавливаем тип заливки на изображение
    shp.getFillFormat().setFillType(FillType.Picture);

    // Устанавливаем режим заливки изображения
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Устанавливаем изображение
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Записываем файл PPTX на диск
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сплошная цветная заливка**
В PowerPoint сплошная цветная заливка — это опция форматирования, которая позволяет вам залить фигуру одним цветом. Выбранный цвет обычно является простым цветом. Цвет применяется к фону фигуры с любыми специальными эффектами или изменениями.

Вот как использовать Aspose.Slides для применения сплошной цветной заливки к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) фигуры на `Solid`.
5. Установите ваш предпочитаемый цвет для фигуры.
6. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает вам, как применить сплошную цветную заливку к коробке в PowerPoint:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляем прямоугольник автозаполнения
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Устанавливаем тип заливки на Сплошной
    shape.getFillFormat().setFillType(FillType.Solid);

    // Устанавливаем цвет для прямоугольника
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Записываем файл PPTX на диск
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка прозрачности**

В PowerPoint при заливке фигур сплошными цветами, градиентами, изображениями или текстурами, вы можете установить уровень прозрачности, который определяет непрозрачность заливки. Таким образом, например, если вы установите низкий уровень прозрачности, объект слайда или фон, находящийся за (фигурой), будет виден.

Aspose.Slides позволяет вам установить уровень прозрачности для фигуры следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) на слайд.
4. Используйте `new Color` с установленным компонентом альфа.
5. Сохраните объект как файл PowerPoint.

Этот код на Java демонстрирует процесс:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляем сплошную фигуру
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Добавляем прозрачную фигуру поверх сплошной фигуры
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // Записываем файл PPTX на диск
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Вращение фигур**
Aspose.Slides позволяет вам вращать фигуру, добавленную на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) на слайд.
4. Поверните фигуру на необходимое количество градусов.
5. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает вам, как вращать фигуру на 90 градусов:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем прямоугольник автозаполнения
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Вращаем фигуру на 90 градусов
    shp.setRotation(90);

    // Записываем файл PPTX на диск
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление эффектов 3D-обводки**
Aspose.Slides позволяет вам добавлять эффекты 3D-обводки к фигуре, изменяя ее параметры [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) на слайд.
4. Установите ваши предпочтительные параметры для свойств [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) фигуры.
5. Запишите презентацию на диск.

Этот код на Java показывает вам, как добавить эффекты 3D-обводки к фигуре:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляем фигуру на слайд
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Устанавливаем параметры ThreeDFormat фигуры
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Записываем презентацию в файл PPTX
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление эффекта 3D-вращения**
Aspose.Slides позволяет вам применять эффекты 3D-вращения к фигуре, изменяя ее параметры [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) на слайд.
4. Укажите ваши предпочтительные значения для [CameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICamera#getCameraType--) и [LightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRig#getLightType--).
5. Запишите презентацию на диск.

Этот код на Java показывает вам, как применить эффекты 3D-вращения к фигуре:

```java
// Создаем экземпляр класса презетации, представляющего файл презентации
Presentation pres = new Presentation();
try {
    IShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(0, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Записываем презентацию в файл PPTX
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сброс форматирования**

Этот код на Java показывает вам, как сбросить форматирование на слайде и вернуть положение, размер и форматирование каждой фигуры, имеющей плейсхолдер на [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutSlide), к значениям по умолчанию:

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // каждая фигура на слайде, которая имеет плейсхолдер на макете, будет возвращена к значениям по умолчанию
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```