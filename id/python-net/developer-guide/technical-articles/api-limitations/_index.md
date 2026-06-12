---
title: Batasan API
type: docs
weight: 210
url: /id/python-net/api-limitations/
keywords:
- Batasan API
- format ekspor
- aplikasi
- produser
- properti dokumen
- metadata
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Ketahui batasan Aspose.Slides untuk Python: ekspor menetapkan metadata Application/Producer yang tetap dalam PPT, PPTX, ODP, dan PDF—membantu Anda merencanakan integrasi tanpa kejutan."
---
## **Ikhtisar**

Ketika presentasi dibuat atau diekspor dengan Aspose.Slides, sejumlah metadata teknis ditulis ke file output. Artikel ini menjelaskan batasan terkait bidang metadata `Application`, `Creator`, dan `Producer` dalam file PPTX dan PDF.

## **Application dan Producer**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides for Python via .NET, beberapa metadata teknis ditulis ke dalam file. Dua bidang yang sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Dalam Aspose.Slides for Python via .NET, nilai ini tetap dan menampilkan vendor pustaka alih‑alih nama aplikasi Anda, bahkan jika Anda mengatur [DocumentProperties.name_of_application](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir saat ekspor. Pada ekspor **PDF**, metadata menggunakan bidang **Creator** dan **Producer**. Dengan Aspose.Slides for Python via .NET, kedua bidang ini tetap dan mencerminkan pustaka serta versinya.

**Apa yang dibatasi**

Anda tidak dapat menimpa bidang‑bidang ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai “Aspose.Slides for Python via .NET”. Untuk **PDF**, properti Creator dan Producer ditulis sebagai “Aspose.Slides for Python via .NET x.x.x”. Perilaku ini memang dirancang demikian dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang diberikan kepada [DocumentProperties.name_of_application](https://reference.aspose.com/slides/id/python-net/aspose.slides/documentproperties/name_of_application/).