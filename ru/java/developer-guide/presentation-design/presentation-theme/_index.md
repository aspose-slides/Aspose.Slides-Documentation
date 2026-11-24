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
- Презентация
- Java
- Aspose.Slides
description: "Основные темы презентаций в Aspose.Slides для Java для создания, настройки и конвертации файлов PowerPoint с единообразным брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, поддерживающие темы, ссылаются на эти общие определения вместо того, чтобы сохранять каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Master может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/), тогда как layout или отдельный слайд могут переопределять унаследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение master, переопределение layout и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже показаны наиболее распространённые сценарии работы с темами: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) предоставляет доступ к схеме цветов темы, схеме шрифтов и схеме форматов через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/). Просмотр этих коллекций перед изменением особенно полезен, когда презентация получена из внешнего источника, потому что количество и содержание записей стилей могут различаться.

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

Если файл использует несколько master‑ов, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Просмотрите master, связанный со слайдом, и используйте рабочий процесс эффективной темы, показанный далее в статье, когда могут присутствовать переопределения layout или слайда.

## **Изменение цветов темы**

Заливки, линии и текст, зависящие от темы, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/). Когда вы меняете соответствующую запись в [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не изменятся после обновления цвета темы.

Следующий сквозной пример создаёт форму, использующую `Accent4`, меняет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её вновь и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы прямым цветом на форме, последующие изменения `Accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя трансформации цвета. Aspose.Slides предоставляет эти трансформации через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** – Основные цвета темы.  
**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет трансформацию яркости к пяти из них и сохраняет результат:

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

Эти варианты остаются основанными на цветовом схеме темы. Если `Accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Сопоставление значений `SchemeColor` слотам `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, которые динамически преобразуются из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор для основного текста. Методы [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) и [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) предоставляют доступ к этим наборам.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться в форматировании текста:

* `+mn‑lt` – основной шрифт тела (Minor Latin Font)
* `+mj‑lt` – шрифт заголовка (Major Latin Font)
* `+mn‑ea` – основной шрифт восточно‑азиатский (Minor East Asian Font)
* `+mj‑ea` – шрифт заголовка восточно‑азиатский (Major East Asian Font)
* `+mn‑cs` – основной шрифт сложного письма (Minor Complex Script Font)
* `+mj‑cs` – шрифт заголовка сложного письма (Major Complex Script Font)

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

Заголовок следует основному шрифту, а основной текст – вспомогательному. Текст, в котором явно указан шрифт вместо идентификатора темы, не переключится автоматически при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script‑Specific Theme Fonts](/slides/ru/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентации см. [PowerPoint Fonts](/slides/ru/java/powerpoint-fonts/).
{{% /alert %}}

### **Разрешение ссылок на шрифты темы**

При просмотре текста [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) может вернуть ссылку на тему, например `+mn‑lt`, вместо названия семейства шрифтов. Вызовите [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) с соответствующим [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/), чтобы разрешить эту ссылку. Префиксы `+mj` и `+mn` выбирают основные и вспомогательные наборы шрифтов; суффиксы `-lt`, `-ea` и `-cs` выбирают их латинские, восточно‑азиатские и сложные скрипты соответственно.

Получите эффективную тему через [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) у объекта, к которому применяется тема просматриваемого текста. Для обычного текста на слайде вызовите этот метод у слайда, чтобы контекст включал унаследованную тему слайда и локальные переопределения. При просмотре самого layout или master используйте их собственную эффективную тему. Не предполагайте, что тема первого master‑а применяется ко всем слайдам.

Следующий пример создаёт часть текста, явно ссылающуюся на вспомогательный латинский шрифт. Он инициализирует схему шрифтов слайда через [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) и задаёт основные и вспомогательные латинские семейства как `Arial` и `Calibri`, делая результат воспроизводимым без входного файла.

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

Вывод: `+mn‑lt -> Calibri`, затем `Verdana -> Verdana`. Сохранённая ссылка остаётся неизменной, а явно указанное семейство шрифтов возвращается как есть. Если бы часть использовала `+mj‑lt`, она бы разрешалась в `Arial` в этой теме.

Разрешение ссылки темы определяет семейство шрифтов, указанное в теме. Оно не проверяет доступность шрифта и не определяет фактический файл шрифта, который будет использован после подстановки или fallback‑глифов во время рендеринга. См. [Font Selection Sequence](/slides/ru/java/font-selection-sequence/) и [Font Substitution](/slides/ru/java/font-substitution/) для этих отдельных шагов.

## **Копирование или применение темы**

Ниже представлены рабочие процессы для разных задач, связанных с темами.

### **Применить внешнюю тему к слайдам, зависящим от master‑а**

Используйте [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) когда у вас есть файл темы PowerPoint (`.thmx`) и нужно изменить стиль всех слайдов, зависящих от конкретного master‑а. Выберите master из коллекции [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), реализующей [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), и передайте путь к файлу темы методу.

Метод выполняет следующие операции:

1. Создаёт новый master‑слайд на основе выбранного master‑а.  
2. Применяет внешнюю тему к новому master‑у.  
3. Присваивает новый master всем слайдам, которые ранее зависели от выбранного master‑а.  
4. Возвращает только что созданный [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).

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

Неправильный, повреждённый или неподдерживаемый файл темы может вызвать [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/). Проверяйте пути, введённые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переназначаются только слайды, зависящие от выбранного master‑а. Слайды, связанные с другими master‑ами, сохраняют свои текущие master‑ы и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, зависящие от темы, разрешаются на основе внешней темы. Прямо назначенные цвета, шрифты, заливки и другие явные форматы могут остаться без изменений. Переопределения на уровне layout и слайда также могут иметь приоритет над значениями, унаследованными от нового master‑а.

Тема может ссылаться на шрифты, недоступные в текущей среде выполнения. Для согласованного рендеринга и экспорта установите требуемые шрифты, предоставьте их через [custom font sources](/slides/ru/java/custom-font/), или настройте [font substitution](/slides/ru/java/font-substitution/).

Это прямой workflow уровня master: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или layout.

### **Применить разные внешние темы в презентации с несколькими master‑ами**

Когда нужный master неизвестен заранее, получите его из представительного слайда через [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) и [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/). Сохраните исходные ссылки на master‑ы перед применением тем, так как каждый вызов создаёт новый master в презентации.

Следующий пример использует слайды из двух секций, чтобы определить их master‑ы, и применяет разную внешнюю тему к каждой группе:

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

Первый вызов затрагивает только слайды, зависящие от `firstGroupMaster`, а второй – только слайды, зависящие от `secondGroupMaster`. Слайды, принадлежащие другим master‑ам, не меняют стиль.

### **Сохранить исходную тему при перемещении слайдов**

Если нужно переместить слайд в другую презентацию, сохранив его оригинальный дизайн, клонируйте исходный master в целевую презентацию с помощью [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), затем клонируйте слайд с помощью [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) и клонированного master‑а. Это перенесёт master, его layout‑ы и связанную тему целиком.

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

Этот подход предпочтителен, когда исходный слайд должен выглядеть идентично в целевой презентации. Простое копирование содержимого на несвязанный master‑дестинацию может изменить цвета, шрифты, фоны и эффекты, зависящие от темы.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен оставаться на текущем master‑е и layout‑е, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

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

Это меняет тему, используемую этим слайдом, без изменения темы, унаследованной другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/).

### **Применить переопределение темы к layout‑у**

Переопределение уровня layout применяется к слайдам, использующим этот layout, если только у конкретного слайда нет собственного переопределения. Те же методы инициализации могут быть использованы через [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/):

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

Используйте тему уровня master или презентации, когда многие layout‑ы и слайды должны делить один базовый дизайн; используйте переопределение layout, когда одна группа layout‑ов требует отдельного стиля; и переопределение слайда только для истинных исключений. Чрезмерные переопределения уровня слайда затрудняют предсказание последствий глобальных изменений темы.

<!-- visual-explanation:presentation-theme:start -->
[![Мастер‑тема поставляет две layout‑а; переопределение layout влияет на его слайды, кроме слайда с более локальным переопределением.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Переопределение layout применяется к слайдам, использующим этот layout, если только у слайда нет собственного переопределения. Значения, зависящие от темы, следуют их разрешённой схеме; явно отформатированные объекты могут сохранять локальный внешний вид. Держите переопределения настолько узкими, насколько это необходимо для предполагаемого исключения дизайна.*
<!-- visual-explanation:presentation-theme:end -->

## **Обновление стилей фона темы**

Фоновые заливки темы хранятся в [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). PowerPoint может предлагать больше вариантов фона в пользовательском интерфейсе, чем реально хранится в этой коллекции, потому что UI может комбинировать фоновые заливки темы с цветовыми схемами темы и другими ссылками стилей.

![Галерея фоновых стилей PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием фонового стиля просмотрите хранящуюся коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/). Индекс стиля `0` означает отсутствие заливки темы; положительные значения – ссылки на фоновые стили темы. Это отличается от индексации самой Java‑коллекции, где `get_Item(0)` означает первый хранимый элемент. Не предполагаете, что у каждой презентации одинаковое количество фоновых заливок.

Следующий пример сообщает количество доступных фоновых заливок, присваивает ссылку на тематический фон первому master‑у и сохраняет презентацию:

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

Видимый результат зависит от темы, на которую ссылается master, и от любых переопределений фона на уровнях layout или слайда. Если слайд использует собственный фон, изменение только фона master может не отразиться на этом слайде. Используйте [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) когда необходимо знать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не рассматривайте индекс стиля как ноль‑базовый индекс коллекции. Также избегайте жёсткого кодирования номера стиля из одного файла и предположения, что он будет выглядеть одинаково в другом файле; определения стилей темы специфичны для презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/java/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции заливок, линий и эффектов, доступные через [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) и [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). Типичные офисные темы часто включают три основных стилистических записи, визуально соответствующие «тонким», «средним» и «интенсивным» форматам, но код должен проверять каждую коллекцию вместо того, чтобы предполагать фиксированное количество.

![Тонкие, средние и интенсивные эффекты темы, применённые к одной форме](presentation-design_10.png)

При доступе к этим коллекциям в Java индекс коллекции начинается с нуля: `get_Item(0)` – первая сохранённая стилистическая запись, `get_Item(2)` – третья. Индексы ссылки стиля формы – отдельная концепция, раскрываемая через [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/). Изменение стиля темы влияет на формы, которые ссылаются на этот стиль; формы с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, меняет первый линейный стиль, меняет третий стиль заливки, включает внешнюю тень в третьем эффекте и сохраняет результат:

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

Для форм, ссылающихся на эти слоты, первый линейный стиль темы становится красным, третий стиль заливки – сплошным лесным зелёным, а третий стиль эффекта получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё ещё зависит от того, на какие слоты ссылаются отдельные формы и перекрывает ли прямое форматирование тему.

![Эффекты темы после изменения линии, заливки и настроек тени](presentation-design_11.png)

## **Выбор стилей заливки и линии темы для формы**

Форма может независимо выбирать заливку и контур через [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) и [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Для обоих методов индекс `1` выбирает первую запись в соответствующей коллекции темы (`get_Item(0)`), а индекс `2` – вторую (`get_Item(1)`).

Следующий пример создает два стиля заливки (золото и небесно‑голубой) и два стиля линии (тёмно‑синий 6 pt и тёмно‑красный 12 pt) в стандартной теме новой презентации. Он сохраняет слайд на трёх этапах, чтобы вы могли сравнить результаты в PowerPoint.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Начальные стили | Изменить правый контур | Изменить первую заливку темы |
|:---:|:---:|:---:|
| ![Золотые и небесно‑голубые прямоугольники с тонкими тёмно‑синими контурами](theme-style-initial.png) | ![Небесно‑голубой прямоугольник теперь имеет толстый тёмно‑красный контур](theme-style-line-changed.png) | ![Левый прямоугольник теперь зелёный, а оба контура остались без изменений](theme-style-fill-changed.png) |

Выбор другого линейного стиля меняет только контур правого прямоугольника. Изменение первой заливки темы обновляет каждую форму, использующую её. Здесь только левый прямоугольник становится зелёным.

У уже существующей формы локальный цвет заливки, цвет линии или ширина линии могут переопределять соответствующую часть стиля темы. Если изменение индекса стиля не даёт видимого эффекта, проверьте [direct formatting](/slides/ru/java/shape-formatting/) формы.

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может храниться непосредственно в объекте или наследоваться от абзаца, layout‑а, master‑а, стиля темы или другого уровня форматирования. Вызовите [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) чтобы разрешить эту иерархию в неизменяемый [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). Сначала проверьте [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). Только если он возвращает `FillType.Solid`, следует читать свойства сплошной заливки.

Для сплошной заливки [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) возвращает окончательное RGB‑значение после наследования, поиска в теме и применения трансформаций цвета. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/), например `Text1` или `Accent6`. Значение `SchemeColor.NotDefined` означает, что эффективная сплошная заливка не основана на цветовом слоте схемы. В рабочем процессе, где заливки либо являются цветовыми слотами темы, либо прямыми RGB‑цветами, это значение указывает на прямую RGB‑заливку.

Не используйте локальное значение [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) самостоятельно для классификации заливки. Например, у части текста может не быть локального цвета схемы, поэтому локальное значение `NotDefined`, но эффективная заливка может наследовать цвет темы и разрешаться в `Text1` или `Accent6`. В то время как `getSolidFillSchemeColor` показывает, какой логический слот темы дал эффективный цвет, он не указывает, откуда именно этот слот пришёл (объект, абзац, layout, master и т.д.).

Следующий пример загружает презентацию, проверяет заливки форм и текстовых частей, выводит каждый окончательный RGB‑значение и соответствующий слот схемы, а также отмечает сплошные заливки, которые не будут отслеживать изменения цвета темы:

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

Ветвь `NotDefined` предоставляет список сплошных заливок, которые не отреагируют на изменения слотов цветов темы. Проверьте эти объекты, когда презентация должна соответствовать новой брендовой палитре. Выведенное RGB‑значение всё равно показывает текущий внешний вид, а значение схемы объясняет, связан ли этот внешний вид с темой.

Эффективные объекты формата – это снимки. После изменения темы презентации, переопределения темы или любого унаследованного форматирования, вызовите `getEffective` снова и получите новый объект `IFillFormatEffectiveData` перед сравнением или выводом цветов.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или форма действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/).

Следующий пример читает эффективную тему, фон и первую заливку формы со слайда:

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнений. Если вы просматриваете только [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), вы можете пропустить переопределения master‑а, layout‑а, слайда или формы, изменяющие окончательный внешний вид.

## **FAQ**

**Применяется ли внешняя тема ко всем слайдам презентации?**

Нет. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) переназначает только слайды, зависящие от выбранного master‑а. Слайды, использующие другие master‑ы, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения master‑а?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для данного слайда; остальные слайды продолжают наследовать свои существующие темы.

**Какой способ наиболее надёжный для переноса темы из одной презентации в другую?**

При переносе слайда и сохранении внешнего вида источника клонируйте исходный master в целевую презентацию и клонируйте слайд с этим master, используя [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) и [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/). Это сохраняет master, layout‑ы и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) для темы слайда или layout‑а и соответствующие методы получения эффективных данных для объектoв формата, такие как [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.