---
title: Créer une police de secours
type: docs
weight: 10
url: /fr/net/create-fallback-font/
keywords: "Polices, police de secours, présentation PowerPoint C#, Csharp, Aspose.Slides pour .NET"
description: "Police de secours dans PowerPoint en C# ou .NET"
---

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher des glyphes manquants, et une liste de polices qui peuvent contenir des glyphes appropriés :

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//En utilisant plusieurs façons, vous pouvez ajouter une liste de polices :
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```



Il est également possible de [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) une police de secours ou [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) peut être utilisé pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule), lorsque cela est nécessaire pour spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/fr/net/create-fallback-fonts-collection/)
{{% /alert %}}