---
title: Makro VBA
type: docs
weight: 150
url: /pl/php-java/examples/elements/vba-macro/
keywords:
- makro VBA
- dodaj makro VBA
- dostęp do makra VBA
- usuń makro VBA
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Pracuj z makrami VBA w PHP przy użyciu Aspose.Slides: dodawaj lub edytuj projekty i moduły, podpisuj lub usuwaj makra oraz zapisuj prezentacje w formatach PPT, PPTX i ODP."
---
Ilustruje, jak dodawać, uzyskiwać dostęp i usuwać makra VBA przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj makro VBA**

Utwórz prezentację z projektem VBA i prostym modułem makr.

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

## **Uzyskaj dostęp do makra VBA**

Pobierz pierwszy moduł z projektu VBA.

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

## **Usuń makro VBA**

Usuń moduł z projektu VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Zakładając, że w projekcie VBA jest co najmniej jeden moduł.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```