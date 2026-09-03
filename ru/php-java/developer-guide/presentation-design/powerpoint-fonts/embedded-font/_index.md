---
title: Встраивание шрифтов в презентации с использованием PHP
linktitle: Встроенные шрифты
type: docs
weight: 40
url: /ru/php-java/embedded-font/
keywords:
- добавить шрифт
- встроить шрифт
- встраивание шрифта
- получить встроенный шрифт
- добавить встроенный шрифт
- удалить встроенный шрифт
- сжать встроенный шрифт
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Управляйте встроенными шрифтами в PowerPoint с помощью Aspose.Slides for PHP via Java. Добавляйте, получайте, удаляйте и сжимайте шрифты, чтобы сохранить внешний вид текста и уменьшить размер файла."
---
## **Введение**

Встраивание шрифтов сохраняет данные шрифта внутри презентации PowerPoint. Когда просмотрщик поддерживает встроенные шрифты, он может отображать текст с этими шрифтами, даже если они не установлены в целевой системе. Это помогает сохранить разрывы строк, интервалы между текстом и макет слайда.

Aspose.Slides for PHP via Java позволяет получать, добавлять и удалять встроенные шрифты через класс [FontsManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/), возвращаемый методом [Presentation::getFontsManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getFontsManager). Вы также можете уменьшить размер встроенных данных шрифта, удалив символы, которые презентация не использует.

Приведённые ниже примеры работают с файлами PPTX. Перед встраиванием шрифта убедитесь, что его данные доступны Aspose.Slides и его лицензия допускает встраивание.

## **Получение и удаление встроенных шрифтов**

Используйте [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts), чтобы получить список шрифтов, хранящихся в презентации. Чтобы удалить шрифт, передайте один из шрифтов из этого списка в [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont), затем сохраните презентацию.

Следующий пример выводит список встроенных шрифтов в файле `EmbeddedFonts.pptx` и удаляет Calibri, если он присутствует:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Удаление встроенного шрифта удаляет его сохранённые данные шрифта; это не меняет шрифт, назначенный тексту. Если шрифт установлен в целевой системе, текст всё равно может его использовать. В противном случае при рендеринге может потребоваться [font substitution](/slides/ru/php-java/font-substitution/), что может повлиять на макет.

## **Проверка данных шрифта и прав на встраивание**

Используйте класс [FontsManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/), чтобы проверить шрифты перед их встраиванием. Вызовите [FontsManager::getFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getFonts), чтобы получить шрифты, используемые в презентации. Для каждого шрифта передайте объект [FontData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontdata/) и требуемое значение [FontStyleType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontstyletype/) в [FontsManager::getFontBytes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getFontBytes). Метод возвращает бинарные данные для данного стиля шрифта или `null`, если запрошенный шрифт или стиль недоступны. Не передавайте результат `null` в [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), так как этот метод требует массив байтов.

[EmbeddingLevel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/embeddinglevel/) — это перечисление флагов, которое сообщает ограничения на встраивание, хранящиеся в шрифте:

- `Installable` разрешает встраивание и постоянную установку на другой системе при условии соблюдения лицензии шрифта.
- `Restricted` запрещает встраивание, если не получено разрешение от законного владельца шрифта, когда это единственный флаг разрешения использования.
- `PreviewPrint` разрешает временное использование для просмотра и печати; документ, содержащий шрифт, должен быть только для чтения.
- `Editable` разрешает временное использование и позволяет документу быть отредактированным и сохранённым.
- `NoSubsetting` — дополнительное ограничение, запрещающее встраивание только подмножества глифов. При наличии этого флага необходимо встраивать все символы.
- `BitmapOnly` — дополнительное ограничение, позволяющее встраивать только растровые наборы, но не контурные данные. Если у шрифта нет растровых наборов, его нельзя встраивать.

