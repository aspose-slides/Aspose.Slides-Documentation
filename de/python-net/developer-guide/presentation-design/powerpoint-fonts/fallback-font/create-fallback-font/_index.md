---
title: Fallback-Schriftarten für Präsentationen in Python festlegen
linktitle: Fallback-Schriftart
type: docs
weight: 10
url: /de/python-net/create-fallback-font/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftart anwenden
- Schriftart ersetzen
- Unicode-Bereich
- fehlende Glyphe
- passende Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Meistern Sie Aspose.Slides für Python via .NET, um Fallback-Schriftarten in PPT-, PPTX- und ODP-Dateien festzulegen und eine konsistente Textdarstellung auf jedem Gerät oder Betriebssystem zu gewährleisten."
---

## **Fallback-Schriftarten angeben**

Aspose.Slides unterstützt das [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/)‑Interface und die [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)‑Klasse, um die Regeln für die Anwendung einer Fallback‑Schriftart festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriften dar, die die passenden Glyphen enthalten können:
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Verwenden Sie mehrere Möglichkeiten, um eine Schriftliste hinzuzufügen:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```


Es ist außerdem möglich, die Fallback‑Schriftart mit [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) zu entfernen oder mit [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) zu einer vorhandenen [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)‑Instanz hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)‑Objekten zu organisieren, wenn für mehrere Unicode‑Bereiche Fallback‑Schriftart‑Ersetzungsregeln angegeben werden müssen.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/de/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback‑Schriftart, einer Schriftart‑Substitution und dem Einbetten von Schriftarten?**

Eine Fallback‑Schriftart wird nur für Zeichen verwendet, die in der primären Schriftart fehlen. [Font substitution](/slides/de/python-net/font-substitution/) ersetzt die gesamte angegebene Schriftart durch eine andere Schriftart. [Font embedding](/slides/de/python-net/embedded-font/) verpackt die Schriftarten in der Ausgabedatei, sodass Empfänger den Text wie beabsichtigt anzeigen können.

**Werden Fallback‑Schriftarten bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmdarstellung?**

Ja. Fallback beeinflusst alle [rendering and export operations](/slides/de/python-net/convert-presentation/), bei denen Zeichen gezeichnet werden müssen, die in der Quellschriftart nicht vorhanden sind.

**Ändert die Konfiguration von Fallback die Präsentationsdatei selbst und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftarten‑Verzeichnisse die Auswahl des Fallbacks?**

Ja. Die Engine löst Schriftarten aus den verfügbaren Systemordnern und allen von Ihnen angegebenen [additional paths](/slides/de/python-net/custom-font/) auf. Ist eine Schriftart physisch nicht verfügbar, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktioniert Fallback für WordArt, SmartArt und Diagramme?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutions‑Mechanismus angewendet, um fehlende Zeichen darzustellen.