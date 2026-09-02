---
title: Управление темами презентаций в Java
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/java/presentation-theme/
keywords:
- тема PowerPoint
- тема презентации
- тема слайда
- установить тему
- изменить тему
- управлять темой
- внешняя тема
- THMX
- цвет темы
- дополнительная палитра
- шрифт темы
- стиль темы
- эффект темы
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Основные темы презентаций в Aspose.Slides для Java, позволяющие создавать, настраивать и конвертировать файлы PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, поддерживающие темы, ссылаются на эти общие определения, а не хранят каждый визуальный параметр как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Master может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/masterthememanager/), тогда как layout или отдельный слайд могут переопределять унаследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда разрешается по этой цепочке наследования: тема презентации, переопределение master, переопределение layout и переопределение слайда.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Ниже показаны наиболее распространённые сценарии работы с темами: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после применения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/) раскрывает цветовую схему темы, схему шрифтов и схему форматов через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/). Просмотр этих коллекций перед изменением особенно полезен, когда презентация поступает из внешнего источника, потому что количество и содержимое записей стилей могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линии и эффектов хранится в теме:

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

Если файл использует несколько master‑ов, не следует предполагать, что каждый слайд имеет одинаковую эффективную тему. Просмотрите master, связанный со слайдом, и используйте рабочий процесс эффективной темы, показанный далее в статье, когда могут присутствовать переопределения layout‑а или слайда.

## **Изменение цветов темы**

Заполнения, линии и текст, поддерживающие темы, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/schemecolor/). Когда вы изменяете соответствующую запись в [IColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icolorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт форму, использующую `Accent4`, изменяет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в форме, последующие изменения `Accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя цветовые преобразования. Aspose.Slides раскрывает эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Основные цвета темы.

**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет к пятим из них преобразования яркости и сохраняет результат:

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

Эти варианты остаются основанными на цветовом токене темы. Если `Accent4` изменится позже, преобразованные цвета пересчитаются из нового значения `Accent4`.

### **Сопоставление значений `SchemeColor` слотам `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, динамически преобразуемыми из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор для основного текста. Методы [IFontScheme.getMajor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontscheme/) и [IFontScheme.getMinor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontscheme/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться при форматировании текста:

* `+mn-lt` – Основной шрифт Latin (Minor Latin Font)
* `+mj-lt` – Шрифт заголовка Latin (Major Latin Font)
* `+mn-ea` – Основной шрифт East Asian (Minor East Asian Font)
* `+mj-ea` – Шрифт заголовка East Asian (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем меняет шрифты темы и сохраняет результат:

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

Заголовок следует основному шрифту, а основной текст – вспомогательному. Текст, у которого указано явное название шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов также могут содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/java/script-specific-font-mappings/).

{{% alert color="info" title="Подсказка" %}}
Для получения дополнительной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/java/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже приведены рабочие процессы, решающие различные задачи, связанные с темами.

### **Применение внешней темы к слайдам, зависящим от master‑а**

Используйте [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/) , когда у вас есть файл темы PowerPoint (`.thmx`) и нужно изменить стиль всех слайдов, зависящих от конкретного master‑а. Выберите master из коллекции [Presentation.getMasters](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), реализующей [IMasterSlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/), и передайте путь к файлу темы методу.

Метод выполняет следующие операции:

1. Создаёт новый master‑слайд на основе выбранного master‑а.  
2. Применяет внешнюю тему к новому master‑у.  
3. Присваивает новый master всем слайдам, которые ранее зависели от выбранного master‑а.  
4. Возвращает только что созданный [IMasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/).

Следующий пример применяет внешнюю тему к слайдам, зависящим от первого master‑а, и сохраняет презентацию:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Недействительная, повреждённая или неподдерживаемая тема может вызвать [PptxReadException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxreadexception/). Проверяйте пути, введённые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переопределяются только слайды, которые зависели от выбранного master‑а. Слайды, связанные с другими master‑ами, сохраняют свои текущие master‑ы и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, поддерживающие темы, разрешаются относительно внешней темы. Прямо назначенные цвета, шрифты, заливки и другие явные форматы могут оставаться без изменений. Переопределения на уровне layout‑а и слайда могут также иметь приоритет над значениями, унаследованными от нового master‑а.

Тема может ссылаться на шрифты, недоступные в среде выполнения. Для согласованного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/java/custom-font/), или настройте [font substitution](/slides/ru/java/font-substitution/).

Это прямой рабочий процесс уровня master: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или layout‑а.

### **Применение разных внешних тем в презентации с несколькими master‑ами**

Когда нужный master неизвестен заранее, получите его из представительного слайда через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/) и [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilayoutslide/). Сохраните исходные ссылки на master‑ы перед применением любых тем, так как каждый вызов создаёт новый master в презентации.

