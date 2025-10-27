---
title: Gestionar proyectos VBA en presentaciones con Python
linktitle: Presentación vía VBA
type: docs
weight: 250
url: /es/python-net/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- añadir macro
- eliminar macro
- extraer macro
- añadir VBA
- eliminar VBA
- extraer VBA
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo generar y manipular presentaciones PowerPoint y OpenDocument mediante VBA con Aspose.Slides para Python vía .NET para optimizar su flujo de trabajo."
---

## **Descripción general**

Este artículo examina las principales capacidades de Aspose.Slides para Python vía .NET para trabajar con macros en presentaciones de PowerPoint. La biblioteca ofrece herramientas convenientes para añadir, eliminar y extraer macros, lo que le permite automatizar la creación y modificación de presentaciones.

Con Aspose.Slides, usted puede:

- Acelerar el desarrollo de presentaciones: la automatización de tareas rutinarias reduce el tiempo necesario para preparar el material.
- Garantizar flexibilidad: la capacidad de gestionar macros le permite adaptar las presentaciones a tareas y escenarios específicos.
- Integrar datos: la sencilla integración con fuentes de datos externas ayuda a mantener el contenido de las diapositivas actualizado.
- Simplificar el mantenimiento: la gestión centralizada de macros facilita la aplicación de cambios y la actualización de presentaciones.

El artículo continúa presentando ejemplos prácticos de cómo usar Aspose.Slides para trabajar eficazmente con macros en PowerPoint.

El espacio de nombres [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) proporciona clases para trabajar con macros y código VBA.

{{% alert title="Nota" color="warning" %}}

Cuando convierte una presentación que contiene macros a otro formato (PDF, HTML, etc.), Aspose.Slides ignora las macros; no se transfieren al archivo de salida.

Cuando añade macros a una presentación o vuelve a guardar una presentación que contiene macros, Aspose.Slides escribe los bytes de la macro tal cual.

Aspose.Slides **nunca** ejecuta macros en una presentación.

{{% /alert %}}

## **Añadir macros VBA**

Aspose.Slides ofrece la clase [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) para crear proyectos VBA (y referencias de proyecto) y para editar módulos existentes.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Utilizar el constructor de [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) para añadir un nuevo proyecto VBA.
3. Añadir un módulo al proyecto VBA.
4. Establecer el código fuente del módulo.
5. Añadir una referencia a `<stdole>`.
6. Añadir una referencia a **Microsoft Office**.
7. Asociar las referencias con el proyecto VBA.
8. Guardar la presentación.

El siguiente código Python muestra cómo añadir una macro VBA desde cero a una presentación:

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

Puede probar el **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), una aplicación web gratuita para eliminar macros de documentos PowerPoint, Excel y Word.

{{% /alert %}}

## **Eliminar macros VBA**

Utilizando la propiedad [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), puede eliminar una macro VBA.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargar la presentación que contiene la macro.
2. Acceder al módulo de la macro y eliminarlo.
3. Guardar la presentación modificada.

El siguiente código Python muestra cómo eliminar una macro VBA:

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

## **Extraer macros VBA**

Usando la propiedad `modules` de la clase [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/), puede acceder a todos los módulos de un proyecto VBA. La clase [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) permite extraer propiedades del módulo como el nombre y el código.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargar la presentación que contiene la macro.
2. Verificar si la presentación contiene un proyecto VBA.
3. Recorrer todos los módulos del proyecto VBA para ver las macros.

El siguiente código Python muestra cómo extraer macros VBA de una presentación:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Comprobar si un proyecto VBA está protegido por contraseña**

Usando la propiedad [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/), puede determinar si las propiedades de un proyecto están protegidas con contraseña.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargar una presentación que contenga una macro.
2. Verificar si la presentación contiene un [proyecto VBA](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
3. Comprobar si el proyecto VBA está protegido con contraseña para ver sus propiedades.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **Preguntas frecuentes**

**¿Qué ocurre con las macros si guardo la presentación como PPTX?**

Las macros se eliminan porque PPTX no admite VBA. Para conservar las macros, elija PPTM, PPSM o POTM.

**¿Puede Aspose.Slides ejecutar macros dentro de una presentación para, por ejemplo, actualizar datos?**

No. La biblioteca nunca ejecuta código VBA; la ejecución solo es posible dentro de PowerPoint con la configuración de seguridad adecuada.

**¿Se admite trabajar con controles ActiveX vinculados a código VBA?**

Sí, puede acceder a los [controles ActiveX](/slides/es/python-net/activex/) existentes, modificar sus propiedades y eliminarlos. Esto es útil cuando las macros interactúan con ActiveX.