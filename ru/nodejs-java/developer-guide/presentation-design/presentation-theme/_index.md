---
title: Управление темами презентаций в JavaScript
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте темами презентаций в JavaScript с помощью Aspose.Slides для Node.js, создавайте, настраивайте и конвертируйте файлы PowerPoint с единообразным брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, поддерживающие темы, ссылаются на эти общие определения вместо того, чтобы сохранять каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getmastertheme/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterthememanager/), тогда как макет или отдельный слайд могут переопределять наследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseoverridethememanager/). На практике эффективная тема слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже показаны наиболее распространённые сценарии работы с темами: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mastertheme/) открывает схему цветов темы, схему шрифтов и схему форматов через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mastertheme/). Просмотр этих коллекций перед изменением особенно полезен, когда презентация поступает из внешнего источника, поскольку количество и содержание элементов стилей могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линии и эффектов хранится в теме:

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

Если файл использует несколько мастеров, не следует предполагать, что у каждого слайда одинаковая эффективная тема. Просмотрите мастер, связанный со слайдом, и используйте workflow эффективной темы, показанный позже в этой статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Заливки, линии и текст, поддерживающие темы, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/schemecolor/). Когда вы меняете соответствующий элемент в [ColorScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/colorscheme/), все объекты, продолжающие ссылаться на этот цвет темы, применяют новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт форму, использующую `Accent4`, меняет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её заново и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы прямым цветом в форме, последующие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides предоставляет эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** – Основные цвета темы.  
**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет преобразования яркости к пяти из них и сохраняет результат:

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

