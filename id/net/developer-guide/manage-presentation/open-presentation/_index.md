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
description: "Buka presentasi PowerPoint (.pptx, .ppt) dan OpenDocument (.odp) dengan mudah menggunakan Aspose.Slides untuk .NET—cepat, dapat diandalkan, dan memiliki semua fitur."
---
## **Introduction**

Selain membuat presentasi PowerPoint dari awal, Aspose.Slides juga memungkinkan Anda membuka presentasi yang sudah ada. Setelah memuat sebuah presentasi, Anda dapat mengambil informasi tentangnya, mengedit konten slide, menambahkan slide baru, menghapus slide yang ada, dan lain‑lain.

## **Open Presentations**

Untuk membuka presentasi yang sudah ada, buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan berikan jalur file ke konstruktornya.

Contoh C# berikut menunjukkan cara membuka sebuah presentasi dan mendapatkan jumlah slidennya:

```cs
// Membuat instance kelas Presentation dan memberikan jalur file ke konstruktornya.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Cetak jumlah total slide dalam presentasi.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Open Password-Protected Presentations**

Ketika Anda perlu membuka presentasi yang dilindungi kata sandi, berikan kata sandi melalui properti [Password](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/password/) dari kelas [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/) untuk mendekripsi dan memuatnya. Kode C# berikut mendemonstrasikan operasi ini:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Lakukan operasi pada presentasi yang didekripsi.
}
```

## **Open Large Presentations**

Aspose.Slides menyediakan opsi—khususnya properti [BlobManagementOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/blobmanagementoptions/) di kelas [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/)—untuk membantu Anda memuat presentasi berukuran besar.

Kode C# berikut mendemonstrasikan pemuatan presentasi besar (misalnya 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Pilih perilaku KeepLocked—file presentasi akan tetap terkunci selama masa hidup dari 
        // instance Presentation, tetapi tidak perlu dimuat ke memori atau disalin ke file sementara.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Presentasi besar telah dimuat dan dapat digunakan, sementara konsumsi memori tetap rendah.

    // Lakukan perubahan pada presentasi.
    presentation.Slides[0].Name = "Large presentation";

    // Simpan presentasi ke file lain. Konsumsi memori tetap rendah selama operasi ini.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Jangan lakukan ini! Pengecualian I/O akan dilempar karena file terkunci sampai objek presentation dibuang.
    File.Delete(filePath);
}

// Tidak masalah melakukan ini di sini. File sumber tidak lagi terkunci oleh objek presentation.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Untuk mengatasi beberapa keterbatasan saat bekerja dengan aliran, Aspose.Slides mungkin menyalin isi aliran. Memuat presentasi besar dari aliran menyebabkan presentasi disalin dan dapat memperlambat proses pemuatan. Oleh karena itu, ketika Anda perlu memuat presentasi besar, kami sangat menyarankan menggunakan jalur file presentasi daripada aliran.

Saat membuat presentasi yang berisi objek besar (video, audio, gambar resolusi tinggi, dll.), Anda dapat menggunakan [BLOB management](/slides/id/net/manage-blob/) untuk mengurangi konsumsi memori.
{{%/alert %}}

## **Control External Resources**

Aspose.Slides menyediakan antarmuka [IResourceLoadingCallback](https://reference.aspose.com/slides/id/net/aspose.slides/iresourceloadingcallback/) yang memungkinkan Anda mengelola sumber daya eksternal. Kode C# berikut menunjukkan cara menggunakan antarmuka `IResourceLoadingCallback`:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Muat gambar pengganti.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Tetapkan URL pengganti.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Lewati semua gambar lainnya.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Load Presentations without Embedded Binary Objects**

Sebuah presentasi PowerPoint dapat berisi tipe objek biner tersemat berikut:

- proyek VBA (dapat diakses melalui [IPresentation.VbaProject](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/vbaproject/));
- data objek OLE yang tersemat (dapat diakses melalui [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/id/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- data biner kontrol ActiveX (dapat diakses melalui [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/id/net/aspose.slides/icontrol/activexcontrolbinary/)).

Dengan menggunakan properti [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/), Anda dapat memuat presentasi tanpa objek biner tersemat apa pun.

Properti ini berguna untuk menghapus konten biner yang berpotensi berbahaya. Kode C# berikut mendemonstrasikan cara memuat presentasi tanpa konten biner tersemat:

```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Lakukan operasi pada presentasi.
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Anda akan mendapatkan pengecualian parsing/validasi format selama pemuatan. Kesalahan semacam ini biasanya menyebutkan struktur ZIP yang tidak valid atau catatan PowerPoint yang rusak.

**Apa yang terjadi jika font yang diperlukan tidak ada saat membuka?**

File akan tetap terbuka, tetapi kemudian proses [rendering/export](/slides/id/net/convert-presentation/) mungkin akan mengganti font. [Konfigurasikan substitusi font](/slides/id/net/font-substitution/) atau [tambahkan font yang diperlukan](/slides/id/net/custom-font/) ke lingkungan runtime.

**Bagaimana dengan media tersemat (video/audio) saat membuka?**

Media akan tersedia sebagai sumber daya presentasi. Jika media direferensikan melalui jalur eksternal, pastikan jalur tersebut dapat diakses di lingkungan Anda; jika tidak, proses [rendering/export](/slides/id/net/convert-presentation/) mungkin akan mengabaikan media tersebut.