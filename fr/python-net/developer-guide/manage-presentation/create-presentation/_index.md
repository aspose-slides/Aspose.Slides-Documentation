---
title: Créer des présentations en Python
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/python-net/create-presentation/
keywords:
- créer une présentation
- nouvelle présentation
- créer PPT
- nouveau PPT
- créer PPTX
- nouveau PPTX
- créer ODP
- nouveau ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Créez des présentations PowerPoint en Python avec Aspose.Slides - générez des fichiers PPT, PPTX et ODP, bénéficiez du support OpenDocument et enregistrez-les programmatiquement pour des résultats fiables."
---

## **Aperçu**

Aspose.Slides for Python vous permet de créer un tout nouveau fichier de présentation entièrement en code. Cet article montre le flux de travail principal — créer un objet [Présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), récupérer la première diapositive, injecter une forme simple et persister le résultat — pour que vous puissiez voir à quel point peu de configuration est nécessaire pour générer une présentation sans Microsoft Office. Comme la même API écrit des fichiers PPT, PPTX et ODP, vous pouvez cibler à la fois les formats traditionnels PowerPoint et OpenDocument à partir d’une base de code unique. Aspose.Slides convient aux environnements de bureau, web ou serveur, offrant à votre application Python un point de départ efficace pour ajouter du contenu enrichi tel que du texte, des images ou des graphiques une fois le jeu de diapositives initial en place.

## **Créer une Présentation**

Créer un fichier PowerPoint à partir de zéro avec Aspose.Slides for Python est aussi direct que d’instancier la classe [Présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Le constructeur fournit automatiquement un deck vierge contenant une seule diapositive, vous donnant immédiatement une toile pour des formes, du texte, des graphiques ou tout autre contenu dont votre application a besoin. Une fois que vous avez modifié cette diapositive — ou ajouté de nouvelles — vous pouvez persister le résultat en PPTX, PPT hérité ou même en formats OpenDocument. L’exemple de code court ci‑dessous illustre ce flux de travail en ajoutant une forme simple sur la première diapositive.

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par son index.
1. Ajoutez un objet [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de type `CLOUD` en utilisant la méthode `add_auto_shape` exposée par la collection `shapes`.
1. Ajoutez du texte à l’auto‑forme.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, une forme de nuage est ajoutée à la première diapositive de la présentation.
```py
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    # Récupère la première diapositive.
    slide = presentation.slides[0]

    # Ajoute une forme auto de type CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Enregistre la présentation sous forme de fichier PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![La nouvelle présentation](new_presentation.png)

## **FAQ**

**Dans quels formats puis‑je enregistrer une nouvelle présentation ?**

Vous pouvez enregistrer en [PPTX, PPT et ODP](/slides/fr/python-net/save-presentation/), et exporter vers [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/fr/python-net/convert-powerpoint-to-xps/), [HTML](/slides/fr/python-net/convert-powerpoint-to-html/), [SVG](/slides/fr/python-net/convert-powerpoint-to-png/) et [images](/slides/fr/python-net/convert-powerpoint-to-png/), entre autres.

**Puis‑je partir d’un modèle (POTX/POTM) et enregistrer en PPTX standard ?**

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/python-net/supported-file-formats/).

**Comment contrôler la taille/le rapport d’aspect des diapositives lors de la création d’une présentation ?**

Définissez la [taille de la diapositive](/slides/fr/python-net/slide-size/) (y compris les préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

**Dans quelles unités les tailles et coordonnées sont‑elles mesurées ?**

En points : 1 pouce équivaut à 72 unités.

**Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédia) pour réduire la consommation de mémoire ?**

Utilisez les [stratégies de gestion des BLOB](/slides/fr/python-net/manage-blob/), limitez le stockage en mémoire en recourant à des fichiers temporaires, et privilégiez les flux basés sur des fichiers plutôt que les flux purement en mémoire.

**Puis‑je créer/enregistrer des présentations en parallèle ?**

Vous ne pouvez pas manipuler la même instance de [Présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/python-net/multithreading/). Exécutez des instances séparées et isolées par thread ou par processus.

**Comment supprimer le filigrane d’évaluation et les limitations ?**

[Appliquez une licence](/slides/fr/python-net/licensing/) une fois par processus. Le fichier XML de licence doit rester intact, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

**Puis‑je signer numériquement le PPTX que je crée ?**

Oui. Les [signatures numériques](/slides/fr/python-net/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

**Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?**

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/python-net/presentation-via-vba/) et enregistrer des fichiers activés pour les macros tels que PPTM/PPSM.