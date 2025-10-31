---
title: Fallback-Schriften für Präsentationen in Python angeben
linktitle: Fallback-Schriftart
type: docs
weight: 10
url: /de/python-net/create-fallback-font/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftart anwenden
- Schriftart ersetzen
- Unicode‑Bereich
- fehlendes Glyph
- korrektes Glyph
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python via .NET Fallback-Schriftarten in PPT-, PPTX- und ODP-Dateien festlegen, um eine konsistente Textdarstellung auf jedem Gerät oder Betriebssystem sicherzustellen."
---

## **Fallback-Schriften angeben**

Aspose.Slides unterstützt das Interface [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/), um die Regeln zum Anwenden einer Fallback-Schriftart festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriftarten dar, die die richtigen Glyphen enthalten können:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Mit mehreren Methoden können Sie die Schriftliste hinzufügen:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Es ist außerdem möglich, die Fallback‑Schriftart mittels [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) zu entfernen oder mit [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) zu einer bestehenden [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)-Instanz hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)-Objekten zu organisieren, wenn mehrere Unicode‑Bereiche mit jeweiligen Fallback‑Schriftart‑Ersetzungsregeln spezifiziert werden müssen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Fallback-Schriftartensammlung erstellen](/slides/de/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback‑Schriftart, Schriftart‑Ersetzung und Schriftart‑Einbettung?**

Eine Fallback‑Schriftart wird nur für Zeichen verwendet, die in der Hauptschriftart fehlen. [Schriftart‑Ersetzung](/slides/de/python-net/font-substitution/) ersetzt die gesamte angegebene Schriftart durch eine andere. [Schriftart‑Einbettung](/slides/de/python-net/embedded-font/) packt die Schriftarten in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt anzeigen können.

**Werden Fallback‑Schriftarten bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmausgabe?**

Ja. Fallback wirkt sich auf alle [Render‑ und Export‑Operationen](/slides/de/python-net/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, die in der Quellschriftart nicht vorhanden sind.

**Ändert das Konfigurieren von Fallback die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftarten‑Verzeichnisse die Auswahl der Fallback‑Schriftart?**

Ja. Die Engine löst Schriftarten aus den verfügbaren Systemordnern und allen von Ihnen angegebenen [zusätzlichen Pfaden](/slides/de/python-net/custom-font/) auf. Wenn eine Schriftart physisch nicht verfügbar ist, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktioniert Fallback für WordArt, SmartArt und Diagramme?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Ersetzungs‑Mechanismus angewendet, um fehlende Zeichen darzustellen.