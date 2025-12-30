---
title: Указание резервных шрифтов для презентаций в PHP
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/php-java/create-fallback-font/
keywords:
- резервный шрифт
- правило резервного шрифта
- применить шрифт
- заменить шрифт
- диапазон Unicode
- отсутствующий глиф
- правильный глиф
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Освойте Aspose.Slides для PHP через Java, чтобы задать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая согласованное отображение текста на любом устройстве или ОС."
---

## **Правила резервных шрифтов**

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) представляет собой связь между указанным диапазоном Unicode, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать нужные глифы:
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Используя несколько способов, вы можете добавить список шрифтов:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


Также возможно [remove](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) резервный шрифт или [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) в уже существующий объект [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule), когда необходимо задать правила замены резервных шрифтов для нескольких диапазонов Unicode.

{{% alert color="primary" title="См. также" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Вопросы и ответы**

**What is the difference between a fallback font, font substitution, and font embedding?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Font substitution](/slides/ru/php-java/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Font embedding](/slides/ru/php-java/embedded-font/) упаковывает шрифты в выходной файл, чтобы получатели могли просматривать текст как задумано.

**Are fallback fonts applied during exports like PDF, PNG, or SVG, or only on-screen rendering?**

Да. Резервные шрифты влияют на все [rendering and export operations](/slides/ru/php-java/convert-presentation/), где символы должны быть отрисованы, но отсутствуют в исходном шрифте.

**Does configuring fallback change the presentation file itself, and will the setting persist for future openings?**

Нет. Правила резервных шрифтов – это настройки рендеринга во время выполнения в вашем коде; они не сохраняются в файле .pptx и не появляются в PowerPoint.

**Does the operating system (Windows/Linux/macOS) and the set of font directories affect fallback selection?**

Да. Движок ищет шрифты в доступных системных папках и любых [additional paths](/slides/ru/php-java/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

**Does fallback work for WordArt, SmartArt, and charts?**

Да. Когда эти объекты содержат текст, применяется тот же механизм подстановки глифов для отображения отсутствующих символов.