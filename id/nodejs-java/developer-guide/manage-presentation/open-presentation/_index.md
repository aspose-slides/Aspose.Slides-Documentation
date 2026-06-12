---
title: Membuka Presentasi dengan JavaScript
linktitle: Buka Presentasi
type: docs
weight: 20
url: /id/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Buka presentasi PowerPoint (.pptx, .ppt) dan OpenDocument (.odp) dengan mudah menggunakan Aspose.Slides untuk Node.js via Java—cepat, andal, fitur lengkap."
---
## **Pendahuluan**

Selain membuat presentasi PowerPoint dari awal, Aspose.Slides juga memungkinkan Anda membuka presentasi yang sudah ada. Setelah memuat sebuah presentasi, Anda dapat mengambil informasi tentangnya, mengedit konten slide, menambahkan slide baru, menghapus slide yang ada, dan lainnya.

## **Buka Presentasi**

Untuk membuka presentasi yang sudah ada, buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan berikan jalur file ke konstruktor‑nya.

Contoh JavaScript berikut menunjukkan cara membuka presentasi dan memperoleh jumlah slide‑nya:

```js
// Membuat instance kelas Presentation dan memberikan jalur file ke konstruktornya.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Cetak total jumlah slide dalam presentasi.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Buka Presentasi yang Dilindungi Password**

Ketika Anda perlu membuka presentasi yang dilindungi password, berikan password melalui metode [setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword) dari kelas [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/) untuk mendekripsi dan memuatnya. Kode JavaScript berikut mendemonstrasikan operasi ini:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Lakukan operasi pada presentasi yang telah didekripsi.
} finally {
    presentation.dispose();
}
```

## **Buka Presentasi Besar**

Aspose.Slides menyediakan opsi—khususnya metode [getBlobManagementOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) di kelas [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/)—untuk membantu Anda memuat presentasi berukuran besar.

Kode JavaScript berikut mendemonstrasikan memuat presentasi besar (misalnya, 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Pilih perilaku KeepLocked—file presentasi akan tetap terkunci selama masa hidup
// instance Presentation, tetapi tidak perlu dimuat ke memori atau disalin ke file sementara.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // Presentasi besar telah dimuat dan dapat digunakan, sementara konsumsi memori tetap rendah.
    
    // Lakukan perubahan pada presentasi.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Simpan presentasi ke file lain. Konsumsi memori tetap rendah selama operasi ini.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Jangan lakukan ini! Pengecualian I/O akan dilempar karena file terkunci sampai objek presentasi dibuang.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Tidak apa-apa melakukannya di sini. File sumber tidak lagi dikunci oleh objek presentasi.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
Untuk mengatasi beberapa keterbatasan saat bekerja dengan aliran, Aspose.Slides mungkin menyalin isi aliran. Memuat presentasi besar dari aliran menyebabkan presentasi disalin dan dapat memperlambat proses pemuatan. Oleh karena itu, ketika Anda perlu memuat presentasi besar, kami sangat menyarankan menggunakan jalur file presentasi daripada aliran.

Saat membuat presentasi yang berisi objek besar (video, audio, gambar beresolusi tinggi, dll.), Anda dapat menggunakan [BLOB management](/slides/id/nodejs-java/manage-blob/) untuk mengurangi konsumsi memori.
{{%/alert %}}

## **Kendalikan Sumber Daya Eksternal**

Aspose.Slides menyediakan antarmuka [IResourceLoadingCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iresourceloadingcallback/) yang memungkinkan Anda mengelola sumber daya eksternal. Kode JavaScript berikut menunjukkan cara menggunakan antarmuka `IResourceLoadingCallback`:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Muat gambar pengganti.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Setel URL pengganti.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Lewati semua gambar lainnya.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Muat Presentasi Tanpa Objek Biner Tersemat**

Sebuah presentasi PowerPoint dapat berisi jenis objek biner tersemat berikut:

- Proyek VBA (dapat diakses melalui [Presentation.getVbaProject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getVbaProject));
- Data tersemat objek OLE (dapat diakses melalui [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Data biner kontrol ActiveX (dapat diakses melalui [Control.getActiveXControlBinary](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Dengan menggunakan metode [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), Anda dapat memuat presentasi tanpa objek biner tersemat apa pun.

Metode ini berguna untuk menghapus konten biner yang berpotensi berbahaya. Kode JavaScript berikut mendemonstrasikan cara memuat presentasi tanpa konten biner tersemat:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Lakukan operasi pada presentasi.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Anda akan mendapatkan pengecualian validasi parsing/format saat memuat. Kesalahan semacam ini biasanya menyebutkan struktur ZIP yang tidak valid atau rekaman PowerPoint yang rusak.

**Apa yang terjadi jika font yang diperlukan hilang saat membuka?**

File akan terbuka, tetapi kemudian [rendering/export](/slides/id/nodejs-java/convert-presentation/) dapat mengganti font. [Konfigurasikan substitusi font](/slides/id/nodejs-java/font-substitution/) atau [tambahkan font yang diperlukan](/slides/id/nodejs-java/custom-font/) ke lingkungan runtime.

**Bagaimana dengan media tersemat (video/audio) saat membuka?**

Mereka akan tersedia sebagai sumber daya presentasi. Jika media direferensikan melalui jalur eksternal, pastikan jalur tersebut dapat diakses di lingkungan Anda; jika tidak [rendering/export](/slides/id/nodejs-java/convert-presentation/) dapat mengabaikan media.