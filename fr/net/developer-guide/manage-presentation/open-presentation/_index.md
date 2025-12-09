---
title: Ouvrir des présentations dans .NET
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /fr/net/open-presentation/
keywords:
- ouvrir PowerPoint
- ouvrir présentation
- ouvrir PPTX
- ouvrir PPT
- ouvrir ODP
- charger présentation
- charger PPTX
- charger PPT
- charger ODP
- présentation protégée
- présentation volumineuse
- ressource externe
- objet binaire
- .NET
- C#
- Aspose.Slides
description: "Ouvrez des présentations PowerPoint (.pptx, .ppt) et OpenDocument (.odp) facilement avec Aspose.Slides pour .NET — rapide, fiable, complet."
---

## **Vue d'ensemble**

Outre la création de présentations PowerPoint à partir de zéro, Aspose.Slides vous permet également d'ouvrir des présentations existantes. Après le chargement d'une présentation, vous pouvez récupérer des informations à son sujet, modifier le contenu des diapositives, ajouter de nouvelles diapositives, supprimer celles existantes, et plus encore.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et transmettez le chemin du fichier à son constructeur.

L'exemple C# suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :
```cs
// Instanciez la classe Presentation et transmettez un chemin de fichier à son constructeur.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Affichez le nombre total de diapositives dans la présentation.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **Ouvrir des présentations protégées par mot de passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, transmettez le mot de passe via la propriété [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) de la classe [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) pour la déchiffrer et la charger. Le code C# suivant illustre cette opération :
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Effectuez des opérations sur la présentation déchiffrée.
}
```


## **Ouvrir des présentations volumineuses**

Aspose.Slides propose des options—en particulier la propriété [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) de la classe [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)—pour vous aider à charger des présentations volumineuses.

Le code C# suivant montre le chargement d'une présentation volumineuse (par exemple, 2 Go) :
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Choisissez le comportement KeepLocked — le fichier de présentation restera verrouillé pendant la durée de 
        // l'instance Presentation, mais il n'est pas nécessaire de le charger en mémoire ou de le copier dans un fichier temporaire.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 Mo
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // La grande présentation a été chargée et peut être utilisée, tout en maintenant une consommation mémoire faible.

    // Apportez des modifications à la présentation.
    presentation.Slides[0].Name = "Large presentation";

    // Enregistrez la présentation dans un autre fichier. La consommation de mémoire reste faible pendant cette opération.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Ne faites pas cela ! Une exception d'E/S sera levée car le fichier est verrouillé jusqu'à la libération de l'objet présentation.
    File.Delete(filePath);
}

// Vous pouvez le faire ici. Le fichier source n'est plus verrouillé par l'objet présentation.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Pour contourner certaines limitations lors de l'utilisation des flux, Aspose.Slides peut copier le contenu d'un flux. Charger une présentation volumineuse à partir d'un flux entraîne la copie de la présentation et peut ralentir le chargement. Ainsi, lorsque vous devez charger une présentation volumineuse, nous vous recommandons fortement d'utiliser le chemin du fichier de la présentation plutôt qu'un flux.

Lorsque vous créez une présentation contenant des objets volumineux (vidéo, audio, images haute résolution, etc.), vous pouvez utiliser la [gestion BLOB](/slides/fr/net/manage-blob/) pour réduire la consommation de mémoire.
{{%/alert %}}

## **Contrôler les ressources externes**

Aspose.Slides fournit l'interface [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) qui vous permet de gérer les ressources externes. Le code C# suivant montre comment utiliser l'interface `IResourceLoadingCallback` :
```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Charger une image de substitution.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Définir une URL de substitution.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Ignorer toutes les autres images.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Charger des présentations sans objets binaires intégrés**

Une présentation PowerPoint peut contenir les types d'objets binaires intégrés suivants :

- Projet VBA (accessible via [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- Données intégrées d'objet OLE (accessible via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Données binaires de contrôle ActiveX (accessible via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

En utilisant la propriété [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/), vous pouvez charger une présentation sans aucun objet binaire intégré.

Cette propriété est utile pour supprimer d'éventuels contenus binaires malveillants. Le code C# suivant montre comment charger une présentation sans aucun contenu binaire intégré :
```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Effectuer des opérations sur la présentation.
}
```


## **FAQ**

**Comment savoir qu'un fichier est corrompu et ne peut pas être ouvert ?**

Vous recevrez une exception de validation d'analyse/format pendant le chargement. Ces erreurs mentionnent souvent une structure ZIP invalide ou des enregistrements PowerPoint endommagés.

**Que se passe-t-il si les polices requises sont manquantes lors de l'ouverture ?**

Le fichier s'ouvrira, mais le [rendu/export](/slides/fr/net/convert-presentation/) ultérieur pourra substituer les polices. [Configurez les substitutions de polices](/slides/fr/net/font-substitution/) ou [ajoutez les polices requises](/slides/fr/net/custom-font/) à l'environnement d'exécution.

**Qu'en est‑il des médias intégrés (vidéo/audio) lors de l'ouverture ?**

Ils deviennent disponibles en tant que ressources de la présentation. Si les médias sont référencés via des chemins externes, assurez‑vous que ces chemins sont accessibles dans votre environnement ; sinon le [rendu/export](/slides/fr/net/convert-presentation/) pourra omettre les médias.