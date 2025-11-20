---
title: Gestion du Blob
type: docs
weight: 10
url: /fr/net/manage-blob/
keywords: "Ajouter un blob, Exporter le blob, Ajouter une image en tant que blob, Présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Ajouter un blob à une présentation PowerPoint en C# ou .NET. Exporter le blob. Ajouter une image en tant que blob"
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré dans des formats binaires. 

Aspose.Slides for .NET vous permet d'utiliser les BLOBs pour les objets de manière à réduire la consommation de mémoire lorsque de gros fichiers sont impliqués. 

## **Utiliser le BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/net/) for .NET vous permet d'ajouter de gros fichiers (dans ce cas, un gros fichier vidéo) via un processus impliquant des BLOBs pour réduire la consommation de mémoire.

Ce C# vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked car nous
        // ne prévoyons pas d'accéder au fichier "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Enregistre la présentation. Pendant qu'une grande présentation est générée, la consommation de mémoire
        // reste faible pendant le cycle de vie de l'objet pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Exporter un fichier volumineux via BLOB depuis une présentation**
Aspose.Slides for .NET vous permet d'exporter de gros fichiers (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOBs depuis les présentations. Par exemple, vous pouvez avoir besoin d'extraire un gros fichier multimédia d'une présentation sans charger le fichier dans la mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire. 

Ce code en C# montre l'opération décrite :
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Verrouille le fichier source et NE le charge PAS en mémoire
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Crée une instance de Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Enregistrons chaque vidéo dans un fichier. Pour éviter une forte utilisation de la mémoire, nous avons besoin d'un tampon qui sera utilisé
	// pour transférer les données du flux vidéo de la présentation vers un flux pour un fichier vidéo nouvellement créé.
	byte[] buffer = new byte[8 * 1024];

	// Itère sur les vidéos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Ouvre le flux vidéo de la présentation. Notez que nous avons intentionnellement évité d'accéder aux propriétés
		// comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant une vidéo complète, qui ensuite
		// charge des octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et NE
		//  ne nous oblige pas à charger toute la vidéo en mémoire.
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

		// La consommation de mémoire restera faible quel que soit la taille de la vidéo ou de la présentation,
	}

	// Si nécessaire, vous pouvez appliquer les mêmes étapes aux fichiers audio. 
}
```


### **Ajouter une image comme BLOB dans une présentation**
Avec les méthodes de l'interface [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) et de la classe [**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection), vous pouvez ajouter une grande image en tant que flux pour qu'elle soit traitée comme un BLOB. 

Ce code C# vous montre comment ajouter une grande image via le processus BLOB :
```c#
string pathToLargeImage = "large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous
		// ne prévoyons PAS d'accéder au fichier "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Enregistre la présentation. Pendant la génération d'une grande présentation, la consommation de mémoire 
		// reste faible pendant le cycle de vie de l'objet pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **Mémoire et présentations volumineuses**

En général, pour charger une présentation volumineuse, les ordinateurs ont besoin de beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (dont la présentation a été chargée) n'est plus utilisé. 

Considérez une grande présentation PowerPoint (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code C# :
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


Cependant, cette méthode consomme environ 1,6 Go de mémoire temporaire. 

### **Charger une grande présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation en utilisant peu de mémoire. Ce code C# décrit l'implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :
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


### **Modifier le dossier des fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut des fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage à l'aide de `TempFilesRootPath` :
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

Lorsque vous utilisez `TempFilesRootPath`, Aspose.Slides ne crée pas automatiquement de dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement. 

{{% /alert %}}

## **FAQ**

**Quelles données d'une présentation Aspose.Slides sont traitées comme BLOB et contrôlées par les options BLOB ?**

Les grands objets binaires tels que les images, l'audio et la vidéo sont traités comme des BLOB. Le fichier complet de la présentation implique également la gestion des BLOB lors du chargement ou de l'enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l'utilisation de la mémoire et de déverser les données vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d'une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine pour les fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB affectent-ils les performances, et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; diminuer la limite mémoire déplace davantage de travail vers les fichiers temporaires, réduisant la RAM au prix d'un I/O supplémentaire. Ajustez le seuil [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) pour obtenir le bon équilibre selon votre charge de travail et votre environnement.

**Les options BLOB aident-elles lors de l'ouverture de présentations extrêmement volumineuses (par ex., plusieurs gigaoctets) ?**

Oui. Les [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) sont conçues pour de tels scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire considérablement l'utilisation maximale de RAM et stabiliser le traitement de présentations très volumineuses.

**Puis-je utiliser les politiques BLOB lors du chargement depuis des flux au lieu de fichiers disque ?**

Oui. Les mêmes règles s'appliquent aux flux : l'instance de présentation peut posséder et verrouiller le flux d'entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu'ils sont autorisés, maintenant une utilisation de la mémoire prévisible pendant le traitement.