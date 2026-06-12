---
title: ActiveX
type: docs
weight: 200
url: /id/nodejs-java/examples/elements/activex/
keywords:
- contoh kode
- ActiveX
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Lihat contoh ActiveX Aspose.Slides untuk Node.js: sisipkan, konfigurasikan, dan kendalikan objek ActiveX dalam presentasi PPT dan PPTX dengan kode JavaScript yang jelas."
---
Artikel ini menunjukkan cara menambah, mengakses, menghapus, dan mengonfigurasi kontrol ActiveX dalam presentasi menggunakan **Aspose.Slides for Node.js via Java**.

## **Menambahkan Kontrol ActiveX**

Menambahkan kontrol ActiveX baru ke slide.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Tambahkan kontrol ActiveX baru.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Kontrol ActiveX**

Membaca informasi dari kontrol ActiveX pertama pada slide.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Akses kontrol ActiveX pertama.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Kontrol ActiveX**

Menghapus kontrol ActiveX yang ada dari slide.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Hapus kontrol ActiveX pertama.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengatur Properti ActiveX**

Mengonfigurasi beberapa properti ActiveX.

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```