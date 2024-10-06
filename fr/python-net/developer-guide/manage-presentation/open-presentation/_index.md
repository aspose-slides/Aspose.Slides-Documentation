---
title: Ouvrir une Présentation
type: docs
weight: 20
url: /python-net/open-presentation/
keywords: "Ouvrir PowerPoint, PPTX, PPT, Ouvrir Présentation, Charger Présentation, Python"
description: "Ouvrir ou charger une Présentation PPT, PPTX, ODP en Python"
---

En plus de créer des présentations PowerPoint à partir de zéro, Aspose.Slides vous permet d'ouvrir des présentations existantes. Une fois que vous avez chargé une présentation, vous pouvez obtenir des informations sur la présentation, modifier la présentation (le contenu de ses diapositives), ajouter de nouvelles diapositives ou en supprimer des existantes, etc.

## Ouvrir une Présentation

Pour ouvrir une présentation existante, il vous suffit d'instancier la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et de passer le chemin du fichier (de la présentation que vous souhaitez ouvrir) à son constructeur.

Ce code Python vous montre comment ouvrir une présentation et aussi découvrir le nombre de diapositives qu'elle contient :

```python
import aspose.slides as slides

# Instancie la classe Presentation et passe le chemin du fichier à son constructeur
with slides.Presentation("pres.pptx") as pres:
    # Imprime le nombre total de diapositives présentes dans la présentation
    print(pres.slides.length)
```

## **Ouvrir une Présentation Protégée par Mot de Passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, vous pouvez passer le mot de passe via la propriété `password` (de la classe [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)) pour décrypter et charger la présentation. Ce code Python illustre l'opération :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "PASSWORD"
with slides.Presentation("pres.pptx", load_options) as pres:
    ...
```

## Ouvrir une Grande Présentation

Aspose.Slides fournit des options (la propriété `blob_management_options` en particulier) sous la classe [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) pour vous permettre de charger de grandes présentations.

Ce code Python démontre une opération dans laquelle une grande présentation (disons de 2 Go) est chargée :

```python
import aspose.slides as slides
import os

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("pres.pptx", loadOptions) as pres:
    # La grande présentation a été chargée et peut être utilisée, mais la consommation de mémoire reste faible.

    # Effectue des modifications sur la présentation.
    pres.slides[0].name = "Présentation très grande"

    # La présentation sera enregistrée dans un autre fichier. La consommation de mémoire reste faible pendant l'opération
    pres.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # impossible de faire ça ! Une exception IO sera déclenchée car le fichier est verrouillé alors que les objets pres ne seront
    # pas disposés
    os.remove("pres.pptx")

# Il est acceptable de le faire ici. Le fichier source n'est pas verrouillé par l'objet pres.
os.remove("pres.pptx")
```

{{% alert color="info" title="Info" %}}

Pour contourner certaines limitations lors de l'interaction avec des flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et provoquera un chargement lent. Par conséquent, lorsque vous souhaitez charger une grande présentation, nous vous recommandons vivement d'utiliser le chemin du fichier de présentation et non son flux.

Lorsque vous souhaitez créer une présentation contenant de grands objets (vidéo, audio, grandes images, etc.), vous pouvez utiliser la [facilité Blob](https://docs.aspose.com/slides/python-net/manage-blob/) pour réduire la consommation de mémoire.

{{%/alert %}} 


## Charger une Présentation

Aspose.Slides fournit [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) avec une méthode simple pour vous permettre de gérer les ressources externes. Ce code Python vous montre comment utiliser l'interface `IResourceLoadingCallback` :

```python
# [TODO[not_supported_yet]: implémentation python des interfaces .net]
```

<h2>Ouvrir et Enregistrer une Présentation</h2>

<a name="python-net-open-save-presentation"><strong>Étapes : Ouvrir et Enregistrer une Présentation en Python</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et passez le fichier que vous souhaitez ouvrir.
2. Enregistrez la présentation.

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier PPT
with slides.Presentation() as presentation:
    
    #...faites un travail ici...

    # Enregistrez votre présentation dans un fichier
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```