---
title: MacroVBA
type: docs
weight: 150
url: /es/python-net/examples/elements/vba-macro/
keywords:
- macro VBA
- añadir macro VBA
- acceder a macro VBA
- eliminar macro VBA
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Trabaje con macros VBA en Python usando Aspose.Slides: añada o edite proyectos y módulos, firme o elimine macros, y guarde presentaciones en PPT, PPTX y ODP."
---
Ilustra cómo añadir, acceder y eliminar macros VBA usando **Aspose.Slides for Python via .NET**.

## **Añadir un macro VBA**

Crear una presentación con un proyecto VBA y un módulo de macro sencillo.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Inicializar un proyecto VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Añadir un módulo vacío llamado "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Acceder a un macro VBA**

Obtener el primer módulo del proyecto VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Eliminar un macro VBA**

Eliminar un módulo del proyecto VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Suponiendo que la presentación contiene un proyecto VBA y al menos un módulo.
        module = presentation.vba_project.modules[0]

        # Eliminar el módulo del proyecto.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```