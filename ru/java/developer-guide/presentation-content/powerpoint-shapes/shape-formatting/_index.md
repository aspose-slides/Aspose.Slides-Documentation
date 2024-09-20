---
title: Форматирование фигур
type: docs
weight: 20
url: /java/shape-formatting/
keywords: "Формат фигуры, формат линий, формат стилей соединения, градиентная заливка, паттерн-заливка, заливка изображением, сплошная заливка, вращение фигур, 3d эффекты скоса, 3d эффект вращения, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Форматирование фигур в презентации PowerPoint на Java"
---

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать фигуры, изменяя или применяя определенные эффекты к их составным линиям. Кроме того, вы можете форматировать фигуры, указывая настройки, определяющие, как они (их области) будут заполнены. 

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides для Java** предоставляет интерфейсы и свойства, которые позволяют вам форматировать фигуры на основе известных опций в PowerPoint. 

## **Формат линий**

С помощью Aspose.Slides вы можете указать желаемый стиль линии для фигуры. Эти шаги описывают такую процедуру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) на слайд.
4. Установите цвет для линий фигуры.
5. Установите ширину для линий фигуры.
6. Установите [стиль линии](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) для линий фигуры.
7. Установите [стиль штриха](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) для линий фигуры. 
8. Сохраните измененную презентацию в файл PPTX.

Этот код на Java демонстрирует операцию, в которой мы отформатировали прямоугольник `AutoShape`:

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет автозакругление прямоугольника
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Устанавливает цвет заливки для фигуры прямоугольника
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // Применяет некоторые настройки форматирования к линиям прямоугольника
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Устанавливает цвет для линии прямоугольника
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Записывает файл PPTX на диск
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Формат стилей соединения**
Это три типа соединений:

* Закругленный
* Острый
* Скошенный

По умолчанию, когда PowerPoint соединяет две линии под углом (или угол фигуры), он использует настройку **Закругленный**. Однако, если вы хотите нарисовать фигуру с очень острыми углами, вы можете выбрать **Острый**.

![join-style-powerpoint](join-style-powerpoint.png)

Этот Java-код демонстрирует операцию, в которой были созданы 3 прямоугольника (изображение выше) с настройками типов соединения Острый, Скошенный и Закругленный:

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {

    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет 3 автозакругления прямоугольников
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // Устанавливает цвет заливки для фигуры прямоугольника
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Устанавливает ширину линии
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // Устанавливает цвет для линии прямоугольника
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Устанавливает стиль соединения
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Добавляет текст к каждому прямоугольнику
    ((IAutoShape)shp1).getTextFrame().setText("Стиль соединения Острый");
    ((IAutoShape)shp2).getTextFrame().setText("Стиль соединения Скошенный");
    ((IAutoShape)shp3).getTextFrame().setText("Стиль соединения Закругленный");

    // Записывает файл PPTX на диск
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Градиентная заливка**
В PowerPoint Градиентная заливка - это опция форматирования, которая позволяет вам применять непрерывный переход цветов к фигуре. Например, вы можете применять два или более цветов в настройке, где один цвет постепенно преобразуется в другой. 

Вот как вы используете Aspose.Slides, чтобы применить градиентную заливку к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) фигуры на `Gradient`.
5. Добавьте свои 2 любимых цвета с определенными позициями, используя методы `Add`, доступные в коллекции `GradientStops`, связанной с классом `GradientFormat`.
6. Сохраните измененную презентацию в файл PPTX.

Этот Java-код демонстрирует операцию, в которой был использован эффект градиентной заливки на эллипсе:

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет эллипс автозакругления
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Применяет градиентное форматирование к эллипсу
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Устанавливает направление градиента
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Добавляет 2 градиентных стопа
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Записывает файл PPTX на диск
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Паттерн-заливка**
В PowerPoint Паттерн-заливка - это опция форматирования, которая позволяет вам применять двухцветный дизайн, состоящий из точек, полос, перекрестных штрихов или клеток к фигуре. Кроме того, вы можете выбрать свои предпочтительные цвета для переднего плана и фона вашего паттерна. 

Aspose.Slides предоставляет более 45 предопределенных стилей, которые можно использовать для форматирования фигур и улучшения презентаций. Даже после того как вы выберете предопределенный паттерн, вы все равно можете указать цвета, которые должен содержать паттерн.

