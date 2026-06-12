---
title: VbaMakro
type: docs
weight: 150
url: /cs/php-java/examples/elements/vba-macro/
keywords:
- vba makro
- přidat vba makro
- přístup k vba makru
- odstranit vba makro
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Pracujte s makry VBA v PHP pomocí Aspose.Slides: přidávejte nebo upravujte projekty a moduly, podepisujte nebo odstraňujte makra a ukládejte prezentace ve formátech PPT, PPTX a ODP."
---
Ukazuje, jak přidávat, přistupovat k a odstraňovat makra VBA pomocí **Aspose.Slides for PHP via Java**.

## **Přidat makro VBA**

Vytvořte prezentaci s projektem VBA a jednoduchým modulem makra.

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

## **Přístup k VBA makru**

Získejte první modul z projektu VBA.

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

## **Odstranit makro VBA**

Odstraňte modul z projektu VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Předpokládá se, že ve VBA projektu je alespoň jeden modul.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```