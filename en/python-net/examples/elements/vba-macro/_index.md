---
title: VbaMacro
type: docs
weight: 150
url: /python-net/examples/elements/vba-macro/
keywords:
- VBA macro
- add VBA macro
- access VBA macro
- remove VBA macro
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Work with VBA macros in Python using Aspose.Slides: add or edit projects and modules, sign or remove macros, and save presentations in PPT, PPTX and ODP."
---

Illustrates how to add, access, and remove VBA macros using **Aspose.Slides for Python via .NET**.

## **Add a VBA Macro**

Create a presentation with a VBA project and a simple macro module.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Initialize a VBA project.
        presentation.vba_project = slides.vba.VbaProject()

        # Add an empty module named "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Access a VBA Macro**

Retrieve the first module from the VBA project.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Remove a VBA Macro**

Delete a module from the VBA project.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Assuming the presentation contains a VBA project and at least one module.
        module = presentation.vba_project.modules[0]

        # Remove the module from the project.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```
