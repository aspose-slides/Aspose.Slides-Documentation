---
title: Créer des présentations en C++
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/cpp/create-presentation/
keywords:
- créer présentation
- nouvelle présentation
- créer PPT
- nouveau PPT
- créer PPTX
- nouveau PPTX
- créer ODP
- nouveau ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Créez des présentations en C++ avec Aspose.Slides - générez des fichiers PPT, PPTX et ODP, profitez de la prise en charge d'OpenDocument et enregistrez-les programmatiquement pour des résultats fiables."
---

## **Créer une présentation PowerPoint**
Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d’une diapositive en utilisant son Index.
3. Ajoutez une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l’objet Shapes.
4. Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**Quels formats puis‑je enregistrer pour une nouvelle présentation ?**

Vous pouvez enregistrer au format [PPTX, PPT et ODP](/slides/fr/cpp/save-presentation/), et exporter vers [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/fr/cpp/convert-powerpoint-to-xps/), [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), [SVG](/slides/fr/cpp/convert-powerpoint-to-png/) et [images](/slides/fr/cpp/convert-powerpoint-to-png/), entre autres.

**Puis‑je partir d’un modèle (POTX/POTM) et l’enregistrer comme un PPTX ordinaire ?**

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/cpp/supported-file-formats/).

**Comment contrôler la taille/le rapport d’aspect des diapositives lors de la création d’une présentation ?**

Définissez la [taille de la diapositive](/slides/fr/cpp/slide-size/) (y compris les préréglages comme 4 :3 et 16 :9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

**Dans quelles unités les tailles et les coordonnées sont‑elles mesurées ?**

En points : 1 pouce équivaut à 72 unités.

**Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédias) afin de réduire la consommation de mémoire ?**

Utilisez les [stratégies de gestion des BLOB](/slides/fr/cpp/manage-blob/), limitez le stockage en mémoire en utilisant des fichiers temporaires, et privilégiez les flux basés sur des fichiers plutôt que les flux entièrement en mémoire.

**Puis‑je créer/enregistrer des présentations en parallèle ?**

Vous ne pouvez pas manipuler la même instance de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/cpp/multithreading/). Exécutez des instances séparées et isolées par thread ou processus.

**Comment supprimer le filigrane d’essai et les limitations ?**

[Appliquez une licence](/slides/fr/cpp/licensing/) une fois par processus. Le XML de licence doit rester inchangé, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

**Puis‑je signer numériquement le PPTX que je crée ?**

Oui. Les [signatures numériques](/slides/fr/cpp/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

**Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?**

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/cpp/presentation-via-vba/) et enregistrer des fichiers avec macros comme PPTM/PPSM.