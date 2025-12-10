---
title: Указание резервных шрифтов для презентаций в Java
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/java/create-fallback-font/
keywords:
- резервный шрифт
- правило резервного шрифта
- применение шрифта
- замена шрифта
- диапазон Unicode
- пропущенный глиф
- правильный глиф
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Освойте Aspose.Slides для Java, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая постоянное отображение текста на любом устройстве или ОС."
---

## **Правила резервных шрифтов**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) представляет связь между указанным диапазоном Unicode, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать нужные глифы:
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Также можно [remove](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) резервный шрифт или [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule), когда требуется указать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/ru/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Часто задаваемые вопросы**

**В чем разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Font substitution](/slides/ru/java/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Font embedding](/slides/ru/java/embedded-font/) упаковывает шрифты внутрь выходного файла, чтобы получатели могли увидеть текст как задумано.

**Применяются ли резервные шрифты при экспорте, таком как PDF, PNG или SVG, или только при визуализации на экране?**

Да. Резервные шрифты влияют на все [rendering and export operations](/slides/ru/java/convert-presentation/), где необходимо отрисовать символы, но они отсутствуют в исходном шрифте.

**Изменит ли настройка резервных шрифтов сам файл презентации и сохранится ли она при последующих открытиях?**

Нет. Правила резервных шрифтов – это настройки рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не появляются в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [additional paths](/slides/ru/java/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может быть применено.

**Работает ли резервный шрифт для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм подстановки глифов для отображения отсутствующих символов.