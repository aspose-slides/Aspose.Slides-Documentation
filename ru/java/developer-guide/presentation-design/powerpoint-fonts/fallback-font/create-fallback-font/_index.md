---
title: Создание резервного шрифта
type: docs
weight: 10
url: /ru/java/create-fallback-font/
---

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) для указания правил применения резервного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) представляет собой ассоциацию между указанным диапазоном символов Unicode, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать необходимые глифы:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Используя несколько способов, вы можете добавить список шрифтов:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Также возможно [удалить](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) резервный шрифт или [добавить резервные шрифты](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) может использоваться для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule), когда необходимо указать правила замены резервного шрифта для нескольких диапазонов Unicode.

{{% alert color="primary" title="Смотрите также" %}} 
- [Создание коллекции резервных шрифтов](/slides/ru/java/create-fallback-fonts-collection/)
{{% /alert %}}