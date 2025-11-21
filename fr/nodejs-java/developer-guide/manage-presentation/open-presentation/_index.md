---
title: Ouvrir une présentation en JavaScript
linktitle: Ouvrir des présentations
type: docs
weight: 20
url: /fr/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ouvrez des présentations PowerPoint (.pptx, .ppt) et OpenDocument (.odp) en toute simplicité avec Aspose.Slides pour Node.js — rapide, fiable, entièrement fonctionnel."
---

## **Vue d'ensemble**

Au-delà de la création de présentations PowerPoint à partir de zéro, Aspose.Slides vous permet également d'ouvrir des présentations existantes. Après avoir chargé une présentation, vous pouvez en récupérer les informations, modifier le contenu des diapositives, ajouter de nouvelles diapositives, supprimer celles existantes, et bien plus encore.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et transmettez le chemin du fichier à son constructeur.

L'exemple JavaScript suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :
```js
// Instanciez la classe Presentation et transmettez un chemin de fichier à son constructeur.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Affichez le nombre total de diapositives dans la présentation.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Ouvrir des présentations protégées par mot de passe**

Lorsque vous devez ouvrir une présentation protégée par un mot de passe, transmettez le mot de passe via la méthode [setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setPassword) de la classe [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) pour la déchiffrer et la charger. Le code JavaScript suivant démontre cette opération :
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Effectuez des opérations sur la présentation décryptée.
} finally {
    presentation.dispose();
}
```


## **Ouvrir de grandes présentations**

Aspose.Slides propose des options — notamment la méthode [getBlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) de la classe [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) — pour vous aider à charger de grandes présentations.

Le code JavaScript suivant montre comment charger une grande présentation (par exemple, 2 Go) :
```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Choisissez le comportement KeepLocked — le fichier de présentation restera verrouillé pendant la durée de vie de
// l'instance Presentation, mais il n'est pas nécessaire de le charger en mémoire ou de le copier dans un fichier temporaire.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 Mo

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // La grande présentation a été chargée et peut être utilisée, tout en maintenant une faible consommation de mémoire.
    
    // Apportez des modifications à la présentation.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Enregistrez la présentation dans un autre fichier. La consommation de mémoire reste faible pendant cette opération.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Ne faites pas cela ! Une exception d'E/S sera levée car le fichier reste verrouillé jusqu'à ce que l'objet présentation soit libéré.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Il est correct de le faire ici. Le fichier source n'est plus verrouillé par l'objet présentation.
fs.unlinkSync(filePath);
```


{{% alert color="info" title="Info" %}}
Pour contourner certaines limitations lors de l'utilisation de flux, Aspose.Slides peut copier le contenu d'un flux. Charger une grande présentation à partir d'un flux entraîne la copie de la présentation et peut ralentir le chargement. Par conséquent, lorsque vous devez charger une grande présentation, nous vous recommandons fortement d'utiliser le chemin du fichier de présentation plutôt qu'un flux.

Lors de la création d'une présentation contenant de grands objets (vidéo, audio, images haute résolution, etc.), vous pouvez utiliser la [gestion BLOB](/slides/fr/nodejs-java/manage-blob/) pour réduire la consommation de mémoire.
{{%/alert %}}

## **Contrôler les ressources externes**

Aspose.Slides fournit l'interface [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) qui vous permet de gérer les ressources externes. Le code JavaScript suivant montre comment utiliser l'interface `IResourceLoadingCallback` :
```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Charger une image de substitution.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Définir une URL de substitution.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Ignorer toutes les autres images.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```


## **Charger des présentations sans objets binaires intégrés**

Une présentation PowerPoint peut contenir les types d'objets binaires intégrés suivants :

- projet VBA (accessible via [Presentation.getVbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject));
- données d'objet OLE intégrées (accessibles via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- données binaires de contrôle ActiveX (accessibles via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

En utilisant la méthode [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), vous pouvez charger une présentation sans aucun objet binaire intégré.

Cette méthode est utile pour supprimer les contenus binaires potentiellement malveillants. Le code JavaScript suivant montre comment charger une présentation sans aucun contenu binaire intégré :
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Effectuer des opérations sur la présentation.
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Comment savoir qu'un fichier est corrompu et ne peut pas être ouvert ?**

Vous obtiendrez une exception de validation du format/de l'analyse lors du chargement. Ces erreurs mentionnent souvent une structure ZIP invalide ou des enregistrements PowerPoint corrompus.

**Que se passe-t-il si les polices requises sont absentes lors de l'ouverture ?**

Le fichier s'ouvrira, mais le [rendu/export](/slides/fr/nodejs-java/convert-presentation/) pourra substituer les polices. [Configurez les substitutions de polices](/slides/fr/nodejs-java/font-substitution/) ou [ajoutez les polices requises](/slides/fr/nodejs-java/custom-font/) à l'environnement d'exécution.

**Qu'en est-il des médias intégrés (vidéo/audio) lors de l'ouverture ?**

Ils deviennent disponibles en tant que ressources de la présentation. Si les médias sont référencés via des chemins externes, assurez-vous que ces chemins sont accessibles dans votre environnement ; sinon le [rendu/export](/slides/fr/nodejs-java/convert-presentation/) pourra omettre les médias.