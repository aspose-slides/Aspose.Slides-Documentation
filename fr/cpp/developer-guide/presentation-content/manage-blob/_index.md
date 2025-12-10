---
title: Gérer les BLOB de présentation en C++ pour une utilisation efficace de la mémoire
linktitle: Gérer BLOB
type: docs
weight: 10
url: /fr/cpp/manage-blob/
keywords:
- objet volumineux
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
- C++
- Aspose.Slides
description: "Gérer les données BLOB dans Aspose.Slides pour C++ afin de simplifier les opérations sur les fichiers PowerPoint et OpenDocument pour une gestion efficace des présentations."
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré au format binaire.  

Aspose.Slides for C++ vous permet d'utiliser les BLOBs pour des objets de manière à réduire la consommation de mémoire lorsque des fichiers volumineux sont impliqués.  

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/cpp/) for C++ vous permet d'ajouter des fichiers volumineux (dans ce cas, un gros fichier vidéo) via un processus impliquant des BLOBs afin de réduire la consommation de mémoire.

Ce code C++ montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :
```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked car nous
// n'avons pas l'intention d'accéder au "veryLargeVideo.avi" file.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Enregistre la présentation. Bien qu'une présentation volumineuse soit générée, la consommation de mémoire
// reste faible pendant le cycle de vie de l'objet pres
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **Exporter un fichier volumineux via BLOB depuis une présentation**
Aspose.Slides for C++ vous permet d'exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOBs depuis les présentations. Par exemple, il se peut que vous deviez extraire un gros fichier média d'une présentation sans que le fichier ne soit chargé en mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire.  

Ce code en C++ illustre l'opération décrite :
```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Crée une instance de Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Enregistrons chaque vidéo dans un fichier. Pour éviter une forte utilisation de la mémoire, nous avons besoin d'un tampon qui sera utilisé
// pour transférer les données du flux vidéo de la présentation vers un flux pour le nouveau fichier vidéo créé.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Itère à travers les vidéos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux méthodes
	// comme video->get_BinaryData - car cette méthode renvoie un tableau d'octets contenant la vidéo complète, ce qui
	// charge les octets en mémoire. Nous utilisons video->GetStream, qui renvoie un Stream - et ne
	// nous oblige pas à charger la vidéo entière en mémoire.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// La consommation de mémoire restera basse quelle que soit la taille de la vidéo ou de la présentation,
}

// Si nécessaire, vous pouvez appliquer les mêmes étapes aux fichiers audio.
```


### **Ajouter une image en tant que BLOB à une présentation**
Avec les méthodes de l'interface [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection), vous pouvez ajouter une grande image sous forme de flux afin qu'elle soit traitée comme un BLOB.  

Ce code C++ montre comment ajouter une grande image via le processus BLOB :
```cpp
const String pathToLargeImage = u"large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous
// ne prévoyons PAS d'accéder au "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Enregistre la présentation. Bien qu'une présentation volumineuse soit générée, la consommation de mémoire 
// reste faible pendant le cycle de vie de l'objet pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```


## **Mémoire et présentations volumineuses**

En général, pour charger une présentation volumineuse, les ordinateurs ont besoin de beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) n'est plus utilisé.  

Considérez une grande présentation PowerPoint (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code C++ :
```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


Cependant, cette méthode consomme environ 1,6 Go de mémoire temporaire.  

### **Charger une grande présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code C++ décrit l'implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


#### **Modifier le dossier des fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut des fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage à l'aide de `TempFilesRootPath` :
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```


{{% alert title="Info" color="info" %}}
Lorsque vous utilisez `TempFilesRootPath`, Aspose.Slides ne crée pas automatiquement de dossier pour stocker les fichiers temporaires.  
{{% /alert %}}

## **FAQ**

**Quelles données d'une présentation Aspose.Slides sont traitées comme des BLOB et contrôlées par les options BLOB ?**

Les gros objets binaires tels que les images, l'audio et la vidéo sont traités comme des BLOB. Le fichier de présentation complet implique également une gestion BLOB lors du chargement ou de l'enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l'utilisation de la mémoire et de déverser les données vers des fichiers temporaires si nécessaire.  

**Où configurer les règles de gestion des BLOB lors du chargement d'une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine pour les fichiers temporaires et sélectionnez le comportement de verrouillage de la source.  

**Les paramètres BLOB affectent-ils les performances, et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite mémoire déplace davantage de travail vers les fichiers temporaires, diminuant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) pour trouver le bon équilibre pour votre charge de travail et votre environnement.  

**Les options BLOB aident‑elles lors de l'ouverture de présentations extrêmement volumineuses (par ex. plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut réduire considérablement l’utilisation maximale de RAM et stabiliser le traitement de présentations très volumineuses.  

**Puis‑je utiliser les politiques BLOB lors du chargement depuis des flux plutôt que des fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l'instance de présentation peut posséder et verrouiller le flux d'entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, ce qui maintient une utilisation de la mémoire prévisible pendant le traitement.