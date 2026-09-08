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
description: "Créez des présentations en Python via Java avec Aspose.Slides—produisez des fichiers PPT, PPTX et ODP, bénéficiez de la prise en charge d'OpenDocument et enregistrez-les programmatiquement pour des résultats fiables."
---
## **Vue d'ensemble**

Cet article montre comment créer une présentation avec Aspose.Slides for Python via Java, ajouter une forme avec du texte à la première diapositive et enregistrer le résultat au format PPTX. La FAQ couvre les formats de sortie, les modèles, la taille des diapositives, l’utilisation de la mémoire, le multithreading, la licence, les signatures numériques et la prise en charge de VBA.

## **Créer une présentation**

Créer un fichier PowerPoint à partir de zéro avec Aspose.Slides for Python via Java est aussi simple que d'instancier la classe [Présentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). Le constructeur fournit automatiquement un jeu vierge avec une seule diapositive, vous offrant une toile immédiate pour des formes, du texte, des graphiques ou tout autre contenu dont votre application a besoin. Une fois que vous avez modifié cette diapositive — ou ajouté de nouvelles — vous pouvez enregistrer le résultat au format PPTX, PPT hérité ou même aux formats OpenDocument. Le court exemple de code ci‑dessous illustre ce flux de travail en ajoutant une forme simple sur la première diapositive.

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir la première diapositive par son index.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) de type [ShapeType.Cloud](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#Cloud) en utilisant [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Définir le texte de la forme en utilisant [TextFrame.setText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#setText).
1. Enregistrer la présentation en utilisant [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Pptx).

L'exemple suivant nécessite Aspose.Slides for Python via Java et un runtime Java compatible. Il démarre la JVM si elle n'est pas déjà en cours d'exécution, ajoute une forme nuage à la première diapositive et enregistre la présentation :

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

    # Ajouter une forme nuage et définir son texte.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Enregistrer la présentation au format PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![La nouvelle présentation](new_presentation.png)

## **FAQ**

**Dans quels formats puis‑je enregistrer une nouvelle présentation ?**

Vous pouvez enregistrer au format [PPTX, PPT et ODP](/slides/fr/python-java/save-presentation/), et exporter vers [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/python-java/convert-powerpoint-to-xps/), [HTML](/slides/fr/python-java/convert-powerpoint-to-html/), [SVG](/slides/fr/python-java/render-slide-as-svg/), et [images](/slides/fr/python-java/convert-powerpoint-to-png/), entre autres.

**Puis‑je commencer à partir d'un modèle (POTX/POTM) et enregistrer en PPTX ordinaire ?**

Oui. Chargez le modèle et enregistrez-le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/python-java/supported-file-formats/).

**Comment contrôler la taille/la proportion des diapositives lors de la création d'une présentation ?**

Définissez la [taille de la diapositive](/slides/fr/python-java/slide-size/) (y compris les préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l'échelle.

**En quelles unités les tailles et coordonnées sont‑elles mesurées ?**

En points : 1 pouce correspond à 72 unités.

**Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédias) pour réduire l'utilisation de la mémoire ?**

Utilisez les [stratégies de gestion des BLOB](/slides/fr/python-java/manage-blob/), limitez le stockage en mémoire en exploitant des fichiers temporaires, et privilégiez les flux de travail basés sur les fichiers plutôt que les flux purement en mémoire.

**Puis‑je créer/enregistrer des présentations en parallèle ?**

Vous ne pouvez pas exploiter la même instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/python-java/multithreading/). Exécutez des instances distinctes et isolées par thread ou processus.

**Comment enlever le filigrane d'essai et les limitations ?**

[Appliquez une licence](/slides/fr/python-java/licensing/) une fois par processus. Le XML de licence doit rester inchangé, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

**Puis‑je signer numériquement le PPTX que je crée ?**

Oui. Les [signatures numériques](/slides/fr/python-java/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

**Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?**

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/python-java/presentation-via-vba/) et enregistrer des fichiers avec macros tels que PPTM/PPSM.