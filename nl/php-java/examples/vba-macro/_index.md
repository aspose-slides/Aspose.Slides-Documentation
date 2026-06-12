---
title: VbaMacro
type: docs
weight: 150
url: /nl/php-java/examples/elements/vba-macro/
keywords:
- vba macro
- vba macro toevoegen
- vba macro openen
- vba macro verwijderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Werk met VBA-macro’s in PHP met behulp van Aspose.Slides: voeg projecten en modules toe of bewerk ze, onderteken of verwijder macro’s, en sla presentaties op in PPT, PPTX en ODP."
---
Toont hoe u VBA‑macro’s kunt toevoegen, openen en verwijderen met **Aspose.Slides for PHP via Java**.

## **Voeg een VBA-macro toe**

Maak een presentatie met een VBA‑project en een eenvoudige macro‑module.

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

## **Open een VBA-macro**

Haal de eerste module op uit het VBA‑project.

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

## **Verwijder een VBA-macro**

Verwijder een module uit het VBA‑project.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Aangenomen dat er ten minste één module in het VBA‑project zit.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```