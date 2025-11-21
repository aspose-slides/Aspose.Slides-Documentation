---
title: Gérer le Blob
type: docs
weight: 10
url: /fr/nodejs-java/manage-blob/
description: Gérer le Blob dans une présentation PowerPoint en utilisant JavaScript. Utiliser le Blob pour réduire la consommation de mémoire dans une présentation PowerPoint en utilisant JavaScript. Ajouter un gros fichier via Blob à une présentation PowerPoint en utilisant JavaScript. Exporter un gros fichier via Blob depuis une présentation PowerPoint en utilisant JavaScript. Charger une grande présentation PowerPoint en tant que Blob en utilisant JavaScript.
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un gros élément (photo, présentation, document ou média) enregistré sous des formats binaires. 

Aspose.Slides for Node.js via Java vous permet d'utiliser des BLOBs pour les objets de manière à réduire la consommation de mémoire lorsqu'il s'agit de gros fichiers.

{{% alert title="Info" color="info" %}}
Pour contourner certaines limitations lors de l'interaction avec des flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et provoquera un chargement lent. Ainsi, lorsque vous avez l'intention de charger une grande présentation, nous vous recommandons fortement d'utiliser le chemin du fichier de présentation et non son flux.
{{% /alert %}}

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un gros fichier via BLOB à une présentation**

[Aspose.Slides](/slides/fr/nodejs-java/) for Node.js via Java vous permet d'ajouter de gros fichiers (dans ce cas, un gros fichier vidéo) via un processus impliquant des BLOBs afin de réduire la consommation de mémoire.

Ce JavaScript vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :
```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked car nous
        // n'avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Enregistre la présentation. Bien qu'une grande présentation soit générée, la consommation de mémoire
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


### **Exporter un gros fichier via BLOB depuis une présentation**

Aspose.Slides for Node.js via Java vous permet d'exporter de gros fichiers (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOBs depuis les présentations. Par exemple, vous pouvez avoir besoin d'extraire un gros fichier multimédia d'une présentation sans le charger en mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire.

Ce code en JavaScript démontre l'opération décrite :
```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Verrouille le fichier source et ne le charge PAS en mémoire
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// crée l'instance Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Enregistrons chaque vidéo dans un fichier. Pour éviter une consommation élevée de mémoire, nous avons besoin d'un tampon qui sera utilisé
    // pour transférer les données du flux vidéo de la présentation vers un flux pour un nouveau fichier vidéo.
    var buffer = new byte[8 * 1024];
    // Parcourt les vidéos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
        // comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant toute la vidéo, ce qui
        // entraîne le chargement des octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et ne
        // nécessite pas de charger toute la vidéo en mémoire.
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
        // La consommation de mémoire restera faible quelle que soit la taille de la vidéo ou de la présentation.
    }
    // Si nécessaire, vous pouvez appliquer les mêmes étapes pour les fichiers audio.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```


### **Ajouter une image en tant que BLOB dans une présentation**

Avec les méthodes de la classe [**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) et [**ImageCollection** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection), vous pouvez ajouter une grande image sous forme de flux pour qu'elle soit traitée comme un BLOB.

Ce code JavaScript vous montre comment ajouter une grande image via le processus BLOB :
```javascript
var pathToLargeImage = "large_image.jpg";
// crée une nouvelle présentation à laquelle l'image sera ajoutée.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous
        // PAS l'intention d'accéder au fichier "largeImage.png" file.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Enregistre la présentation. Lorsqu'une grande présentation est générée, la consommation de mémoire
        // reste faible tout au long du cycle de vie de l'objet pres.
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

Typiquement, pour charger une grande présentation, les ordinateurs nécessitent beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) n'est plus utilisé. 

Considérez une grande présentation PowerPoint (large.pptx) contenant un fichier vidéo de 1,5 Go. Le mode standard de chargement de la présentation est décrit dans ce code JavaScript :
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

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code JavaScript décrit l'implémentation où le processus BLOB est utilisé pour charger un gros fichier de présentation (large.pptx) :
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

## **FAQ**

**Quelles données d'une présentation Aspose.Slides sont traitées comme BLOB et contrôlées par les options BLOB ?**

Les gros objets binaires tels que les images, l'audio et la vidéo sont traités comme des BLOB. Le fichier complet de la présentation implique également la gestion des BLOB lors du chargement ou de l'enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l'utilisation de la mémoire et de recourir à des fichiers temporaires lorsque nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d'une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine pour les fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB affectent-ils les performances, et comment équilibrer vitesse et mémoire ?**

Oui. Garder les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite mémoire transfère davantage de travail vers les fichiers temporaires, diminuant ainsi la RAM au prix d'un I/O supplémentaire. Utilisez la méthode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) pour atteindre le bon équilibre selon votre charge de travail et votre environnement.

**Les options BLOB aident‑elles lors de l'ouverture de présentations extrêmement volumineuses (par ex., plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire considérablement l'utilisation maximale de RAM et stabiliser le traitement de présentations très volumineuses.

**Puis‑je utiliser les politiques BLOB lors du chargement à partir de flux plutôt que de fichiers disque ?**

Oui. Les mêmes règles s'appliquent aux flux : l'instance de présentation peut posséder et verrouiller le flux d'entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu'ils sont autorisés, maintenant ainsi une utilisation prévisible de la mémoire pendant le traitement.