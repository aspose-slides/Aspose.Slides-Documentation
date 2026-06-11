---
title: VbaMakro
type: docs
weight: 150
url: /sv/php-java/examples/elements/vba-macro/
keywords:
- vba-makro
- lägg till vba-makro
- åtkomst till vba-makro
- ta bort vba-makro
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Arbeta med VBA-makron i PHP med Aspose.Slides: lägg till eller redigera projekt och moduler, signera eller ta bort makron, och spara presentationer i PPT, PPTX och ODP."
---
Illustrerar hur du lägger till, får åtkomst till och tar bort VBA-makron med **Aspose.Slides for PHP via Java**.

## **Lägg till ett VBA-makro**

Skapa en presentation med ett VBA-projekt och en enkel makromodul.

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

## **Få åtkomst till ett VBA-makro**

Hämta den första modulen från VBA-projektet.

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

## **Ta bort ett VBA-makro**

Ta bort en modul från VBA-projektet.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Antag att det finns minst en modul i VBA-projektet.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```