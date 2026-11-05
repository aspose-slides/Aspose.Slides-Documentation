---
title: Форматирование фигур PowerPoint в Java
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/java/shape-formatting/
keywords:
- форматирование фигуры
- форматирование линии
- эффект эскиза
- эскиз линии фигуры
- форматирование стиля соединения
- градиентная заливка
- узорная заливка
- заливка изображением
- заливка текстурой
- сплошная заливка
- прозрачность фигуры
- черно-белая отрисовка фигуры
- отображение фигуры в градациях серого
- вращение фигуры
- 3D-эффект фаски
- 3D-эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в Java с помощью Aspose.Slides - задавайте стили заливки, линий и эффектов для файлов PPT и PPTX с точностью и полным контролем."
---
## **Введение**

Форматируйте фигуры в PowerPoint, регулируя их контуры, заливки и эффекты. Aspose.Slides for Java позволяет управлять этими параметрами программно, включая прозрачность, вращение и 3D‑форматирование.

![Варианты форматирования фигур в PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java предоставляет интерфейсы и методы, позволяющие форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

Используйте [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) для контроля контура фигуры. Этот пример создает незаполненный прямоугольник с синей пунктирной обводкой. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) выбирает составную линию «толстая‑тонкая», а [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) задает её ширину 7 пунктов и [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) выбирает шаблон штрихов.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

### **Установка пользовательских шаблонов штрихов линии**

