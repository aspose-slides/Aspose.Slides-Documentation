---
title: Управление темами презентаций в PHP
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/php-java/presentation-theme/
keywords:
- Тема PowerPoint
- Тема презентации
- Тема слайда
- Установить тему
- Изменить тему
- Управление темой
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
- PHP
- Aspose.Slides
description: "Мастер‑темы презентаций в Aspose.Slides для PHP через Java для создания, настройки и конвертации файлов PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, поддерживающие темы, ссылаются на эти общие определения вместо того, чтобы сохранять каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить многие объекты одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterthememanager/), тогда как макет или отдельный слайд могут переопределять наследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда определяется по этой цепочке наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже показаны наиболее распространённые рабочие процессы с темами: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после применения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/) предоставляет доступ к цветовой схеме темы, схеме шрифтов и схеме форматов через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/). Просмотр этих коллекций перед их изменением особенно полезен, когда презентация получена из внешнего источника, поскольку количество и содержание элементов стилей могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линии и эффекта хранится в теме:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Просмотрите мастер, связанный со слайдом, и используйте рабочий процесс эффективной темы, показанный позже в статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Объекты, учитывающие тему, могут использовать логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/schemecolor/). Когда вы меняете соответствующую запись в [ColorScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт форму, использующую `Accent4`, меняет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её вновь и выводит эффективный цвет заливки:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы прямым цветом формы, последующие изменения `Accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint генерирует более светлые и более тёмные варианты из цветовой схемы темы, применяя трансформации цвета. Aspose.Slides раскрывает эти трансформации через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, полученные из дополнительной палитры](additional-palette-colors.png)

