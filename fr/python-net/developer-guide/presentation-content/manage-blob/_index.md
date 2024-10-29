---
title: Gérer BLOB
type: docs
weight: 10
url: /fr/python-net/manage-blob/
keywords: "Ajouter un blob, Exporter un blob, Ajouter une image en tant que blob, Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter un blob à une présentation PowerPoint en Python. Exporter un blob. Ajouter une image en tant que blob"
---

### **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré en formats binaires.

Aspose.Slides pour Python via .NET vous permet d'utiliser des BLOBs pour des objets de manière à réduire la consommation de mémoire lorsque des fichiers volumineux sont impliqués.

# **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/python-net/) pour .NET vous permet d'ajouter des fichiers volumineux (dans ce cas, un grand fichier vidéo) à travers un processus impliquant des BLOBs pour réduire la consommation de mémoire.

Ce code Python vous montre comment ajouter un grand fichier vidéo via le processus BLOB à une présentation :

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked parce que nous ne
        # avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Sauvegarde la présentation. Bien qu'une grande présentation soit produite, la consommation de mémoire
        # reste faible pendant le cycle de vie de l'objet pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **Exporter un fichier volumineux via BLOB depuis la présentation**
Aspose.Slides pour Python via .NET vous permet d'exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) à travers un processus impliquant des BLOBs depuis des présentations. Par exemple, vous pouvez avoir besoin d'extraire un grand fichier multimédia d'une présentation mais ne voulez pas que le fichier soit chargé dans la mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous pouvez maintenir la consommation de mémoire à un niveau bas.

Ce code en Python illustre l'opération décrite :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Enregistrons chaque vidéo dans un fichier. Pour prévenir une forte consommation de mémoire, nous avons besoin d'un tampon qui sera utilisé
	# pour transférer les données du flux vidéo de la présentation à un flux pour un nouveau fichier vidéo créé.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Itère à travers les vidéos
    index = 0
    # Si nécessaire, vous pouvez appliquer les mêmes étapes pour des fichiers audio. 
    for video in pres.videos:
		# Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
		# comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant une vidéo complète, ce qui 
		# entraîne le chargement des octets dans la mémoire. Nous utilisons video.GetStream, qui renverra un Stream - et ne nécessite PAS
		# de charger la vidéo entière dans la mémoire.
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

### **Ajouter une image en tant que BLOB dans la présentation**
Avec les méthodes de l'interface [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) et de la classe [**ImageCollection** ](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/), vous pouvez ajouter une grande image en tant que flux pour qu'elle soit traitée comme un BLOB.

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

## **Mémoire et grandes présentations**

Typiquement, pour charger une grande présentation, les ordinateurs nécessitent beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé dans la mémoire et le fichier (à partir duquel la présentation a été chargée) cesse d'être utilisé.

Considérez une grande présentation PowerPoint (large.pptx) qui contient un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code Python :

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Mais cette méthode consomme environ 1,6 Go de mémoire temporaire.

### **Charger une grande présentation en tant que BLOB**

À travers le processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code Python décrit l'implémentation où le processus BLOB est utilisé pour charger un grand fichier de présentation (large.pptx) :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

#### **Changer le dossier pour les fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut pour les fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage en utilisant `temp_files_root_path` :

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