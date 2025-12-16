---
title: Spécifier les polices de secours pour les présentations sur Android
linktitle: Police de secours
type: docs
weight: 10
url: /fr/androidjava/create-fallback-font/
keywords:
- police de secours
- règle de secours
- appliquer la police
- remplacer la police
- plage Unicode
- glyphe manquant
- glyphe correct
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Maîtrisez Aspose.Slides pour Android via Java pour définir des polices de secours dans les fichiers PPT, PPTX et ODP, garantissant un affichage texte cohérent sur tout appareil ou système d'exploitation."
---

## **Règles de secours**

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices pouvant contenir les glyphes appropriés :
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//En utilisant plusieurs façons, vous pouvez ajouter une liste de polices:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Il est également possible de [supprimer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) la police de secours ou d'[addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) existant.

FontFallBackRulesCollection peut être utilisé pour organiser une liste d'objets FontFallBackRule, lorsqu'il est nécessaire de spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/fr/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre une police de secours, la substitution de police et l'intégration de police ?**

Une police de secours n'est utilisée que pour les caractères manquants dans la police principale. La [substitution de police](/slides/fr/androidjava/font-substitution/) remplace l'intégralité de la police spécifiée par une autre police. L'[intégration de police](/slides/fr/androidjava/embedded-font/) emballe les polices à l'intérieur du fichier de sortie afin que les destinataires puissent visualiser le texte tel qu'il est prévu.

**Les polices de secours sont‑elles appliquées lors des exportations comme PDF, PNG ou SVG, ou uniquement lors du rendu à l'écran ?**

Oui. Le recours à une police de secours affecte toutes les [opérations de rendu et d'exportation](/slides/fr/androidjava/convert-presentation/) où les caractères doivent être dessinés mais sont absents de la police source.

**La configuration d'une police de secours modifie‑t‑elle le fichier de présentation lui‑même, et le réglage persistera‑t‑il lors des ouvertures futures ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution dans votre code ; elles ne sont pas enregistrées dans le .pptx et n'apparaîtront pas dans PowerPoint.

**Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices influencent‑ils la sélection de la police de secours ?**

Oui. Le moteur résout les polices à partir des dossiers système disponibles et de tout [chemin supplémentaire](/slides/fr/androidjava/custom-font/) que vous fournissez. Si une police n'est pas physiquement disponible, une règle qui la référence ne peut pas prendre effet.

**La police de secours fonctionne‑t‑elle pour WordArt, SmartArt et les graphiques ?**

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s'applique pour rendre les caractères manquants.