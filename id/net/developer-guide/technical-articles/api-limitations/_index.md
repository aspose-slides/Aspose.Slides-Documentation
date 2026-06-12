---
title: Batasan API
type: docs
weight: 320
url: /id/net/api-limitations/
keywords:
- Batasan API
- format ekspor
- aplikasi
- produsen
- properti dokumen
- metadata
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Ketahui batasan Aspose.Slides for .NET: ekspor menetapkan metadata Application/Producer yang tetap pada PPT, PPTX, ODP, dan PDF—membantu Anda merencanakan integrasi tanpa kejutan."
---
## **Ikhtisar**

Ketika presentasi dibuat atau diekspor dengan Aspose.Slides, metadata teknis tertentu ditulis ke file output. Artikel ini menjelaskan batasan yang terkait dengan field metadata `Application`, `Creator`, dan `Producer` dalam file PPTX dan PDF.

## **Aplikasi dan Produsen**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides for .NET, beberapa metadata teknis ditulis ke dalam file. Dua field sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Dalam Aspose.Slides for .NET, nilai ini bersifat tetap dan menampilkan vendor pustaka bukan nama aplikasi Anda, bahkan jika Anda mengatur [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/id/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir saat ekspor. Pada ekspor **PDF**, metadata menggunakan field **Creator** dan **Producer**. Dengan Aspose.Slides for .NET, keduanya bersifat tetap dan mencerminkan pustaka serta versinya.

**Apa yang dibatasi**

Anda tidak dapat mengubah field ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai "Aspose.Slides for .NET". Untuk **PDF**, properti Creator dan Producer ditulis sebagai "Aspose.Slides for .NET x.x.x". Perilaku ini memang dirancang demikian dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang diberikan ke [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/id/net/aspose.slides/documentproperties/nameofapplication/).