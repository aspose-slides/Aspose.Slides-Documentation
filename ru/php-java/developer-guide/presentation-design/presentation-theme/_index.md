---
title: Управление темами презентаций в PHP
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/php-java/presentation-theme/
keywords:
- Тема PowerPoint
- тема презентации
- тема слайда
- установить тему
- изменить тему
- управлять темой
- цвет темы
- дополнительная палитра
- шрифт темы
- стиль темы
- эффект темы
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте темами презентаций в Aspose.Slides для PHP через Java, создавайте, кастомизируйте и конвертируйте файлы PowerPoint с единообразным брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterthememanager/), тогда как макет или отдельный слайд может переопределять наследуемую тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже показаны наиболее распространённые сценарии работы с темой: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/) раскрывает схему цветов, схему шрифтов и схему форматов темы через [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/). Просмотр этих коллекций перед их изменением особенно полезен, когда презентация поступает из внешнего источника, поскольку количество и содержание записей стилей могут различаться.

Следующий пример читает основные свойства темы и сообщает, сколько стилей фона, заливки, линии и эффекта хранится в теме:

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

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Просмотрите мастер, связанный со слайдом, и используйте рабочий процесс эффективной темы, показанный ниже, когда могут быть переопределения макета или слайда.

## **Изменение цветов темы**

Заливки, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/schemecolor/). Когда вы меняете соответствующую запись в [ColorScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не изменяются при обновлении цвета темы.

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

Поскольку прямоугольник остаётся привязанным к `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в форме, последующие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя трансформации цвета. Aspose.Slides раскрывает эти трансформации через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** – Основные цвета темы.  

**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет к пяти из них трансформации яркости и сохраняет результат:

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

Эти варианты остаются основанными на цвете темы. Если позже `Accent4` изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в слоты `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [ColorScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/colorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Соответствие фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, динамически преобразуемыми из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для основного текста. Методы [FontScheme.getMajor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontscheme/) и [FontScheme.getMinor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontscheme/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться в форматировании текста:

* `+mn-lt` – Основной шрифт латиницы (Minor Latin Font)
* `+mj-lt` – Шрифт заголовков латиницы (Major Latin Font)
* `+mn-ea` – Основной шрифт восточно‑азиатский (Minor East Asian Font)
* `+mj-ea` – Шрифт заголовков восточно‑азиатский (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем меняет шрифты темы и сохраняет результат:

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

Заголовок следует за основным шрифтом, а основной текст – за вспомогательным шрифтом. Текст, содержащий явное название шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Коллекции основных и вспомогательных шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Совет" %}}
Для получения дополнительной информации о шрифтах презентаций, см. [Шрифты PowerPoint](/slides/ru/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Существует два распространённых сценария, решающих разные задачи.

### **Сохранить исходную тему при перемещении слайдов**

Если нужно переместить слайд в другую презентацию и сохранить его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/), затем клонируйте слайд с помощью [SlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidecollection/) и клонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

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

Это предпочтительный рабочий процесс, когда исходный слайд должен выглядеть одинаково в целевом документе. Простое клонирование содержимого на несвязанный мастер назначения может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

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

Это меняет тему, используемую этим слайдом, не меняя тему, унаследованную другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/overridetheme/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации могут использоваться через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslidethememanager/):

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

Используйте тему мастера или уровня презентации, когда многие макеты и слайды должны совместно использовать один базовый дизайн; переопределение макета – когда одной семье макетов нужен иной стиль; и переопределение слайда – только для истинных исключений. Чрезмерные переопределения на уровне слайда усложняют прогнозирование последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Фоновые заливки темы хранятся в [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/). PowerPoint может предлагать больше вариантов фона в пользовательском интерфейсе, чем количество фактически сохранённых определений заливки в этой коллекции, потому что UI может комбинировать фоновые заливки темы с цветовыми и другими ссылками стилей.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием стиля фона просмотрите сохранённую коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/). Индекс стиля `0` означает отсутствие темной заливки; положительные значения – ссылки на стили фона темы. Это отличается от индексации PHP‑коллекции напрямую, где `get_Item(0)` означает первый сохранённый элемент. Не следует предполагать, что каждая презентация содержит одинаковое количество стилей фоновой заливки.

Следующий пример сообщает количество доступных фоновых заливок, назначает ссылку на тематический фон первому мастеру и сохраняет презентацию:

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

Видимый результат зависит от записи темы, на которую ссылается мастер, и от любых переопределений фона на уровне макета или слайда. Если слайд использует свой собственный фон, изменение только фона мастера может не затронуть этот слайд. Используйте [Background.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/), когда необходимо знать окончательный фон после применения наследования.

{{% alert color="warning" title="Предупреждение" %}}
Не рассматривайте индекс стиля как нулевой индекс коллекции. Также избегайте жёсткого кодирования номера стиля из одного файла и предположения, что он будет выглядеть так же в другом файле; определения стилей темы специфичны для каждой презентации.
{{% /alert %}}

{{% alert color="info" title="Совет" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/php-java/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции стилей заливки, линии и эффектов, раскрытые через [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/) и [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/php-java/aspose.slides/formatscheme/). Типичные офисные темы часто содержат три основных стиля, визуально соответствующие «деликатному», «умеренно‑насыщенному» и «интенсивному» форматированию, но код должен проверять каждую коллекцию вместо предположения фиксированного количества.

![Деликатные, умеренные и интенсивные эффекты темы, применённые к одной форме](presentation-design_10.png)

При доступе к этим коллекциям в PHP индекс коллекции начинается с нуля: `get_Item(0)` – первая сохранённая стиль, `get_Item(2)` – третий. Индексы ссылки стиля формы – отдельная концепция, раскрытая через [ShapeStyle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapestyle/). Изменение стиля темы влияет на формы, ссылающиеся на этот стиль; формы с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие необходимых записей стилей, меняет первый линейный стиль, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

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

Для форм, ссылающихся на эти слоты, первый линейный стиль темы становится красным, третий стиль заливки темы – сплошным тёмно‑зелёным, а третий стиль эффекта получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей каждая форма использует и переопределяется ли прямое форматирование темы.

![Стили эффектов темы после изменения настроек линии, заливки и тени](presentation-design_11.png)

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или форма действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseoverridethememanager/). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/).

Следующий пример читает эффективную тему, фон и первую заливку формы со слайда:

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

Используйте эффективные данные для диагностики визуализации, проверки и сравнения. Если вы проверяете только [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), можете пропустить переопределение мастера, макета, слайда или формы, которое меняет окончательный внешний вид.

## **FAQ**

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой самый надёжный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида клонируйте исходный мастер в целевую презентацию и клонируйте слайд с этим мастером, используя [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslidecollection/) и [SlideCollection.addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidecollection/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseoverridethememanager/) для темы слайда или макета и соответствующие методы получения эффективных данных для объектных форматов, таких как [Background.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/background/) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.