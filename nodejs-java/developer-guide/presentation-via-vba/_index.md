---
title: Presentation via VBA
type: docs
weight: 250
url: /nodejs-java/presentation-via-vba/
keywords: "Macro, macros, VBA, VBA macro, add macro, remove macro, add VBA, remove VBA, extract macro, extract VBA, PowerPoint macro, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Add, remove, and extract VBA macros in PowerPoint presentations in Javascript"
---

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#VbaProject--) constructor to add a new VBA project.
1. Add a module to the VbaProject.
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

This Javascript code shows you how to add a VBA macro from scratch to a presentation:

```javascript
    // Creates an instance of the presentation class
    var pres = new  aspose.slides.Presentation();
    try {
        // Creates a new VBA Project
        pres.setVbaProject(new  aspose.slides.VbaProject());
        // Adds an empty module to the VBA project
        var module = pres.getVbaProject().getModules().addEmptyModule("Module");
        // Sets the module source code
        module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
        // Creates a reference to <stdole>
        var stdoleReference = new  aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
        // Creates a reference to Office
        var officeReference = new  aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
        // Adds references to the VBA project
        pres.getVbaProject().getReferences().add(stdoleReference);
        pres.getVbaProject().getReferences().add(officeReference);
        // Saves the Presentation
        pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**

Using the [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject--) property under the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

This Javascript code shows you how to remove a VBA macro:

```javascript
    // Loads the presentation containing the macro
    var pres = new  aspose.slides.Presentation("VBA.pptm");
    try {
        // Accesses the Vba module and removes it
        pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
        // Saves the Presentation
        pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Extract VBA Macros**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This Javascript code shows you how to extract VBA macros from a presentation containing macros:

```javascript
    // Loads the presentation containing the macro
    var pres = new  aspose.slides.Presentation("VBA.pptm");
    try {
        // Checks whether the Presentation contains a VBA Project
        if (pres.getVbaProject() != null) {
            pres.getVbaProject().getModules().forEach(function(module) {
                console.log(module.getName());
                console.log(module.getSourceCode());
            });
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

