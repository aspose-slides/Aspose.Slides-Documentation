---
title: Spécifier les polices de repli pour les présentations en Java
linktitle: Police de repli
type: docs
weight: 10
url: /fr/java/create-fallback-font/
keywords:
- police de repli
- règle de repli
- appliquer police
- remplacer police
- plage Unicode
- glyphe manquant
- glyphe approprié
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Maîtrisez Aspose.Slides for Java pour définir les polices de repli dans les fichiers PPT, PPTX et ODP, garantissant un affichage de texte cohérent sur tout appareil ou système d'exploitation."
---

## **Règles de repli**

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) pour spécifier les règles d'application d'une police de repli. La classe [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices susceptibles de contenir les glyphes appropriés :
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Utilisation de plusieurs façons d'ajouter une liste de polices:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


Il est également possible de [remove](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) la police de repli ou [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) existant.

La classe [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) peut être utilisée pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule), lorsqu'il est nécessaire de spécifier des règles de remplacement de police de repli pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Create Fallback Fonts Collection](/slides/fr/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre une police de repli, une substitution de police et une intégration de police ?**

Une police de repli n'est utilisée que pour les caractères manquants dans la police principale. La [substitution de police](/slides/fr/java/font-substitution/) remplace la police spécifiée entière par une autre police. L'[intégration de police](/slides/fr/java/embedded-font/) regroupe les polices à l'intérieur du fichier de sortie afin que les destinataires puissent afficher le texte tel qu'il était prévu.

**Les polices de repli sont‑elles appliquées lors des exportations comme PDF, PNG ou SVG, ou uniquement lors du rendu à l'écran ?**

Oui. Le repli affecte toutes les [opérations de rendu et d'exportation](/slides/fr/java/convert-presentation/) où les caractères doivent être dessinés mais sont absents de la police source.

**La configuration du repli modifie‑t‑elle le fichier de présentation lui‑même, et le paramètre persistera‑t‑il lors des ouvertures futures ?**

Non. Les règles de repli sont des paramètres de rendu d'exécution dans votre code ; elles ne sont pas enregistrées dans le fichier .pptx et n’apparaîtront pas dans PowerPoint.

**Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices influent‑ils sur la sélection du repli ?**

Oui. Le moteur résout les polices à partir des dossiers système disponibles ainsi que de tout [chemin supplémentaire](/slides/fr/java/custom-font/) que vous fournissez. Si une police n’est pas physiquement disponible, une règle qui la référence ne peut pas être appliquée.

**Le repli fonctionne‑t‑il pour WordArt, SmartArt et les graphiques ?**

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s’applique pour rendre les caractères manquants.