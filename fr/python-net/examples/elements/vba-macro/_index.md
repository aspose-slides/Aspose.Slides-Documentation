---
title: Macro VBA
type: docs
weight: 150
url: /fr/python-net/examples/elements/vba-macro/
keywords:
- macro VBA
- ajouter macro VBA
- accéder macro VBA
- supprimer macro VBA
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Travaillez avec les macros VBA en Python à l'aide d'Aspose.Slides : ajoutez ou modifiez des projets et des modules, signez ou supprimez des macros, et enregistrez les présentations au format PPT, PPTX et ODP."
---
Illustre comment ajouter, accéder et supprimer des macros VBA en utilisant **Aspose.Slides for Python via .NET**.

## **Ajouter une macro VBA**

Créez une présentation avec un projet VBA et un module macro simple.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Initialise un projet VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Ajoute un module vide nommé "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Accéder à une macro VBA**

Récupérez le premier module du projet VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Supprimer une macro VBA**

Supprimez un module du projet VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # En supposant que la présentation contient un projet VBA et au moins un module.
        module = presentation.vba_project.modules[0]

        # Supprimez le module du projet.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```