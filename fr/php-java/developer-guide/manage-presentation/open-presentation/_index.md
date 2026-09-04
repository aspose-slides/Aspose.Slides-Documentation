---
title: Ouvrir des présentations en PHP
linktitle: Ouvrir la présentation
type: docs
weight: 20
url: /fr/php-java/open-presentation/
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
- PHP
- Aspose.Slides
description: "Apprenez à ouvrir des présentations PowerPoint et OpenDocument en PHP, à fournir des mots de passe d’ouverture, à contrôler le chargement des ressources et à réduire l’utilisation de la mémoire avec Aspose.Slides pour PHP via Java."
---
## **Introduction**

[Aspose.Slides pour PHP via Java](https://products.aspose.com/slides/fr/php-java/) peut charger des présentations PowerPoint et OpenDocument à partir de fichiers ou de flux. Une fois la présentation chargée, vous pouvez inspecter sa structure, modifier les diapositives, gérer les ressources et l’enregistrer dans le format d’origine ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/). Par exemple, vous pouvez fournir un mot de passe d’ouverture, conserver de gros objets binaires en dehors de la mémoire du tas Java, contrôler les ressources externes ou omettre les données binaires intégrées.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). Libérez la présentation après utilisation afin que les poignées de fichier, les données temporaires et les autres ressources soient rapidement libérées.

L’exemple PHP suivant montre comment ouvrir une présentation et obtenir son nombre de diapositives :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Ouvrir des présentations protégées par mot de passe**

Un mot de passe d’ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, transmettez le mot de passe correct à [LoadOptions::setPassword](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setPassword) et fournissez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). Le chargement échoue si le mot de passe est absent ou incorrect.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Pour la détection, la validation et les flux de travail de chiffrement des mots de passe, consultez [Password-Protect Presentations](/slides/fr/php-java/password-protected-presentation/). Si une présentation chiffrée a été enregistrée intentionnellement avec des propriétés de document publiques, ces propriétés peuvent être lues sans mot de passe ; voir [Manage Presentation Properties](/slides/fr/php-java/presentation-properties/).

## **Ouvrir de grandes présentations**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) renvoie les options qui contrôlent la façon dont Aspose.Slides gère les objets binaires volumineux tels que les images, l’audio et la vidéo. Vous pouvez garder le fichier source verrouillé, autoriser les fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

Le code PHP suivant montre comment charger une grande présentation (par exemple, 2 Go) :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Avec [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), le fichier source reste verrouillé jusqu’à ce que l’instance de présentation soit libérée. Ne déplacez, n’écrasez ni ne supprimez pas le fichier source tant que cette instance est vivante.

Aspose.Slides peut copier le contenu d’un flux d’entrée lors du chargement. Pour les grandes présentations, un chemin de fichier est donc généralement plus efficace qu’un flux. Consultez [Manage BLOBs](/slides/fr/php-java/manage-blob/) pour des options supplémentaires de stockage et de gestion de la mémoire.
{{% /alert %}}

## **Contrôler les ressources externes**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepte une implémentation de l’interface Java [IResourceLoadingCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iresourceloadingcallback/) via PHP/Java Bridge. Le rappel peut fournir des données de remplacement, rediriger une ressource, utiliser le chargeur par défaut ou ignorer la ressource. Cela est utile lorsque les présentations contiennent des images externes qui doivent être résolues selon des règles de sécurité ou de stockage spécifiques à l’application.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Charger des présentations sans objets binaires intégrés**

Une présentation peut contenir des données binaires intégrées qu’une application n’a pas besoin ou ne souhaite pas conserver. Exemples :

- projets VBA, accessibles via [Presentation::getVbaProject](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getVbaProject) ;
- données OLE intégrées, accessibles via [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/fr/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) ;
- données de contrôles ActiveX, accessibles via [Control::getActiveXControlBinary](https://reference.aspose.com/slides/fr/php-java/aspose.slides/control/#getActiveXControlBinary).

Définissez [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) sur `true` pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée pour conserver le résultat assaini.

Cette option réduit l’exposition à des charges utiles intégrées indésirables, mais elle ne constitue pas un système complet de détection de logiciels malveillants ou de désinfection du contenu.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Comment savoir si un fichier est corrompu et ne peut pas être ouvert ?**

Aspose.Slides lève une exception d’analyse ou de format lors du chargement. Gérez cet échec séparément d’une erreur de mot de passe incorrect afin que l’application puisse rapporter la cause avec précision.

**Que se passe-t-il si des polices requises sont manquantes ?**

La présentation peut tout de même être chargée, mais le rendu et l’exportation peuvent substituer les polices. Vous pouvez [configurer la substitution de polices](/slides/fr/php-java/font-substitution/) ou [fournir des polices personnalisées](/slides/fr/php-java/custom-font/) pour rendre la sortie plus prévisible.

**Le chargement d’une présentation charge‑t‑il également ses médias intégrés ?**

Les fichiers audio et vidéo intégrés deviennent accessibles via le modèle d’objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement des ressources configuré et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.