Используйте [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) когда предопределённые стили линии не предоставляют нужных длины штрихов и промежутков, например для фирменных контуров или технических схем. Назначение шаблона автоматически меняет стиль штриха линии на [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

Элементы массива чередуются между длинами штриха и пробела, начиная со штриха. Каждое значение является кратным ширине линии: `{ 4, 2 }` при ширине 3 пункта даёт штрих 12 пунктов, за которым следует пробел 6 пунктов. Используйте пары конечных, неотрицательных значений для определения полных сегментов штрих‑пробел. В примере использованы положительные значения, чтобы каждый штрих и пробел были видимы.

Этот пример создаёт пять синих линий одинаковой длины и плоских окончаний. Первые три сравнивают шаблоны при ширине 3 пункта. Четвёртая повторяет первый шаблон при удвоенной ширине, удваивая длину как штриха, так и пробела. Пятая переключается с пользовательского шаблона на сплошную линию.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Возвратить последнюю линию к сплошному стилю.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы вместо этого вернуться к предопределённому пунктирному стилю, передайте [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) в [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). Выбранный стиль контролирует внешний вид линии.

Результат в PowerPoint сверху вниз: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; и **Solid, 3 pt**.

![Три пользовательских шаблона штрихов, более широкая линия, использующая первый шаблон, и сплошная линия в PowerPoint](custom-dash-patterns.png)

### **Установка окончаний линии**

Используйте [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) для установки концов открытой линии. Класс [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) предоставляет три явных стиля окончаний:

- `Flat`: Обводка останавливается на конечной точке.
- `Round`: Полукруглая головка выступает за конечную точку на половину ширины линии.
- `Square`: Квадратная головка выступает за конечную точку на половину ширины линии.

Класс также включает `NotDefined`, что означает, что стиль окончания не задан явно.

Окончания отличаются от стрелок, которые добавляют символы к концам линии, и соединений, которые управляют углами между сегментами линии. В этом примере стрелки отключаются с помощью [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) и [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-), чтобы сравнивались только формы окончаний.

Следующий пример создаёт три в остальных отношениях одинаковые горизонтальные линии шириной 20 пунктов. Сверху вниз они используют плоские, круглые и квадратные окончания. Их конечные точки имеют одинаковые горизонтальные координаты; круглые и квадратные окончания выступают на 10 пунктов за каждую конечную точку.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат в PowerPoint сверху вниз: **Flat**, **Round**, и **Square**.

![Плоские, круглые и квадратные окончания на одинаковых толстых линиях в PowerPoint](line-caps.png)

## **Применение эффектов эскиза к линиям фигур**

Эффект эскиза делает линию фигуры похожей на нарисованную от руки. Используйте [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) для доступа к настройкам линии, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) для доступа к настройкам эскиза и [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) для выбора значения из класса [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Следующий код Java демонстрирует, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) и удалить его с помощью [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться из темы, главного слайда или макета, используйте [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--), доступ к [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) и читайте [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Эффективное значение отражает фактическое форматирование после разрешения наследования. Этот пример требует существующей презентации с как минимум одной фигурой на первом слайде и выводит оба значения:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Round
* Miter
* Bevel

Стиль соединения определяет, как два сегмента контура встречаются в угле. Используйте **Round** для округлых углов, **Miter** для острых углов или **Bevel** для сглаженных углов.

![Стиль соединения в презентации](join-style-powerpoint.png)

Этот пример создаёт три чёрных прямоугольника с синими контурами шириной 15 пунктов. Он использует [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) для установки значений miter, bevel и round класса [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) соответственно, чтобы сравнить, как рисуются углы.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ограничение соединений Miter на острых углах**

Используйте [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) совместно с [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-), установленным в [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/), чтобы ограничить, насколько далеко может вытягиваться острый угол.

Ограничение — это отношение расстояния между внутренними и внешними углами соединения к ширине линии. Например, значение `8` позволяет длине соединения Miter достигать до восьми ширин линии; это не измерение в пунктах. Если угол превысит ограничение, PowerPoint использует скошенный (bevel) соединительный элемент в этом месте. Большое ограничение позволяет более острые точки. Эта настройка относится только к соединениям Miter, и её изменение не даёт видимого эффекта, пока угол остаётся в пределах обоих ограничений.

В этом примере создаются два одинаковых незаполненных треугольника с контурами шириной 20 пунктов. Левая треугольник использует ограничение `2`, а правая — `8`. Каждый треугольник шириной 80 пунктов и высотой 160 пунктов, что даёт верхнему углу отношение длины Miter к ширине линии примерно `4.12`. Поэтому PowerPoint скашивает левый верхний угол и оставляет правый острым.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат в PowerPoint: **Miter limit 2** слева и **miter limit 8** справа.

![Скошенный верх с ограничением miter 2 и острый верх с ограничением miter 8 в PowerPoint](miter-limits.png)

## **Градиентная заливка**

Градиентная заливка смешивает цвета по фигуре. Этот пример заполняет эллипс линейным градиентом под углом 45 градусов от красного к фиолетовому с использованием [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). Метод [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) помещает контрольные точки цвета в позиции 0 и 1, в начале и в конце градиента. Очистка существующих точек гарантирует, что будут использованы только эти два цвета.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Choose a Gradient Rendering Style](/slides/ru/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга, не меняя градиентную заливку, сохранённую в презентации.

### **Установка угла линейного градиента**

Используйте [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) для управления ориентацией заливки [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). Угол измеряется в градусах и увеличивается по часовой стрелке: `0` — слева направо, `90` — сверху вниз, `180` — справа налево, `270` — снизу вверх. Поддерживаются дробные углы. Конечные углы за пределами `[0, 360)` нормализуются к одному обороту; например, `-45` становится `315`, а `360` — `0`.

Этот пример создаёт шесть прямоугольников с одинаковыми красными, зелёными и синими точками остановки на позициях `0`, `0.5` и `1`. Масштабирование отключено, чтобы угол можно было сравнить независимо от пропорций прямоугольников. Углы слева направо: `0`, `45` и `90` в первой строке, и `135`, `180` и `270` во второй строке.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат в PowerPoint:

![Линейные градиенты при 0, 45 и 90 градусах в верхней строке, и 135, 180 и 270 градусах в нижней строке](linear-gradient-angles.png)

### **Масштабирование линейного градиента с фигурой**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) принимает значение [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). Установите его явно в `False`, чтобы сохранять геометрический угол градиента при изменении пропорций фигуры, или в `True`, чтобы масштабировать градиент вместе с шириной и высотой фигуры. При включённом масштабировании видимый угол может отличаться от заданного угла у не квадратной фигуры.

Следующий пример использует угол `45` градусов и те же цветовые остановки, что и в сравнении углов. В левом столбце используется `False`; в правом — `True`. Каждый столбец содержит широкий прямоугольник над высоким. Оба начинаются с одинаковых широких размеров; изменение ширины и высоты второго прямоугольника демонстрирует, как заливка реагирует на изменение размеров без изменения настроек градиента.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат в PowerPoint, с отключённым масштабированием слева и включённым справа:

![Широкие и высокие прямоугольники с градиентом 45 градусов, сравнение LinearGradientScaled False слева и True справа](linear-gradient-scaling.png)

При отключённом масштабировании диагональные цветовые полосы сохраняют одинаковую ориентацию в обоих прямоугольниках. При включённом масштабировании полосы растягиваются вместе с пропорциями фигуры. Это помогает воспроизвести градиент шаблона при адаптации фигуры к другому размеру. В квадрате включение масштабирования не меняет внешний вид этого градиента `45` градусов.

И угол, и настройки масштабирования применяются к линейным градиентам. Они не управляют заливками [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **Комбинирование угла с направлением градиента**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) выбирает стиль градиента из класса [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/); это не замена числовому углу. Для линейного градиента стили углов могут менять область распределения цветов без изменения угла, заданного через [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Сохраняйте направление неизменным при сравнении углов или масштабировании.

Следующий пример применяет те же настройки в противоположном порядке. У двух прямоугольников одинаковый внешний вид: назначение направления до или после угла не меняет результат.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Заполнение узором**

Заполнение узором применяется к двухцветному рисунку, например точкам, полоскам или шахматному узору. Этот пример использует [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) для выбора узора решётки. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) задаёт светло‑серый фон, а [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) задаёт жёлтый цвет узора.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прямоугольник с заполнением узором](pattern-fill.png)

## **Заполнение изображением**

Заполнение изображением использует картинку внутри фигуры. Этот пример требует локального изображения и использует [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) для загрузки его в коллекцию изображений презентации. Установка [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) в режим мозаики повторяет изображение внутри прямоугольника. Исходное изображение, используемое здесь, показано ниже:

![Изображение лотоса](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Фигура с заполнением изображением](picture-fill.png)

### **Повтор изображения как текстура**

Если вы хотите установить повторяющееся изображение как текстуру и настроить поведение мозаики, вы можете использовать следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Устанавливает режим заполнения изображением — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Задаёт выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Управляет тем, будет ли плитка отражена по горизонтали, вертикали или обеими способами.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Устанавливает горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Устанавливает вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Определяет вертикальный масштаб плитки в процентах.

Этот пример требует локального изображения и настраивает [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) для повторения его в размере 50 % от оригинала. Смещения −32 пункта сдвигают плитки по горизонтали и вертикали; выравнивание в правом нижнем углу и отражение в обоих направлениях определяют расположение повторяющейся текстуры.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Параметры мозаики](tile-options.png)

