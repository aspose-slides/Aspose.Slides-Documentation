---
title: Укажите резервные шрифты для презентаций на Android
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/androidjava/create-fallback-font/
keywords:
- резервный шрифт
- правило резервного шрифта
- применить шрифт
- заменить шрифт
- диапазон Unicode
- отсутствующий глиф
- нужный глиф
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Овладейте Aspose.Slides для Android на Java, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая единообразное отображение текста на любом устройстве или ОС."
---
## **Обзор**

Aspose.Slides позволяет задавать резервные шрифты для рендеринга презентаций и операций экспорта. Резервные шрифты используются, когда основной шрифт не содержит глифов для определённых символов.

Поведение резервных шрифтов настраивается с помощью правил резервирования. Каждое правило связывает диапазон Unicode с одним или несколькими шрифтами, которые могут содержать требуемые глифы. Вы можете определять правила для разных диапазонов символов, добавлять или удалять резервные шрифты из существующих правил и организовывать несколько правил в коллекцию правил резервных шрифтов.

Правила резервных шрифтов являются настройками рендеринга во время выполнения. Они не изменяют сам файл презентации и не сохраняются внутри файла PPTX.

## **Правила резервных шрифтов**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRule) представляет связь между указанным диапазоном Unicode, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать нужные глифы:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Используя различные способы, вы можете добавить список шрифтов:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Также возможно [remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) резервный шрифт или [addFallBackFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRulesCollection) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRule), когда требуется задать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="info" title="См. также" %}} 
- [Create Fallback Fonts Collection](/slides/ru/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **Часто задаваемые вопросы**

### В чём разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Font substitution](/slides/ru/androidjava/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Font embedding](/slides/ru/androidjava/embedded-font/) упаковывает шрифты внутрь выходного файла, чтобы получатели могли видеть текст так, как задумано.

### Применяются ли резервные шрифты при экспорте в PDF, PNG или SVG, или только при визуализации на экране?

Да. Резервирование влияет на все [rendering and export operations](/slides/ru/androidjava/convert-presentation/), где необходимо отрисовать символы, но они отсутствуют в исходном шрифте.

### Изменяет ли конфигурация резервных шрифтов сам файл презентации и сохраняются ли настройки при последующих открытиях?

Нет. Правила резервных шрифтов являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не отображаются в PowerPoint.

### Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?

Да. Движок ищет шрифты в доступных системных папках и любых [additional paths](/slides/ru/androidjava/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не сможет сработать.

### Работает ли резервирование для WordArt, SmartArt и диаграмм?

Да. Когда эти объекты содержат текст, применяется тот же механизм подстановки глифов для рендеринга отсутствующих символов.