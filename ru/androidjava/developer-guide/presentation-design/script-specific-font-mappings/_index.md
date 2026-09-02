---
title: Управление шрифтами темы, специфичными для скрипта, на Android
linktitle: Шрифты темы, специфичные для скрипта
type: docs
weight: 15
url: /ru/androidjava/script-specific-font-mappings/
keywords:
- шрифт, специфичный для скрипта
- сопоставление шрифтов темы
- многоязычная презентация
- система письма
- кириллический шрифт
- арабский шрифт
- японский шрифт
- грузинский шрифт
- таана шрифт
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Просмотр, добавление, замена и удаление сопоставлений шрифтов, специфичных для скрипта, в темах PowerPoint с Aspose.Slides для Android через Java."
---
## **Обзор**

Тема презентации может выбирать разные семейства шрифтов для разных систем письма. Это позволяет многократно языковый текст, который по‑прежнему использует шрифты темы, следовать единой согласованной схеме шрифтов, используя подходящие шрифты для кириллицы, арабского, японского, грузинского, таана и других письменностей.

Тема содержит объект [IFontScheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontscheme/), который включает основную коллекцию шрифтов, обычно используемую для заголовков, и вспомогательную коллекцию шрифтов, обычно используемую для основного текста. Помимо их настроек латинских и восточно‑азиатских шрифтов, обе коллекции предоставляют сопоставления от тегов систем письма к названиям семейств шрифтов через интерфейс [IFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifonts/).

В этой статье показано, как просмотреть и изменить эти сопоставления в основной теме презентации и проверить, что изменения сохраняются после сохранения и повторного открытия.

## **Понимание тегов скриптов**

Методы работы со шрифтами скриптов используют четырёхбуквенные субтеги BCP 47 для идентификации систем письма. Распространённые значения включают:

| Тег скрипта | Система письма |
|---|---|
| `Cyrl` | Кириллица |
| `Arab` | Арабский |
| `Hans` | Упрощённый китайский |
| `Jpan` | Японский |
| `Geor` | Грузинский |
| `Thaa` | Тана |

Эти сопоставления относятся к схеме шрифтов темы, а не к отдельным фрагментам текста. Презентация может определять разные сопоставления для основной и вспомогательной коллекций и может опускать сопоставления для некоторых скриптов.

## **Доступ и проверка сопоставлений шрифтов скриптов**

