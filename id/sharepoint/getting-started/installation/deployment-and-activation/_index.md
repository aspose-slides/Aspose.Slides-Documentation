---
title: Penyebaran dan Aktivasi
type: docs
weight: 20
url: /id/sharepoint/deployment-and-activation/
---
## **Penyebaran**
Selama penyebaran, Aspose.Slides for SharePoint: 

- Menginstal **Aspose.Slides.SharePoint.dll** ke Global Assembly Cache dan menambahkan entri SafeControl ke file **web.config**.
- Menginstal manifes fitur dan file lain yang diperlukan ke direktori yang sesuai.
- Mendaftarkan fitur di basis data SharePoint dan membuatnya tersedia untuk aktivasi pada ruang lingkup fitur.
## **Aktivasi**
Aspose.Slides for SharePoint dikemas sebagai fitur tingkat situs (koleksi situs) dan dapat diaktifkan atau dinonaktifkan pada koleksi situs. Selama aktivasi, fitur ini membuat beberapa perubahan pada direktori virtual aplikasi web induk dari koleksi situs. Itu: 

- Menambahkan halaman pengaturan konversi ke file sitemap.
- Menyalin file sumber daya yang diperlukan ke folder App_GlobalResources di direktori virtual.