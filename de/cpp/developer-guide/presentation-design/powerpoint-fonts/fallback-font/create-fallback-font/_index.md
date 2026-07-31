---
title: Festlegen von Fallback-Schriften für Präsentationen in C++
linktitle: Fallback-Schrift
type: docs
weight: 10
url: /de/cpp/create-fallback-font/
keywords:
- Fallback-Schrift
- Fallback-Regel
- Schrift anwenden
- Schrift ersetzen
- Unicode-Bereich
- fehlende Glyphe
- korrekte Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Beherrschen Sie Aspose.Slides für C++, um Fallback-Schriften in PPT-, PPTX- und ODP-Dateien festzulegen und eine konsistente Textanzeige auf jedem Gerät oder Betriebssystem zu gewährleisten."
---
## **Übersicht**

Aspose.Slides ermöglicht das Angeben von Ersatzschriften für die Darstellung und den Export von Präsentationen. Ersatzschriften werden verwendet, wenn die primäre Schrift keine Glyphen für bestimmte Zeichen enthält.

Das Verhalten von Ersatzschriften wird über Ersatzregeln konfiguriert. Jede Regel verknüpft einen Unicode-Bereich mit einer oder mehreren Schriften, die die erforderlichen Glyphen enthalten können. Sie können Regeln für verschiedene Zeichenbereiche definieren, Ersatzschriften zu bestehenden Regeln hinzufügen oder entfernen und mehrere Regeln in einer Sammlung von Ersatzschrift-Regeln organisieren.

Ersatzregeln sind Laufzeit-Render-Einstellungen. Sie verändern die Präsentationsdatei selbst nicht und werden nicht im PPTX-Datei gespeichert.

## **Ersatzregeln**

Aspose.Slides unterstützt das Interface [IFontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontfallbackrule/) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/), um die Regeln für die Anwendung einer Ersatzschrift anzugeben. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/) stellt eine Zuordnung zwischen dem angegebenen Unicode-Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriften dar, die die richtigen Glyphen enthalten können:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Auf verschiedene Arten können Sie die Schriftliste hinzufügen:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Es ist außerdem möglich, eine Ersatzschrift mit [Remove()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontfallbackrule/remove/) zu entfernen oder mit [AddFallBackFonts()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) zu einer bestehenden [FontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/)-Instanz hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrulescollection/) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/)-Objekten zu organisieren, wenn Ersatzschrift-Ersetzungsregeln für mehrere Unicode-Bereiche angegeben werden müssen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Erstellen einer Ersatzschriftensammlung](/slides/de/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Ersatzschrift, Schrift­substitution und Schrift­einbettung?**

Eine Ersatzschrift wird nur für Zeichen verwendet, die in der primären Schrift fehlen. [Font substitution](/slides/de/cpp/font-substitution/) ersetzt die gesamte angegebene Schrift durch eine andere Schrift. [Font embedding](/slides/de/cpp/embedded-font/) packt die Schriften in die Ausgabedatei, sodass Empfänger den Text wie beabsichtigt anzeigen können.

**Werden Ersatzschriften bei Exporten wie PDF, PNG oder SVG angewendet oder nur bei der Anzeige auf dem Bildschirm?**

Ja. Ersatzschriften beeinflussen alle [Render- und Exportvorgänge](/slides/de/cpp/convert-presentation/), bei denen Zeichen gezeichnet werden müssen, aber in der Ausgangsschrift fehlen.

**Ändert das Konfigurieren von Ersatzschriften die Präsentationsdatei selbst und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Ersatzregeln sind Laufzeit-Render-Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Ersatzschriften?**

Ja. Die Engine ermittelt Schriften aus den verfügbaren Systemordnern sowie aus allen [zusätzlichen Pfaden](/slides/de/cpp/custom-font/), die Sie angeben. Ist eine Schrift nicht physisch verfügbar, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktionieren Ersatzschriften für WordArt, SmartArt und Diagramme?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyphen‑Substitutions‑Mechanismus angewendet, um fehlende Zeichen darzustellen.