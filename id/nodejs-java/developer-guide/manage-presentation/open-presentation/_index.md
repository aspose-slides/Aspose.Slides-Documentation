---
title: Membuka Presentasi dalam JavaScript
linktitle: Buka Presentasi
type: docs
weight: 20
url: /id/nodejs-java/open-presentation/
keywords:
- buka PowerPoint
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
description: "Pelajari cara membuka presentasi PowerPoint dan OpenDocument dalam JavaScript, menyediakan kata sandi pembuka, mengontrol pemuatan sumber daya, dan mengurangi penggunaan memori dengan Aspose.Slides untuk Node.js via Java."
---
## **Pendahuluan**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/id/nodejs-java/) dapat memuat presentasi PowerPoint dan OpenDocument dari file dan aliran. Setelah sebuah presentasi dimuat, Anda dapat memeriksa strukturnya, mengedit slide, mengelola sumber daya, dan menyimpannya dalam format asli atau format lain yang didukung.

Perilaku pemuatan dapat disesuaikan melalui kelas [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/). Misalnya, Anda dapat menyediakan kata sandi pembuka, menyimpan objek biner besar di luar memori Node.js, mengontrol sumber daya eksternal, atau mengabaikan data biner yang disematkan.

## **Buka Presentasi**

Untuk membuka presentasi yang ada, berikan jalur file-nya ke konstruktor [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Hapus (dispose) presentasi setelah selesai digunakan agar pegangan file, data sementara, dan sumber daya lainnya segera dibebaskan.

Contoh JavaScript berikut menunjukkan cara membuka presentasi dan mendapatkan jumlah slide:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Buka Presentasi yang Dilindungi Kata Sandi**

Kata sandi pembuka mengenkripsi konten presentasi. Untuk memuat seluruh presentasi, berikan kata sandi yang benar ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setPassword) dan sediakan opsi tersebut ke konstruktor [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Pemuatan gagal jika kata sandi tidak ada atau salah.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Untuk deteksi kata sandi, validasi, dan alur kerja enkripsi, lihat [Presentasi yang Dilindungi Kata Sandi](/slides/id/nodejs-java/password-protected-presentation/). Jika presentasi yang dienkripsi sengaja disimpan dengan properti dokumen publik, properti tersebut dapat dibaca tanpa kata sandi; lihat [Kelola Properti Presentasi](/slides/id/nodejs-java/presentation-properties/).

## **Buka Presentasi Besar**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) mengembalikan opsi yang mengontrol cara Aspose.Slides menangani objek biner besar seperti gambar, audio, dan video. Anda dapat menjaga file sumber tetap terkunci, mengizinkan file sementara, dan membatasi jumlah data BLOB yang disimpan dalam memori.

Kode JavaScript berikut menunjukkan cara memuat presentasi besar (misalnya, 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Dengan [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), file sumber tetap terkunci sampai instance presentasi dibuang. Jangan memindahkan, menimpa, atau menghapus file sumber selama instance tersebut masih hidup.

Aspose.Slides mungkin menyalin isi aliran masuk saat memuatnya. Untuk presentasi besar, jalur file biasanya lebih efisien daripada aliran. Lihat [Kelola BLOB](/slides/id/nodejs-java/manage-blob/) untuk opsi penyimpanan dan manajemen memori tambahan.
{{% /alert %}}

## **Kontrol Sumber Daya Eksternal**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) menerima implementasi [IResourceLoadingCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iresourceloadingcallback/). Callback dapat menyediakan data pengganti, mengarahkan ulang sumber daya, menggunakan pemuat default, atau melewati sumber daya tersebut. Ini berguna ketika presentasi berisi gambar eksternal yang harus diselesaikan menurut aturan keamanan atau penyimpanan spesifik aplikasi.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Muat Presentasi tanpa Objek Biner yang Disematkan**

Sebuah presentasi dapat berisi data biner yang disematkan yang tidak diperlukan atau tidak ingin disimpan oleh aplikasi. Contohnya:

- Proyek VBA, tersedia melalui [Presentation.getVbaProject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getVbaProject);
- Data OLE yang disematkan, tersedia melalui [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- Data kontrol ActiveX, tersedia melalui [Control.getActiveXControlBinary](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Setel [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) ke `true` untuk menghapus data biner ini saat memuat. Simpan presentasi yang dimuat untuk mempertahankan hasil yang telah dibersihkan.

Opsi ini mengurangi paparan terhadap payload yang tidak diinginkan yang disematkan, namun bukan sistem deteksi malware atau sanitasi konten yang lengkap.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Aspose.Slides melempar pengecualian parsing atau format saat memuat. Tangani kegagalan tersebut secara terpisah dari kesalahan kata sandi yang salah agar aplikasi dapat melaporkan penyebabnya secara akurat.

**Apa yang terjadi jika font yang dibutuhkan tidak ada?**

Presentasi masih dapat dimuat, tetapi proses rendering dan ekspor mungkin menggantikan font. Anda dapat [mengonfigurasi substitusi font](/slides/id/nodejs-java/font-substitution/) atau [menyediakan font khusus](/slides/id/nodejs-java/custom-font/) untuk membuat output lebih dapat diprediksi.

**Apakah memuat presentasi juga memuat media yang disematkan?**

Audio dan video yang disematkan menjadi tersedia melalui model objek presentasi. Sumber daya eksternal diselesaikan sesuai dengan perilaku pemuatan sumber daya yang dikonfigurasi dan mungkin tidak tersedia jika lokasinya tidak dapat diakses.