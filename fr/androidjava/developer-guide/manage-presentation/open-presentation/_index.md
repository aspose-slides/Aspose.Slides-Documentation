---
title: Ouvrir des présentations sur Android
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /fr/androidjava/open-presentation/
keywords:
- ouvrir PowerPoint
- ouvrir une présentation
- ouvrir PPTX
- ouvrir PPT
- ouvrir ODP
- charger une présentation
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
description: "Apprenez à ouvrir des présentations PowerPoint et OpenDocument sur Android, à fournir les mots de passe d’ouverture, à contrôler le chargement des ressources et à réduire l’utilisation de la mémoire avec Aspose.Slides pour Android via Java."
---
## **Introduction**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/fr/androidjava/) peut charger des présentations PowerPoint et OpenDocument à partir de fichiers et de flux. Après le chargement d’une présentation, vous pouvez inspecter sa structure, modifier les diapositives, gérer les ressources et l’enregistrer dans le format d’origine ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/). Par exemple, vous pouvez fournir un mot de passe d’ouverture, conserver les gros objets binaires en dehors de la mémoire du tas Java, contrôler les ressources externes ou ignorer les données binaires incorporées.

## **Open Presentations**

Après avoir chargé un fichier ou un flux, vous pouvez [déterminer son format de présentation d’origine](/slides/fr/androidjava/detect-presentation-source-format/) pour choisir la façon dont votre application le traite.

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/). Libérez la présentation après utilisation afin que les poignées de fichier, les données temporaires et les autres ressources soient rapidement libérées.

L’exemple Java suivant montre comment ouvrir une présentation et obtenir son nombre de diapositives :

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Open Password-Protected Presentations**

Un mot de passe d’ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, transmettez le mot de passe correct à [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) et fournissez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/). Le chargement échoue si le mot de passe est absent ou incorrect.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Pour la détection, la validation et les flux de travail de chiffrement des mots de passe, consultez [Password-Protect Presentations](/slides/fr/androidjava/password-protected-presentation/). Si une présentation chiffrée a été enregistrée intentionnellement avec des propriétés de document publiques, ces propriétés peuvent être lues sans mot de passe ; voir [Manage Presentation Properties](/slides/fr/androidjava/presentation-properties/).

## **Open Large Presentations**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) renvoie des options qui contrôlent la façon dont Aspose.Slides gère les objets binaires volumineux tels que les images, l’audio et la vidéo. Vous pouvez maintenir le fichier source verrouillé, autoriser les fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

Le code Java suivant montre le chargement d’une grande présentation (par exemple, 2 Go) :

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Avec [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked), le fichier source reste verrouillé jusqu’à ce que l’instance de présentation soit libérée. Ne déplacez pas, ne remplacez pas et ne supprimez pas le fichier source tant que cette instance est active.

Aspose.Slides peut copier le contenu d’un flux d’entrée lors du chargement. Pour les grandes présentations, un chemin de fichier est donc généralement plus efficace qu’un flux. Consultez [Manage BLOBs](/slides/fr/androidjava/manage-blob/) pour des options supplémentaires de stockage et de gestion de la mémoire.
{{% /alert %}}

## **Control External Resources**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) accepte une implémentation de [IResourceLoadingCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iresourceloadingcallback/). Le rappel peut fournir des données de substitution, rediriger une ressource, utiliser le chargeur par défaut ou ignorer la ressource. Ceci est utile lorsque les présentations contiennent des images externes qui doivent être résolues selon des règles de sécurité ou de stockage spécifiques à l’application.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Load Presentations without Embedded Binary Objects**

Une présentation peut contenir des données binaires intégrées qu’une application n’a pas besoin ou ne veut pas conserver. Par exemple :

- Projets VBA, disponibles via [IPresentation.getVbaProject](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- données OLE intégrées, disponibles via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- données de contrôle ActiveX, disponibles via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Définissez [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) à `true` pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée afin de conserver le résultat nettoyé.

Cette option réduit l’exposition à des charges utiles intégrées indésirables, mais ce n’est pas un système complet de détection de logiciels malveillants ou de désinfection de contenu.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Comment savoir qu’un fichier est corrompu et ne peut pas être ouvert ?**

Aspose.Slides lève une exception d’analyse ou de format lors du chargement. Gérez cet échec séparément d’une erreur de mot de passe incorrect afin que l’application puisse signaler la cause avec précision.

**Que se passe-t-il si les polices requises sont manquantes ?**

La présentation peut toujours être chargée, mais le rendu et l’exportation peuvent substituer les polices. Vous pouvez [configurer la substitution de polices](/slides/fr/androidjava/font-substitution/) ou [fournir des polices personnalisées](/slides/fr/androidjava/custom-font/) pour rendre la sortie plus prévisible.

**Le chargement d’une présentation charge-t-il également ses médias intégrés ?**

L’audio et la vidéo intégrés deviennent accessibles via le modèle d’objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement des ressources configuré et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.