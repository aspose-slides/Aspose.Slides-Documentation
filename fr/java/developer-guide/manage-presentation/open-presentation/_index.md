---
title: Ouvrir des présentations en Java
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /fr/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Apprenez comment ouvrir des présentations PowerPoint et OpenDocument en Java, fournir des mots de passe d’ouverture, contrôler le chargement des ressources et réduire l’utilisation de la mémoire avec Aspose.Slides pour Java."
---
## **Introduction**

[Aspose.Slides pour Java](https://products.aspose.com/slides/fr/java/) peut charger des présentations PowerPoint et OpenDocument à partir de fichiers et de flux. Une fois la présentation chargée, vous pouvez examiner sa structure, modifier les diapositives, gérer les ressources et l’enregistrer au format d’origine ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/). Par exemple, vous pouvez fournir un mot de passe d’ouverture, garder les gros objets binaires hors de la mémoire du tas Java, contrôler les ressources externes ou omettre les données binaires intégrées.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). Libérez la présentation après utilisation afin que les poignées de fichier, les données temporaires et les autres ressources soient libérées rapidement.

Le code Java suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Ouvrir des présentations protégées par mot de passe**

Un mot de passe d’ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, transmettez le mot de passe correct à [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) et fournissez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). Le chargement échoue lorsque le mot de passe est absent ou incorrect.

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

Pour la détection, la validation et les flux de travail de chiffrement des mots de passe, consultez [Password‑Protect Presentations](/slides/fr/java/password-protected-presentation/). Si une présentation chiffrée a été enregistrée délibérément avec des propriétés publiques du document, ces propriétés peuvent être lues sans mot de passe ; voir [Manage Presentation Properties](/slides/fr/java/presentation-properties/).

## **Ouvrir de grandes présentations**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) renvoie des options qui contrôlent la façon dont Aspose.Slides gère les gros objets binaires tels que les images, l’audio et la vidéo. Vous pouvez garder le fichier source verrouillé, autoriser les fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

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
Avec [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked), le fichier source reste verrouillé jusqu’à ce que l’instance de présentation soit libérée. Ne déplacez pas, n’écrasez pas et ne supprimez pas le fichier source tant que cette instance est vivante.

Aspose.Slides peut copier le contenu d’un flux d’entrée lors du chargement. Pour de grandes présentations, un chemin de fichier est donc généralement plus efficace qu’un flux. Consultez [Manage BLOBs](/slides/fr/java/manage-blob/) pour des options supplémentaires de stockage et de gestion de la mémoire.
{{% /alert %}}

## **Contrôler les ressources externes**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) accepte une implémentation de [IResourceLoadingCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iresourceloadingcallback/). Le rappel peut fournir des données de remplacement, rediriger une ressource, utiliser le chargeur par défaut ou ignorer la ressource. Cela est utile lorsque les présentations contiennent des images externes qui doivent être résolues selon des règles de sécurité ou de stockage spécifiques à l’application.

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

## **Charger des présentations sans objets binaires intégrés**

Une présentation peut contenir des données binaires intégrées qu’une application n’a pas besoin ou ne veut pas conserver. Parmi les exemples :

- projets VBA, disponibles via [IPresentation.getVbaProject](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getVbaProject--);
- données OLE intégrées, disponibles via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- données de contrôle ActiveX, disponibles via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Définissez [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) sur `true` pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée afin de conserver le résultat assaini.

Cette option réduit l’exposition à des charges utiles intégrées indésirables, mais ce n’est pas un système complet de détection de malware ou de désinfection du contenu.

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

**Comment savoir qu'un fichier est corrompu et ne peut pas être ouvert ?**

Aspose.Slides lève une exception d’analyse ou de format pendant le chargement. Gérez cet échec séparément d’une erreur de mot de passe incorrect afin que l’application puisse signaler la cause avec précision.

**Que se passe-t-il si les polices requises sont manquantes ?**

La présentation peut encore être chargée, mais le rendu et l’exportation peuvent substituer les polices. Vous pouvez [configurer la substitution de polices](/slides/fr/java/font-substitution/) ou [fournir des polices personnalisées](/slides/fr/java/custom-font/) pour rendre la sortie plus prévisible.

**Le chargement d'une présentation charge-t-il également ses médias intégrés ?**

Les audio et vidéo intégrés deviennent disponibles via le modèle d’objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement de ressources configuré et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.