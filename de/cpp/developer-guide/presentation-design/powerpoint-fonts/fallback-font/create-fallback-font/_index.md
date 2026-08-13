---
title: Fallback-Schriften für Präsentationen in C++ festlegen
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
- richtige Glyphe
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Meistern Sie Aspose.Slides für C++, um Fallback-Schriften in PPT-, PPTX- und ODP-Dateien festzulegen und eine konsistente Textanzeige auf jedem Gerät oder Betriebssystem zu gewährleisten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Fallback‑Schriften für die Präsentations‑Render‑ und Exportvorgänge festzulegen. Fallback‑Schriften werden verwendet, wenn die primäre Schrift keine Glyphen für bestimmte Zeichen enthält.

Das Fallback‑Verhalten wird über Fallback‑Regeln konfiguriert. Jede Regel verknüpft einen Unicode‑Bereich mit einer oder mehreren Schriften, die die erforderlichen Glyphen enthalten könnten. Sie können Regeln für verschiedene Zeichenbereiche definieren, Fallback‑Schriften zu bestehenden Regeln hinzufügen oder entfernen und mehrere Regeln in einer Fallback‑Schrift‑Regelsammlung organisieren.

Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen. Sie verändern die Präsentationsdatei selbst nicht und werden nicht im PPTX‑File gespeichert.

## **Fallback‑Regeln**

Aspose.Slides unterstützt das Interface [IFontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontfallbackrule/) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/), um die Regeln für die Anwendung einer Fallback‑Schrift festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zur Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriften dar, die die passenden Glyphen enthalten können:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Es ist außerdem möglich, eine Fallback‑Schrift mit [Remove()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontfallbackrule/remove/) zu entfernen oder mit [AddFallBackFonts()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) zu einer bestehenden [FontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/)‑Instanz hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrulescollection/) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/)‑Objekten zu organisieren, wenn es nötig ist, Fallback‑Schrift‑Ersetzungsregeln für mehrere Unicode‑Bereiche festzulegen.

{{% alert color="info" title="Siehe auch" %}} 
- [Fallback‑Schrift‑Sammlung erstellen](/slides/de/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Was ist der Unterschied zwischen einer Fallback‑Schrift, einer Schrift‑Substitution und dem Einbetten von Schriften?

Eine Fallback‑Schrift wird nur für Zeichen verwendet, die in der primären Schrift fehlen. [Font substitution](/slides/de/cpp/font-substitution/) ersetzt die gesamte angegebene Schrift durch eine andere Schrift. [Font embedding](/slides/de/cpp/embedded-font/) bündelt die Schriften im Ausgabedokument, sodass Empfänger den Text wie beabsichtigt anzeigen können.

### Werden Fallback‑Schriften bei Exporten wie PDF, PNG oder SVG angewendet oder nur beim Rendern auf dem Bildschirm?

Ja. Fallback beeinflusst alle [rendering and export operations](/slides/de/cpp/convert-presentation/), bei denen Zeichen gezeichnet werden müssen, die jedoch in der Ausgangsschrift fehlen.

### Ändert die Konfiguration von Fallback die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

### Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Auswahl von Fallback?

Ja. Die Engine löst Schriften aus den verfügbaren Systemordnern und allen von Ihnen angegebenen [additional paths](/slides/de/cpp/custom-font/) auf. Wenn eine Schrift nicht physisch verfügbar ist, kann eine Regel, die sie referenziert, nicht wirksam werden.

### Funktioniert Fallback für WordArt, SmartArt und Diagramme?

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyphen‑Substitutions‑Mechanismus verwendet, um fehlende Zeichen zu rendern.