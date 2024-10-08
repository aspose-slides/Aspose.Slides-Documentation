---
title: Erstellen von Fallback-Schriftarten
type: docs
weight: 10
url: /de/python-net/create-fallback-font/
keywords: "Schriftarten, Fallback-Schriftart, PowerPoint-Präsentation Python, Aspose.Slides für Python über .NET"
description: "Fallback-Schriftart in PowerPoint in Python"
---

Aspose.Slides unterstützt das [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) Interface und die [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) Klasse, um die Regeln zur Anwendung einer Fallback-Schriftart festzulegen. Die [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) Klasse stellt eine Assoziation zwischen dem angegebenen Unicode-Bereich, der zur Suche nach fehlenden Glyphen verwendet wird, und einer Liste von Schriftarten dar, die die entsprechenden Glyphen enthalten können:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Auf verschiedene Weise können Sie eine Schriftartenliste hinzufügen:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Es ist auch möglich, die [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) Fallback-Schriftart oder die [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) in ein vorhandenes [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) Objekt hinzuzufügen.

Die [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) kann verwendet werden, um eine Liste von [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) Objekten zu organisieren, wenn es erforderlich ist, Fallback-Schriftartenersatzregeln für mehrere Unicode-Bereiche festzulegen.

{{% alert color="primary" title="Siehe auch" %}} 
- [Fallback-Schriftarten-Sammlung erstellen](/slides/de/python-net/create-fallback-fonts-collection/)
{{% /alert %}}