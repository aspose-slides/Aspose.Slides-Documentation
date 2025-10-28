---
title: Gérer les projets VBA dans les présentations avec Python
linktitle: Présentation via VBA
type: docs
weight: 250
url: /fr/python-net/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- ajouter macro
- supprimer macro
- extraire macro
- ajouter VBA
- supprimer VBA
- extraire VBA
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment générer et manipuler des présentations PowerPoint et OpenDocument via VBA avec Aspose.Slides for Python via .NET pour simplifier votre flux de travail."
---

## **Aperçu**

Cet article examine les principales capacités d’Aspose.Slides for Python via .NET pour travailler avec les macros dans les présentations PowerPoint. La bibliothèque fournit des outils pratiques pour ajouter, supprimer et extraire les macros, ce qui vous permet d’automatiser la création et la modification de présentations.

Avec Aspose.Slides, vous pouvez :

- Accélérer le développement de présentations — l’automatisation des tâches récurrentes réduit le temps nécessaire à la préparation du contenu.
- Garantir la flexibilité — la capacité de gérer les macros vous permet d’adapter les présentations à des tâches et scénarios spécifiques.
- Intégrer des données — une intégration simple avec des sources de données externes aide à maintenir le contenu des diapositives à jour.
- Simplifier la maintenance — une gestion centralisée des macros facilite l’application de modifications et la mise à jour des présentations.

L’article présente ensuite des exemples pratiques d’utilisation d’Aspose.Slides pour travailler efficacement avec les macros dans PowerPoint.

Le namespace [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) fournit des classes pour travailler avec les macros et le code VBA.

{{% alert title="Remarque" color="warning" %}}

Lorsque vous convertissez une présentation contenant des macros vers un autre format (PDF, HTML, etc.), Aspose.Slides ignore les macros — elles ne sont pas transférées dans le fichier de sortie.

Lorsque vous ajoutez des macros à une présentation ou que vous réenregistrez une présentation contenant des macros, Aspose.Slides écrit les octets de la macro tels quels.

Aspose.Slides **n’exécute jamais** les macros d’une présentation.

{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) pour créer des projets VBA (et des références de projet) et pour modifier les modules existants.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) pour ajouter un nouveau projet VBA.
3. Ajoutez un module au projet VBA.
4. Définissez le code source du module.
5. Ajoutez une référence à `<stdole>`.
6. Ajoutez une référence à **Microsoft Office**.
7. Associez les références au projet VBA.
8. Enregistrez la présentation.

Le code Python suivant montre comment ajouter une macro VBA à partir de zéro à une présentation :

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Create a new VBA project.
    presentation.vba_project = slides.vba.VbaProject()

    # Add an empty module to the VBA project.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Set the module source code.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Create a reference to <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Create a reference to Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Add the references to the VBA project.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Save the presentation.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

Vous pouvez essayer le **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), une application Web gratuite pour supprimer les macros de documents PowerPoint, Excel et Word.

{{% /alert %}}

## **Supprimer des macros VBA**

En utilisant la propriété [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant la macro.
2. Accédez au module de macro et supprimez‑le.
3. Enregistrez la présentation modifiée.

Le code Python suivant montre comment supprimer une macro VBA :

```python
import aspose.slides as slides

# Load the presentation that contains the macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Access the VBA module.
    vba_module = presentation.vba_project.modules[0]

    # Remove the VBA module.
    presentation.vba_project.modules.remove(vba_module)

    # Save the presentation.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Extraire des macros VBA**

En utilisant la propriété `modules` de la classe [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/), vous pouvez accéder à tous les modules d’un projet VBA. La classe [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) permet d’extraire les propriétés du module telles que le nom et le code.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules du projet VBA pour visualiser les macros.

Le code Python suivant montre comment extraire des macros VBA d’une présentation :

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Vérifier si un projet VBA est protégé par mot de passe**

En utilisant la propriété [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/), vous pouvez déterminer si les propriétés d’un projet sont protégées par mot de passe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez une présentation contenant une macro.
2. Vérifiez si la présentation contient un [projet VBA](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
3. Vérifiez si le projet VBA est protégé par mot de passe pour visualiser ses propriétés.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**Que se passe-t‑il des macros si j’enregistre la présentation au format PPTX ?**

Les macros seront supprimées car le format PPTX ne prend pas en charge VBA. Pour conserver les macros, choisissez PPTM, PPSM ou POTM.

**Aspose.Slides peut‑il exécuter des macros à l’intérieur d’une présentation pour, par exemple, actualiser des données ?**

Non. La bibliothèque n’exécute jamais le code VBA ; l’exécution n’est possible qu’à l’intérieur de PowerPoint avec les paramètres de sécurité appropriés.

**La prise en charge des contrôles ActiveX liés au code VBA est‑elle disponible ?**

Oui, vous pouvez accéder aux [contrôles ActiveX](/slides/fr/python-net/activex/) existants, modifier leurs propriétés et les supprimer. Ceci est utile lorsque les macros interagissent avec des contrôles ActiveX.