---
title: Gérer les BLOBs de présentation en Java pour une utilisation efficace de la mémoire
linktitle: Gérer BLOB
type: docs
weight: 10
url: /fr/java/manage-blob/
keywords:
- grand objet
- grand élément
- grand fichier
- ajouter BLOB
- exporter BLOB
- ajouter image comme BLOB
- réduire la mémoire
- consommation de mémoire
- grande présentation
- fichier temporaire
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: Gérer les données BLOB dans Aspose.Slides pour Java afin de simplifier les opérations de fichiers PowerPoint et OpenDocument pour une gestion efficace des présentations.
---

## **À propos du BLOB**

**BLOB** (**Objet binaire volumineux**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré dans des formats binaires. 

Aspose.Slides for Java vous permet d'utiliser les BLOBs pour les objets de manière à réduire la consommation de mémoire lorsqu'il s'agit de fichiers volumineux. 

{{% alert title="Info" color="info" %}}
Pour contourner certaines limitations lors de l'interaction avec des flux, Aspose.Slides peut copier le contenu du flux. Charger une présentation volumineuse via son flux entraînera la copie du contenu de la présentation et ralentira le chargement. Par conséquent, lorsque vous prévoyez de charger une présentation volumineuse, nous vous recommandons vivement d'utiliser le chemin du fichier de présentation plutôt que son flux.
{{% /alert %}}

## **Utiliser le BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/java/) pour Java vous permet d'ajouter des fichiers volumineux (dans ce cas, un fichier vidéo volumineux) via un processus impliquant des BLOBs afin de réduire la consommation de mémoire. 

Ce code Java vous montre comment ajouter un fichier vidéo volumineux via le processus BLOB à une présentation :
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked parce que nous
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

Aspose.Slides for Java vous permet d'exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOBs depuis des présentations. Par exemple, il se peut que vous deviez extraire un fichier multimédia volumineux d'une présentation sans que le fichier ne soit chargé en mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire. 

Ce code Java illustre l'opération décrite :
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Verrouille le fichier source et ne le charge PAS en mémoire
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Crée l'instance de Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Enregistrons chaque vidéo dans un fichier. Pour éviter une utilisation élevée de la mémoire, nous avons besoin d'un tampon qui sera utilisé
    // pour transférer les données du flux vidéo de la présentation vers un flux d'un nouveau fichier vidéo.
    byte[] buffer = new byte[8 * 1024];

    // Parcourt les vidéos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
        // comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant la vidéo complète, ce qui
        // entraîne le chargement des octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et ne
        //  requiert que nous chargions toute la vidéo en mémoire.
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
        // La consommation de mémoire restera faible quelle que soit la taille de la vidéo ou de la présentation.
    }
    // Si nécessaire, vous pouvez appliquer les mêmes étapes pour les fichiers audio. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **Ajouter une image en tant que BLOB dans une présentation**

Avec les méthodes de l'interface [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection), vous pouvez ajouter une image volumineuse en tant que flux afin qu'elle soit traitée comme un BLOB. 

Ce code Java vous montre comment ajouter une grande image via le processus BLOB :
```java
String pathToLargeImage = "large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous ne
		// PAS voulons accéder au fichier "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Enregistre la présentation. Lorsqu'une grande présentation est générée, la consommation de mémoire
		// reste faible pendant le cycle de vie de l'objet pres.
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

Considérons une grande présentation PowerPoint (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code Java :
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


Cependant, cette méthode consomme environ 1,6 Go de mémoire temporaire. 

### **Charger une grande présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code Java décrit l'implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :
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

**Quelles données dans une présentation Aspose.Slides sont traitées comme des BLOB et contrôlées par les options BLOB ?**

Les grands objets binaires tels que les images, l’audio et la vidéo sont traités comme des BLOB. Le fichier complet de la présentation implique également la gestion des BLOB lors du chargement ou de l’enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et de déverser les données vers des fichiers temporaires si nécessaire. 

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine des fichiers temporaires et sélectionnez le comportement de verrouillage de la source. 

**Les paramètres BLOB affectent-ils les performances, et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite de mémoire déplace davantage de travail vers les fichiers temporaires, réduisant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) pour trouver le bon équilibre pour votre charge de travail et votre environnement. 

**Les options BLOB aident-elles lors de l'ouverture de présentations extrêmement volumineuses (par exemple, plusieurs gigaoctets) ?**

Oui. Les [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire considérablement l’utilisation maximale de RAM et stabiliser le traitement de jeux de diapositives très volumineux. 

**Puis-je utiliser les politiques BLOB lors du chargement depuis des flux au lieu de fichiers disque ?**

Oui. Les mêmes règles s'appliquent aux flux : l'instance de présentation peut posséder et verrouiller le flux d'entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu'ils sont autorisés, maintenant une utilisation de la mémoire prévisible pendant le traitement.