---
title: Указание резервных шрифтов для презентаций на Android
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
- недостающий глиф
- нужный глиф
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Освойте Aspose.Slides для Android на Java, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая одинаковое отображение текста на любом устройстве или ОС."
---

## **Правила резервных шрифтов**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule), позволяющие задавать правила применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) представляет собой связь между указанным диапазоном Unicode, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать нужные глифы:
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Также возможно [удалить](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) резервный шрифт или [addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) может использоваться для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule), когда необходимо задать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="See also" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **Часто задаваемые вопросы**

**В чём разница между резервным шрифтом, подстановкой шрифта и встраиванием шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Подстановка шрифтов](/slides/ru/androidjava/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Встраивание шрифтов](/slides/ru/androidjava/embedded-font/) упаковывает шрифты внутрь выходного файла, чтобы получатели могли просматривать текст как задумано.

**Применяются ли резервные шрифты при экспорте, например, в PDF, PNG или SVG, или только при отображении на экране?**

Да. Резервные шрифты влияют на все [операции рендеринга и экспорта](/slides/ru/androidjava/convert-presentation/), где необходимо отрисовать символы, отсутствующие в исходном шрифте.

**Изменяет ли настройка резервных шрифтов сам файл презентации и будет ли настройка сохраняться при последующих открытиях?**

Нет. Правила резервных шрифтов — это настройки рендеринга во время выполнения в вашем коде; они не сохраняются внутри файла .pptx и не отображаются в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [дополнительных путях](/slides/ru/androidjava/custom-font/), которые вы предоставляете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

**Работают ли резервные шрифты для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм подстановки глифов для отображения отсутствующих символов.