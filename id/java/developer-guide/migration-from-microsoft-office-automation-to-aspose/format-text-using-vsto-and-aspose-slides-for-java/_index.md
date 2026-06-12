---
title: Memformat Teks Menggunakan VSTO dan Aspose.Slides untuk Java
linktitle: Format Teks
type: docs
weight: 30
url: /id/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- memformat teks
- migrasi
- VSTO
- otomatisasi Office
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Migrasi dari otomatisasi Microsoft Office ke Aspose.Slides for Java dan memformat teks dalam presentasi PowerPoint (PPT, PPTX) dengan kontrol yang tepat."
---
{{% alert color="primary" %}} 

Kadang-kadang, Anda perlu memformat teks pada slide secara programatis. Artikel ini menunjukkan cara membaca presentasi contoh dengan beberapa teks pada slide pertama menggunakan [VSTO](/slides/id/java/format-text-using-vsto-and-aspose-slides-for-java/) dan [Aspose.Slides for Java](/slides/id/java/format-text-using-vsto-and-aspose-slides-for-java/). Kode tersebut memformat teks di kotak teks ketiga pada slide agar terlihat seperti teks di kotak teks terakhir.

{{% /alert %}} 
## **Memformat Teks**
Baik metode VSTO maupun Aspose.Slides mengikuti langkah‑langkah berikut:

1. Buka presentasi sumber.
1. Akses slide pertama.
1. Akses kotak teks ketiga.
1. Ubah format teks di kotak teks ketiga.
1. Simpan presentasi ke disk.

Tangkapan layar di bawah ini menunjukkan slide contoh sebelum dan sesudah menjalankan kode VSTO dan Aspose.Slides for Java.

**Presentasi input** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Contoh Kode VSTO**
Kode di bawah ini menunjukkan cara memformat ulang teks pada slide menggunakan VSTO.

**Teks yang diformat ulang dengan VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}

### **Contoh Aspose.Slides for Java**
Untuk memformat teks dengan Aspose.Slides, tambahkan font sebelum memformat teks.

**Presentasi keluaran yang dibuat dengan Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}