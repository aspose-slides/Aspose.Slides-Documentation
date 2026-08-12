---
title: Kelola Label Sensitivitas dalam Presentasi PowerPoint di Python
linktitle: Label Sensitivitas
type: docs
weight: 50
url: /id/python-net/sensitivity-labels/
keywords:
- label sensitivitas
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- penandaan konten
- perlindungan informasi
- tata kelola dokumen
- PowerPoint
- PPTX
- keamanan presentasi
- Python
- Aspose.Slides
description: "Baca, tambahkan, perbarui, hapus, dan migrasikan label sensitivitas Microsoft Purview dalam presentasi PPTX PowerPoint dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Microsoft Purview sensitivity labels membantu organisasi mengklasifikasikan dan mengatur dokumen. Selama pemrosesan presentasi otomatis, sebuah aplikasi mungkin perlu mempertahankan label yang ada, menerapkan label yang dipilih oleh kebijakan, memperbarui keadaannya, atau memigrasikan metadata label yang ditulis oleh alur kerja Microsoft Information Protection (MIP) yang lebih lama.

Aspose.Slides for Python via .NET mengekspos metadata label sensitivitas modern melalui [Presentation.sensitivity_labels](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/sensitivity_labels/). Properti ini mengembalikan [SensitivityLabelCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcollection/) yang dapat diperiksa dan diubah sebelum presentasi disimpan sebagai PPTX.

{{% alert color="primary" title="Catatan" %}}
Identifier label sensitivitas dan informasi kebijakan didefinisikan oleh konfigurasi Microsoft Purview Anda. Validasi ketersediaan label dan persyaratan kebijakan di lingkungan Anda sebelum menambahkan atau memigrasikan metadata. Nilai [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/content_mark_types/) menggambarkan penandaan konten yang terkait dengan sebuah label; nilai tersebut tidak secara otomatis menambahkan teks atau bentuk yang terlihat pada slide.
{{% /alert %}}

## **Memahami Properti Label Sensitivitas**

Setiap [SensitivityLabel](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/) berisi metadata berikut:

| Properti | Tujuan |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/id/) | Mengidentifikasi label sensitivitas dalam kebijakan Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/site_id/) | Mengidentifikasi situs yang terkait dengan kebijakan label. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Menunjukkan apakah label diaktifkan. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/is_removed/) | Menunjukkan bahwa label telah dihapus. Atur properti ini ke `True` ketika status penghapusan harus dipertahankan dalam metadata. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Menentukan apakah label diterapkan secara otomatis atau melalui keputusan pengguna. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Menampilkan jenis penandaan konten yang terkait dengan label. |

Enum [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelassignmenttype/) menjelaskan cara sebuah label ditetapkan:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelassignmenttype/) mewakili label default atau yang diterapkan secara otomatis.  
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelassignmenttype/) mewakili label yang diterapkan melalui keputusan pengguna, termasuk label yang diterapkan secara manual, direkomendasikan, dan wajib.

Enum [SensitivityLabelContentType](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcontenttype/) mengidentifikasi penandaan yang terkait dengan sebuah label:

| Nilai | Makna |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcontenttype/) | Label diterapkan secara default atau otomatis. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten header terkait dengan label. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten footer terkait dengan label. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcontenttype/) | Penandaan konten watermark terkait dengan label. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcontenttype/) | Perlindungan enkripsi terkait dengan label. |

Beberapa jenis penandaan dapat terkait dengan satu label.

## **Daftar Label Sensitivitas yang Ada**

Baca koleksi label modern dari [Presentation.sensitivity_labels](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/sensitivity_labels/) dan lakukan enumerasi. Contoh berikut menampilkan setiap properti dan penandaan konten yang disimpan untuk masing‑masing label:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Menambahkan Label Sensitivitas dengan Penandaan Konten**

