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
- PHP
- Aspose.Slides
description: "Управление темами презентаций в Aspose.Slides для PHP через Java для создания, настройки и конвертации файлов PowerPoint с единообразным брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить многие объекты одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Презентация также может содержать переопределения темы на более низких уровнях. Master может переопределять тему презентации через [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/), тогда как макет или отдельный слайд могут переопределять унаследованную тему через [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). На практике эффективная тема для слайда разрешается через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже представлены наиболее распространённые сценарии работы с темой: проверка темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Проверка темы**

Объект [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) предоставляет доступ к схемам цветов, шрифтов и форматов темы через [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) и [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/). Проверка этих коллекций перед их изменением особенно полезна, когда презентация поступает из внешнего источника, потому что количество и содержание записей стилей может различаться.

Следующий пример считывает основные свойства темы и выводит количество стилей фона, заливки, линий и эффектов, хранящихся в теме:

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

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте мастер, связанный со слайдом, и используйте рабочий процесс эффективной темы, показанный позже в этой статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Заливки, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/). Когда вы изменяете соответствующую запись в [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт форму, использующую `Accent4`, меняет цвет `Accent4` темы на красный, сохраняет презентацию, открывает её заново и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в форме, последующие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя трансформации цвета. Aspose.Slides предоставляет эти трансформации через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, полученные из дополнительной палитры](additional-palette-colors.png)

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

