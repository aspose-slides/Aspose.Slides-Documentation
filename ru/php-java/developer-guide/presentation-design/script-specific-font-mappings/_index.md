---
title: Управление шрифтами темы, специфичными для скриптов, в PHP
linktitle: Шрифты темы, специфичные для скриптов
type: docs
weight: 15
url: /ru/php-java/script-specific-font-mappings/
keywords:
- шрифт, специфичный для скрипта
- сопоставление шрифта темы
- многоязычная презентация
- система письма
- кириллический шрифт
- арабский шрифт
- японский шрифт
- грузинский шрифт
- шрифт Thaana
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Просмотр, добавление, замена и удаление скриптово‑специфичных сопоставлений шрифтов в темах PowerPoint с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Тема презентации может выбирать разные семейства шрифтов для различных систем письма. Это позволяет многоязычному тексту, который по‑прежнему использует шрифты темы, следовать единой согласованной схеме шрифтов, используя подходящие шрифты для кириллицы, арабского, японского, грузинского, таана и других письменностей.

Тема содержит [FontScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontscheme/), который обычно имеет коллекцию основных шрифтов для заголовков и коллекцию вспомогательных шрифтов для основного текста. Помимо их латинских и восточно‑азиатских настроек, обе коллекции [Fonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fonts/) предоставляют отображения от тегов систем письма к названиям семейств шрифтов.

В этой статье показано, как просматривать и изменять эти отображения в главной теме презентации и проверять, сохраняются ли изменения после сохранения и повторной загрузки.

## **Теги скриптов**

Методы шрифтов скриптов используют четырехбуквенные субтеги BCP 47 для идентификации систем письма. Распространённые значения включают:

| Тег скрипта | Система письма |
|---|---|
| `Cyrl` | Кириллица |
| `Arab` | Арабский |
| `Hans` | Упрощенный китайский |
| `Jpan` | Японский |
| `Geor` | Грузинский |
| `Thaa` | Таана |

Эти сопоставления относятся к схеме шрифтов темы, а не к отдельным фрагментам текста. Презентация может задавать разные сопоставления для основных и вспомогательных коллекций и может опускать сопоставления для некоторых скриптов.

## **Доступ и просмотр сопоставлений шрифтов скриптов**

Используйте [Presentation::getMasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getMasterTheme) для доступа к теме уровня презентации. Методы [MasterTheme::getFontScheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontscheme/#getMajor) и [FontScheme::getMinor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontscheme/#getMinor) предоставляют доступ к двум коллекциям [Fonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fonts/).

Вызовите [Fonts::getScriptFontMap](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fonts/#getScriptFontMap), чтобы получить все сопоставления из коллекции. Чтобы найти конкретную систему письма, вызовите [Fonts::getScriptFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fonts/#getScriptFont) с её тегом скрипта. `Fonts::getScriptFont` возвращает `null`, когда в этой коллекции запрошенное сопоставление не определено.

## **Изменение сопоставлений и проверка их сохранения**

Используйте [Fonts::setScriptFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fonts/#setScriptFont) для создания сопоставления или замены текущего семейства шрифта. Для удаления сопоставления используйте [Fonts::removeScriptFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fonts/#removeScriptFont).

Следующий сквозной пример читает все существующие основные и вспомогательные сопоставления, ищет основной японский шрифт, меняет основной кириллический шрифт, удаляет вспомогательное сопоставление Thaana, сохраняет презентацию и снова открывает её для проверки обоих изменений. Чтобы шаг удаления был независим от начальной темы, пример сначала создаёт сопоставление Thaana только если оно ещё не определено.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

Проверка использует то же поведение `null`, что и обычный поиск: после сохранения удаления `Fonts::getScriptFont("Thaa")` возвращает `null` для вспомогательной коллекции.

## **Отличие сопоставлений темы от других настроек шрифтов**

Сопоставления шрифтов темы, специфичные для скрипта, участвуют в выборе шрифта, но решают другую задачу, чем прямое форматирование текста, замена шрифтов и резервные шрифты:

| Механизм | Назначение | Эффект изменения сопоставления темы |
|---|---|---|
| Script-specific theme font mapping | Выбирает основной или вспомогательный шрифт темы для системы письма. | Текст, продолжающий использовать соответствующий шрифт темы, может переключиться на новое семейство. |
| Font assigned explicitly to a text portion | Шрифт, явно назначенный части текста. | Фиксирует запрошенное семейство шрифтов в этой части вместо использования темы. |
| Font substitution | Замена шрифтов | Заменяет запрашиваемый шрифт, когда он недоступен, или когда применяется правило замены. |
| Font fallback | Резервный шрифт | Предоставляет глифы, которых нет в выбранном шрифте, часто для определённых диапазонов Unicode. |

Для получения дополнительной информации о последних двух механизмах см. [Font Substitution](/slides/ru/php-java/font-substitution/) и [Fallback Fonts](/slides/ru/php-java/fallback-font/).

Изменение сопоставления в [Presentation::getMasterTheme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getMasterTheme) влияет только на содержимое, чьё эффективное форматирование всё ещё зависит от этой темы. Текст может наследовать переопределённую тему от мастера, макета или слайда, либо использовать явно назначенный шрифт. Проверьте эти уровни, если видимый результат не соответствует сопоставлению уровня презентации.

## **Обеспечение доступности сопоставленных шрифтов и проверка результата**

Сопоставление скрипта хранит только название семейства шрифта; оно не устанавливает и не загружает соответствующий файл шрифта. Для согласованного рендеринга и экспорта каждый сопоставленный шрифт должен быть установлен в среде или предоставлен Aspose.Slides через пользовательский источник, например [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#loadExternalFonts) или [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). См. [Custom Fonts](/slides/ru/php-java/custom-font/) для доступных вариантов загрузки.

Проверка сохранённого сопоставления подтверждает только, что определение темы было сохранено. Это не доказывает, что шрифт доступен, содержит все необходимые глифы или создаёт запланированную разметку. Отрендерите представительный текст для каждой требуемой системы письма в изображение или PDF и проверьте результат. Это позволяет обнаружить недостающие шрифты, неполный набор глифов, поведение резервирования и изменения разметки до распространения презентации. См. [Convert PowerPoint Presentations](/slides/ru/php-java/convert-powerpoint/) для примеров рендеринга и экспорта.

## **Вопросы и ответы**

**Что возвращает `Fonts::getScriptFont`, когда скрипт не сопоставлен?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fonts/#getScriptFont) возвращает `null`, когда запрошенное сопоставление скрипта не определено в этой основной или вспомогательной коллекции шрифтов.

**Добавляет ли `Fonts::setScriptFont` второе сопоставление, если скрипт уже существует?**

Нет. [Fonts::setScriptFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fonts/#setScriptFont) создаёт сопоставление, если оно отсутствует, и заменяет существующее семейство шрифтов, когда тег скрипта уже присутствует.

**Почему изменение сопоставления темы не повлияло на некоторый текст?**

Текст мог иметь явно назначенный шрифт, наследовать другую тему через переопределение или подвергаться замене или резервированию во время рендеринга. Сопоставление скрипта уровня презентации управляет только тем текстом, чьё эффективное форматирование всё ещё ссылается на эту коллекцию шрифтов темы.

**Достаточно ли сохранить и заново открыть файл, чтобы проверить многоязычный вывод?**

Нет. Повторное открытие подтверждает лишь сохранность данных темы. Кроме того, необходимо отрендерить представительный текст из каждой требуемой системы письма, чтобы убедиться, что сопоставленные шрифты доступны и содержат необходимые глифы.