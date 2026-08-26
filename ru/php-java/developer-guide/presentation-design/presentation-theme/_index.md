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
- PHP
- Aspose.Slides
description: "Мастер-темы презентаций в Aspose.Slides для PHP через Java для создания, настройки и преобразования файлов PowerPoint с единым фирменным стилем."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо хранения каждого визуального свойства как фиксированного значения, поэтому изменение темы может одновременно обновить множество объектов.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределить тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterthememanager/), а макет или отдельный слайд могут переопределить наследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Разделы ниже показывают самые распространённые сценарии работы с темой: проверка темы, изменение цветов и шрифтов, копирование или применение темы, обновление фоновых и эффектных стилей и чтение эффективных значений после разрешения наследования и переопределений.

## **Осмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/) раскрывает цветовую схему темы, схему шрифтов и схему форматов через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/). Проверка этих коллекций перед их изменением особенно полезна, когда презентация поступает из внешнего источника, поскольку количество и содержание записей стилей могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько фоновых, заливочных, линий и эффектных стилей хранится в теме:

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

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте мастер, связанный со слайдом, и используйте процесс работы с эффективной темой, показанный ниже в статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Тема‑aware заливки, линии и текст могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/schemecolor/). Когда вы меняете соответствующую запись в [ColorScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получат новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `Accent4`, меняет цвет `Accent4` темы на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в фигуре, последующие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides открывает эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** – Основные цвета темы.

**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников, основанных на `Accent4`, применяет преобразования светлоты к пяти из них и сохраняет результат:

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

Эти варианты остаются основанными на цветовом значении темы. Если позже `Accent4` изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в слоты `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [ColorScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Соответствие фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются динамически преобразуемыми значениями.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для основного текста. Методы [FontScheme.getMajor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontscheme/) и [FontScheme.getMinor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontscheme/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, можно использовать в оформлении текста:

* `+mn‑lt` – шрифт тела Latin (Minor Latin Font)
* `+mj‑lt` – шрифт заголовка Latin (Major Latin Font)
* `+mn‑ea` – шрифт тела East Asian (Minor East Asian Font)
* `+mj‑ea` – шрифт заголовка East Asian (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку тела, использующую вспомогательный латинский шрифт темы. Затем он меняет шрифты темы и сохраняет результат:

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

Заголовок следует за основным шрифтом, а основной текст – за вспомогательным. Текст, в котором явно указано имя шрифта вместо идентификатора темы, не переключится автоматически при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Подсказка" %}}
Для получения дополнительной информации о шрифтах презентации см. [PowerPoint Fonts](/slides/ru/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже представлены процессы, решающие различные задачи, связанные с темой.

### **Применение внешней темы к слайдам, зависящим от мастера**

Используйте [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/) , когда у вас есть файл темы PowerPoint (`.thmx`) и необходимо изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation::getMasters](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), представленной [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/), и передайте путь к файлу темы методу.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.  
2. Применяет внешнюю тему к новому мастеру.  
3. Присваивает новый мастер всем слайдам, ранее зависявшим от выбранного мастера.  
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

Неправильная, повреждённая или неподдерживаемая тема может вызвать [PptxReadException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxreadexception/). Проверяйте пути, передаваемые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переassignируются только слайды, зависящие от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, зависящие от темы, рассчитываются на основе внешней темы. Прямо назначенные цвета, шрифты, заливки и другие явные форматы могут оставаться без изменений. Переопределения уровня макета и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, недоступные в среде выполнения. Для согласованного отображения и экспорта установите требуемые шрифты, предоставьте их через [custom font sources](/slides/ru/php-java/custom-font/), либо настройте [font substitution](/slides/ru/php-java/font-substitution/).

Это прямой процесс уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или макета.

### **Применение разных внешних тем в многомастере презентации**

Когда нужный мастер неизвестен заранее, получите его от представительного слайда через [Slide::getLayoutSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/) и [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/). Сохраните оригинальные ссылки на мастеров перед применением любых тем, потому что каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух разделов, чтобы найти их мастера, и применяет различную внешнюю тему к каждой группе:

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

Первый вызов затрагивает только слайды, зависящие от `$firstGroupMaster`, а второй – только слайды, зависящие от `$secondGroupMaster`. Слайды, принадлежащие другим мастерам, не меняют стиль.

### **Сохранение исходной темы при перемещении слайдов**

Если требуется переместить слайд в другую презентацию и сохранить его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/), затем клонируйте слайд с помощью [SlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidecollection/) вместе с клонированным мастером. Это переносит мастер, его макеты и связанную тему.

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

Это предпочтительный процесс, когда исходный слайд должен выглядеть одинаково в целевом файле. Простое клонирование содержимого на несвязанный мастер может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применение значений темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/overridetheme/) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

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

Это меняет тему, используемую этим слайдом, без изменения темы, унаследованной другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/overridetheme/).

### **Применение переопределения темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно вызвать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslidethememanager/):

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

Используйте тему мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; используйте переопределение макета, когда семье макетов нужен иной стиль; и используйте переопределение слайда только для истинных исключений. Чрезмерное количество переопределений уровня слайда усложняет предсказание последствий глобальных изменений темы.

## **Обновление фоновых стилей темы**

Фоновые заливки темы хранятся в [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/). PowerPoint может показывать в интерфейсе больше вариантов фона, чем фактически хранится в этой коллекции, потому что UI может комбинировать заливки темы с цветовыми ссылками темы и другими ссылками стилей.

![Галерея фоновых стилей PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием фонового стиля проверьте хранящуюся коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/). Индекс стиля `0` означает отсутствие тематической заливки; положительные значения – ссылки на стили фона темы. Это отличается от индексации самой PHP‑коллекции, где `get_Item(0)` обозначает первый элемент. Не предполагаете, что каждая презентация содержит одинаковое количество фоновых заливок.

Следующий пример выводит количество доступных фоновых заливок, присваивает тематическую ссылку фона первому мастеру и сохраняет презентацию:

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

Видимый результат зависит от темы, на которую ссылается мастер, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона мастера может не повлиять на этот слайд. Используйте [Background.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/) , когда нужно узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Предупреждение" %}}
Не рассматривайте индекс стиля как нулевой индекс коллекции. Также избегайте жесткой кодировки номера стиля из одного файла с предположением, что он будет выглядеть так же в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Подсказка" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/php-java/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции заливок, линий и эффектов, раскрываемые через [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/) и [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/). Обычные темы Office часто включают три основных стиля, визуально соответствующих «тонкому», «умеренному» и «интенсивному» оформлению, но код должен проверять каждую коллекцию вместо предположения фиксированного количества.

![Субтильные, умеренные и интенсивные эффекты темы, применённые к одной фигуре](presentation-design_10.png)

При работе с этими коллекциями в PHP индексация коллекции начинается с нуля: `get_Item(0)` – первая запись, `get_Item(2)` – третья. Индексы ссылки на стиль фигуры – отдельная концепция, раскрываемая через [ShapeStyle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapestyle/). Изменение стиля темы влияет на фигуры, ссылающиеся на этот стиль; фигуры с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, меняет первый линейный стиль, меняет третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

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

Для фигур, ссылающихся на эти слоты, первый линейный стиль темы станет красным, третий стиль заливки темы станет сплошным лесным зелёным, а третий стиль эффекта получит внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё ещё зависит от того, какие слоты стиля каждая фигура использует и переопределяется ли её прямое форматирование.

![Стили эффектов темы после изменения настроек линии, заливки и тени](presentation-design_11.png)

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура реально используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/).

Следующий пример считывает эффективную тему, фон и первую заливку фигуры со слайда:

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнений. Если вы проверяете только [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), можно пропустить переопределения мастера, макета, слайда или фигуры, меняющие окончательный вид.

## **Вопросы и ответы**

**Влияет ли применение внешней темы на каждый слайд презентации?**

Нет. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/) переassignует только те слайды, которые зависят от выбранного мастера. Слайды, использующие другие мастеры, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidethememanager/) слайда и инициализируйте его переопределяющую тему. Изменение останется локальным для этого слайда; другие слайды продолжат наследовать свои текущие темы.

**Какой самый надёжный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного вида клонируйте исходный мастер в целевую презентацию и клонируйте слайд вместе с этим мастером, используя [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/) и [SlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidecollection/). Это сохраняет мастера, макеты и тему совместно.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseoverridethememanager/) для темы слайда или макета и соответствующие методы получения эффективных данных для объектов формата, таких как [Background.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/). Эти API возвращают рассчитанные значения после применения наследования и переопределений.