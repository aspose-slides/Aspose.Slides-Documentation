---
title: Presentation via VBA
type: docs
weight: 250
url: /net/presentation-via-vba/
keywords: "Macro, macros, VBA, VBA macro, add macro, remove macro, add VBA, remove VBA, extract macro, extract VBA, PowerPoint macro, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add, remove, and extract VBA macros in PowerPoint presentations in C# or .NET"
---

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

Aspose.Slides never runs the macros in a presentation. Additionally, in an operation where a PowerPoint presentation is converted to another file, Aspose.Slides ignores all macros (macros are not carried into the resulting file).

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) constructor to add a new VBA project.
1. Add a module to the VbaProject.
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

This C# code shows you how to add a VBA macro from scratch to a presentation:

```c#
    // Creates an instance of the presentation class
using (Presentation presentation = new Presentation())
{
    // Creates a new VBA Project
    presentation.VbaProject = new VbaProject();

    // Adds an empty module to the VBA project
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Sets the module source code
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Creates a reference to <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Creates a reference to Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Adds references to the VBA project
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Saves the Presentation
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**
Using the [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) property under the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

This C# code shows you how to remove a VBA macro:

```c#
    // Loads the presentation containing the macro
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Accesses the Vba module and removes it 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Saves the Presentation
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Extract VBA Macros**
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This C# code shows you how to extract VBA macros from a presentation containing macros:

```c#
    // Loads the presentation containing the macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Checks whether the Presentation contains a VBA Project
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```
