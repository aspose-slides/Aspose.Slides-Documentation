---
title: Gestionar proyectos VBA en presentaciones usando C++
linktitle: Presentación mediante VBA
type: docs
weight: 250
url: /es/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "Descubra cómo generar y manipular presentaciones PowerPoint y OpenDocument mediante VBA con Aspose.Slides para C++ y optimizar su flujo de trabajo."
---

El espacio de nombres [Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) contiene clases e interfaces para trabajar con macros y código VBA.

{{% alert title="Note" color="warning" %}} 
Cuando conviertes una presentación que contiene macros a un formato de archivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se trasladan al archivo resultante).

Cuando añades macros a una presentación o vuelves a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.
{{% /alert %}}

## **Agregar macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) para permitirte crear proyectos VBA (y referencias de proyecto) y editar módulos existentes. Puedes usar la interfaz [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) para gestionar VBA incrustado en una presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Usa el constructor de [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) para añadir un nuevo proyecto VBA.
1. Añade un módulo al VbaProject.
1. Establece el código fuente del módulo.
1. Añade referencias a <stdole>.
1. Añade referencias a **Microsoft Office**.
1. Asocia las referencias con el proyecto VBA.
1. Guarda la presentación.

Este código C++ muestra cómo añadir una macro VBA desde cero a una presentación: 
```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Crea una instancia de la clase Presentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Crea un nuevo proyecto VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Añade un módulo vacío al proyecto VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Establece el código fuente del módulo
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Crea una referencia a <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Crea una referencia a Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Añade referencias al proyecto VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Guarda la presentación
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


{{% alert color="primary" %}} 
Puede que quieras probar **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), una aplicación web gratuita que sirve para eliminar macros de documentos PowerPoint, Excel y Word. 
{{% /alert %}} 

## **Eliminar macros VBA**

Usando la propiedad [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) bajo la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), puedes eliminar una macro VBA.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación que contiene la macro.
1. Accede al módulo Macro y elimínalo.
1. Guarda la presentación modificada.

Este código C++ muestra cómo eliminar una macro VBA: 
```c++

// La ruta al directorio de documentos.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Carga la presentación que contiene la macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Accede al módulo Vba y lo elimina 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Guarda la presentación
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


## **Extraer macros VBA**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación que contiene la macro.
2. Verifica si la presentación contiene un proyecto VBA.
3. Recorre todos los módulos contenidos en el proyecto VBA para ver las macros.

Este código C++ muestra cómo extraer macros VBA de una presentación que contiene macros: 
```c++

	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/VBA.pptm";

	// Carga la presentación que contiene la macro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Comprueba si la Presentación contiene un proyecto VBA
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```


## **Comprobar si un proyecto VBA está protegido con contraseña**

Utilizando la propiedad [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/), puedes determinar si las propiedades de un proyecto están protegidas con contraseña.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y carga una presentación que contiene una macro.
2. Comprueba si la presentación contiene un [proyecto VBA](https://reference.aspose.com/slides/cpp/aspose.slides.vba/vbaproject/).
3. Verifica si el proyecto VBA está protegido con contraseña para ver sus propiedades.
```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Comprueba si la presentación contiene un proyecto VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```


## **Preguntas frecuentes**

**¿Qué ocurre con las macros si guardo la presentación como PPTX?**

Las macros se eliminarán porque PPTX no admite VBA. Para conservar las macros, elige PPTM, PPSM o POTM.

**¿Puede Aspose.Slides ejecutar macros dentro de una presentación para, por ejemplo, actualizar datos?**

No. La biblioteca nunca ejecuta código VBA; la ejecución solo es posible dentro de PowerPoint con la configuración de seguridad adecuada.

**¿Se admite trabajar con controles ActiveX vinculados a código VBA?**

Sí, puedes acceder a los [controles ActiveX](/slides/es/cpp/activex/) existentes, modificar sus propiedades y eliminarlos. Esto es útil cuando las macros interactúan con ActiveX.