---
title: Spécifier des polices de secours pour les présentations en Python via Java
linktitle: Police de secours
type: docs
weight: 10
url: /fr/python-java/create-fallback-font/
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
- Python
- Java
- Aspose.Slides
description: "Maîtrisez Aspose.Slides pour Python via Java afin de définir des polices de secours dans les fichiers PPT, PPTX et ODP, garantissant un affichage de texte cohérent sur tout appareil ou système d'exploitation."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de spécifier des polices de secours pour le rendu et les opérations d'exportation des présentations. Les polices de secours sont utilisées lorsque la police principale ne contient pas de glyphes pour certains caractères.

Le comportement de secours est configuré via des règles de secours. Chaque règle associe une plage Unicode à une ou plusieurs polices pouvant contenir les glyphes requis. Vous pouvez définir des règles pour différentes plages de caractères, ajouter ou supprimer des polices de secours des règles existantes, et organiser plusieurs règles dans une collection de règles de polices de secours.

Les règles de secours sont des paramètres de rendu à l'exécution. Elles ne modifient pas le fichier de présentation lui‑même et ne sont pas stockées dans le fichier PPTX.

## **Règles de secours**

Aspose.Slides fournit la classe [FontFallBackRule](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrule/) pour spécifier des règles d'application des polices de secours. Cette classe représente une association entre une plage Unicode utilisée pour rechercher les glyphes manquants et une liste de polices susceptibles de contenir les glyphes requis :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Utilisez plusieurs méthodes pour spécifier une liste de polices.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Vous pouvez également supprimer une police de secours à l'aide de [remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrule/#remove) ou ajouter des polices de secours à l'aide de [addFallBackFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) dans un objet [FontFallBackRule](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrule/) existant.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrulescollection/) peut organiser une liste d'objets [FontFallBackRule](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrule/) lorsque vous devez spécifier des règles de remplacement de polices de secours pour plusieurs plages Unicode.

{{% alert color="info" title="Voir aussi" %}} 
- [Créer une collection de polices de secours](/slides/fr/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre une police de secours, la substitution de police et l'intégration de police ?**

Une police de secours n'est utilisée que pour les caractères manquants dans la police principale. La [substitution de police](/slides/fr/python-java/font-substitution/) remplace l'intégralité de la police spécifiée par une autre police. L'[intégration de police](/slides/fr/python-java/embedded-font/) inclut les polices dans le fichier de sortie afin que les destinataires puissent visualiser le texte tel qu'il est prévu.

**Les polices de secours sont-elles appliquées lors des exportations comme PDF, PNG ou SVG, ou uniquement lors du rendu à l'écran ?**

Oui. Le secours affecte toutes les [opérations de rendu et d'exportation](/slides/fr/python-java/convert-presentation/) où les caractères doivent être dessinés mais sont absents de la police source.

**La configuration du secours modifie-t-elle le fichier de présentation lui‑même, et le réglage persistera-t-il pour les ouvertures futures ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution dans votre code ; elles ne sont pas stockées dans le .pptx et n'apparaîtront pas dans PowerPoint.

**Le système d'exploitation (Windows/Linux/macOS) et l'ensemble des répertoires de polices influencent-ils la sélection du secours ?**

Oui. Le moteur résout les polices à partir des dossiers système disponibles et de tout [chemin supplémentaire](/slides/fr/python-java/custom-font/) que vous fournissez. Si une police n'est pas physiquement disponible, une règle qui la référence ne peut pas prendre effet.

**Le secours fonctionne-t-il pour WordArt, SmartArt et les graphiques ?**

Oui. Lorsque ces objets contiennent du texte, le même mécanisme de substitution de glyphes s'applique pour rendre les caractères manquants.