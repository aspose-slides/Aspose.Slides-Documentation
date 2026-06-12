---
title: Makro VBA
type: docs
weight: 150
url: /id/java/examples/elements/vba-macro/
keywords:
- contoh kode
- VBA
- makro
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Otomatisasi presentasi dengan Aspose.Slides for Java: buat, jalankan, impor, dan amankan makro VBA dalam PPT, PPTX, dan ODP menggunakan contoh Java yang jelas."
---
Artikel ini menunjukkan cara menambahkan, mengakses, dan menghapus makro VBA menggunakan **Aspose.Slides for Java**.

## **Menambahkan Makro VBA**

Buat presentasi dengan proyek VBA dan modul makro sederhana.

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Makro VBA**

Ambil modul pertama dari proyek VBA.

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Makro VBA**

Hapus sebuah modul dari proyek VBA.

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```