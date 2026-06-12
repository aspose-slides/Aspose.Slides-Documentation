---
title: Dukungan untuk Menyematkan Video dalam Presentasi
type: docs
weight: 80
url: /id/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services tidak memiliki kemampuan bawaan untuk mengekspor laporan dengan video tersemat ke presentasi PowerPoint. Aspose.Slides for Reporting Services versi 4.10 dan setelahnya mendukung penyematan video di dalam presentasi. 

{{% /alert %}} 

Untuk menyematkan video ke slide, silakan tambahkan kotak teks dengan teks berikut ke dalam laporan: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Berfungsi untuk versi SQL Server 2008 dan yang lebih baru. Fitur ini hanya didukung untuk ekspor PPTX.