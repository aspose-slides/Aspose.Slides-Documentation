---
title: Ouvrir des présentations en Python via Java
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /fr/python-java/open-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Apprenez comment ouvrir des présentations PowerPoint et OpenDocument en Python via Java, fournir des mots de passe d'ouverture, contrôler le chargement des ressources et réduire l'utilisation de la mémoire avec Aspose.Slides pour Python via Java."
---
## **Introduction**

Aspose.Slides for Python via Java peut charger des présentations PowerPoint et OpenDocument à partir de fichiers et de flux. Après le chargement d’une présentation, vous pouvez inspecter sa structure, modifier les diapositives, gérer les ressources et l’enregistrer au format d’origine ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe LoadOptions. Par exemple, vous pouvez fournir un mot de passe d’ouverture, garder les gros objets binaires hors de la mémoire du tas Java, contrôler les ressources externes ou omettre les données binaires intégrées.

## **Ouvrir des présentations**

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur Presentation. Libérez la présentation après utilisation afin que les poignées de fichiers, les données temporaires et les autres ressources soient libérées rapidement.

Le code Python suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :

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

Un mot de passe d’ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, transmettez le mot de passe correct à LoadOptions.setPassword et fournissez les options au constructeur Presentation. Le chargement échoue si le mot de passe est absent ou incorrect.

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

Pour la détection, la validation et les flux de travail de chiffrement des mots de passe, consultez Password‑Protect Presentations. Si une présentation chiffrée a été enregistrée volontairement avec des propriétés de document publiques, ces propriétés peuvent être lues sans mot de passe ; voir Manage Presentation Properties.

## **Ouvrir de grandes présentations**

LoadOptions.getBlobManagementOptions renvoie des options qui contrôlent la façon dont Aspose.Slides gère les objets binaires volumineux tels que les images, l’audio et la vidéo. Vous pouvez garder le fichier source verrouillé, autoriser les fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

Le code Python suivant montre le chargement d’une grande présentation (par exemple, 2 Go) :

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

{{% alert color="info" title="Note" %}}
Avec PresentationLockingBehavior.KeepLocked, le fichier source reste verrouillé jusqu’à ce que l’instance de présentation soit libérée. Ne déplacez pas, n’écrasez pas et ne supprimez pas le fichier source tant que cette instance est en vie.

Aspose.Slides peut copier le contenu d’un flux d’entrée lors du chargement. Pour les grandes présentations, un chemin de fichier est donc généralement plus efficace qu’un flux. Consultez Manage BLOBs pour des options supplémentaires de stockage et de gestion de la mémoire.
{{% /alert %}}

## **Contrôler les ressources externes**

LoadOptions.setResourceLoadingCallback accepte un proxy JPype implémentant l’interface de rappel de chargement de ressources Java. Le rappel peut fournir des données de remplacement, rediriger une ressource, utiliser le chargeur par défaut ou ignorer la ressource. Ceci est utile lorsque les présentations contiennent des images externes qui doivent être résolues selon des règles de sécurité ou de stockage propres à l’application.

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

Une présentation peut contenir des données binaires intégrées dont une application n’a pas besoin ou ne souhaite pas conserver. Exemples :

- Projets VBA, accessibles via Presentation.getVbaProject ;
- données OLE intégrées, accessibles via OleEmbeddedDataInfo.getEmbeddedFileData ;
- données de contrôle ActiveX, accessibles via Control.getActiveXControlBinary.

Définissez LoadOptions.setDeleteEmbeddedBinaryObjects sur `True` pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée pour conserver le résultat désinfecté.

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

**Comment savoir si un fichier est corrompu et ne peut pas être ouvert ?**

Aspose.Slides lève une exception d’analyse ou de format lors du chargement. Gérez cet échec séparément d’une erreur de mot de passe incorrect afin que l’application puisse signaler la cause avec précision.

**Que se passe-t-il si les polices requises sont manquantes ?**

La présentation peut toujours être chargée, mais le rendu et l’exportation peuvent substituer les polices. Vous pouvez configurer la substitution de polices ou fournir des polices personnalisées pour rendre la sortie plus prévisible.

**Le chargement d’une présentation charge-t-il également ses médias intégrés ?**

L’audio et la vidéo intégrés deviennent accessibles via le modèle d’objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement de ressources configuré et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.