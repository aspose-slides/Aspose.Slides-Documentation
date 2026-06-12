---
title: Keterbatasan API
type: docs
weight: 320
url: /id/java/api-limitations/
keywords:
- Keterbatasan API
- format ekspor
- aplikasi
- produsen
- properti dokumen
- metadata
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Ketahui batasan Aspose.Slides for Java: ekspor menetapkan metadata Application/Producer yang tetap pada PPT, PPTX, ODP, dan PDF—membantu Anda merencanakan integrasi tanpa kejutan."
---
## **Ikhtisar**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides for Java, beberapa metadata teknis ditulis ke dalam file. Dua bidang sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Pada Aspose.Slides for Java, nilai ini bersifat tetap dan menampilkan vendor perpustakaan alih‑alih nama aplikasi Anda, bahkan jika Anda menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir saat ekspor. Pada ekspor **PDF**, metadata menggunakan bidang **Creator** dan **Producer**. Dengan Aspose.Slides for Java, keduanya bersifat tetap dan mencerminkan perpustakaan serta versinya.

**Apa yang dibatasi**

Anda tidak dapat menimpa bidang‑bidang ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai "Aspose.Slides for Java". Untuk **PDF**, properti Creator dan Producer ditulis sebagai "Aspose.Slides for Java x.x.x." Perilaku ini memang dirancang demikian dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang ditetapkan menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).