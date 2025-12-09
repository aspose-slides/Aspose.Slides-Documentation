---
title: Fallback-Schrift erstellen
type: docs
weight: 10
url: /de/nodejs-java/create-fallback-font/
---

## **Fallback-Regeln**

Aspose.Slides unterstützt die Klasse [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) um die Regeln zum Anwenden einer Ersatzschrift festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriften dar, die die richtigen Glyphen enthalten können:
```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Mit mehreren Möglichkeiten können Sie die Schriftliste hinzufügen:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segue UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```


Es ist auch möglich, eine Ersatzschrift zu [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) zu entfernen oder [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) zu einem vorhandenen [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule)-Objekt hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule)-Objekten zu organisieren, wenn Ersatzschrift‑Ersetzungsregeln für mehrere Unicode‑Bereiche angegeben werden müssen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Erstellen einer Fallback-Schriftarten-Sammlung](/slides/de/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Ersatzschrift, Schrift‑substitution und Schrift‑einbettung?**

Eine Ersatzschrift wird nur für Zeichen verwendet, die in der primären Schrift fehlen. [Font substitution](/slides/de/nodejs-java/font-substitution/) ersetzt die gesamte angegebene Schrift durch eine andere Schrift. [Font embedding](/slides/de/nodejs-java/embedded-font/) packt die Schriften in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt sehen können.

**Werden Ersatzschriften bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmausgabe?**

Ja. Ersatzschriften beeinflussen alle [Rendering‑ und Export‑Operationen](/slides/de/nodejs-java/convert-presentation/), bei denen Zeichen gezeichnet werden müssen, die in der Quellschrift fehlen.

**Ändert die Konfiguration von Ersatzschriften die Präsentationsdatei selbst und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Ersatzschriften‑Regeln sind Laufzeit‑Render‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Wirken sich das Betriebssystem (Windows/Linux/macOS) und das Set an Schriftverzeichnissen auf die Auswahl von Ersatzschriften aus?**

Ja. Die Engine löst Schriften aus verfügbaren Systemordnern und allen [zusätzlichen Pfade](/slides/de/nodejs-java/custom-font/) auf, die Sie angeben. Wenn eine Schrift nicht physisch verfügbar ist, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktionieren Ersatzschriften für WordArt, SmartArt und Diagramme?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutions‑Mechanismus verwendet, um fehlende Zeichen darzustellen.