Эти варианты продолжают основываться на цветовом схеме темы. Если `Accent4` позже изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в слоты `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [ColorScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/colorscheme/) открывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Соответствие фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, динамически преобразуемыми из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор для основного текста. Методы [FontScheme.getMajor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontscheme/) и [FontScheme.getMinor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontscheme/) открывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться при форматировании текста:

* `+mn-lt` – Основной шрифт латиница (Minor Latin Font)
* `+mj-lt` – Шрифт заголовка латиница (Major Latin Font)
* `+mn-ea` – Основной шрифт восточно‑азиатский (Minor East Asian Font)
* `+mj-ea` – Шрифт заголовка восточно‑азиатский (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем меняет шрифты темы и сохраняет результат:

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

Заголовок следует основному шрифту, а основной текст – вспомогательному. Текст, у которого явно указано имя шрифта вместо идентификатора темы, не переключится автоматически при изменении схемы шрифтов темы.

Основные и вспомогательные наборы шрифтов могут также содержать соответствия для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти соответствия, см. [Script-Specific Theme Fonts](/slides/ru/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Подсказка" %}}
Для получения дополнительной информации о шрифтах презентации см. [PowerPoint Fonts](/slides/ru/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже представлены рабочие процессы, решающие разные задачи, связанные с темой.

### **Применить внешнюю тему к слайдам, зависящим от мастера**

Используйте [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) , когда у вас есть файл темы PowerPoint (`.thmx`) и требуется изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation.getMasters](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), представленной [MasterSlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslidecollection/), и передайте путь к файлу темы в метод.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.  
1. Применяет внешнюю тему к новому мастеру.  
1. Присваивает новый мастер всем слайдам, ранее зависявшим от выбранного мастера.  
1. Возвращает только что созданный [MasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/).

Следующий пример применяет внешнюю тему к слайдам, зависящим от первого мастера, и сохраняет презентацию:

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

Недопустимая, повреждённая или неподдерживаемая тема может вызвать [PptxReadException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxreadexception/). Проверяйте пути, передаваемые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переприсваиваются только слайды, зависящие от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, зависящие от темы, рассчитываются по внешней теме. Прямо назначенные цвета, шрифты, заливки и другое явное форматирование могут оставаться без изменений. Переопределения уровня макета и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, недоступные в среде выполнения. Для согласованного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/nodejs-java/custom-font/), или настройте [font substitution](/slides/ru/nodejs-java/font-substitution/).

Это прямой workflow уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровнях слайда или макета.

### **Применить разные внешние темы в презентации с несколькими мастерами**

Когда нужный мастер неизвестен заранее, получите его из представительного слайда через [Slide.getLayoutSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/) и [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/). Сохраните оригинальные ссылки на мастера до применения тем, поскольку каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух разделов, находит их мастера и применяет различную внешнюю тему к каждой группе:

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

Первый вызов влияет только на слайды, зависящие от `firstGroupMaster`, второй – только на слайды, зависящие от `secondGroupMaster`. Слайды, принадлежащие другим мастерам, не переоформляются.

### **Сохранить исходную тему при перемещении слайдов**

Если нужно переместить слайд в другую презентацию, сохранив оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslidecollection/), затем клонируйте слайд с помощью [SlideCollection.addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidecollection/) и клонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

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

Это предпочтительный workflow, когда исходный слайд должен выглядеть одинаково в целевом файле. Простое клонирование содержимого на несвязанный мастер‑назначения может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

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

Это меняет тему, используемую этим слайдом, не затрагивая тему, наследуемую другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/overridetheme/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации могут быть использованы через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Используйте тему уровня мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета – когда одной группе макетов нужен иной стиль; и переопределение слайда – только для истинных исключений. Чрезмерное количество переопределений на уровне слайда усложняет предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Заливки фона темы хранятся в [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/formatscheme/). PowerPoint может предлагать в интерфейсе больше вариантов фона, чем реально хранится в этой коллекции, поскольку UI может комбинировать заливки темы с цветовыми ссылками и другими стилями.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием стиля фона просмотрите хранящуюся коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/background/). Индекс стиля `0` означает отсутствие тематической заливки; положительные значения – ссылки на стили фоновой темы. Это отличается от прямой индексации JavaScript‑коллекции, где `0` обозначает первый элемент. Не предполагайте, что у каждой презентации одинаковое количество стилей фоновой заливки.

Следующий пример выводит количество доступных фоновых заливок, назначает тематическую ссылку фона первому мастеру и сохраняет презентацию:

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

Видимый результат зависит от темы, на которую ссылается мастер, и от любых переопределений фона на уровнях макета или слайда. Если у слайда собственный фон, изменение только фона мастера может не отразиться на этом слайде. Используйте [Background.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/background/) , когда требуется узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Предупреждение" %}}
Не рассматривайте индекс стиля как нулевой индекс коллекции. Также избегайте жёстко заданных номеров стилей из одного файла, полагая, что они будут выглядеть одинаково в другом файле; определения стилей темы специфичны для каждой презентации.
{{% /alert %}}

{{% alert color="info" title="Подсказка" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/nodejs-java/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции заливок, линий и эффектов, открываемые через [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/formatscheme/) и [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/formatscheme/). Обычные офисные темы часто включают три основных стиля, визуально соответствующих «тёплый», «умеренный» и «интенсивный» формат, но код должен проверять каждую коллекцию, а не полагаться на фиксированное количество элементов.

![Тёплые, умеренные и интенсивные эффекты темы, применённые к одной фигуре](presentation-design_10.png)

При доступе к этим коллекциям в JavaScript индексация начинается с нуля: индекс `0` – первая сохранённая стилизация, индекс `2` – третья. Индексы ссылок стилей фигуры – отдельная концепция, открываемая через [ShapeStyle](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapestyle/). Изменение стиля темы влияет на фигуры, ссылающиеся на этот стиль; фигуры с прямым форматированием могут оставаться без изменений.

Следующий пример проверяет наличие необходимых стилей, меняет первый линейный стиль, третий заливочный стиль, включает внешнюю тень в третьем эффекте и сохраняет результат:

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

Для фигур, ссылающихся на эти слоты, первый линейный стиль темы станет красным, третий заливочный стиль – сплошным тёмно‑зелёным, а третий эффект получит внешнюю тень с отступом 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей каждая фигура использует и перекрывается ли тема прямым форматированием.

![Стили эффектов темы после изменения линии, заливки и тени](presentation-design_11.png)

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть задана непосредственно на объекте или унаследована от абзаца, макета, мастера, стиля темы или другого уровня форматирования. Вызовите [FillFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/) , чтобы превратить эту иерархию в неизменяемый снимок эффективной заливки. Сначала проверьте значение `getFillType`. Только если оно равно `FillType.Solid`, следует читать свойства сплошной заливки.

Для сплошной заливки `getSolidFillColor` возвращает финальное RGB‑значение после применения наследования, поиска в теме и преобразований цвета. Метод `getSolidFillSchemeColor` выдаёт соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/schemecolor/), например `Text1` или `Accent6`. Значение `SchemeColor.NotDefined` означает, что эффективная сплошная заливка не основана на цветовом слоте схемы. В рабочем процессе, где заливки либо темы, либо прямые RGB‑цвета, это значение указывает на прямую RGB‑заливку.

Не используйте только локальное значение [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/colorformat/) для классификации заливки. Например, у части текста может не быть локального схемного цвета (`NotDefined`), но её эффективная заливка может наследовать цвет темы и разрешаться в `Text1` или `Accent6`. С другой стороны, `getSolidFillSchemeColor` сообщает, какой логический слот темы создал эффективный цвет, но не указывает, с какого уровня (объект, абзац, макет, мастер) он пришёл.

Следующий пример загружает презентацию, проверяет заливки фигур и текста, выводит каждое окончательное RGB‑значение и связанный слот схемы, а также отмечает сплошные заливки, которые не будут отслеживать изменения цветов темы:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ветка `NotDefined` предоставляет список сплошных заливок, не реагирующих на изменения слотów цветов темы. Проверьте эти объекты, когда презентация должна соответствовать новой бренд‑палитре. Выведенное RGB‑значение показывает текущее отображение, а значение схемы поясняет, привязано ли оно к теме.

Эффективные объекты формата – это снимки. После изменения темы презентации, переопределения темы или любого унаследованного форматирования вызовите `getEffective` снова и получите новый объект эффективной заливки перед сравнением или выводом цветов.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/background/), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/).

Следующий пример считывает эффективную тему, фон и первую заливку фигуры со слайда:

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

Используйте эффективные данные для диагностики рендеринга, проверки и сравнения. Если смотреть только на [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getmastertheme/), можно пропустить переопределения мастера, макета, слайда или фигуры, меняющие окончательный вид.

## **FAQ**

**Применение внешней темы влияет на каждый слайд в презентации?**

Нет. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) переприсваивает только слайды, зависящие от выбранного мастера. Слайды, использующие другие мастеры, сохраняют свои текущие темы.

**Можно ли применить тему к одному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой самый безопасный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного вида клонируйте исходный мастер в целевую презентацию и клонируйте слайд с этим мастером, используя [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslidecollection/) и [SlideCollection.addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidecollection/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseoverridethememanager/) для темы слайда или макета и соответствующие методы получения эффективных данных для форматных объектов, таких как [Background.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.