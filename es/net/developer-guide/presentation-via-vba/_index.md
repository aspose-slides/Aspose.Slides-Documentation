---
title: Presentación a través de VBA
type: docs
weight: 250
url: /es/net/presentation-via-vba/
keywords: "Macro, macros, VBA, macro de VBA, añadir macro, eliminar macro, añadir VBA, eliminar VBA, extraer macro, extraer VBA, macro de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Añadir, eliminar y extraer macros de VBA en presentaciones de PowerPoint en C# o .NET"
---

El espacio de nombres [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) contiene clases e interfaces para trabajar con macros y código VBA.

{{% alert title="Nota" color="warning" %}} 

Cuando conviertes una presentación que contiene macros a un formato de archivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se transfieren al archivo resultante).

Cuando agregas macros a una presentación o vuelves a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.

{{% /alert %}}

## **Añadir Macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) para permitirte crear proyectos de VBA (y referencias de proyectos) y editar módulos existentes. Puedes usar la interfaz [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) para gestionar el VBA embebido en una presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Usa el constructor de [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) para añadir un nuevo proyecto de VBA.
1. Añade un módulo al VbaProject.
1. Establece el código fuente del módulo.
1. Añade referencias a <stdole>.
1. Añade referencias a **Microsoft Office**.
1. Asocia las referencias con el proyecto de VBA.
1. Guarda la presentación.

Este código C# te muestra cómo añadir una macro de VBA desde cero a una presentación:

```c#
    // Crea una instancia de la clase de presentación
using (Presentation presentation = new Presentation())
{
    // Crea un nuevo proyecto de VBA
    presentation.VbaProject = new VbaProject();

    // Añade un módulo vacío al proyecto de VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Módulo");
  
    // Establece el código fuente del módulo
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Crea una referencia a <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Crea una referencia a Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Añade referencias al proyecto de VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Guarda la presentación
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Puede que quieras consultar **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), que es una aplicación web gratuita utilizada para eliminar macros de documentos de PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar Macros VBA**
Usando la propiedad [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) bajo la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), puedes eliminar una macro de VBA.

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y carga la presentación que contiene la macro.
1. Accede al módulo de la macro y elimínalo.
1. Guarda la presentación modificada.

Este código C# te muestra cómo eliminar una macro de VBA:

```c#
    // Carga la presentación que contiene la macro
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Accede al módulo de Vba y lo elimina 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Guarda la presentación
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Extraer Macros VBA**
1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y carga la presentación que contiene la macro.
2. Verifica si la presentación contiene un proyecto de VBA.
3. Recorre todos los módulos contenidos en el proyecto de VBA para ver las macros.

Este código C# te muestra cómo extraer macros VBA de una presentación que contiene macros:

```c#
    // Carga la presentación que contiene la macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Verifica si la presentación contiene un proyecto de VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Verificar si un Proyecto de VBA está Protegido con Contraseña**

Usando la propiedad [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), puedes verificar si las propiedades del proyecto están protegidas por contraseña.

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y carga la presentación que contiene la macro.
2. Verifica si la presentación contiene un [Proyecto de VBA](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/).
3. Verifica si el Proyecto de VBA está protegido con una contraseña para ver las propiedades del proyecto.

Este código C# demuestra la operación:

```c#
using (Presentation pres = new Presentation("VBA.pptm"))
{
    if (pres.VbaProject == null) // Verifica si la presentación contiene un proyecto de VBA
        return;

    if (pres.VbaProject.IsPasswordProtected)
    {
        Console.WriteLine("El Proyecto de VBA '" + pres.VbaProject.Name +
                            "' está protegido por contraseña para ver las propiedades del proyecto.");
    }
}
```