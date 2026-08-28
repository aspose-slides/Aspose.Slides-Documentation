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
- Java
- Aspose.Slides
description: "Создавайте, настраивайте и конвертируйте файлы PowerPoint с единым брендингом, используя главные темы презентаций в Aspose.Slides для Java."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо хранения каждого визуального свойства как фиксированного значения, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Master может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/masterthememanager/), тогда как макет или отдельный слайд могут переопределять унаследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда определяется по цепочке наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Разделы ниже показывают самые типичные рабочие процессы с темой: проверка темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после того, как наследование и переопределения применены.

## **Проверка темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/) предоставляет доступ к схеме цветов темы, схеме шрифтов и схеме форматов через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/mastertheme/). Проверка этих коллекций перед их изменением особенно полезна, когда презентация поступает из внешнего источника, поскольку количество и содержание записей стилей могут различаться.

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

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте мастер, связанный со слайдом, и используйте рабочий процесс с эффективной темой, показанный позже в этой статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Тема‑aware заливки, линии и текст могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/schemecolor/). Когда вы меняете соответствующую запись в [IColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icolorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цветa темы.

Следующий сквозной пример создаёт фигуру, использующую `Accent4`, меняет цвет `Accent4` темы на красный, сохраняет презентацию, открывает её заново и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся привязанным к `Accent4`, его видимый цвет станет красным после изменения темы. Если заменить цвет схемы прямым цветом в фигуре, дальнейшие изменения `Accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides раскрывает эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, полученные из дополнительной палитры](additional-palette-colors.png)

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

Эти варианты остаются привязанными к цветовому слоту темы. Если позже `Accent4` изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в слоты `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icolorscheme/) представляет те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Отображение фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные имена одних и тех же слотов темы; они не являются значениями, которые динамически преобразуются из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для основного текста. Методы [IFontScheme.getMajor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontscheme/) и [IFontScheme.getMinor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontscheme/) предоставляют доступ к этим наборам.

Идентификаторы шрифтов, совместимые с PowerPoint, можно использовать в форматировании текста:

* `+mn-lt` – Текстовый шрифт Latin (Minor Latin Font)
* `+mj-lt` – Шрифт заголовка Latin (Major Latin Font)
* `+mn-ea` – Текстовый шрифт East Asian (Minor East Asian Font)
* `+mj-ea` – Шрифт заголовка East Asian (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем он меняет шрифты темы и сохраняет результат:

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

Заголовок следует за основным шрифтом, а основной текст – за вспомогательным. Текст, в котором явно указано имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные наборы шрифтов также могут содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентации смотрите [PowerPoint Fonts](/slides/ru/java/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже перечислены рабочие процессы, решающие разные задачи, связанные с темами.

### **Применить внешнюю тему к слайдам, зависящим от мастера**

Используйте [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/) когда у вас есть файл темы PowerPoint (`.thmx`) и нужно переоформить каждый слайд, зависящий от конкретного мастера. Выберите мастер из коллекции [Presentation.getMasters](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), реализующей [IMasterSlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/), и передайте путь к файлу темы в метод.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.  
2. Применяет внешнюю тему к новому мастеру.  
3. Присваивает новый мастер всем слайдам, которые ранее зависели от выбранного мастера.  
4. Возвращает только что созданный [IMasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/).

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

Недопустимая, повреждённая или неподдерживаемая тема может вызвать [PptxReadException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxreadexception/). Проверяйте пути, предоставляемые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переназначаются только те слайды, которые зависели от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастеры и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, учитывающие тему, разрешаются относительно внешней темы. Прямо назначенные цвета, шрифты, заливки и прочее явное форматирование могут остаться без изменений. Переопределения уровня макета и слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, отсутствующие в среде выполнения. Для единообразного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/java/custom-font/), либо настройте [font substitution](/slides/ru/java/font-substitution/).

Это прямой рабочий процесс уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы уровня слайда или макета.

### **Применить разные внешние темы в презентации с несколькими мастерами**

Когда нужный мастер неизвестен заранее, получайте его из представительного слайда через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/) и [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilayoutslide/). Сохраните исходные ссылки на мастера перед применением любых тем, так как каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух секций, чтобы найти их мастера, и применяет различную внешнюю тему к каждой группе:

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

Первый вызов затрагивает только слайды, зависимые от `firstGroupMaster`, а второй – только слайды, зависимые от `secondGroupMaster`. Слайды, принадлежащие к другим мастерам, не переоформляются.

### **Сохранить исходную тему при перемещении слайдов**

Если необходимо переместить слайд в другую презентацию и сохранить его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/), затем клонируйте слайд с помощью [ISlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidecollection/) и клонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

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

Это предпочтительный рабочий процесс, когда исходный слайд должен выглядеть одинаково в целевом файле. Простое клонирование содержимого на независящий от него мастер может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/overridetheme/) копируют три основных компонента темы во переопределение.

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

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно использовать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/layoutslidethememanager/):

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

Используйте тему мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета – когда семейству макетов нужен иной стиль; а переопределение слайда – только для истинных исключений. Чрезмерное количество переопределений уровня слайда усложняет предсказуемость последующих глобальных изменений темы.

## **Обновление фоновых стилей темы**

