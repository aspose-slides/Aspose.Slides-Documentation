---
title: Gérer les BLOB de présentation en C++ pour une utilisation efficace de la mémoire
linktitle: Gérer les BLOB
type: docs
weight: 10
url: /fr/cpp/manage-blob/
keywords:
- gros objet
- gros élément
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
- C++
- Aspose.Slides
description: "Gérez les données BLOB dans Aspose.Slides pour C++ afin de rationaliser les opérations de fichiers PowerPoint et OpenDocument pour une manipulation efficace des présentations."
---
## **Aperçu**

Aspose.Slides propose une gestion basée sur les BLOB pour les données binaires volumineuses dans les présentations afin d’aider à réduire la consommation de mémoire lors du traitement d’images, d’audios, de vidéos et de fichiers de présentation de grande taille.

Cet article montre comment utiliser le traitement basé sur les BLOB pour ajouter des médias volumineux à une présentation, exporter des médias volumineux depuis une présentation et charger des présentations de grande taille de manière plus efficace. Il explique également comment des fichiers temporaires peuvent être utilisés pendant le traitement et comment modifier le dossier utilisé pour les stocker.

## **À propos des BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré dans des formats binaires.

Aspose.Slides for C++ vous permet d’utiliser des BLOB pour les objets de manière à réduire la consommation de mémoire lorsque des fichiers volumineux sont impliqués.

## **Utiliser les BLOB pour réduire la consommation de mémoire**

### **Ajouter un gros fichier via BLOB à une présentation**

[Aspose.Slides](/slides/fr/cpp/) for C++ vous permet d’ajouter des fichiers volumineux (dans ce cas, un gros fichier vidéo) via un processus impliquant des BLOB afin de réduire la consommation de mémoire.

Ce code C++ vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked car nous
//n'avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Enregistre la présentation. Pendant qu'une grande présentation est générée, la consommation de mémoire
// reste faible tout au long du cycle de vie de l'objet pres
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Exporter un gros fichier via BLOB depuis une présentation**

Aspose.Slides for C++ vous permet d’exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOB depuis des présentations. Par exemple, vous pouvez devoir extraire un gros fichier multimédia d’une présentation sans le charger dans la mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire.

Ce code en C++ illustre l’opération décrite :

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Crée une instance de Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Enregistrons chaque vidéo dans un fichier. Pour éviter une forte utilisation de la mémoire, nous avons besoin d'un tampon qui sera utilisé
// pour transférer les données du flux vidéo de la présentation vers un flux pour un nouveau fichier vidéo.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux méthodes
	// comme video->get_BinaryData - car cette méthode renvoie un tableau d'octets contenant toute la vidéo, ce qui
	// provoque le chargement des octets en mémoire. Nous utilisons video->GetStream, qui renvoie un Stream - et ne
	// nous oblige pas à charger la vidéo entière en mémoire.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// La consommation de mémoire restera faible quel que soit la taille de la vidéo ou de la présentation,
}

// Si nécessaire, vous pouvez appliquer les mêmes étapes pour les fichiers audio.
```

### **Ajouter une image en tant que BLOB à une présentation**

Avec les méthodes de l’interface [**IImageCollection**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_image_collection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.image_collection), vous pouvez ajouter une grande image sous forme de flux afin qu’elle soit traitée comme un BLOB.

Ce code C++ vous montre comment ajouter une grande image via le processus BLOB :

```cpp
const String pathToLargeImage = u"large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous
// NE prévoyons pas d'accéder au fichier "largeImage.png".
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Enregistre la présentation. Pendant qu'une grande présentation est générée, la consommation de mémoire 
// reste faible tout au long du cycle de vie de l'objet pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Mémoire et grandes présentations**

En général, pour charger une grande présentation, les ordinateurs ont besoin de beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) n’est plus utilisé.

Considérez une grande présentation PowerPoint (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code C++ :

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Cependant, cette méthode consomme environ 1,6 Go de mémoire temporaire.

### **Charger une grande présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code C++ décrit l’implémentation où le processus BLOB est utilisé pour charger un gros fichier de présentation (large.pptx) :

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

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut des fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez modifier les paramètres de stockage en utilisant `TempFilesRootPath` :

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Lorsque vous utilisez `TempFilesRootPath`, Aspose.Slides ne crée pas automatiquement de dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement. 
{{% /alert %}}

### **Libérer les objets de présentation pour libérer la mémoire**

Lors du traitement de présentations volumineuses, assurez‑vous que l’instance [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) soit correctement libérée afin que la mémoire qu’elle occupait soit relâchée. Appelez `Dispose()` après avoir fini d’utiliser la présentation pour libérer les ressources non gérées.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...traiter la présentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Libérer explicitement les ressources.
presentation->Dispose();
```

## **FAQ**

**Quelles données d’une présentation Aspose.Slides sont traitées comme BLOB et contrôlées par les options BLOB ?**

Les gros objets binaires tels que les images, les audios et les vidéos sont traités comme des BLOB. Le fichier complet de la présentation fait également l’objet d’une gestion BLOB lors de son chargement ou de son enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et de déverser vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/blobmanagementoptions/). Vous pouvez y définir la limite en mémoire pour les BLOB, autoriser ou interdire les fichiers temporaires, choisir le chemin racine pour les fichiers temporaires et sélectionner le comportement de verrouillage de la source.

**Les paramètres BLOB affectent‑ils les performances et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite de mémoire déplace davantage de travail vers les fichiers temporaires, réduisant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/fr/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) pour trouver le bon compromis selon votre charge de travail et votre environnement.

**Les options BLOB aident‑elles à l’ouverture de présentations extrêmement volumineuses (par ex. plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : l’activation des fichiers temporaires et l’utilisation du verrouillage de la source permettent de réduire considérablement l’utilisation maximale de RAM et de stabiliser le traitement de présentations très volumineuses.

**Puis‑je utiliser les politiques BLOB lors du chargement depuis des flux au lieu de fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, maintenant une utilisation de mémoire prévisible pendant le traitement.