Первые четыре значения описывают разрешение на использование, а `NoSubsetting` и `BitmapOnly` могут комбинироваться с ними. Проверяйте модификаторы с помощью побитовых операций. Поскольку `Installable` имеет значение ноль, маскируйте биты разрешения на использование и сравнивайте результат с `Installable`, а не проверяйте его как отдельный флаг. Текущие шрифты должны устанавливать не более одного бита разрешения использования. Для совместимости со старыми шрифтами, которые устанавливают более одного, вспомогательная функция ниже выбирает наименее ограничительное разрешение: `Editable`, затем `PreviewPrint`, затем `Restricted`.

Следующий пример проверяет обычные, полужирные, курсивные и полужирно‑курсивные данные, доступные для каждого шрифта, возвращённого методом `FontsManager::getFonts`. Он пропускает недоступные стили, ограниченные шрифты, шрифты только с растровыми данными, шрифты, ограниченные только просмотром и печатью, поскольку вывод остаётся редактируемым, а также уже встроенные шрифты. Если любой доступный стиль имеет `NoSubsetting`, для этой семейства шрифтов встраиваются все символы.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Эта проверка сообщает о ограничениях, закодированных в каждом файле шрифта. Она не предоставляет лицензию, не доказывает, что вы получили шрифт легально, и не заменяет проверку лицензионного соглашения шрифта перед распространением встроенной копии.

## **Добавление встроенных шрифтов**

Используйте [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), чтобы встроить шрифт. Его перегрузки принимают либо объект [FontData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontdata/), либо массив байтов, содержащий данные шрифта. Перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/ru/php-java/aspose.slides/embedfontcharacters/) управляет тем, какие символы включаются:

- [All](https://reference.aspose.com/slides/ru/php-java/aspose.slides/embedfontcharacters/) встраивает все символы шрифта. Используйте эту опцию, когда получатели должны иметь возможность редактировать презентацию и вводить новый текст.
- [OnlyUsed](https://reference.aspose.com/slides/ru/php-java/aspose.slides/embedfontcharacters/) встраивает только те символы, которые использованы в презентации, чтобы уменьшить размер файла. Выбирайте эту опцию для готовой презентации, предназначенной преимущественно для просмотра.

Следующий пример использует [FontsManager::getFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getFonts), чтобы получить шрифты, использованные в файле `Fonts.pptx`, и встраивает те, которые ещё не встроены. Шрифты для добавления должны быть доступны на машине, где выполняется код. Существующие встроенные шрифты сохраняют свои текущие наборы символов.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Сжатие встроенных шрифтов**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#compressEmbeddedFonts) уменьшает данные встроенного шрифта, удаляя неиспользуемые символы. Он работает с уже встроенными шрифтами, поэтому степень уменьшения размера зависит от того, сколько неиспользуемых данных шрифта содержится в презентации.

Следующий пример сжимает шрифты в файле `EmbeddedFonts.pptx` и сохраняет результат в отдельный файл:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сохраняйте оригинальный файл, если получатели могут позже добавить текст. Символы, удалённые во время сжатия, больше недоступны из встроенного шрифта, даже если изначально были встраиваемы все символы.

## **FAQ**

**Как проверить, будет ли встроенный шрифт всё ещё заменяться во время рендеринга?**

Вызовите [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getSubstitutions) в среде, где вы рендерите презентацию, чтобы увидеть, какие шрифты Aspose.Slides заменит. Также проверьте настройки [font substitution](/slides/ru/php-java/font-substitution/) и правила [font fallback](/slides/ru/php-java/fallback-font/). Fallback обрабатывает отсутствующие символы, поэтому встраивание шрифта не решает проблему символов, которых в самом шрифте нет.

**Стоит ли встраивать распространённые шрифты, такие как Arial и Calibri?**

Решение зависит от целевой среды. Если требуемые шрифты доступны на каждой машине, открывающей или рендерящей презентацию, их встраивание может лишь увеличить размер файла без необходимости. Если у получателей или серверов могут отсутствовать эти шрифты, их встраивание поможет сохранить задуманное отображение, при условии, что лицензии позволяют это.