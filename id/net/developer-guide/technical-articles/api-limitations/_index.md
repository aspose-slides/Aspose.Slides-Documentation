---
title: Batasan Metadata Output
type: docs
weight: 320
url: /id/net/api-limitations/
keywords:
- batasan API
- format ekspor
- aplikasi
- produser
- properti dokumen
- metadata
- generator
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides untuk .NET menulis metadata aplikasi, pembuat, dan produser yang tetap ke file PPTX, PDF, dan ODP yang disimpan, terlepas dari nama aplikasi yang Anda tetapkan."
---
## **Gambaran Umum**

Saat presentasi dibuat atau diekspor dengan Aspose.Slides, beberapa metadata teknis ditulis ke file output. Artikel ini menjelaskan batasan terkait bidang metadata `Application`, `Creator`, `Producer`, dan generator dalam file PPTX, PDF, dan ODP.

## **Aplikasi dan Produser**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides untuk .NET, beberapa metadata teknis ditulis ke dalam file. Dua bidang yang sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Pada Aspose.Slides untuk .NET, nilai ini bersifat tetap dan menampilkan nama pustaka alih-alih nama aplikasi Anda, bahkan jika Anda mengatur [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir selama ekspor. Pada ekspor **PDF**, metadata menggunakan bidang **Creator** dan **Producer**. Dengan Aspose.Slides untuk .NET, keduanya bersifat tetap dan mencerminkan pustaka serta versinya.

**Apa yang dibatasi**

Anda tidak dapat mengganti bidang-bidang ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai "Aspose.Slides for .NET". Untuk **PDF**, properti Creator dan Producer ditulis sebagai "Aspose.Slides for .NET" diikuti oleh versi pustaka. Untuk **ODP**, bidang generator ditulis sebagai "Aspose.Slides for .NET" diikuti oleh versi pustaka. Perilaku ini memang dirancang demikian dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang diberikan pada [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

Pembatasan ini tidak berlaku untuk file **PPT**: pada file PPT, nama aplikasi yang Anda atur di [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) disimpan.