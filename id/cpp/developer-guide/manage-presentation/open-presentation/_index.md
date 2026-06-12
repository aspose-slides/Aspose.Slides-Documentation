---
title: Buka Presentasi dalam C++
linktitle: Buka Presentasi
type: docs
weight: 20
url: /id/cpp/open-presentation/
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
- C++
- Aspose.Slides
description: "Buka presentasi PowerPoint (.pptx, .ppt) dan OpenDocument (.odp) dengan mudah menggunakan Aspose.Slides untuk C++—cepat, dapat diandalkan, dan lengkap."
---
## **Pendahuluan**

Selain membuat presentasi PowerPoint dari awal, Aspose.Slides juga memungkinkan Anda membuka presentasi yang sudah ada. Setelah memuat sebuah presentasi, Anda dapat mengambil informasi tentangnya, mengedit konten slide, menambahkan slide baru, menghapus yang sudah ada, dan lain-lain.

## **Membuka Presentasi**

Untuk membuka presentasi yang sudah ada, buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan berikan jalur file ke konstruktornya.

Contoh C++ berikut menunjukkan cara membuka sebuah presentasi dan mendapatkan jumlah slide-nya:

```cpp
// Membuat instance kelas Presentation dan memberikan jalur file ke konstruktor-nya.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Menampilkan total jumlah slide dalam presentasi.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Membuka Presentasi yang Dilindungi Kata Sandi**

Ketika Anda perlu membuka presentasi yang dilindungi kata sandi, berikan kata sandi melalui metode [set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/) dari kelas [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/) untuk mendekripsi dan memuatnya. Kode C++ berikut mendemonstrasikan operasi ini:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Lakukan operasi pada presentasi yang telah didekripsi.

presentation->Dispose();
```

## **Membuka Presentasi Besar**

Aspose.Slides menyediakan opsi—terutama metode [get_BlobManagementOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) di kelas [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/)—untuk membantu Anda memuat presentasi berukuran besar.

Kode C++ berikut menunjukkan cara memuat presentasi besar (misalnya, 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Pilih perilaku KeepLocked—file presentasi akan tetap terkunci selama umur
// instansi Presentation, tetapi tidak perlu dimuat ke memori atau disalin ke file sementara.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// Presentasi besar telah dimuat dan dapat digunakan, sementara konsumsi memori tetap rendah.

// Lakukan perubahan pada presentasi.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Simpan presentasi ke file lain. Konsumsi memori tetap rendah selama operasi ini.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Jangan lakukan ini! Eksepsi I/O akan dilempar karena file terkunci sampai objek presentasi dibuang.
File::Delete(filePath);

presentation->Dispose();

// Tidak apa-apa melakukannya di sini. File sumber tidak lagi terkunci oleh objek presentasi.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Untuk mengatasi beberapa keterbatasan saat bekerja dengan aliran, Aspose.Slides mungkin menyalin isi aliran. Memuat presentasi besar dari aliran menyebabkan presentasi disalin dan dapat memperlambat proses pemuatan. Oleh karena itu, ketika Anda perlu memuat presentasi besar, kami sangat menyarankan menggunakan jalur file presentasi alih-alih aliran.

Saat membuat presentasi yang berisi objek besar (video, audio, gambar resolusi tinggi, dll.), Anda dapat menggunakan [BLOB management](/slides/id/cpp/manage-blob/) untuk mengurangi konsumsi memori.
{{%/alert %}}

## **Mengendalikan Sumber Daya Eksternal**

Aspose.Slides menyediakan antarmuka [IResourceLoadingCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/iresourceloadingcallback/) yang memungkinkan Anda mengelola sumber daya eksternal. Kode C++ berikut menunjukkan cara menggunakan antarmuka `IResourceLoadingCallback`:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Muat gambar pengganti.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Tetapkan URL pengganti.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Lewati semua gambar lainnya.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Muat Presentasi tanpa Objek Biner yang Disematkan**

Presentasi PowerPoint dapat berisi jenis objek biner yang disematkan berikut:

- Proyek VBA (dapat diakses melalui [IPresentation::get_VbaProject](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_vbaproject/));
- Data yang disematkan objek OLE (dapat diakses melalui [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- Data biner kontrol ActiveX (dapat diakses melalui [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/id/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Dengan menggunakan metode [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/), Anda dapat memuat sebuah presentasi tanpa objek biner yang disematkan.

Metode ini berguna untuk menghapus konten biner yang berpotensi berbahaya. Kode C++ berikut menunjukkan cara memuat sebuah presentasi tanpa konten biner yang disematkan:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Anda akan menerima pengecualian parsing/validasi format saat memuat. Kesalahan semacam itu sering menyebutkan struktur ZIP yang tidak valid atau rekaman PowerPoint yang rusak.

**Apa yang terjadi jika font yang dibutuhkan tidak ada saat membuka?**

File akan terbuka, tetapi kemudian [rendering/export](/slides/id/cpp/convert-presentation/) mungkin menggantikan font. [Konfigurasikan substitusi font](/slides/id/cpp/font-substitution/) atau [tambahkan font yang diperlukan](/slides/id/cpp/custom-font/) ke lingkungan runtime.

**Bagaimana dengan media yang disematkan (video/audio) saat membuka?**

Mereka akan tersedia sebagai sumber daya presentasi. Jika media direferensikan melalui jalur eksternal, pastikan jalur tersebut dapat diakses di lingkungan Anda; bila tidak, [rendering/export](/slides/id/cpp/convert-presentation/) mungkin tidak menyertakan media tersebut.