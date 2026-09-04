---
title: Ouvrir des présentations en JavaScript
linktitle: Ouvrir la présentation
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
description: "Apprenez comment ouvrir des présentations PowerPoint et OpenDocument en JavaScript, fournir des mots de passe d'ouverture, contrôler le chargement des ressources et réduire l'utilisation de la mémoire avec Aspose.Slides pour Node.js via Java."
---
## **Introduction**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/fr/nodejs-java/) peut charger des présentations PowerPoint et OpenDocument à partir de fichiers et de flux. Après le chargement d'une présentation, vous pouvez inspecter sa structure, modifier les diapositives, gérer les ressources et l'enregistrer au format d'origine ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/). Par exemple, vous pouvez fournir un mot de passe d'ouverture, conserver les gros objets binaires hors de la mémoire Node.js, contrôler les ressources externes ou omettre les données binaires intégrées.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/). Libérez la présentation après utilisation afin que les descripteurs de fichiers, les données temporaires et les autres ressources soient rapidement libérés.

L'exemple JavaScript suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Ouvrir des présentations protégées par mot de passe**

Un mot de passe d'ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, transmettez le mot de passe correct à [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setPassword) et fournissez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/). Le chargement échoue si le mot de passe est manquant ou incorrect.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Pour la détection, la validation et les flux de travail de chiffrement des mots de passe, consultez [Présentations protégées par mot de passe](/slides/fr/nodejs-java/password-protected-presentation/). Si une présentation chiffrée a été enregistrée délibérément avec des propriétés de document publiques, ces propriétés peuvent être lues sans mot de passe ; voir [Gérer les propriétés de la présentation](/slides/fr/nodejs-java/presentation-properties/).

## **Ouvrir de grandes présentations**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) renvoie des options qui contrôlent la façon dont Aspose.Slides gère les objets binaires volumineux tels que les images, l'audio et la vidéo. Vous pouvez garder le fichier source verrouillé, autoriser les fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

Le code JavaScript suivant montre comment charger une grande présentation (par exemple, 2 Go) :

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Avec [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), le fichier source reste verrouillé jusqu'à ce que l'instance de présentation soit libérée. Ne déplacez pas, n'écrasez pas et ne supprimez pas le fichier source tant que cette instance est active.

Aspose.Slides peut copier le contenu d'un flux d'entrée lors du chargement. Pour les grandes présentations, un chemin de fichier est généralement plus efficace qu'un flux. Consultez [Manage BLOBs](/slides/fr/nodejs-java/manage-blob/) pour des options supplémentaires de stockage et de gestion de la mémoire.
{{% /alert %}}

## **Contrôler les ressources externes**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepte une implémentation de [IResourceLoadingCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iresourceloadingcallback/). Le rappel peut fournir des données de remplacement, rediriger une ressource, utiliser le chargeur par défaut ou ignorer la ressource. Cela est utile lorsque les présentations contiennent des images externes qui doivent être résolues selon des règles de sécurité ou de stockage spécifiques à l'application.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Charger des présentations sans objets binaires intégrés**

Une présentation peut contenir des données binaires intégrées qu'une application n'a pas besoin ou ne souhaite pas conserver. Les exemples incluent :

- projets VBA, accessibles via [Presentation.getVbaProject](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getVbaProject);
- données OLE intégrées, accessibles via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- données de contrôle ActiveX, accessibles via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Définissez [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) sur `true` pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée pour conserver le résultat nettoyé.

Cette option réduit l'exposition à des charges utiles intégrées indésirables, mais ce n'est pas un système complet de détection de logiciels malveillants ou de désinfection de contenu.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Comment savoir qu'un fichier est corrompu et ne peut pas être ouvert ?**

Aspose.Slides lève une exception d'analyse ou de format lors du chargement. Gérez cet échec séparément d'une erreur de mot de passe incorrect afin que l'application puisse signaler la cause avec précision.

**Que se passe-t-il si les polices requises sont manquantes ?**

La présentation peut toujours se charger, mais le rendu et l'exportation peuvent substituer les polices. Vous pouvez [configurer la substitution de polices](/slides/fr/nodejs-java/font-substitution/) ou [fournir des polices personnalisées](/slides/fr/nodejs-java/custom-font/) pour rendre la sortie plus prévisible.

**Le chargement d'une présentation charge-t-il également ses médias intégrés ?**

L'audio et la vidéo intégrés deviennent accessibles via le modèle d'objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement des ressources configuré et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.