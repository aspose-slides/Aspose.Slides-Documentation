---
title: Fallback-Schriften für Präsentationen auf Android festlegen
linktitle: Fallback-Schriftart
type: docs
weight: 10
url: /de/androidjava/create-fallback-font/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftart anwenden
- Schriftart ersetzen
- Unicode-Bereich
- fehlende Glyphe
- korrekte Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Meistern Sie Aspose.Slides für Android mit Java, um Fallback-Schriften in PPT-, PPTX- und ODP-Dateien festzulegen und eine konsistente Textdarstellung auf jedem Gerät oder Betriebssystem zu gewährleisten."
---

## **Fallback-Regeln**

Aspose.Slides unterstützt das Interface [IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule), um die Regeln zum Anwenden einer Fallback‑Schriftart festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriftarten dar, die die passenden Glyphen enthalten können:
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Es ist außerdem möglich, die Fallback‑Schriftart zu [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) zu entfernen oder [addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einem bestehenden [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule)‑Objekt hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule)-Objekten zu organisieren, wenn es nötig ist, Fallback‑Schriftart‑Ersetzungsregeln für mehrere Unicode‑Bereiche anzugeben.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/de/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback‑Schriftart, einer Schriftart‑Substitution und dem Einbetten von Schriftarten?**

Eine Fallback‑Schriftart wird nur für Zeichen verwendet, die in der primären Schriftart fehlen. [Font substitution](/slides/de/androidjava/font-substitution/) ersetzt die gesamte angegebene Schriftart durch eine andere Schriftart. [Font embedding](/slides/de/androidjava/embedded-font/) verpackt die Schriftarten in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt sehen können.

**Werden Fallback‑Schriftarten bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmausgabe?**

Ja. Fallback wirkt sich auf alle [rendering and export operations](/slides/de/androidjava/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, die jedoch in der Quellschriftart fehlen.

**Verändert die Konfiguration von Fallback die Präsentationsdatei selbst und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Fallbacks?**

Ja. Die Engine löst Schriftarten aus den verfügbaren Systemordnern und allen von Ihnen angegebenen [additional paths](/slides/de/androidjava/custom-font/) auf. Ist eine Schriftart physisch nicht verfügbar, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktioniert Fallback für WordArt, SmartArt und Diagramme?**

Ja. Enthalten diese Objekte Text, wird derselbe Glyph‑Substitutions‑Mechanismus angewendet, um fehlende Zeichen darzustellen.