---
title: Gérer les BLOB de présentation en JavaScript pour une utilisation efficace de la mémoire
linktitle: Gérer les BLOB
type: docs
weight: 10
url: /fr/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérez les données BLOB en JavaScript avec Aspose.Slides pour Node.js afin de simplifier les opérations sur les fichiers PowerPoint et OpenDocument pour une gestion efficace des présentations."
---
## **Vue d'ensemble**

Aspose.Slides fournit une gestion basée sur les BLOB pour les données binaires volumineuses dans les présentations afin d'aider à réduire la consommation de mémoire lors du traitement d'images, d'audios, de vidéos et de fichiers de présentation volumineux.

Cet article montre comment utiliser le traitement basé sur les BLOB pour ajouter des médias volumineux à une présentation, exporter des médias volumineux depuis une présentation, et charger des présentations volumineuses de manière plus efficace. Il explique également comment les fichiers temporaires peuvent être utilisés pendant le traitement et comment changer le dossier utilisé pour les stocker.

## **À propos des BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré dans des formats binaires. 

Aspose.Slides for Node.js via Java vous permet d'utiliser les BLOB pour les objets de manière à réduire la consommation de mémoire lorsque des fichiers volumineux sont impliqués.

{{% alert title="Info" color="info" %}}
Pour contourner certaines limitations lors de l'interaction avec des flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et provoquera un chargement lent. Par conséquent, lorsque vous avez l'intention de charger une grande présentation, nous vous recommandons fortement d'utiliser le chemin du fichier de présentation et non son flux.
{{% /alert %}}

## **Utiliser les BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/nodejs-java/) for Node.js via Java permet d'ajouter des fichiers volumineux (dans ce cas, un fichier vidéo volumineux) via un processus impliquant des BLOB afin de réduire la consommation de mémoire.

Ce code JavaScript vous montre comment ajouter un fichier vidéo volumineux via le processus BLOB à une présentation :
```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked parce que nous
        // n'avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Enregistre la présentation. Pendant qu'une grande présentation est générée, la consommation de mémoire
        // reste faible tout au long du cycle de vie de l'objet pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Exporter un fichier volumineux via BLOB depuis une présentation**

Aspose.Slides for Node.js via Java vous permet d'exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOB depuis des présentations. Par exemple, il se peut que vous deviez extraire un fichier média volumineux d'une présentation mais ne souhaitiez pas que le fichier soit chargé en mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire.

Ce code JavaScript démontre l'opération décrite :
```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Verrouille le fichier source et NE le charge PAS en mémoire
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// crée l'instance Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Enregistrons chaque vidéo dans un fichier. Pour éviter une forte utilisation de la mémoire, nous avons besoin d'un tampon qui sera utilisé
    // pour transférer les données du flux vidéo de la présentation vers un flux pour un nouveau fichier vidéo.
    var buffer = new byte[8 * 1024];
    // Parcourt les vidéos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
        // comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant la vidéo complète, ce qui ensuite
        // entraîne le chargement des octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et NE
        // nous oblige pas à charger toute la vidéo en mémoire.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // La consommation de mémoire restera faible quel que soit la taille de la vidéo ou de la présentation.
    }
    // Si nécessaire, vous pouvez appliquer les mêmes étapes pour les fichiers audio.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Ajouter une image en tant que BLOB dans une présentation**

Avec les méthodes de la classe [**ImageCollection**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ImageCollection) et de la classe [**ImageCollection** ](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ImageCollection), vous pouvez ajouter une grande image en tant que flux pour qu'elle soit traitée comme un BLOB.

Ce code JavaScript vous montre comment ajouter une grande image via le processus BLOB :
```javascript
var pathToLargeImage = "large_image.jpg";
// crée une nouvelle présentation à laquelle l'image sera ajoutée.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked parce que nous
        // N'AVONS PAS l'intention d'accéder au "largeImage.png" file.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Enregistre la présentation. Pendant qu'une grande présentation est générée, la consommation de mémoire
        // reste faible tout au long du cycle de vie de l'objet pres
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mémoire et présentations volumineuses**

Typiquement, pour charger une grande présentation, les ordinateurs nécessitent beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) n’est plus utilisé.

Considérez une grande présentation PowerPoint (large.pptx) qui contient un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code JavaScript :
```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Mais cette méthode consomme environ 1,6 Go de mémoire temporaire. 

### **Charger une grande présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code JavaScript décrit l'implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Modifier le dossier des fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut des fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage en utilisant `setTempFilesRootPath` :
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Lorsque vous utilisez `setTempFilesRootPath`, Aspose.Slides ne crée pas automatiquement un dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement. 
{{% /alert %}}

### **Libérer les objets Presentation pour libérer la mémoire**

Lors du traitement de présentations volumineuses, assurez-vous que l'instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) est correctement libérée afin que la mémoire qu'elle occupait soit libérée. Appelez `dispose()` après avoir terminé l'utilisation de la présentation pour libérer les ressources non gérées.
```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Quelles données dans une présentation Aspose.Slides sont traitées comme des BLOB et contrôlées par les options BLOB ?**

Les objets binaires volumineux tels que les images, l’audio et la vidéo sont traités comme des BLOB. Le fichier complet de la présentation implique également une gestion des BLOB lors de son chargement ou de son enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et de déverser vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d'une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/blobmanagementoptions/). Vous définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine pour les fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les réglages des BLOB affectent-ils les performances, et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite de mémoire déplace davantage de travail vers les fichiers temporaires, réduisant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) pour atteindre le bon équilibre pour votre charge de travail et votre environnement.

**Les options BLOB aident-elles à l'ouverture de présentations extrêmement volumineuses (par exemple, plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire considérablement l’utilisation maximale de RAM et stabiliser le traitement des présentations très volumineuses.

**Puis-je utiliser les politiques BLOB lors du chargement depuis des flux plutôt que depuis des fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, maintenant une utilisation de la mémoire prévisible pendant le traitement.