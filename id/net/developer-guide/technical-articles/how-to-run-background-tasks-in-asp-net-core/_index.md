---
title: Cara Menjalankan Tugas Latar Belakang di ASP.NET Core
type: docs
weight: 300
url: /id/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- tugas latar belakang
- pemrosesan latar belakang
- layanan terhosting
- pekerja latar belakang
- antrian pekerjaan
- penjadwalan pekerjaan asynchronous
- pemrosesan file sisi server
- pelacakan kemajuan
- polling status
- notifikasi SignalR
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- arsitektur skalabel
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Jalankan tugas latar belakang di ASP.NET Core dengan Hosted Services, antrian pekerjaan, dan pembaruan status – proses dan konversi PPT, PPTX, dan ODP menggunakan Aspose.Slides."
---
## **Pendahuluan**

Pemrosesan file (mis., mengekspor presentasi ke PDF) adalah tugas tipikal sisi server. Menjalankannya di dalam penangkap permintaan (saat klien menunggu) memiliki kelemahan berikut:

- *UI yang buruk.* Halaman membeku dan pengguna harus menunggu hasilnya. Memuat ulang halaman membatalkan tugas.
- *Timeout operasi.* Kami tidak dapat memastikan bahwa pemrosesan akan selesai dalam periode tetap, sehingga pengguna kemungkinan melihat "operation timeout".
- *Rendemen dan skalabilitas rendah.* ASP.NET Core dirancang untuk memproses banyak permintaan secara asynchronous. Tugas yang CPU-bound dan berjalan lama memblokir thread dan mengurangi rendemen server.
- *Toleransi kesalahan yang buruk.* Jika ada yang salah selama tugas yang berjalan lama (mis., masalah konektivitas), pemrosesan gagal dan harus dimulai kembali dari awal.

Sebuah [pendekatan yang lebih baik](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests) adalah menjadwalkan pekerjaan secara asynchronous, memprosesnya di latar belakang, dan mengembalikan hasil ketika siap.

Dalam model ini, pengguna dapat melihat status saat ini (dan dapat meninggalkan atau memuat ulang halaman), sumber daya server dapat diskalakan secara efisien dan disetel secara fleksibel, serta kebijakan percobaan ulang dapat diterapkan.

Sebuah solusi pemrosesan latar belakang tipikal meliputi:

1. Sebuah API untuk menjadwalkan pekerjaan.
1. Sebuah API untuk melacak status pekerjaan.
1. Sebuah pekerja latar belakang untuk memproses pekerjaan yang dijadwalkan.
1. Sebuah API untuk menyimpan dan mengambil hasil.

## **Contoh Tugas Latar Belakang**

Untuk mendemonstrasikan pendekatan ini, pertimbangkan [aplikasi web contoh ASP.NET Core 3.1](./BackgroundJobDemo.zip). Aplikasi tersebut menyertakan halaman dimana pengguna dapat mengunggah presentasi dan mengklik **Export to PDF**; presentasi kemudian diunggah dan dikonversi ke PDF oleh pekerja latar belakang.

## **Aplikasi Web**

Aplikasi web contoh (proyek *BackgroundJobDemo*) menyertakan:

- Halaman unggah file (halaman Razor "Upload").
- Halaman progres (halaman Razor "Progress" dengan beberapa fungsi JavaScript yang memeriksa dan menampilkan status).
- Pengontrol (`JobStatusController`) yang menyediakan status pemrosesan (`api/status/{jobId}`).
- Pengontrol (`JobResultController`) yang mengembalikan file PDF yang diekspor (`api/result/{id}`).
- Pekerja latar belakang berbasis layanan hosting ASP.NET Core (lihat kelas `WorkerService`).

Halaman Razor, pengontrol, dan pekerja latar belakang mendelegasikan pekerjaan sebenarnya melalui antarmuka yang didefinisikan dalam proyek *BackgroundJobDemo.Common*. Implementasi konkrit dari manajemen pekerjaan dan pemrosesan disediakan dalam proyek terpisah (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws*, dll.) dan dapat diganti dalam metode `Startup.ConfigureServices`.

Untuk tujuan demo, halaman "Upload" menggunakan binding model terbuffer, tetapi untuk unggahan file besar, streaming tidak terbuffer [direkomendasikan](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Untuk produksi, pertimbangkan [aspek keamanan](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations) yang relevan. Halaman "Progress" melakukan polling status pekerjaan yang dijadwalkan via JavaScript setiap dua detik (interval ini dapat dikonfigurasi). Polling adalah hal umum, tetapi untuk skenario yang lebih maju Anda mungkin memerlukan notifikasi real-time via WebSockets (komunikasi real-time berada di luar ruang lingkup artikel ini). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) adalah alat yang sederhana namun kuat untuk komunikasi real-time.

