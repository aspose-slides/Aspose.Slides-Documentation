---
title: Menginstal Aspose.Slides untuk SharePoint
type: docs
weight: 10
url: /id/sharepoint/installing-aspose-slides-for-sharepoint/
---
{{% alert color="primary" %}} 

Aspose.Slides for SharePoint diunduh sebagai arsip Aspose.Slides.SharePoint.zip. Arsip tersebut berisi: 

- **Aspose.Slides.SharePoint.wsp**: File solusi SharePoint. Aspose.Slides for SharePoint dikemas sebagai solusi SharePoint untuk memudahkan aktivasi dan deaktivasi di seluruh farm server.
- **Aspose_LicenseAgreement.rtf**: Perjanjian lisensi pengguna akhir.
- **Setup.exe**: Program pemasangan.
- **Setup.exe.config**: File konfigurasi pemasangan.

{{% /alert %}} 
## **Proses Instalasi**
Sebelum menjalankan instalasi, program pemasangan memeriksa hal berikut: 

- WSS 3.0 atau MOSS 2007 terpasang.
- Pengguna memiliki izin untuk menginstal solusi SharePoint.
- Database SharePoint online.
- Layanan Administrasi WSS berjalan.
- Layanan Timer WSS berjalan.

Layanan Administrasi dan Timer WSS diperlukan karena beberapa tindakan pemasangan bergantung pada pekerjaan timer untuk menyebar ke semua server di farm server. 
### **Menjalankan Instalasi**
Untuk menginstal Aspose.Slides for SharePoint: 

1. Ekstrak zip Aspose.Slides.SharePoint ke drive lokal pada Server MOSS 7.0 atau WSS 3.0. 
2. Jalankan setup.exe dan ikuti petunjuk pada layar. 
   Program pemasangan melakukan tindakan berikut: 
   1. Memeriksa prasyarat instalasi. Pemasangan tidak akan dilanjutkan jika ada pemeriksaan yang gagal. 

      **Menjalankan pemeriksaan sistem** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. Menampilkan Perjanjian Lisensi Pengguna Akhir. Anda harus menyetujui perjanjian tersebut untuk melanjutkan. 

   **EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. Menampilkan pemilihan target penyebaran. Memilih aplikasi web dan koleksi situs yang akan diaktifkan fiturnya. 

   **Memilih target penyebaran** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. Menyebarkan fitur ke farm server. 

   **Bar kemajuan instalasi** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. Mengaktifkan Aspose.Slides untuk koleksi situs terpilih dan mengkonfigurasi aplikasi web induknya. 
7. Menampilkan daftar aplikasi web dan koleksi situs yang telah disebarkan dan diaktifkan fitur tersebut. 

   **Instalasi berhasil** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)