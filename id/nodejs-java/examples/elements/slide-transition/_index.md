---
title: Transisi Slide
type: docs
weight: 110
url: /id/nodejs-java/examples/elements/slide-transition/
keywords:
- contoh kode
- transisi slide
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasai transisi slide di Aspose.Slides untuk Node.js: tambahkan, sesuaikan, dan urutkan efek serta durasi dengan contoh untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menerapkan efek transisi slide dan penjadwalan dengan **Aspose.Slides for Node.js via Java**.

## **Tambahkan Transisi Slide**

Terapkan efek transisi memudar pada slide pertama.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Terapkan transisi memudar.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Akses Transisi Slide**

Baca jenis transisi yang saat ini ditetapkan pada sebuah slide.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Akses jenis transisi.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Transisi Slide**

Hapus semua efek transisi dengan mengatur jenisnya ke `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Hapus transisi dengan mengatur ke None.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Atur Durasi Transisi**

Tentukan berapa lama slide ditampilkan sebelum berpindah secara otomatis.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // dalam milidetik.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```