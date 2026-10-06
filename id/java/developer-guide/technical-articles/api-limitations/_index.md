---
title: Batasan Metadata Output
type: docs
weight: 320
url: /id/java/api-limitations/
keywords:
- batasan API
- format ekspor
- aplikasi
- produsen
- properti dokumen
- metadata
- generator
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Aspose.Slides for Java menulis metadata aplikasi, pencipta, dan produsen yang tetap ke file PPTX, PDF, dan ODP yang disimpan, terlepas dari nama aplikasi yang Anda tetapkan."
---
## **Ringkasan**

Saat presentasi dibuat atau diekspor dengan Aspose.Slides, metadata teknis tertentu ditulis ke file output. Artikel ini menjelaskan batasan terkait bidang metadata `Application`, `Creator`, `Producer`, dan generator dalam file PPTX, PDF, dan ODP.

## **Application dan Producer**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides for Java, beberapa metadata teknis ditulis ke dalam file. Dua bidang yang sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Dalam Aspose.Slides for Java, nilai ini bersifat tetap dan menampilkan nama perpustakaan alih‑alih nama aplikasi Anda, bahkan jika Anda menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir selama ekspor. Pada ekspor **PDF**, metadata menggunakan bidang **Creator** dan **Producer**. Dengan Aspose.Slides for Java, keduanya bersifat tetap dan mencerminkan perpustakaan serta versinya.

**Apa yang dibatasi**

Anda tidak dapat mengganti bidang‑bidang ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai "Aspose.Slides for Java". Untuk **PDF**, properti Creator dan Producer ditulis sebagai "Aspose.Slides for Java" diikuti versi perpustakaan. Untuk **ODP**, bidang generator ditulis sebagai "Aspose.Slides for Java" diikuti versi perpustakaan. Perilaku ini sengaja dirancang dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang ditetapkan menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Batasan ini tidak berlaku untuk file **PPT**: pada file PPT, nama aplikasi yang Anda atur dengan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) disimpan.