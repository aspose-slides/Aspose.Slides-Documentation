---
title: Форматирование текста
type: docs
weight: 50
url: /androidjava/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание текстовых абзацев
- прозрачность текста
- свойства шрифта абзаца
- семейство шрифтов
- вращение текста
- пользовательский угол вращения
- текстовый каркас
- межстрочное расстояние
- свойство автофита
- якорь текстового каркаса
- табуляция текста
- стиль текста по умолчанию
- Java
- Aspose.Slides для Android через Java
description: "Управление и манипуляция свойствами текста и текстового каркаса в Java"
---

## **Выделение текста**
Метод [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

Он позволяет выделить часть текста фоновым цветом с использованием текстового образца, аналогично инструменту выделения цвета текста в PowerPoint 2019.

Пример кода ниже показывает, как использовать эту функцию:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // выделение всех слов 'важно'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// выделение всех отдельных вхождений 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Aspose предоставляет простой, [бесплатный онлайн сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Выделение текста с использованием регулярного выражения**

Метод [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

Он позволяет выделить часть текста фоновым цветом, используя регулярное выражение, аналогично инструменту выделения цвета текста в PowerPoint 2019.

Пример кода ниже показывает, как использовать эту функцию:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // выделение всех слов длиной 10 символов или более
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка цвета фона текста**

Aspose.Slides позволяет вам указать предпочитаемый цвет для фона текста.

Этот код на Java показывает, как установить цвет фона для всего текста:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Черный");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Красный ");

    Portion portion3 = new Portion("Черный");
    portion3.getPortionFormat().setFontBold(NullableBool.True);

    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);

    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    StreamSupport.stream(autoShape.getTextFrame().getParagraphs().spliterator(), false)
            .map(p -> p.getPortions())
            .forEach(c -> c.forEach(ic -> ic.getPortionFormat().getHighlightColor().setColor(Color.BLUE)));

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Этот код на Java показывает, как установить цвет фона только для части текста:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Черный");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Красный ");

    Portion portion3 = new Portion("Черный");
    portion3.getPortionFormat().setFontBold(NullableBool.True);
    
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    
    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    Optional<IPortion> redPortion = StreamSupport.stream(autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false)
            .filter(p -> p.getText().contains("Красный"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Выравнивание текстовых абзацев**

Форматирование текста является одним из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides для Android через Java поддерживает добавление текста на слайды, но в этой теме мы увидим, как мы можем управлять выравниванием текстовых абзацев на слайде. Пожалуйста, следуйте приведенным ниже шагам, чтобы выровнять текстовые абзацы с использованием Aspose.Slides для Android через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к фигурным шаблонам, присутствующим на слайде, и приведите их к типу [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
4. Получите абзац (который необходимо выровнять) из [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) класса AutoShape.
5. Выровняйте абзац. Абзац может быть выровнен по правому, левому, центральному и выровненным по ширине.
6. Запишите измененную презентацию в виде файла PPTX.

Реализация вышеуказанных шагов приведена ниже.

```java
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);

    // Доступ к первому и второму плейсхолдерам на слайде и приведение их к типу AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Изменение текста в обоих плейсхолдерах
    tf1.setText("Выравнивание по центру с помощью Aspose");
    tf2.setText("Выравнивание по центру с помощью Aspose");

    // Получение первого абзаца плейсхолдеров
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Выравнивание текстового абзаца по центру
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Запись презентации в виде файла PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка прозрачности текста**
В этой статье демонстрируется, как установить свойство прозрачности для любой текстовой фигуры с использованием Aspose.Slides для Android через Java. Для установки прозрачности текста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Запишите презентацию в виде файла PPTX.

Реализация вышеуказанных шагов приведена ниже.

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - прозрачность: "+ (shadowColor.getAlpha() / 255f) * 100);

    // Установить прозрачность на ноль процентов
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка интервала между символами для текста**

Aspose.Slides позволяет устанавливать пространство между буквами в текстовом поле. Таким образом, вы можете регулировать визуальную плотность строки или блока текста, расширяя или сжимая пространство между символами.

Этот код на Java показывает, как расширить расстояние для одной строки текста и сократить расстояние для другой строки:

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // расширить
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // сжать

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **Управление свойствами шрифта абзацев**

Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различными способами, чтобы выделить конкретные секции и слова или соответствовать корпоративным стилям. Форматирование текста помогает пользователям варьировать внешний вид и ощущение содержимого презентации. Эта статья демонстрирует, как использовать Aspose.Slides для Android через Java для настройки свойств шрифтов абзацев текста на слайдах. Чтобы управлять свойствами шрифта абзаца с использованием Aspose.Slides для Android через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к шарнирным фигурам в слайде и приведите их к типу [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. Получите [Абзац](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) из [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame), предоставленного [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
1. Обоснуйте абзац.
1. Получите текст Portion абзаца.
1. Определите шрифт, используя FontData, и установите шрифт текстового Portion соответствующим образом.
   1. Установите шрифт в жирный.
   1. Установите шрифт в курсив.
1. Установите цвет шрифта, используя [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) предоставленный объектом [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
1. Запишите измененную презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Реализация вышеуказанных шагов приведена ниже. Она берет неприукрашеную презентацию и форматирует шрифты на одном из слайдов.

```java
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Получение ссылки на слайд с использованием его позиции
    ISlide slide = pres.getSlides().get_Item(0);

    // Доступ к первому и второму плейсхолдерам на слайде и приведение их к типу AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Получение первого абзаца
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Получение первой части
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Определение новых шрифтов
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Присвоение новых шрифтов доле
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Установка шрифта в жирный
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Установка шрифта в курсив
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Установка цвета шрифта
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Запись PPTX на диск
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление семейством шрифтов текста**
Часть текста используется для хранения текста с подобным стилем форматирования в абзаце. Эта статья показывает, как использовать Aspose.Slides для Android через Java, чтобы создать текстовое поле с некоторым текстом, а затем определить определенный шрифт и различные другие свойства в категории шрифта. Чтобы создать текстовое поле и установить свойства шрифта текста в нем:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) на слайд.
4. Удалите стиль заполнения, связанный с [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. Получите доступ к текстовому каркасу фигуры.
6. Добавьте некоторый текст в текстовый каркас.
7. Получите доступ к объекту Portion, связанному с [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
8. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
9. Установите другие свойства шрифта, такие как жирный, курсив, подчеркивание, цвет и высота, с помощью соответствующих свойств, предоставляемых объектом Portion.
10. Запишите измененную презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.

```java
// Создание презентации
Presentation pres = new Presentation();
try {

    // Получение первого слайда
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавление фигуры типа Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Удалите любой стиль заполнения, связанный с фигурой
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Получение текстового каркаса, связанного с фигурой
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Получение Portion, связанного с TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Установка шрифта для Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Установка свойства шрифта в жирный
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Установка свойства шрифта в курсив
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Установка свойства шрифта в подчеркивание
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Установка высоты шрифта
    port.getPortionFormat().setFontHeight(25);

    // Установка цвета шрифта
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Запись PPTX на диск 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка размера шрифта для текста**

Aspose.Slides позволяет вам выбирать предпочитаемый размер шрифта для существующего текста в абзаце и других текстов, которые могут быть добавлены в абзац позже.

Этот код на Java показывает, как установить размер шрифта для текстов, содержащихся в абзаце:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Получает первую фигуру, например.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // Получение первого абзаца, например.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // Устанавливает размер шрифта по умолчанию на 20 пунктов для всех текстовых частей в абзаце. 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Устанавливает размер шрифта на 20 пунктов для текущих текстовых частей в абзаце. 
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Установка вращения текста**

Aspose.Slides для Android через Java позволяет разработчикам вращать текст. Текст может быть установлен так, чтобы выглядеть как [Горизонтальный](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal), [Вертикальный](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical), [Вертикальный270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270), [WordArtВертикальный](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical), [ВосточноазиатскийВертикальный](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical), [МонгольскийВертикальный](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) или [WordArtВертикальныйСправоНалево](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Чтобы повернуть текст любого TextFrame, пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Поверните текст](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Сохраните файл на диск.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавьте фигуру типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Добавьте TextFrame к фигуре
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Получение текстового каркаса
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Создание объекта Paragraph для текстового каркаса
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Создание объекта Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Удобная быстрая лисица прыгает через ленивую собаку. Удобная быстрая лисица прыгает через ленивую собаку.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Сохранение презентации
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка пользовательского угла вращения для TextFrame**
Aspose.Slides для Android через Java теперь поддерживает установку пользовательского угла вращения для текстового каркаса. В этой теме мы увидим на примере, как установить свойство RotationAngle в Aspose.Slides. Новые методы [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) и [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) были добавлены в интерфейсы [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) и [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat), которые позволяют установить пользовательский угол вращения для текстового каркаса. Чтобы установить RotationAngle, пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. [Установите свойство RotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Запишите презентацию в виде файла PPTX.

В приведенном ниже примере мы устанавливаем свойство RotationAngle.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавьте фигуру типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Добавьте TextFrame к фигуре
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Получение текстового каркаса
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Создание объекта Paragraph для текстового каркаса
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создание объекта Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Пример вращения текста.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Сохранение презентации
    pres.save(resourcesOutputPath + "RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Межстрочное расстояние абзаца**
Aspose.Slides предоставляет свойства в [ParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` и `SpaceWithin`—которые позволяют управлять межстрочным расстоянием для абзаца. Эти три свойства используются следующим образом:

* Чтобы указать межстрочное расстояние для абзаца в процентах, используйте положительное значение. 
* Чтобы указать межстрочное расстояние для абзаца в пунктах, используйте отрицательное значение.

Например, вы можете установить межстрочное расстояние в 16 пунктов для абзаца, установив свойство `SpaceBefore` в -16.

Вот как вы можете указать межстрочное расстояние для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с некоторым текстом в ней.
2. Получите ссылку на слайд через его индекс.
3. Доступ к TextFrame.
4. Доступ к абзацу.
5. Установите свойства абзаца.
6. Сохраните презентацию.

Этот код на Java показывает, как указать межстрочное расстояние для абзаца:

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Получение ссылки на слайд через его индекс
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Доступ к TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Доступ к абзацу
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Установка свойств абзаца
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Сохранение презентации
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка свойства AutofitType для TextFrame**
В этой теме мы изучим различные свойства форматирования текстового каркаса. Эта статья охватывает, как установить свойство AutofitType текстового каркаса, якорь текста и вращение текста в презентации. Aspose.Slides для Android через Java позволяет разработчикам установить свойство AutofitType для любого текстового каркаса. AutofitType может быть установлен в [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) или [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape). Если установлено в [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal), то форма останется прежней, тогда как текст будет настроен без изменения самой формы, а если AutofitType установлен в [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape), то форма будет изменена так, чтобы только необходимый текст содержался в ней. Чтобы установить свойство AutofitType текстового каркаса, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Установите AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) текстового каркаса.
6. Сохраните файл на диск.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавьте фигуру типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Добавьте TextFrame к фигуре
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Получение текстового каркаса
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Создание объекта Paragraph для текстового каркаса
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создание объекта Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Удобная быстрая лисица прыгает через ленивую собаку. Удобная быстрая лисица прыгает через ленивую собаку.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Сохранение презентации
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка якоря для TextFrame**
Aspose.Slides для Android через Java позволяет разработчикам устанавливать якорь для любого TextFrame. TextAnchorType указывает, где располагается текст в фигуре. AnchorType может быть установлен в [Верх](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top), [Центр](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center), [Низ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom), [Выровненный](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) или [Распределенный](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed). Чтобы установить якорь для любого TextFrame, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Установите TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) текстового каркаса.
6. Сохраните файл на диск.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавьте фигуру типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Добавьте TextFrame к фигуре
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Получение текстового каркаса
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Создание объекта Paragraph для текстового каркаса
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Создание объекта Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Удобная быстрая лисица прыгает через ленивую собаку. Удобная быстрая лисица прыгает через ленивую собаку.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Сохранение презентации
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Табы и EffectiveTabs в презентации**
Все табуляции текста заданы в пикселях.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Рисунок: 2 явных табуляции и 2 табуляции по умолчанию**|
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно свойству Tabs.Count.
- Коллекция EffectiveTabs включает все табуляции (из коллекции Tabs и табуляции по умолчанию).
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно свойству Tabs.Count.
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между табуляциями по умолчанию (3 и 4 в нашем примере).
- Метод EffectiveTabs.GetTabByIndex(index) с индексом = 0 вернет первую явную табуляцию (Позиция = 731), индекс = 1 - вторую табуляцию (Позиция = 1241). Если вы попробуете получить следующую табуляцию с индексом = 2, будет возвращена первая табуляция по умолчанию (Позиция = 1470) и т.д.
- Метод EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, у вас есть текст: "Привет, мир!". Чтобы отобразить такой текст, вам нужно знать, с какого места начинать рисовать "мир!". Сначала вы должны вычислить длину "Привет" в пикселях и вызвать GetTabAfterPosition с этим значением. Вы получите следующую позицию табуляции для рисования "мир!".

## **Установка стиля текста по умолчанию**

Если вам нужно применить одно и то же форматирование текста по умолчанию ко всем текстовым элементам презентации сразу, то вы можете использовать метод `getDefaultTextStyle` интерфейса [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) и установить предпочитаемое форматирование. Пример кода ниже показывает, как установить жирный шрифт по умолчанию (14 пунктов) для текста на всех слайдах в новой презентации.

```java
Presentation presentation = new Presentation();
try {
    // Получение верхнего уровня форматирования абзаца.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("DefaultTextStyle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```