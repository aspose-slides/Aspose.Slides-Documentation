---
title: Erstellen von Fallback-Schriftarten
type: docs
weight: 10
url: /de/php-java/create-fallback-font/
---

Aspose.Slides unterstützt das [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) Interface und die [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) Klasse, um die Regeln für die Anwendung einer Fallback-Schriftart festzulegen. Die [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) Klasse stellt eine Zuordnung zwischen dem angegebenen Unicode-Bereich, der zur Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriftarten dar, die die richtigen Glyphen enthalten können:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Auf mehrere Arten können Sie eine Schriftartenliste hinzufügen:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial");
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Es ist auch möglich, die Fallback-Schriftart [zu entfernen](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) oder [Fallback-Schriftarten hinzuzufügen](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) in ein bestehendes [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) Objekt.

Die [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) Objekten zu organisieren, wenn es erforderlich ist, Fallback-Schriftartenersetzungsregeln für mehrere Unicode-Bereiche festzulegen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Erstellen von Fallback-Schriftarten-Sammlungen](/slides/de/php-java/create-fallback-fonts-collection/)
{{% /alert %}}