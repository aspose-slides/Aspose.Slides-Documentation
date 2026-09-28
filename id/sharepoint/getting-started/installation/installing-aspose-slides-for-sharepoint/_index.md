---
title: Menginstal Aspose.Slides untuk SharePoint
type: docs
weight: 10
url: /id/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Instal Aspose.Slides untuk SharePoint pada farm SharePoint: pilih program pemasangan untuk versi SharePoint Anda, jalankan pemeriksaan sistem, dan men-deploy serta mengaktifkan solusi."
---
## **Isi Paket**

Aspose.Slides for SharePoint diunduh dari [halaman unduhan](https://releases.aspose.com/slides/id/sharepoint/) sebagai arsip ZIP. Arsip tersebut berisi satu paket solusi SharePoint (WSP) dan satu program pemasangan untuk setiap versi SharePoint yang didukung:

| Versi SharePoint | Program pemasangan | Paket solusi |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Setiap program pemasangan memiliki file konfigurasi di sampingnya (misalnya, *Setup2019.exe.config*) yang menyebutkan paket solusi yang dipasang. Folder *License* berisi tautan ke perjanjian lisensi pengguna akhir dan pemberitahuan lisensi pihak ketiga.

Aspose.Slides for SharePoint dipaketkan sebagai solusi SharePoint, yang dideploy oleh SharePoint ke seluruh farm server. Fitur ini kemudian diaktifkan atau dinonaktifkan per koleksi situs.

## **Proses Instalasi**

Sebelum menginstal, program pemasangan menjalankan pemeriksaan sistem. Ia memverifikasi bahwa:

- SharePoint sudah terinstal di server.
- Pengguna saat ini memiliki izin untuk menginstal dan men-deploy solusi SharePoint.
- Layanan Administrasi SharePoint sudah berjalan.
- Layanan Timer SharePoint sudah berjalan.
- Paket solusi yang disebutkan dalam file konfigurasi ada.

Layanan Administrasi dan Timer diperlukan karena beberapa tindakan pemasangan dijalankan sebagai pekerjaan timer yang menyebarkan solusi ke semua server di farm.

### **Menjalankan Instalasi**

Untuk menginstal Aspose.Slides for SharePoint:

1. Ekstrak arsip ZIP ke drive lokal pada server di farm SharePoint.
2. Jalankan program pemasangan yang cocok dengan versi SharePoint Anda (lihat tabel di atas) dan ikuti petunjuk di layar. Program pemasangan:
   1. Menjalankan pemeriksaan sistem. Pemasangan tidak dilanjutkan jika ada pemeriksaan yang gagal.

      **Menjalankan pemeriksaan sistem**

      ![Layar Pemeriksaan Sistem dari program pemasangan](installing-aspose-slides-for-sharepoint_1.png)

   2. Menampilkan perjanjian lisensi pengguna akhir. Anda harus menyetujuinya untuk melanjutkan.

      **Perjanjian lisensi**

      ![Layar Perjanjian Lisensi dari program pemasangan](installing-aspose-slides-for-sharepoint_2.png)

   3. Menampilkan target deployment. Pilih aplikasi web dan koleksi situs untuk mengaktifkan fitur.

      **Memilih target deployment**

      ![Layar Target Deployment Koleksi Situs dari program pemasangan](installing-aspose-slides-for-sharepoint_3.png)

   4. Men-deploy solusi ke farm.

      **Progres instalasi**

      ![Layar Progres Instalasi dari program pemasangan](installing-aspose-slides-for-sharepoint_4.png)

   5. Mengaktifkan Aspose.Slides for SharePoint pada koleksi situs yang dipilih.
   6. Menampilkan aplikasi web dan koleksi situs tempat solusi telah dideploy dan diaktifkan.

      **Instalasi berhasil**

      ![Layar Instalasi Selesai dari program pemasangan](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
Tangkapan layar diambil pada SharePoint 2007. Program pemasangan untuk versi yang lebih baru melalui layar yang sama.
{{% /alert %}}

Jika versi yang sama dari Aspose.Slides for SharePoint sudah terinstal, program pemasangan menawarkan untuk memperbaiki atau menghapusnya. Jika versi lain terinstal, ia menawarkan untuk meningkatkan atau menghapusnya.

Setelah instalasi, item **Convert via Aspose.Slides** muncul di menu file pada pustaka dokumen koleksi situs yang dipilih (pada SharePoint 2007, **Convert with Aspose.Slides**). Untuk mengonversi presentasi pertama, lihat [Mengonversi Dokumen Microsoft PowerPoint ke Format Lain](/slides/id/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). Apa yang ditambahkan solusi ke farm dijelaskan di [Deployment and Activation](/slides/id/sharepoint/deployment-and-activation/).

## **FAQ**

**Program pemasangan mana yang harus saya jalankan?**

Program yang namanya sesuai dengan versi SharePoint Anda. Misalnya, jalankan *Setup2016.exe* pada farm SharePoint Server 2016. Setiap program pemasangan hanya menginstal paket solusi miliknya.

**Apakah saya memerlukan unduhan terpisah untuk versi berlisensi?**

Tidak. Paket yang sama berfungsi dalam mode evaluasi hingga Anda menginstal solusi lisensi; lihat [Installing Aspose.Slides for SharePoint License](/slides/id/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**Bagaimana cara menghapus produk?**

Jalankan kembali program pemasangan yang sama dan pilih **Remove**; lihat [Uninstalling Aspose.Slides for SharePoint](/slides/id/sharepoint/uninstalling-aspose-slides-for-sharepoint/).