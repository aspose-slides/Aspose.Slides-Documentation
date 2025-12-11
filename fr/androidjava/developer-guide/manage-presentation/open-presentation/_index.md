---
title: Ouvrir des présentations sur Android
linktitle: Ouvrir la présentation
type: docs
weight: 20
url: /fr/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Ouvrez facilement les présentations PowerPoint (.pptx, .ppt) et OpenDocument (.odp) avec Aspose.Slides pour Android via Java—rapide, fiable, entièrement fonctionnel."
---

## **Vue d'ensemble**

Au-delà de la création de présentations PowerPoint à partir de zéro, Aspose.Slides vous permet également d'ouvrir des présentations existantes. Après le chargement d'une présentation, vous pouvez récupérer des informations à son sujet, modifier le contenu des diapositives, ajouter de nouvelles diapositives, supprimer celles existantes, et plus encore.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et transmettez le chemin du fichier à son constructeur.

L'exemple Java suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :
```java
// Instanciez la classe Presentation et passez un chemin de fichier à son constructeur.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Affichez le nombre total de diapositives dans la présentation.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Ouvrir des présentations protégées par mot de passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, transmettez le mot de passe via la méthode [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) de la classe [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) pour la déchiffrer et la charger. Le code Java suivant illustre cette opération :
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Effectuer des opérations sur la présentation déchiffrée.
} finally {
    presentation.dispose();
}
```


## **Ouvrir de grandes présentations**

Aspose.Slides propose des options—en particulier la méthode [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) de la classe [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)—pour vous aider à charger de grandes présentations.

Le code Java suivant montre comment charger une grande présentation (par exemple, 2 Go) :
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Choisissez le comportement KeepLocked — le fichier de présentation restera verrouillé pendant la durée de vie de
// l'instance Presentation, mais il n'est pas nécessaire de le charger en mémoire ou de le copier dans un fichier temporaire.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 Mo

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // La grande présentation a été chargée et peut être utilisée, tout en maintenant une consommation mémoire faible.

    // Apportez des modifications à la présentation.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Enregistrez la présentation dans un autre fichier. La consommation mémoire reste faible pendant cette opération.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Ne faites pas cela ! Une exception d'E/S sera levée car le fichier est verrouillé jusqu'à ce que l'objet Presentation soit libéré.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Il est correct de le faire ici. Le fichier source n'est plus verrouillé par l'objet Presentation.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
Pour contourner certaines limites lors de l'utilisation de flux, Aspose.Slides peut copier le contenu d'un flux. Charger une grande présentation à partir d'un flux entraîne la copie de la présentation et peut ralentir le chargement. Par conséquent, lorsque vous devez charger une grande présentation, nous recommandons vivement d'utiliser le chemin du fichier de présentation plutôt qu'un flux.

Lors de la création d'une présentation contenant de gros objets (vidéo, audio, images haute résolution, etc.), vous pouvez utiliser la [BLOB management](/slides/fr/androidjava/manage-blob/) pour réduire la consommation de mémoire.
{{%/alert %}}

## **Contrôler les ressources externes**

Aspose.Slides fournit l'interface [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) qui vous permet de gérer les ressources externes. Le code Java suivant montre comment utiliser l'interface `IResourceLoadingCallback` :
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Charger une image de substitution.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Utilisez n'importe quelle méthode pour obtenir les octets
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Définir une URL de substitution.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Ignorer toutes les autres images.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Charger des présentations sans objets binaires intégrés**

Une présentation PowerPoint peut contenir les types d'objets binaires intégrés suivants :

- projet VBA (accessible via [IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- données d'objet OLE intégrées (accessibles via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- données binaires du contrôle ActiveX (accessibles via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

En utilisant la méthode [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), vous pouvez charger une présentation sans aucun objet binaire intégré.

Cette méthode est utile pour supprimer le contenu binaire potentiellement malveillant. Le code Java suivant montre comment charger une présentation sans aucun contenu binaire intégré :
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Effectuer des opérations sur la présentation.
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Comment savoir si un fichier est corrompu et ne peut pas être ouvert ?**

Vous recevrez une exception de validation du format ou d’analyse lors du chargement. Ces erreurs mentionnent souvent une structure ZIP invalide ou des enregistrements PowerPoint corrompus.

**Que se passe-t-il si les polices requises sont manquantes lors de l'ouverture ?**

Le fichier s'ouvrira, mais le [rendu/export](/slides/fr/androidjava/convert-presentation/) peut substituer les polices. [Configurez les substitutions de polices](/slides/fr/androidjava/font-substitution/) ou [ajoutez les polices requises](/slides/fr/androidjava/custom-font/) à l'environnement d'exécution.

**Qu'en est-il des médias intégrés (vidéo/audio) lors de l'ouverture ?**

Ils deviennent disponibles en tant que ressources de la présentation. Si les médias sont référencés via des chemins externes, assurez‑vous que ces chemins sont accessibles dans votre environnement ; sinon le [rendu/export](/slides/fr/androidjava/convert-presentation/) peut omettre les médias.