---
title: Управление темами презентаций в Java
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/java/presentation-theme/
keywords:
- Тема PowerPoint
- Тема презентации
- Тема слайда
- Установить тему
- Изменить тему
- Управление темой
- Цвет темы
- Дополнительная палитра
- Шрифт темы
- Стиль темы
- Эффект темы
- PowerPoint
- OpenDocument
- Презентация
- Java
- Aspose.Slides
description: "Создавайте, настраивайте и конвертируйте файлы PowerPoint с единым брендингом, используя основные темы презентаций в Aspose.Slides для Java."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, осведомленные о теме, ссылаются на эти общие определения вместо хранения каждого визуального свойства как фиксированного значения, поэтому изменение темы может одновременно обновить множество объектов.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/masterthememanager/), а макет или отдельный слайд могут переопределять унаследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

В разделах ниже показаны самые распространённые рабочие процессы с темами: проверка темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Проверка темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/) раскрывает схему цветов темы, схему шрифтов и схему форматов через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/). Проверка этих коллекций перед их изменением особенно полезна, когда презентация поступает из внешнего источника, потому что количество и содержание элементов стиля могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линий и эффектов хранится в теме:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте мастер, связанный со слайдом, и используйте рабочий процесс эффективной темы, показанный далее в этой статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Объекты, осведомленные о теме, для заливок, линий и текста могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/schemecolor/). Когда вы изменяете соответствующий элемент в [IColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icolorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт форму, использующую `Accent4`, меняет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её заново и выводит эффективный цвет заливки:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Поскольку прямоугольник остаётся привязанным к `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в форме, последующие изменения `Accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides раскрывает эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** – Основные цвета темы.  
**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет к пяти из них преобразования яркости и сохраняет результат:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Эти варианты остаются основанными на цвете темы. Если позже `Accent4` изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Сопоставление значений `SchemeColor` слотам `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Соответствие фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные имена одних и тех же слотов темы; они не являются значениями, которые динамически преобразуются из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит набор основных шрифтов для заголовков и набор второстепенных шрифтов для основного текста. Методы [IFontScheme.getMajor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontscheme/) и [IFontScheme.getMinor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontscheme/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться в форматировании текста:

* `+mn-lt` – Основной шрифт латиницы (Minor Latin Font)
* `+mj-lt` – Шрифт заголовков латиницы (Major Latin Font)
* `+mn-ea` – Основной шрифт восточноазиатского текста (Minor East Asian Font)
* `+mj-ea` – Шрифт заголовков восточноазиатского текста (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую второстепенный латинский шрифт темы. Затем он меняет шрифты темы и сохраняет результат:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Заголовок следует основному шрифту, а основной текст – второстепенному шрифту. Текст, в котором указано явное имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и второстепенные коллекции шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Для проверки, добавления, замены или удаления этих сопоставлений см. [Script-Specific Theme Fonts](/slides/ru/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/java/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Существуют два распространённых рабочего процесса, и они решают разные задачи.

### **Сохранение исходной темы при перемещении слайдов**

Если нужно переместить слайд в другую презентацию и сохранить его оригинальный дизайн, склонируйте исходный мастер в целевую презентацию с помощью [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/), затем склонируйте слайд с помощью [ISlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidecollection/) и склонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Это предпочтительный рабочий процесс, когда исходный слайд должен выглядеть одинаково в месте назначения. Простое клонирование содержимого на несвязанный мастер назначения может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применение значений темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Это меняет тему, используемую этим слайдом, без изменения темы, унаследованной другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/).

### **Применение переопределения темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации могут быть использованы через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Используйте тему уровня мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета – когда одной группе макетов нужен иной стиль; и переопределение слайда – только для истинных исключений. Чрезмерные переопределения уровня слайда усложняют предсказание последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Заливки фона темы хранятся в [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/). PowerPoint может показывать в интерфейсе больше вариантов фона, чем фактически хранится в этой коллекции, потому что интерфейс может комбинировать заливки темы с её цветами и другими ссылками на стили.

![Галерея стилей фоновых изображений PowerPoint для темы презентации](presentation-design_8.png)

Прежде чем использовать стиль фона, проверьте хранящуюся коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/). Индекс стиля `0` означает отсутствие тематической заливки; положительные значения являются ссылками на стили фонового оформления темы. Это отличается от индексации самой Java‑коллекции, где `get_Item(0)` обозначает первый сохранённый элемент. Не предполагайте, что каждая презентация содержит одинаковое количество стилей фоновых заливок.

Следующий пример сообщает количество доступных фоновых заливок, назначает тематическую ссылку на фон первому мастеру и сохраняет презентацию:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Видимый результат зависит от темы, на которую ссылается мастер, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона мастера может не затронуть этот слайд. Используйте [Background.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/) когда требуется узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не рассматривайте индекс стиля как нулевой индекс коллекции. Также избегайте жёстко задавать номер стиля из одного файла, предполагая, что он будет выглядеть так же в другом файле; определения стилей темы специфичны для презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/java/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции стилей заливки, линий и эффектов, доступные через [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/) и [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/). Обычные темы Office часто включают три основных стиля, визуально соответствующих «нежному», «умеренному» и «интенсивному» форматированию, но код должен проверять каждую коллекцию, а не предполагать фиксированное количество.

![Неожные, умеренные и интенсивные эффекты темы, применённые к одной форме](presentation-design_10.png)

При доступе к этим коллекциям в Java индекс коллекции начинается с нуля: `get_Item(0)` – первый сохранённый стиль, `get_Item(2)` – третий. Индексы ссылок стиля формы – отдельная концепция, раскрытая через [IShapeStyle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapestyle/). Изменение стиля темы влияет на формы, которые ссылаются на этот стиль; формы с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие требуемых стилей, меняет первый стиль линии, меняет третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для форм, ссылающихся на эти слоты, первый стиль линии темы становится красным, третий стиль заливки темы становится сплошным тёмно‑зелёным, а третий стиль эффекта получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей каждая форма использует и переопределяется ли прямое форматирование.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или форма реально используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/).

Следующий пример считывает эффективную тему, фон и заливку первой формы со слайда:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Используйте эффективные данные для диагностики рендеринга, валидации и сравнения. Если проверять только [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), можно упустить переопределения мастера, макета, слайда или формы, изменяющие окончательный вид.

## **Часто задаваемые вопросы**

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidethememanager/) слайда и инициализируйте его переопределяющую тему. Изменение остаётся локальным для этого слайда; остальные слайды продолжают наследовать свои текущие темы.

**Какой способ является самым безопасным для переноса темы из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида склонируйте исходный мастер в целевую презентацию и склонируйте слайд с этим мастером, используя [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/) и [ISlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidecollection/). Это сохраняет вместе мастер, макеты и тему.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseoverridethememanager/) для темы слайда или макета и соответствующие методы получения эффективных данных для объектов формата, такие как [Background.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.