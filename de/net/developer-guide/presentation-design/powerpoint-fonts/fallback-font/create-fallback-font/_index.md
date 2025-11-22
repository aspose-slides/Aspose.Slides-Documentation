---
title: Fallback-Schriftart erstellen
type: docs
weight: 10
url: /de/net/create-fallback-font/
keywords: "Schriften, Fallback-Schriftart, PowerPoint-Präsentation C#, Csharp, Aspose.Slides für .NET"
description: "Fallback-Schriftart in PowerPoint in C# oder .NET"
---

## **Fallback-Regeln**

Aspose.Slides unterstützt die Schnittstelle [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) und die Klasse [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule), um die Regeln zum Anwenden einer Fallback‑Schriftart festzulegen. Die Klasse [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) stellt eine Zuordnung zwischen dem angegebenen Unicode‑Bereich, der zum Suchen fehlender Glyphen verwendet wird, und einer Liste von Schriften dar, die die richtigen Glyphen enthalten können:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Mit mehreren Möglichkeiten können Sie die Schriftartenliste hinzufügen:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Es ist auch möglich, die Fallback‑Schriftart mit [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) zu entfernen oder mit [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) zu einem bestehenden [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)‑Objekt hinzuzufügen.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)‑Objekten zu organisieren, wenn Bedarf besteht, Fallback‑Schriftart‑Ersetzungsregeln für mehrere Unicode‑Bereiche festzulegen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Fallback-Schriftartsammlung erstellen](/slides/de/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einer Fallback‑Schriftart, einer Font‑Substitution und dem Einbetten von Schriftarten?**

Eine Fallback‑Schriftart wird nur für Zeichen verwendet, die in der primären Schriftart fehlen. [Font substitution](/slides/de/net/font-substitution/) ersetzt die gesamte angegebene Schriftart durch eine andere Schriftart. [Font embedding](/slides/de/net/embedded-font/) verpackt die Schriftarten im Ausgabedatei, sodass Empfänger den Text wie beabsichtigt sehen können.

**Werden Fallback‑Schriftarten beim Exportieren, z. B. nach PDF, PNG oder SVG, angewendet oder nur bei der Bildschirmdarstellung?**

Ja. Fallback wirkt sich auf alle [rendering and export operations](/slides/de/net/convert-presentation/) aus, bei denen Zeichen gezeichnet werden müssen, aber in der Quellschriftart fehlen.

**Ändert das Konfigurieren von Fallback die Präsentationsdatei selbst, und bleibt die Einstellung bei zukünftigen Öffnungen erhalten?**

Nein. Fallback‑Regeln sind Laufzeit‑Render‑Einstellungen in Ihrem Code; sie werden nicht in der .pptx gespeichert und erscheinen nicht in PowerPoint.

**Beeinflussen das Betriebssystem (Windows/Linux/macOS) und die Menge der Schriftverzeichnisse die Fallback‑Auswahl?**

Ja. Die Engine löst Schriftarten aus verfügbaren Systemordnern und allen von Ihnen angegebenen [additional paths](/slides/de/net/custom-font/) auf. Wenn eine Schriftart nicht physisch verfügbar ist, kann eine Regel, die sie referenziert, nicht wirksam werden.

**Funktioniert Fallback bei WordArt, SmartArt und Diagrammen?**

Ja. Wenn diese Objekte Text enthalten, wird derselbe Glyph‑Substitutions‑Mechanismus angewendet, um fehlende Zeichen darzustellen.