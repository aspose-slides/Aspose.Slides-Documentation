---
title: Gérer les BLOBs de présentation en Python via Java pour une utilisation efficace de la mémoire
linktitle: Gérer les BLOB
type: docs
weight: 10
url: /fr/python-java/manage-blob/
keywords:
- grand objet
- grand élément
- gros fichier
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
- Java
- Aspose.Slides
description: "Gérez les données BLOB dans Aspose.Slides pour Python via Java afin de rationaliser les opérations sur les fichiers PowerPoint et OpenDocument pour une gestion efficace des présentations."
---
## **Vue d'ensemble**

Aspose.Slides fournit une gestion basée sur les BLOB pour les données binaires volumineuses dans les présentations afin d’aider à réduire la consommation de mémoire lors de la manipulation d’images, d’audio, de vidéo et de fichiers de présentation volumineux.

Cet article montre comment utiliser le traitement basé sur les BLOB pour ajouter des médias volumineux à une présentation, exporter des médias volumineux depuis une présentation et charger des présentations volumineuses de manière plus efficace. Il explique également comment des fichiers temporaires peuvent être utilisés pendant le traitement et comment modifier le dossier utilisé pour les stocker.

## **À propos du BLOB**

Un **BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré en format binaire.

Aspose.Slides for Python via Java vous permet d’utiliser les BLOB pour les objets de façon à réduire la consommation de mémoire lorsque des fichiers volumineux sont impliqués.

{{% alert color="info" title="Note" %}}
Pour contourner certaines limites lors de l’interaction avec les flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation à partir de son flux entraînera la copie du contenu de la présentation et provoquera un chargement lent. Par conséquent, lorsque vous avez l’intention de charger une grande présentation, nous vous recommandons fortement d’utiliser le chemin du fichier de la présentation et non son flux.
{{% /alert %}}

## **Utiliser les BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux à une présentation en utilisant les BLOB**

[Aspose.Slides](/slides/fr/python-java/) for Python via Java vous permet d’ajouter des fichiers volumineux (dans ce cas, un fichier vidéo volumineux) via un processus impliquant des BLOB afin de réduire la consommation de mémoire.

Ce code Python vous montre comment ajouter un fichier vidéo volumineux via le processus BLOB à une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Créez une nouvelle présentation à laquelle la vidéo sera ajoutée.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Gardez le flux verrouillé car nous n'avons pas l'intention d'accéder au fichier vidéo.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Enregistrez la présentation tout en maintenant la consommation de mémoire faible.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Exporter un fichier volumineux depuis une présentation en utilisant les BLOB**
Aspose.Slides for Python via Java vous permet d’exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOB depuis des présentations. Par exemple, il se peut que vous deviez extraire un fichier média volumineux d’une présentation sans le charger en mémoire. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire.

Ce code en Python illustre l’opération décrite :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Verrouillez le fichier source au lieu de le charger en mémoire.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Transférez les données vidéo via un tampon pour garder la consommation de mémoire faible.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Utilisez le flux au lieu de charger toute la vidéo dans un tableau d'octets.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Si nécessaire, appliquez les mêmes étapes aux fichiers audio.
finally:
    presentation.dispose()
```

### **Ajouter une image en tant que BLOB à une présentation**
Avec les méthodes de la classe [ImageCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/) vous pouvez ajouter une grande image en tant que flux afin qu’elle soit traitée comme un BLOB.

Ce code Python vous montre comment ajouter une grande image via le processus BLOB :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Créez une nouvelle présentation à laquelle l'image sera ajoutée.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Gardez le flux verrouillé car nous n'avons pas l'intention d'accéder au fichier image.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Enregistrez la présentation tout en maintenant une faible consommation de mémoire.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Mémoire et présentations volumineuses**

En général, pour charger une présentation volumineuse, les ordinateurs ont besoin de beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) cesse d’être utilisé.

Considérez une grande présentation PowerPoint (large.pptx) qui contient un fichier vidéo de 1,5 Go. La méthode standard de chargement de la présentation est décrite dans ce code Python :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Mais cette méthode consomme environ 1,6 Go de mémoire temporaire.

### **Charger une présentation volumineuse en tant que BLOB**

En utilisant la gestion des BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code Python montre comment utiliser la gestion des BLOB pour charger un fichier de présentation volumineux (large.pptx) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Modifier le dossier des fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut pour les fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage en utilisant [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
Lorsque vous utilisez [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides ne crée pas automatiquement de dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement.
{{% /alert %}}

### **Libérer les objets Presentation pour libérer la mémoire**

Lors du traitement de présentations volumineuses, assurez‑vous que l’instance [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) soit correctement libérée afin que la mémoire qu’elle occupait soit libérée. Appelez [Presentation.dispose](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#dispose) après avoir fini d’utiliser la présentation pour libérer les ressources non gérées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...traiter la présentation...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Libérer explicitement les ressources.
    presentation.dispose()
```

## **FAQ**

**Quelles données d’une présentation Aspose.Slides sont traitées comme un BLOB et contrôlées par les options BLOB ?**

Les gros objets binaires tels que les images, l’audio et la vidéo sont traités comme des BLOB. Le fichier de la présentation complet implique également la gestion des BLOB lors de son chargement ou de son enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et le débordement vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine pour les fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB influent-ils sur les performances, et comment équilibrer vitesse et mémoire ?**

Oui. Garder les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; diminuer la limite de mémoire transfère davantage de travail vers les fichiers temporaires, réduisant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fr/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) pour trouver le bon équilibre selon votre charge de travail et votre environnement.

**Les options BLOB aident‑elles lors de l’ouverture de présentations extrêmement volumineuses (par exemple, plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/blobmanagementoptions/) est conçu pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire considérablement l’utilisation maximale de RAM et stabiliser le traitement de très grands decks.

**Puis‑je utiliser les politiques BLOB lors du chargement depuis des flux plutôt que des fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, maintenant une utilisation de mémoire prévisible pendant le traitement.