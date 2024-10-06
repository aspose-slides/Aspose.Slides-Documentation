---
title: Créer une police de secours
type: docs
weight: 10
url: /python-net/create-fallback-font/
keywords: "Polices, police de secours, présentation PowerPoint Python, Aspose.Slides pour Python via .NET"
description: "Police de secours dans PowerPoint en Python"
---

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) et la classe [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher des glyphes manquants, et une liste de polices pouvant contenir des glyphes appropriés :

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#En utilisant plusieurs méthodes, vous pouvez ajouter une liste de polices :
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```



Il est également possible de [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) une police de secours ou [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) à un objet [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) peut être utilisée pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/), lorsqu'il est nécessaire de spécifier des règles de remplacement de polices de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/python-net/create-fallback-fonts-collection/)
{{% /alert %}}