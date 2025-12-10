---
title: Gérer les exposants et indices dans les présentations avec C++
linktitle: Exposant et indice
type: docs
weight: 80
url: /fr/cpp/superscript-and-subscript/
keywords:
- exposant
- indice
- ajouter un exposant
- ajouter un indice
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez les exposants et indices dans Aspose.Slides pour C++ et améliorez vos présentations avec un formatage de texte professionnel pour un impact maximal."
---

## **Gérer le texte en exposant et indice**
Vous pouvez ajouter du texte en exposant et en indice dans n'importe quelle portion de paragraphe. Pour ajouter du texte en exposant ou en indice dans le cadre de texte d’Aspose.Slides, vous devez utiliser les propriétés **Escapement** de la classe PortionFormat.

Cette propriété renvoie ou définit le texte en exposant ou en indice (valeur de -100 % (indice) à 100 % (exposant)). Par exemple :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- Obtenir la référence d’une diapositive en utilisant son index.
- Ajouter un IAutoShape de type Rectangle à la diapositive.
- Accéder au ITextFrame associé à l’IAutoShape.
- Effacer les paragraphes existants.
- Créer un nouvel objet paragraphe pour contenir le texte en exposant et l’ajouter à la collection IParagraphs du ITextFrame.
- Créer un nouvel objet portion.
- Définir la propriété Escapement pour la portion entre 0 et 100 pour ajouter un exposant. (0 signifie aucun exposant)
- Définir du texte pour la Portion puis l’ajouter à la collection de portions du paragraphe.
- Créer un nouvel objet paragraphe pour contenir le texte en indice et l’ajouter à la collection IParagraphs du ITextFrame.
- Créer un nouvel objet portion.
- Définir la propriété Escapement pour la portion entre 0 et -100 pour ajouter un indice. (0 signifie aucun indice)
- Définir du texte pour la Portion puis l’ajouter à la collection de portions du paragraphe.
- Enregistrer la présentation au format PPTX.

L'implémentation des étapes ci‑dessus est fournie ci‑dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**L’exposant et l’indice seront-ils conservés lors de l’exportation vers PDF ou d’autres formats ?**

Oui, Aspose.Slides conserve correctement le formatage d’exposant et d’indice lors de l’exportation des présentations vers PDF, PPT/PPTX, images et autres formats pris en charge. Le formatage spécialisé reste intact dans tous les fichiers de sortie.

**L’exposant et l’indice peuvent-ils être combinés avec d’autres styles de formatage tels que gras ou italique ?**

Oui, Aspose.Slides vous permet de mélanger divers styles de texte au sein d’une même portion. Vous pouvez activer le gras, l’italique, le soulignement et appliquer simultanément l’exposant ou l’indice en configurant les propriétés correspondantes dans [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) .

**Le formatage d’exposant et d’indice fonctionne-t-il pour le texte à l’intérieur des tableaux, graphiques ou SmartArt ?**

Oui, Aspose.Slides prend en charge le formatage dans la plupart des objets, y compris les tableaux et les éléments de graphique. Lors du travail avec SmartArt, vous devez accéder aux éléments appropriés (tels que [SmartArtNode](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartnode/)) et à leurs conteneurs de texte, puis configurer les propriétés [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) de manière similaire.