Фоновые заливки темы хранятся в [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/). PowerPoint может показывать в интерфейсе больше вариантов фона, чем реально хранится в этой коллекции, потому что UI комбинирует заливки темы с цветовыми слотами и другими ссылками стилей.

![Галерея фоновых стилей PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием фонового стиля проверьте сохранённую коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/). Индекс стиля `0` означает отсутствие тематической заливки; положительные значения – ссылки на тематические стили фона. Это отличается от индексации Java‑коллекции напрямую, где `get_Item(0)` обозначает первый элемент. Не предполагаете, что в каждой презентации одинаковое количество фоновых заливок.

Следующий пример выводит количество доступных фоновых заливок, назначает тематическую ссылку фона первому мастеру и сохраняет презентацию:

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

Видимый результат зависит от ссылки, хранящейся в мастере, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона мастера может не затронуть этот слайд. Используйте [Background.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/) когда нужно знать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не рассматривайте индекс стиля как нулевой индекс коллекции. Также избегайте жёстко задавать номер стиля из одного файла и предполагать, что он будет выглядеть так же в другом файле; определения стилей темы специфичны для каждой презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/java/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции стилей заливки, линии и эффектов, доступные через [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/) и [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iformatscheme/). Обычные темы Office часто содержат три основных стиля, визуально соответствующие «нежному», «умеренному» и «интенсивному» форматированию, но код должен проверять каждую коллекцию, а не предполагать фиксированное количество.

![Незначительные, умеренные и интенсивные эффекты темы, применённые к одной фигуре](presentation-design_10.png)

При работе с этими коллекциями в Java индексация начинается с нуля: `get_Item(0)` – первая сохранённая запись, `get_Item(2)` – третья. Индексы ссылок стиля у фигуры – отдельная концепция, раскрытая через [IShapeStyle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapestyle/). Изменение стиля темы влияет на фигуры, ссылающиеся на этот стиль; фигуры с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие необходимых записей стилей, меняет первый линейный стиль, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

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

Для фигур, которые ссылаются на эти слоты, первый линейный стиль темы станет красным, третий стиль заливки – сплошным лесным зелёным, а третий стиль эффекта получит внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей использует каждая фигура и есть ли прямое переопределение форматирования.

![Стили эффектов темы после изменения линии, заливки и настроек тени](presentation-design_11.png)

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть сохранена непосредственно в объекте или наследоваться от абзаца, макета, мастера, стиля темы или другого уровня форматирования. Вызовите [IFillFormat.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformat/), чтобы разрешить эту иерархию в неизменяемый объект [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformateffectivedata/). Сначала проверьте [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformateffectivedata/). Только когда тип `FillType.Solid`, следует читать свойства сплошной заливки.

Для сплошной заливки [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformateffectivedata/) возвращает окончательное отрисованное RGB‑значение после применения наследования, поиска в теме и преобразований цвета. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformateffectivedata/) возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/schemecolor/), например `Text1` или `Accent6`. Значение `SchemeColor.NotDefined` означает, что эффективная сплошная заливка не основана на цветовом слоте схемы. В рабочем процессе, где заливки либо являются цветовыми слотами темы, либо прямыми RGB‑цветами, это значение идентифицирует прямую RGB‑заливку.

Не используйте только локальное значение [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icolorformat/) для классификации заливки. Например, часть текста может не иметь локально определённого цвета схемы, поэтому её локальное значение будет `NotDefined`, тогда как её эффективная заливка наследует цвет темы и разрешается к `Text1` или `Accent6`. С другой стороны, `getSolidFillSchemeColor` сообщает, какой логический слот темы дал конечный цвет, но не указывает, откуда этот слот пришёл – от объекта, абзаца, макета, мастера или другого уровня иерархии.

Следующий пример загружает презентацию, проверяет заливки фигур и заливки текстовых частей, выводит каждое окончательное RGB‑значение и связанный слот схемы, а также отмечает сплошные заливки, которые не будут отслеживать изменения цветов темы:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ветка `NotDefined` формирует список аудита сплошных заливок, которые не отреагируют на изменения цветовых слотов темы. Просмотрите эти объекты, когда презентация должна соответствовать новой брендинговой палитре. Отчётный RGB‑значение всё равно отражает текущее отображение, а значение схемы поясняет, связано ли оно с темой.

Эффективные объекты формата – это снимки. После изменения темы презентации, переопределения темы или любого унаследованного форматирования вызовите `getEffective` снова и считайте новый объект `IFillFormatEffectiveData` перед сравнением или выводом цветов.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/).

Следующий пример считывает эффективную тему, фон и первую заливку фигуры со слайда:

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнения. Если проверять только [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), можно упустить переопределения мастера, макета, слайда или фигуры, меняющие окончательный вид.

## **FAQ**

**Применение внешней темы влияет на каждый слайд в презентации?**

Нет. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslide/) переназначает только те слайды, которые зависят от выбранного мастера. Слайды, использующие другие мастеры, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidethememanager/) слайда и инициализируйте его переопределённую тему. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой самый безопасный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида клонируйте исходный мастер в целевую презентацию через [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imasterslidecollection/) и клонируйте сам слайд с этим мастером используя [ISlideCollection.addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidecollection/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Для слайда или макета темы используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseoverridethememanager/), а для объектов формата – соответствующие методы получения эффективных данных, такие как [Background.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.