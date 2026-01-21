---
title: Fallback-Schriftarten für Präsentationen in С++ festlegen
linktitle: Fallback-Schriftart
type: docs
weight: 10
url: /de/cpp/create-fallback-font/
keywords:
- Fallback-Schriftart
- Fallback-Regel
- Schriftart anwenden
- Schriftart ersetzen
- Unicode-Bereich
- fehlende Glyphe
- richtige Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- С++
- Aspose.Slides
description: "Meistern Sie Aspose.Slides für С++, um Fallback-Schriftarten in PPT-, PPTX- und ODP-Dateien festzulegen und eine konsistente Textdarstellung auf jedem Gerät oder Betriebssystem sicherzustellen."
---

## **Fallback-Regeln**

Aspose.Slides unterstützt das Interface [IFontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/), um die Regeln zum Anwenden einer Fallback‑Schriftart festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der für die Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriftarten dar, die die richtigen Glyphen enthalten könnten:
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Mehrere Wege können Sie benutzen, um die Schriftartenliste hinzuzufügen:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


Es ist außerdem möglich, die Fallback‑Schriftart mit [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/remove/) zu entfernen oder mit [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) zu einem bestehenden [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/)‑Objekt hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/)‑Objekten zu organisieren, wenn es nötig ist, Fallback‑Schriftart‑Ersetzungsregeln für mehrere Unicode‑Bereiche festzulegen.

{{% alert color="primary" title="See also" %}} 
- [Erstelle Fallback‑Schriftartensammlung](/slides/de/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback‑Schriftart, einer Schriftart‑Substitution und dem Einbetten von Schriftarten?**

Eine Fallback‑Schriftart wird nur für Zeichen verwendet, die in der primären Schriftart fehlen. [Font substitution](/slides/de/cpp/font-substitution/) ersetzt die gesamte angegebene Schriftart durch eine andere Schriftart. [Font embedding](/slides/de/cpp/embedded-font/) packt die Schriftarten in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt anzeigen können.

**Werden Fallback‑Schriftarten bei Exporten wie PDF, PNG oder SVG angewendet oder nur beim Rendern auf dem Bildschirm?**

Ja. Fallback wirkt sich auf alle [Render‑ und Export‑Operationen](/slides/de/cpp/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, aber in der Quellschriftart fehlen.

**Ändert die Konfiguration von Fallback die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflusst das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftordner die Auswahl der Fallback‑Schriftart?**

Ja. Die Engine löst Schriftarten aus den verfügbaren Systemordnern und allen [zusätzlichen Pfaden](/slides/de/cpp/custom-font/) auf, die Sie angeben. Wenn eine Schriftart physisch nicht verfügbar ist, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktioniert Fallback für WordArt, SmartArt und Diagramme?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutionsmechanismus verwendet, um fehlende Zeichen darzustellen.