Gunakan [SensitivityLabelCollection.add](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcollection/add/) dengan identifier label, identifier situs, status aktif, dan metode penetapan. Berikan identifier situs sebagai objek Python `uuid.UUID`. Setelah metode mengembalikan [SensitivityLabel](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/) baru, tambahkan nilai penandaan yang diperlukan ke [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

Contoh berikut menambahkan label yang dipilih secara manual dengan penandaan footer dan watermark, kemudian menyimpan hasilnya sebagai PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Memperbarui Label Sensitivitas**

Properti [SensitivityLabel](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/) dapat dibaca/ditulis, kecuali daftar yang dikembalikan oleh [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/content_mark_types/) dimodifikasi melalui operasi daftar. Setelah menemukan label yang dibutuhkan, Anda dapat memperbarui identifier, identifier situs, status aktif, metode penetapan, status penghapusan, dan jenis penandaan konten. Simpan presentasi untuk menerapkan perubahan.

Contoh berikut memperbarui status aktif dan metode penetapan label pertama:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Menandai Label Sensitivitas sebagai Dihapus**

Untuk mempertahankan fakta bahwa sebuah label telah dihapus, temukan label tersebut dan atur [SensitivityLabel.is_removed](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/is_removed/) ke `True`. Ini mempertahankan entri label sambil mencatat statusnya yang dihapus. Jika Anda ingin menghapus entri dari koleksi modern, gunakan [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); gunakan [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcollection/clear/) untuk menghapus semua entri.

Contoh berikut menandai label tertentu sebagai dihapus dan menyimpan presentasi yang telah diperbarui:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Membaca dan Memigrasikan Label Sensitivitas MIP Legacy**

Alur kerja berbasis MIP lama dapat menyimpan metadata label sensitivitas dalam properti dokumen kustom alih‑alih koleksi label modern. Baca metadata tersebut dengan [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). Metode ini mem-parsing properti kustom legacy dan mengembalikan objek [SensitivityLabel](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/).

Untuk memigrasikan metadata, tambahkan setiap label yang dikembalikan ke [SensitivityLabelCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcollection/) modern melalui [SensitivityLabelCollection.add](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcollection/add/). Karena menambahkan identifier label duplikat memunculkan pengecualian, contoh memeriksa koleksi tujuan sebelum menyalin masing‑masing label. Anda dapat menambahkan validasi lebih lanjut untuk memastikan setiap label legacy masih ada dalam kebijakan Purview saat ini.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

Migrasi menyalin objek label yang diparse ke dalam koleksi modern. Tidak diperlukan penghapusan semua properti dokumen kustom, sehingga metadata dokumen yang tidak terkait tetap utuh. Gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) dengan [SaveFormat.PPTX](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/) untuk menulis metadata label modern ke file PPTX.

## **FAQ**

**Apakah menambahkan jenis penandaan konten membuat header, footer, atau watermark yang terlihat pada slide?**

Tidak. Nilai yang ditambahkan melalui [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/content_mark_types/) menjelaskan penandaan yang terkait dengan label sensitivitas. Nilai tersebut tidak membuat teks atau bentuk yang terlihat dalam presentasi. Tambahkan konten slide yang sesuai secara terpisah jika alur kerja Anda harus menampilkan penandaan tersebut.

**Apa perbedaan antara menandai label sebagai dihapus dan menghapusnya dari koleksi?**

Mengatur [SensitivityLabel.is_removed](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/is_removed/) ke `True` mempertahankan entri label dan mencatat status penghapusannya. Memanggil [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) menghapus entri dari koleksi modern. Pilih operasi yang sesuai dengan kebutuhan retensi metadata organisasi Anda.

**Apakah sebuah presentasi dapat berisi metadata MIP legacy dan label sensitivitas modern sekaligus?**

Ya. Label legacy dapat tetap berada di properti dokumen kustom sementara label modern tersedia melalui [Presentation.sensitivity_labels](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/sensitivity_labels/). Gunakan [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) untuk membaca metadata legacy dan memigrasikan hanya label yang valid yang belum ada di koleksi modern.

**Apa yang terjadi jika label dengan identifier yang sama ditambahkan lebih dari satu kali?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabelcollection/add/) memunculkan pengecualian ketika koleksi sudah berisi label dengan identifier yang sama. Periksa nilai [SensitivityLabel.id](https://reference.aspose.com/slides/id/python-net/aspose.slides/sensitivitylabel/id/) yang ada sebelum menambahkan atau memigrasikan label.

**Format output apa yang harus digunakan untuk mempertahankan label sensitivitas yang diperbarui?**

Simpan presentasi sebagai PPTX dengan memanggil [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) bersama [SaveFormat.PPTX](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/), seperti yang ditunjukkan pada contoh di atas.