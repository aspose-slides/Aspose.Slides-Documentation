---
title: VbaMakró
type: docs
weight: 150
url: /hu/php-java/examples/elements/vba-macro/
keywords:
- vba makró
- vba makró hozzáadása
- vba makró elérése
- vba makró eltávolítása
- kódrészletek
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Dolgozzon VBA makrókkal PHP-ben az Aspose.Slides használatával: adjon hozzá vagy szerkesszen projekteket és modulokat, írja alá vagy távolítsa el a makrókat, és mentse a prezentációkat PPT, PPTX és ODP formátumban."
---
Bemutatja, hogyan lehet VBA makrókat hozzáadni, elérni és eltávolítani a **Aspose.Slides for PHP via Java** használatával.

## **VBA makró hozzáadása**

Készítsen egy prezentációt egy VBA projekttel és egy egyszerű makrómodullal.

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

## **VBA makró elérése**

Szerezze meg az első modult a VBA projektből.

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

## **VBA makró eltávolítása**

Töröljön egy modult a VBA projektből.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Feltételezve, hogy a VBA projektben van legalább egy modul.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```