## **Заполнение сплошным цветом**

Сплошная заливка придаёт фигуре один, однородный цвет. Этот пример использует [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) для установки режима сплошной заливки и задаёт жёлтый цвет через [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--), затем сохраняет прямоугольник в презентацию.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Фигура со сплошной заливкой](solid-color-fill.png)

### **Копирование цветов с сохранением ссылок на тему**

Используйте [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) для копирования определения цвета, включая тип цвета, ссылку на тему и преобразования. Это полезно при переносе цвета заливки между фигурами, которые должны продолжать использовать тему презентации. Метод копирует только цвет: он не копирует тип заливки, контур или другое форматирование фигуры. Установите тип заливки назначения явно с помощью [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-).

Этот пример создаёт три прямоугольника слева направо: источник, копию с учётом темы и фиксированную копию RGB. Источник использует [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) для ссылки на первый акцентный цвет и добавляет оттенок через [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-). Копия RGB использует эффективный цвет заливки источника, поэтому все три изначально выглядят одинаково. Вызов [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) задаёт фиксированное значение RGB и очищает любые существующие преобразования цвета.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Тематические ссылки следуют новому акцентному цвету; фиксированное значение RGB не меняется.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

До изменения темы все три заливки совпадают:

![Источник, копия copyFrom и фиксированная цель RGB с одинаковой синей заливкой](color-copy-before.png)

После изменения темы источник и копия с учётом темы следуют за новым акцентным цветом и сохраняют свой оттенок. Фиксированная копия RGB остаётся синей:

![Источник и копия copyFrom с оранжевыми заливками, в то время как фиксированная цель RGB остаётся синей](color-copy-after.png)

Скопированное определение независимо от источника. Последующее изменение ссылки темы источника, назначение другого цвета или добавление/удаление его преобразований не изменит назначение. Изменение темы всё равно влияет на обе фигуры, поскольку каждая независимо ссылается на один и тот же цвет темы.

Сохранение и повторное открытие PPTX сохраняет тип скопированного цвета, возвращаемый [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--), ссылку на тему и коллекцию преобразований, возвращаемую [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--); он не преобразует определение в RGB.

При копировании между разными контекстами темы, например между презентациями с разными акцентными палитрами, скопированная ссылка разрешается относительно темы получателя. Та же ссылка и преобразования могут дать иной видимый цвет. См. [Presentation Theme](/slides/ru/java/presentation-theme/) для получения дополнительной информации о настройке цветов темы.

## **Использование фона слайда как заливки фигуры**

Используйте [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) когда фигура должна соответствовать фону слайда, например в шаблоне презентации. Сначала задайте тип заливки через [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) в [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) , чтобы удалить любую явную заливку. При этой комбинации фигура использует фон слайда вместо своей заливки стиля. Включение флага само по себе не удаляет существующую явную заливку.

