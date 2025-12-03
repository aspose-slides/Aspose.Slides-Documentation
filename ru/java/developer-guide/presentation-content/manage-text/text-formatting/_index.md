---
title: Форматирование текста PowerPoint в Java
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/java/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- интервал между символами
- свойства шрифта
- семейство шрифтов
- поворот текста
- угол поворота
- текстовый фрейм
- межстрочный интервал
- свойство автоподгонки
- якорь текстового фрейма
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Java. Настройка шрифтов, цветов, выравнивания и других параметров."
---

## **Выделить текст**
Метод [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Он позволяет выделять часть текста фоном, используя образец текста, аналогично инструменту Выделение цветом текста в PowerPoint 2019.

Ниже приведён фрагмент кода, показывающий, как использовать эту функцию:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // выделение всех слов 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// выделение всех отдельных вхождений 'the' occurrences
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Aspose предоставляет простой, [бесплатный онлайн‑сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Выделение текста с помощью регулярного выражения**
Метод [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Он позволяет выделять часть текста фоном, используя регулярное выражение, аналогично инструменту Выделение цветом текста в PowerPoint 2019.

Ниже приведён фрагмент кода, показывающий, как использовать эту функцию:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // выделение всех слов, содержащих 10 и более символов
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка цвета фона текста**
Aspose.Slides позволяет задать предпочтительный цвет фона текста.

Этот Java‑код показывает, как установить цвет фона для всего текста:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
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


Этот Java‑код показывает, как установить цвет фона только для части текста:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
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
            .filter(p -> p.getText().contains("Red"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Выравнивание абзацев текста**
Форматирование текста — один из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides for Java поддерживает добавление текста на слайды, но в этой теме мы рассмотрим, как управлять выравниванием абзацев текста на слайде. Пожалуйста, выполните следующие шаги для выравнивания абзацев текста с помощью Aspose.Slides for Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Доступ к фигурам‑заполнителям на слайде и приведение их к типу [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. Получите абзац (который необходимо выровнять) из [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) объекта [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Выравнивайте абзац. Абзац можно выровнять по правому, левому, центру или по ширине.
6. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.
```java
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);

    // Получение первого и второго заполнителя на слайде и приведение к типу AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Изменение текста в обоих заполнителях
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // Получение первого абзаца заполнителей
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Выравнивание абзаца текста по центру
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //Запись презентации в файл PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка прозрачности для текста**
В этой статье продемонстрировано, как установить свойство прозрачности для любой текстовой фигуры с помощью Aspose.Slides for Java. Чтобы задать прозрачность текста, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Сохраните презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // установить прозрачность в ноль процентов
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка интервала между символами текста**
Aspose.Slides позволяет задавать интервал между буквами в текстовом поле. Таким образом вы можете регулировать визуальную плотность строки или блока текста, расширяя или сужая расстояние между символами.

Этот Java‑код показывает, как увеличить интервал для одной строки текста и уменьшить его для другой строки:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // расширить
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // уплотнить

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **Управление свойствами шрифта абзаца**
Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различными способами — для выделения определённых разделов и слов или в соответствии с корпоративными стилями. Форматирование текста помогает пользователям изменять внешний вид содержимого презентации. Эта статья показывает, как с помощью Aspose.Slides for Java настроить свойства шрифта абзацев текста на слайдах. Чтобы управлять свойствами шрифта абзаца с помощью Aspose.Slides for Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к фигурам‑заполнителям на слайде и приведение их к типу [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Получите объект [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) из [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame), предоставляемого [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Выравнивайте абзац по ширине.
1. Доступ к части текста абзаца.
1. Определите шрифт с помощью FontData и установите шрифт части текста соответственно.
   1. Сделайте шрифт полужирным.
   1. Сделайте шрифт курсивом.
1. Установите цвет шрифта, используя метод [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) объекта [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
1. Сохраните изменённую презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Реализация вышеуказанных шагов приведена ниже. Она берёт незакрашенную презентацию и форматирует шрифты на одном из слайдов.
```java
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Получение слайда по его порядковому номеру
    ISlide slide = pres.getSlides().get_Item(0);

    // Получение первого и второго заполнителя на слайде и приведение к типу AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Получение первого абзаца
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Получение первой части текста
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Определение новых шрифтов
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Назначение новых шрифтов части текста
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Установка шрифта полужирным
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Установка шрифта курсивом
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Установка цвета шрифта
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Записать PPTX на диск
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление семейством шрифтов текста**
Часть (Portion) используется для хранения текста с одинаковым стилем в абзаце. Эта статья показывает, как с помощью Aspose.Slides for Java создать текстовое поле, добавить в него текст и задать определённый шрифт, а также различные свойства семейства шрифтов. Чтобы создать текстовое поле и задать свойства шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle).
4. Удалите стиль заливки, связанный с [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. Доступ к TextFrame автофигуры.
6. Добавьте немного текста в TextFrame.
7. Доступ к объекту Portion, связанному с [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
8. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. Установите другие свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства объекта Portion.
10. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.
```java
// Создать объект Presentation
Presentation pres = new Presentation();
try {

    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Удалить любой стиль заливки, связанный с AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Получить TextFrame, связанный с AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Получить Portion, связанный с TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Установить шрифт для Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Установить свойство Bold для шрифта
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Установить свойство Italic для шрифта
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Установить свойство Underline для шрифта
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Установить высоту шрифта
    port.getPortionFormat().setFontHeight(25);

    // Установить цвет шрифта
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Записать PPTX на диск 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка размера шрифта текста**
Aspose.Slides позволяет выбрать предпочтительный размер шрифта для существующего текста в абзаце и для текста, который может быть добавлен в абзац позже.

Этот Java‑код показывает, как задать размер шрифта для текста, содержащегося в абзаце:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Получаем первую форму, например.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // Получаем первый абзац, например.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // Устанавливает размер шрифта по умолчанию 20 pt для всех текстовых частей в абзаце. 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Устанавливает размер шрифта 20 pt для текущих текстовых частей в абзаце. 
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Поворот текста**
Aspose.Slides for Java позволяет разработчикам вращать текст. Текст может отображаться как [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) или [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Чтобы повернуть текст любого TextFrame, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Поверните текст](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Сохраните файл на диск.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Доступ к текстовому фрейму
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Создать объект Paragraph для текстового фрейма
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Создать объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Сохранить презентацию
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка пользовательского угла поворота для TextFrame**
Aspose.Slides for Java теперь поддерживает задание пользовательского угла поворота для TextFrame. В этой теме мы рассмотрим пример, как установить свойство RotationAngle в Aspose.Slides. Были добавлены новые методы [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) и [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) в интерфейсы [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) и [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat), позволяющие задавать пользовательский угол поворота для TextFrame. Чтобы установить RotationAngle, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. [Установите свойство RotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Сохраните презентацию в файл PPTX.

В примере ниже показано, как установить свойство RotationAngle.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Получить доступ к текстовому фрейму
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Создать объект Paragraph для текстового фрейма
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создать объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Сохранить презентацию
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Межстрочный интервал абзаца**
Aspose.Slides предоставляет свойства в [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat) — `SpaceAfter`, `SpaceBefore` и `SpaceWithin` — позволяющие управлять межстрочным интервалом абзаца. Свойства используются следующим образом:

* Чтобы задать межстрочный интервал в процентах, используйте положительное значение. 
* Чтобы задать межстрочный интервал в пунктах, используйте отрицательное значение.

Например, можно задать межстрочный интервал 16 pt для абзаца, установив свойство `SpaceBefore` в -16.

Как задать межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с текстом.
2. Получите ссылку на слайд через его индекс.
3. Доступ к TextFrame.
4. Доступ к Paragraph.
5. Установите свойства абзаца.
6. Сохраните презентацию.

Этот Java‑код показывает, как задать межстрочный интервал для абзаца:
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Получить ссылку на слайд по его индексу
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Доступ к TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Доступ к Paragraph
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Установить свойства Paragraph
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Сохранить презентацию
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка свойства AutofitType для TextFrame**
В этой теме мы рассмотрим различные свойства форматирования текстового фрейма. Статья охватывает, как установить свойство AutofitType текстового фрейма, привязку текста и вращение текста в презентации. Aspose.Slides for Java позволяет разработчикам задавать свойство AutofitType любого текстового фрейма. AutofitType может быть установлен в [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) или [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). Если установлено значение [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal), форма остаётся прежней, а текст подгоняется без изменения формы; если AutofitType установлен в [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape), форма изменяется так, чтобы в неё помещался только необходимый текст. Чтобы установить свойство AutofitType текстового фрейма, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Установите свойство AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) для TextFrame.
6. Сохраните файл на диск.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Доступ к текстовому фрейму
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Создать объект Paragraph для текстового фрейма
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создать объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Сохранить презентацию
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка привязки (Anchor) TextFrame**
Aspose.Slides for Java позволяет разработчикам задавать привязку любого TextFrame. TextAnchorType определяет, где размещён текст внутри фигуры. AnchorType может быть установлен в [Top](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) или [Distributed](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). Чтобы установить привязку любого TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Установите TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) для TextFrame.
6. Сохраните файл на диск.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Доступ к текстовому фрейму
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Создать объект Paragraph для текстового фрейма
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Создать объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Сохранить презентацию
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Табы и EffectiveTabs в презентации**
Все табуляции текста задаются в пикселях.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Рисунок: 2 явных таба и 2 таба по умолчанию**|

- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.
- Коллекция EffectiveTabs включает все табуляции (из коллекции Tabs и табуляции по умолчанию).
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между табуляциями по умолчанию (3 и 4 в нашем примере).
- EffectiveTabs.GetTabByIndex(index) с index = 0 вернёт первый явный таб (Position = 731), index = 1 – второй таб (Position = 1241). При запросе index = 2 будет возвращён первый таб по умолчанию (Position = 1470) и т.д.
- EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, имеется текст: "Hello World!". Чтобы отрисовать такой текст, необходимо знать, с какого места начать рисовать "world!". Сначала вычислите длину "Hello" в пикселях и вызовите GetTabAfterPosition с этим значением. Вы получите позицию следующего таба для рисования "world!".

## **Установка стиля текста по умолчанию**
Если требуется применить одинаковое форматирование текста ко всем элементам презентации одновременно, используйте метод `getDefaultTextStyle` интерфейса [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) и задайте предпочтительное форматирование. Ниже показан пример кода, задающего полужирный шрифт размером 14 pt для текста на всех слайдах новой презентации.
```java
Presentation presentation = new Presentation();
try {
    // Получить формат абзаца верхнего уровня.
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


## **Извлечение текста с эффектом All‑Caps**
В PowerPoint применение эффекта **All Caps** делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст в оригинальном виде. Чтобы корректно обработать его, проверьте [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) — если он указан как `All`, просто преобразуйте полученную строку в верхний регистр, чтобы ваш вывод соответствовал тому, что видят пользователи на слайде.

Допустим, в файле sample2.pptx на первом слайде находится следующий текстовый блок.

![The All Caps effect](all_caps_effect.png)

Ниже приведён пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:
```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    IPortion textPortion = paragraph.getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```


Вывод:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Как изменить текст в таблице на слайде?**

Для изменения текста в таблице используйте интерфейс [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Можно пройтись по всем ячейкам таблицы и изменить текст в каждой ячейке, получив её `TextFrame` и свойства `ParagraphFormat`.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте метод `getFillFormat` в [BasePortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/). Установите `FillFormat` в `Gradient`, задав начальный и конечный цвета градиента, а также дополнительные параметры, такие как направление и прозрачность, для создания градиентного эффекта текста.