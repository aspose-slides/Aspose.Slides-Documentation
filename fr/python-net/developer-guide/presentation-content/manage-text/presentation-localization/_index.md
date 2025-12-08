---
title: Automatiser la localisation des présentations avec Python
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/python-net/presentation-localization/
keywords:
- modifier la langue
- vérification orthographique
- identifiant de langue
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Automatisez la localisation des diapositives PowerPoint et OpenDocument en Python avec Aspose.Slides, en utilisant des exemples de code pratiques et des astuces pour un déploiement mondial plus rapide."
---

## **Modifier la langue pour la présentation et le texte de la forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Rectangle à la diapositive.
- Ajouter du texte au TextFrame.
- Définir l’ID de langue du texte.
- Enregistrer la présentation au format PPTX.

L'implémentation des étapes ci‑dessus est illustrée ci‑dessous dans un exemple.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Est‑ce que language_id déclenche une traduction automatique du texte ?**

Non. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) dans Aspose.Slides stocke la langue pour la vérification orthographique et grammaticale, mais ne traduit pas le texte ni ne le modifie. Il s'agit de métadonnées que PowerPoint comprend pour la révision.

**language_id affecte‑t‑il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) est destiné à la révision. La qualité de la césure et le retour à la ligne dépendent principalement de la disponibilité des [polices appropriées](/slides/fr/python-net/powerpoint-fonts/) et des paramètres de mise en page/retour à la ligne pour le système d'écriture. Pour garantir un rendu correct, assurez‑vous que les polices requises sont disponibles, configurez les [règles de substitution de polices](/slides/fr/python-net/font-substitution/), et/ou [intégrez les polices](/slides/fr/python-net/embedded-font/) dans la présentation.

**Puis‑je définir différentes langues dans un même paragraphe ?**

Oui. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) est appliqué au niveau de la portion de texte, de sorte qu'un même paragraphe peut contenir plusieurs langues avec des paramètres de révision distincts.