Следующий пример использует слайды из двух разделов, находя их master‑ы, и применяет различную внешнюю тему к каждой группе:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Первый вызов влияет только на слайды, зависимые от `firstGroupMaster`, а второй — только на слайды, зависимые от `secondGroupMaster`. Слайды, принадлежащие другим master‑ам, не изменяются.

### **Сохранение исходной темы при перемещении слайдов**

Если необходимо переместить слайд в другую презентацию и сохранить его оригинальный дизайн, клонируйте исходный master в целевую презентацию с помощью [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/), затем клонируйте слайд с помощью [ISlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidecollection/) и клонированного master‑а. Это переносит master, его layout‑ы и связанную тему вместе.

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

Это предпочтительный рабочий процесс, когда исходный слайд должен выглядеть одинаково в назначении. Простое копирование содержимого на несвязанный master‑о может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применение значений темы к существующему слайду**

Если целевой слайд должен оставаться на текущем master‑е и layout‑е, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

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

### **Применение переопределения темы к layout‑у**

Переопределение уровня layout‑а применяется к слайдам, использующим этот layout, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно вызвать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/layoutslidethememanager/):

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

Используйте тему уровня master‑а или презентации, когда многие layout‑ы и слайды должны делить один базовый дизайн; переопределение layout‑а — когда одной семье layout‑ов нужен иной стиль; и переопределение слайда — только для истинных исключений. Чрезмерное количество переопределений на уровне слайда затрудняет предсказание последствий глобальных изменений темы.

## **Обновление стилей фона темы**

Фоновые заливки темы хранятся в [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/). PowerPoint может предлагать в пользовательском интерфейсе больше вариантов фона, чем количество фактически хранимых определений заливки в этой коллекции, поскольку UI может комбинировать заливки темы с цветовыми токенами и другими ссылками стилей.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Перед использованием фонового стиля просмотрите хранимую коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/). Индекс стиля `0` означает отсутствие тематической заливки; положительные значения — ссылки на стили фона темы. Это отличается от индексации самой Java‑коллекции, где `get_Item(0)` обозначает первый элемент. Не предполагаете, что у каждой презентации одинаковое количество фоновых стилей заливки.

Следующий пример выводит количество доступных фоновых заливок, назначает тематическую фоновую ссылку первому master‑у и сохраняет презентацию:

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

Видимый результат зависит от записи темы, на которую ссылается master, а также от любых переопределений фона на уровне layout‑а или слайда. Если слайд использует собственный фон, изменение только фона master‑а может не затронуть этот слайд. Используйте [Background.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/), когда нужно узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Предупреждение" %}}
Не рассматривайте индекс стиля как нулевой индекс коллекции. Также избегайте жёсткой кодировки номера стиля из одного файла и предположения, что он будет выглядеть так же в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Подсказка" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/java/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции заливок, линий и эффектов, раскрытые через [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/) и [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/). Типичные офисные темы часто включают три основных стиля, визуально соответствующие «тихим», «умеренным» и «интенсивным» форматам, но код должен проверять каждую коллекцию, а не полагаться на фиксированное количество.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

При доступе к этим коллекциям в Java индекс коллекции начинается с нуля: `get_Item(0)` – первая сохранённая запись, `get_Item(2)` – третья. Индексы ссылок стилей формы – отдельная концепция, раскрытая через [IShapeStyle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapestyle/). Изменение стиля темы затрагивает формы, которые ссылаются на этот стиль; формы с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, изменяет первый стиль линии, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

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

Для форм, ссылающихся на эти слоты, первый стиль линии темы становится красным, третий стиль заливки темы – сплошным темно‑зелёным, а третий стиль эффекта получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей каждая форма использует и переопределяется ли прямое форматирование.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или форма действительно используют после применения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/).

Следующий пример считывает эффективную тему, фон и первую заливку формы со слайда:

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнения. Если вы проверяете только [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), можно пропустить переопределения master‑а, layout‑а, слайда или формы, меняющие окончательный вид.

## **FAQ**

**Применяет ли внешняя тема тему ко всем слайдам презентации?**

Нет. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/) переназначает только слайды, зависящие от выбранного master‑а. Слайды, использующие другие master‑ы, сохраняют свои текущие темы.

**Можно ли применить тему к одному слайду, не меняя master?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidethememanager/) слайда и инициализируйте его переопределённую тему. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой способ самый безопасный для переноса темы из одной презентации в другую?**

При перемещении слайда и сохранении его исходного вида клонируйте исходный master в целевую презентацию, а затем клонируйте сам слайд с этим master‑ом, используя [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/) и [ISlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidecollection/). Это сохраняет master, layout‑ы и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseoverridethememanager/) для темы слайда или layout‑а и соответствующие методы получения эффективных данных для объектов формата, такие как [Background.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.