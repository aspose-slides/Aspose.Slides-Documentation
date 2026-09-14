---
title: Kelola Label Sensitivitas di Presentasi PowerPoint dengan Python
linktitle: Label Sensitivitas
type: docs
weight: 50
url: /id/python-java/sensitivity-labels/
keywords:
- label sensitivitas
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- penandaan konten
- perlindungan informasi
- pengelolaan dokumen
- PowerPoint
- PPTX
- keamanan presentasi
- Python
- Aspose.Slides
description: "Baca, tambahkan, perbarui, hapus, dan migrasi label sensitivitas Microsoft Purview dalam presentasi PowerPoint PPTX dengan Aspose.Slides untuk Python melalui Java."
---
## **Ikhtisar**

Microsoft Purview sensitivity labels membantu organisasi mengklasifikasikan dan mengelola dokumen. Selama pemrosesan presentasi otomatis, sebuah aplikasi mungkin perlu mempertahankan label yang ada, menerapkan label yang dipilih oleh kebijakan, memperbarui keadaannya, atau memigrasi metadata label yang ditulis oleh alur kerja Microsoft Information Protection (MIP) yang lebih lama.

Aspose.Slides mengekspos metadata label sensitivitas modern melalui [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSensitivityLabels). Metode ini mengembalikan sebuah [SensitivityLabelCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcollection/) yang dapat diperiksa dan diubah sebelum presentasi disimpan sebagai PPTX.

{{% alert color="info" title="Catatan" %}}

Identifier label sensitivitas dan informasi kebijakan didefinisikan oleh konfigurasi Microsoft Purview Anda. Validasi ketersediaan label dan persyaratan kebijakan di lingkungan Anda sebelum menambahkan atau memigrasi metadata. Nilai [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) menjelaskan penandaan konten yang terkait dengan label; nilai tersebut tidak secara langsung menambahkan teks atau bentuk yang terlihat ke slide.

{{% /alert %}}

## **Memahami Properti Label Sensitivitas**

Setiap [SensitivityLabel](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/) berisi metadata berikut:

