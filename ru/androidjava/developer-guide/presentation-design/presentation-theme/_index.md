---
title: Управление темами презентаций на Android
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/androidjava/presentation-theme/
keywords:
- Тема PowerPoint
- Тема презентации
- Тема слайда
- Установить тему
- Изменить тему
- Управлять темой
- Внешняя тема
- THMX
- Цвет темы
- Дополнительная палитра
- Шрифт темы
- Стиль темы
- Эффект темы
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте темами презентаций в Aspose.Slides для Android на Java, создавайте, настраивайте и конвертируйте файлы PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, поддерживающие тему, ссылаются на эти общие определения, а не хранят каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить многие объекты одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Master может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/masterthememanager/), а layout или отдельный слайд могут переопределять унаследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseoverridethememanager/). На практике эффективная тема слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение layout и переопределение слайда.

![Элементы темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже показаны самые распространённые варианты работы с темой: проверка темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Проверка темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mastertheme/) предоставляет доступ к цветовой схеме темы, схемe шрифтов и схеме формата через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mastertheme/). Проверка этих коллекций перед их изменением особенно полезна, когда презентация поступает из внешнего источника, поскольку количество и содержание элементов стилей могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линий и эффектов хранится в теме:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

Если файл использует несколько мастеров, не следует полагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте мастер, связанный со слайдом, и используйте workflow эффективной темы, показанный позже в этой статье, когда могут присутствовать переопределения layout или слайда.

## **Изменение цветов темы**

Заполняющие элементы, линии и текст, поддерживающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/schemecolor/). Когда вы изменяете соответствующий элемент в [IColorScheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icolorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `Accent4`, меняет цвет `Accent4` темы на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет станет красным после изменения темы. Если заменить цвет схемы на прямой цвет фигуры, последующие изменения `Accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя трансформации цвета. Aspose.Slides предоставляет эти трансформации через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** – Основные цвета темы.  
**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет к пяти из них трансформации яркости и сохраняет результат:

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

Эти варианты остаются основанными на цветовом схеме темы. Если `Accent4` позже изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в слоты `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, которые динамически преобразуются из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит набор основных шрифтов для заголовков и набор вспомогательных шрифтов для основного текста. Методы [IFontScheme.getMajor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontscheme/) и [IFontScheme.getMinor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontscheme/) предоставляют доступ к этим наборам.

Идентификаторы шрифтов темы, совместимые с PowerPoint, можно использовать в форматировании текста:

* `+mn-lt` – Основной шрифт латиницы (Minor Latin Font)
* `+mj-lt` – Шрифт заголовков латиницы (Major Latin Font)
* `+mn-ea` – Основной шрифт восточноазиатского текста (Minor East Asian Font)
* `+mj-ea` – Шрифт заголовков восточноазиатского текста (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем изменяет шрифты темы и сохраняет результат:

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

Заголовок следует основному шрифту, а основной текст – вспомогательному. Текст, у которого явно указано имя шрифта вместо идентификатора темы, не переключится автоматически при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов также могут содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Подсказка" %}}
Для получения дополнительной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже приведены варианты решения разных проблем, связанных с темами.

### **Применить внешнюю тему к слайдам, зависящим от мастера**

Используйте [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/) когда у вас есть файл темы PowerPoint (`.thmx`) и нужно изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation.getMasters](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/), реализующей [IMasterSlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslidecollection/), и передайте путь к файлу темы в метод.

Метод выполняет следующие операции:

1. Создаёт новый слайд‑мастер на основе выбранного мастера.  
1. Применяет внешнюю тему к новому мастеру.  
1. Назначает новый мастер всем слайдам, которые ранее зависели от выбранного мастера.  
1. Возвращает только что созданный [IMasterSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/).

Следующий пример применяет внешнюю тему к слайдам, зависящим от первого мастера, и сохраняет презентацию:

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

Недопустимая, повреждённая или неподдерживаемая тема может вызвать [PptxReadException](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pptxreadexception/). Проверяйте пути, вводимые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переименовываются только слайды, зависившие от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастеры и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, которые зависят от темы, разрешаются в соответствии с внешней темой. Прямо назначенные цвета, шрифты, заливки и другие явные форматы могут остаться без изменений. Переопределения на уровне layout и слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, недоступные в среде выполнения. Для корректного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/androidjava/custom-font/), либо настройте [font substitution](/slides/ru/androidjava/font-substitution/).

Это прямой workflow уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или layout.

### **Применить разные внешние темы в презентации с несколькими мастерами**

Если нужный мастер неизвестен заранее, получите его из репрезентативного слайда через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/) и [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslide/). Сохраните ссылки на оригинальные мастера перед применением тем, потому что каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух секций, определяет их мастера и применяет различную внешнюю тему к каждой группе:

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

