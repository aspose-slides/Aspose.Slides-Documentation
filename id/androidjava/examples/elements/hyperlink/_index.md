---
title: Hyperlink
type: docs
weight: 130
url: /id/androidjava/examples/elements/hyperlink/
keywords:
- contoh kode
- hyperlink
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Menambahkan dan mengelola hyperlink di Aspose.Slides untuk Android: tautkan teks, bentuk, dan gambar, atur target serta aksi untuk PPT, PPTX, dan ODP dengan contoh Java."
---
Artikel ini menunjukkan cara menambahkan, mengakses, menghapus, dan memperbarui hyperlink pada bentuk menggunakan **Aspose.Slides for Android via Java**.

## **Menambahkan Hyperlink**

Buat bentuk persegi panjang dengan hyperlink yang mengarah ke situs web eksternal.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Hyperlink**

Baca informasi hyperlink dari bagian teks sebuah bentuk.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Hyperlink**

Hapus hyperlink dari teks bentuk.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Memperbarui Hyperlink**

Ubah target hyperlink yang ada. Gunakan `HyperlinkManager` untuk memodifikasi teks yang sudah mengandung hyperlink, yang meniru cara PowerPoint memperbarui hyperlink dengan aman.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // Mengubah hyperlink dalam teks yang ada harus dilakukan melalui
        // HyperlinkManager daripada mengatur properti secara langsung.
        // Ini meniru cara PowerPoint memperbarui hyperlink dengan aman.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```