---
title: MacroVBA
type: docs
weight: 150
url: /es/php-java/examples/elements/vba-macro/
keywords:
- macro vba
- agregar macro vba
- acceder macro vba
- eliminar macro vba
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Trabaje con macros VBA en PHP usando Aspose.Slides: añada o edite proyectos y módulos, firme o elimine macros, y guarde presentaciones en PPT, PPTX y ODP."
---
Ilustra cómo agregar, acceder y eliminar macros VBA utilizando **Aspose.Slides for PHP via Java**.

## **Agregar una macro VBA**

Cree una presentación con un proyecto VBA y un módulo de macro simple.

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

## **Acceder a una macro VBA**

Recupere el primer módulo del proyecto VBA.

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

## **Eliminar una macro VBA**

Elimine un módulo del proyecto VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Suponiendo que hay al menos un módulo en el proyecto VBA.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```