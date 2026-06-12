---
title: Membuka Presentasi di Java
linktitle: Buka Presentasi
type: docs
weight: 20
url: /id/java/open-presentation/
keywords:
- buka PowerPoint
- buka OpenDocument
- buka presentasi
- buka PPTX
- buka PPT
- buka ODP
- muat presentasi
- muat PPTX
- muat PPT
- muat ODP
- presentasi yang dilindungi
- presentasi besar
- sumber daya eksternal
- objek biner
- Java
- Aspose.Slides
description: "Buka presentasi PowerPoint (.pptx, .ppt) dan OpenDocument (.odp) dengan mudah menggunakan Aspose.Slides untuk Java—cepat, andal, lengkap fiturnya."
---
## **Pendahuluan**

Selain membuat presentasi PowerPoint dari awal, Aspose.Slides juga memungkinkan Anda membuka presentasi yang sudah ada. Setelah memuat sebuah presentasi, Anda dapat mengambil informasi tentangnya, mengedit konten slide, menambahkan slide baru, menghapus slide yang ada, dan lain-lain.

## **Membuka Presentasi**

Untuk membuka presentasi yang sudah ada, buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan berikan jalur file ke konstruktornya.

Contoh Java berikut menunjukkan cara membuka sebuah presentasi dan mendapatkan jumlah slidennya:

```java
// Membuat instance kelas Presentation dan memberikan jalur file ke konstruktornya.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Cetak total jumlah slide dalam presentasi.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Membuka Presentasi yang Dilindungi Kata Sandi**

Saat Anda perlu membuka presentasi yang dilindungi kata sandi, berikan kata sandi melalui metode [setPassword](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) dari kelas [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/) untuk mendekripsi dan memuatnya. Kode Java berikut mendemonstrasikan operasi ini:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Lakukan operasi pada presentasi yang sudah didekripsi.
} finally {
    presentation.dispose();
}
```

## **Membuka Presentasi Besar**

Aspose.Slides menyediakan opsi—khususnya metode [getBlobManagementOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) pada kelas [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/)—untuk membantu Anda memuat presentasi yang besar.

Kode Java berikut menunjukkan cara memuat presentasi besar (misalnya, 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Pilih perilaku KeepLocked—file presentasi akan tetap terkunci selama masa hidup
// instance Presentation, tetapi tidak perlu dimuat ke memori atau disalin ke file sementara.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Presentasi besar telah dimuat dan dapat digunakan, sementara konsumsi memori tetap rendah.

    // Lakukan perubahan pada presentasi.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Simpan presentasi ke file lain. Konsumsi memori tetap rendah selama operasi ini.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Jangan lakukan ini! Pengecualian I/O akan dilempar karena file terkunci sampai objek presentasi dibuang.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Ini boleh dilakukan di sini. File sumber tidak lagi terkunci oleh objek presentasi.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Untuk mengatasi beberapa keterbatasan saat bekerja dengan aliran, Aspose.Slides dapat menyalin isi aliran. Memuat presentasi besar dari aliran menyebabkan presentasi disalin dan dapat memperlambat proses pemuatan. Oleh karena itu, ketika Anda perlu memuat presentasi besar, kami sangat menyarankan untuk menggunakan jalur file presentasi daripada aliran.

Saat membuat presentasi yang berisi objek besar (video, audio, gambar beresolusi tinggi, dll.), Anda dapat menggunakan [BLOB management](/slides/id/java/manage-blob/) untuk mengurangi konsumsi memori.
{{%/alert %}}

## **Mengontrol Sumber Daya Eksternal**

Aspose.Slides menyediakan antarmuka [IResourceLoadingCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iresourceloadingcallback/) yang memungkinkan Anda mengelola sumber daya eksternal. Kode Java berikut menunjukkan cara menggunakan antarmuka `IResourceLoadingCallback`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Muat gambar pengganti.
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Atur URL pengganti.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Lewati semua gambar lainnya.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Muat Presentasi tanpa Objek Biner Tersemat**

Presentasi PowerPoint dapat berisi tipe objek biner tersemat berikut:

- Proyek VBA (dapat diakses melalui [IPresentation.getVbaProject](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getVbaProject--));
- Data tersemat objek OLE (dapat diakses melalui [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Data biner kontrol ActiveX (dapat diakses melalui [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/id/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Dengan menggunakan metode [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), Anda dapat memuat presentasi tanpa objek biner tersemat apapun.

Metode ini berguna untuk menghilangkan konten biner yang berpotensi berbahaya. Kode Java berikut mendemonstrasikan cara memuat presentasi tanpa konten biner tersemat apa pun:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Lakukan operasi pada presentasi.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Anda akan menerima pengecualian parsing/validasi format saat memuat. Kesalahan semacam ini sering menyebutkan struktur ZIP yang tidak valid atau rekaman PowerPoint yang rusak.

**Apa yang terjadi jika font yang dibutuhkan tidak ada saat membuka?**

File akan terbuka, tetapi kemudian [rendering/export](/slides/id/java/convert-presentation/) mungkin menggantikan font. [Konfigurasi substitusi font](/slides/id/java/font-substitution/) atau [tambahkan font yang dibutuhkan](/slides/id/java/custom-font/) ke lingkungan runtime.

**Bagaimana dengan media tersemat (video/audio) saat membuka?**

Media tersebut akan tersedia sebagai sumber daya presentasi. Jika media direferensikan melalui jalur eksternal, pastikan jalur tersebut dapat diakses dalam lingkungan Anda; jika tidak, [rendering/export](/slides/id/java/convert-presentation/) mungkin mengabaikan media tersebut.