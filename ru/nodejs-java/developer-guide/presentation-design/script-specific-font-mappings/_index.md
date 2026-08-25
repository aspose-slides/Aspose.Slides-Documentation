---
title: Управление шрифтами темы, специфичными для скриптов, в JavaScript
linktitle: Шрифты темы, специфичные для скрипта
type: docs
weight: 15
url: /ru/nodejs-java/script-specific-font-mappings/
keywords:
- шрифт, специфичный для скрипта
- отображение шрифтов темы
- многоязычная презентация
- система письма
- кириллический шрифт
- арабский шрифт
- японский шрифт
- грузинский шрифт
- шрифт таана
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Изучайте, добавляйте, заменяйте и удаляйте отображения шрифтов, специфичных для скриптов, в темах PowerPoint с помощью Aspose.Slides для Node.js."
---
## **Обзор**

Тема презентации может выбирать разные семейства шрифтов для разных систем письма. Это позволяет использовать многоязычный текст, который всё еще использует шрифты темы, следуя единообразной схеме шрифтов, при этом подбирая подходящие шрифты для кириллицы, арабского, японского, грузинского, таана и других систем.

Тема содержит объект [FontScheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontscheme/), в котором есть основной набор шрифтов, обычно используемый для заголовков, и вспомогательный набор, обычно используемый для основного текста. Помимо их настроек для латиницы и восточноазиатских шрифтов, обе коллекции предоставляют отображения от тегов системы письма к именам семейств шрифтов через класс [Fonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fonts/).

В этой статье показано, как просматривать и изменять эти отображения в мастер‑теме презентации и проверять, что изменения сохраняются после сохранения и повторной загрузки.

## **Понимание тегов скриптов**

Методы шрифтов скриптов используют четырёхбуквенные субтеги BCP 47 для идентификации систем письма. Распространённые значения:

| Тег скрипта | Система письма |
|---|---|
| `Cyrl` | Кириллица |
| `Arab` | Арабский |
| `Hans` | Упрощённый китайский |
| `Jpan` | Японский |
| `Geor` | Грузинский |
| `Thaa` | Таана |

Эти отображения относятся к схеме шрифтов темы, а не к отдельным фрагментам текста. Презентация может определить разные отображения для основных и вспомогательных наборов и может не задавать их для некоторых скриптов.

## **Доступ и просмотр отображений шрифтов скриптов**

Используйте [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getmastertheme/) для получения темы уровня презентации. Методы [FontScheme.getMajor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontscheme/) и [FontScheme.getMinor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontscheme/) возвращают два коллектива [Fonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fonts/).

Вызовите [Fonts.getScriptFontMap](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fonts/) для получения всех отображений из коллекции. Чтобы найти шрифт конкретной системы письма, вызовите [Fonts.getScriptFont](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fonts/) с его тегом. `getScriptFont` возвращает `null`, когда в этой коллекции нет запрашиваемого отображения.

## **Изменение отображений и проверка их сохранения**

Используйте [Fonts.setScriptFont](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fonts/) для создания нового отображения или замены текущего семейства шрифтов. Для удаления отображения используйте [Fonts.removeScriptFont](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fonts/).

Ниже приведён полный пример, который читает все существующие основные и вспомогательные отображения, ищет основной японский шрифт, меняет основной кириллический шрифт, удаляет вспомогательное отображение таана, сохраняет презентацию и открывает её вновь для проверки обоих изменений. Чтобы шаг удаления был независим от исходной темы, пример сначала создаёт отображение таана только если оно ещё не определено.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Проверка использует то же поведение `null`, что и обычный поиск: после сохранения удаления вызов `getScriptFont("Thaa")` возвращает `null` для вспомогательной коллекции.

## **Различие отображений темы от остальных настроек шрифтов**

Отображения темы, специфичные для скрипта, участвуют в выборе шрифта, но решают другую задачу, чем прямое форматирование текста, подстановка и резервирование:

| Механизм | Назначение | Эффект изменения сопоставления темы |
|---|---|---|
| Отображение шрифта темы, специфичное для скрипта | Выбирает основной или вспомогательный шрифт темы для системы письма. | Текст, продолжающий использовать соответствующий шрифт темы, может быть перенаправлен к новому семейству. |
| Шрифт, явно назначенный фрагменту текста | Фиксирует запрошенное семейство шрифтов для данного фрагмента, не полагаясь на тему. | Фрагмент может остаться неизменным, поскольку его прямое форматирование переопределяет выбор темы. |
| Подстановка шрифтов | Заменяет запрошенный шрифт, когда он недоступен или применяется правило подстановки. | Выполняется после запроса шрифта; не переопределяет отображение скрипта в теме. |
| Резервирование шрифтов | Предоставляет глифы, которых нет в выбранном шрифте, часто для конкретных диапазонов Unicode. | Заполняет недостающие глифы; не меняет сохранённое отображение темы. |

Для получения дополнительной информации о последних двух механизмах см. [Font Substitution](/slides/ru/nodejs-java/font-substitution/) и [Fallback Fonts](/slides/ru/nodejs-java/fallback-font/).

Изменение отображения через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getmastertheme/) влияет только на содержимое, чьё эффективное форматирование всё ещё зависит от этой темы. Текст может наследовать переопределение темы от мастера, макета или слайда, либо использовать явно назначенный шрифт. Проверьте эти уровни, когда видимый результат не соответствует отображению уровня презентации.

## **Доступность отображённых шрифтов и проверка результата**

Отображение скрипта хранит только имя семейства шрифта; оно не устанавливает и не загружает сам файл шрифта. Для согласованного рендеринга и экспорта каждый отображённый шрифт должен быть установлен в окружении или передан Aspose.Slides через пользовательский источник, например [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) или [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/). Смотрите раздел [Custom Fonts](/slides/ru/nodejs-java/custom-font/) для доступных вариантов загрузки.

Проверка сохранённого отображения подтверждает лишь то, что определение темы было сохранено. Она не доказывает, что шрифт доступен, содержит все необходимые глифы или даёт ожидаемую разметку. Отрендерите представительный текст для каждой требуемой системы письма в изображение или PDF и проанализируйте результат. Это позволит выявить отсутствующие шрифты, неполное покрытие глифов, поведение резервирования и изменения разметки до распространения презентации. См. [Convert PowerPoint Presentations](/slides/ru/nodejs-java/convert-powerpoint/) для примеров рендеринга и экспорта.

## **FAQ**

**Что возвращает `getScriptFont`, когда скрипт не сопоставлен?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fonts/) возвращает `null`, когда запрошенное отображение скрипта не определено в основной или вспомогательной коллекции шрифтов.

**Добавляет ли `setScriptFont` второе отображение, если скрипт уже существует?**

Нет. [Fonts.setScriptFont](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fonts/) создаёт отображение, если оно отсутствует, и заменяет семейство шрифтов, когда тот же тег скрипта уже присутствует.

**Почему изменение отображения темы не изменило некоторый текст?**

Текст мог иметь явно назначенный шрифт, наследовать другую тему через переопределение или быть затронут подстановкой или резервированием при рендеринге. Отображение скрипта уровня презентации контролирует только тот текст, чьё эффективное форматирование ещё ссылается на эту коллекцию шрифтов темы.

**Достаточно ли сохранить и открыть файл заново для проверки многоязычного вывода?**

Нет. Повторное открытие подтверждает только сохранность данных темы. Также необходимо отрендерить представительный текст из каждой требуемой системы письма, чтобы убедиться, что отображённые шрифты доступны и содержат необходимые глифы.