| Metode | Tujuan |
| --- | --- |
| [getId](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#getId) dan [setId](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#setId) | Mendapatkan atau mengatur pengidentifikasi label sensitivitas dalam kebijakan Purview. |
| [getSiteId](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#getSiteId) dan [setSiteId](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Mendapatkan atau mengatur situs yang terkait dengan kebijakan label. |
| [isEnabled](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#isEnabled) dan [setEnabled](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Mendapatkan atau mengatur apakah label diaktifkan. |
| [isRemoved](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#isRemoved) dan [setRemoved](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Mendapatkan atau mengatur apakah label telah dihapus. Atur nilai menjadi `True` ketika status penghapusan harus dipertahankan dalam metadata. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) dan [setAssignmentMethodType](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Mendapatkan atau mengatur apakah label diterapkan secara otomatis atau melalui keputusan pengguna. |
| [getContentMarkTypes](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Mendapatkan jenis penandaan konten yang terkait dengan label. |

Kelas [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelassignmenttype/) mendefinisikan cara label diberikan:

- [Standard](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelassignmenttype/) mewakili label default atau yang diterapkan secara otomatis.
- [Privileged](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelassignmenttype/) mewakili label yang diterapkan melalui keputusan pengguna, termasuk label yang diterapkan secara manual, yang direkomendasikan, dan yang wajib.

Kelas [SensitivityLabelContentType](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcontenttype/) mendefinisikan penandaan yang terkait dengan label:

| Nilai | Makna |
| --- | --- |
| [None](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcontenttype/) | Label diterapkan secara default atau otomatis. |
| [Header](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten Header terkait dengan label. |
| [Footer](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten Footer terkait dengan label. |
| [Watermark](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten Watermark terkait dengan label. |
| [Encryption](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcontenttype/) | Perlindungan enkripsi terkait dengan label. |

Beberapa jenis penandaan dapat terkait dengan satu label.

## **Daftar Label Sensitivitas yang Ada**

Baca koleksi label modern dari [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSensitivityLabels) dan iterasi semuanya. Contoh berikut mencantumkan setiap properti dan penandaan konten yang disimpan untuk masing‑masing label:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Menambahkan Label Sensitivitas dengan Penandaan Konten**

Gunakan [SensitivityLabelCollection.add](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcollection/#add) dengan pengidentifikasi label, pengidentifikasi situs, status aktif, dan metode penugasan. Setelah metode mengembalikan [SensitivityLabel](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/) baru, tambahkan nilai penandaan yang diperlukan melalui daftar yang dikembalikan oleh [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Contoh berikut menambahkan label yang dipilih secara manual dengan penandaan footer dan watermark, kemudian menyimpan hasilnya sebagai PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Memperbarui Label Sensitivitas**

Nilai [SensitivityLabel](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/) dapat dibaca/ditulis, kecuali daftar yang dikembalikan oleh [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) yang dimodifikasi melalui operasi daftar. Setelah menemukan label yang diperlukan, Anda dapat memperbarui pengidentifikasinya, pengidentifikasi situs, status aktif, metode penugasan, status penghapusan, dan jenis penandaan konten. Simpan presentasi untuk menerapkan perubahan.

Contoh berikut memperbarui status aktif dan metode penugasan label pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menandai Label Sensitivitas sebagai Dihapus**

Untuk mempertahankan fakta bahwa sebuah label telah dihapus, temukan label tersebut dan panggil [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#setRemoved) dengan `True`. Ini mempertahankan entri label sambil mencatat status penghapusan. Jika Anda ingin menghapus entri dari koleksi modern, gunakan [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); gunakan [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcollection/#clear) untuk menghapus semua entri.

Contoh berikut menandai label tertentu sebagai dihapus dan menyimpan presentasi yang telah diperbarui:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Membaca dan Memigrasi Label Sensitivitas MIP Legacy**

Alur kerja berbasis MIP lama dapat menyimpan metadata label sensitivitas dalam properti dokumen khusus alih‑alih koleksi label modern. Baca metadata tersebut dengan [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getSensitivityLabels). Metode ini mem-parsing properti khusus legacy dan mengembalikan array objek [SensitivityLabel](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/).

Untuk memigrasi metadata, tambahkan setiap label yang dikembalikan ke [SensitivityLabelCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcollection/) modern melalui [SensitivityLabelCollection.add](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcollection/#add). Karena menambahkan label dengan pengidentifikasi duplikat akan memicu pengecualian, contoh memeriksa koleksi tujuan sebelum menyalin setiap label. Anda dapat menambahkan validasi lebih lanjut untuk memastikan setiap label legacy masih ada dalam kebijakan Purview saat ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Migrasi menyalin objek label yang diparsing ke dalam koleksi modern. Tidak diperlukan penghapusan semua properti dokumen khusus, sehingga metadata dokumen yang tidak terkait tetap utuh. Gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/) untuk menulis metadata label modern ke file PPTX.

## **FAQ**

**Apakah menambahkan jenis penandaan konten membuat header, footer, atau watermark yang terlihat pada slide?**

Tidak. Nilai yang ditambahkan melalui daftar yang dikembalikan oleh [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) menjelaskan penandaan yang terkait dengan label sensitivitas. Mereka tidak membuat teks atau bentuk yang terlihat dalam presentasi. Tambahkan konten slide yang sesuai secara terpisah jika alur kerja Anda harus menampilkan penandaan tersebut.

**Apa perbedaan antara menandai label sebagai dihapus dan menghapusnya dari koleksi?**

Memanggil [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#setRemoved) dengan `True` menjaga entri label dan mencatat status penghapusannya. Memanggil [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) menghapus entri dari koleksi modern. Pilih operasi yang sesuai dengan persyaratan retensi metadata organisasi Anda.

**Apakah sebuah presentasi dapat berisi metadata MIP legacy dan label sensitivitas modern secara bersamaan?**

Ya. Label legacy dapat tetap berada dalam properti dokumen khusus sementara label modern tersedia melalui [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSensitivityLabels). Gunakan [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#getSensitivityLabels) untuk membaca metadata legacy dan memigrasi hanya label yang valid yang belum ada dalam koleksi modern.

**Apa yang terjadi ketika label dengan pengidentifikasi yang sama ditambahkan lebih dari sekali?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabelcollection/#add) memicu pengecualian bila koleksi sudah berisi label dengan pengidentifikasi yang sama. Periksa nilai yang ada dengan [SensitivityLabel.getId](https://reference.aspose.com/slides/id/python-java/aspose.slides/sensitivitylabel/#getId) sebelum menambahkan atau memigrasi label.

**Format output mana yang harus digunakan untuk mempertahankan label sensitivitas yang diperbarui?**

Simpan presentasi sebagai PPTX dengan memanggil [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) menggunakan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/), seperti yang ditunjukkan dalam contoh di atas.