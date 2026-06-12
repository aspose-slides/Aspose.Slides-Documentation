---
title: Multithreading di Aspose.Slides untuk PHP via Java
linktitle: Multithreading
type: docs
weight: 310
url: /id/php-java/multithreading/
keywords:
- multithreading
- beberapa thread
- pekerjaan paralel
- mengonversi slide
- slide ke gambar
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Multithreading Aspose.Slides untuk PHP via Java meningkatkan pemrosesan PowerPoint dan OpenDocument. Temukan praktik terbaik untuk alur kerja presentasi yang efisien."
---
## **Pendahuluan**

Meskipun pekerjaan paralel dengan presentasi memungkinkan (selain parsing/memuat/menyalin) dan biasanya berjalan lancar (kebanyakan waktu), ada kemungkinan kecil Anda mendapatkan hasil yang tidak tepat ketika menggunakan perpustakaan ini dalam beberapa thread.

Kami sangat menyarankan agar Anda **tidak** menggunakan satu instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dalam lingkungan multi-threading karena dapat menghasilkan kesalahan atau kegagalan yang tidak dapat diprediksi dan sulit dideteksi.

Tidak **aman** untuk memuat, menyimpan, dan/atau menyalin sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dalam beberapa thread. Operasi semacam itu **tidak** didukung. Jika Anda perlu melakukan tugas tersebut, Anda harus memparalelkan operasi dengan menggunakan beberapa proses single-threaded - dan setiap proses tersebut harus menggunakan instance presentasinya masing-masing.

Kami tidak menjamin multithreading di PHP saat menggunakan ekstensi. Jika Anda menggunakannya, lakukan dengan risiko Anda sendiri.

## **FAQ**

**Apakah saya harus memanggil penyiapan lisensi di setiap thread?**

Tidak. Cukup lakukan sekali per proses/domain aplikasi sebelum thread dimulai. Jika [penyiapan lisensi](/slides/id/php-java/licensing/) mungkin dipanggil bersamaan (misalnya, selama inisialisasi lambat), sinkronkan pemanggilan tersebut karena metode penyiapan lisensi sendiri tidak thread-safe.

**Bisakah saya mengirim objek `Presentation` atau `Slide` antar thread?**

Mengirim objek presentasi "hidup" antar thread tidak disarankan: gunakan instance terpisah per thread atau buat sebelumnya presentasi/kontainer slide terpisah untuk setiap thread. Pendekatan ini mengikuti rekomendasi umum untuk tidak berbagi satu instance presentasi di seluruh thread.

**Apakah aman memparalelkan ekspor ke format berbeda (PDF, HTML, gambar) dengan setiap thread memiliki instance `Presentation` masing-masing?**

Ya. Dengan instance independen dan jalur output terpisah, tugas semacam itu biasanya dapat diparalelkan dengan benar; hindari objek presentasi bersama dan aliran I/O bersama.

**Apa yang harus saya lakukan dengan pengaturan font global (folder, substitusi) dalam multithreading?**

Inisialisasi semua [pengaturan font](/slides/id/php-java/powerpoint-fonts/) global sebelum memulai thread dan jangan ubah selama pekerjaan paralel. Ini menghilangkan kondisi balapan saat mengakses sumber daya font bersama.