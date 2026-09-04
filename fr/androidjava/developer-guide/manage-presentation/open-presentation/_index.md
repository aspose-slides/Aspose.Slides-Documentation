---
title: Ouvrir des présentations sur Android
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /fr/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Apprenez à ouvrir des présentations PowerPoint et OpenDocument sur Android, fournir des mots de passe d’ouverture, contrôler le chargement des ressources et réduire l’utilisation de la mémoire avec Aspose.Slides pour Android via Java."
---
## **Introduction**

Aspose.Slides for Android via Java peut charger des présentations PowerPoint et OpenDocument à partir de fichiers et de flux. Après le chargement d’une présentation, vous pouvez inspecter sa structure, modifier les diapositives, gérer les ressources et l’enregistrer dans son format d’origine ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/) . Par exemple, vous pouvez fournir un mot de passe d’ouverture, garder les gros objets binaires en dehors de la mémoire du tas Java, contrôler les ressources externes ou omettre les données binaires incorporées.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) . Libérez la présentation après utilisation afin que les descripteurs de fichiers, les données temporaires et les autres ressources soient rapidement libérés.

L’exemple Java suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :

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

Un mot de passe d’ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, transmettez le mot de passe correct à [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) et fournissez les options au constructeur de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) . Le chargement échoue lorsque le mot de passe est absent ou incorrect.

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

Pour la détection, la validation et les flux de travail de chiffrement des mots de passe, voir [Protéger les présentations par mot de passe](/slides/fr/androidjava/password-protected-presentation/). Si une présentation chiffrée a été délibérément enregistrée avec des propriétés de document publiques, ces propriétés peuvent être lues sans mot de passe ; voir [Gérer les propriétés de la présentation](/slides/fr/androidjava/presentation-properties/).

## **Ouvrir de grandes présentations**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) renvoie des options qui contrôlent la façon dont Aspose.Slides gère les gros objets binaires tels que les images, l’audio et la vidéo. Vous pouvez garder le fichier source verrouillé, autoriser les fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

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
Avec [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked), le fichier source reste verrouillé jusqu’à ce que l’instance de présentation soit libérée. Ne déplacez pas, ne remplacez pas et ne supprimez pas le fichier source tant que cette instance est vivante.

Aspose.Slides peut copier le contenu d’un flux d’entrée lors du chargement. Pour les grandes présentations, un chemin de fichier est donc généralement plus efficace qu’un flux. Consultez [Gérer les BLOBs](/slides/fr/androidjava/manage-blob/) pour des options supplémentaires de stockage et de gestion de la mémoire.
{{% /alert %}}

## **Contrôler les ressources externes**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) accepte une implémentation de [IResourceLoadingCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iresourceloadingcallback/) . Le rappel peut fournir des données de remplacement, rediriger une ressource, utiliser le chargeur par défaut ou ignorer la ressource. Ceci est utile lorsque les présentations contiennent des images externes qui doivent être résolues selon des règles de sécurité ou de stockage spécifiques à l’application.

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

## **Charger des présentations sans objets binaires incorporés**

Une présentation peut contenir des données binaires incorporées qu’une application n’a pas besoin ou ne souhaite pas conserver. Exemples :

- projets VBA, accessibles via [IPresentation.getVbaProject](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) ;
- données OLE incorporées, accessibles via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) ;
- données de contrôle ActiveX, accessibles via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) .

Définissez [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) sur `true` pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée pour persister le résultat assaini.

Cette option réduit l’exposition à des charges utiles indésirables incorporées, mais ce n’est pas un système complet de détection de logiciels malveillants ou de désinfection de contenu.

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

**Comment puis‑je savoir qu’un fichier est corrompu et ne peut pas être ouvert ?**

Aspose.Slides lève une exception d’analyse ou de format pendant le chargement. Gérez cet échec séparément d’une erreur de mot de passe incorrect afin que l’application puisse signaler la cause avec précision.

**Que se passe‑t‑il si les polices requises sont manquantes ?**

La présentation peut encore se charger, mais le rendu et l’exportation peuvent substituer les polices. Vous pouvez [configurer la substitution de police](/slides/fr/androidjava/font-substitution/) ou [fournir des polices personnalisées](/slides/fr/androidjava/custom-font/) pour rendre la sortie plus prévisible.

**Le chargement d’une présentation charge‑t‑il également ses médias incorporés ?**

Les audio et vidéo incorporés deviennent accessibles via le modèle d’objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement des ressources configuré et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.