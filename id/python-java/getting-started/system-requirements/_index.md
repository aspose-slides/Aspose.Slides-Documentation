---
title: Persyaratan Sistem
type: docs
weight: 60
url: /id/python-java/system-requirements/
keywords:
- persyaratan sistem
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Periksa persyaratan sistem operasi, Python, Java, dan JPype untuk menjalankan Aspose.Slides for Python via Java di Windows, Linux, dan macOS."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java membuat, memodifikasi, mengonversi, dan merender presentasi tanpa harus menginstal Microsoft PowerPoint. Ia menggunakan JPype untuk mengakses pustaka Java dari Python, sehingga lingkungan harus mendukung Python, Java, dan JPype bersama‑sama.

## **Sistem Operasi yang Didukung**

The [Aspose.Slides package](https://pypi.org/project/aspose-slides-java/) mendukung keluarga sistem operasi berikut:

- Windows
- Linux
- macOS

Pilih versi sistem operasi yang didukung oleh rilis Python, Java, dan JPype yang Anda pilih. Ketersediaan Java saja tidak menjamin kompatibilitas dengan paket Python dan jembatannya.

## **Persyaratan Python, Java, dan JPype**

| Komponen | Persyaratan |
| --- | --- |
| Python | Paket Aspose.Slides menyatakan dukungan untuk Python 3.7 hingga 3.14. Rilis JPype yang dipilih harus mendukung versi Python yang sama; misalnya, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) memerlukan Python 3.8 atau lebih baru. |
| Java | Instal runtime Java atau JDK yang kompatibel dengan rilis JPype yang dipilih. [Prasyarat JPype](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) saat ini menentukan Java 11 atau lebih baru. Java 8 tidak dapat menjalankan JPype1 1.7.1. |
| JPype | Instal paket JPype1 untuk interpreter Python Anda, sistem operasi, dan arsitektur CPU. |
| Arsitektur CPU | Python dan Java Virtual Machine (JVM) harus menggunakan arsitektur yang cocok. Misalnya, interpreter Python 64-bit memerlukan JVM 64-bit yang kompatibel. |

Pada Apple Silicon, Python dan Java harus keduanya menggunakan ARM64 atau keduanya menggunakan x64. JVM yang berjalan secara mandiri masih dapat gagal dimuat melalui JPype bila arsitekturnya berbeda dengan Python.

Untuk lingkungan baru, Python 3.12, JDK 17, dan JPype1 1.7.1 merupakan titik awal yang cocok. Kombinasi ini telah diverifikasi dengan Aspose.Slides for Python via Java 26.6.0 pada Windows. Kombinasi lain harus memenuhi persyaratan semua tiga komponen.

Untuk penyiapan lingkungan dan contoh verifikasi yang berfungsi, lihat [Installation](/slides/id/python-java/installation/).

## **Ketergantungan Tambahan**

Roda JPype pra‑bangun yang kompatibel tidak memerlukan kompiler C++. Jika JPype harus dibangun dari sumber, instal kompiler C++ yang kompatibel dan berkas pengembangan Python yang diperlukan oleh platform Anda. Lihat [JPype installation instructions](https://jpype.readthedocs.io/en/latest/install.html) untuk persyaratan pembangunan dan pemecahan masalah.

## **Tanya Jawab**

**Apakah saya perlu menginstal Microsoft PowerPoint?**

Tidak. Aspose.Slides memproses presentasi secara terpisah dari PowerPoint. Python, Java, dan JPype tetap diperlukan.

**Apakah saya dapat menggunakan Python 3.7 dengan rilis JPype apa pun?**

Tidak. Meskipun paket Aspose.Slides menyatakan dukungan untuk Python 3.7, JPype1 1.7.1 memerlukan Python 3.8 atau lebih baru. Pilih versi yang persyaratannya saling tumpang tindih.

**Apakah saya dapat mencampur Python 32-bit dengan Java 64-bit?**

Tidak. JPype memuat JVM ke dalam proses Python, sehingga Python dan Java harus memiliki arsitektur yang cocok. Persyaratan yang sama berlaku untuk ARM64 dan x64 pada macOS.