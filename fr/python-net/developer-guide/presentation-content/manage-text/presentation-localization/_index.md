---
title: Automatiser la localisation des présentations avec Python
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/python-net/presentation-localization/
keywords:
- changer la langue
- vérification orthographique
- identifiant de langue
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Automatisez la localisation des diapositives PowerPoint et OpenDocument en Python avec Aspose.Slides, en utilisant des exemples de code pratiques et des conseils pour un déploiement mondial plus rapide."
---

## **Modifier la langue de la présentation et du texte de la forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenir la référence d’une diapositive en utilisant son index.
- Ajouter une AutoShape de type Rectangle à la diapositive.
- Ajouter du texte au TextFrame.
- Définir l’identifiant de langue du texte.
- Enregistrer la présentation au format PPTX.

The implementation of the above steps is demonstrated below in an example.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**L’identifiant de langue (language_id) déclenche-t-il une traduction automatique du texte ?**

Non. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) dans Aspose.Slides stocke la langue pour la vérification orthographique et la correction grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. Il s’agit de métadonnées que PowerPoint comprend pour la révision.

**L’identifiant de langue (language_id) affecte-t-il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) sert à la révision. La qualité de la césure et le retour à la ligne dépendent principalement de la disponibilité des [polices appropriées](/slides/fr/python-net/powerpoint-fonts/) ainsi que des paramètres de mise en page/coupure de ligne pour le système d’écriture. Pour garantir un rendu correct, assurez la disponibilité des polices requises, configurez les [règles de substitution de polices](/slides/fr/python-net/font-substitution/) et/ou [intégrez les polices](/slides/fr/python-net/embedded-font/) dans la présentation.

**Puis-je définir différentes langues dans un même paragraphe ?**

Oui. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) est appliqué au niveau de la portion de texte, de sorte qu’un même paragraphe peut contenir plusieurs langues avec des paramètres de révision distincts.