---
title: Ouvrir des présentations en .NET
linktitle: Ouvrir la présentation
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
- grande présentation
- ressource externe
- objet binaire
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment ouvrir des présentations PowerPoint et OpenDocument en C#, fournir des mots de passe d’ouverture, contrôler le chargement des ressources et réduire l’utilisation de la mémoire avec Aspose.Slides pour .NET."
---
## **Introduction**

[Aspose.Slides pour .NET](https://products.aspose.com/slides/fr/net/) peut charger des présentations PowerPoint et OpenDocument à partir de fichiers et de flux. Après le chargement d’une présentation, vous pouvez inspecter sa structure, modifier les diapositives, gérer les ressources et l’enregistrer dans le format d’origine ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/). Par exemple, vous pouvez fournir un mot de passe d’ouverture, laisser les gros objets binaires en dehors de la mémoire gérée, contrôler les ressources externes ou ignorer les données binaires intégrées.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Libérez la présentation après utilisation afin que les handles de fichier, les données temporaires et les autres ressources soient libérés rapidement.

L’exemple C# suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Ouvrir des présentations protégées par mot de passe**

Un mot de passe d’ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, affectez le mot de passe correct à [LoadOptions.Password](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/password/) et transmettez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Le chargement échoue si le mot de passe est absent ou incorrect.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Pour la détection, la validation et les flux de travail de chiffrement des mots de passe, consultez [Password-Protect Presentations](/slides/fr/net/password-protected-presentation/). Si une présentation chiffrée a été volontairement enregistrée avec des propriétés de document publiques, ces propriétés peuvent être lues sans mot de passe ; voir [Manage Presentation Properties](/slides/fr/net/presentation-properties/).

## **Ouvrir de grandes présentations**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/blobmanagementoptions/) contrôle la façon dont Aspose.Slides gère les gros objets binaires tels que les images, l’audio et la vidéo. Vous pouvez garder le fichier source verrouillé, autoriser les fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

L’exemple C# suivant montre le chargement d’une grande présentation (par exemple, 2 Go) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Avec `PresentationLockingBehavior.KeepLocked`, le fichier source reste verrouillé jusqu’à ce que l’objet `Presentation` soit libéré. Ne déplacez pas, ne remplacez pas et ne supprimez pas le fichier source tant que cet objet est vivant.

Aspose.Slides peut copier le contenu d’un flux d’entrée lors du chargement. Pour les grandes présentations, un chemin de fichier est donc généralement plus efficace qu’un flux. Voir [Manage BLOBs](/slides/fr/net/manage-blob/) pour des options supplémentaires de stockage et de gestion de la mémoire.
{{% /alert %}}

## **Contrôler les ressources externes**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/resourceloadingcallback/) accepte une implémentation de [IResourceLoadingCallback](https://reference.aspose.com/slides/fr/net/aspose.slides/iresourceloadingcallback/). Le rappel peut fournir des données de remplacement, rediriger une ressource, utiliser le chargeur par défaut ou ignorer la ressource. Ceci est utile lorsque les présentations contiennent des images externes qui doivent être résolues selon des règles de sécurité ou de stockage propres à l’application.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Charger des présentations sans objets binaires intégrés**

Une présentation peut contenir des données binaires intégrées qu’une application n’a pas besoin ou ne veut pas conserver. Exemples :

- projets VBA, accessibles via [IPresentation.VbaProject](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/vbaproject/) ;
- données OLE intégrées, accessibles via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/fr/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) ;
- données de contrôle ActiveX, accessibles via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/fr/net/aspose.slides/icontrol/activexcontrolbinary/) .

Définissez [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) sur `true` pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée pour persister le résultat assaini.

Cette option réduit l’exposition à des charges utiles intégrées indésirables, mais ce n’est pas un système complet de détection de logiciels malveillants ou de désinfection de contenu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Comment savoir qu’un fichier est corrompu et ne peut pas être ouvert ?**

Aspose.Slides lève une exception d’analyse ou de format pendant le chargement. Gérez cet échec séparément d’une erreur de mot de passe incorrect afin que l’application puisse signaler la cause avec précision.

**Que se passe-t-il si les polices requises sont manquantes ?**

La présentation peut toujours être chargée, mais le rendu et l’exportation peuvent substituer les polices. Vous pouvez [configurer la substitution de polices](/slides/fr/net/font-substitution/) ou [fournir des polices personnalisées](/slides/fr/net/custom-font/) pour rendre la sortie plus prévisible.

**Le chargement d’une présentation charge-t-il également ses médias intégrés ?**

Les audio et vidéo intégrés deviennent accessibles via le modèle d’objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement des ressources configuré et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.