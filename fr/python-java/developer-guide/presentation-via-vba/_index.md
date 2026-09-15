---
title: Gérer les projets VBA dans les présentations avec Python
linktitle: Présentation via VBA
type: docs
weight: 250
url: /fr/python-java/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- ajouter une macro
- supprimer une macro
- extraire une macro
- ajouter VBA
- supprimer VBA
- extraire VBA
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez comment générer et manipuler des présentations PowerPoint et OpenDocument via VBA avec Aspose.Slides pour Python via Java afin d'optimiser votre flux de travail."
---
## **Introduction**

Aspose.Slides fournit des classes et des interfaces pour travailler avec les macros et le code VBA.

{{% alert title="Avertissement" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros vers un autre format de fichier (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas transférées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou que vous réenregistrez une présentation contenant des macros, Aspose.Slides écrit simplement les octets des macros.

Aspose.Slides **n'exécute jamais** les macros d’une présentation.

{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/fr/python-java/aspose.slides/vbaproject/) qui vous permet de créer des projets VBA (et des références de projets) et de modifier des modules existants. Vous pouvez utiliser la classe [VbaProject](https://reference.aspose.com/slides/fr/python-java/aspose.slides/vbaproject/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Utilisez le constructeur de la [VbaProject](https://reference.aspose.com/slides/fr/python-java/aspose.slides/vbaproject/#vbaproject) pour ajouter un nouveau projet VBA.
3. Ajoutez un module au projet VBA.
4. Définissez le code source du module.
5. Ajoutez des références à `stdole`.
6. Ajoutez des références à **Microsoft Office**.
7. Associez les références au projet VBA.
8. Enregistrez la présentation.

Ce code Python montre comment ajouter une macro VBA à partir de zéro à une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Créer un nouveau projet VBA.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Ajouter un module vide et définir son code source.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Créer des références à stdole et Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Ajouter des références au projet VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Enregistrer la présentation.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Vous pouvez essayer le **Macro Remover** d’Aspose : [https://products.aspose.app/slides/fr/remove-macros](https://products.aspose.app/slides/fr/remove-macros), une application Web gratuite permettant de supprimer les macros des documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer des macros VBA**

En utilisant la méthode [getVbaProject](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getvbaproject) de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant la macro.
2. Accédez au module de macro et supprimez‑le.
3. Enregistrez la présentation modifiée.

Ce code Python montre comment supprimer une macro VBA :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Charger la présentation contenant la macro.
presentation = Presentation("VBA.pptm")
try:
    # Accéder au module VBA et le supprimer.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Enregistrer la présentation.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Extraire des macros VBA**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules du projet VBA pour visualiser les macros.

Ce code Python montre comment extraire des macros VBA d’une présentation contenant des macros :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Charger la présentation contenant la macro.
presentation = Presentation("VBA.pptm")
try:
    # Vérifier si la présentation contient un projet VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Vérifier si un projet VBA est protégé par mot de passe**

En utilisant la méthode [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/fr/python-java/aspose.slides/vbaproject/#ispasswordprotected), vous pouvez déterminer si les propriétés d’un projet sont protégées par mot de passe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez une présentation contenant une macro.
2. Vérifiez si la présentation contient un [projet VBA](https://reference.aspose.com/slides/fr/python-java/aspose.slides/vbaproject/).
3. Vérifiez si le projet VBA est protégé par mot de passe pour visualiser ses propriétés.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Vérifier si la présentation contient un projet VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**Que se passe-t-il avec les macros si j’enregistre la présentation au format PPTX ?**

Les macros sont supprimées car le format PPTX ne prend pas en charge VBA. Pour conserver les macros, choisissez PPTM, PPSM ou POTM.

**Aspose.Slides peut‑il exécuter des macros dans une présentation pour, par exemple, actualiser des données ?**

Non. La bibliothèque n’exécute jamais de code VBA ; l’exécution n’est possible qu’à l’intérieur de PowerPoint avec les paramètres de sécurité appropriés.

**La prise en charge des contrôles ActiveX liés au code VBA est‑elle disponible ?**

Oui, vous pouvez accéder aux [contrôles ActiveX](/slides/fr/python-java/activex/), modifier leurs propriétés et les supprimer. Ceci est utile lorsque les macros interagissent avec des contrôles ActiveX.