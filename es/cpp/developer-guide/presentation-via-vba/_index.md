---
title: Presentación a través de VBA
type: docs
weight: 250
url: /cpp/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, agregar macro, eliminar macro, agregar VBA, eliminar VBA, extraer macro, extraer VBA, macro de PowerPoint, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Agregar, eliminar y extraer macros VBA en presentaciones de PowerPoint en C++"
---

El espacio de nombres [Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) contiene clases e interfaces para trabajar con macros y código VBA.

{{% alert title="Nota" color="warning" %}} 

Cuando conviertes una presentación que contiene macros a otro formato de archivo (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se transfieren al archivo resultante).

Cuando agregas macros a una presentación o vuelves a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.

{{% /alert %}}

## **Agregar Macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) para permitirte crear proyectos VBA (y referencias a proyectos) y editar módulos existentes. Puedes usar la interfaz [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) para administrar VBA incrustado en una presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Usa el constructor de [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) para agregar un nuevo proyecto VBA.
1. Agrega un módulo al VbaProject.
1. Establece el código fuente del módulo.
1. Agrega referencias a <stdole>.
1. Agrega referencias a **Microsoft Office**.
1. Asocia las referencias con el proyecto VBA.
1. Guarda la presentación.

Este código C++ te muestra cómo agregar una macro VBA desde cero a una presentación: 

```c++

// La ruta al directorio de documentos.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Crea una instancia de la clase de presentación
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Crea un nuevo Proyecto VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Agrega un módulo vacío al proyecto VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Establece el código fuente del módulo
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Crea una referencia a <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Crea una referencia a Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Agrega referencias al proyecto VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Guarda la Presentación
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);

```

{{% alert color="primary" %}} 

Es posible que desees consultar **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), que es una aplicación web gratuita utilizada para eliminar macros de documentos de PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar Macros VBA**

Usando la propiedad [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), puedes eliminar una macro VBA.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación que contiene la macro.
1. Accede al módulo Macro y elimínalo.
1. Guarda la presentación modificada.

Este código C++ te muestra cómo eliminar una macro VBA: 

```c++

// La ruta al directorio de documentos.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Carga la presentación que contiene la macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Accede al módulo Vba y elimínalo 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Guarda la Presentación
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);

```

## **Extraer Macros VBA**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) y carga la presentación que contiene la macro.
2. Verifica si la presentación contiene un Proyecto VBA.
3. Recorre todos los módulos contenidos en el Proyecto VBA para ver las macros.

Este código C++ te muestra cómo extraer macros VBA de una presentación que contiene macros: 

```c++

	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/VBA.pptm";

	// Carga la presentación que contiene la macro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Verifica si la Presentación contiene un Proyecto VBA
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