---
title: Форматирование текста
type: docs
weight: 50
url: /ru/java/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание абзацев текста
- прозрачность текста
- свойства шрифта абзаца
- семейство шрифтов
- вращение текста
- произвольный угол вращения
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- якорь текстовой рамки
- табуляция текста
- стиль текста по умолчанию
- Java
- Aspose.Slides для Java
description: "Управление и манипуляция свойствами текста и текстовых рамок в Java"
---

## **Выделение текста**
Метод [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Он позволяет выделять часть текста цветом фона, используя текстовый образец, аналогично инструменту "Цвет выделения текста" в PowerPoint 2019.

Приведенный ниже фрагмент кода показывает, как использовать эту функцию:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // выделение всех слов 'важный'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// выделение всех отдельных 'the' вхождений
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Aspose предоставляет простой, [бесплатный онлайн сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Выделение текста с помощью регулярного выражения**

Метод [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Он позволяет выделять часть текста цветом фона, используя regex, аналогично инструменту "Цвет выделения текста" в PowerPoint 2019.

Приведенный ниже фрагмент кода показывает, как использовать эту функцию:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // выделение всех слов длиной 10 символов и более
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка цвета фона текста**

Aspose.Slides позволяет вам указать предпочитаемый цвет для фона текста.

Этот Java код показывает, как установить цвет фона для всего текста:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Чёрный");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Красный ");

    Portion portion3 = new Portion("Чёрный");
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

Этот Java код показывает, как установить цвет фона только для части текста:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Чёрный");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Красный ");

    Portion portion3 = new Portion("Чёрный");
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

## **Выравнивание абзацев текста**

Форматирование текста является одним из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides для Java поддерживает добавление текста на слайды, но в этой теме мы рассмотрим, как можно контролировать выравнивание текстовых абзацев на слайде. Пожалуйста, следуйте приведенным ниже шагам, чтобы выровнять текстовые абзацы с помощью Aspose.Slides для Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к фигурным заполняющим (Placeholder) формам, присутствующим на слайде, и выполните их приведение к [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. Получите абзац (который нужно выровнять) из [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) , предоставленного [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Выравните абзац. Абзац может быть выровнен по правому, левому, центру и по ширине.
6. Запишите изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.

```java
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);

    // Получение первого и второго заполнителей на слайде и приведение их к AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Измените текст в обоих заполнителях
    tf1.setText("Центр по Aspose");
    tf2.setText("Центр по Aspose");

    // Получение первого абзаца заполнителей
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Выравнивание текстового абзаца по центру
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Запись презентации в файл PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка прозрачности текста**
В этой статье показано, как установить свойство прозрачности для любой текстовой формы с использованием Aspose.Slides для Java. Чтобы установить прозрачность текста, пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Запишите презентацию в файл PPTX.

Реализация вышеперечисленных шагов представлена ниже.

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - прозрачность: "+ (shadowColor.getAlpha() / 255f) * 100);

    // Установка прозрачности на ноль процентов
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка межбуквенного интервала для текста**

Aspose.Slides позволяет вам устанавливать расстояние между буквами в текстовом поле. Таким образом, вы можете регулировать визуальную плотность строки или блока текста, расширяя или сжимая пространство между символами.

Этот Java-код показывает, как увеличить расстояние для одной строки текста и сжать расстояние для другой строки:

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // расширить
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // сжать

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **Управление свойствами шрифта абзаца**

Презентации обычно содержат как текст, так и изображения. Текст можно форматировать различными способами, как для выделения конкретных разделов и слов, так и для соответствия корпоративным стилям. Форматирование текста помогает пользователям варьировать внешний вид и облик содержимого презентации. В этой статье показано, как использовать Aspose.Slides для Java для настройки свойств шрифта абзацев текста на слайдах. Для управления свойствами шрифта абзаца с помощью Aspose.Slides для Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к заполняющим формам на слайде и приведите их к [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Получите [Абзац](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) из [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame), предоставленного [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Выравните абзац.
1. Получите текстовую долю (Portion) абзаца.
1. Определите шрифт с помощью FontData и установите шрифт текста в соответствии с ним.
   1. Установите шрифт в жирный.
   2. Установите шрифт в курсив.
1. Установите цвет шрифта с помощью [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) , предоставленного объектом [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
1. Запишите изменённую презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Реализация вышеуказанных шагов приведена ниже. Она берет неоформленную презентацию и форматирует шрифты на одном из слайдов.

```java
// Создайте объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Получение доступа к слайду по его позиции
    ISlide slide = pres.getSlides().get_Item(0);

    // Получение первого и второго заполнителей на слайде и приведение их к AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Доступ к первому абзацу
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Доступ к первой доле
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Определение новых шрифтов
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Назначение новых шрифтов для доли
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
Доля используется для хранения текста с похожим стилем форматирования в абзаце. Эта статья показывает, как использовать Aspose.Slides для Java, чтобы создать текстовое поле с некоторым текстом, а затем определить конкретный шрифт и различные другие свойства категории семейства шрифтов. Чтобы создать текстовое поле и установить свойства шрифта текста в нем:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) на слайд.
4. Удалите стиль заливки, связанный с [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. Получите доступ к TextFrame AutoShape.
6. Добавьте некоторый текст в TextFrame.
7. Получите объект Portion, связанный с [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
8. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. Установите другие свойства шрифта, такие как жирный, курсив, подчеркивание, цвет и высота, с помощью соответствующих свойств, предоставляемых объектом Portion.
10. Запишите измененную презентацию как PPTX файл.

Реализация вышеуказанных шагов представлена ниже.

```java
// Создайте Presentation
Presentation pres = new Presentation();
try {

    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавьте AutoShape типа Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Удалите любой стиль заливки, связанный с AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Получите доступ к TextFrame, связанной с AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Получите доступ к Portion, связанной с TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Установите шрифт для Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Установите свойство Bold шрифта
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Установите свойство Italic шрифта
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Установите свойство Underline шрифта
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Установите высоту шрифта
    port.getPortionFormat().setFontHeight(25);

    // Установите цвет шрифта
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Запишите PPTX на диск 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка размера шрифта для текста**

Aspose.Slides позволяет вам выбрать предпочитаемый размер шрифта для существующего текста в абзаце и другого текста, который может быть добавлен в абзац позже.

Этот Java-код показывает, как установить размер шрифта для текстов, содержащихся в абзаце:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Получает первую форму, например.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // Получает первый абзац, например.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // Устанавливает размер шрифта по умолчанию на 20 пт для всех текстовых долей в абзаце. 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Устанавливает размер шрифта на 20 пт для текущих текстовых долей в абзаце. 
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Вращение текста**

Aspose.Slides для Java позволяет разработчикам вращать текст. Текст может быть установлен как [Горизонтальный](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Вертикальный](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Вертикальный270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [ВертикальныйWordArt](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [ВосточноазиатскийВертикальный](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [МонголВертикальный](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) или [ВертикальныйWordArtСправоНалево](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Чтобы вращать текст любого TextFrame, пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Поворачивайте текст](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Сохраните файл на диск.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавьте AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Добавьте TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Получение текстовой рамки
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Создайте объект абзаца для текстовой рамки
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Создайте объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Быстрая коричневая лисица прыгает через ленивую собаку. Быстрая коричневая лисица прыгает через ленивую собаку.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Сохраните презентацию
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка угла вращения для TextFrame**
Aspose.Slides для Java теперь поддерживает установку произвольного угла вращения для текстовой рамки. В этой теме мы увидим с примером, как установить свойство RotationAngle в Aspose.Slides. Новые методы [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) и [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) были добавлены в интерфейсы [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) и [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat), которые позволяют устанавливать произвольный угол вращения для текстовой рамки. Чтобы установить RotationAngle, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. [Установите свойство RotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Запишите презентацию в файл PPTX.

В приведенном ниже примере мы устанавливаем свойство RotationAngle.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавьте AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Добавьте TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Получите доступ к текстовой рамке
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Создайте объект абзаца для текстовой рамки
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создайте объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Пример вращения текста.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Сохраните презентацию
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Межстрочный интервал абзаца**
Aspose.Slides предоставляет свойства под [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` и `SpaceWithin`—которые позволяют вам управлять межстрочным интервалом для абзаца. Три свойства используются следующим образом:

* Чтобы указать межстрочный интервал для абзаца в процентах, используйте положительное значение. 
* Чтобы указать межстрочный интервал для абзаца в пунктах, используйте отрицательное значение.

Например, вы можете применить межстрочный интервал 16 пунктов для абзаца, установив свойство `SpaceBefore` на -16.

Вот как вы можете указать межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с некоторым текстом в ней.
2. Получите ссылку на слайд через его индекс.
3. Получите доступ к TextFrame.
4. Получите доступ к Абзацу.
5. Установите свойства абзаца.
6. Сохраните презентацию.

Этот Java код показывает, как указать межстрочный интервал для абзаца:

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Получите ссылку на слайд по его индексу
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Получите доступ к TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Получите доступ к абзацу
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Установите свойства абзаца
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Сохраните презентацию
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка свойства AutofitType для TextFrame**
В этой теме мы исследуем различные свойства форматирования текстовой рамки. Эта статья охватывает, как установить свойство AutofitType для текстовой рамки, якорь текста и вращение текста в презентации. Aspose.Slides для Java позволяет разработчикам установить свойства AutofitType для любой текстовой рамки. AutofitType может быть установлен на [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) или [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). Если установлен на [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal), то фигура останется прежней, тогда как текст будет отрегулирован без изменения самой фигуры; тогда как, если AutofitType установлен на [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape), то фигура будет изменена так, что в ней будет содержаться только необходимый текст. Чтобы установить свойство AutofitType текстовой рамки, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)class.
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Установите AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) для текстовой рамки.
6. Сохраните файл на диск.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавьте AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Добавьте TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Получите доступ к текстовой рамке
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Создайте объект абзаца для текстовой рамки
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создайте объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Быстрая коричневая лисица прыгает через ленивую собаку. Быстрая коричневая лисица прыгает через ленивую собаку.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Сохраните презентацию
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка якоря TextFrame**
Aspose.Slides для Java позволяет разработчикам установить якорь для любой текстовой рамки. TextAnchorType указывает, где текст расположен в форме. AnchorType может быть установлен на [Верх](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Центр](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Низ](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [По ширине](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) или [Распределенный](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). Чтобы установить якорь для текстовой рамки, пожалуйста, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Установите TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) для текстовой рамки.
6. Сохраните файл на диск.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавьте AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Добавьте TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Получите доступ к текстовой рамке
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Создайте объект абзаца для текстовой рамки
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Создайте объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Быстрая коричневая лисица прыгает через ленивую собаку. Быстрая коричневая лисица прыгает через ленивую собаку.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Сохраните презентацию
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Табуляции и EffectiveTabs в презентации**
Все текстовые табуляции указаны в пикселях.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Рисунок: 2 явных табуляции и 2 табуляции по умолчанию**|
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно значению Tabs.Count.
- Коллекция EffectiveTabs включает все табуляции (из коллекции Tabs и табуляции по умолчанию).
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно значению Tabs.Count.
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между табуляциями по умолчанию (3 и 4 в нашем примере).
- Метод EffectiveTabs.GetTabByIndex(index), где index = 0, вернет первую явную табуляцию (Position = 731); index = 1 - вторую табуляцию (Position = 1241). Если вы попробуете получить следующую табуляцию с индексом = 2, будет возвращена первая табуляция по умолчанию (Position = 1470) и т. д.
- Метод EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, у вас есть текст: "Привет Мир!". Чтобы отобразить такой текст, вы должны знать, с какого места начать рисовать "мир!". Сначала вам нужно рассчитать длину "Привет" в пикселях и вызвать GetTabAfterPosition с этим значением. Вы получите следующую позицию табуляции для отображения "мира!".

## **Установка стиля текста по умолчанию**

Если вам нужно применить одно и то же форматирование текста по умолчанию ко всем текстовым элементам презентации сразу, вы можете использовать метод `getDefaultTextStyle` из интерфейса [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) и установить предпочитаемое форматирование. Пример кода ниже показывает, как установить жирный шрифт по умолчанию (14 пунктов) для текста на всех слайдах в новой презентации.

```java
Presentation presentation = new Presentation();
try {
    // Получите формат абзаца верхнего уровня.
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