Это отличается от [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): заливка фоном покрывает объекты за фигурой соответствующей областью фона слайда, в то время как отсутствие заливки оставляет эти объекты видимыми. Градиент остаётся выровненным по слайду, а не начинается внутри каждой фигуры.

Следующий пример создаёт фон мастера, наследуемый слайдом, и помещает пурпурную полоску позади трёх прямоугольников. Левый прямоугольник использует фон, средний — без заливки, правый переключается от фоновой заливки к явной оранжевой заливке.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Наследовать градиент из мастер‑слайда.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // Добавить этот объект первым, чтобы он оказался позади прямоугольников.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Отключить заливку фоном перед применением явной заливки.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат слева направо: **background fill**, **no fill**, и **explicit fill**. Пурпурная полоска скрыта левым и правым прямоугольниками, но остаётся видимой через средний прямоугольник.

![Фоновая заливка, отсутствие заливки и явная оранжевая заливка поверх пурпурной полоски](background-fill.png)

То же поведение применяется к фону, определённому непосредственно на слайде или унаследованному от макета. Фигура использует разрешённый фон слайда; в примере оба фона слайда и макета не заданы, поэтому их предоставляет мастер.

## **Установка прозрачности**

Для сплошной заливки альфа‑компонент цвета управляет непрозрачностью: 0 — полностью прозрачный, 255 — полностью непрозрачный. Этот пример использует альфа‑значение 128 для жёлтого прямоугольника, делая его примерно на 50 % прозрачным, чтобы нижний прямоугольник оставался видимым. Цвет задаётся через [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Используйте [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) для вращения фигуры в плоскости слайда. Угол измеряется в градусах; этот пример вращает прямоугольник на 5 градусов по часовой стрелке и сохраняет презентацию.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D‑эффекта фаски**

Используйте [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) чтобы придать фигуре глубину и фаску. Этот пример создаёт зелёный эллипс с оранжевым контуром, использует [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) для установки глубины в 4 пункта и применяет круглую верхнюю фаску шириной и высотой по 6 пунктов через [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). Камера с фронтальным ортографическим видом и трёхточечное освещение делают фаску видимой.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑фаски](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

3D‑вид фигуры контролируется настройками её камеры. Этот пример использует [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) с углами широты, долготы и вращения 40, 35 и 20 градусов соответственно. Он выбирает изометрическую камеру через [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) и сбалансированное освещение через [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), затем сохраняет отформатированный прямоугольник.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Управление черно‑белой отрисовкой фигур**

Метод [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) указывает, как отдельная фигура отрисовывается, когда презентация просматривается или обрабатывается в черно‑белом режиме. Он сам по себе не включает черно‑белый режим отображения и не меняет заливку, контур или другое форматирование фигуры в обычном цветном режиме.

Используйте значение из класса [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) для выбора желаемого поведения. Например, `Automatic` позволяет приложению‑отображателю выбрать преобразование, `Gray` и `LightGray` используют серый цвет, `BlackWhite` использует только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в черно‑белом режиме. `NotDefined` означает, что режим для фигуры не задан.

Этот пример создаёт оранжевый прямоугольник и использует [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) для установки режима в `Gray`. Сохранённая фигура сохраняет оранжую заливку для обычного цветного отображения и запрашивает серую окраску у приложений, которые учитывают настройки черно‑белого отображения:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В обычном цветном режиме прямоугольник сохраняет оранжную заливку. В рабочем процессе черно‑белого отображения он использует серый цвет, потому что его режим установлен в `Gray`. Это позволяет сохранять слайд в полном цвете, определяя при этом отдельный вид для печати, предварительного просмотра или других процессов, которые учитывают черно‑белые настройки отображения презентации.

## **Сброс форматирования**

Используйте [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) для восстановления позиции, размеров и форматирования заполнителей слайда из соответствующих заполнителей макета. Этот пример требует существующей презентации с заполнителями, привязанными к макету, и сбрасывает каждый слайд перед сохранением. Фигуры без соответствующих заполнителей макета не сбрасываются.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Цвета, стили линий и параметры эффектов обычно добавляют мало данных по сравнению с встроенными изображениями и медиа. Заполнение изображением может увеличить размер файла, поскольку его изображения хранятся в презентации.

**Как определить фигуры на слайде, имеющие одинаковое форматирование, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — заливку, контур и параметры эффектов. Если все соответствующие значения совпадают, считайте их стили одинаковыми и логически группируйте такие фигуры, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в наборе шаблонных слайдов или файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные фигуры и повторно применяйте их форматирование там, где это необходимо.