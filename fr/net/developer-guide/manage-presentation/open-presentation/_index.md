---
title: Ouvrir une présentation en C#
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /net/open-presentation/
keywords: "Ouvrir PowerPoint, PPTX, PPT, Ouvrir présentation, Charger présentation, C#, Csharp, .NET"
description: "Ouvrir ou charger une présentation PPT, PPTX, ODP en C# ou .NET"
---

En plus de créer des présentations PowerPoint à partir de zéro, Aspose.Slides vous permet d'ouvrir des présentations existantes. Après avoir chargé une présentation, vous pouvez obtenir des informations sur la présentation, modifier la présentation (le contenu de ses diapositives), ajouter de nouvelles diapositives ou supprimer celles existantes, etc. 

## Ouvrir une présentation

Pour ouvrir une présentation existante, vous devez simplement instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et passer le chemin du fichier (de la présentation que vous souhaitez ouvrir) à son constructeur.

Ce code C# vous montre comment ouvrir une présentation et également découvrir le nombre de diapositives qu'elle contient : 

```c#
// Instancie la classe Presentation et passe le chemin du fichier à son constructeur
Presentation pres = new Presentation("OpenPresentation.pptx");

// Affiche le nombre total de diapositives présentes dans la présentation
System.Console.WriteLine(pres.Slides.Count.ToString());
```

## **Ouvrir une présentation protégée par mot de passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, vous pouvez passer le mot de passe via la propriété [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) (de la classe [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)) pour décrypter et charger la présentation. Ce code C# démontre l'opération :

```c#
	LoadOptions loadOptions = new LoadOptions {Password = "VOTRE_MOT_DE_PASSE"};
	using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
	{
	  // Faites quelque chose avec la présentation décryptée
	}
```

## Ouvrir une grande présentation

Aspose.Slides fournit des options (la propriété [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) en particulier) sous la classe [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) pour vous permettre de charger de grandes présentations.

Ce C# démontre une opération dans laquelle une grande présentation (disons 2 Go de taille) est chargée :

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // Choisissons le comportement KeepLocked - le "veryLargePresentation.pptx" sera verrouillé pour
        // la durée de vie de l'instance de la Présentation, mais nous n'avons pas besoin de le charger en mémoire ou de le copier dans
        // le fichier temporaire
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // La grande présentation a été chargée et peut être utilisée, mais la consommation de mémoire reste faible.

    // Apporte des modifications à la présentation.
    pres.Slides[0].Name = "Très grande présentation";

    // La présentation sera enregistrée dans l'autre fichier. La consommation de mémoire reste faible pendant l'opération
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // impossible de faire ça ! Une exception IO sera lancée, car le fichier est verrouillé pendant que les objets pres ne seront
    // pas disposés
    File.Delete(pathToVeryLargePresentationFile);
}

// Il est acceptable de le faire ici, le fichier source n'est pas verrouillé par l'objet pres
File.Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Info" %}}

Pour contourner certaines limitations lors de l'interaction avec les flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et provoquera un chargement lent. Par conséquent, lorsque vous envisagez de charger une grande présentation, nous vous recommandons fortement d'utiliser le chemin du fichier de présentation et non son flux.

Lorsque vous souhaitez créer une présentation contenant de gros objets (vidéos, audio, grandes images, etc.), vous pouvez utiliser la [facility Blob](https://docs.aspose.com/slides/net/manage-blob/) pour réduire la consommation de mémoire.

{{%/alert %}} 


## Charger une présentation
Aspose.Slides fournit [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) avec une seule méthode pour vous permettre de gérer des ressources externes. Ce code C# vous montre comment utiliser l'interface `IResourceLoadingCallback` :

```c#
LoadOptions opts = new LoadOptions();
opts.ResourceLoadingCallback = new ImageLoadingHandler();
Presentation presentation = new Presentation("presentation.pptx", opts);
```

```c#
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try // Charge une image de substitution
            {
                byte[] imageBytes = File.ReadAllBytes("c:\\aspose-logo.jpg");
                args.SetData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Définit l'url de substitution
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Ignore toutes les autres images
        return ResourceLoadingAction.Skip;
    }
}
```

## Charger une présentation sans objets binaires intégrés

La présentation PowerPoint peut contenir les types suivants d'objets binaires intégrés :

- Projet VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- Données OLE Object intégrées ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Données binaires de contrôle ActiveX ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/));

En utilisant la propriété [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/), vous pouvez charger la présentation sans aucun objet binaire intégré.

Cette propriété peut être utile pour supprimer du contenu binaire potentiellement malveillant.

Le code C# démontre comment charger et enregistrer une présentation sans contenu malveillant :

```c#
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (var pres = new Presentation("malware.ppt", loadOptions))
{
    pres.Save("clean.ppt", SaveFormat.Ppt);
}
```

<h2>Ouvrir et enregistrer une présentation</h2>

<a name="csharp-open-save-presentation"><strong>Étapes : Ouvrir et enregistrer une présentation en C#</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et passez le fichier que vous souhaitez ouvrir. 
2. Enregistrez la présentation.

```c#
// Charge n'importe quelle présentation supportée, par exemple ppt, pptx, odp
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```