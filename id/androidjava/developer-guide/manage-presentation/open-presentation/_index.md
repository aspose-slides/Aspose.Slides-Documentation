---
title: Buka Presentasi di Android
linktitle: Buka Presentasi
type: docs
weight: 20
url: /id/androidjava/open-presentation/
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
- presentasi terlindungi
- presentasi besar
- sumber daya eksternal
- objek biner
- Android
- Java
- Aspose.Slides
description: "Buka presentasi PowerPoint (.pptx, .ppt) dan OpenDocument (.odp) dengan mudah menggunakan Aspose.Slides untuk Android via Java—cepat, andal, fitur lengkap."
---
## **Pendahuluan**

Selain membuat presentasi PowerPoint dari nol, Aspose.Slides juga memungkinkan Anda membuka presentasi yang sudah ada. Setelah memuat presentasi, Anda dapat mengambil informasi tentangnya, mengedit konten slide, menambahkan slide baru, menghapus yang sudah ada, dan lainnya.

## **Buka Presentasi**

Untuk membuka presentasi yang sudah ada, buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan berikan jalur file ke konstruktor-nya.

Contoh Java berikut menunjukkan cara membuka sebuah presentasi dan mendapatkan jumlah slidennya:

```java
// Buat instance kelas Presentation dan berikan jalur file ke konstruktor-nya.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Cetak jumlah total slide dalam presentasi.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Buka Presentasi yang Dilindungi Password**

Ketika Anda perlu membuka presentasi yang dilindungi password, berikan password melalui metode [setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) pada kelas [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/) untuk mendekripsi dan memuatnya. Kode Java berikut mendemonstrasikan operasi ini:

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

## **Buka Presentasi Besar**

Aspose.Slides menyediakan opsi—khususnya metode [getBlobManagementOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) dalam kelas [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/)—untuk membantu Anda memuat presentasi berukuran besar.

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

    // Jangan lakukan ini! Pengecualian I/O akan dilempar karena file terkunci hingga objek presentasi dibuang.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Tidak apa-apa melakukannya di sini. File sumber tidak lagi terkunci oleh objek presentasi.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Untuk mengatasi beberapa keterbatasan saat bekerja dengan aliran, Aspose.Slides mungkin menyalin isi aliran. Memuat presentasi besar dari aliran menyebabkan presentasi disalin dan dapat memperlambat proses pemuatan. Oleh karena itu, ketika Anda perlu memuat presentasi besar, kami sangat menyarankan menggunakan jalur file presentasi daripada aliran.

Saat membuat presentasi yang berisi objek besar (video, audio, gambar beresolusi tinggi, dll.), Anda dapat menggunakan [BLOB management](/slides/id/androidjava/manage-blob/) untuk mengurangi konsumsi memori.
{{%/alert %}}

## **Kendalikan Sumber Daya Eksternal**

Aspose.Slides menyediakan antarmuka [IResourceLoadingCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iresourceloadingcallback/) yang memungkinkan Anda mengelola sumber daya eksternal. Kode Java berikut menunjukkan cara menggunakan antarmuka `IResourceLoadingCallback`:

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
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Gunakan metode apa saja untuk mendapatkan byte
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

- Proyek VBA (dapat diakses melalui [IPresentation.getVbaProject](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- Data tersemat objek OLE (dapat diakses melalui [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Data biner kontrol ActiveX (dapat diakses melalui [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Dengan menggunakan metode [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), Anda dapat memuat presentasi tanpa objek biner tersemat apa pun.

Metode ini berguna untuk menghapus konten biner yang berpotensi berbahaya. Kode Java berikut menunjukkan cara memuat presentasi tanpa konten biner tersemat apa pun:

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

Anda akan menerima pengecualian validasi parsing/format saat memuat. Kesalahan semacam ini sering menyebutkan struktur ZIP yang tidak valid atau rekaman PowerPoint yang rusak.

**Apa yang terjadi jika font yang diperlukan tidak ada saat membuka?**

File akan terbuka, tetapi kemudian [rendering/export](/slides/id/androidjava/convert-presentation/) mungkin menggantikan font. [Configure font substitutions](/slides/id/androidjava/font-substitution/) atau [add the required fonts](/slides/id/androidjava/custom-font/) ke lingkungan runtime.

**Bagaimana dengan media tersemat (video/audio) saat membuka?**

Mereka menjadi tersedia sebagai sumber daya presentasi. Jika media dirujuk melalui jalur eksternal, pastikan jalur tersebut dapat diakses di lingkungan Anda; jika tidak, [rendering/export](/slides/id/androidjava/convert-presentation/) mungkin mengabaikan media.