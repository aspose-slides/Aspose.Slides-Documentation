---
title: Kelola Proyek VBA dalam Presentasi Menggunakan JavaScript
linktitle: Presentasi via VBA
type: docs
weight: 250
url: /id/nodejs-java/presentation-via-vba/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan manipulasi presentasi PowerPoint serta OpenDocument melalui VBA dalam JavaScript dengan Aspose.Slides untuk Node.js via Java guna memperlancar alur kerja Anda."
---
## **Pengantar**

Aspose.Slides menyediakan kelas untuk bekerja dengan makro dan kode VBA.

{{% alert title="Catatan" color="warning" %}} 

Ketika Anda mengonversi presentasi yang berisi makro ke format file lain (PDF, HTML, dll.), Aspose.Slides mengabaikan semua makro (makro tidak dibawa ke file yang dihasilkan).

Ketika Anda menambahkan makro ke presentasi atau menyimpan ulang presentasi yang berisi makro, Aspose.Slides hanya menuliskan byte‑byte untuk makro tersebut.

Aspose.Slides **tidak pernah** menjalankan makro dalam presentasi.

{{% /alert %}}

## **Tambah Makro VBA**

Aspose.Slides menyediakan kelas [VbaProject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/vbaproject/) untuk memungkinkan Anda membuat proyek VBA (dan referensi proyek) serta menyunting modul yang ada. Anda dapat menggunakan kelas [VbaProject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/vbaproject/) untuk mengelola VBA yang tertanam dalam sebuah presentasi.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Gunakan konstruktor [VbaProject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/vbaproject/#VbaProject--) untuk menambahkan proyek VBA baru.
1. Tambahkan modul ke VbaProject.
1. Setel kode sumber modul.
1. Tambahkan referensi ke <stdole>.
1. Tambahkan referensi ke **Microsoft Office**.
1. Asosiasikan referensi dengan proyek VBA.
1. Simpan presentasi.

Kode JavaScript ini menunjukkan cara menambahkan makro VBA dari awal ke sebuah presentasi:

```javascript
// Membuat sebuah instance dari kelas presentasi
let pres = new aspose.slides.Presentation();
try {
    // Membuat Proyek VBA baru
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Menambahkan modul kosong ke proyek VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Mengatur kode sumber modul
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Membuat referensi ke <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Membuat referensi ke Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Menambahkan referensi ke proyek VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Menyimpan Presentasi
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

Anda mungkin ingin melihat **Aspose** [Macro Remover](https://products.aspose.app/slides/id/remove-macros), sebuah aplikasi web gratis yang digunakan untuk menghapus makro dari dokumen PowerPoint, Excel, dan Word. 

{{% /alert %}} 

## **Hapus Makro VBA**

Dengan menggunakan properti [VbaProject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getVbaProject--) pada kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation), Anda dapat menghapus makro VBA.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dan muat presentasi yang berisi makro.
1. Akses modul Makro dan hapus.
1. Simpan presentasi yang telah dimodifikasi.

Kode JavaScript ini menunjukkan cara menghapus makro VBA:

```javascript
// Memuat presentasi yang berisi makro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Mengakses modul Vba dan menghapusnya
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Menyimpan Presentasi
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ekstrak Makro VBA**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi Proyek VBA.
3. Loop melalui semua modul yang terdapat dalam Proyek VBA untuk melihat makro.

Kode JavaScript ini menunjukkan cara mengekstrak makro VBA dari presentasi yang berisi makro:

```javascript
// Memuat presentasi yang berisi makro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Memeriksa apakah Presentasi berisi Proyek VBA
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Periksa Apakah Proyek VBA Dilindungi Kata Sandi**

Dengan menggunakan metode [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected), Anda dapat menentukan apakah properti proyek dilindungi kata sandi.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi [proyek VBA](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/vbaproject/).
3. Periksa apakah proyek VBA dilindungi kata sandi untuk melihat propertinya.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Periksa apakah presentasi berisi proyek VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
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

Tidak. Perpustakaan tidak pernah mengeksekusi kode VBA; eksekusi hanya dimungkinkan di dalam PowerPoint dengan pengaturan keamanan yang sesuai.

**Apakah bekerja dengan kontrol ActiveX yang terhubung ke kode VBA didukung?**

Ya, Anda dapat mengakses [kontrol ActiveX](/slides/id/nodejs-java/activex/) yang ada, mengubah propertinya, dan menghapusnya. Ini berguna ketika makro berinteraksi dengan ActiveX.