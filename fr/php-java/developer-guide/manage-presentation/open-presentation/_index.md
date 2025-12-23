---
title: Ouvrir des présentations en PHP
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /fr/php-java/open-presentation/
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
- PHP
- Aspose.Slides
description: "Ouvrez facilement les présentations PowerPoint (.pptx, .ppt) et OpenDocument (.odp) avec Aspose.Slides pour PHP via Java — rapide, fiable, complet."
---

## **Vue d'ensemble**

Au-delà de la création de présentations PowerPoint à partir de zéro, Aspose.Slides vous permet également d'ouvrir des présentations existantes. Après avoir chargé une présentation, vous pouvez en récupérer les informations, modifier le contenu des diapositives, ajouter de nouvelles diapositives, supprimer celles existantes, et plus encore.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, instanciez la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et transmettez le chemin du fichier à son constructeur.

L'exemple PHP suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :
```php
// Instanciez la classe Presentation et passez un chemin de fichier à son constructeur.
$presentation = new Presentation("Sample.pptx");
try {
    // Affichez le nombre total de diapositives de la présentation.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```


## **Ouvrir des présentations protégées par mot de passe**

Lorsque vous devez ouvrir une présentation protégée par mot de passe, transmettez le mot de passe via la méthode [setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) de la classe [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) pour la déchiffrer et la charger. Le code PHP suivant montre cette opération :
```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Effectuez des opérations sur la présentation décryptée.
} finally {
    $presentation->dispose();
}
```


## **Ouvrir de grandes présentations**

Aspose.Slides propose des options—en particulier la méthode [getBlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) de la classe [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)—pour vous aider à charger de grandes présentations.

Le code PHP suivant montre le chargement d'une grande présentation (par exemple, 2 Go) :
```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Choisissez le comportement KeepLocked — le fichier de présentation restera verrouillé pendant la durée de
// l'instance Presentation, mais il n'est pas nécessaire de le charger en mémoire ou de le copier vers un fichier temporaire.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 Mo

$presentation = new Presentation($filePath, $loadOptions);
try {
    // La grande présentation a été chargée et peut être utilisée, tout en maintenant une faible consommation de mémoire.

    // Apportez des modifications à la présentation.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Enregistrez la présentation dans un autre fichier. La consommation de mémoire reste faible pendant cette opération.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
    
    // Ne faites pas cela ! Une exception d'E/S sera levée car le fichier reste verrouillé jusqu'à la libération de l'objet présentation.
    //unlink($filePath);
} finally {
    $presentation->dispose();
}
// Il est acceptable de le faire ici. Le fichier source n'est plus verrouillé par l'objet présentation.
unlink($filePath);
```


{{% alert color="info" title="Info" %}}
Pour contourner certaines limitations lors de l'utilisation de flux, Aspose.Slides peut copier le contenu d'un flux. Charger une grande présentation à partir d'un flux entraîne la copie de la présentation et peut ralentir le chargement. Ainsi, lorsque vous devez charger une grande présentation, nous vous recommandons fortement d'utiliser le chemin du fichier de présentation plutôt qu'un flux.

Lorsque vous créez une présentation contenant de gros objets (vidéo, audio, images haute résolution, etc.), vous pouvez utiliser la [gestion BLOB](/slides/fr/php-java/manage-blob/) pour réduire la consommation de mémoire.
{{%/alert %}}

## **Contrôler les ressources externes**

Aspose.Slides fournit l'interface [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) qui vous permet de gérer les ressources externes. Le code PHP suivant montre comment utiliser l'interface `IResourceLoadingCallback` :
```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Charger une image de substitution.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Définir une URL de substitution.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Ignorer toutes les autres images.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```


## **Charger des présentations sans objets binaires intégrés**

Une présentation PowerPoint peut contenir les types d'objets binaires intégrés suivants :

- Projet VBA (accessible via [Presentation.getVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject));
- Données intégrées d'objet OLE (accessible via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Données binaires de contrôle ActiveX (accessible via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getActiveXControlBinary)).

En utilisant la méthode [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), vous pouvez charger une présentation sans aucun objet binaire intégré.

Cette méthode est utile pour supprimer un contenu binaire potentiellement malveillant. Le code PHP suivant montre comment charger une présentation sans aucun contenu binaire intégré :
```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Effectuer des opérations sur la présentation.
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Comment savoir si un fichier est corrompu et ne peut pas être ouvert ?**

Vous recevrez une exception de validation/parsing du format lors du chargement. Ces erreurs mentionnent souvent une structure ZIP invalide ou des enregistrements PowerPoint corrompus.

**Que se passe-t-il si les polices requises sont manquantes lors de l'ouverture ?**

Le fichier s'ouvrira, mais le [rendu/export](/slides/fr/php-java/convert-presentation/) pourra substituer les polices. [Configurez les substitutions de polices](/slides/fr/php-java/font-substitution/) ou [ajoutez les polices requises](/slides/fr/php-java/custom-font/) à l'environnement d'exécution.

**Qu'en est-il des médias intégrés (vidéo/audio) lors de l'ouverture ?**

Ils deviennent disponibles comme ressources de la présentation. Si les médias sont référencés via des chemins externes, assurez-vous que ces chemins sont accessibles dans votre environnement ; sinon le [rendu/export](/slides/fr/php-java/convert-presentation/) pourrait omettre les médias.