---
title: Gérer le BLOB
type: docs
weight: 10
url: /fr/net/manage-blob/
keywords: "Ajouter un blob, Exporter un blob, Ajouter une image en tant que blob, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter un blob à une présentation PowerPoint en C# ou .NET. Exporter un blob. Ajouter une image en tant que blob"
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré dans des formats binaires.

Aspose.Slides pour .NET vous permet d'utiliser des BLOBs pour des objets de manière à réduire la consommation de mémoire lorsque des fichiers volumineux sont concernés.

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/net/) pour .NET vous permet d'ajouter des fichiers volumineux (dans ce cas, un fichier vidéo volumineux) via un processus impliquant des BLOBs pour réduire la consommation de mémoire.

Ce code C# vous montre comment ajouter un fichier vidéo volumineux via le processus BLOB à une présentation :

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Ajoutons la vidéo à la présentation - nous choisissons le comportement KeepLocked car nous ne
        // avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Enregistre la présentation. Bien qu'une grande présentation soit générée, la consommation de mémoire
        // reste basse tout au long du cycle de vie de l'objet pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Exporter un fichier volumineux via BLOB d'une présentation**
Aspose.Slides pour .NET vous permet d'exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOBs à partir de présentations. Par exemple, vous pourriez avoir besoin d'extraire un fichier média volumineux d'une présentation mais ne souhaitez pas que le fichier soit chargé dans la mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous pouvez maintenir la consommation de mémoire basse.

Ce code en C# démontre l'opération décrite :

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // Verrouille le fichier source et ne le charge PAS dans la mémoire
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

// Crée une instance de présentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
    // Enregistrons chaque vidéo dans un fichier. Pour éviter une forte consommation de mémoire, nous avons besoin d'un tampon qui sera utilisé
    // pour transférer les données depuis le flux vidéo de la présentation vers un flux pour un fichier vidéo nouvellement créé.
    byte[] buffer = new byte[8 * 1024];

    // Itère à travers les vidéos
    for (var index = 0; index < pres.Videos.Count; index++)
    {
        IVideo video = pres.Videos[index];

        // Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder à des propriétés
        // comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant une vidéo complète, ce qui entraîne ensuite
        // le chargement des octets dans la mémoire. Nous utilisons video.GetStream, qui renverra Stream - et ne nécessite PAS
        //  de charger l'ensemble de la vidéo dans la mémoire.
        using (Stream presVideoStream = video.GetStream())
        {
            using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
            {
                int bytesRead;
                while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outputFileStream.Write(buffer, 0, bytesRead);
                }
            }
        }

        // La consommation de mémoire restera faible, quel que soit la taille de la vidéo ou de la présentation,
    }

    // Si nécessaire, vous pouvez appliquer les mêmes étapes pour les fichiers audio. 
}
```

### **Ajouter une image en tant que BLOB dans la présentation**
Avec les méthodes de l'interface [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) et de la classe [**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection), vous pouvez ajouter une grande image en tant que flux pour qu'elle soit traitée comme un BLOB.

Ce code C# montre comment ajouter une grande image via le processus BLOB :

```c#
string pathToLargeImage = "large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
    {
        // Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous ne
        // avons PAS l'intention d'accéder au fichier "largeImage.png".
        IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

        // Enregistre la présentation. Bien qu'une grande présentation soit produite, la consommation de mémoire 
        // reste basse tout au long du cycle de vie de l'objet pres
        pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
    }
}
```

## **Mémoire et grandes présentations**

En général, pour charger une grande présentation, les ordinateurs nécessitent beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé dans la mémoire et le fichier (à partir duquel la présentation a été chargée) cesse d'être utilisé.

Considérez une grande présentation PowerPoint (large.pptx) qui contient un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code C# :

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Mais cette méthode consomme environ 1,6 Go de mémoire temporaire.

### **Charger une grande présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code C# décrit l'implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Changer le dossier pour les fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut pour les fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage en utilisant `TempFilesRootPath` :

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}

Lorsque vous utilisez `TempFilesRootPath`, Aspose.Slides ne crée pas automatiquement un dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement.

{{% /alert %}}