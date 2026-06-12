---
title: Prasyarat Instalasi
type: docs
weight: 20
url: /id/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 

Prasyarat berikut harus dipenuhi sebelum kita melanjutkan instalasi. 

{{% /alert %}} 
## **Reporting Services Add‑In untuk SharePoint**
**Reporting Services Add‑In untuk SharePoint** adalah salah satu komponen kunci agar Integrasi berfungsi dengan baik. Add‑In harus dipasang pada salah satu **Web Front Ends (WFE)** yang berada di farm SharePoint Anda bersama dengan server Central Admin. Salah satu perubahan baru pada SQL 2008 R2 & SharePoint 2010 adalah Add‑In 2008 R2 kini menjadi prasyarat untuk instalasi SharePoint. Ini berarti RS Add‑In akan dipasang secara otomatis ketika Anda menginstal SharePoint. Hal ini telah ditunjukkan dan disorot pada gambar di bawah. Pendekatan ini sebenarnya menghindari banyak masalah yang kami temui pada SP 2007 dan RS 2008 saat memasang Add‑In. 

![todo:image_alt_text](installation-prerequisites_1.png)


**Gambar 1**: Reporting Services Add‑In untuk SharePoint 
## **Autentikasi SharePoint**
Sebelum masuk ke bagian‑bagian Integrasi RS, satu hal yang penting dan harus diperhatikan adalah cara Anda menyiapkan **Situs** di farm SharePoint. Secara khusus, bagaimana Anda mengonfigurasi autentikasi untuk situs; apakah akan memakai **Klasik** atau **Claims**. Pilihan ini penting sejak awal. Saya tidak yakin bahwa opsi ini dapat diubah setelah selesai. Jika dapat diubah, prosesnya tidak akan sederhana. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 TIDAK mendukung Claims 

{{% /alert %}} 

Bahkan jika Anda memilih situs SharePoint Anda menggunakan **Claims**, Reporting Services itu sendiri tidak mendukung Claims. Hal ini memengaruhi cara autentikasi bekerja dengan Reporting Services. Jadi, apa perbedaannya dari perspektif Reporting Services? Itu tergantung pada apakah Anda ingin meneruskan Kredensial Pengguna ke sumber data. 

***Classic*** - Dapat menggunakan Kerberos dan meneruskan kredensial pengguna ke sumber data backend Anda (akan membutuhkan Kerberos untuk itu). 

***Claims*** - Token Claims digunakan, bukan token Windows. RS akan selalu menggunakan Trusted Authentication dalam skenario ini dan hanya akan memiliki akses ke token SPUser. Anda perlu menyimpan kredensial Anda di dalam sumber data. 

Untuk saat ini, kami hanya ingin fokus pada penyiapan RS. Pada titik ini SharePoint sudah terpasang di SharePoint Box dan dikonfigurasi dengan **Situs Auth Klasik** pada **port 80**. Selain itu, di server RS saya **baru saja memasang Reporting Services** dan selesai.