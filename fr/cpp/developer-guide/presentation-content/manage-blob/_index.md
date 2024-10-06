---
title: Gérer les blobs
type: docs
weight: 10
url: /cpp/manage-blob/
keywords: "Ajouter un blob, Exporter un blob, Ajouter une image en tant que blob, Présentation PowerPoint, C++, Aspose.Slides pour C++"
description: "Ajouter un blob à une présentation PowerPoint en C++. Exporter un blob. Ajouter une image en tant que blob"
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré dans des formats binaires.

Aspose.Slides pour C++ vous permet d'utiliser des BLOBs pour des objets de manière à réduire la consommation de mémoire lorsque des fichiers volumineux sont impliqués.

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/cpp/) pour C++ vous permet d'ajouter des fichiers volumineux (dans ce cas, un gros fichier vidéo) via un processus impliquant des BLOBs pour réduire la consommation de mémoire.

Ce code C++ vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Ajoutons la vidéo à la présentation - nous choisissons le comportement KeepLocked car nous n'avons
// pas l'intention d'accéder au fichier "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Enregistre la présentation. Bien qu'une grande présentation soit générée, la consommation de mémoire
// reste faible tout au long du cycle de vie de l'objet pres
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **Exporter un fichier volumineux via BLOB depuis la présentation**
Aspose.Slides pour C++ vous permet d'exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) via un processus impliquant des BLOBs depuis des présentations. Par exemple, vous pourriez avoir besoin d'extraire un gros fichier multimédia d'une présentation, mais ne pas vouloir que le fichier soit chargé dans la mémoire de votre ordinateur. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire.

Ce code en C++ illustre l'opération décrite :

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Crée une instance de Présentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Enregistrons chaque vidéo dans un fichier. Pour éviter une forte utilisation de la mémoire, nous avons besoin d'un tampon qui sera utilisé
// pour transférer les données du flux vidéo de la présentation à un flux pour un fichier vidéo nouvellement créé.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Itère à travers les vidéos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux méthodes
	// comme video->get_BinaryData - car cette méthode renvoie un tableau d'octets contenant une vidéo complète, ce qui
	// entraîne un chargement des octets dans la mémoire. Nous utilisons video->GetStream, qui renvoie Stream - et ne nécessite PAS
	// de charger toute la vidéo dans la mémoire.

	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// La consommation de mémoire restera faible quelle que soit la taille de la vidéo ou de la présentation,
}

// Si nécessaire, vous pouvez appliquer les mêmes étapes pour les fichiers audio.
```

### **Ajouter une image en tant que BLOB dans la présentation**
Avec les méthodes de l'interface [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection), vous pouvez ajouter une grande image en tant que flux pour qu'elle soit traitée comme un BLOB.

Ce code C++ vous montre comment ajouter une grande image via le processus BLOB :

```cpp
const String pathToLargeImage = u"large_image.jpg";

// crée une nouvelle présentation à laquelle l'image sera ajoutée.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous n'avons
// PAS l'intention d'accéder au fichier "largeImage.png".
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Enregistre la présentation. Bien qu'une grande présentation soit générée, la consommation de mémoire 
// reste faible tout au long du cycle de vie de l'objet pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Mémoire et grandes présentations**

En général, pour charger une grande présentation, les ordinateurs nécessitent beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé dans la mémoire et le fichier (à partir duquel la présentation a été chargée) cesse d'être utilisé.

Considérez une grande présentation PowerPoint (large.pptx) qui contient un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code C++ :

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Mais cette méthode consomme environ 1,6 Go de mémoire temporaire.

### **Charger une grande présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code C++ décrit l'implémentation où le processus BLOB est utilisé pour charger un gros fichier de présentation (large.pptx) :

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Changer le dossier pour les fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut pour les fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un dossier différent, vous pouvez changer les paramètres de stockage en utilisant `TempFilesRootPath` :

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}

Lorsque vous utilisez `TempFilesRootPath`, Aspose.Slides ne crée pas automatiquement un dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement.

{{% /alert %}}