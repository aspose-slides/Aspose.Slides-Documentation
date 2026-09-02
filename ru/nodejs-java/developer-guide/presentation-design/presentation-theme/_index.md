---
title: Управление темами презентаций в JavaScript
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/nodejs-java/presentation-theme/
keywords:
- Тема PowerPoint
- тема презентации
- тема слайда
- установить тему
- изменить тему
- управление темой
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Создание, настройка и конвертация файлов PowerPoint с единым брендингом в JavaScript с использованием Aspose.Slides для Node.js."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо хранения каждого визуального свойства как фиксированного значения, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getmastertheme/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределить тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterthememanager/), в то время как макет или отдельный слайд может переопределить унаследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда определяется по этой цепочке наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже представлены самые распространённые сценарии работы с темой: исследование темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Исследование темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mastertheme/) раскрывает схему цветов, схему шрифтов и схему форматов темы через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mastertheme/). Исследование этих коллекций перед их изменением особенно полезно, когда презентация получена из внешнего источника, поскольку количество и содержание записей стиля могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линий и эффектов хранится в теме:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Исследуйте мастер, связанный со слайдом, и используйте сценарий эффективной темы, показанный ниже в статье, когда могут быть присутствовать переопределения макета или слайда.

## **Изменить цвета темы**

