---
title: Создать шрифт резервирования
type: docs
weight: 10
url: /php-java/create-fallback-font/
---

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) для указания правил применения шрифта резервирования. Класс [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) представляет собой связь между указанным диапазоном Юникода, используемым для поиска недостающих глифов, и списком шрифтов, которые могут содержать соответствующие глифы:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Используя несколько способов, вы можете добавить список шрифтов:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);

```

Также возможно [удалить](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) шрифт резервирования или [добавить шрифты резервирования](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) можно использовать для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule), когда необходимо указать правила замены шрифтов резервирования для нескольких диапазонов Юникода.

{{% alert color="primary" title="Смотрите также" %}} 
- [Создать коллекцию шрифтов резервирования](/slides/php-java/create-fallback-fonts-collection/)
{{% /alert %}}