---
title: Manage VBA Projects in Presentations Using PHP
linktitle: Presentation via VBA
type: docs
weight: 250
url: /php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "Discover how to generate and manipulate PowerPoint and OpenDocument presentations via VBA with Aspose.Slides for PHP via Java to streamline your workflow."
---

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the `VbaProject` class to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject) constructor to add a new VBA project.
1. Add a module to the VbaProject.
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

This PHP code shows you how to add a VBA macro from scratch to a presentation:

```php
  # Creates an instance of the presentation class
  $pres = new Presentation();
  try {
    # Creates a new VBA Project
    $pres->setVbaProject(new VbaProject());
    # Adds an empty module to the VBA project
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Sets the module source code
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Creates a reference to <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Creates a reference to Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Adds references to the VBA project
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Saves the Presentation
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**

Using the [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject) property under the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

This PHP code shows you how to remove a VBA macro:

```php
  # Loads the presentation containing the macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Accesses the Vba module and removes it
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Saves the Presentation
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extract VBA Macros**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This PHP code shows you how to extract VBA macros from a presentation containing macros:

```php
  # Loads the presentation containing the macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Checks whether the Presentation contains a VBA Project
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Check Whether a VBA Project Is Password-Protected**

Using the [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected) method, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class and load a presentation that contains a macro.
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/).
3. Check whether the VBA project is password-protected to view its properties.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Check whether the presentation contains a VBA project.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**What happens to macros if I save the presentation as PPTX?**

Macros will be removed because PPTX does not support VBA. To keep macros, choose PPTM, PPSM, or POTM.

**Can Aspose.Slides run macros inside a presentation to, for example, refresh data?**

No. The library never executes VBA code; execution is only possible inside PowerPoint with the appropriate security settings.

**Is working with ActiveX controls linked to VBA code supported?**

Yes, you can access existing [ActiveX controls](/slides/php-java/activex/), modify their properties, and remove them. This is useful when macros interact with ActiveX.
