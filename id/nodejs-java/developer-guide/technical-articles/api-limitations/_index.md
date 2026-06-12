---
title: Batasan API
type: docs
weight: 320
url: /id/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ketahui batasan Aspose.Slides for Node.js: ekspor menetapkan metadata Application/Producer yang tetap pada PPT, PPTX, ODP, dan PDF—membantu Anda merencanakan integrasi tanpa kejutan."
---
## **Ikhtisar**

Ketika presentasi dibuat atau diekspor dengan Aspose.Slides, metadata teknis tertentu ditulis ke file output. Artikel ini menjelaskan batasan terkait bidang metadata `Application`, `Creator`, dan `Producer` dalam file PPTX dan PDF.

## **Aplikasi dan Produsen**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides for Node.js via Java, beberapa metadata teknis ditulis ke dalam file. Dua bidang yang sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Pada Aspose.Slides for Node.js via Java, nilai ini bersifat tetap dan menampilkan vendor perpustakaan alih‑alih nama aplikasi Anda, bahkan jika Anda menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir selama proses ekspor. Pada ekspor **PDF**, metadata menggunakan bidang **Creator** dan **Producer**. Dengan Aspose.Slides for Node.js via Java, keduanya bersifat tetap dan mencerminkan perpustakaan serta versinya.

**Apa yang dibatasi**

Anda tidak dapat mengganti bidang‑bidang ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai "Aspose.Slides for Node.js via Java". Untuk **PDF**, properti Creator dan Producer ditulis sebagai "Aspose.Slides for Node.js via Java x.x.x." Perilaku ini memang dirancang demikian dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang ditetapkan menggunakan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).