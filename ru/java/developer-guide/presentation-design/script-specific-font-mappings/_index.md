---
title: Управление тематическими шрифтами, специфичными для скриптов, в Java
linktitle: Тематические шрифты, специфичные для скриптов
type: docs
weight: 15
url: /ru/java/script-specific-font-mappings/
keywords:
- скриптовый шрифт
- сопоставление шрифтов темы
- многоязычная презентация
- система письма
- шрифт кириллицы
- шрифт арабского
- японский шрифт
- грузинский шрифт
- шрифт таана
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Просмотр, добавление, замена и удаление скриптовых сопоставлений шрифтов в темах PowerPoint с помощью Aspose.Slides для Java."
---
## **Обзор**

Тема презентации может выбирать разные гарнитуры шрифтов для разных систем письма. Это позволяет многоязычному тексту, который всё ещё использует шрифты темы, следовать единой согласованной схеме шрифтов, применяя подходящие шрифты для кириллицы, арабского, японского, грузинского, таана и других сценариев.

Тема содержит [IFontScheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontscheme/), в котором есть основная коллекция шрифтов, обычно используемая для заголовков, и вспомогательная коллекция шрифтов, обычно используемая для основного текста. Помимо их параметров для латинского и восточно‑азиатского шрифтов, обе коллекции предоставляют сопоставления от тегов системы письма к названиям гарнитур через интерфейс [IFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifonts/).

В этой статье показано, как просмотреть и изменить эти сопоставления в главной теме презентации и убедиться, что изменения сохраняются после сохранения и повторной загрузки.

## **Понимание тегов скриптов**

Методы работы со скриптовыми шрифтами используют четырёхбуквенные субтеги BCP 47 для идентификации систем письма. Общие значения включают:

| Тег скрипта | Писательная система |
|---|---|
| `Cyrl` | Кириллица |
| `Arab` | Арабский |
| `Hans` | Упрощённый китайский |
| `Jpan` | Японский |
| `Geor` | Грузинский |
| `Thaa` | Таана |

Эти сопоставления относятся к схеме шрифтов темы, а не к отдельным фрагментам текста. Презентация может определять разные сопоставления для основной и вспомогательной коллекций и может не определять сопоставления для некоторых скриптов.

## **Доступ и просмотр сопоставлений скриптовых шрифтов**

Используйте [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getMasterTheme--) для доступа к теме уровня презентации. Методы [IFontScheme.getMajor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontscheme/#getMajor--) и [IFontScheme.getMinor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontscheme/#getMinor--) возвращают две коллекции [IFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifonts/).

Вызовите [IFonts.getScriptFontMap](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fonts/#getScriptFontMap--) для получения всех сопоставлений из коллекции. Чтобы найти конкретную систему письма, вызовите [IFonts.getScriptFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) с её тегом скрипта. `getScriptFont` возвращает `null`, когда в этой коллекции нет запрошенного сопоставления.

## **Изменение сопоставлений и проверка их сохранения**

Используйте [IFonts.setScriptFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) для создания сопоставления или замены текущей гарнитуры. Используйте [IFonts.removeScriptFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) для удаления сопоставления.

Ниже приведён сквозной пример, который считывает все существующие основные и вспомогательные сопоставления, ищет основной шрифт для японского, меняет основной шрифт для кириллицы, удаляет вспомогательное сопоставление для таана, сохраняет презентацию и открывает её снова, чтобы проверить оба изменения. Чтобы шаг удаления был независим от исходной темы, пример сначала создаёт сопоставление для таана только если оно ещё не определено.

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

Проверка использует то же поведение `null`, что и обычный запрос: после сохранения удаления `getScriptFont("Thaa")` возвращает `null` для вспомогательной коллекции.

## **Различие сопоставлений темы и других параметров шрифтов**

Скриптовые сопоставления темы участвуют в выборе шрифта, но решают другую задачу, чем прямое форматирование текста, замена шрифтов и резервирование:

| Механизм | Назначение | Эффект изменения сопоставления темы |
|---|---|---|
| Тематическое сопоставление шрифтов, специфичное для скрипта | Выбирает основной или вспомогательный шрифт темы для системы письма. | Текст, который всё ещё использует соответствующий шрифт темы, может быть сопоставлен с новой гарнитурой. |
| Шрифт, явно назначенный части текста | Фиксирует требуемое семейство шрифтов для этой части, вместо того чтобы полагаться на тему. | Эта часть может остаться неизменной, поскольку её прямое форматирование переопределяет выбор темы. |
| Замена шрифтов | Заменяет запрашиваемый шрифт, когда он недоступен или применимо правило замены. | Она действует после запроса шрифта; не переопределяет скриптовое сопоставление темы. |
| Резервный шрифт | Предоставляет глифы, которых нет в выбранном шрифте, часто для определённых диапазонов Юникода. | Заполняет недостающие глифы; не изменяет сохранённое сопоставление темы. |

Для получения дополнительной информации о последних двух механизмах см. [Font Substitution](/slides/ru/java/font-substitution/) и [Fallback Fonts](/slides/ru/java/fallback-font/).

Изменение сопоставления в [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getMasterTheme--) затрагивает только контент, эффективное форматирование которого всё ещё зависит от этой темы. Текст может наследовать переопределение темы от мастера, макета или слайда, либо использовать явно назначенный шрифт. Проверьте эти уровни, если видимый результат не следует сопоставлению уровня презентации.

## **Обеспечение доступности сопоставленных шрифтов и проверка результата**

Скриптовое сопоставление хранит только название гарнитуры; оно не устанавливает и не загружает сам файл шрифта. Для согласованного рендеринга и экспорта каждый сопоставленный шрифт должен быть установлен в среде или предоставлен Aspose.Slides через пользовательский источник, например [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) или [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Смотрите [Custom Fonts](/slides/ru/java/custom-font/) для доступных вариантов загрузки.

Проверка сохранённого сопоставления подтверждает лишь то, что определение темы было сохранено. Это не доказывает, что шрифт доступен, содержит все необходимые глифы или создаёт ожидаемое расположение. Сгенерируйте представительный текст для каждой требуемой системы письма в виде изображения или PDF и проанализируйте результат. Это выявит отсутствующие шрифты, неполное покрытие глифов, поведение резервирования и изменения макета до распространения презентации. См. [Convert PowerPoint Presentations](/slides/ru/java/convert-powerpoint/) для примеров рендеринга и экспорта.

## **FAQ**

**Что возвращает `getScriptFont`, когда скрипт не сопоставлен?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) возвращает `null`, когда запрошенное скриптовое сопоставление не определено в основной или вспомогательной коллекции шрифтов.

**Добавляет ли `setScriptFont` второе сопоставление, когда скрипт уже существует?**

Нет. [IFonts.setScriptFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) создаёт сопоставление, если его нет, и заменяет гарнитуру, когда тот же тег скрипта уже присутствует.

**Почему изменение сопоставления темы не изменило некоторый текст?**

Текст может иметь явно назначенный шрифт, наследовать другую тему через переопределение или быть затронут заменой или резервированием при рендеринге. Сценарное сопоставление на уровне презентации управляет только тем текстом, эффективность которого всё ещё ссылается на эту коллекцию шрифтов темы.

**Достаточно ли сохранить и открыть файл заново для проверки многоязычного вывода?**

Нет. Повторное открытие проверяет только сохранность данных темы. Также следует отрендерить представительный текст для каждой требуемой системы письма, чтобы убедиться, что сопоставленные шрифты доступны и содержат необходимые глифы.