Эти варианты остаются основанными на цветовом схеме темы. Если `Accent4` позже изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в ячейки `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) представляет те же ячейки темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же ячеек темы; они не представляют значения, динамически преобразуемые из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для основного текста. Методы [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) и [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) предоставляют доступ к этим наборам.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться при форматировании текста:

* `+mn-lt` – основной шрифт латиницы (Minor Latin Font)
* `+mj-lt` – шрифт заголовков латиницы (Major Latin Font)
* `+mn-ea` – основной шрифт восточноазиатский (Minor East Asian Font)
* `+mj-ea` – шрифт заголовков восточноазиатский (Major East Asian Font)
* `+mn-cs` – основной шрифт сложных сценариев (Minor Complex Script Font)
* `+mj-cs` – шрифт заголовков сложных сценариев (Major Complex Script Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем он меняет шрифты темы и сохраняет результат:

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

Заголовок следует за основным шрифтом, а основной текст – за вспомогательным. Текст, в котором указано явное имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Для получения дополнительной информации о шрифтах презентации см. [PowerPoint Fonts](/slides/ru/php-java/powerpoint-fonts/).

{{% /alert %}}

### **Разрешение ссылок на шрифты темы**

При проверке текста [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) может вернуть ссылку на тему, например `+mn-lt`, вместо имени семейства шрифта. Вызовите [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) с соответствующими данными эффективной темы, чтобы разрешить эту ссылку. Префиксы `+mj` и `+mn` выбирают основные и вспомогательные наборы шрифтов; суффиксы `-lt`, `-ea` и `-cs` выбирают их латинские, восточноазиатские и сложные сценарии соответственно.

Получите эффективную тему через [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) на объекте, к которому применяется тема проверяемого текста. Для обычного текста на слайде вызовите этот метод на слайде, чтобы контекст включал унаследованную тему этого слайда и локальные переопределения. При проверке самого макета или мастера используйте их собственную эффективную тему. Не предполагаете, что тема первого мастера применяется ко всем слайдам.

Следующий пример создаёт текстовую часть, явно ссылающуюся на вспомогательный латинский шрифт. Он инициализирует схему шрифтов слайда через [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) и задаёт основные и вспомогательные латинские семейства шрифтов как `Arial` и `Calibri`, что делает результат воспроизводимым без входного файла.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Вывод выглядит как `+mn-lt -> Calibri`, а затем `Verdana -> Verdana`. Сохранённая ссылка остаётся неизменной, в то время как явное имя семейства возвращается как есть. Если бы часть использовала `+mj-lt`, она бы разрешилась в `Arial` в этой теме.

Разрешение ссылки темы определяет шрифтовое семейство, указанное в теме. Это не проверяет наличие шрифта и не определяет, какой файл шрифта будет в конечном итоге использован после подстановки или резервирования глифов при рендеринге. Смотрите [Font Selection Sequence](/slides/ru/php-java/font-selection-sequence/) и [Font Substitution](/slides/ru/php-java/font-substitution/) для этих отдельный шагов.

## **Копирование или применение темы**

Ниже представлены рабочие процессы, решающие разные задачи, связанные с темами.

### **Применить внешнюю тему к слайдам, зависящим от мастера**

Используйте [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) когда у вас есть файл темы PowerPoint (`.thmx`) и требуется изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), представленной объектом [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), и передайте путь к файлу темы в метод.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.  
2. Применяет внешнюю тему к новому мастеру.  
3. Присваивает новый мастер всем слайдам, ранее зависявшим от выбранного мастера.  
4. Возвращает только что созданный [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

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

Недействительная, повреждённая или неподдерживаемая тема может вызвать [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/). Проверяйте пути, предоставленные пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Перепризначаются только слайды, зависящие от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, учитывающие тему, разрешаются относительно внешней темы. Прямо назначенные цвета, шрифты, заливки и прочее явное форматирование могут оставаться без изменений. Переопределения на уровне макета и слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, которые недоступны в среде выполнения. Для согласованного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/php-java/custom-font/), либо настройте [font substitution](/slides/ru/php-java/font-substitution/).

Это прямой рабочий процесс уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или макета.

### **Применить разные внешние темы в презентации с несколькими мастерами**

Когда нужный мастер неизвестен заранее, получите его из представительного слайда через [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) и [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). Сохраните оригинальные ссылки на мастера перед применением любой темы, потому что каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух разделов, чтобы найти их мастера, и применяет к каждой группе другую внешнюю тему:

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

Если требуется переместить слайд в другую презентацию, сохранив его оригинальный дизайн, склонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), затем склонируйте слайд с помощью [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) и склонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

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

Это предпочтительный рабочий процесс, когда исходный слайд должен выглядеть одинаково в целевом документе. Простое копирование содержимого на несвязанный мастер назначения может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен остаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) и [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) копируют три основных компонента темы в переопределение.

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

Это меняет тему, используемую этим слайдом, без изменения темы, унаследованной другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации могут быть использованы через [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/):

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

Используйте тему мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; используйте переопределение макета, когда одной семье макетов нужен иной стиль; и переопределение слайда только для истинных исключений. Чрезмерные переопределения на уровне слайда усложняют предсказание последствий глобальных изменений темы.

## **Обновление стилей фона темы**

Заливки фона темы хранятся в [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). PowerPoint может показывать в интерфейсе больше вариантов фона, чем фактически хранится в этой коллекции, потому что UI может комбинировать заливки темы с цветовыми схемами и другими ссылками стилей.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием стиля фона проверьте хранимую коллекцию и текущий [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/). Индекс стиля `0` означает отсутствие заливки темы; положительные значения – ссылки на стили фона темы. Это отличается от индексации PHP‑коллекции напрямую, где `get_Item(0)` означает первый сохранённый элемент. Не предполагаете, что у каждой презентации одинаковое количество стилей фоновых заливок.

Следующий пример выводит количество доступных фоновых заливок, назначает ссылку на фон темы первому мастеру и сохраняет презентацию:

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

Видимый результат зависит от записи темы, на которую ссылается мастер, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона мастера может не повлиять на него. Используйте [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) когда нужно узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}

Не воспринимайте индекс стиля как нулевой индекс коллекции. Также избегайте жёсткого кодирования номера стиля из одного файла и предположения, что он будет выглядеть так же в другом файле; определения стилей темы зависят от конкретной презентации.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/php-java/presentation-background/).

{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции стилей заливок, линий и эффектов, доступные через [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) и [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). Типичные офисные темы часто содержат три основных стиля, визуально соответствующих лёгкому, умеренному и интенсивному форматированию, но код должен проверять каждую коллекцию, а не предполагать фиксированное количество.

![Лёгкие, умеренные и интенсивные эффекты темы, применённые к одной и той же форме](presentation-design_10.png)

При работе с этими коллекциями в PHP индексация коллекции начинается с нуля: `get_Item(0)` – первая сохранённая стилизация, `get_Item(2)` – третья. Индексы ссылок стиля формы – отдельная концепция, представляемая через [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/). Изменение стиля темы влияет на формы, которые ссылаются на этот стиль; формы с прямым форматированием могут оставаться без изменений.

Следующий пример проверяет наличие требуемых записей стиля, меняет первый стиль линии, третий стиль заливки и включает внешнюю тень в третьем стиле эффекта, затем сохраняет результат:

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

Для форм, ссылающихся на эти ячейки, первый стиль линии темы становится красным, третий стиль заливки темы – сплошным лесным зелёным, а третий стиль эффекта получает внешнюю тень с дистанцией 10 пунктов. Точный визуальный результат всё ещё зависит от того, какие ячейки стиля каждая форма использует и переопределяется ли прямое форматирование темой.

![Стили эффектов темы после изменения линии, заливки и настроек тени](presentation-design_11.png)

## **Выбор стилей заливки и линии темы для формы**

Форма может независимо выбирать заливку и контур через [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) и [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex). Для обоих методов индекс `1` выбирает первую запись в соответствующей теме (`get_Item(0)`), а индекс `2` – вторую (`get_Item(1)`).

Следующий пример задаёт две стилизации заливки (золотую и небесно‑голубую) и две стилизации линии (тёмно‑синяя 6 pt и тёмно‑красная 12 pt) в теме по умолчанию новой презентации. Он сохраняет слайд в трёх этапах, чтобы вы могли сравнить результаты в PowerPoint.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Начальные стили | Изменить правый контур | Отредактировать первую заливку темы |
|:---:|:---:|:---:|
| ![Золотые и небесно‑голубые прямоугольники с тонкими тёмно‑синими контурами](theme-style-initial.png) | ![Небесно‑голубой прямоугольник теперь имеет толстый тёмно‑красный контур](theme-style-line-changed.png) | ![Левый прямоугольник теперь зелёный, а оба контура остались без изменений](theme-style-fill-changed.png) |

Выбор другого стиля линии меняет только контур правого прямоугольника. Изменение первой заливки темы обновляет каждую форму, использующую её. Здесь только левый прямоугольник становится зелёным.

На существующей форме локальный цвет заливки, цвет линии или толщина линии могут переопределять соответствующую часть стиля темы. Если изменение индекса стиля не даёт видимого эффекта, проверьте [direct formatting](/slides/ru/php-java/shape-formatting/) формы.

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть сохранена напрямую в объекте или унаследована от абзаца, макета, мастера, стиля темы или другого уровня форматирования. Вызовите [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) чтобы разрешить эту иерархию в неизменяемые данные эффективной заливки. Сначала проверьте результат `getFillType`. Только когда он равен `FillType::Solid`, следует читать свойства сплошной заливки.

Для сплошной заливки `getSolidFillColor` возвращает окончательное RGB‑значение после применённого наследования, поиска в теме и трансформаций цвета. Метод `getSolidFillSchemeColor` возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/), например `Text1` или `Accent6`. Значение `SchemeColor::NotDefined` означает, что эффективная сплошная заливка не основана на цветовом слоте схемы. В рабочем процессе, где заливки либо являются цветовыми темами, либо прямыми RGB‑цветами, это значение указывает на прямую RGB‑заливку.

Не используйте локальное значение [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) само по себе для классификации заливки. Например, у текстовой части может не быть локально определённого слота схемы, поэтому её локальное значение будет `NotDefined`, в то время как её эффективная заливка наследует цвет темы и разрешается в `Text1` или `Accent6`. Напротив, `getSolidFillSchemeColor` сообщает, какой логический слот темы породил эффективный цвет, но не указывает, откуда этот слот пришёл (объект, абзац, макет, мастер или иной уровень).

Следующий пример загружает презентацию, проверяет заливки форм и заливки текстовых частей, выводит каждое окончательное RGB‑значение и связанный цвет схемы, а также отмечает сплошные заливки, которые не будут отслеживать изменения цвета темы:

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

Ветка `NotDefined` предоставляет список сплошных заливок, которые не будут реагировать на изменения слотов цветовой схемы темы. Просмотрите эти объекты, когда презентация должна соответствовать новой брендовой палитре. Отчётный RGB‑цвет всё ещё отображает текущий внешний вид, а значение схемы объясняет, связан ли этот внешний вид с темой.

Эффективные объекты формата – это снимки. После изменения темы презентации, переопределения темы или любого унаследованного форматирования вызовите `getEffective` снова и прочитайте новые эффективные данные заливки перед сравнением или отчётом о цветах.

## **Чтение эффективных значений темы**

Сырые объекты темы сообщают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или форма действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Для фона используйте [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), а для заливки – [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнений. Если проверять только [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), можно упустить переопределения мастера, макета, слайда или формы, меняющие окончательный внешний вид.

## **FAQ**

**Применение внешней темы влияет на каждый слайд в презентации?**

Нет. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) переassigns только слайды, зависящие от выбранного мастера. Слайды, использующие другие мастера, сохраняют свои текущие темы.

**Можно ли применить тему к одному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение остаётся локальным для этого слайда; остальные слайды продолжают наследовать свои текущие темы.

**Какой самый безопасный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида склонируйте исходный мастер в целевую презентацию и склонируйте слайд с этим мастером, используя [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) и [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) для темы слайда или макета и соответствующие методы получения эффективных данных для объектов формата, таких как [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) и [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). Эти API возвращают разрешённые значения после применения наследования и переопределений.