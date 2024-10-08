---
title: Ouvrir une Présentation - API PowerPoint C++
linktitle: Ouvrir une Présentation
type: docs
weight: 20
url: /fr/cpp/open-presentation/
keywords: "Ouvrir PowerPoint, PPTX, PPT, Ouvrir Présentation, Charger Présentation, C++, CPP"
description: "Ouvrir ou charger une Présentation PPT, PPTX, ODP en C++"
---

En plus de créer des présentations PowerPoint à partir de zéro, Aspose.Slides vous permet d'ouvrir des présentations existantes. Après avoir chargé une présentation, vous pouvez obtenir des informations sur la présentation, modifier la présentation (contenu de ses diapositives), ajouter de nouvelles diapositives ou en supprimer des existantes, etc.

## Ouvrir une Présentation

Pour ouvrir une présentation existante, vous devez simplement instancier la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et passer le chemin du fichier (de la présentation que vous souhaitez ouvrir) à son constructeur.

Ce code C++ vous montre comment ouvrir une présentation et également découvrir le nombre de diapositives qu'elle contient :

```c++
// Le chemin vers le répertoire des documents.
String dataDir = u"";

// Instancie la classe Presentation et passe le chemin du fichier à son constructeur
auto pres = System::MakeObject<Presentation>(dataDir + u"OpenPresentation.pptx");

// Imprime le nombre total de diapositives présentes dans la présentation
Console::WriteLine(Convert::ToString(pres->get_Slides()->get_Count()));
```

## **Ouvrir une Présentation Protégée par Mot de Passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, vous pouvez passer le mot de passe via la propriété [get_Password()](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_password/) (de la classe [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)) pour déchiffrer la présentation et charger la présentation. Ce code C++ illustre l'opération :

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"VOTRE_MOT_DE_PASSE");
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
// Effectuer des opérations avec la présentation déchiffrée
```

## Ouvrir une Grande Présentation

Aspose.Slides fournit des options (la propriété [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) en particulier) sous la classe [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) pour vous permettre de charger de grandes présentations.

Ce C++ illustre une opération dans laquelle une grande présentation (disons de 2 Go) est chargée :

```c++
String pathToVeryLargePresentationFile = u"veryLargePresentation.pptx";

{
    SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    // choisissons le comportement KeepLocked - la "veryLargePresentation.pptx" sera verrouillée pour
    // la durée de vie de l'instance de la Présentation, mais nous n'avons pas besoin de la charger en mémoire ou de la copier dans
    // le fichier temporaire
    loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

    auto pres = System::MakeObject<Presentation>(pathToVeryLargePresentationFile, loadOptions);

    // La grande présentation a été chargée et peut être utilisée, mais la consommation de mémoire reste faible.

    // Apporte des modifications à la présentation.
    pres->get_Slides()->idx_get(0)->set_Name(u"Très grande présentation");

    // La présentation sera enregistrée dans l'autre fichier. La consommation de mémoire reste faible durant l'opération
    pres->Save(u"veryLargePresentation-copy.pptx", SaveFormat::Pptx);

    // cela ne peut pas être fait ! Une exception IO sera lancée car le fichier est verrouillé pendant que les objets pres ne seront
    // pas supprimés
    File::Delete(pathToVeryLargePresentationFile);
}

// C'est ok de le faire ici. Le fichier source n'est pas verrouillé par l'objet pres
File::Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Info" %}}

Pour contourner certaines limitations lors de l'interaction avec des flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et causera un chargement lent. Par conséquent, lorsque vous avez l'intention de charger une grande présentation, nous vous recommandons fortement d'utiliser le chemin du fichier de présentation et non son flux.

Lorsque vous souhaitez créer une présentation qui contient de grands objets (vidéo, audio, grandes images, etc.), vous pouvez utiliser la [facilité Blob](https://docs.aspose.com/slides/cpp/manage-blob/) pour réduire la consommation de mémoire.

{{%/alert %}} 

## Charger une Présentation

Aspose.Slides fournit [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) avec une seule méthode pour vous permettre de gérer des ressources externes. Ce code C++ vous montre comment utiliser l'interface `IResourceLoadingCallback` :

```c++
// Le chemin vers le répertoire des documents.
System::String dataDir = GetDataPath();

auto opts = System::MakeObject<LoadOptions>();
opts->set_ResourceLoadingCallback(System::MakeObject<ImageLoadingHandler>(dataDir));
auto presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", opts);
```

```c++
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ImageLoadingHandler(String dataDir)
        : m_dataDir(dataDir)
    {
    }

    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                System::ArrayPtr<uint8_t> imageBytes = File::ReadAllBytes(Path::Combine(m_dataDir, u"aspose-logo.jpg"));
                args->SetData(imageBytes);
                return ResourceLoadingAction::UserProvided;
            }
            catch (System::Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }

        if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Définit l'URL de remplacement
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Ignore toutes les autres images
        return ResourceLoadingAction::Skip;
    }
    
private:
    String m_dataDir;
};
```

<h2>Ouvrir et Enregistrer une Présentation</h2>

<a name="cplusplus-open-save-presentation"><strong>Étapes : Ouvrir et Enregistrer une Présentation en C++</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et passez le fichier que vous souhaitez ouvrir. 

2. Enregistrez la présentation. 

   ```c++
   	const String outPath = u"../out/SaveToFile_out.ppt";
   	
   	SharedPtr<Presentation> pres = MakeObject<Presentation>();
   
   	// pres->get_ProtectionManager()->Encrypt(u"pass");
   	// ... effectuez certaines opérations ici..
   
   	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
   ```