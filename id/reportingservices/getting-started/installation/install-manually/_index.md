---
title: Instal Secara Manual
type: docs
weight: 30
url: /id/reportingservices/install-manually/
keywords:
- instalasi manual
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Instal Aspose.Slides for Reporting Services secara manual dari paket ZIP hanya berisi DLL: assembly mana yang harus disalin, dan apa yang harus ditambahkan ke rsreportserver.config dan rssrvpolicy.config."
---
## **Ikhtisar**

Ikuti langkah-langkah berikut untuk menginstal Aspose.Slides for Reporting Services tanpa installer MSI, dari paket ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* pada [halaman unduhan](https://releases.aspose.com/slides/id/reportingservices/). Mereka mendaftar ekstensi yang sama seperti [installer MSI](/slides/id/reportingservices/install-with-msi-installer/). Ulangi langkah tersebut untuk setiap instance server laporan.

Sebelum memulai, periksa [persyaratan sistem](/slides/id/reportingservices/system-requirements/). Anda memerlukan hak administrator lokal pada server laporan.

## **Pilih Assembly**

Paket ZIP berisi beberapa build. Salin tepat satu *Aspose.Slides.ReportingServices.dll* ke server laporan:

| File dalam paket ZIP | Gunakan untuk |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 ke atas Reporting Services, dan Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Bukan untuk server laporan: aplikasi yang mengekspor dari kontrol ReportViewer 2010 atau 2012, lihat [Menggunakan Aspose.Slides dengan ReportViewer 2010 dan 2012](/slides/id/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Opsional: menyimpan laporan dalam format RPL untuk laporan masalah, lihat [Mengekspor Laporan ke Format RPL](/slides/id/reportingservices/exporting-reports-to-rpl-format/) |

## **Temukan Folder Server Laporan**

Langkah-langkah di bawah ini mengacu pada folder *ReportServer* milik server laporan, yang berisi *rsreportserver.config* dan *rssrvpolicy.config*. Pada instalasi default, lokasinya adalah:

| Server laporan | Folder *ReportServer* default |
| :- | :- |
| SQL Server 2017 dan seterusnya Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 dan sebelumnya Reporting Services | `C:\Program Files\Microsoft SQL Server\<folder instance>\Reporting Services\ReportServer`, di mana folder instance adalah, misalnya, `MSRS13.MSSQLSERVER` untuk SQL Server 2016 atau `MSSQL.x` untuk SQL Server 2005 |

Untuk lokasi lainnya, lihat artikel [file konfigurasi RsReportServer.config](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Instal Ekstensi**

1. Salin assembly yang Anda pilih ke subfolder *bin* dari folder *ReportServer*.

   File yang disalin tidak boleh memiliki izin NTFS yang ditetapkan secara eksplisit, atau server laporan akan ditolak akses ketika memuat assembly dan format ekspor baru tidak muncul. Klik kanan file, pilih **Properties**, dan pada tab **Security** hapus semua izin yang ditetapkan secara eksplisit, biarkan hanya yang diwariskan. Jika pada tab **General** terdapat opsi **Unblock**, pilih opsi tersebut.

2. Simpan salinan *rsreportserver.config*, lalu buka file tersebut di editor teks. Tambahkan entri berikut di dalam elemen `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Setiap entri mendaftarkan satu format ekspor; `Name` harus unik di antara ekstensi rendering. Installer MSI mendaftarkan enam nama dan tipe yang sama. Hapus entri jika Anda tidak menginginkan format tersebut muncul di daftar ekspor.

3. Simpan salinan *rssrvpolicy.config*, lalu buka file tersebut di editor teks. Temukan grup kode yang `Description`‑nya adalah "This code group grants MyComputer code Execution permission." dan tambahkan grup kode ini sebagai anak terakhirnya:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` adalah kunci publik dari assembly Aspose.Slides.ReportingServices. Simpan dalam satu baris.

4. Simpan kedua file. Server laporan akan membaca kembali file konfigurasi setiap kali file disimpan. Jika sebuah file berisi XML yang tidak valid, server laporan akan mengabaikannya atau tidak dapat memulai, sehingga pulihkan salinan Anda jika terjadi masalah.

## **Periksa Instalasi**

Buka laporan berhalaman di portal web (Report Manager pada SQL Server 2014 dan sebelumnya) dan buka daftar **Export**. Sekarang daftar tersebut mencakup format berikut:

- PPT - Presentasi PowerPoint via Aspose.Slides
- PPS - SlideShow PowerPoint via Aspose.Slides
- PPTX - Presentasi PowerPoint 2007 via Aspose.Slides
- PPSX - SlideShow PowerPoint 2007 via Aspose.Slides
- ODP - Presentasi OpenDocument via Aspose.Slides
- XPS - via Aspose.Slides

Pilih salah satu untuk mengekspor laporan. File akan dibuka di aplikasi yang terkait dengan formatnya.

![Laporan diekspor ke PowerPoint oleh Aspose.Slides for Reporting Services](install-manually_2.png)

Jika format tidak muncul, periksa izin NTFS pada assembly yang disalin. Tanpa lisensi, file yang diekspor akan memiliki watermark evaluasi; lihat [Lisensi](/slides/id/reportingservices/license-aspose-slides-for-reporting-services/).