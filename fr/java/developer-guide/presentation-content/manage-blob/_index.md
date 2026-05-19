---
title: "Gérer les BLOBs de présentation en Java pour une utilisation efficace de la mémoire"
linktitle: "Gérer BLOB"
type: docs
weight: 10
url: /fr/java/manage-blob/
keywords:
- gros objet
- gros élément
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
- Java
- Aspose.Slides
description: "Gérer les données BLOB dans Aspose.Slides pour Java afin de rationaliser les opérations sur les fichiers PowerPoint et OpenDocument pour une manipulation efficace des présentations."
---
## **Vue d'ensemble**

Aspose.Slides fournit une prise en charge basée sur les BLOB pour les données binaires volumineuses dans les présentations afin de réduire la consommation de mémoire lors de la manipulation d’images, d’audio, de vidéo et de fichiers de présentation de grande taille.

Cet article montre comment utiliser le traitement basé sur les BLOB pour ajouter des médias volumineux à une présentation, exporter des médias volumineux d’une présentation et charger des présentations volumineuses de manière plus efficace. Il explique également comment des fichiers temporaires peuvent être utilisés pendant le traitement et comment modifier le dossier utilisé pour les stocker.

## **À propos des BLOB**

**BLOB** (**Binary Large Object**) désigne généralement un élément volumineux (photo, présentation, document ou média) enregistré au format binaire.

Aspose.Slides for Java vous permet d’utiliser des BLOB pour les objets de manière à réduire la consommation de mémoire lorsque des fichiers volumineux sont impliqués.

{{% alert title="Info" color="info" %}}
Pour contourner certaines limitations lors de l’interaction avec les flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et provoquera un chargement lent. Par conséquent, lorsque vous avez l’intention de charger une grande présentation, nous vous recommandons fortement d’utiliser le chemin du fichier de présentation et non son flux.
{{% /alert %}}

## **Utiliser les BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/java/) for Java vous permet d’ajouter de gros fichiers (dans ce cas, un fichier vidéo volumineux) via un processus impliquant des BLOB afin de réduire la consommation de mémoire.

Ce code Java montre comment ajouter un fichier vidéo volumineux via le processus BLOB à une présentation :

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked parce que nous
        //n'avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Enregistre la présentation. Pendant qu'une grande présentation est générée, la consommation de mémoire
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

Aspose.Slides for Java vous permet d’exporter de gros fichiers (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOB depuis des présentations. Par exemple, il peut être nécessaire d’extraire un fichier média volumineux d’une présentation sans le charger en mémoire. En exportant le fichier via le processus BLOB, la consommation de mémoire reste faible.

Ce code Java illustre l’opération décrite :

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Verrouille le fichier source et ne le charge PAS en mémoire
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Crée l'instance de Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Enregistrons chaque vidéo dans un fichier. Pour éviter une forte utilisation de la mémoire, nous avons besoin d'un tampon qui sera utilisé
    // pour transférer les données du flux vidéo de la présentation vers un flux pour le fichier vidéo nouvellement créé.
    byte[] buffer = new byte[8 * 1024];

    // Parcourt les vidéos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
        // comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant la vidéo complète, ce qui
        // charge des octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et ne
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
        // La consommation de mémoire restera faible quel que soit la taille de la vidéo ou de la présentation.
    }
    // Si nécessaire, vous pouvez appliquer les mêmes étapes pour les fichiers audio. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Ajouter une image en tant que BLOB à une présentation**

Avec les méthodes de l’interface [**IImageCollection**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IImageCollection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ImageCollection), vous pouvez ajouter une grande image sous forme de flux afin qu’elle soit traitée comme un BLOB.

Ce code Java montre comment ajouter une grande image via le processus BLOB :

```java
String pathToLargeImage = "large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked parce que nous
		// PAS l'intention d'accéder au fichier "largeImage.png" file.
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

## **Mémoire et présentations volumineuses**

En général, pour charger une présentation volumineuse, les ordinateurs ont besoin de beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) cesse d’être utilisé.

Considérez une présentation PowerPoint volumineuse (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard de chargement de la présentation est décrite dans ce code Java :

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Mais cette méthode consomme environ 1,6 Go de mémoire temporaire.

### **Charger une présentation volumineuse en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une présentation volumineuse tout en utilisant peu de mémoire. Ce code Java décrit l’implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :

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

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut des fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage à l’aide de `TempFilesRootPath` :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Lorsque vous utilisez `TempFilesRootPath`, Aspose.Slides ne crée pas automatiquement un dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement.
{{% /alert %}}

### **Libérer les objets Presentation pour libérer la mémoire**

Lors du traitement de présentations volumineuses, assurez‑vous que l’instance [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) est correctement libérée afin que la mémoire qu’elle occupait soit récupérée. Appelez `dispose()` après avoir fini d’utiliser la présentation pour libérer les ressources non gérées.

```java
Presentation presentation = new Presentation("large.pptx");

// ...traiter la présentation...
presentation.save("large.pdf", SaveFormat.Pdf);

// Libérer explicitement les ressources.
presentation.dispose();
```

## **FAQ**

**Quelles données d’une présentation Aspose.Slides sont traitées comme des BLOB et contrôlées par les options BLOB ?**

Les objets binaires volumineux tels que les images, l’audio et la vidéo sont traités comme des BLOB. Le fichier de présentation complet implique également la gestion des BLOB lors du chargement ou de l’enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et le débordement vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine des fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB affectent‑ils les performances, et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite mémoire déplace davantage de travail vers les fichiers temporaires, réduisant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fr/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) pour trouver le bon équilibre selon votre charge de travail et votre environnement.

**Les options BLOB aident‑elles lors de l’ouverture de présentations extrêmement volumineuses (par exemple, plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire considérablement l’utilisation maximale de RAM et stabiliser le traitement de présentations très grandes.

**Puis‑je appliquer les politiques BLOB lors du chargement depuis des flux au lieu de fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, ce qui maintient la consommation de mémoire prévisible pendant le traitement.