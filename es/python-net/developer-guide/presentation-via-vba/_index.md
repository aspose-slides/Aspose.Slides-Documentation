---
title: Presentación a través de VBA
type: docs
weight: 250
url: /es/python-net/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, agregar macro, eliminar macro, agregar VBA, eliminar VBA, extraer macro, extraer VBA, macro de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar, eliminar y extraer macros VBA en presentaciones de PowerPoint en Python"
---

El espacio de nombres [Aspose.Slides.Vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) contiene clases e interfaces para trabajar con macros y código VBA.

{{% alert title="Nota" color="warning" %}} 

Cuando conviertes una presentación que contiene macros a un formato de archivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se transfieren al archivo resultante).

Cuando agregas macros a una presentación o vuelves a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes para las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.

{{% /alert %}}

## **Agregar Macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) para permitirte crear proyectos VBA (y referencias de proyecto) y editar módulos existentes. Puedes usar la interfaz [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) para gestionar VBA incrustado en una presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Usa el constructor de [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) para agregar un nuevo proyecto VBA.
1. Agrega un módulo al VbaProject.
1. Establece el código fuente del módulo.
1. Agrega referencias a <stdole>.
1. Agrega referencias a **Microsoft Office**.
1. Asocia las referencias con el proyecto VBA.
1. Guarda la presentación.

Este código Python te muestra cómo agregar una macro VBA desde cero a una presentación:

```python
import aspose.slides as slides

# Crea una instancia de la clase presentación
with slides.Presentation() as presentation:
    # Crea un nuevo proyecto VBA
    presentation.vba_project = slides.vba.VbaProject()

    # Agrega un módulo vacío al proyecto VBA
    module = presentation.vba_project.modules.add_empty_module("Module")
  
    # Establece el código fuente del módulo
    module.source_code = "Sub Test(oShape As Shape) MsgBox ""Test"" End Sub"

    # Crea una referencia a <stdole>
    stdoleReference = slides.vba.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Crea una referencia a Office
    officeReference =slides.vba.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Agrega referencias al proyecto VBA
    presentation.vba_project.references.add(stdoleReference)
    presentation.vba_project.references.add(officeReference)

            
    # Guarda la Presentación
    presentation.save("AddVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}} 

Puede que quieras probar **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), que es una aplicación web gratuita utilizada para eliminar macros de documentos de PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar Macros VBA**

Usando la propiedad [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#properties) bajo la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), puedes eliminar una macro VBA.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación que contiene la macro.
1. Accede al módulo de la macro y elimínalo.
1. Guarda la presentación modificada.

Este código Python te muestra cómo eliminar una macro VBA:

```python
import aspose.slides as slides

# Carga la presentación que contiene la macro
with slides.Presentation(path + "VBA.pptm") as presentation:
    # Accede al módulo Vba y lo elimina  
    presentation.vba_project.modules.remove(presentation.vba_project.modules[0])

    # guarda la Presentación
    presentation.save("RemovedVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Extraer Macros VBA**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación que contiene la macro.
2. Comprueba si la presentación contiene un proyecto VBA.
3. Recorre todos los módulos contenidos en el proyecto VBA para ver las macros.

Este código Python te muestra cómo extraer macros VBA de una presentación que contiene macros:

```python
import aspose.slides as slides

with slides.Presentation(path + "VBA.pptm") as pres:
    if pres.vba_project is not None: # Comprueba si la Presentación contiene un proyecto VBA
        for module in pres.vba_project.modules:
            print(module.name)
            print(module.source_code)
```