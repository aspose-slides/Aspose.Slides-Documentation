---
title: Membuka Presentasi di Android
linktitle: Buka Presentasi
type: docs
weight: 20
url: /id/androidjava/open-presentation/
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
- presentasi dilindungi
- presentasi besar
- sumber daya eksternal
- objek biner
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membuka presentasi PowerPoint dan OpenDocument di Android, menyediakan kata sandi pembuka, mengontrol pemuatan sumber daya, dan mengurangi penggunaan memori dengan Aspose.Slides untuk Android via Java."
---
## **Pendahuluan**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/id/androidjava/) dapat memuat presentasi PowerPoint dan OpenDocument dari file dan aliran. Setelah sebuah presentasi dimuat, Anda dapat memeriksa strukturnya, mengedit slide, mengelola sumber daya, dan menyimpannya dalam format aslinya atau format lain yang didukung.

Perilaku pemuatan dapat disesuaikan melalui kelas [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/). Misalnya, Anda dapat menyediakan kata sandi pembuka, menyimpan objek biner besar di luar memori heap Java, mengendalikan sumber daya eksternal, atau mengabaikan data biner yang disematkan.

## **Buka Presentasi**

Untuk membuka presentasi yang sudah ada, berikan jalur filenya ke konstruktor [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Tutup (dispose) presentasi setelah digunakan sehingga pegangan file, data sementara, dan sumber daya lainnya segera dibebaskan.

Contoh Java berikut menunjukkan cara membuka sebuah presentasi dan mendapatkan jumlah slide:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Buka Presentasi yang Dilindungi Kata Sandi**

Kata sandi pembuka mengenkripsi konten presentasi. Untuk memuat keseluruhan presentasi, berikan kata sandi yang benar ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) dan sediakan opsi tersebut ke konstruktor [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Pemuatan gagal ketika kata sandi tidak ada atau salah.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Untuk deteksi kata sandi, validasi, dan alur kerja enkripsi, lihat [Presentasi yang Dilindungi Kata Sandi](/slides/id/androidjava/password-protected-presentation/). Jika sebuah presentasi terenkripsi sengaja disimpan dengan properti dokumen publik, properti tersebut dapat dibaca tanpa kata sandi; lihat [Kelola Properti Presentasi](/slides/id/androidjava/presentation-properties/).

## **Buka Presentasi Besar**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) mengembalikan opsi yang mengontrol bagaimana Aspose.Slides menangani objek biner besar seperti gambar, audio, dan video. Anda dapat menjaga file sumber tetap terkunci, mengizinkan file sementara, dan membatasi jumlah data BLOB yang dipertahankan dalam memori.

Kode Java berikut memperlihatkan cara memuat presentasi besar (misalnya, 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Catatan" %}}
Dengan [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked), file sumber tetap terkunci hingga instance presentasi dibuang. Jangan memindahkan, menimpa, atau menghapus file sumber selama instance tersebut masih hidup.

Aspose.Slides dapat menyalin isi aliran input saat memuatnya. Untuk presentasi besar, jalur file biasanya lebih efisien daripada aliran. Lihat [Manage BLOBs](/slides/id/androidjava/manage-blob/) untuk opsi penyimpanan dan pengelolaan memori tambahan.
{{% /alert %}}

## **Kendalikan Sumber Daya Eksternal**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) menerima implementasi [IResourceLoadingCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iresourceloadingcallback/). Callback dapat menyediakan data pengganti, mengarahkan ulang sebuah sumber daya, menggunakan pemuat default, atau melewati sumber daya tersebut. Ini berguna ketika presentasi berisi gambar eksternal yang harus diselesaikan sesuai dengan kebijakan keamanan atau penyimpanan khusus aplikasi.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Muat Presentasi tanpa Objek Biner yang Disematkan**

Suatu presentasi dapat berisi data biner yang disematkan yang tidak diperlukan atau tidak ingin disimpan oleh aplikasi. Contohnya meliputi:

- Proyek VBA, tersedia melalui [IPresentation.getVbaProject](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- data OLE yang disematkan, tersedia melalui [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- data kontrol ActiveX, tersedia melalui [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Atur [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) ke `true` untuk menghapus data biner ini saat memuat. Simpan presentasi yang dimuat untuk mempertahankan hasil yang telah disanitasi.

Opsi ini mengurangi paparan terhadap payload yang disematkan tidak diinginkan, tetapi bukan sistem deteksi malware atau sanitasi konten yang lengkap.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Aspose.Slides melemparkan exception parsing atau format saat memuat. Tangani kegagalan tersebut secara terpisah dari kesalahan kata sandi yang tidak tepat sehingga aplikasi dapat melaporkan penyebabnya dengan akurat.

**Apa yang terjadi jika font yang dibutuhkan tidak ada?**

Presentasi masih dapat dimuat, tetapi rendering dan ekspor mungkin menggantikan font. Anda dapat [mengonfigurasi substitusi font](/slides/id/androidjava/font-substitution/) atau [menyediakan font khusus](/slides/id/androidjava/custom-font/) untuk membuat output lebih dapat diprediksi.

**Apakah memuat sebuah presentasi juga memuat media yang disematkan?**

Audio dan video yang disematkan menjadi tersedia melalui model objek presentasi. Sumber daya eksternal diselesaikan sesuai dengan perilaku pemuatan sumber daya yang dikonfigurasi dan mungkin tidak tersedia jika lokasinya tidak dapat diakses.