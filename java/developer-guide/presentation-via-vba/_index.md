---
title: Presentation via VBA
type: docs
weight: 250
url: /java/presentation-via-vba/
---

## **Add VBA Macros to Presentation**
{{% alert color="primary" %}} 

Aspose.Slides for Java allows developers to manage VBA macros in a presentation. All you have to do is to add a VBA using the [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) interface associated with the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class using the [Presentation.getVbaProject()](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/presentation/methods/getVbaProject\(\)/) method.

{{% /alert %}} 

The [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class previous **getVbaProject()** method has been replaced. Now instead of the raw bytes of the [**getVbaProject()**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getVbaProject--) method representation of VBA project, the new [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) interface implementation has been added.
Use [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) to manage VBA embedded in a presentation. You can add new project references, edit existing modules and create new ones.
Also, you can create a new VBA project using the [VbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VbaProject) class which implements the [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) interface.
The following example shows how to create a simple VBA project. It contains one module and adds two required references to the libraries.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Add a new [VbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VbaProject) with the [Presentation.setVbaProject()](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/presentation/methods/setVbaProject\(com.aspose.slides.IVbaProject\)/) method.
1. Add a module to the [VbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VbaProject).
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the [VbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VbaProject).
1. Finally, write the PPTX file using the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.

The implementation of the above steps is demonstrated in the example below.

```java
// Instantiate Presentation
Presentation pres = new Presentation();
try {
    // Create new VBA Project
    pres.setVbaProject(new VbaProject());
    
    // Add empty module to the VBA project
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Set module source code
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Create reference to <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Create reference to Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Add references to the VBA project
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove VBA Macros from Presentation**
{{% alert color="primary" %}} 

Aspose.Slides for Java allows developers to remove VBA macros in a presentation. All you have to do is to add a VBA using the [IVbaProject](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IVbaProject) interface associated with the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class using the [Presentation.getVbaProject()](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/presentation/methods/getVbaProject\(\)/) method.

{{% /alert %}} 

The [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class now has included the support to remove the VBA macros inside presentation. The following example shows how to access and remove a VBA macro in presentation.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load presentation with Macro.
1. Access the Macro module and remove that
1. Finally, write the PPTX file using the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.

The implementation of the above steps is demonstrated in the example below.

```java
// Load Presentation
Presentation pres = new Presentation("VBA.pptm");
try {
    // Access the Vba module and remove
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Save Presentation
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extract VBA Macros**
Aspose.Slides for Java supports extracting VBA Macros from the slide. In order to extract VBA Macros, please follow the steps below:

- Load a [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) containing a VBA Macros
- Check if [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) contains VBA Project
- Loop through all the modules that are contained in the VBA Project

The implementation of the above steps is demonstrated in the example below.

```java
// Load Presentation
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // check if Presentation contains VBA Project
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


