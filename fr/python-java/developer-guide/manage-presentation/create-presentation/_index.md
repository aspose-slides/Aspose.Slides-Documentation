---
title: Créer des présentations en Python via Java
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/python-java/create-presentation/
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
- présentation
- Python
- Java
- Aspose.Slides
description: "Créez des présentations en Python via Java avec Aspose.Slides — produisez des fichiers PPT, PPTX et ODP, bénéficiez de la prise en charge d’OpenDocument et enregistrez‑les de façon programmatique pour des résultats fiables."
---
## **Vue d'ensemble**

Cet article montre comment créer une présentation avec Aspose.Slides for Python via Java, ajouter une forme avec du texte à la première diapositive et enregistrer le résultat sous forme de fichier PPTX. La FAQ couvre les formats de sortie, les modèles, la taille des diapositives, l’utilisation de la mémoire, le multithreading, la licence, les signatures numériques et la prise en charge de VBA.

Avant de commencer, installez Python, un JDK, JPype et Aspose.Slides for Python via Java. Consultez [Installation](/slides/fr/python-java/installation/) pour les étapes sous Windows, Linux et macOS.

## **Créer une présentation**

Créer un fichier PowerPoint à partir de zéro avec Aspose.Slides for Python via Java est aussi simple que d’instancier la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). Le constructeur fournit automatiquement un jeu vierge avec une seule diapositive, vous donnant immédiatement un canevas pour des formes, du texte, des graphiques ou tout autre contenu dont votre application a besoin. Une fois que vous avez modifié cette diapositive — ou ajouté de nouvelles — vous pouvez enregistrer le résultat au format PPTX, PPT hérité ou même aux formats OpenDocument. L’exemple de code court ci‑dessous illustre ce flux de travail en ajoutant une forme simple à la première diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. récupérez la première diapositive par son indice, 0.
1. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) de type [ShapeType.Cloud](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#Cloud) à l’aide de [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Définissez le texte de la forme avec [TextFrame.setText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#setText).
1. Enregistrez la présentation avec [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) en utilisant [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Pptx).

L’exemple suivant démarre la machine virtuelle Java (JVM) si elle n’est pas déjà en cours d’exécution, ajoute une forme de nuage avec du texte à la première diapositive et enregistre la présentation. Enregistrez‑le sous le nom *create_presentation.py* :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Créer une présentation avec une diapositive vierge.
presentation = Presentation()
try:
    # Obtenir la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme de nuage et définir son texte.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Enregistrer la présentation au format PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Exécutez le script dans l’environnement où vous avez installé les packages :

```sh
python create_presentation.py
```

Le coin supérieur gauche du nuage est à 20 points du bord gauche et du bord supérieur de la diapositive, et le nuage mesure 200 points de large sur 80 points de haut. Le script enregistre *new_presentation.pptx* dans le répertoire de travail actuel, contenant une diapositive qui possède le nuage et son texte. La JVM reste active jusqu’à la fin du processus Python ; voir [Limitations and API Differences](/slides/fr/python-java/limitations-and-api-differences/#import-the-library). Sans licence, Aspose.Slides ajoute également une zone de texte de filigrane d’évaluation à chaque diapositive enregistrée ; voir [Licensing](/slides/fr/python-java/licensing/).

Le résultat :

![La nouvelle présentation](new_presentation.png)

## **FAQ**

**Quels formats puis‑je utiliser pour enregistrer une nouvelle présentation ?**

Vous pouvez enregistrer au format [PPTX, PPT, et ODP](/slides/fr/python-java/save-presentation/), et exporter vers [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/python-java/convert-powerpoint-to-xps/), [HTML](/slides/fr/python-java/convert-powerpoint-to-html/), [SVG](/slides/fr/python-java/render-a-slide-as-an-svg-image/) et [images](/slides/fr/python-java/convert-powerpoint-to-png/), entre autres.

**Puis‑je partir d’un modèle (POTX/POTM) et enregistrer en PPTX standard ?**

Oui. Chargez le modèle et enregistrez-le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/python-java/supported-file-formats/).

**Comment contrôler la taille/la proportion des diapositives lors de la création d’une présentation ?**

Définissez la [taille de la diapositive](/slides/fr/python-java/slide-size/) (avec des préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

**Dans quelles unités sont mesurées les tailles et les coordonnées ?**

En points : 1 pouce équivaut à 72 unités.

**Comment gérer de très grandes présentations (avec de nombreux fichiers multimédias) pour réduire l’utilisation de la mémoire ?**

Utilisez les [stratégies de gestion des BLOB](/slides/fr/python-java/manage-blob/), limitez le stockage en mémoire en utilisant des fichiers temporaires, et privilégiez les flux basés sur des fichiers plutôt que les flux purement en mémoire.

**Puis‑je créer/enregistrer des présentations en parallèle ?**

Vous ne pouvez pas manipuler la même instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/python-java/multithreading/). Exécutez des instances distinctes et isolées par thread ou processus.

**Comment supprimer le filigrane d’évaluation et les limitations ?**

[Appliquez une licence](/slides/fr/python-java/licensing/) une fois par processus. Le XML de licence doit rester non modifié, et la configuration de licence doit être synchronisée si plusieurs threads sont impliqués.

**Puis‑je signer numériquement le PPTX que je crée ?**

Oui. Les [signatures numériques](/slides/fr/python-java/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

**Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?**

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/python-java/presentation-via-vba/) et enregistrer des fichiers activés macros tels que PPTM/PPSM.