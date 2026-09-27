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
description: "Créer des présentations PowerPoint en Python avec Aspose.Slides — produire des fichiers PPT, PPTX et ODP, bénéficier de la prise en charge OpenDocument, et les enregistrer programmatiquement pour des résultats fiables."
---
## **Aperçu**

Cet article montre comment créer une présentation avec Aspose.Slides pour Python via .NET, ajouter une forme contenant du texte à sa première diapositive et enregistrer le résultat sous forme de fichier PPTX. La même API permet également d’enregistrer des présentations au format PPT et ODP, de sorte que vous pouvez cibler à la fois les formats PowerPoint et OpenDocument à partir d’une même base de code, sans Microsoft Office. Une FAQ courte à la fin couvre les questions courantes concernant les formats, les modèles, la taille des diapositives, les unités, l’utilisation de la mémoire, le multithreading, la licence, les signatures numériques et la prise en charge VBA.

Avant de commencer, installez le package depuis PyPI avec `pip install aspose.slides`. Consultez [Installation](/slides/fr/python-net/installation/) pour les bibliothèques requises également sous Linux et macOS, ainsi que pour l’environnement virtuel dont le Python système de Debian et Ubuntu a besoin.

## **Créer une présentation**

Pour créer une présentation et placer une forme avec du texte sur sa première diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Une nouvelle présentation contient déjà une diapositive vide.  
2. Récupérez cette diapositive à partir de la collection [slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slides/fr/) en utilisant son index, 0.  
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) en forme de nuage à l'aide de la méthode [add_auto_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_auto_shape/) de la collection [shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/shapes/) de la diapositive, et définissez son [text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/text/).  
4. Enregistrez la présentation en tant que fichier PPTX avec la méthode [save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    # Récupérer la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une auto-forme de type CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Enregistrer la présentation sous forme de fichier PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Le coin supérieur gauche du nuage est à 20 points du bord gauche et à 20 points du bord supérieur de la diapositive, et le nuage mesure 200 points de largeur sur 80 points de hauteur. L’instruction `with` libère les ressources de la présentation à la fin du bloc. Le script enregistre *new_presentation.pptx* dans le dossier actuel, avec une diapositive contenant le nuage et son texte. Sans licence, Aspose.Slides ajoute également un filigrane d’évaluation à chaque diapositive enregistrée ; consultez [Licence](/slides/fr/python-net/licensing/).

Le résultat :

![La nouvelle présentation](new_presentation.png)

## **FAQ**

### Quels formats puis‑je enregistrer une nouvelle présentation ?

Vous pouvez enregistrer au format [PPTX, PPT et ODP](/slides/fr/python-net/save-presentation/), et exporter vers [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/fr/python-net/convert-powerpoint-to-xps/), [HTML](/slides/fr/python-net/convert-powerpoint-to-html/), [SVG](/slides/fr/python-net/render-a-slide-as-an-svg-image/) et [images](/slides/fr/python-net/convert-powerpoint-to-png/), entre autres.

### Puis‑je démarrer à partir d’un modèle (POTX/POTM) et enregistrer en PPTX standard ?

Oui. Chargez le modèle et enregistrez-le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/python-net/supported-file-formats/).

### Comment contrôler la taille ou le rapport d’aspect des diapositives lors de la création d’une présentation ?

Définissez la [taille de diapositive](/slides/fr/python-net/slide-size/) (incluant des préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

### En quelles unités les tailles et les coordonnées sont‑elles mesurées ?

En points : 1 pouce équivaut à 72 unités.

### Comment gérer des présentations très volumineuses (avec de nombreux fichiers médias) pour réduire l’utilisation de la mémoire ?

Utilisez les [BLOB management strategies](/slides/fr/python-net/manage-blob/), limitez le stockage en mémoire en vous appuyant sur des fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que des flux purement en mémoire.

### Puis‑je créer/enregistrer des présentations en parallèle ?

Vous ne pouvez pas manipuler la même instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) depuis [multiple threads](/slides/fr/python-net/multithreading/). Exécutez des instances séparées et isolées par thread ou processus.

### Comment supprimer le filigrane d’évaluation et les limitations ?

[Appliquer une licence](/slides/fr/python-net/licensing/) une fois par processus. Le fichier XML de licence doit rester inchangé, et la configuration de licence doit être synchronisée si plusieurs threads sont impliqués.

### Puis‑je signer numériquement le PPTX que je crée ?

Oui. Les [signatures numériques](/slides/fr/python-net/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

### Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/python-net/presentation-via-vba/) et enregistrer des fichiers contenant des macros tels que PPTM/PPSM.