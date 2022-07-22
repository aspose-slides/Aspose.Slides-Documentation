---
title: Presentation via VBA
type: docs
weight: 250
url: /net/presentation-via-vba/
keywords: "Macro, macros, VBA, VBA macro, add macro, remove macro, add VBA, remove VBA, extract macro, extract VBA, PowerPoint macro, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add, remove, and extract VBA macros in PowerPoint presentations in C# or .NET"
---

## **Add VBA Macros**
The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class previous [VbaProject](http://www.aspose.com/api/net/slides/aspose.slides.vba/vbaproject) property has been replaced. Now instead of the raw bytes of the [VbaProject](http://www.aspose.com/api/net/slides/aspose.slides.vba/vbaproject) property representation of VBA project, the new **IVbaProject** interface implementation has been added. Use **IVbaProject** to manage VBA embedded in a presentation. You can add new project references, edit existing modules and create new ones. Also, you can create a new VBA project using the **VbaProject** class which implements the **VbaProject** interface. The following example shows how to create a simple VBA project. It contains one module and adds two required references to the libraries.

1. Create an instance of the `Presentation` class.
1. Add a new VbaProject with the **Presentation.VbaProject** property.
1. Add a module to the [VbaProject](http://www.aspose.com/api/net/slides/aspose.slides.vba/vbaproject).
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the **VbaProject**.
1. Finally, write the PPTX file using the `Presentation` object.

The implementation of the above steps is demonstrated in the example below.

```c#
// Instantiate Presentation
using (Presentation presentation = new Presentation())
{
    // Create new VBA Project
    presentation.VbaProject = new VbaProject();

    // Add empty module to the VBA project
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Set module source code
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Create reference to <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Create reference to Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Add references to the VBA project
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Save Presentation
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**
The `Presentation` class now has included the support to remove the VBA macros inside presentation. The following example shows how to access and remove a VBA macro in presentation.

1. Create an instance of the `Presentation` class and load presentation with Macro.
1. Access the Macro module and remove that
1. Finally, write the PPTX file using the `Presentation` class object.

The implementation of the above steps is demonstrated in the example below.

```c#
// Instantiate Presentation
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Access the Vba module and remove 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Save Presentation
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Extract VBA Macros**
Aspose.Slides for .NET supports extracting VBA Macros from the slide. In order to extract VBA Macros, please follow the steps below:

- Load a Presentation containing a VBA Macros
- Check if Presentation contains VBA Project
- Loop through all the modules that are contained in the VBA Project

The implementation of the above steps is demonstrated in the example below.

```c#
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // check if Presentation contains VBA Project
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

