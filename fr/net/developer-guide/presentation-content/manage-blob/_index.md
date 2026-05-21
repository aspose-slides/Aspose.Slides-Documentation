---
title: Gérer les BLOB de présentation dans .NET pour une utilisation efficace de la mémoire
linktitle: Gérer BLOB
type: docs
weight: 10
url: /fr/net/manage-blob/
keywords:
- grand objet
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
- .NET
- C#
- Aspose.Slides
description: "Gérer les données BLOB dans Aspose.Slides pour .NET afin de rationaliser les opérations sur les fichiers PowerPoint et OpenDocument pour une manipulation efficace des présentations."
---
## **Vue d'ensemble**

Aspose.Slides fournit une gestion basée sur les BLOB pour les données binaires volumineuses dans les présentations afin d’aider à réduire la consommation de mémoire lors du travail avec de grandes images, audio, vidéo et fichiers de présentation.

Cet article montre comment utiliser le traitement basé sur les BLOB pour ajouter des médias volumineux à une présentation, exporter des médias volumineux depuis une présentation et charger des présentations volumineuses plus efficacement. Il explique également comment les fichiers temporaires peuvent être utilisés pendant le traitement et comment changer le dossier utilisé pour les stocker.

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré sous forme binaire. 

Aspose.Slides for .NET vous permet d’utiliser les BLOB pour les objets d’une manière qui réduit la consommation de mémoire lorsque de gros fichiers sont impliqués. 

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/net/) for .NET vous permet d’ajouter de gros fichiers (dans ce cas, un gros fichier vidéo) via un processus impliquant des BLOB afin de réduire la consommation de mémoire.

Ce C# vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked parce que nous
        //n'avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Enregistre la présentation. Pendant qu'une présentation volumineuse est générée, la consommation de mémoire
        // reste faible tout au long du cycle de vie de l'objet pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Exporter un fichier volumineux via BLOB depuis une présentation**
Aspose.Slides for .NET vous permet d’exporter de gros fichiers (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOB depuis des présentations. Par exemple, vous pouvez avoir besoin d’extraire un gros fichier média d’une présentation sans que le fichier soit chargé en mémoire. En exportant le fichier via le processus BLOB, vous maintenez la consommation de mémoire basse. 

Ce code en C# démontre l’opération décrite :

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Verrouille le fichier source et ne le charge PAS en mémoire
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Creates a Presentation's instance, locks the "hugePresentationWithAudiosAndVideos.pptx" file.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Sauvegardons chaque vidéo dans un fichier. Pour éviter une utilisation élevée de la mémoire, nous avons besoin d'un tampon qui sera utilisé
	// pour transférer les données du flux vidéo de la présentation vers un flux pour un nouveau fichier vidéo.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
		// comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant toute la vidéo, ce qui alors
		// charge les octets en mémoire. Nous utilisons video.GetStream, qui renverra un Stream - et ne
		//  nécessite pas de charger toute la vidéo en mémoire.
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

		// La consommation de mémoire restera faible quelle que soit la taille de la vidéo ou de la présentation,
	}

	// Si nécessaire, vous pouvez appliquer les mêmes étapes aux fichiers audio. 
}
```

### **Ajouter une image en tant que BLOB à une présentation**
Avec les méthodes de l’interface [**IImageCollection**](https://reference.aspose.com/slides/fr/net/aspose.slides/iimagecollection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/fr/net/aspose.slides/imagecollection), vous pouvez ajouter une grande image sous forme de flux pour qu’elle soit traitée comme un BLOB. 

Ce code C# vous montre comment ajouter une grande image via le processus BLOB :

```c#
string pathToLargeImage = "large_image.jpg";

// Crée une nouvelle présentation à laquelle l'image sera ajoutée.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked parce que nous
		// NE prévoyons PAS d'accéder au fichier "largeImage.png".
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Enregistre la présentation. Lorsqu'une présentation volumineuse est générée, la consommation de mémoire 
		// reste faible tout au long du cycle de vie de l'objet pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Mémoire et présentations volumineuses**

Typiquement, pour charger une présentation volumineuse, les ordinateurs ont besoin de beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) cesse d’être utilisé. 

Considérez une grande présentation PowerPoint (large.pptx) contenant un fichier vidéo de 1,5 GB. La méthode standard de chargement de la présentation est décrite dans ce code C# :

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Mais cette méthode consomme environ 1,6 GB de mémoire temporaire. 

### **Charger une présentation volumineuse en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une présentation volumineuse tout en utilisant peu de mémoire. Ce code C# décrit l’implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :

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

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut des fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage en utilisant `TempFilesRootPath` :

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

### **Libérer les objets Presentation pour libérer la mémoire**

Lors du traitement de présentations volumineuses, assurez‑vous que l’instance [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) est correctement libérée afin que la mémoire qu’elle occupe soit libérée. La méthode recommandée est d’utiliser une instruction `using` ou une déclaration comme indiqué dans les exemples ci‑dessus ; elle libère automatiquement la présentation et les ressources non managées lorsque le bloc se termine.

Si vous créez une présentation sans bloc `using`, appelez explicitement `Dispose()` après l’avoir utilisée.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...traiter la présentation...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Libérer explicitement les ressources.
presentation.Dispose();
```

## **FAQ**

**Quelles données dans une présentation Aspose.Slides sont traitées comme BLOB et contrôlées par les options BLOB ?**

Les objets binaires volumineux tels que les images, l’audio et la vidéo sont traités comme BLOB. Le fichier de présentation complet implique également la gestion des BLOB lorsqu’il est chargé ou enregistré. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et de déverser vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine des fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB affectent‑ils les performances, et comment équilibrer vitesse et mémoire ?**

Oui. Garder les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite mémoire déplace davantage de travail vers les fichiers temporaires, diminuant la RAM au coût d’un I/O supplémentaire. Ajustez le seuil [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/fr/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) pour atteindre le bon équilibre selon votre charge de travail et votre environnement.

**Les options BLOB aident‑elles lors de l’ouverture de présentations extrêmement volumineuses (par exemple, plusieurs gigaoctets) ?**

Oui. Les [BlobManagementOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire considérablement le pic de RAM et stabiliser le traitement de présentations très grandes.

**Puis‑je utiliser les politiques BLOB lors du chargement depuis des flux au lieu de fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, gardant l’utilisation de la mémoire prévisible pendant le traitement.