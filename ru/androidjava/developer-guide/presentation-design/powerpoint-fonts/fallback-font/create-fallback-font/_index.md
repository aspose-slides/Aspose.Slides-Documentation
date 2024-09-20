---
title: Создание запасного шрифта
type: docs
weight: 10
url: /androidjava/create-fallback-font/
---

Aspose.Slides поддерживает интерфейс [IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) и класс [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule), чтобы задать правила применения запасного шрифта. Класс [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) представляет собой ассоциацию между указанным диапазоном Unicode, используемым для поиска пропущенных глифов, и списком шрифтов, которые могут содержать необходимые глифы:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Несколько способов добавления списка шрифтов:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Также возможно [удалить](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) запасной шрифт или [добавить запасные шрифты](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) в существующий объект [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) может использоваться для организации списка объектов [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule), когда необходимо задать правила замены запасного шрифта для нескольких диапазонов Unicode.

{{% alert color="primary" title="Смотрите также" %}} 
- [Создание коллекции запасных шрифтов](/slides/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}