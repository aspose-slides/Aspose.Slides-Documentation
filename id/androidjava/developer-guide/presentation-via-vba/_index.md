---
title: Kelola Proyek VBA dalam Presentasi di Android
linktitle: Presentasi melalui VBA
type: docs
weight: 250
url: /id/androidjava/presentation-via-vba/
keywords:
- makro
- VBA
- makro VBA
- tambahkan makro
- hapus makro
- ekstrak makro
- tambahkan VBA
- hapus VBA
- ekstrak VBA
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan cara menghasilkan dan memanipulasi presentasi PowerPoint dan OpenDocument melalui VBA dengan Aspose.Slides untuk Android via Java agar mempermudah alur kerja Anda."
---
## **Pendahuluan**

Aspose.Slides menyediakan kelas dan antarmuka untuk bekerja dengan makro dan kode VBA.

{{% alert title="Note" color="warning" %}} 

Ketika Anda mengonversi presentasi yang berisi makro ke format file lain (PDF, HTML, dll.), Aspose.Slides mengabaikan semua makro (makro tidak dibawa ke file hasil).

Ketika Anda menambahkan makro ke sebuah presentasi atau menyimpan kembali presentasi yang berisi makro, Aspose.Slides hanya menulis byte untuk makro tersebut.

Aspose.Slides **tidak pernah** menjalankan makro dalam presentasi.

{{% /alert %}}

## **Menambahkan Makro VBA**

Aspose.Slides menyediakan kelas [VbaProject](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/vbaproject/) untuk memungkinkan Anda membuat proyek VBA (dan referensi proyek) serta menyunting modul yang ada. Anda dapat menggunakan antarmuka [IVbaProject](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivbaproject/) untuk mengelola VBA yang tertanam dalam presentasi.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Gunakan konstruktor [VbaProject](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/vbaproject/#VbaProject--) untuk menambahkan proyek VBA baru.
1. Tambahkan modul ke VbaProject.
1. Atur kode sumber modul.
1. Tambahkan referensi ke <stdole>.
1. Tambahkan referensi ke **Microsoft Office**.
1. Hubungkan referensi dengan proyek VBA.
1. Simpan presentasi.

Kode Java ini menunjukkan cara menambahkan makro VBA dari awal ke sebuah presentasi:

```java
// Membuat sebuah instance dari kelas presentasi
Presentation pres = new Presentation();
try {
    // Membuat Proyek VBA baru
    pres.setVbaProject(new VbaProject());
    
    // Menambahkan modul kosong ke proyek VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Mengatur kode sumber modul
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Membuat referensi ke <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Membuat referensi ke Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Menambahkan referensi ke proyek VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Menyimpan Presentasi
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Anda mungkin ingin melihat **Aspose** [Macro Remover](https://products.aspose.app/slides/id/remove-macros), sebuah aplikasi web gratis yang digunakan untuk menghapus makro dari dokumen PowerPoint, Excel, dan Word. 

{{% /alert %}} 

## **Menghapus Makro VBA**

Dengan menggunakan properti [VbaProject](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getVbaProject--) pada kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation), Anda dapat menghapus makro VBA.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) dan muat presentasi yang berisi makro.
1. Akses modul Makro dan hapus.
1. Simpan presentasi yang telah dimodifikasi.

Kode Java ini menunjukkan cara menghapus makro VBA:

```java
// Memuat presentasi yang berisi makro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Mengakses modul Vba dan menghapusnya 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Menyimpan Presentasi
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengekstrak Makro VBA**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi Proyek VBA.
3. Lakukan perulangan pada semua modul yang terdapat dalam Proyek VBA untuk melihat makro.

Kode Java ini menunjukkan cara mengekstrak makro VBA dari presentasi yang berisi makro:

```java
// Memuat presentasi yang berisi makro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Memeriksa apakah Presentasi berisi Proyek VBA
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Memeriksa Apakah Proyek VBA Dilindungi Kata Sandi**

Dengan menggunakan metode [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) Anda dapat menentukan apakah properti proyek dilindungi kata sandi.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi [proyek VBA](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/vbaproject/).
3. Periksa apakah proyek VBA dilindungi kata sandi untuk melihat propertinya.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Periksa apakah presentasi berisi proyek VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa yang terjadi pada makro jika saya menyimpan presentasi sebagai PPTX?**

Makro akan dihapus karena PPTX tidak mendukung VBA. Untuk mempertahankan makro, pilih PPTM, PPSM, atau POTM.

**Apakah Aspose.Slides dapat menjalankan makro di dalam presentasi untuk, misalnya, menyegarkan data?**

Tidak. Perpustakaan tidak pernah mengeksekusi kode VBA; eksekusi hanya memungkinkan di dalam PowerPoint dengan pengaturan keamanan yang sesuai.

**Apakah bekerja dengan kontrol ActiveX yang terhubung ke kode VBA didukung?**

Ya, Anda dapat mengakses [kontrol ActiveX](/slides/id/androidjava/activex/), mengubah propertinya, dan menghapusnya. Ini berguna ketika makro berinteraksi dengan ActiveX.