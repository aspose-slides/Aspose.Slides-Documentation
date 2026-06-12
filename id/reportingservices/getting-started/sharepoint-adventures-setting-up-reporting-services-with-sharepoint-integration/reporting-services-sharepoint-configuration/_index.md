---
title: Konfigurasi Reporting Services SharePoint
type: docs
weight: 50
url: /id/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

Sekarang setelah SharePoint terpasang dan dikonfigurasi pada server RS serta RS telah diatur melalui Reporting Services Configuration Manager, kita dapat melanjutkan ke konfigurasi di Central Admin. RS 2008 R2 benar‑benar menyederhanakan proses ini. Dulu kami harus melakukan proses 3 langkah untuk membuatnya bekerja. Sekarang hanya ada satu langkah.  

Kita ingin pergi ke situs Central Administrator dan kemudian ke General Application Settings. Di bagian bawah kita akan melihat Reporting Services.  

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)

**Figure 17**: Gambar 17: Konfigurasi SharePoint 

{{% alert color="primary" %}} 

Klik pada **Reporting Services Integration**.  

{{% /alert %}} 
## **URL Layanan Web**
Kami akan menyediakan URL untuk Report Server yang kami temukan di Reporting Services Configuration Manager. 
## **Mode Otentikasi**
Kami juga akan memilih Mode Otentikasi. Tautan MSDN berikut menjelaskan secara detail apa itu. 
[Security Overview for Reporting Services in SharePoint Integrated Mode](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

Singkatnya, jika situs Anda menggunakan **Claims Authentication**, Anda akan selalu menggunakan Trusted Authentication terlepas dari apa yang Anda pilih di sini. Jika Anda ingin meneruskan kredensial Windows, pilih Windows Authentication. Untuk Trusted Authentication, kami akan meneruskan token SPUser dan tidak bergantung pada kredensial Windows.  

Anda juga akan ingin menggunakan Trusted Authentication jika Anda telah mengkonfigurasi situs Classic Mode Anda untuk NTLM dan RS diatur untuk NTLM. Kerberos diperlukan untuk menggunakan Windows Authentication dan meneruskannya ke sumber data Anda.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)

**Figure 18**: Gambar 18: Menyetel kredensial Integrasi Reporting Services 
## **Aktifkan Fitur**
Ini memberi Anda opsi untuk mengaktifkan Reporting Services pada semua koleksi situs, atau Anda dapat memilih koleksi mana yang ingin diaktifkan. Ini berarti situs mana yang dapat menggunakan Reporting Services. Setelah selesai, Anda akan melihat gambar berikut.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)

**Figure 19**: Gambar 19: Integrasi Reporting Services dengan lingkungan SharePoint berhasil 

Kembali ke URL Report Server seperti yang ditunjukkan pada Gambar 14, kita harus melihat sesuatu yang mirip dengan gambar berikut.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)

**Figure 20**: Gambar 20: Verifikasi Reporting Services dengan lingkungan SharePoint berhasil 

{{% alert color="primary" %}} 

Jika situs SharePoint Anda dikonfigurasi untuk SSL, itu tidak akan muncul dalam daftar ini. Ini adalah masalah yang diketahui dan tidak berarti ada masalah. Laporan Anda tetap akan berfungsi.  

{{% /alert %}} 

Sekarang, kami siap menggunakan Reporting Services di SharePoint 2010. Seperti versi sebelumnya, kami memiliki fitur (diaktifkan saat kami mengkonfigurasi Reporting Services Integration) di “Site Collection Feature”. Instalasi juga menambahkan 3 tipe konten ke situs kami. Pada Gambar 21 kami dapat melihat 2 tipe konten yang ditambahkan ke perpustakaan dokumen untuk membuat laporan kustom, seperti yang terlihat pada Gambar 21.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)

**Figure 21**: Gambar 21: Report Builder 

“**Reporter Builder**” adalah ActiveX yang perlu kami unduh pada server, seperti yang terlihat pada Gambar 22.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)

**Figure 22**: Gambar 22: Unduh dan Pasang Report Builder 

Setelah unduhan selesai, jalankan **“Report Builder”**. Sekarang kami siap merancang laporan pertama kami, seperti yang terlihat pada Gambar 23.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Figure 23**: Gambar 23: Wizard Pembuatan Laporan Baru Report Builder 

Setelah membuat laporan kami, kami dapat menyimpannya di perpustakaan dokumen yang dibuat untuk menempatkan laporan di SharePoint 2010 kami.  

Tipe konten lainnya harus digunakan untuk membuat koneksi bersama sebagai sumber data dan menyimpannya di perpustakaan dokumen di SharePoint. Kami dapat membuat perpustakaan dokumen, menambahkan tipe konten ini, dan kemudian koneksi kami tersedia untuk mengubah sumber data laporan.  

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)

**Figure 24**: Gambar 24: Ekspor laporan ke Report Server berhasil