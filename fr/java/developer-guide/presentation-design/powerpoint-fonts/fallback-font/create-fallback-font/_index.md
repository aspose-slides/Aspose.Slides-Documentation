---
title: Spécifier les polices de secours pour les présentations en Java
linktitle: Police de secours
type: docs
weight: 10
url: /fr/java/create-fallback-font/
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
- Java
- Aspose.Slides
description: "Maîtrisez Aspose.Slides pour Java afin de définir des polices de secours dans les fichiers PPT, PPTX et ODP, garantissant un affichage de texte cohérent sur tout appareil ou système d'exploitation."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de spécifier des polices de secours pour le rendu et les opérations d'exportation des présentations. Les polices de secours sont utilisées lorsque la police principale ne contient pas de glyphes pour certains caractères.

Le comportement de secours est configuré via des règles de secours. Chaque règle associe une plage Unicode à une ou plusieurs polices pouvant contenir les glyphes requis. Vous pouvez définir des règles pour différentes plages de caractères, ajouter ou supprimer des polices de secours des règles existantes, et organiser plusieurs règles dans une collection de règles de polices de secours.

Les règles de secours sont des paramètres de rendu à l'exécution. Elles ne modifient pas le fichier de présentation lui‑même et ne sont pas stockées dans le fichier PPTX.

## **Règles de secours**

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IFontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRule) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices pouvant contenir les glyphes appropriés :

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Utilisez plusieurs façons d'ajouter une liste de polices:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Il est également possible de [supprimer](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) une police de secours ou d'[addFallBackFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRule) existant.

La classe [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRulesCollection) peut être utilisée pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontFallBackRule), lorsqu'il est nécessaire de spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="info" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/fr/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Quelle est la différence entre une police de secours, la substitution de police et l'incorporation de police ?

Une police de secours n'est utilisée que pour les caractères manquants dans la police principale. La [substitution de police](/slides/fr/java/font-substitution/) remplace l'intégralité de la police spécifiée par une autre police. L'[incorporation de police](/slides/fr/java/embedded-font/) intègre les polices dans le fichier de sortie afin que les destinataires puissent visualiser le texte tel qu'il est prévu.

### Les polices de secours sont‑elles appliquées lors des exportations telles que PDF, PNG ou SVG, ou uniquement lors du rendu à l'écran ?

Oui. La fonction de secours affecte toutes les [opérations de rendu et d'exportation](/slides/fr/java/convert-presentation/) où des caractères doivent être dessinés mais sont absents de la police source.

### La configuration du secours modifie‑t‑elle le fichier de présentation lui‑même, et le paramètre persistera‑t‑il lors des ouvertures futures ?

Non. Les règles de secours sont des paramètres de rendu à l'exécution dans votre code ; elles ne sont pas stockées dans le .pptx et n’apparaîtront pas dans PowerPoint.

### Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices influent‑ils sur la sélection du secours ?

Oui. Le moteur recherche les polices dans les dossiers système disponibles ainsi que dans les [chemins supplémentaires](/slides/fr/java/custom-font/) que vous fournissez. Si une police n’est pas physiquement disponible, une règle la référençant ne peut pas être appliquée.

### Le secours fonctionne‑t‑il pour WordArt, SmartArt et les graphiques ?

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s’applique pour rendre les caractères manquants.