**1** – основные цвета темы.  
**2** – более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет трансформацию светлоты к пяти из них и сохраняет результат:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Эти варианты остаются основанными на цветовом схеме темы. Если `Accent4` изменится позже, преобразованные цвета будут пересчитаны исходя из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в ячейки `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [ColorScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colorscheme/) представляет те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Соответствие фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются динамически преобразуемыми значениями.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для основного текста. Методы [FontScheme.getMajor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontscheme/) и [FontScheme.getMinor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontscheme/) предоставляют доступ к этим наборам.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться в форматировании текста:

* `+mn-lt` – основной шрифт тела (Minor Latin Font)
* `+mj-lt` – шрифт заголовка (Major Latin Font)
* `+mn-ea` – основной шрифт восточно‑азиатского текста (Minor East Asian Font)
* `+mj-ea` – шрифт заголовка восточно‑азиатского текста (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем он изменяет шрифты темы и сохраняет результат:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Заголовок следует за основным шрифтом, а основной текст – за вспомогательным шрифтом. Текст, в котором явно указано имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные наборы шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просматривать, добавлять, заменять или удалять эти сопоставления, см. [Шрифты темы, специфичные для скриптов](/slides/ru/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Для получения дополнительной информации о шрифтах презентации см. [Шрифты PowerPoint](/slides/ru/php-java/powerpoint-fonts/).

{{% /alert %}}

## **Копирование или применение темы**

Ниже приведены рабочие процессы, решающие разные задачи, связанные с темами.

### **Применить внешнюю тему к слайдам, зависящим от мастера**

Используйте [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/) при наличии файла темы PowerPoint (`.thmx`), когда нужно переоформить каждый слайд, зависящий от конкретного мастера. Выберите нужный мастер из коллекции [Presentation::getMasters](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), представленной типом [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/), и передайте путь к файлу темы в метод.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.  
2. Применяет внешнюю тему к новому мастеру.  
3. Назначает новый мастер всем слайдам, ранее зависявшим от выбранного мастера.  
4. Возвращает только что созданный [MasterSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/).

Следующий пример применяет внешнюю тему к слайдам, зависящим от первого мастера, и сохраняет презентацию:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Недопустимая, повреждённая или неподдерживаемая тема может вызвать [PptxReadException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxreadexception/). Проверяйте пути, полученные от пользователей, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переименовываются только слайды, зависявшие от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, учитывающие тему, разрешаются в соответствии с внешней темой. Прямо назначенные цвета, шрифты, заливки и другие явные форматы могут остаться без изменений. Переопределения уровня макета и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, отсутствующие в среде выполнения. Для гарантированной отрисовки и экспорта установите требуемые шрифты, предоставьте их через [пользовательские источники шрифтов](/slides/ru/php-java/custom-font/), либо сконфигурируйте [замену шрифтов](/slides/ru/php-java/font-substitution/).

Это прямой рабочий процесс уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы уровня слайда или макета.

### **Применить разные внешние темы в презентации с несколькими мастерами**

Если нужный мастер неизвестен заранее, получите его из представительного слайда через [Slide::getLayoutSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/) и [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/). Сохраните исходные ссылки на мастера перед применением любых тем, поскольку каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух разделов, находит их мастера и применяет к каждой группе свою внешнюю тему:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Первый вызов влияет только на слайды, зависящие от `$firstGroupMaster`, а второй – только на слайды, зависящие от `$secondGroupMaster`. Слайды, принадлежащие другим мастерам, не переоформляются.

### **Сохранить исходную тему при перемещении слайдов**

Если нужно переместить слайд в другую презентацию и сохранить его исходный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/), затем клонируйте сам слайд с помощью [SlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidecollection/) и клонированного мастера. Это перенесёт мастер, его макеты и связанную тему вместе со слайдом.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Это предпочтительный рабочий процесс, когда исходный слайд должен выглядеть одинаково в целевом файле. Простое клонирование содержимого на несвязанный мастер получателя может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен оставаться на текущих мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Это изменяет тему, используемую этим слайдом, не затрагивая тему, унаследованную другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/overridetheme/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется ко всем слайдам, использующим этот макет, если у конкретного слайда нет собственного переопределения. Те же методы инициализации можно вызвать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Используйте тему уровня мастера или презентации, когда многие макеты и слайды должны делить одну базовую конфигурацию, переопределение макета — когда одной семье макетов нужен иной стиль, а переопределение слайда — только для истинных исключений. Чрезмерное количество переопределений уровня слайда усложняет предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Фонные заливки темы хранятся в [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/). В пользовательском интерфейсе PowerPoint может быть предложено больше вариантов фона, чем количество фактически хранящихся в этой коллекции определений заливки, поскольку UI комбинирует тематические заливки с цветовыми схемами и другими ссылками стилей.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Прежде чем использовать стиль фона, просмотрите хранящуюся коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/). Индекс стиля `0` означает отсутствие тематической заливки; положительные значения — ссылки на тематические стили фона. Это отличается от индексации самой PHP‑коллекции, где `get_Item(0)` обозначает первый элемент. Не предполагаете, что у каждой презентации одинаковое количество стилей фоновой заливки.

Следующий пример выводит количество доступных фоновых заливок, назначает тематическую ссылку на фон первому мастеру и сохраняет презентацию:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Видимый результат зависит от ссылки, хранящейся в мастере, а также от любых переопределений фона на уровнях макета или слайда. Если у слайда есть собственный фон, изменение только фона мастера может не затронуть этот слайд. Для получения окончательного фона после применения наследования используйте [Background.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/).

{{% alert color="warning" title="Warning" %}}
Не воспринимайте индекс стиля как нулевой индекс коллекции. Также избегайте «жёсткого» кодирования номера стиля из одного файла и предположения, что он будет выглядеть так же в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Фон презентации](/slides/ru/php-java/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции заливок, линий и эффектов, доступные через [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/) и [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/). Обычные темы Office часто включают три основных стиля, визуально соответствующие «тонкому», «умеренно» и «интенсивному» форматированию, но код должен проверять каждую коллекцию, а не предполагать фиксированное количество.

![Тонкие, умеренные и интенсивные эффекты темы, применённые к одной и той же форме](presentation-design_10.png)

При работе с этими коллекциями в PHP индексация начинается с нуля: `get_Item(0)` — первый сохранённый стиль, `get_Item(2)` — третий. Индексы ссылок стиля формы — отдельная концепция, представленная через [ShapeStyle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapestyle/). Изменение стилевого шаблона темы влияет на формы, которые ссылаются на этот стиль; формы с прямым форматированием могут оставаться без изменений.

Следующий пример проверяет наличие требуемых стилей, изменяет первый линейный стиль, третий заливочный стиль, включает внешний теневой эффект в третьем стилевом эффекте и сохраняет результат:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Для форм, ссылающихся на эти слоты, первый линейный стиль темы станет красным, третий заливочный стиль — сплошным лесным зелёным, а третий эффект получит внешнюю теневую проекцию с отступом 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стиля каждая форма использует и переопределяется ли прямое форматирование.

![Стили эффектов темы после изменения линий, заливки и теней](presentation-design_11.png)

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть сохранена непосредственно в объекте или наследоваться от абзаца, макета, мастера, стиля темы или другого уровня форматирования. Вызовите [FillFormat::getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/) для получения неизменяемых эффективных данных заливки. Сначала проверьте результат `getFillType`. Только если он равен `FillType::Solid`, следует считывать свойства сплошной заливки.

Для сплошной заливки `getSolidFillColor` возвращает окончательное RGB‑значение после наследования, поиска по теме и применения цветовых трансформаций. Метод `getSolidFillSchemeColor` возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/schemecolor/), такой как `Text1` или `Accent6`. Значение `SchemeColor::NotDefined` означает, что эффективная сплошная заливка не основана на цветовом слоте. В рабочем процессе, где заливки либо являются цветовыми слотами темы, либо прямыми RGB‑цветами, это значение указывает на прямую RGB‑заливку.

Не используйте только локальное значение [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colorformat/) для классификации заливки. Например, у части текста может не быть локального определения цветового слота, поэтому его локальное значение `NotDefined`, но эффективная заливка наследуется из темы и соответствует `Text1` или `Accent6`. С другой стороны, `getSolidFillSchemeColor` сообщает, какой логический слот темы сформировал эффективный цвет, но не указывает, откуда этот слот пришёл — объект, абзац, макет, мастер или иной уровень иерархии.

Следующий пример загружает презентацию, проверяет заливки форм и заливки текстовых фрагментов, выводит каждое окончательное RGB‑значение и связанный цветовой слот, а также отмечает сплошные заливки, которые не будут отслеживать изменения цветовых слотов темы:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Отметка `NotDefined` предоставляет список сплошных заливок, которые не будут реагировать на изменения цветовых слотов темы. Проверьте эти объекты, когда презентация должна соответствовать новой фирменной палитре. Выведенное RGB‑значение показывает текущий вид, а значение слота объясняет, связано ли оно с темой.

Эффективные объекты — это снимки. После изменения темы презентации, переопределения темы или любого унаследованного форматирования вызовите `getEffective` ещё раз и получите новые эффективные данные заливки перед сравнением или выводом цветов.

## **Чтение эффективных значений темы**

Сырые объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или форма действительно используют после применения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/), а для заливки — [FillFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/).

Следующий пример считывает эффективную тему, фон и первую заливку формы со слайда:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Используйте эффективные данные для диагностики отрисовки, проверки и сравнения. Если вы изучаете только [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), можете пропустить переопределения мастера, макета, слайда или формы, меняющие окончательный внешний вид.

## **FAQ**

**Применение внешней темы затрагивает каждый слайд презентации?**

Нет. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/) переassignует только те слайды, которые зависят от выбранного мастера. Слайды, использующие другие мастеры, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой способ самый безопасный для переноса темы из одной презентации в другую?**

При перемещении слайда и сохранении его исходного вида клонируйте исходный мастер в целевую презентацию и клонируйте сам слайд с этим мастером, используя [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/) и [SlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidecollection/). Это сохранит мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseoverridethememanager/) для темы слайда или макета и соответствующие методы получения эффективных данных для объектов форматов, такие как [Background.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.