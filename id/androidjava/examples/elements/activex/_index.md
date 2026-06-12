---
title: ActiveX
type: docs
weight: 200
url: /id/androidjava/examples/elements/activex/
keywords:
- contoh kode
- ActiveX
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Lihat contoh ActiveX Aspose.Slides for Android: menyisipkan, mengonfigurasi, dan mengontrol objek ActiveX dalam presentasi PPT dan PPTX dengan kode Java yang jelas."
---
Artikel ini menunjukkan cara menambah, mengakses, menghapus, dan mengonfigurasi kontrol ActiveX dalam sebuah presentasi menggunakan **Aspose.Slides for Android via Java**.

## **Menambahkan Kontrol ActiveX**

Masukkan kontrol ActiveX baru dan secara opsional atur propertinya.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Menambahkan kontrol ActiveX baru.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Secara opsional mengatur beberapa properti.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Kontrol ActiveX**

Baca informasi dari kontrol ActiveX pertama pada slide.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Mengakses kontrol ActiveX pertama.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Kontrol ActiveX**

Hapus kontrol ActiveX yang ada dari slide.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Menghapus kontrol ActiveX pertama.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengatur Properti ActiveX**

Tambahkan kontrol dan konfigurasikan beberapa properti ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Menambahkan kontrol Windows Media Player dan mengonfigurasi properti.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```