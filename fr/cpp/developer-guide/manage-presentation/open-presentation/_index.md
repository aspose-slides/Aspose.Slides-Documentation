---
title: "Ouvrir des présentations en C++"
linktitle: "Ouvrir une présentation"
type: docs
weight: 20
url: /fr/cpp/open-presentation/
keywords:
- ouvrir PowerPoint
- ouvrir OpenDocument
- ouvrir présentation
- ouvrir PPTX
- ouvrir PPT
- ouvrir ODP
- charger présentation
- charger PPTX
- charger PPT
- charger ODP
- présentation protégée
- grande présentation
- ressource externe
- objet binaire
- C++
- Aspose.Slides
description: "Ouvrez facilement les présentations PowerPoint (.pptx, .ppt) et OpenDocument (.odp) avec Aspose.Slides pour C++ — rapide, fiable, entièrement fonctionnel."
---

## **Vue d'ensemble**

Au‑delà de la création de présentations PowerPoint à partir de zéro, Aspose.Slides vous permet également d’ouvrir des présentations existantes. Après le chargement d’une présentation, vous pouvez récupérer des informations à son sujet, modifier le contenu des diapositives, ajouter de nouvelles diapositives, supprimer celles existantes, et plus encore.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, instanciez la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et transmettez le chemin du fichier à son constructeur.

L’exemple C++ suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :
```cpp
// Instancier la classe Presentation et passer un chemin de fichier à son constructeur.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Afficher le nombre total de diapositives dans la présentation.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```


## **Ouvrir des présentations protégées par mot de passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, transmettez le mot de passe via la méthode [set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) de la classe [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) pour la déchiffrer et la charger. Le code C++ suivant illustre cette opération :
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Effectuer des opérations sur la présentation décryptée.

presentation->Dispose();
```


## **Ouvrir de grandes présentations**

Aspose.Slides propose des options — notamment la méthode [get_BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) dans la classe [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) — pour vous aider à charger de grandes présentations.

Le code C++ suivant montre comment charger une grande présentation (par exemple, 2 Go) :
```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Choisissez le comportement KeepLocked - le fichier de présentation restera verrouillé pendant toute la durée de
// l'instance Presentation, mais il n'est pas nécessaire de le charger en mémoire ou de le copier dans un fichier temporaire.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 Mo

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// La grande présentation a été chargée et peut être utilisée, tout en maintenant une faible consommation de mémoire.

// Apportez des modifications à la présentation.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Enregistrez la présentation dans un autre fichier. La consommation de mémoire reste faible pendant cette opération.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Ne faites pas cela ! Une exception d'E/S sera levée car le fichier est verrouillé jusqu'à ce que l'objet Presentation soit libéré.
File::Delete(filePath);

presentation->Dispose();

// Il est correct de le faire ici. Le fichier source n'est plus verrouillé par l'objet Presentation.
File::Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Pour contourner certaines limitations lors de l’utilisation de flux, Aspose.Slides peut copier le contenu d’un flux. Charger une grande présentation depuis un flux entraîne la copie de la présentation et peut ralentir le chargement. Ainsi, lorsque vous devez charger une grande présentation, nous vous recommandons vivement d’utiliser le chemin du fichier de présentation plutôt qu’un flux.

Lors de la création d’une présentation contenant de gros objets (vidéo, audio, images haute résolution, etc.), vous pouvez utiliser la [gestion BLOB](/slides/fr/cpp/manage-blob/) pour réduire la consommation de mémoire.
{{%/alert %}}

## **Contrôler les ressources externes**

Aspose.Slides fournit l’interface [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) qui vous permet de gérer les ressources externes. Le code C++ suivant montre comment utiliser l’interface `IResourceLoadingCallback` :
```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Charger une image de substitution.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Définir une URL de substitution.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Ignorer toutes les autres images.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```


## **Charger des présentations sans objets binaires intégrés**

Une présentation PowerPoint peut contenir les types d’objets binaires intégrés suivants :

- Projet VBA (accessible via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_vbaproject/));
- Données d’objet OLE intégré (accessibles via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- Données binaires de contrôle ActiveX (accessibles via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

En utilisant la méthode [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/), vous pouvez charger une présentation sans aucun objet binaire intégré.

Cette méthode est utile pour supprimer le contenu binaire potentiellement malveillant. Le code C++ suivant montre comment charger une présentation sans aucun contenu binaire intégré :
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Effectuer des opérations sur la présentation.

presentation->Dispose();
```


## **FAQ**

**Comment puis‑je savoir qu’un fichier est corrompu et ne peut pas être ouvert ?**

Vous obtiendrez une exception de validation de parsing/format lors du chargement. Ces erreurs mentionnent souvent une structure ZIP invalide ou des enregistrements PowerPoint endommagés.

**Que se passe‑t‑il si des polices requises sont manquantes lors de l’ouverture ?**

Le fichier s’ouvrira, mais le [rendu/export](/slides/fr/cpp/convert-presentation/) pourra substituer les polices. [Configurez les substitutions de polices](/slides/fr/cpp/font-substitution/) ou [ajoutez les polices requises](/slides/fr/cpp/custom-font/) à l’environnement d’exécution.

**Qu’en est‑il du média intégré (vidéo/audio) lors de l’ouverture ?**

Ils deviennent disponibles en tant que ressources de la présentation. Si les médias sont référencés via des chemins externes, assurez‑vous que ces chemins soient accessibles dans votre environnement ; sinon le [rendu/export](/slides/fr/cpp/convert-presentation/) pourra les ignorer.