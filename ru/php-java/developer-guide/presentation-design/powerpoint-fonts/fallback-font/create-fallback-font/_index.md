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
description: "Освойте Aspose.Slides для PHP через Java, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая согласованное отображение текста на любом устройстве или ОС."
---

## **Правила резервных шрифтов**

Aspose.Slides поддерживает класс [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) представляет связь между указанным диапазоном Юникода, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать нужные глифы:
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Используя разные способы, вы можете добавить список шрифтов:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


Также возможно [remove](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/remove/) резервный шрифт или [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule), когда необходимо указать правила замены резервных шрифтов для нескольких диапазонов Юникода.

{{% alert color="primary" title="См. также" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Вопросы и ответы**

**В чем разница между резервным шрифтом, заменой шрифта и внедрением шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Замена шрифта](/slides/ru/php-java/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Внедрение шрифта](/slides/ru/php-java/embedded-font/) упаковывает шрифты внутри выходного файла, чтобы получатели могли просматривать текст как задумано.

**Применяются ли резервные шрифты при экспорте, например PDF, PNG или SVG, или только при отображении на экране?**

Да. Резервный шрифт влияет на все [операции рендеринга и экспорта](/slides/ru/php-java/convert-presentation/) где необходимо отрисовать символы, но они отсутствуют в исходном шрифте.

**Изменяет ли настройка резервного шрифта сам файл презентации, и сохранится ли параметр при последующих открытиях?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри файла .pptx и не отображаются в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [дополнительные пути](/slides/ru/php-java/custom-font/) которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может сработать.

**Работает ли резервный шрифт для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм подстановки глифов для отображения недостающих символов.