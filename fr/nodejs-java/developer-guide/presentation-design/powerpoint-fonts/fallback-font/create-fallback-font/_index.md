---
title: Créer une police de secours
type: docs
weight: 10
url: /fr/nodejs-java/create-fallback-font/
---

## **Règles de police de secours**

Aspose.Slides prend en charge la classe [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices pouvant contenir les glyphes appropriés :
```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// En utilisant plusieurs méthodes, vous pouvez ajouter une liste de polices :
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```


Il est également possible de [supprimer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) la police de secours ou d'[addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) peut être utilisé pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule), lorsqu'il est nécessaire de spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="See also" %}} 
- [Créer une collection de polices de secours](/slides/fr/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre une police de secours, la substitution de police et l'intégration de police ?**

Une police de secours n'est utilisée que pour les caractères manquants dans la police principale. La [substitution de police](/slides/fr/nodejs-java/font-substitution/) remplace la police spécifiée entière par une autre police. L'[intégration de police](/slides/fr/nodejs-java/embedded-font/) emballe les polices à l'intérieur du fichier de sortie afin que les destinataires puissent visualiser le texte tel qu'il est prévu.

**Les polices de secours sont-elles appliquées lors des exportations comme PDF, PNG ou SVG, ou uniquement lors du rendu à l'écran ?**

Oui. La police de secours affecte toutes les [opérations de rendu et d'exportation](/slides/fr/nodejs-java/convert-presentation/) où les caractères doivent être dessinés mais sont absents de la police source.

**La configuration de la police de secours modifie-t-elle le fichier de présentation lui-même, et le paramètre persistera-t-il lors des ouvertures futures ?**

Non. Les règles de police de secours sont des paramètres de rendu à l'exécution dans votre code ; elles ne sont pas enregistrées dans le .pptx et n'apparaissent pas dans PowerPoint.

**Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices influencent-ils la sélection de la police de secours ?**

Oui. Le moteur résout les polices à partir des dossiers système disponibles et de tout [chemin supplémentaire](/slides/fr/nodejs-java/custom-font/) que vous fournissez. Si une police n'est pas physiquement disponible, une règle y faisant référence ne peut pas être appliquée.

**La police de secours fonctionne-t-elle pour WordArt, SmartArt et les graphiques ?**

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s'applique pour rendre les caractères manquants.