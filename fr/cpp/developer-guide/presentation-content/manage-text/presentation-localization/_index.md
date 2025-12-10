---
title: Automatiser la localisation des présentations en C++
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/cpp/presentation-localization/
keywords:
- modifier la langue
- vérification orthographique
- ID de langue
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Automatisez la localisation des diapositives PowerPoint et OpenDocument en C++ avec Aspose.Slides, en utilisant des exemples de code pratiques et des astuces pour un déploiement mondial plus rapide."
---

## **Modifier la langue d’une présentation et du texte d’une forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Rectangle à la diapositive.
- Ajouter du texte au TextFrame.
- Définir l’ID de langue pour le texte.
- Enregistrer la présentation au format PPTX.

L’implémentation des étapes ci‑dessus est illustrée ci‑après dans un exemple.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**L’ID de langue déclenche-t-il une traduction automatique du texte ?**

Non. L’[ID de langue](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) dans Aspose.Slides stocke la langue pour la vérification orthographique et la correction grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. C’est une métadonnée que PowerPoint comprend pour la révision.

**L’ID de langue affecte-t-il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, l’[ID de langue](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) est destiné à la révision. La qualité de la césure et le retour à la ligne dépendent principalement de la disponibilité des [polices appropriées](/slides/fr/cpp/powerpoint-fonts/) et des paramètres de mise en page/retour à la ligne du système d’écriture. Pour garantir un rendu correct, rendez les polices requises disponibles, configurez les [règles de substitution de polices](/slides/fr/cpp/font-substitution/), et/ou [intégrez les polices](/slides/fr/cpp/embedded-font/) dans la présentation.

**Puis‑je définir des langues différentes au sein d’un même paragraphe ?**

Oui. L’[ID de langue](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) s’applique au niveau de la portion de texte, de sorte qu’un même paragraphe peut mélanger plusieurs langues avec des paramètres de révision distincts.