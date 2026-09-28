---
title: Persyaratan Sistem
type: docs
weight: 15
url: /id/reportingservices/system-requirements/
keywords:
- persyaratan sistem
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Periksa server laporan, edisi, dan versi .NET Framework apa yang dibutuhkan Aspose.Slides for Reporting Services sebelum Anda menginstalnya."
---
## **Gambaran Umum**

Aspose.Slides for Reporting Services berjalan di dalam server laporan sebagai ekstensi rendering. Halaman ini mencantumkan apa yang diperlukan mesin server laporan sebelum Anda [pasang](/slides/id/reportingservices/installing-aspose-slides-for-reporting-services/) itu. Microsoft PowerPoint dan Microsoft Office tidak diperlukan.

## **Server Laporan yang Didukung**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, for paginated (RDL) reports

Server laporan 32-bit dan 64-bit keduanya didukung. SQL Server 2005 menggunakan build ekstensi tersendiri; semua versi selanjutnya dan Power BI Report Server menggunakan build yang sama. [Instal Manual](/slides/id/reportingservices/install-manually/) menunjukkan file mana yang harus disalin.

Jika versi server laporan Anda tidak ada dalam daftar ini, tanyakan di [forum dukungan gratis](https://forum.aspose.com/c/slides/id/11) sebelum Anda melakukan penyebaran.

## **Edisi Server Laporan**

Untuk SQL Server 2016 Reporting Services dan versi berikutnya serta untuk Power BI Report Server, Microsoft mendukung ekstensi rendering pada edisi Enterprise, Standard, Developer, dan Evaluation; edisi Web dan Express tidak mendukungnya. Lihat [Fitur Reporting Services yang didukung oleh edisi](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Instalasi MSI melewatkan instance edisi Express dari SQL Server 2016 dan sebelumnya.

## **.NET Framework**

.NET Framework 3.5 harus diinstal pada mesin server laporan. Assembly ekstensi dibangun untuk runtime .NET Framework 2.0, dan instalasi MSI akan berhenti dengan pesan bila .NET Framework 3.5 tidak ada. Pada Windows Server, tambahkan **.NET Framework 3.5 Features** di Add Roles and Features Wizard; lihat [Instal .NET Framework 3.5 di Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Izin**

Menginstal ekstensi mengubah file di folder server laporan, sehingga kedua jalur instalasi memerlukan hak administrator lokal. Jika Anda memulai instalasi MSI tanpa hak tersebut, ia akan menawarkan untuk memulai ulang dengan hak administrator.

## **FAQ**

**Apakah saya memerlukan Microsoft PowerPoint pada server laporan?**

Tidak. Ekstensi membuat presentasi sendiri; baik PowerPoint maupun Microsoft Office tidak perlu diinstal.

**Dapatkah saya menginstal ekstensi pada edisi Express?**

Tidak. Edisi Express tidak mendukung ekstensi rendering. Instalasi MSI menyembunyikan instance Express dari SQL Server 2016 dan sebelumnya; pada versi yang lebih baru, jangan pilih instance Express.

**Format apa yang ditambahkan ekstensi ke daftar ekspor?**

PPT, PPS, PPTX, PPSX, ODP dan XPS. Lihat [Format File yang Didukung](/slides/id/reportingservices/supported-file-formats/).