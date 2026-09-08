---
title: Ouvrir des présentations en Python via Java
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /fr/python-java/open-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Apprenez comment ouvrir des présentations PowerPoint et OpenDocument en Python via Java, fournir des mots de passe d’ouverture, contrôler le chargement des ressources et réduire l’utilisation de la mémoire avec Aspose.Slides pour Python via Java."
---
## **Introduction**

[Aspose.Slides pour Python via Java](https://products.aspose.com/slides/fr/python-java/) peut charger des présentations PowerPoint et OpenDocument à partir de fichiers et de flux. Une fois la présentation chargée, vous pouvez inspecter sa structure, modifier les diapositives, gérer les ressources et l’enregistrer au format d’origine ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/). Par exemple, vous pouvez fournir un mot de passe d’ouverture, conserver les gros objets binaires hors de la mémoire du tas Java, contrôler les ressources externes ou omettre les données binaires intégrées.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). Libérez la présentation après utilisation afin que les poignées de fichier, les données temporaires et les autres ressources soient rapidement libérées.

L’exemple Python suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Ouvrir des présentations protégées par mot de passe**

Un mot de passe d’ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, transmettez le mot de passe correct à [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setPassword) et fournissez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). Le chargement échoue si le mot de passe est absent ou incorrect.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Pour les flux de détection, de validation et de chiffrement des mots de passe, consultez [Présentations protégées par mot de passe](/slides/fr/python-java/password-protected-presentation/). Si une présentation chiffrée a été enregistrée délibérément avec des propriétés de document publiques, ces propriétés peuvent être lues sans mot de passe ; voir [Gérer les propriétés de la présentation](/slides/fr/python-java/presentation-properties/).

## **Ouvrir de grandes présentations**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) renvoie des options qui contrôlent la façon dont Aspose.Slides gère les objets binaires volumineux tels que les images, l’audio et la vidéo. Vous pouvez garder le fichier source verrouillé, autoriser les fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

Le code Python suivant illustre le chargement d’une grande présentation (par exemple, 2 Go) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Remarque" %}}
Avec PresentationLockingBehavior.KeepLocked, le fichier source reste verrouillé jusqu’à ce que l’instance de présentation soit libérée. Ne déplacez pas, ne remplacez pas et ne supprimez pas le fichier source tant que cette instance est active.

Aspose.Slides peut copier le contenu d’un flux d’entrée lors de son chargement. Pour les présentations volumineuses, un chemin de fichier est donc généralement plus efficace qu’un flux. Consultez [Gérer les BLOBs](/slides/fr/python-java/manage-blob/) pour des options supplémentaires de stockage et de gestion de la mémoire.
{{% /alert %}}

## **Contrôler les ressources externes**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepte un proxy JPype implémentant l’interface de rappel de chargement de ressources Java. Le rappel peut fournir des données de remplacement, rediriger une ressource, utiliser le chargeur par défaut ou ignorer la ressource. Cela est utile lorsque les présentations contiennent des images externes qui doivent être résolues selon des règles de sécurité ou de stockage spécifiques à l’application.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Charger des présentations sans objets binaires intégrés**

Une présentation peut contenir des données binaires intégrées qu’une application n’a pas besoin ou ne souhaite pas conserver. Exemples :

- Projets VBA, disponibles via [Presentation.getVbaProject](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getVbaProject);
- Données OLE intégrées, disponibles via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- Données de contrôle ActiveX, disponibles via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/fr/python-java/aspose.slides/control/#getActiveXControlBinary).

Définissez [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) sur `True` pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée pour conserver le résultat assaini.

Cette option réduit l’exposition à des charges utiles intégrées indésirables, mais ce n’est pas un système complet de détection de logiciels malveillants ou de désinfection de contenu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Comment savoir qu’un fichier est corrompu et ne peut pas être ouvert ?**

Aspose.Slides lève une exception d’analyse ou de format lors du chargement. Gérez cet échec séparément d’une erreur de mot de passe incorrect afin que l’application puisse signaler la cause avec précision.

**Que se passe-t-il si les polices requises sont manquantes ?**

La présentation peut toujours se charger, mais le rendu et l’exportation peuvent substituer les polices. Vous pouvez [configurer la substitution de polices](/slides/fr/python-java/font-substitution/) ou [fournir des polices personnalisées](/slides/fr/python-java/custom-font/) pour rendre la sortie plus prévisible.

**Le chargement d’une présentation charge-t-il également ses médias intégrés ?**

L’audio et la vidéo intégrés deviennent accessibles via le modèle d’objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement de ressources configuré et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.