---
title: Fallback‑Schriften für Präsentationen in .NET festlegen
linktitle: Fallback‑Schrift
type: docs
weight: 10
url: /de/net/create-fallback-font/
keywords:
- Fallback‑Schrift
- Fallback‑Regel
- Schrift anwenden
- Schrift ersetzen
- Unicode‑Bereich
- fehlende Glyphe
- richtige Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Beherrschen Sie Aspose.Slides für .NET, um Fallback‑Schriften in PPT-, PPTX‑ und ODP‑Dateien festzulegen und damit eine konsistente Textanzeige auf jedem Gerät oder Betriebssystem zu gewährleisten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Fallback‑Schriften für die Darstellung und den Export von Präsentationen anzugeben. Fallback‑Schriften werden verwendet, wenn die primäre Schrift keine Glyphe für bestimmte Zeichen enthält.

Das Fallback‑Verhalten wird über Fallback‑Regeln konfiguriert. Jede Regel ordnet einen Unicode‑Bereich einem oder mehreren Schriften zu, die die erforderlichen Glyphen enthalten können. Sie können Regeln für verschiedene Zeichenbereiche definieren, Fallback‑Schriften aus bestehenden Regeln hinzufügen oder entfernen und mehrere Regeln in einer Fallback‑Schriftregelsammlung organisieren.

Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen. Sie verändern die Präsentationsdatei selbst nicht und werden nicht im PPTX‑Datei gespeichert.

## **Fallback‑Regeln**

Aspose.Slides unterstützt das Interface [IFontFallBackRule](https://reference.aspose.com/slides/de/net/aspose.slides/iFontFallBackRule) sowie die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/net/aspose.slides/FontFallBackRule). Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/net/aspose.slides/FontFallBackRule) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zur Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriften dar, die die richtigen Glyphen enthalten können:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Mit mehreren Methoden können Sie die Schriftliste hinzufügen:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Es ist außerdem möglich, die Fallback‑Schrift über [Remove()](https://reference.aspose.com/slides/de/net/aspose.slides/ifontfallbackrule/methods/remove) zu entfernen oder über [AddFallBackFonts()](https://reference.aspose.com/slides/de/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) zu einer bestehenden [FontFallBackRule](https://reference.aspose.com/slides/de/net/aspose.slides/FontFallBackRule) Instanz hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/de/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/de/net/aspose.slides/fontfallbackrulescollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/de/net/aspose.slides/FontFallBackRule) Objekten zu organisieren, wenn die Angabe von Fallback‑Schrift‑Ersetzungsregeln für mehrere Unicode‑Bereiche erforderlich ist.

{{% alert color="info" title="Siehe auch" %}} 
- [Erstellen einer Fallback‑Schriftensammlung](/slides/de/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Was ist der Unterschied zwischen einer Fallback‑Schrift, einer Schrift‑substitution und einer Schrift‑einbettung?

Eine Fallback‑Schrift wird nur für Zeichen verwendet, die in der primären Schrift fehlen. [Font substitution](/slides/de/net/font-substitution/) ersetzt die gesamte angegebene Schrift durch eine andere Schrift. [Font embedding](/slides/de/net/embedded-font/) packt die Schriften in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt sehen können.

### Werden Fallback‑Schriften bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Bildschirmdarstellung?

Ja. Fallback wirkt sich auf alle [Rendering- und Exportvorgänge](/slides/de/net/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, aber in der Quellschrift fehlen.

### Ändert das Konfigurieren von Fallback die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?

Nein. Fallback‑Regeln sind Laufzeit‑Rendering‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

### Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Fallback?

Ja. Die Engine löst Schriften aus den verfügbaren Systemordnern und aus allen [zusätzlichen Pfaden](/slides/de/net/custom-font/) auf, die Sie angeben. Ist eine Schrift nicht physisch verfügbar, kann eine Regel, die sie referenziert, nicht wirksam werden.

### Funktioniert Fallback für WordArt, SmartArt und Diagramme?

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyphen‑Substitutions‑Mechanismus verwendet, um fehlende Zeichen darzustellen.