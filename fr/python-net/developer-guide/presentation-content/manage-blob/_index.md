---
title: Gérer les BLOBs dans les présentations avec Python pour une utilisation efficace de la mémoire
linktitle: Gérer BLOB
type: docs
weight: 10
url: /fr/python-net/manage-blob/
keywords:
- objet volumineux
- élément volumineux
- fichier volumineux
- ajouter BLOB
- exporter BLOB
- ajouter image en tant que BLOB
- réduire la mémoire
- consommation de mémoire
- présentation volumineuse
- fichier temporaire
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Gérer les données BLOB dans Aspose.Slides pour Python via .NET afin de rationaliser les opérations sur les fichiers PowerPoint et OpenDocument pour une gestion efficace des présentations."
---
## **À propos du BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré dans des formats binaires.

Aspose.Slides for Python via .NET vous permet d’utiliser les BLOB pour les objets d’une manière qui réduit la consommation de mémoire lorsque des fichiers volumineux sont impliqués.

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/python-net/) for .NET vous permet d’ajouter des fichiers volumineux (dans ce cas, un fichier vidéo volumineux) via un processus impliquant des BLOB afin de réduire la consommation de mémoire.

Ce script Python montre comment ajouter un fichier vidéo volumineux via le processus BLOB à une présentation :

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

        # Enregistre la présentation. Lorsqu'une grande présentation est générée, la consommation de mémoire
        # reste basse tout au long du cycle de vie de l'objet pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Exporter un fichier volumineux via BLOB depuis une présentation**
Aspose.Slides for Python via .NET vous permet d’exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOB depuis des présentations. Par exemple, vous pouvez avoir besoin d’extraire un fichier média volumineux d’une présentation sans le charger entièrement en mémoire. En exportant le fichier via le processus BLOB, vous maintenez la consommation de mémoire faible.

Ce code Python démontre l’opération décrite :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Enregistrons chaque vidéo dans un fichier. Pour éviter une utilisation élevée de la mémoire, nous avons besoin d'un tampon qui sera utilisé
	# pour transférer les données du flux vidéo de la présentation vers un flux pour un fichier vidéo nouvellement créé.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Parcourt les vidéos
    index = 0
    # Si nécessaire, vous pouvez appliquer les mêmes étapes aux fichiers audio. 
    for video in pres.videos:
		# Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
		# comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant toute la vidéo, ce qui alors
		# fait charger les octets en mémoire. Nous utilisons video.GetStream, qui renverra un Stream - et ne
		# nous oblige pas à charger toute la vidéo en mémoire.
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
Avec les méthodes de la classe [**ImageCollection**](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/), vous pouvez ajouter une image volumineuse en tant que flux pour qu’elle soit traitée comme un BLOB.

Ce code Python vous montre comment ajouter une image volumineuse via le processus BLOB :

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

Typiquement, pour charger une présentation volumineuse, les ordinateurs nécessitent beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) n’est plus utilisé.

Considérez une présentation PowerPoint volumineuse (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard de chargement de la présentation est illustrée dans ce code Python :

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

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage à l’aide de `temp_files_root_path` :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Lorsque vous utilisez `temp_files_root_path`, Aspose.Slides ne crée pas automatiquement un dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement.
{{% /alert %}}

### **Libérer les objets Presentation pour libérer la mémoire**

Lors du traitement de présentations volumineuses, assurez‑vous que l’instance `Presentation` est correctement libérée afin que la mémoire qu’elle occupait soit libérée. La méthode recommandée consiste à utiliser le gestionnaire de contexte (`with slides.Presentation(...) as presentation:`) comme indiqué dans les exemples ci‑dessus ; il ferme automatiquement la présentation et libère les ressources non gérées à la sortie du bloc.

Si vous créez une présentation sans bloc `with`, appelez explicitement `presentation.dispose()` après l’avoir utilisée, et supprimez toutes les références restantes afin que le ramasse‑miettes de Python puisse récupérer la mémoire.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")
# ...traiter la présentation...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)
# Libérez explicitement les ressources.
presentation.dispose()
```

## **FAQ**

**Quelles données d’une présentation Aspose.Slides sont traitées comme BLOB et contrôlées par les options BLOB ?**

Les objets binaires volumineux tels que images, audio et vidéo sont traités comme BLOB. Le fichier complet de la présentation implique également la gestion des BLOB lors du chargement ou de l’enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et de basculer vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine pour les fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB affectent-ils les performances et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite mémoire transfère davantage de travail vers les fichiers temporaires, diminuant la RAM au prix d’I/O supplémentaire. Ajustez le seuil [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/fr/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) pour obtenir le bon équilibre pour votre charge de travail et votre environnement.

**Les options BLOB aident‑elles lors de l’ouverture de présentations extrêmement volumineuses (par exemple, plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de source peut réduire considérablement l’utilisation maximale de RAM et stabiliser le traitement de présentations très volumineuses.

**Puis‑je utiliser les politiques BLOB lors du chargement depuis des flux au lieu de fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, gardant la consommation de mémoire prévisible pendant le traitement.