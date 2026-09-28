---
title: Penyebaran dan Aktivasi
type: docs
weight: 20
url: /id/sharepoint/deployment-and-activation/
description: "Apa yang diinstal oleh solusi Aspose.Slides for SharePoint pada farm ketika disebarkan, dan apa yang ditambahkan oleh fitur koleksi situsnya ketika diaktifkan."
---
## **Penyebaran**

- Menginstal assembly‑nya ke Global Assembly Cache dan menambahkan entri SafeControl ke file **web.config**. Pada SharePoint 2010 dan yang lebih baru, ini adalah *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* atau *Aspose.Slides.SharePoint2016.dll* (paket SharePoint 2019 juga menginstal *Aspose.Slides.SharePoint2016.dll*). Pada SharePoint 2007, ini adalah *Aspose.Slides.SharePointUI.dll*, bersama dengan *Aspose.Slides.SharePoint.Deployment.dll*.
- Menyalin halaman konversi serta gambar dan file pendukung lainnya ke folder instalasi SharePoint.
- Menginstal fitur dan membuatnya tersedia untuk diaktifkan pada koleksi situs.

## **Aktivasi**

Aspose.Slides for SharePoint dikemas sebagai fitur koleksi situs dan dapat diaktifkan atau dinonaktifkan pada koleksi situs. Ketika diaktifkan pada sebuah koleksi situs, fitur tersebut menambahkan:

- Pada SharePoint 2010 dan yang lebih baru:
  - item **Convert via Aspose.Slides** ke menu dokumen di perpustakaan dokumen;
  - tab pita **Aspose Tools** dengan tombol **Convert Slides**, yang mengonversi dokumen yang dipilih;
  - item **View Slides** ke menu file PPT, PPTX, PPS, dan PPSX.
- Pada SharePoint 2007:
  - item **Convert with Aspose.Slides** ke menu dokumen di perpustakaan dokumen;
  - item **Convert All with Aspose.Slides** ke menu **Actions** di perpustakaan dokumen.

Pada SharePoint 2007, aktivasi juga melakukan perubahan pada direktori virtual dari aplikasi web induk koleksi situs. Ini:
- Menambahkan halaman pengaturan konversi ke file sitemap.
- Menyalin file sumber daya yang diperlukan ke folder App_GlobalResources di direktori virtual.

Program pengaturan mengaktifkan fitur pada koleksi situs yang Anda pilih selama [instalasi](/slides/id/sharepoint/installing-aspose-slides-for-sharepoint/).