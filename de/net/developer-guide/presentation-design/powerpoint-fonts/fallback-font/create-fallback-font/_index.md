---
title: Fallback-Schriftart erstellen
type: docs
weight: 10
url: /net/create-fallback-font/
keywords: "Schriftarten, Fallback-Schriftart, PowerPoint-Präsentation C#, Csharp, Aspose.Slides für .NET"
description: "Fallback-Schriftart in PowerPoint in C# oder .NET"
---

Aspose.Slides unterstützt die [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) Schnittstelle und die [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) Klasse, um die Regeln für die Anwendung einer Fallback-Schriftart festzulegen. Die [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) Klasse stellt eine Zuordnung zwischen dem angegebenen Unicode-Bereich, der zur Suche nach fehlenden Glyphe verwendet wird, und einer Liste von Schriftarten dar, die die richtigen Glyphe enthalten können:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Auf verschiedene Weisen können Sie eine Liste von Schriftarten hinzufügen:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Es ist auch möglich, die [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) Fallback-Schriftart zu entfernen oder [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) in ein vorhandenes [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) Objekt hinzuzufügen.

Die [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) Objekten zu organisieren, wenn es notwendig ist, Regeln für den Fallback-Schriftersatz für mehrere Unicode-Bereiche festzulegen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Fallback-Schriftarten-Kollektion erstellen](/slides/net/create-fallback-fonts-collection/)
{{% /alert %}}