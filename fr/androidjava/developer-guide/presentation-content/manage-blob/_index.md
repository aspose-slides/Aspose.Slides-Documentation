---
title: Gérer les BLOB de présentation sur Android pour une utilisation efficace de la mémoire
linktitle: Gérer BLOB
type: docs
weight: 10
url: /fr/androidjava/manage-blob/
keywords:
- gros objet
- gros élément
- gros fichier
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
- Android
- Java
- Aspose.Slides
description: "Gérez les données BLOB dans Aspose.Slides pour Android via Java afin d'optimiser les opérations de fichiers PowerPoint et OpenDocument pour une manipulation efficace des présentations."
---
## **À propos de BLOB**

**BLOB** (**Binary Large Object**) désigne généralement un élément volumineux (photo, présentation, document ou média) enregistré dans des formats binaires.  

Aspose.Slides for Android via Java vous permet d’utiliser les BLOBs pour des objets de façon à réduire la consommation de mémoire lorsqu’il s’agit de fichiers volumineux.

{{% alert title="Info" color="info" %}}
Pour contourner certaines limitations lors de l’interaction avec les flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraîne la copie du contenu de la présentation et provoque un chargement lent. Ainsi, lorsque vous devez charger une grande présentation, nous vous recommandons fortement d’utiliser le chemin du fichier de présentation et non son flux.
{{% /alert %}}

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/androidjava/) pour Java vous permet d’ajouter des fichiers volumineux (dans ce cas, un gros fichier vidéo) grâce à un processus impliquant des BLOBs afin de réduire la consommation de mémoire.

Ce code Java montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked car nous
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

Aspose.Slides for Android via Java vous permet d’exporter des fichiers volumineux (par exemple un fichier audio ou vidéo) grâce à un processus impliquant des BLOBs depuis les présentations. Par exemple, vous pouvez avoir besoin d’extraire un gros fichier média d’une présentation sans le charger en mémoire. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire.

Ce code Java illustre l’opération décrite :

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Verrouille le fichier source et ne le charge PAS en mémoire
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// crée l'instance Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Sauvegardons chaque vidéo dans un fichier. Pour éviter une consommation élevée de mémoire, nous avons besoin d'un tampon qui sera utilisé
    // pour transférer les données du flux vidéo de la présentation vers un flux pour un nouveau fichier vidéo.
    byte[] buffer = new byte[8 * 1024];

    // Parcourt les vidéos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons délibérément évité d'accéder aux propriétés
        // comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant la vidéo complète, ce qui
        // provoque le chargement des octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et ne
        //  nécessite de charger toute la vidéo en mémoire.
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
    // Si nécessaire, vous pouvez appliquer les mêmes étapes aux fichiers audio. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Ajouter une image en tant que BLOB dans une présentation**

Avec les méthodes de l’interface [**IImageCollection**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IImageCollection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ImageCollection), vous pouvez ajouter une grande image sous forme de flux pour qu’elle soit traitée comme un BLOB.

Ce code Java montre comment ajouter une grande image via le processus BLOB :

```java
String pathToLargeImage = "large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous ne
		// pas l'intention d'accéder au fichier "largeImage.png" file.
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

En général, le chargement d’une grande présentation nécessite beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier source n’est plus utilisé.  

Considérons une grande présentation PowerPoint (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard de chargement de la présentation est illustrée dans ce code Java :

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

Grâce au processus BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code Java décrit l’implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :

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

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage avec `TempFilesRootPath` :

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

Lors du traitement de présentations volumineuses, assurez‑vous que l’instance [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) est correctement libérée afin que la mémoire qu’elle occupe soit libérée. Appelez `dispose()` après avoir fini d’utiliser la présentation pour libérer les ressources non gérées.

```java
Presentation presentation = new Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Quelles données d’une présentation Aspose.Slides sont traitées comme BLOB et contrôlées par les options BLOB ?**  
Les gros objets binaires tels que les images, l’audio et la vidéo sont traités comme BLOB. Le fichier complet de la présentation implique également la gestion des BLOB lors du chargement ou de l’enregistrement. Ces objets sont régis par des politiques BLOB qui permettent de gérer l’utilisation de la mémoire et le basculement vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**  
Utilisez [LoadOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine des fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB influencent‑ils les performances, et comment équilibrer vitesse et mémoire ?**  
Oui. Garder les BLOB en mémoire maximise la vitesse mais augmente la consommation RAM ; réduire la limite mémoire déplace davantage de travail vers les fichiers temporaires, diminuant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) pour trouver le bon équilibre selon votre charge de travail et votre environnement.

**Les options BLOB aident‑elles lors de l’ouverture de présentations extrêmement volumineuses (par ex. plusieurs gigaoctets) ?**  
Oui. [BlobManagementOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et le verrouillage de la source peut réduire considérablement l’utilisation maximale de RAM et stabiliser le traitement de très gros jeux de diapositives.

**Puis‑je appliquer les politiques BLOB lors du chargement depuis des flux au lieu de fichiers disque ?**  
Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, maintenant ainsi une utilisation prévisible de la mémoire pendant le traitement.