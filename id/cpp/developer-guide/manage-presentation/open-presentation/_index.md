---
title: Membuka Presentasi di C++
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
description: "Pelajari cara membuka presentasi PowerPoint dan OpenDocument di C++, menyediakan kata sandi pembuka, mengontrol pemuatan sumber daya, dan mengurangi penggunaan memori dengan Aspose.Slides untuk C++."
---
## **Pendahuluan**

[Aspose.Slides for C++](https://products.aspose.com/slides/id/cpp/) dapat memuat presentasi PowerPoint dan OpenDocument dari file dan aliran. Setelah sebuah presentasi dimuat, Anda dapat memeriksa strukturnya, mengedit slide, mengelola sumber daya, dan menyimpannya dalam format asli atau format lain yang didukung.

Perilaku pemuatan dapat disesuaikan melalui kelas [LoadOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/). Misalnya, Anda dapat menyediakan kata sandi pembuka, menyimpan objek biner besar di luar memori, mengontrol sumber daya eksternal, atau mengabaikan data biner yang disematkan.

## **Buka Presentasi**

Setelah memuat file atau aliran, Anda dapat [menentukan format presentasi aslinya](/slides/id/cpp/detect-presentation-source-format/) untuk memilih cara aplikasi Anda memprosesnya.

Untuk membuka presentasi yang ada, berikan jalur file ke konstruktor [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Buang (dispose) presentasi setelah digunakan agar penangan file, data sementara, dan sumber daya lainnya segera dibebaskan.

Contoh C++ berikut menunjukkan cara membuka sebuah presentasi dan memperoleh jumlah slide-nya:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Buka Presentasi yang Dilindungi Kata Sandi**

Kata sandi pembuka mengenkripsi konten presentasi. Untuk memuat seluruh presentasi, berikan kata sandi yang benar ke [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/) dan berikan opsi tersebut ke konstruktor [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Pemuatan gagal jika kata sandi tidak ada atau salah.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Untuk deteksi kata sandi, validasi, dan alur kerja enkripsi, lihat [Password-Protect Presentations](/slides/id/cpp/password-protected-presentation/). Jika sebuah presentasi yang terenkripsi sengaja disimpan dengan properti dokumen publik, properti tersebut dapat dibaca tanpa kata sandi; lihat [Manage Presentation Properties](/slides/id/cpp/presentation-properties/).

## **Buka Presentasi Besar**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) mengontrol cara Aspose.Slides menangani objek biner besar seperti gambar, audio, dan video. Anda dapat menjaga file sumber tetap terkunci, mengizinkan file sementara, dan membatasi jumlah data BLOB yang dipertahankan dalam memori.

Kode C++ berikut menunjukkan cara memuat presentasi besar (misalnya, 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Dengan `PresentationLockingBehavior::KeepLocked`, file sumber tetap terkunci hingga objek `Presentation` dibuang. Jangan memindahkan, menimpa, atau menghapus file sumber selama objek tersebut masih hidup.

Aspose.Slides mungkin menyalin isi aliran masuk saat memuatnya. Untuk presentasi besar, jalur file biasanya lebih efisien dibanding aliran. Lihat [Manage BLOBs](/slides/id/cpp/manage-blob/) untuk opsi penyimpanan dan manajemen memori tambahan.
{{% /alert %}}

## **Kontrol Sumber Daya Eksternal**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) menerima implementasi [IResourceLoadingCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/iresourceloadingcallback/). Callback dapat menyediakan data pengganti, mengarahkan ulang sumber daya, menggunakan pemuat default, atau melewati sumber daya. Ini berguna ketika presentasi berisi gambar eksternal yang harus diselesaikan sesuai dengan aturan keamanan atau penyimpanan khusus aplikasi.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Muat Presentasi Tanpa Objek Biner yang Disematkan**

Presentasi dapat berisi data biner yang disematkan yang tidak diperlukan atau tidak ingin disimpan oleh aplikasi. Contohnya meliputi:
- proyek VBA, tersedia melalui [IPresentation::get_VbaProject](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_vbaproject/);
- data OLE yang disematkan, tersedia melalui [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- data kontrol ActiveX, tersedia melalui [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/id/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Berikan `true` ke [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) untuk menghapus data biner ini saat memuat. Simpan presentasi yang dimuat untuk mempertahankan hasil yang telah disanitasi.

Opsi ini mengurangi paparan terhadap muatan tersemat yang tidak diinginkan, namun bukan sistem deteksi malware atau sanitasi konten yang lengkap.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Aspose.Slides melemparkan pengecualian parsing atau format saat memuat. Tangani kegagalan tersebut secara terpisah dari kesalahan kata sandi yang salah agar aplikasi dapat melaporkan penyebabnya dengan akurat.

**Apa yang terjadi jika font yang diperlukan tidak ada?**

Presentasi masih dapat dimuat, namun proses perenderan dan ekspor mungkin menggantikan font. Anda dapat [mengonfigurasi substitusi font](/slides/id/cpp/font-substitution/) atau [menyediakan font khusus](/slides/id/cpp/custom-font/) untuk membuat output lebih dapat diprediksi.

**Apakah memuat sebuah presentasi juga memuat media yang disematkan?**

Audio dan video yang disematkan menjadi tersedia melalui model objek presentasi. Sumber daya eksternal diselesaikan sesuai dengan perilaku pemuatan sumber daya yang dikonfigurasi dan mungkin tidak tersedia jika lokasinya tidak dapat diakses.