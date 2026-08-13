---
title: Spécifier des polices de secours pour les présentations en .NET
linktitle: Police de secours
type: docs
weight: 10
url: /fr/net/create-fallback-font/
keywords:
- police de secours
- règle de secours
- appliquer police
- remplacer police
- plage Unicode
- glyphe manquant
- glyphe correct
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez Aspose.Slides pour .NET afin de définir des polices de secours dans les fichiers PPT, PPTX et ODP, garantissant un affichage texte cohérent sur tout appareil ou système d'exploitation."
---
## **Aperçu**

Aspose.Slides vous permet de spécifier des polices de secours pour le rendu et les opérations d'exportation des présentations. Les polices de secours sont utilisées lorsque la police principale ne contient pas de glyphes pour certains caractères.

Le comportement de secours est configuré via des règles de secours. Chaque règle associe une plage Unicode à une ou plusieurs polices pouvant contenir les glyphes requis. Vous pouvez définir des règles pour différentes plages de caractères, ajouter ou supprimer des polices de secours des règles existantes, et organiser plusieurs règles dans une collection de règles de polices de secours.

Les règles de secours sont des paramètres de rendu à l'exécution. Elles ne modifient pas le fichier de présentation lui‑même et ne sont pas stockées dans le fichier PPTX.

## **Règles de secours**

Aspose.Slides prend en charge l’interface [IFontFallBackRule](https://reference.aspose.com/slides/fr/net/aspose.slides/iFontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/fr/net/aspose.slides/FontFallBackRule) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/fr/net/aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices pouvant contenir les glyphes appropriés :

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//En utilisant plusieurs méthodes, vous pouvez ajouter une liste de polices :
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Il est également possible de [Remove()](https://reference.aspose.com/slides/fr/net/aspose.slides/ifontfallbackrule/methods/remove) une police de secours ou d'[AddFallBackFonts()](https://reference.aspose.com/slides/fr/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/fr/net/aspose.slides/FontFallBackRule) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/fr/net/aspose.slides/fontfallbackrulescollection) peut être utilisée pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/fr/net/aspose.slides/FontFallBackRule), lorsqu'il est nécessaire de spécifier des règles de remplacement de polices de secours pour plusieurs plages Unicode.

{{% alert color="info" title="Voir aussi" %}}
- [Créer une collection de polices de secours](/slides/fr/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Quelle est la différence entre une police de secours, la substitution de police et l'intégration de police ?

Une police de secours n’est utilisée que pour les caractères manquants dans la police principale. La [substitution de police](/slides/fr/net/font-substitution/) remplace la police spécifiée entière par une autre police. L’[intégration de police](/slides/fr/net/embedded-font/) intègre les polices dans le fichier de sortie afin que les destinataires puissent afficher le texte tel qu’il est prévu.

### Les polices de secours sont‑elles appliquées lors des exportations comme PDF, PNG ou SVG, ou uniquement lors du rendu à l’écran ?

Oui. La police de secours affecte toutes les [opérations de rendu et d'exportation](/slides/fr/net/convert-presentation/) où des caractères doivent être dessinés mais sont absents de la police source.

### La configuration du secours modifie‑t‑elle le fichier de présentation lui‑même, et le réglage persistera‑t‑il lors des ouvertures futures ?

Non. Les règles de secours sont des paramètres de rendu à l'exécution dans votre code ; elles ne sont pas stockées dans le .pptx et n'apparaîtront pas dans PowerPoint.

### Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices influencent‑ils la sélection du secours ?

Oui. Le moteur résout les polices à partir des dossiers système disponibles et de tout [chemin supplémentaire](/slides/fr/net/custom-font/) que vous fournissez. Si une police n’est pas physiquement disponible, une règle qui la référence ne peut pas être appliquée.

### Le secours fonctionne‑t‑il pour WordArt, SmartArt et les graphiques ?

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s'applique pour rendre les caractères manquants.