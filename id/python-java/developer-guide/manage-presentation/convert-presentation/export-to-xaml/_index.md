---
title: Ekspor Presentasi ke XAML dalam Python via Java
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/python-java/export-to-xaml/
keywords:
- ekspor PowerPoint
- ekspor OpenDocument
- ekspor presentasi
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- PowerPoint ke XAML
- OpenDocument ke XAML
- presentasi ke XAML
- PPT ke XAML
- PPTX ke XAML
- ODP ke XAML
- simpan PPT sebagai XAML
- simpan PPTX sebagai XAML
- simpan ODP sebagai XAML
- ekspor PPT ke XAML
- ekspor PPTX ke XAML
- ekspor ODP ke XAML
- Python
- Java
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke XAML dengan Aspose.Slides untuk Python via Java. Gunakan opsi default atau sertakan slide tersembunyi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint dan OpenDocument ke XAML menggunakan Aspose.Slides untuk Python via Java. Artikel ini memperkenalkan XAML, memperlihatkan cara mengekspor dengan pengaturan default, dan mendemonstrasikan cara menyertakan slide tersembunyi dengan [XamlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/).

Contoh-contoh memerlukan Aspose.Slides untuk Python via Java dan runtime Java yang kompatibel. Letakkan `pres.pptx` di direktori kerja saat ini. Setiap contoh memulai JVM hanya jika belum berjalan.

## **Tentang XAML**

XAML (Extensible Application Markup Language) adalah bahasa berbasis XML untuk mendeskripsikan antarmuka pengguna. Bahasa ini digunakan oleh kerangka kerja seperti Windows Presentation Foundation (WPF). Anda dapat membuat dan mengedit XAML dengan desainer visual atau editor teks.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Buat sebuah [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dari file masukan, kemudian berikan [XamlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/) ke [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) untuk mengekspor dengan pengaturan default:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Gunakan [XamlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/) untuk mengkonfigurasi ekspor. Untuk menyertakan slide tersembunyi, panggil [setExportHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) dengan `True` sebelum menyimpan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Bagaimana saya dapat memilih font fallback ketika font asli tidak tersedia?**

Gunakan [setDefaultRegularFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) pada objek [XamlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/) Anda untuk menentukan font fallback. Pastikan font yang dipilih tersedia di lingkungan ekspor.

**Apakah saya dapat menggunakan markup yang diekspor di kerangka kerja XAML mana pun?**

Kerangka kerja XAML berbeda dalam elemen dan fitur yang didukung. Uji markup yang diekspor di kerangka kerja target Anda sebelum mengintegrasikannya ke dalam aplikasi.

**Apakah slide tersembunyi diekspor secara default?**

Tidak. Untuk menyertakannya, panggil [setExportHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) dengan `True`. Biarkan tetap `False` untuk mengecualikannya.