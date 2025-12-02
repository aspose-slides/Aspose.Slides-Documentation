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
description: "Créez des présentations PowerPoint en Python avec Aspose.Slides - générez des fichiers PPT, PPTX et ODP, profitez de la prise en charge d'OpenDocument et enregistrez-les programmeusement pour des résultats fiables."
---

## **Vue d'ensemble**

Aspose.Slides for Python vous permet de créer un tout nouveau fichier de présentation entièrement en code. Cet article montre le flux de travail principal — création d’un objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , récupération de la première diapositive, insertion d’une forme simple et persistance du résultat—ainsi vous pouvez voir à quel point peu de configuration est nécessaire pour générer une présentation sans Microsoft Office. Comme la même API écrit les fichiers PPT, PPTX et ODP, vous pouvez cibler à la fois les formats PowerPoint traditionnels et OpenDocument à partir d’une unique base de code. Aspose.Slides convient aux environnements de bureau, web ou serveur, offrant à votre application Python un point de départ efficace pour ajouter du contenu enrichi tel que texte, images ou graphiques une fois le jeu de diapositives initial en place.

## **Créer une présentation**

Créer un fichier PowerPoint à partir de rien avec Aspose.Slides for Python est aussi simple que d’instancier la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) . Le constructeur fournit automatiquement un diaporama vierge avec une seule diapositive, vous offrant un canevas immédiat pour les formes, le texte, les graphiques ou tout autre contenu dont votre application a besoin. Une fois que vous avez modifié cette diapositive—ou ajouté de nouvelles—vous pouvez persister le résultat en PPTX, PPT hérité ou même formats OpenDocument. L’exemple de code ci‑dessous illustre ce flux de travail en ajoutant une forme simple sur la première diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez une référence à la diapositive par son indice.
1. Ajoutez un objet [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de type `CLOUD` en utilisant la méthode `add_auto_shape` exposée par la collection `shapes` .
1. Ajoutez du texte à l’auto‑forme.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, une forme de nuage est ajoutée à la première diapositive de la présentation.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une auto-shape de type CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Enregistrer la présentation au format PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![La nouvelle présentation](new_presentation.png)

## **FAQ**

**Quels formats puis‑je enregistrer une nouvelle présentation ?**

Vous pouvez enregistrer au format [PPTX, PPT, et ODP](/slides/fr/python-net/save-presentation/) , et exporter vers [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/) , [XPS](/slides/fr/python-net/convert-powerpoint-to-xps/) , [HTML](/slides/fr/python-net/convert-powerpoint-to-html/) , [SVG](/slides/fr/python-net/convert-powerpoint-to-png/) , et [images](/slides/fr/python-net/convert-powerpoint-to-png/) , entre autres.

**Puis‑je partir d’un modèle (POTX/POTM) et l’enregistrer comme un PPTX standard ?**

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/python-net/supported-file-formats/) .

**Comment contrôler la taille/rapport d’aspect des diapositives lors de la création d’une présentation ?**

Définissez la [taille des diapositives](/slides/fr/python-net/slide-size/) (y compris les préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

**Dans quelles unités les tailles et coordonnées sont‑elles mesurées ?**

En points : 1 pouce équivaut à 72 unités.

**Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédia) pour réduire la consommation de mémoire ?**

Utilisez les [stratégies de gestion des BLOB](/slides/fr/python-net/manage-blob/) , limitez le stockage en mémoire en exploitant des fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que les flux purement en mémoire.

**Puis‑je créer/enregistrer des présentations en parallèle ?**

Vous ne pouvez pas manipuler la même instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/python-net/multithreading/) . Exécutez des instances séparées et isolées par thread ou processus.

**Comment supprimer le filigrane d’essai et les limitations ?**

[Appliquez une licence](/slides/fr/python-net/licensing/) une fois par processus. Le fichier XML de licence doit rester tel quel, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

**Puis‑je signer numériquement le PPTX que je crée ?**

Oui. Les [signatures numériques](/slides/fr/python-net/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

**Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?**

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/python-net/presentation-via-vba/) et enregistrer des fichiers activés macron tels que PPTM/PPSM.