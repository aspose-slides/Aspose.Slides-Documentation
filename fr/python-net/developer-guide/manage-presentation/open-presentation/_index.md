---
title: Ouvrir des présentations en Python
linktitle: Ouvrir des présentations
type: docs
weight: 20
url: /fr/python-net/open-presentation/
keywords:
- ouvrir PowerPoint
- ouvrir présentation
- ouvrir PPTX
- ouvrir PPT
- ouvrir ODP
- charger présentation
- charger PPTX
- charger PPT
- charger ODP
- présentation protégée
- grande présentation
- ressource externe
- objet binaire
- Python
- Aspose.Slides
description: "Ouvrez des présentations PowerPoint (.pptx, .ppt) et OpenDocument (.odp) sans effort avec Aspose.Slides pour Python via .NET — rapide, fiable, entièrement fonctionnel."
---

## **Aperçu**

Au‑delà de la création de présentations PowerPoint à partir de zéro, Aspose.Slides vous permet également d’ouvrir des présentations existantes. Après avoir chargé une présentation, vous pouvez en récupérer les informations, modifier le contenu des diapositives, ajouter de nouvelles diapositives, supprimer celles existantes, et plus encore.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et transmettez le chemin du fichier à son constructeur.

Le code Python suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :
```python
import aspose.slides as slides

# Instanciez la classe Presentation et transmettez un chemin de fichier à son constructeur.
with slides.Presentation("sample.pptx") as presentation:
    # Affichez le nombre total de diapositives dans la présentation.
    print(presentation.slides.length)
```


## **Ouvrir des présentations protégées par mot de passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, transmettez le mot de passe via la propriété [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) de la classe [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) pour la déchiffrer et la charger. Le code Python suivant montre cette opération :
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Effectuez des opérations sur la présentation déchiffrée.
```


## **Ouvrir de grandes présentations**

Aspose.Slides offre des options — notamment la propriété [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) de la classe [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) — pour vous aider à charger de grandes présentations.

Le code Python suivant montre le chargement d’une grande présentation (par exemple, 2 Go) :
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of 
# the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 Mo

with slides.Presentation(file_path, load_options) as presentation:
    # The large presentation has been loaded and can be used, while memory consumption remains low.

    # Make changes to the presentation.
    presentation.slides[0].name = "Large presentation"

    # Save the presentation to another file. Memory consumption remains low during this operation.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
    os.remove(file_path)

# It is OK to do it here. The source file is no longer locked by the presentation object.
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
Pour contourner certaines limites lors de l’utilisation de flux, Aspose.Slides peut copier le contenu d’un flux. Charger une grande présentation depuis un flux entraîne la copie de la présentation et peut ralentir le chargement. Par conséquent, lorsque vous devez charger une grande présentation, nous vous recommandons fortement d’utiliser le chemin du fichier de présentation plutôt qu’un flux.

Lors de la création d’une présentation contenant de grands objets (vidéo, audio, images haute résolution, etc.), vous pouvez utiliser la [gestion BLOB](/slides/fr/python-net/manage-blob/) pour réduire la consommation mémoire.
{{%/alert %}}

## **Contrôler les ressources externes**

Aspose.Slides fournit l’interface [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) qui vous permet de gérer les ressources externes. Le code Python suivant montre comment utiliser l’interface `IResourceLoadingCallback` :
```python
# [TODO[not_supported_yet]: implémentation Python des interfaces .NET]
```


## **Charger des présentations sans objets binaires incorporés**

Une présentation PowerPoint peut contenir les types d’objets binaires incorporés suivants :

- Projet VBA (accessible via [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/));
- Données incorporées d’objet OLE (accessibles via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Données binaires de contrôle ActiveX (accessibles via [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/)).

En utilisant la propriété [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/), vous pouvez charger une présentation sans aucun objet binaire incorporé.

Cette propriété est utile pour supprimer un contenu binaire potentiellement malveillant. Le code Python suivant montre comment charger une présentation sans aucun contenu binaire incorporé :
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Effectuez des opérations sur la présentation.
```


## **FAQ**

**Comment savoir qu’un fichier est corrompu et ne peut pas être ouvert ?**

Vous recevrez une exception de validation d’analyse/format lors du chargement. Ces erreurs mentionnent souvent une structure ZIP non valide ou des enregistrements PowerPoint corrompus.

**Que se passe-t-il si des polices requises sont manquantes lors de l’ouverture ?**

Le fichier s’ouvrira, mais le [rendu/export](/slides/fr/python-net/convert-presentation/) pourra substituer les polices. [Configurez les substitutions de polices](/slides/fr/python-net/font-substitution/) ou [ajoutez les polices requises](/slides/fr/python-net/custom-font/) à l’environnement d’exécution.

**Qu’en est‑il des médias incorporés (vidéo/audio) lors de l’ouverture ?**

Ils deviennent disponibles en tant que ressources de la présentation. Si les médias sont référencés via des chemins externes, assurez‑vous que ces chemins sont accessibles dans votre environnement ; sinon le [rendu/export](/slides/fr/python-net/convert-presentation/) pourra omettre les médias.