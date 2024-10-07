---
title: Fallback-Schriftart erstellen
type: docs
weight: 10
url: /androidjava/create-fallback-font/
---

Aspose.Slides unterstützt das [IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) Interface und die [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) Klasse, um die Regeln für die Anwendung einer Fallback-Schriftart festzulegen. Die [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) Klasse stellt eine Zuordnung zwischen dem angegebenen Unicode-Bereich dar, der zur Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriftarten, die passende Glyphen enthalten können:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Auf mehreren Wegen können Sie eine Liste von Schriftarten hinzufügen:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Es ist auch möglich, eine Fallback-Schriftart [zu entfernen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) oder [FallBackFonts hinzuzufügen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einem vorhandenen [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) Objekt.

Die [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) Objekten zu organisieren, wenn es notwendig ist, Fallback-Schriftart-Ersetzungsregeln für mehrere Unicode-Bereiche festzulegen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Fallback-Schriftarten-Kollektion erstellen](/slides/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}