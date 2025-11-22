---
title: Créer une police de secours
type: docs
weight: 10
url: /fr/net/create-fallback-font/
keywords: "Polices, police de secours, présentation PowerPoint C#, Csharp, Aspose.Slides for .NET"
description: "Police de secours dans PowerPoint en C# ou .NET"
---

## **Règles de secours**

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices pouvant contenir les glyphes appropriés :
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//En utilisant plusieurs façons, vous pouvez ajouter la liste des polices:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```




Il est également possible de [Remove()] la police de secours ou d'[AddFallBackFonts()] dans un objet [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) peut être utilisé pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule), lorsqu'il est nécessaire de spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/fr/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre une police de secours, la substitution de police et l'intégration de police ?**

Une police de secours n'est utilisée que pour les caractères manquants dans la police principale. La [substitution de police](/slides/fr/net/font-substitution/) remplace la police spécifiée entière par une autre police. L'[intégration de police](/slides/fr/net/embedded-font/) regroupe les polices à l'intérieur du fichier de sortie afin que les destinataires puissent voir le texte tel qu'il est prévu.

**Les polices de secours sont‑elles appliquées lors des exportations telles que PDF, PNG ou SVG, ou uniquement lors du rendu à l'écran ?**

Oui. Le secours affecte toutes les [opérations de rendu et d'exportation](/slides/fr/net/convert-presentation/) où les caractères doivent être dessinés mais sont absents dans la police source.

**La configuration du secours modifie‑t‑elle le fichier de présentation lui‑même, et le paramètre persistera‑t‑il lors des ouvertures futures ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution dans votre code ; elles ne sont pas stockées dans le .pptx et n'apparaîtront pas dans PowerPoint.

**Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices affectent‑ils la sélection du secours ?**

Oui. Le moteur résout les polices à partir des dossiers système disponibles et de tout [chemin supplémentaire](/slides/fr/net/custom-font/) que vous fournissez. Si une police n'est pas physiquement disponible, une règle la référencant ne peut pas être appliquée.

**Le secours fonctionne‑t‑il pour WordArt, SmartArt et les graphiques ?**

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s'applique pour rendre les caractères manquants.