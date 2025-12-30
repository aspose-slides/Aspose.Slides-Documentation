---
title: "Spécifier les polices de secours pour les présentations en PHP"
linktitle: "Police de secours"
type: docs
weight: 10
url: /fr/php-java/create-fallback-font/
keywords:
- "police de secours"
- "règle de secours"
- "appliquer la police"
- "remplacer la police"
- "plage Unicode"
- "glyphe manquant"
- "glyphe correct"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "PHP"
- "Aspose.Slides"
description: "Maîtrisez Aspose.Slides pour PHP via Java afin de définir des polices de secours dans les fichiers PPT, PPTX et ODP, garantissant un affichage cohérent du texte sur tout appareil ou système d’exploitation."
---

## **Règles de secours**

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) et la classe [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices qui peuvent contenir les glyphes appropriés :

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Utilisation de plusieurs méthodes pour ajouter une liste de polices:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


Il est également possible de [remove](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) la police de secours ou [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) peut être utilisé pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule), lorsqu'il faut spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/fr/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre une police de secours, une substitution de police et une incorporation de police ?**

Une police de secours n'est utilisée que pour les caractères manquants dans la police principale. [Font substitution](/slides/fr/php-java/font-substitution/) remplace la police spécifiée entière par une autre police. [Font embedding](/slides/fr/php-java/embedded-font/) regroupe les polices à l'intérieur du fichier de sortie afin que les destinataires puissent voir le texte comme prévu.

**Les polices de secours sont‑elles appliquées lors des exportations comme PDF, PNG ou SVG, ou uniquement lors du rendu à l'écran ?**

Oui. La police de secours affecte toutes les [rendering and export operations](/slides/fr/php-java/convert-presentation/) où les caractères doivent être dessinés mais sont absents de la police source.

**La configuration de la police de secours modifie‑t‑elle le fichier de présentation lui‑même, et le réglage persistera‑t‑il lors des ouvertures futures ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution dans votre code ; elles ne sont pas enregistrées dans le .pptx et n’apparaîtront pas dans PowerPoint.

**Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices influencent‑ils la sélection de la police de secours ?**

Oui. Le moteur résout les polices à partir des dossiers système disponibles et de tout [additional paths](/slides/fr/php-java/custom-font/) que vous fournissez. Si une police n’est pas physiquement disponible, une règle qui y fait référence ne peut pas être appliquée.

**La police de secours fonctionne‑t‑elle pour WordArt, SmartArt et les graphiques ?**

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s’applique pour rendre les caractères manquants.