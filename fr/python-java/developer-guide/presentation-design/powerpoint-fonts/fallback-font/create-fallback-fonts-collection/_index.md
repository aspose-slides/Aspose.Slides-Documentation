---
title: Configurer des collections de polices de secours en Python via Java
linktitle: Collection de polices de secours
type: docs
weight: 20
url: /fr/python-java/create-fallback-fonts-collection/
keywords:
- police de secours
- règle de secours
- collection de polices
- configurer la police
- mettre en place la police
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Configurez une collection de polices de secours dans Aspose.Slides pour Python via Java afin de maintenir le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de configurer une collection de règles de police de secours pour une présentation. Chaque règle de secours est représentée par la classe [FontFallBackRule](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrule/) et peut être ajoutée à une [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrulescollection/).

Après avoir créé la collection, vous pouvez l'attribuer à l'aide de la méthode [setFontFallBackRulesCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) du [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) de la présentation. Le [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) contrôle les polices dans l'ensemble de la présentation, et chaque instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) possède son propre [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/).

Une fois le [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) initialisé avec la collection de polices de secours, les polices de secours spécifiées sont appliquées lors du rendu de la présentation.

## **Appliquer les règles de secours**

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrule/) peuvent être organisées dans une [FontFallBackRulesCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrulescollection/). Vous pouvez ajouter ou supprimer des règles de la collection.

Cette collection peut ensuite être assignée à l'aide de la méthode [setFontFallBackRulesCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) de la classe [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/), qui contrôle les polices dans l'ensemble de la présentation.

Chaque [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) possède une méthode [getFontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getFontsManager) qui renvoie sa propre instance de la classe [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/).

L'exemple suivant montre comment créer une collection de règles de police de secours et l'attribuer au [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) d'une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Après que le [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) soit initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="info" title="Remarque" %}}
En savoir plus sur la façon de [render a presentation with a fallback font](/slides/fr/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Mes règles de secours seront‑elles intégrées au fichier PPTX et visibles dans PowerPoint après l'enregistrement ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution ; elles ne sont pas sérialisées dans le PPTX et n'apparaîtront pas dans l'interface de PowerPoint.

**La fonction de secours s'applique‑t‑elle au texte à l'intérieur de SmartArt, WordArt, de graphiques et de tableaux ?**

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous ajoutez et utilisez les polices de votre côté, sous votre propre responsabilité.

**Le remplacement/substitution pour les polices manquantes et la fonction de secours pour les glyphes manquants peuvent‑ils être utilisés ensemble ?**

Oui. Elles constituent des étapes indépendantes du même pipeline de résolution des polices : d'abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/python-java/font-replacement/)/[substitution](/slides/fr/python-java/font-substitution/)), puis la fonction de secours comble les lacunes des glyphes manquants dans les polices disponibles.