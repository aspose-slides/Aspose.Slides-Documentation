---
title: Gérer les BLOB de présentation en Java pour une utilisation efficace de la mémoire
linktitle: Gérer BLOB
type: docs
weight: 10
url: /fr/java/manage-blob/
keywords:
- grand objet
- grand élément
- gros fichier
- ajouter BLOB
- exporter BLOB
- ajouter une image en tant que BLOB
- réduire la mémoire
- consommation de mémoire
- grande présentation
- fichier temporaire
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérez les données BLOB dans Aspose.Slides pour Java afin de rationaliser les opérations de fichiers PowerPoint et OpenDocument pour une manipulation efficace des présentations."
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré sous des formats binaires. 

Aspose.Slides for Java vous permet d'utiliser les BLOBs pour les objets de manière à réduire la consommation de mémoire lorsque des fichiers volumineux sont impliqués. 

{{% alert title="Info" color="info" %}}
Pour contourner certaines limitations lors de l'interaction avec des flux, Aspose.Slides peut copier le contenu du flux. Le chargement d'une présentation volumineuse via son flux entraînera la copie du contenu de la présentation et provoquera un chargement lent. Par conséquent, lorsque vous avez l'intention de charger une présentation volumineuse, nous vous recommandons vivement d'utiliser le chemin du fichier de présentation et non son flux.
{{% /alert %}}

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/java/) for Java vous permet d'ajouter de gros fichiers (dans ce cas, un fichier vidéo volumineux) via un processus impliquant des BLOBs afin de réduire la consommation de mémoire.

Ce code Java vous montre comment ajouter un fichier vidéo volumineux via le processus BLOB à une présentation :
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked car nous
        // ne prévoyons pas d'accéder au fichier "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Enregistre la présentation. Lorsqu'une grande présentation est générée, la consommation de mémoire
        // reste faible tout au long du cycle de vie de l'objet pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **Exporter un fichier volumineux via BLOB depuis une présentation**
Aspose.Slides for Java vous permet d'exporter de gros fichiers (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOBs depuis les présentations. Par exemple, il se peut que vous ayez besoin d'extraire un fichier média volumineux d'une présentation mais que vous ne vouliez pas que le fichier soit chargé en mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous gardez la consommation de mémoire basse. 

Ce code en Java démontre l'opération décrite :
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Locks the source file and does NOT load it into memory
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        //  require us to load the whole video into the memory.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Memory consumption will remain low regardless of the size of the video or presentation.
    }
    // If necessary, you can apply the same steps for audio files. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **Ajouter une image en tant que BLOB à une présentation**
Avec les méthodes de l'interface [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection), vous pouvez ajouter une grande image en tant que flux pour qu'elle soit traitée comme un BLOB. 

Ce code Java vous montre comment ajouter une grande image via le processus BLOB :
```java
String pathToLargeImage = "large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous
		// ne prévoyons PAS d'accéder au fichier "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Enregistre la présentation. Pendant la génération d'une grande présentation, la consommation de mémoire
		// reste faible tout au long du cycle de vie de l'objet pres.
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **Mémoire et présentations volumineuses**

En général, le chargement d'une présentation volumineuse nécessite beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) n'est plus utilisé. 

Considérons une grande présentation PowerPoint (large.pptx) qui contient un fichier vidéo de 1,5 Go. La méthode standard de chargement de la présentation est décrite dans ce code Java :
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


Mais cette méthode consomme environ 1,6 Go de mémoire temporaire. 

### **Charger une grande présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code Java décrit l'implémentation où le processus BLOB est utilisé pour charger un gros fichier de présentation (large.pptx) :
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Modifier le dossier des fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut des fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage en utilisant `TempFilesRootPath` :
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
Lorsque vous utilisez `TempFilesRootPath`, Aspose.Slides ne crée pas automatiquement de dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement. 
{{% /alert %}}

## **FAQ**

**Quelles données d’une présentation Aspose.Slides sont traitées comme BLOB et contrôlées par les options BLOB ?**

Les objets binaires volumineux tels que les images, l’audio et la vidéo sont traités comme BLOB. Le fichier complet de la présentation implique également la gestion des BLOB lors du chargement ou de l’enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et le déversement vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou refusez les fichiers temporaires, choisissez le chemin racine pour les fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB affectent-ils les performances et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite de mémoire transfère plus de travail vers les fichiers temporaires, diminuant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) pour trouver le bon compromis selon votre charge de travail et votre environnement.

**Les options BLOB aident‑elles lors de l'ouverture de présentations extrêmement volumineuses (par ex. plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : l’activation des fichiers temporaires et l’utilisation du verrouillage de la source peuvent réduire considérablement le pic de RAM et stabiliser le traitement de très grands decks.

**Puis‑je utiliser les politiques BLOB lors du chargement depuis des flux au lieu de fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, maintenant une consommation de mémoire prévisible pendant le traitement.