---
title: Batasan API
type: docs
weight: 320
url: /id/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Ketahui batasan Aspose.Slides untuk PHP: ekspor menetapkan metadata Application/Producer yang tetap pada PPT, PPTX, ODP, dan PDF—membantu Anda merencanakan integrasi tanpa kejutan."
---
## **Ringkasan**

Saat presentasi dibuat atau diekspor dengan Aspose.Slides, metadata teknis tertentu ditulis ke file output. Artikel ini menjelaskan batasan terkait bidang metadata `Application`, `Creator`, dan `Producer` dalam file PPTX dan PDF.

## **Aplikasi dan Produsen**

Saat Anda membuat atau mengekspor presentasi dengan Aspose.Slides for PHP via Java, beberapa metadata teknis ditulis ke dalam file. Dua bidang yang sering menimbulkan pertanyaan:

**Application** mengidentifikasi program yang membuat atau terakhir menyimpan presentasi **PPTX**. Pada Aspose.Slides for PHP via Java, nilai ini tetap dan menampilkan vendor perpustakaan alih‑alih nama aplikasi Anda, bahkan jika Anda menggunakan [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** mengidentifikasi mesin rendering yang menghasilkan file akhir selama ekspor. Pada ekspor **PDF**, metadata menggunakan bidang **Creator** dan **Producer**. Dengan Aspose.Slides for PHP via Java, kedua bidang ini tetap dan mencerminkan perpustakaan serta versinya.

**Apa yang dibatasi**

Anda tidak dapat menimpa bidang‑bidang ini melalui API untuk format di atas. Untuk **PPTX**, properti Application ditulis sebagai "Aspose.Slides for PHP via Java". Untuk **PDF**, properti Creator dan Producer ditulis sebagai "Aspose.Slides for PHP via Java x.x.x." Perilaku ini memang dirancang demikian dan berlaku terlepas dari cara Anda memuat atau menyimpan file, serta terlepas dari nilai yang ditetapkan menggunakan [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/setnameofapplication/).