Используйте [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getMasterTheme--) для доступа к теме уровня презентации. Методы [IFontScheme.getMajor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontscheme/#getMajor--) и [IFontScheme.getMinor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontscheme/#getMinor--) возвращают две коллекции [IFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifonts/).

Вызовите [IFonts.getScriptFontMap](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) для получения всех сопоставлений из коллекции. Чтобы найти шрифт для одной системы письма, вызовите [IFonts.getScriptFont](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) с её тегом скрипта. `getScriptFont` возвращает `null`, когда в этой коллекции не определено запрошенное сопоставление.

## **Изменение сопоставлений и проверка их сохранения**

Используйте [IFonts.setScriptFont](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) для создания сопоставления или замены текущего семейства шрифтов. Используйте [IFonts.removeScriptFont](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) для удаления сопоставления.

В следующем сквозном примере читаются все существующие основные и вспомогательные сопоставления, ищется основной японский шрифт, меняется основной кириллический шрифт, удаляется вспомогательное сопоставление таана, презентация сохраняется и открывается заново для проверки обоих изменений. Чтобы шаг удаления был независим от начальной темы, пример сначала создаёт сопоставление таана только если оно ещё не определено.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Проверка использует то же поведение `null`, что и обычный поиск: после сохранения удаления `getScriptFont("Thaa")` возвращает `null` для вспомогательной коллекции.

## **Различие сопоставлений темы от других параметров шрифтов**

Сопоставления темы, специфичные для скрипта, участвуют в выборе шрифта, но решают другую задачу, отличную от прямого форматирования текста, подстановки и резервных шрифтов:

| Механизм | Назначение | Эффект изменения сопоставления темы |
|---|---|---|
| Тема‑специфичное сопоставление шрифтов скрипта | Выбирает основной или вспомогательный шрифт темы для системы письма. | Текст, который продолжает использовать соответствующий шрифт темы, может переключиться на новое сопоставленное семейство. |
| Шрифт, явно назначенный части текста | Фиксирует требуемое семейство шрифтов в этой части, вместо того чтобы полагаться на тему. | Эта часть может остаться неизменной, поскольку её прямое форматирование переопределяет выбор темы. |
| Подстановка шрифтов | Заменяет запрошенный шрифт, когда он недоступен или применяется правило подстановки. | Она срабатывает после запроса шрифта; не переопределяет скриптовое сопоставление темы. |
| Запасные шрифты | Предоставляет глифы, которых нет в выбранном шрифте, часто для определённых диапазонов Unicode. | Заполняет недостающие глифы; не меняет сохранённое сопоставление темы. |

Для получения дополнительной информации о последних двух механизмах см. [Font Substitution](/slides/ru/androidjava/font-substitution/) и [Fallback Fonts](/slides/ru/androidjava/fallback-font/).

Изменение сопоставления в [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getMasterTheme--) влияет только на контент, эффективное форматирование которого всё ещё зависит от этой темы. Текст может вместо этого наследовать переопределение темы от мастера, макета или слайда, либо использовать явно назначенный шрифт. Проверьте эти уровни, когда видимый результат не соответствует сопоставлению уровня презентации.

## **Обеспечение доступности сопоставленных шрифтов и проверка результата**

Сопоставление скрипта хранит название семейства шрифта; оно не устанавливает и не загружает соответствующий файл шрифта. Для согласованного рендеринга и экспорта каждый сопоставленный шрифт должен быть установлен в окружении или передан Aspose.Slides через пользовательский источник, такой как [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) или [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). См. [Custom Fonts](/slides/ru/androidjava/custom-font/) для доступных вариантов загрузки.

Проверка сохранённого сопоставления подтверждает только то, что определение темы было сохранено. Это не доказывает, что шрифт доступен, содержит все необходимые глифы или обеспечивает задуманную разметку. Сгенерируйте характерный текст для каждой требуемой системы письма в виде изображения или PDF и проверьте результат. Это позволяет выявить отсутствующие шрифты, неполное покрытие глифов, поведение запасных шрифтов и изменения разметки до распространения презентации. См. [Convert PowerPoint Presentations](/slides/ru/androidjava/convert-powerpoint/) для примеров рендеринга и экспорта.

## **FAQ**

**Что возвращает `getScriptFont`, когда скрипт не сопоставлен?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) возвращает `null`, когда запрошенное сопоставление скрипта не определено в основной или вспомогательной коллекции шрифтов.

**Добавляет ли `setScriptFont` второе сопоставление, если скрипт уже существует?**

Нет. [IFonts.setScriptFont](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) создаёт сопоставление, когда его нет, и заменяет сопоставленное семейство шрифтов, если тег скрипта уже присутствует.

**Почему изменение сопоставления темы не изменило некоторый текст?**

Текст может иметь явно назначенный шрифт, наследовать другую тему через переопределение, либо быть затронут подстановкой или резервным шрифтом во время рендеринга. Скриптовое сопоставление уровня презентации управляет только тем текстом, чей эффективный формат всё ещё ссылается на эту коллекцию шрифтов темы.

**Достаточно ли сохранить и открыть файл заново для проверки многоязычного вывода?**

Нет. Повторное открытие проверяет только сохранность данных темы. Кроме того, необходимо отрендерить характерный текст для каждой требуемой системы письма, чтобы подтвердить, что сопоставленные шрифты доступны и содержат необходимые глифы.