---
title: Управление темами презентаций на Android
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "Основные темы презентаций в Aspose.Slides для Android через Java для создания, настройки и конвертации файлов PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо хранения каждого визуального свойства как фиксированного значения, поэтому изменение темы может одновременно обновить множество объектов.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Master может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), тогда как макет или отдельный слайд могут переопределять наследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда разрешается по этой цепочке наследования: тема презентации, переопределение master, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже показаны наиболее распространённые сценарии работы с темой: изучение темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Проверка темы**

Объект [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) раскрывает цветовую схему темы, схему шрифтов и схему форматов через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). Проверка этих коллекций перед их изменением особенно полезна, когда презентация получена из внешнего источника, поскольку количество и содержание записей стилей могут различаться.

Следующий пример читает основные свойства темы и сообщает, сколько стилей фона, заливки, линий и эффектов хранится в теме:

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

Если файл использует несколько master‑слайдов, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте master, связанный со слайдом, и используйте workflow эффективной темы, показанный ниже, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Тема‑aware заливки, линии и текст могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). Когда вы меняете соответствующую запись в [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `Accent4`, меняет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся привязанным к `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет фигуры, последующие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint генерирует более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides раскрывает эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, созданные из дополнительной палитры](additional-palette-colors.png)

**1** - Основные цвета темы.  
**2** - Более светлые и более тёмные варианты, полученные из основных цветов темы.

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

Эти варианты остаются основанными на цвете темы. Если `Accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений SchemeColor в слоты IColorScheme**

Перечисление [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Соответствие фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, динамически преобразуемыми из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит набор основных шрифтов для заголовков и набор вспомогательных шрифтов для основного текста. Методы [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) и [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться в форматировании текста:

* `+mn‑lt` - Тело шрифт Latin (шрифт Minor Latin)
* `+mj‑lt` - Заголовок шрифт Latin (шрифт Major Latin)
* `+mn‑ea` - Тело шрифт East Asian (шрифт Minor East Asian)
* `+mj‑ea` - Заголовок шрифт East Asian (шрифт Major East Asian)
* `+mn‑cs` - Тело шрифт Complex Script (шрифт Minor Complex Script)
* `+mj‑cs` - Заголовок шрифт Complex Script (шрифт Major Complex Script)

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

Заголовок следует за основным шрифтом, а основной текст — за вспомогательным. Текст, у которого явно указано имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов могут также содержать сопоставления шрифтов для отдельных письменных систем, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентации см. [Шрифты PowerPoint](/slides/ru/androidjava/powerpoint-fonts/).
{{% /alert %}}

### **Разрешение ссылок на шрифты темы**

При проверке текста [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) может вернуть ссылку на тему, например `+mn‑lt`, вместо имени семейства шрифта. Вызовите [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) с соответствующим [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) для разрешения этой ссылки. Префиксы `+mj` и `+mn` выбирают основные и вспомогательные наборы шрифтов; суффиксы `-lt`, `-ea` и `-cs` выбирают их латинские, восточно‑азиатские и сложные скриптовые шрифты соответственно.

Получите эффективную тему через [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) у объекта, к теме которого относится проверяемый текст. Для обычного текста на слайде вызывайте этот метод у слайда, чтобы контекст включал наследованную тему слайда и локальные переопределения. При проверке самого макета или master‑слайда используйте его собственную эффективную тему. Не предполагаете, что тема первого master‑слайда применяется ко всем слайдам.

Следующий пример создаёт текстовую часть, явно ссылающуюся на вспомогательный латинский шрифт. Он инициализирует схему шрифтов слайда через [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) и задаёт основные и вспомогательные латинские семейства шрифтов `Arial` и `Calibri`, делая результат воспроизводимым без входного файла.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Вывод: `+mn‑lt -> Calibri`, за которым следует `Verdana -> Verdana`. Сохранённая ссылка остаётся неизменной, в то время как явно указанное семейство шрифта возвращается как есть. Если бы часть использовала `+mj‑lt`, она бы разрешилась в `Arial` в этой теме.

Разрешение ссылки темы определяет семейство шрифтов, указанное в теме. Оно не проверяет наличие шрифта и не определяет фактический файл шрифта, используемый после подстановки или fallback‑глифов во время рендеринга. См. [Font Selection Sequence](/slides/ru/androidjava/font-selection-sequence/) и [Font Substitution](/slides/ru/androidjava/font-substitution/) для этих отдельных шагов.

## **Копирование или применение темы**

Ниже представлены сценарии решения различных задач, связанных с темой.

### **Применить внешнюю тему к слайдам, зависящим от master‑слайда**

Используйте [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) при наличии файла темы PowerPoint (`.thmx`) и необходимости переоформить каждый слайд, зависящий от конкретного master‑слайда. Выберите master из коллекции [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), реализующей [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), и передайте путь к файлу темы в метод.

Метод выполняет следующие операции:

1. Создаёт новый master‑слайд на основе выбранного master‑слайда.  
1. Применяет внешнюю тему к новому master‑слайду.  
1. Присваивает новый master всем слайдам, ранее зависящим от выбранного master‑слайда.  
1. Возвращает только что созданный [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

Следующий пример применяет внешнюю тему к слайдам, зависящим от первого master‑слайда, и сохраняет презентацию:

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

Недействительная, повреждённая или неподдерживаемая тема может вызвать [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). Проверяйте пути, передаваемые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переназначаются только слайды, зависимые от выбранного master‑слайда. Слайды, связанные с другими master‑слайдами, сохраняют свои текущие master‑слайды и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, зависящие от темы, разрешаются относительно внешней темы. Прямо назначенные цвета, шрифты, заливки и другие явные форматирования могут остаться без изменений. Переопределения уровня макета и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового master‑слайда.

Тема может ссылаться на шрифты, отсутствующие в среде выполнения. Для согласованного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/androidjava/custom-font/), либо настройте [font substitution](/slides/ru/androidjava/font-substitution/).

Это прямой workflow уровня master: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или макета.

### **Применить различные внешние темы в презентации с несколькими master‑слайдами**

Когда нужный master‑слайд неизвестен заранее, получите его из представительного слайда через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) и [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). Сохраните исходные ссылки на master‑слайды перед применением тем, поскольку каждый вызов создаёт новый master‑слайд в презентации.

Следующий пример использует слайды из двух разделов, чтобы найти их master‑слайды, и применяет к каждой группе отдельную внешнюю тему:

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

Первый вызов затрагивает только слайды, зависящие от `firstGroupMaster`, второй — только слайды, зависящие от `secondGroupMaster`. Слайды, принадлежащие другим master‑слайдам, не переоформляются.

### **Сохранить исходную тему при перемещении слайдов**

Если необходимо переместить слайд в другую презентацию и сохранить его оригинальный дизайн, клонируйте исходный master в целевую презентацию с помощью [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), затем клонируйте слайд с помощью [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) и клонированного master‑слайда. Это переносит master, его макеты и связанную тему вместе.

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

Это предпочтительный workflow, когда исходный слайд должен выглядеть одинаково в целевом файле. Простое копирование содержимого на несоответствующий master‑слайд может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен остаться на текущем master‑слайде и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

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

Это меняет тему, используемую этим слайдом, не затрагивая тему, наследуемую другими слайдами. Чтобы удалить локальное переопределение и вернуться к наследуемым значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно использовать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Используйте тему уровня master или презентации, когда множество макетов и слайдов должны делить один базовый дизайн, переопределение макета — когда одна семейка макетов требует другого стиля, а переопределение слайда — только для истинных исключений. Чрезмерное количество переопределений на уровне слайда усложняет предсказание последствий глобальных изменений темы.


<!-- visual-explanation:presentation-theme:start -->
[![Мастер‑тема снабжает двумя макетами; переопределение макета влияет на его слайды, за исключением слайда с более локальным переопределением.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Переопределение макета применяется к слайдам, использующим этот макет, если слайд не задаёт собственное переопределение. Значения, основанные на теме, следуют своей разрешённой схеме; явно отформатированные объекты могут сохранять локальный внешний вид. Держите переопределения настолько узкими, насколько требуется для конкретного исключения дизайна.*
<!-- visual-explanation:presentation-theme:end -->

## **Обновление стилей фона темы**

Заливки фона темы хранятся в [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). PowerPoint может предлагать больше вариантов фона в пользовательском интерфейсе, чем количество фактически сохранённых определений заливок в этой коллекции, потому что UI может комбинировать заливки темы с цветовыми ссылками и другими ссылками стилей.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием стиля фона проверьте сохранённую коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/). Индекс стиля `0` означает отсутствие тематической заливки; положительные значения — ссылки на стили фона темы. Это отличается от индексации коллекции Java, где `get_Item(0)` означает первый сохранённый элемент. Не предполагайте, что каждая презентация содержит одинаковое количество стилей фоновых заливок.

Следующий пример выводит количество доступных фоновых заливок, назначает тематическую ссылку фона первому master‑слайду и сохраняет презентацию:

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

Видимый результат зависит от записи темы, на которую ссылается master, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона master‑слайда может не затронуть этот слайд. Используйте [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) когда необходимо узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не рассматривайте индекс стиля как нулевой индекс коллекции. Также избегайте «жёсткого» кодирования номера стиля из одного файла и предположения, что он будет выглядеть одинаково в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/androidjava/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции стилей заливки, линий и эффектов, открываемые через [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), и [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Типичные темы Office часто содержат три основных стиля, визуально соответствующие «деликатному», «умеренно‑насыщенному» и «интенсивному» форматированию, но код должен проверять каждую коллекцию вместо предположения фиксированного количества.

![Деликатные, умеренно‑насыщенные и интенсивные эффекты темы, применённые к одной и той же фигуре](presentation-design_10.png)

При доступе к этим коллекциям в Java индексация коллекции начинается с нуля: `get_Item(0)` — первая сохранённая заливка, `get_Item(2)` — третья. Индексы ссылок стилей фигуры — отдельная концепция, раскрываемая через [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). Изменение стиля темы влияет на фигуры, ссылающиеся на этот стиль; фигуры с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, меняет первый стиль линии, третий стиль заливки и включает внешнюю тень в третьем стиле эффекта, затем сохраняет результат:

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

Для фигур, ссылающихся на эти слоты, первый стиль линии темы становится красным, третий стиль заливки темы — сплошным цветом «лесной зелёный», а третий стиль эффекта получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей каждая фигура использует и переопределяется ли прямое форматирование.

![Стили эффектов темы после изменения линии, заливки и параметров тени](presentation-design_11.png)

## **Выбор стилей заливки и линии темы для фигуры**

Фигура может независимо выбирать свою заливку и обводку через [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) и [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Для каждого метода индекс `1` выбирает первую запись в соответствующей коллекции темы (`get_Item(0)`), индекс `2` — вторую (`get_Item(1)`).

Следующий пример создаёт два стиля заливки (золото и небесно‑голубой) и два стиля линии (тёмно‑синий 6 pt и тёмно‑красный 12 pt) в теме по умолчанию новой презентации. Он сохраняет слайд в трёх состояниях, чтобы вы могли сравнить результаты в PowerPoint.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Начальные стили | Изменить правую обводку | Изменить первую заливку темы |
|:---:|:---:|:---:|
| ![Золотые и небесно‑голубые прямоугольники с совпадающими тонкими тёмно‑синими контурами](theme-style-initial.png) | ![Небесно‑голубой прямоугольник теперь имеет толстый тёмно‑красный контур](theme-style-line-changed.png) | ![Левый прямоугольник стал зелёным, обе обводки остались без изменений](theme-style-fill-changed.png) |

Выбор другого стиля линии меняет только контур правого прямоугольника. Изменение первой заливки темы обновляет каждую фигуру, использующую её. Здесь только левый прямоугольник становится зелёным.

У существующей фигуры локальный цвет заливки, цвет линии или толщина линии могут переопределять соответствующую часть стиля темы. Если изменение индекса стиля не даёт визуального эффекта, проверьте [direct formatting](/slides/ru/androidjava/shape-formatting/) фигуры.

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть сохранена непосредственно в объекте или наследоваться от параграфа, макета, master‑слайда, стиля темы или другого уровня форматирования. Вызовите [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) для разрешения этой иерархии в неизменяемый [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Сначала проверьте [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Только когда тип `FillType.Solid` следует читать свойства сплошной заливки.

Для сплошной заливки [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) возвращает окончательное RGB‑значение после наследования, поиска в теме и применения цветовых преобразований. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/), например `Text1` или `Accent6`. Значение `SchemeColor.NotDefined` означает, что эффективная сплошная заливка не основана на цветовом слоте схемы. В workflow, где заливки являются либо цветовыми темами, либо прямыми RGB‑цветами, это значение указывает на прямую RGB‑заливку.

Не используйте локальное значение [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) самостоятельно для классификации заливки. Например, у части текста может не быть локально определённого цвета схемы, поэтому её локальное значение `NotDefined`, в то время как её эффективная заливка наследует цвет темы и разрешается в `Text1` или `Accent6`. Обратное, `getSolidFillSchemeColor` сообщает, какой логический слот темы создал эффективный цвет, но не указывает, от какого уровня (объект, параграф, макет, master‑слайд) он пришёл.

Следующий пример загружает презентацию, проверяет заливки фигур и заливки текстовых частей, выводит каждый окончательный RGB‑цвет и соответствующий слот схемы, а также отмечает сплошные заливки, которые не будут отслеживать изменения цветовых слотов темы:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
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

Ветка `NotDefined` формирует список сплошных заливок, которые не будут реагировать на изменения цветовых слотов темы. Просмотрите эти объекты, когда презентация должна соответствовать новой фирменной палитре. Сообщаемое RGB‑значение всё равно отображает текущий внешний вид, а значение схемы объясняет, связан ли этот вид с темой.

Объекты эффективного формата являются моментальными снимками. После изменения темы презентации, переопределения темы или любого унаследованного форматирования вызовите `getEffective` снова и получите новый объект `IFillFormatEffectiveData` перед сравнением или выводом цветов.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), а для заливки — [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнений. Если вы проверяете только [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), вы можете упустить переопределения master‑слайда, макета, слайда или фигуры, которые изменяют окончательный внешний вид.

## **Вопросы и ответы**

**Применение внешней темы влияет на каждый слайд в презентации?**

Нет. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) переназначает только слайды, зависящие от выбранного master‑слайда. Слайды, использующие другие master‑слайды, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения master‑слайда?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) конкретного слайда и инициализируйте его переопределённую тему. Изменение остаётся локальным для этого слайда; остальные слайды продолжают наследовать свои существующие темы.

**Какой способ безопаснее всего перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида клонируйте исходный master в целевую презентацию и клонируйте слайд с этим master, используя [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) и [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). Это сохраняет master, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) для темы слайда или макета и соответствующие методы эффективных данных для форматов, такие как [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.