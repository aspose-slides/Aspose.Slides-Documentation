---
title: "Форматировать текст PowerPoint на Android"
linktitle: "Форматирование текста"
type: docs
weight: 50
url: /ru/androidjava/text-formatting/
keywords:
- "выделение текста"
- "регулярное выражение"
- "выравнивание абзаца"
- "стиль текста"
- "фон текста"
- "прозрачность текста"
- "межсимвольный интервал"
- "свойства шрифта"
- "семейство шрифтов"
- "вращение текста"
- "угол вращения"
- "текстовый кадр"
- "межстрочный интервал"
- "свойство автоподгонки"
- "якорь текстового кадра"
- "табуляция текста"
- "язык по умолчанию"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---

## **Выделение текста**
Метод [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

Он позволяет выделять часть текста фоновым цветом, используя образец текста, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже показан пример кода, демонстрирующий использование этой функции:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // выделение всех слов 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// выделение всех отдельных вхождений 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Aspose предоставляет простой, [бесплатный онлайн‑сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Выделение текста с помощью регулярного выражения**
Метод [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame).

Он позволяет выделять часть текста фоновым цветом, используя регулярное выражение, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже показан пример кода, демонстрирующий использование этой функции:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // выделение всех слов длиной 10 и более символов
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить цвет фона текста**
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
Форматирование текста — один из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides for Android via Java поддерживает добавление текста на слайды, но в этой теме мы рассмотрим, как управлять выравниванием абзацев текста на слайде. Пожалуйста, выполните следующие шаги для выравнивания абзацев текста с использованием Aspose.Slides for Android via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Доступ к Placeholder‑формам на слайде и приведение их к типу [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
4. Получите абзац (который требуется выравнять) из [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) объекта [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Выравняйте абзац. Абзац может быть выровнен по правому, левому, центральному и выровненному по ширине краю.
6. Сохраните изменённую презентацию в файл PPTX.

Реализация перечисленных шагов приведена ниже.
```java
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);

    // Получение первого и второго заполнителя на слайде и приведение его к типу AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Изменение текста в обоих заполнителях
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // Получение первого абзаца из заполнителей
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Выровнять абзац текста по центру
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //Запись презентации в файл PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить прозрачность текста**
В этой статье демонстрируется, как установить свойство прозрачности любой текстовой фигуры с помощью Aspose.Slides for Android via Java. Для установки прозрачности текста выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Сохраните презентацию в файл PPTX.

Реализация перечисленных шагов приведена ниже.
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


## **Установить межбуквенный интервал для текста**
Aspose.Slides позволяет задать интервал между буквами в текстовом поле. Таким образом, вы можете отрегулировать визуальную плотность строки или блока текста, увеличивая или уменьшая интервал между символами.

Этот Java‑код показывает, как расширить интервал для одной строки текста и сжать интервал для другой строки:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // расширить
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // сжать

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **Управление свойствами шрифта абзаца**
Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различными способами — для выделения определённых разделов и слов или в соответствии с корпоративными стилями. Форматирование текста помогает пользователям варьировать внешний вид содержимого презентации. Эта статья показывает, как с помощью Aspose.Slides for Android via Java настроить свойства шрифта абзацев текста на слайдах.

Для управления свойствами шрифта абзаца выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Доступ к Placeholder‑формам на слайде и приведение их к типу [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
4. Получите объект [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) из [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame), предоставляемого [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. Выровняйте абзац.
6. Доступ к Portion текста абзаца.
7. Определите шрифт с помощью FontData и установите шрифт Portion соответственно.
   1. Установите шрифт полужирным.
   2. Установите шрифт курсивом.
8. Установите цвет шрифта с помощью метода [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) объекта [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
9. Сохраните изменённую презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Реализация перечисленных шагов приведена ниже. Она берёт простую презентацию и форматирует шрифты на одном из слайдов.
```java
// Создать объект Presentation, представляющий файл PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Получаем слайд по его позиции
    ISlide slide = pres.getSlides().get_Item(0);

    // Получаем первый и второй заполнитель на слайде и преобразуем их к AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Получаем первый абзац
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Получаем первую часть
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Определяем новые шрифты
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Назначаем новые шрифты части
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Устанавливаем полужирный шрифт
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Устанавливаем курсив
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Устанавливаем цвет шрифта
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    //Записываем PPTX на диск
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление семейством шрифтов текста**
Portion используется для хранения текста с одинаковым стилем форматирования в абзаце. Эта статья показывает, как с помощью Aspose.Slides for Android via Java создать текстовое поле с текстом, а затем задать определённый шрифт и различные свойства семейства шрифтов. Для создания текстового поля и задания свойств шрифта выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте на слайд объект [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle).
4. Удалите стиль заливки, связанный с [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. Доступ к TextFrame AutoShape.
6. Добавьте некоторый текст в TextFrame.
7. Доступ к объекту Portion, связанному с [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
8. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion).
9. Установите дополнительные свойства шрифта, такие как полужирный, курсив, подчёркнутый, цвет и высота, используя соответствующие свойства Portion.
10. Сохраните изменённую презентацию в файл PPTX.

Реализация перечисленных шагов приведена ниже.
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


## **Установить размер шрифта для текста**
Aspose.Slides позволяет выбрать предпочтительный размер шрифта для существующего текста в абзаце и для текста, который может быть добавлен позже.

Этот Java‑код показывает, как установить размер шрифта для текста, содержащегося в абзаце:
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

        // Устанавливает размер шрифта по умолчанию 20 пунктов для всех текстовых частей в абзаце. 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Устанавливает размер шрифта 20 пунктов для текущих текстовых частей в абзаце. 
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Установить вращение текста**
Aspose.Slides for Android via Java позволяет разработчикам вращать текст. Текст может быть установлен в виде [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) или [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Чтобы вращать текст любого TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Доступ к объекту [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Rotate the text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Сохраните файл на диск.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Добавить TextFrame к Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Доступ к текстовому кадру
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Создать объект Paragraph для текстового кадра
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


## **Установить пользовательский угол вращения для TextFrame**
Aspose.Slides for Android via Java теперь поддерживает установку пользовательского угла вращения для TextFrame. В этой теме показан пример, как задать свойство RotationAngle в Aspose.Slides. В интерфейсы [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) и [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) добавлены новые методы [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) и [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--), позволяющие задавать пользовательский угол вращения для TextFrame. Чтобы установить RotationAngle, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. [Set RotationAngle property](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Сохраните презентацию в файл PPTX.

В примере ниже показано, как задать свойство RotationAngle.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Добавить TextFrame к Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Доступ к текстовому кадру
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Создать объект Paragraph для текстового кадра
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
Aspose.Slides предоставляет свойства в [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` и `SpaceWithin`—которые позволяют управлять межстрочным интервалом абзаца. Свойства используются следующим образом:

* Чтобы задать межстрочный интервал в процентах, укажите положительное значение. 
* Чтобы задать межстрочный интервал в пунктах, укажите отрицательное значение.

Например, можно применить интервал 16 pt, установив свойство `SpaceBefore` в -16.

Как задать межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с некоторым текстом.
2. Получите ссылку на слайд по его индексу.
3. Доступ к TextFrame.
4. Доступ к Paragraph.
5. Установите свойства Paragraph.
6. Сохраните презентацию.

Этот Java‑код показывает, как задать межстрочный интервал для абзаца:
```java
// Create an instance of Presentation class
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Obtain a slide's reference by its index
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Access the TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Access the Paragraph
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Set properties of Paragraph
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Save Presentation
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить свойство AutofitType для TextFrame**
В этой статье рассматриваются различные свойства форматирования TextFrame. Описывается, как установить свойство AutofitType TextFrame, привязку текста и вращение текста в презентации. Aspose.Slides for Android via Java позволяет установить свойство AutofitType любого TextFrame. AutofitType может быть установлен в [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) или [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape). При значении [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) форма остаётся неизменной, а текст подгоняется, не изменяя форму. При значении [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) форма изменяется так, чтобы в неё помещался только необходимый текст. Чтобы установить свойство AutofitType TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Доступ к объекту [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) TextFrame.
6. Сохраните файл на диск.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Добавить TextFrame к Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Доступ к текстовому кадру
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Создать объект Paragraph для текстового кадра
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


## **Установить привязку TextFrame**
Aspose.Slides for Android via Java позволяет установить привязку любого TextFrame. TextAnchorType определяет, где текст размещён внутри формы. Привязка может быть установлена в [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) или [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed). Чтобы установить привязку TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Доступ к объекту [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) TextFrame.
6. Сохраните файл на диск.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Добавить TextFrame к Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Доступ к текстовому кадру
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Создать объект Paragraph для текстового кадра
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


## **Табуляции и EffectiveTabs в презентации**
Все табуляции текста заданы в пикселях.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|
- Свойство EffectiveTabs.ExplicitTabCount (в нашем случае 2) равно количеству элементов в Tabs.
- Коллекция EffectiveTabs включает все табуляции (из коллекции Tabs и табуляции по умолчанию).
- EffectiveTabs.ExplicitTabCount (в нашем случае 2) равно количеству элементов в Tabs.
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между табуляциями по умолчанию (3 и 4 в нашем примере).
- EffectiveTabs.GetTabByIndex(index) с index = 0 вернёт первую явную табуляцию (Position = 731), index = 1 — вторую (Position = 1241). При запросе index = 2 будет возвращена первая табуляция по умолчанию (Position = 1470) и т.д.
- EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, у вас есть текст: “Hello World!”. Чтобы отрисовать такой текст, необходимо знать, где начинается слово “world!”. Сначала вычислите длину слова “Hello” в пикселях и вызовите GetTabAfterPosition с этим значением. Вы получите позицию следующей табуляции для отрисовки “world!”.

## **Установить стиль текста по умолчанию**
Если необходимо сразу применить одинаковое форматирование текста ко всем элементам презентации, используйте метод `getDefaultTextStyle` интерфейса [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) и задайте нужные параметры. Пример кода ниже показывает, как установить полужирный шрифт (14 pt) по умолчанию для текста на всех слайдах новой презентации.
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


## **Извлечение текста с эффектом All Caps**
В PowerPoint применение эффекта **All Caps** делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такой части текста через Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы корректно отобразить его, проверьте [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) — если он равен `All`, просто преобразуйте полученную строку к верхнему регистру, чтобы вывод соответствовал тому, что видит пользователь на слайде.

Допустим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:
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

Для изменения текста в таблице на слайде используйте интерфейс [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Можно пройтись по всем ячейкам таблицы и изменить текст в каждой ячейке, получив её `TextFrame` и свойства `ParagraphFormat`.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте метод `getFillFormat` объекта [BasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/). Установите `FillFormat` в `Gradient`, задав начальный и конечный цвета градиента, а также дополнительные параметры, такие как направление и прозрачность, чтобы создать градиентный эффект для текста.