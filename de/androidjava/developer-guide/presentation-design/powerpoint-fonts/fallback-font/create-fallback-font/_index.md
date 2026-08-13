---
title: Fallback-Schriften für Präsentationen auf Android festlegen
linktitle: Ersatzschrift
type: docs
weight: 10
url: /de/androidjava/create-fallback-font/
keywords:
- Ersatzschrift
- Ersatzregel
- Schrift anwenden
- Schrift ersetzen
- Unicode-Bereich
- fehlende Glyphe
- richtige Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Meistern Sie Aspose.Slides für Android via Java, um Ersatzschriften in PPT-, PPTX- und ODP-Dateien festzulegen und damit eine konsistente Textdarstellung auf jedem Gerät oder Betriebssystem zu gewährleisten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Ersatzschriften für die Darstellung und den Export von Präsentationen anzugeben. Ersatzschriften werden verwendet, wenn die primäre Schrift die Glyphen für bestimmte Zeichen nicht enthält.

Das Verhalten von Ersatzschriften wird über Ersatzregeln konfiguriert. Jede Regel verknüpft einen Unicode-Bereich mit einer oder mehreren Schriften, die die erforderlichen Glyphen enthalten können. Sie können Regeln für verschiedene Zeichenbereiche definieren, Ersatzschriften zu bestehenden Regeln hinzufügen oder entfernen und mehrere Regeln in einer Sammlung von Ersatzschrift-Regeln organisieren.

Ersatzregeln sind Laufzeit-Rendering-Einstellungen. Sie ändern die Präsentationsdatei selbst nicht und werden nicht in der PPTX-Datei gespeichert.

## **Ersatzregeln**

Aspose.Slides unterstützt das Interface [IFontFallBackRule](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IFontFallBackRule) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRule), um die Regeln zum Anwenden einer Ersatzschrift festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRule) stellt eine Zuordnung zwischen dem angegebenen Unicode-Bereich, der zur Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriften dar, die die passenden Glyphen enthalten können:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Verwenden Sie mehrere Möglichkeiten, um die Schriftliste hinzuzufügen:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Es ist außerdem möglich, eine Ersatzschrift zu [remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) zu entfernen oder [addFallBackFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einem bestehenden [FontFallBackRule](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRule)-Objekt hinzuzufügen.

Die Klasse [FontFallBackRulesCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRulesCollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontFallBackRule)-Objekten zu organisieren, wenn Ersatzschrift-Ersetzungsregeln für mehrere Unicode-Bereiche angegeben werden müssen.

{{% alert color="info" title="Siehe auch" %}} 
- [Erstellen einer Ersatzschrift-Sammlung](/slides/de/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Was ist der Unterschied zwischen einer Ersatzschrift, Schrift‑substitution und Schrift‑einbettung?

Eine Ersatzschrift wird nur für Zeichen verwendet, die in der primären Schrift fehlen. [Font substitution](/slides/de/androidjava/font-substitution/) ersetzt die gesamte angegebene Schrift durch eine andere Schrift. [Font embedding](/slides/de/androidjava/embedded-font/) packt die Schriften in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt sehen können.

### Werden Ersatzschriften bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmausgabe?

Ja. Ersatzschriften wirken sich auf alle [Render- und Exportvorgänge](/slides/de/androidjava/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, die jedoch in der Quellschrift fehlen.

### Ändert die Konfiguration von Ersatzschriften die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen bestehen?

Nein. Ersatzregeln sind Laufzeit-Rendering-Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

### Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftordner die Auswahl von Ersatzschriften?

Ja. Die Engine ermittelt Schriften aus den verfügbaren Systemordnern und allen [zusätzlichen Pfaden](/slides/de/androidjava/custom-font/), die Sie angeben. Wenn eine Schrift nicht physisch verfügbar ist, kann eine Regel, die sie referenziert, nicht wirksam werden.

### Funktionieren Ersatzschriften für WordArt, SmartArt und Diagramme?

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutions‑Mechanismus angewendet, um fehlende Zeichen darzustellen.