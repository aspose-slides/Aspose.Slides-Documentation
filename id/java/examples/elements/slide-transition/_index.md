---
title: Transisi Slide
type: docs
weight: 110
url: /id/java/examples/elements/slide-transition/
keywords:
- contoh kode
- transisi slide
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kuasai transisi slide di Aspose.Slides untuk Java: tambahkan, sesuaikan, dan urutkan efek serta durasi dengan contoh Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menerapkan efek transisi slide dan pengatur waktu dengan **Aspose.Slides for Java**.

## **Menambahkan Transisi Slide**

Terapkan efek transisi memudar pada slide pertama.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Terapkan transisi memudar.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Transisi Slide**

Baca jenis transisi yang saat ini ditetapkan pada sebuah slide.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Akses jenis transisi.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Transisi Slide**

Hapus semua efek transisi dengan mengatur jenisnya menjadi `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Hapus transisi dengan mengatur menjadi none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengatur Durasi Transisi**

Tentukan berapa lama slide ditampilkan sebelum beralih secara otomatis.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // dalam milidetik.
    } finally {
        presentation.dispose();
    }
}
```