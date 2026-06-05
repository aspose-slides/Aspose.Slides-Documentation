---
title: Ouvrir des présentations en Python
linktitle: Ouvrir des présentations
type: docs
weight: 20
url: /fr/python-net/open-presentation/
keywords:
- ouvrir PowerPoint
- ouvrir une présentation
- ouvrir PPTX
- ouvrir PPT
- ouvrir ODP
- charger une présentation
- charger PPTX
- charger PPT
- charger ODP
- présentation protégée
- grande présentation
- ressource externe
- objet binaire
- Python
- Aspose.Slides
description: "Ouvrez facilement les présentations PowerPoint (.pptx, .ppt) et OpenDocument (.odp) avec Aspose.Slides pour Python via .NET—rapide, fiable, riche en fonctionnalités."
---
## **Introduction**

Au‑delà de la création de présentations PowerPoint à partir de zéro, Aspose.Slides vous permet également d’ouvrir des présentations existantes. Après le chargement d’une présentation, vous pouvez en extraire des informations, modifier le contenu des diapositives, ajouter de nouvelles diapositives, supprimer celles existantes, et plus encore.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et transmettez le chemin du fichier à son constructeur.

L’exemple Python suivant montre comment ouvrir une présentation et obtenir son nombre de diapositives :

```python
import aspose.slides as slides

# Instanciez la classe Presentation et passez un chemin de fichier à son constructeur.
with slides.Presentation("sample.pptx") as presentation:
    # Affichez le nombre total de diapositives de la présentation.
    print(presentation.slides.length)
```

## **Ouvrir des présentations protégées par mot de passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, transmettez le mot de passe via la propriété [password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/password/) de la classe [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/) pour la déchiffrer et la charger. Le code Python suivant illustre cette opération :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Effectuez des opérations sur la présentation déchiffrée.
```

## **Ouvrir de grandes présentations**

Aspose.Slides propose des options—notamment la propriété [blob_management_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/blob_management_options/) de la classe [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/)—pour faciliter le chargement de présentations volumineuses.

Ce code Python montre le chargement d’une grande présentation (par exemple, 2 Go) :

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Choisissez le comportement KeepLocked — le fichier de présentation restera verrouillé pendant la durée de 
# l'instance Presentation, mais il n'est pas nécessaire de le charger en mémoire ou de le copier dans un fichier temporaire.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 Mo

with slides.Presentation(file_path, load_options) as presentation:
    # La grande présentation a été chargée et peut être utilisée, tandis que la consommation mémoire reste faible.

    # Apportez des modifications à la présentation.
    presentation.slides[0].name = "Large presentation"

    # Enregistrez la présentation dans un autre fichier. La consommation mémoire reste faible pendant cette opération.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Ne faites pas cela ! Une exception d'E/S sera levée car le fichier reste verrouillé jusqu'à la libération de l'objet présentation.
    os.remove(file_path)

# Il est correct de le faire ici. Le fichier source n'est plus verrouillé par l'objet présentation.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
Pour contourner certaines limitations lors de l’utilisation de flux, Aspose.Slides peut copier le contenu d’un flux. Le chargement d’une grande présentation depuis un flux entraîne la copie de la présentation et peut ralentir le chargement. Ainsi, lorsque vous devez charger une grande présentation, nous vous recommandons fortement d’utiliser le chemin du fichier de présentation plutôt qu’un flux.

Lorsque vous créez une présentation contenant de gros objets (vidéo, audio, images haute résolution, etc.), vous pouvez utiliser la [gestion des BLOB](/slides/fr/python-net/manage-blob/) afin de réduire la consommation de mémoire.
{{%/alert %}}

## **Charger des présentations sans objets binaires intégrés**

Une présentation PowerPoint peut contenir les types d’objets binaires intégrés suivants :

- projet VBA (accessible via [Presentation.vba_project](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/vba_project/));
- données d’objet OLE intégrées (accessible via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- données binaires de contrôle ActiveX (accessible via [Control.active_x_control_binary](https://reference.aspose.com/slides/fr/python-net/aspose.slides/control/active_x_control_binary/)).

En utilisant la propriété [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/), vous pouvez charger une présentation sans aucun objet binaire intégré.

Cette propriété est utile pour éliminer un contenu binaire potentiellement malveillant. Le code Python suivant montre comment charger une présentation sans aucun contenu binaire intégré :

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Effectuez des opérations sur la présentation.
```

## **FAQ**

**Comment savoir qu’un fichier est corrompu et ne peut pas être ouvert ?**

Vous recevrez une exception de validation du format/l’analyse lors du chargement. Ces erreurs mentionnent souvent une structure ZIP invalide ou des enregistrements PowerPoint endommagés.

**Que se passe‑t‑il si des polices requises sont manquantes lors de l’ouverture ?**

Le fichier s’ouvrira, mais le [rendu/export](/slides/fr/python-net/convert-presentation/) pourra substituer les polices. [Configurez les substitutions de polices](/slides/fr/python-net/font-substitution/) ou [ajoutez les polices requises](/slides/fr/python-net/custom-font/) à l’environnement d’exécution.

**Qu’en est‑il des médias intégrés (vidéo/audio) lors de l’ouverture ?**

Ils deviennent disponibles en tant que ressources de la présentation. Si les médias sont référencés via des chemins externes, assurez‑vous que ces chemins sont accessibles dans votre environnement ; sinon, le [rendu/export](/slides/fr/python-net/convert-presentation/) pourra omettre les médias.