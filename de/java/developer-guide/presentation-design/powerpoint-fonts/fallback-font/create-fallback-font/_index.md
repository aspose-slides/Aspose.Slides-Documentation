---
title: Festlegen von Ersatzschriften für Präsentationen in Java
linktitle: Ersatzschrift
type: docs
weight: 10
url: /de/java/create-fallback-font/
keywords:
- Ersatzschrift
- Ersatzregel
- Schrift anwenden
- Schrift ersetzen
- Unicode-Bereich
- fehlende Glyphe
- korrekte Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Meistern Sie Aspose.Slides für Java, um Ersatzschriften in PPT-, PPTX- und ODP-Dateien festzulegen und eine konsistente Textanzeige auf jedem Gerät oder Betriebssystem zu gewährleisten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Ersatzschriften für die Darstellung und den Export von Präsentationen anzugeben. Ersatzschriften werden verwendet, wenn die primäre Schrift die Glyphen für bestimmte Zeichen nicht enthält.

Das Verhalten von Ersatzschriften wird über Ersatzregeln konfiguriert. Jede Regel verknüpft einen Unicode-Bereich mit ein oder mehreren Schriften, die die erforderlichen Glyphen enthalten können. Sie können Regeln für verschiedene Zeichenbereiche definieren, Ersatzschriften zu bestehenden Regeln hinzufügen oder entfernen und mehrere Regeln in einer Sammlung von Ersatzschrift-Regeln organisieren.

Ersatzregeln sind Laufzeit-Rendering-Einstellungen. Sie ändern die Präsentationsdatei selbst nicht und werden nicht in der PPTX-Datei gespeichert.

## **Ersatzregeln**

Aspose.Slides unterstützt das Interface [IFontFallBackRule](https://reference.aspose.com/slides/de/java/com.aspose.slides/IFontFallBackRule) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRule), um die Regeln zur Anwendung einer Ersatzschrift anzugeben. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRule) stellt eine Zuordnung zwischen dem angegebenen Unicode-Bereich, der zur Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriften dar, die die passenden Glyphen enthalten können:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Mit mehreren Methoden können Sie eine Schriftartenliste hinzufügen:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Es ist auch möglich, eine Ersatzschrift zu [remove](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) zu entfernen oder [addFallBackFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einem bestehenden [FontFallBackRule](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRule) Objekt hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRulesCollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontFallBackRule) Objekten zu organisieren, wenn es nötig ist, Ersatzschrift-Ersetzungsregeln für mehrere Unicode-Bereiche anzugeben.

{{% alert color="info" title="Siehe auch" %}} 
- [Erstelle Sammlung von Ersatzschriften](/slides/de/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Was ist der Unterschied zwischen einer Ersatzschrift, einer Schrift‑substitution und dem Einbetten von Schriften?

Eine Ersatzschrift wird nur für Zeichen verwendet, die in der primären Schrift fehlen. [Font substitution](/slides/de/java/font-substitution/) ersetzt die gesamte angegebene Schrift durch eine andere Schrift. [Font embedding](/slides/de/java/embedded-font/) packt die Schriften in die Ausgabedatei, sodass Empfänger den Text wie vorgesehen anzeigen können.

### Werden Ersatzschriften bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmausgabe?

Ja. Ersatzschriften wirken sich auf alle [rendering and export operations](/slides/de/java/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, aber in der Quellschrift fehlen.

### Ändert die Konfiguration von Ersatzschriften die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?

Nein. Ersatzregeln sind Laufzeit-Rendering-Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

### Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Ersatzschriften?

Ja. Die Engine ermittelt Schriften aus den verfügbaren Systemordnern und allen [additional paths](/slides/de/java/custom-font/), die Sie angeben. Ist eine Schrift nicht physisch verfügbar, kann eine Regel, die sie referenziert, nicht wirksam werden.

### Funktionieren Ersatzschriften für WordArt, SmartArt und Diagramme?

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph-Substitutions-Mechanismus verwendet, um fehlende Zeichen darzustellen.