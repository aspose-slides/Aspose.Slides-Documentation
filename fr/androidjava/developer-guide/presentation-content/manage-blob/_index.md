---
title: Gérer le Blob
type: docs
weight: 10
url: /androidjava/manage-blob/
description: Gérer Blob dans une présentation PowerPoint en utilisant Java. Utiliser Blob pour réduire la consommation de mémoire dans une présentation PowerPoint en utilisant Java. Ajouter un gros fichier via Blob à une présentation PowerPoint en utilisant Java. Exporter un gros fichier via Blob d'une présentation PowerPoint en utilisant Java. Charger une grande présentation PowerPoint en tant que Blob en utilisant Java.
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un grand élément (photo, présentation, document ou média) enregistré dans des formats binaires. 

Aspose.Slides pour Android via Java vous permet d'utiliser des BLOBs pour des objets d'une manière qui réduit la consommation de mémoire lorsque de gros fichiers sont impliqués.

{{% alert title="Info" color="info" %}}

Pour contourner certaines limitations lors de l'interaction avec des flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et ralentira le chargement. Par conséquent, lorsque vous comptez charger une grande présentation, nous recommandons fortement d'utiliser le chemin du fichier de présentation et non son flux.

{{% /alert %}}

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un gros fichier via BLOB à une présentation**

[Aspose.Slides](/slides/androidjava/) pour Java vous permet d'ajouter de gros fichiers (dans ce cas, un gros fichier vidéo) via un processus impliquant des BLOBs pour réduire la consommation de mémoire.

Ce Java vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked car nous ne
        // avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Sauvegarde la présentation. Pendant qu'une grande présentation est générée, la consommation de mémoire
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


### **Exporter un gros fichier via BLOB depuis la présentation**
Aspose.Slides pour Android via Java vous permet d'exporter de gros fichiers (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOBs depuis des présentations. Par exemple, vous pourriez avoir besoin d'extraire un gros fichier média d'une présentation mais ne pas vouloir que le fichier soit chargé dans la mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous pouvez garder la consommation de mémoire basse.

Ce code en Java démontre l'opération décrite :

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Verrouille le fichier source et ne le charge PAS dans la mémoire
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// crée l'instance de la présentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Sauvegardons chaque vidéo dans un fichier. Pour éviter une utilisation élevée de la mémoire, nous avons besoin d'un tampon qui sera utilisé
    // pour transférer les données du flux vidéo de la présentation à un flux pour un fichier vidéo nouvellement créé.
    byte[] buffer = new byte[8 * 1024];

    // Itère à travers les vidéos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder à des propriétés
        // comme video.BinaryData - car cette propriété retourne un tableau d'octets contenant une vidéo complète, ce qui provoque ensuite
        // le chargement des octets en mémoire. Nous utilisons video.GetStream, qui renvoie un flux - et ne nécessite PAS
        // de charger la vidéo entière en mémoire.
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

### **Ajouter une image en tant que BLOB dans la présentation**
Avec les méthodes de l'interface [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection), vous pouvez ajouter une grande image en tant que flux pour qu'elle soit traitée comme un BLOB.

Ce code Java vous montre comment ajouter une grande image via le processus BLOB :

```java
String pathToLargeImage = "large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous ne
		// avons PAS l'intention d'accéder au fichier "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Sauvegarde la présentation. Pendant qu'une grande présentation est générée, la consommation de mémoire
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

Typiquement, pour charger une grande présentation, les ordinateurs nécessitent beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé dans la mémoire et le fichier (à partir duquel la présentation a été chargée) cesse d'être utilisé. 

Considérez une grande présentation PowerPoint (large.pptx) qui contient un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code Java :

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

À travers le processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code Java décrit l'implémentation où le processus BLOB est utilisé pour charger un gros fichier de présentation (large.pptx) :

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

### **Changer le dossier pour les fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut pour les fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un dossier différent, vous pouvez modifier les paramètres de stockage en utilisant `TempFilesRootPath` :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}

Lorsque vous utilisez `TempFilesRootPath`, Aspose.Slides ne crée pas automatiquement un dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement. 

{{% /alert %}}