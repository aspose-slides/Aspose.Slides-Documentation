---
title: Gestionar proyectos VBA en presentaciones usando Python
linktitle: Presentación mediante VBA
type: docs
weight: 250
url: /es/python-java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Descubra cómo generar y manipular presentaciones PowerPoint y OpenDocument mediante VBA con Aspose.Slides para Python mediante Java para optimizar su flujo de trabajo."
---
## **Introducción**

Aspose.Slides proporciona clases e interfaces para trabajar con macros y código VBA.

{{% alert title="Warning" color="warning" %}} 

Al convertir una presentación que contiene macros a otro formato de archivo (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se transportan al archivo resultante).

Al añadir macros a una presentación o volver a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.

{{% /alert %}}

## **Añadir macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/es/python-java/aspose.slides/vbaproject/) para permitirle crear proyectos VBA (y referencias de proyectos) y editar módulos existentes. Puede usar la clase [VbaProject](https://reference.aspose.com/slides/es/python-java/aspose.slides/vbaproject/) para gestionar VBA incrustado en una presentación.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Utilizar el constructor de [VbaProject](https://reference.aspose.com/slides/es/python-java/aspose.slides/vbaproject/#vbaproject) para añadir un nuevo proyecto VBA.
1. Añadir un módulo al proyecto VBA.
1. Establecer el código fuente del módulo.
1. Añadir referencias a `stdole`.
1. Añadir referencias a **Microsoft Office**.
1. Asociar las referencias con el proyecto VBA.
1. Guardar la presentación.

Este código Python le muestra cómo añadir una macro VBA desde cero a una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Crear un nuevo proyecto VBA.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Añadir un módulo vacío y establecer su código fuente.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Crear referencias a stdole y Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Añadir referencias al proyecto VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Guardar la presentación.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Puede que desee probar el **Aspose** [Macro Remover](https://products.aspose.app/slides/es/remove-macros), una aplicación web gratuita que se usa para eliminar macros de documentos PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar macros VBA**

Usando el método [getVbaProject](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getvbaproject) de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/), puede eliminar una macro VBA.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargar la presentación que contiene la macro.
1. Acceder al módulo de la macro y eliminarlo.
1. Guardar la presentación modificada.

Este código Python le muestra cómo eliminar una macro VBA:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Cargar la presentación que contiene la macro.
presentation = Presentation("VBA.pptm")
try:
    # Acceder al módulo VBA y eliminarlo.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Guardar la presentación.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Extraer macros VBA**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargar la presentación que contiene la macro.
2. Comprobar si la presentación contiene un proyecto VBA.
3. Recorrer todos los módulos contenidos en el proyecto VBA para ver las macros.

Este código Python le muestra cómo extraer macros VBA de una presentación que contiene macros:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Cargar la presentación que contiene la macro.
presentation = Presentation("VBA.pptm")
try:
    # Comprobar si la presentación contiene un proyecto VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Comprobar si un proyecto VBA está protegido con contraseña**

Usando el método [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/es/python-java/aspose.slides/vbaproject/#ispasswordprotected), puede determinar si las propiedades de un proyecto están protegidas con contraseña.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargar una presentación que contiene una macro.
2. Comprobar si la presentación contiene un [VBA project](https://reference.aspose.com/slides/es/python-java/aspose.slides/vbaproject/).
3. Verificar si el proyecto VBA está protegido con contraseña para ver sus propiedades.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Comprobar si la presentación contiene un proyecto VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**¿Qué ocurre con las macros si guardo la presentación como PPTX?**

Las macros se eliminarán porque PPTX no admite VBA. Para conservar las macros, elija PPTM, PPSM o POTM.

**¿Puede Aspose.Slides ejecutar macros dentro de una presentación para, por ejemplo, actualizar datos?**

No. La biblioteca nunca ejecuta código VBA; la ejecución solo es posible dentro de PowerPoint con la configuración de seguridad adecuada.

**¿Se admite trabajar con controles ActiveX vinculados a código VBA?**

Sí, puede acceder a los [ActiveX controls](/slides/es/python-java/activex/), modificar sus propiedades y eliminarlos. Esto es útil cuando las macros interactúan con ActiveX.