Первый вызов влияет только на слайды, зависящие от `firstGroupMaster`, а второй – только на слайды, зависящие от `secondGroupMaster`. Слайды, принадлежащие другим мастерам, не переоформляются.

### **Сохранить исходную тему при перемещении слайдов**

Если нужно переместить слайд в другую презентацию, сохранив его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslidecollection/), затем клонируйте слайд с помощью [ISlideCollection.addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidecollection/) и клонированного мастера. Это перенесёт мастер, его layout‑ы и связанную тему вместе.

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

Это предпочтительный workflow, когда исходный слайд должен выглядеть одинаково в целевом файле. Простое клонирование содержимого на несвязанный мастер получателя может изменить цвета, шрифты, фоны и эффекты, задаваемые темой.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и layout, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Это меняет тему, используемую этим слайдом, без изменения темы, унаследованной другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/overridetheme/).

### **Применить переопределение темы к layout**

Переопределение уровня layout применяется к слайдам, использующим этот layout, если только у конкретного слайда нет собственного переопределения. Те же методы инициализации можно использовать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Используйте тему мастера или презентации, когда многие layout‑ы и слайды должны делить один базовый дизайн; переопределение layout, когда одна семья layout‑ов нуждается в отдельном стиле; и переопределение слайда только для истинных исключений. Чрезмерные переопределения уровня слайда усложняют предсказуемость глобальных изменений темы.

## **Обновление стилей фона темы**

Заполнения фона темы хранятся в [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iformatscheme/). PowerPoint может предлагать больше вариантов фона в пользовательском интерфейсе, чем количество фактически сохранённых определений заливок в этой коллекции, потому что UI может комбинировать заливки темы с цветовыми схемами и другими ссылками стилей.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием стиля фона проверьте хранимую коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/background/). Индекс стиля `0` означает отсутствие тематической заливки; положительные значения – ссылки на стили фона темы. Это отличается от индексации самой Java‑коллекции, где `get_Item(0)` обозначает первый элемент. Не предполагайте, что у каждой презентации одинаковое число стилей фона.

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

Видимый результат зависит от темы, на которую ссылается мастер, и от любых переопределений фона на уровне layout или слайда. Если слайд использует собственный фон, изменение только фона мастера может не повлиять на этот слайд. Используйте [Background.getEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/background/), когда необходимо узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Предупреждение" %}}
Не воспринимайте индекс стиля как нулевой индекс коллекции. Также избегайте жёстко задавать номер стиля из одного файла, полагая, что он будет выглядеть одинаково в другом файле; определения стилей темы специфичны для каждой презентации.
{{% /alert %}}

{{% alert color="info" title="Подсказка" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/androidjava/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции заливок, линий и эффектов, доступные через [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iformatscheme/) и [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iformatscheme/). Типичные офисные темы часто включают три основных стиля, визуально соответствующие «тонким», «средним» и «интенсивным» форматированиям, но код должен проверять каждую коллекцию, а не предполагать фиксированное количество.

![Тонкие, средние и интенсивные эффекты темы, применённые к одной и той же фигуре](presentation-design_10.png)

При доступе к этим коллекциям в Java индекс коллекции начинается с нуля: `get_Item(0)` – первая сохранённая стилистика, `get_Item(2)` – третья. Индексы ссылок стилей у фигур – отдельная концепция, доступная через [IShapeStyle](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapestyle/). Изменение стильовой темы влияет на фигуры, которые ссылаются на этот стиль; фигуры с прямым форматированием могут остаться неизменными.

Следующий пример проверяет наличие требуемых стилей, меняет первый стиль линии, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для фигур, ссылающихся на эти слоты, первый стиль линии темы станет красным, третий стиль заливки темы – сплошным темно‑зелёным, а третий стиль эффекта получит внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей использует каждая фигура, и от того, переопределяется ли тема прямым форматированием.

![Стили эффектов темы после изменения линий, заливок и настроек теней](presentation-design_11.png)

## **Чтение эффективных значений темы**

«Сырые» объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/background/), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/).

Следующий пример читает эффективную тему, фон и первую заливку фигуры со слайда:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Используйте эффективные данные для диагностики рендеринга, валидации и сравнений. Если проверять только [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/), можно упустить переопределения мастера, layout, слайда или фигуры, меняющие окончательный внешний вид.

## **FAQ**

**Применяет ли внешняя тема каждый слайд в презентации?**

Нет. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslide/) переназначает только те слайды, которые зависят от выбранного мастера. Слайды, использующие другие мастеры, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slidethememanager/) слайда и инициализируйте его переопределённую тему. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой способ самый безопасный для переноса темы из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида клонируйте исходный мастер в целевую презентацию, а затем клонируйте слайд с этим мастером, используя [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslidecollection/) и [ISlideCollection.addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidecollection/). Это сохраняет мастер, layout‑ы и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseoverridethememanager/) для темы слайда или layout и соответствующие методы получения эффективных данных для объектов формата, таких как [Background.getEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.