---
title: Gérer les BLOBs de présentation sur Android pour une utilisation efficace de la mémoire
linktitle: Gérer le BLOB
type: docs
weight: 10
url: /fr/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Gérer les données BLOB dans Aspose.Slides pour Android via Java afin de simplifier les opérations de fichiers PowerPoint et OpenDocument pour une manipulation efficace des présentations."
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré au format binaire.  

Aspose.Slides pour Android via Java vous permet d’utiliser les BLOB pour les objets d’une manière qui réduit la consommation de mémoire lorsque de gros fichiers sont impliqués.

{{% alert title="Info" color="info" %}}
Pour contourner certaines limitations lors de l’interaction avec les flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et ralentira le chargement. Par conséquent, lorsque vous prévoyez de charger une grande présentation, nous vous recommandons fortement d’utiliser le chemin du fichier de la présentation et non son flux.
{{% /alert %}}

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un gros fichier via BLOB à une présentation**

[Aspose.Slides](/slides/fr/androidjava/) pour Java permet d’ajouter de gros fichiers (dans ce cas, un gros fichier vidéo) via un processus impliquant des BLOB pour réduire la consommation de mémoire.

Ce code Java vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked parce que nous ne
        // avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Enregistre la présentation. Pendant qu'une grande présentation est générée,
        // la consommation de mémoire reste faible tout au long du cycle de vie de l'objet pres
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **Exporter un gros fichier via BLOB depuis une présentation**

Aspose.Slides pour Android via Java permet d’exporter de gros fichiers (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOB depuis les présentations. Par exemple, vous pouvez devoir extraire un gros fichier média d’une présentation sans le charger en mémoire. En exportant le fichier via le processus BLOB, vous maintenez la consommation de mémoire basse.

Ce code Java démontre l’opération décrite :
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Verrouille le fichier source et ne le charge PAS en mémoire
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// crée l'instance de Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Enregistrons chaque vidéo dans un fichier. Pour éviter une forte consommation de mémoire, nous avons besoin d'un tampon qui sera utilisé
    // pour transférer les données du flux vidéo de la présentation vers un flux d'un nouveau fichier vidéo.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
        // comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant toute la vidéo, ce qui
        // charge les octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et ne
        //  nécessite pas de charger toute la vidéo en mémoire.
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

Avec les méthodes de l’interface [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection), vous pouvez ajouter une grande image sous forme de flux pour qu’elle soit traitée comme un BLOB.

Ce code Java vous montre comment ajouter une grande image via le processus BLOB :
```java
String pathToLargeImage = "large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked parce que nous
		// n'avons PAS l'intention d'accéder au fichier "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Enregistre la présentation. Pendant qu'une grande présentation est générée, la consommation de mémoire
		// reste faible tout au long du cycle de vie de l'objet pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **Mémoire et grandes présentations**

En général, charger une grande présentation nécessite beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier source cesse d’être utilisé.  

Considérons une grande présentation PowerPoint (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard de chargement de la présentation est décrite dans ce code Java :
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


Cette méthode consomme environ 1,6 Go de mémoire temporaire.  

### **Charger une grande présentation en tant que BLOB**

Via le processus BLOB, vous pouvez charger une grande présentation en utilisant très peu de mémoire. Ce code Java décrit l’implémentation où le processus BLOB est utilisé pour charger un gros fichier de présentation (large.pptx) :
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

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier le paramètre de stockage avec `TempFilesRootPath` :
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
Les objets binaires volumineux tels que les images, l’audio et la vidéo sont traités comme BLOB. Le fichier complet de la présentation implique également la gestion des BLOB lors du chargement ou de l’enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et le transfert vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**  
Utilisez [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/). Vous pouvez y définir la limite en mémoire pour les BLOB, autoriser ou interdire les fichiers temporaires, choisir le chemin racine des fichiers temporaires et sélectionner le comportement de verrouillage de la source.

**Les paramètres BLOB influencent-ils les performances, et comment équilibrer vitesse et mémoire ?**  
Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; diminuer la limite mémoire déplace davantage de travail vers les fichiers temporaires, réduisant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) pour trouver le bon compromis selon votre charge de travail et votre environnement.

**Les options BLOB aident-elles à ouvrir des présentations extrêmement volumineuses (par exemple, plusieurs gigaoctets) ?**  
Oui. [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire considérablement l’utilisation maximale de RAM et stabiliser le traitement de très gros decks.

**Puis‑je appliquer les politiques BLOB lors du chargement depuis des flux plutôt que des fichiers disque ?**  
Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, maintenant ainsi une utilisation prévisible de la mémoire pendant le traitement.