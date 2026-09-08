---
title: Buka Presentasi di Python via Java
linktitle: Buka Presentasi
type: docs
weight: 20
url: /id/python-java/open-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Pelajari cara membuka presentasi PowerPoint dan OpenDocument di Python via Java, menyediakan kata sandi pembuka, mengontrol pemuatan sumber daya, dan mengurangi penggunaan memori dengan Aspose.Slides untuk Python via Java."
---
## **Pendahuluan**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/id/python-java/) dapat memuat presentasi PowerPoint dan OpenDocument dari file dan aliran. Setelah presentasi dimuat, Anda dapat memeriksa strukturnya, mengedit slide, mengelola sumber daya, dan menyimpannya dalam format asli atau format lain yang didukung.

Perilaku pemuatan dapat disesuaikan melalui kelas [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/). Sebagai contoh, Anda dapat menyediakan kata sandi pembuka, menyimpan objek biner besar di luar memori heap Java, mengontrol sumber daya eksternal, atau mengabaikan data biner yang disematkan.

## **Buka Presentasi**

Untuk membuka presentasi yang ada, kirimkan jalur file ke konstruktor [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/). Lepaskan presentasi setelah digunakan agar pegangan file, data sementara, dan sumber daya lainnya segera dibebaskan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Buka Presentasi yang Dilindungi Kata Sandi**

Kata sandi pembuka mengenkripsi konten presentasi. Untuk memuat seluruh presentasi, kirimkan kata sandi yang benar ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setPassword) dan berikan opsi tersebut ke konstruktor [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/). Pemuatan gagal bila kata sandi tidak ada atau salah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Untuk deteksi kata sandi, validasi, dan alur kerja enkripsi, lihat [Password-Protect Presentations](/slides/id/python-java/password-protected-presentation/). Jika presentasi yang dienkripsi secara sengaja disimpan dengan properti dokumen publik, properti tersebut dapat dibaca tanpa kata sandi; lihat [Manage Presentation Properties](/slides/id/python-java/presentation-properties/).

## **Buka Presentasi Besar**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) mengembalikan opsi yang mengontrol bagaimana Aspose.Slides menangani objek biner besar seperti gambar, audio, dan video. Anda dapat menjaga file sumber tetap terkunci, mengizinkan file sementara, dan membatasi jumlah data BLOB yang disimpan dalam memori.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Dengan [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked), file sumber tetap terkunci hingga instance presentasi dibebaskan. Jangan memindahkan, menimpa, atau menghapus file sumber selama instance tersebut masih hidup.

Aspose.Slides mungkin menyalin isi aliran masukan saat memuatnya. Untuk presentasi besar, jalur file biasanya lebih efisien daripada aliran. Lihat [Manage BLOBs](/slides/id/python-java/manage-blob/) untuk opsi penyimpanan dan manajemen memori tambahan.
{{% /alert %}}

## **Kontrol Sumber Daya Eksternal**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) menerima proxy JPype yang mengimplementasikan antarmuka callback pemuatan sumber daya Java. Callback dapat menyediakan data pengganti, mengarahkan ulang sumber daya, menggunakan loader default, atau melewati sumber daya. Ini berguna ketika presentasi berisi gambar eksternal yang harus diselesaikan sesuai aturan keamanan atau penyimpanan aplikasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Muat Presentasi tanpa Objek Biner yang Disematkan**

Sebuah presentasi mungkin berisi data biner yang disematkan yang tidak diperlukan atau tidak diinginkan oleh aplikasi. Contohnya meliputi:

- proyek VBA, tersedia melalui [Presentation.getVbaProject](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getVbaProject);
- data OLE yang disematkan, tersedia melalui [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- data kontrol ActiveX, tersedia melalui [Control.getActiveXControlBinary](https://reference.aspose.com/slides/id/python-java/aspose.slides/control/#getActiveXControlBinary).

Setel [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) ke `True` untuk menghapus data biner ini saat memuat. Simpan presentasi yang dimuat untuk mempertahankan hasil yang telah dibersihkan.

Opsi ini mengurangi paparan terhadap payload yang tidak diinginkan, tetapi bukan sistem deteksi malware atau sanitasi konten yang lengkap.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa file rusak dan tidak dapat dibuka?**

Aspose.Slides melemparkan pengecualian parsing atau format selama pemuatan. Tangani kegagalan tersebut secara terpisah dari kesalahan kata sandi yang salah sehingga aplikasi dapat melaporkan penyebabnya secara akurat.

**Apa yang terjadi jika font yang diperlukan tidak ada?**

Presentasi masih dapat dimuat, tetapi perenderan dan ekspor mungkin menggantikan font. Anda dapat [configure font substitution](/slides/id/python-java/font-substitution/) atau [provide custom fonts](/slides/id/python-java/custom-font/) untuk membuat output lebih dapat diprediksi.

**Apakah memuat presentasi juga memuat media yang disematkan?**

Audio dan video yang disematkan menjadi tersedia melalui model objek presentasi. Sumber daya eksternal diselesaikan sesuai perilaku pemuatan sumber daya yang dikonfigurasi dan mungkin tidak tersedia jika lokasinya tidak dapat diakses.