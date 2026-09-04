---
title: Buka Presentasi di .NET
linktitle: Buka Presentasi
type: docs
weight: 20
url: /id/net/open-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuka presentasi PowerPoint dan OpenDocument dalam C#, menyediakan kata sandi pembuka, mengontrol pemuatan sumber daya, dan mengurangi penggunaan memori dengan Aspose.Slides untuk .NET."
---
## **Pengantar**

[Aspose.Slides untuk .NET](https://products.aspose.com/slides/id/net/) dapat memuat presentasi PowerPoint dan OpenDocument dari file dan aliran. Setelah presentasi dimuat, Anda dapat memeriksa strukturnya, menyunting slide, mengelola sumber daya, dan menyimpannya dalam format asli atau format lain yang didukung.

Perilaku pemuatan dapat disesuaikan melalui kelas [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/). Misalnya, Anda dapat menyediakan kata sandi pembuka, menyimpan objek biner besar di luar memori terkelola, mengontrol sumber daya eksternal, atau mengabaikan data biner yang disematkan.

## **Buka Presentasi**

Untuk membuka presentasi yang ada, berikan jalur file ke konstruktor [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Buang (dispose) presentasi setelah selesai digunakan sehingga pegangan file, data sementara, dan sumber daya lain segera dilepaskan.

Contoh C# berikut menunjukkan cara membuka presentasi dan memperoleh jumlah slide-nya:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Buka Presentasi yang Dilindungi Kata Sandi**

Kata sandi pembuka mengenkripsi konten presentasi. Untuk memuat seluruh presentasi, tetapkan kata sandi yang tepat ke [LoadOptions.Password](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/password/) dan berikan opsi tersebut ke konstruktor [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Pemuatan gagal bila kata sandi tidak ada atau tidak benar.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Untuk deteksi kata sandi, validasi, dan alur kerja enkripsi, lihat [Presentasi yang Dilindungi Kata Sandi](/slides/id/net/password-protected-presentation/). Jika presentasi yang dienkripsi disimpan dengan sengaja menggunakan properti dokumen publik, properti tersebut dapat dibaca tanpa kata sandi; lihat [Kelola Properti Presentasi](/slides/id/net/presentation-properties/).

## **Buka Presentasi Besar**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/blobmanagementoptions/) mengontrol cara Aspose.Slides menangani objek biner besar seperti gambar, audio, dan video. Anda dapat menjaga file sumber tetap terkunci, mengizinkan file sementara, dan membatasi jumlah data BLOB yang disimpan di memori.

Kode C# berikut menunjukkan cara memuat presentasi besar (misalnya, 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Dengan `PresentationLockingBehavior.KeepLocked`, file sumber tetap terkunci sampai objek `Presentation` dibuang. Jangan memindahkan, menimpa, atau menghapus file sumber selama objek tersebut masih hidup.

Aspose.Slides dapat menyalin isi aliran masukan saat memuatnya. Untuk presentasi besar, jalur file biasanya lebih efisien daripada aliran. Lihat [Kelola BLOBs](/slides/id/net/manage-blob/) untuk opsi penyimpanan dan manajemen memori tambahan.
{{% /alert %}}

## **Kendalikan Sumber Daya Eksternal**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/resourceloadingcallback/) menerima implementasi [IResourceLoadingCallback](https://reference.aspose.com/slides/id/net/aspose.slides/iresourceloadingcallback/). Callback dapat menyediakan data pengganti, mengarahkan ulang sumber daya, menggunakan pemuat default, atau melewatkan sumber daya. Hal ini berguna ketika presentasi berisi gambar eksternal yang harus diselesaikan sesuai dengan aturan keamanan atau penyimpanan khusus aplikasi.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Muat Presentasi tanpa Objek Biner Tersisip**

Sebuah presentasi dapat berisi data biner yang disematkan yang tidak diperlukan atau tidak diinginkan oleh aplikasi. Contohnya termasuk:

- Proyek VBA, tersedia melalui [IPresentation.VbaProject](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/vbaproject/);
- Data OLE yang disematkan, tersedia melalui [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/id/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- Data kontrol ActiveX, tersedia melalui [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/id/net/aspose.slides/icontrol/activexcontrolbinary/).

Setel [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) ke `true` untuk menghapus data biner ini saat memuat. Simpan presentasi yang dimuat untuk mempertahankan hasil yang telah dibersihkan.

Opsi ini mengurangi paparan terhadap muatan tersisip yang tidak diinginkan, namun bukan sistem deteksi malware atau sanitasi konten yang lengkap.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Aspose.Slides melempar pengecualian parsing atau format saat memuat. Tangani kegagalan tersebut secara terpisah dari kesalahan kata sandi yang salah agar aplikasi dapat melaporkan penyebabnya dengan tepat.

**Apa yang terjadi jika font yang diperlukan tidak ada?**

Presentasi tetap dapat dimuat, tetapi proses rendering dan ekspor mungkin menggantikan font. Anda dapat mengonfigurasi substitusi font atau menyediakan font khusus untuk membuat output lebih dapat diprediksi.

**Apakah memuat sebuah presentasi juga memuat media yang disematkan?**

Audio dan video yang disematkan tersedia melalui model objek presentasi. Sumber daya eksternal diselesaikan sesuai dengan perilaku pemuatan sumber daya yang dikonfigurasi dan mungkin tidak tersedia jika lokasinya tidak dapat diakses.