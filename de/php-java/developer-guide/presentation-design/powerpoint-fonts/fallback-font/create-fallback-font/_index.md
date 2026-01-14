---
title: Fallback-Schriftarten für Präsentationen in PHP festlegen
linktitle: Fallback-Schriftart
type: docs
weight: 10
url: /de/php-java/create-fallback-font/
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
- PHP
- Aspose.Slides
description: "Meistern Sie Aspose.Slides für PHP über Java, um Fallback-Schriftarten in PPT-, PPTX- und ODP-Dateien festzulegen und eine konsistente Textanzeige auf jedem Gerät oder Betriebssystem zu gewährleisten."
---

## **Fallback-Regeln**

Aspose.Slides unterstützt die Klasse [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule), um die Regeln zum Anwenden einer Fallback-Schriftart festzulegen. [FontFallBackRule]-Klasse stellt eine Zuordnung zwischen dem angegebenen Unicode-Bereich, der zur Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriftarten dar, die die richtigen Glyphen enthalten können:
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Verwenden Sie mehrere Wege, um die Schriftartenliste hinzuzufügen:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


Es ist außerdem möglich, die Fallback-Schriftart zu [remove](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/remove/) oder [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) in ein bestehendes [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule)-Objekt einzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule)-Objekten zu organisieren, wenn es nötig ist, Fallback-Schriftart-Ersetzungsregeln für mehrere Unicode-Bereiche festzulegen.

{{% alert color="primary" title="See also" %}} 
- [Erstellen einer Fallback-Schriftartensammlung](/slides/de/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback-Schriftart, einer Schriftart-Ersetzung und dem Einbetten von Schriftarten?**

Eine Fallback-Schriftart wird nur für Zeichen verwendet, die in der primären Schriftart fehlen. [Font substitution](/slides/de/php-java/font-substitution/) ersetzt die gesamte angegebene Schriftart durch eine andere Schriftart. [Font embedding](/slides/de/php-java/embedded-font/) packt die Schriftarten in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt anzeigen können.

**Werden Fallback-Schriftarten bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmausgabe?**

Ja. Fallback wirkt sich auf alle [Rendering‑ und Exportvorgänge](/slides/de/php-java/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, aber in der Quellschriftart nicht vorhanden sind.

**Ändert die Konfiguration von Fallback die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback-Regeln sind Laufzeit-Renderingeinstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftartenverzeichnisse die Auswahl von Fallback?**

Ja. Die Engine löst Schriftarten aus den verfügbaren Systemordnern und allen von Ihnen angegebenen [zusätzlichen Pfaden](/slides/de/php-java/custom-font/) auf. Wenn eine Schriftart nicht physisch verfügbar ist, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktioniert Fallback für WordArt, SmartArt und Diagramme?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph-Ersetzungsmechanismus verwendet, um fehlende Zeichen darzustellen.