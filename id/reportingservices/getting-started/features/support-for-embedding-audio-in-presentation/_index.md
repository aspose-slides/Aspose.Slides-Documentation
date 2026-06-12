---
title: Dukungan untuk Menyematkan Audio dalam Presentasi
type: docs
weight: 90
url: /id/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services tidak memiliki kemampuan bawaan untuk mengekspor laporan dengan audio tersemat ke presentasi PowerPoint. Aspose.Slides untuk Reporting Services versi 4.10 dan yang lebih baru mendukung penyematan audio di dalam presentasi yang diekspor. 

{{% /alert %}} 

Untuk menyematkan audio ke slide, silakan tambahkan kotak teks ke laporan dengan teks: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Berfungsi untuk versi SQL Server 2008 ke atas. Fitur ini hanya didukung untuk ekspor PPTX.