---
title: Fallback-Schriftarten für Präsentationen in C++
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
- C++
- Aspose.Slides
description: "Meistern Sie Aspose.Slides für C++, um Fallback-Schriftarten in PPT-, PPTX- und ODP-Dateien festzulegen, damit die Textdarstellung auf jedem Gerät oder Betriebssystem konsistent bleibt."
---

## **Fallback-Regeln**

Aspose.Slides unterstützt die Schnittstelle [IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) zum Festlegen der Regeln, die eine Fallback‑Schriftart anwenden. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriftarten dar, die passende Glyphen enthalten können:
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Auf verschiedene Arten können Sie die Schriftartenliste hinzufügen:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


Es ist auch möglich, die Fallback‑Schriftart mit [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) zu entfernen oder mit [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) zu einem bestehenden [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)‑Objekt hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)-Objekten zu organisieren, wenn es nötig ist, Fallback‑Schriftart‑Ersetzungsregeln für mehrere Unicode‑Bereiche festzulegen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Create Fallback Fonts Collection](/slides/de/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback‑Schriftart, einer Schriftart‑Substitution und dem Einbetten von Schriftarten?**

Eine Fallback‑Schriftart wird nur für Zeichen verwendet, die in der primären Schriftart fehlen. [Schriftart-Substitution](/slides/de/cpp/font-substitution/) ersetzt die gesamte angegebene Schriftart durch eine andere Schriftart. [Schriftart‑Einbettung](/slides/de/cpp/embedded-font/) packt die Schriftarten in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt anzeigen können.

**Werden Fallback‑Schriftarten bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmausgabe?**

Ja. Fallback wirkt sich auf alle [Render‑ und Exportvorgänge](/slides/de/cpp/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, die jedoch in der Quellschriftart nicht vorhanden sind.

**Ändert die Konfiguration von Fallback‑Regeln die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Fallback‑Schriftarten?**

Ja. Die Engine ermittelt Schriftarten aus den verfügbaren Systemordnern und allen [zusätzlichen Pfaden](/slides/de/cpp/custom-font/), die Sie angeben. Ist eine Schriftart nicht physisch verfügbar, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktioniert Fallback bei WordArt, SmartArt und Diagrammen?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutions‑Mechanismus verwendet, um fehlende Zeichen darzustellen.