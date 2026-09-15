---
title: Batasan API
type: docs
weight: 320
url: /id/python-java/api-limitations/
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
- Java
- Aspose.Slides
description: "Pelajari tentang batasan Aspose.Slides for Python via Java: metadata Application, Creator, dan Producer yang tetap pada file PPTX dan PDF."
---
## **Ikhtisar**

Ketika presentasi dibuat atau diekspor dengan Aspose.Slides, sejumlah metadata teknis ditulis ke file keluaran. Artikel ini menjelaskan batasan yang terkait dengan bidang metadata `Application`, `Creator`, dan `Producer` dalam file PPTX dan PDF.

## **Aplikasi dan Produser**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides for Python via Java, beberapa metadata teknis ditulis ke dalam file. Dua bidang sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Dalam Aspose.Slides for Python via Java, nilai ini tetap dan menampilkan vendor perpustakaan alih‑alih nama aplikasi Anda, bahkan jika Anda menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir selama ekspor. Dalam ekspor **PDF**, metadata menggunakan bidang **Creator** dan **Producer**. Dengan Aspose.Slides for Python via Java, kedua bidang ini tetap dan mencerminkan perpustakaan serta versinya.

**Apa yang Dibatasi**

Anda tidak dapat mengganti bidang‑bidang ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai "Aspose.Slides for Java". Untuk **PDF**, properti Creator dan Producer ditulis sebagai "Aspose.Slides for Java x.x.x." Perilaku ini memang dirancang demikian dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang ditetapkan menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **FAQ**

**Apakah saya dapat mengganti nilai Application dalam file PPTX dengan nama aplikasi saya?**

Tidak. Nilainya tetap, bahkan jika Anda menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Apakah saya dapat menimpa bidang Creator dan Producer dalam ekspor PDF?**

Tidak. Kedua bidang tersebut tetap dan mencerminkan perpustakaan serta versinya, terlepas dari cara Anda memuat atau menyimpan presentasi.