Заполнения, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/schemecolor/). Когда вы изменяете соответствующую запись в [ColorScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/colorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получат новое значение. Объекты, использующие прямой цвет RGB, не изменятся при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `Accent4`, меняет цвет `Accent4` темы на красный, сохраняет презентацию, открывает её вновь и выводит фактический цвет заливки:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Поскольку прямоугольник остаётся привязанным к `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в фигуре, последующие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использовать цвета из дополнительной палитры**

PowerPoint выводит более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides предоставляет эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** — Основные цвета темы.  
**2** — Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет к пяти из них преобразования яркости и сохраняет результат:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Эти варианты остаются основанными на цвете темы. Если `Accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Сопоставить значения `SchemeColor` со слотами `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, в то время как [ColorScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/colorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, динамически преобразуемыми из одной формы в другую.

## **Изменить шрифты темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для основного текста. Методы [FontScheme.getMajor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontscheme/) и [FontScheme.getMinor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontscheme/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться при форматировании текста:

* `+mn-lt` — шрифт тела Latin (младший латинский шрифт)
* `+mj-lt` — шрифт заголовка Latin (старший латинский шрифт)
* `+mn-ea` — шрифт тела East Asian (младший восточноазиатский шрифт)
* `+mj-ea` — шрифт заголовка East Asian (старший восточноазиатский шрифт)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем он изменяет шрифты темы и сохраняет результат:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Заголовок следует за основным шрифтом, а основной текст — за вспомогательным шрифтом. Текст, у которого указано явное имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов также могут содержать сопоставления шрифтов для конкретных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы исследовать, добавить, заменить или удалить эти сопоставления, смотрите [Script-Specific Theme Fonts](/slides/ru/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Подсказка" %}}
Для получения дополнительной информации о шрифтах презентации см. [PowerPoint Fonts](/slides/ru/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Копировать или применить тему**

Ниже приведены сценарии, решающие различные задачи, связанные с темой.

### **Применить внешний файл темы к зависимым слайдам мастера**

Используйте [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) при наличии файла темы PowerPoint (`.thmx`) и необходимости изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation.getMasters](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), представленной [MasterSlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslidecollection/), и передайте путь к файлу темы методу.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.
2. Применяет внешний файл темы к новому мастеру.
3. Назначает новый мастер всем слайдам, ранее зависящим от выбранного мастера.
4. Возвращает только что созданный [MasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/).

Следующий пример применяет внешний файл темы к слайдам, зависящим от первого мастера, и сохраняет презентацию:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Недействительный, повреждённый или неподдерживаемый файл темы может вызвать [PptxReadException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxreadexception/). Проверяйте пути, переданные пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переназначаются только слайды, зависимые от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, учитывающие тему, разрешаются в соответствии с внешней темой. Прямо назначенные цвета, шрифты, заливки и другие явные форматы могут оставаться без изменений. Переопределения уровня макета и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, недоступные в среде выполнения. Для согласованного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/nodejs-java/custom-font/), или сконфигурируйте [font substitution](/slides/ru/nodejs-java/font-substitution/).

Это прямой сценарий уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или макета.

### **Применить разные внешние темы в презентации с несколькими мастерами**

Когда нужный мастер заранее неизвестен, получите его из представительного слайда через [Slide.getLayoutSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/) и [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/). Сохраните ссылки на оригинальные мастера до применения любых тем, поскольку каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух секций, чтобы найти их мастера, и применяет к каждой группе разную внешнюю тему:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Первый вызов воздействует только на слайды, зависящие от `firstGroupMaster`, а второй – только на слайды, зависящие от `secondGroupMaster`. Слайды, принадлежащие любому другому мастеру, не меняют стиль.

### **Сохранить исходную тему при перемещении слайдов**

Если необходимо переместить слайд в другую презентацию, сохранив его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslidecollection/), затем клонируйте слайд с помощью [SlideCollection.addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidecollection/) и клонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Это предпочтительный сценарий, когда исходный слайд должен выглядеть одинаково в целевой презентации. Простое копирование содержимого в несвязанный мастер получателя может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен остаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Это меняет тему, используемую этим слайдом, не меняя тему, унаследованную другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/overridetheme/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно использовать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Используйте тему мастера или уровня презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета – когда одной семье макетов нужен иной стиль; и переопределение слайда – только для истинных исключений. Чрезмерное количество переопределений на уровне слайда усложняет предсказание последующих глобальных изменений темы.

## **Обновить стили фонового оформления темы**

Фоновые заливки темы хранятся в [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/formatscheme/). PowerPoint может показывать в интерфейсе больше вариантов фона, чем количество фактически сохранённых в этой коллекции определений заливок, поскольку UI комбинирует заливки темы с её цветами и другими ссылками стилей.

![Галерея стилей фонового оформления PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием фонового стиля исследуйте хранимую коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/background/). Индекс стиля `0` означает отсутствие заливки темы; положительные значения – ссылки на стили фонового оформления темы. Это отличается от индексации JavaScript‑коллекции, где `0` означает первый сохранённый элемент. Не предполагаете, что у каждой презентации одинаковое количество стилей фоновых заливок.

Следующий пример сообщает количество доступных фоновых заливок, назначает ссылку на тематический фон первому мастеру и сохраняет презентацию:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Видимый результат зависит от записи темы, на которую ссылается мастер, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фонового стиля мастера может не изменить этот слайд. Используйте [Background.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/background/), когда необходимо узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Предупреждение" %}}
Не рассматривайте индекс стиля как нулевой индекс коллекции. Также избегайте жёсткого кодирования номера стиля из одного файла и предположения, что он будет выглядеть так же в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Подсказка" %}}
Для прямого форматирования фона и наследования фона смотрите [Presentation Background](/slides/ru/nodejs-java/presentation-background/).
{{% /alert %}}

## **Обновить стили эффектов темы**

Схема форматов темы содержит отдельные коллекции стилей заливок, линий и эффектов, открываемые через [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/formatscheme/), и [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/formatscheme/). Типичные офисные темы часто содержат три основных стиля, визуально соответствующие «тонким», «средним» и «интенсивным» форматам, но код должен проверять каждую коллекцию вместо предположения фиксированного количества.

![Тонкие, умеренные и интенсивные эффекты темы, применённые к одной фигуре](presentation-design_10.png)

При доступе к этим коллекциям в JavaScript индекс коллекции начинается с нуля: индекс `0` – первая сохранённая стилизация, индекс `2` – третья. Индексы ссылок стилей фигур – отдельная концепция, раскрытая через [ShapeStyle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapestyle/). Изменение стиля темы влияет на фигуры, ссылающиеся на этот стиль; фигуры с прямым форматированием могут оставаться без изменений.

Следующий пример проверяет наличие необходимых записей стилей, изменяет первый стиль линии, меняет третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для фигур, ссылающихся на эти слоты, первый стиль линии темы станет красным, третий стиль заливки темы станет сплошным лесным зелёным, а третий стиль эффекта получит внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё ещё зависит от того, какие слоты стилей использует каждая фигура и переопределяется ли тема прямым форматированием.

![Стили эффектов темы после изменения настроек линии, заливки и тени](presentation-design_11.png)

## **Читать эффективные значения темы**

Сырые объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура фактически используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/background/), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/).

Следующий пример считывает эффективную тему, фон и заливку первой фигуры со слайда:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Используйте эффективные данные для диагностики рендеринга, валидации и сравнения. Если исследовать только [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getmastertheme/), можно пропустить переопределения мастера, макета, слайда или фигуры, меняющие окончательный вид.

## **FAQ**

**Применение внешнего файла темы влияет на каждый слайд в презентации?**

Нет. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) переназначает только слайды, зависящие от выбранного мастера. Слайды, использующие другие мастера, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для этого слайда; другие слайды продолжат наследовать свои существующие темы.

**Какой самый надёжный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида клонируйте исходный мастер в целевую презентацию и затем клонируйте слайд с этим мастером, используя [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslidecollection/) и [SlideCollection.addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidecollection/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseoverridethememanager/) для темы слайда или макета и соответствующие методы получения эффективных данных для объектов формата, таких как [Background.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.