Menjalankan pekerja latar belakang dalam proses server nyaman untuk aplikasi sederhana tetapi memiliki [kerugian](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Pendekatan yang lebih kuat dan skalabel adalah menyebarkan pekerja dalam proses terpisah (lihat, mis., aplikasi konsol *BackgroundJobDemo.Worker*).

## **Implementasi Dasar**

Proyek *BackgroundJobDemo.Local* menyediakan implementasi manajemen pekerjaan sederhana menggunakan basis data SQLite (jalur basis data dikonfigurasi melalui `LocalConfig.DbFilePath`; lihat `Startup.ConfigureServices`). File yang diunggah dan diproses disimpan di sistem berkas (jalur folder penyimpanan dikonfigurasi melalui `LocalConfig.FileStorageFolderPath`; lihat `Startup.ConfigureServices`). Untuk toleransi kesalahan dan kinerja yang lebih baik dalam aplikasi dunia nyata, penjadwalan pekerjaan harus diimplementasikan melalui antrian pesan (mis., RabbitMQ, AWS SQS, Azure Storage Queue).

## **Implementasi Terdistribusi Berdasarkan Amazon Web Services**

Proyek *BackgroundJobDemo.Aws* mengimplementasikan pemrosesan pekerjaan pada Amazon Web Services dan menunjukkan arsitektur terdistribusi yang dapat diskalakan secara horizontal. Ini mencakup komponen berikut:

- Aplikasi web - berinteraksi dengan pengguna dan menjadwalkan tugas ekspor PPTX-ke-PDF, dll.
- Pekerja - memproses ekspor (in-process, out-of-process, atau AWS Lambda).
- Antrian pesan - menyimpan tugas yang akan diproses (Amazon SQS).
- Penyimpanan berkas - menyimpan file yang diunggah dan diproses (Amazon S3).
- Penyimpanan key-value - melacak status pemrosesan tugas (Amazon DynamoDB).

Arsitektur terdistribusi tipikal bergantung pada [antrian pesan](https://aws.amazon.com/message-queue/): aplikasi web menempatkan tugas latar belakang ke dalam antrian; pekerja latar belakang mengambil tugas dari antrian dan melakukan pekerjaan yang diperlukan. Ini memisahkan komponen dan membuat pemrosesan asynchronous serta andal. Antrian menjamin pengiriman dan menggunakan *visibility timeout*: ketika satu pekerja mengambil pesan, pesan tersebut menjadi tidak terlihat oleh pekerja lain; hanya pekerja yang memproses yang menghapusnya setelah selesai. Jika pemrosesan tidak selesai dalam visibility timeout (mis., karena kegagalan atau masalah jaringan), pesan yang tidak diproses menjadi terlihat kembali.

Implementasi kami menggunakan [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS), sebuah antrian pesan yang dikelola sepenuhnya untuk mikroservis, sistem terdistribusi, dan aplikasi serverless.

Antrian pesan dimaksudkan untuk pesan ringan (mis., batas ukuran pesan SQS adalah 256 KB), sehingga sebuah pesan hanya harus berisi deskripsi tugas. Data berat (seperti file yang akan diproses) harus disimpan terpisah dan direferensikan dari pesan. [Amazon S3](https://aws.amazon.com/s3/) digunakan untuk menyimpan file yang diunggah dan diproses.

Penyimpanan key-value diperlukan untuk menyimpan dan mengambil hasil pekerjaan berdasarkan ID. Contoh ini menggunakan [Amazon DynamoDB](https://aws.amazon.com/dynamodb/), layanan basis data NoSQL yang cepat dan fleksibel.

Untuk menjalankan aplikasi demo dengan Amazon Web Services:

1. Di region AWS yang sama, buat dan konfigurasikan:
   1. antrian SQS,
   1. bucket S3,
   1. tabel DynamoDB.
1. Hubungkan aplikasi web ke layanan ini dengan memanggil *AddAws* dalam `Startup.ConfigureServices`, menyediakan URL antrian SQS, nama bucket S3, nama tabel DynamoDB, dan region AWS.

## **Referensi**

- [Praktik Terbaik Kinerja ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Unggah file di ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [ASP.NET Real-time dengan SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Antrian Pesan](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)