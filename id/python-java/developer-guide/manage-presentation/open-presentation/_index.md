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
description: "Pelajari cara membuka presentasi PowerPoint dan OpenDocument di Python via Java, menyediakan kata sandi pembuka, mengontrol pemuatan sumber daya, dan mengurangi penggunaan memori dengan Aspose.Slides for Python via Java."
---
## **Pendahuluan**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/id/python-java/) dapat memuat presentasi PowerPoint dan OpenDocument dari file dan aliran. Setelah presentasi dimuat, Anda dapat memeriksa strukturnya, mengedit slide, mengelola sumber daya, dan menyimpannya dalam format asli atau format lain yang didukung.

Perilaku pemuatan dapat disesuaikan melalui kelas [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/). Misalnya, Anda dapat menyediakan kata sandi pembuka, menyimpan objek biner besar di luar memori heap Java, mengontrol sumber daya eksternal, atau menghilangkan data biner yang disematkan.

## **Buka Presentasi**

Untuk membuka presentasi yang ada, berikan jalur file ke konstruktor [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/). Buang (dispose) presentasi setelah selesai agar pegangan file, data sementara, dan sumber daya lainnya segera dibebaskan.

Contoh Python berikut memperlihatkan cara membuka presentasi dan mendapatkan jumlah slide:

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

Kata sandi pembuka mengenkripsi konten presentasi. Untuk memuat seluruh presentasi, berikan kata sandi yang benar ke [LoadOptions.setPassword](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setPassword) dan sediakan opsi ke konstruktor [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/). Pemuatan gagal bila kata sandi tidak diberikan atau salah.

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

Untuk deteksi kata sandi, validasi, dan alur kerja enkripsi, lihat [Password‑Protect Presentations](/slides/id/python-java/password-protected-presentation/). Jika presentasi terenkripsi disimpan secara sengaja dengan properti dokumen publik, properti tersebut dapat dibaca tanpa kata sandi; lihat [Manage Presentation Properties](/slides/id/python-java/presentation-properties/).

## **Buka Presentasi Besar**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) mengembalikan opsi yang mengatur cara Aspose.Slides menangani objek biner besar seperti gambar, audio, dan video. Anda dapat mengunci file sumber, memperbolehkan file sementara, dan membatasi jumlah data BLOB yang dipertahankan dalam memori.

Kode Python berikut menunjukkan cara memuat presentasi besar (misalnya, 2 GB):

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

{{% alert color="info" title="Catatan" %}}

Dengan [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked), file sumber tetap terkunci hingga instansi presentasi dibuang. Jangan memindahkan, menimpa, atau menghapus file sumber selama instansi tersebut masih hidup.

Aspose.Slides dapat menyalin isi aliran masukan saat memuatnya. Untuk presentasi besar, jalur file biasanya lebih efisien daripada aliran. Lihat [Manage BLOBs](/slides/id/python-java/manage-blob/) untuk opsi penyimpanan dan pengelolaan memori tambahan.

{{% /alert %}}

## **Kontrol Sumber Daya Eksternal**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) menerima proksi JPype yang mengimplementasikan antarmuka callback pemuatan sumber daya Java. Callback dapat menyediakan data pengganti, mengarahkan ulang sumber daya, menggunakan pemuat default, atau melewatkan sumber daya. Ini berguna ketika presentasi berisi gambar eksternal yang harus diselesaikan sesuai aturan keamanan atau penyimpanan khusus aplikasi.

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

## **Muat Presentasi tanpa Objek Biner Tertanam**

Presentasi dapat berisi data biner tertanam yang tidak diperlukan atau tidak ingin dipertahankan oleh aplikasi. Contohnya:

- proyek VBA, tersedia melalui [Presentation.getVbaProject](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getVbaProject);
- data OLE tertanam, tersedia melalui [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- data kontrol ActiveX, tersedia melalui [Control.getActiveXControlBinary](https://reference.aspose.com/slides/id/python-java/aspose.slides/control/#getActiveXControlBinary).

Setel [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) ke `True` untuk menghapus data biner ini saat memuat. Simpan presentasi yang telah dimuat untuk mempertahankan hasil yang telah dibersihkan.

Opsi ini mengurangi ekspos terhadap payload tertanam yang tidak diinginkan, tetapi bukan sistem deteksi malware atau sanitasi konten yang lengkap.

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

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Aspose.Slides melemparkan pengecualian parsing atau format saat memuat. Tangani kegagalan tersebut secara terpisah dari kesalahan kata sandi yang salah agar aplikasi dapat melaporkan penyebabnya secara akurat.

**Apa yang terjadi jika font yang dibutuhkan tidak ada?**

Presentasi masih dapat dimuat, tetapi rendering dan ekspor mungkin mengganti font. Anda dapat [mengonfigurasi substitusi font](/slides/id/python-java/font-substitution/) atau [menyediakan font khusus](/slides/id/python-java/custom-font/) untuk membuat output lebih dapat diprediksi.

**Apakah memuat presentasi juga memuat media yang tertanam?**

Audio dan video yang tertanam menjadi tersedia melalui model objek presentasi. Sumber daya eksternal diselesaikan sesuai perilaku pemuatan sumber daya yang dikonfigurasi dan mungkin tidak tersedia bila lokasinya tidak dapat diakses.