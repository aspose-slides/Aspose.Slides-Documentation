---
title: Batasan API
type: docs
weight: 320
url: /id/androidjava/api-limitations/
keywords:
- batasan API
- format ekspor
- aplikasi
- produser
- properti dokumen
- metadata
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Ketahui batasan Aspose.Slides for Android: ekspor menetapkan metadata Application/Producer yang tetap di PPT, PPTX, ODP, dan PDF—membantu Anda merencanakan integrasi tanpa kejutan."
---
## **Ikhtisar**

Ketika presentasi dibuat atau diekspor dengan Aspose.Slides, metadata teknis tertentu ditulis ke file output. Artikel ini menjelaskan batasan yang terkait dengan bidang metadata `Application`, `Creator`, dan `Producer` dalam file PPTX dan PDF.

## **Application dan Producer**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides for Android via Java, beberapa metadata teknis ditulis ke dalam file. Dua bidang yang sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Dalam Aspose.Slides for Android via Java, nilai ini bersifat tetap dan menampilkan vendor perpustakaan bukan nama aplikasi Anda, bahkan bila Anda menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir saat ekspor. Pada ekspor **PDF**, metadata menggunakan bidang **Creator** dan **Producer**. Dengan Aspose.Slides for Android via Java, keduanya bersifat tetap dan mencerminkan perpustakaan serta versinya.

**Apa yang dibatasi**

Anda tidak dapat menimpa bidang-bidang ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai "Aspose.Slides for Android via Java". Untuk **PDF**, properti Creator dan Producer ditulis sebagai "Aspose.Slides for Android via Java x.x.x.". Perilaku ini memang dirancang demikian dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang ditetapkan menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).