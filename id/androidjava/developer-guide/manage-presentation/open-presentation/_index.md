---
title: Buka Presentasi di Android
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
- presentasi terlindungi
- presentasi besar
- sumber daya eksternal
- objek biner
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membuka presentasi PowerPoint dan OpenDocument di Android, menyediakan kata sandi pembuka, mengontrol pemuatan sumber daya, dan mengurangi penggunaan memori dengan Aspose.Slides untuk Android via Java."
---
## **Pendahuluan**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/id/androidjava/) dapat memuat presentasi PowerPoint dan OpenDocument dari file dan aliran. Setelah presentasi dimuat, Anda dapat memeriksa strukturnya, mengedit slide, mengelola sumber daya, dan menyimpannya dalam format asli atau format lain yang didukung.

Perilaku pemuatan dapat disesuaikan melalui kelas [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/). Misalnya, Anda dapat menyediakan kata sandi pembuka, menyimpan objek biner besar di luar memori heap Java, mengontrol sumber daya eksternal, atau menghilangkan data biner tersemat.

## **Membuka Presentasi**

Setelah memuat file atau aliran, Anda dapat [menentukan format presentasi asli](/slides/id/androidjava/detect-presentation-source-format/) untuk memilih cara aplikasi Anda memprosesnya.

Untuk membuka presentasi yang sudah ada, berikan jalur file ke konstruktor [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Buang (dispose) objek presentasi setelah digunakan agar penangan file, data sementara, dan sumber daya lainnya segera dilepaskan.

Contoh Java berikut menunjukkan cara membuka presentasi dan mendapatkan jumlah slide:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Membuka Presentasi yang Dilindungi Kata Sandi**

Kata sandi pembuka mengenkripsi konten presentasi. Untuk memuat seluruh presentasi, berikan kata sandi yang benar ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) dan berikan opsi tersebut ke konstruktor [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Pemuatan gagal bila kata sandi hilang atau tidak tepat.

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

Untuk deteksi kata sandi, validasi, dan alur kerja enkripsi, lihat [Password-Protect Presentations](/slides/id/androidjava/password-protected-presentation/). Jika presentasi terenkripsi sengaja disimpan dengan properti dokumen publik, properti tersebut dapat dibaca tanpa kata sandi; lihat [Manage Presentation Properties](/slides/id/androidjava/presentation-properties/).

## **Membuka Presentasi Besar**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) mengembalikan opsi yang mengontrol bagaimana Aspose.Slides menangani objek biner besar seperti gambar, audio, dan video. Anda dapat mengunci file sumber, memperbolehkan file sementara, dan membatasi jumlah data BLOB yang disimpan di memori.

Contoh kode Java berikut mendemonstrasikan pemuatan presentasi besar (misalnya, 2 GB):

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

{{% alert color="info" title="Note" %}}
Dengan [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked), file sumber tetap terkunci hingga instansi presentasi dibuang. Jangan memindahkan, menimpa, atau menghapus file sumber selama instansi itu masih hidup.

Aspose.Slides dapat menyalin isi aliran input saat memuatnya. Untuk presentasi besar, jalur file umumnya lebih efisien daripada aliran. Lihat [Manage BLOBs](/slides/id/androidjava/manage-blob/) untuk opsi penyimpanan dan manajemen memori tambahan.
{{% /alert %}}

## **Mengontrol Sumber Daya Eksternal**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) menerima implementasi [IResourceLoadingCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iresourceloadingcallback/). Callback dapat menyediakan data pengganti, mengarahkan ulang sumber daya, menggunakan pemuat default, atau melewatkan sumber daya. Ini berguna ketika presentasi berisi gambar eksternal yang harus diselesaikan sesuai aturan keamanan atau penyimpanan khusus aplikasi.

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

## **Memuat Presentasi tanpa Objek Biner Tersemat**

Sebuah presentasi dapat berisi data biner tersemat yang tidak diperlukan atau tidak ingin disimpan oleh aplikasi. Contohnya meliputi:

- Proyek VBA, tersedia melalui [IPresentation.getVbaProject](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- Data OLE tersemat, tersedia melalui [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- Data kontrol ActiveX, tersedia melalui [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Setel [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) ke `true` untuk menghapus data biner ini saat pemuatan. Simpan presentasi yang telah dimuat untuk mempertahankan hasil yang telah dibersihkan.

Opsi ini mengurangi paparan terhadap payload tersemat yang tidak diinginkan, namun tidak menjadi sistem deteksi malware atau sanitasi konten yang lengkap.

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

**Bagaimana cara mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Aspose.Slides melempar pengecualian parsing atau format saat memuat. Tangani kegagalan tersebut secara terpisah dari kesalahan kata sandi yang salah sehingga aplikasi dapat melaporkan penyebabnya secara akurat.

**Apa yang terjadi jika font yang diperlukan tidak ada?**

Presentasi masih dapat dimuat, tetapi proses rendering dan ekspor mungkin menggantikan font. Anda dapat [mengonfigurasi substitusi font](/slides/id/androidjava/font-substitution/) atau [menyediakan font khusus](/slides/id/androidjava/custom-font/) untuk membuat output lebih dapat diprediksi.

**Apakah pemuatan presentasi juga memuat media tersematnya?**

Audio dan video tersemat menjadi tersedia melalui model objek presentasi. Sumber daya eksternal diselesaikan sesuai perilaku pemuatan sumber daya yang dikonfigurasi dan mungkin tidak tersedia jika lokasinya tidak dapat diakses.