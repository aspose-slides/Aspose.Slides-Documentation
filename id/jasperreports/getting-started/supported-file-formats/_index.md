---
title: Format File yang Didukung
type: docs
weight: 20
url: /id/jasperreports/supported-file-formats/
description: "Lihat apa yang diterima Aspose.Slides for JasperReports sebagai input dan format file apa yang digunakannya untuk mengekspor laporan."
---
## **Input**

Aspose.Slides for JasperReports mengekspor laporan; tidak mengonversi presentasi yang ada. Ekspornya menerima laporan JasperReports yang sudah terisi (`JasperPrint`), seperti hasil dari `JasperFillManager` atau laporan terisi yang dimuat dari file *.jrprint*.

## **Format Output**

Tabel berikut mencantumkan format yang diekspor oleh Aspose.Slides for JasperReports, serta kelas ekspor yang menulis masing‑masing.

|**Format**|**Deskripsi**|**Ekspor**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentasi PowerPoint 97–2003; satu slide per halaman laporan|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentasi PowerPoint (Office Open XML); satu slide per halaman laporan|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; satu halaman PDF per halaman laporan|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Satu file HTML dengan satu gambar SVG per halaman laporan|`ASHtmlExporter`|

Tidak ada ekspor untuk format slide show PPS dan PPSX. Memberi ekspor PPTX nama file *.ppsx* tetap menghasilkan presentasi PPTX, bukan slide show. Untuk melihat cara penggunaan tiap ekspor, lihat [Ekspor PPT, PPTX, PDF, dan HTML](/slides/id/jasperreports/ppt-pptx-pdf-and-html-export/).