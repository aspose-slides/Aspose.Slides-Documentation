---
title: Kotak Teks
type: docs
weight: 40
url: /id/androidjava/examples/elements/text-box/
keywords:
- contoh kode
- kotak teks
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Bekerja dengan kotak teks di Aspose.Slides untuk Android: menambah, memformat, meratakan, membungkus, menyesuaikan otomatis, dan menata teks menggunakan Java untuk presentasi PPT, PPTX, dan ODP."
---
Di Aspose.Slides, **text box** direpresentasikan oleh sebuah `AutoShape`. Hampir semua bentuk dapat berisi teks, tetapi text box standar tidak memiliki isi atau batas dan hanya menampilkan teks.

Panduan ini menjelaskan cara menambahkan, mengakses, dan menghapus text box secara programatik.

## **Menambahkan Text Box**

Text box hanyalah sebuah `AutoShape` tanpa isi atau batas dan dengan teks yang diformat. Berikut cara membuatnya:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Buat shape persegi panjang (secara default terisi dengan border dan tanpa teks).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Hapus isi dan border agar terlihat seperti kotak teks standar.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Atur format teks.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Tetapkan konten teks sebenarnya.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Catatan:** Setiap `AutoShape` yang berisi `TextFrame` tidak kosong dapat berfungsi sebagai text box.

## **Mengakses Text Box Berdasarkan Konten**

Untuk menemukan semua text box yang berisi kata kunci tertentu (mis. "Slide"), iterasi melalui shapes dan periksa teksnya:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Hanya AutoShape yang dapat berisi teks yang dapat diedit.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Lakukan sesuatu dengan kotak teks yang cocok.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Text Box Berdasarkan Konten**

Contoh ini menemukan dan menghapus semua text box pada slide pertama yang berisi kata kunci tertentu:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Tip:** Selalu buat salinan koleksi shape sebelum memodifikasinya selama iterasi untuk menghindari kesalahan modifikasi koleksi.