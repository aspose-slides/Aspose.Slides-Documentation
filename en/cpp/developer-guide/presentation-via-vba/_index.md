---
title: Manage VBA Projects in Presentations Using C++
linktitle: Presentation via VBA
type: docs
weight: 250
url: /cpp/presentation-via-vba/
keywords:
- macro
- VBA
- VBA macro
- add macro
- remove macro
- extract macro
- add VBA
- remove VBA
- extract VBA
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Discover how to generate and manipulate PowerPoint and OpenDocument presentations via VBA with Aspose.Slides for C++ to streamline your workflow."
---

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) constructor to add a new VBA project.
1. Add a module to the VbaProject.
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

This C++ code shows you how to add a VBA macro from scratch to a presentation: 

```c++

// The path to the documents directory.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Creates an instance of the presentation class
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Creates a new VBA Project
presentation->set_VbaProject(MakeObject<VbaProject>());

// Adds an empty module to the VBA project
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Sets the module source code
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Creates a reference to <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Creates a reference to Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Adds references to the VBA project
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Saves the Presentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);


```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**

Using the [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) property under the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

This C++ code shows you how to remove a VBA macro: 

```c++

// The path to the documents directory.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Loads the presentation containing the macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Accesses the Vba module and removes it 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Saves the Presentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);


```

## **Extract VBA Macros**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This C++ code shows you how to extract VBA macros from a presentation containing macros: 

```c++

	// The path to the documents directory.
	const String templatePath = u"../templates/VBA.pptm";

	// Loads the presentation containing the macro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Checks whether the Presentation contains a VBA Project
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

## **Check Whether a VBA Project Is Password-Protected**

Using the [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class and load a presentation that contains a macro.
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/cpp/aspose.slides.vba/vbaproject/).
3. Check whether the VBA project is password-protected to view its properties.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Check whether the presentation contains a VBA project.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```
