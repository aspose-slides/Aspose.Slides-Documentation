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
description: "Apprenez à ouvrir des présentations PowerPoint et OpenDocument en Python, à fournir des mots de passe d’ouverture et à réduire l’utilisation de la mémoire avec Aspose.Slides pour Python via .NET."
---
## **Introduction**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/fr/python-net/) peut charger des présentations PowerPoint et OpenDocument à partir de fichiers et de flux. Après le chargement d’une présentation, vous pouvez inspecter sa structure, modifier les diapositives, gérer les ressources et l’enregistrer au format d’origine ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/). Par exemple, vous pouvez fournir un mot de passe d’ouverture, garder les gros objets binaires hors de la mémoire ou omettre les données binaires intégrées.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Utilisez une instruction `with` afin que les descripteurs de fichiers, les données temporaires et les autres ressources soient libérés rapidement.

L’exemple Python suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Ouvrir des présentations protégées par mot de passe**

Un mot de passe d’ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, affectez le mot de passe correct à [LoadOptions.password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/password/) et transmettez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Le chargement échoue si le mot de passe est absent ou incorrect.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Pour la détection, la validation et les flux de travail de chiffrement des mots de passe, consultez [Password-Protect Presentations](/slides/fr/python-net/password-protected-presentation/). Si une présentation chiffrée a été enregistrée délibérément avec des propriétés de document publiques, ces propriétés peuvent être lues sans mot de passe ; voir [Manage Presentation Properties](/slides/fr/python-net/presentation-properties/).

## **Ouvrir de grandes présentations**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/blob_management_options/) contrôle la manière dont Aspose.Slides gère les gros objets binaires tels que les images, l’audio et la vidéo. Vous pouvez garder le fichier source verrouillé, autoriser les fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

Ce code Python montre comment charger une grande présentation (par exemple, 2 Go) :

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Avec `PresentationLockingBehavior.KEEP_LOCKED`, le fichier source reste verrouillé jusqu’à ce que l’objet `Presentation` soit libéré. Ne déplacez pas, n’écrasez pas et ne supprimez pas le fichier source tant que cet objet est en vie.

Aspose.Slides peut copier le contenu d’un flux d’entrée lors du chargement. Pour les présentations volumineuses, un chemin de fichier est généralement plus efficace qu’un flux. Consultez [Manage BLOBs](/slides/fr/python-net/manage-blob/) pour des options supplémentaires de stockage et de gestion de la mémoire.
{{% /alert %}}

## **Charger des présentations sans objets binaires intégrés**

Une présentation peut contenir des données binaires intégrées dont une application n’a pas besoin ou ne souhaite pas conserver. Les exemples incluent :

- projets VBA, disponibles via [Presentation.vba_project](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/vba_project/);
- données OLE intégrées, disponibles via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- données de contrôle ActiveX, disponibles via [Control.active_x_control_binary](https://reference.aspose.com/slides/fr/python-net/aspose.slides/control/active_x_control_binary/).

Définissez [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) sur `True` pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée pour conserver le résultat désinfecté.

Cette option réduit l’exposition à des charges intégrées indésirables, mais ce n’est pas un système complet de détection de logiciels malveillants ou de désinfection de contenu.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Comment savoir qu’un fichier est corrompu et ne peut pas être ouvert ?**

Aspose.Slides déclenche une exception d’analyse ou de format lors du chargement. Gérez cet échec séparément d’une erreur de mot de passe incorrect afin que l’application puisse signaler la cause avec précision.

**Que se passe-t-il si les polices requises sont manquantes ?**

La présentation peut encore être chargée, mais le rendu et l’exportation peuvent substituer des polices. Vous pouvez [configure font substitution](/slides/fr/python-net/font-substitution/) ou [provide custom fonts](/slides/fr/python-net/custom-font/) pour rendre la sortie plus prévisible.

**Le chargement d’une présentation charge-t-il également ses médias intégrés ?**

Les audio et vidéo intégrés deviennent accessibles via le modèle d’objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement de ressources par défaut et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.