Вот как вы используете Aspose.Slides, чтобы применить паттерн-заливку к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) фигуры на `Pattern`.
5. Установите стиль паттерна для фигуры. 
6. Установите [Цвет фона](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getBackColor--) для [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
7. Установите [Цвет переднего плана](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getForeColor--) для [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat).
8. Сохраните измененную презентацию в файл PPTX.

Этот Java-код демонстрирует операцию, в которой была использована паттерн-заливка для украшения прямоугольника: 

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет автозакругление прямоугольника
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Устанавливает тип заливки на Паттерн
    shp.getFillFormat().setFillType(FillType.Pattern);

    // Устанавливает стиль паттерна
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Устанавливает цвета фона и переднего плана паттерна
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Записывает файл PPTX на диск
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Заливка изображением**
В PowerPoint Заливка изображением - это опция форматирования, которая позволяет вам разместить изображение внутри фигуры. В основном, вы можете использовать изображение в качестве фона фигуры. 

Вот как вы используете Aspose.Slides, чтобы заполнить фигуру изображением:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) фигуры на `Picture`.
5. Установите режим заливки изображения на Плитка.
6. Создайте объект `IPPImage`, используя изображение, которое будет использоваться для заполнения фигуры.
7. Установите свойство `Picture.Image` объекта `PictureFillFormat` на недавно созданный `IPPImage`.
8. Сохраните измененную презентацию в файл PPTX.

Этот Java-код показывает, как заполнить фигуру изображением:

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет автозакругление прямоугольника
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // Устанавливает тип заливки на Изображение
    shp.getFillFormat().setFillType(FillType.Picture);

    // Устанавливает режим заливки изображения
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Устанавливает изображение
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Записывает файл PPTX на диск
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сплошная заливка**
В PowerPoint Сплошная заливка - это опция форматирования, которая позволяет заполнить фигуру одним цветом. Выбранный цвет обычно является простым цветом. Цвет прикладывается к фону фигуры без каких-либо специальных эффектов или модификаций. 

Вот как вы используете Aspose.Slides, чтобы применить сплошную заливку к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) фигуры на `Solid`.
5. Установите свой предпочтительный цвет для фигуры.
6. Сохраните измененную презентацию в файл PPTX.

Этот Java-код показывает, как применить сплошную заливку к квадрату в PowerPoint:

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет автозакругление прямоугольника
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Устанавливает тип заливки на Сплошной
    shape.getFillFormat().setFillType(FillType.Solid);

    // Устанавливает цвет для прямоугольника
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Записывает файл PPTX на диск
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить прозрачность**

В PowerPoint, когда вы заполняете фигуры сплошными цветами, градиентами, изображениями или текстурами, вы можете указать уровень прозрачности, который определяет непрозрачность заливки. Таким образом, например, если вы установите низкий уровень прозрачности, объект на слайде или фон за (фигурой) будет виден. 

Aspose.Slides позволяет вам установить уровень прозрачности для фигуры таким образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) на слайд.
4. Используйте `new Color` с установленным альфа-компонентом.
5. Сохраните объект как файл PowerPoint. 

Этот Java-код демонстрирует процесс:

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет сплошную фигуру
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Добавляет прозрачную фигуру поверх сплошной фигуры
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // Записывает файл PPTX на диск
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Вращение фигур**
Aspose.Slides позволяет вам вращать фигуру, добавленную на слайд, следующим образом: 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) на слайд.
4. Вращайте фигуру на нужные градусы. 
5. Сохраните измененную презентацию в файл PPTX.

Этот Java-код показывает, как вращать фигуру на 90 градусов:

```java
// Создает экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет автозакругление прямоугольника
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Вращает фигуру на 90 градусов
    shp.setRotation(90);

    // Записывает файл PPTX на диск
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавить эффекты 3D-скоса**
Aspose.Slides позволяет добавлять 3D-скосы к фигуре, изменяя ее свойства [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) на слайд.
3. Установите ваши предпочтительные параметры для свойств [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) фигуры. 
4. Сохраните презентацию на диск.

Этот Java-код показывает, как добавить эффекты 3D-скоса к фигуре:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет фигуру на слайд
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Устанавливает свойства ThreeDFormat фигуры
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Записывает презентацию в файл PPTX
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавить эффект 3D-вращения**
Aspose.Slides позволяет применить эффекты 3D-вращения к фигуре, изменяя ее свойства [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) на слайд.
3. Укажите ваши предпочтительные значения для [CameraType](https://reference.aspose.com/slides/java/com.aspose.slides/ICamera#getCameraType--) и [LightType](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRig#getLightType--).
4. Сохраните презентацию на диск. 

Этот Java-код показывает, как применить эффекты 3D-вращения к фигуре:

```java
// Создает экземпляр класса Presentation
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

    // Записывает презентацию в файл PPTX
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сброс форматирования**

Этот Java-код показывает, как сбросить форматирование на слайде и вернуть позицию, размер и форматирование каждой фигуры, которая имеет заполнение на [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutSlide), к их значениям по умолчанию:

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // Каждая фигура на слайде, которая имеет заполнение на макете, будет возвращена
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```