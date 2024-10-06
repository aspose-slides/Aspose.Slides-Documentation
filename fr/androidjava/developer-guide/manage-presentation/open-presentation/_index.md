---
title: Ouvrir une présentation en Java
linktitle: Ouvrir la présentation
type: docs
weight: 20
url: /androidjava/open-presentation/
keywords: "Ouvrir PowerPoint, PPTX, PPT, Ouvrir la présentation, Charger la présentation, Java"
description: "Ouvrir ou charger une présentation PPT, PPTX, ODP en Java"
---

En plus de créer des présentations PowerPoint à partir de zéro, Aspose.Slides vous permet d'ouvrir des présentations existantes. Après avoir chargé une présentation, vous pouvez obtenir des informations sur la présentation, modifier la présentation (contenu de ses diapositives), ajouter de nouvelles diapositives ou en supprimer des existantes, etc. 

## Ouvrir la Présentation

Pour ouvrir une présentation existante, vous devez simplement instancier la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et passer le chemin du fichier (de la présentation que vous souhaitez ouvrir) à son constructeur.

Ce code Java vous montre comment ouvrir une présentation et également découvrir le nombre de diapositives qu'elle contient : 

```java
// Instancie la classe Presentation et passe le chemin du fichier à son constructeur
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Affiche le nombre total de diapositives présentes dans la présentation
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ouvrir une Présentation Protégée par Mot de Passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, vous pouvez passer le mot de passe via la propriété [Password](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getPassword--) (de la classe [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)) pour déchiffrer la présentation et charger la présentation. Ce code Java démontre l'opération :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("VOTRE_MOT_DE_PASSE");
Presentation pres = new Presentation("pres.pptx", loadOptions);
try {
    // Effectue des opérations sur la présentation déchiffrée
} finally {
    if (pres != null) pres.dispose();
}
```

## Ouvrir une Grande Présentation

Aspose.Slides fournit des options (la propriété [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) en particulier) sous la classe [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions) pour vous permettre de charger de grandes présentations.

Ce Java démontre une opération dans laquelle une grande présentation (disons de 2 Go) est chargée :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // La grande présentation a été chargée et peut être utilisée, mais la consommation de mémoire reste faible.
    // Effectue des modifications sur la présentation.
    pres.getSlides().get_Item(0).setName("Très grande présentation");

    // La présentation sera sauvegardée dans un autre fichier. La consommation de mémoire reste faible durant l'opération
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="Info" %}}

Pour contourner certaines limitations lors de l'interaction avec un flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et provoquera un chargement lent. Par conséquent, lorsque vous envisagez de charger une grande présentation, nous vous recommandons fortement d'utiliser le chemin du fichier de présentation et non son flux.

Lorsque vous souhaitez créer une présentation contenant de grands objets (vidéo, audio, grandes images, etc.), vous pouvez utiliser la [fonctionnalité Blob](https://docs.aspose.com/slides/androidjava/manage-blob/) pour réduire la consommation de mémoire.

{{%/alert %}} 

## Charger la Présentation

Aspose.Slides fournit [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) avec une seule méthode pour vous permettre de gérer les ressources externes. Ce code Java vous montre comment utiliser l'interface `IResourceLoadingCallback` :

```java
LoadOptions opts = new LoadOptions();
opts.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation pres = new Presentation("presentation.pptx", opts);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback 
{
    public int resourceLoading(IResourceLoadingArgs args) 
    {
        if (args.getOriginalUri().endsWith(".jpg")) 
        {
            try // charge une image de substitution
            {
                byte[] imageBytes = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // définit l'url de substitution
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // saute toutes les autres images
        return ResourceLoadingAction.Skip;
    }
}
```

## Charger la Présentation Sans Objets Binaires Intégrés

La présentation PowerPoint peut contenir les types suivants d'objets binaires intégrés :

- Projet VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/));
- Données d'objets OLE intégrées ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Données binaires ActiveX Control ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--));

En utilisant la propriété [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), vous pouvez charger la présentation sans aucun objet binaire intégré.

Cette propriété peut être utile pour supprimer un contenu binaire potentiellement malveillant.

Le code démontre comment charger et sauvegarder une présentation sans aucun contenu malveillant :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation pres = new Presentation("malware.ppt", loadOptions);
try {
    pres.save("clean.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## Ouvrir et Sauvegarder la Présentation

Étapes pour Ouvrir et Sauvegarder une Présentation :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et passez le fichier que vous souhaitez ouvrir.
2. Sauvegardez la présentation.  

```java
// Instancie un objet Presentation qui représente un fichier PPT
Presentation pres = new Presentation();
try {
    // ...faites un travail ici...
    
    // Sauvegarde votre présentation dans un fichier
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```