---
title: Gérer les BLOBs dans les présentations avec Python pour une utilisation efficace de la mémoire
linktitle: Gérer BLOB
type: docs
weight: 10
url: /fr/python-net/manage-blob/
keywords:
- grand objet
- grand élément
- grand fichier
- ajouter BLOB
- exporter BLOB
- ajouter image en tant que BLOB
- réduire la mémoire
- consommation de mémoire
- grande présentation
- fichier temporaire
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Gérer les données BLOB dans Aspose.Slides pour Python via .NET afin de simplifier les opérations sur les fichiers PowerPoint et OpenDocument pour une gestion efficace des présentations."
---
## **Vue d'ensemble**

Aspose.Slides fournit une gestion basée sur les BLOB pour les grandes données binaires dans les présentations afin d’aider à réduire la consommation de mémoire lors du travail avec de grandes images, audio, vidéo et fichiers de présentation.

Cet article montre comment utiliser le traitement basé sur les BLOB pour ajouter des médias volumineux à une présentation, exporter des médias volumineux depuis une présentation et charger des présentations volumineuses de manière plus efficace. Il explique également comment les fichiers temporaires peuvent être utilisés pendant le traitement et comment modifier le dossier utilisé pour les stocker.

## **À propos du BLOB**

**BLOB** (**Binary Large Object**) désigne généralement un élément volumineux (photo, présentation, document ou média) enregistré au format binaire. 

Aspose.Slides for Python via .NET vous permet d’utiliser les BLOB pour les objets de façon à réduire la consommation de mémoire lorsque de gros fichiers sont impliqués. 

## **Utiliser le BLOB pour réduire la consommation de mémoire**

### **Ajouter un gros fichier via BLOB à une présentation**

[Aspose.Slides](/slides/fr/python-net/) for .NET vous permet d’ajouter de gros fichiers (dans ce cas, un gros fichier vidéo) via un processus impliquant des BLOB afin de réduire la consommation de mémoire.

Ce code Python vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked parce que nous
        # n'avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Enregistre la présentation. Bien qu'une grande présentation soit générée, la consommation de mémoire
        # reste faible tout au long du cycle de vie de l'objet pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Exporter un gros fichier via BLOB depuis une présentation**
Aspose.Slides for Python via .NET vous permet d’exporter de gros fichiers (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOB depuis les présentations. Par exemple, vous pouvez avoir besoin d’extraire un gros fichier média d’une présentation sans le charger complètement en mémoire. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire. 

Ce code Python démontre l’opération décrite :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Enregistrez chaque vidéo dans un fichier. Pour éviter une utilisation élevée de la mémoire, nous avons besoin d'un tampon qui sera utilisé
	# pour transférer les données du flux vidéo de la présentation vers un flux pour un fichier vidéo nouvellement créé.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Parcourt les vidéos
    index = 0
    # Si nécessaire, vous pouvez appliquer les mêmes étapes aux fichiers audio. 
    for video in pres.videos:
		# Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons délibérément évité d'accéder aux propriétés
		# comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant toute la vidéo, ce qui
		# charge des octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et ne
		#  requiert pas de charger toute la vidéo en mémoire.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Ajouter une image en tant que BLOB dans une présentation**
Avec les méthodes de la classe [**ImageCollection**](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/), vous pouvez ajouter une grande image sous forme de flux pour qu’elle soit traitée comme un BLOB. 

Ce code Python vous montre comment ajouter une grande image via le processus BLOB :

```py
import aspose.slides as slides

# crée une nouvelle présentation à laquelle l'image sera ajoutée.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Mémoire et présentations volumineuses**

En général, charger une présentation volumineuse nécessite beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) cesse d’être utilisé. 

Considérons une présentation PowerPoint volumineuse (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard de chargement de la présentation est illustrée dans ce code Python :

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Mais cette méthode consomme environ 1,6 Go de mémoire temporaire. 

### **Charger une présentation volumineuse en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une présentation volumineuse tout en utilisant peu de mémoire. Ce code Python décrit l’implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Modifier le dossier des fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut des fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage en utilisant `temp_files_root_path` :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Lorsque vous utilisez `temp_files_root_path`, Aspose.Slides ne crée pas automatiquement de dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement. 
{{% /alert %}}

### **Libérer les objets Presentation pour libérer la mémoire**

Lors du traitement de présentations volumineuses, assurez‑vous que l’instance [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) est correctement libérée afin que la mémoire qu’elle occupe soit libérée. La façon recommandée est d’utiliser le gestionnaire de contexte (`with slides.Presentation(...) as presentation:`) comme illustré dans les exemples ci‑dessus ; il ferme automatiquement la présentation et libère les ressources non gérées à la sortie du bloc.

Si vous créez une présentation sans bloc `with`, appelez explicitement `presentation.dispose()` après l’avoir utilisée, puis supprimez toutes les références restantes afin que le ramasse‑miettes de Python puisse récupérer la mémoire.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...traitez la présentation...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Libérez explicitement les ressources.
presentation.dispose()
```

## **FAQ**

**Quelles données d’une présentation Aspose.Slides sont traitées comme BLOB et contrôlées par les options BLOB ?**

Les grands objets binaires tels que les images, l’audio et la vidéo sont traités comme BLOB. Le fichier de présentation complet implique également une gestion BLOB lors de son chargement ou de son enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et le recours aux fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine des fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB affectent‑ils les performances, et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite mémoire déplace davantage de travail vers les fichiers temporaires, diminuant la RAM au prix d’I/O supplémentaires. Ajustez le seuil [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/fr/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) pour atteindre le bon compromis selon votre charge de travail et votre environnement.

**Les options BLOB aident‑elles lors de l’ouverture de présentations extrêmement volumineuses (par exemple, plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire significativement l’utilisation maximale de RAM et stabiliser le traitement de très gros decks.

**Puis‑je appliquer les politiques BLOB lors du chargement depuis des flux plutôt que depuis des fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, maintenant une utilisation de mémoire prévisible pendant le traitement.