---
title: Présentation via VBA
type: docs
weight: 250
url: /python-net/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, ajouter macro, supprimer macro, ajouter VBA, supprimer VBA, extraire macro, extraire VBA, macro PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter, supprimer et extraire des macros VBA dans des présentations PowerPoint en Python"
---

L'espace de noms [Aspose.Slides.Vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) contient des classes et des interfaces pour travailler avec des macros et du code VBA.

{{% alert title="Note" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros dans un autre format de fichier (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas transférées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou que vous enregistrez à nouveau une présentation contenant des macros, Aspose.Slides écrit simplement les octets pour les macros.

Aspose.Slides **n'exécute **jamais** les macros d'une présentation.

{{% /alert %}}

## **Ajouter des Macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) pour vous permettre de créer des projets VBA (et des références de projet) et d'éditer des modules existants. Vous pouvez utiliser l'interface [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) pour ajouter un nouveau projet VBA.
1. Ajoutez un module au VbaProject.
1. Définissez le code source du module.
1. Ajoutez des références à <stdole>.
1. Ajoutez des références à **Microsoft Office**.
1. Associez les références au projet VBA.
1. Enregistrez la présentation.

Ce code Python montre comment ajouter une macro VBA à partir de zéro à une présentation :

```python
import aspose.slides as slides

# Crée une instance de la classe de présentation
with slides.Presentation() as presentation:
    # Crée un nouveau projet VBA
    presentation.vba_project = slides.vba.VbaProject()

    # Ajoute un module vide au projet VBA
    module = presentation.vba_project.modules.add_empty_module("Module")
  
    # Définit le code source du module
    module.source_code = "Sub Test(oShape As Shape) MsgBox ""Test"" End Sub"

    # Crée une référence à <stdole>
    stdoleReference = slides.vba.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Crée une référence à Office
    officeReference =slides.vba.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Ajoute des références au projet VBA
    presentation.vba_project.references.add(stdoleReference)
    presentation.vba_project.references.add(officeReference)

            
    # Enregistre la Présentation
    presentation.save("AddVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}} 

Vous voudrez peut-être découvrir **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), qui est une application web gratuite utilisée pour supprimer des macros de documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer des Macros VBA**

En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#properties) sous la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant la macro.
1. Accédez au module Macro et supprimez-le.
1. Enregistrez la présentation modifiée.

Ce code Python montre comment supprimer une macro VBA :

```python
import aspose.slides as slides

# Charge la présentation contenant la macro
with slides.Presentation(path + "VBA.pptm") as presentation:
    # Accède au module Vba et le supprime  
    presentation.vba_project.modules.remove(presentation.vba_project.modules[0])

    # Enregistre la Présentation
    presentation.save("RemovedVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Extraire des Macros VBA**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules contenus dans le projet VBA pour voir les macros.

Ce code Python montre comment extraire des macros VBA d'une présentation contenant des macros :

```python
import aspose.slides as slides

with slides.Presentation(path + "VBA.pptm") as pres:
    if pres.vba_project is not None: # Vérifie si la Présentation contient un projet VBA
        for module in pres.vba_project.modules:
            print(module.name)
            print(module.source_code)
```