---
title: Mengonversi Presentasi PowerPoint ke XPS dalam Python
linktitle: PowerPoint ke XPS
type: docs
weight: 70
url: /id/python-java/convert-powerpoint-to-xps/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi PPT
- konversi PPTX
- PowerPoint ke XPS
- presentasi ke XPS
- PPT ke XPS
- PPTX ke XPS
- simpan PPT sebagai XPS
- simpan PPTX sebagai XPS
- ekspor PPT ke XPS
- ekspor PPTX ke XPS
- Python
- Java
- Aspose.Slides
description: "Konversi presentasi PowerPoint PPT dan PPTX ke XPS dalam Python menggunakan Aspose.Slides untuk Python via Java, dengan pengaturan ekspor default atau kustom."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java memungkinkan Anda mengonversi presentasi PowerPoint ke XPS dengan menyimpan file PPT atau PPTX dalam format XPS. Artikel ini menjelaskan kapan XPS berguna dan menunjukkan cara mengekspor presentasi menggunakan pengaturan default atau pengaturan [XpsOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xpsoptions/) khusus.

## **Tentang XPS**

XPS (XML Paper Specification) adalah format dokumen berbasis XML yang dikembangkan oleh Microsoft. Format ini menggambarkan halaman tetap, mempertahankan tata letak teks dan grafis untuk tampilan serta pencetakan dengan perangkat lunak yang kompatibel.

## **Kapan Menggunakan Format Microsoft XPS**

Gunakan XPS ketika alur kerja dokumen memerlukan file berlayout tetap untuk berbagi atau mencetak melalui alat yang kompatibel dengan XPS. Penerima memerlukan perangkat lunak yang mendukung XPS. Jika alur kerja Anda memerlukan PDF, lihat [Convert PowerPoint to PDF](/slides/id/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Untuk mencoba mengonversi presentasi PPT atau PPTX ke XPS, gunakan [konverter online gratis](https://products.aspose.app/slides/id/conversion).
{{% /alert %}}

| Presentasi PowerPoint input | Dokumen XPS output |
| --- | --- |
| ![Presentasi PowerPoint asli](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Presentasi yang dikonversi ke XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Konversi XPS dengan Aspose.Slides**

Gunakan metode [save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) pada kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dengan [SaveFormat.Xps](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Xps) untuk mengekspor presentasi. Anda dapat menggunakan pengaturan ekspor default atau menyediakan [XpsOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xpsoptions/) untuk menyesuaikan output.

Setiap contoh di bawah ini memulai mesin virtual Java bila diperlukan dan melepaskan presentasi setelah penggunaan. Ganti nama file input dengan path ke file PPT atau PPTX Anda.

### **Mengonversi Presentasi ke XPS Menggunakan Pengaturan Default**

Kode Python berikut mengonversi presentasi ke XPS menggunakan pengaturan default:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Simpan presentasi sebagai dokumen XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Mengonversi Presentasi ke XPS Menggunakan Pengaturan Kustom**

Contoh berikut menggunakan [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/id/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) untuk menyimpan metafile sebagai gambar PNG dalam dokumen XPS yang dihasilkan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Simpan presentasi dengan pengaturan XPS khusus.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Bisakah saya menyimpan XPS ke stream alih-alih file?**

Ya. Metode [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) memiliki overload yang menerima stream output Java. Dengan Python via Java, gunakan stream Java yang kompatibel melalui JPype, seperti Java byte‑array output stream, untuk menyimpan data yang diekspor di memori.

**Apakah slide tersembunyi disertakan dalam output XPS?**

Slide tersembunyi tidak disertakan secara default. Untuk menyertakannya, setel [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) ke `True` sebelum menyimpan.

**Apakah animasi dan transisi slide dipertahankan dalam XPS?**

Tidak. XPS berisi halaman tetap, sehingga slide yang diekspor tidak memutar animasi atau efek transisi.