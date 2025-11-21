---
title: Presentación mediante VBA
type: docs
weight: 250
url: /es/net/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, agregar macro, eliminar macro, agregar VBA, eliminar VBA, extraer macro, extraer VBA, macro PowerPoint, presentación PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar, eliminar y extraer macros VBA en presentaciones de PowerPoint en C# o .NET"
---

El espacio de nombres [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) contiene clases e interfaces para trabajar con macros y código VBA.

{{% alert title="Note" color="warning" %}} 

Cuando conviertes una presentación que contiene macros a un formato de archivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se trasladan al archivo resultante).

Cuando añades macros a una presentación o vuelves a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.

{{% /alert %}}

## **Agregar macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) para permitirte crear proyectos VBA (y referencias de proyecto) y editar módulos existentes. Puedes usar la interfaz [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) para gestionar VBA incrustado en una presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Utiliza el constructor [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) para añadir un nuevo proyecto VBA.
1. Añade un módulo al VbaProject.
1. Establece el código fuente del módulo.
1. Añade referencias a <stdole>.
1. Añade referencias a **Microsoft Office**.
1. Asocia las referencias con el proyecto VBA.
1. Guarda la presentación.

Este código C# muestra cómo agregar una macro VBA desde cero a una presentación:
```c#
    // Crea una instancia de la clase presentation
    using (Presentation presentation = new Presentation())
    {
        // Crea un nuevo proyecto VBA
        presentation.VbaProject = new VbaProject();

        // Añade un módulo vacío al proyecto VBA
        IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
      
        // Establece el código fuente del módulo
        module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

        // Crea una referencia a <stdole>
        VbaReferenceOleTypeLib stdoleReference =
            new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

        // Crea una referencia a Office
        VbaReferenceOleTypeLib officeReference =
            new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

        // Añade referencias al proyecto VBA
        presentation.VbaProject.References.Add(stdoleReference);
        presentation.VbaProject.References.Add(officeReference);

                
        // Guarda la presentación
        presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
    }
```


{{% alert color="primary" %}} 

Puede que quieras echar un vistazo a **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), una aplicación web gratuita que sirve para eliminar macros de documentos PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar macros VBA**

Usando la propiedad [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) bajo la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), puedes eliminar una macro VBA.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y carga la presentación que contiene la macro.
1. Accede al módulo Macro y elimínalo.
1. Guarda la presentación modificada.

Este código C# muestra cómo eliminar una macro VBA:
```c#
    // Carga la presentación que contiene la macro
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Accede al módulo Vba y lo elimina
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Guarda la presentación
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Extraer macros VBA**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y carga la presentación que contiene la macro.
2. Comprueba si la presentación contiene un proyecto VBA.
3. Recorre todos los módulos contenidos en el proyecto VBA para ver las macros.

Este código C# muestra cómo extraer macros VBA de una presentación que contiene macros:
```c#
    // Carga la presentación que contiene la macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Comprueba si la presentación contiene un proyecto VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```


## **Comprobar si un proyecto VBA está protegido con contraseña**

Usando la propiedad [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), puedes determinar si las propiedades de un proyecto están protegidas con contraseña.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y carga una presentación que contiene una macro.
2. Comprueba si la presentación contiene un [proyecto VBA](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/).
3. Comprueba si el proyecto VBA está protegido con contraseña para ver sus propiedades.
```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Comprueba si la presentación contiene un proyecto VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```


## **FAQ**

**¿Qué ocurre con las macros si guardo la presentación como PPTX?**

Las macros se eliminarán porque PPTX no admite VBA. Para conservarlas, elige PPTM, PPSM o POTM.

**¿Puede Aspose.Slides ejecutar macros dentro de una presentación para, por ejemplo, actualizar datos?**

No. La biblioteca nunca ejecuta código VBA; la ejecución solo es posible dentro de PowerPoint con la configuración de seguridad adecuada.

**¿Se admite trabajar con controles ActiveX vinculados a código VBA?**

Sí, puedes acceder a los [controles ActiveX](/slides/es/net/activex/), modificar sus propiedades y eliminarlos. Esto es útil cuando las macros interactúan con ActiveX.