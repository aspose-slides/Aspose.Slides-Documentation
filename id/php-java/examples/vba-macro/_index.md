---
title: MakroVBA
type: docs
weight: 150
url: /id/php-java/examples/elements/vba-macro/
keywords:
- makro vba
- tambahkan makro vba
- akses makro vba
- hapus makro vba
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Bekerja dengan makro VBA di PHP menggunakan Aspose.Slides: tambahkan atau edit proyek dan modul, tandatangani atau hapus makro, dan simpan presentasi dalam format PPT, PPTX, dan ODP."
---
Mengilustrasikan cara menambahkan, mengakses, dan menghapus makro VBA menggunakan **Aspose.Slides for PHP via Java**.

## **Menambahkan Makro VBA**
Buat presentasi dengan proyek VBA dan modul makro sederhana.

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

## **Mengakses Makro VBA**
Ambil modul pertama dari proyek VBA.

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

## **Menghapus Makro VBA**
Hapus modul dari proyek VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Mengasumsikan ada setidaknya satu modul dalam proyek VBA.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```