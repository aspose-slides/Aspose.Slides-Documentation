---
title: Makro VBA
type: docs
weight: 150
url: /id/nodejs-java/examples/elements/vba-macro/
keywords:
- contoh kode
- VBA
- makro
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Otomatisasi presentasi dengan Aspose.Slides untuk Node.js via Java: buat, impor, dan amankan makro VBA dalam PPT, PPTX, dan ODP menggunakan contoh JavaScript yang jelas."
---
Artikel ini menunjukkan cara menambahkan, mengakses, dan menghapus makro VBA menggunakan **Aspose.Slides for Node.js via Java**.

## **Tambah Makro VBA**
Buat presentasi dengan proyek VBA dan modul makro sederhana.

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Makro VBA**
Ambil modul pertama dari proyek VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Mengasumsikan presentasi memiliki setidaknya satu modul VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Makro VBA**
Hapus modul dari proyek VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Mengasumsikan presentasi memiliki setidaknya satu modul VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```