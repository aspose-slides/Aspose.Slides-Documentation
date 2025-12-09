---
title: Festlegen von Fallback-Schriften für Präsentationen in .NET
linktitle: Fallback-Schrift
type: docs
weight: 10
url: /de/net/create-fallback-font/
keywords:
- Fallback-Schrift
- Fallback-Regel
- Schrift anwenden
- Schrift ersetzen
- Unicode-Bereich
- fehlende Glyphe
- richtige Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Beherrschen Sie Aspose.Slides für .NET, um Fallback-Schriften in PPT-, PPTX- und ODP-Dateien festzulegen und eine konsistente Textanzeige auf jedem Gerät oder Betriebssystem zu gewährleisten."
---

## **Fallback-Regeln**

Aspose.Slides unterstützt das Interface [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule), um die Regeln zum Anwenden einer Fallback‑Schrift festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriftarten dar, die die richtigen Glyphen enthalten können:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Mehrere Möglichkeiten, um eine Schriftartenliste hinzuzufügen:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Es ist auch möglich, die Fallback‑Schrift mit [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) zu entfernen oder mit [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) zu bestehenden [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)‑Objekten hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)‑Objekten zu organisieren, wenn es nötig ist, Fallback‑Schrift‑Ersetzungsregeln für mehrere Unicode‑Bereiche anzugeben.

{{% alert color="primary" title="See also" %}} 
- [Fallback‑Schrift‑Sammlung erstellen](/slides/de/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback‑Schrift, Schrift‑substitution und Schrift‑einbettung?**

Eine Fallback‑Schrift wird nur für Zeichen verwendet, die in der primären Schrift fehlen. [Schrift‑substitution](/slides/de/net/font-substitution/) ersetzt die gesamte angegebene Schrift durch eine andere Schrift. [Schrift‑einbettung](/slides/de/net/embedded-font/) bettet die Schriften in die Ausgabedatei ein, sodass Empfänger den Text wie beabsichtigt sehen können.

**Werden Fallback‑Schriften bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmausgabe?**

Ja. Fallback wirkt sich auf alle [Rendering‑ und Export‑Operationen](/slides/de/net/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, die in der Quellschrift fehlen.

**Ändert die Konfiguration von Fallback die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Fallbacks?**

Ja. Die Engine löst Schriften aus den verfügbaren Systemordnern und allen [Zusätzliche Pfade](/slides/de/net/custom-font/) auf, die Sie angeben. Ist eine Schrift nicht physisch verfügbar, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktioniert Fallback bei WordArt, SmartArt und Diagrammen?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutions‑Mechanismus verwendet, um fehlende Zeichen darzustellen.