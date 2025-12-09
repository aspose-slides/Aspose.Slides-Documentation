---
title: Spécifier les polices de secours pour les présentations en Python
linktitle: Police de secours
type: docs
weight: 10
url: /fr/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "Maîtrisez Aspose.Slides pour Python via .NET afin de définir des polices de secours dans les fichiers PPT, PPTX et ODP, garantissant un affichage texte cohérent sur tout appareil ou système d'exploitation."
---

## **Spécifier les polices de secours**

Aspose.Slides prend en charge l'interface [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) et la classe [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) pour spécifier les règles d'application d'une police de secours. La classe [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) représente une association entre la plage Unicode spécifiée, utilisée pour rechercher les glyphes manquants, et une liste de polices pouvant contenir les glyphes appropriés :
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#En utilisant plusieurs méthodes, vous pouvez ajouter une liste de polices :
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```


Il est également possible de [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) la police de secours ou [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) peut être utilisé pour organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/), lorsqu'il faut spécifier des règles de remplacement de police de secours pour plusieurs plages Unicode.

{{% alert color="primary" title="See also" %}} 
- [Créer une collection de polices de secours](/slides/fr/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre une police de secours, une substitution de police et l'incorporation de police ?**

Une police de secours n'est utilisée que pour les caractères manquants dans la police principale. La [substitution de police](/slides/fr/python-net/font-substitution/) remplace toute la police spécifiée par une autre police. L'[incorporation de police](/slides/fr/python-net/embedded-font/) intègre les polices dans le fichier de sortie afin que les destinataires puissent voir le texte tel qu'il est prévu.

**Les polices de secours sont‑elles appliquées lors des exportations comme PDF, PNG ou SVG, ou uniquement lors du rendu à l'écran ?**

Oui. La police de secours affecte toutes les [opérations de rendu et d'exportation](/slides/fr/python-net/convert-presentation/) où des caractères doivent être dessinés mais sont absents de la police source.

**La configuration d'une police de secours modifie‑t‑elle le fichier de présentation lui‑même, et le paramètre persistera‑t‑il lors des ouvertures ultérieures ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution dans votre code ; elles ne sont pas stockées dans le fichier .pptx et n'apparaîtront pas dans PowerPoint.

**Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices influencent‑ils la sélection de la police de secours ?**

Oui. Le moteur résout les polices à partir des dossiers système disponibles et de tout [chemin supplémentaire](/slides/fr/python-net/custom-font/) que vous fournissez. Si une police n'est pas physiquement disponible, une règle la référencant ne peut pas être appliquée.

**La police de secours fonctionne‑t‑elle pour WordArt, SmartArt et les graphiques ?**

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s'applique pour rendre les caractères manquants.