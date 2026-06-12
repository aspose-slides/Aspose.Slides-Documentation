---
title: Batasan API
type: docs
weight: 320
url: /id/cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "Ketahui batasan Aspose.Slides for C++: ekspor menetapkan metadata Aplikasi/Produsen yang tetap pada PPT, PPTX, ODP, dan PDF—membantu Anda merencanakan integrasi tanpa kejutan."
---
## **Ikhtisar**

Saat presentasi dibuat atau diekspor dengan Aspose.Slides, metadata teknis tertentu ditulis ke file output. Artikel ini menjelaskan batasan yang terkait dengan bidang metadata `Application`, `Creator`, dan `Producer` di file PPTX dan PDF.

## **Application dan Producer**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides for C++, beberapa metadata teknis ditulis ke dalam file. Dua bidang sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Pada Aspose.Slides for C++, nilai ini bersifat tetap dan menampilkan vendor pustaka alih‑alih nama aplikasi Anda, bahkan jika Anda menggunakan [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/id/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir selama ekspor. Pada ekspor **PDF**, metadata menggunakan bidang **Creator** dan **Producer**. Dengan Aspose.Slides for C++, keduanya bersifat tetap dan mencerminkan pustaka serta versinya.

**Apa yang dibatasi**

Anda tidak dapat mengganti bidang‑bidang ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai "Aspose.Slides for C++". Untuk **PDF**, properti Creator dan Producer ditulis sebagai "Aspose.Slides for C++ x.x.x". Perilaku ini memang dirancang begitu dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang ditetapkan menggunakan [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/id/cpp/aspose.slides/documentproperties/set_nameofapplication/).