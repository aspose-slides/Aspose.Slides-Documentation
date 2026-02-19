---
title: VbaMacro
type: docs
weight: 150
url: /php-java/examples/elements/vba-macro/
keywords:
- vba macro
- add vba macro
- access vba macro
- remove vba macro
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Work with VBA macros in PHP using Aspose.Slides: add or edit projects and modules, sign or remove macros, and save presentations in PPT, PPTX and ODP."
---

Illustrates how to add, access, and remove VBA macros using **Aspose.Slides for PHP via Java**.

## **Add a VBA Macro**

Create a presentation with a VBA project and a simple macro module.

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a VBA Macro**

Retrieve the first module from the VBA project.

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a VBA Macro**

Delete a module from the VBA project.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Assuming there is at least one module in the VBA project.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```
